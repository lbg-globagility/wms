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
                            else _context.Entry(t).State = EntityState.Modified;
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
    }
}