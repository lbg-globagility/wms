Option Strict On

Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class RackShelfColumnForm
    Private ReadOnly _inventoryLocationId As Integer
    Private ReadOnly _productColorSizeId As Integer
    Private ReadOnly _rackShelfColumnIds As Integer()
    Public ReadOnly Property ProcessedRackShelfColumn As RackShelfColumn

    Public Sub New(inventoryLocationId As Integer,
        productColorSizeId As Integer,
        Optional rackShelfColumnIds As Integer() = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _inventoryLocationId = inventoryLocationId
        _productColorSizeId = productColorSizeId
        _rackShelfColumnIds = If(rackShelfColumnIds Is Nothing, Enumerable.Empty(Of Integer).ToArray(), rackShelfColumnIds)
    End Sub

    Private Async Sub RackShelfColumnForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grid.AutoGenerateColumns = False

        Await LoadRackShelfColumnAsync()
    End Sub

    Private Async Function LoadRackShelfColumnAsync() As Task
        Dim rackShelfColumnDataService = GetRequiredService(Of IRackShelfColumnDataService)()
        Dim rackShelfColumnList = Await rackShelfColumnDataService.GetByInventoryLocationIdAsync(_inventoryLocationId)

        grid.DataSource = rackShelfColumnList.
            Where(Function(t) Not _rackShelfColumnIds.Contains(t.RowID.Value)).
            Select(Function(t) New RackShelfColumnSimpleModel(productColorSizeId:=_productColorSizeId, rackShelfColumn:=t)).
            OrderBy(Function(t) t.PickOrderNo).
            ToList()
    End Function

    Private Async Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim rackShelfColumnDataService = GetRequiredService(Of IRackShelfColumnDataService)()
        Dim rackShelfColumn = Await rackShelfColumnDataService.GenerateNew(organizationId:=Z_OrganizationID,
            userId:=Z_UserID,
            inventoryLocationId:=_inventoryLocationId)

        Dim form As New RackShelfColumnFormDialog(productColorSizeId:=_productColorSizeId,
            rackShelfColumn:=rackShelfColumn)
        If Not form.ShowDialog() = DialogResult.OK Then Return

        Await FunctionUtils.TryCatchFunctionAsync("Create Rack-Shelf-Column",
            Async Function()
                Dim newRackShelfColumn = form.ProcessedRackShelfColumn

                Await rackShelfColumnDataService.SaveManyAsync(userId:=Z_UserID,
                    added:=New List(Of RackShelfColumn) From {newRackShelfColumn})

                _ProcessedRackShelfColumn = form.ProcessedRackShelfColumn
            End Function,
            successCallBack:=
            Async Sub()
                Await LoadRackShelfColumnAsync()
            End Sub)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If grid.CurrentRow Is Nothing Then Return

        Dim model = CType(grid.CurrentRow.DataBoundItem, RackShelfColumnSimpleModel)

        _ProcessedRackShelfColumn = model.RackShelfColumn

        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellContentClick

    End Sub
End Class