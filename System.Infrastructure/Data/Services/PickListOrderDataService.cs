using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class PickListOrderDataService : AuditableDataService<PickListOrder>, IPickListOrderDataService
    {
        private readonly IPickListOrderRepository _pickListOrderRepository;

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
            _pickListOrderRepository = pickListOrderRepository;
        }

        public async Task<ICollection<PickListOrder>> GetByOrderIdAsync(int orderId) => await _pickListOrderRepository.GetByOrderIdAsync(orderId: orderId);

        protected override string CreateUserActivitySuffixIdentifier(PickListOrder entity) => $"{_entityName}.RowID: {entity.RowID}";

        protected override string GetUserActivityName(PickListOrder entity) => _entityName;
    }
}
