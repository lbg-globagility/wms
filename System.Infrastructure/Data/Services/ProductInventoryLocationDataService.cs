using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;
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
        private readonly IProductColorSizeDataService _productColorSizeDataService;

        public ProductInventoryLocationDataService(IProductInventoryLocationRepository productInventoryLocationRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IRackShelfColumnDataService rackShelfColumnDataService,
            IProductColorSizeDataService productColorSizeDataService) :

            base(productInventoryLocationRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "ProductInventoryLocation")
        {
            _productInventoryLocationRepository = productInventoryLocationRepository;
            _rackShelfColumnDataService = rackShelfColumnDataService;
            _productColorSizeDataService= productColorSizeDataService;
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

        public async Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdAndProductColorSizeIdsAsync(
            int organizationId,
            int userId,
            int inventoryLocationId,
            int[] productColorSizeIds)
        {
            var data = await _productInventoryLocationRepository.GetByInventoryLocationIdAndProductColorSizeIdsAsync(inventoryLocationId: inventoryLocationId, productColorSizeIds: productColorSizeIds);

            var fetchedProductColorSizeIds = data.GroupBy(t => t.ProductColorSizeID)
                .Select(t => t.Key)
                .ToArray();

            var notExistingProductColorSizeIds = productColorSizeIds?
                .Where(id => !fetchedProductColorSizeIds.Contains(id))
                .ToArray();

            if(notExistingProductColorSizeIds?.Any() ?? false)
            {
                var newProductInventoryLocations = new List<ProductInventoryLocation>();

                var productColorSizes = await _productColorSizeDataService.GetManyByIdsAsync(ids: notExistingProductColorSizeIds);

                foreach (var id in notExistingProductColorSizeIds)
                {
                    var productColorSize = productColorSizes?.FirstOrDefault(t => t.RowID == id);
                    if (productColorSize == null) continue;

                    var newProductInventoryLocation = ProductInventoryLocation.NewProductInventoryLocation(organizationId: organizationId,
                        userId: userId,
                        productColorSizeId: id,
                        unitOfMeasure: productColorSize?.ProductColor?.Product?.UnitOfMeasure,
                        unitPrice: productColorSize?.ProductColor?.Product?.UnitPrice ?? 0,
                        unitOfMeasure2: productColorSize?.ProductColor?.Product?.UnitOfMeasure2,
                        unitPriceOfUOM2: productColorSize?.ProductColor?.Product?.UnitPriceOfUOM2 ?? 0);

                    newProductInventoryLocation.SetRackShelfColumn(RackShelfColumn.NewRackShelfColumn(
                        organizationId: organizationId,
                        userId: userId,
                        inventoryLocationId: inventoryLocationId));

                    newProductInventoryLocations.Add(newProductInventoryLocation);
                }

                await SaveManyAsync(userId: userId, added: newProductInventoryLocations);
            }

            return await _productInventoryLocationRepository.GetByInventoryLocationIdAndProductColorSizeIdsAsync(inventoryLocationId: inventoryLocationId, productColorSizeIds: productColorSizeIds);
        }

        public async Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdsAndProductColorSizeIdsAsync(int[] inventoryLocationIds,
            int[] productColorSizeIds) => await _productInventoryLocationRepository.GetByInventoryLocationIdsAndProductColorSizeIdsAsync(inventoryLocationIds: inventoryLocationIds, productColorSizeIds: productColorSizeIds);

        public async Task<List<ProductInventoryLocation>> GetByInventoryLocationIdsAsync(int[] inventoryLocationIds) =>
            await _productInventoryLocationRepository.GetByInventoryLocationIdsAsync(inventoryLocationIds: inventoryLocationIds);

        public async Task<ICollection<ProductInventoryLocation>> GetByProductColorSizeIdsAndInventoryLocationIdsAsync(
            int organizationId,
            int userId,
            List<(int productColorSizeId, int inventoryLocationId)> productColorSizeIdsAndInventoryIds)
        {
            return await _productInventoryLocationRepository.GetByProductColorSizeIdsAndInventoryLocationIdsAsync(
                organizationId: organizationId,
                userId: userId,
                productColorSizeIdsAndInventoryIds: productColorSizeIdsAndInventoryIds);
        }
    }
}