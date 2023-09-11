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

        public async Task<List<Contact>> GetManyByTypeAsync(int organizationId, ContactType contactType = ContactType.Contact) => await _context.Contacts
            .AsNoTracking()
            .Where(c => c.Type == contactType)
            .ToListAsync();
    }
}