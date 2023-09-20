using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
            if (!nonExistentProductColorSizes?.Any() ?? true) return;

            var thisRackShelfColumns = new List<RackShelfColumn>();
            var hasRackShelfColumns = RackShelfColumns != null && RackShelfColumns.Any();
            if (hasRackShelfColumns) thisRackShelfColumns = RackShelfColumns.ToList();

            if (IsMainWarehouse)
            {
                if (hasRackShelfColumns)
                {
                    var thisRackShelfColumn = thisRackShelfColumns
                        .OrderBy(t => t.PickOrderNo)
                        .FirstOrDefault();

                    foreach (var nonExistentProductColorSize in nonExistentProductColorSizes)
                    {
                        var newProductInventoryLocation = ProductInventoryLocation.NewProductInventoryLocation(organizationId: organizationId,
                            userId: userId,
                            productColorSizeId: nonExistentProductColorSize.RowID.Value,
                            unitPrice: nonExistentProductColorSize?.ProductColor?.Product?.UnitPrice ?? 0);

                        newProductInventoryLocation.RackShelfColumnID = thisRackShelfColumn.RowID;

                        thisRackShelfColumn.AddProductInventoryLocations(productInventoryLocations: new List<ProductInventoryLocation>() { newProductInventoryLocation });
                    }
                }
                else
                {
                    var newRackShelfColumn = RackShelfColumn.NewRackShelfColumn(organizationId: organizationId, userId: userId, inventoryLocationId: RowID.Value);

                    foreach (var nonExistentProductColorSize in nonExistentProductColorSizes)
                    {
                        var newProductInventoryLocation = ProductInventoryLocation.NewProductInventoryLocation(organizationId: organizationId,
                            userId: userId,
                            productColorSizeId: nonExistentProductColorSize.RowID.Value,
                            unitPrice: nonExistentProductColorSize?.ProductColor?.Product?.UnitPrice ?? 0);

                        newRackShelfColumn.AddProductInventoryLocations(productInventoryLocations: new List<ProductInventoryLocation>() { newProductInventoryLocation });
                    }

                    thisRackShelfColumns.Add(newRackShelfColumn);
                }
            }
            else if (IsNotMain)
            {
                if (hasRackShelfColumns)
                {
                    var thisRackShelfColumn = thisRackShelfColumns
                        .OrderBy(t => t.PickOrderNo)
                        .FirstOrDefault();

                    foreach (var nonExistentProductColorSize in nonExistentProductColorSizes)
                    {
                        var newProductInventoryLocation = ProductInventoryLocation.NewProductInventoryLocation(organizationId: organizationId,
                            userId: userId,
                            productColorSizeId: nonExistentProductColorSize.RowID.Value,
                            unitPrice: nonExistentProductColorSize?.ProductColor?.Product?.UnitPrice ?? 0);

                        newProductInventoryLocation.RackShelfColumnID = thisRackShelfColumn.RowID;

                        thisRackShelfColumn.AddProductInventoryLocations(productInventoryLocations: new List<ProductInventoryLocation>() { newProductInventoryLocation });
                    }
                }
                else
                {
                    var newRackShelfColumn = RackShelfColumn.NewRackShelfColumn(organizationId: organizationId, userId: userId, inventoryLocationId: RowID.Value);

                    foreach (var nonExistentProductColorSize in nonExistentProductColorSizes)
                    {
                        var newProductInventoryLocation = ProductInventoryLocation.NewProductInventoryLocation(organizationId: organizationId,
                            userId: userId,
                            productColorSizeId: nonExistentProductColorSize.RowID.Value,
                            unitPrice: nonExistentProductColorSize?.ProductColor?.Product?.UnitPrice ?? 0);

                        newRackShelfColumn.AddProductInventoryLocations(productInventoryLocations: new List<ProductInventoryLocation>() { newProductInventoryLocation });
                    }

                    thisRackShelfColumns.Add(newRackShelfColumn);
                }
            }

            if (RackShelfColumns == null) RackShelfColumns = new List<RackShelfColumn>();
            RackShelfColumns = thisRackShelfColumns;
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