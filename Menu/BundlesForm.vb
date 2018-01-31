Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Linq
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Public Class BundlesForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim cue, searchmode As String
    Dim itemno, rowscount As Integer
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim simplesearchphrase, commonphrase, pagefilter1, pagefilter2, pagefilter3 As String
    Dim bfproductcolorsizesid, bfproductid, bftotalqtyavailable, bfproductbundleid, bfskuid, bfproductbundleitemid, bfcategoryid, bfbrandid, bfcompanyid As Integer
    Private Sub BundlesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            displayBundleList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BundlesForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , lblsavemsg, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoComplete()
        globalautocompleteListOfValues(cboUnitOfMeasure, "Unit Of Measure", Me)
        autocompleteBrandName(cboBrandName)
        autocompleteCategory(cboCategory)
        autocompleteCompany(cboCompany)
    End Sub
    Sub callAutoPopulate()
        autopopulatecboSearch()
        autopopulatecboBy()
        globalautopopulateListOfValues(cboUnitOfMeasure, "Unit Of Measure", Me)
        autopopulateBrandName(cboBrandName)
        autopopulateCategory(cboCategory)
        autopopulateCompany(cboCompany)
        autopopulateStatus(cboStatus)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearBundleInformation()
            clearAddProduct()
            dgProductColorSizes.Rows.Clear()
            dgProductColors.Rows.Clear()
            dgProductSizes.Rows.Clear()
            dgBundleItems.Rows.Clear()
            enableGB(legit, fraud)
            visibleGB(fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearRightPage()
        Try
            cue = ""
            clearBundleInformation()
            clearAddProduct()
            dgProductColorSizes.Rows.Clear()
            dgProductColors.Rows.Clear()
            dgProductSizes.Rows.Clear()
            dgBundleItems.Rows.Clear()
            enableGB(legit, fraud)
            visibleGB(fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
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
    Sub clearBundleInformation()
        Try
            txtBundleName.Text = ""
            txtSKU.Text = ""
            txtSRP.Text = ""
            cboStatus.Text = ""
            cboUnitOfMeasure.Text = ""
            cboBrandName.Text = ""
            cboCategory.Text = ""
            cboCompany.Text = ""
            txtDescription.Text = ""
            txtTotalItems.Text = ""
            txtTotalQty.Text = ""
            cboStatus.SelectedItem = Nothing
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
    Sub clearAddProduct()
        Try
            cboBy.Text = ""
            cboByPhrase.Text = ""
            txtQty.Text = ""
            cboBy.SelectedItem = Nothing
            cboByPhrase.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbBundleList.Enabled = enable1
            gbBundleInformation.Enabled = enable2
            gbAddProducts.Enabled = enable2
            gbBundleItems.Enabled = enable2
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub enableANDvisibleMS(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal visible1 As Boolean)
        Try
            msNew.Enabled = enable1
            msSave.Enabled = enable2
            msCancel.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub visibleGB(ByVal visible1 As Boolean, ByVal visible2 As Boolean)
        Try
            dgProductColorSizes.Visible = visible1
            dgProductColors.Visible = visible2
            dgProductSizes.Visible = visible2
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
            callAutoComplete()
            callAutoPopulate()
            displayBundleList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub btnAddperformclick()
        Try
            errProvider.Clear()
            If cboByPhrase.Text <> "" Then
                If cboBy.Text = "" Then
                    errProvider.SetError(cboBy, "Please choose among the options given in this box.")
                    cboBy.Focus()
                    Exit Try
                ElseIf cboBy.Text = "Combination" Then
                    If Not IsNumeric(txtQty.Text) Then
                        errProvider.SetError(txtQty, "Please use numbers for qty.")
                        txtQty.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the combination code.")
                        cboByPhrase.Focus()
                    Else
                        checkProductBundleItemsA()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    If dgProductSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the sizes.")
                        cboByPhrase.Focus()
                    Else
                        checkProductBundleItemsB()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    If Not IsNumeric(txtQty.Text) Then
                        errProvider.SetError(txtQty, "Please use numbers for qty.")
                        txtQty.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the sku.")
                        cboByPhrase.Focus()
                    Else
                        checkProductBundleItemsA()
                    End If
                End If
            Else
                errProvider.SetError(cboByPhrase, "Please fill-up this box.")
                cboByPhrase.Focus()
                Exit Try
            End If
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
            bftotalqtyavailable = 0
            If dgBundleItems.Rows.Count <> 0 Then
                For i = 0 To dgBundleItems.Rows.Count - 1
                    If IsNumeric(dgBundleItems.Rows(i).Cells("bi_qtyavailable").Value) Then
                        bftotalqtyavailable = bftotalqtyavailable + CInt(dgBundleItems.Rows(i).Cells("bi_qtyavailable").Value)
                    End If

                Next
            End If
            txtTotalItems.Text = Format(dgBundleItems.Rows.Count, "#,##0")
            txtTotalQty.Text = Format(bftotalqtyavailable, "#,##0")
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
            dtCid = getDataTableForSQL("SELECT COUNT(b.rowid) FROM productbundles b WHERE b.organizationid = " & Z_OrganizationID & " ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(b.rowid),0) FROM productbundles b WHERE b.organizationid = " & Z_OrganizationID & " AND (b.bundlename LIKE ""%" & esearchstring & "%"" OR b.sku LIKE ""%" & esearchstring & "%"" OR b.status LIKE ""%" & esearchstring & "%"") ")
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
            dtCid = getDataTableForSQL("SELECT COUNT(b.rowid) FROM productbundles b LEFT JOIN productbundleitems pbi ON b.rowid = pbi.productbundleid LEFT JOIN productcolorsizes pcs ON pbi.productcolorsizeid = pcs.rowid " & _
                        "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE b.organizationid = " & Z_OrganizationID & " AND " & ecommontring & " ")
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
            If icommonbox.Text = "ProductCode" Then
                commonphrase = "p.productcode = """ & icommonstring & """"
            ElseIf icommonbox.Text = "SKU" Then
                commonphrase = "pcs.sku = """ & icommonstring & """"
            ElseIf icommonbox.Text = "Status" Then
                commonphrase = "b.status = """ & icommonstring & """"
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
    Sub autocompleteBrandName(ByVal icombobox As ComboBox)
        Try
            Dim brandname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(b.brandname,'') AS 'brandname' FROM brands b WHERE b.organizationid = " & Z_OrganizationID & " AND b.`status` = 'Active' GROUP BY b.brandname ", conn)
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
    Sub autocompleteCategory(ByVal icombobox As ComboBox)
        Try
            Dim categoryname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.categoryname,'') AS 'categoryname' FROM categories c WHERE c.organizationid = " & Z_OrganizationID & " AND c.`status` = 'Active' GROUP BY c.categoryname ", conn)
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
    Sub autocompleteCompany(ByVal icombobox As ComboBox)
        Try
            Dim companyname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.companyname,'') AS 'companyname' FROM companies c WHERE c.organizationid = " & Z_OrganizationID & " AND c.`status` = 'Active' GROUP BY c.companyname ", conn)
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
    Sub autocompleteStatus(ByVal icombobox As ComboBox)
        Try
            Dim status As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT lic AS 'status' FROM listofvalues WHERE type = 'Status' AND status = 'Active' ORDER BY lic ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                status.Add(ds.Tables(0).Rows(i)("status").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = status
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autocompleteProductCode(ByVal icombobox As ComboBox)
        Try
            Dim productcode As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(p.productcode,'') AS 'productcode' FROM productbundles b LEFT JOIN productbundleitems pbi ON b.rowid = pbi.productbundleid LEFT JOIN productcolorsizes pcs ON pbi.productcolorsizeid = pcs.rowid " & _
                                "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE b.organizationid = " & Z_OrganizationID & " GROUP BY p.productcode ORDER BY p.productcode ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                productcode.Add(ds.Tables(0).Rows(i)("productcode").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = productcode
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autocompleteSKU(ByVal icombobox As ComboBox)
        Try
            Dim sku As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(pcs.sku,'') AS 'sku' FROM productbundles b LEFT JOIN productbundleitems pbi ON b.rowid = pbi.productbundleid " & _
                                "LEFT JOIN productcolorsizes pcs ON pbi.productcolorsizeid = pcs.rowid WHERE b.organizationid = " & Z_OrganizationID & " GROUP BY pcs.sku ORDER BY pcs.sku ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                sku.Add(ds.Tables(0).Rows(i)("sku").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = sku
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autocompleteBySKU(ByVal icombobox As ComboBox)
        Try
            Dim sku As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(pcs.sku,'') AS 'sku' FROM productcolorsizes pcs WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.status = 'Active' AND pcs.sku != '' GROUP BY pcs.sku ORDER BY pcs.sku ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                sku.Add(ds.Tables(0).Rows(i)("sku").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = sku
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
            cboSearch1.Items.Add("ProductCode")
            cboSearch1.Items.Add("SKU")
            cboSearch1.Items.Add("Status")
            cboSearch3.Items.Add("ProductCode")
            cboSearch3.Items.Add("SKU")
            cboSearch3.Items.Add("Status")
            cboSearch1.Items.Add("")
            cboSearch3.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autopopulatecboBy()
        Try
            cboBy.Items.Clear()
            cboBy.Items.Add("Combination")
            cboBy.Items.Add("ProductCode")
            cboBy.Items.Add("SKU")
            cboBy.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autopopulateBrandName(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(b.brandname,'') AS 'brandname' FROM brands b WHERE b.organizationid = " & Z_OrganizationID & " AND b.`status` = 'Active' GROUP BY b.brandname ORDER BY b.brandname "
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
    Sub autopopulateCategory(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.categoryname,'') AS 'categoryname' FROM categories c WHERE c.organizationid = " & Z_OrganizationID & " AND c.`status` = 'Active' GROUP BY c.categoryname ORDER BY c.categoryname "
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
    Sub autopopulateCompany(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.companyname,'') AS 'companyname' FROM companies c WHERE c.organizationid = " & Z_OrganizationID & " AND c.`status` = 'Active' GROUP BY c.companyname ORDER BY c.companyname "
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
    Sub autopopulateStatus(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT lic FROM listofvalues WHERE type = 'Status' AND status = 'Active' ORDER BY lic "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                icombobox.Items.Add(reader1(0).ToString())
            End While
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autopopulateProductCode(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(p.productcode,'') AS 'productcode' FROM productbundles b LEFT JOIN productbundleitems pbi ON b.rowid = pbi.productbundleid LEFT JOIN productcolorsizes pcs ON pbi.productcolorsizeid = pcs.rowid " & _
                                "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE b.organizationid = " & Z_OrganizationID & " GROUP BY p.productcode ORDER BY p.productcode "
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
    Sub autopopulateSKU(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(pcs.sku,'') AS 'sku' FROM productbundles b LEFT JOIN productbundleitems pbi ON b.rowid = pbi.productbundleid " & _
                                "LEFT JOIN productcolorsizes pcs ON pbi.productcolorsizeid = pcs.rowid WHERE b.organizationid = " & Z_OrganizationID & " GROUP BY pcs.sku ORDER BY pcs.sku "
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
    Sub autopopulateBySKU(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(pcs.sku,'') AS 'sku' FROM productcolorsizes pcs WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.status = 'Active' AND pcs.sku != '' GROUP BY pcs.sku ORDER BY pcs.sku "
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
#Region "Datagrids"
    Sub displayBundleList(ByVal istartpage As Integer)
        Try
            dgBundleList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT b.rowid,COALESCE(b.bundlename,''),COALESCE(b.sku,''),COALESCE(b.srp,0.0),COALESCE(b.status,'') FROM productbundles b " & _
                        "WHERE b.organizationid = " & Z_OrganizationID & " ORDER BY b.bundlename ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgBundleList.Rows.Add()
                    dgBundleList.Item(b_rowid.Index, n).Value = reader1(0)
                    dgBundleList.Item(b_bundlename.Index, n).Value = reader1(1)
                    dgBundleList.Item(b_sku.Index, n).Value = reader1(2)
                    dgBundleList.Item(b_srp.Index, n).Value = Format(CDec(reader1(3)), "#,##0.00")
                    dgBundleList.Item(b_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgBundleList.Columns("b_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleList.Columns("b_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleList.Columns("b_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgBundleList.Rows.Count <> 0 Then
                dgBundleList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgBundleList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT b.rowid,COALESCE(b.bundlename,''),COALESCE(b.sku,''),COALESCE(b.srp,0.0),COALESCE(b.status,'') FROM productbundles b LEFT JOIN categories ct ON b.categoryid = ct.rowid " & _
                        "WHERE b.organizationid = " & Z_OrganizationID & " AND (b.bundlename LIKE ""%" & isearchphrase & "%"" OR b.sku LIKE ""%" & isearchphrase & "%"" OR ct.categoryname LIKE ""%" & isearchphrase & "%"" OR " & _
                        "b.status LIKE ""%" & isearchphrase & "%"") ORDER BY b.bundlename ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgBundleList.Rows.Add()
                    dgBundleList.Item(b_rowid.Index, n).Value = reader1(0)
                    dgBundleList.Item(b_bundlename.Index, n).Value = reader1(1)
                    dgBundleList.Item(b_sku.Index, n).Value = reader1(2)
                    dgBundleList.Item(b_srp.Index, n).Value = Format(CDec(reader1(3)), "#,##0.00")
                    dgBundleList.Item(b_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgBundleList.Columns("b_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleList.Columns("b_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleList.Columns("b_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgBundleList.Rows.Count <> 0 Then
                dgBundleList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal istartpage As Integer)
        Try
            dgBundleList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT b.rowid,COALESCE(b.bundlename,''),COALESCE(b.sku,''),COALESCE(b.srp,0.0),COALESCE(b.status,'') FROM productbundles b LEFT JOIN productbundleitems pbi ON b.rowid = pbi.productbundleid " & _
                            "LEFT JOIN productcolorsizes pcs ON pbi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
                            "WHERE b.organizationid = " & Z_OrganizationID & " AND " & icommonphrase & " ORDER BY b.bundlename ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgBundleList.Rows.Add()
                    dgBundleList.Item(b_rowid.Index, n).Value = reader1(0)
                    dgBundleList.Item(b_bundlename.Index, n).Value = reader1(1)
                    dgBundleList.Item(b_sku.Index, n).Value = reader1(2)
                    dgBundleList.Item(b_srp.Index, n).Value = Format(CDec(reader1(3)), "#,##0.00")
                    dgBundleList.Item(b_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgBundleList.Columns("b_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleList.Columns("b_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleList.Columns("b_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgBundleList.Rows.Count <> 0 Then
                dgBundleList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayBundleInformation(ByVal iproductbundleid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(b.bundlename,''),COALESCE(b.sku,''),COALESCE(b.srp,0.0),COALESCE(b.status,''),COALESCE(b.unitofmeasure,''),COALESCE(b.description,''),COALESCE(br.brandname,''),COALESCE(ct.categoryname,'')," & _
                "COALESCE(cm.companyname,'') FROM productbundles b LEFT JOIN brands br ON b.brandid = br.rowid LEFT JOIN categories ct ON b.categoryid = ct.rowid LEFT JOIN companies cm ON b.companyid = cm.rowid WHERE b.rowid = " & iproductbundleid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtBundleName.Text = reader1(0)
                    txtSKU.Text = reader1(1)
                    txtSRP.Text = reader1(2)
                    cboStatus.Text = reader1(3)
                    cboUnitOfMeasure.Text = reader1(4)
                    txtDescription.Text = reader1(5)
                    cboBrandName.Text = reader1(6)
                    cboCategory.Text = reader1(7)
                    cboCompany.Text = reader1(8)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub
    Sub displayBundleItems(ByVal iproductbundleid As Integer)
        Try
            dgBundleItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT bi.rowid,COALESCE(bi.productcolorsizeid,0),COALESCE(c.colorvalue,''),COALESCE(bi.qtyavailable,0),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,'') " & _
                    "FROM productbundleitems bi LEFT JOIN productcolorsizes pcs ON bi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " & _
                    "LEFT JOIN products p ON pc.productid = p.rowid WHERE bi.productbundleid = " & iproductbundleid & " AND bi.organizationid = " & Z_OrganizationID & " AND bi.status = 'Active' ORDER BY p.productcode,c.colorname "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgBundleItems.Rows.Add()
                    dgBundleItems.Item(bi_seqno.Index, n).Value = seqno
                    dgBundleItems.Item(bi_rowid.Index, n).Value = reader1(0)
                    dgBundleItems.Item(bi_pcsrowid.Index, n).Value = reader1(1)
                    dgBundleItems.Item(bi_colorvalue.Index, n).Value = reader1(2)
                    dgBundleItems.Item(bi_qtyavailable.Index, n).Value = reader1(3)
                    dgBundleItems.Item(bi_productcode.Index, n).Value = reader1(4)
                    dgBundleItems.Item(bi_colorname.Index, n).Value = reader1(5)
                    dgBundleItems.Item(bi_size.Index, n).Value = reader1(6)
                    dgBundleItems.Item(bi_seasoncode.Index, n).Value = reader1(7)
                    dgBundleItems.Item(bi_sku.Index, n).Value = reader1(8)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgBundleItems.Columns("bi_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgBundleItems.Rows.Count <> 0 Then
                dgBundleItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayProductsA(ByVal iproductcolorsizeid As Integer)
        Try
            dgProductColorSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,'') FROM productcolorsizes pcs " & _
                "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.rowid = " & iproductcolorsizeid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductColorSizes.Rows.Add()
                    dgProductColorSizes.Item(pcs_seqno.Index, n).Value = seqno
                    dgProductColorSizes.Item(pcs_rowid.Index, n).Value = reader1(0)
                    dgProductColorSizes.Item(pcs_colorvalue.Index, n).Value = reader1(1)
                    dgProductColorSizes.Item(pcs_productcode.Index, n).Value = reader1(2)
                    dgProductColorSizes.Item(pcs_colorname.Index, n).Value = reader1(3)
                    dgProductColorSizes.Item(pcs_size.Index, n).Value = reader1(4)
                    dgProductColorSizes.Item(pcs_seasoncode.Index, n).Value = reader1(5)
                    dgProductColorSizes.Item(pcs_sku.Index, n).Value = reader1(6)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductColorSizes.Columns("pcs_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductColorSizes.Rows.Count <> 0 Then
                dgProductColorSizes.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayProductsB(ByVal iproductid As Integer)
        Try
            dgProductColors.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pc.rowid,COALESCE(c.colorvalue,''),COALESCE(c.colorname,'') FROM productcolors pc LEFT JOIN colors c ON pc.colorid = c.rowid " & _
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
    Sub displayProductsC(ByVal iproductcolorid As Integer)
        Try
            dgProductSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(pcs.size,0.0),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,'') FROM productcolorsizes pcs WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.productcolorid = " & iproductcolorid & " AND pcs.status = 'Active' ORDER BY pcs.size ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductSizes.Rows.Add()
                    dgProductSizes.Item(s_rowid.Index, n).Value = reader1(0)
                    dgProductSizes.Item(s_sizes.Index, n).Value = reader1(1)
                    dgProductSizes.Item(s_seasoncode.Index, n).Value = reader1(2)
                    dgProductSizes.Item(s_qty.Index, n).Value = ""
                    dgProductSizes.Item(s_sku.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductSizes.Columns("s_sizes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductSizes.Rows.Count <> 0 Then
                dgProductSizes.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Colors"
    Sub colorCoding()
        Try
            If dgProductColorSizes.Rows.Count <> 0 Then
                For i As Integer = 0 To dgProductColorSizes.Rows.Count - 1
                    If CStr(dgProductColorSizes.Rows(i).Cells("pcs_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgProductColorSizes.Rows(i).Cells("pcs_colorvalue").Value))
                        dgProductColorSizes.Rows(i).Cells("pcs_color").Style.BackColor = readcolor
                    End If
                Next
            End If
            If dgProductColors.Rows.Count <> 0 Then
                For i As Integer = 0 To dgProductColors.Rows.Count - 1
                    If CStr(dgProductColors.Rows(i).Cells("c_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgProductColors.Rows(i).Cells("c_colorvalue").Value))
                        dgProductColors.Rows(i).Cells("c_color").Style.BackColor = readcolor
                    End If
                Next
            End If
            If dgBundleItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgBundleItems.Rows.Count - 1
                    If CStr(dgBundleItems.Rows(i).Cells("bi_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgBundleItems.Rows(i).Cells("bi_colorvalue").Value))
                        dgBundleItems.Rows(i).Cells("bi_color").Style.BackColor = readcolor
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
#Region "Adding Functions"
    Sub checkProductBundleItemsA()
        Try
            If dgProductColorSizes.Rows.Count <> 0 Then
                For p = 0 To dgProductColorSizes.Rows.Count - 1
                    If dgBundleItems.Rows.Count <> 0 Then
                        rowscount = dgBundleItems.Rows.Count - 1
                        For i = 0 To dgBundleItems.Rows.Count - 1
                            If dgBundleItems.Rows(i).Cells("bi_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                errProvider.SetError(cboByPhrase, "Product is in the list already.")
                                cboByPhrase.Focus()
                                Exit Try
                            ElseIf rowscount = 0 Then
                                addProductBundleItem(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CInt(txtQty.Text))
                                For a = 0 To dgBundleItems.Rows.Count - 1
                                    dgBundleItems.CurrentRow.Selected = fraud
                                    If dgBundleItems.Rows(a).Cells("bi_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                        dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Selected = legit
                                        dgBundleItems.FirstDisplayedScrollingRowIndex = dgBundleItems.RowCount - 1
                                        Exit For
                                    End If
                                Next
                                cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQty.Text = "" : cboByPhrase.Focus() : dgProductColorSizes.Rows.Clear()
                            End If
                            rowscount = rowscount - 1
                        Next
                    Else
                        addProductBundleItem(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CInt(txtQty.Text))
                        For a = 0 To dgBundleItems.Rows.Count - 1
                            dgBundleItems.CurrentRow.Selected = fraud
                            If dgBundleItems.Rows(a).Cells("bi_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Selected = legit
                                dgBundleItems.FirstDisplayedScrollingRowIndex = dgBundleItems.RowCount - 1
                                Exit For
                            End If
                        Next
                        cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQty.Text = "" : cboByPhrase.Focus() : dgProductColorSizes.Rows.Clear()
                    End If
                Next
            End If
            itemno = 1 : colorCoding() : totalcomputation()
            For i As Integer = 0 To dgBundleItems.Rows.Count - 1
                dgBundleItems.Rows(i).Cells("bi_seqno").Value = itemno
                itemno = itemno + 1
            Next i
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub checkProductBundleItemsB()
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                For p = 0 To dgProductSizes.Rows.Count - 1
                    If IsNumeric(dgProductSizes.Rows(p).Cells("s_qty").Value) Then
                        If CInt(dgProductSizes.Rows(p).Cells("s_qty").Value) > 0 Then
                            If dgBundleItems.Rows.Count <> 0 Then
                                rowscount = dgBundleItems.Rows.Count - 1
                                For i = 0 To dgBundleItems.Rows.Count - 1
                                    If dgBundleItems.Rows(i).Cells("bi_pcsrowid").Value = dgProductSizes.Rows(p).Cells("s_rowid").Value Then
                                        Exit For
                                    ElseIf rowscount = 0 Then
                                        addProductBundleItem(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CInt(dgProductSizes.Rows(p).Cells("s_qty").Value))
                                    End If
                                    rowscount = rowscount - 1
                                Next
                            Else
                                addProductBundleItem(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CInt(dgProductSizes.Rows(p).Cells("s_qty").Value))
                            End If
                        End If
                    End If
                Next
            End If
            itemno = 1 : colorCoding() : totalcomputation()
            For i As Integer = 0 To dgBundleItems.Rows.Count - 1
                dgBundleItems.Rows(i).Cells("bi_seqno").Value = itemno
                itemno = itemno + 1
            Next i
            If dgBundleItems.Rows.Count <> 0 Then
                dgBundleItems.CurrentRow.Selected = False
                dgBundleItems.FirstDisplayedScrollingRowIndex = dgBundleItems.RowCount - 1
            End If
            cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQty.Text = "" : cboByPhrase.Focus()
            dgProductColors.Rows.Clear() : dgProductSizes.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub addProductBundleItem(ByVal iproductcolorsizeid As Integer, ByVal iqtyavailable As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,'') FROM productcolorsizes pcs " & _
                "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.rowid = " & iproductcolorsizeid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    dgBundleItems.Rows.Add()
                    dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Cells("bi_rowid").Value = ""
                    dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Cells("bi_pcsrowid").Value = reader1(0)
                    dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Cells("bi_colorvalue").Value = reader1(1)
                    dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Cells("bi_qtyavailable").Value = iqtyavailable
                    dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Cells("bi_productcode").Value = reader1(2)
                    dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Cells("bi_colorname").Value = reader1(3)
                    dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Cells("bi_size").Value = reader1(4)
                    dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Cells("bi_seasoncode").Value = reader1(5)
                    dgBundleItems.Rows(dgBundleItems.Rows.Count - 1).Cells("bi_sku").Value = reader1(6)
                End If
            End While
            reader1.Close()
            dgBundleItems.Columns("bi_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
                PrimaryForm.BndlsForm = False
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
            txtBundleName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub btnAddProduct_Leave(sender As Object, e As EventArgs) Handles btnAddProduct.Leave
        Try
            cboByPhrase.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
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
            myBalloon("Automatic adding of unit of measure.", "Auto-Add", pbAutoAddA, -15, -65)
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
            myBalloon("Automatic adding of brand name.", "Auto-Add", pbAutoAddB, -15, -65)
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
            myBalloon("Automatic adding of category.", "Auto-Add", pbAutoAddC, -15, -65)
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
            myBalloon("Automatic adding of vendor name.", "Auto-Add", pbAutoAddD, -15, -65)
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
    Private Sub msNew_Click(sender As Object, e As EventArgs) Handles msNew.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Bundles", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.BndlsForm = False
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
            cue = "New"
            errProvider.Clear()
            clearBundleInformation()
            clearAddProduct()
            dgProductColorSizes.Rows.Clear()
            dgProductColors.Rows.Clear()
            dgProductSizes.Rows.Clear()
            dgBundleItems.Rows.Clear()
            enableGB(fraud, legit)
            visibleGB(fraud, fraud)
            enableANDvisibleMS(fraud, legit, legit)
            If dgBundleList.Rows.Count <> 0 Then
                dgBundleList.CurrentRow.Selected = False
            End If
            txtBundleName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub msCancel_Click(sender As Object, e As EventArgs) Handles msCancel.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBundleList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearBundleInformation()
                clearAddProduct()
                dgProductColorSizes.Rows.Clear()
                dgProductColors.Rows.Clear()
                dgProductSizes.Rows.Clear()
                dgBundleItems.Rows.Clear()
                enableGB(legit, legit)
                visibleGB(fraud, fraud)
                enableANDvisibleMS(legit, legit, fraud)
                dgBundleList.CurrentRow.Selected = True
                displayBundleInformation(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value))
                displayBundleItems(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value))
                totalcomputation() : colorCoding()
                txtBundleName.Focus()
            Else
                tsrefreshperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgBundleList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBundleList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBundleList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearBundleInformation()
                clearAddProduct()
                dgProductColorSizes.Rows.Clear()
                dgProductColors.Rows.Clear()
                dgProductSizes.Rows.Clear()
                dgBundleItems.Rows.Clear()
                enableGB(legit, legit)
                visibleGB(fraud, fraud)
                enableANDvisibleMS(legit, legit, fraud)
                displayBundleInformation(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value))
                displayBundleItems(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value))
                totalcomputation() : colorCoding()
                txtBundleName.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgBundleList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgBundleList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBundleList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearBundleInformation()
                    clearAddProduct()
                    dgProductColorSizes.Rows.Clear()
                    dgProductColors.Rows.Clear()
                    dgProductSizes.Rows.Clear()
                    dgBundleItems.Rows.Clear()
                    enableGB(legit, legit)
                    visibleGB(fraud, fraud)
                    enableANDvisibleMS(legit, legit, fraud)
                    displayBundleInformation(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value))
                    displayBundleItems(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value))
                    totalcomputation() : colorCoding()
                    txtBundleName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtBundleName_Leave(sender As Object, e As EventArgs) Handles txtBundleName.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                getProductBundleIDA(txtBundleName.Text, Me)
                bfproductbundleid = globalproductbundleid
                If bfproductbundleid <> 0 Then
                    errProvider.SetError(txtBundleName, "Bundle name has been created already, please type a new one.")
                End If
            ElseIf cue = "Edit" Then
                If dgBundleList.Rows.Count <> 0 Then
                    getProductBundleIDB(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value), txtBundleName.Text, Me)
                    bfproductbundleid = globalproductbundleid
                    If bfproductbundleid <> 0 Then
                        errProvider.SetError(txtBundleName, "Bundle name has been created already, please type a new one.")
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
    'Private Sub txtBundleName_TextChanged(sender As Object, e As EventArgs) Handles txtBundleName.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            getProductBundleIDA(txtBundleName.Text, Me)
    '            bfproductbundleid = globalproductbundleid
    '            If bfproductbundleid <> 0 Then
    '                errProvider.SetError(txtBundleName, "Bundle name has been created already, please type a new one.")
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgBundleList.Rows.Count <> 0 Then
    '                getProductBundleIDB(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value), txtBundleName.Text, Me)
    '                bfproductbundleid = globalproductbundleid
    '                If bfproductbundleid <> 0 Then
    '                    errProvider.SetError(txtBundleName, "Bundle name has been created already, please type a new one.")
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
            If cue = "New" Then
                getProductBundleSKUA(txtSKU.Text, Me)
                bfskuid = globalskuid
                If bfskuid <> 0 Then
                    errProvider.SetError(txtSKU, "SKU has been created already, please type a new one.")
                Else
                    getProductColorSizesSKUA(txtSKU.Text, Me)
                    bfskuid = globalskuid
                    If bfskuid <> 0 Then
                        errProvider.SetError(txtSKU, "SKU has been created already, please type a new one.")
                    End If
                End If
            ElseIf cue = "Edit" Then
                If dgBundleList.Rows.Count <> 0 Then
                    getProductBundleSKUB(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value), txtSKU.Text, Me)
                    bfskuid = globalskuid
                    If bfskuid <> 0 Then
                        errProvider.SetError(txtSKU, "SKU has been created already, please type a new one.")
                    Else
                        getProductColorSizesSKUA(txtSKU.Text, Me)
                        bfskuid = globalskuid
                        If bfskuid <> 0 Then
                            errProvider.SetError(txtSKU, "SKU has been created already, please type a new one.")
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
    'Private Sub txtSKU_TextChanged(sender As Object, e As EventArgs) Handles txtSKU.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            getProductBundleSKUA(txtSKU.Text, Me)
    '            bfskuid = globalskuid
    '            If bfskuid <> 0 Then
    '                errProvider.SetError(txtSKU, "SKU has been created already, please type a new one.")
    '            Else
    '                getProductColorSizesSKUA(txtSKU.Text, Me)
    '                bfskuid = globalskuid
    '                If bfskuid <> 0 Then
    '                    errProvider.SetError(txtSKU, "SKU has been created already, please type a new one.")
    '                End If
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgBundleList.Rows.Count <> 0 Then
    '                getProductBundleSKUB(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value), txtSKU.Text, Me)
    '                bfskuid = globalskuid
    '                If bfskuid <> 0 Then
    '                    errProvider.SetError(txtSKU, "SKU has been created already, please type a new one.")
    '                Else
    '                    getProductColorSizesSKUA(txtSKU.Text, Me)
    '                    bfskuid = globalskuid
    '                    If bfskuid <> 0 Then
    '                        errProvider.SetError(txtSKU, "SKU has been created already, please type a new one.")
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
    Private Sub cboBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBy.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            txtQty.Text = ""
            dgProductColors.Rows.Clear()
            dgProductSizes.Rows.Clear()
            dgProductColorSizes.Rows.Clear()
            If cboBy.Text = "" Then
                cboByPhrase.Items.Clear() : cboByPhrase.AutoCompleteCustomSource.Clear()
                visibleGB(fraud, fraud)
            ElseIf cboBy.Text = "Combination" Then
                globalautocompleteByCombination(cboByPhrase, Me)
                globalautopopulateByCombination(cboByPhrase, Me)
                visibleGB(legit, fraud)
            ElseIf cboBy.Text = "ProductCode" Then
                globalautocompleteByProductCode(cboByPhrase, Me)
                globalautopopulateByProductCode(cboByPhrase, Me)
                visibleGB(fraud, legit)
            ElseIf cboBy.Text = "SKU" Then
                autocompleteBySKU(cboByPhrase)
                autopopulateBySKU(cboByPhrase)
                visibleGB(legit, fraud)
            End If
            cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboByPhrase_Leave(sender As Object, e As EventArgs) Handles cboByPhrase.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cboByPhrase.Text <> "" Then
                If cboBy.Text = "" Then
                    dgProductColorSizes.Rows.Clear()
                    dgProductColors.Rows.Clear()
                    dgProductSizes.Rows.Clear()
                ElseIf cboBy.Text = "Combination" Then
                    getProductColorSizesIDB(cboByPhrase.Text, Me)
                    bfproductcolorsizesid = globalproductcolorsizesid
                    If bfproductcolorsizesid <> 0 Then
                        displayProductsA(bfproductcolorsizesid)
                        colorCoding()
                    Else
                        dgProductColorSizes.Rows.Clear()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    getProductIDB(cboByPhrase.Text, Me)
                    bfproductid = globalproductid
                    If bfproductid <> 0 Then
                        displayProductsB(bfproductid)
                        colorCoding()
                    Else
                        dgProductColors.Rows.Clear()
                        dgProductSizes.Rows.Clear()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    getProductColorSizesSKUA(cboByPhrase.Text, Me)
                    bfproductcolorsizesid = globalskuid
                    If bfproductcolorsizesid <> 0 Then
                        displayProductsA(bfproductcolorsizesid)
                        colorCoding()
                    Else
                        dgProductColorSizes.Rows.Clear()
                    End If
                End If
            Else
                dgProductColorSizes.Rows.Clear()
                dgProductColors.Rows.Clear()
                dgProductSizes.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub cboByPhrase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboByPhrase.SelectedIndexChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cboByPhrase.Text <> "" Then
    '            If cboBy.Text = "" Then
    '                dgProductColorSizes.Rows.Clear()
    '                dgProductColors.Rows.Clear()
    '                dgProductSizes.Rows.Clear()
    '            ElseIf cboBy.Text = "Combination" Then
    '                getProductColorSizesIDB(cboByPhrase.Text, Me)
    '                bfproductcolorsizesid = globalproductcolorsizesid
    '                If bfproductcolorsizesid <> 0 Then
    '                    displayProductsA(bfproductcolorsizesid)
    '                    colorCoding()
    '                Else
    '                    dgProductColorSizes.Rows.Clear()
    '                End If
    '            ElseIf cboBy.Text = "ProductCode" Then
    '                getProductIDB(cboByPhrase.Text, Me)
    '                bfproductid = globalproductid
    '                If bfproductid <> 0 Then
    '                    displayProductsB(bfproductid)
    '                    colorCoding()
    '                Else
    '                    dgProductColors.Rows.Clear()
    '                    dgProductSizes.Rows.Clear()
    '                End If
    '            ElseIf cboBy.Text = "SKU" Then
    '                getProductColorSizesSKUA(cboByPhrase.Text, Me)
    '                bfproductcolorsizesid = globalskuid
    '                If bfproductcolorsizesid <> 0 Then
    '                    displayProductsA(bfproductcolorsizesid)
    '                    colorCoding()
    '                Else
    '                    dgProductColorSizes.Rows.Clear()
    '                End If
    '            End If
    '        Else
    '            dgProductColorSizes.Rows.Clear()
    '            dgProductColors.Rows.Clear()
    '            dgProductSizes.Rows.Clear()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    'Private Sub cboByPhrase_TextChanged(sender As Object, e As EventArgs) Handles cboByPhrase.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cboByPhrase.Text <> "" Then
    '            If cboBy.Text = "" Then
    '                dgProductColorSizes.Rows.Clear()
    '                dgProductColors.Rows.Clear()
    '                dgProductSizes.Rows.Clear()
    '            ElseIf cboBy.Text = "Combination" Then
    '                getProductColorSizesIDB(cboByPhrase.Text, Me)
    '                bfproductcolorsizesid = globalproductcolorsizesid
    '                If bfproductcolorsizesid <> 0 Then
    '                    displayProductsA(bfproductcolorsizesid)
    '                    colorCoding()
    '                Else
    '                    dgProductColorSizes.Rows.Clear()
    '                End If
    '            ElseIf cboBy.Text = "ProductCode" Then
    '                getProductIDB(cboByPhrase.Text, Me)
    '                bfproductid = globalproductid
    '                If bfproductid <> 0 Then
    '                    displayProductsB(bfproductid)
    '                    colorCoding()
    '                Else
    '                    dgProductColors.Rows.Clear()
    '                    dgProductSizes.Rows.Clear()
    '                End If
    '            ElseIf cboBy.Text = "SKU" Then
    '                getProductColorSizesSKUA(cboByPhrase.Text, Me)
    '                bfproductcolorsizesid = globalskuid
    '                If bfproductcolorsizesid <> 0 Then
    '                    displayProductsA(bfproductcolorsizesid)
    '                    colorCoding()
    '                Else
    '                    dgProductColorSizes.Rows.Clear()
    '                End If
    '            End If
    '        Else
    '            dgProductColorSizes.Rows.Clear()
    '            dgProductColors.Rows.Clear()
    '            dgProductSizes.Rows.Clear()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub dgProductColors_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductColors.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductColors.Rows.Count <> 0 Then
                displayProductsC(CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value))
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
                    displayProductsC(CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value))
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgProductSizes_KeyDown(sender As Object, e As KeyEventArgs) Handles dgProductSizes.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Enter Then
                    btnAddperformclick()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgProductSizes_MouseUp(sender As Object, e As MouseEventArgs) Handles dgProductSizes.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgProductSizes.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgProductSizes.BeginEdit(True)
                Else
                    dgProductSizes.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgBundleItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgBundleItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgBundleItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgBundleItems.BeginEdit(True)
                Else
                    dgBundleItems.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            btnAddperformclick()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                btnAddperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            dgBundleItems.CommitEdit(legit) : dgBundleItems.ClearSelection() : dgBundleItems.CurrentCell = Nothing
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Bundles", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.BndlsForm = False
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
            If cue = "New" Then
                getProductBundleIDA(txtBundleName.Text, Me)
            ElseIf cue = "Edit" Then
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgBundleList.Rows.Count <> 0 Then
                    getProductBundleIDB(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value), txtBundleName.Text, Me)
                End If
            End If
            bfproductbundleid = globalproductbundleid
            myModule.systemerrorfound = False
            If LTrim(txtBundleName.Text) = "" Then
                errProvider.SetError(txtBundleName, "Please type the bundle name.")
                txtBundleName.Focus()
            ElseIf LTrim(cboStatus.Text) = "" Then
                errProvider.SetError(cboStatus, "Please choose the status of the bundle.")
                cboStatus.Focus()
            ElseIf bfproductbundleid <> 0 Then
                errProvider.SetError(txtBundleName, "Bundle name has been created already, please type a new one.")
                txtBundleName.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    If LTrim(cboCategory.Text) <> "" Then
                        getCategoryID(cboCategory.Text, "", Me) : bfcategoryid = globalcategoryid
                        If bfcategoryid = 0 Then
                            I_Categories(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboCategory.Text, "Active", Me)
                            getCategoryID(cboCategory.Text, "", Me) : bfcategoryid = globalcategoryid
                        End If
                    Else
                        bfcategoryid = 0
                    End If
                    If myModule.systemerrorfound = True Then
                        Exit Try
                    End If
                    If LTrim(cboBrandName.Text) <> "" Then
                        getBrandID(cboBrandName.Text, Me) : bfbrandid = globalbrandid
                        If bfbrandid = 0 Then
                            I_Brands(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboBrandName.Text, "Active", Me)
                            getBrandID(cboBrandName.Text, Me) : bfbrandid = globalbrandid
                        End If
                    Else
                        bfbrandid = 0
                    End If
                    If myModule.systemerrorfound = True Then
                        Exit Try
                    End If
                    If LTrim(cboCompany.Text) <> "" Then
                        getCompanyIDA("AND companyname = """ & cboCompany.Text & """", "", Me) : bfcompanyid = globalcompanyid
                        If bfcompanyid = 0 Then
                            I_Companies(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, "", cboCompany.Text, "Active", Me)
                            getCompanyIDA("AND companyname = """ & cboCompany.Text & """", "", Me) : bfcompanyid = globalcompanyid
                        End If
                    Else
                        bfcompanyid = 0
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
                    If cue = "New" Then
                        getProductBundleSKUA(txtSKU.Text, Me)
                        bfskuid = globalskuid
                        If bfskuid = 0 Then
                            getProductColorSizesSKUA(txtSKU.Text, Me)
                            bfskuid = globalskuid
                        End If
                        getProductBundleIDA(txtBundleName.Text, Me)
                        bfproductbundleid = globalproductbundleid
                        If bfproductbundleid <> 0 Then
                            errProvider.SetError(txtBundleName, "Bundle name has been created already, please type a new one.")
                            txtBundleName.Focus()
                            Exit Try
                        End If
                        I_ProductBundles(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(bfcategoryid = 0, DBNull.Value, bfcategoryid), If(bfbrandid = 0, DBNull.Value, bfbrandid), If(bfcompanyid = 0, DBNull.Value, bfcompanyid), _
                                txtBundleName.Text, If(bfskuid = 0, txtSKU.Text, ""), cboUnitOfMeasure.Text, txtDescription.Text, cboStatus.Text, If(IsNumeric(txtSRP.Text), CDec(txtSRP.Text), 0.0), Me)
                        If myModule.systemerrorfound = False Then
                            If dgBundleItems.Rows.Count <> 0 Then
                                getProductBundleIDA(txtBundleName.Text, Me)
                                bfproductbundleid = globalproductbundleid
                                For a = 0 To dgBundleItems.Rows.Count - 1
                                    If myModule.systemerrorfound = False Then
                                        I_ProductBundleItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, bfproductbundleid, CInt(dgBundleItems.Rows(a).Cells("bi_pcsrowid").Value), _
                                                If(IsNumeric(dgBundleItems.Rows(a).Cells("bi_qtyavailable").Value), CInt(dgBundleItems.Rows(a).Cells("bi_qtyavailable").Value), 0), "Active", Me)
                                    Else
                                        Exit Try
                                    End If
                                Next
                            End If
                        End If
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                        End If
                    ElseIf cue = "Edit" Then
                        getProductBundleSKUB(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value), txtSKU.Text, Me)
                        bfskuid = globalskuid
                        If bfskuid = 0 Then
                            getProductColorSizesSKUA(txtSKU.Text, Me)
                            bfskuid = globalskuid
                        End If
                        If dgBundleList.Rows.Count <> 0 Then
                            getProductBundleIDB(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value), txtBundleName.Text, Me)
                            bfproductbundleid = globalproductbundleid
                        End If
                        If bfproductbundleid <> 0 Then
                            errProvider.SetError(txtBundleName, "Bundle name has been created already, please type a new one.")
                            txtBundleName.Focus()
                            Exit Try
                        End If
                        U_ProductBundles(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(bfcategoryid = 0, DBNull.Value, bfcategoryid), If(bfbrandid = 0, DBNull.Value, bfbrandid), _
                                If(bfcompanyid = 0, DBNull.Value, bfcompanyid), txtBundleName.Text, If(bfskuid = 0, txtSKU.Text, ""), cboUnitOfMeasure.Text, txtDescription.Text, cboStatus.Text, If(IsNumeric(txtSRP.Text), CDec(txtSRP.Text), 0.0), Me)
                        If myModule.systemerrorfound = False Then
                            If dgBundleItems.Rows.Count <> 0 Then
                                For a = 0 To dgBundleItems.Rows.Count - 1
                                    If myModule.systemerrorfound = False Then
                                        getProductBundleItemID(CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value), CInt(dgBundleItems.Rows(a).Cells("bi_pcsrowid").Value), Me)
                                        bfproductbundleitemid = globalproductbundleitemid
                                        If bfproductbundleitemid = 0 Then
                                            I_ProductBundleItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CInt(dgBundleList.CurrentRow.Cells("b_rowid").Value), CInt(dgBundleItems.Rows(a).Cells("bi_pcsrowid").Value), _
                                                If(IsNumeric(dgBundleItems.Rows(a).Cells("bi_qtyavailable").Value), CInt(dgBundleItems.Rows(a).Cells("bi_qtyavailable").Value), 0), "Active", Me)
                                        Else
                                            U_ProductBundleItems(bfproductbundleitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgBundleItems.Rows(a).Cells("bi_qtyavailable").Value), CInt(dgBundleItems.Rows(a).Cells("bi_qtyavailable").Value), 0), "Active", Me)
                                        End If
                                    Else
                                        Exit Try
                                    End If
                                Next
                            End If
                        End If
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                        End If
                    Else
                    End If
                    If myModule.systemerrorfound = False Then
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
    Private Sub dgBundleItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBundleItems.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBundleItems.Rows.Count <> 0 Then
                If e.ColumnIndex = dgBundleItems.Columns("bi_option").Index Then
                    If IsNumeric(dgBundleItems.CurrentRow.Cells("bi_rowid").Value) Then
                        If dgBundleItems.CurrentRow.Cells("bi_rowid").Value = 0 Then
                            If dgBundleItems.SelectedRows.Count > 0 Then
                                dgBundleItems.Rows.Remove(dgBundleItems.SelectedRows(0))
                            End If
                        Else
                            getPositionID(Me)
                            If globalpositionid <> 0 Then
                                getPositionView(globalpositionid, "Bundles", Me)
                                If globaldisableflg = "Y" Then
                                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    PrimaryForm.BndlsForm = False
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
                            If MessageBox.Show("Would you like to delete this item from this list?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Me.Cursor = Cursors.WaitCursor
                                U_ProductBundleItems(CInt(dgBundleItems.CurrentRow.Cells("bi_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgBundleItems.CurrentRow.Cells("bi_qtyavailable").Value), CInt(dgBundleItems.CurrentRow.Cells("bi_qtyavailable").Value), 0), "Inactive", Me)
                                If myModule.systemerrorfound = False Then
                                    If dgBundleItems.SelectedRows.Count > 0 Then
                                        dgBundleItems.Rows.Remove(dgBundleItems.SelectedRows(0))
                                    End If
                                    myBalloon("Successfully Deleted", "Delete", lblsavemsg, -15, -65)
                                End If
                            End If
                        End If
                    Else
                        If dgBundleItems.SelectedRows.Count > 0 Then
                            dgBundleItems.Rows.Remove(dgBundleItems.SelectedRows(0))
                        End If
                    End If
                    itemno = startingpage
                    For i As Integer = 0 To dgBundleItems.Rows.Count - 1
                        dgBundleItems.Rows(i).Cells("bi_seqno").Value = itemno
                        itemno = itemno + 1
                    Next i
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
            ElseIf cboSearch1.Text = "ProductCode" Then
                autocompleteProductCode(cboSearch2)
                autopopulateProductCode(cboSearch2)
            ElseIf cboSearch1.Text = "SKU" Then
                autocompleteSKU(cboSearch2)
                autopopulateSKU(cboSearch2)
            ElseIf cboSearch1.Text = "Status" Then
                autocompleteStatus(cboSearch2)
                autopopulateStatus(cboSearch2)
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
            ElseIf cboSearch3.Text = "ProductCode" Then
                autocompleteProductCode(cboSearch4)
                autopopulateProductCode(cboSearch4)
            ElseIf cboSearch3.Text = "SKU" Then
                autocompleteSKU(cboSearch4)
                autopopulateSKU(cboSearch4)
            ElseIf cboSearch3.Text = "Status" Then
                autocompleteStatus(cboSearch4)
                autopopulateStatus(cboSearch4)
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
                displayBundleList(spagenum)
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
                displayBundleList(spagenum)
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
                displayBundleList(spagenum)
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
                displayBundleList(spagenum)
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
                            displayBundleList(spagenum)
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
    Private Sub dgBundleList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgBundleList.DataError
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
                dgBundleList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgProductColorSizes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductColorSizes.DataError
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
                dgProductColorSizes.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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
    Private Sub dgBundleItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgBundleItems.DataError
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
                dgBundleItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#End Region
End Class