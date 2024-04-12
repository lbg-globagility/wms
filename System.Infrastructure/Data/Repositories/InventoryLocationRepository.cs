using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class InventoryLocationRepository : SavableRepository<InventoryLocation>, IInventoryLocationRepository
    {
        public InventoryLocationRepository(SystemContext context) : base(context)
        {
        }

        public Task<InventoryLocation> GetByNameAsync(string name)
        {
            var query = _context.InventoryLocations
                .Include(i => i.RackShelfColumns)
                    .ThenInclude(r => r.ProductInventoryLocations)
                .AsNoTracking()
                .AsQueryable();

            var nameToLower = name.ToLower();

            return Task.FromResult(
                query
                .AsEnumerable()
                .FirstOrDefault(t => t.Name.ToLower() == nameToLower));
        }

        public override async Task<InventoryLocation> GetByIdAsync(int id) => await _context.InventoryLocations
            .Include(i => i.RackShelfColumns)
                .ThenInclude(r => r.ProductInventoryLocations)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.RowID == id);

        public async Task<List<InventoryLocation>> GetAllByOrganizationIdAsync(int organizationId, string status = "Active") => await _context.InventoryLocations
            .Include(i => i.RackShelfColumns)
                .ThenInclude(r => r.ProductInventoryLocations)
            .AsNoTracking()
            .Where(i => i.OrganizationID == organizationId)
            .Where(i => i.Status == status)
            .ToListAsync();

        public async Task<List<InventoryLocation>> GetManyByTypeAsync(int organizationId, InventoryLocationType inventoryLocationType)
        {
            var query =  _context.InventoryLocations
                .Include(i => i.RackShelfColumns)
                    .ThenInclude(r => r.ProductInventoryLocations)
                .AsNoTracking()
                .Where(i => i.OrganizationID == organizationId);

            return await query
                .Where(t => t.Type == inventoryLocationType)
                .ToListAsync();
        }
    }
}