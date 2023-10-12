using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class ProductColorSizeRepository : SavableRepository<ProductColorSize>, IProductColorSizeRepository
    {
        public ProductColorSizeRepository(SystemContext context) : base(context)
        {
        }

        public override async Task<ICollection<ProductColorSize>> GetManyByOrganizationIdsAsync(int organizationId)
        {
            return await _context.ProductColorSizes
                .Include(pcs => pcs.ProductColor)
                    .ThenInclude(pc => pc.Product)
                        .ThenInclude(p => p.Category)
                .Include(pcs => pcs.ProductColor)
                    .ThenInclude(pc => pc.Color)
                .AsNoTracking()
                .Where(x => x.OrganizationID == organizationId)
                .ToListAsync();
        }
    }
}