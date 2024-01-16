using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class PickListRepository : SavableRepository<PickList>, IPickListRepository
    {
        public PickListRepository(SystemContext context) : base(context)
        {
        }

        public async override Task<PickList> GetByIdAsync(int id)
        {
            return await _context.PickLists
                .Include(t => t.PickListOrders)
                    .ThenInclude(t => t.PickListOrderItems)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.RowID == id);
        }

        public Task<PickList> GetByOrderIdAsync(int orderId)
        {
            var query = _context.PickLists
                .Include(t => t.PickListOrders)
                    .ThenInclude(t => t.PickListOrderItems)
                .AsNoTracking()
                .AsQueryable();

            return Task.FromResult(query.AsEnumerable()
                .Where(t => t.PickListOrders.Any(x => x.OrderID == orderId))
                .FirstOrDefault());
        }
    }
}
