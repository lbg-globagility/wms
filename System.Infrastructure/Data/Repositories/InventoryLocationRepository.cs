using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class InventoryLocationRepository : SavableRepository<InventoryLocation>, IInventoryLocationRepository
    {
        public InventoryLocationRepository(SystemContext context) : base(context)
        {
        }

        public async Task<InventoryLocation> GetByNameAsync(string name) => await _context.InventoryLocations
            .Include(i => i.RackShelfColumns)
                .ThenInclude(r => r.ProductInventoryLocations)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Name == name);
    }
}