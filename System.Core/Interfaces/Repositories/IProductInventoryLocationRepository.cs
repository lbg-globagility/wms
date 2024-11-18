using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IProductInventoryLocationRepository : ISavableRepository<ProductInventoryLocation>
    {
        Task<List<ProductInventoryLocation>> GetProductColorSizesByInventoryLocationIdAsync(int inventoryLocationId);

        Task<List<ProductInventoryLocation>> GetByInventoryLocationIdAsync(int inventoryLocationId);

        Task<List<ProductInventoryLocation>> GetProductInventoryLocationsZeroQtyAsync();
        Task<ProductInventoryLocation> GetByInventoryLocationIdAndProductColorSizeIdAsync(int inventoryLocationId, int productColorSizeId);

        Task<ICollection<ProductInventoryLocation>> GetManyByCompositeKeysAsync(int organizationId, int inventoryLocationId, int productColorId);
        Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdAndProductColorSizeIdsAsync(int inventoryLocationId, int[] productColorSizeIds);
        Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdsAndProductColorSizeIdsAsync(int[] inventoryLocationIds, int[] productColorSizeIds);

        Task<ICollection<ProductInventoryLocation>> GetByProductColorSizeIdsAndInventoryLocationIdsAsync(
            int organizationId,
            int userId,
            List<(int productColorSizeId, int inventoryLocationId)> productColorSizeIdsAndInventoryIds);

        Task<List<ProductInventoryLocation>> GetByInventoryLocationIdsAsync(int[] inventoryLocationIds);
    }
}