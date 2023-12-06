Option Strict On

Imports WarehouseManagementSystem.Core.Entities

Public Class ProductColorSizeSelectorSubDialog
    Private ReadOnly _productColorSizeId As Integer
    Private ReadOnly _productInventoryLocations As List(Of ProductInventoryLocation)
    Private ReadOnly _rackShelfColumnList As List(Of RackShelfColumn)

    Public Sub New(productColorSizeId As Integer,
        productInventoryLocations As List(Of ProductInventoryLocation))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _productColorSizeId = productColorSizeId
        _productInventoryLocations = productInventoryLocations
    End Sub

    Public Sub New(productColorSizeId As Integer,
        rackShelfColumnList As List(Of RackShelfColumn))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _productColorSizeId = productColorSizeId
        _rackShelfColumnList = rackShelfColumnList
    End Sub

    Public ReadOnly Property SelectedRackShelfColumnId As Integer

    Private Sub ProductColorSizeSelectorSubDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grid.AutoGenerateColumns = False

        If If(_productInventoryLocations?.Any(), False) Then
            grid.DataSource = _productInventoryLocations.Select(Function(t) New RackShelfColumnSimpleModel(productColorSizeId:=_productColorSizeId, t.RackShelfColumn)).ToList()
        End If

        If If(_rackShelfColumnList?.Any(), False) Then
            grid.DataSource = _rackShelfColumnList.Select(Function(t) New RackShelfColumnSimpleModel(productColorSizeId:=_productColorSizeId, t)).ToList()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If grid.Rows.Count() = 0 AndAlso grid.CurrentRow Is Nothing Then Return

        Dim model = CType(grid.CurrentRow.DataBoundItem, RackShelfColumnSimpleModel)

        _SelectedRackShelfColumnId = model.RowID

        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DialogResult = DialogResult.Cancel
    End Sub

End Class