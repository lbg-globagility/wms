using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Helpers;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class PickListDataService : AuditableDataService<PickList>, IPickListDataService
    {
        private readonly IPickListRepository _pickListRepository;
        private readonly IPickListOrderDataService _pickListOrderDataService;
        private readonly IPickListOrderItemDataService _pickListOrderItemDataService;

        public PickListDataService(IPickListRepository pickListRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IPickListOrderDataService pickListOrderDataService,
            IPickListOrderItemDataService pickListOrderItemDataService) :

            base(pickListRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "PickList")
        {
            _pickListRepository = pickListRepository;
            _pickListOrderDataService = pickListOrderDataService;
            _pickListOrderItemDataService = pickListOrderItemDataService;
        }

        public async Task<PickList> GetByOrderIdAsync(int orderId) => await _pickListRepository.GetByOrderIdAsync(orderId);

        protected override string CreateUserActivitySuffixIdentifier(PickList entity) => $"PickListNo: {entity.PickListNo}";

        protected override string GetUserActivityName(PickList entity) => _entityName;

        public override async Task SaveManyAsync(
            int userId,
            List<PickList> added = null,
            List<PickList> updated = null,
            List<PickList> deleted = null)
        {
            if (updated != null && updated.Any())
            {
                var updatePickListOrders = new List<PickListOrder>();
                var updatePickListOrderItems = new List<PickListOrderItem>();

                foreach (var pickList in updated)
                    foreach (var pickListOrder in pickList.PickListOrders.Where(t => t.IsEdited))
                    {
                        updatePickListOrders.Add(pickListOrder);
                        foreach (var item in pickListOrder.PickListOrderItems.Where(t => t.IsEdited))
                            updatePickListOrderItems.Add(item: item);
                    }

                if (updatePickListOrderItems?.Any() ?? false) await _pickListOrderItemDataService.SaveManyAsync(userId: userId, updated: updatePickListOrderItems);

                if (updatePickListOrders?.Any() ?? false) await _pickListOrderDataService.SaveManyAsync(userId: userId, updated: updatePickListOrders);
            }

            await base.SaveManyAsync(
                userId: userId,
                added: added,
                updated: updated,
                deleted: deleted);
        }

        public async Task<PaginatedList<PickList>> GetPaginatedPickListsAsync(PageOptions pageOptions, int organizationId, string searchText = "") => await _pickListRepository.GetPaginatedPickListsAsync(pageOptions: pageOptions, organizationId: organizationId, searchText: searchText);
    }
}
