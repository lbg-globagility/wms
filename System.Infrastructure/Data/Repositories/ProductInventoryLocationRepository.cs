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

        public async Task<List<ProductInventoryLocation>> GetByInventoryLocationIdAsync(int inventoryLocationId) => await _context.ProductInventoryLocations
            .Include(t => t.RackShelfColumn)
            .Include(t => t.ProductColorSize)
                .ThenInclude(t => t.ProductColor)
                    .ThenInclude(t => t.Color)
            .Include(t => t.ProductColorSize)
                .ThenInclude(t => t.ProductColor)
                    .ThenInclude(t => t.Product)
                        .ThenInclude(t => t.Category)
            .AsNoTracking()
            .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)
            .ToListAsync();

        public async Task<List<ProductInventoryLocation>> GetProductColorSizesByInventoryLocationIdAsync(int inventoryLocationId) => await _context.ProductInventoryLocations
            .AsNoTracking()
            .Include(t => t.RackShelfColumn)
            .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)
            .ToListAsync();

        public async Task<List<ProductInventoryLocation>> GetProductInventoryLocationsZeroQtyAsync() => await _context.ProductInventoryLocations
            .Include(t => t.RackShelfColumn)
            .Include(t => t.ProductColorSize)
                .ThenInclude(t => t.ProductColor)
                    .ThenInclude(t => t.Color)
            .Include(t => t.ProductColorSize)
                .ThenInclude(t => t.ProductColor)
                    .ThenInclude(t => t.Product)
                        .ThenInclude(t => t.Category)
            .Where(x => x.TotalAvailableQty <= 0)
            .AsNoTracking()
            .ToListAsync();
    }
}