using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IPositionViewDataService : IBaseSavableDataService<PositionView>
    {
        Task<List<PositionView>> GetManyByUserIdAsync(int organizationId, int userId);

        Task<PositionView> GetByUserIdAndViewNameAsync(int organizationId, int userId, string viewName);
    }
}