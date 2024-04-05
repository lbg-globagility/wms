using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class ProductColorRepository : SavableRepository<ProductColor>, IProductColorRepository
    {
        public ProductColorRepository(SystemContext context) : base(context)
        {
        }

        public Task<List<ProductColor>> GetByOrganizationAsync(int organizationId) => _context.ProductColors
            .Include(p => p.Color)
            .Include(p => p.Product)
            .AsNoTracking()
            .Where(t => t.OrganizationID == organizationId)
            .ToListAsync();
    }
}
