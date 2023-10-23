using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Exceptions;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Services.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public partial class OrderDataService : BaseSavableDataService<Order>, IOrderDataService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductInventoryLocationRepository _productInventoryLocationRepository;
        private readonly IPositionViewDataService _positionViewDataService;

        public OrderDataService(IOrderRepository orderRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IProductInventoryLocationRepository productInventoryLocationRepository,
            IPositionViewDataService positionViewDataService) :

            base(orderRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "Order")
        {
            _orderRepository = orderRepository;
            _productInventoryLocationRepository = productInventoryLocationRepository;
            _positionViewDataService = positionViewDataService;
        }

        public async Task<List<Order>> GetOrdersByOrderTypeAsync(int organizationId, OrderType orderType) =>
            await _orderRepository.GetOrdersByOrderTypeAsync(organizationId: organizationId, orderType: orderType);

        public async Task SaveChangesAsync(Order order, int userId)
        {
            await ScrutinateUserPrivilegeAsync(order, userId);

            if ((order.IsStockAdjustType || order.IsStockTransferType) &&
                order.IsOpen)
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

                if (order.DeletedMovementHistories != null && order.DeletedMovementHistories.Any(t => !t.IsNewEntity)) _context.MovementHistories.RemoveRange(order.DeletedMovementHistories.Where(t => !t.IsNewEntity));

                await _context.SaveChangesAsync();
            }

            order.AuditUser(userId);

            await _orderRepository.SaveAsync(order);
        }

        public async Task<Order> GetOrderAsync(int id) => await _orderRepository.GetOrderAsync(id: id);

        public async Task<Order> GetOrderAsync(Order order) => await _orderRepository.GetOrderAsync(order: order);

        private async Task ScrutinateUserPrivilegeAsync(Order order, int userId)
        {
            var positionView = await _positionViewDataService.GetByUserIdAndViewNameAsync(organizationId: order.OrganizationID.Value,
                userId: userId,
                viewName: order.ViewName);

            if (positionView.Restricted || positionView.ReadOnly) ThrowError();

            var isDoingUpdateWithNoUpdatePrivilege = !order.IsNewEntity && !positionView.Updates;

            if ((order.IsStockTransferType || order.IsStockAdjustType) &&
                isDoingUpdateWithNoUpdatePrivilege)
            {
                var originOrder = await _orderRepository.GetOrderAsync(order);

                if (!originOrder.HasMovementHistories && order.HasNewMovementHistories) return;

                ThrowError();
            }

            if (isDoingUpdateWithNoUpdatePrivilege)
                ThrowError();

            void ThrowError() => BusinessLogicException.Throw(message: "The user has insufficient privilege to perform this command.");
        }
    }
}