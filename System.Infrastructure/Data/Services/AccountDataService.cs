using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class AccountDataService : AuditableDataService<Account>, IAccountDataService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountDataService(IAccountRepository accountRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :

            base(accountRepository,
                userActivityRepository,
                context,
        policy,
                entityName: "Account")
        {
            _accountRepository = accountRepository;
        }

        public async Task<List<Account>> GetManyByOrganizationIdAndTypeAsync(int organizationId, AccountType type) => await _accountRepository.GetManyByOrganizationIdAndTypeAsync(organizationId: organizationId, type: type);

        protected override string CreateUserActivitySuffixIdentifier(Account entity) => $"Name: {entity.CompanyName}";

        protected override string GetUserActivityName(Account entity) => _entityName;
    }
}