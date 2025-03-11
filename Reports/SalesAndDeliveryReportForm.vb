Option Strict On

Imports OfficeOpenXml
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories

Public Class SalesAndDeliveryReportForm
    Private _inventoryLocations As List(Of InventoryLocation)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Async Sub SalesAndDeliveryReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _inventoryLocations = Await GetInventoryLocationsAsync()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        If DateTimePicker2.Checked Then
            Label2.Text = "From"

            Label3.ForeColor = SystemColors.ControlText
        Else
            Label2.Text = "One Day"

            Dim foreColor = Label3.ForeColor
            Label3.ForeColor = ProductColorSizeSelectorDialog.Lighten(foreColor)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not Button2.DialogResult = DialogResult.Cancel Then Close()

    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not (DateTimePicker1.Value.Date <= DateTimePicker2.Value.Date) Then
            MessageBox.Show("Invalid date range.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim lineups = Await GetLineupsAsync(
            from:=DateTimePicker1.Value,
            [to]:=If(DateTimePicker2.Checked, DateTimePicker2.Value, DateTimePicker1.Value))

        Dim packingListCartonItems As New List(Of PackingListCartonItem)
        lineups.ForEach(Sub(t)
                            t.LineupCartons.ToList().
                            ForEach(Sub(tt)
                                        packingListCartonItems.AddRange(tt.PackingListCartonItems)

                                    End Sub)

                        End Sub)

        Dim models = packingListCartonItems.
            Select(Function(t) New SalesDeliveryModel(packingListCartonItem:=t,
                productInventoryLocation:=t.OrderItem.ProductInventoryLocation)).
            ToList()

        Dim now = Date.Now
        Dim time = now.ToString("HHmm")
        Dim [date] = now.ToString("yyMMdd")
        Dim customDate = $"{[date]}~{time}"

        Dim saveFileDialogHelperOutPut = SaveFileDialogHelper.BrowseFile(defaultFileName:=$"SalesDelivery_{customDate}", ".xlsx")

        If saveFileDialogHelperOutPut.IsSuccess = False Then
            Return
        End If

        Using excel = New ExcelPackage(newFile:=saveFileDialogHelperOutPut.FileInfo)
            Dim defaultWorksheet = excel.Workbook.
                Worksheets.
                OfType(Of ExcelWorksheet).
                FirstOrDefault()
            If defaultWorksheet Is Nothing Then defaultWorksheet = excel.Workbook.Worksheets.Add(Name:="Sheet1")

            Dim initialRowIndex = 1
            With defaultWorksheet
                .Cells(initialRowIndex, 1).Value = If(CheckBox3.Checked, String.Empty, "Category")
                .Cells(initialRowIndex, 2).Value = "ProductCode"
                .Cells(initialRowIndex, 3).Value = "ColorName"
                .Cells(initialRowIndex, 4).Value = "SeasonCode"
                .Cells(initialRowIndex, 5).Value = "SRP"
                .Cells(initialRowIndex, 6).Value = "SKU"
                .Cells(initialRowIndex, 7).Value = "Qty"
                .Cells(initialRowIndex, 8).Value = "UnitOfMeasure"
                .Cells($"A{initialRowIndex}:H{initialRowIndex}").Style.Font.Bold = True

                .View.FreezePanes(initialRowIndex + 1, 1)
            End With

            initialRowIndex += 1

            Dim rowIndex = initialRowIndex

            Dim categories = models.
                GroupBy(Function(t) t.CategoryName).
                ToList()

            For Each category In categories
                Dim categoryName = String.Empty

                Dim productColorSizesOfThisCategory = models.Where(Function(t) t.CategoryName = category.Key)

                If CheckBox3.Checked Then
                    Dim productColorSizesOfThisProductGroupNames = productColorSizesOfThisCategory.
                        GroupBy(Function(t) t.ProductGroupName).
                        ToList()

                    For Each productGroup In productColorSizesOfThisProductGroupNames
                        Dim productGroupName = String.Empty

                        For Each productColorSize In productGroup

                            Dim ifSame2 = productGroupName = productGroup.Key
                            If Not ifSame2 Then productGroupName = productGroup.Key

                            SetRowContent(defaultWorksheet,
                                    rowIndex,
                                    productGroupName,
                                    productColorSize,
                                    ifSame2)

                            rowIndex += 1
                        Next

                        With defaultWorksheet.Cells(rowIndex, 6)
                            .Value = $"{productGroupName} Sub-Total:"
                            .Style.Font.Bold = True
                            .Style.Font.Size -= 1
                        End With

                        With defaultWorksheet.Cells(rowIndex, 7)
                            .Formula = $"=SUM(G{initialRowIndex}:G{rowIndex - 1})"
                            .Style.Font.Bold = True
                            .Style.Numberformat.Format = "#,##0"
                            .Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right
                        End With

                        rowIndex += 2

                        initialRowIndex = rowIndex

                    Next

                Else
                    For Each model In productColorSizesOfThisCategory
                        Dim ifSame = categoryName = model.CategoryName
                        If Not ifSame Then categoryName = model.CategoryName

                        SetRowContent(defaultWorksheet,
                            rowIndex,
                            categoryName,
                            model,
                            ifSame)

                        rowIndex += 1

                    Next

                End If

                If CheckBox1.Checked Then
                    With defaultWorksheet.Cells(rowIndex, 6)
                        .Value = $"{category.Key} Sub-Total:"
                        .Style.Font.Bold = True
                    End With

                    With defaultWorksheet.Cells(rowIndex, 7)
                        If Not CheckBox3.Checked Then .Formula = $"=SUM(G{initialRowIndex}:G{rowIndex - 1})"
                        If CheckBox3.Checked Then .Value = productColorSizesOfThisCategory.Sum(Function(t) t.Qty)

                        .Style.Font.Bold = True
                        .Style.Numberformat.Format = "#,##0"
                        .Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right
                        .Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
                    End With

                    rowIndex += 2
                End If

                initialRowIndex = rowIndex
            Next

            If CheckBox2.Checked Then
                With defaultWorksheet.Cells(initialRowIndex, 6)
                    .Value = "GRAND TOTAL:"
                    .Style.Font.Bold = True
                    .Style.Font.Size += 2
                End With

                With defaultWorksheet.Cells(initialRowIndex, 7)
                    .Value = models.Sum(Function(t) t.Qty)
                    .Style.Font.Bold = True
                    .Style.Font.Size += 2
                    .Style.Numberformat.Format = "#,##0"
                    .Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right
                    .Style.Border.Top.Style = Style.ExcelBorderStyle.Double
                End With
            End If

            defaultWorksheet.Cells.AutoFitColumns()

            excel.Save()
        End Using

        DialogResult = DialogResult.OK

        Process.Start(saveFileDialogHelperOutPut.FileInfo.FullName)

    End Sub

    Private Async Function GetInventoryLocationsAsync() As Task(Of List(Of InventoryLocation))
        Dim inventoryLocationRepository = GetRequiredService(Of IInventoryLocationRepository)()
        Dim inventoryLocations = Await inventoryLocationRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)

        Return inventoryLocations.
            OrderByDescending(Function(t) t.IsMainWarehouse).
            ThenBy(Function(t) t.Name).
            ToList()
    End Function

    Private Async Function GetLineupsAsync(from As Date, [to] As Date) As Task(Of List(Of Lineup))
        Dim inventoryLocationIds = _inventoryLocations.
            Where(Function(t) t.IsActive).
            Select(Function(t) t.RowID.Value).
            ToArray()

        If Not If(inventoryLocationIds?.Any(Function(i) i > 0), False) Then Return Enumerable.Empty(Of Lineup).ToList()

        Dim lineupDataService = GetRequiredService(Of ILineupDataService)()

        Return Await lineupDataService.GetByOrganizationIdAndDateRangeAsync(
            organizationId:=Z_OrganizationID,
            from:=from,
            [to]:=[to])

    End Function

    Private Sub SetRowContent(defaultWorksheet As ExcelWorksheet,
            rowIndex As Integer,
            defaultString As String,
            model As SalesDeliveryModel,
            ifSame As Boolean)

        With defaultWorksheet
            .Cells(rowIndex, 1).Value = If(ifSame, String.Empty, defaultString)
            .Cells(rowIndex, 2).Value = model.ProductCode
            .Cells(rowIndex, 3).Value = model.ColorName
            .Cells(rowIndex, 4).Value = model.SeasonCode
            .Cells(rowIndex, 5).Value = model.SRP
            .Cells(rowIndex, 6).Value = model.SKU
            .Cells(rowIndex, 7).Value = model.Qty
            .Cells(rowIndex, 8).Value = model.UnitOfMeasure
        End With
    End Sub

    Private Class SalesDeliveryModel

        Public Sub New(packingListCartonItem As PackingListCartonItem,
            productInventoryLocation As ProductInventoryLocation)

            Dim productColorSize = productInventoryLocation?.ProductColorSize

            ProductCode = productColorSize?.ProductColor?.ProductCode
            ColorName = productColorSize?.ProductColor?.ColorName
            SeasonCode = productColorSize?.SeasonCode
            SRP = If(packingListCartonItem?.OrderItem?.SRP, 0)
            SKU = productColorSize?.SKU
            Qty = If(packingListCartonItem.QtyInCarton, 0)
            UnitOfMeasure = productInventoryLocation?.UnitOfMeasure2
            CategoryName = productColorSize?.ProductColor?.Product?.Category?.CategoryName
            ProductGroupName = productColorSize?.ProductColor?.Product?.ProductGroupName
        End Sub

        Public ReadOnly Property ProductCode As String
        Public ReadOnly Property ColorName As String
        Public ReadOnly Property SeasonCode As String
        Public ReadOnly Property SRP As Decimal
        Public ReadOnly Property SKU As String
        Public ReadOnly Property Qty As Integer
        Public ReadOnly Property UnitOfMeasure As String
        Public ReadOnly Property CategoryName As String
        Public ReadOnly Property ProductGroupName As String
    End Class
End Class
