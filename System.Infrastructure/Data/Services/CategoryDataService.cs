using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class CategoryDataService : AuditableDataService<Category>, ICategoryDataService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDataService(ICategoryRepository categoryRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :

            base(categoryRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "Category")
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetManyOrCreateManyAsync(int organizationId, int userId, string[] names)
        {
            var categories = await _categoryRepository.GetByNamesAsync(organizationId: organizationId, names: names);

            var result = new List<Category>();

            foreach (var name in names)
            {
                var category = categories.FirstOrDefault(t => t.CategoryName.ToLower() == name.ToLower());
                if (category == null) category = await GetOrCreateAsync(organizationId: organizationId, userId: userId, name: name);

                result.Add(category);
            }

            return result;
        }

        public async Task<Category> GetOrCreateAsync(int organizationId, int userId, string name)
        {
            var category = await _categoryRepository.GetByNameAsync(organizationId: organizationId, name: name);

            if (category == null)
            {
                category = Category.NewCategory(organizationId: organizationId, userId: userId, name: name);

                await SaveManyAsync(entities: new List<Category>() { category }, userId: userId);
            }

            if (category == null)
            {
                var ex = new System.Exception("CategoryDataService->GetOrCreateAsync: Category not found.");
                throw ex;
            }

            return category;
        }

        protected override string CreateUserActivitySuffixIdentifier(Category entity) => $" with `name` '{entity.CategoryName}' and `status` is '{entity.Status}'";

        protected override string GetUserActivityName(Category entity) => _entityName;
    }
}