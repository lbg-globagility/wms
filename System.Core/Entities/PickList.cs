using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public string Status { get; set; }
        public string Comments { get; set; }
    }

    public partial class PickList
    {
        public virtual ICollection<PickListOrder> PickListOrders { get; set; }
        public void SetStatusToCancelled()
        {
            Status = $"{OrderStatus.Cancelled}";

            if(PickListOrders?.Any() ?? false)
                foreach (var pickListOrder in PickListOrders)
                {
                    pickListOrder.Status = Status;
                    pickListOrder.SetEdited();

                    foreach (var item in pickListOrder.PickListOrderItems)
                    {
                        item.Status = Status;
                        item.SetEdited();
                    }
                }
        }
    }
}
