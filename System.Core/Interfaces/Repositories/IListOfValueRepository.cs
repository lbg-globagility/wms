using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IListOfValueRepository : ISavableRepository<ListOfValue>
    {
        Task<List<ListOfValue>> GetManyByTypeAsync(int organizationId, string type);
    }
}