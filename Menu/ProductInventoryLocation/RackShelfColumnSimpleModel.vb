Imports WarehouseManagementSystem.Core.Entities

Public Class RackShelfColumnSimpleModel
    Private ReadOnly _rackShelfColumn As RackShelfColumn
    Private ReadOnly _productColorSizeId As Integer
    Private Const DEFAULT_DISPLAY_TEXT As String = "[Default]"

    Public Sub New(productColorSizeId As Integer,
        rackShelfColumn As RackShelfColumn)

        _productColorSizeId = productColorSizeId
        _RowID = rackShelfColumn.RowID.Value
        _PickOrderNo = rackShelfColumn.PickOrderNo.Value
        _Rack = If(String.IsNullOrEmpty(rackShelfColumn.RackNo) AndAlso String.IsNullOrEmpty(rackShelfColumn.ShelfNo) AndAlso String.IsNullOrEmpty(rackShelfColumn.ColumnNo), DEFAULT_DISPLAY_TEXT, rackShelfColumn.RackNo)
        _Shelf = If(_Rack = DEFAULT_DISPLAY_TEXT AndAlso String.IsNullOrEmpty(rackShelfColumn.ShelfNo), DEFAULT_DISPLAY_TEXT, rackShelfColumn.ShelfNo)
        _Column = If(_Rack = DEFAULT_DISPLAY_TEXT AndAlso String.IsNullOrEmpty(rackShelfColumn.ColumnNo), DEFAULT_DISPLAY_TEXT, rackShelfColumn.ColumnNo)

        Dim aQty = If(rackShelfColumn.AvailableQty, 0)
        _AvailableQty = aQty
        If aQty = 0 Then
            Dim availableQty = rackShelfColumn.ProductInventoryLocations.
                FirstOrDefault(Function(t) t.ProductColorSizeID = productColorSizeId)?.
                TotalAvailableQty
            _AvailableQty = If(availableQty, 0)
        End If

        Dim rQty = If(rackShelfColumn.ReservedQty, 0)
        _ReservedQty = rQty
        If rQty = 0 Then
            Dim reserveQty = rackShelfColumn.ProductInventoryLocations.
                FirstOrDefault(Function(t) t.ProductColorSizeID = productColorSizeId)?.
                TotalReserveQty
            _ReservedQty = If(reserveQty, 0)
        End If

        _Remarks = rackShelfColumn.Remarks

        _rackShelfColumn = rackShelfColumn
    End Sub

    Public ReadOnly Property RowID As Integer
    Public ReadOnly Property PickOrderNo As Integer
    Public ReadOnly Property Rack As String
    Public ReadOnly Property Shelf As String
    Public ReadOnly Property Column As String
    Public ReadOnly Property AvailableQty As Integer
    Public ReadOnly Property ReservedQty As Integer
    Public ReadOnly Property Remarks As String
    Public ReadOnly Property RackShelfColumn As RackShelfColumn
        Get
            Return _rackShelfColumn
        End Get
    End Property

    Public ReadOnly Property HasAvailableQty As Boolean
        Get
            Return Not AvailableQty <= 0
        End Get
    End Property
End Class