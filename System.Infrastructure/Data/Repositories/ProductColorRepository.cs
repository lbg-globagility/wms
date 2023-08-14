using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class ProductColorRepository : SavableRepository<ProductColor>, IProductColorRepository
    {
        public ProductColorRepository(SystemContext context) : base(context)
        {
        }
    }
}
