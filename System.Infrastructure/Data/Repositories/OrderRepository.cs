using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;
using System.Linq;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class OrderRepository : SavableRepository<Order>, IOrderRepository
    {
        public OrderRepository(SystemContext context) : base(context)
        {

        }
        public async Task<Order> GetById(int orderId) => await _context.Orders
           .Include(x=>x.OrderItems)
            .ThenInclude(x=>x.ProductColorSize)
                .ThenInclude(x=>x.ProductColor)
                    .ThenInclude(x=>x.Product)
           .Include(x => x.OrderItems)
            .ThenInclude(x => x.ProductColorSize)
                .ThenInclude(x => x.ProductColor)
                    .ThenInclude(x => x.Color)
          .AsNoTracking()
          .Where(c => c.RowID == orderId)
          .FirstAsync();
    }
}