using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IProductInventoryLocationDataService : IBaseSavableDataService<ProductInventoryLocation>
    {
        Task<List<ProductInventoryLocation>> GetByInventoryLocationIdAsync(int inventoryLocationId);
        Task<ICollection<ProductInventoryLocation>> GetManyByIdsAsync(int[] ids);
        Task<ProductInventoryLocation> GetByInventoryLocationIdAndProductColorSizeIdAsync(int inventoryLocationId, int productColorSizeId);
        Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdAndProductColorSizeIdsAsync(
            int organizationId,
            int userId,
            int inventoryLocationId,
            int[] productColorSizeIds);

        Task<ICollection<ProductInventoryLocation>> GetByProductColorSizeIdsAndInventoryLocationIdsAsync(
            int organizationId,
            int userId,
            List<(int productColorSizeId, int inventoryLocationId)> productColorSizeIdsAndInventoryIds);

        Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdsAndProductColorSizeIdsAsync(int[] inventoryLocationIds, int[] productColorSizeIds);
        Task<List<ProductInventoryLocation>> GetByInventoryLocationIdsAsync(int[] inventoryLocationIds);
    }
}
