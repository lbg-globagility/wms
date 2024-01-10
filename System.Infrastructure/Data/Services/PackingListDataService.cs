using Microsoft.EntityFrameworkCore;
using System;
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
        public PackingListDataService(IPackingListRepository packingListRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) : 
            
            base(packingListRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "PackingList")
        {
        }

        protected override string CreateUserActivitySuffixIdentifier(PackingList entity) => $"Packing List No.: {entity.PackingListNo} and status: {entity.Status}";

        protected override string GetUserActivityName(PackingList entity) => _entityName;

        public override Task SaveManyAsync(int userId,
            List<PackingList> added = null,
            List<PackingList> updated = null,
            List<PackingList> deleted = null)
        {
            return base.SaveManyAsync(userId, added, updated, deleted);
        }

        public async Task<PackingList> GetPackingListByOrderIdAsync(int orderId)
        {
            return await _context.PackingLists
                .Include(t => t.Order)
                    .ThenInclude(o => o.OrderItems)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.OrderID == orderId);
        }

        public async Task<PackingList> GetPackingListByOrderIdAsync(int orderId, string packingListNo)
        {
            return await _context.PackingLists
                .Include(t => t.Order)
                    .ThenInclude(o => o.OrderItems)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.OrderID == orderId && t.PackingListNo == packingListNo);
        }
    }
}
