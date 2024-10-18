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

        RowID = orderItem.RowID
        ProductColorSizeId = orderItem.ProductColorSizeID
        ProductInventoryLocationId = orderItem.ProductInventoryLocationId

        Dim wname = orderItem?.ProductInventoryLocation?.RackShelfColumn?.InventoryLocation?.NameAlternative
        _WarehouseName = If(String.IsNullOrEmpty(wname), orderItem?.WarehouseName, wname)
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

        RowID = orderItem.RowID
        ProductColorSizeId = orderItem.ProductColorSizeID
        ProductInventoryLocationId = orderItem.ProductInventoryLocationId

        Dim wname = orderItem?.ProductInventoryLocation?.RackShelfColumn?.InventoryLocation?.NameAlternative
        _WarehouseName = If(String.IsNullOrEmpty(wname), orderItem?.WarehouseName, wname)
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
    Public ReadOnly Property WarehouseName As String

    Private _UnitOfLengthPrice As Decimal

    Public ReadOnly Property UnitOfLengthPrice As Decimal
        Get
            If IsNonData Then Return _UnitOfLengthPrice

            Return If(QuantityOrdered > 0 AndAlso If(UnitOfLengthNumber.HasValue, UnitOfLengthNumber.Value, 0D) > 0,
                TotalItemPrice / UnitOfLengthNumber.Value,
                0D)
        End Get
    End Property

    Private _TotalItemPrice As Decimal

    Public ReadOnly Property TotalItemPrice As Decimal
        Get
            Return If(IsNonData, _TotalItemPrice, UnitPrice * QuantityOrdered)
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
        If IsNonData Then Return

        _orderItem.SetDelete()
        _IsDelete = _orderItem.IsDelete
    End Sub

    Private Sub New()

    End Sub

    Public Property IsNonData As Boolean

    Public Shared Function EmulatedGrandTotals(unitPrice As Decimal,
        unitOfLengthNumber As Decimal,
        unitOfLengthPrice As Decimal,
        totalItemPrice As Decimal,
        quantityOrdered As Integer) As OrderItemModel

        Return New OrderItemModel() With {
            .UnitPrice = unitPrice,
            .UnitOfLengthNumber = unitOfLengthNumber,
            ._UnitOfLengthPrice = unitOfLengthPrice,
            ._TotalItemPrice = totalItemPrice,
            .QuantityOrdered = quantityOrdered,
            .IsNonData = True
        }
    End Function

    Public Sub RefreshGrandTotals(unitPrice As Decimal,
        unitOfLengthNumber As Decimal,
        unitOfLengthPrice As Decimal,
        totalItemPrice As Decimal,
        quantityOrdered As Integer)

        If Not IsNonData Then Return

        _UnitPrice = unitPrice
        _UnitOfLengthNumber = unitOfLengthNumber
        _UnitOfLengthPrice = unitOfLengthPrice
        _TotalItemPrice = totalItemPrice
        _QuantityOrdered = quantityOrdered
    End Sub

End Class