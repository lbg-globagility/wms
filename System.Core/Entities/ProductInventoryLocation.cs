using System;
using System.Collections.Generic;
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
        public string UnitOfMeasure { get; set; }
    }

    public partial class ProductInventoryLocation
    {
        private ProductInventoryLocation()
        {
        }

        public ProductInventoryLocation(int organizationId,
            int userId,
            int productColorSizeId,
            string unitOfMeasure,
            decimal? unitPrice = null)
        {
            OrganizationID = organizationId;
            AuditUser(userId);
            ProductColorSizeID = productColorSizeId;
            UnitPrice = unitPrice;
            UnitOfMeasure = unitOfMeasure;
        }

        public virtual ProductColorSize ProductColorSize { get; set; }
        public virtual RackShelfColumn RackShelfColumn { get; set; }
        public virtual ICollection<MovementHistory> MovementHistories { get; set; }

        public static ProductInventoryLocation NewProductInventoryLocation(int organizationId,
            int userId,
            int productColorSizeId,
            string unitOfMeasure,
            decimal? unitPrice = null) => new ProductInventoryLocation(organizationId: organizationId,
                userId: userId,
                productColorSizeId: productColorSizeId,
                unitOfMeasure: unitOfMeasure,
                unitPrice: unitPrice);

        public int TotalOrderableQty => (TotalAvailableQty ?? 0) - (TotalAllocatedQty ?? 0);

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}