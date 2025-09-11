using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Exceptions;
using WarehouseManagementSystem.Core.Helpers;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public partial class OrderDataService
    {
        public async Task<List<Order>> GetCustomerOrdersAsync(int organizationId) =>
            await GetOrdersByOrderTypeAsync(organizationId: organizationId, orderType: OrderType.CO);

        public async Task<PaginatedList<Order>> GetCustomerOrdersAsync(int organizationId, PageOptions pageOptions, string searchText = "") =>
            await _orderRepository.GetOrdersByOrderTypeAsync(pageOptions: pageOptions, organizationId: organizationId, orderType: OrderType.CO, searchText: searchText);

        public async Task<Order> GetCustomerOrderAsync(int primaryKey) =>
            await _orderRepository.GetOrderByOrderTypeAsync(id: primaryKey, orderType: OrderType.CO);

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
                status: OrderStatus.New,
                orderDate: DateTime.Now);

            await ScrutinateUserPrivilegeAsync(order: customerOrder, userId: userId);

            await SaveManyAsync(entities: new List<Order>() { customerOrder }, userId: userId);

            return customerOrder;
        }

        public async Task ApproveCustomerOrder(Order order, int userId)
        {
            if (order == null) return;

            await ScrutinateUserPrivilegeAsync(order, userId);

            CustomerOrderValidation(order);

            order.SetSubmittedToWarehouseCustomerOrder();

            if ((order.RowID ?? 0) > 0)
            {
                var originOrder = await _orderRepository.GetByIdAsync(order.RowID.Value);
                if (!(originOrder.IsStatusNew && order.IsStatusSubmittedToWarehouse))
                {
                    order.Status = originOrder.Status;
                    BusinessLogicException.Throw(message: "Customer Order cannot be `SENT TO WAREHOUSE` anymore.");
                }
            }

            await SaveManyAsync(entities: new List<Order>() { order }, userId: userId);
        }

        public async Task RevokeCustomerOrder(Order order, int userId)
        {
            if (order == null) return;

            await ScrutinateUserPrivilegeAsync(order, userId);

            CustomerOrderValidation(order);

            await RevokeLineUpDeliveryAsync(order, userId);

            order.SetCancelledCustomerOrder();

            //if ((order.RowID ?? 0) > 0)
            //{
            //    var originOrder = await _orderRepository.GetByIdAsync(order.RowID.Value);
            //    if ((!(!originOrder.IsStatusCancelled && order.IsStatusCancelled)) // when cancelling an already cancelled order
            //        || (originOrder.IsStatusDelivery && order.IsStatusCancelled)) // when cancelling a confirmed delivered transaction
            //    {
            //        order.Status = originOrder.Status;
            //        BusinessLogicException.Throw(message: "Customer Order cannot be `CANCELLED` anymore.");
            //    }
            //}

            await SaveManyAsync(entities: new List<Order>() { order }, userId: userId);
        }

        private async Task RevokeLineUpDeliveryAsync(Order order, int userId)
        {
            var orderId = order.RowID.Value;

            var lineups = await _lineupRepository.GetManyByOrderIdAsync(orderId);
            var hasLineups = lineups?.Where(t => !t.IsCancelled)?.Any(t => t.LineupCartons?.Any(x => x.PackingListCarton.PackingListCartonItems?.Any() ?? false) ?? false) ?? false;

            if (hasLineups)
            {
                foreach (var lineup in lineups)
                {
                    var pcsIdsAndinvIds = new List<(int pcsId, int invId)>();
                    foreach (var item1 in lineup.LineupCartons)
                    {
                        var packingListCartonItems = item1.PackingListCarton.PackingListCartonItems;
                        if (!(packingListCartonItems?.Any() ?? false))
                            continue;

                        foreach (var packingListCartonItem in packingListCartonItems)
                            pcsIdsAndinvIds.Add((pcsId: packingListCartonItem.OrderItem.ProductColorSizeID.Value, invId: packingListCartonItem.OrderItem.ProductInventoryLocation.RackShelfColumn.InventoryLocationID));
                    }

                    var productInventoryLocations = await _productInventoryLocationDataService.GetByProductColorSizeIdsAndInventoryLocationIdsAsync(
                        organizationId: lineup.OrganizationID ?? 0,
                        userId: userId,
                        productColorSizeIdsAndInventoryIds: pcsIdsAndinvIds);

                    var updatedProductInventoryLocations = new List<ProductInventoryLocation>();
                    var orderItemIds = new List<int?>();
                    foreach (var lineupCarton in lineup.LineupCartons)
                    {
                        var packingListCartonItems = lineupCarton.PackingListCarton.PackingListCartonItems;
                        if (!packingListCartonItems.Any())
                            continue;

                        foreach (var packingListCartonItem in packingListCartonItems)
                        {
                            var productColorSizeId = packingListCartonItem.OrderItem.ProductColorSizeID.Value;
                            orderItemIds.Add(packingListCartonItem.OrderItem.RowID);
                            var productInventoryLocation = productInventoryLocations
                                .Where(t => t.ProductColorSizeID == productColorSizeId)
                                //.Where(t => (t.TotalReserveQty ?? 0) > 0 && (t.TotalReserveQty ?? 0) >= (packingListCartonItem.QtyInCarton ?? 0))
                                .FirstOrDefault();

                            if (productInventoryLocation == null)
                                continue;

                            var qty = packingListCartonItem?.OrderItem?.QtyOrdered ?? packingListCartonItem.QtyInCarton ?? 0;

                            if (lineup.IsConfirmedDelivery)
                                productInventoryLocation.TotalAvailableQty += qty;

                            updatedProductInventoryLocations.Add(productInventoryLocation);
                        }
                    }

                    var packingList = await _packingListRepository.GetByOrderIdAsync(lineup.OrderID.Value);
                    if (!packingList.IsCancelled)
                    {
                        packingList.SetStatusToCancelled();
                        packingList.AuditUser(userId);
                        await _packingListRepository.SaveManyAsync(updated: new List<PackingList>() { packingList });
                    }

                    var pickListOrders = await _pickListOrderRepository.GetManyByOrderIdAsync(lineup.OrderID.Value);
                    var updatedPickListOrders = new List<PickListOrder>();
                    foreach (var pickListOrder in pickListOrders
                        .Where(t => !t.PickList.IsStatusCancelled)
                        .Where(t => !t.IsCancelledStatus)
                        .Where(t => !t.IsInactiveStatus)
                        .Where(t => orderItemIds.Contains(t.OrderItemID)))
                    {
                        pickListOrder.SetStatusToCancelled();
                        pickListOrder.AuditUser(userId);
                        updatedPickListOrders.Add(pickListOrder);
                    }
                    await _pickListOrderRepository.SaveManyAsync(updated: updatedPickListOrders);

                    lineup.SetStatusToCancelled();
                    lineup.AuditUser(userId);
                    await _lineupRepository.SaveManyAsync(new List<Lineup>() { lineup });

                    await _productInventoryLocationDataService.SaveManyAsync(userId: userId, updated: updatedProductInventoryLocations);
                }
            }
            else
            {
                var orderItemIds = order.OrderItems.Select(t => t.RowID).ToArray();
                var pickListOrders = (await _pickListOrderRepository.GetManyByOrderIdAsync(orderId))
                    .Where(t => !t.PickList.IsStatusCancelled)
                    .Where(t => !t.IsCancelledStatus)
                    .Where(t => orderItemIds.Contains(t.OrderItemID))
                    .ToList();

                if (!hasLineups && (pickListOrders?.Any() ?? false))
                {
                    var orderItems = (await _orderItemDataService.GetByOrderIdAsync(orderId))
                        .Where(t => pickListOrders?.Any(x => x.OrderItemID == t.RowID) ?? false)
                        .ToList();

                    var pcsIdsAndinvIds = new List<(int pcsId, int invId)>();
                    orderItems.ForEach(t =>
                    {
                        var fsdaf = t.ProductInventoryLocation;
                        pcsIdsAndinvIds.Add((fsdaf.ProductColorSizeID, fsdaf.RackShelfColumn.InventoryLocationID));
                    });

                    var productInventoryLocations = await _productInventoryLocationDataService.GetByProductColorSizeIdsAndInventoryLocationIdsAsync(
                        organizationId: order.OrganizationID ?? 0,
                        userId: userId,
                        productColorSizeIdsAndInventoryIds: pcsIdsAndinvIds);

                    var updatedProductInventoryLocations = new List<ProductInventoryLocation>();
                    foreach (var productInventoryLocation in productInventoryLocations)
                    {
                        var orderItem = orderItems.FirstOrDefault(t => t.ProductInventoryLocationId == productInventoryLocation.RowID);
                        if (orderItem == null) continue;
                        var qty = orderItem?.QtyOrdered ?? 0;

                        var picklistOrder = pickListOrders?.FirstOrDefault(t => t.OrderItemID == (orderItem?.RowID ?? 0));
                        if ((picklistOrder?.IsVerifiedStatus ?? false) && (picklistOrder?.PickListOrderItem?.IsVerified ?? false))
                            productInventoryLocation.TotalReserveQty -= qty;
                        else
                            continue;

                        //productInventoryLocation.TotalAvailableQty -= qty;

                        updatedProductInventoryLocations.Add(productInventoryLocation);
                    }
                    if(updatedProductInventoryLocations?.Any() ?? false) await _productInventoryLocationDataService.SaveManyAsync(userId: userId, updated: updatedProductInventoryLocations);

                    var updatedPickListOrders = new List<PickListOrder>();
                    foreach (var pickListOrder in pickListOrders)
                    {
                        pickListOrder.SetStatusToCancelled();
                        pickListOrder.AuditUser(userId);
                        updatedPickListOrders.Add(pickListOrder);
                    }
                    await _pickListOrderRepository.SaveManyAsync(updated: updatedPickListOrders);

                    var packinglists = await _packingListRepository.GetManyByOrderIdsAsync(new int[] { orderId });
                    var updatedPackingLists = new List<PackingList>();
                    foreach (var packinglist in packinglists)
                    {
                        packinglist.SetStatusToCancelled();
                        packinglist.AuditUser(userId);
                        updatedPackingLists.Add(packinglist);
                    }
                    await _packingListRepository.SaveManyAsync(updated: updatedPackingLists);
                }
            }
        }

        private void CustomerOrderValidation(Order order)
        {
            if (!order.IsCustomerOrderType) return;
            if (string.IsNullOrEmpty(order.ReferenceNumber)) BusinessLogicException.Throw(message: "Invalid P.O. number.");
            if ((order.AccountID ?? 0) == 0) BusinessLogicException.Throw(message: "Invalid Customer Name.");
            if ((order.AgentID ?? 0) == 0) BusinessLogicException.Throw(message: "Invalid Agent value.");
            if (!order.HasOrderItems) BusinessLogicException.Throw(message: "Invalid Order Item(s).");
            //if (order.IsStatusDelivery) BusinessLogicException.Throw(message: "Changes can not be made, transaction already completed.");
            if (order.IsStatusCancelled) BusinessLogicException.Throw(message: "Changes can not be made, transaction already cancelled.");
        }

        private void CustomerOrderRecordUpdate(Order entity, Order oldEntity, string suffix = "")
        {
            if (!oldEntity.IsCustomerOrderType) return;

            suffix = $" of Customer Order #{entity.OrderNumber}";

        }

        public async Task SaveManyCustomerOrderAsync(int userId,
            List<Order> added = null,
            List<Order> updated = null,
            List<Order> deleted = null)
        {
            if (added != null)
            {
                await ScrutinateUserPrivilegeAsync(orders: added, userId: userId);

                var addedOrderItems = new List<OrderItem>();
                var updatedOrderItems = new List<OrderItem>();

                added.ForEach(o =>
                {
                    CustomerOrderValidation(o);

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

                await _orderItemDataService.SaveManyChangesAsync(userId: userId, added: addedOrderItems, updated: updatedOrderItems);
            }

            if (updated != null)
            {
                await ScrutinateUserPrivilegeAsync(orders: updated, userId: userId);

                var addedOrderItems = new List<OrderItem>();
                var updatedOrderItems = new List<OrderItem>();
                var deletedOrderItems = new List<OrderItem>();

                updated.ForEach(o =>
                {
                    CustomerOrderValidation(o);

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

                            if (oi.IsDelete) deletedOrderItems.Add(oi);
                        });
                    }
                });

                await _orderItemDataService.SaveManyChangesAsync(userId: userId, added: addedOrderItems, updated: updatedOrderItems);
                if (deletedOrderItems.Any()) await _orderItemDataService.DeleteManyAsync(userId: userId, deleted: deletedOrderItems);
            }

            if (deleted != null)
            {
                await ScrutinateUserPrivilegeAsync(orders: deleted, userId: userId);

                var deletedOrderItems = new List<OrderItem>();

                deleted.ForEach(o =>
                {
                    if (o.OrderItems != null)
                    {
                        var orderItems = o.OrderItems.Where(oi => oi.IsNewEntity).ToList();
                        orderItems.ForEach(oi =>
                        {
                            oi.SetDelete();
                            o.OrderItems.Remove(oi);
                        });

                        var notNeworderItems = o.OrderItems.Where(oi => !oi.IsNewEntity).ToList();
                        notNeworderItems.ForEach(oi =>
                        {
                            oi.SetDelete();
                            deletedOrderItems.Add(oi);
                        });
                    }
                });

                await _orderItemDataService.DeleteManyAsync(userId: userId, deleted: deletedOrderItems);
            }

            await SaveManyAsync(userId: userId,
                added: added,
                updated: updated,
                deleted: deleted);
        }

    }
}