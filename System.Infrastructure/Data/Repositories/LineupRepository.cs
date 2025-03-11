using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class LineupRepository : SavableRepository<Lineup>, ILineupRepository
    {
        public LineupRepository(SystemContext context) : base(context)
        {
        }

        public async Task<List<Lineup>> GetAllByOrganizationIdAsync(int organizationId) => await _context.Lineups
            .AsNoTracking()
            .Where(c => c.OrganizationID == organizationId)
            .ToListAsync();

        public override async Task<Lineup> GetByIdAsync(int id) => await _context.Lineups
            .Include(l => l.DeliveryTruckShift)
                .ThenInclude(dts => dts.DeliveryTruck)
            .Include(l => l.Driver)
            .Include(l => l.Helper1)
            .Include(l => l.Helper2)
            .AsNoTracking()
            .Where(c => c.RowID == id)
            .FirstOrDefaultAsync();

        public Task<Lineup> GetByLineupIdAsync(int lineUpId)
        {
            var query = _context.Lineups
            .Include(t => t.Order)
            .Include(t => t.LineupCartons)
                .ThenInclude(t => t.PackingListCarton)
                    .ThenInclude(t => t.PackingListCartonItems)
                        .ThenInclude(t => t.OrderItem)
                            .ThenInclude(oi => oi.ProductInventoryLocation)
                                .ThenInclude(pil => pil.RackShelfColumn)
            .Include(t => t.LineupCartons)
                .ThenInclude(t => t.PackingListCarton)
                    .ThenInclude(t => t.PackingListCartonItems)
                        .ThenInclude(t => t.PickListOrder)
                            .ThenInclude(t=>t.PickListOrderItems)
            .Where(t => t.LineupCartons.Any(luc => luc.LineUpID == lineUpId))
            .AsNoTracking()
            .AsQueryable();

            return Task.FromResult(query.AsEnumerable()
                .Where(t => t.HasPackingListCartonItems)
                .FirstOrDefault());

            //return await _context.Lineups
            //.Include(t => t.LineupCartons)
            //    .ThenInclude(t => t.PackingListCarton)
            //        .ThenInclude(t => t.PackingListCartonItems)
            //.Where(t => t.LineupCartons.FirstOrDefault().LineUpID == lineUpId)
            //.AsNoTracking()
            //.FirstOrDefaultAsync();
        }

        public Task<List<Lineup>> GetByOrganizationIdAndDateRangeAsync(int organizationId, DateTime from, DateTime to)
        {
            var query = _context.Lineups
            .Include(t => t.Order)
            .Include(t => t.LineupCartons)
                .ThenInclude(t => t.PackingListCartonItems)
                    .ThenInclude(t => t.OrderItem)
                        .ThenInclude(oi => oi.ProductInventoryLocation)
                            .ThenInclude(pil => pil.RackShelfColumn)
            .Include(t => t.LineupCartons)
                .ThenInclude(t => t.PackingListCartonItems)
                    .ThenInclude(t => t.OrderItem)
                        .ThenInclude(oi => oi.ProductInventoryLocation)
                            .ThenInclude(pil => pil.ProductColorSize)
                                .ThenInclude(pcs => pcs.ProductColor)
                                    .ThenInclude(pc => pc.Product)
                                        .ThenInclude(p => p.Category)
            .Where(t => t.OrganizationID == organizationId)
            .AsNoTracking()
            .AsQueryable();

            return Task.FromResult(query.AsEnumerable()
                .Where(t => t.IsConfirmedDelivery && (t.ConfirmedDeliveryTimeStamp.Value.Date >= from.Date && t.ConfirmedDeliveryTimeStamp.Value.Date <= to.Date))
                .ToList());
        }
    }
}