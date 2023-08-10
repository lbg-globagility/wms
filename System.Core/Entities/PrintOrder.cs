using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("printorder")]
    public class PrintOrder : AuditableEntity
    {
        public string PrintValue { get; set; }

        [Column("PrintOrder")]
        public int? IsPrintOrder { get; set; }

        public string Status { get; set; }
    }
}