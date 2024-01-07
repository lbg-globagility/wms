using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class AccountRepository : SavableRepository<Account>, IAccountRepository
    {
        public AccountRepository(SystemContext context) : base(context)
        {
        }

        public async Task<List<Account>> GetManyByOrganizationIdAndTypeAsync(int organizationId, AccountType type) => await _context.Accounts
            .Include(t => t.Agent)
            .Include(t => t.SubAccounts)
            .Include(t => t.Address)
            .AsNoTracking()
            .Where(t => t.OrganizationID == organizationId)
            .Where(t => t.AccountType == type)
            .ToListAsync();
    }
}