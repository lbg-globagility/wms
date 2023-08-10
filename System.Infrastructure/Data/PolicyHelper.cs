using WarehouseManagementSystem.Core.Interfaces;

namespace WarehouseManagementSystem.Infrastructure.Data
{
    public class PolicyHelper : IPolicyHelper
    {
        private readonly ISystemOwnerService _systemOwnerService;

        public PolicyHelper(ISystemOwnerService systemOwnerService)
        {
            _systemOwnerService = systemOwnerService;
        }
    }
}