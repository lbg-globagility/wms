using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
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

        public async Task SaveManyCustomerOrderAsync(int userId,
            List<Order> added = null,
            List<Order> updated = null,
            List<Order> deleted = null)
        {
            if (added != null)
            {
                var addedOrderItems = new List<OrderItem>();
                var updatedOrderItems = new List<OrderItem>();

                added.ForEach(o =>
                {
                    if (o.OrderItems != null)
                    {
                        o.OrderItems.ToList().ForEach(oi =>
                        {
                            oi.Order = null;
                            oi.ProductColorSize = null;
                            oi.ProductInventoryLocation = null;
                            oi.RackShelfColumn = null;

                            if (oi.IsNewEntity)
                            {
                                oi.OrderID = o.RowID.Value;
                                // _context.Entry(oi).State = EntityState.Added;
                                addedOrderItems.Add(oi);
                            }
                            else if (!oi.IsNewEntity)
                            {
                                // _context.Entry(oi).State = EntityState.Modified;
                                updatedOrderItems.Add(oi);
                            }
                        });
                    }
                });

                await _orderItemDataService.SaveManyAsync(userId: userId, added: addedOrderItems, updated: updatedOrderItems);
            }

            if (updated != null)
            {
                var addedOrderItems = new List<OrderItem>();
                var updatedOrderItems = new List<OrderItem>();

                updated.ForEach(o =>
                {
                    o.PackingList = null;
                    o.Customer = null;
                    o.Customer = null;
                    o.InventoryLocation = null;

                    if (o.OrderItems != null)
                    {
                        o.OrderItems.ToList().ForEach(oi =>
                        {
                            oi.Order = null;
                            oi.ProductColorSize = null;
                            oi.ProductInventoryLocation = null;
                            oi.RackShelfColumn = null;

                            if (oi.IsNewEntity)
                            {
                                oi.OrderID = o.RowID.Value;
                                // _context.Entry(oi).State = EntityState.Added;
                                addedOrderItems.Add(oi);
                            }
                            else if (!oi.IsNewEntity)
                            {
                                // _context.Entry(oi).State = EntityState.Modified;
                                updatedOrderItems.Add(oi);
                            }
                        });
                    }
                });

                await _orderItemDataService.SaveManyAsync(userId: userId, added: addedOrderItems, updated: updatedOrderItems);
            }

            if (deleted != null)
            {
                var deletedOrderItems = new List<OrderItem>();

                deleted.ForEach(o =>
                {
                    if (o.OrderItems != null)
                    {
                        var orderItems = o.OrderItems.Where(oi => oi.IsNewEntity).ToList();
                        orderItems.ForEach(oi =>
                        {
                            o.OrderItems.Remove(oi);
                        });

                        var notNeworderItems = o.OrderItems.Where(oi => !oi.IsNewEntity).ToList();
                        notNeworderItems.ForEach(oi =>
                        {
                            deletedOrderItems.Add(oi);
                        });

                    }
                });

                await _orderItemDataService.SaveManyAsync(userId: userId, deleted: deletedOrderItems);
            }

            await SaveManyAsync(userId: userId,
                added: added,
                updated: updated,
                deleted: deleted);
        }
    }
}