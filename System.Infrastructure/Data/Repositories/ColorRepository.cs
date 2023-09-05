using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;
using WarehouseManagementSystem.Utilities.Extensions;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class ColorRepository : SavableRepository<Color>, IColorRepository
    {
        public ColorRepository(SystemContext context) : base(context)
        {
        }

        public Task<Color> GetByNameAsync(int organizationId, string name)
        {
            var query = _context.Colors
                .AsNoTracking()
                .AsQueryable();

            return Task.FromResult(
                query
                .AsEnumerable()
                .FirstOrDefault(t => t.OrganizationID == organizationId && t.ColorName.IsEqualTo(name)));
        }

        public Task<List<Color>> GetByNamesAsync(int organizationId, string[] names)
        {
            var query = _context.Colors
                .AsNoTracking()
                .AsQueryable();

            var namesToLower = names
                .Select(s => s.ToLower())
                .ToArray();

            bool isContains(string input) => namesToLower.Any(t => t.IsEqualTo(input));

            return Task.FromResult(
                query
                .AsEnumerable()
                .Where(t => t.OrganizationID == organizationId)
                .Where(t => namesToLower.Contains(t.ColorName.ToLower()))
                .ToList());
        }
    }
}