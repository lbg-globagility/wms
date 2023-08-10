using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productcolors")]
    public partial class ProductColor : AuditableEntity
    {
        //[ForeignKey("Product")]
        public int ProductID { get; set; }

        public int ColorID { get; set; }
        public string Status { get; set; }

        public virtual Product Product { get; set; }
    }

    public partial class ProductColor
    {
        public virtual ICollection<ProductColorSize> ProductColorSizes { get; set; }
    }
}