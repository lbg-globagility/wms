Option Strict On

Imports WarehouseManagementSystem.Core.Entities

Public Class OrderItemModel
    Private ReadOnly _orderItem As OrderItem

    Public Sub New(orderItem As OrderItem)
        _orderItem = orderItem

        _ProductCode = orderItem.ProductColorSize?.ProductColor.Product.ProductCode
        _ColorName = orderItem.ProductColorSize?.ProductColor.Color.ColorName
        _Size = If(orderItem.ProductColorSize?.Size, 0)
        _SeasonCode = orderItem.ProductColorSize?.SeasonCode
        _QuantityOrdered = If(orderItem.QtyOrdered, 0)
        _UnitPrice = If(orderItem.SRP, 0)
        _UnitOfMeasure = orderItem.UnitOfMeasure
        _Sku = orderItem.SKU
        _Sku2 = orderItem.SKU2
        _IsNew = orderItem.IsNewEntity

        RowID = orderItem.RowID
        ProductColorSizeId = orderItem.ProductColorSizeID
        ProductInventoryLocationId = orderItem.ProductInventoryLocationId
    End Sub

    Public ReadOnly Property OrderItem As OrderItem
        Get
            Return _orderItem
        End Get
    End Property

    Public ReadOnly Property RowID As Integer?
    Public ReadOnly Property ProductColorSizeId As Integer?
    Public ReadOnly Property ProductInventoryLocationId As Integer?
    Public ReadOnly Property ProductCode As String
    Public ReadOnly Property ColorName As String
    Public ReadOnly Property Size As Decimal
    Public ReadOnly Property SeasonCode As String
    Public Property QuantityOrdered As Integer
    Public Property UnitPrice As Decimal
    Public Property UnitOfMeasure As String
    Public Property Sku As String
    Public Property Sku2 As String
    Public ReadOnly Property IsNew As Boolean
    Public ReadOnly Property IsDelete As Boolean
    Public ReadOnly Property TotalItemPrice As Decimal
        Get
            Return UnitPrice * QuantityOrdered
        End Get
    End Property
End Class