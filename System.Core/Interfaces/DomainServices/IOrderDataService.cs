using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IOrderDataService : IBaseSavableDataService<Order>
    {
        Task<Order> QuickCreateStockTransferOrderAsync(int organizationId, int userId);

        Task<List<Order>> GetOrdersByOrderTypeAsync(int organizationId, OrderType orderType);

        Task<List<Order>> GetStockTransferOrdersAsync(int organizationId);

        Task SaveChangesAsync(Order order, int userId);

        Task ApproveStockTransfer(Order order, int userId);

        Task<List<Order>> SearchStockTransferOrdersAsync(int organizationId, string searchText);

        Task<Order> GetOrderAsync(int id);

        Task<Order> GetOrderAsync(Order order);
    }
}