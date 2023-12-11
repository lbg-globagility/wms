using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IContactRepository : ISavableRepository<Contact>
    {
        Task<List<Contact>> GetManyByTypeAsync(int organizationId, ContactType contactType = ContactType.Contact);
        Task<Contact> GetDefaultAsync(int organizationId, int userId, ContactType contactType = ContactType.Contact);
        Contact GenerateDefault(int organizationId, int userId, ContactType contactType);
    }
}