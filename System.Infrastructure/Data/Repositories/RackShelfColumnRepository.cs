using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class RackShelfColumnRepository : SavableRepository<RackShelfColumn>, IRackShelfColumnRepository
    {
        public RackShelfColumnRepository(SystemContext context) : base(context)
        {
        }

        public override async Task SaveManyAsync(
            List<RackShelfColumn> added = null,
            List<RackShelfColumn> updated = null,
            List<RackShelfColumn> deleted = null)
        {
            if (added != null)
            {
                added.ForEach(entity =>
                {
                    if (entity.IsNewEntity) _context.RackShelfColumns.Add(entity);
                    else _context.Entry(entity).State = EntityState.Added;

                    if (entity.ProductInventoryLocations != null && entity.ProductInventoryLocations.Any())
                        entity.ProductInventoryLocations.ToList().ForEach(t =>
                        {
                            if (t.RackShelfColumn != null) t.RackShelfColumn = null;

                            if (t.IsNewEntity) _context.ProductInventoryLocations.Add(t);
                            else _context.Entry(t).State = EntityState.Added;
                        });

                    DetachNavigationProperties(entity);
                });
            }

            if (updated != null)
            {
                updated.ForEach(entity =>
                {
                    _context.Entry(entity).State = EntityState.Modified;

                    if (entity.ProductInventoryLocations != null && entity.ProductInventoryLocations.Any())
                        entity.ProductInventoryLocations.ToList().ForEach(t =>
                        {
                            if (t.IsNewEntity) _context.ProductInventoryLocations.Add(t);
                            //else _context.Entry(t).State = EntityState.Modified;
                        });

                    DetachNavigationProperties(entity);
                });
            }

            if (deleted != null)
            {
                deleted = deleted
                    .GroupBy(x => x.RowID)
                    .Select(x => x.FirstOrDefault())
                    .ToList();
                _context.RackShelfColumns.RemoveRange(deleted);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<RackShelfColumn>> GetByInventoryLocationIdAsync(int inventoryLocationId) => await _context.RackShelfColumns
                .Include(t => t.ProductInventoryLocations)
                .Where(t => t.InventoryLocationID == inventoryLocationId)
                .ToListAsync();

        public Task<RackShelfColumn> GenerateNew(int organizationId, int userId, int inventoryLocationId)
        {
            var query = _context.RackShelfColumns
                .Where(t => t.OrganizationID == organizationId)
                .Where(t => t.InventoryLocationID == inventoryLocationId)
                .AsNoTracking()
                .AsQueryable();

            var preceedingRackShelfColumns = query
                .AsEnumerable()
                .Where(t=>t.IsActive)
                .ToList();

            var newRackShelfColumn = RackShelfColumn.NewRackShelfColumn(organizationId: organizationId,
                userId: userId,
                inventoryLocationId: inventoryLocationId);

            newRackShelfColumn.PickOrderNo =
                (preceedingRackShelfColumns?.OrderByDescending(t => t.PickOrderNo).FirstOrDefault().PickOrderNo ?? 0) + 1;

            return Task.FromResult(newRackShelfColumn);
        }
    }
}