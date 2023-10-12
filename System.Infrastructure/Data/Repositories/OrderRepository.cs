using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class OrderRepository : SavableRepository<Order>, IOrderRepository
    {
        public OrderRepository(SystemContext context) : base(context)
        {
        }

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
    }
}