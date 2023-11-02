Imports System.IO
Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class ProductsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim fileOpener As OpenFileDialog = New OpenFileDialog()
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim fs As FileStream
    Dim br As BinaryReader
    Dim sqlquery As String
    Dim ImageData() As Byte
    Dim productimage As Object
    Dim itemno, rowscount As Integer
    Dim cueA, cueB, searchmode As String
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim pfproductid, pfcategoryid, pfbrandid, pfcompanyid, pfskuid, pfSKU2id, pfproductcolorsizeid As Integer
    Dim pftotalqtyavailable, pftotalqtyallocated, pftotalqtyreserve As Integer
    Dim simplesearchphrase, commonphrase, pagefilter1, pagefilter2, pagefilter3 As String
    Private _systemOwner As WarehouseManagementSystem.Core.Entities.SystemOwner
    Private _picp As ProductImageConfigParser
    Private _pim As ProductImageManager
    Public Const VIEW_NAME As String = "Products"

    Private Async Sub ProductManagementForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        _picp = New ProductImageConfigParser(filePath:=CONFIG_FILE_PATH)

        _pim = New ProductImageManager(_picp,
            organizationId:=Z_OrganizationID,
            userId:=Z_UserID,
            viewName:=VIEW_NAME)

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayProductList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ProductManagementForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , lblsavemsg, , , 1)
            myBalloon(, , pbAutoAddA, , , 1)
            myBalloon(, , pbAutoAddB, , , 1)
            myBalloon(, , pbAutoAddC, , , 1)
            myBalloon(, , pbAutoAddD, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Functions"

    Sub callAutoCompleteFunctions()
        autocompleteBrandName(cboBrandName, "AND b.`status` = 'Active'")
        autocompleteCategory(cboCategory, "AND c.`status` = 'Active'")
        autocompleteCompany(cboCompany, "AND c.`status` = 'Active'")
        globalautocompleteListOfValues(cboUnitOfMeasure, "Unit Of Measure", Me)
    End Sub

    Sub callAutoPopulateFunctions()
        autopopulatecboSearch()
        autopopulateBrandName(cboBrandName, "AND b.`status` = 'Active'")
        autopopulateCategory(cboCategory, "AND c.`status` = 'Active'")
        autopopulateCompany(cboCompany, "AND c.`status` = 'Active'")
        globalautopopulateListOfValues(cboUnitOfMeasure, "Unit Of Measure", Me)
    End Sub

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cueA = ""
            cueB = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearProductInformation()
            clearImage()
            clearProductSubInfo()
            clearTags()
            clearDataGrids()
            enableGB(legit, fraud, fraud)
            enableANDvisibleMS(fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cueA = ""
            cueB = ""
            clearProductInformation()
            clearImage()
            clearProductSubInfo()
            clearTags()
            clearDataGrids()
            enableGB(legit, fraud, fraud)
            enableANDvisibleMS(legit)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearSearchItems()
        Try
            txtSimpleSearch.Text = ""
            txtPageNo.Text = ""
            txtPage.Text = ""
            cboSearch2.Text = ""
            cboSearch4.Text = ""
            cboSearch1.SelectedItem = Nothing
            cboSearch2.SelectedItem = Nothing
            cboSearch3.SelectedItem = Nothing
            cboSearch4.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearcboSearch()
        Try
            txtPage.Text = ""
            cboSearch1.SelectedItem = Nothing : cboSearch3.SelectedItem = Nothing
            cboSearch2.Items.Clear() : cboSearch2.AutoCompleteCustomSource.Clear()
            cboSearch2.Text = "" : cboSearch2.SelectedItem = Nothing
            cboSearch4.Items.Clear() : cboSearch4.AutoCompleteCustomSource.Clear()
            cboSearch4.Text = "" : cboSearch4.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearProductInformation()
        Try
            txtProductCode.Text = ""
            cboUnitOfMeasure.Text = ""
            cboBrandName.Text = ""
            cboCategory.Text = ""
            cboCompany.Text = ""
            txtSRP.Text = ""
            txtDescription.Text = ""
            cboBrandName.SelectedItem = Nothing
            cboUnitOfMeasure.SelectedItem = Nothing
            cboCategory.SelectedItem = Nothing
            cboCompany.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearImage()
        Try
            txtImagePath.Clear()
            pbProductImage.Image = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearProductSubInfo()
        Try
            txtSumQtyAvailable.Text = ""
            txtSumQtyAllocated.Text = ""
            txtSumQtyReserve.Text = ""
            txtSKU.Text = ""
            txtSKU2.Text = ""
            txtEditSeasonCode.Text = ""
            txtLastShipmentDate.Text = ""
            txtLastSoldDate.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearTags()
        Try
            txtColor.Text = ""
            txtSize.Text = ""
            txtSeasonCode.Text = ""
            txtLocation.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearDataGrids()
        Try
            dgProductColors.Rows.Clear()
            dgProductSizes.Rows.Clear()
            dgInventoryLocations.Rows.Clear()
            dgRackShelfColumn.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbProductList.Enabled = enable1
            gbProductInformation.Enabled = enable2
            gbProductImage.Enabled = enable2
            gbProductColor.Enabled = enable3
            gbProductSize.Enabled = enable3
            gbInventoryLocation.Enabled = enable3
            gbRackShelfColumn.Enabled = enable3
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableANDvisibleMS(ByVal enable1 As Boolean)
        Try
            msSave.Enabled = enable1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Click"

    Sub tsrefreshperformclick()
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayProductList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Computations"

    Sub totalcomputation()
        Try
            pftotalqtyavailable = 0 : pftotalqtyallocated = 0 : pftotalqtyreserve = 0
            If dgProductSizes.Rows.Count <> 0 Then
                For i = 0 To dgProductSizes.Rows.Count - 1
                    If IsNumeric(dgProductSizes.Rows(i).Cells("s_totalqtyavailable").Value) Then
                        pftotalqtyavailable = pftotalqtyavailable + CInt(dgProductSizes.Rows(i).Cells("s_totalqtyavailable").Value)
                    End If
                    If IsNumeric(dgProductSizes.Rows(i).Cells("s_totalqtyallocated").Value) Then
                        pftotalqtyallocated = pftotalqtyallocated + CInt(dgProductSizes.Rows(i).Cells("s_totalqtyallocated").Value)
                    End If
                    If IsNumeric(dgProductSizes.Rows(i).Cells("s_totalqtyreserve").Value) Then
                        pftotalqtyreserve = pftotalqtyreserve + CInt(dgProductSizes.Rows(i).Cells("s_totalqtyreserve").Value)
                    End If
                Next
            End If
            txtSumQtyAvailable.Text = Format(pftotalqtyavailable, "#,##0")
            txtSumQtyAllocated.Text = Format(pftotalqtyallocated, "#,##0")
            txtSumQtyReserve.Text = Format(pftotalqtyreserve, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Page Setup"

    Sub pageSetup()
        Try
            getCountPageNum()
            If countpagenum < pagedivisor Then
                validpages = startingpage
            Else
                additionalpage = countpagenum / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpages = countpagenum / pagedivisor
                Else
                    validpages = countpagenum / pagedivisor
                    validpages = validpages + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNum()
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COUNT(p.rowid) FROM products p WHERE p.organizationid = " & Z_OrganizationID & " ")
            If dtCid.Rows.Count <> 0 Then
                countpagenum = dtCid.Rows(0)(0)
            Else
                countpagenum = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetup1(ByVal isearchstring As String)
        Try
            getCountPageNum1(isearchstring)
            If countpagenum < pagedivisor Then
                validpages = startingpage
            Else
                additionalpage = countpagenum / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpages = countpagenum / pagedivisor
                Else
                    validpages = countpagenum / pagedivisor
                    validpages = validpages + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNum1(ByVal esearchstring As String)
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COUNT(p.rowid) FROM products p LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN categories ct ON p.categoryid = ct.rowid LEFT JOIN companies cm ON p.companyid = cm.rowid WHERE p.organizationid = " & Z_OrganizationID & " AND " &
                            "(p.productcode LIKE ""%" & esearchstring & "%"" OR b.brandname LIKE ""%" & esearchstring & "%"" OR ct.categoryname LIKE ""%" & esearchstring & "%"" OR cm.companyname LIKE ""%" & esearchstring & "%"")")
            If dtCid.Rows.Count <> 0 Then
                countpagenum = dtCid.Rows(0)(0)
            Else
                countpagenum = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetup2(ByVal isearchstring As String)
        Try
            getCountPageNum2(isearchstring)
            If countpagenum < pagedivisor Then
                validpages = startingpage
            Else
                additionalpage = countpagenum / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpages = countpagenum / pagedivisor
                Else
                    validpages = countpagenum / pagedivisor
                    validpages = validpages + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNum2(ByVal ecommontring As String)
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COUNT(p.rowid) FROM products p LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN categories ct ON p.categoryid = ct.rowid " &
                            "LEFT JOIN companies cm ON p.companyid = cm.rowid WHERE p.organizationid = " & Z_OrganizationID & " AND " & ecommontring & " ")
            If dtCid.Rows.Count <> 0 Then
                countpagenum = dtCid.Rows(0)(0)
            Else
                countpagenum = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCommonPhrase(ByVal icommonbox As ComboBox, ByVal icommonstring As String)
        Try
            commonphrase = ""
            If icommonbox.Text = "BrandName" Then
                commonphrase = "b.brandname = """ & icommonstring & """"
            ElseIf icommonbox.Text = "Category" Then
                commonphrase = "ct.categoryname = """ & icommonstring & """"
            ElseIf icommonbox.Text = "VendorName" Then
                commonphrase = "cm.companyname = """ & icommonstring & """"
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Display"

#Region "AutoComplete"

    Sub autocompleteBrandName(ByVal icombobox As ComboBox, ByVal istatuscondition As String)
        Try
            Dim brandname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(b.brandname,'') AS 'brandname' FROM brands b WHERE b.organizationid = " & Z_OrganizationID & " " & istatuscondition & " GROUP BY b.brandname ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                brandname.Add(ds.Tables(0).Rows(i)("brandname").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = brandname
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteCategory(ByVal icombobox As ComboBox, ByVal istatuscondition As String)
        Try
            Dim categoryname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.categoryname,'') AS 'categoryname' FROM categories c WHERE c.organizationid = " & Z_OrganizationID & " " & istatuscondition & " GROUP BY c.categoryname ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                categoryname.Add(ds.Tables(0).Rows(i)("categoryname").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = categoryname
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteCompany(ByVal icombobox As ComboBox, ByVal istatuscondition As String)
        Try
            Dim companyname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.companyname,'') AS 'companyname' FROM companies c WHERE c.organizationid = " & Z_OrganizationID & " " & istatuscondition & " GROUP BY c.companyname ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                companyname.Add(ds.Tables(0).Rows(i)("companyname").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = companyname
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "AutoPopulate"

    Sub autopopulatecboSearch()
        Try
            cboSearch1.Items.Clear()
            cboSearch3.Items.Clear()
            cboSearch1.Items.Add("BrandName")
            cboSearch1.Items.Add("Category")
            cboSearch1.Items.Add("VendorName")
            cboSearch3.Items.Add("BrandName")
            cboSearch3.Items.Add("Category")
            cboSearch3.Items.Add("VendorName")
            cboSearch1.Items.Add("")
            cboSearch3.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulateBrandName(ByVal icombobox As ComboBox, ByVal istatuscondition As String)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(b.brandname,'') AS 'brandname' FROM brands b WHERE b.organizationid = " & Z_OrganizationID & " " & istatuscondition & " GROUP BY b.brandname ORDER BY b.brandname "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                icombobox.Items.Add(reader1(0).ToString())
            End While
            icombobox.Items.Add("")
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulateCategory(ByVal icombobox As ComboBox, ByVal istatuscondition As String)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.categoryname,'') AS 'categoryname' FROM categories c WHERE c.organizationid = " & Z_OrganizationID & " " & istatuscondition & " GROUP BY c.categoryname ORDER BY c.categoryname "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                icombobox.Items.Add(reader1(0).ToString())
            End While
            icombobox.Items.Add("")
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulateCompany(ByVal icombobox As ComboBox, ByVal istatuscondition As String)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.companyname,'') AS 'companyname' FROM companies c WHERE c.organizationid = " & Z_OrganizationID & " " & istatuscondition & " GROUP BY c.companyname ORDER BY c.companyname "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                icombobox.Items.Add(reader1(0).ToString())
            End While
            icombobox.Items.Add("")
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Datagrids/Information"

    Sub displayProductList(ByVal istartpage As Integer)
        Try
            dgProductList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT p.rowid,COALESCE(p.productcode,''),COALESCE(b.brandname,''),COALESCE(ct.categoryname,''),COALESCE(cm.companyname,'') FROM products p " &
                        "LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN categories ct ON p.categoryid = ct.rowid LEFT JOIN companies cm ON p.companyid = cm.rowid " &
                        "WHERE p.organizationid = " & Z_OrganizationID & " ORDER BY p.productcode ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer
            If istartpage = neutralpage Then
                seqno = 1
            Else
                seqno = istartpage + 1
            End If
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductList.Rows.Add()
                    dgProductList.Item(p_rowid.Index, n).Value = reader1(0)
                    dgProductList.Item(p_seqno.Index, n).Value = seqno
                    dgProductList.Item(p_productcode.Index, n).Value = reader1(1)
                    dgProductList.Item(p_brandname.Index, n).Value = reader1(2)
                    dgProductList.Item(p_category.Index, n).Value = reader1(3)
                    dgProductList.Item(p_company.Index, n).Value = reader1(4)
                    dgProductList.Item(PhotoResourceLocation.Index, n).Value = _pim.GetPhotoUrl(productCode:=reader1(1))
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductList.Columns("p_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_brandname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_category").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_company").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductList.Rows.Count <> 0 Then
                dgProductList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgProductList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT p.rowid,COALESCE(p.productcode,''),COALESCE(b.brandname,''),COALESCE(ct.categoryname,''),COALESCE(cm.companyname,'') FROM products p " &
                        "LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN categories ct ON p.categoryid = ct.rowid LEFT JOIN companies cm ON p.companyid = cm.rowid WHERE p.organizationid = " & Z_OrganizationID & " AND " &
                        "(p.productcode LIKE ""%" & isearchphrase & "%"" OR b.brandname LIKE ""%" & isearchphrase & "%"" OR ct.categoryname LIKE ""%" & isearchphrase & "%"" OR cm.companyname LIKE ""%" & isearchphrase & "%"") " &
                        "ORDER BY p.productcode ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer
            If istartpage = neutralpage Then
                seqno = 1
            Else
                seqno = istartpage + 1
            End If
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductList.Rows.Add()
                    dgProductList.Item(p_rowid.Index, n).Value = reader1(0)
                    dgProductList.Item(p_seqno.Index, n).Value = seqno
                    dgProductList.Item(p_productcode.Index, n).Value = reader1(1)
                    dgProductList.Item(p_brandname.Index, n).Value = reader1(2)
                    dgProductList.Item(p_category.Index, n).Value = reader1(3)
                    dgProductList.Item(p_company.Index, n).Value = reader1(4)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductList.Columns("p_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_brandname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_category").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_company").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductList.Rows.Count <> 0 Then
                dgProductList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal istartpage As Integer)
        Try
            dgProductList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT p.rowid,COALESCE(p.productcode,''),COALESCE(b.brandname,''),COALESCE(ct.categoryname,''),COALESCE(cm.companyname,'') FROM products p " &
                        "LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN categories ct ON p.categoryid = ct.rowid LEFT JOIN companies cm ON p.companyid = cm.rowid " &
                        "WHERE p.organizationid = " & Z_OrganizationID & " AND " & icommonphrase & " ORDER BY p.productcode ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer
            If istartpage = neutralpage Then
                seqno = 1
            Else
                seqno = istartpage + 1
            End If
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductList.Rows.Add()
                    dgProductList.Item(p_rowid.Index, n).Value = reader1(0)
                    dgProductList.Item(p_seqno.Index, n).Value = seqno
                    dgProductList.Item(p_productcode.Index, n).Value = reader1(1)
                    dgProductList.Item(p_brandname.Index, n).Value = reader1(2)
                    dgProductList.Item(p_category.Index, n).Value = reader1(3)
                    dgProductList.Item(p_company.Index, n).Value = reader1(4)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductList.Columns("p_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_brandname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_category").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductList.Columns("p_company").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductList.Rows.Count <> 0 Then
                dgProductList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayProductInformation(ByVal iproductid As Integer)
        Try
            productimage = Nothing
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(p.productcode,''),COALESCE(b.brandname,''),COALESCE(ct.categoryname,''),COALESCE(cm.companyname,''),COALESCE(p.unitprice,0.0)," &
                        "COALESCE(p.unitofmeasure,''),COALESCE(p.description,''),p.image FROM products p LEFT JOIN brands b ON p.brandid = b.rowid " &
                        "LEFT JOIN categories ct ON p.categoryid = ct.rowid LEFT JOIN companies cm ON p.companyid = cm.rowid WHERE p.rowid = " & iproductid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtProductCode.Text = reader1(0)
                    cboBrandName.Text = reader1(1)
                    cboCategory.Text = reader1(2)
                    cboCompany.Text = reader1(3)
                    txtSRP.Text = reader1(4)
                    cboUnitOfMeasure.Text = reader1(5)
                    txtDescription.Text = reader1(6)
                    productimage = reader1(7)
                    If IsDBNull(productimage) Then
                        pbProductImage.Image = Nothing
                    Else
                        pbProductImage.Image = ConvertByteToImage(productimage)
                    End If
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
            PictureBox1.LoadAsync(url:=dgProductList.CurrentRow?.Cells(PhotoResourceLocation.Name).Value)
        End Try
    End Sub

    Sub displayProductColors(ByVal iproductid As Integer)
        Try
            dgProductColors.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pc.rowid,COALESCE(c.colorvalue,''),COALESCE(c.colorname,'') FROM productcolors pc LEFT JOIN colors c ON pc.colorid = c.rowid " &
                            "WHERE pc.organizationid = " & Z_OrganizationID & " AND pc.productid = " & iproductid & " ORDER BY c.colorname ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductColors.Rows.Add()
                    dgProductColors.Item(c_seqno.Index, n).Value = seqno
                    dgProductColors.Item(c_rowid.Index, n).Value = reader1(0)
                    dgProductColors.Item(c_colorvalue.Index, n).Value = reader1(1)
                    dgProductColors.Item(c_colorname.Index, n).Value = reader1(2)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductColors.Columns("c_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColors.Columns("c_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductColors.Rows.Count <> 0 Then
                dgProductColors.CurrentRow.Selected = False
            End If
            colorCoding()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayProductSizes(ByVal iproductcolorid As Integer)
        Try
            dgProductSizes.Rows.Clear()
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = $"SELECT pcs.rowid,COALESCE(pcs.size,''),COALESCE(pcs.status,''),COALESCE(pcs.seasoncode,''), p.ProductCode FROM productcolorsizes pcs INNER JOIN productcolors pc ON pc.RowID=pcs.ProductColorID INNER JOIN products p ON p.RowID=pc.ProductID WHERE pcs.organizationid = {Z_OrganizationID} AND pcs.productcolorid = {iproductcolorid} ORDER BY pcs.size ASC;"
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductSizes.Rows.Add()
                    dgProductSizes.Item(s_rowid.Index, n).Value = reader1(0)
                    dgProductSizes.Item(s_sizes.Index, n).Value = reader1(1)
                    If reader1(2) = "Active" Then
                        dgProductSizes.Item(s_active.Index, n).Value = legit
                    Else
                        dgProductSizes.Item(s_active.Index, n).Value = fraud
                    End If
                    dgProductSizes.Item(s_seasoncode.Index, n).Value = reader1(3)
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    dgProductSizes.Item(s_totalqtyavailable.Index, n).Value = globaltotalqtyavailable
                    getTotalQtyAllocatedA(CInt(reader1(0)), Me)
                    dgProductSizes.Item(s_totalqtyallocated.Index, n).Value = globaltotalqtyallocated
                    getTotalQtyReserveA(CInt(reader1(0)), Me)
                    dgProductSizes.Item(s_totalqtyreserve.Index, n).Value = globaltotalqtyreserve
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductSizes.Columns("s_sizes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_totalqtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_totalqtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_totalqtyreserve").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductSizes.Rows.Count <> 0 Then
                dgProductSizes.CurrentRow.Selected = False
            End If

            colorCoding()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayInventoryLocations(ByVal iproductcolorsizeid As Integer)
        Try
            dgInventoryLocations.Rows.Clear()
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(rsc.inventorylocationid,0),COALESCE(il.name,''),COALESCE(il.type,'') FROM productinventorylocation pil " &
                            "LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid LEFT JOIN inventorylocations il ON rsc.inventorylocationid = il.rowid " &
                            "WHERE pil.organizationid = " & Z_OrganizationID & " AND pil.productcolorsizeid = " & iproductcolorsizeid & " GROUP BY il.name ORDER BY il.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgInventoryLocations.Rows.Add()
                    dgInventoryLocations.Item(il_seqno.Index, n).Value = seqno
                    dgInventoryLocations.Item(il_rowid.Index, n).Value = reader1(0)
                    dgInventoryLocations.Item(il_locationname.Index, n).Value = reader1(1)
                    dgInventoryLocations.Item(il_locationtype.Index, n).Value = reader1(2)
                    getTotalQtyAvailableB(iproductcolorsizeid, CInt(reader1(0)), Me)
                    dgInventoryLocations.Item(il_totalqtyavailable.Index, n).Value = globaltotalqtyavailable
                    getTotalQtyAllocatedB(iproductcolorsizeid, CInt(reader1(0)), Me)
                    dgInventoryLocations.Item(il_totalqtyallocated.Index, n).Value = globaltotalqtyallocated
                    getTotalQtyReserveB(iproductcolorsizeid, CInt(reader1(0)), Me)
                    dgInventoryLocations.Item(il_totalqtyreserve.Index, n).Value = globaltotalqtyreserve
                    getTotalQtyDamageA(iproductcolorsizeid, Me)
                    dgInventoryLocations.Item(il_totalqtydamage.Index, n).Value = globaltotalqtydamage
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgInventoryLocations.Columns("il_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocations.Columns("il_locationtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocations.Columns("il_totalqtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocations.Columns("il_totalqtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocations.Columns("il_totalqtyreserve").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocations.Columns("il_totalqtydamage").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgInventoryLocations.Rows.Count <> 0 Then
                dgInventoryLocations.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayRackShelfColumn(ByVal iproductcolorsizeid As Integer, ByVal iinventorylocationid As Integer)
        Try
            dgRackShelfColumn.Rows.Clear()
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT pil.rowid,COALESCE(rsc.rackno,''),COALESCE(rsc.shelfno,''),COALESCE(rsc.columnno,''),COALESCE(pil.totalavailableqty,0),COALESCE(pil.totalreserveqty,0)," &
                            "COALESCE(pil.totaldamageqty,0),COALESCE(pil.totalallocatedqty,0) FROM productinventorylocation pil LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " &
                            "WHERE pil.organizationid = " & Z_OrganizationID & " AND pil.productcolorsizeid = " & iproductcolorsizeid & "  AND rsc.inventorylocationid = " & iinventorylocationid & " ORDER BY rsc.pickorderno ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgRackShelfColumn.Rows.Add()
                    dgRackShelfColumn.Item(rsc_seqno.Index, n).Value = seqno
                    dgRackShelfColumn.Item(rsc_rowid.Index, n).Value = reader1(0)
                    dgRackShelfColumn.Item(rsc_rack.Index, n).Value = reader1(1)
                    dgRackShelfColumn.Item(rsc_shelf.Index, n).Value = reader1(2)
                    dgRackShelfColumn.Item(rsc_column.Index, n).Value = reader1(3)
                    dgRackShelfColumn.Item(rsc_qtyavailable.Index, n).Value = reader1(4)
                    dgRackShelfColumn.Item(rsc_qtyreserve.Index, n).Value = reader1(5)
                    dgRackShelfColumn.Item(rsc_qtydamage.Index, n).Value = reader1(6)
                    dgRackShelfColumn.Item(rsc_qtyallocated.Index, n).Value = reader1(7)
                    dgRackShelfColumn.Item(rsc_qtyorderable.Index, n).Value = CInt(reader1(4)) - CInt(reader1(7))
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgRackShelfColumn.Columns("rsc_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_rack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_shelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_column").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_qtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_qtyorderable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_qtyreserve").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_qtydamage").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgRackShelfColumn.Rows.Count <> 0 Then
                dgRackShelfColumn.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayProductColorSizesInformation(ByVal iproductcolorsizesid As Integer)
        Try
            If conn1.State = ConnectionState.Open Then conn1.Close()
            Dim dtPcs As New DataTable
            dtPcs = getDataTableForSQL("SELECT COALESCE(pcs.sku,''),COALESCE(DATE_FORMAT(pcs.lastshipmentdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(pcs.lastsolddate,'%d-%b-%Y'),''),COALESCE(pcs.seasoncode,''),IFNULL(pcs.sku2,'') `sku2` FROM productcolorsizes pcs WHERE pcs.rowid = " & iproductcolorsizesid & " ")
            If dtPcs.Rows.Count <> 0 Then
                txtSKU.Text = dtPcs.Rows(0)(0)
                txtLastShipmentDate.Text = dtPcs.Rows(0)(1)
                txtLastSoldDate.Text = dtPcs.Rows(0)(2)
                txtEditSeasonCode.Text = dtPcs.Rows(0)(3)
                txtSKU2.Text = dtPcs.Rows(0)(4)
            Else
                txtSKU.Text = ""
                txtLastShipmentDate.Text = ""
                txtLastSoldDate.Text = ""
                txtEditSeasonCode.Text = ""
                txtSKU2.Text = String.Empty
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

#End Region

#Region "Colors"

    Sub colorCoding()
        Try
            If dgProductColors.Rows.Count <> 0 Then
                For i As Integer = 0 To dgProductColors.Rows.Count - 1
                    If CStr(dgProductColors.Rows(i).Cells("c_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgProductColors.Rows(i).Cells("c_colorvalue").Value))
                        dgProductColors.Rows(i).Cells("c_color").Style.BackColor = readcolor
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

#Region "Image"

    Sub downloadImage()
        Try
            Dim ctr As Integer = 0
            Dim sFilename As String = "Image_"
            Dim ext As String = ".jpeg"
            If (Not System.IO.Directory.Exists("c:\AttachedImages")) Then
                System.IO.Directory.CreateDirectory("c:\AttachedImages")
                Dim path As String = System.IO.Path.Combine("c:\AttachedImages", sFilename & ctr & ext)
                Dim dest As New Bitmap(ConvertByteToImage(productimage).Width, ConvertByteToImage(productimage).Height)
                Dim gfx As Graphics = Graphics.FromImage(dest)
                gfx.DrawImageUnscaled(ConvertByteToImage(productimage), Point.Empty)
                gfx.Dispose()
                dest.Save(path)
                dest.Dispose()
                MessageBox.Show("Image saved to c:\AttachedImages as " & sFilename & ctr & ext, "System Message")
                Dim info As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(path)
                path = info.DirectoryName
                Shell("explorer /select, " & "c:\AttachedImages\" & sFilename & ctr & ext, vbNormalFocus)
            Else
                ctr = 0
                While ctr >= 0
                    Dim path As String = System.IO.Path.Combine("c:\AttachedImages", sFilename & ctr & ext)
                    If System.IO.File.Exists(path) = True Then
                        ctr = ctr + 1
                        Continue While
                    ElseIf System.IO.File.Exists(path) = False Then
                        Dim newPath As String = System.IO.Path.Combine("c:\AttachedImages", sFilename & ctr & ext)
                        Dim dest As New Bitmap(ConvertByteToImage(productimage).Width, ConvertByteToImage(productimage).Height)
                        Dim gfx As Graphics = Graphics.FromImage(dest)
                        gfx.DrawImageUnscaled(ConvertByteToImage(productimage), Point.Empty)
                        gfx.Dispose()
                        dest.Save(newPath)
                        dest.Dispose()
                        MessageBox.Show("Image saved to c:\Attached_Images as " & sFilename & ctr & ext, "System Message")
                        Shell("explorer /select, " & "c:\AttachedImages\" & sFilename & ctr & ext, vbNormalFocus)
                        Exit While
                    End If
                End While
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

    Private Sub tabMain_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabMain.DrawItem
        Try
            TabControlColor(tabMain, e)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.PrdForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtDescription_Leave(sender As Object, e As EventArgs) Handles txtDescription.Leave
        Try
            txtProductCode.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnDownloadImage_Leave(sender As Object, e As EventArgs) Handles btnDownloadImage.Leave
        Try
            btnChangeImage.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub tsRefresh_Click(sender As Object, e As EventArgs) Handles tsRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            tsrefreshperformclick()
            myBalloon("Successfully Refreshed", "Refresh", lblsavemsg, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsColors_Click(sender As Object, e As EventArgs) Handles tsColors.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Products", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PrdForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            Dim colorslinkform As New ColorsForm
            colorslinkform.ShowInTaskbar = False
            colorslinkform.ShowDialog()
            If colorslinkform.cfcue = legit Then
                If cueA = "Edit" Then
                    cueB = ""
                    clearProductSubInfo()
                    clearTags()
                    clearDataGrids()
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit)
                    displayProductInformation(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value))
                    displayProductColors(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value))
                    txtSKU.ReadOnly = legit : txtEditSeasonCode.ReadOnly = legit
                    txtProductCode.Focus()
                    txtSKU2.ReadOnly = legit
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAutoAddA_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddA.MouseEnter
        Try
            pbAutoAddA.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddA_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddA.MouseLeave
        Try
            pbAutoAddA.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddA_Click(sender As Object, e As EventArgs) Handles pbAutoAddA.Click
        Try
            myBalloon("Automatic adding of brand name.", "Auto-Add", pbAutoAddA, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddB_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddB.MouseEnter
        Try
            pbAutoAddB.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddB_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddB.MouseLeave
        Try
            pbAutoAddB.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddB_Click(sender As Object, e As EventArgs) Handles pbAutoAddB.Click
        Try
            myBalloon("Automatic adding of category.", "Auto-Add", pbAutoAddB, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddC_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddC.MouseEnter
        Try
            pbAutoAddC.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddC_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddC.MouseLeave
        Try
            pbAutoAddC.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddC_Click(sender As Object, e As EventArgs) Handles pbAutoAddC.Click
        Try
            myBalloon("Automatic adding of vendor name.", "Auto-Add", pbAutoAddC, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddD_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddD.MouseEnter
        Try
            pbAutoAddD.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddD_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddD.MouseLeave
        Try
            pbAutoAddD.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddD_Click(sender As Object, e As EventArgs) Handles pbAutoAddD.Click
        Try
            myBalloon("Automatic adding of unit of measure.", "Auto-Add", pbAutoAddD, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgProductList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductList.CellContentClick

    End Sub

    Private Sub dgProductList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductList.Rows.Count <> 0 Then
                cueA = "Edit"
                cueB = ""
                errProvider.Clear()
                clearProductInformation()
                clearImage()
                clearProductSubInfo()
                clearTags()
                clearDataGrids()
                enableGB(legit, legit, legit)
                enableANDvisibleMS(legit)
                displayProductInformation(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value))
                displayProductColors(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value))
                txtSKU.ReadOnly = legit : txtEditSeasonCode.ReadOnly = legit
                txtProductCode.Focus()
                txtSKU2.ReadOnly = legit
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgProductList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cueA = "Edit"
                    cueB = ""
                    errProvider.Clear()
                    clearProductInformation()
                    clearImage()
                    clearProductSubInfo()
                    clearTags()
                    clearDataGrids()
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit)
                    displayProductInformation(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value))
                    displayProductColors(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value))
                    txtSKU.ReadOnly = legit : txtEditSeasonCode.ReadOnly = legit
                    txtProductCode.Focus()
                    txtSKU2.ReadOnly = legit
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductColors_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductColors.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductColors.Rows.Count <> 0 Then
                cueB = ""
                clearProductSubInfo()
                clearTags()
                dgInventoryLocations.Rows.Clear() : dgRackShelfColumn.Rows.Clear()
                displayProductSizes(CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value))
                totalcomputation()
                txtSKU.ReadOnly = legit : txtEditSeasonCode.ReadOnly = legit
                txtColor.Text = dgProductColors.CurrentRow.Cells("c_colorname").Value
                txtSize.Text = ""
                txtSeasonCode.Text = ""
                txtLocation.Text = ""
                txtSKU2.ReadOnly = legit
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductColors_KeyUp(sender As Object, e As KeyEventArgs) Handles dgProductColors.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductColors.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cueB = ""
                    clearProductSubInfo()
                    clearTags()
                    dgInventoryLocations.Rows.Clear() : dgRackShelfColumn.Rows.Clear()
                    displayProductSizes(CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value))
                    totalcomputation()
                    txtSKU.ReadOnly = legit : txtEditSeasonCode.ReadOnly = legit
                    txtColor.Text = dgProductColors.CurrentRow.Cells("c_colorname").Value
                    txtSize.Text = ""
                    txtSeasonCode.Text = ""
                    txtLocation.Text = ""
                    txtSKU2.ReadOnly = legit
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductSizes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductSizes.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                cueB = "Edit"
                txtSKU.ReadOnly = fraud : txtEditSeasonCode.ReadOnly = fraud
                displayProductColorSizesInformation(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value))
                displayInventoryLocations(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value))
                txtSize.Text = dgProductSizes.CurrentRow.Cells("s_sizes").Value
                txtSeasonCode.Text = dgProductSizes.CurrentRow.Cells("s_seasoncode").Value
                txtSKU2.ReadOnly = fraud
                If dgInventoryLocations.Rows.Count <> 0 Then
                    For c = 0 To dgInventoryLocations.Rows.Count - 1
                        displayRackShelfColumn(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), CInt(dgInventoryLocations.Rows(c).Cells("il_rowid").Value))
                        txtLocation.Text = dgInventoryLocations.Rows(c).Cells("il_locationname").Value
                        Exit For
                    Next
                Else
                    dgRackShelfColumn.Rows.Clear()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductSizes_KeyUp(sender As Object, e As KeyEventArgs) Handles dgProductSizes.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cueB = "Edit"
                    txtSKU.ReadOnly = fraud : txtEditSeasonCode.ReadOnly = fraud
                    displayProductColorSizesInformation(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value))
                    displayInventoryLocations(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value))
                    txtSize.Text = dgProductSizes.CurrentRow.Cells("s_sizes").Value
                    txtSeasonCode.Text = dgProductSizes.CurrentRow.Cells("s_seasoncode").Value
                    txtSKU2.ReadOnly = fraud
                    If dgInventoryLocations.Rows.Count <> 0 Then
                        For c = 0 To dgInventoryLocations.Rows.Count - 1
                            displayRackShelfColumn(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), CInt(dgInventoryLocations.Rows(c).Cells("il_rowid").Value))
                            txtLocation.Text = dgInventoryLocations.Rows(c).Cells("il_locationname").Value
                            Exit For
                        Next
                    Else
                        dgRackShelfColumn.Rows.Clear()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgInventoryLocations_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgInventoryLocations.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgInventoryLocations.Rows.Count <> 0 Then
                If CStr(dgInventoryLocations.CurrentRow.Cells("il_locationtype").Value) = "Main" Then
                    displayRackShelfColumn(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), CInt(dgInventoryLocations.CurrentRow.Cells("il_rowid").Value))
                    txtLocation.Text = dgInventoryLocations.CurrentRow.Cells("il_locationname").Value
                Else
                    dgRackShelfColumn.Rows.Clear()
                    txtLocation.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgInventoryLocations_KeyUp(sender As Object, e As KeyEventArgs) Handles dgInventoryLocations.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgInventoryLocations.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    If CStr(dgInventoryLocations.CurrentRow.Cells("il_locationtype").Value) = "Main" Then
                        displayRackShelfColumn(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), CInt(dgInventoryLocations.CurrentRow.Cells("il_rowid").Value))
                        txtLocation.Text = dgInventoryLocations.CurrentRow.Cells("il_locationname").Value
                    Else
                        dgRackShelfColumn.Rows.Clear()
                        txtLocation.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub btnChangeImage_Click(sender As Object, e As EventArgs) Handles btnChangeImage.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Products", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PrdForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            fileOpener.Filter = "Image files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png"

            If IsThurston Then fileOpener.Filter = "Image files (*.jpg)|*.jpg"

            If fileOpener.ShowDialog() = Windows.Forms.DialogResult.OK Then
                pbProductImage.Image = Image.FromFile(fileOpener.FileName)
                txtImagePath.Text = fileOpener.FileName

                If dgProductList.CurrentRow IsNot Nothing AndAlso
                    IsThurston Then

                    Dim errorCallback = Sub()
                                            Me.Cursor = Cursors.Default
                                        End Sub

                    Await FunctionUtils.TryCatchFunctionAsync("Change Product Image",
                        action:=
                        Async Function()
                            Await _pim.ChangeAsync(productId:=CInt(dgProductList.CurrentRow?.Cells("p_rowid").Value),
                                sourceFileName:=fileOpener.FileName)

                            PictureBox1.LoadAsync(url:=dgProductList.CurrentRow?.Cells(PhotoResourceLocation.Name).Value)
                            PictureBox1.Refresh()

                            errorCallback()
                        End Function,
                        errorCallBack:=errorCallback)
                End If

            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub btnDeleteImage_Click(sender As Object, e As EventArgs) Handles btnDeleteImage.Click
        If dgProductList.CurrentRow IsNot Nothing AndAlso
            IsThurston Then

            Dim errorCallback = Sub()
                                    Me.Cursor = Cursors.Default
                                End Sub

            Await FunctionUtils.TryCatchFunctionAsync("Delete Product Image",
                action:=
                    Async Function()

                        Await _pim.DeleteAsync(productId:=CInt(dgProductList.CurrentRow?.Cells("p_rowid").Value))

                        errorCallback()
                    End Function,
                errorCallBack:=errorCallback)
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsDBNull(productimage) Then
                getPositionID(Me)
                If globalpositionid <> 0 Then
                    getPositionView(globalpositionid, "Products", Me)
                    If globaldisableflg = "Y" Then
                        MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        PrimaryForm.PrdForm = False
                        Me.Close()
                    End If
                    If globalreadonlyflg = "Y" Then
                        MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If globalcreateflg = "Y" Then
                        MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If MessageBox.Show("Would you like to permanently delete this image?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    myModule.systemerrorfound = False
                    U_ProductImage(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, DBNull.Value, Me)
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Deleted Image", "Delete", lblsavemsg, -15, -65)

                    End If
                End If
            End If
            If txtImagePath.Text <> "" Then
                txtImagePath.Clear()

            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub btnDownloadImage_Click(sender As Object, e As EventArgs) Handles btnDownloadImage.Click
        If dgProductList.CurrentRow IsNot Nothing AndAlso
            IsThurston Then

            Dim errorCallback = Sub()
                                    Me.Cursor = Cursors.Default
                                End Sub

            Await FunctionUtils.TryCatchFunctionAsync("Download Product Image",
                action:=
                    Async Function()

                        Await _pim.DownloadAsync(productId:=CInt(dgProductList.CurrentRow?.Cells("p_rowid").Value))

                        errorCallback()
                    End Function,
                errorCallBack:=errorCallback)
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsDBNull(productimage) Then
                getPositionID(Me)
                If globalpositionid <> 0 Then
                    getPositionView(globalpositionid, "Products", Me)
                    If globaldisableflg = "Y" Then
                        MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        PrimaryForm.PrdForm = False
                        Me.Close()
                    End If
                    If globalreadonlyflg = "Y" Then
                        MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If globalcreateflg = "Y" Then
                        MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                txtImagePath.Clear()
                pbProductImage.Image = ConvertByteToImage(productimage)
                If MessageBox.Show("Would you like to download this image?", "Downloading", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    myModule.systemerrorfound = False
                    downloadImage()
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Downloaded Image", "Download", lblsavemsg, -15, -65)
                    End If
                End If
            Else
                MessageBox.Show("System cannot find the image uploaded to this product.", "Downloading", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtProductCode_Leave(sender As Object, e As EventArgs) Handles txtProductCode.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cueA = "Edit" Then
                If dgProductList.Rows.Count <> 0 Then
                    getProductIDA(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value), txtProductCode.Text, Me)
                    pfproductid = globalproductid
                    If pfproductid <> 0 Then
                        errProvider.SetError(txtProductCode, "Product code has been created already, please type a new one.")
                        txtProductCode.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductSizes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductSizes.CellContentClick

    End Sub

    'Private Sub txtProductCode_TextChanged(sender As Object, e As EventArgs) Handles txtProductCode.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cueA = "Edit" Then
    '            If dgProductList.Rows.Count <> 0 Then
    '                getProductIDA(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value), txtProductCode.Text, Me)
    '                pfproductid = globalproductid
    '                If pfproductid <> 0 Then
    '                    errProvider.SetError(txtProductCode, "Product code has been created already, please type a new one.")
    '                    txtProductCode.Focus()
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub txtSKU_Leave(sender As Object, e As EventArgs) Handles txtSKU.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cueB = "Edit" Then
                If dgProductSizes.Rows.Count <> 0 Then
                    If LTrim(txtSKU.Text) <> "" Then
                        getProductColorSizesSKUB(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), txtSKU.Text, Me)
                        pfskuid = globalskuid
                        If pfskuid <> 0 Then
                            errProvider.SetError(lblSKU, "SKU has been created already, please type a new one.")
                            txtSKU.Focus()
                        Else
                            getProductBundleSKUA(txtSKU.Text, Me)
                            pfskuid = globalskuid
                            If pfskuid <> 0 Then
                                errProvider.SetError(lblSKU, "SKU has been created already, please type a new one.")
                                txtSKU.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtSKU2_Leave(sender As Object, e As EventArgs) Handles txtSKU2.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cueB = "Edit" Then
                If dgProductSizes.Rows.Count <> 0 Then
                    If LTrim(txtSKU2.Text) <> "" Then
                        getProductColorSizesSKU2B(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), txtSKU2.Text, Me)
                        pfSKU2id = globalSKU2id
                        If pfSKU2id <> 0 Then
                            errProvider.SetError(lblSKU2, "SKU2 has been created already, please type a new one.")
                            txtSKU2.Focus()
                        Else
                            getProductBundleSKU2A(txtSKU2.Text, Me)
                            pfSKU2id = globalSKU2id
                            If pfSKU2id <> 0 Then
                                errProvider.SetError(lblSKU2, "SKU2 has been created already, please type a new one.")
                                txtSKU2.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtEditSeasonCode_Leave(sender As Object, e As EventArgs) Handles txtEditSeasonCode.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cueB = "Edit" Then
                If dgProductColors.Rows.Count <> 0 Then
                    If dgProductSizes.Rows.Count <> 0 Then
                        If LTrim(txtEditSeasonCode.Text) <> "" Then
                            getProductColorSizesIDC(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value), CStr(dgProductSizes.CurrentRow.Cells("s_sizes").Value), txtEditSeasonCode.Text, Me)
                            pfproductcolorsizeid = globalproductcolorsizesid
                            If pfproductcolorsizeid <> 0 Then
                                errProvider.SetError(lblSeasonCode, "Same color, size, and season code has been created already, please type a new one.")
                                txtEditSeasonCode.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub txtEditSeasonCode_TextChanged(sender As Object, e As EventArgs) Handles txtEditSeasonCode.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cueB = "Edit" Then
    '            If dgProductColors.Rows.Count <> 0 Then
    '                If dgProductSizes.Rows.Count <> 0 Then
    '                    If LTrim(txtEditSeasonCode.Text) <> "" Then
    '                        getProductColorSizesIDC(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value), CStr(dgProductSizes.CurrentRow.Cells("s_sizes").Value), txtEditSeasonCode.Text, Me)
    '                        pfproductcolorsizeid = globalproductcolorsizesid
    '                        If pfproductcolorsizeid <> 0 Then
    '                            errProvider.SetError(lblSeasonCode, "Same color, size, and season code has been created already, please type a new one.")
    '                            txtEditSeasonCode.Focus()
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Async Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Products", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PrdForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If cueB = "Edit" Then
                If dgProductSizes.Rows.Count <> 0 Then
                    If LTrim(txtSKU.Text) <> "" Then
                        getProductColorSizesSKUB(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), txtSKU.Text, Me)
                        pfskuid = globalskuid
                        If pfskuid <> 0 Then
                            errProvider.SetError(lblSKU, "SKU has been created already, please type a new one.")
                            txtSKU.Focus()
                            Exit Try
                        Else
                            getProductBundleSKUA(txtSKU.Text, Me)
                            pfskuid = globalskuid
                            If pfskuid <> 0 Then
                                errProvider.SetError(lblSKU, "SKU has been created already, please type a new one.")
                                txtSKU.Focus()
                                Exit Try
                            End If
                        End If
                    End If
                    If LTrim(txtSKU2.Text) <> "" Then
                        getProductColorSizesSKU2B(globaliproductcolorsizesid:=CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), globalisku2:=txtSKU2.Text, globalformname:=Me)
                        pfSKU2id = globalSKU2id
                        If pfSKU2id <> 0 Then
                            errProvider.SetError(lblSKU2, "SKU2 has been created already, please type a new one.")
                            txtSKU2.Focus()
                            Exit Try
                        Else
                            getProductBundleSKU2A(globalisku2:=txtSKU2.Text, globalformname:=Me)
                            pfSKU2id = globalSKU2id
                            If pfSKU2id <> 0 Then
                                errProvider.SetError(lblSKU2, "SKU2 has been created already, please type a new one.")
                                txtSKU2.Focus()
                                Exit Try
                            End If
                        End If
                    End If
                    If LTrim(txtEditSeasonCode.Text) <> "" Then
                        getProductColorSizesIDC(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value), CStr(dgProductSizes.CurrentRow.Cells("s_sizes").Value), txtEditSeasonCode.Text, Me)
                        pfproductcolorsizeid = globalproductcolorsizesid
                        If pfproductcolorsizeid <> 0 Then
                            errProvider.SetError(lblSeasonCode, "Same color, size, and season code has been created already, please type a new one.")
                            txtEditSeasonCode.Focus()
                            Exit Try
                        End If
                    End If
                End If
            End If
            getProductIDA(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value), txtProductCode.Text, Me)
            If LTrim(txtProductCode.Text) = "" Then
                errProvider.SetError(txtProductCode, "Please type the product code.")
                txtProductCode.Focus()
            ElseIf pfproductid <> 0 Then
                errProvider.SetError(txtProductCode, "Product code has been created already, please type a new one.")
                txtProductCode.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    If txtImagePath.Text <> "" Then
                        fs = New FileStream(txtImagePath.Text, FileMode.Open, FileAccess.Read)
                        br = New BinaryReader(fs)
                        ImageData = br.ReadBytes(CType(fs.Length, Integer))
                        br.Close()
                        fs.Close()
                    End If
                    If LTrim(cboCategory.Text) <> "" Then
                        getCategoryID(cboCategory.Text, "", Me) : pfcategoryid = globalcategoryid
                        If pfcategoryid = 0 Then
                            I_Categories(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboCategory.Text, "Active", Me)
                            getCategoryID(cboCategory.Text, "", Me) : pfcategoryid = globalcategoryid
                        End If
                    Else
                        pfcategoryid = 0
                    End If
                    If myModule.systemerrorfound = True Then
                        Exit Try
                    End If
                    If LTrim(cboBrandName.Text) <> "" Then
                        getBrandID(cboBrandName.Text, Me) : pfbrandid = globalbrandid
                        If pfbrandid = 0 Then
                            I_Brands(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboBrandName.Text, "Active", Me)
                            getBrandID(cboBrandName.Text, Me) : pfbrandid = globalbrandid
                        End If
                    Else
                        pfbrandid = 0
                    End If
                    If myModule.systemerrorfound = True Then
                        Exit Try
                    End If
                    If LTrim(cboCompany.Text) <> "" Then
                        getCompanyIDA("AND companyname = """ & cboCompany.Text & """", "", Me) : pfcompanyid = globalcompanyid
                        If pfcompanyid = 0 Then
                            I_Companies(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, "", cboCompany.Text, "Active", Me)
                            getCompanyIDA("AND companyname = """ & cboCompany.Text & """", "", Me) : pfcompanyid = globalcompanyid
                        End If
                    Else
                        pfcompanyid = 0
                    End If
                    If myModule.systemerrorfound = True Then
                        Exit Try
                    End If
                    getListOfValuesID(cboUnitOfMeasure.Text, "Unit Of Measure", Me)
                    If globallistofvaluesid = 0 Then
                        I_ListOfValues(Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboUnitOfMeasure.Text, cboUnitOfMeasure.Text, "Unit Of Measure", "", "", "Active", "N", "Y", DBNull.Value, Me)
                    End If
                    If myModule.systemerrorfound = True Then
                        Exit Try
                    End If
                    getProductIDA(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value), txtProductCode.Text, Me)
                    If pfproductid = 0 Then
                        U_Products(CInt(dgProductList.CurrentRow.Cells("p_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(pfcategoryid = 0, DBNull.Value, pfcategoryid), If(pfbrandid = 0, DBNull.Value, pfbrandid), If(pfcompanyid = 0, DBNull.Value, pfcompanyid),
                         txtProductCode.Text, txtProductCode.Text, cboUnitOfMeasure.Text, cboBrandName.Text, cboCategory.Text, cboCompany.Text, txtDescription.Text, If(IsNumeric(txtSRP.Text), CDec(txtSRP.Text), 0.0), If(txtImagePath.Text <> "", ImageData, DBNull.Value), Me)
                    End If
                    If myModule.systemerrorfound = True Then
                        Exit Try
                    End If
                    If cueB = "Edit" Then
                        If dgProductSizes.Rows.Count <> 0 Then
                            If LTrim(txtSKU.Text) <> "" Then
                                getProductColorSizesSKUB(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), txtSKU.Text, Me)
                                pfskuid = globalskuid
                                If pfskuid = 0 Then
                                    getProductBundleSKUA(txtSKU.Text, Me)
                                    pfskuid = globalskuid
                                    If pfskuid = 0 Then
                                        U_ProductColorSizeSKU(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtSKU.Text, Me)
                                    End If
                                End If
                            Else
                                U_ProductColorSizeSKU(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "", Me)
                            End If
                            If LTrim(txtSKU2.Text) <> "" Then
                                getProductColorSizesSKU2B(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), txtSKU2.Text, Me)
                                pfSKU2id = globalSKU2id
                                If pfSKU2id = 0 Then
                                    getProductBundleSKU2A(txtSKU2.Text, Me)
                                    pfSKU2id = globalSKU2id
                                    If pfSKU2id = 0 Then
                                        Await U_ProductColorSizeSKU2(RowID:=CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), LastUpd:=Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), LastUpdby:=Z_UserID, SKU2:=txtSKU2.Text, globalformname:=Me)
                                    End If
                                End If
                            Else
                                Await U_ProductColorSizeSKU2(RowID:=CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), LastUpd:=Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), LastUpdby:=Z_UserID, SKU2:=String.Empty, globalformname:=Me)
                            End If
                            If LTrim(txtEditSeasonCode.Text) <> "" Then
                                getProductColorSizesIDC(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value), CStr(dgProductSizes.CurrentRow.Cells("s_sizes").Value), txtEditSeasonCode.Text, Me)
                                pfproductcolorsizeid = globalproductcolorsizesid
                                If pfproductcolorsizeid = 0 Then
                                    U_ProductColorSizeSeasonCode(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtEditSeasonCode.Text, Me)
                                End If
                            Else
                                U_ProductColorSizeSeasonCode(CInt(dgProductSizes.CurrentRow.Cells("s_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "", Me)
                            End If
                        End If
                    End If
                    If myModule.systemerrorfound = True Then
                        Exit Try
                    End If
                    dgProductSizes.CommitEdit(True) : dgProductSizes.ClearSelection() : dgProductSizes.CurrentCell = Nothing
                    If dgProductSizes.Rows.Count <> 0 Then
                        If myModule.systemerrorfound = False Then
                            For c = 0 To dgProductSizes.Rows.Count - 1
                                U_ProductColorSizeStatus(CInt(dgProductSizes.Rows(c).Cells("s_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(dgProductSizes.Rows(c).Cells("s_active").Value = legit, "Active", "Inactive"), Me)
                            Next
                        Else
                            Exit Try
                        End If
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                        tsrefreshperformclick()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsImport_Click(sender As Object, e As EventArgs) Handles tsImport.Click
        Dim form = New ImportProductForm()
        If form.ShowDialog = DialogResult.OK Then

        End If

        Return

        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Products", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PrdForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            fileOpener.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx"
            If fileOpener.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If MessageBox.Show("Would you like to import this file?", "Importing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim importproductslinkform As New ImportProductsForm
                    importproductslinkform.ipfexcelfilepath = fileOpener.FileName
                    importproductslinkform.ShowInTaskbar = False
                    importproductslinkform.ShowDialog()
                    tsrefreshperformclick()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Search/Page Setup"

    Private Sub txtSimpleSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSimpleSearch.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If txtSimpleSearch.Text = "" Then
                    tsrefreshperformclick()
                Else
                    clearcboSearch()
                    clearRightPage()
                    searchmode = "SimpleSearch"
                    simplesearchphrase = txtSimpleSearch.Text
                    spagenum = neutralpage : numofpages = startingpage
                    displaySearchPhrase(simplesearchphrase, spagenum)
                    pageSetup1(simplesearchphrase)
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboSearch1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearch1.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If cboSearch1.Text = "" Then
                cboSearch2.Items.Clear() : cboSearch2.AutoCompleteCustomSource.Clear()
            ElseIf cboSearch1.Text = "BrandName" Then
                autocompleteBrandName(cboSearch2, "")
                autopopulateBrandName(cboSearch2, "")
            ElseIf cboSearch1.Text = "Category" Then
                autocompleteCategory(cboSearch2, "")
                autopopulateCategory(cboSearch2, "")
            ElseIf cboSearch1.Text = "VendorName" Then
                autocompleteCompany(cboSearch2, "")
                autopopulateCompany(cboSearch2, "")
            End If
            cboSearch2.Text = "" : cboSearch2.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboSearch3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearch3.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If cboSearch3.Text = "" Then
                cboSearch4.Items.Clear() : cboSearch4.AutoCompleteCustomSource.Clear()
            ElseIf cboSearch3.Text = "BrandName" Then
                autocompleteBrandName(cboSearch4, "")
                autopopulateBrandName(cboSearch4, "")
            ElseIf cboSearch3.Text = "Category" Then
                autocompleteCategory(cboSearch4, "")
                autopopulateCategory(cboSearch4, "")
            ElseIf cboSearch3.Text = "VendorName" Then
                autocompleteCompany(cboSearch4, "")
                autopopulateCompany(cboSearch4, "")
            End If
            cboSearch4.Text = "" : cboSearch4.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboSearch2_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSearch2.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If cboSearch1.Text = "" AndAlso cboSearch3.Text = "" Then
                    tsrefreshperformclick()
                ElseIf cboSearch2.Text = "" AndAlso cboSearch4.Text = "" Then
                    tsrefreshperformclick()
                Else
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "CommonSearch"
                    If cboSearch1.Text = "" Then
                        pagefilter1 = ""
                    Else
                        getCommonPhrase(cboSearch1, cboSearch2.Text)
                        pagefilter1 = "" & commonphrase & ""
                    End If
                    If cboSearch3.Text = "" Then
                        pagefilter2 = ""
                    Else
                        getCommonPhrase(cboSearch3, cboSearch4.Text)
                        pagefilter2 = "" & commonphrase & ""
                    End If
                    If pagefilter1 = "" Then
                        pagefilter3 = pagefilter2
                    ElseIf pagefilter2 = "" Then
                        pagefilter3 = pagefilter1
                    Else
                        pagefilter3 = "" & pagefilter1 & " AND " & pagefilter2 & ""
                    End If
                    spagenum = neutralpage : numofpages = startingpage
                    displayCommonPhrase(pagefilter3, spagenum)
                    pageSetup2(pagefilter3)
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboSearch4_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSearch4.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If cboSearch1.Text = "" AndAlso cboSearch3.Text = "" Then
                    tsrefreshperformclick()
                ElseIf cboSearch2.Text = "" AndAlso cboSearch4.Text = "" Then
                    tsrefreshperformclick()
                Else
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "CommonSearch"
                    If cboSearch1.Text = "" Then
                        pagefilter1 = ""
                    Else
                        getCommonPhrase(cboSearch1, cboSearch2.Text)
                        pagefilter1 = "" & commonphrase & ""
                    End If
                    If cboSearch3.Text = "" Then
                        pagefilter2 = ""
                    Else
                        getCommonPhrase(cboSearch3, cboSearch4.Text)
                        pagefilter2 = "" & commonphrase & ""
                    End If
                    If pagefilter1 = "" Then
                        pagefilter3 = pagefilter2
                    ElseIf pagefilter2 = "" Then
                        pagefilter3 = pagefilter1
                    Else
                        pagefilter3 = "" & pagefilter1 & " AND " & pagefilter2 & ""
                    End If
                    spagenum = neutralpage : numofpages = startingpage
                    displayCommonPhrase(pagefilter3, spagenum)
                    pageSetup2(pagefilter3)
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdFirst_Click(sender As Object, e As EventArgs) Handles cmdFirst.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            spagenum = neutralpage
            numofpages = startingpage
            If searchmode = "Basic" Then
                displayProductList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            End If
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdPrev_Click(sender As Object, e As EventArgs) Handles cmdPrev.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            spagenum = spagenum - pagedivisor
            numofpages = numofpages - 1
            If spagenum < 0 Then
                If countpagenum < pagedivisor Then
                    spagenum = neutralpage
                Else
                    spagenum = countpagenum - pagedivisor
                End If
                numofpages = validpages
            End If
            If searchmode = "Basic" Then
                displayProductList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            End If
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            spagenum = spagenum + pagedivisor
            numofpages = numofpages + 1
            If numofpages > validpages Then
                spagenum = neutralpage
                numofpages = startingpage
            End If
            If searchmode = "Basic" Then
                displayProductList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            End If
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdLast_Click(sender As Object, e As EventArgs) Handles cmdLast.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If countpagenum < pagedivisor Then
                spagenum = neutralpage
            Else
                spagenum = countpagenum - pagedivisor
            End If
            numofpages = validpages
            If searchmode = "Basic" Then
                displayProductList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            End If
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtPage_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPage.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If IsNumeric(txtPage.Text) Then
                    If CInt(txtPage.Text) < 0 Then
                    ElseIf CInt(txtPage.Text) = 0 Then
                    ElseIf CInt(txtPage.Text) > validpages Then
                    Else
                        clearRightPage()
                        tabMain.SelectedTab = tabDetails
                        If countpagenum < pagedivisor Then
                            spagenum = neutralpage
                        Else
                            pageequation1 = CInt(txtPage.Text) * pagedivisor
                            pageequation2 = ((CInt(txtPage.Text) / validpages) * countpagenum)
                            If pageequation1 < pageequation2 Then
                                pageequation3 = ((CInt(txtPage.Text) / validpages) * countpagenum) - (pageequation2 - pageequation1)
                            Else
                                pageequation3 = (CInt(txtPage.Text) / validpages) * countpagenum
                            End If
                            spagenum = pageequation3 - pagedivisor
                        End If
                        numofpages = CInt(txtPage.Text)
                        If searchmode = "Basic" Then
                            displayProductList(spagenum)
                        ElseIf searchmode = "CommonSearch" Then
                            displayCommonPhrase(pagefilter3, spagenum)
                        ElseIf searchmode = "SimpleSearch" Then
                            displaySearchPhrase(simplesearchphrase, spagenum)
                        End If
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                        txtPage.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Datagrid Errors"

    Private Sub dgProductList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductList.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgProductList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductColors_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductColors.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgProductColors.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductSizes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductSizes.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgProductSizes.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgInventoryLocations_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgInventoryLocations.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgInventoryLocations.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgRackShelfColumn_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgRackShelfColumn.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgRackShelfColumn.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

    Private ReadOnly Property IsThurston As Boolean
        Get
            Return _systemOwner.IsThurston
        End Get
    End Property

End Class