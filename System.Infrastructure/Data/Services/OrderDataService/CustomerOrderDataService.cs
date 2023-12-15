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
        public async Task<List<Order>> GetCustomerOrdersAsync(int organizationId) =>
            await GetOrdersByOrderTypeAsync(organizationId: organizationId, orderType: OrderType.CO);

        public async Task<List<Order>> SearchCustomerOrdersAsync(int organizationId, string searchText) =>
            await _orderRepository.SearchOrdersAsync(organizationId: organizationId, orderType: OrderType.CO, searchText: searchText);

        public async Task<Order> QuickCreateCustomerOrderAsync(int organizationId, int userId)
        {
            var lastOrder = await _orderRepository.GetLastOrderOfThisTypeAsync(organizationId: organizationId,
                orderType: OrderType.CO);

            var orderNumber = 1;
            if (lastOrder != null) orderNumber = lastOrder.OrderNumberInt + orderNumber;

            var customerOrder = Order.NewCustomerOrder(organizationId: organizationId,
                userId: userId,
                orderNumber: $"{orderNumber}",
                status: OrderStatus.Open,
                orderDate: DateTime.Now);

            await SaveManyAsync(entities: new List<Order>() { customerOrder }, userId: userId);

            return customerOrder;
        }

        public async Task ApproveCustomerOrder(Order order, int userId)
        {
            await ScrutinateUserPrivilegeAsync(order, userId);

            if (order.IsCustomerOrderType && (order?.IsApproved ?? false)) BusinessLogicException.Throw(message: "Customer Order already `Approved`");

            if (order.InventoryLocationID == null) BusinessLogicException.Throw(message: "Invalid Invetory Location value.");

            order.SetSubmittedToWarehouseCustomerOrder();

            await SaveManyAsync(entities: new List<Order>() { order }, userId: userId);
        }

        private void CustomerOrderRecordUpdate(Order entity, Order oldEntity, List<UserActivityItem> userActivityItems)
        {
            if (!oldEntity.IsCustomerOrderType) return;

            var suffix = $" of Customer Order #{entity.OrderNumber}";

            if (entity.OrderDate != oldEntity.OrderDate)
            {
                userActivityItems.Add(UserActivityItem.NewUserActivityItem(entityId: oldEntity.RowID.Value,
                    description: $"Change `Customer Order Date` from '{oldEntity.OrderDate.Value.Date.ToShortDateString()}' to '{entity.OrderDate.Value.Date.ToShortDateString()}'{suffix}",
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