using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class RackShelfColumnDataService : AuditableDataService<RackShelfColumn>, IRackShelfColumnDataService
    {
        private readonly IRackShelfColumnRepository _rackShelfColumnRepository;

        public RackShelfColumnDataService(IRackShelfColumnRepository rackShelfColumnRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :

            base(rackShelfColumnRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "RackShelfColumn")
        {
            _rackShelfColumnRepository = rackShelfColumnRepository;
        }

        public async Task<RackShelfColumn> GenerateNew(int organizationId, int userId, int inventoryLocationId) => await _rackShelfColumnRepository.GenerateNew(organizationId: organizationId, userId: userId, inventoryLocationId: inventoryLocationId);

        public async Task<List<RackShelfColumn>> GetByInventoryLocationIdAsync(int inventoryLocationId) => await _rackShelfColumnRepository.GetByInventoryLocationIdAsync(inventoryLocationId);

        protected override string CreateUserActivitySuffixIdentifier(RackShelfColumn entity) => string.Empty;

        protected override string GetUserActivityName(RackShelfColumn entity) => _entityName;
    }
}