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
    public class ContactRepository : SavableRepository<Contact>, IContactRepository
    {
        public ContactRepository(SystemContext context) : base(context)
        {
        }

        public Contact GenerateDefault(int organizationId, int userId, ContactType contactType) => new Contact(organizationId: organizationId,
            lastName: Contact.DEFAULT_NAME,
            firstName: string.Empty,
            type: contactType,
            workPhone: string.Empty,
            email: string.Empty,
            comments: string.Empty);

        public async Task<Contact> GetDefaultAsync(int organizationId, int userId, ContactType contactType = ContactType.Contact)
        {
            return await _context.Contacts
                .AsNoTracking()
                .Where(c => c.OrganizationID == organizationId)
                .Where(c => c.Type == contactType)
                .Where(c => c.Status == "Active")
                .FirstOrDefaultAsync();
        }

        public async Task<List<Contact>> GetManyByTypeAsync(int organizationId, ContactType contactType = ContactType.Contact) => await _context.Contacts
            .AsNoTracking()
            .Where(c => c.OrganizationID == organizationId)
            .Where(c => c.Type == contactType)
            .Where(c => c.Status == "Active")
            .ToListAsync();
    }
}