using System;
using System.Linq;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    public partial class Order
    {
        public static Order NewStockAdjustmentOrder(int organizationId,
            int userId,
            string orderNumber,
            OrderStatus status,
            DateTime orderDate) => new Order(organizationId: organizationId,
                userId: userId,
                orderType: OrderType.SA,
                orderNumber: orderNumber,
                status: status,
                orderDate: orderDate);

        public int? StockAdjustmentFromInventoryLocationId =>
            MovementHistories != null ?
            MovementHistories.FirstOrDefault(t => t.IsTransactionTypeIsFrom)?.ProductInventoryLocation?.RackShelfColumn?.InventoryLocationID :
            null;

        public int? StockAdjustmentToInventoryLocationId =>
            MovementHistories != null ?
            MovementHistories.FirstOrDefault(t => t.IsTransactionTypeIsTo)?.ProductInventoryLocation?.RackShelfColumn?.InventoryLocationID :
            null;
    }
}