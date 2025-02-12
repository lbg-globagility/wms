using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface ICategoryDataService : IBaseSavableDataService<Category>
    {
        Task<Category> GetOrCreateAsync(int organizationId, int userId, string name);

        Task<List<Category>> GetManyOrCreateManyAsync(int organizationId, int userId, string[] names);

        Task<List<Category>> GetAllByOrganizationIdAsync(int organizationId, CategoryStatus status = CategoryStatus.Active);
    }
}