using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class PositionViewRepository : SavableRepository<PositionView>, IPositionViewRepository
    {
        public PositionViewRepository(SystemContext context) : base(context)
        {
        }

        public async Task<List<PositionView>> GetManyByPositionIdAsync(int organizationId, int positionId) => await _context.PositionViews
            .Include(t => t.Position)
            .Include(t => t.View)
            .Where(t => t.OrganizationID == organizationId)
            .Where(t => t.PositionID == positionId)
            .ToListAsync();
    }
}