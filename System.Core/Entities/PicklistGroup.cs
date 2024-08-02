using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("picklist")]
    public partial class PicklistGroup : AuditableEntity
    {
        public string GroupName { get; set; }
        public string Status { get; set; }
    }

    public partial class PicklistGroup
    {

    }
}
