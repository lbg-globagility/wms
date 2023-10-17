Imports System.Windows.Forms.LinkLabel
Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Dto
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class StockTransferForm2
    Private _selectedOrder As Order
    Private _inventoryLocations As List(Of InventoryLocation)
    Private _isNew As Boolean

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

        cboToInventory.BindingContext = New BindingContext()
        cboToInventory.DataSource = _inventoryLocations

        Await LoadStockTransferOrders()
    End Sub

    Private Async Function LoadStockTransferOrders() As Task
        gridStockTransferOrders.DataSource = Await GetStockTransferOrders()
    End Function

    Private Async Function GetStockTransferOrders() As Task(Of List(Of Order))
        Dim orderDataService = MainServiceProvider.GetRequiredService(Of IOrderDataService)
        Return (Await orderDataService.GetStockTransferOrdersAsync(Z_OrganizationID)).
            OrderByDescending(Function(t) t.Created).
            ToList()
    End Function

    Private Async Function GetInventoryLocations() As Task(Of List(Of InventoryLocation))
        Dim inventoryLocationRepository = MainServiceProvider.GetRequiredService(Of IInventoryLocationRepository)
        Return Await inventoryLocationRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)
    End Function

    Private Sub gridStockTransferOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridStockTransferOrders.CellContentClick

    End Sub

    Private Sub gridStockTransferOrders_SelectionChanged(sender As Object, e As EventArgs) Handles gridStockTransferOrders.SelectionChanged
        Dim currentRow = gridStockTransferOrders.CurrentRow
        If currentRow Is Nothing Then
            _selectedOrder = Nothing
            ReloadDisplayForm()
            Return
        End If

        _selectedOrder = CType(currentRow.DataBoundItem, Order)

        ReloadDisplayForm(order:=_selectedOrder)

    End Sub

    Private Async Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            LinkLabelRefresh_LinkClicked(LinkLabelRefresh,
                New LinkLabelLinkClickedEventArgs(LinkLabelRefresh.Links.OfType(Of Link).FirstOrDefault()))
            Return
        End If

        Dim orderDataService = MainServiceProvider.GetRequiredService(Of IOrderDataService)
        gridStockTransferOrders.DataSource = (Await orderDataService.SearchStockTransferOrdersAsync(organizationId:=Z_OrganizationID,
            searchText:=txtSearch.Text)).
            OrderByDescending(Function(t) t.Created).
            ToList()
    End Sub

    Private Async Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        ToolStripButtonNew.Enabled = False

        Await FunctionUtils.TryCatchFunctionAsync("Quick create stock transfer",
            Async Function()
                Dim orderDataService = MainServiceProvider.GetRequiredService(Of IOrderDataService)
                Dim newOrder = Await orderDataService.QuickCreateStockTransferOrderAsync(organizationId:=Z_OrganizationID, userId:=Z_UserID)

                _selectedOrder = newOrder

                ReloadDisplayForm(order:=_selectedOrder)

                SplitContainer1.Panel1.Enabled = False

                DisEnableButtons(True, ignoreToolStripButton:=ToolStripButtonApproved)
            End Function)

    End Sub

    Private Async Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        SplitContainer1.Panel1.Enabled = False
        txtStockTransferNo.Focus()

        Dim action As Action =
            Async Sub()
                Await LoadStockTransferOrders()
                SplitContainer1.Panel1.Enabled = True
            End Sub

        Await FunctionUtils.TryCatchFunctionAsync("Save Stock Transfer changes",
            action:=
            Async Function()
                Dim orderDataService = MainServiceProvider.GetRequiredService(Of IOrderDataService)
                Await orderDataService.SaveAsync(_selectedOrder)

                action()
            End Function,
            errorCallBack:=action)
    End Sub

    Private Async Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        Dim cancelButtonAction As Action =
            Sub()
                LinkLabelRefresh_LinkClicked(LinkLabelRefresh,
                    New LinkLabelLinkClickedEventArgs(LinkLabelRefresh.Links.OfType(Of Link).FirstOrDefault()))

                If ToolStripButtonNew.Enabled = False Then ToolStripButtonNew.Enabled = True

                If SplitContainer1.Panel1.Enabled = False Then SplitContainer1.Panel1.Enabled = True
            End Sub

        If _isNew Then
            SplitContainer1.Panel1.Enabled = False

            Await FunctionUtils.TryCatchFunctionAsync("Delete order after quick create stock transfer",
                action:=
                Async Function()
                    Dim orderRepository = MainServiceProvider.GetRequiredService(Of IOrderRepository)
                    Await orderRepository.DeleteAsync(_selectedOrder)

                    cancelButtonAction()
                End Function,
                errorCallBack:=cancelButtonAction)

            Return
        End If

        cancelButtonAction()
    End Sub

    Private Sub ToolStripButtonClose_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClose.Click
        Close()
    End Sub

    Private Sub cboFromInventory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFromInventory.SelectedIndexChanged
        EnOrDisableAddItemButton()
    End Sub

    Private Sub EnOrDisableAddItemButton()
        Dim inventoryLocationIdFrom = CInt(cboFromInventory.SelectedValue)
        Dim inventoryLocationIdTo = CInt(cboToInventory.SelectedValue)

        Dim invalidFrom = inventoryLocationIdFrom = Nothing OrElse inventoryLocationIdFrom = 0
        Dim invalidTo = inventoryLocationIdTo = Nothing OrElse inventoryLocationIdTo = 0
        btnAddItem.Enabled = Not invalidFrom AndAlso Not invalidTo AndAlso If(_selectedOrder?.IsOpen, False)
    End Sub

    Private Sub cboToInventory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboToInventory.SelectedIndexChanged
        EnOrDisableAddItemButton()
    End Sub

    Private Async Sub gridStockTransferOrdersFrom_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridStockTransferOrdersFrom.CellContentClick

        If pickFromRackShelfColumn.Index = e.ColumnIndex Then
            Dim movementHistoryGroupByProductColorSizeModel = CType(gridStockTransferOrdersFrom.Rows(e.RowIndex).DataBoundItem, MovementHistoryGroupByProductColorSizeModel)
            Dim form As New RackShelfColumnSelectorDialog(orderId:=_selectedOrder.RowID,
                inventoryLocationId:=_selectedOrder.StockTransferFromInventoryLocationId,
                movementHistoryGroupByProductColorSizeModel:=movementHistoryGroupByProductColorSizeModel,
                inventoryLocationName:=cboFromInventory.Text)
            If form.ShowDialog() = DialogResult.OK Then
                For Each movementHistory In form.GeneratedMovementHistories
                    _selectedOrder.AddMovementHistories(New List(Of MovementHistory) From {movementHistory})
                Next

                ReloadDisplayForm(_selectedOrder)
            End If
        ElseIf deleteProductColorSize.Index = e.ColumnIndex Then
            Dim movementHistoryGroupByProductColorSizeModel = CType(gridStockTransferOrdersFrom.Rows(e.RowIndex).DataBoundItem, MovementHistoryGroupByProductColorSizeModel)

            Await FunctionUtils.TryCatchFunctionAsync("Delete Stock Transfer Item",
                Function()
                    _selectedOrder.DeleteMovementHistoryByProductColorSizeId(productColorSizeId:=movementHistoryGroupByProductColorSizeModel.ProductColorSizeId)

                    ReloadDisplayForm(_selectedOrder)

                    Return Task.FromResult(0)
                End Function)
        End If
    End Sub

    Private Sub gridStockTransferOrdersTo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridStockTransferOrdersTo.CellContentClick
        'pickToRackShelfColumn
        If pickToRackShelfColumn.Index = e.ColumnIndex Then
            Dim movementHistoryGroupByProductColorSizeModel = CType(gridStockTransferOrdersTo.Rows(e.RowIndex).DataBoundItem, MovementHistoryGroupByProductColorSizeModel)
            Dim form As New RackShelfColumnSelectorDialog(orderId:=_selectedOrder.RowID,
                inventoryLocationId:=_selectedOrder.StockTransferToInventoryLocationId,
                movementHistoryGroupByProductColorSizeModel:=movementHistoryGroupByProductColorSizeModel,
                inventoryLocationName:=cboToInventory.Text)
            If form.ShowDialog() = DialogResult.OK Then
                For Each movementHistory In form.GeneratedMovementHistories
                    _selectedOrder.AddMovementHistories(New List(Of MovementHistory) From {movementHistory})
                Next

                ReloadDisplayForm(_selectedOrder)
            End If
        End If
    End Sub

    Private Sub ReloadDisplayForm(Optional order As Order = Nothing)
        txtStockTransferNo.DataBindings.Clear()
        txtStatus.DataBindings.Clear()
        txtTransferedBy.DataBindings.Clear()
        dtpStockTransferDate.DataBindings.Clear()
        txtComments.DataBindings.Clear()

        If order Is Nothing Then
            If _selectedOrder IsNot Nothing Then _selectedOrder = Nothing

            Dim txtBoxes = SplitContainer2.Panel1.Controls.OfType(Of TextBox).ToList()
            For Each txtBox In txtBoxes
                txtBox.Clear()
            Next
            dtpStockTransferDate.ResetText()
            dtpStockTransferDate.Value = Date.Now

            cboFromInventory.SelectedIndex = -1
            cboToInventory.SelectedIndex = -1

            ToolStripButtonApproved.Enabled = False

            Dim emptyDataSource = MovementHistoryGroupByProductColorSizeModel.EmptyDataSource()
            gridStockTransferOrdersFrom.DataSource = emptyDataSource

            gridStockTransferOrdersTo.BindingContext = New BindingContext()
            gridStockTransferOrdersTo.DataSource = emptyDataSource

            Return
        End If

        ToolStripButtonApproved.Enabled = order.IsOpen AndAlso order.HasMovementHistories

        txtStockTransferNo.Text = order?.OrderNumber
        txtStockTransferNo.DataBindings.Add("Text", order, "OrderNumber", True, DataSourceUpdateMode.OnPropertyChanged)

        txtStatus.Text = order?.Status
        txtStatus.DataBindings.Add("Text", order, "Status", True, DataSourceUpdateMode.OnPropertyChanged)

        txtTransferedBy.Text = String.Empty
        'txtTransferedBy.DataBindings.Add("Text", order, "LoanNumber", True, DataSourceUpdateMode.OnPropertyChanged)

        dtpStockTransferDate.Value = If(order?.OrderDate.Date, Date.Now)
        Dim dtpDatePickerBinding = New Binding("Value", order, "OrderDate") With {
            .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged}
        dtpStockTransferDate.DataBindings.Add(dtpDatePickerBinding)

        txtComments.Text = order?.Comments
        txtComments.DataBindings.Add("Text", order, "Comments", True, DataSourceUpdateMode.OnPropertyChanged)

        Dim inventoryLocationIdFrom = If(order.StockTransferFromInventoryLocationId, -1)
        Dim inventoryLocationIdTo = If(order.StockTransferToInventoryLocationId, -1)

        cboFromInventory.SelectedValue = inventoryLocationIdFrom
        cboToInventory.SelectedValue = inventoryLocationIdTo

        gridStockTransferOrdersFrom.DataSource = order.MovementHistoriesFromGroupByProductColorSize?.
            Select(Function(t) New MovementHistoryGroupByProductColorSizeModel(group:=t)).
            ToList()

        gridStockTransferOrdersTo.BindingContext = New BindingContext()
        gridStockTransferOrdersTo.DataSource = order.MovementHistoriesToGroupByProductColorSize?.
            Select(Function(t) New MovementHistoryGroupByProductColorSizeModel(group:=t)).
            ToList()
        'New(group As IGrouping(Of Integer?, MovementHistory))
    End Sub

    Private Async Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Dim inventoryLocationIdFrom = CInt(cboFromInventory.SelectedValue)
        Dim inventoryLocationIdTo = CInt(cboToInventory.SelectedValue)

        Dim invalidFrom = inventoryLocationIdFrom = Nothing OrElse inventoryLocationIdFrom = 0
        Dim invalidTo = inventoryLocationIdTo = Nothing OrElse inventoryLocationIdTo = 0

        If invalidFrom OrElse invalidTo Then
            MessageBox.Show(text:=$"Invalid value of `{If(invalidFrom, "From", If(invalidTo, "To", String.Empty))} Inventory`", caption:="Invalid Inventory", icon:=MessageBoxIcon.Error, buttons:=MessageBoxButtons.OK)
            Return
        End If

        Dim hasOrder As Boolean = _selectedOrder IsNot Nothing

        Dim form As New ProductSelectorDialog(inventoryLocationId:=CInt(cboFromInventory.SelectedValue))
        If hasOrder Then form.ProductColorSizeExceptionIds = _selectedOrder.MovementHistories?.
            GroupBy(Function(t) t.ProductColorSizeID.Value).
            Select(Function(id) id.Key).
            ToList()

        If hasOrder AndAlso form.ShowDialog() = Global.System.Windows.Forms.DialogResult.OK Then
            Dim selectedProductColorSizeModels = form.SelectedProductColorSizeModels

            Dim productInventoryLocationDataService = MainServiceProvider.GetRequiredService(Of IProductInventoryLocationDataService)
            Dim productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAsync(inventoryLocationId:=inventoryLocationIdTo)

            For Each productColorSizeModel In selectedProductColorSizeModels
                Dim newMovementHistoryFrom = MovementHistory.NewMovementHistory(organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    productColorSizeID:=productColorSizeModel.ProductColorSize.RowID,
                    orderId:=_selectedOrder.RowID,
                    productInventoryLocationId:=productColorSizeModel.ProductInventoryLocation.RowID,
                    currentQty:=0,
                    qtyToApply:=0,
                    transactionType:=$"{OrderType.ST} - From")
                newMovementHistoryFrom.SetProductInventoryLocation(productColorSizeModel.ProductInventoryLocation)

                _selectedOrder.AddMovementHistories(New List(Of MovementHistory) From {newMovementHistoryFrom})

                Dim toProductInventoryLocation = productInventoryLocations.
                    Where(Function(t) t.ProductColorSizeID = productColorSizeModel.ProductColorSize.RowID).
                    Where(Function(t) t.RackShelfColumn.InventoryLocationID = inventoryLocationIdTo).
                    FirstOrDefault()
                Dim newMovementHistoryTo = MovementHistory.NewMovementHistory(organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    productColorSizeID:=productColorSizeModel.ProductColorSize.RowID,
                    orderId:=_selectedOrder.RowID,
                    productInventoryLocationId:=toProductInventoryLocation.RowID,
                    currentQty:=0,
                    qtyToApply:=0,
                    transactionType:=$"{OrderType.ST} - To")
                newMovementHistoryTo.SetProductInventoryLocation(toProductInventoryLocation)

                _selectedOrder.AddMovementHistories(New List(Of MovementHistory) From {newMovementHistoryTo})
            Next

            ReloadDisplayForm(_selectedOrder)
        End If
    End Sub

    Private Async Sub LinkLabelRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelRefresh.LinkClicked
        LinkLabelRefresh.Enabled = False
        Await LoadStockTransferOrders()
        LinkLabelRefresh.Enabled = True
    End Sub

    Private Sub ToolStripButtonNew_EnabledChanged(sender As Object, e As EventArgs) Handles ToolStripButtonNew.EnabledChanged
        _isNew = Not ToolStripButtonNew.Enabled
    End Sub

    Private Async Sub ToolStripButtonApproved_Click(sender As Object, e As EventArgs) Handles ToolStripButtonApproved.Click
        Dim prompt = MessageBox.Show(text:="Are you sure you want to `Approve` this Stock Transfer?", caption:="Approve Stock Transfer", icon:=MessageBoxIcon.Question, buttons:=MessageBoxButtons.YesNoCancel)
        If Not prompt = DialogResult.Yes Then Return

        SplitContainer1.Panel1.Enabled = False

        Dim action As Action =
            Async Sub()
                Await LoadStockTransferOrders()
                SplitContainer1.Panel1.Enabled = True
            End Sub

        Await FunctionUtils.TryCatchFunctionAsync("Approve Stock Transfer",
            Async Function()
                Dim orderDataService = MainServiceProvider.GetRequiredService(Of IOrderDataService)

                Await orderDataService.ApproveStockTransfer(_selectedOrder)

                action()
            End Function,
            errorCallBack:=action)

        SplitContainer1.Panel1.Enabled = True
    End Sub

    Private Sub SplitContainer1_Panel1_EnabledChanged(sender As Object, e As EventArgs) Handles SplitContainer1.Panel1.EnabledChanged
        Dim enabled = SplitContainer1.Panel1.Enabled

        DisEnableButtons(enabled)
    End Sub

    Private Sub DisEnableButtons(enabled As Boolean,
        Optional ignoreToolStripButton As ToolStripButton = Nothing)

        Dim names = {ToolStripButtonSave.Name,
                    ToolStripButtonApproved.Name,
                    ToolStripButtonCancel.Name}
        If ignoreToolStripButton IsNot Nothing Then names = names.Where(Function(t) Not t = ignoreToolStripButton.Name).ToArray()

        Dim toolStripButtons = ToolStrip1.Items.OfType(Of ToolStripButton).
            Where(Function(t) names.Contains(t.Name)).
            ToList()
        For Each button In toolStripButtons
            button.Enabled = enabled
        Next
    End Sub

    Private Sub gridStockTransferOrders_DataSourceChanged(sender As Object, e As EventArgs) Handles gridStockTransferOrders.DataSourceChanged
        If If(gridStockTransferOrders.Rows?.Count(), 0) = 0 Then ReloadDisplayForm()
    End Sub

End Class