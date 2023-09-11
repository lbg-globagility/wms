using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<List<ListOfValue>> GetManyByTypeAsync(int organizationId, string type)
        {
            throw new System.NotImplementedException();
        }
    }
}