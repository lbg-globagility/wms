using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("lineupcartons")]
    public partial class LineupCarton : AuditableEntity
    {
        public int? PackingListCartonID { get; set; }
        public int? LineUpID { get; set; }
        public string Status { get; set; }
        public decimal? CBM { get; set; }
    }

    public partial class LineupCarton
    {
        public virtual Lineup Lineup { get; set; }
        public virtual PackingListCarton PackingListCarton { get; set; }
        public virtual ICollection<PackingListCartonItem> PackingListCartonItems { get; set; }
        //public bool HasPackingListCartonItems => PackingListCarton?.PackingListCartonItems?.Any() ?? false;
    }
}
