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
        private PackingListCartonItem() { }
        private bool IsActive => Status == PackingListCartonItemStatus.Active;
        private bool IsDelivered => Status == PackingListCartonItemStatus.Delivered;
        private bool IsInactive => Status == PackingListCartonItemStatus.Inactive;
    }
}