using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class UserRepository : SavableRepository<User>, IUserRepository
    {
        public UserRepository(SystemContext context) : base(context)
        {
        }
    }
}