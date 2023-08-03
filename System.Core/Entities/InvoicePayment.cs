using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("invoicepayments")]
    public class InvoicePayment : OrganizationalEntity
    {
        public int? OrderID { get; set; }
        public int? InvoiceID { get; set; }
        public int PaymentID { get; set; }
        public decimal AppliedAmount { get; set; }
    }
}