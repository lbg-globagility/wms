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
            .Include(t => t.LineupCartons)
                .ThenInclude(t => t.PackingListCarton)
                    .ThenInclude(t => t.PackingListCartonItems)
                        .ThenInclude(t => t.PickListOrder)
                            .ThenInclude(t=>t.PickListOrderItems)
            .Where(t => t.LineupCartons.FirstOrDefault().LineUpID == lineUpId)
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
    }
}