using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface ICartonSizeDataService : IBaseSavableDataService<CartonSize>
    {
        Task<CartonSize> GetOrCreateDefaultAsync(int organizationId, int userId);
    }
}
