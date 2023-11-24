using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("deliverytrucks")]
    public partial class DeliveryTruck : AuditableEntity
    {
        public int TruckNo { get; set; }
        public string TruckName { get; set; }
        public string PlateNo { get; set; }
        public string BrandName { get; set; }
        public string MadeIn { get; set; }
        public string Status { get; set; } // Active
        public decimal? CBM { get; set; }
        public string YearAndModel { get; set; }
    }

    public partial class DeliveryTruck
    {
        private DeliveryTruck() { }
    }
}