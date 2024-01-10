using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class LineupDataService : AuditableDataService<Lineup>, ILineupDataService
    {
        private readonly ILineupRepository _lineupRepository;

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
            _lineupRepository = lineupRepository;
        }

        public async Task<Lineup> GetByLineupIdAsync(int lineupId) => await _lineupRepository.GetByLineupIdAsync(lineupId);

        protected override string CreateUserActivitySuffixIdentifier(Lineup entity) => $"LineUpNo: {entity.LineUpNo}, Date: {entity.LineUpDate}, and OrderId: {entity.OrderID}";

        protected override string GetUserActivityName(Lineup entity) => _entityName;
    }
}
