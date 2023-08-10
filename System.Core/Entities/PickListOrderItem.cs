using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("picklistorderitems")]
    public class PickListOrderItem : AuditableEntity
    {
        public int PickListOrderID { get; set; }
        public int ProductInventoryLocationID { get; set; }
        public int? QtyPicked { get; set; }
        public int? QtyDelivered { get; set; }
        public int? QtyReserve { get; set; }
        public int? QtyAvailable { get; set; }
        public string IssueFlg { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}