using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

using WarehouseManagementSystem.Utilities.Extensions;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ColorDataService : AuditableDataService<Color>, IColorDataService
    {
        private readonly IColorRepository _colorRepository;

        public ColorDataService(IColorRepository colorRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :

            base(colorRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "Color")
        {
            _colorRepository = colorRepository;
        }

        public async Task<List<Color>> GetManyOrCreateManyAsync(int organizationId, int userId, string[] names)
        {
            var colors = await _colorRepository.GetByNamesAsync(organizationId: organizationId, names: names);

            var result = new List<Color>();

            foreach (var name in names)
            {
                var color = colors.FirstOrDefault(t => t.ColorName.IsEqualTo(name));
                if (color == null) color = await GetOrCreateAsync(organizationId: organizationId, userId: userId, name: name);

                result.Add(color);
            }

            return result;
        }

        public async Task<Color> GetOrCreateAsync(int organizationId, int userId, string name)
        {
            var color = await _colorRepository.GetByNameAsync(organizationId: organizationId, name: name);

            if (color == null)
            {
                color = Color.NewColor(organizationId: organizationId, userId: userId, name: name, value: string.Empty);

                await SaveManyAsync(userId: userId, added: new List<Color>() { color });
            }

            if (color == null)
            {
                var ex = new System.Exception("ColorDataService->GetOrCreateAsync: Category not found.");
                throw ex;
            }

            return color;
        }

        protected override string CreateUserActivitySuffixIdentifier(Color entity) => $" with `name` '{entity.ColorName}, `value` '{entity.ColorValue}', and `status` is '{entity.Status}'";

        protected override string GetUserActivityName(Color entity) => _entityName;
    }
}