using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productcolors")]
    public class ProductColor : OrganizationalEntity
    {
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public string Status { get; set; }
    }
}