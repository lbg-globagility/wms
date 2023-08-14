using WarehouseManagementSystem.Core.Exceptions;

namespace WarehouseManagementSystem.Infrastructure.Excel.Exception
{
    public class InvalidFormatException : ExcelException
    {
        public InvalidFormatException(string message = "Only .xlsx files are supported.") : base(message)
        {
        }
    }
}