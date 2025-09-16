Option Strict On

Imports Microsoft.EntityFrameworkCore.Internal
Imports OfficeOpenXml
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories

Partial Public Class StockLevelExcelOptionsForm
    Private ReadOnly _organizationId As Integer
    Private _categoryIds As Integer()
    Private ReadOnly _categoryName As String
    Private ReadOnly _isDamageStocks As Boolean
    Private _inventoryLocations As List(Of InventoryLocation)

    Public Sub New(organizationId As Integer,
        categoryIds As Integer(),
        Optional categoryName As String = "",
        Optional isDamageStocks As Boolean = False)

        _organizationId = organizationId
        _categoryIds = categoryIds
        _categoryName = categoryName
        _isDamageStocks = isDamageStocks

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Async Sub StockLevelExcelOptionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim hasAny = If(_categoryIds?.Any(Function(i) i > 0), False)

        If Not hasAny AndAlso Not String.IsNullOrEmpty(_categoryName) Then
            Dim category = (Await GetCategoriesAsync()).FirstOrDefault(Function(t) t.CategoryName = _categoryName)

            _categoryIds = New Integer() {If(category?.RowID, 0)}
        End If

        _inventoryLocations = Await GetInventoryLocationsAsync()

        Await LoadCategoriesAsync().
            ContinueWith(Sub()
                             Panel2.Enabled = True
                         End Sub, TaskScheduler.FromCurrentSynchronizationContext())

        RadioButton1.Checked = Not _isDamageStocks
        RadioButton2.Checked = _isDamageStocks
    End Sub

    Private Async Function GetCategoriesAsync() As Task(Of List(Of Category))
        Dim categoryDataService = GetRequiredService(Of ICategoryDataService)()
        Return Await categoryDataService.GetAllByOrganizationIdAsync(_organizationId)
    End Function

    Private Async Function LoadCategoriesAsync() As Task
        Dim categories = (Await GetCategoriesAsync()).
            OrderBy(Function(t) t.CategoryName).
            ToList()

        For Each category In categories
            Dim checkBoxControl = New CheckBox() With {.Name = $"CheckBoxLeaveType{category.CategoryName.Replace(" ", String.Empty)}",
                .Text = category.CategoryName,
                .Checked = If(_categoryIds?.Contains(category.RowID.Value), False),
                .Tag = category.RowID.Value,
                .Margin = New Padding(0, 0, 0, 0)}

            Dim textSize = TextRenderer.MeasureText(checkBoxControl.Text, checkBoxControl.Font)

            Dim width = checkBoxControl.Size.Width
            checkBoxControl.AutoSize = False
            checkBoxControl.AutoEllipsis = False
            Dim customWidth = textSize.Width + (width * 0.5)
            checkBoxControl.Width = CType(customWidth, Integer)

            FlowLayoutPanelCategories.Controls.Add(checkBoxControl)
        Next
    End Function

    Private Async Function GetInventoryLocationsAsync() As Task(Of List(Of InventoryLocation))
        Dim inventoryLocationRepository = GetRequiredService(Of IInventoryLocationRepository)()
        Dim inventoryLocations = Await inventoryLocationRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)

        Return inventoryLocations.
            OrderByDescending(Function(t) t.IsMainWarehouse).
            ThenBy(Function(t) t.Name).
            ToList()
    End Function

    Private Async Function GetProductInventoryLocationsAsync() As Task(Of List(Of ProductInventoryLocation))
        Dim inventoryLocationIds = _inventoryLocations.
            Where(Function(t) t.IsActive).
            Select(Function(t) t.RowID.Value).
            ToArray()

        RefreshSelectedCategories()

        Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()

        If Not If(inventoryLocationIds?.Any(Function(i) i > 0), False) Then Return Enumerable.Empty(Of ProductInventoryLocation).ToList()

        If CheckBox5.Checked Then
            Return (Await productInventoryLocationDataService.GetByInventoryLocationIdsAsync(inventoryLocationIds)).
                Where(Function(t) _categoryIds.Contains(If(t.ProductColorSize.ProductColor.Product.CategoryID, 0))).
                Where(Function(t) t.ProductColorSize.IsActive).
                Where(Function(t) t.RackShelfColumn.IsActive).
                OrderBy(Function(t) t.ProductColorSize.ProductColor.Product.Category.CategoryName).
                ThenBy(Function(t) t.ProductColorSize.ProductColor.Product.ProductCode).
                ThenBy(Function(t) t.ProductColorSize.ProductColor.Color.ColorName).
                ToList()
        End If

        If CheckBox4.Checked Then
            Return (Await productInventoryLocationDataService.GetByInventoryLocationIdsAsync(inventoryLocationIds)).
                Where(Function(t) _categoryIds.Contains(If(t.ProductColorSize.ProductColor.Product.CategoryID, 0))).
                Where(Function(t) t.ProductColorSize.IsActive).
                Where(Function(t) t.RackShelfColumn.IsActive).
                Where(Function(t) If(t.TotalAvailableQty, 0) > -1).
                OrderBy(Function(t) t.ProductColorSize.ProductColor.Product.Category.CategoryName).
                ThenBy(Function(t) t.ProductColorSize.ProductColor.Product.ProductCode).
                ThenBy(Function(t) t.ProductColorSize.ProductColor.Color.ColorName).
                ToList()
        End If

        Return (Await productInventoryLocationDataService.GetByInventoryLocationIdsAsync(inventoryLocationIds)).
            Where(Function(t) _categoryIds.Contains(If(t.ProductColorSize.ProductColor.Product.CategoryID, 0))).
            Where(Function(t) t.ProductColorSize.IsActive).
            Where(Function(t) t.RackShelfColumn.IsActive).
            Where(Function(t) If(t.TotalAvailableQty, 0) > 0).
            OrderBy(Function(t) t.ProductColorSize.ProductColor.Product.Category.CategoryName).
            ThenBy(Function(t) t.ProductColorSize.ProductColor.Product.ProductCode).
            ThenBy(Function(t) t.ProductColorSize.ProductColor.Color.ColorName).
            ToList()
    End Function

    Private Sub RefreshSelectedCategories()
        Dim checkBoxCategories = FlowLayoutPanelCategories.Controls.OfType(Of CheckBox).
            Where(Function(t) t.Checked).
            ToList()

        _categoryIds = checkBoxCategories.
            Select(Function(t) CInt(t.Tag)).
            ToArray()
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim models = (Await GetProductInventoryLocationsAsync()).
            Select(Function(t) New StockLevelModel(t)).
            ToList()

        If Not If(models?.Any(), False) Then
            MessageBox.Show("Please select one or more Category.",
                "Invalid Category(ies)",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return
        End If

        Dim now = DateTime.Now
        Dim time = now.ToString("HHmm")
        Dim [date] = now.ToString("yyMMdd")
        Dim customDate = $"{[date]}~{time}"

        Dim saveFileDialogHelperOutPut = SaveFileDialogHelper.BrowseFile(defaultFileName:=$"StockLevel_{customDate}", ".xlsx")

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
                .Cells(initialRowIndex, 7).Value = "TotalAvailableQty"
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

                        For Each productColorSizes In productGroup.GroupBy(Function(t) t.ProductColorSizeID)

                            Dim ifSame2 = productGroupName = productGroup.Key
                            If Not ifSame2 Then productGroupName = productGroup.Key

                            Dim productColorSize = productColorSizes.FirstOrDefault()
                            If productColorSize Is Nothing Then Continue For

                            productColorSize.SetTotalQtyPerProductCode(totalAvailableQtyPerProductCode:=If(productColorSizes?.Sum(Function(t) t.TotalAvailableQty), 0))

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
                    For Each categoryGroup In productColorSizesOfThisCategory.
                        GroupBy(Function(t) t.CategoryName)

                        For Each productGroup In productColorSizesOfThisCategory.
                            Where(Function(t) t.CategoryName = categoryGroup.Key).
                            GroupBy(Function(t) t.ProductColorSizeID)

                            Dim ifSame = categoryName = categoryGroup.Key
                            If Not ifSame Then categoryName = categoryGroup.Key

                            Dim model = productGroup.FirstOrDefault()
                            model.SetTotalQtyPerProductCode(If(productGroup?.Sum(Function(t) t.TotalAvailableQty), 0))

                            SetRowContent(defaultWorksheet,
                                rowIndex,
                                categoryName,
                                model,
                                ifSame)

                            rowIndex += 1
                        Next
                    Next

                End If

                If CheckBox1.Checked Then
                    With defaultWorksheet.Cells(rowIndex, 6)
                        .Value = $"{category.Key} Sub-Total:"
                        .Style.Font.Bold = True
                    End With

                    With defaultWorksheet.Cells(rowIndex, 7)
                        If Not CheckBox3.Checked Then .Formula = $"=SUM(G{initialRowIndex}:G{rowIndex - 1})"
                        If CheckBox3.Checked Then .Value = productColorSizesOfThisCategory.Sum(Function(t) t.TotalAvailableQty)

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
                    .Value = models.Sum(Function(t) t.TotalAvailableQty)
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

    Private Sub SetRowContent(defaultWorksheet As ExcelWorksheet,
            rowIndex As Integer,
            defaultString As String,
            model As StockLevelModel,
            ifSame As Boolean)

        With defaultWorksheet
            .Cells(rowIndex, 1).Value = If(ifSame, String.Empty, defaultString)
            .Cells(rowIndex, 2).Value = model.ProductCode
            .Cells(rowIndex, 3).Value = model.ColorName
            .Cells(rowIndex, 4).Value = model.SeasonCode
            .Cells(rowIndex, 5).Value = model.SRP
            .Cells(rowIndex, 6).Value = model.SKU
            .Cells(rowIndex, 7).Value = model.TotalAvailableQty
            .Cells(rowIndex, 8).Value = model.UnitOfMeasure
        End With
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        CheckBox3.Enabled = CheckBox1.Checked

    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        CheckBox5.Enabled = CheckBox4.Checked

    End Sub

    Public Class StockLevelModel

        Public Sub New(productInventoryLocation As ProductInventoryLocation)

            Dim productColorSize = productInventoryLocation?.ProductColorSize

            ProductCode = productColorSize?.ProductColor?.ProductCode
            ColorName = productColorSize?.ProductColor?.ColorName
            SeasonCode = productColorSize?.SeasonCode
            SRP = If(productInventoryLocation?.UnitPriceOfUOM2, 0)
            SKU = productColorSize?.SKU
            TotalAvailableQty = If(productInventoryLocation?.TotalAvailableQty, 0)
            UnitOfMeasure = productInventoryLocation?.UnitOfMeasure2
            CategoryName = productColorSize?.ProductColor?.Product?.Category?.CategoryName
            ProductGroupName = productColorSize?.ProductColor?.Product?.ProductGroupName
            ProductColorSizeID = If(productColorSize?.RowID, 0)
        End Sub

        Public ReadOnly Property ProductCode As String
        Public ReadOnly Property ColorName As String
        Public ReadOnly Property SeasonCode As String
        Public ReadOnly Property SRP As Decimal
        Public ReadOnly Property SKU As String
        Public ReadOnly Property TotalAvailableQty As Integer
        Public ReadOnly Property UnitOfMeasure As String
        Public ReadOnly Property CategoryName As String
        Public ReadOnly Property ProductGroupName As String
        Public ReadOnly Property ProductColorSizeID As Integer

        Friend Sub SetTotalQtyPerProductCode(totalAvailableQtyPerProductCode As Integer)
            _TotalAvailableQty = totalAvailableQtyPerProductCode
        End Sub

    End Class

End Class
