Imports WarehouseManagementSystem.Core.Entities

Public Class ProductColorSizeOrderModel
    Private ReadOnly _dataSource As IGrouping(Of Integer, ProductInventoryLocation)

    Public Sub New(dataSource As IGrouping(Of Integer, ProductInventoryLocation))
        _dataSource = dataSource

        _ProductColorSizeId = dataSource.FirstOrDefault().ProductColorSizeID
        _ColorName = dataSource.FirstOrDefault()?.ProductColorSize.ProductColor.Color.ColorName
        _ColorValue = dataSource.FirstOrDefault()?.ProductColorSize.ProductColor.Color.ColorValue
        _ProductCode = dataSource.FirstOrDefault()?.ProductColorSize.ProductColor.Product.ProductCode
        _Size = If(dataSource.FirstOrDefault()?.ProductColorSize.Size, 0)
        _SeasonCode = dataSource.FirstOrDefault()?.ProductColorSize.SeasonCode
        _UnitOfMeasure = dataSource.FirstOrDefault()?.UnitOfMeasure
        _UnitPrice = If(dataSource.FirstOrDefault()?.UnitPrice, 0)
        _SKU = dataSource.FirstOrDefault().ProductColorSize.SKU
        _SKU2 = dataSource.FirstOrDefault().ProductColorSize.SKU2
        _TotalAvailableQty = dataSource.Sum(Function(t) If(t.TotalAvailableQty, 0))
        _TotalReserveQty = dataSource.Sum(Function(t) If(t.TotalReserveQty, 0))
        _TotalAllocatedQty = dataSource.Sum(Function(t) If(t.TotalAllocatedQty, 0))
        _TotalOrderableQty = dataSource.Sum(Function(t) t.TotalOrderableQty)
    End Sub

    Public ReadOnly Property ProductColorSizeId As Integer
    Public ReadOnly Property ColorName As String
    Public ReadOnly Property ColorValue As String
    Public ReadOnly Property ProductCode As String
    Public ReadOnly Property Size As Decimal
    Public ReadOnly Property SeasonCode As String
    Public ReadOnly Property UnitOfMeasure As String
    Public ReadOnly Property UnitPrice As Decimal
    Public ReadOnly Property SKU As String
    Public ReadOnly Property SKU2 As String
    Public ReadOnly Property TotalAvailableQty As Integer
    Public ReadOnly Property TotalReserveQty As Integer
    Public ReadOnly Property TotalAllocatedQty As Integer
    Public ReadOnly Property TotalOrderableQty As Integer
End Class
