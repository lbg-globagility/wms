using System;

namespace WarehouseManagementSystem.Utilities.Attributes
{
    public class ColumnNameAttribute : Attribute
    {
        public string Value { get; set; }

        public ColumnNameAttribute(string value) => Value = value;
    }
}