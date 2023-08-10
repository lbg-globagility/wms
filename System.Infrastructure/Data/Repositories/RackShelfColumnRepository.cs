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
    }
}