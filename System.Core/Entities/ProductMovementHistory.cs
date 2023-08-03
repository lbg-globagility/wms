using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productmovementhistory")]
    public class ProductMovementHistory : OrganizationalEntity
    {
        public int? OrderID { get; set; }
        public int? LineUpID { get; set; }
        public int? PickListID { get; set; }
        public int? ProductColorSizeID { get; set; }
        public int? ProductInventoryLocationIDA { get; set; }
        public int? ProductInventoryLocationIDB { get; set; }
        public int? CurrentQty { get; set; }
        public int? QtyToApply { get; set; }
        public int? NewQty { get; set; }
        public string TransactionType { get; set; }
        public string ColumnName { get; set; }
        public string Comments { get; set; }
    }
}