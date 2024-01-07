using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IRackShelfColumnRepository : ISavableRepository<RackShelfColumn>
    {
        Task<List<RackShelfColumn>> GetByInventoryLocationIdAsync(int inventoryLocationId);
        Task<RackShelfColumn> GenerateNew(int organizationId, int userId, int inventoryLocationId);
    }
}