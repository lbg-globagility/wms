Option Strict On

Imports Microsoft.Extensions.DependencyInjection
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Utilities.Extensions
Public Class ProductColorSizeSelectorDialog

    Private Class InvetoryTypeModel
        Public ReadOnly Property Name As String
        Public ReadOnly Property Value As InventoryLocationType

        Public Sub New(inventoryLocationType As InventoryLocationType)
            _Name = $"{inventoryLocationType}"
            _Value = inventoryLocationType
        End Sub

    End Class

    Private _baseSource As List(Of ProductColorSizeModel)
    Private _currentSelectedInventoryName As Integer
    Private _inventoryLocations As List(Of InventoryLocation)
    Private _currentSelectedInventorySource As InventoryLocationType
    Private ReadOnly _showAllInventory As Boolean
    Private ReadOnly _inventoryLocationId As Integer
    Private ReadOnly _picp As ProductImageConfigParser

    Private _selectedProductColorSizeModels As New List(Of ProductColorSizeModel)

    Public ReadOnly Property SelectedProductColorSizeModels As List(Of ProductColorSizeModel)
        Get
            'Return _baseSource.
            '    Where(Function(t) t.IsSelected).
            '    ToList()
            Return _selectedProductColorSizeModels
        End Get
    End Property

    Public Property ProductColorSizeExceptionIds As List(Of Integer)

    Public Property ProductInventoryLocationExceptionIds As List(Of Integer)

    Public Sub New(Optional inventoryLocationId As Integer? = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _showAllInventory = Not inventoryLocationId.HasValue

        cboInventorySource.Visible = _showAllInventory
        cboInventoryName.Visible = _showAllInventory
        LabelInventorySource.Visible = _showAllInventory
        LabelInventoryName.Visible = _showAllInventory

        _inventoryLocationId = If(inventoryLocationId, 0)

        _picp = New ProductImageConfigParser(filePath:=CONFIG_FILE_PATH)

        InitButtonClearSearch()

        grid.AutoGenerateColumns = False
        gridSelectedItems.AutoGenerateColumns = False

    End Sub

    Private Async Sub ProductSelectorDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grid.AutoGenerateColumns = False
        gridSelectedItems.AutoGenerateColumns = False

        _inventoryLocations = Await GetInventoryLocationsAsync()

        LoadInventorySourceType()

        If _showAllInventory Then
            AddHandler cboInventorySource.SelectedIndexChanged, AddressOf cboInventorySource_SelectedIndexChanged
            AddHandler cboInventorySource.SelectedValueChanged, AddressOf cboInventorySource_SelectedValueChanged

            AddHandler cboInventoryName.SelectedIndexChanged, AddressOf cboInventoryName_SelectedIndexChanged
            AddHandler cboInventoryName.SelectedValueChanged, AddressOf cboInventoryName_SelectedValueChanged

        Else
            _baseSource = Await GetProductColorSizes()

            grid.AutoGenerateColumns = False
            grid.DataSource = _baseSource

        End If

        ShowSelectedStatus()

        inventorySourceOnChange()

    End Sub

    Private Async Function GetProductColorSizes(Optional inventoryId As Integer? = Nothing) As Task(Of List(Of ProductColorSizeModel))
        Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()
        Dim productInventoryLocations = New List(Of ProductInventoryLocation)

        If _showAllInventory Then
            Dim inventoryLocationIds = _inventoryLocations.
                Select(Function(t) t.RowID.Value).
                ToArray()

            productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdsAsync(inventoryLocationIds:=If(inventoryId.HasValue, inventoryLocationIds.Where(Function(i) i = inventoryId.Value).ToArray(), inventoryLocationIds))

        Else
            productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAsync(inventoryLocationId:=If(inventoryId.HasValue, inventoryId.Value, _inventoryLocationId))

        End If

        Dim productColorSizeRepository = GetRequiredService(Of IProductColorSizeRepository)()
        Dim productColorSizes = Await productColorSizeRepository.GetManyByOrganizationIdsAsync(Z_OrganizationID)

        Dim selector As Func(Of ProductColorSize, ProductColorSizeModel) =
            Function(t)
                Dim productInventoryLocation = productInventoryLocations.
                    FirstOrDefault(Function(i) i.ProductColorSizeID = t.RowID.Value)
                Dim productInventoryLocationItems = productInventoryLocations.
                    Where(Function(i) i.ProductColorSizeID = t.RowID.Value).
                    ToList()
                Return New ProductColorSizeModel(productInventoryLocations:=productInventoryLocationItems,
                    productColorSize:=t,
                    _picp)
            End Function

        If Not _showAllInventory AndAlso If(ProductColorSizeExceptionIds?.Any(), False) Then
            Return productColorSizes.
                Where(Function(t) Not ProductColorSizeExceptionIds.Contains(t.RowID.Value)).
                Select(selector).
                OrderBy(Function(t) t.ProductCode).
                ToList()
        End If

        Dim activeProductColorSizeIds = productInventoryLocations.Where(Function(t) t.RackShelfColumn.IsActive).GroupBy(Function(t) t.ProductColorSizeID).Select(Function(t) t.Key).ToArray()

        Return productColorSizes.
            Where(Function(t) activeProductColorSizeIds.Contains(If(t.RowID, 0))).
            Select(selector).
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
        Dim searchText = txtSearch.Text

        Dim dataSource = _baseSource

        Dim absoluteBool =
            Function(boolValue As Boolean?)
                Return If(boolValue, False)
            End Function

        If Not String.IsNullOrEmpty(searchText) AndAlso
            _baseSource IsNot Nothing Then

            '(Not String.IsNullOrEmpty(t.BrandName) AndAlso t.BrandName.ToLower.Contains(searchText)) Or
            dataSource = _baseSource.
                Where(Function(t) t.ProductCode.SimilarTo(searchText) Or
                    absoluteBool(t.BrandName?.SimilarTo(searchText)) Or
                    absoluteBool(t.Category?.SimilarTo(searchText)) Or
                    absoluteBool(t.UnitOfMeasure?.SimilarTo(searchText)) Or
                    absoluteBool(t.Description?.SimilarTo(searchText)) Or
                    absoluteBool(t.Colors?.SimilarTo(searchText)) Or
                    absoluteBool(t.SeasonCode?.SimilarTo(searchText))).
                ToList()
        ElseIf String.IsNullOrEmpty(searchText) AndAlso
            _baseSource IsNot Nothing Then
            ' Load default data source
        Else
            dataSource = Enumerable.Empty(Of ProductColorSizeModel)().ToList()
        End If

        grid.AutoGenerateColumns = False
        grid.DataSource = dataSource
    End Sub

    Private Sub grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellContentClick
        If isSelectedColumn.Index = e.ColumnIndex And e.RowIndex >= 0 Then
            txtSearch.Focus()
            grid.Item(isSelectedColumn.Index, e.RowIndex).Selected = False
            grid.Item(Column3.Index, e.RowIndex).Selected = True
            grid.Item(Column3.Index, e.RowIndex).Selected = False
            grid.Item(isSelectedColumn.Index, e.RowIndex).Selected = True
            grid.Focus()
            ShowSelectedStatus()

            Dim model = CType(grid.Rows(e.RowIndex).DataBoundItem, ProductColorSizeModel)
            If model.IsSelected Then
                If ProductInventoryLocationExceptionIds.Contains(model.ProductInventoryLocationId) Then
                    MessageBox.Show(text:="This item already exists on the base `order`.",
                        caption:="Invalid Item",
                        icon:=MessageBoxIcon.Error,
                        buttons:=MessageBoxButtons.OK)

                Else
                    _selectedProductColorSizeModels.Add(model)

                End If

            End If

            If Not model.IsSelected Then
                Dim items = _selectedProductColorSizeModels.
                    Where(Function(t) t.ProductInventoryLocationId = model.ProductInventoryLocationId).
                    ToList()
                For Each item In items
                    _selectedProductColorSizeModels.Remove(item)
                Next
            End If

            _selectedProductColorSizeModels = _selectedProductColorSizeModels.
                GroupBy(Function(t) t.ProductInventoryLocationId).
                Select(Function(t) t.FirstOrDefault()).
                ToList()

            gridSelectedItems.DataSource = _selectedProductColorSizeModels
            Dim count = If(_selectedProductColorSizeModels?.Count(), 0)
            TabPage2.Text = If(count <= 0, "Selected", $"Selected ({count})")


            Return

            If grid.Rows.Count() = 0 AndAlso grid.CurrentRow Is Nothing Then Return

            Dim boundData = CType(grid.CurrentRow.DataBoundItem, ProductColorSizeModel)

            If boundData.IsSelected AndAlso boundData.HasMoreThanOneRackShelfColumn Then
                Dim productColorSizeId = boundData.ProductColorSizeId
                Dim form As New ProductColorSizeSelectorSubDialog(productColorSizeId:=productColorSizeId,
                    productInventoryLocations:=boundData.ProductInventoryLocations)
                If Not form.ShowDialog() = DialogResult.OK Then Return

                boundData.ChangeSelectedProductInventoryLocation(form.SelectedRackShelfColumnId)
            End If
        End If
    End Sub

    Private Sub grid_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grid.CellBeginEdit

    End Sub

    Private Sub ShowSelectedStatus()
        Dim selectedCount = If(_baseSource?.Where(Function(t) t.IsSelected)?.Count(), 0)
        Label2.Text = $"{selectedCount} selected over {If(_baseSource?.Count(), 0)}"
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

    Private Sub grid_KeyDown(sender As Object, e As KeyEventArgs) Handles grid.KeyDown
        e.Handled = e.KeyCode = Keys.Enter
        If e.Handled Then ButtonOK.PerformClick()
    End Sub

    Private Sub grid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellDoubleClick
        Dim currentRow = grid.CurrentRow
        If currentRow Is Nothing Then Return

        Dim model = CType(currentRow.DataBoundItem, ProductColorSizeModel)
        model.IsSelected = Not model.IsSelected

        grid.Refresh()

        grid_CellContentClick(grid, e:=New DataGridViewCellEventArgs(
            columnIndex:=currentRow.Cells(isSelectedColumn.Name).ColumnIndex,
            rowIndex:=e.RowIndex))
    End Sub

    Private Sub grid_DataSourceChanged(sender As Object, e As EventArgs) Handles grid.DataSourceChanged
        grid.AutoGenerateColumns = False
        If Not If(grid.Rows.OfType(Of DataGridViewRow)?.Any(), False) Then Return

        Dim allRows = grid.Rows.OfType(Of DataGridViewRow).ToList()

        Dim hasNoQtyRows = allRows.Where(Function(t) CDbl(t.Cells(Column4.Index).Value) = 0).ToList()
        For Each row In hasNoQtyRows
            Dim origColor = grid.Item(columnIndex:=Column4.Index, row.Index).Style.ForeColor
            row.DefaultCellStyle.ForeColor = Lighten(origColor, 48)

        Next

        For Each row In allRows
            Dim model = CType(row.DataBoundItem, ProductColorSizeModel)
            If model Is Nothing Then Continue For

            Dim bool = Not If(model.ProductInventoryLocation?.RackShelfColumn?.IsActive, False)
            row.ReadOnly = bool

            If bool Then
                Dim font = row.InheritedStyle.Font
                row.DefaultCellStyle.Font = New Font(prototype:=font,
                    newStyle:=FontStyle.Strikeout)

            End If

        Next

    End Sub

    Function Lighten(orig As Drawing.Color, Optional percent As Integer = 80) As Drawing.Color
        'get remainders
        Dim rr As Integer = 255 - orig.R
        Dim gr As Integer = 255 - orig.G
        Dim br As Integer = 255 - orig.B

        'add a percentage of the remainder, plus original value
        Dim r As Integer = CInt(percent / 100 * rr) + orig.R
        Dim g As Integer = CInt(percent / 100 * gr) + orig.G
        Dim b As Integer = CInt(percent / 100 * br) + orig.B

        Return Drawing.Color.FromArgb(r, g, b)
    End Function

    Function Darken(orig As Drawing.Color, Optional percent As Integer = 80) As Drawing.Color
        'subtract the percentage of the original value from the original value
        Dim r As Integer = orig.R - CInt(percent / 100 * orig.R)
        Dim g As Integer = orig.G - CInt(percent / 100 * orig.G)
        Dim b As Integer = orig.B - CInt(percent / 100 * orig.B)

        Return Drawing.Color.FromArgb(r, g, b)
    End Function

    Private Async Function GetInventoryLocationsAsync() As Task(Of List(Of InventoryLocation))
        Dim inventoryLocationRepository = GetRequiredService(Of IInventoryLocationRepository)()
        Dim inventoryLocations = Await inventoryLocationRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)

        Return inventoryLocations.
            OrderByDescending(Function(t) t.IsMainWarehouse).
            ThenBy(Function(t) t.Name).
            ToList()
    End Function

    Private Sub cboInventorySource_SelectedIndexChanged0(sender As Object, e As EventArgs) Handles cboInventorySource.SelectedIndexChanged

    End Sub

    Private Sub cboInventorySource_SelectedIndexChanged(sender As Object, e As EventArgs)
        cboInventorySource_SelectedValueChanged(sender:=sender, e:=e)
    End Sub

    Private Sub cboInventorySource_SelectedValueChanged(sender As Object, e As EventArgs)

        ''If _currentSelectedInventorySource = CType(cboInventorySource.SelectedValue, InventoryLocationType) Then Return
        '_currentSelectedInventorySource = CType(cboInventorySource.SelectedValue, InventoryLocationType)

        'Dim inventoryLocationType = CType(cboInventorySource.SelectedValue, InventoryLocationType)

        'Dim hasSelectedItemInventorySource = cboInventorySource.SelectedValue IsNot Nothing
        'cboInventoryName.Enabled = hasSelectedItemInventorySource

        'cboInventoryName.Enabled = False
        'Dim inventoryLocations = _inventoryLocations.
        '    Where(Function(t) t.Type = inventoryLocationType).
        '    ToList()

        'cboInventoryName.DisplayMember = "NameAlternative"
        'cboInventoryName.ValueMember = "RowID"
        'cboInventoryName.DataSource = inventoryLocations

        'cboInventoryName.Enabled = hasSelectedItemInventorySource And
        '    If(inventoryLocations?.Any(), False)

        inventorySourceOnChange()
    End Sub

    Private Sub inventorySourceOnChange()
        'If _currentSelectedInventorySource = CType(cboInventorySource.SelectedValue, InventoryLocationType) Then Return
        _currentSelectedInventorySource = CType(cboInventorySource.SelectedValue, InventoryLocationType)

        Dim inventoryLocationType = CType(cboInventorySource.SelectedValue, InventoryLocationType)

        Dim hasSelectedItemInventorySource = cboInventorySource.SelectedValue IsNot Nothing
        cboInventoryName.Enabled = hasSelectedItemInventorySource

        cboInventoryName.Enabled = False
        Dim inventoryLocations = _inventoryLocations.
            Where(Function(t) t.Type = inventoryLocationType).
            ToList()

        cboInventoryName.DisplayMember = "NameAlternative"
        cboInventoryName.ValueMember = "RowID"
        cboInventoryName.DataSource = inventoryLocations

        cboInventoryName.Enabled = hasSelectedItemInventorySource And
            If(inventoryLocations?.Any(), False)
    End Sub

    Private Sub cboInventoryName_SelectedIndexChanged0(sender As Object, e As EventArgs) Handles cboInventoryName.SelectedIndexChanged

    End Sub

    Private Sub cboInventoryName_SelectedIndexChanged(sender As Object, e As EventArgs)
        cboInventoryName_SelectedValueChanged(sender:=sender, e:=e)
    End Sub

    Private Async Sub cboInventoryName_SelectedValueChanged(sender As Object, e As EventArgs)
        If _currentSelectedInventoryName = CType(cboInventoryName.SelectedValue, Integer) Then Return
        _currentSelectedInventoryName = CType(cboInventoryName.SelectedValue, Integer)

        _baseSource = (Await GetProductColorSizes(inventoryId:=CType(cboInventoryName.SelectedValue, Integer))).
            Where(Function(t) Not ProductInventoryLocationExceptionIds.Contains(t.ProductInventoryLocationId)).
            ToList()

        grid.AutoGenerateColumns = False
        grid.DataSource = _baseSource

        ShowSelectedStatus()
    End Sub

    Private Sub LoadInventorySourceType()
        With cboInventorySource
            .Enabled = False
            .ValueMember = "Value"
            .DisplayMember = "Name"

            Dim customerOrderTypes = InventoryLocation.GetTypes.
                OfType(Of Object).
                Select(Function(t) New InvetoryTypeModel(CType(t, InventoryLocationType))).
                ToList()
            .BindingContext = New BindingContext()
            .DataSource = customerOrderTypes
            .Enabled = True
        End With
    End Sub

    Private Sub cboInventoryName_EnabledChanged(sender As Object, e As EventArgs) Handles cboInventoryName.EnabledChanged
        Dim bool = cboInventoryName.Enabled
        txtSearch.Enabled = bool
        grid.Enabled = bool
        ButtonOK.Enabled = bool

    End Sub

    Private Sub InitButtonClearSearch()
        With btnClearSearch
            .Size = New Size(width:=txtSearch.ClientSize.Height, height:=txtSearch.ClientSize.Height)
            .Location = New Point(x:=txtSearch.ClientSize.Width - (btnClearSearch.Size.Width - 1), y:=0)
            .Font = New Font(Me.Font.Name, 7.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            .Cursor = Cursors.Default
        End With

        txtSearch.Controls.Add(btnClearSearch)

        txtSearch_TextChanged(txtSearch, New EventArgs())
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Clear()
        txtSearch.Focus()
    End Sub

    Private Sub gridSelectedItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridSelectedItems.CellContentClick
        Dim currentRow = gridSelectedItems.CurrentRow
        If currentRow Is Nothing Then Return

        If e.ColumnIndex = Column18.Index Then
            Dim model = CType(grid.Rows(e.RowIndex).DataBoundItem, ProductColorSizeModel)
            model.IsSelected = False

            Dim items = _selectedProductColorSizeModels.
                    Where(Function(t) t.ProductInventoryLocationId = model.ProductInventoryLocationId).
                    ToList()
            For Each item In items
                item.IsSelected = False
                _selectedProductColorSizeModels.Remove(item)
            Next

            _selectedProductColorSizeModels = _selectedProductColorSizeModels.
                GroupBy(Function(t) t.ProductInventoryLocationId).
                Select(Function(t) t.FirstOrDefault()).
                ToList()

            gridSelectedItems.DataSource = _selectedProductColorSizeModels
            Dim count = If(_selectedProductColorSizeModels?.Count(), 0)
            TabPage2.Text = If(count <= 0, "Selected", $"Selected ({count})")
        End If

    End Sub

    Private Sub grid_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles grid.CellFormatting
        If e.RowIndex >= 0 Then grid.Rows(e.RowIndex).HeaderCell.Value = $"{e.RowIndex + 1}"

    End Sub

End Class
