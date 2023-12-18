using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Helpers;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IOrderRepository : ISavableRepository<Order>
    {
        Task<Order> GetById(int orderId);
        
        Task<Order> GetLastOrderOfThisTypeAsync(int organizationId, OrderType orderType);

        Task<List<Order>> GetOrdersByOrderTypeAsync(int organizationId, OrderType orderType);

        Task<List<Order>> SearchOrdersAsync(int organizationId, OrderType orderType, string searchText);

        Task<Order> GetOrderAsync(int id);

        Task<Order> GetOrderAsync(Order order);

        Task<PaginatedList<Order>> GetOrdersByOrderTypeAsync(PageOptions pageOptions, int organizationId, OrderType orderType, string searchText = "");
    }
}