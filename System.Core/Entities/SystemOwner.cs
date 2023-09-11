using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("systemowner")]
    public class SystemOwner : BaseEntity
    {
        public string Name { get; set; }
        public bool IsCurrentOwner { get; set; }

        private const string TEXT_THURSTON = "Thurston";
        public bool IsThurston => Name == TEXT_THURSTON;
    }
}