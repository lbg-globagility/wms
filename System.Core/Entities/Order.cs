using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Dto;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("orders")]
    public partial class Order : AuditableEntity
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
        public OrderStatus Status { get; set; }
        public string ReceivedBrands { get; set; }
        public string ContainerNo { get; set; }
        public string SealNo { get; set; }
        public string ArrivedIn { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalDownPayment { get; set; }
        public decimal? TotalPayment { get; set; }
        public decimal? TotalBalance { get; set; }
    }

    public partial class Order
    {
        private Order()
        {
        }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        
        public virtual ICollection<Lineup> Lineups { get; set; }
        public int? AgentId { get; set; }

        public virtual ICollection<MovementHistory> MovementHistories { get; set; }
        public bool HasMovementHistories => MovementHistories?.Any(t => (t.QtyToApply ?? 0) != 0) ?? false;
        public bool HasNewMovementHistories => MovementHistories?.Any(t => t.IsNewEntity) ?? false;

        public bool IsCustomerOrderType => OrderType == OrderType.CO;
        public bool IsPurchaseOrderType => OrderType == OrderType.PO;
        public bool IsReceivingReportType => OrderType == OrderType.RR;
        public bool IsStockAdjustType => OrderType == OrderType.SA;
        public bool IsStockTransferType => OrderType == OrderType.ST;
        public int OrderNumberInt => int.Parse(OrderNumber);

        public bool IsOpen => Status == OrderStatus.Open;
        public bool IsClose => Status == OrderStatus.Close;
        public bool IsApproved => Status == OrderStatus.Approved;
        public bool IsDelivery => Status == OrderStatus.Delivery;
        public bool IsPacking => Status == OrderStatus.Packing;
        public bool IsForPacking => Status == OrderStatus.ForPacking;
        public bool IsPickListed => Status == OrderStatus.PickListed;
        public bool IsNew => Status == OrderStatus.New;
        public bool IsLinedUp => Status == OrderStatus.LinedUp;
        public bool IsCancelled => Status == OrderStatus.Cancelled;
        public bool IsReceived => Status == OrderStatus.Received;
        public bool IsForApproval => Status == OrderStatus.ForApproval;
        public bool IsSubmittedToWarehouse => Status == OrderStatus.SubmittedToWarehouse;

        public Order(int organizationId,
            int userId,
            OrderType orderType,
            string orderNumber,
            OrderStatus status,
            DateTime orderDate)
        {
            OrganizationID = organizationId;
            CreatedBy = userId;
            OrderType = orderType;
            OrderNumber = orderNumber;
            Status = status;
            OrderDate = orderDate;
        }

        public static Order NewStockTransferOrder(int organizationId,
            int userId,
            string orderNumber,
            OrderStatus status,
            DateTime orderDate) => new Order(organizationId: organizationId,
                userId: userId,
                orderType: OrderType.ST,
                orderNumber: orderNumber,
                status: status,
                orderDate: orderDate);
    }
}