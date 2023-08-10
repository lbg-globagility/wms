using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class ProductColorSizeRepository : SavableRepository<ProductColorSize>, IProductColorSizeRepository
    {
        public ProductColorSizeRepository(SystemContext context) : base(context)
        {
        }
    }
}