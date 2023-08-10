using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class ProductInventoryLocationRepository : SavableRepository<ProductInventoryLocation>, IProductInventoryLocationRepository
    {
        public ProductInventoryLocationRepository(SystemContext context) : base(context)
        {
        }

        public async Task<List<ProductInventoryLocation>> GetProductColorSizesByInventoryLocationIdAsync(int inventoryLocationId) => await _context.ProductInventoryLocations
            .AsNoTracking()
            .Include(t => t.RackShelfColumn)
            .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)
            .ToListAsync();
    }
}