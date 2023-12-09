using Microsoft.EntityFrameworkCore;
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
                .Include(t => t.PackingListNo)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RowID == id);
        }
    }
}
