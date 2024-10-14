using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("deliverytruckshifts")]
    public partial class DeliveryTruckShift : AuditableEntity
    {
        public int DeliveryTruckID { get; set; }
        public int ShiftID { get; set; }
        public string Status { get; set; } // Active
    }

    public partial class DeliveryTruckShift
    {
        private DeliveryTruckShift() { }

        public virtual DeliveryTruck DeliveryTruck { get; set; }

        public virtual ICollection<Lineup> LineUps { get; set; }
    }
}