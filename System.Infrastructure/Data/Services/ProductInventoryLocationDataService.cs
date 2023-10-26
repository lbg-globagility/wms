using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Services.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ProductInventoryLocationDataService : BaseSavableDataService<ProductInventoryLocation>, IProductInventoryLocationDataService
    {
        private readonly IProductInventoryLocationRepository _productInventoryLocationRepository;

        public ProductInventoryLocationDataService(IProductInventoryLocationRepository productInventoryLocationRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :

            base(productInventoryLocationRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "ProductInventoryLocation")
        {
            _productInventoryLocationRepository = productInventoryLocationRepository;
        }

        public async Task<List<ProductInventoryLocation>> GetByInventoryLocationIdAsync(int inventoryLocationId) =>
            await _productInventoryLocationRepository.GetByInventoryLocationIdAsync(inventoryLocationId: inventoryLocationId);
    }
}