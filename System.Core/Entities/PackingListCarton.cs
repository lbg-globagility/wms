using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("packinglistcartons")]
    public partial class PackingListCarton : AuditableEntity
    {
        public int? ContactID { get; set; }
        public int? CartonSizeID { get; set; }
        public int? PackingListID { get; set; }
        public DateTime? PackedDate { get; set; }
        public string CartonNo { get; set; }
        public PackingListCartonStatus Status { get; set; }
        public string WeightUOM { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Amount { get; set; }
    }

    public partial class PackingListCarton
    {
        private PackingListCarton() { }
        private bool IsActive => Status == PackingListCartonStatus.Active;
        private bool IsDelivered => Status == PackingListCartonStatus.Delivered;
        private bool IsInactive  => Status == PackingListCartonStatus.Inactive;
    }
}