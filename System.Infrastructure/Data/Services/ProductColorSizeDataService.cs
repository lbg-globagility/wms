using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ProductColorSizeDataService : AuditableDataService<ProductColorSize>, IProductColorSizeDataService
    {
        public ProductColorSizeDataService(IProductColorSizeRepository productColorSizeRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) : 
            
            base(productColorSizeRepository,
                 userActivityRepository,
        context,
        policy,
        entityName: "ProductColorSize")
        {
        }

        protected override string CreateUserActivitySuffixIdentifier(ProductColorSize entity) => string.Empty;

        protected override string GetUserActivityName(ProductColorSize entity) => _entityName;
    }
}
