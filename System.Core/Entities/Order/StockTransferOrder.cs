using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    public partial class Order
    {
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

        public bool HasMovementHistoryProductLikeThis(string searchText) => MovementHistories?
            .Where(t => t.ProductCode.Contains(searchText))?
            .Any() ?? false;

        public void ApproveStockTransfer()
        {
            Status = OrderStatus.Approved;
        }
    }
}