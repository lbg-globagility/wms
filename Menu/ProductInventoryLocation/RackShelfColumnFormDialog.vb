Option Strict On

Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices

Public Class RackShelfColumnFormDialog
    Private Const VALID_INITIAL_MINIMUM_QUANTITY As Integer = 0
    Private ReadOnly _inventoryLocationId As Integer
    Private ReadOnly _productColorSizeId As Integer
    Private ReadOnly _rackShelfColumn As RackShelfColumn
    Private ReadOnly _originRackShelfColumn As RackShelfColumn
    Private ReadOnly _isNew As Boolean
    Public ReadOnly Property ProcessedRackShelfColumn As RackShelfColumn
    Public ReadOnly Property IsValid As Boolean
    Public ReadOnly Property HasChanges As Boolean

    Public Sub New(inventoryLocationId As Integer,
        productColorSizeId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _inventoryLocationId = inventoryLocationId
        _productColorSizeId = productColorSizeId
    End Sub

    Public Sub New(productColorSizeId As Integer,
        rackShelfColumn As RackShelfColumn)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _productColorSizeId = productColorSizeId
        _rackShelfColumn = rackShelfColumn
        _originRackShelfColumn = rackShelfColumn
        _isNew = rackShelfColumn.IsNewEntity
    End Sub

    Private Async Sub RackShelfColumnFormDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()
        Dim productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAsync(_inventoryLocationId)

        txtAvailableQty.Minimum = VALID_INITIAL_MINIMUM_QUANTITY
        txtAvailableQty.Maximum = Integer.MaxValue

        txtPickOrderNo.Text = $"{productInventoryLocations.Max(Function(t) t.RackShelfColumn.PickOrderNo) + 1}"

        Dim numericUpDownButton = txtAvailableQty.Controls.OfType(Of Control).FirstOrDefault()
        If numericUpDownButton IsNot Nothing Then numericUpDownButton.Visible = False

        If _rackShelfColumn IsNot Nothing Then
            txtPickOrderNo.Text = $"{_rackShelfColumn.PickOrderNo}"
            txtRack.Text = _rackShelfColumn.RackNo
            txtShelf.Text = _rackShelfColumn.ShelfNo
            txtColumn.Text = _rackShelfColumn.ColumnNo

            Dim aQty = If(_rackShelfColumn.AvailableQty, 0)
            txtAvailableQty.Value = aQty
            If aQty = 0 Then
                Dim availableQty = _rackShelfColumn.ProductInventoryLocations?.
                FirstOrDefault(Function(t) t.ProductColorSizeID = _productColorSizeId)?.
                TotalAvailableQty
                txtAvailableQty.Value = If(availableQty, 0)
            End If

            txtRemarks.Text = _rackShelfColumn.Remarks
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _rackShelfColumn.PickOrderNo = CInt(txtPickOrderNo.Text)
        _rackShelfColumn.RackNo = txtRack.Text
        _rackShelfColumn.ShelfNo = txtShelf.Text
        _rackShelfColumn.ColumnNo = txtColumn.Text
        _rackShelfColumn.AvailableQty = CInt(txtAvailableQty.Value)
        _rackShelfColumn.Remarks = txtRemarks.Text

        _IsValid = True 'txtAvailableQty.Value > VALID_INITIAL_MINIMUM_QUANTITY

        _HasChanges = Not _originRackShelfColumn.RackNo = _rackShelfColumn.RackNo AndAlso
            Not _originRackShelfColumn.ShelfNo = _rackShelfColumn.ShelfNo AndAlso
            Not _originRackShelfColumn.ColumnNo = _rackShelfColumn.ColumnNo AndAlso
            Not If(_originRackShelfColumn.AvailableQty, 0) = If(_rackShelfColumn.AvailableQty, 0) AndAlso
            Not _originRackShelfColumn.Remarks = _rackShelfColumn.Remarks

        _ProcessedRackShelfColumn = _rackShelfColumn

        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class