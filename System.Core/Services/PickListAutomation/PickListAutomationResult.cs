using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces;

namespace WarehouseManagementSystem.Core.Services.PickListAutomation
{
    public class PickListAutomationResult : IPickListAutomationResult
    {
        private readonly PickListOrderItem _pickListOrderItem;

        public string No => string.Empty;

        public string Name => string.Empty;

        public int Id => new int();

        public string Description { get; set; }

        public ResultStatus Status { get; set; }

        public bool IsSuccess => Status == ResultStatus.Success;

        public bool IsError => Status == ResultStatus.Error;

        public PickListAutomationResult(PickListOrderItem pickListOrderItem, string message)
        {
            _pickListOrderItem = pickListOrderItem;
            Description = message;
        }

        public PickListAutomationResult(string message)
        {
            Description = message;
        }

        public static PickListAutomationResult Success(string message = "") => new PickListAutomationResult(message);

        public static PickListAutomationResult Success(PickListOrderItem pickListOrderItem, string message = "") => new PickListAutomationResult(pickListOrderItem, message: message);

        public static PickListAutomationResult Error(string message = "") => new PickListAutomationResult(message);

        public static PickListAutomationResult Error(PickListOrderItem pickListOrderItem, string message = "") => new PickListAutomationResult(pickListOrderItem: pickListOrderItem, message: message);

        public PickListOrderItem PickListOrderItem => _pickListOrderItem;

    }
}
