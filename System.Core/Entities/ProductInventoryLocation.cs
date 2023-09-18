using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productinventorylocation")]
    public partial class ProductInventoryLocation : AuditableEntity
    {
        ////[ForeignKey("RackShelfColumn")]
        public int? RackShelfColumnID { get; set; }

        ////[ForeignKey("ProductColorSize")]
        public int ProductColorSizeID { get; set; }

        public int? TotalAvailableQty { get; set; }
        public int? TotalAllocatedQty { get; set; }
        public int? TotalReserveQty { get; set; }
        public int? TotalDamageQty { get; set; }
        public int? TotalSupplierProblemQty { get; set; }
        public int? TotalInRepairQty { get; set; }
        public int? TotalToReceiveQty { get; set; }
        public int? RunningTotalQty { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? LastInventoryCount { get; set; }
    }

    public partial class ProductInventoryLocation
    {
        private ProductInventoryLocation()
        {
        }

        public ProductInventoryLocation(int organizationId,
            int userId,
            int productColorSizeId,
            decimal? unitPrice = null)
        {
            OrganizationID = organizationId;
            CreatedBy = userId;
            ProductColorSizeID = productColorSizeId;
            UnitPrice = unitPrice;
        }

        public virtual ProductColorSize ProductColorSize { get; set; }
        public virtual RackShelfColumn RackShelfColumn { get; set; }

        public static ProductInventoryLocation NewProductInventoryLocation(int organizationId,
            int userId,
            int productColorSizeId,
            decimal? unitPrice = null) => new ProductInventoryLocation(organizationId: organizationId,
                userId: userId,
                productColorSizeId: productColorSizeId,
                unitPrice: unitPrice);
    }
}