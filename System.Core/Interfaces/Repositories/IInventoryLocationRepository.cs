using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IInventoryLocationRepository : ISavableRepository<InventoryLocation>
    {
        Task<InventoryLocation> GetByNameAsync(string name);

        Task<List<InventoryLocation>> GetAllByOrganizationIdAsync(int organizationId);
    }
}