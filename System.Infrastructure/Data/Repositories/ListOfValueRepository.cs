using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class ListOfValueRepository : SavableRepository<ListOfValue>, IListOfValueRepository
    {
        public ListOfValueRepository(SystemContext context) : base(context)
        {
        }

        public async Task<List<ListOfValue>> GetManyByTypeAsync(int organizationId, string type)
        {
           return  await _context.ListOfValues
          .AsNoTracking()
          .Where(c => c.Type == type)
          .ToListAsync();
        }

        public async Task<List<ListOfValue>> GetManyByParentIdAsync(int organizationId, string parentId)
        {
            return await _context.ListOfValues
           .AsNoTracking()
           .Where(c =>  c.ParentLIC == parentId)
           .ToListAsync();
        }
    }
}