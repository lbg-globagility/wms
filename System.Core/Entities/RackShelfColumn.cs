using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("rackshelfcolumn")]
    public partial class RackShelfColumn : AuditableEntity
    {
        public int InventoryLocationID { get; set; }
        public string RackNo { get; set; }
        public string ShelfNo { get; set; }
        public string ColumnNo { get; set; }
        public string Remarks { get; set; }
        public RackShelfColumnStatus Status { get; set; }
        public int? PickOrderNo { get; set; }
        public int? AvailableQty { get; set; }
        public int? DistributedQty { get; set; }
        public int? ReservedQty { get; set; }
        public int? DamagedQty { get; set; }
        public int? InRepairQty { get; set; }
        public int? SupplierProblemQty { get; set; }
        public DateTime? LastShippedToLocDate { get; set; }
        public DateTime? LastCycleCountDate { get; set; }

    }

    public partial class RackShelfColumn
    {
        private RackShelfColumn()
        {
        }

        public RackShelfColumn(int organizationId,
            int userId,
            int inventoryLocationId)
        {
            OrganizationID = organizationId;
            AuditUser(userId);
            InventoryLocationID = inventoryLocationId;
            Status = RackShelfColumnStatus.Active;
            PickOrderNo = (PickOrderNo ?? 0) == 0 ? 1 : PickOrderNo;
        }

        public virtual InventoryLocation InventoryLocation { get; set; }
        public virtual ICollection<ProductInventoryLocation> ProductInventoryLocations { get; set; }

        public static RackShelfColumn NewRackShelfColumn(int organizationId,
            int userId,
            int inventoryLocationId) => new RackShelfColumn(organizationId: organizationId,
                userId: userId,
                inventoryLocationId: inventoryLocationId);

        public void AddProductInventoryLocations(List<ProductInventoryLocation> productInventoryLocations)
        {
            if (productInventoryLocations == null) return;

            if (ProductInventoryLocations == null) ProductInventoryLocations = new List<ProductInventoryLocation>();

            foreach (var productInventoryLocation in productInventoryLocations)
            {
                var exitingProductInventoryLocation = ProductInventoryLocations?
                    .FirstOrDefault(t => t.ProductColorSizeID == productInventoryLocation.ProductColorSizeID);

                if (exitingProductInventoryLocation == null)
                    ProductInventoryLocations.Add(productInventoryLocation);
                else
                    continue;
            }
        }

        public int LogicalAvailableQty => AvailableQty ?? 0 - ReservedQty ?? 0;

        public bool IsActive => Status == RackShelfColumnStatus.Active;
    }
}