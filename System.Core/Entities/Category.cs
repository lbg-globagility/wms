using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("categories")]
    public partial class Category : AuditableEntity
    {
        public string CategoryName { get; set; }
        public CategoryStatus Status { get; set; }
    }

    public partial class Category
    {
        private Category()
        {
        }

        public Category(int organizationId,
            int userId,
            string name)
        {
            OrganizationID = organizationId;
            CreatedBy = userId;
            CategoryName = name;
        }

        public virtual ICollection<Product> Products { get; set; }

        public static Category NewCategory(int organizationId,
            int userId,
            string name) => new Category(organizationId: organizationId,
                userId: userId,
                name: name);

        public void AddProducts(List<Product> products)
        {
            if (Products == null) Products = new List<Product>();

            foreach (var product in products)
                Products.Add(product);
        }
    }
}