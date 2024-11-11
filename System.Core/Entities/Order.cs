using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("orders")]
    public partial class Order : CreateUpdateAuditableEntity
    {
        public int? RelatedOrderID { get; set; }
        public int? InventoryLocationID { get; set; }
        /// <summary>
        /// Basically the `Agent`
        /// </summary>
        public int? ContactID { get; set; }
        public int? BranchID { get; set; }
        public int? CompanyID { get; set; }
        public int? CombineCodingID { get; set; }
        /// <summary>
        /// Basically the `Customer`
        /// </summary>
        public int? AccountID { get; set; }
        public OrderType OrderType { get; set; }
        public string OrderNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string DRNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public TimeSpan? TimeArrived { get; set; }
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
        /// <summary>
        /// Basically the `Agent`
        /// </summary>
        public int? AgentID { get; set; }
    }

    public partial class Order
    {
        private Order()
        {
            if(OrderItems == null) OrderItems = new List<OrderItem>();
        }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Lineup> Lineups { get; set; }
        public virtual ICollection<MovementHistory> MovementHistories { get; set; }
        public bool HasMovementHistories => MovementHistories?.Any(t => (t.QtyToApply ?? 0) != 0) ?? false;
        public bool HasNewMovementHistories => MovementHistories?.Any(t => t.IsNewEntity) ?? false;

        public bool HasOrderItems => OrderItems?.Any(t => (t.QtyOrdered ?? 0) != 0) ?? false;
        public bool HasNewOrderItems => OrderItems?.Any(t => t.IsNewEntity) ?? false;

        public bool IsCustomerOrderType => OrderType == OrderType.CO;
        public bool IsPurchaseOrderType => OrderType == OrderType.PO;
        public bool IsReceivingReportType => OrderType == OrderType.RR;
        public bool IsStockAdjustType => OrderType == OrderType.SA;
        public bool IsStockTransferType => OrderType == OrderType.ST;

        public int OrderNumberInt
        {
            get
            {
                if (string.IsNullOrEmpty(OrderNumber)) return 0;

                return int.Parse(OrderNumber);
            }
        }

        public bool IsStatusOpen => Status == OrderStatus.Open;
        public bool IsStatusClose => Status == OrderStatus.Close;
        public bool IsStatusApproved => Status == OrderStatus.Approved;
        public bool IsStatusDelivery => Status == OrderStatus.Delivery;
        public bool IsStatusPacking => Status == OrderStatus.Packing;
        public bool IsStatusForPacking => Status == OrderStatus.ForPacking;
        public bool IsStatusPickListed => Status == OrderStatus.PickListed;
        public bool IsStatusNew => Status == OrderStatus.New;
        public bool IsStatusLinedUp => Status == OrderStatus.LinedUp;
        public bool IsStatusCancelled => Status == OrderStatus.Cancelled;
        public bool IsStatusReceived => Status == OrderStatus.Received;
        public bool IsStatusForApproval => Status == OrderStatus.ForApproval;
        public bool IsStatusSubmittedToWarehouse => Status == OrderStatus.SubmittedToWarehouse;

        public Order(int organizationId,
            int userId,
            OrderType orderType,
            string orderNumber,
            OrderStatus status,
            DateTime orderDate)
        {
            OrganizationID = organizationId;
            AuditUser(userId);
            OrderType = orderType;
            OrderNumber = orderNumber;
            Status = status;
            OrderDate = orderDate;
            if (OrderItems == null) OrderItems = new List<OrderItem>();
        }

        public string ViewName => IsCustomerOrderType ? View.CUSTOMER_ORDERS_VIEW :
            IsPurchaseOrderType ? View.PURCHASE_ORDERS_VIEW :
            IsReceivingReportType ? View.RECEIVING_VIEW :
            IsStockAdjustType ? View.STOCK_ADJUSTMENT_VIEW :
            IsStockTransferType ? View.STOCK_TRANSFER_VIEW : string.Empty;

        public string OrderTypeText => IsCustomerOrderType ? "Customer Order" :
            IsPurchaseOrderType ? "Purchase Order" :
            IsReceivingReportType ? "Receiving Report" :
            IsStockAdjustType ? "Stock Adjust" :
            IsStockTransferType ? "Stock Transfer" : string.Empty;

        public virtual PackingList PackingList { get; set; }
        public virtual Contact Agent { get; set; }
        public virtual Account Customer { get; set; }
        public virtual InventoryLocation InventoryLocation { get; set; }
        public string InventoryLocationName => InventoryLocation?.Name;
        public virtual string StatusDisplayText => Status == OrderStatus.Open ? OrderStatus.Open.ToString() :
            Status == OrderStatus.Close ? OrderStatus.Close.ToString() :
            Status == OrderStatus.Approved ? OrderStatus.Approved.ToString() :
            Status == OrderStatus.Delivery ? OrderStatus.Delivery.ToString() :
            Status == OrderStatus.Packing ? OrderStatus.Packing.ToString() :
            Status == OrderStatus.ForPacking ? "For Packing" :
            Status == OrderStatus.PickListed ? "Pick Listed" :
            Status == OrderStatus.New ? OrderStatus.New.ToString() :
            Status == OrderStatus.LinedUp ? "Lined Up" :
            Status == OrderStatus.Cancelled ? OrderStatus.Cancelled.ToString() :
            Status == OrderStatus.Received ? OrderStatus.Received.ToString() :
            Status == OrderStatus.ForApproval ? "For Approval" :
            Status == OrderStatus.SubmittedToWarehouse ? "Submitted To Warehouse" : OrderStatus.New.ToString();

        public string TotalQuantitiesText => string.Join(separator: ", ",
            OrderItems?
            .GroupBy(_ => _.UnitOfMeasure)
            .Select(_ => $"{_.Sum(t => t.QtyOrdered ?? 0)} {_.Key}")
            .ToArray());

        public int[] InventoryLocationIds => OrderItems?.GroupBy(t => t.ProductInventoryLocation?.RackShelfColumn?.InventoryLocationID ?? 0)?.Select(t => t.Key).ToArray() ?? Enumerable.Empty<int>().ToArray();

        public virtual ICollection<PickListOrder> PickListOrders { get; set; }
    }
}