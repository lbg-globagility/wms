using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Helpers;

namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IUserActivityRepository
    {

        Task CreateRecordAsync(int userId, string entityName, int organizationId, string recordType, List<UserActivityItem> activityItems = null);

        Task<PaginatedList<UserActivityItem>> GetPaginatedListAsync(PageOptions options, int? organizationId = null, string[] entityNames = null, int? changedByUserId = null, UserActivity.ChangedType? changedType = null, int? changedEntityId = null, string description = null, DateTime? dateFrom = null, DateTime? dateTo = null);

        Task RecordAddAsync(int userId, string entityName, int entityId, int organizationId, string suffixIdentifier = "", int? changedEmployeeId = null, int? changedUserId = null);

        Task RecordDeleteAsync(int userId, string entityName, int entityId, int organizationId, string suffixIdentifier = "", int? changedEmployeeId = null, int? changedUserId = null);
    }
}