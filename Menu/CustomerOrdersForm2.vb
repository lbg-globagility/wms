Option Strict On

Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Helpers
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Desktop.Utilities
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

    Private ReadOnly _userId As Integer
    Private _selectedOrder As Order
    Private ReadOnly DEFAULT_PAGEOPTIONS As PageOptions = New PageOptions(pageIndex:=0, pageSize:=20, sort:="Created", direction:="desc")
    Private _pageOptions As PageOptions = DEFAULT_PAGEOPTIONS

    Public Sub New(userId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _userId = userId

        InitButtonClearSearch()
    End Sub

    Private Async Sub CustomerOrdersForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridOrders.AutoGenerateColumns = False
        gridOrderItems.AutoGenerateColumns = False

        Await ScrutinateUserPrivilegeAsync()

        LoadInventorySourceType()

        Await LoadInventoryLocationsAsync()
        Await LoadCustomersAsync()
        cboCustomerName_DropDown(cboCustomerName, New EventArgs())
        Await LoadAgentsAsync()

        Await LoadCustomerOrdersAsync()

        gridOrders_SelectionChanged(gridOrders, New EventArgs())
        AddHandler gridOrders.SelectionChanged, AddressOf gridOrders_SelectionChanged

    End Sub

    Private Sub InitButtonClearSearch()
        With btnClearSearch
            .Size = New Size(width:=TextBoxSearch.ClientSize.Height, height:=TextBoxSearch.ClientSize.Height)
            .Location = New Point(x:=TextBoxSearch.ClientSize.Width - (btnClearSearch.Size.Width - 1), y:=0)
            .Font = New Font("Segoe UI", 7.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            .Cursor = Cursors.Default
        End With

        TextBoxSearch.Controls.Add(btnClearSearch)

        TextBoxSearch_TextChanged(TextBoxSearch, New EventArgs())
    End Sub

    Private Async Function ScrutinateUserPrivilegeAsync() As Task
        Dim positionViewDataService = GetRequiredService(Of IPositionViewDataService)()
        Dim positionView = Await positionViewDataService.GetByUserIdAndViewNameAsync(organizationId:=Z_OrganizationID,
            userId:=_userId,
            viewName:=View.CUSTOMER_ORDERS_VIEW)
        If positionView.Restricted Then
            MessageBox.Show(text:="The user has insufficient privilege to access this module.",
                caption:="Insufficient Privilege",
                icon:=MessageBoxIcon.Error,
                buttons:=MessageBoxButtons.OK)

            Close()

            Return
        ElseIf positionView.ReadOnly Then
            Dim toolStripItems = ToolStrip1.Items.
                OfType(Of ToolStripItem).
                Where(Function(t) Not t.Name = ToolStripButtonClose.Name).
                ToList()

            For Each item In toolStripItems
                item.Visible = False
            Next

            Return
        End If

        ToolStripButtonNew.Visible = Not positionView.ReadOnly AndAlso positionView.Creates
        ToolStripButtonSave.Visible = Not positionView.ReadOnly AndAlso (positionView.Updates Or positionView.Creates)
        ToolStripButtonApproved.Visible = Not positionView.ReadOnly AndAlso positionView.Updates
        ToolStripButtonRevoke.Visible = Not positionView.ReadOnly AndAlso positionView.Updates
    End Function

    Private Async Function LoadCustomerOrdersAsync() As Task(Of Integer)
        Dim orderDataService = GetRequiredService(Of IOrderDataService)()
        Dim result = Await orderDataService.GetCustomerOrdersAsync(
            organizationId:=Z_OrganizationID,
            pageOptions:=_pageOptions,
            searchText:=TextBoxSearch.Text)

        gridOrders.DataSource = result.Items.
            ToList()

        Return result.TotalCount
    End Function

    Private Sub LoadInventorySourceType()
        cboCustomerOrderType.ValueMember = "Value"
        cboCustomerOrderType.DisplayMember = "Name"

        Dim customerOrderTypes = InventoryLocation.GetTypes.
            OfType(Of Object).
            Select(Function(t) New InvetoryTypeModel(CType(t, InventoryLocationType))).
            ToList()
        cboCustomerOrderType.BindingContext = New BindingContext()
        cboCustomerOrderType.DataSource = customerOrderTypes
    End Sub

    Private Async Function LoadInventoryLocationsAsync() As Task
        Dim inventoryLocationRepository = GetRequiredService(Of IInventoryLocationRepository)()
        Dim inventoryLocations = Await inventoryLocationRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)

        cboInventoryLocation.ValueMember = "RowID"
        cboInventoryLocation.DisplayMember = "Name"
        cboInventoryLocation.BindingContext = New BindingContext()
        cboInventoryLocation.DataSource = inventoryLocations.
            OrderByDescending(Function(t) t.IsMainWarehouse).
            ThenBy(Function(t) t.Name).
            ToList()
    End Function

    Private Async Function LoadCustomersAsync() As Task
        Dim accountDataService = GetRequiredService(Of IAccountDataService)()
        Dim accounts = Await accountDataService.GetManyByOrganizationIdAndTypeAsync(organizationId:=Z_OrganizationID, type:=AccountType.Customer)

        With cboCustomerName
            .ValueMember = "RowID"
            .DisplayMember = "CompanyName"
            .BindingContext = New BindingContext()
            .DataSource = accounts.
                OrderBy(Function(t) t.CompanyName).
                ToList()
        End With
    End Function

    Private Async Function LoadAgentsAsync() As Task
        Dim contactDataService = GetRequiredService(Of IContactDataService)()

        Dim agents = Await contactDataService.GetAgentsAsync(organizationId:=Z_OrganizationID)

        cboAgent.ValueMember = "RowID"
        cboAgent.DisplayMember = "FullNameLastNameFirst"
        cboAgent.BindingContext = New BindingContext()
        cboAgent.DataSource = agents.OrderBy(Function(t) t.FullNameLastNameFirst).ToList()
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

            Dim productColorSizeIds = orderItemModels?.Select(Function(oi) oi.ProductColorSizeId.Value).ToArray().
                Concat(selectedProductColorSizeModels.Select(Function(t) t.ProductColorSizeId).ToArray()).
                ToArray()

            Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()
            Dim productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAndProductColorSizeIdsAsync(inventoryLocationId:=CInt(cboInventoryLocation.SelectedValue), productColorSizeIds:=productColorSizeIds)

            For Each item In selectedProductColorSizeModels
                Dim orderItemModel = orderItemModels.FirstOrDefault(Function(t) If(t.ProductColorSizeId, 0) = item.ProductColorSizeId)

                If orderItemModel Is Nothing Then
                    orderItemList.Add(OrderItem.NewCustomerOrderItem(organizationId:=Z_OrganizationID,
                        userId:=Z_UserID,
                        qtyOrdered:=0,
                        srp:=If(item.UnitPriceOfUOM2, 0),
                        unitOfMeasure:=item.UnitOfMeasure2,
                        sku:=item.Sku,
                        sku2:=item.Sku2,
                        productColorSizeId:=item.ProductColorSizeId,
                        productInventoryLocationId:=item.ProductInventoryLocation.RowID.Value,
                        itemCode:=item.ProductCode,
                        accountId:=_selectedOrder.AccountID))

                    Continue For
                End If

                Dim thisOrderItem = OrderItem.NewCustomerOrderItem(organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    qtyOrdered:=If(orderItemModel?.QuantityOrdered, 0),
                    srp:=If(orderItemModel?.UnitPrice, If(item.UnitPriceOfUOM2, 0)),
                    unitOfMeasure:=StringExtensions.IfNullOrEmpty(orderItemModel?.UnitOfMeasure, item.UnitOfMeasure2),
                    sku:=StringExtensions.IfNullOrEmpty(orderItemModel?.Sku, item.Sku),
                    sku2:=StringExtensions.IfNullOrEmpty(orderItemModel?.Sku2, item.Sku2),
                    productColorSizeId:=If(orderItemModel?.ProductColorSizeId, item.ProductColorSizeId),
                    productInventoryLocationId:=If(orderItemModel?.ProductInventoryLocationId, item.ProductInventoryLocation.RowID.Value),
                    itemCode:=StringExtensions.IfNullOrEmpty(orderItemModel?.ProductCode, item.ProductCode),
                    accountId:=_selectedOrder.AccountID)

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


    Private Sub cboCustomerOrderType_SelectedIndexChanged(sender As Object, e As EventArgs)
        cboCustomerOrderType_SelectedValueChanged(sender, e)
    End Sub

    Private Sub cboCustomerOrderType_SelectedValueChanged(sender As Object, e As EventArgs)
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
            'cboInventoryLocation.SelectedItem = dataSource.FirstOrDefault()
            Dim id As Integer = If(dataSource.FirstOrDefault()?.RowID, 0)
            cboInventoryLocation.SelectedValue = id
        End If
    End Sub

    Private Sub cboCustomerName_DropDown(sender As Object, e As EventArgs) 'Handles cboCustomerName.DropDown

        Dim customerList = CType(cboCustomerName.DataSource, List(Of Account))

        If Not customerList.Any() Then Return

        Static font As Font = cboCustomerName.Font
        Dim grp As Graphics = cboCustomerName.CreateGraphics()

        Dim vertScrollBarWidth As Integer = If(cboCustomerName.Items.Count > cboCustomerName.MaxDropDownItems, SystemInformation.VerticalScrollBarWidth, 0)

        Dim longestWord = customerList.
            OrderByDescending(Function(o) o.CompanyName.Length).
            Select(Function(o) o.CompanyName).
            FirstOrDefault()

        Dim width = CInt(grp.MeasureString(longestWord, font).Width) + vertScrollBarWidth

        cboCustomerName.DropDownWidth = width + 8
    End Sub

    Private Sub gridOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridOrders.CellContentClick

    End Sub

    Private Async Sub gridOrders_SelectionChanged(sender As Object, e As EventArgs)
        Dim currentRow = gridOrders.CurrentRow
        If currentRow Is Nothing Or gridOrders.Rows.Count() = 0 Then
            _selectedOrder = Nothing
            Await ReloadDisplayForm(order:=Nothing)
            Return
        End If

        _selectedOrder = CType(currentRow.DataBoundItem, Order)

        Await ReloadDisplayForm(order:=_selectedOrder)

    End Sub

    Private Sub gridOrderItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridOrderItems.CellContentClick

    End Sub

    Private Sub gridOrderItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridOrderItems.CellClick
        Dim currentRow = gridOrderItems.CurrentRow
        If currentRow Is Nothing Then Return

        If e.ColumnIndex = ColumnDelete.Index Then

            Dim orderItemModel = GetOrderItemModel(currentRow)

            'If MessageBox.Show(text:=$"Are you sure you want to delete `{orderItemModel.ProductCode}`?",
            '    caption:="Delete Item",
            '    icon:=MessageBoxIcon.Question,
            '    buttons:=MessageBoxButtons.YesNoCancel,
            '    defaultButton:=MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            orderItemModel.SetDelete()

            gridOrderItems.Refresh()

            Dim orderItemModels = GetOrderItemModels().
                Where(Function(t) Not t.IsDelete).
                ToList()

            gridOrderItems.DataSource = orderItemModels
            'End If
        End If
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

    Private Sub gridOrderItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gridOrderItems.CellMouseClick
        If e.Button = MouseButtons.Right Then
            MsgBox("gridOrderItems_CellMouseClick")
        End If
    End Sub

    Private Async Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        ToolStripButtonNew.Enabled = False

        Dim successCallBack =
            Async Function()
                'Return Task.FromResult(0)
            End Function

        Dim errorCallBack =
            Async Function()

            End Function

        Await FunctionUtils.TryCatchFunctionAsync("Quick create Customer Order",
            Async Function()
                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Dim newOrder = Await orderDataService.QuickCreateCustomerOrderAsync(organizationId:=Z_OrganizationID, userId:=_userId)

                _selectedOrder = newOrder

                Await ReloadDisplayForm(order:=_selectedOrder)
            End Function,
            errorCallBack:=errorCallBack,
            successCallBack:=successCallBack)
    End Sub

    Private Sub ToolStripButtonNew_EnabledChanged(sender As Object, e As EventArgs) Handles ToolStripButtonNew.EnabledChanged
        Dim bool = ToolStripButtonNew.Enabled
        SplitContainer1.Panel1.Enabled = bool
        ToolStripButtonApproved.Enabled = bool
        ToolStripButtonReEncode.Enabled = bool
        ToolStripButtonRevoke.Enabled = bool
    End Sub

    Private Async Function ReloadDisplayForm(Optional order As Order = Nothing) As Task(Of Integer)
        'RemoveHandler cboCustomerOrderType.SelectedIndexChanged, AddressOf cboCustomerOrderType_SelectedIndexChanged
        RemoveHandler cboCustomerOrderType.SelectedValueChanged, AddressOf cboCustomerOrderType_SelectedValueChanged
        RemoveHandler cboInventoryLocation.SelectedValueChanged, AddressOf cboInventoryLocation_SelectedValueChanged

        gridOrderItems.DataSource = Enumerable.Empty(Of OrderItemModel)()

        For Each textBox In SplitContainer2.Panel1.Controls.OfType(Of Control).OfType(Of TextBox)
            textBox.DataBindings.Clear()
            textBox.Clear()
        Next
        For Each comboBox In SplitContainer2.Panel1.Controls.OfType(Of Control).OfType(Of ComboBox)
            comboBox.DataBindings.Clear()
            comboBox.SelectedIndex = -1
        Next
        For Each dateTimePicker In SplitContainer2.Panel1.Controls.OfType(Of Control).OfType(Of DateTimePicker)
            dateTimePicker.DataBindings.Clear()
            dateTimePicker.Value = Date.Now
        Next

        If order IsNot Nothing Then
            Dim isUntouchable = If(order?.IsCustomerOrderType, False) AndAlso Not If(order?.IsStatusNew, False)
            Dim updateMode = If(isUntouchable, DataSourceUpdateMode.Never, DataSourceUpdateMode.OnPropertyChanged)

            txtOrderNumber.DataBindings.Add("Text", order, "OrderNumber", False, DataSourceUpdateMode.Never)

            txtReferenceNumber.DataBindings.Add("Text", order, "ReferenceNumber", False, updateMode)

            txtStatus.DataBindings.Add("Text", order, "StatusDisplayText", False, DataSourceUpdateMode.Never)

            Dim dtpOrderDateBinding = New Binding("Value", order, "OrderDate") With {
            .DataSourceUpdateMode = updateMode,
            .FormattingEnabled = True}
            dtpOrderDate.DataBindings.Add(dtpOrderDateBinding)

            RemoveHandler cboCustomerName.SelectedIndexChanged, AddressOf cboCustomerName_SelectedIndexChanged
            cboCustomerName.DataBindings.Add("SelectedValue", order, "AccountID", True, updateMode)
            AddHandler cboCustomerName.SelectedIndexChanged, AddressOf cboCustomerName_SelectedIndexChanged

            cboAgent.DataBindings.Add("SelectedValue", order, "AgentID", False, updateMode)

            cboInventoryLocation.DataBindings.Add("SelectedValue", order, "InventoryLocationID", True, updateMode)

            cboCustomerOrderType.SelectedValue = If(order?.InventoryLocation?.Type, InventoryLocationType.Main)

            If updateMode = DataSourceUpdateMode.OnPropertyChanged Then
                AddHandler cboInventoryLocation.SelectedValueChanged, AddressOf cboInventoryLocation_SelectedValueChanged
                AddHandler cboCustomerOrderType.SelectedValueChanged, AddressOf cboCustomerOrderType_SelectedValueChanged
                If cboInventoryLocation.SelectedValue Is Nothing Then
                    cboInventoryLocation_SelectedValueChanged(cboInventoryLocation, New EventArgs())
                    cboCustomerOrderType_SelectedValueChanged(cboCustomerOrderType, New EventArgs())
                End If
                'AddHandler cboCustomerOrderType.SelectedIndexChanged, AddressOf cboCustomerOrderType_SelectedIndexChanged
            End If

            txtDRNumber.DataBindings.Add("Text", order, "DRNumber", False, DataSourceUpdateMode.OnPropertyChanged)

            txtDeliveryAddress.DataBindings.Add("Text", order, "CustomerAddress", False, updateMode)

            'dtpDateSubmitted.Value = If(order?.DateSubmitted?.Date, Date.Now)
            dtpDateSubmitted.DataBindings.Add(New Binding("Value", order, "DateSubmitted") With {
            .DataSourceUpdateMode = DataSourceUpdateMode.Never, .FormattingEnabled = True, .NullValue = dtpDateSubmitted.MinDate.Date})
            dtpDateSubmitted.Checked = Not dtpDateSubmitted.Value.Date = dtpDateSubmitted.MinDate.Date

            'dtpDeliveryDate.Value = If(order?.TargetDate?.Date, Date.Now)
            dtpDeliveryDate.DataBindings.Add(New Binding("Value", order, "TargetDate") With {
            .DataSourceUpdateMode = DataSourceUpdateMode.Never, .FormattingEnabled = True, .NullValue = dtpDeliveryDate.MinDate.Date})
            dtpDeliveryDate.Checked = Not dtpDeliveryDate.Value.Date = dtpDeliveryDate.MinDate.Date

            'dtpEndDate.Value = If(order?.EndDate?.Date, Date.Now)
            dtpEndDate.DataBindings.Add(New Binding("Value", order, "EndDate") With {
            .DataSourceUpdateMode = DataSourceUpdateMode.Never, .FormattingEnabled = True, .NullValue = dtpEndDate.MinDate.Date})
            dtpEndDate.Checked = Not dtpEndDate.Value.Date = dtpEndDate.MinDate.Date

            txtComments.DataBindings.Add("Text", order, "Comments", False, DataSourceUpdateMode.OnPropertyChanged)

            Dim productColorSizeIds = If(order?.OrderItems?.Select(Function(oi) oi.ProductColorSizeID.Value).ToArray(),
                Enumerable.Empty(Of Integer).ToArray())

            Dim productInventoryLocations = Enumerable.Empty(Of ProductInventoryLocation)()
            If If(productColorSizeIds?.Any(), False) Then
                Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()
                productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAndProductColorSizeIdsAsync(inventoryLocationId:=CInt(cboInventoryLocation.SelectedValue), productColorSizeIds:=productColorSizeIds)
            End If

            Dim getOrderItemModel =
                Function(orderItem As OrderItem)
                    Dim productInventoryLocation = productInventoryLocations.
                        Where(Function(t) t.ProductColorSizeID = orderItem.ProductColorSizeID.Value).
                        FirstOrDefault()
                    If orderItem.ProductColorSize Is Nothing AndAlso productInventoryLocation IsNot Nothing Then _
                        Return New OrderItemModel(orderItem:=orderItem, productInventoryLocation:=productInventoryLocation)

                    Return New OrderItemModel(orderItem:=orderItem)
                End Function

            Dim dataSource = order?.OrderItems?.Select(Function(t) getOrderItemModel(t)).
                Where(Function(t) Not t.IsDelete).
                OrderBy(Function(t) t.RowID).
                ToList()

            gridOrderItems.DataSource = If(dataSource, Enumerable.Empty(Of OrderItemModel)())
            'gridOrderItems.Refresh()
        End If

        Return 0
    End Function

    Private Async Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        If _selectedOrder Is Nothing Then Return

        ToolStripButtonSave.Enabled = False

        Dim successCallBack =
            Async Function()
                ToolStripButtonNew.Enabled = True

                Await DefaultReloadCustomerOrdersAsync(order:=_selectedOrder)

                ToolStripButtonSave.Enabled = True

                'Return Task.FromResult(0)
            End Function

        Dim errorCallBack =
            Async Function()
                ToolStripButtonSave.Enabled = True
            End Function

        Await FunctionUtils.TryCatchFunctionAsync("Save changes from Customer Order",
            Async Function()
                ApplyCustomerOrderChanges(_selectedOrder)

                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Await orderDataService.SaveManyCustomerOrderAsync(userId:=Z_UserID,
                    updated:=New List(Of Order) From {_selectedOrder})

                MessageBox.Show(text:="Changes saved successfully!",
                    caption:="Success",
                    icon:=MessageBoxIcon.Information,
                    buttons:=MessageBoxButtons.OK)
            End Function,
            errorCallBack:=errorCallBack,
            successCallBack:=successCallBack)
    End Sub

    Private Sub ApplyCustomerOrderChanges(order As Order)
        order.CustomerName = cboCustomerName.Text

        If If(order.InventoryLocationID, 0) = 0 Then order.InventoryLocationID = CType(cboInventoryLocation.SelectedValue, Integer)
        If If(order.AccountID, 0) = 0 Then order.AccountID = CType(cboCustomerName.SelectedValue, Integer)
        If If(order.AgentID, 0) = 0 Then order.AgentID = CType(cboAgent.SelectedValue, Integer)

        Dim orderItemList = GetOrderItemModels().
            Where(Function(t) Not (t.IsDelete And t.IsNew)).
            Select(Function(t) t.OrderItem).
            ToList()
        order.AddCustomerOrderItems(orderItemList)
        order.RecomputeTotalAmount()
    End Sub

    Private Async Sub ToolStripButtonApproved_Click(sender As Object, e As EventArgs) Handles ToolStripButtonApproved.Click
        If If(_selectedOrder?.IsNewEntity, True) Then Return

        Dim text = $"NOTE: Submitting this customer order means that you have completed, checked, and satisfied this order.{vbNewLine}{vbNewLine}Do you want to proceed submitting this to warehouse?"
        If Not MessageBox.Show(text:=text,
            caption:="Submitting",
            buttons:=MessageBoxButtons.YesNoCancel,
            icon:=MessageBoxIcon.Question,
            defaultButton:=MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            Return
        End If

        ToolStripButtonApproved.Enabled = False

        Dim successCallBack =
            Async Function()
                ToolStripButtonNew.Enabled = True

                Await DefaultReloadCustomerOrdersAsync(order:=_selectedOrder)

                ToolStripButtonApproved.Enabled = True
            End Function

        Dim errorCallBack =
            Async Function()
                ToolStripButtonNew.Enabled = True
                ToolStripButtonApproved.Enabled = True
            End Function

        Await FunctionUtils.TryCatchFunctionAsync(String.Empty,
            Async Function()
                ApplyCustomerOrderChanges(_selectedOrder)

                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Await orderDataService.ApproveCustomerOrder(order:=_selectedOrder, userId:=Z_UserID)
            End Function,
            errorCallBack:=errorCallBack,
            successCallBack:=successCallBack)
    End Sub

    Private Async Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        ToolStripButtonCancel.Enabled = False

        Dim successCallBack =
            Async Function()
                ToolStripButtonNew.Enabled = True

                Await DefaultReloadCustomerOrdersAsync(order:=_selectedOrder)

                ToolStripButtonCancel.Enabled = True

                Dim currentSelectedOrder = If(gridOrders.CurrentRow Is Nothing, Nothing, CType(gridOrders.CurrentRow?.DataBoundItem, Order))
                Await ReloadDisplayForm(currentSelectedOrder)
            End Function

        Dim errorCallBack =
            Async Function()
                ToolStripButtonCancel.Enabled = True
            End Function

        Await FunctionUtils.TryCatchFunctionAsync("Save changes from Customer Order",
            Async Function()
                If ToolStripButtonNew.Enabled Then Return

                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Await orderDataService.SaveManyCustomerOrderAsync(userId:=Z_UserID, deleted:=New List(Of Order) From {_selectedOrder})
            End Function,
            errorCallBack:=errorCallBack,
            successCallBack:=successCallBack)
    End Sub

    Private Async Sub ToolStripButtonReEncode_Click(sender As Object, e As EventArgs) Handles ToolStripButtonReEncode.Click
        If If(_selectedOrder?.IsNewEntity, True) Then Return

        Dim originOrderId = _selectedOrder.RowID.Value

        ToolStripButtonNew.Enabled = False

        Await FunctionUtils.TryCatchFunctionAsync("ReEncode as new Customer Order",
            Async Function()
                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Dim originOrder = Await orderDataService.GetCustomerOrderAsync(originOrderId)

                Dim newOrder = Await orderDataService.QuickCreateCustomerOrderAsync(organizationId:=Z_OrganizationID, userId:=_userId)

                newOrder.ReferenceNumber = originOrder.ReferenceNumber
                newOrder.OrderDate = originOrder.OrderDate
                newOrder.AccountID = originOrder.AccountID
                newOrder.AgentID = originOrder.AgentID
                newOrder.InventoryLocationID = originOrder.InventoryLocationID
                newOrder.CustomerAddress = originOrder.CustomerAddress
                newOrder.CustomerName = originOrder.CustomerName
                newOrder.Comments = originOrder.Comments

                Dim orderItems = originOrder.OrderItems.ToList()
                orderItems.ForEach(Sub(oi)
                                       oi.RowID = Nothing
                                       oi.OrderID = Nothing
                                   End Sub)

                newOrder.AddCustomerOrderItems(orderItems)
                newOrder.RecomputeTotalAmount()

                _selectedOrder = newOrder
                Await ReloadDisplayForm(order:=_selectedOrder)
            End Function)
    End Sub

    Private Async Sub ToolStripButtonRevoke_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRevoke.Click
        If If(_selectedOrder?.IsNewEntity, True) Then Return

        Dim text = $"Are you sure you want to ""CANCEL"" this `Customer Order` #{_selectedOrder.OrderNumber} {If(String.IsNullOrEmpty(_selectedOrder.ReferenceNumber), String.Empty, $"P.O. #{_selectedOrder.ReferenceNumber}")}?{vbNewLine}{vbNewLine}If so, please coordinate to those user(s) who are involve on this transaction process."
        If Not MessageBox.Show(text:=text,
            caption:="WARNING: Revoke Customer Order",
            buttons:=MessageBoxButtons.YesNoCancel,
            icon:=MessageBoxIcon.Warning,
            defaultButton:=MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            Return
        End If

        ToolStripButtonRevoke.Enabled = False

        Dim successCallBack =
            Async Function()
                ToolStripButtonNew.Enabled = True

                Await DefaultReloadCustomerOrdersAsync(order:=_selectedOrder)

                ToolStripButtonRevoke.Enabled = True
            End Function

        Dim errorCallBack =
            Async Function()
                ToolStripButtonNew.Enabled = True
                ToolStripButtonRevoke.Enabled = True
            End Function

        Await FunctionUtils.TryCatchFunctionAsync(String.Empty,
            Async Function()
                ApplyCustomerOrderChanges(_selectedOrder)

                Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                Await orderDataService.RevokeCustomerOrder(order:=_selectedOrder, userId:=Z_UserID)
            End Function,
            errorCallBack:=errorCallBack,
            successCallBack:=successCallBack)
    End Sub

    Private Sub ToolStripButtonClose_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClose.Click
        Close()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles cboCustomerName.SelectedIndexChanged
        Console.WriteLine($"order: {_selectedOrder?.AccountID}, cboCustomerName: {cboCustomerName.SelectedItem} or {cboCustomerName.SelectedValue}")
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If ToolStripButtonNew.Enabled Then Return

        Dim customers = CType(cboCustomerName.DataSource, List(Of Account))
        Dim id = CInt(cboCustomerName.SelectedValue)
        Dim customer = customers.FirstOrDefault(Function(t) t.RowID.Value = id)

        If customer Is Nothing Then Return

        txtDeliveryAddress.Text = customer.FullAddress
        cboAgent.SelectedValue = If(customer.AgentID, 0)
    End Sub

    Private Sub cboInventoryLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInventoryLocation.SelectedIndexChanged
        Console.WriteLine(_selectedOrder?.InventoryLocationID)
    End Sub

    Private Sub cboInventoryLocation_SelectedValueChanged1(sender As Object, e As EventArgs) Handles cboInventoryLocation.SelectedValueChanged
        Console.WriteLine(_selectedOrder?.InventoryLocationID)
    End Sub

    Private Sub cboInventoryLocation_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim id = CInt(cboInventoryLocation.SelectedValue)
        btnAddOrderItem.Enabled = id > 0
    End Sub

    Private Sub SplitContainer1_Panel1_SizeChanged(sender As Object, e As EventArgs) Handles SplitContainer1.Panel1.SizeChanged
        Dim centerWidth = CInt(SplitContainer1.Panel1.Size.Width / 2)
        linkNext.Location = New Point(x:=centerWidth, y:=linkNext.Location.Y)
        linkLast.Location = New Point(x:=(linkNext.Location.X + linkLast.Width), y:=linkLast.Location.Y)

        linkPrev.Location = New Point(x:=(linkNext.Location.X - linkPrev.Width), y:=linkPrev.Location.Y)
        linkFirst.Location = New Point(x:=(linkPrev.Location.X - linkFirst.Width), y:=linkFirst.Location.Y)
    End Sub

    Private Async Function DefaultReloadCustomerOrdersAsync(order As Order) As Task
        Dim row = gridOrders.Rows?.OfType(Of DataGridViewRow)?.
            FirstOrDefault(Function(r) If(DirectCast(r.DataBoundItem, Order)?.RowID = order.RowID, False))

        Await DefaultReloadCustomerOrdersAsync(rowIndex:=If(row?.Index, 0))
    End Function

    Private Async Function DefaultReloadCustomerOrdersAsync(rowIndex As Integer) As Task
        SetPageOptionToCurrentPageIndex()

        RemoveHandler gridOrders.SelectionChanged, AddressOf gridOrders_SelectionChanged

        Panel5.Enabled = False

        Await LoadCustomerOrdersAsync().
            ContinueWith(
            Sub()
                Panel5.Enabled = True
                gridOrders.CurrentCell = gridOrders.Item(columnIndex:=Column13.Index, rowIndex:=rowIndex)
                gridOrders_SelectionChanged(gridOrders, New EventArgs())
                AddHandler gridOrders.SelectionChanged, AddressOf gridOrders_SelectionChanged
            End Sub, TaskScheduler.FromCurrentSynchronizationContext)
    End Function

    Private Async Function DefaultReloadCustomerOrdersAsync() As Task
        RemoveHandler gridOrders.SelectionChanged, AddressOf gridOrders_SelectionChanged

        Panel5.Enabled = False

        Await LoadCustomerOrdersAsync().
            ContinueWith(
            Sub()
                Panel5.Enabled = True
                gridOrders_SelectionChanged(gridOrders, New EventArgs())
                AddHandler gridOrders.SelectionChanged, AddressOf gridOrders_SelectionChanged
            End Sub, TaskScheduler.FromCurrentSynchronizationContext)

    End Function

    Private Sub SetPageOptionToCurrentPageIndex()
        _pageOptions = DEFAULT_PAGEOPTIONS
    End Sub

    Private Async Sub Pagination_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkFirst.LinkClicked,
            linkPrev.LinkClicked,
            linkNext.LinkClicked
        RemoveHandler gridOrders.SelectionChanged, AddressOf gridOrders_SelectionChanged

        Panel5.Enabled = False

        Dim control = CType(sender, LinkLabel)
        If control.Name = linkFirst.Name Then
            _pageOptions.MoveToFirst()
        ElseIf control.Name = linkPrev.Name Then
            _pageOptions.MoveToPrevious()
        ElseIf control.Name = linkNext.Name Then
            _pageOptions.MoveToNext()
        End If

        _pageOptions.All = CheckBoxShowAll.Checked 'PageOptions.AllData

        Await LoadCustomerOrdersAsync().
            ContinueWith(
            Sub()
                Panel5.Enabled = True
                gridOrders_SelectionChanged(gridOrders, New EventArgs())
                AddHandler gridOrders.SelectionChanged, AddressOf gridOrders_SelectionChanged
            End Sub, TaskScheduler.FromCurrentSynchronizationContext)
    End Sub

    Private Async Sub linkLast_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLast.LinkClicked
        RemoveHandler gridOrders.SelectionChanged, AddressOf gridOrders_SelectionChanged

        Panel5.Enabled = False

        Dim total = Await LoadCustomerOrdersAsync()
        _pageOptions.MoveToLast(total:=total)
        Await LoadCustomerOrdersAsync().
            ContinueWith(
            Sub()
                Panel5.Enabled = True
                gridOrders_SelectionChanged(gridOrders, New EventArgs())
                AddHandler gridOrders.SelectionChanged, AddressOf gridOrders_SelectionChanged
            End Sub, TaskScheduler.FromCurrentSynchronizationContext)
    End Sub

    Private Sub txtStatus_TextChanged(sender As Object, e As EventArgs) Handles txtStatus.TextChanged
        ToolStripButtonApproved.Enabled = ToolStripButtonNew.Enabled AndAlso txtStatus.Text = OrderStatus.[New].ToString()
    End Sub

    Private Sub Print()
        If _selectedOrder Is Nothing Then Return

        Dim printreport As New VendorReportPrint
        Dim dataSource = CustomerOrdersForm.printCustomerOrderItems(icustomerorderid:=If(_selectedOrder?.RowID, 0))
        printreport.SetDataSource(CType(dataSource, DataTable))

        Dim openreportviewer As New ReportViewer
        openreportviewer.CrystalReportViewer.ReportSource = printreport
        openreportviewer.Show()
    End Sub

    Private Sub ToolStripButtonPrint_Click(sender As Object, e As EventArgs) Handles ToolStripButtonPrint.Click
        Print()
    End Sub

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        btnClearSearch.Visible = Not String.IsNullOrEmpty(TextBoxSearch.Text)
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        Pagination_LinkClicked(sender:=linkFirst, e:=New LinkLabelLinkClickedEventArgs(link:=New LinkLabel.Link))
    End Sub

    Private Sub TextBoxSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearch.KeyPress

    End Sub

    Private Sub TextBoxSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSearch.KeyDown
        If Not e.KeyCode = Keys.Enter Then Return
        ButtonSearch_Click(sender:=ButtonSearch, e:=New EventArgs())
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        TextBoxSearch.Clear()
        TextBoxSearch.Focus()
    End Sub

    Private Sub CheckBoxShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowAll.CheckedChanged
        Panel5.Visible = Not CheckBoxShowAll.Checked

        ButtonSearch_Click(ButtonSearch, New EventArgs())

        SplitContainer1_Panel1_SizeChanged(sender:=SplitContainer1.Panel1, e:=New EventArgs())
    End Sub
End Class