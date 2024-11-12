
Imports WarehouseManagementSystem.Core.Entities

Public Class GeneratePickListOrderDto
    Public ReadOnly Order As Order

    Public Sub New(order As Order)
        Me.Order = order

        No = order.OrderNumber
        PoNo = order.ReferenceNumber
        CustomerName = order.CustomerNameText
        AgentName = order.AgentNameText
        Info = If(order.HasOrderItems, $"{order.OrderItems.Count()} item(s)", "No item(s)")
    End Sub

    Public Property IsSelected As Boolean
    Public ReadOnly Property No As String
    Public ReadOnly Property PoNo As String
    Public ReadOnly Property CustomerName As String
    Public ReadOnly Property AgentName As String
    Public ReadOnly Property Info As String

End Class
