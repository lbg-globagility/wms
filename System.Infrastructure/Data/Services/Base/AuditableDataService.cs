using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Exceptions;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data
{
    public abstract class AuditableDataService<T> : BaseOrganizationDataService<T> where T : AuditableEntity
    {
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
                throw new BusinessLogicException("Organization is required.");
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
    }
}