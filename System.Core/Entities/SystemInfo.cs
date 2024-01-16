using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("systeminfo")]
    public partial class SystemInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public partial class SystemInfo
    {
        public const string SYSTEM_VERSION = "system.version";

        public bool IsSystemVersion => Name == SYSTEM_VERSION;
    }
}
