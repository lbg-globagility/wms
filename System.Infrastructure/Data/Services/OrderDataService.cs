using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Exceptions;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public partial class OrderDataService : AuditableDataService<Order>, IOrderDataService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductInventoryLocationRepository _productInventoryLocationRepository;
        private readonly IPositionViewDataService _positionViewDataService;
        private readonly IMovementHistoryDataService _movementHistoryDataService;
        private readonly IProductInventoryLocationDataService _productInventoryLocationDataService;
        private readonly IOrderItemDataService _orderItemDataService;

        public OrderDataService(IOrderRepository orderRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IProductInventoryLocationRepository productInventoryLocationRepository,
            IPositionViewDataService positionViewDataService,
            IMovementHistoryDataService movementHistoryDataService,
            IProductInventoryLocationDataService productInventoryLocationDataService,
            IOrderItemDataService orderItemDataService) :

            base(orderRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "Order")
        {
            _orderRepository = orderRepository;
            _productInventoryLocationRepository = productInventoryLocationRepository;
            _positionViewDataService = positionViewDataService;
            _movementHistoryDataService = movementHistoryDataService;
            _productInventoryLocationDataService = productInventoryLocationDataService;
            _orderItemDataService = orderItemDataService;
        }

        public async Task<List<Order>> GetOrdersByOrderTypeAsync(int organizationId, OrderType orderType) =>
            await _orderRepository.GetOrdersByOrderTypeAsync(organizationId: organizationId, orderType: orderType);

        public async Task SaveChangesAsync(Order order, int userId)
        {
            await ScrutinateUserPrivilegeAsync(order, userId);

            if ((order.IsStockAdjustType || order.IsStockTransferType) &&
                order.IsStatusOpen)
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

                    if (!movementHistory.IsNewEntity) _context.Entry(movementHistory).State = EntityState.Modified;
                });

                await _movementHistoryDataService.SaveManyAsync(userId: userId,
                    added: order.MovementHistories?.Where(t => t.IsNewEntity).ToList(),
                    updated: order.MovementHistories?.Where(t => !t.IsNewEntity).ToList(),
                    deleted: order.DeletedMovementHistories?.Where(t => !t.IsNewEntity).ToList());
            }

            order.AuditUser(userId);

            await SaveManyAsync(entities: new List<Order>() { order }, userId: userId);
        }

        public async Task<Order> GetOrderAsync(int id) => await _orderRepository.GetOrderAsync(id: id);

        public async Task<Order> GetOrderAsync(Order order) => await _orderRepository.GetOrderAsync(order: order);

        private async Task ScrutinateUserPrivilegeAsync(Order order, int userId)
        {
            var positionView = await _positionViewDataService.GetByUserIdAndViewNameAsync(organizationId: order.OrganizationID.Value,
                userId: userId,
                viewName: order.ViewName);

            if (positionView.IsGodMode) return;

            if (positionView.Restricted || positionView.ReadOnly) ThrowError();

            var isDoingCreateWithNoCreatePrivilege = order.IsNewEntity && !positionView.Creates;
            if (isDoingCreateWithNoCreatePrivilege) ThrowError();

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

            void ThrowError() => BusinessLogicException.ThrowInsufficientPrivilege();
        }

        private async Task ScrutinateUserPrivilegeAsync(List<Order> orders, int userId)
        {
            var positionView = await _positionViewDataService.GetByUserIdAndViewNameAsync(organizationId: orders.FirstOrDefault().OrganizationID.Value,
                userId: userId,
                viewName: orders.FirstOrDefault().ViewName);

            if (positionView.IsGodMode) return;

            if (positionView.Restricted || positionView.ReadOnly) ThrowError();

            var isDoingCreateWithNoCreatePrivilege = (orders?.Any(t => t.IsNewEntity) ?? false) && !positionView.Creates;
            if (isDoingCreateWithNoCreatePrivilege) ThrowError();

            var isDoingUpdateWithNoUpdatePrivilege = (orders?.Any(t => !t.IsNewEntity) ?? false) && !positionView.Updates;
            if ((orders.Any(t => t.IsStockTransferType)
                || orders.Any(t => t.IsStockAdjustType))
                && isDoingUpdateWithNoUpdatePrivilege)
            {
                var ids = orders.Where(t => !t.IsNewEntity)
                    .Select(t => t.RowID.Value)
                    .ToArray();
                var originOrders = await _orderRepository.GetManyByIdsAsync(ids: ids);

                if (originOrders.Any(t => !t.HasMovementHistories) && orders.Any(t => t.HasNewMovementHistories)) return;

                ThrowError();
            }
            else if (orders.Any(t => t.IsCustomerOrderType) && isDoingUpdateWithNoUpdatePrivilege)
            {
                var ids = orders.Where(t => !t.IsNewEntity)
                    .Select(t => t.RowID.Value)
                    .ToArray();
                var originOrders = await _orderRepository.GetManyByIdsAsync(ids: ids);

                if (originOrders.Any(t => !t.HasOrderItems) && orders.Any(t => t.HasNewOrderItems)) return;

                ThrowError();
            }
            
            if (isDoingUpdateWithNoUpdatePrivilege)
                ThrowError();

            void ThrowError() => BusinessLogicException.ThrowInsufficientPrivilege();
        }

        protected override string CreateUserActivitySuffixIdentifier(Order entity) => $" #{entity.OrderNumber}{entity.OrderTypeText}, `date` { (entity.OrderDate != null ? entity.OrderDate?.ToShortDateString() : "[nodate]") }, and `status` is '{entity.Status}'";

        protected override string GetUserActivityName(Order entity) => _entityName;

        protected override async Task RecordUpdate(Order entity, Order oldEntity)
        {
            if (oldEntity == null) return;

            var userActivityItems = new List<UserActivityItem>();
            var entityName = _entityName.ToLower();

            //var suffixIdentifier = $"of {entityName}{CreateUserActivitySuffixIdentifier(oldEntity)}.";

            StockAdjustmentRecordUpdate(entity, oldEntity, userActivityItems);

            StockTransferRecordUpdate(entity, oldEntity, userActivityItems);

            CustomerOrderRecordUpdate(entity, oldEntity, userActivityItems);
            
            if (userActivityItems.Any())
            {
                await _userActivityRepository.CreateRecordAsync(
                    entity.LastUpdBy.Value,
                    entityName,
                    entity.OrganizationID.Value,
                    UserActivity.RecordTypeEdit,
                    userActivityItems);
            }
        }

        protected override Task RecordAdd(Order entity)
        {
            return base.RecordAdd(entity);
        }
    }
}