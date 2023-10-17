using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Exceptions;
using WarehouseManagementSystem.Utilities.Extensions;

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
                    .Where(t => t.IsTransactionTypeIsFrom == movementHistory.IsTransactionTypeIsFrom)
                    .Where(t => t.IsTransactionTypeIsTo == movementHistory.IsTransactionTypeIsTo)
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
            .OrderBy(t => t.ProductCode)
            .ToList();

        public ICollection<MovementHistory> MovementHistoriesTo => MovementHistories?
            .Where(t => t.ProductInventoryLocation?.RackShelfColumn?.InventoryLocationID == StockTransferToInventoryLocationId)
            .OrderBy(t => t.ProductCode)
            .ToList();

        public List<IGrouping<int?, MovementHistory>> MovementHistoriesFromGroupByProductColorSize => MovementHistoriesFrom?
            .GroupBy(t => t.ProductColorSizeID)
            .ToList();

        public List<IGrouping<int?, MovementHistory>> MovementHistoriesToGroupByProductColorSize => MovementHistoriesTo?
            .GroupBy(t => t.ProductColorSizeID)
            .ToList();

        public bool HasMovementHistoryProductLikeThis(string searchText) => MovementHistories?
            .Where(t => t.ProductCode.Like(searchText))?
            .Any() ?? false;

        public void SetApproveStockTransfer()
        {
            Status = OrderStatus.Approved;
        }

        public void DeleteMovementHistoryByProductColorSizeId(int productColorSizeId)
        {
            if (IsApproved) throw new BusinessLogicException("Invalid Command. Stock Transfer already `Approved`.");

            var deleteItems = MovementHistories?.Where(t => t.ProductColorSizeID.Value == productColorSizeId).ToList();
            if (DeletedMovementHistories == null) DeletedMovementHistories = new List<MovementHistory>();
            DeletedMovementHistories = DeletedMovementHistories.Concat(deleteItems).ToList();

            var preserveItems = MovementHistories?.Where(t => t.ProductColorSizeID.Value != productColorSizeId).ToList();
            foreach (var deleteItem in deleteItems)
                MovementHistories?.Remove(deleteItem);

            AddMovementHistories(preserveItems);
        }

        [NotMapped]
        public ICollection<MovementHistory> DeletedMovementHistories { get; private set; }

        public List<int> DeletedMovementHistoryProductColorSizeIds => DeletedMovementHistories?.GroupBy(t => t.ProductColorSizeID.Value).Select(t => t.Key).ToList();
    }
}