using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("picklistorders")]
    public class PickListOrder : AuditableEntity
    {
        public int PickListID { get; set; }
        public int OrderID { get; set; }
        public int OrderItemID { get; set; }
        public char? ModifiedFlg { get; set; }
        public string Status { get; set; }
    }
}