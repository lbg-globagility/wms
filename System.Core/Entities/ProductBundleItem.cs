using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productbundleitems")]
    public class ProductBundleItem : AuditableEntity
    {
        public int ProductBundleID { get; set; }
        public int ProductColorSizeID { get; set; }
        public int? QtyAvailable { get; set; }
        public string Status { get; set; }
    }
}