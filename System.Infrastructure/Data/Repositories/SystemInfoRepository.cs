using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class SystemInfoRepository : ISystemInfoRepository
    {
        private readonly SystemContext _context;

        public SystemInfoRepository(SystemContext context)
        {
            _context = context;
        }

        public async Task<SystemInfo> GetSystemVersion()
        {
            var query = _context.SystemInfos
                .AsNoTracking()
                .AsQueryable();

            return query
                .AsEnumerable()
                .FirstOrDefault(t => t.IsSystemVersion);
        }
    }
}
