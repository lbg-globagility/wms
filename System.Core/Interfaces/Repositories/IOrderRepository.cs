using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IOrderRepository : ISavableRepository<Order>
    {
        Task<Order> GetById(int orderId);
    }
}