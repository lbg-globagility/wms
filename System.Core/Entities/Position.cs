using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("positions")]
    public partial class Position : AuditableEntity
    {
        public string PositionName { get; set; }
        public string Status { get; set; }
        public int? ParentPositionID { get; set; }
        public int? DivisionId { get; set; }
        public string Comments { get; set; }
    }

    public partial class Position
    {
        private Position()
        {
        }

        public virtual ICollection<PositionView> PositionViews { get; set; }
        public virtual User User { get; set; }
    }
}