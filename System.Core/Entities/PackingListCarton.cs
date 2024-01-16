using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public PackingListCarton(int organizationId,
            int userId,
            int cartonSizeId,
            int contactId,
            int packingListId,
            DateTime packedDate,
            string cartonNo,
            decimal amount)
        {
            OrganizationID = organizationId;
            AuditUser(userId);
            CartonSizeID = cartonSizeId;
            ContactID = contactId;
            PackingListID = packingListId;
            PackedDate = packedDate;
            CartonNo = cartonNo;
            Amount = amount;
        }
        public bool IsActive => Status == PackingListCartonStatus.Active;
        public bool IsDelivered => Status == PackingListCartonStatus.Delivered;
        public bool IsInactive  => Status == PackingListCartonStatus.Inactive;
        public virtual CartonSize CartonSize { get; set; }
        public virtual PackingList PackingList { get; set; }
        public virtual ICollection<PackingListCartonItem> PackingListCartonItems { get; set; }
        public void AddPackingListCartonItems(List<PackingListCartonItem> packingListCartonItems)
        {
            if (packingListCartonItems == null) return;

            if (PackingListCartonItems == null) PackingListCartonItems = new List<PackingListCartonItem>();

            foreach (var packingListCartonItem in packingListCartonItems)
            {
                var exitingPackingListCarton = PackingListCartonItems?
                    .FirstOrDefault(t => t.OrderItemID == packingListCartonItem.OrderItemID);

                if (exitingPackingListCarton == null)
                    PackingListCartonItems.Add(packingListCartonItem);
                else
                    continue;
            }
        }

        public static PackingListCarton NewPackingListCarton(int organizationId,
            int userId,
            int cartonSizeId,
            int contactId,
            int packingListId,
            DateTime packedDate,
            string cartonNo,
            decimal amount) => new PackingListCarton(organizationId: organizationId,
                userId: userId,
                cartonSizeId: cartonSizeId,
                contactId: contactId,
                packingListId: packingListId,
                packedDate: packedDate,
                cartonNo: cartonNo,
                amount: amount);

        public bool HasPackingListCartonItems => PackingListCartonItems?.Any() ?? false;
    }
}