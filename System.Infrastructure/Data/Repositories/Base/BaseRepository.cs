using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories.Base
{
    public abstract class BaseRepository : IBaseRepository
    {
        public bool IsNewEntity(int? id) => BaseEntity.CheckIfNewEntity(id);
    }
}