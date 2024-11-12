using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Helpers;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;
using WarehouseManagementSystem.Utilities.Extensions;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class PickListRepository : SavableRepository<PickList>, IPickListRepository
    {
        public PickListRepository(SystemContext context) : base(context)
        {
        }

        public async override Task<PickList> GetByIdAsync(int id)
        {
            return await _context.PickLists
                .Include(t => t.PickListOrders)
                    .ThenInclude(t => t.Order)
                        .ThenInclude(t => t.Customer)
                .Include(t => t.PickListOrders)
                    .ThenInclude(t => t.PickListOrderItems)
                .Include(t => t.PickListOrders)
                    .ThenInclude(t => t.OrderItem)
                        .ThenInclude(t => t.ProductColorSize)
                            .ThenInclude(t => t.ProductColor)
                                .ThenInclude(t => t.Product)
                .Include(t => t.PickListOrders)
                    .ThenInclude(t => t.OrderItem)
                        .ThenInclude(t => t.ProductColorSize)
                            .ThenInclude(t => t.ProductColor)
                                .ThenInclude(t => t.Color)
                .Include(t => t.PickListOrders)
                    .ThenInclude(t => t.OrderItem)
                        .ThenInclude(t => t.ProductInventoryLocation)
                            .ThenInclude(t => t.RackShelfColumn)
                                .ThenInclude(t => t.InventoryLocation)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.RowID == id);
        }

        public Task<PickList> GetByOrderIdAsync(int orderId)
        {
            var query = _context.PickLists
                .Include(t => t.PickListOrders)
                    .ThenInclude(t => t.PickListOrderItems)
                .AsNoTracking()
                .AsQueryable();

            return Task.FromResult(query.AsEnumerable()
                .Where(t => t.PickListOrders.Any(x => x.OrderID == orderId))
                .FirstOrDefault());
        }

        public Task<PickList> GetLastAsync(int organizationId)
        {
            var query = _context.PickLists
                .AsNoTracking()
                .Where(o => o.OrganizationID == organizationId)
                .AsQueryable();

            return Task.FromResult(
                query
                .AsEnumerable()
                .OrderByDescending(o => o.PickListNumberInt)
                .FirstOrDefault());
        }

        public Task<PaginatedList<PickList>> GetPaginatedPickListsAsync(PageOptions pageOptions,
            int organizationId,
            string searchText = "")
        {
            var query = _context.PickLists
                .Include(p => p.PickListOrders)
                .AsNoTracking()
                .Where(o => o.OrganizationID == organizationId)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                var pickList1 = query
                    .AsEnumerable()
                    .Where(t => t.SearchableText.SimilarTo(searchText))
                    .AsQueryable()
                    .Page(pageOptions);
                var count1 = pickList1.Count();

                pickList1 = SortMethod(q: pickList1);

                return Task.FromResult(new PaginatedList<PickList>(items: pickList1, total: count1));
            }

            query = SortMethod(q: query);

            var count = query.AsEnumerable().Count();
            var pickLists = query.Page(pageOptions).AsEnumerable();

            return Task.FromResult(new PaginatedList<PickList>(items: pickLists, total: count));

            IQueryable<PickList> SortMethod(IQueryable<PickList> q)
            {
                if (!string.IsNullOrWhiteSpace(pageOptions.Sort) &&
                    !string.IsNullOrWhiteSpace(pageOptions.Direction))
                {
                    var sorts = pageOptions.Sort.Split(',');
                    var directions = pageOptions.Direction.Split(',');

                    if ((sorts?.Count() ?? 0) > 1)
                    {
                        var hasMultiDirection = (directions?.Count() ?? 0) > 1;
                        var i = 0;
                        foreach (var sort in sorts)
                        {
                            var dir = hasMultiDirection ? directions[i] : pageOptions.Direction;
                            var isFirstLoop = i == 0;
                            var fsdfsd = (IOrderedQueryable<PickList>)q;

                            if (sort == "Created")
                                q = isFirstLoop ? q.OrderBy(x => x.Created, direction: dir) : fsdfsd.ThenBy(x => x.Created, direction: dir);
                            if (sort == "PickListDate")
                                q = isFirstLoop ? q.OrderBy(x => x.PickListDate, direction: dir) : fsdfsd.ThenBy(x => x.Created, direction: dir);
                            if (sort == "PickListNo")
                                q = isFirstLoop ? q.OrderBy(x => x.PickListNo, direction: dir) : fsdfsd.ThenBy(x => x.Created, direction: dir);

                            i++;
                        }
                    } else if (pageOptions.Sort == "Created")
                        q = q.OrderBy(x => x.Created, pageOptions.Direction);
                }

                return q;
            }
        }

        
    }
}
