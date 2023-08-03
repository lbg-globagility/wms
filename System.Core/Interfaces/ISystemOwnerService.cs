using WarehouseManagementSystem.Core.Entities;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Core.Interfaces
{
    public interface ISystemOwnerService
    {
        string GetCurrentSystemOwner();

        Task<string> GetCurrentSystemOwnerAsync();

        Task<SystemOwner> GetCurrentSystemOwnerEntityAsync();
    }
}