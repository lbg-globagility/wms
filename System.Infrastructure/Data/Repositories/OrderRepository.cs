using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Helpers;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;
using WarehouseManagementSystem.Utilities.Extensions;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class OrderRepository : SavableRepository<Order>, IOrderRepository
    {
        public OrderRepository(SystemContext context) : base(context)
        {
        }

        public async Task<Order> GetById(int orderId) => await _context.Orders
           .Include(x => x.OrderItems)
            .ThenInclude(x => x.ProductColorSize)
                .ThenInclude(x => x.ProductColor)
                    .ThenInclude(x => x.Product)
           .Include(x => x.OrderItems)
            .ThenInclude(x => x.ProductColorSize)
                .ThenInclude(x => x.ProductColor)
                    .ThenInclude(x => x.Color)
          .AsNoTracking()
          .Where(c => c.RowID == orderId)
          .FirstOrDefaultAsync();

        public Task<Order> GetLastOrderOfThisTypeAsync(int organizationId, OrderType orderType)
        {
            var query = _context.Orders
                .AsNoTracking()
                .Where(o => o.OrganizationID == organizationId)
                .AsQueryable();

            return Task.FromResult(
                query
                .AsEnumerable()
                .Where(o => o.OrderType == orderType)
                .OrderByDescending(o => o.OrderNumberInt)
                .FirstOrDefault());
        }

        public Task<List<Order>> GetOrdersByOrderTypeAsync(int organizationId, OrderType orderType)
        {
            var query = _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.InventoryLocation)
                .AsNoTracking()
                .Where(o => o.OrganizationID == organizationId)
                .AsQueryable();

            query = StockTransferNavMapping(query, orderType);

            query = StockAdjustmentNavMapping(query, orderType);

            query = CustomerOrderNavMapping(query, orderType);

            return Task.FromResult(
                query
                .AsEnumerable()
                .Where(o => o.OrderType == orderType)
                .ToList());
        }

        public Task<Order> GetOrderByOrderTypeAsync(int id, OrderType orderType)
        {
            var query = _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.InventoryLocation)
                .AsNoTracking()
                .Where(o => o.RowID == id)
                .Where(o => o.OrderType == orderType)
                .AsQueryable();

            query = StockTransferNavMapping(query, orderType);

            query = StockAdjustmentNavMapping(query, orderType);

            query = CustomerOrderNavMapping(query, orderType);

            return Task.FromResult(
                query
                .AsEnumerable()
                .FirstOrDefault());
        }

        public Task<List<Order>> SearchOrdersAsync(int organizationId, OrderType orderType, string searchText)
        {
            var query = OrderQueryable(organizationId, orderType);

            return Task.FromResult(
                query
                .AsEnumerable()
                .Where(o => o.OrderType == orderType)
                .Where(o => o.OrderNumber.Contains(searchText) ||
                    (o.Comments?.ToLower().Contains(searchText) ?? false) ||
                    o.HasMovementHistoryProductLikeThis(searchText))
                .ToList());
        }

        private IQueryable<Order> OrderQueryable(int organizationId, OrderType orderType)
        {
            var query = _context.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.OrganizationID == organizationId)
                .AsQueryable();

            query = StockTransferNavMapping(query, orderType);

            query = StockAdjustmentNavMapping(query, orderType);

            query = CustomerOrderNavMapping(query, orderType);

            return query;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var order = await GetByIdAsync(id);

            return await GetOrderAsync(order);
        }

        public async Task<Order> GetOrderAsync(Order order)
        {
            var query = BaseOrderNavMapping(order);

            query = StockTransferNavMapping(query, order.OrderType);

            query = StockAdjustmentNavMapping(query, order.OrderType);

            query = CustomerOrderNavMapping(query, order.OrderType);

            return await query.FirstOrDefaultAsync();
        }

        private IQueryable<Order> BaseOrderNavMapping(Order order) => _context.Orders
            .Include(o => o.OrderItems)
            .Include(o => o.UserCreate)
            .Include(o => o.UserUpdate)
            .AsNoTracking()
            .Where(o => o.RowID == order.RowID)
            .AsQueryable();

        private IQueryable<Order> BaseOrderNavMapping(int organizationId) => _context.Orders
            .Include(o => o.OrderItems)
            .Include(o => o.UserCreate)
            .Include(o => o.UserUpdate)
            .AsNoTracking()
            .Where(o => o.OrganizationID == organizationId)
            .AsQueryable();

        private IQueryable<Order> StockTransferNavMapping(IQueryable<Order> query, OrderType orderType = default)
        {
            if (orderType == OrderType.ST)
                query = query
                    .Include(o => o.MovementHistories)
                        .ThenInclude(m => m.ProductInventoryLocation)
                            .ThenInclude(pil => pil.ProductColorSize)
                                .ThenInclude(pcs => pcs.ProductColor)
                                    .ThenInclude(pc => pc.Product)
                    .Include(o => o.MovementHistories)
                        .ThenInclude(m => m.ProductInventoryLocation)
                            .ThenInclude(pil => pil.ProductColorSize)
                                .ThenInclude(pcs => pcs.ProductColor)
                                    .ThenInclude(pc => pc.Color)
                    .Include(o => o.MovementHistories)
                        .ThenInclude(m => m.ProductInventoryLocation)
                            .ThenInclude(pil => pil.RackShelfColumn);
            return query;
        }

        private IQueryable<Order> StockAdjustmentNavMapping(IQueryable<Order> query, OrderType orderType = default)
        {
            if (orderType == OrderType.SA)
                query = query
                    .Include(o => o.MovementHistories)
                        .ThenInclude(m => m.ProductInventoryLocation)
                            .ThenInclude(pil => pil.ProductColorSize)
                                .ThenInclude(pcs => pcs.ProductColor)
                                    .ThenInclude(pc => pc.Product)
                    .Include(o => o.MovementHistories)
                        .ThenInclude(m => m.ProductInventoryLocation)
                            .ThenInclude(pil => pil.ProductColorSize)
                                .ThenInclude(pcs => pcs.ProductColor)
                                    .ThenInclude(pc => pc.Color)
                    .Include(o => o.MovementHistories)
                        .ThenInclude(m => m.ProductInventoryLocation)
                            .ThenInclude(pil => pil.RackShelfColumn);
            return query;
        }

        private IQueryable<Order> CustomerOrderNavMapping(IQueryable<Order> query, OrderType orderType = default)
        {
            if (orderType == OrderType.CO)
                query = query
                    .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.ProductColorSize)
                            .ThenInclude(pcs => pcs.ProductColor)
                                .ThenInclude(pc => pc.Color)
                    .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.ProductColorSize)
                            .ThenInclude(pcs => pcs.ProductColor)
                                .ThenInclude(pc => pc.Product)
                    .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.ProductInventoryLocation)
                    .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.RackShelfColumn)
                    .Include(o => o.Agent)
                    .Include(o => o.Customer)
                    .Include(o => o.InventoryLocation);
            return query;
        }

        public Task<PaginatedList<Order>> GetOrdersByOrderTypeAsync(PageOptions pageOptions,
            int organizationId,
            OrderType orderType,
            string searchText = "")
        {
            var query = BaseOrderNavMapping(organizationId);

            query = query.Where(t => t.OrderType == orderType);

            query = CustomerOrderNavMapping(query, orderType);

            if (!string.IsNullOrEmpty(searchText))
            {
                var orders1 = query
                    .AsEnumerable()
                    .Where(t => t.CustomerOrderSearchableString.SimilarTo(searchText))
                    .AsQueryable()
                    .Page(pageOptions);
                var count1 = orders1.Count();

                orders1 = SortMethod(q: orders1);

                return Task.FromResult(new PaginatedList<Order>(items: orders1, total: count1));
            }

            query = SortMethod(q: query);

            var count = query.AsEnumerable().Count();
            var orders = query.Page(pageOptions).AsEnumerable();

            return Task.FromResult(new PaginatedList<Order>(items: orders, total: count));

            IQueryable<Order> SortMethod(IQueryable<Order> q)
            {
                if (!string.IsNullOrWhiteSpace(pageOptions.Sort) &&
                    !string.IsNullOrWhiteSpace(pageOptions.Direction))
                {
                    if (pageOptions.Sort == "Created")
                        q = q.OrderBy(x => x.Created, pageOptions.Direction);
                }

                return q;
            }
        }
    }
}