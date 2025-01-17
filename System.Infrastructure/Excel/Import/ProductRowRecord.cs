using System.Linq;
using WarehouseManagementSystem.Core.Interfaces.Excel.Import;
using WarehouseManagementSystem.Utilities.Attributes;

namespace WarehouseManagementSystem.Infrastructure.Excel.Import
{
    public partial class ProductRowRecord : IProductRowRecord
    {
        [ColumnName("Product Code")]
        public string ProductCode { get; set; }

        [ColumnName("Product Group Name")]
        public string ProductGroupName { get; set; }

        [ColumnName("Brand Name")]
        public string BrandName { get; set; }

        [ColumnName("Category")]
        public string Category { get; set; }

        // Company

        [ColumnName("SRP")]
        public decimal SRP { get; set; }

        [ColumnName("Unit of Measure")]
        public string UnitOfMeasure { get; set; }

        [ColumnName("Description")]
        public string Description { get; set; }

        [ColumnName("Colors")]
        public string Colors { get; set; }

        [ColumnName("Style")]
        public string Style { get; set; }

        [ColumnName("Season Code")]
        public string SeasonCode { get; set; }

        [ColumnName("SKU")]
        public string SKU { get; set; }

        [ColumnName("SKU2")]
        public string SKU2 { get; set; }

        [Ignore]
        public int LineNumber { get; set; }
    }

    public partial class ProductRowRecord
    {
        private string _errorMessage;

        public bool HasProductCode => !string.IsNullOrEmpty(ProductCode);
        public bool HasCategory => !string.IsNullOrEmpty(Category);
        public bool HasColor => !string.IsNullOrEmpty(Colors);
        public bool HasStyle => !string.IsNullOrEmpty(Style);
        public bool HasSeasonCode => !string.IsNullOrEmpty(SeasonCode);
        public bool HasProductGroupName => !string.IsNullOrEmpty(ProductGroupName);

        public string ErrorMessage
        {
            get
            {
                string[] errorTexts = {
                    HasProductCode ? string.Empty : "Invalid Product Code",
                    HasCategory ? string.Empty : "Invalid Category",
                    HasColor ? string.Empty : "Invalid Color",
                    HasStyle ? string.Empty : "Invalid Style",
                    HasProductGroupName ? string.Empty : "Invalid ProductGroupName",
                    _errorMessage
                };
                var errorTexts2 = errorTexts.Where(t => !string.IsNullOrEmpty(t));

                if (errorTexts2.Any()) return string.Join("; ", errorTexts2);

                return string.Empty;
            }
        }

        public bool IsValid => string.IsNullOrEmpty(ErrorMessage);

        public int? ColorId { get; private set; }

        public void SetColorId(int colorId)
        {
            ColorId = colorId;
        }

        public int? CategoryId { get; private set; }

        public void SetCategoryId(int categoryId)
        {
            CategoryId = categoryId;
        }

        public void AppendErrorMessage(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
    }
}