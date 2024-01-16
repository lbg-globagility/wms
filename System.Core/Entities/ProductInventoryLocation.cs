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
        public string UnitOfMeasure2 { get; set; }
        public decimal? UnitPriceOfUOM2 { get; set; }

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
            decimal? unitPrice,
            string unitOfMeasure2,
            decimal? unitPriceOfUOM2)
        {
            OrganizationID = organizationId;
            AuditUser(userId);
            ProductColorSizeID = productColorSizeId;
            UnitPrice = unitPrice;
            UnitOfMeasure = unitOfMeasure;
            UnitOfMeasure2 = unitOfMeasure2;
            UnitPriceOfUOM2 = unitPriceOfUOM2;
        }

        public virtual ProductColorSize ProductColorSize { get; set; }
        public virtual RackShelfColumn RackShelfColumn { get; set; }
        public virtual ICollection<MovementHistory> MovementHistories { get; set; }

        public static ProductInventoryLocation NewProductInventoryLocation(int organizationId,
            int userId,
            int productColorSizeId,
            string unitOfMeasure,
            decimal? unitPrice,
            string unitOfMeasure2,
            decimal? unitPriceOfUOM2) => new ProductInventoryLocation(organizationId: organizationId,
                userId: userId,
                productColorSizeId: productColorSizeId,
                unitOfMeasure: unitOfMeasure,
                unitPrice: unitPrice,
                unitOfMeasure2: unitOfMeasure2,
                unitPriceOfUOM2: unitPriceOfUOM2);

        public int TotalOrderableQty => (TotalAvailableQty ?? 0) - ((TotalAllocatedQty ?? 0) + (TotalReserveQty ?? 0));

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}