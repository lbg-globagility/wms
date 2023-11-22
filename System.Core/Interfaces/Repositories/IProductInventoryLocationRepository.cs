using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IProductInventoryLocationRepository : ISavableRepository<ProductInventoryLocation>
    {
        Task<List<ProductInventoryLocation>> GetProductColorSizesByInventoryLocationIdAsync(int inventoryLocationId);

        Task<List<ProductInventoryLocation>> GetByInventoryLocationIdAsync(int inventoryLocationId);
    }
}