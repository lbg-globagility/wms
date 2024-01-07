using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("packinglistcartonitems")]
    public partial class PackingListCartonItem : AuditableEntity
    {
        public int? PackingListCartonID { get; set; }
        public int? OrderItemID { get; set; }
        public int? QtyInCarton { get; set; }
        public PackingListCartonItemStatus Status { get; set; }
    }
    public partial class PackingListCartonItem
    {
        private PackingListCartonItem()
        {
        }

        public PackingListCartonItem(int organizationId,
            int userId,
            int orderItemId,
            int quantity)
        {
            OrganizationID = organizationId;
            AuditUser(userId);
            OrderItemID = orderItemId;
            QtyInCarton = quantity;
        }

        public bool IsActive => Status == PackingListCartonItemStatus.Active;
        public bool IsDelivered => Status == PackingListCartonItemStatus.Delivered;
        public bool IsInactive => Status == PackingListCartonItemStatus.Inactive;
        public virtual PackingListCarton PackingListCarton { get; set; }

        public static PackingListCartonItem NewPackingListCartonItem(int organizationId,
            int userId,
            int orderItemId,
            int quantity) => new PackingListCartonItem(organizationId: organizationId,
                userId: userId,
                orderItemId: orderItemId,
                quantity: quantity);
    }
}