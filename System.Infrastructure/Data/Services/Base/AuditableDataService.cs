using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Exceptions;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data
{
    public abstract class AuditableDataService<T> : BaseOrganizationDataService<T> where T : AuditableEntity
    {
        public readonly string[] NON_TRACKABLE_PROPERTY_NAMES = { "Created", "CreatedBy", "LastUpd", "LastUpdBy" };

        protected AuditableDataService(ISavableRepository<T> repository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            string entityName,
            string entityNamePlural = null) :

            base(repository,
                userActivityRepository,
                context,
                policy,
                entityName,
                entityNamePlural)
        {
        }

        protected override async Task SanitizeEntity(T entity, T oldEntity, int currentlyLoggedInUserId)
        {
            await base.SanitizeEntity(entity, oldEntity, currentlyLoggedInUserId);

            entity.AuditUser(currentlyLoggedInUserId);

            if (entity.OrganizationID == null)
                BusinessLogicException.Throw("Organization is required.");
        }

        protected override async Task RecordDelete(T entity, int currentlyLoggedInUserId)
        {
            await _userActivityRepository.RecordDeleteAsync(
                currentlyLoggedInUserId,
                entityId: entity.RowID.Value,
                entityName: GetUserActivityName(entity),
                suffixIdentifier: CreateUserActivitySuffixIdentifier(entity),
                organizationId: entity.OrganizationID.Value);
        }

        protected override async Task RecordAdd(T entity)
        {
            await _userActivityRepository.RecordAddAsync(
                entity.CreatedBy.Value,
                entityId: entity.RowID.Value,
                entityName: GetUserActivityName(entity),
                suffixIdentifier: CreateUserActivitySuffixIdentifier(entity),
                organizationId: entity.OrganizationID.Value);
        }

        protected override async Task RecordUpdate(T entity, T oldEntity, string suffix = "")
        {
            var userActivityItems = new List<UserActivityItem>();

            var currentEntityEntry = _context.Entry(entity);
            var oldEntityEntry = _context.Entry(oldEntity);

            var currentEntityEntryProperties = currentEntityEntry
                .Properties
                .Where(_ => !NON_TRACKABLE_PROPERTY_NAMES.Contains(_.Metadata.Name));
            foreach (var currentEntityEntryProperty in currentEntityEntryProperties)
            {
                var propertyName = currentEntityEntryProperty.Metadata.Name;

                var currentEntityValue = JsonSerializer.Serialize(currentEntityEntryProperty.CurrentValue);
                var oldEntityValue = JsonSerializer.Serialize(oldEntityEntry.Property(propertyName).OriginalValue);

                if (currentEntityValue != oldEntityValue)
                    userActivityItems.Add(UserActivityItem.NewUserActivityItem(entityId: oldEntity.RowID.Value,
                        description: $"Change `{propertyName}` from '{oldEntityEntry.Property(propertyName).OriginalValue}' to '{currentEntityEntryProperty.CurrentValue}'{suffix}",
                        changedUserId: entity.LastUpdBy.Value));
            }

            var entityName = currentEntityEntry.Metadata.Name.ToLower().Split('.').LastOrDefault();

            await _userActivityRepository.CreateRecordAsync(
                userId: entity.LastUpdBy.Value,
                entityName: entityName,
                organizationId: entity.OrganizationID.Value,
                recordType: UserActivity.RecordTypeEdit,
                activityItems: userActivityItems);

            await base.RecordUpdate(entity, oldEntity);
        }

        protected override Task PostSaveManyAction(IReadOnlyCollection<T> entities, IReadOnlyCollection<T> oldEntities, SaveType saveType, int currentlyLoggedInUserId)
        {
            if(saveType == SaveType.Update ||
                saveType == SaveType.Delete)
            {
                var entitiesWithNoLastUpdateBy = entities.Where(t => t.LastUpdBy == null);
                entitiesWithNoLastUpdateBy.ToList().ForEach(t => t.AuditUser(userId: currentlyLoggedInUserId));
            }

            return base.PostSaveManyAction(entities, oldEntities, saveType, currentlyLoggedInUserId);
        }
    }
}