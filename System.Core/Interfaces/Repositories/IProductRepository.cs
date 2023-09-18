using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IProductRepository : ISavableRepository<Product>
    {
        Task<List<Product>> GetManyByProductCodesAsync(int organizationId, string[] productCodes);

        Task<List<Product>> GetManyByOrganizationIdAsync(int organizationId);
    }
}