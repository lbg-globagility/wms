using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class PackingListRepository : SavableRepository<PackingList>, IPackingListRepository
    {
        public PackingListRepository(SystemContext context) : base(context)
        {
        }

        public async override Task<PackingList> GetByIdAsync(int id) => await _context.PackingLists
            .Include(t => t.PackingListCartons)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.RowID == id);

        public async Task<PackingList> GetByOrderIdAsync(int orderId) => await _context.PackingLists
            .Include(t => t.PackingListCartons)
                .ThenInclude(t => t.PackingListCartonItems)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.OrderID == orderId);

        public async Task<ICollection<PackingList>> GetManyByOrderIdsAsync(int[] ids)
        {
            if (ids?.Any() ?? false) return Enumerable.Empty<PackingList>().ToList();

            return await _context.PackingLists
                .Include(t => t.PackingListCartons)
                    .ThenInclude(t => t.PackingListCartonItems)
                        .ThenInclude(t => t.OrderItem)
                            .ThenInclude(oi => oi.ProductInventoryLocation)
                .AsNoTracking()
                .Where(t => ids.Contains(t.OrderID.Value))
                .ToListAsync();
        }
    }
}
