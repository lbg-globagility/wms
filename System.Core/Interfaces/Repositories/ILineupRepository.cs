using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface ILineupRepository : ISavableRepository<Lineup>
    {
        Task<List<Lineup>> GetAllByOrganizationIdAsync(int organizationId);
        //Task<Lineup> GetByIdAsync(int lineUpId);
        Task<Lineup> GetByLineupIdAsync(int lineUpId);
    }
}