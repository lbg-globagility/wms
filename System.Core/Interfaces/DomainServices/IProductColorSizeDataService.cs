using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IProductColorSizeDataService : IBaseSavableDataService<ProductColorSize>
    {
        Task<List<ProductColorSize>> GetManyByIdsAsync(int[] ids);
    }
}
