using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("positionviews")]
    public partial class PositionView : AuditableEntity
    {
        public int? PositionID { get; set; }
        public int? ViewID { get; set; }
        public bool Creates { get; set; }
        public bool ReadOnly { get; set; }
        public bool Updates { get; set; }
        public bool Disable { get; set; }
        public string Remarks { get; set; }
    }

    public partial class PositionView
    {
        private PositionView()
        {
        }

        public virtual Position Position { get; set; }
        public virtual View View { get; set; }

        public string PositionName => Position?.PositionName;
        public string ViewName => View?.ViewName;
        public bool Restricted => Disable && !ReadOnly;
        public bool IsGodMode => Position?.IsGodMode ?? false;
    }
}