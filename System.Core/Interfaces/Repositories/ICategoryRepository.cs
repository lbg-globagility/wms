using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : ISavableRepository<Category>
    {
        Task<Category> GetByNameAsync(int organizationId, string name);

        Task<List<Category>> GetByNamesAsync(int organizationId, string[] names);
    }
}