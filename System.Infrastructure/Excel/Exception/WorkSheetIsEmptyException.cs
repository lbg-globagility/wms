using WarehouseManagementSystem.Core.Exceptions;

namespace WarehouseManagementSystem.Infrastructure.Excel.Exception
{
    public class WorkSheetIsEmptyException : ExcelException
    {
        public WorkSheetIsEmptyException(string message = "WorkSheet is empty.") : base(message)
        {
        }
    }
}