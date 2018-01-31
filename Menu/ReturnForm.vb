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
Public Class ReturnForm
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
    Dim simplesearchphrase, datephrase, commonphrase, pagefilter1, pagefilter2, pagefilter3, pagefilter4 As String
    Dim poorderno As String
    Dim pocustomerid, poorderid, poproductcolorsizesid, poproductid, poproductbundleid As Integer
    Dim pooverallsrp, pototalsrp, poitotalprice As Decimal
    Dim pototalgoodqty, pototalbadqty, pogoodqty, pobadqty, poitotalgoodqty, poitotalbadqty, poigoodqty, poibadqty As Integer

    Public creates As Char = ""
    Public updates As Char = ""
    Public disable As Char = ""
    Public reads As Char = ""
    Private Sub ReturnForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            displayReturnOrderList(spagenum)
            callAutoComplete()
            callAutoPopulate()
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
            UserRights(Z_PositionID, "Return", creates, updates, disable, reads, Me)
            If reads = "Y" Then
                enableGB(legit, fraud, fraud)
                enableANDvisibleMS(fraud, fraud, fraud, fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ReturnForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearReturnOrderInformation()
            clearAddProductA()
            clearAddProductB()
            clearReturnOrderItems()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visibleReturnOrderItems(fraud)
            visibleGB(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud)
            If reads = "Y" Then
                enableGB(legit, fraud, fraud)
                enableANDvisibleMS(fraud, fraud, fraud, fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearRightPage()
        Try
            cue = ""
            clearReturnOrderInformation()
            clearAddProductA()
            clearAddProductB()
            clearReturnOrderItems()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visibleReturnOrderItems(fraud)
            visibleGB(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud)
            If reads = "Y" Then
                enableGB(legit, fraud, fraud)
                enableANDvisibleMS(fraud, fraud, fraud, fraud)
            End If
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
            cboSearch3.Text = ""
            cboSearch4.Text = ""
            cboDate.SelectedItem = Nothing
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
            cboDate.SelectedItem = Nothing
            cboSearch1.SelectedItem = Nothing
            cboSearch2.SelectedItem = Nothing
            cboSearch3.Items.Clear() : cboSearch3.AutoCompleteCustomSource.Clear()
            cboSearch3.Text = "" : cboSearch3.SelectedItem = Nothing
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
    Sub clearReturnOrderInformation()
        Try
            txtReturnOrderNo.Text = ""
            cboCustomerName.Text = ""
            txtStatus.Text = ""
            txtComments.Text = ""
            txtDRNos.Text = ""
            dtpReturnOrderDate.Value = Now.Date
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearAddProductA()
        Try
            cboBy.Text = ""
            cboByPhrase.Text = ""
            txtGoodQty.Text = ""
            TxtBadQty.Text = ""
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
            txtBundleSRP.Text = ""
            txtOverallQty.Text = ""
            txtOverallPrice.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearReturnOrderItems()
        Try
            chkOtherInfo.Checked = fraud
            txtTotalItems.Text = ""
            txtTotalGoodQty.Text = ""
            TxtTotalBadQty.Text = ""
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
            dgReturnOrderItems.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbReturnOrderList.Enabled = enable1
            gbReturnOrderInformation.Enabled = enable2
            gbReturnOrderItems.Enabled = enable2
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
    Sub visibleReturnOrderItems(ByVal visible1 As Boolean)
        Try
            ci_unitofmeasure.Visible = visible1
            ci_remarks.Visible = visible1
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
            lblSRP.Visible = visible3
            'txtBundleSRP.Visible = visible3
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
            displayReturnOrderList(spagenum)
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
                    If Not IsNumeric(txtGoodQty.Text) Then
                        errProvider.SetError(txtGoodQty, "Please use numbers for good qty.")
                        txtGoodQty.Focus()
                        Exit Try
                    End If
                    If Not IsNumeric(TxtBadQty.Text) Then
                        errProvider.SetError(TxtBadQty, "Please use numbers for bad qty.")
                        TxtBadQty.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the combination code.")
                        cboByPhrase.Focus()
                    Else
                        checkReturnOrderItemsA()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    If dgProductSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the sizes.")
                        cboByPhrase.Focus()
                    Else
                        checkReturnOrderItemsB()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    If Not IsNumeric(txtGoodQty.Text) Then
                        errProvider.SetError(txtGoodQty, "Please use numbers for good qty.")
                        txtGoodQty.Focus()
                        Exit Try
                    End If
                    If Not IsNumeric(TxtBadQty.Text) Then
                        errProvider.SetError(TxtBadQty, "Please use numbers for bad qty.")
                        TxtBadQty.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the sku.")
                        cboByPhrase.Focus()
                    Else
                        If dgProductColorSizes.Rows.Count <> 0 Then
                            checkReturnOrderItemsA()
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
            pototalgoodqty = 0 : pototalbadqty = 0 : pogoodqty = 0 : pooverallsrp = 0.0 : pototalsrp = 0.0
            If IsNumeric(txtGoodQty.Text) Then
                pogoodqty = CInt(txtGoodQty.Text)
            Else
                pogoodqty = 0
            End If
            If IsNumeric(TxtBadQty.Text) Then
                pobadqty = CInt(TxtBadQty.Text)
            Else
                pobadqty = 0
            End If
            If dgProductColorSizes.Visible = legit Then
                If dgProductColorSizes.Rows.Count <> 0 Then
                    For i = 0 To dgProductColorSizes.Rows.Count - 1
                        If IsNumeric(dgProductColorSizes.Rows(i).Cells("pcs_srp").Value) Then
                            pototalsrp = pototalsrp + CDec(dgProductColorSizes.Rows(i).Cells("pcs_srp").Value)
                        End If
                    Next
                End If
                pooverallsrp = pototalsrp * pogoodqty
            ElseIf dgProductSizes.Visible = legit Then
                If dgProductSizes.Rows.Count <> 0 Then
                    For i = 0 To dgProductSizes.Rows.Count - 1
                        If IsNumeric(dgProductSizes.Rows(i).Cells("s_goodqty").Value) Then
                            pogoodqty = CInt(dgProductSizes.Rows(i).Cells("s_goodqty").Value)
                            pototalgoodqty = pototalgoodqty + CInt(dgProductSizes.Rows(i).Cells("s_goodqty").Value)
                        Else
                            pogoodqty = 0
                        End If
                        If IsNumeric(dgProductSizes.Rows(i).Cells("s_badqty").Value) Then
                            pobadqty = CInt(dgProductSizes.Rows(i).Cells("s_badqty").Value)
                            pototalbadqty = pototalbadqty + CInt(dgProductSizes.Rows(i).Cells("s_badqty").Value)
                        Else
                            pobadqty = 0
                        End If
                        If IsNumeric(dgProductSizes.Rows(i).Cells("s_srp").Value) Then
                            dgProductSizes.Rows(i).Cells("s_totalprice").Value = pogoodqty * CDec(dgProductSizes.Rows(i).Cells("s_srp").Value)
                        Else
                            dgProductSizes.Rows(i).Cells("s_totalprice").Value = 0.0
                        End If
                        If IsNumeric(dgProductSizes.Rows(i).Cells("s_totalprice").Value) Then
                            pooverallsrp = pooverallsrp + CDec(dgProductSizes.Rows(i).Cells("s_totalprice").Value)
                        End If
                    Next
                End If
            End If
            txtOverallQty.Text = Format(pototalgoodqty, "#,##0")
            txtOverallPrice.Text = Format(pooverallsrp, "#,##0.00")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub ReturnOrderitemscomputations()
        Try
            poitotalgoodqty = 0 : poitotalbadqty = 0 : poigoodqty = 0 : poibadqty = 0 : poitotalprice = 0.0
            If dgReturnOrderItems.Rows.Count <> 0 Then
                For i = 0 To dgReturnOrderItems.Rows.Count - 1
                    If IsNumeric(dgReturnOrderItems.Rows(i).Cells("ci_goodqty").Value) Then
                        poigoodqty = CInt(dgReturnOrderItems.Rows(i).Cells("ci_goodqty").Value)
                        poitotalgoodqty = poitotalgoodqty + CInt(dgReturnOrderItems.Rows(i).Cells("ci_goodqty").Value)
                    Else
                        poigoodqty = 0
                    End If
                    If IsNumeric(dgReturnOrderItems.Rows(i).Cells("ci_badqty").Value) Then
                        poibadqty = CInt(dgReturnOrderItems.Rows(i).Cells("ci_badqty").Value)
                        poitotalbadqty = poitotalbadqty + CInt(dgReturnOrderItems.Rows(i).Cells("ci_badqty").Value)
                    Else
                        poibadqty = 0
                    End If
                    If IsNumeric(dgReturnOrderItems.Rows(i).Cells("ci_srp").Value) Then
                        dgReturnOrderItems.Rows(i).Cells("ci_totalprice").Value = Math.Round(poigoodqty * CDec(dgReturnOrderItems.Rows(i).Cells("ci_srp").Value), 2)
                    Else
                        dgReturnOrderItems.Rows(i).Cells("ci_totalprice").Value = 0.0
                    End If
                    If IsNumeric(dgReturnOrderItems.Rows(i).Cells("ci_totalprice").Value) Then
                        poitotalprice = poitotalprice + CDec(dgReturnOrderItems.Rows(i).Cells("ci_totalprice").Value)
                    End If
                Next
            End If
            txtTotalItems.Text = dgReturnOrderItems.Rows.Count
            txtTotalGoodQty.Text = Format(poitotalgoodqty, "#,##0")
            TxtTotalBadQty.Text = Format(poitotalbadqty, "#,##0")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' " & _
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' AND " & _
                            "(" & edatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " & _
                            "" & edatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) GROUP BY po.rowid ")
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
            cboDate.Items.Clear()
            cboDate.Items.Add("OrderDate")
            cboDate.Items.Add("TargetDate")
            cboDate.Items.Add("")
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
#End Region
#Region "Datagrids"
    Sub displayReturnOrderList(ByVal istartpage As Integer)
        Try
            dgReturnOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," & _
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' " & _
                        "ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgReturnOrderList.Rows.Add()
                    dgReturnOrderList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgReturnOrderList.Item(so_returnorderno.Index, n).Value = reader1(1)
                    dgReturnOrderList.Item(so_returnorderdate.Index, n).Value = reader1(2)
                    dgReturnOrderList.Item(so_customername.Index, n).Value = reader1(3)
                    dgReturnOrderList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReturnOrderList.Columns("so_returnorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderList.Columns("so_returnorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReturnOrderList.Rows.Count <> 0 Then
                dgReturnOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgReturnOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," & _
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' AND " & _
                        "(po.ordernumber LIKE '%" & isearchphrase & "%' OR po.status LIKE '%" & isearchphrase & "%' OR cu.companyname LIKE '%" & isearchphrase & "%') " & _
                        "ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgReturnOrderList.Rows.Add()
                    dgReturnOrderList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgReturnOrderList.Item(so_returnorderno.Index, n).Value = reader1(1)
                    dgReturnOrderList.Item(so_returnorderdate.Index, n).Value = reader1(2)
                    dgReturnOrderList.Item(so_customername.Index, n).Value = reader1(3)
                    dgReturnOrderList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReturnOrderList.Columns("so_returnorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderList.Columns("so_returnorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReturnOrderList.Rows.Count <> 0 Then
                dgReturnOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayDateSearch(ByVal istartpage As Integer, ByVal idatesearch As String)
        Try
            dgReturnOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," & _
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' AND " & _
                        "(" & idatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " & _
                        "" & idatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) " & _
                        "GROUP BY po.rowid ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgReturnOrderList.Rows.Add()
                    dgReturnOrderList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgReturnOrderList.Item(so_returnorderno.Index, n).Value = reader1(1)
                    dgReturnOrderList.Item(so_returnorderdate.Index, n).Value = reader1(2)
                    dgReturnOrderList.Item(so_customername.Index, n).Value = reader1(3)
                    dgReturnOrderList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReturnOrderList.Columns("so_returnorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderList.Columns("so_returnorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReturnOrderList.Rows.Count <> 0 Then
                dgReturnOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal idatesearch As String, ByVal istartpage As Integer)
        Try
            dgReturnOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," & _
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' " & _
                        "AND " & icommonphrase & " " & idatesearch & " ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgReturnOrderList.Rows.Add()
                    dgReturnOrderList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgReturnOrderList.Item(so_returnorderno.Index, n).Value = reader1(1)
                    dgReturnOrderList.Item(so_returnorderdate.Index, n).Value = reader1(2)
                    dgReturnOrderList.Item(so_customername.Index, n).Value = reader1(3)
                    dgReturnOrderList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReturnOrderList.Columns("so_returnorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderList.Columns("so_returnorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReturnOrderList.Rows.Count <> 0 Then
                dgReturnOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayReturnOrderInformation(ByVal iReturnid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),DATE_FORMAT(po.targetdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," & _
                        "COALESCE(po.comments,''),COALESCE(po.status,''), COALESCE(rr.OrderNumber,0) FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid LEFT JOIN orders rr ON rr.RelatedOrderID = po.RowID WHERE po.rowid = " & iReturnid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtReturnOrderNo.Text = reader1(0)
                    dtpReturnOrderDate.Text = reader1(1)
                    cboCustomerName.Text = reader1(3)
                    txtComments.Text = reader1(4)
                    txtStatus.Text = reader1(5)
                    txtDRNos.Text = reader1(6)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub
    Sub displayReturnOrderItems(ByVal iReturnid As Integer)
        Try
            dgReturnOrderItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(ci.productbundleid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(b.bundlename,''),COALESCE(c.colorname,''),COALESCE(pcs.size,'')," & _
                    "COALESCE(pcs.seasoncode,''),COALESCE(ci.unitofmeasure,''),COALESCE(ci.qtyordered,0),COALESCE(ci.srp,0.0),COALESCE(pcs.sku,''),COALESCE(b.sku,''),COALESCE(ci.itemtype,''),COALESCE(ci.remarks,''),COALESCE(ci.qtydamaged,0),COALESCE(ci.reasons,'') FROM orderitems ci " & _
                    "LEFT JOIN productbundles b ON ci.productbundleid = b.rowid LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
                    "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE ci.orderid = " & iReturnid & " AND ci.organizationid = " & Z_OrganizationID & " " & _
                    "AND ci.status != 'Inactive' AND ci.itemtype != 'BI' ORDER BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgReturnOrderItems.Rows.Add()
                    dgReturnOrderItems.Item(ci_seqno.Index, n).Value = seqno
                    dgReturnOrderItems.Item(ci_rowid.Index, n).Value = reader1(0)
                    dgReturnOrderItems.Item(ci_pcsrowid.Index, n).Value = reader1(1)
                    dgReturnOrderItems.Item(ci_bid.Index, n).Value = reader1(2)
                    dgReturnOrderItems.Item(ci_colorvalue.Index, n).Value = reader1(3)
                    If CInt(reader1(1)) <> 0 Then
                        dgReturnOrderItems.Item(ci_productcode.Index, n).Value = reader1(4)
                    Else
                        dgReturnOrderItems.Item(ci_productcode.Index, n).Value = reader1(5)
                    End If
                    dgReturnOrderItems.Item(ci_colorname.Index, n).Value = reader1(6)
                    dgReturnOrderItems.Item(ci_size.Index, n).Value = reader1(7)
                    dgReturnOrderItems.Item(ci_seasoncode.Index, n).Value = reader1(8)
                    dgReturnOrderItems.Item(ci_unitofmeasure.Index, n).Value = reader1(9)
                    dgReturnOrderItems.Item(ci_goodqty.Index, n).Value = reader1(10)
                    dgReturnOrderItems.Item(ci_srp.Index, n).Value = reader1(11)
                    If CInt(reader1(1)) <> 0 Then
                        dgReturnOrderItems.Item(ci_sku.Index, n).Value = reader1(12)
                    Else
                        dgReturnOrderItems.Item(ci_sku.Index, n).Value = reader1(13)
                    End If
                    dgReturnOrderItems.Item(ci_remarks.Index, n).Value = reader1(15)
                    dgReturnOrderItems.Item(ci_badqty.Index, n).Value = reader1(16)
                    dgReturnOrderItems.Item(ci_reasons.Index, n).Value = reader1(17)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReturnOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_goodqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_badqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_reasons").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReturnOrderItems.Rows.Count <> 0 Then
                dgReturnOrderItems.CurrentRow.Selected = False
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
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,''),COALESCE(p.unitprice,0.00) " & _
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
                    getTotalQtyReserveA(CInt(reader1(0)), Me)
                    'dgProductColorSizes.Item(pcs_qtyreserve.Index, n).Value = globaltotalqtyreserve
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductColorSizes.Columns("pcs_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'dgProductColorSizes.Columns("pcs_qtyreserve").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(pcs.size,0.0),COALESCE(pcs.seasoncode,''),COALESCE(p.unitprice,0.00),COALESCE(pcs.sku,'') FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
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
                    dgProductSizes.Item(s_goodqty.Index, n).Value = 0
                    dgProductSizes.Item(s_srp.Index, n).Value = reader1(3)
                    dgProductSizes.Item(s_totalprice.Index, n).Value = ""
                    dgProductSizes.Item(s_sku.Index, n).Value = reader1(4)
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    dgProductSizes.Item(s_badqty.Index, n).Value = 0
                    getTotalQtyReserveA(CInt(reader1(0)), Me)
                    'dgProductSizes.Item(s_qtyreserve.Index, n).Value = globaltotalqtyreserve
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductSizes.Columns("s_sizes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_goodqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_badqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'dgProductSizes.Columns("s_qtyreserve").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            If dgReturnOrderItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgReturnOrderItems.Rows.Count - 1
                    'If dgPullOutItems.Rows(i).Cells(ci_type.Index).Value = "B" Then
                    '    dgPullOutItems.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
                    'Else
                    If CStr(dgReturnOrderItems.Rows(i).Cells("ci_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgReturnOrderItems.Rows(i).Cells("ci_colorvalue").Value))
                        dgReturnOrderItems.Rows(i).Cells("ci_color").Style.BackColor = readcolor
                    End If
                    'End If
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
    Sub checkReturnOrderItemsA()
        Try
            If dgProductColorSizes.Rows.Count <> 0 Then

                For p = 0 To dgProductColorSizes.Rows.Count - 1
                    If dgReturnOrderItems.Rows.Count <> 0 Then
                        rowscount = dgReturnOrderItems.Rows.Count - 1
                        For i = 0 To dgReturnOrderItems.Rows.Count - 1
                            If dgReturnOrderItems.Rows(i).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                errProvider.SetError(cboByPhrase, "Product is in the list already.")
                                cboByPhrase.Focus()
                                Exit Try
                            ElseIf rowscount = 0 Then
                                addReturOrderItemA(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CInt(txtGoodQty.Text), CInt(TxtBadQty.Text), If(IsNumeric(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), CDec(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), 0.0))
                                For a = 0 To dgReturnOrderItems.Rows.Count - 1
                                    dgReturnOrderItems.CurrentRow.Selected = fraud
                                    If dgReturnOrderItems.Rows(a).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                        dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Selected = legit
                                        dgReturnOrderItems.FirstDisplayedScrollingRowIndex = dgReturnOrderItems.RowCount - 1
                                        Exit For
                                    End If
                                Next
                                cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtGoodQty.Text = "" : TxtBadQty.Text = "" : cboByPhrase.Focus()
                            End If
                            rowscount = rowscount - 1
                        Next
                    Else
                        addReturOrderItemA(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CInt(txtGoodQty.Text), CInt(TxtBadQty.Text), If(IsNumeric(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), CDec(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), 0.0))
                        For a = 0 To dgReturnOrderItems.Rows.Count - 1
                            dgReturnOrderItems.CurrentRow.Selected = fraud
                            If dgReturnOrderItems.Rows(a).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Selected = legit
                                dgReturnOrderItems.FirstDisplayedScrollingRowIndex = dgReturnOrderItems.RowCount - 1
                                Exit For
                            End If
                        Next
                        cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtGoodQty.Text = "" : TxtBadQty.Text = "" : cboByPhrase.Focus()
                    End If
                Next
                itemno = 1 : colorCoding() : addproductcomputations() : ReturnOrderitemscomputations()
                For i As Integer = 0 To dgReturnOrderItems.Rows.Count - 1
                    dgReturnOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub checkReturnOrderItemsB()
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                For p = 0 To dgProductSizes.Rows.Count - 1
                    If IsNumeric(dgProductSizes.Rows(p).Cells("s_goodqty").Value) Then
                        If CInt(dgProductSizes.Rows(p).Cells("s_goodqty").Value) > 0 Then
                            If dgReturnOrderItems.Rows.Count <> 0 Then
                                rowscount = dgReturnOrderItems.Rows.Count - 1
                                For i = 0 To dgReturnOrderItems.Rows.Count - 1
                                    If dgReturnOrderItems.Rows(i).Cells("ci_pcsrowid").Value = dgProductSizes.Rows(p).Cells("s_rowid").Value Then
                                        Exit For
                                    ElseIf rowscount = 0 Then
                                        addReturOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CInt(dgProductSizes.Rows(p).Cells("s_goodqty").Value), CInt(dgProductSizes.Rows(p).Cells("s_badqty").Value), If(IsNumeric(dgProductSizes.Rows(p).Cells("s_srp").Value), CDec(dgProductSizes.Rows(p).Cells("s_srp").Value), 0.0))
                                    End If
                                    rowscount = rowscount - 1
                                Next
                            Else
                                addReturOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CInt(dgProductSizes.Rows(p).Cells("s_goodqty").Value), CInt(dgProductSizes.Rows(p).Cells("s_badqty").Value), If(IsNumeric(dgProductSizes.Rows(p).Cells("s_srp").Value), CDec(dgProductSizes.Rows(p).Cells("s_srp").Value), 0.0))
                            End If
                        End If
                    End If
                Next
                itemno = 1 : colorCoding() : addproductcomputations() : ReturnOrderitemscomputations()
                For i As Integer = 0 To dgReturnOrderItems.Rows.Count - 1
                    dgReturnOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
                If dgReturnOrderItems.Rows.Count <> 0 Then
                    dgReturnOrderItems.CurrentRow.Selected = False
                    dgReturnOrderItems.FirstDisplayedScrollingRowIndex = dgReturnOrderItems.RowCount - 1
                End If
                cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtGoodQty.Text = "" : TxtBadQty.Text = "" : cboByPhrase.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub addReturOrderItemA(ByVal iproductcolorsizeid As Integer, ByVal igoodqty As Integer, ByVal ibadqty As Integer, ByVal isrp As Decimal)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(p.unitofmeasure,''),COALESCE(pcs.sku,''),COALESCE(pcs.seasoncode,'') " & _
                "FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.rowid = " & iproductcolorsizeid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    dgReturnOrderItems.Rows.Add()
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_rowid").Value = ""
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_bid").Value = neutralpage
                    'dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_type").Value = "S"
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_remarks").Value = ""
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = reader1(0)
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_colorvalue").Value = reader1(1)
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_productcode").Value = reader1(2)
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_colorname").Value = reader1(3)
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_size").Value = reader1(4)
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = reader1(5)
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_goodqty").Value = igoodqty
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_badqty").Value = ibadqty
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_srp").Value = isrp
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_sku").Value = reader1(6)
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_seasoncode").Value = reader1(7)
                End If
            End While
            reader1.Close()
            dgReturnOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_goodqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'dgPullOutItems.Columns("ci_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_badqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub addReturnOrdertItemB(ByVal iproductbundleid As Integer, ByVal iqtyordered As Integer, ByVal isrp As Decimal)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT b.rowid,COALESCE(b.bundlename,''),COALESCE(b.unitofmeasure,''),COALESCE(b.sku,'') FROM productbundles b WHERE b.rowid = " & iproductbundleid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    dgReturnOrderItems.Rows.Add()
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_rowid").Value = ""
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = neutralpage
                    'dgPullOutItems.Rows(dgPullOutItems.Rows.Count - 1).Cells("ci_type").Value = "B"
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_remarks").Value = ""
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_colorvalue").Value = ""
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_colorname").Value = ""
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_size").Value = ""
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_seasoncode").Value = ""
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_bid").Value = reader1(0)
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_productcode").Value = reader1(1)
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = reader1(2)
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_goodqty").Value = iqtyordered
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_srp").Value = isrp
                    dgReturnOrderItems.Rows(dgReturnOrderItems.Rows.Count - 1).Cells("ci_sku").Value = reader1(3)
                End If
            End While
            reader1.Close()
            dgReturnOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_goodqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'dgPullOutItems.Columns("ci_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturnOrderItems.Columns("ci_badqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
    Private Sub txtComments_Leave(sender As Object, e As EventArgs) Handles txtComments.Leave
        Try
            txtReturnOrderNo.Focus()
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
            If creates = "N" Then
                MessageBox.Show("You are not allowed to create new record. Please check your user rights.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            End If
            cue = "New"
            errProvider.Clear()
            clearReturnOrderInformation()
            clearAddProductA()
            clearAddProductB()
            clearReturnOrderItems()
            clearDatagrids()
            enableGB(fraud, legit, legit)
            visibleReturnOrderItems(fraud)
            visibleGB(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(fraud, legit, legit, fraud)
            getOrderNo("Return", Me)
            txtReturnOrderNo.Text = CStr(globalorderno)
            txtStatus.Text = "New"
            txtReturnOrderNo.Focus()
            If dgReturnOrderList.Rows.Count <> 0 Then
                dgReturnOrderList.CurrentRow.Selected = False
            End If
            UserRights(Z_PositionID, "Return", creates, updates, disable, reads, Me)
            If reads = "Y" Then
                enableGB(legit, fraud, fraud)
                enableANDvisibleMS(fraud, fraud, fraud, fraud)
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
            If dgReturnOrderList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearReturnOrderInformation()
                clearAddProductA()
                clearAddProductB()
                clearReturnOrderItems()
                clearDatagrids()
                visibleReturnOrderItems(fraud)
                visibleGB(fraud, fraud, fraud, fraud, fraud)
                dgReturnOrderList.CurrentRow.Selected = True
                displayReturnOrderInformation(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value))
                displayReturnOrderItems(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value))
                ReturnOrderitemscomputations() : colorCoding()
                If txtStatus.Text = "New" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Received" Then
                    enableGB(legit, fraud, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                End If
                txtReturnOrderNo.Focus()
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
    Private Sub dgReturnOrderList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReturnOrderList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            UserRights(Z_PositionID, "Return", creates, updates, disable, reads, Me)
            If dgReturnOrderList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearReturnOrderInformation()
                clearAddProductA()
                clearAddProductB()
                clearReturnOrderItems()
                clearDatagrids()
                visibleReturnOrderItems(fraud)
                visibleGB(fraud, fraud, fraud, fraud, fraud)
                displayReturnOrderInformation(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value))
                displayReturnOrderItems(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value))
                ReturnOrderitemscomputations() : colorCoding()
                If txtStatus.Text = "New" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Received" Then
                    enableGB(legit, fraud, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                End If
                txtReturnOrderNo.Focus()
                If reads = "Y" Then
                    enableGB(legit, fraud, fraud)
                    enableANDvisibleMS(fraud, fraud, fraud, fraud)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgReturnOrderList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgReturnOrderList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgReturnOrderList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearReturnOrderInformation()
                    clearAddProductA()
                    clearAddProductB()
                    clearReturnOrderItems()
                    clearDatagrids()
                    visibleReturnOrderItems(fraud)
                    visibleGB(fraud, fraud, fraud, fraud, fraud)
                    displayReturnOrderInformation(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value))
                    displayReturnOrderItems(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value))
                    ReturnOrderitemscomputations() : colorCoding()
                    If txtStatus.Text = "New" Then
                        enableGB(legit, legit, legit)
                        enableANDvisibleMS(legit, legit, fraud, legit)
                        msOrder.Text = "Cancel Order"
                    ElseIf txtStatus.Text = "Received" Then
                        enableGB(legit, fraud, fraud)
                        enableANDvisibleMS(legit, fraud, fraud, fraud)
                    ElseIf txtStatus.Text = "Cancelled" Then
                        enableGB(legit, legit, fraud)
                        enableANDvisibleMS(legit, fraud, fraud, legit)
                        msOrder.Text = "Re-Open Order"
                    Else
                        enableGB(legit, legit, fraud)
                        enableANDvisibleMS(legit, fraud, fraud, fraud)
                    End If
                    txtReturnOrderNo.Focus()
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
                visibleReturnOrderItems(legit)
            Else
                visibleReturnOrderItems(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtReturnOrderNo_TextChanged(sender As Object, e As EventArgs) Handles txtReturnOrderNo.TextChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                If LTrim(cboCustomerName.Text) <> "" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    pocustomerid = globalcustomerid
                    If LTrim(txtReturnOrderNo.Text) <> "" Then
                        If pocustomerid = 0 Then
                            errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                        Else
                            getOrderIDSupB(txtReturnOrderNo.Text, "Return", Me)
                            poorderid = globalorderid
                            If poorderid <> 0 Then
                                errProvider.SetError(txtReturnOrderNo, "Return no. and customer name has been created already, please type a new one.")
                            End If
                        End If
                    End If
                End If
            ElseIf cue = "Edit" Then
                If dgReturnOrderList.Rows.Count <> 0 Then
                    If LTrim(cboCustomerName.Text) <> "" Then
                        getCustomerID(cboCustomerName.Text, Me)
                        pocustomerid = globalcustomerid
                        If LTrim(txtReturnOrderNo.Text) <> "" Then
                            If pocustomerid = 0 Then
                                errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                            Else
                                getOrderIDSupA(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), txtReturnOrderNo.Text, "Return", Me)
                                poorderid = globalorderid
                                If poorderid <> 0 Then
                                    errProvider.SetError(txtReturnOrderNo, "Return no. and customer name been created already, please type a new one.")
                                End If
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
    Private Sub cboCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomerName.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                If LTrim(cboCustomerName.Text) <> "" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    pocustomerid = globalcustomerid
                    If LTrim(txtReturnOrderNo.Text) <> "" Then
                        If pocustomerid = 0 Then
                            errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                        Else
                            getOrderIDSupB(txtReturnOrderNo.Text, "Return", Me)
                            poorderid = globalorderid
                            If poorderid <> 0 Then
                                errProvider.SetError(txtReturnOrderNo, "Return no. and customer name has been created already, please type a new one.")
                            End If
                        End If
                    End If
                End If
            ElseIf cue = "Edit" Then
                If dgReturnOrderList.Rows.Count <> 0 Then
                    If LTrim(cboCustomerName.Text) <> "" Then
                        getCustomerID(cboCustomerName.Text, Me)
                        pocustomerid = globalcustomerid
                        If LTrim(txtReturnOrderNo.Text) <> "" Then
                            If pocustomerid = 0 Then
                                errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                            Else
                                getOrderIDSupA(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), txtReturnOrderNo.Text, "Return", Me)
                                poorderid = globalorderid
                                If poorderid <> 0 Then
                                    errProvider.SetError(txtReturnOrderNo, "Return no. and customer name been created already, please type a new one.")
                                End If
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
    Private Sub cboCustomerName_TextChanged(sender As Object, e As EventArgs) Handles cboCustomerName.TextChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                If LTrim(cboCustomerName.Text) <> "" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    pocustomerid = globalcustomerid
                    If LTrim(txtReturnOrderNo.Text) <> "" Then
                        If pocustomerid = 0 Then
                            errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                        Else
                            getOrderIDSupB(txtReturnOrderNo.Text, "Return", Me)
                            poorderid = globalorderid
                            If poorderid <> 0 Then
                                errProvider.SetError(txtReturnOrderNo, "Return no. and customer name has been created already, please type a new one.")
                            End If
                        End If
                    End If
                End If
            ElseIf cue = "Edit" Then
                If dgReturnOrderList.Rows.Count <> 0 Then
                    If LTrim(cboCustomerName.Text) <> "" Then
                        getCustomerID(cboCustomerName.Text, Me)
                        pocustomerid = globalcustomerid
                        If LTrim(txtReturnOrderNo.Text) <> "" Then
                            If pocustomerid = 0 Then
                                errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                            Else
                                getOrderIDSupA(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), txtReturnOrderNo.Text, "Return", Me)
                                poorderid = globalorderid
                                If poorderid <> 0 Then
                                    errProvider.SetError(txtReturnOrderNo, "Return no. and customer name been created already, please type a new one.")
                                End If
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
    Private Sub cboBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBy.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            txtGoodQty.Text = ""
            TxtBadQty.Text = ""
            txtBundleSRP.Text = ""
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
                visibleGB(fraud, fraud, fraud, fraud, fraud)
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
    Private Sub cboByPhrase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboByPhrase.SelectedIndexChanged
        Try
            errProvider.Clear()
            If cboByPhrase.Text <> "" Then
                If cboBy.Text = "" Then
                    txtBundleSRP.Text = ""
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
                    Else
                        getProductBundleSKUA(cboByPhrase.Text, Me)
                        poproductbundleid = globalskuid
                    End If
                End If
            Else
                txtBundleSRP.Text = ""
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
    End Sub
    Private Sub cboByPhrase_TextChanged(sender As Object, e As EventArgs) Handles cboByPhrase.TextChanged
        Try
            errProvider.Clear()
            If cboByPhrase.Text <> "" Then
                If cboBy.Text = "" Then
                    txtBundleSRP.Text = ""
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
                    Else
                        getProductBundleSKUA(cboByPhrase.Text, Me)
                    End If
                End If
            Else
                txtBundleSRP.Text = ""
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
    End Sub
    Private Sub txtGoodQty_TextChanged(sender As Object, e As EventArgs) Handles txtGoodQty.TextChanged
        Try
            addproductcomputations()
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub txtBadQty_TextChanged(sender As Object, e As EventArgs) Handles TxtBadQty.TextChanged
        Try
            addproductcomputations()
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub txtBundleSRP_TextChanged(sender As Object, e As EventArgs) Handles txtBundleSRP.TextChanged
        Try
            addproductcomputations()
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
    Private Sub txtGoodQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGoodQty.KeyDown
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
    Private Sub txtBadQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtBadQty.KeyDown
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
    Private Sub pbAddCustomer_Click(sender As Object, e As EventArgs) Handles pbAddCustomer.Click
        Try
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
    End Sub
    Private Sub dgReturnOrderItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgReturnOrderItems.CellEndEdit
        Try
            ReturnOrderitemscomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgReturnOrderItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReturnOrderItems.CellClick
        Try
            If dgReturnOrderItems.Rows.Count <> 0 Then
                If cue = "Edit" Then
                    If dgReturnOrderList.Rows.Count <> 0 Then
                        getOrderStatus(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub msOrder_Click(sender As Object, e As EventArgs) Handles msOrder.Click
        Try
            myModule.systemerrorfound = False
            If dgReturnOrderList.Rows.Count <> 0 Then

                getOrderStatus(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                If globalorderstatus <> txtStatus.Text Then
                    MessageBox.Show("This Return no. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                ElseIf globalorderstatus = "New" Then
                    If MessageBox.Show("Would you like to cancel this order?", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgReturnOrderList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This Return no. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        U_OrderStatus(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Cancelled", "Cancel", lblsavemsg, -15, -65)
                            tsrefreshperformclick()
                        End If
                    End If
                ElseIf globalorderstatus = "Cancelled" Then
                    If MessageBox.Show("Would you like to re-open this order?", "Opening", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgReturnOrderList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This Return no. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        U_OrderStatus(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "New", Me)
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
        Try
            errProvider.Clear()
            ReturnOrderitemscomputations()
            dgReturnOrderItems.CommitEdit(legit) : dgReturnOrderItems.ClearSelection() : dgReturnOrderItems.CurrentCell = Nothing
            If cue = "New" Then
                If creates = "N" Then
                    MessageBox.Show("You are not allowed to create new record. Please check your user rights.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If
                If LTrim(cboCustomerName.Text) <> "" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    pocustomerid = globalcustomerid
                    If LTrim(txtReturnOrderNo.Text) <> "" Then
                        If pocustomerid = 0 Then
                            errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                            Exit Try
                        Else
                            getOrderIDSupB(txtReturnOrderNo.Text, "Return", Me)
                            poorderid = globalorderid
                            If poorderid <> 0 Then
                                errProvider.SetError(txtReturnOrderNo, "Return no. and customer name has been created already, please type a new one.")
                                Exit Try
                            End If
                        End If
                    Else
                        errProvider.SetError(pbAddCustomer, "Please enter the return order no.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddCustomer, "Please enter the return name.")
                    Exit Try
                End If
            ElseIf cue = "Edit" Then
                If updates = "N" Then
                    MessageBox.Show("You are not allowed to update a record. Please check your user rights.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If
                If dgReturnOrderList.Rows.Count <> 0 Then
                    If LTrim(cboCustomerName.Text) <> "" Then
                        getCustomerID(cboCustomerName.Text, Me)
                        pocustomerid = globalcustomerid
                        If LTrim(txtReturnOrderNo.Text) <> "" Then
                            If pocustomerid = 0 Then
                                errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                                Exit Try
                            Else
                                getOrderIDSupA(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), txtReturnOrderNo.Text, "Return", Me)
                                poorderid = globalorderid
                                If poorderid <> 0 Then
                                    errProvider.SetError(txtReturnOrderNo, "Return no. and customer name been created already, please type a new one.")
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
                    errProvider.SetError(pbAddCustomer, "System cannot find the existing customer order.")
                    Exit Try
                End If
                If dgReturnOrderList.Rows.Count <> 0 Then
                    getOrderStatus(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                    If globalorderstatus <> txtStatus.Text Then
                        MessageBox.Show("This Return no has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                End If
            End If

            myModule.systemerrorfound = False
            If MessageBox.Show("Would you like to save the changes on this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If cue = "New" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    pocustomerid = globalcustomerid
                    getOrderIDSupB(txtReturnOrderNo.Text, "Return", Me)
                    poorderid = globalorderid
                    If poorderid <> 0 Then
                        errProvider.SetError(txtReturnOrderNo, "Return no. and customer name has been created already, please type a new one.")
                        Exit Try
                    End If
                    M_I_OrdersA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, pocustomerid, txtReturnOrderNo.Text, "Return", dtpReturnOrderDate.Value, Now.Date, _
                           cboCustomerName.Text, txtComments.Text, txtStatus.Text, Math.Round(poitotalprice, 2), Me)
                    poorderid = globalorderidsp
                    If dgReturnOrderItems.Rows.Count <> 0 Then
                        For a = 0 To dgReturnOrderItems.Rows.Count - 1
                            If myModule.systemerrorfound = False Then
                                If IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                    If CInt(dgReturnOrderItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                        getTotalQtyAvailableA(CInt(dgReturnOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                        M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, pocustomerid, poorderid, CInt(dgReturnOrderItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, _
                                              If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_goodqty").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_goodqty").Value), 0), globaltotalqtyavailable, "S", _
                                            "" & CStr(dgReturnOrderItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgReturnOrderItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgReturnOrderItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgReturnOrderItems.Rows(a).Cells("ci_seasoncode").Value) & "", _
                                            CStr(dgReturnOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgReturnOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", 0,
                                            "N", If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_badqty").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_badqty").Value), 0), dgReturnOrderItems.Rows(a).Cells("ci_reasons").Value, Me)
                                    End If
                                End If
                                If IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_bid").Value) Then
                                    If CInt(dgReturnOrderItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                        M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, pocustomerid, CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), DBNull.Value, CInt(dgReturnOrderItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_goodqty").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_goodqty").Value), 0), _
                                                     0, "S", CStr(dgReturnOrderItems.Rows(a).Cells("ci_productcode").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_remarks").Value), _
                                                     If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgReturnOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", 0, "N", If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_badqty").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_badqty").Value), 0), dgReturnOrderItems.Rows(a).Cells("ci_reasons").Value, Me)
                                    End If
                                End If
                            Else
                                Exit Sub
                            End If
                        Next
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                    End If
                ElseIf cue = "Edit" Then
                    If dgReturnOrderList.Rows.Count <> 0 Then
                        getCustomerID(cboCustomerName.Text, Me)
                        pocustomerid = globalcustomerid
                        getOrderIDSupA(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), dgReturnOrderItems.Text, "Return", Me)
                        poorderid = globalorderid
                        If poorderid <> 0 Then
                            errProvider.SetError(dgReturnOrderItems, "Return no. and customer name has been created already, please type a new one.")
                            Exit Try
                        End If
                        M_U_OrderA(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, pocustomerid, txtReturnOrderNo.Text, dtpReturnOrderDate.Value, _
                           Now.Date, txtComments.Text, Math.Round(poitotalprice, 2), Me)
                        If dgReturnOrderItems.Rows.Count <> 0 Then
                            For a = 0 To dgReturnOrderItems.Rows.Count - 1
                                If myModule.systemerrorfound = False Then
                                    If IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_rowid").Value) Then
                                        If CInt(dgReturnOrderItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                                            M_U_OrderItemsA(CInt(dgReturnOrderItems.Rows(a).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_goodqty").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_goodqty").Value), 0), If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_badqty").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_badqty").Value), 0), _
                                                    If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgReturnOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), CStr(dgReturnOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_remarks").Value), dgReturnOrderItems.Rows(a).Cells("ci_reasons").Value, Me)
                                        End If
                                    Else
                                        If IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                            If CInt(dgReturnOrderItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                                getTotalQtyAvailableA(CInt(dgReturnOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, pocustomerid, CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, _
                                                    If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_goodqty").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_goodqty").Value), 0), globaltotalqtyavailable, "S", _
                                                    "" & CStr(dgReturnOrderItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgReturnOrderItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgReturnOrderItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgReturnOrderItems.Rows(a).Cells("ci_seasoncode").Value) & "", _
                                                    CStr(dgReturnOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgReturnOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", 0, "N", If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_badqty").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_badqty").Value), 0), dgReturnOrderItems.Rows(a).Cells("ci_reasons").Value, Me)
                                            End If
                                        End If
                                        If IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_bid").Value) Then
                                            If CInt(dgReturnOrderItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                                M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, pocustomerid, CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), DBNull.Value, CInt(dgReturnOrderItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_goodqty").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_goodqty").Value), 0), _
                                                    0, "S", CStr(dgReturnOrderItems.Rows(a).Cells("ci_productcode").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgReturnOrderItems.Rows(a).Cells("ci_remarks").Value), _
                                                    If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgReturnOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", 0, "N", If(IsNumeric(dgReturnOrderItems.Rows(a).Cells("ci_badqty").Value), CInt(dgReturnOrderItems.Rows(a).Cells("ci_badqty").Value), 0), dgReturnOrderItems.Rows(a).Cells("ci_reasons").Value, Me)
                                            End If
                                        End If
                                    End If
                                Else
                                    Exit Sub
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
    Private Sub dgReturnOrderItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReturnOrderItems.CellContentClick
        Try
            If dgReturnOrderItems.Rows.Count <> 0 Then
                If e.ColumnIndex = dgReturnOrderItems.Columns("ci_option").Index Then
                    If updates = "N" Then
                        MessageBox.Show("You are not allowed to delete this record. Please check your user rights.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Try
                    End If
                    If IsNumeric(dgReturnOrderItems.CurrentRow.Cells("ci_rowid").Value) Then
                        If dgReturnOrderItems.CurrentRow.Cells("ci_rowid").Value = 0 Then
                            If dgReturnOrderItems.SelectedRows.Count > 0 Then
                                dgReturnOrderItems.Rows.Remove(dgReturnOrderItems.SelectedRows(0))
                            End If
                        Else
                            If dgReturnOrderList.Rows.Count <> 0 Then
                                getOrderStatus(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                                If globalorderstatus <> txtStatus.Text Then
                                    MessageBox.Show("This return order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                ElseIf globalorderstatus = "New" Then
                                    If MessageBox.Show("Would you like to delete this item from this list?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        Me.Cursor = Cursors.WaitCursor
                                        getOrderStatus(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                                        If globalorderstatus <> "New" Then
                                            MessageBox.Show("This return order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Exit Try
                                        End If
                                        getOrderItemInfo(CInt(dgReturnOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                                        getOrderTotalAmount(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                                        U_OrderTotalAmount(CInt(dgReturnOrderList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalordertotalamount - Math.Round(globalorderitemsrp * globalorderitemqtyordered, 2), Me)
                                        If myModule.systemerrorfound = False Then
                                            U_OrderItemStatus(CInt(dgReturnOrderItems.CurrentRow.Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                                        End If
                                        If myModule.systemerrorfound = False Then
                                            If dgReturnOrderItems.SelectedRows.Count > 0 Then
                                                dgReturnOrderItems.Rows.Remove(dgReturnOrderItems.SelectedRows(0))
                                            End If
                                            myBalloon("Successfully Deleted", "Delete", lblsavemsg, -15, -65)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If dgReturnOrderItems.SelectedRows.Count > 0 Then
                            dgReturnOrderItems.Rows.Remove(dgReturnOrderItems.SelectedRows(0))
                        End If
                    End If
                    itemno = startingpage
                    For i As Integer = 0 To dgReturnOrderItems.Rows.Count - 1
                        dgReturnOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
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
                If cboDate.Text = "" And cboSearch1.Text = "" And cboSearch3.Text = "" Then
                    tsrefreshperformclick()
                Else
                    If cboDate.Text <> "" And cboSearch1.Text = "" And cboSearch3.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "OrderDate" Then
                            datephrase = "po.orderdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        ElseIf cboDate.Text = "TargetDate" Then
                            datephrase = "po.targetdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        End If
                        txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
                    ElseIf cboDate.Text <> "" And cboSearch2.Text = "" And cboSearch4.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "OrderDate" Then
                            displayDateSearch(spagenum, "po.orderdate")
                            pageSetup2("po.orderdate")
                        ElseIf cboDate.Text = "TargetDate" Then
                            displayDateSearch(spagenum, "po.targetdate")
                            pageSetup2("po.targetdate")
                        End If
                        txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
                    Else
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "CommonSearch"
                        If cboSearch1.Text = "" Then
                            pagefilter1 = ""
                        Else
                            getCommonPhrase(cboSearch1, cboSearch3.Text)
                            pagefilter1 = "" & commonphrase & ""
                        End If
                        If cboSearch2.Text = "" Then
                            pagefilter2 = ""
                        Else
                            getCommonPhrase(cboSearch2, cboSearch4.Text)
                            pagefilter2 = "" & commonphrase & ""
                        End If
                        If pagefilter1 = "" Then
                            pagefilter3 = pagefilter2
                        ElseIf pagefilter2 = "" Then
                            pagefilter3 = pagefilter1
                        Else
                            pagefilter3 = "" & pagefilter1 & " AND " & pagefilter2 & ""
                        End If
                        If cboDate.Text = "OrderDate" Then
                            pagefilter4 = " AND (po.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " & _
                                    "po.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') GROUP BY po.rowid "
                        ElseIf cboDate.Text = "TargetDate" Then
                            pagefilter4 = " AND (po.targetdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " & _
                                    "po.targetdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') GROUP BY po.rowid "
                        Else
                            pagefilter4 = ""
                        End If
                        spagenum = neutralpage : numofpages = startingpage
                        displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
                        pageSetup3(pagefilter3, pagefilter4)
                        txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
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
    Private Sub cboSearch4_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSearch4.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If cboDate.Text = "" And cboSearch1.Text = "" And cboSearch3.Text = "" Then
                    tsrefreshperformclick()
                Else
                    If cboDate.Text <> "" And cboSearch1.Text = "" And cboSearch3.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "OrderDate" Then
                            datephrase = "po.orderdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        ElseIf cboDate.Text = "TargetDate" Then
                            datephrase = "po.targetdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        End If
                        txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
                    ElseIf cboDate.Text <> "" And cboSearch2.Text = "" And cboSearch4.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "OrderDate" Then
                            displayDateSearch(spagenum, "po.orderdate")
                            pageSetup2("po.orderdate")
                        ElseIf cboDate.Text = "TargetDate" Then
                            displayDateSearch(spagenum, "po.targetdate")
                            pageSetup2("po.targetdate")
                        End If
                        txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
                    Else
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "CommonSearch"
                        If cboSearch1.Text = "" Then
                            pagefilter1 = ""
                        Else
                            getCommonPhrase(cboSearch1, cboSearch3.Text)
                            pagefilter1 = "" & commonphrase & ""
                        End If
                        If cboSearch2.Text = "" Then
                            pagefilter2 = ""
                        Else
                            getCommonPhrase(cboSearch2, cboSearch4.Text)
                            pagefilter2 = "" & commonphrase & ""
                        End If
                        If pagefilter1 = "" Then
                            pagefilter3 = pagefilter2
                        ElseIf pagefilter2 = "" Then
                            pagefilter3 = pagefilter1
                        Else
                            pagefilter3 = "" & pagefilter1 & " AND " & pagefilter2 & ""
                        End If
                        If cboDate.Text = "OrderDate" Then
                            pagefilter4 = " AND (po.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " & _
                                    "po.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') GROUP BY po.rowid "
                        ElseIf cboDate.Text = "TargetDate" Then
                            pagefilter4 = " AND (po.targetdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " & _
                                    "po.targetdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') GROUP BY po.rowid "
                        Else
                            pagefilter4 = ""
                        End If
                        spagenum = neutralpage : numofpages = startingpage
                        displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
                        pageSetup3(pagefilter3, pagefilter4)
                        txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
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
    Private Sub cmdFirst_Click(sender As Object, e As EventArgs) Handles cmdFirst.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            spagenum = neutralpage
            numofpages = startingpage
            If searchmode = "Basic" Then
                displayReturnOrderList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
            End If
            txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
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
                displayReturnOrderList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
            End If
            txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
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
                displayReturnOrderList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
            End If
            txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
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
                displayReturnOrderList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
            End If
            txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
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
                            displayReturnOrderList(spagenum)
                        ElseIf searchmode = "CommonSearch" Then
                            displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
                        ElseIf searchmode = "SimpleSearch" Then
                            displaySearchPhrase(simplesearchphrase, spagenum)
                        ElseIf searchmode = "DateSearch" Then
                            displayDateSearch(spagenum, datephrase)
                        End If
                        txtPageNo.Text = "Page " & numofpages & " of " & validpages & " "
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
    Private Sub dgReturnOrderItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgReturnOrderItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgReturnOrderItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgReturnOrderItems.BeginEdit(True)
                Else
                    dgReturnOrderItems.EndEdit()
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
    Private Sub dgReturnOrderList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgReturnOrderList.DataError
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
                dgReturnOrderList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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
    Private Sub dgReturnOrderItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgReturnOrderItems.DataError
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
                dgReturnOrderItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#End Region
    Private Sub pbAddCustomer_Click_1(sender As Object, e As EventArgs) Handles pbAddCustomer.Click
        Try
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
    End Sub
End Class