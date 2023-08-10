using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Services.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class InventoryLocationDataService : BaseSavableDataService<InventoryLocation>, IInventoryLocationDataService
    {
        private readonly IProductColorSizeRepository _productColorSizeRepository;
        private readonly IInventoryLocationRepository _inventoryLocationRepository;
        private readonly IProductInventoryLocationRepository _productInventoryLocationRepository;
        private readonly IRackShelfColumnRepository _rackShelfColumnRepository;

        public InventoryLocationDataService(IInventoryLocationRepository inventoryLocationRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,

            IProductColorSizeRepository productColorSizeRepository,
            IProductInventoryLocationRepository productInventoryLocationRepository,
            IRackShelfColumnRepository rackShelfColumnRepository) :

            base(inventoryLocationRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "InventoryLocation")
        {
            _productColorSizeRepository = productColorSizeRepository;
            _inventoryLocationRepository = inventoryLocationRepository;
            _productInventoryLocationRepository = productInventoryLocationRepository;
            _rackShelfColumnRepository = rackShelfColumnRepository;
        }

        public async Task PopulateWithProductColorSizesAsync(string inventoryLocationName, int userId)
        {
            var inventoryLocation = await _inventoryLocationRepository.GetByNameAsync(inventoryLocationName);

            if (inventoryLocation == null) return;

            await PopulateWithProductColorSizesAsync(inventoryLocation: inventoryLocation, userId: userId);
        }

        private async Task PopulateWithProductColorSizesAsync(InventoryLocation inventoryLocation, int userId)
        {
            var organizationId = inventoryLocation.OrganizationID.Value;

            var allProductColorSizes = await _productColorSizeRepository.GetManyByOrganizationIdsAsync(organizationId);

            var inventoryLocationProductColorSizes = await _productInventoryLocationRepository.GetProductColorSizesByInventoryLocationIdAsync(inventoryLocation.RowID.Value);
            var inventoryLocationProductColorSizeIds = inventoryLocationProductColorSizes
                .Select(t => t.ProductColorSizeID)
                .ToArray();

            var addedProductInventoryLocation = new List<ProductInventoryLocation>();

            var addedRackShelfColumn = new List<RackShelfColumn>();

            var nonExistentProductColorSizes = allProductColorSizes
                .Where(t => !inventoryLocationProductColorSizeIds.Contains(t.RowID.Value))
                .OrderByDescending(t => t.TotalAvailableQty)
                .Take(1000)
                .ToList();

            inventoryLocation.PopulateWithRackShelfColumns(organizationId: organizationId,
                userId: userId,
                nonExistentProductColorSizes: nonExistentProductColorSizes);

            await _rackShelfColumnRepository.SaveManyAsync(added: inventoryLocation.RackShelfColumns.ToList());
        }

        public async Task PopulateWithProductColorSizesAsync(int inventoryLocationId, int userId)
        {
            if (inventoryLocationId <= 0) return;

            var inventoryLocation = await _inventoryLocationRepository.GetByIdAsync(inventoryLocationId);

            var organizationId = inventoryLocation.OrganizationID.Value;

            var allProductColorSizes = await _productColorSizeRepository.GetManyByOrganizationIdsAsync(organizationId);

            var inventoryLocationProductColorSizes = await _productInventoryLocationRepository.GetProductColorSizesByInventoryLocationIdAsync(inventoryLocationId);
            var inventoryLocationProductColorSizeIds = inventoryLocationProductColorSizes
                .Select(t => t.ProductColorSizeID)
                .ToArray();

            var addedProductInventoryLocation = new List<ProductInventoryLocation>();

            var addedRackShelfColumn = new List<RackShelfColumn>();

            var nonExistentProductColorSizes = allProductColorSizes
                .Where(t => !inventoryLocationProductColorSizeIds.Contains(t.RowID.Value))
                .OrderByDescending(t => t.TotalAvailableQty)
                .Take(1000)
                .ToList();

            inventoryLocation.PopulateWithRackShelfColumns(organizationId: organizationId,
                userId: userId,
                nonExistentProductColorSizes: nonExistentProductColorSizes);

            await SaveAsync(entity: inventoryLocation, userId: userId);
        }
    }
}