using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Services.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ContactDataService : BaseSavableDataService<Contact>, IContactDataService
    {
        private readonly IContactRepository _contactRepository;

        public ContactDataService(IContactRepository contactRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :

            base(contactRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "Contact")
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<Contact>> GetAgentsAsync(int organizationId) => await _contactRepository.GetManyByTypeAsync(organizationId: organizationId, contactType: ContactType.Agent);

        public async Task<List<Contact>> GetContactsAsync(int organizationId) => await _contactRepository.GetManyByTypeAsync(organizationId: organizationId, contactType: ContactType.Contact);

        public async Task<List<Contact>> GetDriversAsync(int organizationId) => await _contactRepository.GetManyByTypeAsync(organizationId: organizationId, contactType: ContactType.Driver);

        public async Task<List<Contact>> GetHelpersAsync(int organizationId) => await _contactRepository.GetManyByTypeAsync(organizationId: organizationId, contactType: ContactType.Helper);

        public async Task<List<Contact>> GetPackersAsync(int organizationId) => await _contactRepository.GetManyByTypeAsync(organizationId: organizationId, contactType: ContactType.Packer);

        public async Task<List<Contact>> GetPickersAsync(int organizationId) => await _contactRepository.GetManyByTypeAsync(organizationId: organizationId, contactType: ContactType.Picker);
    }
}