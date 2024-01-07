
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class PackingListCartonDataService : AuditableDataService<PackingListCarton>, IPackingListCartonDataService
    {
        public PackingListCartonDataService(IPackingListCartonRepository packingListCartonRepositry,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) : 
            
            base(packingListCartonRepositry,
                userActivityRepository,
                context,
                policy,
                entityName: "PackingListCarton")
        {
        }

        protected override string CreateUserActivitySuffixIdentifier(PackingListCarton entity) => $"CartonNo: {entity.CartonNo}";

        protected override string GetUserActivityName(PackingListCarton entity) => _entityName;

    }
}
