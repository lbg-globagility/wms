using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("lineups")]
    public partial class Lineup : AuditableEntity
    {
        public int? ContactID { get; set; }
        public int? PackingListID { get; set; }
        public int? DeliveryTruckShiftID { get; set; }
        public int? OrderID { get; set; }
        public DateTime? LineUpDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryHours { get; set; }
        public string DeliveryNo { get; set; }
        public string LineUpNo { get; set; }
        public LineupStatus Status { get; set; }
        public string Comments { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime? ConfirmedDeliveryTimeStamp { get; private set; }
    }

    public partial class Lineup
    {
        public bool IsConfirmedDelivery => Status == LineupStatus.ConfirmedDelivery;
        public bool IsDelivered => Status == LineupStatus.Delivered;
        public bool IsCancelled => Status == LineupStatus.Cancelled;

        public void SetConfirmedDeliveryTimeStamp(DateTime? dateTime)
        {
            ConfirmedDeliveryTimeStamp = dateTime;
        }
    }
}