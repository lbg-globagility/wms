using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Exceptions;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Extensions;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class LineupDataService : AuditableDataService<Lineup>, ILineupDataService
    {
        private readonly ILineupRepository _lineupRepository;
        private readonly IProductInventoryLocationDataService _productInventoryLocationDataService;
        private readonly IPackingListDataService _packingListDataService;
        private readonly IOrderDataService _orderDataService;
        private readonly IPickListOrderDataService _pickListOrderDataService;

        public LineupDataService(ILineupRepository lineupRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IProductInventoryLocationDataService productInventoryLocationDataService,
            IPackingListDataService packingListDataService,
            IOrderDataService orderDataService,
            IPickListOrderDataService pickListOrderDataService) :

            base(lineupRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "Lineup")
        {
            _lineupRepository = lineupRepository;
            _productInventoryLocationDataService = productInventoryLocationDataService;
            _packingListDataService = packingListDataService;
            _orderDataService = orderDataService;
            _pickListOrderDataService = pickListOrderDataService;
        }

        public async Task CancelDeliveryAsync(int lineupId, int userId)
        {
            var lineup = await GetByLineupIdAsync(lineupId: lineupId);

            if (lineup.IsCancelled) BusinessLogicException.Throw("Invalid command: Delivery already cancelled.");

            lineup.SetStatusToCancelled();

            await SaveManyAsync(userId: userId, updated: new List<Lineup>() { lineup });
        }

        public async Task ConfirmDeliveryAsync(int lineupId, int userId, DateTime dateTime)
        {
            var lineup = await GetByLineupIdAsync(lineupId: lineupId);

            if (lineup.IsConfirmedDelivery) BusinessLogicException.Throw("Invalid command: Delivery already confirmed.");

            lineup.SetConfirmedDeliveryTimeStamp(dateTime: dateTime);

            var order = lineup.Order;
            var productColorSizeIds = new List<int>();
            var inventoryLocationIds = new List<int>();
            foreach (var item1 in lineup.LineupCartons)
            {
                var packingListCartonItems = item1.PackingListCarton.PackingListCartonItems;
                if (!packingListCartonItems.Any())
                    continue;

                foreach (var packingListCartonItem in packingListCartonItems)
                    productColorSizeIds.Add(packingListCartonItem.OrderItem.ProductColorSizeID.Value);

                foreach (var packingListCartonItem in packingListCartonItems)
                    inventoryLocationIds.Add(packingListCartonItem.OrderItem.ProductInventoryLocation.RackShelfColumn.InventoryLocationID);
            }

            var productInventoryLocations = await _productInventoryLocationDataService.GetByInventoryLocationIdsAndProductColorSizeIdsAsync(
                inventoryLocationIds: inventoryLocationIds.ToArray(),
                productColorSizeIds: productColorSizeIds.ToArray());

            // For Each productColorSizeId In productColorSizeIds
            // Next
            var updatedProductInventoryLocations = new List<ProductInventoryLocation>();
            foreach (var item1 in lineup.LineupCartons)
            {
                var packingListCartonItems = item1.PackingListCarton.PackingListCartonItems;
                if (!packingListCartonItems.Any())
                    continue;

                foreach (var packingListCartonItem in packingListCartonItems)
                {
                    var isSameOrderItemId = packingListCartonItem.PickListOrder.OrderItemID == (packingListCartonItem.OrderItemID ?? 0);
                    var pickListOrderItems = packingListCartonItem.PickListOrder.PickListOrderItems?
                        .Where(t => t.IsVerified);

                    if (!isSameOrderItemId && !(pickListOrderItems?.Any() ?? false)) continue;

                    var productColorSizeId = packingListCartonItem.OrderItem.ProductColorSizeID.Value;
                    var inventoryLocationId = packingListCartonItem.OrderItem.ProductInventoryLocation.RackShelfColumn.InventoryLocationID;
                    var productInventoryLocation = productInventoryLocations
                        .ToList()
                        .BestOrDefault(inventoryLocationId: inventoryLocationId, productColorSizeId: productColorSizeId);
                    //.Where(t => t.ProductColorSizeID == productColorSizeId)
                    //.Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)
                    ////.Where(t => (t.TotalReserveQty ?? 0) > 0 && (t.TotalReserveQty ?? 0) >= (packingListCartonItem.QtyInCarton ?? 0))
                    //.FirstOrDefault();

                    if (productInventoryLocation == null)
                        continue;

                    var qty = packingListCartonItem.QtyInCarton ?? 0;

                    // DO NOT DO THIS HERE. IT IS ALREADY PERFORMED SOMEWHERE ELSE
                    //productInventoryLocation.TotalReserveQty -= qty;

                    productInventoryLocation.TotalAvailableQty -= qty;

                    updatedProductInventoryLocations.Add(productInventoryLocation);
                }
            }

            await _productInventoryLocationDataService.SaveManyAsync(userId: userId, updated: updatedProductInventoryLocations);

            await SaveManyAsync(userId: userId, updated: new List<Lineup>() { lineup });
        }

        public async Task<Lineup> GetByLineupIdAsync(int lineupId) => await _lineupRepository.GetByLineupIdAsync(lineupId);

        public async Task<List<Lineup>> GetByOrganizationIdAndDateRangeAsync(int organizationId, DateTime from, DateTime to) => await _lineupRepository.GetByOrganizationIdAndDateRangeAsync(organizationId, from: from, to: to);

        public async Task<List<Lineup>> GetManyByOrderIdAsync(int orderId) => await _lineupRepository.GetManyByOrderIdAsync(orderId);

        protected override string CreateUserActivitySuffixIdentifier(Lineup entity) => $"LineUpNo: {entity.LineUpNo}, Date: {entity.LineUpDate}, and OrderId: {entity.OrderID}";

        protected override string GetUserActivityName(Lineup entity) => _entityName;
    }
}
