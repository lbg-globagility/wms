using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IOrderItemRepository : ISavableRepository<OrderItem>
    {
        Task<List<OrderItem>> GetByOrderIdAsync(int orderId);
    }
}