
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class PackingListCartonDataService : AuditableDataService<PackingListCarton>, IPackingListCartonDataService
    {
        private readonly IPackingListCartonRepository _packingListCartonRepositry;

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
            _packingListCartonRepositry = packingListCartonRepositry;
        }

        protected override string CreateUserActivitySuffixIdentifier(PackingListCarton entity) => $"CartonNo: {entity.CartonNo}";

        protected override string GetUserActivityName(PackingListCarton entity) => _entityName;

    }
}
