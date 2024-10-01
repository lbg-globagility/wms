Option Strict On

Imports System.Collections.Concurrent
Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Helpers
Imports WarehouseManagementSystem.Core.Helpers.ProgressGenerator
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Services.PickListAutomation
Imports PickListEntity = WarehouseManagementSystem.Core.Entities.PickList

Public Class PickListAutomation
    Inherits ProgressGenerator

    Private ReadOnly _pickLists As IEnumerable(Of PickListEntity)

    Private _results As BlockingCollection(Of PickListAutomationResult)

    Public Sub New(pickLists As IEnumerable(Of PickListEntity),
            Optional additionalProgressCount As Integer = 0)

        MyBase.New(total:=pickLists.Where(Function(e) e IsNot Nothing AndAlso e.RowID IsNot Nothing).Sum(Function(t) If(t.PickListOrders()?.Count(), 0)) + additionalProgressCount)

        _pickLists = pickLists

        _results = New BlockingCollection(Of PickListAutomationResult)()

    End Sub

    Public Async Function Start(orders As IEnumerable(Of Order),
        pickListOrderItems As IEnumerable(Of PickListOrderItem),
        productInventoryLocations As IEnumerable(Of ProductInventoryLocation)) As Task

        For Each pickList In _pickLists
            Dim orderItemId = 0

            For Each pickListOrder In pickList.PickListOrders

                Try
                    Dim pickListAutomator = MainServiceProvider.GetRequiredService(Of IPickListAutomator)

                    Dim order = orders.FirstOrDefault(Function(t) If(t.RowID, 0) = pickListOrder.OrderID)
                    Dim orderItem = order.OrderItems.FirstOrDefault(Function(t) If(t.RowID, 0) = pickListOrder.OrderItemID)
                    orderItemId = If(orderItem.RowID, 0)
                    Dim pickListOrderItem = pickListOrderItems.
                        FirstOrDefault(Function(t) t.PickListOrderID = If(pickListOrder.RowID, 0))

                    Dim productInventoryLocationQuery = productInventoryLocations.
                        Where(Function(t) t.RackShelfColumn.IsActive).
                        Where(Function(t) t.RackShelfColumn.InventoryLocationID = If(order.InventoryLocationID, 0)).
                        Where(Function(t) t.ProductColorSizeID = If(orderItem.ProductColorSizeID, 0)).
                        OrderBy(Function(t) t.RackShelfColumn.PickOrderNo)

                    If If(productInventoryLocationQuery?.Count(), 0) > 1 Then

                        _results.Add(PickListAutomationResult.Error(Nothing, message:="Has multiple `rack-shelf-column`, the picking should be done by the user."))

                        SetCurrentMessage($"Skipped automate-picking for PickListId: {pickList.RowID}, PickListOrderId: {If(pickListOrder.RowID, 0)}, OrderItemId: {orderItemId}.")

                    Else

                        Dim productInventoryLocation = productInventoryLocationQuery.FirstOrDefault()

                        Dim result = Await pickListAutomator.Start(
                            pickListId:=If(pickList.RowID, 0),
                            pickListOrder:=pickListOrder,
                            order:=order,
                            orderItem:=orderItem,
                            pickListOrderItem:=pickListOrderItem,
                            productInventoryLocation:=productInventoryLocation,
                            organizationId:=Z_OrganizationID,
                            userId:=Z_UserID)

                        _results.Add(result)

                        If result.IsSuccess Then
                            SetCurrentMessage($"Finished automate-picking for PickListId: {pickList.RowID}, PickListOrderId: {If(pickListOrder.RowID, 0)}, OrderItemId: {orderItemId}.")
                        Else
                            SetCurrentMessage($"Failure automate-picking for PickListId: {pickList.RowID}, PickListOrderId: {If(pickListOrder.RowID, 0)}, OrderItemId: {orderItemId}.")
                        End If

                    End If

                Catch ex As Exception

                    Dim text = $"Failure automate-picking for PickListId: {pickList.RowID}, PickListOrderId: {If(pickListOrder.RowID, 0)}, OrderItemId: {orderItemId}."

                    SetCurrentMessage(text)

                    _results.Add(PickListAutomationResult.Error(message:=$"{text} Error: {ex.Message}."))

                Finally

                    IncreaseProgress()

                End Try
            Next
        Next

        SetResults(_results.ToList())

    End Function

End Class
