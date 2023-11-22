using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementSystem.Core.Entities.Base
{
    public abstract class AuditableEntity : OrganizationalEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastUpd { get; private set; }

        public int? CreatedBy { get; private set; }

        public int? LastUpdBy { get; private set; }

        public void AuditUser(int userId)
        {
            if (IsNewEntity)
                CreatedBy = userId;
            else
                LastUpdBy = userId;
        }
    }
}