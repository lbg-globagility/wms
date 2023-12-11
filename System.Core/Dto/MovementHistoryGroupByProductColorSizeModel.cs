using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Core.Dto
{
    public class MovementHistoryGroupByProductColorSizeModel
    {
        private readonly int? _productColorSizeId;
        private List<MovementHistory> _movementHistories;

        private MovementHistoryGroupByProductColorSizeModel()
        {
        }

        public MovementHistoryGroupByProductColorSizeModel(IGrouping<int?, MovementHistory> group)
        {
            _productColorSizeId = group.Key;
            _movementHistories = group.ToList();
        }

        public MovementHistoryGroupByProductColorSizeModel(int? productColorSizeId,
            List<MovementHistory> movementHistories)
        {
            _productColorSizeId = productColorSizeId;
            _movementHistories = movementHistories;
        }

        public int ProductColorSizeId => _productColorSizeId.Value;

        public List<MovementHistory> MovementHistories => _movementHistories;

        public ProductColorSize ProductColorSize => MovementHistories.FirstOrDefault().ProductColorSize;

        public bool IsTransactionTypeIsFrom => MovementHistories.FirstOrDefault()?.IsTransactionTypeIsFrom ?? false;

        public bool IsTransactionTypeIsTo => MovementHistories.FirstOrDefault()?.IsTransactionTypeIsTo ?? false;

        public ProductInventoryLocation ProductInventoryLocation => MovementHistories.FirstOrDefault().ProductInventoryLocation;

        public string ProductCode => MovementHistories.FirstOrDefault(t => !string.IsNullOrEmpty(t.ProductCode))?.ProductCode;

        public int QtyToApply => MovementHistories.Sum(t => t.QtyToApply.Value);

        public string UnitOfMeasure => MovementHistories.FirstOrDefault().UnitOfMeasure;

        public void AddMovementHistories(MovementHistory movementHistory)
        {
            _movementHistories.Add(movementHistory);
        }

        public int? StockTransferFromInventoryLocationId =>
            MovementHistories != null ?
            MovementHistories?.FirstOrDefault(t => t.IsTransactionTypeIsFrom)?.ProductInventoryLocation.RackShelfColumn.InventoryLocationID :
            null;

        public int? StockTransferToInventoryLocationId =>
            MovementHistories != null ?
            MovementHistories?.FirstOrDefault(t => t.IsTransactionTypeIsTo)?.ProductInventoryLocation.RackShelfColumn.InventoryLocationID :
            null;

        public static List<MovementHistoryGroupByProductColorSizeModel> EmptyDataSource() => Enumerable.Empty<MovementHistoryGroupByProductColorSizeModel>().ToList();
    }
}