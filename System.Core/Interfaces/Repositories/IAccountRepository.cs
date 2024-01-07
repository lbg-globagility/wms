using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IAccountRepository : ISavableRepository<Account>
    {
        Task<List<Account>> GetManyByOrganizationIdAndTypeAsync(int organizationId, AccountType type);
    }
}