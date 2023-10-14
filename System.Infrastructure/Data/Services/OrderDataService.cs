using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Services.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class OrderDataService : BaseSavableDataService<Order>, IOrderDataService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductInventoryLocationRepository _productInventoryLocationRepository;

        public OrderDataService(IOrderRepository orderRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IProductInventoryLocationRepository productInventoryLocationRepository) :

            base(orderRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "Order")
        {
            _orderRepository = orderRepository;
            _productInventoryLocationRepository = productInventoryLocationRepository;
        }

        public async Task<List<Order>> GetOrdersByOrderTypeAsync(int organizationId, OrderType orderType) =>
            await _orderRepository.GetOrdersByOrderTypeAsync(organizationId: organizationId, orderType: orderType);

        public async Task<List<Order>> GetStockTransferOrdersAsync(int organizationId) =>
            await GetOrdersByOrderTypeAsync(organizationId: organizationId, orderType: OrderType.ST);

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

            await _orderRepository.SaveAsync(entity: stockTransferOrder);

            return stockTransferOrder;
        }

        public async Task SaveAsync(Order order)
        {
            if (order.IsStockTransferType)
            {
                order.MovementHistories?.ToList().ForEach(movementHistory =>
                {
                    if (movementHistory.ProductColorSize != null)
                    {
                        _context.Entry(movementHistory.ProductColorSize).State = EntityState.Detached;
                        movementHistory.ProductColorSize = null;
                    }

                    if (movementHistory.ProductInventoryLocation != null)
                    {
                        _context.Entry(movementHistory.ProductInventoryLocation).State = EntityState.Detached;
                        movementHistory.ProductInventoryLocation = null;
                    }

                    if (movementHistory.IsNewEntity) _context.MovementHistories.Add(movementHistory);
                    else _context.Entry(movementHistory).State = EntityState.Modified;
                });

                await _context.SaveChangesAsync();
            }

            await _orderRepository.SaveAsync(order);
        }

        public async Task ApproveStockTransfer(Order order)
        {
            var pilIds = order.MovementHistories
                .Select(t => t.ProductInventoryLocationIDA.Value)
                .ToArray();
            var productInventoryLocations = await _productInventoryLocationRepository.GetManyByIdsAsync(pilIds);

            foreach (var productInventoryLocation in productInventoryLocations)
            {
                var movementHistory = order.MovementHistories.FirstOrDefault(t => t.ProductInventoryLocationIDA == productInventoryLocation.RowID);
                if (movementHistory == null) continue;
                productInventoryLocation.TotalAvailableQty = (productInventoryLocation.TotalAvailableQty ?? 0) + movementHistory.FormulatedQtyToApply;
            }

            await _productInventoryLocationRepository.SaveManyAsync(updated: productInventoryLocations.ToList());

            order.ApproveStockTransfer();

            await _orderRepository.SaveAsync(order);
        }
    }
}