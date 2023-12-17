using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Utilities.Extensions;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("productmovementhistory")]
    public partial class MovementHistory : AuditableEntity
    {
        public int? OrderID { get; set; }
        public int? LineUpID { get; set; }
        public int? PickListID { get; set; }

        [ForeignKey("ProductColorSize")]
        public int? ProductColorSizeID { get; set; }

        [ForeignKey("ProductInventoryLocation")]
        public int? ProductInventoryLocationIDA { get; set; }

        public int? ProductInventoryLocationIDB { get; set; }
        public int? CurrentQty { get; set; }
        public int? QtyToApply { get; set; }
        public int? NewQty { get; private set; }
        public string TransactionType { get; set; }
        public string ColumnName { get; set; }
        public string Comments { get; set; }

        public void SetProductInventoryLocation(ProductInventoryLocation productInventoryLocation)
        {
            ProductInventoryLocation = productInventoryLocation;
        }
    }

    public partial class MovementHistory
    {
        public virtual Order Order { get; set; }
        public virtual ProductColorSize ProductColorSize { get; set; }
        public virtual ProductInventoryLocation ProductInventoryLocation { get; set; }
        public string ProductCode => ProductInventoryLocation?.ProductColorSize?.ProductColor?.Product?.ProductCode;
        public string UnitOfMeasure => new string[] { ProductInventoryLocation?.UnitOfMeasure2, ProductColorSize?.UnitOfMeasure2 }.Where(t => !string.IsNullOrEmpty(t)).FirstOrDefault();

        private MovementHistory()
        {
        }

        public MovementHistory(int organizationId,
            int userId,
            int productColorSizeID,
            int? orderId,
            int productInventoryLocationId,
            int currentQty,
            int qtyToApply,
            string transactionType,
            string columnName = "TotalAvailableQty")
        {
            OrganizationID = organizationId;
            AuditUser(userId);
            ProductColorSizeID = productColorSizeID;
            OrderID = orderId;
            ProductInventoryLocationIDA = productInventoryLocationId;
            CurrentQty = currentQty;
            QtyToApply = qtyToApply;
            TransactionType = transactionType;
            ColumnName = columnName;

            RecomputeNewQty();
        }

        public static MovementHistory NewMovementHistory(int organizationId,
            int userId,
            int productColorSizeID,
            int? orderId,
            int productInventoryLocationId,
            int currentQty,
            int qtyToApply,
            string transactionType,
            string columnName = "TotalAvailableQty") => new MovementHistory(organizationId: organizationId,
                userId: userId,
                productColorSizeID: productColorSizeID,
                orderId: orderId,
                productInventoryLocationId: productInventoryLocationId,
                currentQty: currentQty,
                qtyToApply: qtyToApply,
                transactionType: transactionType,
                columnName: columnName);

        public bool IsTransactionTypeIsFrom => TransactionType?.Contains("From") ?? false;
        public bool IsTransactionTypeIsTo => TransactionType?.Contains("To") ?? false;

        public void RecomputeNewQty()
        {
            NewQty = CurrentQty + FormulatedQtyToApply;
        }

        public int FormulatedQtyToApply => (QtyToApply * (IsTransactionTypeIsFrom ? -1 : IsTransactionTypeIsTo ? 1 : 1)) ?? 0;
    }
}