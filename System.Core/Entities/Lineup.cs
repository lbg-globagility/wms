using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
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
        public int? Helper1Id { get; set; }
        public int? Helper2Id { get; set; }
    }

    public partial class Lineup
    {
        public Order Order { get; set; }
        public bool IsConfirmedDelivery => ConfirmedDeliveryTimeStamp != null && Status == LineupStatus.ConfirmedDelivery;
        public bool IsDelivered => Status == LineupStatus.Delivered;
        public bool IsCancelled => Status == LineupStatus.Cancelled;

        public virtual ICollection<LineupCarton> LineupCartons { get; set; }
        public bool HasPackingListCartonItems => LineupCartons?.Any(t => t.PackingListCarton?.PackingListCartonItems?.Any() ?? false) ?? false;
        public virtual PackingList  PackingList { get; set; }

        public void SetConfirmedDeliveryTimeStamp(DateTime? dateTime)
        {
            ConfirmedDeliveryTimeStamp = dateTime;
        }

        public void SetStatusToCancelled()
        {
            Status = LineupStatus.Cancelled;
        }

        public virtual DeliveryTruckShift DeliveryTruckShift { get; set; }

        public virtual Contact Driver { get; set; }

        public virtual Contact Helper1 { get; set; }

        public virtual Contact Helper2 { get; set; }

        public string DeliveredBy
        {
            get
            {
                string input = Driver == null ? string.Empty : Driver?.FirstName;
                string pattern = @"\((.*?)\)";

                var match = Regex.Match(input, pattern);
                if (match.Success)
                    return match.Groups[1].Value;

                return Driver?.FirstName;
            }
        }

        public string Helpers
        {
            get
            {
                string[] helperNames = { Helper1?.FirstName, Helper2?.FirstName };

                return string.Join(" & ", helperNames.Where(t => !string.IsNullOrEmpty(t)));
            }
        }

        public string PlateNo => DeliveryTruckShift?.DeliveryTruck?.PlateNo;
    }
}