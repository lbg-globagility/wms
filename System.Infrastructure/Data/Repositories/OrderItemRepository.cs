using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<OrderItem>> GetByOrderIdAsync(int orderId) => await _context.OrderItems
            .Include(t => t.ProductInventoryLocation)
                .ThenInclude(t => t.RackShelfColumn)
            .AsNoTracking()
            .Where(t => t.OrderID == orderId)
            .ToListAsync();
    }
}