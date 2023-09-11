using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("listofvalues")]
    public class ListOfValue : AuditableEntity
    {
        public string DisplayValue { get; set; }
        public string LIC { get; set; }
        public string Type { get; set; }
        public string ParentLIC { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string SystemFlg { get; set; }
        public string DisplayFlg { get; set; }
        public int? OrderBy { get; set; }
    }
}