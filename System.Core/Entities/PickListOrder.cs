using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("picklistorders")]
    public partial class PickListOrder : AuditableEntity
    {
        public int PickListID { get; set; }
        public int OrderID { get; set; }
        public int OrderItemID { get; set; }
        public char? ModifiedFlg { get; set; }
        public PickListOrderStatus Status { get; set; }
    }

    public partial class PickListOrder
    {
        public virtual PickList PickList { get; set; }
        public virtual ICollection<PickListOrderItem> PickListOrderItems { get; set; }
    }
}