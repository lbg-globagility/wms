using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IColorRepository : ISavableRepository<Color>
    {
        Task<Color> GetByNameAsync(int organizationId, string name);

        Task<List<Color>> GetByNamesAsync(int organizationId, string[] names);
    }
}