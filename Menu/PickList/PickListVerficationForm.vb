Option Strict On

Imports System.Threading
Imports SergeUtils
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices

Public Class PickListVerficationForm
    Private ReadOnly _pickListId As Integer

    Public Sub New(pickListId As Integer)
        _pickListId = pickListId

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Async Sub PickListVerficationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataGrid.AutoGenerateColumns = False

        Dim cbHeaderIsVerified = New DatagridViewCheckBoxHeaderCell("Verified?")
        Column1.HeaderCell = cbHeaderIsVerified
        AddHandler cbHeaderIsVerified.OnCheckBoxClicked, AddressOf cbHeaderIsVerified_CheckBoxClicked

        Dim pickListDataService = GetRequiredService(Of IPickListDataService)()
        Dim picklist = Await pickListDataService.GetByIdAsync(_pickListId)
        Dim orderIds = picklist.PickListOrders.GroupBy(Function(t) t.OrderID).Select(Function(t) t.Key).ToArray()

        Dim packingListDataService = GetRequiredService(Of IPackingListDataService)()
        Dim packingLists = Await packingListDataService.GetManyByOrderIdsAsync(ids:=orderIds)

        btnOK.Visible = Not If(packingLists?.Any(), False)

        Await LoadPickListOrders()

    End Sub

    Private Async Function LoadPickListOrders() As Task
        dataGrid.BindingContext = New BindingContext()
        dataGrid.DataSource = Await GetPickListOrders()

    End Function

    Private Async Function GetPickListOrders() As Task(Of List(Of PickListOrderDto))
        Dim pickListDataService = GetRequiredService(Of IPickListDataService)()
        Dim picklist = Await pickListDataService.GetByIdAsync(_pickListId)

        Dim picklistOrders = picklist.PickListOrders

        Dim dataSource = picklistOrders.
            Select(Function(t) New PickListOrderDto(t)).
            ToList()

        Return dataSource
    End Function

    Private Sub cbHeaderIsVerified_CheckBoxClicked(state As Boolean)
        Dim data = dataGrid.Rows.OfType(Of DataGridViewRow).
            Select(Function(r) CType(r.DataBoundItem, PickListOrderDto)).
            ToList()

        data.ForEach(Sub(t)
                         t.IsVerified = state
                         dataGrid.EndEdit()
                         dataGrid.Refresh()
                     End Sub)

    End Sub

    Private Sub dataGrid_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dataGrid.CellFormatting
        If e.RowIndex >= 0 Then dataGrid.Rows(e.RowIndex).HeaderCell.Value = $"{e.RowIndex + 1}"

    End Sub

    Private Async Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Panel2.Enabled = False

        Dim pickListOrderDataService = GetRequiredService(Of IPickListOrderDataService)()
        Dim datasource = dataGrid.Rows.OfType(Of DataGridViewRow).
            Select(Function(r) CType(r.DataBoundItem, PickListOrderDto)).
            ToList()
        Dim editedPickListOrders = datasource.
            Where(Function(t) t.IsEdited).
            ToList()

        Dim updated = editedPickListOrders.
            Select(
                Function(t)
                    Dim pickListOrder = t.PickListOrder
                    If t.IsVerified Then pickListOrder.Status = PickListOrderStatus.Verified
                    If Not t.IsVerified Then pickListOrder.Status = PickListOrderStatus.New

                    Return pickListOrder
                End Function).
            ToList()

        '        Dim pickListOrderItems = updated.
        '            Where(Function(t) t.IsVerifiedStatus).
        '            Select(Function(t) t.PickListOrderItem).
        '            ToList()

        '        For Each item In pickListOrderItems
        '            item.Status = PickListOrderItemStatus.Verified
        '            item.SetEdited()
        '        Next

        '        Dim pickListOrderItemDataService = GetRequiredService(Of IPickListOrderItemDataService)()
        '        Task.WhenAll(pickListOrderItemDataService.SaveManyAsync(updated:=pickListOrderItems, userId:=Z_UserID),
        ')

        Await pickListOrderDataService.SaveManyAsync(updated:=updated, userId:=Z_UserID).
            ContinueWith(
                Async Function(antecedent)
                    Dim pickListDataService = GetRequiredService(Of IPickListDataService)()
                    Dim picklist = Await pickListDataService.GetByIdAsync(_pickListId)

                    Dim status As PickListStatus

                    Dim perfect = If(datasource?.Count(), 0)
                    Dim actualCount = If(datasource.Where(Function(t) t.IsVerified)?.Count(), 0)

                    If perfect = actualCount Then status = PickListStatus.Completed

                    If perfect > actualCount Then status = PickListStatus.PartiallyVerified

                    picklist.Status = status

                    Await pickListDataService.SaveAsync(entity:=picklist, userId:=Z_UserID)

                End Function,
                CancellationToken.None,
                TaskContinuationOptions.OnlyOnRanToCompletion,
                TaskScheduler.FromCurrentSynchronizationContext()).
            ContinueWith(
                Sub(antecedent)
                    If Not antecedent.IsCompleted Then Return

                    MessageBox.Show(text:="Finish",
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

                End Sub, TaskScheduler.FromCurrentSynchronizationContext())

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub PickListVerficationForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not Panel2.Enabled
    End Sub

End Class
