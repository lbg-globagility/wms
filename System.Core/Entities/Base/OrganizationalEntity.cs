namespace WarehouseManagementSystem.Core.Entities.Base
{
    public abstract class OrganizationalEntity : BaseEntity
    {
        public int? OrganizationID { get; set; }

        //[ForeignKey("OrganizationID")]
        public virtual Organization Organization { get; set; }
    }
}