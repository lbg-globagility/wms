Option Strict On

Imports System.Windows.Forms.LinkLabel
Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Dto
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class StockAdjustmentForm2
    Private _selectedOrder As Order
    Private _isNew As Boolean
    Private _positionView As PositionView
    Private ReadOnly _userId As Integer
    Private Const VIEW_NAME = View.STOCK_ADJUSTMENT_VIEW

    Public Sub New(userId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        SplitContainer3.Panel1Collapsed = True

        _userId = userId

        ToolStripButtonClose.Visible = Not FormBorderStyle = FormBorderStyle.FixedDialog
    End Sub

    Private Async Sub StockAdjustmentForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadUserPrivilege()

        gridStockAdjustmentOrders.AutoGenerateColumns = False
        gridStockAdjustmentOrdersFrom.AutoGenerateColumns = False
        gridStockAdjustmentOrdersTo.AutoGenerateColumns = False

        cboFromInventory.ValueMember = "RowID"
        cboFromInventory.DisplayMember = "Name"

        cboToInventory.ValueMember = "RowID"
        cboToInventory.DisplayMember = "Name"

        Await LoadInventoryLocations()

        Await LoadStockAdjustmentOrders()

        AddHandler gridStockAdjustmentOrders.SelectionChanged, AddressOf gridStockAdjustmentOrders_SelectionChanged
        gridStockAdjustmentOrders_SelectionChanged(gridStockAdjustmentOrders, New EventArgs)
    End Sub

    Private Async Function LoadInventoryLocations() As Task
        Dim inventoryLocations = Await GetInventoryLocations()
        cboFromInventory.DataSource = inventoryLocations

        cboToInventory.BindingContext = New BindingContext()
        cboToInventory.DataSource = inventoryLocations
    End Function

    Private Async Function LoadUserPrivilege() As Task
        Dim positionViewDataService = GetRequiredService(Of IPositionViewDataService)()
        _positionView = Await positionViewDataService.GetByUserIdAndViewNameAsync(organizationId:=Z_OrganizationID,
            userId:=_userId,
            viewName:=VIEW_NAME)

        If _positionView.Restricted Then
            MessageBox.Show(text:="The user has insufficient privilege to access this module.",
                caption:="Insufficient Privilege",
                icon:=MessageBoxIcon.Error,
                buttons:=MessageBoxButtons.OK)

            Close()

            Return
        ElseIf _positionView.ReadOnly Then
            Dim toolStripItems = ToolStrip1.Items.
                OfType(Of ToolStripItem).
                Where(Function(t) Not t.Name = ToolStripButtonClose.Name).
                ToList()

            For Each item In toolStripItems
                item.Visible = False
            Next

            Return
        End If

        ToolStripButtonNew.Visible = _positionView.Creates
        ToolStripButtonSave.Visible = _positionView.Updates Or _positionView.Creates
        ToolStripButtonApproved.Visible = _positionView.Updates

    End Function

    Private Async Function LoadStockAdjustmentOrders() As Task
        gridStockAdjustmentOrders.DataSource = Await GetStockAdjustmentOrders()
    End Function

    Private Async Function GetStockAdjustmentOrders() As Task(Of List(Of Order))
        Dim orderDataService = GetRequiredService(Of IOrderDataService)()
        Return (Await orderDataService.GetStockAdjustmentOrdersAsync(organizationId:=Z_OrganizationID)).
            OrderByDescending(Function(t) t.Created).
            ToList()
    End Function

    Private Async Function GetInventoryLocations() As Task(Of List(Of InventoryLocation))
        Dim inventoryLocationRepository = GetRequiredService(Of IInventoryLocationRepository)()
        Return Await inventoryLocationRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)
    End Function

    Private Sub gridStockAdjustmentOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridStockAdjustmentOrders.CellContentClick

    End Sub

    Private Sub gridStockAdjustmentOrders_SelectionChanged(sender As Object, e As EventArgs) 'Handles gridStockAdjustmentOrders.SelectionChanged
        Dim currentRow = gridStockAdjustmentOrders.CurrentRow
        If currentRow Is Nothing Then
            _selectedOrder = Nothing
            ReloadDisplayForm()
            Return
        End If

        _selectedOrder = CType(currentRow.DataBoundItem, Order)

        ReloadDisplayForm(order:=_selectedOrder)

    End Sub

    Private Async Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        RemoveStockAdjustmentSelectionChangedEvent()

        If String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            LinkLabelRefresh_LinkClicked(LinkLabelRefresh,
                New LinkLabelLinkClickedEventArgs(LinkLabelRefresh.Links.OfType(Of Link).FirstOrDefault()))
            Return
        End If

        Dim orderDataService = GetRequiredService(Of IOrderDataService)()
        gridStockAdjustmentOrders.DataSource = (Await orderDataService.SearchStockAdjustmentOrdersAsync(organizationId:=Z_OrganizationID,
            searchText:=txtSearch.Text)).
            OrderByDescending(Function(t) t.Created).
            ToList()

        AddStockAdjustmentSelectionChangedEvent()
        gridStockAdjustmentOrders_SelectionChanged(gridStockAdjustmentOrders, New EventArgs)
    End Sub

    Private Async Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        ToolStripButtonNew.Enabled = False

        Await FunctionUtils.TryCatchFunctionAsync("Quick create stock adjustment",
            Async Function()
                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Dim newOrder = Await orderDataService.QuickCreateStockAdjustmentOrderAsync(organizationId:=Z_OrganizationID, userId:=_userId)

                _selectedOrder = newOrder

                ReloadDisplayForm(order:=_selectedOrder)

                SplitContainer1.Panel1.Enabled = False

                DisEnableButtons(True)
            End Function)

    End Sub

    Private Async Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        SplitContainer1.Panel1.Enabled = False
        txtStockAdjustmentNo.Focus()

        Dim action As Action =
             Sub()
                 LinkLabelRefresh_LinkClicked(LinkLabelRefresh,
                    New LinkLabelLinkClickedEventArgs(LinkLabelRefresh.Links.OfType(Of Link).FirstOrDefault()))

                 If ToolStripButtonNew.Enabled = False Then ToolStripButtonNew.Enabled = True

                 If SplitContainer1.Panel1.Enabled = False Then SplitContainer1.Panel1.Enabled = True
             End Sub

        Await FunctionUtils.TryCatchFunctionAsync("Save Stock Adjustment changes",
            action:=
            Async Function()
                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Await orderDataService.SaveChangesAsync(_selectedOrder, _userId)

                MessageBox.Show(text:="Changes saved successfully!",
                    caption:="Success",
                    icon:=MessageBoxIcon.Information,
                    buttons:=MessageBoxButtons.OK)

                action()

            End Function,
            errorCallBack:=action)
    End Sub

    Private Async Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        Dim cancelButtonAction As Action =
            Sub()
                If ToolStripButtonNew.Enabled = False Then ToolStripButtonNew.Enabled = True

                If SplitContainer1.Panel1.Enabled = False Then SplitContainer1.Panel1.Enabled = True

                LinkLabelRefresh_LinkClicked(LinkLabelRefresh,
                    New LinkLabelLinkClickedEventArgs(LinkLabelRefresh.Links.OfType(Of Link).FirstOrDefault()))
            End Sub

        If _isNew Then
            SplitContainer1.Panel1.Enabled = False

            Await FunctionUtils.TryCatchFunctionAsync("Delete order after quick create stock adjustment",
                action:=
                Async Function()
                    Dim orderRepository = GetRequiredService(Of IOrderRepository)()
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
        If cboToInventory.SelectedIndex = -1 Then Return

        Dim value = cboToInventory.SelectedValue
        cboFromInventory.SelectedValue = value

        EnOrDisableAddItemButton()
    End Sub

    Private Async Sub gridStockAdjustmentOrdersFrom_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridStockAdjustmentOrdersFrom.CellContentClick

        If pickFromRackShelfColumn.Index = e.ColumnIndex Then
            Dim movementHistoryGroupByProductColorSizeModel = CType(gridStockAdjustmentOrdersFrom.Rows(e.RowIndex).DataBoundItem, MovementHistoryGroupByProductColorSizeModel)
            Dim form As New RackShelfColumnSelectorDialog(orderId:=_selectedOrder.RowID,
                inventoryLocationId:=_selectedOrder.StockAdjustmentFromInventoryLocationId,
                movementHistoryGroupByProductColorSizeModel:=movementHistoryGroupByProductColorSizeModel,
                inventoryLocationName:=cboFromInventory.Text)
            If form.ShowDialog() = DialogResult.OK Then
                For Each movementHistory In form.GeneratedMovementHistories
                    _selectedOrder.AddMovementHistories(New List(Of MovementHistory) From {movementHistory})
                Next

                ReloadDisplayForm(_selectedOrder)
            End If
        ElseIf deleteProductColorSize.Index = e.ColumnIndex Then
            Dim movementHistoryGroupByProductColorSizeModel = CType(gridStockAdjustmentOrdersFrom.Rows(e.RowIndex).DataBoundItem, MovementHistoryGroupByProductColorSizeModel)

            Await FunctionUtils.TryCatchFunctionAsync("Delete Stock Adjustment Item",
                Function()
                    _selectedOrder.DeleteMovementHistoryByProductColorSizeId(productColorSizeId:=movementHistoryGroupByProductColorSizeModel.ProductColorSizeId)

                    ReloadDisplayForm(_selectedOrder)

                    Return Task.FromResult(0)
                End Function)
        End If
    End Sub

    Private Sub gridStockAdjustmentOrdersTo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridStockAdjustmentOrdersTo.CellContentClick
        'pickToRackShelfColumn
        If pickToRackShelfColumn.Index = e.ColumnIndex Then
            Dim movementHistoryGroupByProductColorSizeModel = CType(gridStockAdjustmentOrdersTo.Rows(e.RowIndex).DataBoundItem, MovementHistoryGroupByProductColorSizeModel)
            Dim form As New RackShelfColumnSelectorDialog(orderId:=_selectedOrder.RowID,
                inventoryLocationId:=_selectedOrder.StockAdjustmentToInventoryLocationId,
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
        txtStockAdjustmentNo.DataBindings.Clear()
        txtStatus.DataBindings.Clear()
        txtTransferedBy.DataBindings.Clear()
        dtpStockAdjustmentDate.DataBindings.Clear()
        txtComments.DataBindings.Clear()

        If order Is Nothing Then
            If _selectedOrder IsNot Nothing Then _selectedOrder = Nothing

            Dim txtBoxes = SplitContainer2.Panel1.Controls.OfType(Of TextBox).ToList()
            For Each txtBox In txtBoxes
                txtBox.Clear()
            Next
            dtpStockAdjustmentDate.ResetText()
            dtpStockAdjustmentDate.Value = Date.Now

            cboFromInventory.SelectedIndex = -1
            cboToInventory.SelectedIndex = -1

            ToolStripButtonApproved.Enabled = False

            Dim emptyDataSource = MovementHistoryGroupByProductColorSizeModel.EmptyDataSource()
            gridStockAdjustmentOrdersFrom.DataSource = emptyDataSource

            gridStockAdjustmentOrdersTo.BindingContext = New BindingContext()
            gridStockAdjustmentOrdersTo.DataSource = emptyDataSource

            Return
        End If

        ToolStripButtonApproved.Enabled = order.IsOpen AndAlso order.HasMovementHistories

        txtStockAdjustmentNo.Text = order?.OrderNumber
        txtStockAdjustmentNo.DataBindings.Add("Text", order, "OrderNumber", True, DataSourceUpdateMode.OnPropertyChanged)

        txtStatus.Text = $"{order?.Status}"
        txtStatus.DataBindings.Add("Text", order, "Status", True, DataSourceUpdateMode.OnPropertyChanged)

        txtTransferedBy.Text = String.Empty
        'txtTransferedBy.DataBindings.Add("Text", order, "LoanNumber", True, DataSourceUpdateMode.OnPropertyChanged)

        dtpStockAdjustmentDate.Value = If(order?.OrderDate.Date, Date.Now)
        Dim dtpDatePickerBinding = New Binding("Value", order, "OrderDate") With {
            .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged}
        dtpStockAdjustmentDate.DataBindings.Add(dtpDatePickerBinding)

        txtComments.Text = order?.Comments
        txtComments.DataBindings.Add("Text", order, "Comments", True, DataSourceUpdateMode.OnPropertyChanged)

        Dim inventoryLocationIdFrom = If(order.StockAdjustmentFromInventoryLocationId, -1)
        Dim inventoryLocationIdTo = If(order.StockAdjustmentToInventoryLocationId, -1)

        cboFromInventory.SelectedValue = inventoryLocationIdFrom
        cboToInventory.SelectedValue = inventoryLocationIdTo

        gridStockAdjustmentOrdersFrom.DataSource = order.MovementHistoriesFromGroupByProductColorSize?.
            Select(Function(t) New MovementHistoryGroupByProductColorSizeModel(group:=t)).
            ToList()

        gridStockAdjustmentOrdersTo.BindingContext = New BindingContext()
        gridStockAdjustmentOrdersTo.DataSource = order.MovementHistoriesToGroupByProductColorSize?.
            Select(Function(t) New MovementHistoryGroupByProductColorSizeModel(group:=t)).
            ToList()
        'New(group As IGrouping(Of Integer?, MovementHistory))
    End Sub

    Private Async Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click, btnAddItem2.Click
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

            Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()
            Dim productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAsync(inventoryLocationId:=inventoryLocationIdTo)

            For Each productColorSizeModel In selectedProductColorSizeModels
                Dim newMovementHistoryFrom = MovementHistory.NewMovementHistory(organizationId:=Z_OrganizationID,
                    userId:=_userId,
                    productColorSizeID:=productColorSizeModel.ProductColorSize.RowID.Value,
                    orderId:=_selectedOrder.RowID,
                    productInventoryLocationId:=productColorSizeModel.ProductInventoryLocation.RowID.Value,
                    currentQty:=0,
                    qtyToApply:=0,
                    transactionType:=$"{OrderType.ST} - From")
                newMovementHistoryFrom.SetProductInventoryLocation(productColorSizeModel.ProductInventoryLocation)

                _selectedOrder.AddMovementHistories(New List(Of MovementHistory) From {newMovementHistoryFrom})

                Dim toProductInventoryLocation = productInventoryLocations.
                    Where(Function(t) t.ProductColorSizeID = productColorSizeModel.ProductColorSize.RowID.Value).
                    Where(Function(t) t.RackShelfColumn.InventoryLocationID = inventoryLocationIdTo).
                    FirstOrDefault()
                Dim newMovementHistoryTo = MovementHistory.NewMovementHistory(organizationId:=Z_OrganizationID,
                    userId:=_userId,
                    productColorSizeID:=productColorSizeModel.ProductColorSize.RowID.Value,
                    orderId:=_selectedOrder.RowID,
                    productInventoryLocationId:=toProductInventoryLocation.RowID.Value,
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
        RemoveStockAdjustmentSelectionChangedEvent()

        LinkLabelRefresh.Enabled = False
        Await LoadStockAdjustmentOrders()
        LinkLabelRefresh.Enabled = True

        AddStockAdjustmentSelectionChangedEvent()
        gridStockAdjustmentOrders_SelectionChanged(gridStockAdjustmentOrders, New EventArgs)
    End Sub

    Private Sub AddStockAdjustmentSelectionChangedEvent()
        AddHandler gridStockAdjustmentOrders.SelectionChanged, AddressOf gridStockAdjustmentOrders_SelectionChanged
    End Sub

    Private Sub RemoveStockAdjustmentSelectionChangedEvent()
        RemoveHandler gridStockAdjustmentOrders.SelectionChanged, AddressOf gridStockAdjustmentOrders_SelectionChanged
    End Sub

    Private Sub ToolStripButtonNew_EnabledChanged(sender As Object, e As EventArgs) Handles ToolStripButtonNew.EnabledChanged
        _isNew = Not ToolStripButtonNew.Enabled
    End Sub

    Private Async Sub ToolStripButtonApproved_Click(sender As Object, e As EventArgs) Handles ToolStripButtonApproved.Click
        Dim inventoryLocationIdTo = CInt(cboToInventory.SelectedValue)

        If inventoryLocationIdTo = 0 Then

            MessageBox.Show(text:="Please select a value for `Inventory Location`.",
                caption:="Select Inventory Location",
                icon:=MessageBoxIcon.Error,
                buttons:=MessageBoxButtons.OK)
            Return
        End If

        Dim prompt = MessageBox.Show(text:="Are you sure you want to `Approve` this Stock Adjustment?", caption:="Approve Stock Adjustment", icon:=MessageBoxIcon.Question, buttons:=MessageBoxButtons.YesNoCancel)
        If Not prompt = DialogResult.Yes Then Return

        SplitContainer1.Panel1.Enabled = False

        Dim action As Action =
             Sub()
                 If ToolStripButtonNew.Enabled = False Then ToolStripButtonNew.Enabled = True

                 If SplitContainer1.Panel1.Enabled = False Then SplitContainer1.Panel1.Enabled = True

                 LinkLabelRefresh_LinkClicked(LinkLabelRefresh,
                    New LinkLabelLinkClickedEventArgs(LinkLabelRefresh.Links.OfType(Of Link).FirstOrDefault()))

                 'ReloadDisplayForm(order:=_selectedOrder)
             End Sub

        Await FunctionUtils.TryCatchFunctionAsync("Approve Stock Adjustment",
            Async Function()
                Dim orderDataService = GetRequiredService(Of IOrderDataService)()

                Await orderDataService.ApproveStockAdjustment(order:=_selectedOrder, userId:=_userId)

                MessageBox.Show(text:="Stock Transfer approved!",
                    caption:="Approved",
                    icon:=MessageBoxIcon.Information,
                    buttons:=MessageBoxButtons.OK)

                '_selectedOrder = Await orderDataService.GetOrderAsync(order:=_selectedOrder)

                action()

            End Function,
            errorCallBack:=action)

        SplitContainer1.Panel1.Enabled = True
    End Sub

    Private Sub SplitContainer1_Panel1_EnabledChanged(sender As Object, e As EventArgs) Handles SplitContainer1.Panel1.EnabledChanged
        Dim enabled = SplitContainer1.Panel1.Enabled

        DisEnableButtons(enabled)
    End Sub

    Private Sub DisEnableButtons(enabled As Boolean)

        Dim names = {ToolStripButtonSave.Name,
                    ToolStripButtonApproved.Name,
                    ToolStripButtonCancel.Name}

        Dim toolStripButtons = ToolStrip1.Items.OfType(Of ToolStripButton).
            Where(Function(t) names.Contains(t.Name)).
            ToList()
        For Each button In toolStripButtons
            button.Enabled = enabled
        Next

        If _selectedOrder IsNot Nothing AndAlso _selectedOrder.IsApproved Then ToolStripButtonApproved.Enabled = False
    End Sub

    Private Sub gridStockAdjustmentOrders_DataSourceChanged(sender As Object, e As EventArgs) Handles gridStockAdjustmentOrders.DataSourceChanged
        If If(gridStockAdjustmentOrders.Rows?.Count(), 0) = 0 Then ReloadDisplayForm()
    End Sub

    Private Sub gridStockAdjustmentOrdersFrom_SelectionChanged(sender As Object, e As EventArgs) Handles gridStockAdjustmentOrdersFrom.SelectionChanged

    End Sub

    Private Sub btnAddItem_EnabledChanged(sender As Object, e As EventArgs) Handles btnAddItem.EnabledChanged
        btnAddItem2.Enabled = btnAddItem.Enabled
    End Sub

End Class