using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Services.PickListAutomation;

namespace WarehouseManagementSystem.Core.Interfaces
{
    public interface IPickListAutomator
    {
        Task<PickListAutomationResult> Start(
            int pickListId,
            PickListOrder pickListOrder,
            Order order,
            OrderItem orderItem,
            PickListOrderItem pickListOrderItem,
            ProductInventoryLocation productInventoryLocation,
            int organizationId,
            int userId);
    }
}
