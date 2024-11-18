using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ProductColorSizeDataService : AuditableDataService<ProductColorSize>, IProductColorSizeDataService
    {
        private readonly IProductColorSizeRepository _productColorSizeRepository;

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
            _productColorSizeRepository = productColorSizeRepository;
        }

        public async Task<List<ProductColorSize>> GetManyByIdsAsync(int[] ids) => (await _productColorSizeRepository.GetManyByIdsAsync(ids: ids)).ToList();

        protected override string CreateUserActivitySuffixIdentifier(ProductColorSize entity) => string.Empty;

        protected override string GetUserActivityName(ProductColorSize entity) => _entityName;
    }
}
