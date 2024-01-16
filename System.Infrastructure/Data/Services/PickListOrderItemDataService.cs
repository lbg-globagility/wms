using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class PickListOrderItemDataService : AuditableDataService<PickListOrderItem>, IPickListOrderItemDataService
    {
        public PickListOrderItemDataService(IPickListOrderItemRepository pickListOrderItemRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :
            
            base(pickListOrderItemRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "PickListOrderItem")
        {
        }

        protected override string CreateUserActivitySuffixIdentifier(PickListOrderItem entity) => $"{_entityName}.RowID: {entity.RowID}";

        protected override string GetUserActivityName(PickListOrderItem entity) => _entityName;
    }
}
