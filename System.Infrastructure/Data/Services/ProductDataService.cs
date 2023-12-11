using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ProductDataService : AuditableDataService<Product>, IProductDataService
    {
        private readonly IProductRepository _productRepository;

        public ProductDataService(IProductRepository productRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :

            base(productRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "Product")
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetManyByProductCodesAsync(int organizationId, string[] productCodes) => await _productRepository.GetManyByProductCodesAsync(organizationId: organizationId, productCodes: productCodes);

        public async Task<List<Product>> GetManyByOrganizationIdAsync(int organizationId) => await _productRepository.GetManyByOrganizationIdAsync(organizationId);

        protected override string CreateUserActivitySuffixIdentifier(Product entity) => $" with `code` '{entity.ProductCode}', `sku` '{entity.SKU}', `sku2` '{entity.SKU2}', `unit of measure` '{entity.UnitOfMeasure}', `unit price` '{entity.UnitPrice}', and `status` is '{entity.Status}'";

        protected override string GetUserActivityName(Product entity) => _entityName;
    }
}