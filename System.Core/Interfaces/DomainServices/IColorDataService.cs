using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IColorDataService : IBaseSavableDataService<Color>
    {
        Task<Color> GetOrCreateAsync(int organizationId, int userId, string name);

        Task<List<Color>> GetManyOrCreateManyAsync(int organizationId, int userId, string[] names);
    }
}