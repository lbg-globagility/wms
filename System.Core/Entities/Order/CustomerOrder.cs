using System;
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
        }

        public string CustomerNameText => Customer?.CompanyName;

        public string AgentNameText => Agent?.FullNameLastNameFirst;
    }
}