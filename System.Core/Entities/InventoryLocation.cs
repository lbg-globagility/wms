using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("inventorylocations")]
    public partial class InventoryLocation : AuditableEntity
    {
        public int? AddressID { get; set; }
        public int? PrimaryContactID { get; set; }
        public string Name { get; set; }
        public InventoryLocationType Type { get; set; }
        public string MainPhone { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNumber { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string MainBranch { get; set; }
    }

    public partial class InventoryLocation
    {
        private InventoryLocation()
        {
        }

        public bool IsMainWarehouse => Type == InventoryLocationType.Main;
        public bool IsNotMain => !IsMainWarehouse && (IsClassBWarehouse || IsSampleWarehouse || IsDamageWarehouse);

        //public bool IsBranch => Type == InventoryLocationType.Branch;
        //public bool IsOthers => Type == InventoryLocationType.Others;
        //public bool IsSub => Type == InventoryLocationType.Sub;
        public bool IsClassBWarehouse => Type == InventoryLocationType.ClassB;

        public bool IsSampleWarehouse => Type == InventoryLocationType.Sample;
        public bool IsDamageWarehouse => Type == InventoryLocationType.Damage;

        //public virtual RackShelfColumn RackShelfColumn { get; set; }
        public virtual ICollection<RackShelfColumn> RackShelfColumns { get; set; }

        public void PopulateWithRackShelfColumns(int organizationId,
            int userId,
            List<ProductColorSize> nonExistentProductColorSizes)
        {
            if (IsNewEntity) return;

            var newRackShelfColumns = new List<RackShelfColumn>();

            if (IsMainWarehouse)
            {
                foreach (var nonExistentProductColorSize in nonExistentProductColorSizes)
                {
                    var newProductInventoryLocation = ProductInventoryLocation.NewProductInventoryLocation(organizationId: organizationId,
                        userId: userId,
                        productColorSizeId: nonExistentProductColorSize.RowID.Value);

                    var newRackShelfColumn = RackShelfColumn.NewRackShelfColumn(organizationId: organizationId, userId: userId, inventoryLocationId: RowID.Value);

                    newRackShelfColumn.AddProductInventoryLocations(productInventoryLocations: new List<ProductInventoryLocation>() { newProductInventoryLocation });

                    newRackShelfColumns.Add(newRackShelfColumn);
                }
            }
            else if (IsNotMain)
            {
                var newRackShelfColumn = RackShelfColumn.NewRackShelfColumn(organizationId: organizationId, userId: userId, inventoryLocationId: RowID.Value);

                newRackShelfColumns.Add(newRackShelfColumn);

                foreach (var nonExistentProductColorSize in nonExistentProductColorSizes)
                {
                    var newProductInventoryLocation = ProductInventoryLocation.NewProductInventoryLocation(organizationId: organizationId,
                        userId: userId,
                        productColorSizeId: nonExistentProductColorSize.RowID.Value);

                    newRackShelfColumn.AddProductInventoryLocations(productInventoryLocations: new List<ProductInventoryLocation>() { newProductInventoryLocation });
                }
            }

            if (RackShelfColumns == null) RackShelfColumns = new List<RackShelfColumn>();
            RackShelfColumns = newRackShelfColumns;
        }

        public InventoryLocation(int organizationId,
            string name,
            InventoryLocationType type)
        {
            OrganizationID = organizationId;
            Name = name;
            Type = type;
        }

        public static InventoryLocation NewInventoryLocation(int organizationId,
            string name,
            InventoryLocationType type) => new InventoryLocation(organizationId: organizationId,
                name: name,
                type: type);
    }
}