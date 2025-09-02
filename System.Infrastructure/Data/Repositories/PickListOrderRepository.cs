using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class PickListOrderRepository : SavableRepository<PickListOrder>, IPickListOrderRepository
    {
        public PickListOrderRepository(SystemContext context) : base(context)
        {
        }

        public async Task<ICollection<PickListOrder>> GetManyByOrderIdAsync(int orderId) => await _context.PickListOrders
            .Include(t => t.PickList)
            .Include(t => t.PickListOrderItems)
            .AsNoTracking()
            .Where(t => t.OrderID == orderId)
            .ToListAsync();
    }
}
