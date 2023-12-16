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
        Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdAndProductColorSizeIdsAsync(int inventoryLocationId, int[] productColorSizeIds);
    }
}