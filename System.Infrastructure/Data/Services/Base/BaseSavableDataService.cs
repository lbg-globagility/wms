using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Exceptions;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data
{
    public abstract partial class BaseSavableDataService<T> : BaseDataService, IBaseSavableDataService<T> where T : BaseEntity
    {
        public enum SaveType
        {
            Insert,
            Update,
            Delete
        }

        protected readonly ISavableRepository<T> _repository;
        protected readonly SystemContext _context;
        protected readonly string _entityName;
        protected readonly string _entityNamePlural;

        public BaseSavableDataService(
            ISavableRepository<T> repository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy,
            string entityName,
            string entityNamePlural = null) :

            base(userActivityRepository,
                policy)
        {
            _repository = repository;
            _context = context;

            _entityName = entityName;
            _entityNamePlural = entityNamePlural ?? entityName + "s";
        }

        public virtual async Task DeleteAsync(int id, int userId)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                BusinessLogicException.Throw($"{_entityName} does not exists.");

            await AdditionalDeleteValidation(entity: entity);

            await _repository.DeleteAsync(entity);

            await PostDeleteAction(entity: entity, userId: userId);
        }

        public virtual async Task DeleteManyAsync(int[] ids, int userId)
        {
            await _repository.DeleteManyAsync(ids);
        }

        public virtual async Task<T> SaveAsync(T entity, int userId)
        {
            bool isNew = entity.IsNewEntity;

            T oldEntity = null;
            if (!isNew)
            {
                oldEntity = await _repository.GetByIdAsync(entity.RowID.Value);

                if (oldEntity == null)
                    BusinessLogicException.Throw($"{_entityName} no longer exists.");
            }

            await SanitizeEntity(entity, oldEntity, userId);
            await AdditionalSaveValidation(entity, oldEntity);

            DetachOldEntity(oldEntity);
            await _repository.SaveAsync(entity);

            SaveType saveType = isNew ? SaveType.Insert : SaveType.Update;
            await PostSaveAction(entity, oldEntity, saveType);

            return entity;
        }

        public virtual async Task SaveManyAsync(int userId,
            List<T> added = null,
            List<T> updated = null,
            List<T> deleted = null)
        {
            if (added == null && updated == null && deleted == null)
                BusinessLogicException.Throw($"No {_entityNamePlural} to be saved.");

            var allEntities = new List<T>();
            if (added != null && added.Any()) allEntities.AddRange(added);
            if (updated != null && updated.Any()) allEntities.AddRange(updated);
            if (deleted != null && deleted.Any()) allEntities.AddRange(deleted);

            ICollection<T> oldEntities = await ValidateMultipleEntities(
                userId: userId,
                added: added,
                updated: updated,
                deleted: deleted);

            await CallAdditionalSaveManyValidation(entities: added, oldEntities, SaveType.Insert);
            await CallAdditionalSaveManyValidation(entities: updated, oldEntities, SaveType.Update);
            await CallAdditionalSaveManyValidation(entities: deleted, oldEntities, SaveType.Delete);

            DetachOldEntities(oldEntities: oldEntities);

            await _repository.SaveManyAsync(
                added: added,
                updated: updated,
                deleted: deleted);

            await CallPostSaveManyAction(entities: added, oldEntities, SaveType.Insert, userId);
            await CallPostSaveManyAction(entities: updated, oldEntities, SaveType.Update, userId);
            await CallPostSaveManyAction(entities: deleted, oldEntities, SaveType.Delete, userId);
        }

        public virtual async Task SaveManyAsync(List<T> entities, int userId)
        {
            if (entities == null)
                BusinessLogicException.Throw($"No {_entityNamePlural} to be saved.");

            var insertEntities = entities.Where(x => x.IsNewEntity).ToList();
            var updateEntities = entities.Where(x => !x.IsNewEntity).ToList();

            await SaveManyAsync(
                userId,
                added: insertEntities,
                updated: updateEntities);
        }
    }

    public abstract partial class BaseSavableDataService<T>
    {
        protected virtual Task PostSaveAction(T entity, T oldEntity, SaveType saveType) => Task.CompletedTask;

        private void DetachOldEntity(T oldEntity)
        {
            if (oldEntity != null)
            {
                _context.Entry(oldEntity).State = EntityState.Detached;
            }
        }

        protected virtual Task AdditionalSaveValidation(T entity, T oldEntity) => Task.CompletedTask;

        protected virtual Task SanitizeEntity(T entity, T oldEntity, int userId)
        {
            if (entity == null)
                BusinessLogicException.Throw($"Invalid {_entityName}.");

            if (entity.IsNewEntity && oldEntity != null)
                BusinessLogicException.Throw("Your data is no longer up to date. Please refresh the form/page.");

            return Task.CompletedTask;
        }

        private async Task CallPostSaveManyAction(List<T> entities, ICollection<T> oldEntities, SaveType saveType, int userId)
        {
            if (entities != null && entities.Any())
                await PostSaveManyAction(entities, GetOldEntitiesOfPassedEntities(entities, oldEntities), saveType, userId);
        }

        protected virtual Task PostSaveManyAction(IReadOnlyCollection<T> entities, IReadOnlyCollection<T> ts, SaveType saveType, int userId) => Task.CompletedTask;

        private void DetachOldEntities(ICollection<T> oldEntities)
        {
            if (oldEntities != null && oldEntities.Any())
            {
                foreach (var oldEntity in oldEntities)
                {
                    DetachOldEntity(oldEntity);
                }
            }
        }

        private async Task CallAdditionalSaveManyValidation(List<T> entities, ICollection<T> oldEntities, SaveType saveType)
        {
            if (entities != null && entities.Any())
                await AdditionalSaveManyValidation(entities, GetOldEntitiesOfPassedEntities(entities, oldEntities), saveType);
        }

        protected virtual Task AdditionalSaveManyValidation(List<T> entities, List<T> ts, SaveType saveType) => Task.CompletedTask;

        private async Task<ICollection<T>> ValidateMultipleEntities(int userId, List<T> added, List<T> updated, List<T> deleted)
        {
            var allEntities = new List<T>();
            if (added != null) allEntities.AddRange(added);
            if (updated != null) allEntities.AddRange(updated);
            if (deleted != null) allEntities.AddRange(deleted);

            ICollection<T> oldEntities = await GetOldEntitiesAsync(oldEntities: allEntities);

            if (added != null && added.Any())
            {
                foreach (var entity in added)
                {
                    T oldEntity = GetOldEntity(oldEntities: oldEntities, entity);
                    await SanitizeEntity(entity, oldEntity, userId);
                }
            }

            if (updated != null && updated.Any())
            {
                foreach (var entity in updated)
                {
                    var oldEntity = GetOldEntity(oldEntities: oldEntities, entity);

                    if (oldEntity == null)
                        BusinessLogicException.Throw($"One of the {_entityNamePlural} no longer exists.");

                    await SanitizeEntity(entity, oldEntity, userId);
                }
            }

            if (deleted != null && deleted.Any())
            {
                foreach (var entity in deleted)
                {
                    if (entity == null)
                        BusinessLogicException.Throw("Invalid data.");

                    var oldEntity = oldEntities.FirstOrDefault(x => x.RowID == entity.RowID);

                    if (oldEntity == null)
                        BusinessLogicException.Throw($"One of the {_entityNamePlural} no longer exists.");
                }
            }

            return oldEntities;
        }

        protected T GetOldEntity(ICollection<T> oldEntities, T entity) => oldEntities.FirstOrDefault(x => x.RowID == entity?.RowID);

        protected async Task<ICollection<T>> GetOldEntitiesAsync(List<T> oldEntities)
        {
            var updatedEntityIds = oldEntities
                .Where(x => !x.IsNewEntity)
                .Select(x => x.RowID.Value)
                .Distinct()
                .ToArray();

            return await _repository.GetManyByIdsAsync(updatedEntityIds);
        }

        protected virtual Task PostDeleteAction(T entity, int userId) => Task.CompletedTask;

        protected virtual Task AdditionalDeleteValidation(T entity) => Task.CompletedTask;

        private static List<T> GetOldEntitiesOfPassedEntities(List<T> entities, ICollection<T> oldEntities)
        {
            var entityIds = entities.Select(a => a.RowID);

            return oldEntities.Where(x => entityIds.Contains(x.RowID)).ToList();
        }

        public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id: id);
    }
}