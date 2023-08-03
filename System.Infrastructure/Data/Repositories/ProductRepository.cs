using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class ProductRepository : SavableRepository<Product>, IProductRepository
    {
        public ProductRepository(SystemContext context) : base(context)
        {
        }
    }
}