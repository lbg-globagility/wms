using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("invoiceitems")]
    public class InvoiceItem : OrganizationalEntity
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal? AmountDue { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal? VAT { get; set; }
        public decimal? WithholdingTax { get; set; }
        public int InvoiceID { get; set; }
        public int? AccountID { get; set; }
        public int? BillingPeriodID { get; set; }
        public int? AccountBillingPeriodID { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? TotalDiscount { get; set; }
        public string Comments { get; set; }
        public string ProratedBillingPeriod { get; set; }
        public decimal? TotalAmountDue { get; set; }
        public int LineNumber { get; set; }
        public int? OrderID { get; set; }
        public string AdditionalItem { get; set; }
    }
}