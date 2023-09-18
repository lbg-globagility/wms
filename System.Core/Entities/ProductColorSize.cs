using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productcolorsizes")]
    public partial class ProductColorSize : AuditableEntity
    {
        ////[ForeignKey("ProductColor")]
        public int ProductColorID { get; set; }

        public decimal Size { get; set; }
        public int? TotalAvailableQty { get; set; }
        public int? TotalDamageQty { get; set; }
        public int? LastSoldCount { get; set; }
        public DateTime? LastShipmentDate { get; set; }
        public DateTime? LastSoldDate { get; set; }
        public string SeasonCode { get; set; }
        public string SKU { get; set; }
        public string SKU2 { get; set; }
        public string Status { get; set; }
        public string BarCode { get; set; }
        public string Type { get; set; }
    }

    public partial class ProductColorSize
    {
        private ProductColorSize()
        {
        }

        public ProductColorSize(int organizationId,
            int userId,
            decimal size,
            string sku,
            string sku2,
            string seasonCode)
        {
            OrganizationID = organizationId;
            CreatedBy = userId;
            Size = size;
            SKU = sku;
            SKU2 = sku2;
            SeasonCode = seasonCode;
        }

        public virtual ProductColor ProductColor { get; set; }

        public virtual ICollection<ProductInventoryLocation> ProductInventoryLocations { get; set; }

        public static ProductColorSize NewProductColorSize(int organizationId,
            int userId,
            decimal size,
            string sku,
            string sku2,
            string seasonCode) => new ProductColorSize(organizationId: organizationId,
                userId: userId,
                size: size,
                sku: sku,
                sku2: sku2,
                seasonCode: seasonCode);

        public bool HasColorAndSize(string colorName, decimal size) => ProductColor == null ? false : ProductColor.Color.ColorName.ToLower() == (colorName?.ToLower() ?? string.Empty) && Size == size;
    }
}