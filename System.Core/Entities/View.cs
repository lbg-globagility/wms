using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("views")]
    public partial class View
    {
        public int RowID { get; set; }
        public int? OrganizationID { get; set; }
        public string ViewName { get; set; }
    }

    public partial class View
    {
        private View()
        {
        }

        public virtual ICollection<PositionView> PositionViews { get; set; }

        public const string ACCOUNTS_VIEW = "Accounts";
        public const string ADDITIONAL_A_VIEW = "Additional A";
        public const string ADDITIONAL_B_VIEW = "Additional B";
        public const string ADDITIONAL_C_VIEW = "Additional C";
        public const string AGING_VIEW = "Aging";
        public const string APPROVE_RECEIVING_VIEW = "Approve Receiving";
        public const string APPROVE_STOCK_ADJUSTMENT_VIEW = "Approve Stock Adjustment";
        public const string BROKEN_SIZES_VIEW = "Broken Sizes";
        public const string BUNDLES_VIEW = "Bundles";
        public const string CONTACTS_VIEW = "Contacts";
        public const string CUSTOMER_ORDERS_VIEW = "Customer Orders";
        public const string CYCLE_COUNT_VIEW = "Cycle Count";
        public const string DELIVERY_PERFORMANCE_VIEW = "Delivery Performance";
        public const string INVENTORY_LOCATIONS_VIEW = "Inventory Locations";
        public const string LINE_UP_AND_DELIVERY_VIEW = "Line-Up And Delivery";
        public const string MOVE_FROM_PICKING_TO_PACKING_VIEW = "Move From Picking To Packing";
        public const string ORGANIZATIONS_VIEW = "Organizations";
        public const string PACKING_LIST_VIEW = "Packing List";
        public const string PICK_LIST_VIEW = "Pick List";
        public const string PICK_LIST_REPORT_VIEW = "Pick List Report";
        public const string POSITIONS_AND_VIEWS_VIEW = "Positions And Views";
        public const string PRODUCTS_VIEW = "Products";
        public const string PULL_OUT_VIEW = "Pull-Out";
        public const string PURCHASE_ORDERS_VIEW = "Purchase Orders";
        public const string RECEIVING_VIEW = "Receiving";
        public const string REFERENCES_VIEW = "References";
        public const string RETURNS_VIEW = "Returns";
        public const string SALES_AND_QTY_VIEW = "Sales And Qty";
        public const string SELL_THROUGH_VIEW = "Sell-Through";
        public const string STOCK_ADJUSTMENT_VIEW = "Stock Adjustment";
        public const string STOCK_LEVEL_VIEW = "Stock Level";
        public const string STOCK_TRANSFER_VIEW = "Stock Transfer";
        public const string STOCKING_TO_RACK_SHELF_COLUMN_VIEW = "Stocking To Rack/Shelf/Column";
        public const string SUPPLIERS_VIEW = "Suppliers";
        public const string USERS_VIEW = "Users";
    }
}