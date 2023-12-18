using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IOrderItemDataService : IBaseSavableDataService<OrderItem>
    {
        Task DeleteManyAsync(int userId, List<OrderItem> deleted);
        Task SaveManyChangesAsync(int userId, List<OrderItem> added, List<OrderItem> updated);
    }
}