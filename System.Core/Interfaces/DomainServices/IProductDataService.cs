using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IProductDataService : IBaseSavableDataService<Product>
    {
        Task<List<Product>> GetManyByProductCodesAsync(int organizationId, string[] productCodes);
    }
}