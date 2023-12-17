Option Strict On

Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Desktop.Utilities
Imports WarehouseManagementSystem.Infrastructure.Data.Services
Imports WarehouseManagementSystem.Utilities.Extensions

Public Class CustomerOrdersForm2

    Private Class InvetoryTypeModel
        Public ReadOnly Property Name As String
        Public ReadOnly Property Value As InventoryLocationType

        Public Sub New(inventoryLocationType As InventoryLocationType)
            _Name = $"{inventoryLocationType}"
            _Value = inventoryLocationType
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
            Select(Function(t) New InvetoryTypeModel(CType(t, InventoryLocationType))).
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

    Private Async Sub btnAddOrderItem_Click(sender As Object, e As EventArgs) Handles btnAddOrderItem.Click
        Dim inventoryLocationId = CInt(cboInventoryLocation.SelectedValue)

        Dim hasOrder As Boolean = _selectedOrder IsNot Nothing

        Dim orderItemModels = GetOrderItemModels()

        Dim form As New ProductColorSizeSelectorDialog(inventoryLocationId:=inventoryLocationId)
        If hasOrder Then form.ProductColorSizeExceptionIds = orderItemModels.
            Select(Function(t) t.ProductColorSizeId.Value).
            ToList()

        If hasOrder AndAlso form.ShowDialog() = DialogResult.OK Then
            Dim selectedProductColorSizeModels = form.SelectedProductColorSizeModels

            Dim orderItemList As New List(Of OrderItem)

            For Each item In selectedProductColorSizeModels
                Dim orderItemModel = orderItemModels.FirstOrDefault(Function(t) If(t.ProductColorSizeId, 0) = item.ProductColorSizeId)

                Dim thisOrderItem = OrderItem.NewCustomerOrderItem(organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    qtyOrdered:=If(orderItemModel?.QuantityOrdered, 0),
                    srp:=If(orderItemModel?.UnitPrice, If(item.UnitPriceOfUOM2, 0)),
                    unitOfMeasure:=StringExtensions.IfNullOrEmpty(orderItemModel?.UnitOfMeasure, item.UnitOfMeasure2),
                    sku:=StringExtensions.IfNullOrEmpty(orderItemModel?.Sku, item.Sku),
                    sku2:=StringExtensions.IfNullOrEmpty(orderItemModel?.Sku2, item.Sku2),
                    productColorSizeId:=If(orderItemModel?.ProductColorSizeId, item.ProductColorSizeId),
                    productInventoryLocationId:=If(orderItemModel?.ProductInventoryLocationId, item.ProductInventoryLocation.RowID.Value))

                orderItemList.Add(thisOrderItem)
            Next

            _selectedOrder.AddCustomerOrderItems(orderItemList)

            Await ReloadDisplayForm(_selectedOrder)
        End If
    End Sub

    Private Function GetOrderItemModel(gridRow As DataGridViewRow) As OrderItemModel
        Return CType(gridRow.DataBoundItem, OrderItemModel)
    End Function

    Private Function GetOrderItemModels() As List(Of OrderItemModel)
        If Not If(gridOrderItems.Rows?.Count(), 0) > 0 Then
            Return Enumerable.Empty(Of OrderItemModel).ToList()
        End If

        Return gridOrderItems.Rows.OfType(Of DataGridViewRow).
            Select(Function(t) GetOrderItemModel(t)).
            ToList()
    End Function

    Private Sub cboCustomerOrderType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomerOrderType.SelectedIndexChanged
        cboCustomerOrderType_SelectedValueChanged(sender, e)
    End Sub

    Private Sub cboCustomerOrderType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCustomerOrderType.SelectedValueChanged
        'If cboCustomerOrderType.SelectedValue IsNot Nothing Then errProvider.SetError(cboCustomerOrderType, String.Empty)

        If ToolStripButtonNew.Enabled AndAlso Not cboCustomerOrderType.SelectedIndex = -1 Then Return

        Dim inventoryLocationType = CType(cboCustomerOrderType.SelectedValue, InventoryLocationType)

        Dim source = cboInventoryLocation.Items?.
            OfType(Of Object)
        If Not If(source?.Any(), False) Then Return

        Dim dataSource = source?.
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

    Private Async Sub gridOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridOrders.CellContentClick
        Dim currentRow = gridOrders.CurrentRow

        If currentRow Is Nothing Then
            Await ReloadDisplayForm()
            Return
        End If

        Dim selectedOrder = CType(currentRow.DataBoundItem, Order)

        Await ReloadDisplayForm(selectedOrder)
    End Sub

    Private Async Sub gridOrders_SelectionChanged(sender As Object, e As EventArgs) Handles gridOrders.SelectionChanged
        Dim currentRow = gridOrders.CurrentRow
        If currentRow Is Nothing Then
            _selectedOrder = Nothing
            Await ReloadDisplayForm()
            Return
        End If

        _selectedOrder = CType(currentRow.DataBoundItem, Order)

        Await ReloadDisplayForm(order:=_selectedOrder)

    End Sub

    Private Sub gridOrderItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridOrderItems.CellContentClick

    End Sub

    Private Sub gridOrderItems_SelectionChanged(sender As Object, e As EventArgs) Handles gridOrderItems.SelectionChanged
        Dim currentRow = gridOrderItems.CurrentRow

        If currentRow Is Nothing Then Return

        Dim selectedOrderItem = GetOrderItemModel(currentRow)

    End Sub

    Private Sub gridOrderItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles gridOrderItems.CellEndEdit
        Dim currentRow = gridOrderItems.CurrentRow

        If currentRow Is Nothing Then Return

        gridOrderItems.Refresh()

        Dim selectedOrderItem = GetOrderItemModel(currentRow)

        selectedOrderItem.Refresh(orderItemModel:=selectedOrderItem)

    End Sub

    Private Async Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        ToolStripButtonNew.Enabled = False

        Dim afterTaskMethod =
            Async Function()
                Return Task.FromResult(0)
            End Function

        Dim continuationAction As Action(Of Object) = Function() afterTaskMethod()

        Await FunctionUtils.TryCatchFunctionAsync("Quick create Customer Order",
            Async Function()
                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Dim newOrder = Await orderDataService.QuickCreateCustomerOrderAsync(organizationId:=Z_OrganizationID, userId:=_userId)

                _selectedOrder = newOrder

                Await ReloadDisplayForm(order:=_selectedOrder)
            End Function,
            errorCallBack:=afterTaskMethod).
            ContinueWith(continuationAction:=continuationAction, scheduler:=TaskScheduler.FromCurrentSynchronizationContext)
    End Sub

    Private Sub ToolStripButtonNew_EnabledChanged(sender As Object, e As EventArgs) Handles ToolStripButtonNew.EnabledChanged
        SplitContainer1.Panel1.Enabled = ToolStripButtonNew.Enabled
    End Sub

    Private Async Function ReloadDisplayForm(Optional order As Order = Nothing) As Task(Of Integer)
        'txtOrderNumber.Text = String.Empty
        'txtReferenceNumber.Text = String.Empty
        'txtStatus.Text = String.Empty
        'dtpOrderDate.Value = Date.Now
        'cboCustomerName.Text = String.Empty
        'cboAgent.Text = String.Empty
        'cboCustomerOrderType.Text = String.Empty
        'txtDRNumber.Text = String.Empty
        'txtDeliveryAddress.Text = String.Empty

        'dtpDateSubmitted.Value = Date.Now
        'dtpDateSubmitted.Checked = False

        'dtpDeliveryDate.Value = Date.Now
        'dtpDeliveryDate.Checked = False

        'dtpEndDate.Value = Date.Now
        'dtpEndDate.Checked = False

        'txtComments.Text = String.Empty

        gridOrderItems.DataSource = Enumerable.Empty(Of OrderItemModel)()

        For Each textBox In SplitContainer2.Panel1.Controls.OfType(Of Control).OfType(Of TextBox)
            textBox.DataBindings.Clear()
        Next
        For Each comboBox In SplitContainer2.Panel1.Controls.OfType(Of Control).OfType(Of ComboBox)
            comboBox.DataBindings.Clear()
        Next
        For Each dateTimePicker In SplitContainer2.Panel1.Controls.OfType(Of Control).OfType(Of DateTimePicker)
            dateTimePicker.DataBindings.Clear()
        Next

        If order Is Nothing Then

            Return 0
        End If

        'txtOrderNumber.Text = order.OrderNumber
        txtOrderNumber.DataBindings.Add("Text", order, "OrderNumber", True, DataSourceUpdateMode.Never)

        'txtReferenceNumber.Text = order.ReferenceNumber
        txtReferenceNumber.DataBindings.Add("Text", order, "ReferenceNumber", True, DataSourceUpdateMode.OnPropertyChanged)

        'txtStatus.Text = $"{order.Status}"
        txtStatus.DataBindings.Add("Text", order, "Status", True, DataSourceUpdateMode.Never)

        'dtpOrderDate.Value = If(order.OrderDate?.Date, Date.Now)
        Dim dtpOrderDateBinding = New Binding("Value", order, "OrderDate") With {
            .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged}
        dtpOrderDate.DataBindings.Add(dtpOrderDateBinding)

        'cboCustomerName.SelectedValue = If(order.AccountID, 0)
        cboCustomerName.DataBindings.Add("SelectedValue", order, "AccountID", True, DataSourceUpdateMode.OnPropertyChanged)

        'cboAgent.SelectedValue = If(order.AgentID, 0)
        cboAgent.DataBindings.Add("SelectedValue", order, "AgentID", True, DataSourceUpdateMode.OnPropertyChanged)

        'cboInventoryLocation.SelectedValue = If(order.InventoryLocationID, -1)
        cboInventoryLocation.DataBindings.Add("SelectedValue", order, "InventoryLocationID", True, DataSourceUpdateMode.OnPropertyChanged)

        cboCustomerOrderType.SelectedValue = If(order.InventoryLocation?.Type, InventoryLocationType.Main)

        'txtDRNumber.Text = order.DRNumber
        txtDRNumber.DataBindings.Add("Text", order, "DRNumber", True, DataSourceUpdateMode.OnPropertyChanged)

        'txtDeliveryAddress.Text = order.CustomerAddress
        txtDeliveryAddress.DataBindings.Add("Text", order, "CustomerAddress", True, DataSourceUpdateMode.OnPropertyChanged)

        dtpDateSubmitted.Value = If(order.DateSubmitted?.Date, Date.Now)
        dtpDateSubmitted.Checked = False

        dtpDeliveryDate.Value = If(order.TargetDate?.Date, Date.Now)
        dtpDeliveryDate.Checked = False

        dtpEndDate.Value = If(order.EndDate?.Date, Date.Now)
        dtpEndDate.Checked = False

        'txtComments.Text = order.Comments
        txtComments.DataBindings.Add("Text", order, "Comments", True, DataSourceUpdateMode.OnPropertyChanged)

        Dim productColorSizeIds = order.OrderItems?.Select(Function(oi) oi.ProductColorSizeID.Value).ToArray()

        Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()
        Dim productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAndProductColorSizeIdsAsync(inventoryLocationId:=CInt(cboInventoryLocation.SelectedValue), productColorSizeIds:=productColorSizeIds)

        Dim getOrderItemModel =
            Function(orderItem As OrderItem)
                Dim productInventoryLocation = productInventoryLocations.
                    Where(Function(t) t.ProductColorSizeID = orderItem.ProductColorSizeID.Value).
                    FirstOrDefault()
                If orderItem.ProductColorSize Is Nothing Then Return New OrderItemModel(orderItem:=orderItem, productInventoryLocation:=productInventoryLocation)

                Return New OrderItemModel(orderItem:=orderItem)
            End Function

        gridOrderItems.DataSource = If(_selectedOrder.OrderItems?.Select(Function(t) getOrderItemModel(t)).ToList(),
            Enumerable.Empty(Of OrderItemModel)())

        Return 0
    End Function

    Private Async Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        ToolStripButtonSave.Enabled = False

        Dim afterTaskMethod =
            Async Function()
                ToolStripButtonNew.Enabled = True

                Await LoadCustomerOrdersAsync()

                ToolStripButtonSave.Enabled = True

                Return Task.FromResult(0)
            End Function

        Dim continuationAction As Action(Of Object) = Function() afterTaskMethod()

        Await FunctionUtils.TryCatchFunctionAsync("Save changes from Customer Order",
            Async Function()
                'With _selectedOrder
                '    .OrderNumber = txtOrderNumber.Text
                '    .ReferenceNumber = txtReferenceNumber.Text
                '    Dim orderStatus As OrderStatus
                '    .Status = If([Enum].TryParse(txtStatus.Text, result:=orderStatus), orderStatus, OrderStatus.Open)
                '    .OrderDate = dtpOrderDate.Value.Date
                '    .AccountID = CInt(cboCustomerName.SelectedValue)
                '    .AgentID = CInt(cboAgent.SelectedValue)
                '    .InventoryLocationID = CInt(cboInventoryLocation.SelectedValue)
                '    .DRNumber = txtDRNumber.Text
                '    .CustomerAddress = txtDeliveryAddress.Text
                '    .DateSubmitted = dtpDateSubmitted.Value.Date
                '    .TargetDate = dtpDeliveryDate.Value.Date
                '    .EndDate = dtpEndDate.Value.Date
                '    .Comments = txtComments.Text
                'End With

                _selectedOrder.CustomerName = cboCustomerName.Text

                Dim orderItemList = GetOrderItemModels().
                    Select(Function(t) t.OrderItem).
                    ToList()
                _selectedOrder.AddCustomerOrderItems(orderItemList)
                _selectedOrder.RecomputeTotalAmount()

                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Await orderDataService.SaveManyCustomerOrderAsync(userId:=Z_UserID,
                    updated:=New List(Of Order) From {_selectedOrder})

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
        ToolStripButtonCancel.Enabled = False

        Dim afterTaskMethod =
            Async Function()
                ToolStripButtonNew.Enabled = True

                Await LoadCustomerOrdersAsync()

                ToolStripButtonCancel.Enabled = True

                Return Task.FromResult(0)
            End Function

        Dim continuationAction As Action(Of Object) = Function() afterTaskMethod()

        Await FunctionUtils.TryCatchFunctionAsync("Save changes from Customer Order",
            Async Function()
                If ToolStripButtonNew.Enabled Then Return

                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Await orderDataService.SaveManyCustomerOrderAsync(userId:=Z_UserID, deleted:=New List(Of Order) From {_selectedOrder})
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

    End Sub

    Private Sub cboInventoryLocation_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboInventoryLocation.SelectedValueChanged
        Dim id = CInt(cboInventoryLocation.SelectedValue)
        btnAddOrderItem.Enabled = id > 0
    End Sub

End Class