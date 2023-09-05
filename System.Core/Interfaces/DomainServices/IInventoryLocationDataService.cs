using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IInventoryLocationDataService : IBaseSavableDataService<InventoryLocation>
    {
        Task PopulateWithProductColorSizesAsync(string inventoryLocationName, int userId);

        Task PopulateWithProductColorSizesAsync(int inventoryLocationId, int userId);

        Task PopulateAllInventoryLocationWithProductColorSizesAsync(int organizationId, int userId, string[] productCodes);
    }
}