using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("invoice")]
    public class Invoice : OrganizationalEntity
    {
        public int? InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Status { get; set; }
        public string BillPeriod { get; set; }
        public decimal? TotalInvoiceAmount { get; set; }
        public decimal? TotalDue { get; set; }
        public decimal? BalanceForward { get; set; }
        public decimal? BalanceDue { get; set; }
        public decimal? PaymentAmount { get; set; }
        public int? BillToAccountID { get; set; }
        public string LatePaymentFlag { get; set; }
        public int? BillPeriodID { get; set; }
        public int? OrderID { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public string Comments { get; set; }
        public string InvoiceType { get; set; }
        public string WaivePenalty { get; set; }
        public DateTime BillPeriodStartDate { get; set; }
        public DateTime BillPeriodEndDate { get; set; }
        public string PaymentTerms { get; set; }
        public int? ContractID { get; set; }
        public int? PayableToAccountID { get; set; }
        public decimal? AvailableCredit { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal? DepositAmountReceived { get; set; }
        public DateTime DepositDate { get; set; }
        public DateTime DepositDueDate { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalPenalties { get; set; }
        public decimal? TotalVAT { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? TotalDiscounts { get; set; }
        public decimal? TotalGrossAmount { get; set; }
    }
}