using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Exceptions;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class LineupDataService : AuditableDataService<Lineup>, ILineupDataService
    {
        private readonly ILineupRepository _lineupRepository;
        private readonly IProductInventoryLocationDataService _productInventoryLocationDataService;
        private readonly IPackingListDataService _packingListDataService;
        private readonly IPickListDataService _pickListDataService;
        private readonly IOrderDataService _orderDataService;
        private readonly IPickListOrderDataService _pickListOrderDataService;

        public LineupDataService(ILineupRepository lineupRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IProductInventoryLocationDataService productInventoryLocationDataService,
            IPackingListDataService packingListDataService,
            IPickListDataService pickListDataService,
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
            _pickListDataService = pickListDataService;
            _orderDataService = orderDataService;
            _pickListOrderDataService = pickListOrderDataService;
        }

        public async Task CancelDeliveryAsync(int lineupId, int userId)
        {
            var lineup = await GetByLineupIdAsync(lineupId: lineupId);

            if (lineup.IsCancelled) BusinessLogicException.Throw("Invalid command: Delivery already cancelled.");

            var order = lineup.Order;
            var pcsIdsAndinvIds = new List<(int pcsId, int invId)>();
            foreach (var item1 in lineup.LineupCartons)
            {
                var packingListCartonItems = item1.PackingListCarton.PackingListCartonItems;
                if (!(packingListCartonItems?.Any() ?? false))
                    continue;

                foreach (var packingListCartonItem in packingListCartonItems)
                    pcsIdsAndinvIds.Add((pcsId: packingListCartonItem.OrderItem.ProductColorSizeID.Value, invId: packingListCartonItem.OrderItem.ProductInventoryLocation.RackShelfColumn.InventoryLocationID));
            }

            var productInventoryLocations = await _productInventoryLocationDataService.GetByProductColorSizeIdsAndInventoryLocationIdsAsync(
                organizationId: lineup.OrganizationID ?? 0,
                userId: userId,
                productColorSizeIdsAndInventoryIds: pcsIdsAndinvIds);

            var updatedProductInventoryLocations = new List<ProductInventoryLocation>();
            var orderItemIds = new List<int?>();
            foreach (var lineupCarton in lineup.LineupCartons)
            {
                var packingListCartonItems = lineupCarton.PackingListCarton.PackingListCartonItems;
                if (!packingListCartonItems.Any())
                    continue;

                foreach (var packingListCartonItem in packingListCartonItems)
                {
                    var productColorSizeId = packingListCartonItem.OrderItem.ProductColorSizeID.Value;
                    orderItemIds.Add(packingListCartonItem.OrderItem.RowID);
                    var productInventoryLocation = productInventoryLocations
                        .Where(t => t.ProductColorSizeID == productColorSizeId)
                        .Where(t => (t.TotalReserveQty ?? 0) > 0 && (t.TotalReserveQty ?? 0) >= (packingListCartonItem.QtyInCarton ?? 0))
                        .FirstOrDefault();

                    if (productInventoryLocation == null)
                        continue;

                    var qty = packingListCartonItem?.OrderItem?.QtyOrdered ?? packingListCartonItem.QtyInCarton ?? 0;

                    productInventoryLocation.TotalReserveQty -= qty;

                    //productInventoryLocation.TotalAvailableQty -= qty;

                    updatedProductInventoryLocations.Add(productInventoryLocation);
                }
            }

            var packingList = await _packingListDataService.GetByOrderIdAsync(orderId: order.RowID.Value);
            packingList.SetStatusToCancelled();
            await _packingListDataService.SaveManyAsync(userId: userId, updated: new List<PackingList>() { packingList });

            var pickListOrders = await _pickListOrderDataService.GetManyByOrderIdAsync(orderId: order.RowID.Value);
            var updatedPickListOrders = new List<PickListOrder>();
            foreach (var pickListOrder in pickListOrders.Where(t => orderItemIds.Contains(t.OrderItemID)))
            {
                pickListOrder.SetStatusToCancelled();
                updatedPickListOrders.Add(pickListOrder);
            }
            await _pickListOrderDataService.SaveManyAsync(updated: updatedPickListOrders, userId: userId);

            await _productInventoryLocationDataService.SaveManyAsync(userId: userId, updated: updatedProductInventoryLocations);

            var customerOrder = await _orderDataService.GetCustomerOrderAsync(primaryKey: order.RowID.Value);
            await _orderDataService.RevokeCustomerOrder(order: customerOrder, userId: userId);

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
                        .Where(t => t.ProductColorSizeID == productColorSizeId)
                        .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)
                        .Where(t => (t.TotalReserveQty ?? 0) > 0 && (t.TotalReserveQty ?? 0) >= (packingListCartonItem.QtyInCarton ?? 0))
                        .FirstOrDefault();

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

        protected override string CreateUserActivitySuffixIdentifier(Lineup entity) => $"LineUpNo: {entity.LineUpNo}, Date: {entity.LineUpDate}, and OrderId: {entity.OrderID}";

        protected override string GetUserActivityName(Lineup entity) => _entityName;
    }
}
