using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    public partial class Order
    {
        public static Order NewCustomerOrder(int organizationId,
            int userId,
            string orderNumber,
            OrderStatus status,
            DateTime orderDate) => new Order(organizationId: organizationId,
                userId: userId,
                orderType: OrderType.CO,
                orderNumber: orderNumber,
                status: status,
                orderDate: orderDate);

        public void SetSubmittedToWarehouseCustomerOrder()
        {
            Status = OrderStatus.SubmittedToWarehouse;
            DateSubmitted = DateTime.Now;
        }

        public void SetCancelledCustomerOrder()
        {
            Status = OrderStatus.Cancelled;
            EndDate = DateTime.Now;
            SetEdited();
        }

        public string CustomerNameText => Customer?.CompanyName;

        public string AgentNameText => Agent?.FullNameLastNameFirst;

        public void AddCustomerOrderItems(List<OrderItem> orderItems)
        {
            if (OrderItems == null) OrderItems = new List<OrderItem>();

            foreach (var orderItem in orderItems)
            {
                var productColorSizeId = orderItem.ProductColorSizeID;
                var existingOrderItem = OrderItems
                    .Where(t => t.RowID == orderItem.RowID)
                    .Where(t => t.ProductColorSizeID == productColorSizeId)
                    .FirstOrDefault();
                if (existingOrderItem == null)
                    OrderItems.Add(orderItem);
                else
                {
                    existingOrderItem.QtyOrdered = orderItem.QtyOrdered;
                    existingOrderItem.SRP = orderItem.SRP;
                    existingOrderItem.UnitOfMeasure = orderItem.UnitOfMeasure;
                    existingOrderItem.SKU = orderItem.SKU;
                    existingOrderItem.SKU2 = orderItem.SKU2;
                    existingOrderItem.Remarks = orderItem.Remarks;
                }
            }
        }

        public void RecomputeTotalAmount()
        {
            var totalAmount = OrderItems?.Sum(t => t.OrderedGross) ?? 0M;
            TotalAmount = totalAmount;
        }

        public string CustomerOrderSearchableString
        {
            get
            {
                string[] texts = {Comments,
                    OrderNumber,
                    ReferenceNumber,
                    DRNumber,
                    CustomerName,
                    CustomerAddress,
                    DeliveryHours,
                    ReceivedBy,
                    ReceivedBrands,
                    ContainerNo,
                    SealNo,
                    ArrivedIn,
                    InventoryLocationName};
                return string.Join(Environment.NewLine, texts.Where(t => !string.IsNullOrEmpty(t)));
            }
        }
    }
}