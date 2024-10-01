using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Core.Services.PickListAutomation;
using WarehouseManagementSystem.Infrastructure.Data.Services;

namespace WarehouseManagementSystem.Infrastructure.Data
{
    public class PickListAutomator : IPickListAutomator
    {
        private readonly IPickListOrderItemDataService _pickListOrderItemDataService;
        private readonly IPickListOrderDataService _pickListOrderDataService;

        public PickListAutomator(IPickListOrderItemDataService pickListOrderItemDataService,
            IPickListOrderDataService pickListOrderDataService) {
            _pickListOrderItemDataService = pickListOrderItemDataService;
            _pickListOrderDataService = pickListOrderDataService;
        }

        public async Task<PickListAutomationResult> Start(
            int pickListId,
            PickListOrder pickListOrder,
            Order order,
            OrderItem orderItem,
            PickListOrderItem pickListOrderItem,
            ProductInventoryLocation productInventoryLocation,
            int organizationId,
            int userId)
        {
            var productInventoryLocationId = productInventoryLocation.RowID ?? 0;
            var qtyAvailable = productInventoryLocation.TotalAvailableQty ?? 0;

            Console.WriteLine(string.Join("—", userId,
                pickListOrder.RowID,
                productInventoryLocationId,
                orderItem.QtyOrdered,
                0,
                0,
                qtyAvailable,
                "N",
                string.Empty));

            if (pickListOrderItem == null)
            {
                var newPickListOrderItem = PickListOrderItem.NewPickListOrderItem(organizationId: organizationId,
                    userId: userId,
                    pickListOrderId: pickListOrder.RowID ?? 0,
                    productInventoryLocationId: productInventoryLocationId,
                    qtyPicked: orderItem.QtyOrdered,
                    qtyDelivered: 0,
                    qtyReserve: 0,
                    qtyAvailable: qtyAvailable,
                    issueFlg: "N",
                    remarks: string.Empty);

                await _pickListOrderItemDataService.SaveManyAsync(
                    added: new List<PickListOrderItem>() { newPickListOrderItem },
                    userId: userId
                    );

                pickListOrder.Status = PickListOrderStatus.Modified;
                pickListOrder.SetEdited();

                await _pickListOrderDataService.SaveManyAsync(updated: new List<PickListOrder>() { pickListOrder },
                    userId: userId);

                return PickListAutomationResult.Success(newPickListOrderItem);
            }

            pickListOrderItem.QtyPicked = orderItem.QtyOrdered;
            pickListOrderItem.ProductInventoryLocationID = productInventoryLocationId;
            pickListOrderItem.QtyAvailable = qtyAvailable;
            pickListOrderItem.SetEdited();

            await _pickListOrderItemDataService.SaveManyAsync(
                updated: new List<PickListOrderItem>() { pickListOrderItem },
                userId: userId
                );

            pickListOrder.Status = PickListOrderStatus.Modified;
            pickListOrder.SetEdited();

            await _pickListOrderDataService.SaveManyAsync(updated: new List<PickListOrder>() { pickListOrder },
                userId: userId);

            return PickListAutomationResult.Success(pickListOrderItem);
        }
    }
}
