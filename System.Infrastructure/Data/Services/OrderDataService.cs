using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Services.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class OrderDataService : BaseSavableDataService<Order>, IOrderDataService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderDataService(IOrderRepository orderRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :

            base(orderRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "Order")
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> QuickCreateStockTransferOrderAsync(int organizationId, int userId)
        {
            var lastOrder = await _orderRepository.GetLastOrderOfThisTypeAsync(organizationId: organizationId, orderType: OrderType.ST);
            var orderNumber = 1;
            if (lastOrder != null) orderNumber = lastOrder.OrderNumberInt + orderNumber;

            var stockTransferOrder = Order.NewStockTransferOrder(organizationId: organizationId,
                userId: userId,
                orderNumber: $"{orderNumber}",
                status: OrderStatus.Approved.ToString(),
                orderDate: System.DateTime.Now);

            await _orderRepository.SaveAsync(entity: stockTransferOrder);

            return stockTransferOrder;
        }
    }
}