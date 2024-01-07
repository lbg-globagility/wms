using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Helpers;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using static WarehouseManagementSystem.Core.Entities.UserActivity;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class UserActivityRepository : IUserActivityRepository
    {
        private readonly SystemContext _context;

        public UserActivityRepository(SystemContext context)
        {
            _context = context;
        }

        public async Task CreateRecordAsync(int userId,
            string entityName,
            int organizationId,
            string recordType,
            List<UserActivityItem> activityItems = null)
        {
            var userActivity = NewUserActivity(organizationId: organizationId,
                userId: userId,
                entityName: entityName.ToUpper(),
                recordType: recordType);

            userActivity.AddActivityItems(activityItems: activityItems);

            _context.UserActivities.Add(userActivity);

            await _context.SaveChangesAsync();
        }

        public Task<PaginatedList<UserActivityItem>> GetPaginatedListAsync(
            PageOptions options,
            int? organizationId = null,
            string[] entityNames = null,
            int? changedByUserId = null,
            ChangedType? changedType = null,
            int? changedEntityId = null,
            string description = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null)
        {
            throw new NotImplementedException();
        }

        public async Task RecordAddAsync(
            int currentlyLoggedInUserId,
            string entityName,
            int entityId,
            int organizationId,
            string suffixIdentifier = "",
            int? changedEmployeeId = null,
            int? changedUserId = null)
        {
            await RecordSimpleAsync(
                currentlyLoggedInUserId,
                entityName,
                "Created a new",
                suffixIdentifier,
                entityId: entityId,
                organizationId: organizationId,
                RecordTypeAdd,
                changedEmployeeId: changedEmployeeId,
                changedByUserId: changedUserId ?? currentlyLoggedInUserId);
        }

        public async Task RecordDeleteAsync(
            int currentlyLoggedInUserId,
            string entityName,
            int entityId,
            int organizationId,
            string suffixIdentifier = "",
            int? changedEmployeeId = null,
            int? changedUserId = null)
        {
            await RecordSimpleAsync(
                currentlyLoggedInUserId,
                entityName,
                $"Deleted {(CheckIfFirstLetterIsVowel(entityName) ? "an" : "a")}",
                suffixIdentifier,
                entityId: entityId,
                organizationId: organizationId,
                RecordTypeDelete,
                changedEmployeeId: changedEmployeeId,
                changedByUserId: changedUserId ?? currentlyLoggedInUserId);
        }

        private async Task RecordSimpleAsync(
            int currentlyLoggedInUserId,
            string entityName,
            string simpleDescription,
            string suffixIdentifier,
            int entityId,
            int organizationId,
            string recordType,
            int? changedEmployeeId,
            int? changedByUserId)
        {
            entityName = SetStringToPascalCase(entityName);

            List<UserActivityItem> activityItems = CreateSimpleUserActivityItem(
                entityName: entityName,
                simpleDescription: simpleDescription,
                suffixIdentifier: suffixIdentifier,
                entityId: entityId,
                changedEmployeeId: changedEmployeeId,
                changedByUserId: changedByUserId);

            await CreateRecordAsync(currentlyLoggedInUserId, entityName, organizationId, recordType, activityItems);
        }

        private static List<UserActivityItem> CreateSimpleUserActivityItem(
            string entityName,
            string simpleDescription,
            string suffixIdentifier,
            int entityId,
            int? changedEmployeeId,
            int? changedByUserId)
        {
            return new List<UserActivityItem>()
            {
                UserActivityItem.NewUserActivityItem(entityId: entityId,
                    description: $"{simpleDescription} {entityName?.ToLower()}{suffixIdentifier}.",
                    changedUserId: changedByUserId)
            };
        }

        private static bool CheckIfFirstLetterIsVowel(string entityName)
        {
            if (!string.IsNullOrWhiteSpace(entityName))
            {
                return "aeiouAEIOU".IndexOf(entityName[0]) >= 0;
            }

            return false;
        }

        private static string SetStringToPascalCase(string entityName)
        {
            if (!string.IsNullOrWhiteSpace(entityName))
            {
                var textInfo = new CultureInfo("en-US", false).TextInfo;
                entityName = textInfo.ToTitleCase(entityName);
            }

            return entityName;
        }
    }
}