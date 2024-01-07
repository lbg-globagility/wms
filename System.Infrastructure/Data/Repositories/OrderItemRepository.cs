using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class OrderItemRepository : SavableRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(SystemContext context) : base(context)
        {
        }
    }
}