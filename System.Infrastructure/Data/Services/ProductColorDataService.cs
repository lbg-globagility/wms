using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ProductColorDataService : AuditableDataService<ProductColor>, IProductColorDataService
    {
        private readonly IProductColorRepository _productColorRepository;
        private readonly IProductColorSizeDataService _productColorSizeDataService;

        public ProductColorDataService(IProductColorRepository productColorRepository,
            IUserActivityRepository userActivityRepository,
            IProductColorSizeDataService productColorSizeDataService,
            SystemContext context,
            IPolicyHelper policy) :

            base(productColorRepository,
                 userActivityRepository,
                 context,
                 policy,
                 entityName: "ProductColor")
        {
            _productColorRepository = productColorRepository;
            _productColorSizeDataService = productColorSizeDataService;
        }

        public async Task<List<ProductColor>> GetByOrganizationAsync(int organizationId) => await _productColorRepository.GetByOrganizationAsync(organizationId);

        public async Task SaveManyChangesAsync(int userId,
            List<ProductColor> added = null,
            List<ProductColor> updated = null,
            List<ProductColor> deleted = null)
        {
            if (updated != null && updated.Any())
            {
                var newProductColorSizes = new List<ProductColorSize>();

                updated.ToList().ForEach(pc =>
                {
                    var addedProductColorSizes = pc.ProductColorSizes.Where(pcs => pcs.IsNewEntity);
                    addedProductColorSizes.ToList().ForEach(pcs => pcs.ProductColorID = pc.RowID.Value);
                    newProductColorSizes.AddRange(addedProductColorSizes);
                });

                await _productColorSizeDataService.SaveManyAsync(userId: userId, added: newProductColorSizes);
            }

            await SaveManyAsync(
                userId: userId,
                added: added,
                updated: updated,
                deleted: deleted);
        }

        protected override string CreateUserActivitySuffixIdentifier(ProductColor entity) => string.Empty;

        protected override string GetUserActivityName(ProductColor entity) => _entityName;
    }
}