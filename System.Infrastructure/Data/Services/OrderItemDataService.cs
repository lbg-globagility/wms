using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Exceptions;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class OrderItemDataService : AuditableDataService<OrderItem>, IOrderItemDataService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IPositionViewDataService _positionViewDataService;

        public OrderItemDataService(IOrderItemRepository orderItemRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IPositionViewDataService positionViewDataService) :

            base(orderItemRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "OrderItem")
        {
            _orderItemRepository = orderItemRepository;
            _positionViewDataService = positionViewDataService;
        }

        protected override string CreateUserActivitySuffixIdentifier(OrderItem entity) => $"ProductColorSizeID: {entity.ProductColorSizeID}";

        protected override string GetUserActivityName(OrderItem entity) => _entityName;

        private async Task ScrutinateUserPrivilegeAsync(List<OrderItem> orderItems, int userId)
        {
            if (!(orderItems?.Any() ?? false)) return;

            var positionView = await _positionViewDataService.GetByUserIdAndViewNameAsync(organizationId: orderItems.FirstOrDefault().OrganizationID.Value,
                userId: userId,
                viewName: orderItems.FirstOrDefault().ViewName);

            if (positionView.IsGodMode) return;

            if (positionView.Restricted || positionView.ReadOnly) ThrowError();

            var isDoingCreateWithNoCreatePrivilege = (orderItems?.Any(t => t.IsNewEntity) ?? false) && !positionView.Creates;
            var isDoingUpdateWithNoUpdatePrivilege = (orderItems?.Any(t => !t.IsNewEntity) ?? false) && !positionView.Updates;
            var isDoingDeleteWithNoDeletePrivilege = (orderItems?.Any(t => t.IsDelete) ?? false) && !positionView.Updates;

            if (isDoingCreateWithNoCreatePrivilege || isDoingUpdateWithNoUpdatePrivilege || isDoingDeleteWithNoDeletePrivilege)
            {
                ThrowError();
            }

            void ThrowError() => BusinessLogicException.ThrowInsufficientPrivilege();
        }

        public async Task DeleteManyAsync(int userId, List<OrderItem> deleted)
        {
            await ScrutinateUserPrivilegeAsync(userId: userId, orderItems: deleted);

            if(deleted?.Any() ?? false) await SaveManyAsync(userId: userId, deleted: deleted);
        }

        public async Task SaveManyChangesAsync(int userId, List<OrderItem> added, List<OrderItem> updated)
        {
            await ScrutinateUserPrivilegeAsync(userId: userId, orderItems: added);
            await ScrutinateUserPrivilegeAsync(userId: userId, orderItems: updated);

            if ((added?.Any() ?? false) || (updated?.Any() ?? false)) await SaveManyAsync(userId: userId, added: added, updated: updated);
        }
    }
}