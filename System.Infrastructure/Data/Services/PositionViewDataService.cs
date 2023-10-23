using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Services.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class PositionViewDataService : BaseSavableDataService<PositionView>, IPositionViewDataService
    {
        private readonly IPositionViewRepository _positionViewRepository;
        private readonly IUserRepository _userRepository;

        public PositionViewDataService(IPositionViewRepository positionViewRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            IUserRepository userRepository) :

            base(positionViewRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "PositionView")
        {
            _positionViewRepository = positionViewRepository;
            _userRepository = userRepository;
        }

        public async Task<List<PositionView>> GetManyByUserIdAsync(int organizationId, int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            return await _positionViewRepository
                .GetManyByPositionIdAsync(organizationId: organizationId, positionId: user.PositionID);
        }

        public async Task<PositionView> GetByUserIdAndViewNameAsync(int organizationId, int userId, string viewName)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            var positionViews = await _positionViewRepository
                .GetManyByPositionIdAsync(organizationId: organizationId, positionId: user.PositionID);

            return positionViews.FirstOrDefault(t => t.ViewName == viewName);
        }
    }
}