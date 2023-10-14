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
        public virtual ICollection<MovementHistory> MovementHistories { get; set; }

        public bool IsCustomerOrderType => OrderType == OrderType.CO;
        public bool IsPurchaseOrderType => OrderType == OrderType.PO;
        public bool IsReceivingReportType => OrderType == OrderType.RR;
        public bool IsStockAdjustType => OrderType == OrderType.SA;
        public bool IsStockTransferType => OrderType == OrderType.ST;
        public int OrderNumberInt => int.Parse(OrderNumber);

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

        public void AddMovementHistories(List<MovementHistory> movementHistories)
        {
            if (MovementHistories == null) MovementHistories = new List<MovementHistory>();

            foreach (var movementHistory in movementHistories)
            {
                var productColorSizeId = movementHistory.ProductColorSizeID;
                var productInventoryLocationId = movementHistory.ProductInventoryLocationIDA;
                var existingMovementHistory = MovementHistories
                    .Where(t => t.ProductColorSizeID == productColorSizeId)
                    .Where(t => t.ProductInventoryLocationIDA == productInventoryLocationId)
                    .FirstOrDefault();
                if (existingMovementHistory == null) MovementHistories.Add(movementHistory);
                else
                {
                    existingMovementHistory.QtyToApply = movementHistory.QtyToApply;
                    existingMovementHistory.RecomputeNewQty();
                }
            }
        }

        public int? StockTransferFromInventoryLocationId =>
            MovementHistories != null ?
            MovementHistories.FirstOrDefault(t => t.IsTransactionTypeIsFrom)?.ProductInventoryLocation?.RackShelfColumn?.InventoryLocationID :
            null;

        public int? StockTransferToInventoryLocationId =>
            MovementHistories != null ?
            MovementHistories.FirstOrDefault(t => t.IsTransactionTypeIsTo)?.ProductInventoryLocation?.RackShelfColumn?.InventoryLocationID :
            null;

        public ICollection<MovementHistory> MovementHistoriesFrom => MovementHistories?
            .Where(t => t.ProductInventoryLocation?.RackShelfColumn?.InventoryLocationID == StockTransferFromInventoryLocationId)
            .ToList();

        public ICollection<MovementHistory> MovementHistoriesTo => MovementHistories?
            .Where(t => t.ProductInventoryLocation?.RackShelfColumn?.InventoryLocationID == StockTransferToInventoryLocationId)
            .ToList();

        public List<IGrouping<int?, MovementHistory>> MovementHistoriesFromGroupByProductColorSize => MovementHistoriesFrom?
            .GroupBy(t => t.ProductColorSizeID)
            .ToList();

        public List<IGrouping<int?, MovementHistory>> MovementHistoriesToGroupByProductColorSize => MovementHistoriesTo?
            .GroupBy(t => t.ProductColorSizeID)
            .ToList();

        public void ApproveStockTransfer()
        {
            Status = OrderStatus.Approved;
        }
    }
}