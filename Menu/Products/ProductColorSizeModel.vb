Option Strict On

Imports WarehouseManagementSystem.Core.Entities

Public Class ProductColorSizeModel

    'Private ReadOnly _productInventoryLocation As ProductInventoryLocation
    Private ReadOnly _productInventoryLocations As List(Of ProductInventoryLocation)

    Private ReadOnly _productColorSize As ProductColorSize
    Private ReadOnly _productColor As ProductColor
    Private ReadOnly _pim As ProductImageManager

    'productInventoryLocation As ProductInventoryLocation,
    Public Sub New(productInventoryLocations As List(Of ProductInventoryLocation),
        productColorSize As ProductColorSize,
        productImageConfigParser As ProductImageConfigParser)

        '_productInventoryLocation = productInventoryLocation
        _productInventoryLocations = productInventoryLocations
        _ProductInventoryLocation = productInventoryLocations.
            OrderBy(Function(t) t.RackShelfColumn.PickOrderNo).
            FirstOrDefault()
        _productColorSize = productColorSize
        _productColor = productColorSize.ProductColor

        _pim = New ProductImageManager(productImageConfigParser)

        UnitOfMeasure2 = productColorSize.UnitOfMeasure2
        UnitPriceOfUOM2 = productColorSize.UnitPriceOfUOM2
    End Sub

    Public Property IsSelected As Boolean

    Public ReadOnly Property ProductCode As String
        Get
            Return _productColor?.Product?.ProductCode
        End Get
    End Property

    Public ReadOnly Property BrandName As String
        Get
            Return _productColor?.Product?.BrandName
        End Get
    End Property

    Public ReadOnly Property Category As String
        Get
            Return _productColor?.Product?.Category.CategoryName
        End Get
    End Property

    Public ReadOnly Property SRP As String
        Get
            Return If(If(_ProductInventoryLocation?.UnitPrice, 0) = 0, _productColor?.Product?.UnitPrice.Value.ToString("N2"), _ProductInventoryLocation?.UnitPrice.Value.ToString("N2"))
        End Get
    End Property

    Public ReadOnly Property UnitPrice As Decimal
        Get
            Dim fsdfsd = If(If(_ProductInventoryLocation?.UnitPrice, 0) = 0, _productColor?.Product?.UnitPrice.Value, _ProductInventoryLocation?.UnitPrice.Value)
            Return If(fsdfsd, 0)
        End Get
    End Property

    Public ReadOnly Property UnitOfMeasure As String
        Get
            Return If(String.IsNullOrEmpty(_ProductInventoryLocation?.UnitOfMeasure2), _productColor?.Product?.UnitOfMeasure2, _ProductInventoryLocation?.UnitOfMeasure2)
        End Get
    End Property

    Public ReadOnly Property Sku As String
        Get
            Return _productColorSize?.SKU
        End Get
    End Property

    Public ReadOnly Property Sku2 As String
        Get
            Return _productColorSize?.SKU2
        End Get
    End Property

    Public ReadOnly Property Description As String
        Get
            Return _productColor?.Product?.Description
        End Get
    End Property

    Public ReadOnly Property Colors As String
        Get
            Return _productColor.Color.ColorName
        End Get
    End Property

    Public ReadOnly Property Style As String
        Get
            Return $"{_productColorSize.Size}"
        End Get
    End Property

    Public ReadOnly Property SeasonCode As String
        Get
            Return $"{_productColorSize.SeasonCode}"
        End Get
    End Property

    Public ReadOnly Property ProductColorSize As ProductColorSize
        Get
            Return _productColorSize
        End Get
    End Property

    Public ReadOnly Property ProductColorSizeId As Integer
        Get
            Return _productColorSize.RowID.Value
        End Get
    End Property

    Public ReadOnly Property ProductInventoryLocation As ProductInventoryLocation
    '    Get
    '        Return _productInventoryLocation
    '    End Get
    'End Property

    Public ReadOnly Property Photo As String
        Get
            Return _pim.GetPhotoUrl(productCode:=ProductCode)
        End Get
    End Property

    Public ReadOnly Property ProductInventoryLocations As List(Of ProductInventoryLocation)
        Get
            Return _productInventoryLocations
        End Get
    End Property

    Public ReadOnly Property HasMoreThanOneRackShelfColumn As Boolean
        Get
            Return If(_productInventoryLocations?.Count(), 0) > 1
        End Get
    End Property

    Public Sub ChangeSelectedProductInventoryLocation(rackShelfColumnId As Integer)
        If Not rackShelfColumnId > 0 Then Return

        Dim selectedProductInventoryLocation = _productInventoryLocations.
            Where(Function(t) t.ProductColorSizeID = _productColorSize.RowID.Value).
            FirstOrDefault(Function(t) t.RackShelfColumnID.Value = rackShelfColumnId)

        _ProductInventoryLocation = selectedProductInventoryLocation
    End Sub

    Public ReadOnly Property TotalAvailableQty As Integer
        Get
            Return If(_productInventoryLocations?.
                Where(Function(t) t.ProductColorSizeID = _productColorSize.RowID.Value)?.
                Sum(Function(t) If(t.TotalAvailableQty, 0)), 0)
        End Get
    End Property

    Public ReadOnly Property TotalAllocatedQty As Integer
        Get
            Return If(_productInventoryLocations?.
                Where(Function(t) t.ProductColorSizeID = _productColorSize.RowID.Value)?.
                Sum(Function(t) If(t.TotalAllocatedQty, 0)), 0)
        End Get
    End Property

    Public ReadOnly Property TotalReserveQty As Integer
        Get
            Return If(_productInventoryLocations?.
                Where(Function(t) t.ProductColorSizeID = _productColorSize.RowID.Value)?.
                Sum(Function(t) If(t.TotalReserveQty, 0)), 0)
        End Get
    End Property

    Public ReadOnly Property TotalDamageQty As Integer
        Get
            Return If(_productInventoryLocations?.
                Where(Function(t) t.ProductColorSizeID = _productColorSize.RowID.Value)?.
                Sum(Function(t) If(t.TotalDamageQty, 0)), 0)
        End Get
    End Property

    Public ReadOnly Property TotalSupplierProblemQty As Integer
        Get
            Return If(_productInventoryLocations?.
                Where(Function(t) t.ProductColorSizeID = _productColorSize.RowID.Value)?.
                Sum(Function(t) If(t.TotalSupplierProblemQty, 0)), 0)
        End Get
    End Property

    Public ReadOnly Property TotalInRepairQty As Integer
        Get
            Return If(_productInventoryLocations?.
                Where(Function(t) t.ProductColorSizeID = _productColorSize.RowID.Value)?.
                Sum(Function(t) If(t.TotalInRepairQty, 0)), 0)
        End Get
    End Property

    Public ReadOnly Property TotalToReceiveQty As Integer
        Get
            Return If(_productInventoryLocations?.
                Where(Function(t) t.ProductColorSizeID = _productColorSize.RowID.Value)?.
                Sum(Function(t) If(t.TotalToReceiveQty, 0)), 0)
        End Get
    End Property

    Public ReadOnly Property RunningTotalQty As Integer
        Get
            Return If(_productInventoryLocations?.
                Where(Function(t) t.ProductColorSizeID = _productColorSize.RowID.Value)?.
                Sum(Function(t) If(t.RunningTotalQty, 0)), 0)
        End Get
    End Property

    Public ReadOnly Property TotalOrderableQty As Integer
        Get
            Return If(_productInventoryLocations?.
                Where(Function(t) t.ProductColorSizeID = _productColorSize.RowID.Value)?.
                Sum(Function(t) t.TotalOrderableQty), 0)
        End Get
    End Property

    Public ReadOnly Property UnitOfMeasure2 As String
    Public ReadOnly Property UnitPriceOfUOM2 As Decimal?
End Class