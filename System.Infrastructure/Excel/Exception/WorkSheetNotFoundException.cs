using WarehouseManagementSystem.Core.Exceptions;

namespace WarehouseManagementSystem.Infrastructure.Excel.Exception
{
    public class WorkSheetNotFoundException : ExcelException
    {
        public WorkSheetNotFoundException(string message) : base(message)
        {
        }
    }
}