using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Services.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ProductDataService : BaseSavableDataService<Product>, IProductDataService
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
    }
}