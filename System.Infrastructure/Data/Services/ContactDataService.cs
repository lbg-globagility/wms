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
    public class ContactDataService : AuditableDataService<Contact>, IContactDataService
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

        public async Task<Contact> GetOrCreateDefaultAsync(int organizationId, int userId, ContactType contactType = ContactType.Contact)
        {
            var contact = await _contactRepository.GetDefaultAsync(organizationId: organizationId, userId: userId, contactType: contactType);

            if (contact == null)
            {
                var newContact = _contactRepository.GenerateDefault(organizationId: organizationId, userId: userId, contactType: contactType);

                newContact.AuditUser(userId);

                await SaveManyAsync(userId: userId, added: new List<Contact>() { newContact });

                return await _contactRepository.GetDefaultAsync(organizationId: organizationId, userId: userId, contactType: contactType);
            }

            return contact;
        }

        public async Task<List<Contact>> GetPackersAsync(int organizationId) => await _contactRepository.GetManyByTypeAsync(organizationId: organizationId, contactType: ContactType.Packer);

        public async Task<List<Contact>> GetPickersAsync(int organizationId) => await _contactRepository.GetManyByTypeAsync(organizationId: organizationId, contactType: ContactType.Picker);

        protected override string CreateUserActivitySuffixIdentifier(Contact entity) => $" with `name` '{entity.FullNameLastNameFirst}' and `status` is '{entity.Status}'";

        protected override string GetUserActivityName(Contact entity) => _entityName;
    }
}