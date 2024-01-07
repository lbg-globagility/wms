using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface ICartonSizeRepository : ISavableRepository<CartonSize>
    {
        Task<CartonSize> GetDefaultAsync(int organizationId);

        CartonSize GenerateDefault(int organizationId, int userId);
    }
}
