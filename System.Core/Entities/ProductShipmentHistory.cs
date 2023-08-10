using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productshipmenthistory")]
    public class ProductShipmentHistory : AuditableEntity
    {
        public int? ShipmentCount { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string LotNo { get; set; }
        public string BatchNo { get; set; }
        public string CartonNo { get; set; }
        public int? InvoiceNo { get; set; }
    }
}