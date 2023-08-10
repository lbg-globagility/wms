using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("agents")]
    public class Agent : AuditableEntity
    {
        public string Code { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}