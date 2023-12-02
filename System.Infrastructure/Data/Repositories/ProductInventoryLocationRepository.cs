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

        public async Task<List<ProductInventoryLocation>> GetByInventoryLocationIdAsync(int inventoryLocationId)
        {
            if (inventoryLocationId == 0) return Enumerable.Empty<ProductInventoryLocation>().ToList();

            return await _context.ProductInventoryLocations
                .Include(t => t.RackShelfColumn)
                    .ThenInclude(r => r.ProductInventoryLocations)
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
        }

        public async Task<List<ProductInventoryLocation>> GetProductColorSizesByInventoryLocationIdAsync(int inventoryLocationId) => await _context.ProductInventoryLocations
            .AsNoTracking()
            .Include(t => t.RackShelfColumn)
            .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)
            .ToListAsync();

        public override async Task<ICollection<ProductInventoryLocation>> GetManyByIdsAsync(int[] ids) => await _context.ProductInventoryLocations
            .Include(t => t.RackShelfColumn)
            .AsNoTracking()
            .Where(t => ids.Contains(t.RowID.Value))
            .ToListAsync();

        public async Task<ProductInventoryLocation> GetByInventoryLocationIdAndProductColorSizeIdAsync(int inventoryLocationId, int productColorSizeId) => await _context.ProductInventoryLocations
            .Include(t => t.RackShelfColumn)
            .Where(t => t.ProductColorSizeID == productColorSizeId)
            .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)
            .FirstOrDefaultAsync();
    }
}