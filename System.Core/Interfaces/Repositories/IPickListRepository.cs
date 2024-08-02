using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Helpers;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IPickListRepository : ISavableRepository<PickList>
    {
        Task<PickList> GetByOrderIdAsync(int orderId);

        Task<PaginatedList<PickList>> GetPaginatedPickListsAsync(PageOptions pageOptions,
            int organizationId,
            string searchText = "");
    }
}
