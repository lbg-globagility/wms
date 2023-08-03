using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementSystem.Core.Entities
{
    public class Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        public int? CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastUpd { get; set; }

        public int? LastUpdBy { get; set; }
        public int? PrimaryAddressID { get; set; }
        public int? PremiseAddressID { get; set; }
        public int? PrimaryContactID { get; set; }
        public string Name { get; set; }
        public string TradeName { get; set; }
        public string MainPhone { get; set; }
        public string AltPhone { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AltEmailAddress { get; set; }
        public string TINNo { get; set; }
        public string Website { get; set; }
        public string OrganizationType { get; set; }
        public string Comments { get; set; }
        //public longblob? Image { get; set; }
    }
}