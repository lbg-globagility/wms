using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class LineupRepository : SavableRepository<Lineup>, ILineupRepository
    {
        public LineupRepository(SystemContext context) : base(context)
        {
        }
    }
}