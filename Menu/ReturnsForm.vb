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
Imports WarehouseManagementSystem.Core.Enums
Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Infrastructure.Data.Repositories
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Math
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Information

Public Class ReturnsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdataset As New DataSetA.SetDDataTable
    Dim printdatatable As New DataTable
    Dim sqlquery As String
    Dim cue, searchmode As String
    Dim itemno, rowscount As Integer
    Dim pooverallsrp, pototalsrp, poitotalprice As Decimal
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim pototalqtyordered, poqtyordered, poitotalqtyordered, poiqtyordered As Integer
    Dim pocustomerid, poorderid, poproductcolorsizesid, poproductid, poproductbundleid As Integer
    Dim simplesearchphrase, datephrase, commonphrase, pagefilter1, pagefilter2, pagefilter3, pagefilter4 As String
    Private Sub ReturnsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            displayPullOutList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ReturnsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        globalautocompleteAccountName(cboCustomerName, "Customer", "AND a.`status` = 'Active'", Me)
    End Sub
    Sub callAutoPopulate()
        autopopulatecboSearch()
        autopopulatecboBy()
        globalautopopulateAccountName(cboCustomerName, "Customer", "AND a.`status` = 'Active'", Me)
        autopopulateDeliveryLineUp()
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearPullOutInformation()
            clearAddProductA()
            clearAddProductB()
            clearPullOutItems()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visiblePullOutItems(fraud)
            visibleGB(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearRightPage()
        Try
            cue = ""
            clearPullOutInformation()
            clearAddProductA()
            clearAddProductB()
            clearPullOutItems()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visiblePullOutItems(fraud)
            visibleGB(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud)
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
            dtpFromSearch.Value = Now.Date.AddDays(-(Now.Day) + 1)
            dtpToSearch.Value = Now.Date
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearcboSearch()
        Try
            txtPage.Text = ""
            cboSearch1.SelectedItem = Nothing
            cboSearch3.SelectedItem = Nothing
            cboSearch2.Items.Clear() : cboSearch2.AutoCompleteCustomSource.Clear()
            cboSearch2.Text = "" : cboSearch2.SelectedItem = Nothing
            cboSearch4.Items.Clear() : cboSearch4.AutoCompleteCustomSource.Clear()
            cboSearch4.Text = "" : cboSearch4.SelectedItem = Nothing
            dtpFromSearch.Value = Now.Date.AddDays(-(Now.Day) + 1)
            dtpToSearch.Value = Now.Date
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearPullOutInformation()
        Try
            txtPullOutNo.Text = ""
            cboCustomerName.Text = ""
            txtStatus.Text = ""
            txtComments.Text = ""
            txtRRNo.Text = ""
            cboCustomerName.SelectedItem = Nothing
            dtpPullOutDate.Value = Now.Date
            cboDRNo.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearAddProductA()
        Try
            cboByPhrase.Text = ""
            txtQtyOrdered.Text = ""
            cboBy.SelectedItem = Nothing
            cboByPhrase.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearAddProductB()
        Try
            txtOverallQty.Text = ""
            txtOverallPrice.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearPullOutItems()
        Try
            chkOtherInfo.Checked = fraud
            txtTotalItems.Text = ""
            txtTotalQty.Text = ""
            txtTotalPrice.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearDatagrids()
        Try
            dgProductColorSizes.Rows.Clear()
            dgProductColors.Rows.Clear()
            dgProductSizes.Rows.Clear()
            dgPullOutItems.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbPullOutList.Enabled = enable1
            gbPullOutInformation.Enabled = enable2
            gbPullOutItems.Enabled = enable2
            gbAddProducts.Enabled = enable3
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub enableANDvisibleMS(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal visible1 As Boolean, ByVal visible2 As Boolean)
        Try
            msNew.Enabled = enable1
            msSave.Enabled = enable2
            msCancel.Visible = visible1
            msOrder.Visible = visible2
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub visiblePullOutItems(ByVal visible1 As Boolean)
        Try
            ci_unitofmeasure.Visible = visible1
            ci_qtyreceived.Visible = visible1
            ci_qtybad.Visible = visible1
            ci_reason.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub visibleGB(ByVal visible1 As Boolean, ByVal visible2 As Boolean, ByVal visible3 As Boolean, ByVal visible4 As Boolean, ByVal visible5 As Boolean)
        Try
            dgProductColorSizes.Visible = visible1
            dgProductColors.Visible = visible2
            dgProductSizes.Visible = visible2
            lblOverallQty.Visible = visible4
            txtOverallQty.Visible = visible4
            lblOverallPrice.Visible = visible5
            lblOverallPesoSign.Visible = visible5
            txtOverallPrice.Visible = visible5
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
            displayPullOutList(spagenum)
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
            If cboBy.Text <> "" Then
                If LTrim(cboByPhrase.Text) = "" Then
                    errProvider.SetError(cboByPhrase, "Please fill-up this box.")
                    cboByPhrase.Focus()
                    Exit Try
                ElseIf cboBy.Text = "Combination" Then
                    If Not IsNumeric(txtQtyOrdered.Text) Then
                        errProvider.SetError(txtQtyOrdered, "Please use numbers for pulled-out qty.")
                        txtQtyOrdered.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the combination code.")
                        cboByPhrase.Focus()
                    Else
                        checkPullOutItemsA()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    If dgProductSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the sizes.")
                        cboByPhrase.Focus()
                    Else
                        checkPullOutItemsB()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    If Not IsNumeric(txtQtyOrdered.Text) Then
                        errProvider.SetError(txtQtyOrdered, "Please use numbers for pulled-out qty.")
                        txtQtyOrdered.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the sku.")
                        cboByPhrase.Focus()
                    Else
                        If dgProductColorSizes.Rows.Count <> 0 Then
                            checkPullOutItemsA()
                        End If
                    End If
                End If
            Else
                errProvider.SetError(cboBy, "Please choose among the options given in this box.")
                cboBy.Focus()
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
    Sub addproductcomputations()
        Try
            pototalqtyordered = 0 : poqtyordered = 0 : pooverallsrp = 0.0 : pototalsrp = 0.0
            If IsNumeric(txtQtyOrdered.Text) Then
                poqtyordered = CInt(txtQtyOrdered.Text)
            Else
                poqtyordered = 0
            End If
            If dgProductColorSizes.Visible = legit Then
                If dgProductColorSizes.Rows.Count <> 0 Then
                    For i = 0 To dgProductColorSizes.Rows.Count - 1
                        If IsNumeric(dgProductColorSizes.Rows(i).Cells("pcs_srp").Value) Then
                            pototalsrp = pototalsrp + CDec(dgProductColorSizes.Rows(i).Cells("pcs_srp").Value)
                        End If
                    Next
                End If
                pooverallsrp = pototalsrp * poqtyordered
            ElseIf dgProductSizes.Visible = legit Then
                If dgProductSizes.Rows.Count <> 0 Then
                    For i = 0 To dgProductSizes.Rows.Count - 1
                        If IsNumeric(dgProductSizes.Rows(i).Cells("s_qtyordered").Value) Then
                            poqtyordered = CInt(dgProductSizes.Rows(i).Cells("s_qtyordered").Value)
                            pototalqtyordered = pototalqtyordered + CInt(dgProductSizes.Rows(i).Cells("s_qtyordered").Value)
                        Else
                            poqtyordered = 0
                        End If
                        If IsNumeric(dgProductSizes.Rows(i).Cells("s_srp").Value) Then
                            dgProductSizes.Rows(i).Cells("s_totalprice").Value = poqtyordered * CDec(dgProductSizes.Rows(i).Cells("s_srp").Value)
                        Else
                            dgProductSizes.Rows(i).Cells("s_totalprice").Value = 0.0
                        End If
                        If IsNumeric(dgProductSizes.Rows(i).Cells("s_totalprice").Value) Then
                            pooverallsrp = pooverallsrp + CDec(dgProductSizes.Rows(i).Cells("s_totalprice").Value)
                        End If
                    Next
                End If
            End If
            txtOverallQty.Text = Format(pototalqtyordered, "#,##0")
            txtOverallPrice.Text = Format(pooverallsrp, "#,##0.00")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub pulloutitemscomputations()
        Try
            poitotalqtyordered = 0 : poiqtyordered = 0 : poitotalprice = 0.0
            If dgPullOutItems.Rows.Count <> 0 Then
                For i = 0 To dgPullOutItems.Rows.Count - 1
                    If IsNumeric(dgPullOutItems.Rows(i).Cells("ci_qtyordered").Value) Then
                        poiqtyordered = CInt(dgPullOutItems.Rows(i).Cells("ci_qtyordered").Value)
                        poitotalqtyordered = poitotalqtyordered + CInt(dgPullOutItems.Rows(i).Cells("ci_qtyordered").Value)
                    Else
                        poiqtyordered = 0
                    End If
                    If IsNumeric(dgPullOutItems.Rows(i).Cells("ci_srp").Value) Then
                        dgPullOutItems.Rows(i).Cells("ci_totalprice").Value = Math.Round(poiqtyordered * CDec(dgPullOutItems.Rows(i).Cells("ci_srp").Value), 2)
                    Else
                        dgPullOutItems.Rows(i).Cells("ci_totalprice").Value = 0.0
                    End If
                    If IsNumeric(dgPullOutItems.Rows(i).Cells("ci_totalprice").Value) Then
                        poitotalprice = poitotalprice + CDec(dgPullOutItems.Rows(i).Cells("ci_totalprice").Value)
                    End If
                Next
            End If
            txtTotalItems.Text = dgPullOutItems.Rows.Count
            txtTotalQty.Text = Format(poitotalqtyordered, "#,##0")
            txtTotalPrice.Text = Format(poitotalprice, "#,##0.00")
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
            dtCid = getDataTableForSQL("SELECT COUNT(po.rowid) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' " &
                            "AND (po.ordernumber LIKE '%" & esearchstring & "%' OR po.status LIKE '%" & esearchstring & "%' OR su.companyname LIKE '%" & esearchstring & "%') ")
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
    Sub pageSetup2(ByVal idatesearch As String)
        Try
            getCountPageNum2(idatesearch)
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
    Sub getCountPageNum2(ByVal edatesearch As String)
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' AND " &
                            "(" & edatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                            "" & edatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) ")
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
    Sub pageSetup3(ByVal icommonstring As String, ByVal idatesearch As String)
        Try
            getCountPageNum3(icommonstring, idatesearch)
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
    Sub getCountPageNum3(ByVal ecommonstring As String, ByVal edatesearch As String)
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' AND " & ecommonstring & " " & edatesearch & " ")
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
            If icommonbox.Text = "CustomerName" Then
                getCustomerID(icommonstring, Me)
                pocustomerid = globalcustomerid
                commonphrase = "po.accountid = " & pocustomerid & ""
            ElseIf icommonbox.Text = "Status" Then
                commonphrase = "po.status = """ & icommonstring & """"
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
    Sub autocompleteCustomerName(ByVal icombobox As ComboBox)
        Try
            Dim customername As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'') AS 'customername' FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' GROUP BY su.accountno ORDER BY su.accountno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                customername.Add(ds.Tables(0).Rows(i)("customername").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = customername
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autocompleteStatus(ByVal icombobox As ComboBox)
        Try
            Dim costatus As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(po.status,'') AS 'postatus' FROM orders po WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' GROUP BY po.status ORDER BY po.status ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                costatus.Add(ds.Tables(0).Rows(i)("postatus").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = costatus
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
            cboSearch1.Items.Add("CustomerName")
            cboSearch1.Items.Add("Status")
            cboSearch3.Items.Add("CustomerName")
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
    Sub autopopulateCustomerName(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'') AS 'Customername' FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' GROUP BY su.accountno ORDER BY su.companyname "
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
            Dim sql1 As String = "SELECT COALESCE(po.status,'') AS 'postatus' FROM orders po WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' GROUP BY po.status ORDER BY po.status "
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
    Private Async Sub autopopulateDeliveryLineUp()
        cboDRNo.Items.Clear()
        Dim lineUpRepository = MainServiceProvider.GetRequiredService(Of ILineupRepository)
        Dim lineUps = Await lineUpRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)
        For Each lineUp In lineUps
            cboDRNo.Items.Add(lineUp.RowID)
        Next
        cboDRNo.Items.Add("")
    End Sub
#End Region
#Region "Datagrids"
    Sub displayPullOutList(ByVal istartpage As Integer)
        Try
            dgPullOutList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' " &
                        "ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPullOutList.Rows.Add()
                    dgPullOutList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgPullOutList.Item(so_pulloutno.Index, n).Value = reader1(1)
                    dgPullOutList.Item(so_pulloutdate.Index, n).Value = reader1(2)
                    dgPullOutList.Item(so_customername.Index, n).Value = reader1(3)
                    dgPullOutList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPullOutList.Columns("so_pulloutno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutList.Columns("so_pulloutdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPullOutList.Rows.Count <> 0 Then
                dgPullOutList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgPullOutList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' AND " &
                        "(po.ordernumber LIKE '%" & isearchphrase & "%' OR po.status LIKE '%" & isearchphrase & "%' OR cu.companyname LIKE '%" & isearchphrase & "%') " &
                        "ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPullOutList.Rows.Add()
                    dgPullOutList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgPullOutList.Item(so_pulloutno.Index, n).Value = reader1(1)
                    dgPullOutList.Item(so_pulloutdate.Index, n).Value = reader1(2)
                    dgPullOutList.Item(so_customername.Index, n).Value = reader1(3)
                    dgPullOutList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPullOutList.Columns("so_PullOutno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutList.Columns("so_PullOutdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPullOutList.Rows.Count <> 0 Then
                dgPullOutList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayDateSearch(ByVal istartpage As Integer, ByVal idatesearch As String)
        Try
            dgPullOutList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' AND " &
                        "(" & idatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                        "" & idatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) " &
                        "GROUP BY po.rowid ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPullOutList.Rows.Add()
                    dgPullOutList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgPullOutList.Item(so_pulloutno.Index, n).Value = reader1(1)
                    dgPullOutList.Item(so_pulloutdate.Index, n).Value = reader1(2)
                    dgPullOutList.Item(so_customername.Index, n).Value = reader1(3)
                    dgPullOutList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPullOutList.Columns("so_PullOutno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutList.Columns("so_PullOutdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPullOutList.Rows.Count <> 0 Then
                dgPullOutList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal idatesearch As String, ByVal istartpage As Integer)
        Try
            dgPullOutList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' " &
                        "AND " & icommonphrase & " " & idatesearch & " GROUP BY po.rowid ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPullOutList.Rows.Add()
                    dgPullOutList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgPullOutList.Item(so_pulloutno.Index, n).Value = reader1(1)
                    dgPullOutList.Item(so_pulloutdate.Index, n).Value = reader1(2)
                    dgPullOutList.Item(so_customername.Index, n).Value = reader1(3)
                    dgPullOutList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPullOutList.Columns("so_PullOutno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutList.Columns("so_PullOutdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPullOutList.Rows.Count <> 0 Then
                dgPullOutList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayPullOutInformation(ByVal ipulloutid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(po.comments,''),COALESCE(po.status,''),COALESCE(po.lineUpId,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.rowid = " & ipulloutid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtPullOutNo.Text = reader1(0)
                    dtpPullOutDate.Text = reader1(1)
                    cboCustomerName.Text = reader1(2)
                    txtComments.Text = reader1(3)
                    txtStatus.Text = reader1(4)
                    cboDRNo.Text = reader1(5)
                    getRRInfo(ipulloutid, Me)
                    txtRRNo.Text = gloRRNo
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub
    Sub displayPullOutItems(ByVal iPullOutid As Integer)
        Try
            dgPullOutItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(ci.productbundleid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(b.bundlename,''),COALESCE(c.colorname,''),COALESCE(pcs.size,'')," &
                    "COALESCE(pcs.seasoncode,''),COALESCE(ci.unitofmeasure,''),COALESCE(ci.qtyordered,0),COALESCE(ci.srp,0.0),COALESCE(pcs.sku,''),COALESCE(b.sku,''),COALESCE(ci.itemtype,''),COALESCE(ci.remarks,''),COALESCE(ci.qtyreceived,0)," &
                    "COALESCE(ci.qtydamaged,0),COALESCE(ci.reasons,'') FROM orderitems ci LEFT JOIN productbundles b ON ci.productbundleid = b.rowid LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " &
                    "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE ci.orderid = " & iPullOutid & " AND ci.organizationid = " & Z_OrganizationID & " " &
                    "AND ci.status != 'Inactive' AND ci.itemtype != 'BI' ORDER BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgPullOutItems.Rows.Add()
                    dgPullOutItems.Item(ci_seqno.Index, n).Value = seqno
                    dgPullOutItems.Item(ci_rowid.Index, n).Value = reader1(0)
                    dgPullOutItems.Item(ci_pcsrowid.Index, n).Value = reader1(1)
                    dgPullOutItems.Item(ci_bid.Index, n).Value = reader1(2)
                    dgPullOutItems.Item(ci_colorvalue.Index, n).Value = reader1(3)
                    If CInt(reader1(1)) <> 0 Then
                        dgPullOutItems.Item(ci_productcode.Index, n).Value = reader1(4)
                    Else
                        dgPullOutItems.Item(ci_productcode.Index, n).Value = reader1(5)
                    End If
                    dgPullOutItems.Item(ci_colorname.Index, n).Value = reader1(6)
                    dgPullOutItems.Item(ci_size.Index, n).Value = reader1(7)
                    dgPullOutItems.Item(ci_seasoncode.Index, n).Value = reader1(8)
                    dgPullOutItems.Item(ci_unitofmeasure.Index, n).Value = reader1(9)
                    dgPullOutItems.Item(ci_qtyordered.Index, n).Value = reader1(10)
                    dgPullOutItems.Item(ci_srp.Index, n).Value = reader1(11)
                    If CInt(reader1(1)) <> 0 Then
                        dgPullOutItems.Item(ci_sku.Index, n).Value = reader1(12)
                    Else
                        dgPullOutItems.Item(ci_sku.Index, n).Value = reader1(13)
                    End If
                    dgPullOutItems.Item(ci_remarks.Index, n).Value = reader1(15)
                    dgPullOutItems.Item(ci_qtyreceived.Index, n).Value = reader1(16)
                    dgPullOutItems.Item(ci_qtybad.Index, n).Value = reader1(17)
                    dgPullOutItems.Item(ci_reason.Index, n).Value = reader1(18)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPullOutItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_qtybad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPullOutItems.Rows.Count <> 0 Then
                dgPullOutItems.CurrentRow.Selected = False
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
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,''),COALESCE(p.unitprice,0.00) " &
                "FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.rowid = " & iproductcolorsizeid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductColorSizes.Rows.Add()
                    dgProductColorSizes.Item(pcs_rowid.Index, n).Value = reader1(0)
                    dgProductColorSizes.Item(pcs_colorvalue.Index, n).Value = reader1(1)
                    dgProductColorSizes.Item(pcs_productcode.Index, n).Value = reader1(2)
                    dgProductColorSizes.Item(pcs_colorname.Index, n).Value = reader1(3)
                    dgProductColorSizes.Item(pcs_size.Index, n).Value = reader1(4)
                    dgProductColorSizes.Item(pcs_seasoncode.Index, n).Value = reader1(5)
                    dgProductColorSizes.Item(pcs_sku.Index, n).Value = reader1(6)
                    dgProductColorSizes.Item(pcs_srp.Index, n).Value = CDec(reader1(7))
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    dgProductColorSizes.Item(pcs_qtyavailable.Index, n).Value = globaltotalqtyavailable
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductColorSizes.Columns("pcs_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
    Sub displayProductsC(ByVal iproductcolorid As Integer)
        Try
            dgProductSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(pcs.size,0.0),COALESCE(pcs.seasoncode,''),COALESCE(p.unitprice,0.00),COALESCE(pcs.sku,'') FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " &
                        "LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.productcolorid = " & iproductcolorid & " AND pcs.status = 'Active' ORDER BY pcs.size ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductSizes.Rows.Add()
                    dgProductSizes.Item(s_rowid.Index, n).Value = reader1(0)
                    dgProductSizes.Item(s_sizes.Index, n).Value = reader1(1)
                    dgProductSizes.Item(s_seasoncode.Index, n).Value = reader1(2)
                    dgProductSizes.Item(s_qtyordered.Index, n).Value = ""
                    dgProductSizes.Item(s_srp.Index, n).Value = reader1(3)
                    dgProductSizes.Item(s_totalprice.Index, n).Value = ""
                    dgProductSizes.Item(s_sku.Index, n).Value = reader1(4)
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    dgProductSizes.Item(s_qtyavailable.Index, n).Value = globaltotalqtyavailable
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductSizes.Columns("s_sizes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            If dgPullOutItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgPullOutItems.Rows.Count - 1
                    If CStr(dgPullOutItems.Rows(i).Cells("ci_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgPullOutItems.Rows(i).Cells("ci_colorvalue").Value))
                        dgPullOutItems.Rows(i).Cells("ci_color").Style.BackColor = readcolor
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
    Sub checkPullOutItemsA()
        Try
            If dgProductColorSizes.Rows.Count <> 0 Then
                For p = 0 To dgProductColorSizes.Rows.Count - 1
                    If dgPullOutItems.Rows.Count <> 0 Then
                        rowscount = dgPullOutItems.Rows.Count - 1
                        For i = 0 To dgPullOutItems.Rows.Count - 1
                            If dgPullOutItems.Rows(i).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                errProvider.SetError(cboByPhrase, "Product is in the list already.")
                                cboByPhrase.Focus()
                                Exit Try
                            ElseIf rowscount = 0 Then
                                addPullOutItemA(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CInt(txtQtyOrdered.Text), If(IsNumeric(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), CDec(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), 0.0))
                                For a = 0 To dgPullOutItems.Rows.Count - 1
                                    dgPullOutItems.CurrentRow.Selected = fraud
                                    If dgPullOutItems.Rows(a).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                        dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Selected = legit
                                        dgPullOutItems.FirstDisplayedScrollingRowIndex = dgPullOutItems.RowCount - 1
                                        Exit For
                                    End If
                                Next
                                cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyOrdered.Text = "" : cboByPhrase.Focus() : dgProductColorSizes.Rows.Clear()
                            End If
                            rowscount = rowscount - 1
                        Next
                    Else
                        addPullOutItemA(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CInt(txtQtyOrdered.Text), If(IsNumeric(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), CDec(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), 0.0))
                        For a = 0 To dgPullOutItems.Rows.Count - 1
                            dgPullOutItems.CurrentRow.Selected = fraud
                            If dgPullOutItems.Rows(a).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Selected = legit
                                dgPullOutItems.FirstDisplayedScrollingRowIndex = dgPullOutItems.RowCount - 1
                                Exit For
                            End If
                        Next
                        cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyOrdered.Text = "" : cboByPhrase.Focus() : dgProductColorSizes.Rows.Clear()
                    End If
                Next
                itemno = 1 : colorCoding() : addproductcomputations() : pulloutitemscomputations()
                For i As Integer = 0 To dgPullOutItems.Rows.Count - 1
                    dgPullOutItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub checkPullOutItemsB()
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                For p = 0 To dgProductSizes.Rows.Count - 1
                    If IsNumeric(dgProductSizes.Rows(p).Cells("s_qtyordered").Value) Then
                        If CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value) > 0 Then
                            If dgPullOutItems.Rows.Count <> 0 Then
                                rowscount = dgPullOutItems.Rows.Count - 1
                                For i = 0 To dgPullOutItems.Rows.Count - 1
                                    If dgPullOutItems.Rows(i).Cells("ci_pcsrowid").Value = dgProductSizes.Rows(p).Cells("s_rowid").Value Then
                                        Exit For
                                    ElseIf rowscount = 0 Then
                                        addPullOutItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value), If(IsNumeric(dgProductSizes.Rows(p).Cells("s_srp").Value), CDec(dgProductSizes.Rows(p).Cells("s_srp").Value), 0.0))
                                    End If
                                    rowscount = rowscount - 1
                                Next
                            Else
                                addPullOutItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value), If(IsNumeric(dgProductSizes.Rows(p).Cells("s_srp").Value), CDec(dgProductSizes.Rows(p).Cells("s_srp").Value), 0.0))
                            End If
                        End If
                    End If
                Next
                itemno = 1 : colorCoding() : addproductcomputations() : pulloutitemscomputations()
                For i As Integer = 0 To dgPullOutItems.Rows.Count - 1
                    dgPullOutItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
                If dgPullOutItems.Rows.Count <> 0 Then
                    dgPullOutItems.CurrentRow.Selected = False
                    dgPullOutItems.FirstDisplayedScrollingRowIndex = dgPullOutItems.RowCount - 1
                End If
                cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyOrdered.Text = "" : cboByPhrase.Focus()
                dgProductColors.Rows.Clear() : dgProductSizes.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub addPullOutItemA(ByVal iproductcolorsizeid As Integer, ByVal iqtyordered As Integer, ByVal isrp As Decimal)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(p.unitofmeasure,''),COALESCE(pcs.sku,''),COALESCE(pcs.seasoncode,'') " &
                "FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.rowid = " & iproductcolorsizeid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    dgPullOutItems.Rows.Add()
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_rowid").Value = ""
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_bid").Value = neutralpage
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_qtyreceived").Value = ""
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_qtybad").Value = ""
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_remarks").Value = ""
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_reason").Value = ""
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = reader1(0)
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_colorvalue").Value = reader1(1)
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_productcode").Value = reader1(2)
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_colorname").Value = reader1(3)
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_size").Value = reader1(4)
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = reader1(5)
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_qtyordered").Value = iqtyordered
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_srp").Value = isrp
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_sku").Value = reader1(6)
                    dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_seasoncode").Value = reader1(7)
                End If
            End While
            reader1.Close()
            dgPullOutItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_qtybad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOutItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
                PrimaryForm.RetForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
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
                getPositionView(globalpositionid, "Returns", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RetForm = False
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
            clearPullOutInformation()
            clearAddProductA()
            clearAddProductB()
            clearPullOutItems()
            clearDatagrids()
            enableGB(fraud, legit, legit)
            visiblePullOutItems(fraud)
            visibleGB(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(fraud, legit, legit, fraud)
            getOrderNo("Return", Me)
            txtPullOutNo.Text = CStr(globalorderno)
            txtStatus.Text = "New"
            txtPullOutNo.Focus()
            If dgPullOutList.Rows.Count <> 0 Then
                dgPullOutList.CurrentRow.Selected = False
            End If
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
            If dgPullOutList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearPullOutInformation()
                clearAddProductA()
                clearAddProductB()
                clearPullOutItems()
                clearDatagrids()
                visiblePullOutItems(fraud)
                visibleGB(fraud, fraud, fraud, fraud, fraud)
                dgPullOutList.CurrentRow.Selected = True
                displayPullOutInformation(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value))
                displayPullOutItems(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value))
                pulloutitemscomputations() : colorCoding()
                If txtStatus.Text = "New" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Received" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                End If
                txtPullOutNo.Focus()
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
    Private Sub dgPullOutList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPullOutList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPullOutList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearPullOutInformation()
                clearAddProductA()
                clearAddProductB()
                clearPullOutItems()
                clearDatagrids()
                visiblePullOutItems(fraud)
                visibleGB(fraud, fraud, fraud, fraud, fraud)
                cboDRNo.Enabled = False
                displayPullOutInformation(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value))
                displayPullOutItems(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value))
                pulloutitemscomputations() : colorCoding()
                If txtStatus.Text = "New" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Received" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                End If
                txtPullOutNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgPullOutList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgPullOutList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPullOutList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearPullOutInformation()
                    clearAddProductA()
                    clearAddProductB()
                    clearPullOutItems()
                    clearDatagrids()
                    visiblePullOutItems(fraud)
                    visibleGB(fraud, fraud, fraud, fraud, fraud)
                    displayPullOutInformation(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value))
                    displayPullOutItems(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value))
                    pulloutitemscomputations() : colorCoding()
                    If txtStatus.Text = "New" Then
                        enableGB(legit, legit, legit)
                        enableANDvisibleMS(legit, legit, fraud, legit)
                        msOrder.Text = "Cancel Order"
                    ElseIf txtStatus.Text = "Received" Then
                        enableGB(legit, legit, fraud)
                        enableANDvisibleMS(legit, fraud, fraud, fraud)
                    ElseIf txtStatus.Text = "Cancelled" Then
                        enableGB(legit, legit, fraud)
                        enableANDvisibleMS(legit, fraud, fraud, legit)
                        msOrder.Text = "Re-Open Order"
                    Else
                        enableGB(legit, legit, fraud)
                        enableANDvisibleMS(legit, fraud, fraud, fraud)
                    End If
                    txtPullOutNo.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub chkOtherInfo_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtherInfo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If chkOtherInfo.Checked = legit Then
                visiblePullOutItems(legit)
            Else
                visiblePullOutItems(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtPullOutNo_Leave(sender As Object, e As EventArgs) Handles txtPullOutNo.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                If LTrim(txtPullOutNo.Text) <> "" Then
                    getOrderIDSupB(txtPullOutNo.Text, "Return", Me)
                    poorderid = globalorderid
                    If poorderid <> 0 Then
                        errProvider.SetError(txtPullOutNo, "Return No. has been created already, please type a new one.")
                    End If
                End If
            ElseIf cue = "Edit" Then
                If dgPullOutList.Rows.Count <> 0 Then
                    If LTrim(txtPullOutNo.Text) <> "" Then
                        getOrderIDSupA(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), txtPullOutNo.Text, "Return", Me)
                        poorderid = globalorderid
                        If poorderid <> 0 Then
                            errProvider.SetError(txtPullOutNo, "Return No. has been created already, please type a new one.")
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
    'Private Sub txtPullOutNo_TextChanged(sender As Object, e As EventArgs) Handles txtPullOutNo.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            If LTrim(txtPullOutNo.Text) <> "" Then
    '                getOrderIDSupB(txtPullOutNo.Text, "Return", Me)
    '                poorderid = globalorderid
    '                If poorderid <> 0 Then
    '                    errProvider.SetError(txtPullOutNo, "Return No. has been created already, please type a new one.")
    '                End If
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgPullOutList.Rows.Count <> 0 Then
    '                If LTrim(txtPullOutNo.Text) <> "" Then
    '                    getOrderIDSupA(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), txtPullOutNo.Text, "Return", Me)
    '                    poorderid = globalorderid
    '                    If poorderid <> 0 Then
    '                        errProvider.SetError(txtPullOutNo, "Return No. has been created already, please type a new one.")
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
            txtQtyOrdered.Text = ""
            dgProductColors.Rows.Clear()
            dgProductSizes.Rows.Clear()
            dgProductColorSizes.Rows.Clear()
            If cboBy.Text = "" Then
                cboByPhrase.Items.Clear() : cboByPhrase.AutoCompleteCustomSource.Clear()
                visibleGB(fraud, fraud, fraud, fraud, fraud)
            ElseIf cboBy.Text = "Combination" Then
                globalautocompleteByCombination(cboByPhrase, Me)
                globalautopopulateByCombination(cboByPhrase, Me)
                visibleGB(legit, fraud, fraud, fraud, legit)
            ElseIf cboBy.Text = "ProductCode" Then
                globalautocompleteByProductCode(cboByPhrase, Me)
                globalautopopulateByProductCode(cboByPhrase, Me)
                visibleGB(fraud, legit, fraud, legit, legit)
            ElseIf cboBy.Text = "SKU" Then
                globalautocompleteBySKU(cboByPhrase, Me)
                globalautopopulateBySKU(cboByPhrase, Me)
                visibleGB(legit, fraud, fraud, fraud, legit)
            End If
            addproductcomputations()
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
                    poproductcolorsizesid = globalproductcolorsizesid
                    If poproductcolorsizesid <> 0 Then
                        displayProductsA(poproductcolorsizesid)
                        colorCoding()
                    Else
                        dgProductColorSizes.Rows.Clear()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    getProductIDB(cboByPhrase.Text, Me)
                    poproductid = globalproductid
                    If poproductid <> 0 Then
                        displayProductsB(poproductid)
                        colorCoding()
                    Else
                        dgProductColors.Rows.Clear()
                        dgProductSizes.Rows.Clear()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    getProductColorSizesSKUA(cboByPhrase.Text, Me)
                    poproductcolorsizesid = globalskuid
                    If poproductcolorsizesid <> 0 Then
                        visibleGB(legit, fraud, fraud, fraud, legit)
                        displayProductsA(poproductcolorsizesid)
                        colorCoding()
                    End If
                End If
            Else
                dgProductColorSizes.Rows.Clear()
                dgProductColors.Rows.Clear()
                dgProductSizes.Rows.Clear()
            End If
            addproductcomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub cboByPhrase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboByPhrase.SelectedIndexChanged
    '    Try
    '        errProvider.Clear()
    '        If cboByPhrase.Text <> "" Then
    '            If cboBy.Text = "" Then
    '                dgProductColorSizes.Rows.Clear()
    '                dgProductColors.Rows.Clear()
    '                dgProductSizes.Rows.Clear()
    '            ElseIf cboBy.Text = "Combination" Then
    '                getProductColorSizesIDB(cboByPhrase.Text, Me)
    '                poproductcolorsizesid = globalproductcolorsizesid
    '                If poproductcolorsizesid <> 0 Then
    '                    displayProductsA(poproductcolorsizesid)
    '                    colorCoding()
    '                Else
    '                    dgProductColorSizes.Rows.Clear()
    '                End If
    '            ElseIf cboBy.Text = "ProductCode" Then
    '                getProductIDB(cboByPhrase.Text, Me)
    '                poproductid = globalproductid
    '                If poproductid <> 0 Then
    '                    displayProductsB(poproductid)
    '                    colorCoding()
    '                Else
    '                    dgProductColors.Rows.Clear()
    '                    dgProductSizes.Rows.Clear()
    '                End If
    '            ElseIf cboBy.Text = "SKU" Then
    '                getProductColorSizesSKUA(cboByPhrase.Text, Me)
    '                poproductcolorsizesid = globalskuid
    '                If poproductcolorsizesid <> 0 Then
    '                    visibleGB(legit, fraud, fraud, fraud, legit)
    '                    displayProductsA(poproductcolorsizesid)
    '                    colorCoding()
    '                End If
    '            End If
    '        Else
    '            dgProductColorSizes.Rows.Clear()
    '            dgProductColors.Rows.Clear()
    '            dgProductSizes.Rows.Clear()
    '        End If
    '        addproductcomputations()
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    'Private Sub cboByPhrase_TextChanged(sender As Object, e As EventArgs) Handles cboByPhrase.TextChanged
    '    Try
    '        errProvider.Clear()
    '        If cboByPhrase.Text <> "" Then
    '            If cboBy.Text = "" Then
    '                dgProductColorSizes.Rows.Clear()
    '                dgProductColors.Rows.Clear()
    '                dgProductSizes.Rows.Clear()
    '            ElseIf cboBy.Text = "Combination" Then
    '                getProductColorSizesIDB(cboByPhrase.Text, Me)
    '                poproductcolorsizesid = globalproductcolorsizesid
    '                If poproductcolorsizesid <> 0 Then
    '                    displayProductsA(poproductcolorsizesid)
    '                    colorCoding()
    '                Else
    '                    dgProductColorSizes.Rows.Clear()
    '                End If
    '            ElseIf cboBy.Text = "ProductCode" Then
    '                getProductIDB(cboByPhrase.Text, Me)
    '                poproductid = globalproductid
    '                If poproductid <> 0 Then
    '                    displayProductsB(poproductid)
    '                    colorCoding()
    '                Else
    '                    dgProductColors.Rows.Clear()
    '                    dgProductSizes.Rows.Clear()
    '                End If
    '            ElseIf cboBy.Text = "SKU" Then
    '                getProductColorSizesSKUA(cboByPhrase.Text, Me)
    '                poproductcolorsizesid = globalskuid
    '                If poproductcolorsizesid <> 0 Then
    '                    visibleGB(legit, fraud, fraud, fraud, legit)
    '                    displayProductsA(poproductcolorsizesid)
    '                    colorCoding()
    '                End If
    '            End If
    '        Else
    '            dgProductColorSizes.Rows.Clear()
    '            dgProductColors.Rows.Clear()
    '            dgProductSizes.Rows.Clear()
    '        End If
    '        addproductcomputations()
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    Private Sub txtQtyOrdered_TextChanged(sender As Object, e As EventArgs) Handles txtQtyOrdered.TextChanged
        Try
            addproductcomputations()
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
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
    Private Sub dgProductSizes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductSizes.CellEndEdit
        Try
            addproductcomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
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
    Private Sub txtQtyOrdered_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQtyOrdered.KeyDown
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
    Private Sub pbAddCustomer_MouseEnter(sender As Object, e As EventArgs) Handles pbAddCustomer.MouseEnter
        Try
            pbAddCustomer.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddCustomer_MouseLeave(sender As Object, e As EventArgs) Handles pbAddCustomer.MouseLeave
        Try
            pbAddCustomer.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub cboDRNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDRNo.SelectedIndexChanged
        dgPullOutItems.Rows.Clear()
        Console.WriteLine(cue)
        If cue = "New" Then
            If (cboDRNo.Text <> "") Then

                Dim ask As MsgBoxResult = MsgBox("Add Order Items from Delivery Lineup?", MsgBoxStyle.YesNo)

                If ask = MsgBoxResult.Yes Then
                    Dim lineUpRepository = MainServiceProvider.GetRequiredService(Of ILineupRepository)
                    Dim lineUp = Await lineUpRepository.GetById(cboDRNo.Text)
                    Dim orderRepository = MainServiceProvider.GetRequiredService(Of IOrderRepository)
                    Dim order = Await orderRepository.GetById(lineUp.OrderID)
                    Dim n As Integer = 0
                    Dim seqno As Integer = 1

                    For Each item In order.OrderItems
                        dgPullOutItems.Rows.Add()
                        dgPullOutItems.Item(ci_seqno.Index, n).Value = seqno
                        'dgPullOutItems.Item(ci_rowid.Index, n).Value = item.RowID
                        dgPullOutItems.Item(ci_pcsrowid.Index, n).Value = item.ProductColorSizeID
                        dgPullOutItems.Item(ci_bid.Index, n).Value = item.ProductBundleID
                        dgPullOutItems.Item(ci_colorvalue.Index, n).Value = item.ProductColorSize.ProductColor.Color.ColorValue
                        dgPullOutItems.Item(ci_productcode.Index, n).Value = item.ProductColorSize.ProductColor.Product.ProductCode

                        dgPullOutItems.Item(ci_colorname.Index, n).Value = item.ProductColorSize.ProductColor.Color.ColorName
                        dgPullOutItems.Item(ci_size.Index, n).Value = item.ProductColorSize.Size
                        dgPullOutItems.Item(ci_seasoncode.Index, n).Value = item.ProductColorSize.SeasonCode
                        dgPullOutItems.Item(ci_unitofmeasure.Index, n).Value = item.UnitOfMeasure
                        dgPullOutItems.Item(ci_qtyordered.Index, n).Value = item.QtyOrdered
                        dgPullOutItems.Item(ci_srp.Index, n).Value = item.SRP
                        dgPullOutItems.Item(ci_sku.Index, n).Value = item.SKU
                        dgPullOutItems.Item(ci_remarks.Index, n).Value = item.Remarks
                        dgPullOutItems.Item(ci_qtyreceived.Index, n).Value = item.QtyReceived
                        dgPullOutItems.Item(ci_qtybad.Index, n).Value = item.QtyDamaged
                        dgPullOutItems.Item(ci_reason.Index, n).Value = item.Reasons

                        seqno = seqno + 1
                        n = n + 1
                    Next
                    colorCoding()

                End If
            End If

        End If
        pulloutitemscomputations()
    End Sub

    Private Sub pbAddCustomer_Click(sender As Object, e As EventArgs) Handles pbAddCustomer.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Returns", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RetForm = False
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
            Dim addcustomerslinkform As New AddCustomersForm
            addcustomerslinkform.ShowInTaskbar = False
            addcustomerslinkform.ShowDialog()
            If addcustomerslinkform.addcustomerformcue = legit Then
                globalautocompleteAccountName(cboCustomerName, "Customer", "AND a.`status` = 'Active'", Me)
                globalautopopulateAccountName(cboCustomerName, "Customer", "AND a.`status` = 'Active'", Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgPullOutItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgPullOutItems.CellEndEdit
        Try
            pulloutitemscomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub msOrder_Click(sender As Object, e As EventArgs) Handles msOrder.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Returns", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RetForm = False
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
            If dgPullOutList.Rows.Count <> 0 Then
                getOrderStatus(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Me)
                If globalorderstatus <> txtStatus.Text Then
                    MessageBox.Show("This Return no. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                ElseIf globalorderstatus = "New" Then
                    If MessageBox.Show("Would you like to cancel this order?", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgPullOutList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This Return no. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        U_OrderStatus(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Cancelled", "Cancel", lblsavemsg, -15, -65)
                            tsrefreshperformclick()
                        End If
                    End If
                ElseIf globalorderstatus = "Cancelled" Then
                    If MessageBox.Show("Would you like to re-open this order?", "Opening", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgPullOutList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This Return no. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        U_OrderStatus(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "New", Me)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Opened", "Open", lblsavemsg, -15, -65)
                            tsrefreshperformclick()
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
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            pulloutitemscomputations()
            dgPullOutItems.CommitEdit(legit) : dgPullOutItems.ClearSelection() : dgPullOutItems.CurrentCell = Nothing
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Returns", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RetForm = False
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
                If LTrim(cboCustomerName.Text) <> "" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    pocustomerid = globalcustomerid
                    If LTrim(txtPullOutNo.Text) <> "" Then
                        If pocustomerid = 0 Then
                            errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                            Exit Try
                        Else
                            getOrderIDSupB(txtPullOutNo.Text, "Return", Me)
                            poorderid = globalorderid
                            If poorderid <> 0 Then
                                errProvider.SetError(txtPullOutNo, "Return No. has been created already, please type a new one.")
                                Exit Try
                            End If
                        End If
                    Else
                        errProvider.SetError(pbAddCustomer, "Please enter the pull-out no.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddCustomer, "Please enter the customer name.")
                    Exit Try
                End If
            ElseIf cue = "Edit" Then
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgPullOutList.Rows.Count <> 0 Then
                    getOrderStatus(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Me)
                    If globalorderstatus <> txtStatus.Text Then
                        MessageBox.Show("This Return has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If LTrim(cboCustomerName.Text) <> "" Then
                        getCustomerID(cboCustomerName.Text, Me)
                        pocustomerid = globalcustomerid
                        If LTrim(txtPullOutNo.Text) <> "" Then
                            If pocustomerid = 0 Then
                                errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                                Exit Try
                            Else
                                getOrderIDSupA(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), txtPullOutNo.Text, "Return", Me)
                                poorderid = globalorderid
                                If poorderid <> 0 Then
                                    errProvider.SetError(txtPullOutNo, "Return No. has been created already, please type a new one.")
                                    Exit Try
                                End If
                            End If
                        Else
                            errProvider.SetError(pbAddCustomer, "Please enter the customer Return no.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(pbAddCustomer, "Please enter the customer name.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddCustomer, "System cannot find the return to be updated.")
                    Exit Try
                End If
            End If
            myModule.systemerrorfound = False
            If MessageBox.Show("Would you like to save the changes on this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If cue = "New" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    pocustomerid = globalcustomerid
                    getOrderIDSupB(txtPullOutNo.Text, "Return", Me)
                    poorderid = globalorderid
                    If poorderid <> 0 Then
                        errProvider.SetError(txtPullOutNo, "Return No. has been created already, please type a new one.")
                        Exit Try
                    End If
                    M_I_OrdersA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, pocustomerid, txtPullOutNo.Text, "Return", dtpPullOutDate.Value, Now.Date,
                           cboCustomerName.Text, txtComments.Text, txtStatus.Text, Math.Round(poitotalprice, 2), cboDRNo.Text, Me)
                    poorderid = globalorderidsp
                    If dgPullOutItems.Rows.Count <> 0 Then
                        For a = 0 To dgPullOutItems.Rows.Count - 1
                            If myModule.systemerrorfound = False Then
                                If IsNumeric(dgPullOutItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                    If CInt(dgPullOutItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                        getTotalQtyAvailableA(CInt(dgPullOutItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                        M_I_OrderItemsA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, pocustomerid, poorderid, CInt(dgPullOutItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, _
                                            If(IsNumeric(dgPullOutItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgPullOutItems.Rows(a).Cells("ci_qtyordered").Value), 0), globaltotalqtyavailable, "S", _
                                            "" & CStr(dgPullOutItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgPullOutItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgPullOutItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgPullOutItems.Rows(a).Cells("ci_seasoncode").Value) & "", _
                                            CStr(dgPullOutItems.Rows(a).Cells("ci_sku").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgPullOutItems.Rows(a).Cells("ci_srp").Value), CDec(dgPullOutItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", Me)
                                    End If
                                End If
                                If IsNumeric(dgPullOutItems.Rows(a).Cells("ci_bid").Value) Then
                                    If CInt(dgPullOutItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                        M_I_OrderItemsA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, pocustomerid, poorderid, DBNull.Value, CInt(dgPullOutItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgPullOutItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgPullOutItems.Rows(a).Cells("ci_qtyordered").Value), 0), _
                                            0, "S", CStr(dgPullOutItems.Rows(a).Cells("ci_productcode").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_sku").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_remarks").Value), _
                                            If(IsNumeric(dgPullOutItems.Rows(a).Cells("ci_srp").Value), CDec(dgPullOutItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", Me)
                                    End If
                                End If
                            Else
                                Exit Try
                            End If
                        Next
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                    End If
                ElseIf cue = "Edit" Then
                    If dgPullOutList.Rows.Count <> 0 Then
                        getCustomerID(cboCustomerName.Text, Me)
                        pocustomerid = globalcustomerid
                        getOrderIDSupA(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), txtPullOutNo.Text, "Return", Me)
                        poorderid = globalorderid
                        If poorderid <> 0 Then
                            errProvider.SetError(txtPullOutNo, "Return No. has been created already, please type a new one.")
                            Exit Try
                        End If
                        M_U_OrderA(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, pocustomerid, txtPullOutNo.Text, dtpPullOutDate.Value, _
                           Now.Date, txtComments.Text, Math.Round(poitotalprice, 2), Me)
                        If dgPullOutItems.Rows.Count <> 0 Then
                            For a = 0 To dgPullOutItems.Rows.Count - 1
                                If myModule.systemerrorfound = False Then
                                    If IsNumeric(dgPullOutItems.Rows(a).Cells("ci_rowid").Value) Then
                                        If CInt(dgPullOutItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                                            MB_U_OrderItemsA(CInt(dgPullOutItems.Rows(a).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgPullOutItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgPullOutItems.Rows(a).Cells("ci_qtyordered").Value), 0), _
                                                    If(IsNumeric(dgPullOutItems.Rows(a).Cells("ci_srp").Value), CDec(dgPullOutItems.Rows(a).Cells("ci_srp").Value), 0.0), CStr(dgPullOutItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_remarks").Value), Me)
                                        End If
                                    Else
                                        If IsNumeric(dgPullOutItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                            If CInt(dgPullOutItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                                getTotalQtyAvailableA(CInt(dgPullOutItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                M_I_OrderItemsA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, pocustomerid, CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), CInt(dgPullOutItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, _
                                                    If(IsNumeric(dgPullOutItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgPullOutItems.Rows(a).Cells("ci_qtyordered").Value), 0), globaltotalqtyavailable, "S", _
                                                    "" & CStr(dgPullOutItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgPullOutItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgPullOutItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgPullOutItems.Rows(a).Cells("ci_seasoncode").Value) & "", _
                                                    CStr(dgPullOutItems.Rows(a).Cells("ci_sku").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgPullOutItems.Rows(a).Cells("ci_srp").Value), CDec(dgPullOutItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", Me)
                                            End If
                                        End If
                                        If IsNumeric(dgPullOutItems.Rows(a).Cells("ci_bid").Value) Then
                                            If CInt(dgPullOutItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                                M_I_OrderItemsA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, pocustomerid, CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), DBNull.Value, CInt(dgPullOutItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgPullOutItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgPullOutItems.Rows(a).Cells("ci_qtyordered").Value), 0), _
                                                    0, "S", CStr(dgPullOutItems.Rows(a).Cells("ci_productcode").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_sku").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgPullOutItems.Rows(a).Cells("ci_remarks").Value), _
                                                    If(IsNumeric(dgPullOutItems.Rows(a).Cells("ci_srp").Value), CDec(dgPullOutItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", Me)
                                            End If
                                        End If
                                    End If
                                Else
                                    Exit Try
                                End If
                            Next
                        End If
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                        End If
                    End If
                Else
                End If
                If myModule.systemerrorfound = False Then
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
    Private Sub dgPullOutItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPullOutItems.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPullOutItems.Rows.Count <> 0 Then
                If e.ColumnIndex = dgPullOutItems.Columns("ci_option").Index Then

                    If IsNumeric(dgPullOutItems.CurrentRow.Cells("ci_rowid").Value) Then
                        If dgPullOutItems.CurrentRow.Cells("ci_rowid").Value = 0 Then
                            If dgPullOutItems.SelectedRows.Count > 0 Then
                                dgPullOutItems.Rows.Remove(dgPullOutItems.SelectedRows(0))
                            End If
                        Else
                            If dgPullOutList.Rows.Count <> 0 Then
                                getPositionID(Me)
                                If globalpositionid <> 0 Then
                                    getPositionView(globalpositionid, "Returns", Me)
                                    If globaldisableflg = "Y" Then
                                        MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        PrimaryForm.RetForm = False
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
                                getOrderStatus(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Me)
                                If globalorderstatus <> txtStatus.Text Then
                                    MessageBox.Show("This pull-out order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                ElseIf globalorderstatus = "New" Then
                                    If MessageBox.Show("Would you like to delete this item from this list?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        Me.Cursor = Cursors.WaitCursor
                                        getOrderStatus(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Me)
                                        If globalorderstatus <> "New" Then
                                            MessageBox.Show("This pull-out order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Exit Try
                                        End If
                                        getOrderItemInfo(CInt(dgPullOutItems.CurrentRow.Cells("ci_rowid").Value), Me)
                                        getOrderTotalAmount(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Me)
                                        U_OrderTotalAmount(CInt(dgPullOutList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalordertotalamount - Math.Round(globalorderitemsrp * globalorderitemqtyordered, 2), Me)
                                        If myModule.systemerrorfound = False Then
                                            U_OrderItemStatus(CInt(dgPullOutItems.CurrentRow.Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                                        End If
                                        If myModule.systemerrorfound = False Then
                                            If dgPullOutItems.SelectedRows.Count > 0 Then
                                                dgPullOutItems.Rows.Remove(dgPullOutItems.SelectedRows(0))
                                            End If
                                            myBalloon("Successfully Deleted", "Delete", lblsavemsg, -15, -65)
                                        End If
                                    End If
                                Else
                                    MessageBox.Show("This purchase order has been received or cancelled already.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                            End If
                        End If
                    Else
                        If dgPullOutItems.SelectedRows.Count > 0 Then
                            dgPullOutItems.Rows.Remove(dgPullOutItems.SelectedRows(0))
                        End If
                    End If
                    itemno = startingpage
                    For i As Integer = 0 To dgPullOutItems.Rows.Count - 1
                        dgPullOutItems.Rows(i).Cells("ci_seqno").Value = itemno
                        itemno = itemno + 1
                    Next i
                    pulloutitemscomputations()
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
            ElseIf cboSearch1.Text = "CustomerName" Then
                autocompleteCustomerName(cboSearch2)
                autopopulateCustomerName(cboSearch2)
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
            ElseIf cboSearch3.Text = "CustomerName" Then
                autocompleteCustomerName(cboSearch4)
                autopopulateCustomerName(cboSearch4)
            ElseIf cboSearch1.Text = "Status" Then
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
                If cboSearch1.Text = "" And cboSearch3.Text = "" Then
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "DateSearch"
                    spagenum = neutralpage : numofpages = startingpage
                    datephrase = "po.orderdate"
                    displayDateSearch(spagenum, datephrase)
                    pageSetup2(datephrase)
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                ElseIf cboSearch2.Text = "" And cboSearch4.Text = "" Then
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "DateSearch"
                    spagenum = neutralpage : numofpages = startingpage
                    datephrase = "po.orderdate"
                    displayDateSearch(spagenum, datephrase)
                    pageSetup2(datephrase)
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
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
                    pagefilter4 = " AND (po.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " & _
                            "po.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                    spagenum = neutralpage : numofpages = startingpage
                    displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
                    pageSetup3(pagefilter3, pagefilter4)
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
                If cboSearch1.Text = "" And cboSearch3.Text = "" Then
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "DateSearch"
                    spagenum = neutralpage : numofpages = startingpage
                    datephrase = "po.orderdate"
                    displayDateSearch(spagenum, datephrase)
                    pageSetup2(datephrase)
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                ElseIf cboSearch2.Text = "" And cboSearch4.Text = "" Then
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "DateSearch"
                    spagenum = neutralpage : numofpages = startingpage
                    datephrase = "po.orderdate"
                    displayDateSearch(spagenum, datephrase)
                    pageSetup2(datephrase)
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
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
                    pagefilter4 = " AND (po.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " & _
                            "po.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                    spagenum = neutralpage : numofpages = startingpage
                    displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
                    pageSetup3(pagefilter3, pagefilter4)
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
                displayPullOutList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
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
                displayPullOutList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
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
                displayPullOutList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
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
                displayPullOutList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
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
                            displayPullOutList(spagenum)
                        ElseIf searchmode = "CommonSearch" Then
                            displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
                        ElseIf searchmode = "SimpleSearch" Then
                            displaySearchPhrase(simplesearchphrase, spagenum)
                        ElseIf searchmode = "DateSearch" Then
                            displayDateSearch(spagenum, datephrase)
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
#Region "Datagrid MouseUp"
    Private Sub dgProductColorSizes_MouseUp(sender As Object, e As MouseEventArgs) Handles dgProductColorSizes.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgProductColorSizes.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgProductColorSizes.BeginEdit(True)
                Else
                    dgProductColorSizes.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
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
    Private Sub dgPullOutItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgPullOutItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgPullOutItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgPullOutItems.BeginEdit(True)
                Else
                    dgPullOutItems.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Datagrid Errors"
    Private Sub dgPullOutList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgPullOutList.DataError
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
                dgPullOutList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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
    Private Sub dgPullOutItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgPullOutItems.DataError
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
                dgPullOutItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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