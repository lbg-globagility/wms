using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productcolorsizes")]
    public class ProductColorSize : OrganizationalEntity
    {
        public int ProductColorID { get; set; }
        public decimal Size { get; set; }
        public int? TotalAvailableQty { get; set; }
        public int? TotalDamageQty { get; set; }
        public int? LastSoldCount { get; set; }
        public DateTime? LastShipmentDate { get; set; }
        public DateTime? LastSoldDate { get; set; }
        public string SeasonCode { get; set; }
        public string SKU { get; set; }
        public string SKU2 { get; set; }
        public string Status { get; set; }
        public string BarCode { get; set; }
        public string Type { get; set; }
    }
}