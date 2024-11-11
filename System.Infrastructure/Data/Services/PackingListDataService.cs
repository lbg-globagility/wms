using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class PackingListDataService : AuditableDataService<PackingList>, IPackingListDataService
    {
        private readonly IPackingListRepository _packingListRepository;
        private readonly IPackingListCartonDataService _packingListCartonDataService;

        public PackingListDataService(IPackingListRepository packingListRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IPackingListCartonDataService packingListCartonDataService) : 
            
            base(packingListRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "PackingList")
        {
            _packingListRepository = packingListRepository;
            _packingListCartonDataService = packingListCartonDataService;
        }

        protected override string CreateUserActivitySuffixIdentifier(PackingList entity) => $"Packing List No.: {entity.PackingListNo} and status: {entity.Status}";

        protected override string GetUserActivityName(PackingList entity) => _entityName;

        public override async Task SaveManyAsync(int userId,
            List<PackingList> added = null,
            List<PackingList> updated = null,
            List<PackingList> deleted = null)
        {
            if (updated != null && updated.Any())
            {
                var packingListCartons = new List<PackingListCarton>();

                foreach (var packing in updated)
                    foreach (var item in packing.PackingListCartons.Where(t => t.IsEdited))
                        packingListCartons.Add(item);

                if (packingListCartons?.Any() ?? false)
                    await _packingListCartonDataService.SaveManyAsync(userId: userId, updated: packingListCartons);
            }
            
            await base.SaveManyAsync(userId: userId, added: added, updated: updated, deleted: deleted);
        }

        public async Task<PackingList> GetPackingListByOrderIdAsync(int orderId)
        {
            return await _context.PackingLists
                .Include(t => t.PackingListCartons)
                    .ThenInclude(t => t.PackingListCartonItems)
                        .ThenInclude(t => t.PickListOrder)
                            .ThenInclude(t => t.PickListOrderItems)
                .Include(t => t.PackingListCartons)
                    .ThenInclude(t => t.PackingListCartonItems)
                        .ThenInclude(t => t.OrderItem)
                .Include(t => t.Order)
                    .ThenInclude(o => o.OrderItems)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.OrderID == orderId);
        }

        public async Task<PackingList> GetPackingListByOrderIdAsync(int orderId, string packingListNo)
        {
            return await _context.PackingLists
                .Include(t => t.PackingListCartons)
                    .ThenInclude(t => t.PackingListCartonItems)
                        .ThenInclude(t => t.PickListOrder)
                            .ThenInclude(t => t.PickListOrderItems)
                .Include(t => t.PackingListCartons)
                    .ThenInclude(t => t.PackingListCartonItems)
                        .ThenInclude(t => t.OrderItem)
                .Include(t => t.Order)
                    .ThenInclude(o => o.OrderItems)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.OrderID == orderId && t.PackingListNo == packingListNo);
        }

        public async Task<PackingList> GetByOrderIdAsync(int orderId) => await _packingListRepository.GetByOrderIdAsync(orderId);

        public async Task<ICollection<PackingList>> GetManyByOrderIdsAsync(int[] ids) => await _packingListRepository.GetManyByOrderIdsAsync(ids);
    }
}
