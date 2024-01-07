using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IRackShelfColumnDataService : IBaseSavableDataService<RackShelfColumn>
    {
        Task<List<RackShelfColumn>> GetByInventoryLocationIdAsync(int inventoryLocationId);
        Task<RackShelfColumn> GenerateNew(int organizationId, int userId, int inventoryLocationId);
    }
}