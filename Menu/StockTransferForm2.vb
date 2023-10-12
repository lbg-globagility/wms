Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories

Public Class StockTransferForm2
    Private _selectedOrder As Order
    Private _inventoryLocations As List(Of InventoryLocation)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Async Sub StockTransferForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridStockTransferOrders.AutoGenerateColumns = False
        gridStockTransferOrdersFrom.AutoGenerateColumns = False
        gridStockTransferOrdersTo.AutoGenerateColumns = False

        cboFromInventory.ValueMember = "RowID"
        cboFromInventory.DisplayMember = "Name"

        cboToInventory.ValueMember = "RowID"
        cboToInventory.DisplayMember = "Name"

        _inventoryLocations = Await GetInventoryLocations()
        cboFromInventory.DataSource = _inventoryLocations
    End Sub

    Private Async Function GetInventoryLocations() As Task(Of List(Of InventoryLocation))
        Dim inventoryLocationRepository = MainServiceProvider.GetRequiredService(Of IInventoryLocationRepository)
        Return Await inventoryLocationRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)
    End Function

    Private Sub gridStockTransferOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridStockTransferOrders.CellContentClick

    End Sub

    Private Sub gridStockTransferOrders_SelectionChanged(sender As Object, e As EventArgs) Handles gridStockTransferOrders.SelectionChanged

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Async Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        Dim orderDataService = MainServiceProvider.GetRequiredService(Of IOrderDataService)
        Dim newOrder = Await orderDataService.QuickCreateStockTransferOrderAsync(organizationId:=Z_OrganizationID, userId:=Z_UserID)

        _selectedOrder = newOrder

        ToolStripButtonNew.Enabled = False

        ReloadDisplayForm(order:=_selectedOrder)
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        ToolStripButtonNew.Enabled = True
    End Sub

    Private Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        ToolStripButtonNew.Enabled = True
    End Sub

    Private Sub ToolStripButtonClose_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClose.Click

    End Sub

    Private Sub cboFromInventory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFromInventory.SelectedIndexChanged
        cboToInventory.BindingContext = New BindingContext()
        cboToInventory.DataSource = _inventoryLocations.Where(Function(i) Not i.RowID = CInt(cboFromInventory.SelectedValue)).ToList()
    End Sub

    Private Sub cboToInventory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboToInventory.SelectedIndexChanged

    End Sub

    Private Sub gridStockTransferOrdersFrom_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridStockTransferOrdersFrom.CellContentClick

    End Sub

    Private Sub gridStockTransferOrdersTo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridStockTransferOrdersTo.CellContentClick

    End Sub

    Private Sub ReloadDisplayForm(Optional order As Order = Nothing)
        If order Is Nothing Then
            Dim txtBoxes = SplitContainer2.Panel1.Controls.OfType(Of TextBox).ToList()
            For Each txtBox In txtBoxes
                txtBox.Clear()
            Next
            dtpStockTransferDate.Value = Date.Now
            Return
        End If

        txtStockTransferNo.Text = order?.OrderNumber
        txtStatus.Text = order?.Status
        txtTransferedBy.Text = String.Empty
        dtpStockTransferDate.Value = If(order?.OrderDate.Date, Date.Now)
        txtComments.Text = order?.Comments
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Dim inventoryLocationId = CInt(cboFromInventory.SelectedValue)
        If inventoryLocationId = Nothing OrElse inventoryLocationId = 0 Then
            MessageBox.Show(text:="Invalid value of `From Inventory`", caption:="Invalid Inventory", icon:=MessageBoxIcon.Error, buttons:=MessageBoxButtons.OK)
            Return
        End If
        Dim form As New ProductSelectorDialog(inventoryLocationId:=CInt(cboFromInventory.SelectedValue))
        If form.ShowDialog() = DialogResult.OK Then
            Dim fsdfsd = form.SelectedProductColorSizes

        End If
    End Sub

End Class