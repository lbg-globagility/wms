using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IPackingListRepository : ISavableRepository<PackingList>
    {
        Task<PackingList> GetByOrderIdAsync(int orderId);
    }
}
