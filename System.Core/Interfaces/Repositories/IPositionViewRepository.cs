using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IPositionViewRepository : ISavableRepository<PositionView>
    {
        Task<List<PositionView>> GetManyByPositionIdAsync(int organizationId, int positionId);
    }
}