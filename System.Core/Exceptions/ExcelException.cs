using System;

namespace WarehouseManagementSystem.Core.Exceptions
{
    public class ExcelException : Exception
    {
        public ExcelException(string message) : base(message)
        {
        }
    }
}