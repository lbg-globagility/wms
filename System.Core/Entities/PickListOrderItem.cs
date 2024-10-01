using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("picklistorderitems")]
    public partial class PickListOrderItem : AuditableEntity
    {
        public int PickListOrderID { get; set; }
        public int ProductInventoryLocationID { get; set; }
        public int? QtyPicked { get; set; }
        public int? QtyDelivered { get; set; }
        public int? QtyReserve { get; set; }
        public int? QtyAvailable { get; set; }
        public string IssueFlg { get; set; }
        public PickListOrderItemStatus Status { get; set; }
        public string Remarks { get; set; }
     }

    public partial class PickListOrderItem
    {
        private PickListOrderItem() {}

        public PickListOrderItem(int organizationId,
            int userId,
            int pickListOrderId,
            int productInventoryLocationId,
            int? qtyPicked,
            int? qtyDelivered,
            int? qtyReserve,
            int? qtyAvailable,
            string issueFlg,
            string remarks,
            PickListOrderItemStatus status = PickListOrderItemStatus.Active)
        {
            OrganizationID= organizationId;
            PickListOrderID = pickListOrderId;
            ProductInventoryLocationID = productInventoryLocationId;
            QtyPicked = qtyPicked;
            QtyDelivered = qtyDelivered;
            QtyReserve = qtyReserve;
            QtyAvailable = qtyAvailable;
            IssueFlg = issueFlg;
            Remarks = remarks;
            Status = status;
            AuditUser(userId);
        }

        public virtual PickListOrder PickListOrder { get; set; }

        public static PickListOrderItem NewPickListOrderItem(int organizationId,
            int userId,
            int pickListOrderId,
            int productInventoryLocationId,
            int? qtyPicked,
            int? qtyDelivered,
            int? qtyReserve,
            int? qtyAvailable,
            string issueFlg,
            string remarks,
            PickListOrderItemStatus status = PickListOrderItemStatus.Active) => new PickListOrderItem(organizationId: organizationId,
            userId: userId,
            pickListOrderId: pickListOrderId,
            productInventoryLocationId: productInventoryLocationId,
            qtyPicked: qtyPicked,
            qtyDelivered: qtyDelivered,
            qtyReserve: qtyReserve,
            qtyAvailable: qtyAvailable,
            issueFlg: issueFlg,
            remarks: remarks,
            status: status);
    }
}