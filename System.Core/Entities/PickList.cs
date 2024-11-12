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

        private PickList () { }

        public PickList (int organizationId,
            int userId,
            string pickListNo,
            int? inventoryLocationID = null,
            int? contactID = null,
            PickListStatus status = default,
            string comments = "")
        {
            InventoryLocationID = inventoryLocationID;
            ContactID = contactID;
            PickListNo = pickListNo;
            PickListDate = DateTime.Now;
            Status = status;
            Comments = comments;
            OrganizationID = organizationId;
            AuditUser(userId);
        }

        public static PickList NewPickList(int organizationId,
            int userId,
            string pickListNo,
            int? inventoryLocationID = null,
            int? contactID = null,
            PickListStatus status = default,
            string comments = "") => new PickList(organizationId: organizationId,
            userId: userId,
            inventoryLocationID: inventoryLocationID,
            contactID: contactID,
            pickListNo: pickListNo,
            status: status,
            comments: comments);

        public int PickListNumberInt
        {
            get
            {
                if (string.IsNullOrEmpty(PickListNo)) return 0;

                return int.Parse(PickListNo);
            }
        }
    }
}
