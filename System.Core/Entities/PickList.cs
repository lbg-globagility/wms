using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("picklist")]
    public partial class PickList : AuditableEntity
    {
        public int? InventoryLocationID { get; set; }
        public int? ContactID { get; set; }
        public string PickListNo { get; set; }
        public DateTime? PickListDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public PickListStatus Status { get; set; }
        public string Comments { get; set; }
    }

    public partial class PickList
    {
        public virtual ICollection<PickListOrder> PickListOrders { get; set; }
        public void SetStatusToCancelled()
        {
            Status = PickListStatus.Cancelled;

            if(PickListOrders?.Any() ?? false)
                foreach (var pickListOrder in PickListOrders)
                {
                    pickListOrder.Status = PickListOrderStatus.Cancelled;
                    pickListOrder.SetEdited();

                    foreach (var item in pickListOrder.PickListOrderItems)
                    {
                        item.Status = default;
                        item.SetEdited();
                    }
                }
        }

        public string SearchableText => string.Empty;
    }
}
