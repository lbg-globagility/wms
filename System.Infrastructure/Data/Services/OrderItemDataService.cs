using System;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class OrderItemDataService : AuditableDataService<OrderItem>, IOrderItemDataService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemDataService(IOrderItemRepository orderItemRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :
            
            base(orderItemRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "OrderItem")
        {
            _orderItemRepository = orderItemRepository;
        }

        protected override string CreateUserActivitySuffixIdentifier(OrderItem entity) => $"ProductColorSizeID: {entity.ProductColorSizeID}";

        protected override string GetUserActivityName(OrderItem entity) => _entityName;
    }
}