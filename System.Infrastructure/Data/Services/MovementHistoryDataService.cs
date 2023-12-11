using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class MovementHistoryDataService : AuditableDataService<MovementHistory>, IMovementHistoryDataService
    {
        private readonly IMovementHistoryRepository _movementHistoryRepository;

        public MovementHistoryDataService(IMovementHistoryRepository movementHistoryRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) : 
            
            base(movementHistoryRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "MovementHistory")
        {
            _movementHistoryRepository = movementHistoryRepository;
        }

        protected override string CreateUserActivitySuffixIdentifier(MovementHistory entity) => $" {entity.QtyToApply} {(entity.IsTransactionTypeIsFrom ? "outgoing" : "incoming")} quantity {(entity.IsTransactionTypeIsFrom ? "from" : "to")} INVENTORY_LOCATION[{entity.ProductInventoryLocationIDA}] for PRODUCT_COE[{entity.ProductColorSizeID}]";

        protected override string GetUserActivityName(MovementHistory entity) => _entityName;

        protected async override Task RecordUpdate(MovementHistory entity, MovementHistory oldEntity)
        {
            if (oldEntity == null) return;

            var userActivityItems = new List<UserActivityItem>();
            var entityName = _entityName.ToLower();

            if (entity.QtyToApply != oldEntity.QtyToApply)
            {
                userActivityItems.Add(UserActivityItem.NewUserActivityItem(entityId: oldEntity.RowID.Value,
                    description: $"Change `Quantity` {oldEntity.QtyToApply} → {entity.QtyToApply}",
                    changedUserId: entity.LastUpdBy.Value));
            }

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
    }
}