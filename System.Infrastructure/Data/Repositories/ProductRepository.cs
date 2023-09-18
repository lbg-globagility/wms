using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class ProductRepository : SavableRepository<Product>, IProductRepository
    {
        public ProductRepository(SystemContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetManyByProductCodesAsync(int organizationId, string[] productCodes)
        {
            var productCodesToLower = productCodes
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => s.ToLower())
                .ToArray();

            return await _context.Products
                .Include(p => p.ProductColors)
                    .ThenInclude(pc => pc.Color)
                .Include(p => p.ProductColors)
                    .ThenInclude(pc => pc.ProductColorSizes)
                        .ThenInclude(pcs => pcs.ProductColor)
                            .ThenInclude(pc => pc.Color)
                .Include(p => p.Category)
                .AsNoTracking()
                .Where(t => t.OrganizationID == organizationId)
                .Where(t => productCodesToLower.Contains(t.ProductCode.ToLower()))
                .ToListAsync();
        }

        public async Task<List<Product>> GetManyByOrganizationIdAsync(int organizationId) => await _context.Products
            .Include(p => p.ProductColors)
                .ThenInclude(pc => pc.Color)
            .Include(p => p.ProductColors)
                .ThenInclude(pc => pc.ProductColorSizes)
                    .ThenInclude(pcs => pcs.ProductColor)
                        .ThenInclude(pc => pc.Color)
            .Include(p => p.Category)
            .AsNoTracking()
            .Where(t => t.OrganizationID == organizationId)
            .ToListAsync();
    }
}