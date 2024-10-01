using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ProductInventoryLocationDataService : AuditableDataService<ProductInventoryLocation>, IProductInventoryLocationDataService
    {
        private readonly IProductInventoryLocationRepository _productInventoryLocationRepository;
        private readonly IRackShelfColumnDataService _rackShelfColumnDataService;

        public ProductInventoryLocationDataService(IProductInventoryLocationRepository productInventoryLocationRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IRackShelfColumnDataService rackShelfColumnDataService) :

            base(productInventoryLocationRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "ProductInventoryLocation")
        {
            _productInventoryLocationRepository = productInventoryLocationRepository;
            _rackShelfColumnDataService = rackShelfColumnDataService;
        }

        public async Task<List<ProductInventoryLocation>> GetByInventoryLocationIdAsync(int inventoryLocationId) =>
            await _productInventoryLocationRepository.GetByInventoryLocationIdAsync(inventoryLocationId: inventoryLocationId);

        public async Task<ICollection<ProductInventoryLocation>> GetManyByIdsAsync(int[] ids) => await _productInventoryLocationRepository.GetManyByIdsAsync(ids);

        protected override string CreateUserActivitySuffixIdentifier(ProductInventoryLocation entity) => string.Empty;

        protected override string GetUserActivityName(ProductInventoryLocation entity) => _entityName;

        public override async Task SaveManyAsync(int userId, List<ProductInventoryLocation> added = null, List<ProductInventoryLocation> updated = null, List<ProductInventoryLocation> deleted = null)
        {
            if (updated != null && updated.Any())
            {
                var updatedRackShelfColumnList = updated.Select(t => t.RackShelfColumn).ToList();

                await _rackShelfColumnDataService.SaveManyAsync(userId: userId, updated: updatedRackShelfColumnList);
            }

            await base.SaveManyAsync(userId, added: added, updated: updated, deleted: deleted);
        }

        public async Task<ProductInventoryLocation> GetByInventoryLocationIdAndProductColorSizeIdAsync(int inventoryLocationId, int productColorSizeId) => await _productInventoryLocationRepository.GetByInventoryLocationIdAndProductColorSizeIdAsync(inventoryLocationId: inventoryLocationId, productColorSizeId: productColorSizeId);

        public async Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdAndProductColorSizeIdsAsync(int inventoryLocationId, int[] productColorSizeIds) => await _productInventoryLocationRepository.GetByInventoryLocationIdAndProductColorSizeIdsAsync(inventoryLocationId: inventoryLocationId, productColorSizeIds: productColorSizeIds);

        public async Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdsAndProductColorSizeIdsAsync(int[] inventoryLocationIds,
            int[] productColorSizeIds) => await _productInventoryLocationRepository.GetByInventoryLocationIdsAndProductColorSizeIdsAsync(inventoryLocationIds: inventoryLocationIds, productColorSizeIds: productColorSizeIds);
    }
}