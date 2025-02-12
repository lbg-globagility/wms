using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : ISavableRepository<Category>
    {
        Task<Category> GetByNameAsync(int organizationId, string name);

        Task<List<Category>> GetByNamesAsync(int organizationId, string[] names);

        Task<List<Category>> GetAllByOrganizationIdAsync(int organizationId, CategoryStatus status = CategoryStatus.Active);
    }
}