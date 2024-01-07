using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class LineupDataService : AuditableDataService<Lineup>, ILineupDataService
    {
        public LineupDataService(ILineupRepository lineupRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) : 
            
            base(lineupRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "Lineup")
        {
        }

        protected override string CreateUserActivitySuffixIdentifier(Lineup entity) => $"LineUpNo: {entity.LineUpNo}, Date: {entity.LineUpDate}, and OrderId: {entity.OrderID}";

        protected override string GetUserActivityName(Lineup entity) => _entityName;
    }
}
