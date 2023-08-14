using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("products")]
    public partial class Product : AuditableEntity
    {
        public int? CategoryID { get; set; }
        public int? BrandID { get; set; }
        public int? CompanyID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }

        [Column("Category")]
        public string CategoryText { get; set; }

        public string Company { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Description { get; set; }
        public ProductStatus Status { get; set; }
        public string SKU { get; set; }
        public string SKU2 { get; set; }
        public string BarCode { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? CostPrice { get; set; }
        public int? ReOrderPoint { get; set; }
        public int? LastRcvdFromShipmentCount { get; set; }
        public int? LastSoldCount { get; set; }
        public int? LastArrivedQty { get; set; }
        public int? TotalShipmentCount { get; set; }
        public DateTime? LastRcvdFromShipmentDate { get; set; }
        public DateTime? LastPurchaseDate { get; set; }
        public DateTime? LastSoldDate { get; set; }
        //public longblob? Image { get; set; }
    }

    public partial class Product
    {
        private Product()
        {
        }

        public Product(int organizationId,
            int userId,
            int categoryId,
            string productCode,
            string description)
        {
            OrganizationID = organizationId;
            CreatedBy = userId;
            CategoryID = categoryId;
            ProductCode = productCode;
            ProductName = productCode;
            Description = description;
        }

        public virtual Category Category { get; set; }

        public virtual ICollection<ProductColor> ProductColors { get; set; }

        public static Product NewProduct(int organizationId,
            int userId,
            int categoryId,
            string productCode,
            string description) => new Product(organizationId: organizationId,
                categoryId: categoryId,
                userId: userId,
                productCode: productCode,
                description: description);

        public bool HasColorAndSize(string colorName, decimal size) => ProductColors == null ? false : ProductColors?.Any(t => t.HasColorAndSize(colorName, size)) ?? false;
    }
}