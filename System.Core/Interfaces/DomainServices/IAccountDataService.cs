using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IAccountDataService : IBaseSavableDataService<Account>
    {
        Task<List<Account>> GetManyByOrganizationIdAndTypeAsync(int organizationId, AccountType type);
    }
}