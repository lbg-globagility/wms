using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("inventorylocations")]
    public partial class InventoryLocation : OrganizationalEntity
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
        public bool IsMain => Type == InventoryLocationType.Main;
        public bool IsBranch => Type == InventoryLocationType.Branch;
        public bool IsOthers => Type == InventoryLocationType.Others;
        public bool IsSub => Type == InventoryLocationType.Sub;
    }
}