using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ProductColorDataService : AuditableDataService<ProductColor>, IProductColorDataService
    {
        public ProductColorDataService(IProductColorRepository productColorRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :

            base(productColorRepository,
                 userActivityRepository,
                 context,
                 policy,
                 entityName: "ProductColor")
        {
        }

        protected override string CreateUserActivitySuffixIdentifier(ProductColor entity) => string.Empty;

        protected override string GetUserActivityName(ProductColor entity) => _entityName;
    }
}