Option Strict On

Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Desktop.Helpers
Imports WarehouseManagementSystem.Desktop.Utilities
Imports WarehouseManagementSystem.Infrastructure.Excel.Import

Public Class ImportProductForm

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ImportProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ValidRecordsGrid.AutoGenerateColumns = False
        RejectedRecordsGrid.AutoGenerateColumns = False

    End Sub

    Private Async Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        Dim browseFile = New OpenFileDialog With {
            .Filter = "Microsoft Excel Workbook Documents 2007-13 (*.xlsx)|*.xlsx|" &
                "Microsoft Excel Documents 97-2003 (*.xls)|*.xls"
        }

        If browseFile.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        Dim fileName = browseFile.FileName

        Dim productRowRecords As New List(Of ProductRowRecord)

        Dim parsedSuccessfully = FunctionUtils.TryCatchExcelParserReadFunction(
            Sub()
                productRowRecords = ExcelService(Of ProductRowRecord).
                    Read(fileName).
                    ToList()
            End Sub)

        If Not parsedSuccessfully Then Return

        Dim groupByColorList = productRowRecords.
            GroupBy(Function(t) t.ProductCode).
            Select(Function(s) s.Key).
            ToArray()

        Dim productDataService = MainServiceProvider.GetRequiredService(Of IProductDataService)
        'Dim products = Await productDataService.GetManyByProductCodesAsync(organizationId:=Z_OrganizationID,
        '    productCodes:=groupByColorList)
        Dim products = Await productDataService.GetManyByOrganizationIdAsync(organizationId:=Z_OrganizationID)

        Dim hasColorAndSize =
            Function(t As ProductRowRecord)
                Dim size = CDec(t.Style)
                Return products.
                    Where(Function(x) x.ProductCode = t.ProductCode).
                    Any(Function(x) x.HasColorAndSize(t.Colors, size))
            End Function

        Dim validParse = productRowRecords.
            Where(Function(t) t.IsValid).
            Where(Function(t) Not hasColorAndSize(t)).
            OrderBy(Function(t) t.LineNumber).
            ToList()
        Dim invalidParse = productRowRecords.Where(Function(t) Not t.IsValid).
            OrderBy(Function(t) t.LineNumber).
            ToList()
        Dim alreadyExistsParse = productRowRecords.
            Where(Function(t) t.IsValid).
            Where(Function(t) hasColorAndSize(t)).
            OrderBy(Function(t) t.LineNumber).
            ToList()

        ParsedTabControl.Text = $"Ok ({validParse.Count})"
        ErrorsTabControl.Text = $"Errors ({invalidParse.Count})"
        AlreadyExistsTabControl.Text = $"Already Exists ({alreadyExistsParse.Count})"

        SaveButton.Enabled = validParse.Count > 0

        ValidRecordsGrid.DataSource = validParse
        RejectedRecordsGrid.DataSource = invalidParse
        AlreadyExistRecordsGrid.DataSource = alreadyExistsParse
    End Sub

    Private Sub btnDownloadTemplate_Click(sender As Object, e As EventArgs) Handles btnDownloadTemplate.Click
        DownloadTemplateHelper.DownloadExcel(excelTemplate:=ExcelTemplates.Product)
    End Sub

    Private Async Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim productRowRecords = ValidRecordsGrid.Rows.
            OfType(Of DataGridViewRow).
            Select(Function(r) DirectCast(r.DataBoundItem, ProductRowRecord)).
            ToList()

        If Not productRowRecords.Any() Then Return

        Dim productImportation = New ProductImportation(productRowRecords:=productRowRecords)

        Panel1.Enabled = False

        Await FunctionUtils.TryCatchFunctionAsync("Import Product(s)",
            Async Function()
                Await productImportation.SaveAsync()

                Me.DialogResult = DialogResult.OK

                Panel1.Enabled = True
            End Function)
    End Sub

    Private Sub CancelDialogButton_Click(sender As Object, e As EventArgs) Handles CancelDialogButton.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub ImportProductForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not Panel1.Enabled
    End Sub

End Class