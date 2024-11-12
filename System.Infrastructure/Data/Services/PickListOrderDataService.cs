using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class PickListOrderDataService : AuditableDataService<PickListOrder>, IPickListOrderDataService
    {
        private readonly IPickListOrderRepository _pickListOrderRepository;
        private readonly IOrderDataService _orderDataService;
        private readonly IOrderItemDataService _orderItemDataService;
        private readonly IPickListOrderItemDataService _pickListOrderItemDataService;

        public PickListOrderDataService(IPickListOrderRepository pickListOrderRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IOrderDataService orderDataService,
            IOrderItemDataService orderItemDataService,
            IPickListOrderItemDataService pickListOrderItemDataService) :
            
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
        }

        public async Task<ICollection<PickListOrder>> GetByOrderIdAsync(int orderId) => await _pickListOrderRepository.GetByOrderIdAsync(orderId: orderId);

        protected override string CreateUserActivitySuffixIdentifier(PickListOrder entity) => $"{_entityName}.RowID: {entity.RowID}";

        protected override string GetUserActivityName(PickListOrder entity) => _entityName;

        public override async Task SaveManyAsync(int userId,
            List<PickListOrder> added = null,
            List<PickListOrder> updated = null,
            List<PickListOrder> deleted = null)
        {
            if (updated?.Any() ?? false)
            {
                var orderIds = updated.GroupBy(t => t.OrderID)
                    .Select(t => t.Key)
                    .ToArray();
                var orders = await _orderDataService.GetManyByIdsAsync(ids: orderIds);

                var updatedOrderItems = new List<OrderItem>();

                orders.ForEach(t =>
                {
                    if (updated?.Any(x => x.OrderID == t.RowID && x.IsVerifiedStatus) ?? false)
                    {
                        t.Status = OrderStatus.ForPacking;
                        t.SetEdited();

                        foreach (var item in t.OrderItems)
                        {
                            item.Status = OrderItemStatus.Verified;
                            item.SetEdited();
                            updatedOrderItems.Add(item);
                        }
                    }
                });

                var pickListOrderItems = updated.Where(t => t.IsVerifiedStatus).Select(t => t.PickListOrderItem).ToList();
                pickListOrderItems?.ForEach(t =>
                {
                    t.Status = PickListOrderItemStatus.Verified;
                    t.SetEdited();
                });

                if(pickListOrderItems?.Any() ?? false) await _pickListOrderItemDataService.SaveManyAsync(userId: userId, updated: pickListOrderItems);

                if (updatedOrderItems?.Any() ?? false) await _orderItemDataService.SaveManyAsync(userId: userId, updated: updatedOrderItems);

                if (orders?.Any() ?? false) await _orderDataService.SaveManyAsync(userId: userId, updated: orders);
            }

            await base.SaveManyAsync(
                userId,
                added,
                updated,
                deleted);
        }
    }
}
