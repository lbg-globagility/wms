Imports WarehouseManagementSystem.Core.Entities

Public Class OrderItemModel
    Private ReadOnly _orderItem As OrderItem

    Public Sub New(orderItem As OrderItem)
        _orderItem = orderItem

    End Sub

    Public ReadOnly Property OrderItem As OrderItem
        Get
            Return _orderItem
        End Get
    End Property

End Class
