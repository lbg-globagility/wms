Imports WarehouseManagementSystem.Core.Entities

Public Class Form1
    Private ReadOnly _dataSource As List(Of Order)

    Public Sub New(dataSource As List(Of Order))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _dataSource = dataSource

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim orderList = _dataSource.GroupBy(Function(o) o.RowID).ToList()

        For Each item In orderList
            Dim order = item.FirstOrDefault()
            FlowLayoutPanel1.Controls.Add(New RadioButton() With {
                .AutoSize = True,
                .Name = item.Key,
                .Text = $"Order#: {order.OrderNumber}{Environment.NewLine}{String.Join(Environment.NewLine, order.OrderItems.Select(Function(t) $"{t.ProductColorSize.ProductColor.Product.ProductCode} ({t.QtyOrdered} {t.ProductInventoryLocation.UnitOfMeasure2})").ToList())}"
            })
        Next
    End Sub

    ReadOnly Property SelectedCustomerOrderId As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selected = FlowLayoutPanel1.Controls.
            OfType(Of RadioButton).
            FirstOrDefault(Function(t) t.Checked)

        If If(selected?.Checked, False) Then
            _SelectedCustomerOrderId = CInt(selected.Name)
            DialogResult = DialogResult.OK
        Else
            DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DialogResult = DialogResult.Cancel
    End Sub

End Class