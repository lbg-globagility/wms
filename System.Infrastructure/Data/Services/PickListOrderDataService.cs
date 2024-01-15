using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class PickListOrderDataService : AuditableDataService<PickListOrder>, IPickListOrderDataService
    {
        public PickListOrderDataService(IPickListOrderRepository pickListOrderRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :
            
            base(pickListOrderRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "PickListOrder")
        {
        }

        protected override string CreateUserActivitySuffixIdentifier(PickListOrder entity) => $"{_entityName}.RowID: {entity.RowID}";

        protected override string GetUserActivityName(PickListOrder entity) => _entityName;
    }
}
