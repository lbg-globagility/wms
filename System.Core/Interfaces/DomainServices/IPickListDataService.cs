using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Helpers;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IPickListDataService : IBaseSavableDataService<PickList>
    {
        Task<PickList> GetByOrderIdAsync(int orderId);

        Task<PaginatedList<PickList>> GetPaginatedPickListsAsync(PageOptions pageOptions,
            int organizationId,
            string searchText = "");
    }
}
