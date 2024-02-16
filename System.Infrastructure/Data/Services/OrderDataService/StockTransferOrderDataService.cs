using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Exceptions;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public partial class OrderDataService
    {
        public async Task<List<Order>> GetStockTransferOrdersAsync(int organizationId) =>
            await GetOrdersByOrderTypeAsync(organizationId: organizationId, orderType: OrderType.ST);

        public async Task<List<Order>> SearchStockTransferOrdersAsync(int organizationId, string searchText) =>
            await _orderRepository.SearchOrdersAsync(organizationId: organizationId, orderType: OrderType.ST, searchText: searchText);

        public async Task<Order> QuickCreateStockTransferOrderAsync(int organizationId, int userId)
        {
            var lastOrder = await _orderRepository.GetLastOrderOfThisTypeAsync(organizationId: organizationId, orderType: OrderType.ST);
            var orderNumber = 1;
            if (lastOrder != null) orderNumber = lastOrder.OrderNumberInt + orderNumber;

            var stockTransferOrder = Order.NewStockTransferOrder(organizationId: organizationId,
                userId: userId,
                orderNumber: $"{orderNumber}",
                status: OrderStatus.Open,
                orderDate: DateTime.Now);

            await ScrutinateUserPrivilegeAsync(order: stockTransferOrder, userId: userId);

            await SaveManyAsync(entities: new List<Order>() { stockTransferOrder }, userId: userId);

            return stockTransferOrder;
        }

        public async Task ApproveStockTransfer(Order order, int userId)
        {
            await ScrutinateUserPrivilegeAsync(order, userId);

            if (order.IsStockTransferType && (order?.IsStatusApproved ?? false)) BusinessLogicException.Throw(message: "Stock Transfer already `Approved`");

            if (order.StockTransferFromInventoryLocationId == null ||
                order.StockTransferToInventoryLocationId == null) BusinessLogicException.Throw(message: "Invalid Inventory Location value.");

            if (order.HasNewMovementHistories) await SaveChangesAsync(order, userId);

            var pilIds = order.MovementHistories
                .Select(t => t.ProductInventoryLocationIDA.Value)
                .ToArray();
            var productInventoryLocations = await _productInventoryLocationDataService.GetManyByIdsAsync(pilIds);

            foreach (var movementHistory in order.MovementHistories)
            {
                var productInventoryLocation = productInventoryLocations.FirstOrDefault(x => x.RowID == movementHistory.ProductInventoryLocationIDA);
                if (movementHistory == null) continue;

                var quantity = (productInventoryLocation.TotalAvailableQty ?? 0) + movementHistory.FormulatedQtyToApply;
                productInventoryLocation.TotalAvailableQty = quantity;
                productInventoryLocation.RackShelfColumn.AvailableQty = quantity;
            }

            await _productInventoryLocationDataService.SaveManyAsync(userId: userId, updated: productInventoryLocations.ToList());

            order.SetApproveStockTransfer();

            await SaveManyAsync(entities: new List<Order>() { order }, userId: userId);
        }

        private void StockTransferRecordUpdate(Order entity, Order oldEntity, List<UserActivityItem> userActivityItems)
        {
            if (!oldEntity.IsStockTransferType) return;

            var suffix = $" of Stock Transfer #{entity.OrderNumber}";

            if (entity.OrderDate != oldEntity.OrderDate)
            {
                userActivityItems.Add(UserActivityItem.NewUserActivityItem(entityId: oldEntity.RowID.Value,
                    description: $"Change `Stock Transfer Date` from '{oldEntity.OrderDate.Value.Date.ToShortDateString()}' to '{entity.OrderDate.Value.Date.ToShortDateString()}'{suffix}",
                    changedUserId: entity.LastUpdBy.Value));
            }

            if (entity.Comments != oldEntity.Comments)
            {
                userActivityItems.Add(UserActivityItem.NewUserActivityItem(entityId: oldEntity.RowID.Value,
                    description: $"Change `Comments` from '{oldEntity.Comments}' to '{entity.Comments}'{suffix}",
                    changedUserId: entity.LastUpdBy.Value));
            }
        }
    }
}