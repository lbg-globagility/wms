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
        public async Task<List<Order>> GetStockAdjustmentOrdersAsync(int organizationId) =>
            await GetOrdersByOrderTypeAsync(organizationId: organizationId, orderType: OrderType.SA);

        public async Task<List<Order>> SearchStockAdjustmentOrdersAsync(int organizationId, string searchText) =>
            await _orderRepository.SearchOrdersAsync(organizationId: organizationId, orderType: OrderType.SA, searchText: searchText);

        public async Task<Order> QuickCreateStockAdjustmentOrderAsync(int organizationId, int userId)
        {
            var lastOrder = await _orderRepository.GetLastOrderOfThisTypeAsync(organizationId: organizationId, orderType: OrderType.SA);
            var orderNumber = 1;
            if (lastOrder != null) orderNumber = lastOrder.OrderNumberInt + orderNumber;

            var stockAdjustmentOrder = Order.NewStockAdjustmentOrder(organizationId: organizationId,
                userId: userId,
                orderNumber: $"{orderNumber}",
                status: OrderStatus.Open,
                orderDate: DateTime.Now);

            await SaveManyAsync(entities: new List<Order>() { stockAdjustmentOrder }, userId: userId);

            return stockAdjustmentOrder;
        }

        public async Task ApproveStockAdjustment(Order order, int userId)
        {
            await ScrutinateUserPrivilegeAsync(order, userId);

            if (order.IsStockTransferType && (order?.IsApproved ?? false)) BusinessLogicException.Throw(message: "Stock Adjustment already `Approved`");

            if (order.StockTransferFromInventoryLocationId == null ||
                order.StockTransferToInventoryLocationId == null) BusinessLogicException.Throw(message: "Invalid Invetory Location value.");

            if (order.HasNewMovementHistories) await SaveChangesAsync(order, userId);

            var pilIds = order.MovementHistories
                .Select(t => t.ProductInventoryLocationIDA.Value)
                .ToArray();
            var productInventoryLocations = await _productInventoryLocationRepository.GetManyByIdsAsync(pilIds);

            foreach (var movementHistory in order.MovementHistories)
            {
                var productInventoryLocation = productInventoryLocations.FirstOrDefault(x => x.RowID == movementHistory.ProductInventoryLocationIDA);
                if (movementHistory == null) continue;
                productInventoryLocation.TotalAvailableQty = (productInventoryLocation.TotalAvailableQty ?? 0) + movementHistory.FormulatedQtyToApply;
            }

            await _productInventoryLocationRepository.SaveManyAsync(updated: productInventoryLocations.ToList());

            order.SetApproveStockTransfer();

            await SaveManyAsync(entities: new List<Order>() { order }, userId: userId);
        }

        private void StockAdjustmentRecordUpdate(Order entity, Order oldEntity, List<UserActivityItem> userActivityItems)
        {
            if (!oldEntity.IsStockAdjustType) return;

            var suffix = $" of Stock Adjustment #{entity.OrderNumber}";

            if (entity.OrderDate != oldEntity.OrderDate)
            {
                userActivityItems.Add(UserActivityItem.NewUserActivityItem(entityId: oldEntity.RowID.Value,
                    description: $"Change `Stock Adjustment Date` from '{oldEntity.OrderDate.Value.Date.ToShortDateString()}' to '{entity.OrderDate.Value.Date.ToShortDateString()}'{suffix}",
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