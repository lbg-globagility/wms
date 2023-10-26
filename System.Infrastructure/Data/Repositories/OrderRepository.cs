using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;
using System.Linq;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class OrderRepository : SavableRepository<Order>, IOrderRepository
    {
        public OrderRepository(SystemContext context) : base(context)
        {

        }
        public async Task<Order> GetById(int orderId) => await _context.Orders
           .Include(x=>x.OrderItems)
            .ThenInclude(x=>x.ProductColorSize)
                .ThenInclude(x=>x.ProductColor)
                    .ThenInclude(x=>x.Product)
           .Include(x => x.OrderItems)
            .ThenInclude(x => x.ProductColorSize)
                .ThenInclude(x => x.ProductColor)
                    .ThenInclude(x => x.Color)
          .AsNoTracking()
          .Where(c => c.RowID == orderId)
          .FirstAsync();

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
                .AsNoTracking()
                .Where(o => o.OrganizationID == organizationId)
                .AsQueryable();

            query = StockTransferNavMapping(orderType, query);

            return Task.FromResult(
                query
                .AsEnumerable()
                .Where(o => o.OrderType == orderType)
                .ToList());
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

            query = StockTransferNavMapping(orderType, query);

            return query;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var order = await GetByIdAsync(id);

            return await GetOrderAsync(order);
        }

        public async Task<Order> GetOrderAsync(Order order)
        {
            var query = _context.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.RowID == order.RowID)
                .AsQueryable();

            query = StockTransferNavMapping(order.OrderType, query);

            return await query.FirstOrDefaultAsync();
        }

        private IQueryable<Order> StockTransferNavMapping(OrderType orderType, IQueryable<Order> query)
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
    }
}