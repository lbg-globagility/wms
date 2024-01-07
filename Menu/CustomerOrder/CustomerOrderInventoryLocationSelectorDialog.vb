Imports WarehouseManagementSystem.Core.Entities

Public Class CustomerOrderInventoryLocationSelectorDialog
    Private ReadOnly _inventoryLocations As List(Of InventoryLocation)

    Public ReadOnly Property InventoryLocationId As Integer

    Public Sub New(inventoryLocations As List(Of InventoryLocation))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _inventoryLocations = inventoryLocations
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel1.WrapContents = True
    End Sub

    Private Sub CustomerOrderInventoryLocationSelectorDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each inventoryLocation In _inventoryLocations
            FlowLayoutPanel1.Controls.Add(New RadioButton() With {.Text = inventoryLocation.Name, .Tag = inventoryLocation})
        Next
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Dim selectedRadioButton = FlowLayoutPanel1.Controls.OfType(Of RadioButton).FirstOrDefault(Function(t) t.Checked)
        If selectedRadioButton Is Nothing Then Return

        _InventoryLocationId = CType(selectedRadioButton.Tag, InventoryLocation).RowID.Value

        DialogResult = DialogResult.OK
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class