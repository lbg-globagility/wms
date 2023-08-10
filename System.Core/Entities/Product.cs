using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("products")]
    public partial class Product : AuditableEntity
    {
        public int? CategoryID { get; set; }
        public int? BrandID { get; set; }
        public int? CompanyID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string Category { get; set; }
        public string Company { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string SKU { get; set; }
        public string SKU2 { get; set; }
        public string BarCode { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? CostPrice { get; set; }
        public int? ReOrderPoint { get; set; }
        public int? LastRcvdFromShipmentCount { get; set; }
        public int? LastSoldCount { get; set; }
        public int? LastArrivedQty { get; set; }
        public int? TotalShipmentCount { get; set; }
        public DateTime LastRcvdFromShipmentDate { get; set; }
        public DateTime LastPurchaseDate { get; set; }
        public DateTime LastSoldDate { get; set; }
        //public longblob? Image { get; set; }
    }

    public partial class Product
    {
        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}