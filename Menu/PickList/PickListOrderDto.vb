Imports WarehouseManagementSystem.Core.Entities

Public Class PickListOrderDto
    Public ReadOnly PickListOrder As PickListOrder

    Public Sub New(pickListOrder As PickListOrder)
        Me.PickListOrder = pickListOrder

        ProductCode = pickListOrder.ProductCode
        IsVerified = pickListOrder.IsVerifiedStatus
        Dim productColorSize = pickListOrder?.OrderItem?.ProductColorSize
        ColorName = productColorSize?.ProductColor?.ColorName
        [Size] = If(productColorSize?.Size, 0D)
        SeasonCode = productColorSize?.SeasonCode
        QtyPicked = If(pickListOrder?.PickListOrderItem?.QtyPicked, 0D)
        InventoryLocationName = pickListOrder?.OrderItem?.InventoryLocationName
        CustomerOrderNo = pickListOrder?.Order?.OrderNumber
        CustomerName = pickListOrder?.Order?.Customer?.CompanyName
    End Sub

    Public Property IsVerified As Boolean
    Public ReadOnly Property ProductCode As String
    Public ReadOnly Property ColorName As String
    Public ReadOnly Property [Size] As Decimal
    Public ReadOnly Property SeasonCode As String
    Public ReadOnly Property QtyPicked As Decimal
    Public ReadOnly Property InventoryLocationName As String
    Public ReadOnly Property CustomerOrderNo As String
    Public ReadOnly Property CustomerName As String

    Public ReadOnly Property IsEdited As Boolean
        Get
            Return Not PickListOrder.IsVerifiedStatus = IsVerified
        End Get
    End Property

End Class
