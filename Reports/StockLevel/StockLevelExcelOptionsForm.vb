Option Strict On

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
            defaultWorksheet.Cells(initialRowIndex, 1).Value = "Category"
            defaultWorksheet.Cells(initialRowIndex, 2).Value = "ProductCode"
            defaultWorksheet.Cells(initialRowIndex, 3).Value = "ColorName"
            defaultWorksheet.Cells(initialRowIndex, 4).Value = "SeasonCode"
            defaultWorksheet.Cells(initialRowIndex, 5).Value = "SRP"
            defaultWorksheet.Cells(initialRowIndex, 6).Value = "SKU"
            defaultWorksheet.Cells(initialRowIndex, 7).Value = "TotalAvailableQty"
            defaultWorksheet.Cells(initialRowIndex, 8).Value = "UnitOfMeasure"
            defaultWorksheet.Cells($"A{initialRowIndex}:H{initialRowIndex}").Style.Font.Bold = True

            initialRowIndex += 1

            Dim rowIndex = initialRowIndex

            Dim categories = models.
                GroupBy(Function(t) t.CategoryName).
                ToList()

            For Each category In categories
                Dim categoryName = String.Empty

                For Each model In models.Where(Function(t) t.CategoryName = category.Key)
                    Dim ifSame = categoryName = model.CategoryName
                    If Not ifSame Then categoryName = model.CategoryName

                    defaultWorksheet.Cells(rowIndex, 1).Value = If(ifSame, String.Empty, categoryName)
                    defaultWorksheet.Cells(rowIndex, 2).Value = model.ProductCode
                    defaultWorksheet.Cells(rowIndex, 3).Value = model.ColorName
                    defaultWorksheet.Cells(rowIndex, 4).Value = model.SeasonCode
                    defaultWorksheet.Cells(rowIndex, 5).Value = model.SRP
                    defaultWorksheet.Cells(rowIndex, 6).Value = model.SKU
                    defaultWorksheet.Cells(rowIndex, 7).Value = model.TotalAvailableQty
                    defaultWorksheet.Cells(rowIndex, 8).Value = model.UnitOfMeasure
                    rowIndex += 1
                Next

                If CheckBox1.Checked Then
                    With defaultWorksheet.Cells(rowIndex, 7)
                        .Formula = $"=SUM(G{initialRowIndex}:G{rowIndex - 1})"
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
                With defaultWorksheet.Cells(initialRowIndex, 7)
                    .Value = models.Sum(Function(t) t.TotalAvailableQty)
                    .Style.Font.Bold = True
                    .Style.Font.Size += 2
                    .Style.Numberformat.Format = "#,##0"
                    .Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right
                    .Style.Border.Top.Style = Style.ExcelBorderStyle.Double
                End With
            End If

            excel.Save()
        End Using

        Process.Start(saveFileDialogHelperOutPut.FileInfo.FullName)
    End Sub

    Private Class StockLevelModel
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
        End Sub

        Public ReadOnly Property ProductCode As String
        Public ReadOnly Property ColorName As String
        Public ReadOnly Property SeasonCode As String
        Public ReadOnly Property SRP As Decimal
        Public ReadOnly Property SKU As String
        Public ReadOnly Property TotalAvailableQty As Integer
        Public ReadOnly Property UnitOfMeasure As String
        Public ReadOnly Property CategoryName As String
    End Class

End Class
