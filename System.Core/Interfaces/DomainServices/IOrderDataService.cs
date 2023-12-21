using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Helpers;
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

        Task<List<Order>> GetStockAdjustmentOrdersAsync(int organizationId);

        Task<List<Order>> SearchStockAdjustmentOrdersAsync(int organizationId, string searchText);

        Task<Order> QuickCreateStockAdjustmentOrderAsync(int organizationId, int userId);

        Task ApproveStockAdjustment(Order order, int userId);

        Task<List<Order>> GetCustomerOrdersAsync(int organizationId);
        Task<Order> GetCustomerOrderAsync(int primaryKey);
        Task<PaginatedList<Order>> GetCustomerOrdersAsync(int organizationId, PageOptions pageOptions, string searchText = "");
        Task<List<Order>> SearchCustomerOrdersAsync(int organizationId, string searchText);
        Task<Order> QuickCreateCustomerOrderAsync(int organizationId, int userId);
        Task ApproveCustomerOrder(Order order, int userId);
        Task SaveManyCustomerOrderAsync(int userId, List<Order> added = null, List<Order> updated = null, List<Order> deleted = null);
    }
}