using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productinventorylocation")]
    public class ProductInventoryLocation : OrganizationalEntity
    {
        public int RackShelfColumnID { get; set; }
        public int ProductColorSizeID { get; set; }
        public int? TotalAvailableQty { get; set; }
        public int? TotalAllocatedQty { get; set; }
        public int? TotalReserveQty { get; set; }
        public int? TotalDamageQty { get; set; }
        public int? TotalSupplierProblemQty { get; set; }
        public int? TotalInRepairQty { get; set; }
        public int? TotalToReceiveQty { get; set; }
        public int? RunningTotalQty { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? LastInventoryCount { get; set; }
    }
}