using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface ILineupDataService : IBaseSavableDataService<Lineup>
    {
        Task CancelDeliveryAsync(int lineupId, int userId);
        Task ConfirmDeliveryAsync(int lineupId, int userId, DateTime dateTime);
        Task<Lineup> GetByLineupIdAsync(int lineupId);

        Task<List<Lineup>> GetByOrganizationIdAndDateRangeAsync(int organizationId, DateTime from, DateTime to);
        Task<List<Lineup>> GetManyByOrderIdAsync(int orderId);
    }
}
