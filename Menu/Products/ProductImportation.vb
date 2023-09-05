Option Strict On

Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Desktop.Utilities
Imports WarehouseManagementSystem.Infrastructure.Excel.Import
Imports WarehouseManagementSystem.Utilities.Extensions

Public Class ProductImportation
    Private ReadOnly _productRowRecords As List(Of ProductRowRecord)

    Private Sub New()

    End Sub

    Public Sub New(productRowRecords As List(Of ProductRowRecord))
        _productRowRecords = productRowRecords
    End Sub

    Public Async Function SaveAsync() As Task
        Await FunctionUtils.TryCatchFunctionAsync("Import Product(s)",
            Async Function()
                Dim colorDataService = MainServiceProvider.GetRequiredService(Of IColorDataService)
                Dim groupByColorList = _productRowRecords.
                    GroupBy(Function(t) t.Colors.Trim()).
                    ToArray()
                Dim colorNames = groupByColorList.
                    Select(Function(s) s.Key.Trim()).
                    ToArray()
                Dim colors = Await colorDataService.GetManyOrCreateManyAsync(organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    names:=colorNames)

                Dim categoryDataService = MainServiceProvider.GetRequiredService(Of ICategoryDataService)
                Dim groupByProductCategoryList = _productRowRecords.
                    GroupBy(Function(t) t.Category.Trim()).
                    ToList()
                Dim categoryNames = groupByProductCategoryList.
                    Select(Function(s) s.Key.Trim()).
                    ToArray()
                Dim categories = Await categoryDataService.GetManyOrCreateManyAsync(organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    names:=categoryNames)

                Dim productCodes = _productRowRecords.
                    GroupBy(Function(t) t.ProductCode.Trim()).
                    Select(Function(s) s.Key.Trim()).
                    ToArray()

                Dim productDataService = MainServiceProvider.GetRequiredService(Of IProductDataService)
                Dim products = Await productDataService.GetManyByProductCodesAsync(organizationId:=Z_OrganizationID,
                    productCodes:=productCodes)

                Dim newProductColors = New List(Of ProductColor)

                For Each colorItem In groupByColorList
                    Dim colorName = colorItem.Key
                    Dim color = colors.FirstOrDefault(Function(c) c.ColorName.IsEqualTo(colorName))

                    Dim groupByProductList = colorItem.
                        GroupBy(Function(c) c.ProductCode).
                        ToList()
                    For Each productItem In groupByProductList
                        Dim product = products.
                            FirstOrDefault(Function(p) p.ProductCode.ToLower() = productItem.FirstOrDefault().ProductCode.ToLower())
                        If product Is Nothing Then
                            Dim category = categories.FirstOrDefault(Function(c) c.CategoryName.ToLower() = productItem.FirstOrDefault().Category.ToLower())
                            product = Await productDataService.SaveAsync(entity:=Product.NewProduct(organizationId:=Z_OrganizationID,
                                    userId:=Z_UserID,
                                    categoryId:=category.RowID.Value,
                                    productCode:=productItem.FirstOrDefault().ProductCode,
                                    description:=productItem.FirstOrDefault().Description),
                                userId:=Z_UserID)
                        End If

                        Dim newProductColor = ProductColor.NewProductColor(organizationId:=Z_OrganizationID,
                            userId:=Z_UserID,
                            colorId:=color.RowID.Value,
                            productId:=product.RowID.Value)

                        Dim groupBySizeList = productItem.
                            GroupBy(Function(c) c.Style).
                            ToList()
                        For Each sizeItem In groupBySizeList
                            Dim newProductColorSize = ProductColorSize.NewProductColorSize(organizationId:=Z_OrganizationID,
                                userId:=Z_UserID,
                                size:=CDec(sizeItem.Key),
                                sku:=sizeItem.FirstOrDefault().SKU,
                                sku2:=sizeItem.FirstOrDefault().SKU2,
                                seasonCode:=sizeItem.FirstOrDefault().SeasonCode)

                            newProductColor.AddProductColorSizes(productColorSizes:=New List(Of ProductColorSize) From {newProductColorSize})
                        Next

                        newProductColors.Add(newProductColor)
                        color.AddProductColors(New List(Of ProductColor) From {newProductColor})
                    Next
                Next

                Dim productColorDataService = MainServiceProvider.GetRequiredService(Of IProductColorDataService)
                Await productColorDataService.SaveManyAsync(entities:=newProductColors, userId:=Z_UserID)

                Dim inventoryLocationDataService = MainServiceProvider.GetRequiredService(Of IInventoryLocationDataService)

                Await inventoryLocationDataService.PopulateAllInventoryLocationWithProductColorSizesAsync(
                    organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    productCodes:=productCodes)

                MessageBox.Show(text:="Product(s) imported successfully!",
                    caption:="Success — import product(s)",
                    buttons:=MessageBoxButtons.OK,
                    icon:=MessageBoxIcon.Information)

            End Function)
    End Function

End Class