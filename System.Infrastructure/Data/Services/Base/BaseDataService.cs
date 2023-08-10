using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services.Base
{
    public abstract class BaseDataService : IBaseDataService
    {
        protected readonly IUserActivityRepository _userActivityRepository;
        protected readonly IPolicyHelper _policy;

        public BaseDataService(IUserActivityRepository userActivityRepository, IPolicyHelper policy)
        {
            _userActivityRepository = userActivityRepository;
            _policy = policy;
        }
    }
}