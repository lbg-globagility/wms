using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IProductColorRepository : ISavableRepository<ProductColor>
    {
        Task<List<ProductColor>> GetByOrganizationAsync(int organizationId);
    }
}