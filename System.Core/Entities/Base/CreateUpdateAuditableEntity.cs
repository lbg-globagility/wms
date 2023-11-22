using System;
using System.Linq;

namespace WarehouseManagementSystem.Core.Entities.Base
{
    public abstract class CreateUpdateAuditableEntity : AuditableEntity
    {
        public virtual User UserCreate { get; set; }

        public string UserCreateFullName =>
            String.Join(", ", new string[] { UserCreate?.LastName, UserCreate?.FirstName }.Where(t => !string.IsNullOrEmpty(t)));

        public virtual User UserUpdate { get; set; }

        public string UserUpdateFullName =>
            String.Join(", ", new string[] { UserUpdate?.LastName, UserUpdate?.FirstName }.Where(t => !string.IsNullOrEmpty(t)));
    }
}