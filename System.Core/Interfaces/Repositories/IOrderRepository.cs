using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IOrderRepository : ISavableRepository<Order>
    {
        Task<Order> GetLastOrderOfThisTypeAsync(int organizationId, OrderType orderType);

        Task<List<Order>> GetOrdersByOrderTypeAsync(int organizationId, OrderType orderType);

        Task<List<Order>> SearchOrdersAsync(int organizationId, OrderType orderType, string searchText);
    }
}