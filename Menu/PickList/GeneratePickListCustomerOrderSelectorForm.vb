Imports System.Threading
Imports SergeUtils
Imports _PickList = WarehouseManagementSystem.Core.Entities.PickList
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums

Public Class GeneratePickListCustomerOrderSelectorForm
    Private ReadOnly _organizationId As Integer
    Private ReadOnly _userId As Integer

    Public Sub New(organizationId As Integer, userId As Integer)
        _organizationId = organizationId
        _userId = userId
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Async Sub GeneratePickListCustomerOrderSelectorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataGrid.AutoGenerateColumns = False

        Dim cbHeaderIsSelected = New DatagridViewCheckBoxHeaderCell(String.Empty)
        Column1.HeaderCell = cbHeaderIsSelected
        AddHandler cbHeaderIsSelected.OnCheckBoxClicked, AddressOf cbHeaderIsSelected_CheckBoxClicked

        Await LoadOrders()
    End Sub

    Private Sub cbHeaderIsSelected_CheckBoxClicked(state As Boolean)
        Dim data = dataGrid.Rows.OfType(Of DataGridViewRow).
            ToList()
        '            Select(Function(r) CType(r.DataBoundItem, GeneratePickListOrderDto)).
        '
        data.ForEach(Sub(t)
                         't.IsSelected = state
                         t.Cells(Column1.Name).Value = state
                         dataGrid.EndEdit()
                         dataGrid.Refresh()
                     End Sub)

    End Sub

    Private Sub GeneratePickListCustomerOrderSelectorForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not Panel2.Enabled
    End Sub

    Private Async Function GetOrders() As Task(Of List(Of GeneratePickListOrderDto))
        Dim orderDataService = GetRequiredService(Of IOrderDataService)()

        Return (Await orderDataService.GetCustomerOrdersAsync(organizationId:=_organizationId)).
            Where(Function(t) t.IsStatusSubmittedToWarehouse).
            Select(Function(t) New GeneratePickListOrderDto(order:=t)).
            ToList()
    End Function

    Private Async Function LoadOrders() As Task
        dataGrid.BindingContext = New BindingContext()
        dataGrid.DataSource = Await GetOrders()
    End Function

    Private Async Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Panel2.Enabled = False

        Dim pickListDataService = GetRequiredService(Of IPickListDataService)()
        Dim datasource = dataGrid.Rows.OfType(Of DataGridViewRow).
            Select(Function(r) CType(r.DataBoundItem, GeneratePickListOrderDto)).
            ToList()
        Dim selectedOrders = datasource.
            Where(Function(t) t.IsSelected).
            ToList()

        Dim lastPickList = Await pickListDataService.GetLastAsync(Z_OrganizationID)

        Dim newPickList = _PickList.NewPickList(organizationId:=Z_OrganizationID,
            userId:=_userId,
            pickListNo:=If(lastPickList?.PickListNumberInt, 0) + 1)

        Await pickListDataService.SaveManyAsync(added:=New List(Of _PickList) From {newPickList}, userId:=_userId).
            ContinueWith(
                Async Function(antecedent)
                    If Not antecedent.IsCompleted Then Return

                    Dim pickListOrderDataService = GetRequiredService(Of IPickListOrderDataService)()

                    Dim newPickListOrders = New List(Of PickListOrder)

                    selectedOrders.
                        ForEach(Sub(t)
                                    Dim orderId = t.Order.RowID.Value

                                    For Each item In t.Order.OrderItems
                                        Dim p = PickListOrder.NewPickListOrder(organizationId:=_organizationId,
                                            userId:=_userId,
                                            pickListId:=newPickList.RowID,
                                            orderId:=orderId,
                                            orderItemId:=item.RowID)

                                        newPickListOrders.Add(p)
                                    Next
                                End Sub)

                    If Not If(newPickListOrders?.Any(), False) Then Return

                    Await pickListOrderDataService.SaveManyAsync(added:=newPickListOrders, userId:=_userId)

                    Dim orderIds = newPickListOrders.
                        Select(Function(t) t.OrderID).
                        ToArray()

                    Dim orderDataService = GetRequiredService(Of IOrderDataService)()
                    Dim orders = Await orderDataService.GetManyByIdsAsync(ids:=orderIds)

                    orders.
                        ForEach(Sub(t)
                                    t.Status = OrderStatus.PickListed
                                End Sub)

                    Await orderDataService.SaveManyAsync(updated:=orders, userId:=_userId)

                End Function,
                CancellationToken.None,
                TaskContinuationOptions.OnlyOnRanToCompletion,
                TaskScheduler.FromCurrentSynchronizationContext()).
            ContinueWith(
                Sub(antecedent)
                    If Not antecedent.IsCompleted Then Return

                    MessageBox.Show(text:=$"Finish! Pick List #{newPickList.PickListNo}",
                        caption:="Success",
                        buttons:=MessageBoxButtons.OK,
                        icon:=MessageBoxIcon.Information)

                End Sub,
                CancellationToken.None,
                TaskContinuationOptions.OnlyOnRanToCompletion,
                TaskScheduler.FromCurrentSynchronizationContext()).
            ContinueWith(
                Sub(antecedent)

                    DialogResult = DialogResult.OK

                    Panel2.Enabled = True

                End Sub,
                TaskScheduler.FromCurrentSynchronizationContext())
    End Sub

    Private Sub dataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGrid.CellContentClick

    End Sub

    Private Sub dataGrid_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dataGrid.CellValueChanged
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Return

        Dim rows = dataGrid.Rows.OfType(Of DataGridViewRow).
            Select(Function(t) CType(t.DataBoundItem, GeneratePickListOrderDto)).
            ToList()

        btnOK.Enabled = If(rows?.Any(Function(t) t.IsSelected), False)

    End Sub

End Class
