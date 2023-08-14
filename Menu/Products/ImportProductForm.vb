Option Strict On

Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
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
        Dim products = Await productDataService.GetManyByProductCodesAsync(organizationId:=Z_OrganizationID,
            productCodes:=groupByColorList)

        Dim hasColorAndSize =
            Function(t As ProductRowRecord)
                Dim size = CDec(t.Style)
                Return products.Any(Function(x) x.HasColorAndSize(t.Colors, size))
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
    End Sub

    Private Sub btnDownloadTemplate_Click(sender As Object, e As EventArgs) Handles btnDownloadTemplate.Click

    End Sub

    Private Async Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim productRowRecords = ValidRecordsGrid.Rows.
            OfType(Of DataGridViewRow).
            Select(Function(r) DirectCast(r.DataBoundItem, ProductRowRecord)).
            ToList()

        If Not productRowRecords.Any() Then Return

        Await FunctionUtils.TryCatchFunctionAsync("Import Product(s)",
            Async Function()
                Dim colorDataService = MainServiceProvider.GetRequiredService(Of IColorDataService)
                Dim groupByColorList = productRowRecords.
                    GroupBy(Function(t) t.Colors).
                    ToArray()
                Dim colorNames = groupByColorList.
                    Select(Function(s) s.Key).
                    ToArray()
                Dim colors = Await colorDataService.GetManyOrCreateManyAsync(organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    names:=colorNames)

                Dim categoryDataService = MainServiceProvider.GetRequiredService(Of ICategoryDataService)
                Dim groupByProductCategoryList = productRowRecords.
                    GroupBy(Function(t) t.Category).
                    ToList()
                Dim categoryNames = groupByProductCategoryList.
                    Select(Function(s) s.Key).
                    ToArray()
                Dim categories = Await categoryDataService.GetManyOrCreateManyAsync(organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    names:=categoryNames)

                Dim productCodes = productRowRecords.
                    GroupBy(Function(t) t.ProductCode).
                    Select(Function(s) s.Key).
                    ToArray()

                Dim productDataService = MainServiceProvider.GetRequiredService(Of IProductDataService)
                Dim products = Await productDataService.GetManyByProductCodesAsync(organizationId:=Z_OrganizationID,
            productCodes:=productCodes)

                For Each colorItem In groupByColorList
                    Dim colorName = colorItem.Key
                    Dim color = colors.FirstOrDefault(Function(c) c.ColorName = colorName)

                    Dim newProductColor = ProductColor.NewProductColor(organizationId:=Z_OrganizationID,
                        userId:=Z_UserID,
                        colorId:=color.RowID.Value,
                        productId:=0)

                    Dim productColorSizes = colorItem.
                        GroupBy(Function(t) t.Style).
                        ToList()
                    For Each productColorSizeItem In productColorSizes
                        Dim product = products.
                            FirstOrDefault(Function(p) p.ProductCode.ToLower() = productColorSizeItem.FirstOrDefault().ProductCode.ToLower())
                        If product Is Nothing Then Continue For

                        newProductColor.ProductID = product.RowID.Value

                        Dim newProductColorSize = ProductColorSize.NewProductColorSize(organizationId:=Z_OrganizationID,
                            userId:=Z_UserID,
                            size:=CDec(productColorSizeItem.Key),
                            sku:=productColorSizeItem.FirstOrDefault().SKU,
                            sku2:=productColorSizeItem.FirstOrDefault().SKU2)

                        newProductColor.AddProductColorSizes(productColorSizes:=New List(Of ProductColorSize) From {newProductColorSize})
                    Next

                    color.AddProductColors(New List(Of ProductColor) From {newProductColor})
                Next

                MessageBox.Show(text:="Product(s) imported successfully!",
                    caption:="Success — import product(s)",
                    buttons:=MessageBoxButtons.OK,
                    icon:=MessageBoxIcon.Information)
            End Function)
    End Sub

    Private Sub CancelDialogButton_Click(sender As Object, e As EventArgs) Handles CancelDialogButton.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

End Class