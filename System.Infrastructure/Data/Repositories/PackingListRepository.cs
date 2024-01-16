using Microsoft.EntityFrameworkCore;
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

        public async override Task<PackingList> GetByIdAsync(int id)
        {
            return await _context.PackingLists
                .Include(t => t.PackingListCartons)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RowID == id);
        }

        public async Task<PackingList> GetByOrderIdAsync(int orderId)
        {
            return await _context.PackingLists
                .Include(t => t.PackingListCartons)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.OrderID == orderId);
        }
    }
}
