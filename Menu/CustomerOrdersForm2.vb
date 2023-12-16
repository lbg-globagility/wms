Option Strict On

Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class CustomerOrdersForm2

    Private Class InvetoryTypeModel
        Public ReadOnly Property Name As String
        Public ReadOnly Property Value As Object

        Public Sub New(t As Object)
            _Name = $"{t}"
            _Value = t
        End Sub

    End Class

    Private ReadOnly _noAgent As Contact = Contact.BlankAgent(organizationId:=Z_OrganizationID)
    Private ReadOnly _userId As Integer
    Private _selectedOrder As Order

    Public Sub New(userId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _userId = userId
    End Sub

    Private Async Sub CustomerOrdersForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridOrders.AutoGenerateColumns = False
        gridOrderItems.AutoGenerateColumns = False

        LoadInventorySourceType()

        Await LoadInventoryLocationsAsync()
        Await LoadCustomersAsync()
        Await LoadAgentsAsync()

        Await LoadCustomerOrdersAsync()
    End Sub

    Private Async Function LoadCustomerOrdersAsync() As Task
        Dim orderDataService = GetRequiredService(Of IOrderDataService)()
        Dim result = Await orderDataService.GetCustomerOrdersAsync(organizationId:=Z_OrganizationID)

        gridOrders.DataSource = result.
            OrderByDescending(Function(t) t.Created).
            ToList()
    End Function

    Private Sub LoadInventorySourceType()
        cboCustomerOrderType.ValueMember = "Value"
        cboCustomerOrderType.DisplayMember = "Name"

        Dim customerOrderTypes = InventoryLocation.GetTypes.
            OfType(Of Object).
            Select(Function(t) New InvetoryTypeModel(t)).
            ToList()
        cboCustomerOrderType.DataSource = customerOrderTypes
    End Sub

    Private Async Function LoadInventoryLocationsAsync() As Task
        Dim inventoryLocationRepository = GetRequiredService(Of IInventoryLocationRepository)()
        Dim inventoryLocations = Await inventoryLocationRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)

        cboInventoryLocation.ValueMember = "RowID"
        cboInventoryLocation.DisplayMember = "Name"
        cboInventoryLocation.DataSource = inventoryLocations.
            OrderByDescending(Function(t) t.IsMainWarehouse).
            ThenBy(Function(t) t.Name).
            ToList()
    End Function

    Private Async Function LoadCustomersAsync() As Task
        Dim accountDataService = GetRequiredService(Of IAccountDataService)()
        Dim accounts = Await accountDataService.GetManyByOrganizationIdAndTypeAsync(organizationId:=Z_OrganizationID, type:=AccountType.Customer)

        cboCustomerName.ValueMember = "RowID"
        cboCustomerName.DisplayMember = "CompanyName"
        cboCustomerName.DataSource = accounts.
            OrderBy(Function(t) t.CompanyName).
            ToList()
    End Function

    Private Async Function LoadAgentsAsync() As Task
        Dim contactDataService = GetRequiredService(Of IContactDataService)()

        Dim agents = Await contactDataService.GetAgentsAsync(organizationId:=Z_OrganizationID)

        Dim agentDataSource = New List(Of Contact) From {_noAgent}
        agentDataSource.AddRange(agents.OrderBy(Function(t) t.FullNameLastNameFirst).ToList())

        cboAgent.ValueMember = "RowID"
        cboAgent.DisplayMember = "FullNameLastNameFirst"
        cboAgent.DataSource = agentDataSource
    End Function

    Private Sub btnAddOrderItem_Click(sender As Object, e As EventArgs) Handles btnAddOrderItem.Click
        Dim inventoryLocationId = CInt(cboInventoryLocation.SelectedValue)

        Dim hasOrder As Boolean = _selectedOrder IsNot Nothing

        Dim form As New ProductColorSizeSelectorDialog(inventoryLocationId:=inventoryLocationId)
        If hasOrder Then form.ProductColorSizeExceptionIds = Nothing

        'gridOrderItems

        If hasOrder AndAlso form.ShowDialog() = DialogResult.OK Then
            Dim selectedProductColorSizeModels = form.SelectedProductColorSizeModels

        End If
    End Sub

    Private Function GetOrderItemModel(gridRow As DataGridViewRow) As OrderItemModel
        Return CType(gridRow.DataBoundItem, OrderItemModel)
    End Function

    Private Function GetOrderItemModels() As List(Of OrderItemModel)
        If If(gridOrderItems.Rows?.Count(), 0) > 0 Then
            Return Enumerable.Empty(Of OrderItemModel).ToList()
        End If

        Return gridOrderItems.Rows.OfType(Of DataGridViewRow).
            Select(Function(t) GetOrderItemModel(t)).
            ToList()
    End Function

    Private Sub cboCustomerOrderType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomerOrderType.SelectedIndexChanged
        'If cboCustomerOrderType.SelectedValue IsNot Nothing Then errProvider.SetError(cboCustomerOrderType, String.Empty)

        If ToolStripButtonNew.Enabled AndAlso Not cboCustomerOrderType.SelectedIndex = -1 Then Return

        Dim inventoryLocationType = CType(cboCustomerOrderType.SelectedValue, InventoryLocationType)

        Dim dataSource = cboInventoryLocation.Items.
            OfType(Of Object).
            Select(Function(t) CType(t, InventoryLocation)).
            Where(Function(t) t.Type = inventoryLocationType).
            ToList()

        If Not dataSource.Any() Then
            MessageBox.Show(text:=$"No Inventory Location for type `{inventoryLocationType}`.{Environment.NewLine}{Environment.NewLine}You need to create a new Inventory Location with type `{inventoryLocationType}`.{Environment.NewLine}{Environment.NewLine}Go to `Menu` > `Inventory Management` > `(L) Inventory Locations`",
                caption:="No Inventory Location",
                icon:=MessageBoxIcon.Error,
                buttons:=MessageBoxButtons.OK)

            cboCustomerOrderType.SelectedIndex = -1
            Return
        End If

        If dataSource.Count() > 1 Then
            Dim form = New CustomerOrderInventoryLocationSelectorDialog(inventoryLocations:=dataSource)
            If form.ShowDialog() = DialogResult.OK Then
                cboInventoryLocation.SelectedValue = form.InventoryLocationId
            Else
                cboCustomerOrderType.SelectedIndex = -1
            End If
        Else
            cboInventoryLocation.SelectedValue = dataSource.FirstOrDefault().RowID.Value
        End If
    End Sub

    Private Sub cboCustomerName_DropDown(sender As Object, e As EventArgs) Handles cboCustomerName.DropDown

        Dim organizations = CType(cboCustomerName.DataSource, List(Of Account))

        If Not organizations.Any() Then Return

        Static font As Font = cboCustomerName.Font
        Dim grp As Graphics = cboCustomerName.CreateGraphics()

        Dim vertScrollBarWidth As Integer = If(cboCustomerName.Items.Count > cboCustomerName.MaxDropDownItems, SystemInformation.VerticalScrollBarWidth, 0)

        Dim longestWord = organizations.
            OrderByDescending(Function(o) o.CompanyName.Length).
            Select(Function(o) o.CompanyName).
            FirstOrDefault()

        Dim width = CInt(grp.MeasureString(longestWord, font).Width) + vertScrollBarWidth

        cboCustomerName.DropDownWidth = width + 8
    End Sub

    Private Sub gridOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridOrders.CellContentClick
        Dim currentRow = gridOrders.CurrentRow

        If currentRow Is Nothing Then
            ReloadDisplayForm()
            Return
        End If

        Dim selectedOrder = CType(currentRow.DataBoundItem, Order)

        ReloadDisplayForm(selectedOrder)
    End Sub

    Private Sub gridOrders_SelectionChanged(sender As Object, e As EventArgs) Handles gridOrders.SelectionChanged
        Dim currentRow = gridOrders.CurrentRow
        If currentRow Is Nothing Then
            _selectedOrder = Nothing
            ReloadDisplayForm()
            Return
        End If

        _selectedOrder = CType(currentRow.DataBoundItem, Order)

        ReloadDisplayForm(order:=_selectedOrder)

    End Sub

    Private Sub gridOrderItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridOrderItems.CellContentClick

    End Sub

    Private Sub gridOrderItems_SelectionChanged(sender As Object, e As EventArgs) Handles gridOrderItems.SelectionChanged
        Dim currentRow = gridOrderItems.CurrentRow

        If currentRow Is Nothing Then Return

        Dim selectedOrderItem = CType(currentRow.DataBoundItem, OrderItem)

    End Sub

    Private Async Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        ToolStripButtonNew.Enabled = False

        Await FunctionUtils.TryCatchFunctionAsync("Quick create Customer Order",
            Async Function()
                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Dim newOrder = Await orderDataService.QuickCreateCustomerOrderAsync(organizationId:=Z_OrganizationID, userId:=_userId)

                _selectedOrder = newOrder

                ReloadDisplayForm(order:=_selectedOrder)

                'SplitContainer1.Panel1.Enabled = False

                'DisEnableButtons(True)
            End Function)
    End Sub

    Private Sub ToolStripButtonNew_EnabledChanged(sender As Object, e As EventArgs) Handles ToolStripButtonNew.EnabledChanged
        SplitContainer1.Panel1.Enabled = ToolStripButtonNew.Enabled
    End Sub

    Private Sub ReloadDisplayForm(Optional order As Order = Nothing)
        txtOrderNumber.Text = String.Empty
        txtReferenceNumber.Text = String.Empty
        txtStatus.Text = String.Empty
        dtpOrderDate.Value = DateTime.Now
        cboCustomerName.Text = String.Empty
        cboAgent.Text = String.Empty
        cboCustomerOrderType.Text = String.Empty
        txtDRNumber.Text = String.Empty
        txtDeliveryAddress.Text = String.Empty

        dtpDateSubmitted.Value = DateTime.Now
        dtpDateSubmitted.Checked = False

        dtpDeliveryDate.Value = DateTime.Now
        dtpDeliveryDate.Checked = False

        dtpEndDate.Value = DateTime.Now
        dtpEndDate.Checked = False

        txtComments.Text = String.Empty

        If order Is Nothing Then

            Return
        End If

        txtOrderNumber.Text = order.OrderNumber
        txtReferenceNumber.Text = order.ReferenceNumber
        txtStatus.Text = $"{order.Status}"
        dtpOrderDate.Value = If(order.OrderDate?.Date, DateTime.Now)
        cboCustomerName.SelectedValue = If(order.AccountID, 0)
        cboAgent.SelectedValue = If(order.AgentID, 0)
        cboInventoryLocation.SelectedValue = If(order.InventoryLocationID, -1)
        cboCustomerOrderType.SelectedValue = If(order.InventoryLocation?.Type, InventoryLocationType.Main)
        txtDRNumber.Text = order.DRNumber
        txtDeliveryAddress.Text = order.CustomerAddress

        dtpDateSubmitted.Value = If(order.DateSubmitted?.Date, DateTime.Now)
        dtpDateSubmitted.Checked = False

        dtpDeliveryDate.Value = If(order.TargetDate?.Date, DateTime.Now)
        dtpDeliveryDate.Checked = False

        dtpEndDate.Value = If(order.EndDate?.Date, DateTime.Now)
        dtpEndDate.Checked = False

        txtComments.Text = order.Comments
    End Sub

    Private Async Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        Dim afterTaskMethod =
            Async Function()
                ToolStripButtonNew.Enabled = True

                Await LoadCustomerOrdersAsync()

                Return Task.FromResult(0)
            End Function

        Dim continuationAction As Action(Of Object) = Function() afterTaskMethod()

        Await FunctionUtils.TryCatchFunctionAsync("Save changes from Customer Order",
            Async Function()
                With _selectedOrder
                    .OrderNumber = txtOrderNumber.Text
                    .ReferenceNumber = txtReferenceNumber.Text
                    Dim orderStatus As OrderStatus
                    .Status = If([Enum].TryParse(txtStatus.Text, result:=orderStatus), orderStatus, OrderStatus.Open)
                    .OrderDate = dtpOrderDate.Value.Date
                    .AccountID = CInt(cboCustomerName.SelectedValue)
                    .AgentID = CInt(cboAgent.SelectedValue)
                    .InventoryLocationID = CInt(cboInventoryLocation.SelectedValue)
                    .DRNumber = txtDRNumber.Text
                    .CustomerAddress = txtDeliveryAddress.Text
                    .DateSubmitted = dtpDateSubmitted.Value.Date
                    .TargetDate = dtpDeliveryDate.Value.Date
                    .EndDate = dtpEndDate.Value.Date
                    .Comments = txtComments.Text
                End With

                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Await orderDataService.SaveChangesAsync(order:=_selectedOrder, userId:=Z_UserID)

                MessageBox.Show(text:="Changes saved successfully!",
                    caption:="Success",
                    icon:=MessageBoxIcon.Information,
                    buttons:=MessageBoxButtons.OK)
            End Function,
            errorCallBack:=afterTaskMethod).
            ContinueWith(continuationAction:=continuationAction, scheduler:=TaskScheduler.FromCurrentSynchronizationContext)
    End Sub

    Private Sub ToolStripButtonApproved_Click(sender As Object, e As EventArgs) Handles ToolStripButtonApproved.Click

    End Sub

    Private Async Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        Dim afterTaskMethod =
            Async Function()
                ToolStripButtonNew.Enabled = True

                Await LoadCustomerOrdersAsync()

                Return Task.FromResult(0)
            End Function

        Dim continuationAction As Action(Of Object) = Function() afterTaskMethod()

        Await FunctionUtils.TryCatchFunctionAsync("Save changes from Customer Order",
            Async Function()
                If ToolStripButtonNew.Enabled Then Return

                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Await orderDataService.SaveManyAsync(userId:=Z_UserID, deleted:=New List(Of Order) From {_selectedOrder})
            End Function,
            errorCallBack:=afterTaskMethod).
            ContinueWith(continuationAction, scheduler:=TaskScheduler.FromCurrentSynchronizationContext)
    End Sub

    Private Sub ToolStripButtonClose_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClose.Click
        Close()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomerName.SelectedIndexChanged
        If ToolStripButtonNew.Enabled Then Return

        Dim customers = CType(cboCustomerName.DataSource, List(Of Account))
        Dim id = CInt(cboCustomerName.SelectedValue)
        Dim customer = customers.FirstOrDefault(Function(t) t.RowID.Value = id)

        If customer Is Nothing Then Return

        txtDeliveryAddress.Text = customer.FullAddress
        cboAgent.SelectedValue = If(customer.AgentID, 0)
    End Sub

    Private Sub cboInventoryLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInventoryLocation.SelectedIndexChanged
        Dim id = CInt(cboInventoryLocation.SelectedValue)
        btnAddOrderItem.Enabled = id > 0
    End Sub

End Class