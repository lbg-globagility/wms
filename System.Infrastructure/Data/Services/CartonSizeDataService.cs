using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class CartonSizeDataService : AuditableDataService<CartonSize>, ICartonSizeDataService
    {
        private readonly ICartonSizeRepository _cartonSizeRepository;

        public CartonSizeDataService(ICartonSizeRepository cartonSizeRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) : 
            
            base(cartonSizeRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "CartonSize")
        {
            _cartonSizeRepository = cartonSizeRepository;
        }

        public async Task<CartonSize> GetOrCreateDefaultAsync(int organizationId, int userId)
        {
            var cartonSize = await _cartonSizeRepository.GetDefaultAsync(organizationId: organizationId);

            if (cartonSize == null)
            {
                var newDefaultCartonSize = _cartonSizeRepository.GenerateDefault(organizationId: organizationId, userId: userId);

                await SaveManyAsync(userId: userId, added: new List<CartonSize>() { newDefaultCartonSize });

                return await _cartonSizeRepository.GetDefaultAsync(organizationId: organizationId);
            }

            return cartonSize;
        }

        protected override string CreateUserActivitySuffixIdentifier(CartonSize entity) => $"name: {entity.SizeName} and status: {entity.Status}";

        protected override string GetUserActivityName(CartonSize entity) => _entityName;
    }
}
