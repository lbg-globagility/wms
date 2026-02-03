using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Extensions;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class PickListOrderDataService : AuditableDataService<PickListOrder>, IPickListOrderDataService
    {
        private readonly IPickListOrderRepository _pickListOrderRepository;
        private readonly IOrderDataService _orderDataService;
        private readonly IOrderItemDataService _orderItemDataService;
        private readonly IPickListOrderItemDataService _pickListOrderItemDataService;
        private readonly IProductInventoryLocationDataService _productInventoryLocationDataService;
        private readonly IMovementHistoryDataService _movementHistoryDataService;

        public PickListOrderDataService(IPickListOrderRepository pickListOrderRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IOrderDataService orderDataService,
            IOrderItemDataService orderItemDataService,
            IPickListOrderItemDataService pickListOrderItemDataService,
            IProductInventoryLocationDataService productInventoryLocationDataService,
            IMovementHistoryDataService movementHistoryDataService) :

            base(pickListOrderRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "PickListOrder")
        {
            _pickListOrderRepository = pickListOrderRepository;
            _orderDataService = orderDataService;
            _orderItemDataService = orderItemDataService;
            _pickListOrderItemDataService = pickListOrderItemDataService;
            _productInventoryLocationDataService = productInventoryLocationDataService;
            _movementHistoryDataService = movementHistoryDataService;
        }

        public async Task<ICollection<PickListOrder>> GetManyByOrderIdAsync(int orderId) => await _pickListOrderRepository.GetManyByOrderIdAsync(orderId: orderId);

        protected override string CreateUserActivitySuffixIdentifier(PickListOrder entity) => $"{_entityName}.RowID: {entity.RowID}";

        protected override string GetUserActivityName(PickListOrder entity) => _entityName;

        public async Task VerifyAsync(int userId, List<PickListOrder> pickListOrders)
        {
            if (!(pickListOrders?.Any() ?? false)) return;

            var orderIds = pickListOrders.GroupBy(t => t.OrderID)
                .Select(t => t.Key)
                .ToArray();
            var orders = await _orderDataService.GetManyByIdsAsync(ids: orderIds);

            var updatedOrders = new List<Order>();
            var updatedOrderItems = new List<OrderItem>();

            orders.ForEach(t =>
            {
                if (pickListOrders?.Any(x => x.OrderID == t.RowID && x.IsVerifiedStatus) ?? false)
                {
                    t.Status = OrderStatus.ForPacking;
                    t.SetEdited();

                    foreach (var item in t.OrderItems)
                    {
                        item.Status = OrderItemStatus.Verified;
                        item.SetEdited();
                        updatedOrderItems.Add(item);
                    }
                    updatedOrders.Add(t);
                }
            });

            var verifiedPickListOrders = pickListOrders.Where(t => t.IsVerifiedStatus);
            var pickListOrderItems = verifiedPickListOrders.Select(t => t.PickListOrderItem).ToList();
            pickListOrderItems?.ForEach(t =>
            {
                t.Status = PickListOrderItemStatus.Verified;
                t.SetEdited();
            });

            // increments ProductInventoryLocation.TotalReserveQty
            var inventoryLocationIds = updatedOrderItems.Select(t => t.InventoryLocationId ?? 0).ToArray();
            var productColorSizeIds = updatedOrderItems.Select(t => t.ProductColorSizeID ?? 0).ToArray();
            var productInventoryLocations = await _productInventoryLocationDataService.GetByInventoryLocationIdsAndProductColorSizeIdsAsync(
                inventoryLocationIds: inventoryLocationIds,
                productColorSizeIds: productColorSizeIds);

            var updatedProductInventoryLocations = new List<ProductInventoryLocation>();
            var movementHistoryItems = new List<MovementHistory>();
            foreach (var pickListOrder in verifiedPickListOrders)
            {
                var productColorSizeId = pickListOrder.OrderItem.ProductColorSizeID ?? 0;
                var productInventoryLocation = productInventoryLocations.ToList()
                    .BestOrDefault(
                        inventoryLocationId: pickListOrder.OrderItem.InventoryLocationId ?? 0,
                        productColorSizeId: productColorSizeId);

                if (productInventoryLocation == null) continue;

                var qty = pickListOrder.PickListOrderItem.QtyPicked ?? 0;

                movementHistoryItems.Add(MovementHistory.NewMovementHistory(organizationId: pickListOrder.OrganizationID ?? 0,
                    userId: userId,
                    productColorSizeID: productColorSizeId,
                    orderId: pickListOrder.OrderID,
                    productInventoryLocationId: pickListOrder.OrderItem.ProductInventoryLocationId ?? 0,
                    currentQty: productInventoryLocation.TotalReserveQty ?? 0,
                    qtyToApply: qty,
                    transactionType: MovementHistory.VERIFY_PL_QR,
                    columnName: MovementHistory.COLUMN_TOTAL_RESERVE_QTY));

                productInventoryLocation.TotalReserveQty = (productInventoryLocation.TotalReserveQty ?? 0) + qty;

                productInventoryLocation.SetEdited();

                updatedProductInventoryLocations.Add(productInventoryLocation);

            }

            if (pickListOrderItems?.Any() ?? false) await _pickListOrderItemDataService.SaveManyAsync(userId: userId, updated: pickListOrderItems);

            if (updatedOrderItems?.Any() ?? false) await _orderItemDataService.SaveManyAsync(userId: userId, updated: updatedOrderItems);

            if (updatedOrders?.Any() ?? false) await _orderDataService.SaveManyAsync(userId: userId, updated: updatedOrders);

            if (updatedProductInventoryLocations?.Any() ?? false) await _productInventoryLocationDataService.SaveManyAsync(userId: userId, updated: updatedProductInventoryLocations);

            if (movementHistoryItems?.Any() ?? false) await _movementHistoryDataService.SaveManyAsync(userId: userId, added: movementHistoryItems);

            await base.SaveManyAsync(
                userId,
                updated: pickListOrders);
        }
    }
}
