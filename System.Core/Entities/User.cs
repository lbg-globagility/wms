using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("users")]
    public partial class User : AuditableEntity
    {
        public int PositionID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }

    public partial class User
    {
        private User()
        {
        }

        public virtual Position Position { get; set; }
    }
}