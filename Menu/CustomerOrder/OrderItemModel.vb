Option Strict On

Imports WarehouseManagementSystem.Core.Entities

Public Class OrderItemModel
    Private ReadOnly _orderItem As OrderItem

    Public Sub New(orderItem As OrderItem)
        _orderItem = orderItem

        Dim productColorSize = orderItem.ProductColorSize

        _ProductCode = productColorSize?.ProductColor.Product.ProductCode
        _ColorName = productColorSize?.ProductColor.Color.ColorName
        _Size = If(productColorSize?.Size, 0)
        _SeasonCode = productColorSize?.SeasonCode
        _QuantityOrdered = If(orderItem.QtyOrdered, 0)
        _UnitPrice = If(orderItem.SRP, 0)
        _UnitOfMeasure = orderItem.UnitOfMeasure
        _Sku = orderItem.SKU
        _Sku2 = orderItem.SKU2
        _Remarks = orderItem.Remarks
        _IsNew = orderItem.IsNewEntity
        _UnitOfLength = orderItem.UnitOfLength
        _UnitOfLengthNumber = orderItem.UnitOfLengthNumber
        _UnitOfLengthPrice = orderItem.UnitOfLengthPrice

        RowID = orderItem.RowID
        ProductColorSizeId = orderItem.ProductColorSizeID
        ProductInventoryLocationId = orderItem.ProductInventoryLocationId
    End Sub

    Public Sub New(orderItem As OrderItem, productInventoryLocation As ProductInventoryLocation)
        _orderItem = orderItem

        Dim productColorSize = If(orderItem.ProductColorSize Is Nothing, productInventoryLocation.ProductColorSize, orderItem.ProductColorSize)

        _ProductCode = productColorSize?.ProductColor.Product.ProductCode
        _ColorName = productColorSize?.ProductColor.Color.ColorName
        _Size = If(productColorSize?.Size, 0)
        _SeasonCode = productColorSize?.SeasonCode
        _QuantityOrdered = If(orderItem.QtyOrdered, 0)
        _UnitPrice = If(orderItem.SRP, 0)
        _UnitOfMeasure = If(String.IsNullOrEmpty(orderItem.UnitOfMeasure), productInventoryLocation.UnitOfMeasure2, orderItem.UnitOfMeasure)
        _Sku = orderItem.SKU
        _Sku2 = orderItem.SKU2
        _Remarks = orderItem.Remarks
        _IsNew = orderItem.IsNewEntity
        _UnitOfLength = orderItem.UnitOfLength
        _UnitOfLengthNumber = orderItem.UnitOfLengthNumber
        _UnitOfLengthPrice = orderItem.UnitOfLengthPrice

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
    Public ReadOnly Property UnitOfMeasure As String
    Public Property Sku As String
    Public Property Sku2 As String
    Public Property Remarks As String
    Public ReadOnly Property IsNew As Boolean
    Public ReadOnly Property IsDelete As Boolean
    Public Property UnitOfLength As String
    Public Property UnitOfLengthNumber As Decimal?
    Public ReadOnly Property UnitOfLengthPrice As Decimal

    Public ReadOnly Property TotalItemPrice As Decimal
        Get
            Return UnitPrice * QuantityOrdered
        End Get
    End Property

    Public ReadOnly Property UnitOfLengthPriceText As String
        Get
            Dim pricePerUnitOfLength = $"{UnitOfLengthPrice:N2}/{UnitOfLength}".ToLower()
            Return If(pricePerUnitOfLength = "0.00/", String.Empty, pricePerUnitOfLength)
        End Get
    End Property

    Public Sub Refresh(orderItemModel As OrderItemModel)
        _orderItem.QtyOrdered = orderItemModel.QuantityOrdered
        _orderItem.SRP = orderItemModel.UnitPrice
        _orderItem.UnitOfMeasure = orderItemModel.UnitOfMeasure
        _orderItem.SKU = orderItemModel.Sku
        _orderItem.SKU2 = orderItemModel.Sku2
        _orderItem.Remarks = orderItemModel.Remarks
        _orderItem.UnitOfLength = orderItemModel.UnitOfLength
        _orderItem.UnitOfLengthNumber = orderItemModel.UnitOfLengthNumber
    End Sub

    Public Sub SetDelete()
        _orderItem.SetDelete()
        _IsDelete = _orderItem.IsDelete
    End Sub
End Class