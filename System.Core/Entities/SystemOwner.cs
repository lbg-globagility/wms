using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("systemowner")]
    public class SystemOwner : AuditableEntity
    {
        public string Name { get; set; }
        public string IsCurrentOwner { get; set; }

        private const string TEXT_THURSTON = "Thurston";
        public bool IsThurston => Name == TEXT_THURSTON;
    }
}