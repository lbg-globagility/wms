Option Strict On

Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Utilities.Extensions

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
        _productInventoryLocations = productInventoryLocations.
            Where(Function(pil) pil.RackShelfColumn.Status = RackShelfColumnStatus.Active).
            ToList()
        _ProductInventoryLocation = productInventoryLocations.
            OrderBy(Function(t) t.RackShelfColumn.PickOrderNo).
            FirstOrDefault()
        _productColorSize = productColorSize
        _productColor = productColorSize.ProductColor

        _pim = New ProductImageManager(productImageConfigParser)

        UnitOfMeasure2 = If(String.IsNullOrEmpty(_ProductInventoryLocation?.UnitOfMeasure2), productColorSize.UnitOfMeasure2, _ProductInventoryLocation.UnitOfMeasure2)
        UnitPriceOfUOM2 = If(_ProductInventoryLocation?.UnitPriceOfUOM2, productColorSize.UnitPriceOfUOM2)
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

    Public Function AdvanceSearch(searchText As String) As Boolean
        Dim splitted = Split(searchText, ",")
        If splitted.Count() = 1 AndAlso Not searchText.Contains(":") Then
            Return ProductCode.SimilarTo(searchText)
        End If

        Dim conditions = New List(Of Boolean)()

        For Each query In splitted
            Dim tup = Split(query, ":")
            Dim attrib = tup.FirstOrDefault()?.Trim()
            Dim param = tup.LastOrDefault()?.Trim()
            If String.IsNullOrEmpty(attrib) Or String.IsNullOrEmpty(param) Then Continue For

            If {"code", "c"}.Contains(attrib) Then
                conditions.Add(ProductCode.SimilarTo(param))
            ElseIf {"category", "cat"}.Contains(attrib) Then
                conditions.Add(Category.SimilarTo(param))
            ElseIf {"brand", "b"}.Contains(attrib) Then
                conditions.Add(BrandName.SimilarTo(param))
            ElseIf {"unit", "u"}.Contains(attrib) Then
                conditions.Add(UnitOfMeasure2.SimilarTo(param))
            ElseIf {"desc", "d"}.Contains(attrib) Then
                conditions.Add(Description.SimilarTo(param))
            ElseIf {"color", "col"}.Contains(attrib) AndAlso If(_productColor?.RowID, 0) > 0 Then
                conditions.Add(If(_productColor.Color?.ColorName?.SimilarTo(param), False))
            ElseIf {"style", "s"}.Contains(attrib) Then
                conditions.Add(Style.SimilarTo(param))
            ElseIf {"sku", "sku"}.Contains(attrib) Then
                conditions.Add(Sku.SimilarTo(param))
            ElseIf {"sku2", "sku2"}.Contains(attrib) Then
                conditions.Add(Sku2.SimilarTo(param))
            Else
                Continue For
            End If
        Next

        Return conditions.Where(Function(t) t).Count() = conditions.Count()
    End Function

    Public ReadOnly Property ProductInventoryLocationId As Integer
        Get
            Return If(ProductInventoryLocation?.RowID, 0)
        End Get
    End Property


    Public ReadOnly Property InventoryName As String
        Get
            Return ProductInventoryLocation?.RackShelfColumn?.InventoryLocation?.NameAlternative
        End Get
    End Property

End Class