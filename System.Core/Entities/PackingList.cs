using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

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

        public virtual Order Order { get; set; }

        public decimal GrandTotalItemGross => Order?.OrderItems?.Sum(t => t.TotalItemGross) ?? 0M;

        public virtual ICollection<PackingListCarton> PackingListCartons { get; set; }

        public void SetStatusToCancelled()
        {
            Status = $"{OrderStatus.Cancelled}";

            if(PackingListCartons != null)
                foreach (var item in PackingListCartons)
                {
                    item.Status = PackingListCartonStatus.Cancelled;
                    item.SetEdited();
                }
        }


    }
}