
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IProductColorDataService : IBaseSavableDataService<ProductColor>
    {
        Task<List<ProductColor>> GetByOrganizationAsync(int organizationId);

        Task SaveManyChangesAsync(int userId,
            List<ProductColor> added = null,
            List<ProductColor> updated = null,
            List<ProductColor> deleted = null);
    }
}