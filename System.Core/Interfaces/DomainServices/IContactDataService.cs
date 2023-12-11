using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IContactDataService : IBaseSavableDataService<Contact>
    {
        Task<List<Contact>> GetContactsAsync(int organizationId);

        Task<List<Contact>> GetAgentsAsync(int organizationId);

        Task<List<Contact>> GetDriversAsync(int organizationId);

        Task<List<Contact>> GetHelpersAsync(int organizationId);

        Task<List<Contact>> GetPackersAsync(int organizationId);

        Task<List<Contact>> GetPickersAsync(int organizationId);
        
        Task<Contact> GetOrCreateDefaultAsync(int organizationId, int userId, ContactType contactType = ContactType.Contact);
    }
}