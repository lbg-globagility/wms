using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;

namespace WarehouseManagementSystem.Infrastructure.Data
{
    public class SystemOwnerService : ISystemOwnerService
    {
        private readonly SystemContext _context;

        public SystemOwnerService(SystemContext context)
        {
            _context = context;
        }

        public string GetCurrentSystemOwner()
        {
            return GetCurrentSystemOwnerBaseQuery()
                .FirstOrDefault();
        }

        public async Task<string> GetCurrentSystemOwnerAsync()
        {
            return await GetCurrentSystemOwnerBaseQuery()
                .FirstOrDefaultAsync();
        }

        private IQueryable<string> GetCurrentSystemOwnerBaseQuery()
        {
            return _context.SystemOwners
                .AsNoTracking()
                .Where(x => x.IsCurrentOwner == "1")
                .Select(x => x.Name);
        }

        public async Task<SystemOwner> GetCurrentSystemOwnerEntityAsync()
        {
            return await _context.SystemOwners
                .AsNoTracking()
                .Where(x => x.IsCurrentOwner == "1")
                .FirstOrDefaultAsync();
        }
    }
}