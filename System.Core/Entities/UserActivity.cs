using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("useractivity")]
    public partial class UserActivity : OrganizationalEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastUpd { get; private set; }

        public int UserId { get; set; }
        public string EntityName { get; set; }
        public string RecordType { get; set; }
    }

    public partial class UserActivity
    {
        private UserActivity()
        {
        }

        public UserActivity(int organizationId,
            int userId,
            string entityName,
            string recordType)
        {
            UserId = userId;
            EntityName = entityName.ToUpper();
            OrganizationID = organizationId;
            RecordType = recordType;
        }

        public static UserActivity NewUserActivity(int organizationId,
            int userId,
            string entityName,
            string recordType) => new UserActivity(organizationId: organizationId,
                userId: userId,
                entityName: entityName,
                recordType: recordType);

        public virtual ICollection<UserActivityItem> ActivityItems { get; set; }

        public void AddActivityItems(List<UserActivityItem> activityItems)
        {
            if (ActivityItems == null) ActivityItems = new List<UserActivityItem>();

            foreach (var activityItem in activityItems)
                ActivityItems.Add(activityItem);
        }

        public const string RecordTypeAdd = "ADD";
        public const string RecordTypeEdit = "EDIT";
        public const string RecordTypeDelete = "DELETE";

        public enum ChangedType
        {
            Employee,
            User,
            Organization,
            Division,
            Position
        }
    }
}