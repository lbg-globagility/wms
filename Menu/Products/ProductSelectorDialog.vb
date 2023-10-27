Option Strict On

Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices

Public Class ProductSelectorDialog
    Private _baseSource As List(Of ProductColorSizeModel)
    Private ReadOnly _inventoryLocationId As Integer
    Private ReadOnly _picp As ProductImageConfigParser

    Public ReadOnly Property SelectedProductColorSizeModels As List(Of ProductColorSizeModel)
        Get
            Return _baseSource.
                Where(Function(t) t.IsSelected).
                ToList()
        End Get
    End Property

    Public Property ProductColorSizeExceptionIds As List(Of Integer)

    Public Sub New(inventoryLocationId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _inventoryLocationId = inventoryLocationId

        _picp = New ProductImageConfigParser(filePath:=CONFIG_FILE_PATH)
    End Sub

    Private Async Sub ProductSelectorDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grid.AutoGenerateColumns = False

        _baseSource = Await GetProductColorSizes()

        grid.DataSource = _baseSource

        ShowSelectedStatus()
    End Sub

    Private Async Function GetProductColorSizes() As Task(Of List(Of ProductColorSizeModel))
        Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()
        Dim productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAsync(inventoryLocationId:=_inventoryLocationId)

        If ProductColorSizeExceptionIds IsNot Nothing AndAlso ProductColorSizeExceptionIds.Any() Then
            Return productInventoryLocations.
                Where(Function(t) Not ProductColorSizeExceptionIds.Contains(t.ProductColorSizeID)).
                Select(Function(t) New ProductColorSizeModel(productInventoryLocation:=t, productColorSize:=t.ProductColorSize, _picp)).
                OrderBy(Function(t) t.ProductCode).
                ToList()
        End If

        Return productInventoryLocations.
            Select(Function(t) New ProductColorSizeModel(productInventoryLocation:=t, productColorSize:=t.ProductColorSize, _picp)).
            OrderBy(Function(t) t.ProductCode).
            ToList()
    End Function

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim searchText = txtSearch.Text.ToLower()

        Dim dataSource = _baseSource

        Dim absoluteBool =
            Function(boolValue As Boolean?)
                Return If(boolValue, False)
            End Function

        If Not String.IsNullOrEmpty(searchText) Then
            dataSource = _baseSource.
                Where(Function(t) t.ProductCode.ToLower.Contains(searchText) Or
                    (Not String.IsNullOrEmpty(t.BrandName) AndAlso t.BrandName.ToLower.Contains(searchText)) Or
                    absoluteBool(t.Category?.ToLower.Contains(searchText)) Or
                    absoluteBool(t.UnitOfMeasure?.ToLower.Contains(searchText)) Or
                    absoluteBool(t.Description?.ToLower.Contains(searchText)) Or
                    absoluteBool(t.Colors?.ToLower.Contains(searchText)) Or
                    absoluteBool(t.SeasonCode?.ToLower.Contains(searchText))).
                ToList()
        End If

        grid.DataSource = dataSource
    End Sub

    Private Sub grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellContentClick
        If isSelectedColumn.Index = e.ColumnIndex Then
            txtSearch.Focus()
            grid.Item(isSelectedColumn.Index, e.RowIndex).Selected = False
            grid.Item(Column3.Index, e.RowIndex).Selected = True
            grid.Item(Column3.Index, e.RowIndex).Selected = False
            grid.Item(isSelectedColumn.Index, e.RowIndex).Selected = True
            grid.Focus()
            ShowSelectedStatus()
        End If
    End Sub

    Private Sub grid_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grid.CellBeginEdit

    End Sub

    Private Sub ShowSelectedStatus()
        Label2.Text = $"{_baseSource.Where(Function(t) t.IsSelected).Count()}/{_baseSource.Count()} selected"
    End Sub

    Private Sub LinkLabelReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelReset.LinkClicked
        txtSearch.Clear()
        txtSearch_TextChanged(txtSearch, New EventArgs)
        ShowSelectedStatus()
    End Sub

    Private Sub grid_SelectionChanged(sender As Object, e As EventArgs) Handles grid.SelectionChanged
        If grid.Rows.Count() = 0 AndAlso grid.CurrentRow Is Nothing Then Return

        Dim boundData = CType(grid.CurrentRow.DataBoundItem, ProductColorSizeModel)

        PictureBox1.LoadAsync(url:=boundData.Photo)
    End Sub

End Class