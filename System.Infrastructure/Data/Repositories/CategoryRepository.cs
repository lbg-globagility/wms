using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class CategoryRepository : SavableRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SystemContext context) : base(context)
        {
        }

        public Task<Category> GetByNameAsync(int organizationId, string name)
        {
            var query = _context.Categories
                .Include(c => c.Products)
                    .ThenInclude(p => p.ProductColors)
                        .ThenInclude(pc => pc.ProductColorSizes)
                .AsNoTracking()
                .AsQueryable();

            var nameToLower = name.ToLower();

            return Task.FromResult(
                query
                .AsEnumerable()
                .FirstOrDefault(t => t.OrganizationID == organizationId && t.CategoryName.ToLower() == nameToLower));
        }

        public Task<List<Category>> GetByNamesAsync(int organizationId, string[] names)
        {
            var query = _context.Categories
                .Include(c => c.Products)
                    .ThenInclude(p => p.ProductColors)
                        .ThenInclude(pc => pc.ProductColorSizes)
                .AsNoTracking()
                .AsQueryable();

            var namesToLower = names
                .Select(s => s.ToLower())
                .ToArray();

            return Task.FromResult(
                query
                .AsEnumerable()
                .Where(t => t.OrganizationID == organizationId)
                .Where(t => namesToLower.Contains(t.CategoryName.ToLower()))
                .ToList());
        }
    }
}