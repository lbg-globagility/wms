using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("orderitems")]
    public partial class OrderItem : AuditableEntity
    {
        public int? AccountID { get; set; }

        //[ForeignKey("Order")]
        public int OrderID { get; set; }

        public int? ProductColorSizeID { get; set; }
        public int? ProductBundleID { get; set; }

        public int? OrderItemID { get; set; }

        public int? VerifiedBy { get; set; }
        public int? PackedBy { get; set; }
        public int? DeliveredBy { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public DateTime? PackedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public int? QtyOrdered { get; set; }
        public int? QtyAvailable { get; set; }
        public int? QtyDelivered { get; set; }
        public int? QtyDamaged { get; set; }
        public int? QtyReceived { get; set; }
        public decimal? SRP { get; set; }
        public string ItemType { get; set; }
        public string Approval { get; set; }
        public string ItemCode { get; set; }
        public string SKU { get; set; }
        public string SKU2 { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Tags { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string Reasons { get; set; }
        public int? ProductInventoryLocationId { get; set; }
        public int? RackShelfColumnId { get; set; }
    }

    public partial class OrderItem
    {
        public virtual Order Order { get; set; }
        public virtual ProductColorSize ProductColorSize { get; set; }
        public decimal OrderedGross => (QtyOrdered ?? 0) * (SRP ?? 0);
        public decimal AvailableGross => (QtyAvailable ?? 0) * (SRP ?? 0);
        public decimal DeliveredGross => (QtyDelivered ?? 0) * (SRP ?? 0);
        public decimal DamagedGross => (QtyDamaged ?? 0) * (SRP ?? 0);
        public decimal ReceivedGross => (QtyReceived ?? 0) * (SRP ?? 0);
        public decimal TotalItemGross => OrderedGross + AvailableGross + DeliveredGross + DamagedGross + ReceivedGross;
        public virtual ProductInventoryLocation ProductInventoryLocation { get; set; }
        public virtual RackShelfColumn RackShelfColumn { get; set; }

        private OrderItem() { }
        public OrderItem(int organizationId,
            int userId,
            int qtyOrdered,
            decimal srp,
            string unitOfMeasure,
            string sku,
            string sku2,
            int productColorSizeId,
            int productInventoryLocationId,
            int? rowId = null)
        {
            OrganizationID = organizationId;
            AuditUser(userId);
            QtyOrdered = qtyOrdered;
            SRP = srp;
            UnitOfMeasure = unitOfMeasure;
            SKU = sku;
            SKU2 = sku2;
            ProductColorSizeID = productColorSizeId;
            ProductInventoryLocationId = productInventoryLocationId;
        }

        public static OrderItem NewCustomerOrderItem(int organizationId,
            int userId,
            int qtyOrdered,
            decimal srp,
            string unitOfMeasure,
            string sku,
            string sku2,
            int productColorSizeId,
            int productInventoryLocationId,
            int? rowId = null) => new OrderItem(organizationId: organizationId,
                userId: userId,
                qtyOrdered: qtyOrdered,
                srp: srp,
                unitOfMeasure: unitOfMeasure,
                sku: sku,
                sku2: sku2,
                productColorSizeId: productColorSizeId,
                productInventoryLocationId: productInventoryLocationId,
                rowId: rowId);
    }
}