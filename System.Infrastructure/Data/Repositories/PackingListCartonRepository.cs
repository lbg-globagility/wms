using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class PackingListCartonRepository : SavableRepository<PackingListCarton>, IPackingListCartonRepository
    {
        public PackingListCartonRepository(SystemContext context) : base(context)
        {
        }
    }
}
