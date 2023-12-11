using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("contactcities")]
    public partial class ContactCity
    {
        public int RowId { get; set; }
        public int ContactID { get; set; }

        public int CityID { get; set; }

        public Contact Contact { get; set; }
    }
}