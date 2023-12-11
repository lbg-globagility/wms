using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class CartonSizeRepository : SavableRepository<CartonSize>, ICartonSizeRepository
    {
        public CartonSizeRepository(SystemContext context) : base(context)
        {
        }

        public CartonSize GenerateDefault(int organizationId, int userId) => CartonSize.NewCartonSize(
            organizationId: organizationId,
            userId: userId,
            sizeName: CartonSize.DEFUALT_NAME);

        public async Task<CartonSize> GetDefaultAsync(int organizationId) => await _context.CartonSizes
            .Include(t => t.PackingListCartons)
            .AsNoTracking()
            .Where(t => t.OrganizationID == organizationId)
            .Where(t => t.SizeName == CartonSize.DEFUALT_NAME)
            .FirstOrDefaultAsync();
    }
}
