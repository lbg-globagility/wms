using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productcolors")]
    public partial class ProductColor : AuditableEntity
    {
        //[ForeignKey("Product")]
        public int ProductID { get; set; }

        public int ColorID { get; set; }
        public ProductColorStatus Status { get; set; }
    }

    public partial class ProductColor
    {
        private ProductColor()
        {
        }

        public ProductColor(int organizationId,
            int userId,
            int colorId,
            int productId)
        {
            OrganizationID = organizationId;
            CreatedBy = userId;
            ColorID = colorId;
            ProductID = productId;
        }

        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }
        public virtual ICollection<ProductColorSize> ProductColorSizes { get; set; }

        public static ProductColor NewProductColor(int organizationId,
            int userId,
            int colorId,
            int productId) => new ProductColor(organizationId: organizationId,
                userId: userId,
                colorId: colorId,
                productId: productId);

        public bool HasColorAndSize(string colorName, decimal size)
        {
            var hasColor = Color == null ? false : Color?.ColorName.ToLower() == colorName.ToLower();

            var hasSize = ProductColorSizes == null ? false : ProductColorSizes?.Any(t => t.Size == size) ?? false;

            return hasColor && hasSize;
        }

        public void AddProductColorSizes(List<ProductColorSize> productColorSizes)
        {
            if (ProductColorSizes == null) ProductColorSizes = new List<ProductColorSize>();

            foreach (var productColorSize in productColorSizes)
                ProductColorSizes.Add(productColorSize);
        }
    }
}