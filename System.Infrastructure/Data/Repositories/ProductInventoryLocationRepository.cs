using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                        .ThenInclude(pil => pil.RackShelfColumn)
                .Include(t => t.ProductColorSize)
                    .ThenInclude(t => t.ProductColor)
                        .ThenInclude(t => t.Color)
                .Include(t => t.ProductColorSize)
                    .ThenInclude(t => t.ProductColor)
                        .ThenInclude(t => t.Product)
                            .ThenInclude(t => t.Category)
                .Include(t => t.RackShelfColumn)
                    .ThenInclude(r => r.InventoryLocation)
                .AsNoTracking()
                .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)
                .ToListAsync();
        }

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

        public override async Task<ICollection<ProductInventoryLocation>> GetManyByIdsAsync(int[] ids) => await _context.ProductInventoryLocations
            .Include(t => t.RackShelfColumn)
            .Include(t => t.ProductColorSize)
                .ThenInclude(t => t.ProductColor)
                    .ThenInclude(t => t.Product)
            .Include(t => t.ProductColorSize)
                .ThenInclude(t => t.ProductColor)
                    .ThenInclude(t => t.Color)
            .AsNoTracking()
            .Where(t => ids.Contains(t.RowID.Value))
            .ToListAsync();

        public async Task<ProductInventoryLocation> GetByInventoryLocationIdAndProductColorSizeIdAsync(int inventoryLocationId, int productColorSizeId) => await _context.ProductInventoryLocations
            .Include(t => t.RackShelfColumn)
            .Where(t => t.ProductColorSizeID == productColorSizeId)
            .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)
            .FirstOrDefaultAsync();

        public async Task<ICollection<ProductInventoryLocation>> GetManyByCompositeKeysAsync(int organizationId, int inventoryLocationId, int productColorId) => await _context.ProductInventoryLocations
            .Include(t => t.ProductColorSize)
                .ThenInclude(p => p.ProductColor)
                    .ThenInclude(p => p.Color)
            .Include(t => t.ProductColorSize)
                .ThenInclude(p => p.ProductColor)
                    .ThenInclude(p => p.Product)
            .Include(t => t.RackShelfColumn)
            .AsNoTracking()
            .Where(x => x.OrganizationID == organizationId)
            .Where(x => x.ProductColorSize.ProductColorID == productColorId)
            .Where(x => x.RackShelfColumn.InventoryLocationID == inventoryLocationId)
            .ToListAsync();

        public async Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdAndProductColorSizeIdsAsync(int inventoryLocationId, int[] productColorSizeIds) => await _context.ProductInventoryLocations
            .Include(t => t.RackShelfColumn)
            .Include(t => t.ProductColorSize)
                .ThenInclude(t => t.ProductColor)
                    .ThenInclude(t => t.Product)
            .Include(t => t.ProductColorSize)
                .ThenInclude(t => t.ProductColor)
                    .ThenInclude(t => t.Color)
            .Where(t => productColorSizeIds.Contains(t.ProductColorSizeID))
            .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)
            .ToListAsync();

        public async Task<ICollection<ProductInventoryLocation>> GetByInventoryLocationIdsAndProductColorSizeIdsAsync(int[] inventoryLocationIds, int[] productColorSizeIds) => await _context.ProductInventoryLocations
            .Include(t => t.RackShelfColumn)
            .Include(t => t.ProductColorSize)
                .ThenInclude(t => t.ProductColor)
                    .ThenInclude(t => t.Product)
            .Include(t => t.ProductColorSize)
                .ThenInclude(t => t.ProductColor)
                    .ThenInclude(t => t.Color)
            .Where(t => productColorSizeIds.Contains(t.ProductColorSizeID))
            .Where(t => inventoryLocationIds.Contains(t.RackShelfColumn.InventoryLocationID))
            .ToListAsync();

        public async Task<List<ProductInventoryLocation>> GetByInventoryLocationIdsAsync(int[] inventoryLocationIds)
        {
            if (!(inventoryLocationIds?.Any() ?? false)) return Enumerable.Empty<ProductInventoryLocation>().ToList();

            return await _context.ProductInventoryLocations
                .Include(t => t.RackShelfColumn)
                    .ThenInclude(r => r.ProductInventoryLocations)
                        .ThenInclude(pil => pil.RackShelfColumn)
                .Include(t => t.ProductColorSize)
                    .ThenInclude(t => t.ProductColor)
                        .ThenInclude(t => t.Color)
                .Include(t => t.ProductColorSize)
                    .ThenInclude(t => t.ProductColor)
                        .ThenInclude(t => t.Product)
                            .ThenInclude(t => t.Category)
                .Include(t => t.RackShelfColumn)
                    .ThenInclude(r => r.InventoryLocation)
                .AsNoTracking()
                .Where(t => inventoryLocationIds.Contains(t.RackShelfColumn.InventoryLocationID))
                .ToListAsync();
        }

        public async Task<ICollection<ProductInventoryLocation>> GetByProductColorSizeIdsAndInventoryLocationIdsAsync(
            int organizationId,
            int userId,
            List<(int productColorSizeId, int inventoryLocationId)> productColorSizeIdsAndInventoryIds)
        {

            Expression<Func<ProductInventoryLocation, bool>> predicate = t => productColorSizeIdsAndInventoryIds
                .Any(x => x.productColorSizeId == t.ProductColorSizeID && 
                    x.inventoryLocationId == t.RackShelfColumn.InventoryLocationID);

            return await _context.ProductInventoryLocations
                .Include(t => t.RackShelfColumn)
                .Include(t => t.ProductColorSize)
                    .ThenInclude(t => t.ProductColor)
                        .ThenInclude(t => t.Product)
                .Include(t => t.ProductColorSize)
                    .ThenInclude(t => t.ProductColor)
                        .ThenInclude(t => t.Color)
                .Where(predicate)
                .ToListAsync();
        }
    }
}