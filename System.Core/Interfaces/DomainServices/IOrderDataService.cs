using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IOrderDataService : IBaseSavableDataService<Order>
    {
        Task<Order> QuickCreateStockTransferOrderAsync(int organizationId, int userId);
    }
}