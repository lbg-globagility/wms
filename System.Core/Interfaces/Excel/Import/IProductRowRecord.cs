namespace WarehouseManagementSystem.Core.Interfaces.Excel.Import
{
    public interface IProductRowRecord : IExcelRowRecord
    {
        string ProductCode { get; set; }

        string BrandName { get; set; }

        string Category { get; set; }

        // Company

        decimal SRP { get; set; }

        string UnitOfMeasure { get; set; }

        string Description { get; set; }

        string Colors { get; set; }

        string Style { get; set; }

        string SeasonCode { get; set; }

        string SKU { get; set; }

        string SKU2 { get; set; }

        string ErrorMessage { get; }

        bool IsValid { get; }
    }
}