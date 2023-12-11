using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("shifts")]
    public partial class Shift : AuditableEntity
    {
        public string ShiftName { get; set; }
        public TimeSpan? TimeFrom { get; set; }
        public TimeSpan? TimeTo { get; set; }
        public string Status { get; set; } // Active
    }

    public partial class Shift
    {
        private Shift() { }
    }
}