using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IPackingListDataService : IBaseSavableDataService<PackingList>
    {
        Task<PackingList> GetPackingListByOrderIdAsync(int orderId);
        Task<PackingList> GetPackingListByOrderIdAsync(int orderId, string packingListNo);
        Task<PackingList> GetByOrderIdAsync(int orderId);
        Task<ICollection<PackingList>> GetManyByOrderIdsAsync(int[] ids);
    }
}
