using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("useractivityitem")]
    public partial class UserActivityItem : BaseEntity
    {
        public int UserActivityId { get; set; }
        public int EntityId { get; set; }
        public int? ChangedUserId { get; set; }
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastUpd { get; set; }
    }

    public partial class UserActivityItem
    {
        private UserActivityItem()
        {
        }

        public UserActivityItem(int entityId,
            string description,
            int? changedUserId)
        {
            EntityId = entityId;
            Description = description;
            ChangedUserId = changedUserId;
        }

        public static UserActivityItem NewUserActivityItem(int entityId,
            string description,
            int? changedUserId) => new UserActivityItem(entityId: entityId,
                description: description,
                changedUserId: changedUserId);
    }
}