using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class MovementHistoryRepository : SavableRepository<MovementHistory>, IMovementHistoryRepository
    {
        public MovementHistoryRepository(SystemContext context) : base(context)
        {
        }
    }
}