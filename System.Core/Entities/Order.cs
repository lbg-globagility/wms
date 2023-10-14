using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("orders")]
    public class Order : AuditableEntity
    {
        public int? RelatedOrderID { get; set; }
        public int? InventoryLocationID { get; set; }
        public int? ContactID { get; set; }
        public int? BranchID { get; set; }
        public int? CompanyID { get; set; }
        public int? CombineCodingID { get; set; }
        public int? AccountID { get; set; }
        public OrderType OrderType { get; set; }
        public string OrderNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string DRNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime? TimeArrived { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string DeliveryHours { get; set; }
        public string Comments { get; set; }
        public string ReceivedBy { get; set; }
        public string Status { get; set; }
        public string ReceivedBrands { get; set; }
        public string ContainerNo { get; set; }
        public string SealNo { get; set; }
        public string ArrivedIn { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalDownPayment { get; set; }
        public decimal? TotalPayment { get; set; }
        public decimal? TotalBalance { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Lineup> Lineups { get; set; }
        public int? AgentId { get; set; }
    }
}