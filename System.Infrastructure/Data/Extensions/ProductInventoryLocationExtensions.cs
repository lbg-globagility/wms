using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.Core.Entities;

namespace WarehouseManagementSystem.Infrastructure.Data.Extensions
{
    public static class ProductInventoryLocationExtensions
    {
        public static T BestOrDefault<T>(this IList<T> list,
            int inventoryLocationId,
            int productColorSizeId) where T : ProductInventoryLocation
        {
            return list?
                .WhereActiveClause()?
                .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)?
                .Where(t => t.ProductColorSizeID == productColorSizeId)?
                .Where(t => t.IsOrderable)?
                .OrderBy(t => t.RackShelfColumn.PickOrderNo)?
                .FirstOrDefault() ??
                list?
                .WhereActiveClause()?
                .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)?
                .Where(t => t.ProductColorSizeID == productColorSizeId)?
                .OrderBy(t => t.RackShelfColumn.PickOrderNo)?
                .FirstOrDefault();
        }

        public static IOrderedEnumerable<T> BestFetchClause<T>(this IEnumerable<T> list,
            int inventoryLocationId,
            int productColorSizeId) where T : ProductInventoryLocation
        {
            return list?
                .WhereActiveClause()?
                .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)?
                .Where(t => t.ProductColorSizeID == productColorSizeId)?
                .Where(t => t.IsOrderable)?
                .OrderBy(t => t.RackShelfColumn.PickOrderNo) ??
                list?
                .WhereActiveClause()?
                .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)?
                .Where(t => t.ProductColorSizeID == productColorSizeId)?
                .OrderBy(t => t.RackShelfColumn.PickOrderNo);
        }

        public static IOrderedEnumerable<T> BestFetchClause<T>(this IEnumerable<T> list,
            int productInventoryLocationId,
            int inventoryLocationId,
            int productColorSizeId) where T : ProductInventoryLocation
        {
            return list?
                .Where(t => t.RowID == productInventoryLocationId)?
                .WhereActiveClause()?
                .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)?
                .Where(t => t.ProductColorSizeID == productColorSizeId)?
                .Where(t => t.IsOrderable)?
                .OrderBy(t => t.RackShelfColumn.PickOrderNo) ??
                list?
                .Where(t => t.RowID == productInventoryLocationId)?
                .WhereActiveClause()?
                .Where(t => t.RackShelfColumn.InventoryLocationID == inventoryLocationId)?
                .Where(t => t.ProductColorSizeID == productColorSizeId)?
                .OrderBy(t => t.RackShelfColumn.PickOrderNo);
        }

        public static IEnumerable<T> WhereActiveClause<T>(this IEnumerable<T> list) where T : ProductInventoryLocation =>
            list?.Where(t => t.RackShelfColumn?.IsActive ?? false);

        public static IEnumerable<T> WhereActiveClause<T>(this IList<T> list) where T : ProductInventoryLocation =>
            list?.Where(t => t.RackShelfColumn?.IsActive ?? false);
    }
}
