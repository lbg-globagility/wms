using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IInventoryLocationRepository : ISavableRepository<InventoryLocation>
    {
        Task<InventoryLocation> GetByNameAsync(string name);

        Task<List<InventoryLocation>> GetAllByOrganizationIdAsync(int organizationId, string status = "Active");
        Task<List<InventoryLocation>> GetManyByTypeAsync(int organizationId, InventoryLocationType inventoryLocationType);
    }
}