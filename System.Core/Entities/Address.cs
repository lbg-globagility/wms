using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("address")]
    public partial class Address : AuditableEntity
    {
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string Barangay { get; set; }
        public string CityTown { get; set; }
        public string Province { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }

    public partial class Address
    {
        public virtual ICollection<Account> Accounts { get; set; }
        public string FullAddress => string.Join(", ", (new string[] { StreetAddress1,
            StreetAddress2,
            Barangay,
            CityTown,
            Province,
            State,
            ZipCode,
            Country })
            .Where(t => !string.IsNullOrEmpty(t)));
    }
}