using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productbundles")]
    public class ProductBundle : AuditableEntity
    {
        public int? BrandID { get; set; }
        public int? CategoryID { get; set; }
        public int? CompanyID { get; set; }
        public string BundleName { get; set; }
        public string SKU { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal? SRP { get; set; }
    }
}