using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("packinglist")]
    public partial class PackingList : AuditableEntity
    {
        public int? OrderID { get; set; }
        public string PackingListNo { get; set; }
        public DateTime? PackingListDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }

    public partial class PackingList
    {
        private PackingList() { }
    }
}