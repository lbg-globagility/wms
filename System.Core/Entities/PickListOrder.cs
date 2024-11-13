using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("picklistorders")]
    public partial class PickListOrder : AuditableEntity
    {
        public int? PickListID { get; set; }
        public int OrderID { get; set; }
        public int OrderItemID { get; set; }
        public char? ModifiedFlg { get; set; }
        public PickListOrderStatus Status { get; set; }
    }

    public partial class PickListOrder
    {
        public bool IsNewStatus => Status == PickListOrderStatus.New;
        public bool IsInactiveStatus => Status == PickListOrderStatus.Inactive;
        public bool IsModifiedStatus => Status == PickListOrderStatus.Modified;
        public bool IsVerifiedStatus => Status == PickListOrderStatus.Verified;
        public bool IsCancelledStatus => Status == PickListOrderStatus.Cancelled;

        public virtual PickList PickList { get; set; }
        public virtual ICollection<PickListOrderItem> PickListOrderItems { get; set; }
        public PickListOrderItem PickListOrderItem => PickListOrderItems?.FirstOrDefault(t => t.IsActive) ?? PickListOrderItems?.FirstOrDefault();
        public virtual ICollection<PackingListCartonItem> PackingListCartonItems { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderItem OrderItem { get; set; }
        public string ProductCode => OrderItem?.ProductColorSize?.ProductColor.ProductCode;

        private PickListOrder() { }

        public PickListOrder(int organizationId,
            int userId,
            int? pickListId,
            int orderId,
            int orderItemId,
            PickListOrderStatus status = default)
        {
            PickListID = pickListId;
            OrderID = orderId;
            OrderItemID = orderItemId;
            ModifiedFlg = 'N';
            Status = status;
            OrganizationID = organizationId;
            AuditUser(userId);
        }

        public static PickListOrder NewPickListOrder(int organizationId,
            int userId,
            int? pickListId,
            int orderId,
            int orderItemId,
            PickListOrderStatus status = default) => new PickListOrder(organizationId: organizationId,
                userId: userId,
                pickListId: pickListId,
                orderId: orderId,
                orderItemId: orderItemId,
                status: status);
    }
}
