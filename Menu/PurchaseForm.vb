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

Public Class PurchaseForm
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
    Dim povariancestringprint As String
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim pooverallsrp, pototalsrp, poitotalprice, povarianceprint As Decimal
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim pototalqtyordered, poqtyordered, poitotalqtyordered, poiqtyordered As Integer
    Dim posupplierid, poorderid, poproductcolorsizesid, poproductid, poproductbundleid As Integer
    Dim simplesearchphrase, datephrase, commonphrase, pagefilter1, pagefilter2, pagefilter3, pagefilter4 As String

    Private Sub PurchaseForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            displaySupplierOrderList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PurchaseOrderForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        globalautocompleteAccountName(cboSupplierName, "Supplier", "AND a.`status` = 'Active'", Me)
    End Sub

    Sub callAutoPopulate()
        autopopulatecboSearch()
        autopopulatecboBy()
        globalautopopulateAccountName(cboSupplierName, "Supplier", "AND a.`status` = 'Active'", Me)
    End Sub

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearSupplierOrderInformation()
            clearAddProductA()
            clearAddProductB()
            clearSupplierOrderItems()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visibleSupplierOrderItems(fraud)
            visibleAddProductItems(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
            enableGB(legit, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cue = ""
            clearSupplierOrderInformation()
            clearAddProductA()
            clearAddProductB()
            clearSupplierOrderItems()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visibleSupplierOrderItems(fraud)
            visibleAddProductItems(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
            enableGB(legit, fraud, fraud)
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

    Sub clearSupplierOrderInformation()
        Try
            txtSupplierOrderNo.Text = ""
            cboSupplierName.Text = ""
            txtStatus.Text = ""
            txtComments.Text = ""
            txtRRNo.Text = ""
            txtRRDate.Text = ""
            txtTimeArrived.Text = ""
            txtArrivedIn.Text = ""
            txtContainerNo.Text = ""
            txtSealNo.Text = ""
            txtReceivedBy.Text = ""
            txtBrands.Text = ""
            dtpSupplierOrderDate.Value = Now.Date
            dtpTargetDeliveryDate.Value = Now.Date
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

    Sub clearSupplierOrderItems()
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
            dgSupplierOrderItems.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbSupplierOrderList.Enabled = enable1
            gbSupplierOrderInformation.Enabled = enable2
            gbSupplierOrderItems.Enabled = enable2
            gbAddProducts.Enabled = enable3
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableANDvisibleMS(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean, ByVal visible1 As Boolean, ByVal visible2 As Boolean)
        Try
            msNew.Enabled = enable1
            msSave.Enabled = enable2
            msPrint.Enabled = enable3
            msCancel.Visible = visible1
            msOrder.Visible = visible2
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub visibleSupplierOrderItems(ByVal visible1 As Boolean)
        Try
            ci_unitofmeasure.Visible = visible1
            ci_itemtype.Visible = visible1
            ci_qtyreceived.Visible = visible1
            ci_qtybad.Visible = visible1
            ci_reason.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub visibleAddProductItems(ByVal visible1 As Boolean, ByVal visible2 As Boolean, ByVal visible3 As Boolean, ByVal visible4 As Boolean, ByVal visible5 As Boolean)
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
            displaySupplierOrderList(spagenum)
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
                        errProvider.SetError(txtQtyOrdered, "Please use numbers for qty. ordered")
                        txtQtyOrdered.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the combination code.")
                        cboByPhrase.Focus()
                    Else
                        checkSupplierOrderItemsA()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    If dgProductSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the sizes.")
                        cboByPhrase.Focus()
                    Else
                        checkSupplierOrderItemsB()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    If Not IsNumeric(txtQtyOrdered.Text) Then
                        errProvider.SetError(txtQtyOrdered, "Please use numbers for qty. ordered")
                        txtQtyOrdered.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the sku.")
                        cboByPhrase.Focus()
                    Else
                        If dgProductColorSizes.Rows.Count <> 0 Then
                            checkSupplierOrderItemsA()
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

    Sub supplierorderitemscomputations()
        Try
            poitotalqtyordered = 0 : poiqtyordered = 0 : poitotalprice = 0.0
            If dgSupplierOrderItems.Rows.Count <> 0 Then
                For i = 0 To dgSupplierOrderItems.Rows.Count - 1
                    If IsNumeric(dgSupplierOrderItems.Rows(i).Cells("ci_qtyordered").Value) Then
                        poiqtyordered = CInt(dgSupplierOrderItems.Rows(i).Cells("ci_qtyordered").Value)
                        poitotalqtyordered = poitotalqtyordered + CInt(dgSupplierOrderItems.Rows(i).Cells("ci_qtyordered").Value)
                    Else
                        poiqtyordered = 0
                    End If
                    If IsNumeric(dgSupplierOrderItems.Rows(i).Cells("ci_srp").Value) Then
                        dgSupplierOrderItems.Rows(i).Cells("ci_totalprice").Value = Math.Round(poiqtyordered * CDec(dgSupplierOrderItems.Rows(i).Cells("ci_srp").Value), 2)
                    Else
                        dgSupplierOrderItems.Rows(i).Cells("ci_totalprice").Value = 0.0
                    End If
                    If IsNumeric(dgSupplierOrderItems.Rows(i).Cells("ci_totalprice").Value) Then
                        poitotalprice = poitotalprice + CDec(dgSupplierOrderItems.Rows(i).Cells("ci_totalprice").Value)
                    End If
                Next
            End If
            txtTotalItems.Text = dgSupplierOrderItems.Rows.Count
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
            dtCid = getDataTableForSQL("SELECT COUNT(po.rowid) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' " &
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' AND " &
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = 'PO{OrderType.PO.ToString()} AND " & ecommonstring & " " & edatesearch & " ")
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
            If icommonbox.Text = "SupplierName" Then
                getSupplierID(icommonstring, Me)
                posupplierid = globalsupplierid
                commonphrase = "po.accountid = " & posupplierid & ""
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

    Sub autocompleteSupplierName(ByVal icombobox As ComboBox)
        Try
            Dim suppliername As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'') AS 'suppliername' FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' GROUP BY su.accountno ORDER BY su.accountno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                suppliername.Add(ds.Tables(0).Rows(i)("suppliername").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = suppliername
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
            Dim cmd As New MySqlCommand("SELECT COALESCE(po.status,'') AS 'postatus' FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' GROUP BY po.status ORDER BY po.status ", conn)
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
            cboSearch1.Items.Add("SupplierName")
            cboSearch1.Items.Add("Status")
            cboSearch3.Items.Add("SupplierName")
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

    Sub autopopulateSupplierName(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'') AS 'suppliername' FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' GROUP BY su.accountno ORDER BY su.companyname "
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
            Dim sql1 As String = "SELECT COALESCE(po.status,'') AS 'postatus' FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' GROUP BY po.status ORDER BY po.status "
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

    Sub displaySupplierOrderList(ByVal istartpage As Integer)
        Try
            dgSupplierOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' " &
                        "ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgSupplierOrderList.Rows.Add()
                    dgSupplierOrderList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgSupplierOrderList.Item(so_supplierorderno.Index, n).Value = reader1(1)
                    dgSupplierOrderList.Item(so_supplierorderdate.Index, n).Value = reader1(2)
                    dgSupplierOrderList.Item(so_suppliername.Index, n).Value = reader1(3)
                    dgSupplierOrderList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgSupplierOrderList.Columns("so_supplierorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderList.Columns("so_supplierorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgSupplierOrderList.Rows.Count <> 0 Then
                dgSupplierOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgSupplierOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' AND " &
                        "(po.ordernumber LIKE '%" & isearchphrase & "%' OR po.status LIKE '%" & isearchphrase & "%' OR su.companyname LIKE '%" & isearchphrase & "%') " &
                        "ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgSupplierOrderList.Rows.Add()
                    dgSupplierOrderList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgSupplierOrderList.Item(so_supplierorderno.Index, n).Value = reader1(1)
                    dgSupplierOrderList.Item(so_supplierorderdate.Index, n).Value = reader1(2)
                    dgSupplierOrderList.Item(so_suppliername.Index, n).Value = reader1(3)
                    dgSupplierOrderList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgSupplierOrderList.Columns("so_supplierorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderList.Columns("so_supplierorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgSupplierOrderList.Rows.Count <> 0 Then
                dgSupplierOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayDateSearch(ByVal istartpage As Integer, ByVal idatesearch As String)
        Try
            dgSupplierOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' AND " &
                        "(" & idatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                        "" & idatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) " &
                        "GROUP BY po.rowid ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgSupplierOrderList.Rows.Add()
                    dgSupplierOrderList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgSupplierOrderList.Item(so_supplierorderno.Index, n).Value = reader1(1)
                    dgSupplierOrderList.Item(so_supplierorderdate.Index, n).Value = reader1(2)
                    dgSupplierOrderList.Item(so_suppliername.Index, n).Value = reader1(3)
                    dgSupplierOrderList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgSupplierOrderList.Columns("so_supplierorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderList.Columns("so_supplierorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgSupplierOrderList.Rows.Count <> 0 Then
                dgSupplierOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal idatesearch As String, ByVal istartpage As Integer)
        Try
            dgSupplierOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' " &
                        "AND " & icommonphrase & " " & idatesearch & " GROUP BY po.rowid ORDER BY po.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgSupplierOrderList.Rows.Add()
                    dgSupplierOrderList.Item(so_rowid.Index, n).Value = reader1(0)
                    dgSupplierOrderList.Item(so_supplierorderno.Index, n).Value = reader1(1)
                    dgSupplierOrderList.Item(so_supplierorderdate.Index, n).Value = reader1(2)
                    dgSupplierOrderList.Item(so_suppliername.Index, n).Value = reader1(3)
                    dgSupplierOrderList.Item(so_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgSupplierOrderList.Columns("so_supplierorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderList.Columns("so_supplierorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderList.Columns("so_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgSupplierOrderList.Rows.Count <> 0 Then
                dgSupplierOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySupplierOrderInformation(ByVal isupplierorderid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),DATE_FORMAT(po.targetdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(po.comments,''),COALESCE(po.status,'') FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.rowid = " & isupplierorderid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtSupplierOrderNo.Text = reader1(0)
                    dtpSupplierOrderDate.Text = reader1(1)
                    dtpTargetDeliveryDate.Text = reader1(2)
                    cboSupplierName.Text = reader1(3)
                    txtComments.Text = reader1(4)
                    txtStatus.Text = reader1(5)
                    getRRInfo(isupplierorderid, Me)
                    txtRRNo.Text = gloRRNo
                    txtRRDate.Text = gloRRDate
                    txtTimeArrived.Text = gloRRTimeArrived
                    txtArrivedIn.Text = gloRRArrivedIn
                    txtContainerNo.Text = gloRRContainerNo
                    txtSealNo.Text = gloRRSealNo
                    txtReceivedBy.Text = gloRRReceivedBy
                    txtBrands.Text = gloRRBrands
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displaySupplierOrderItems(ByVal isupplierorderid As Integer)
        Try
            dgSupplierOrderItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(ci.productbundleid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(b.bundlename,''),COALESCE(c.colorname,''),COALESCE(pcs.size,'')," &
                    "COALESCE(pcs.seasoncode,''),COALESCE(ci.unitofmeasure,''),COALESCE(ci.qtyordered,0),COALESCE(ci.srp,0.0),COALESCE(pcs.sku,''),COALESCE(b.sku,''),COALESCE(ci.itemtype,''),COALESCE(ci.remarks,''),COALESCE(ci.qtyreceived,0)," &
                    "COALESCE(ci.qtydamaged,0),COALESCE(ci.reasons,'') FROM orderitems ci LEFT JOIN productbundles b ON ci.productbundleid = b.rowid LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " &
                    "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE ci.orderid = " & isupplierorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.status != 'Inactive' AND ci.itemtype != 'BI' ORDER BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgSupplierOrderItems.Rows.Add()
                    dgSupplierOrderItems.Item(ci_seqno.Index, n).Value = seqno
                    dgSupplierOrderItems.Item(ci_rowid.Index, n).Value = reader1(0)
                    dgSupplierOrderItems.Item(ci_pcsrowid.Index, n).Value = reader1(1)
                    dgSupplierOrderItems.Item(ci_bid.Index, n).Value = reader1(2)
                    dgSupplierOrderItems.Item(ci_colorvalue.Index, n).Value = reader1(3)
                    If CInt(reader1(1)) <> 0 Then
                        dgSupplierOrderItems.Item(ci_productcode.Index, n).Value = reader1(4)
                    Else
                        dgSupplierOrderItems.Item(ci_productcode.Index, n).Value = reader1(5)
                    End If
                    dgSupplierOrderItems.Item(ci_colorname.Index, n).Value = reader1(6)
                    dgSupplierOrderItems.Item(ci_size.Index, n).Value = reader1(7)
                    dgSupplierOrderItems.Item(ci_seasoncode.Index, n).Value = reader1(8)
                    dgSupplierOrderItems.Item(ci_unitofmeasure.Index, n).Value = reader1(9)
                    dgSupplierOrderItems.Item(ci_qtyordered.Index, n).Value = reader1(10)
                    dgSupplierOrderItems.Item(ci_srp.Index, n).Value = reader1(11)
                    If CInt(reader1(1)) <> 0 Then
                        dgSupplierOrderItems.Item(ci_sku.Index, n).Value = reader1(12)
                    Else
                        dgSupplierOrderItems.Item(ci_sku.Index, n).Value = reader1(13)
                    End If
                    dgSupplierOrderItems.Item(ci_itemtype.Index, n).Value = reader1(14)
                    dgSupplierOrderItems.Item(ci_remarks.Index, n).Value = reader1(15)
                    dgSupplierOrderItems.Item(ci_qtyreceived.Index, n).Value = reader1(16)
                    dgSupplierOrderItems.Item(ci_qtybad.Index, n).Value = reader1(17)
                    dgSupplierOrderItems.Item(ci_reason.Index, n).Value = reader1(18)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgSupplierOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_itemtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_qtybad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgSupplierOrderItems.Rows.Count <> 0 Then
                dgSupplierOrderItems.CurrentRow.Selected = False
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
            If dgSupplierOrderItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgSupplierOrderItems.Rows.Count - 1
                    If dgSupplierOrderItems.Rows(i).Cells(ci_itemtype.Index).Value = "A" Then
                        dgSupplierOrderItems.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
                    End If
                    If CStr(dgSupplierOrderItems.Rows(i).Cells("ci_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgSupplierOrderItems.Rows(i).Cells("ci_colorvalue").Value))
                        dgSupplierOrderItems.Rows(i).Cells("ci_color").Style.BackColor = readcolor
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

#Region "Adding"

    Sub checkSupplierOrderItemsA()
        Try
            If dgProductColorSizes.Rows.Count <> 0 Then
                For p = 0 To dgProductColorSizes.Rows.Count - 1
                    If dgSupplierOrderItems.Rows.Count <> 0 Then
                        rowscount = dgSupplierOrderItems.Rows.Count - 1
                        For i = 0 To dgSupplierOrderItems.Rows.Count - 1
                            If dgSupplierOrderItems.Rows(i).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                errProvider.SetError(cboByPhrase, "Product is in the list already.")
                                cboByPhrase.Focus()
                                Exit Try
                            ElseIf rowscount = 0 Then
                                addSupplierOrderItemA(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CInt(txtQtyOrdered.Text), If(IsNumeric(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), CDec(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), 0.0))
                                For a = 0 To dgSupplierOrderItems.Rows.Count - 1
                                    dgSupplierOrderItems.CurrentRow.Selected = fraud
                                    If dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                        dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Selected = legit
                                        dgSupplierOrderItems.FirstDisplayedScrollingRowIndex = dgSupplierOrderItems.RowCount - 1
                                        Exit For
                                    End If
                                Next
                                cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyOrdered.Text = "" : cboByPhrase.Focus() : dgProductColorSizes.Rows.Clear()
                            End If
                            rowscount = rowscount - 1
                        Next
                    Else
                        addSupplierOrderItemA(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CInt(txtQtyOrdered.Text), If(IsNumeric(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), CDec(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), 0.0))
                        For a = 0 To dgSupplierOrderItems.Rows.Count - 1
                            dgSupplierOrderItems.CurrentRow.Selected = fraud
                            If dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Selected = legit
                                dgSupplierOrderItems.FirstDisplayedScrollingRowIndex = dgSupplierOrderItems.RowCount - 1
                                Exit For
                            End If
                        Next
                        cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyOrdered.Text = "" : cboByPhrase.Focus() : dgProductColorSizes.Rows.Clear()
                    End If
                Next
                itemno = 1 : colorCoding() : addproductcomputations() : supplierorderitemscomputations()
                For i As Integer = 0 To dgSupplierOrderItems.Rows.Count - 1
                    dgSupplierOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub checkSupplierOrderItemsB()
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                For p = 0 To dgProductSizes.Rows.Count - 1
                    If IsNumeric(dgProductSizes.Rows(p).Cells("s_qtyordered").Value) Then
                        If CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value) > 0 Then
                            If dgSupplierOrderItems.Rows.Count <> 0 Then
                                rowscount = dgSupplierOrderItems.Rows.Count - 1
                                For i = 0 To dgSupplierOrderItems.Rows.Count - 1
                                    If dgSupplierOrderItems.Rows(i).Cells("ci_pcsrowid").Value = dgProductSizes.Rows(p).Cells("s_rowid").Value Then
                                        Exit For
                                    ElseIf rowscount = 0 Then
                                        addSupplierOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value), If(IsNumeric(dgProductSizes.Rows(p).Cells("s_srp").Value), CDec(dgProductSizes.Rows(p).Cells("s_srp").Value), 0.0))
                                    End If
                                    rowscount = rowscount - 1
                                Next
                            Else
                                addSupplierOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value), If(IsNumeric(dgProductSizes.Rows(p).Cells("s_srp").Value), CDec(dgProductSizes.Rows(p).Cells("s_srp").Value), 0.0))
                            End If
                        End If
                    End If
                Next
                itemno = 1 : colorCoding() : addproductcomputations() : supplierorderitemscomputations()
                For i As Integer = 0 To dgSupplierOrderItems.Rows.Count - 1
                    dgSupplierOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
                If dgSupplierOrderItems.Rows.Count <> 0 Then
                    dgSupplierOrderItems.CurrentRow.Selected = False
                    dgSupplierOrderItems.FirstDisplayedScrollingRowIndex = dgSupplierOrderItems.RowCount - 1
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

    Sub addSupplierOrderItemA(ByVal iproductcolorsizeid As Integer, ByVal iqtyordered As Integer, ByVal isrp As Decimal)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(p.unitofmeasure,''),COALESCE(pcs.sku,''),COALESCE(pcs.seasoncode,'') " &
                "FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.rowid = " & iproductcolorsizeid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    dgSupplierOrderItems.Rows.Add()
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_rowid").Value = ""
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_bid").Value = neutralpage
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_remarks").Value = ""
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_reason").Value = ""
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = reader1(0)
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_colorvalue").Value = reader1(1)
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_productcode").Value = reader1(2)
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_colorname").Value = reader1(3)
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_size").Value = reader1(4)
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = reader1(5)
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_qtyordered").Value = iqtyordered
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_srp").Value = isrp
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_sku").Value = reader1(6)
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_seasoncode").Value = reader1(7)
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_itemtype").Value = "S"
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_qtyreceived").Value = ""
                    dgSupplierOrderItems.Rows(dgSupplierOrderItems.Rows.Count - 1).Cells("ci_qtybad").Value = ""
                End If
            End While
            reader1.Close()
            dgSupplierOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_qtybad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSupplierOrderItems.Columns("ci_itemtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Printing"

    Sub printPurchaseOrder(ByVal isupplierorderid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT o.rowid,COALESCE(o.ordernumber,''),DATE_FORMAT(o.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),''),COALESCE(p.productcode,'')," &
                        "COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,''),COALESCE(ci.unitofmeasure,''),COALESCE(ci.qtyordered,0),COALESCE(ci.qtyreceived,0),COALESCE(ci.qtydamaged,0) FROM orderitems ci " &
                        "LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " &
                        "LEFT JOIN orders o ON ci.orderid = o.rowid LEFT JOIN accounts su ON o.accountid = su.rowid WHERE ci.orderid = " & isupplierorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.`status` != 'Inactive' AND (ci.itemtype != 'BI' AND ci.itemtype != 'A') ORDER BY p.productcode,c.colorname,pcs.size "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    getRRInfo(CInt(reader1(0)), Me)
                    povarianceprint = ((CInt(reader1(11)) + CInt(reader1(12))) - CInt(reader1(10))) / CInt(reader1(10)) * pagedivisor
                    povariancestringprint = "" & Format(povarianceprint, "#,##0.00") & "%"
                    printdataset.AddSetDRow("P.O. No.: " & CStr(reader1(1)) & "", "R.R. No.: " & gloRRNo & "", "R.R. Date: " & gloRRDate & "", "P.O. Date: " & CStr(reader1(2)) & "", "Supplier Name: " & CStr(reader1(3)) & "", "Received By: " & gloRRReceivedBy & "", Format(seqno, "#,##0"), CStr(reader1(4)), CStr(reader1(5)), CStr(reader1(6)), CStr(reader1(7)), CStr(reader1(8)), CStr(reader1(9)), Format(CInt(reader1(10)), "#,##0"), Format(CInt(reader1(11)), "#,##0"), Format(CInt(reader1(12)), "#,##0"), povariancestringprint, "", "", "", "")
                    seqno = seqno + 1
                End If
            End While
            reader1.Close()
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
                PrimaryForm.POForm = False
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
                getPositionView(globalpositionid, "Purchase Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.POForm = False
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
            clearSupplierOrderInformation()
            clearAddProductA()
            clearAddProductB()
            clearSupplierOrderItems()
            clearDatagrids()
            enableGB(fraud, legit, legit)
            visibleSupplierOrderItems(fraud)
            visibleAddProductItems(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(fraud, legit, fraud, legit, fraud)
            If dgSupplierOrderList.Rows.Count <> 0 Then
                dgSupplierOrderList.CurrentRow.Selected = False
            End If
            getOrderNo(globaliordertype:=OrderType.PO.ToString(), Me)
            txtSupplierOrderNo.Text = CStr(globalorderno)
            txtStatus.Text = "New"
            txtSupplierOrderNo.Focus()
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
            If dgSupplierOrderList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearSupplierOrderInformation()
                clearAddProductA()
                clearAddProductB()
                clearSupplierOrderItems()
                clearDatagrids()
                visibleSupplierOrderItems(fraud)
                visibleAddProductItems(fraud, fraud, fraud, fraud, fraud)
                dgSupplierOrderList.CurrentRow.Selected = True
                displaySupplierOrderInformation(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value))
                displaySupplierOrderItems(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value))
                supplierorderitemscomputations() : colorCoding()
                If txtStatus.Text = "New" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Received" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, legit, fraud, fraud)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                End If
                txtSupplierOrderNo.Focus()
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

    Private Sub dgSupplierOrderList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSupplierOrderList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgSupplierOrderList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearSupplierOrderInformation()
                clearAddProductA()
                clearAddProductB()
                clearSupplierOrderItems()
                clearDatagrids()
                visibleSupplierOrderItems(fraud)
                visibleAddProductItems(fraud, fraud, fraud, fraud, fraud)
                displaySupplierOrderInformation(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value))
                displaySupplierOrderItems(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value))
                supplierorderitemscomputations() : colorCoding()
                If txtStatus.Text = "New" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Received" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, legit, fraud, fraud)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                End If
                txtSupplierOrderNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSupplierOrderList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgSupplierOrderList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgSupplierOrderList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearSupplierOrderInformation()
                    clearAddProductA()
                    clearAddProductB()
                    clearSupplierOrderItems()
                    clearDatagrids()
                    visibleSupplierOrderItems(fraud)
                    visibleAddProductItems(fraud, fraud, fraud, fraud, fraud)
                    displaySupplierOrderInformation(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value))
                    displaySupplierOrderItems(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value))
                    supplierorderitemscomputations() : colorCoding()
                    If txtStatus.Text = "New" Then
                        enableGB(legit, legit, legit)
                        enableANDvisibleMS(legit, legit, fraud, fraud, legit)
                        msOrder.Text = "Cancel Order"
                    ElseIf txtStatus.Text = "Received" Then
                        enableGB(legit, legit, fraud)
                        enableANDvisibleMS(legit, fraud, legit, fraud, fraud)
                    ElseIf txtStatus.Text = "Cancelled" Then
                        enableGB(legit, legit, fraud)
                        enableANDvisibleMS(legit, fraud, fraud, fraud, legit)
                        msOrder.Text = "Re-Open Order"
                    Else
                        enableGB(legit, legit, fraud)
                        enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                    End If
                    txtSupplierOrderNo.Focus()
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
                visibleSupplierOrderItems(legit)
            Else
                visibleSupplierOrderItems(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtSupplierOrderNo_Leave(sender As Object, e As EventArgs) Handles txtSupplierOrderNo.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                If LTrim(txtSupplierOrderNo.Text) <> "" Then
                    getOrderIDSupB(txtSupplierOrderNo.Text, globaliordertype:=OrderType.PO.ToString(), Me)
                    poorderid = globalorderid
                    If poorderid <> 0 Then
                        errProvider.SetError(txtSupplierOrderNo, "Purchase order no. has been created already, please type a new one.")
                    End If
                End If
            ElseIf cue = "Edit" Then
                If dgSupplierOrderList.Rows.Count <> 0 Then
                    If LTrim(txtSupplierOrderNo.Text) <> "" Then
                        getOrderIDSupA(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), txtSupplierOrderNo.Text, globaliordertype:=OrderType.PO.ToString(), Me)
                        poorderid = globalorderid
                        If poorderid <> 0 Then
                            errProvider.SetError(txtSupplierOrderNo, "Purchase order no. has been created already, please type a new one.")
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

    'Private Sub txtSupplierOrderNo_TextChanged(sender As Object, e As EventArgs) Handles txtSupplierOrderNo.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            If LTrim(txtSupplierOrderNo.Text) <> "" Then
    '                getOrderIDSupB(txtSupplierOrderNo.Text, "PO", Me)
    '                poorderid = globalorderid
    '                If poorderid <> 0 Then
    '                    errProvider.SetError(txtSupplierOrderNo, "Purchase order no. has been created already, please type a new one.")
    '                End If
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgSupplierOrderList.Rows.Count <> 0 Then
    '                If LTrim(txtSupplierOrderNo.Text) <> "" Then
    '                    getOrderIDSupA(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), txtSupplierOrderNo.Text, "PO", Me)
    '                    poorderid = globalorderid
    '                    If poorderid <> 0 Then
    '                        errProvider.SetError(txtSupplierOrderNo, "Purchase order no. has been created already, please type a new one.")
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
                visibleAddProductItems(fraud, fraud, fraud, fraud, fraud)
            ElseIf cboBy.Text = "Combination" Then
                globalautocompleteByCombination(cboByPhrase, Me)
                globalautopopulateByCombination(cboByPhrase, Me)
                visibleAddProductItems(legit, fraud, fraud, fraud, legit)
            ElseIf cboBy.Text = "ProductCode" Then
                globalautocompleteByProductCode(cboByPhrase, Me)
                globalautopopulateByProductCode(cboByPhrase, Me)
                visibleAddProductItems(fraud, legit, fraud, legit, legit)
            ElseIf cboBy.Text = "SKU" Then
                globalautocompleteBySKU(cboByPhrase, Me)
                globalautopopulateBySKU(cboByPhrase, Me)
                visibleAddProductItems(legit, fraud, fraud, fraud, legit)
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
                        visibleAddProductItems(legit, fraud, fraud, fraud, legit)
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
    '                    visibleAddProductItems(legit, fraud, fraud, fraud, legit)
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
    '                    visibleAddProductItems(legit, fraud, fraud, fraud, legit)
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
            errProvider.Clear()
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

    Private Sub pbAddSupplier_MouseEnter(sender As Object, e As EventArgs) Handles pbAddSupplier.MouseEnter
        Try
            pbAddSupplier.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddSupplier_MouseLeave(sender As Object, e As EventArgs) Handles pbAddSupplier.MouseLeave
        Try
            pbAddSupplier.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddSupplier_Click(sender As Object, e As EventArgs) Handles pbAddSupplier.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Purchase Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.POForm = False
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
            Dim addsupplierslinkform As New AddSupplierForm
            addsupplierslinkform.ShowInTaskbar = False
            addsupplierslinkform.ShowDialog()
            If addsupplierslinkform.addsupplierformcue = legit Then
                globalautocompleteAccountName(cboSupplierName, "Supplier", "AND a.`status` = 'Active'", Me)
                globalautopopulateAccountName(cboSupplierName, "Supplier", "AND a.`status` = 'Active'", Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSupplierOrderItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgSupplierOrderItems.CellEndEdit
        Try
            supplierorderitemscomputations()
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
                getPositionView(globalpositionid, "Purchase Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.POForm = False
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
            If dgSupplierOrderList.Rows.Count <> 0 Then
                getOrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                If globalorderstatus <> txtStatus.Text Then
                    MessageBox.Show("This supplier order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                ElseIf globalorderstatus = "New" Then
                    If MessageBox.Show("Would you like to cancel this order?", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgSupplierOrderList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This supplier order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        U_OrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Cancelled", "Cancel", lblsavemsg, -15, -65)
                            tsrefreshperformclick()
                        End If
                    End If
                ElseIf globalorderstatus = "Cancelled" Then
                    If MessageBox.Show("Would you like to re-open this order?", "Opening", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgSupplierOrderList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This supplier order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        U_OrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "New", Me)
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
            supplierorderitemscomputations()
            dgSupplierOrderItems.CommitEdit(legit) : dgSupplierOrderItems.ClearSelection() : dgSupplierOrderItems.CurrentCell = Nothing
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Purchase Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.POForm = False
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
            If LTrim(cboSupplierName.Text) <> "" Then
                getSupplierID(cboSupplierName.Text, Me)
                posupplierid = globalsupplierid
                If posupplierid = 0 Then
                    errProvider.SetError(pbAddSupplier, "System cannot find the supplier name.")
                    Exit Try
                End If
            Else
                errProvider.SetError(pbAddSupplier, "Please enter the supplier name.")
                Exit Try
            End If
            If cue = "New" Then
                If LTrim(txtSupplierOrderNo.Text) <> "" Then
                    getOrderIDSupB(txtSupplierOrderNo.Text, globaliordertype:=OrderType.PO.ToString(), Me)
                    poorderid = globalorderid
                    If poorderid <> 0 Then
                        errProvider.SetError(txtSupplierOrderNo, "Purchase order no. has been created already, please type a new one.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddSupplier, "Please enter the purchase order no.")
                    Exit Try
                End If
            ElseIf cue = "Edit" Then
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgSupplierOrderList.Rows.Count <> 0 Then
                    getOrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                    If globalorderstatus <> txtStatus.Text Then
                        MessageBox.Show("This purchase order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If LTrim(txtSupplierOrderNo.Text) <> "" Then
                        getOrderIDSupA(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), txtSupplierOrderNo.Text, globaliordertype:=OrderType.PO.ToString(), Me)
                        poorderid = globalorderid
                        If poorderid <> 0 Then
                            errProvider.SetError(txtSupplierOrderNo, "Purchase order no. has been created already, please type a new one.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(pbAddSupplier, "Please enter the supplier order no.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddSupplier, "System cannot find the existing supplier order.")
                    Exit Try
                End If
            End If
            myModule.systemerrorfound = False
            If MessageBox.Show("Would you like to save the changes on this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If cue = "New" Then
                    getSupplierID(cboSupplierName.Text, Me)
                    posupplierid = globalsupplierid
                    If posupplierid = 0 Then
                        errProvider.SetError(pbAddSupplier, "System cannot find the supplier name.")
                        Exit Try
                    End If
                    getOrderIDSupB(txtSupplierOrderNo.Text, globaliordertype:=OrderType.PO.ToString(), Me)
                    poorderid = globalorderid
                    If poorderid <> 0 Then
                        errProvider.SetError(txtSupplierOrderNo, "Purchase order no. has been created already, please type a new one.")
                        Exit Try
                    End If
                    M_I_OrdersA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, posupplierid, txtSupplierOrderNo.Text, OrderType:=OrderType.PO.ToString(), dtpSupplierOrderDate.Value, dtpTargetDeliveryDate.Value,
                           cboSupplierName.Text, txtComments.Text, txtStatus.Text, Math.Round(poitotalprice, 2), Me)
                    poorderid = globalorderidsp
                    If dgSupplierOrderItems.Rows.Count <> 0 Then
                        For a = 0 To dgSupplierOrderItems.Rows.Count - 1
                            If myModule.systemerrorfound = False Then
                                If IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                    If CInt(dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                        getTotalQtyAvailableA(CInt(dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                        M_I_OrderItemsA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, posupplierid, poorderid, CInt(dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value,
                                            If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), globaltotalqtyavailable, "S",
                                            "" & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_seasoncode").Value) & "",
                                            CStr(dgSupplierOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", Me)
                                    End If
                                End If
                                If IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_bid").Value) Then
                                    If CInt(dgSupplierOrderItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                        M_I_OrderItemsA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, posupplierid, poorderid, DBNull.Value, CInt(dgSupplierOrderItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                            0, "S", CStr(dgSupplierOrderItems.Rows(a).Cells("ci_productcode").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_remarks").Value),
                                            If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", Me)
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
                    If dgSupplierOrderList.Rows.Count <> 0 Then
                        getOrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                        If globalorderstatus <> txtStatus.Text Then
                            MessageBox.Show("This purchase order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        getSupplierID(cboSupplierName.Text, Me)
                        posupplierid = globalsupplierid
                        If posupplierid = 0 Then
                            errProvider.SetError(pbAddSupplier, "System cannot find the supplier name.")
                            Exit Try
                        End If
                        getOrderIDSupA(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), txtSupplierOrderNo.Text, globaliordertype:=OrderType.PO.ToString(), Me)
                        poorderid = globalorderid
                        If poorderid <> 0 Then
                            errProvider.SetError(txtSupplierOrderNo, "Purchase order no. has been created already, please type a new one.")
                            Exit Try
                        End If
                        M_U_OrderA(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, posupplierid, txtSupplierOrderNo.Text, dtpSupplierOrderDate.Value,
                            dtpTargetDeliveryDate.Value, txtComments.Text, Math.Round(poitotalprice, 2), Me)
                        If dgSupplierOrderItems.Rows.Count <> 0 Then
                            For a = 0 To dgSupplierOrderItems.Rows.Count - 1
                                If myModule.systemerrorfound = False Then
                                    If IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_rowid").Value) Then
                                        If CInt(dgSupplierOrderItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                                            MB_U_OrderItemsA(CInt(dgSupplierOrderItems.Rows(a).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                                    If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_remarks").Value), Me)
                                        Else
                                            getTotalQtyAvailableA(CInt(dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                            M_I_OrderItemsA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, posupplierid, CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), CInt(dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value,
                                                If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), globaltotalqtyavailable, "S",
                                                "" & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_seasoncode").Value) & "",
                                                CStr(dgSupplierOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", Me)
                                        End If
                                    Else
                                        If IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                            If CInt(dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                                getTotalQtyAvailableA(CInt(dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                M_I_OrderItemsA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, posupplierid, CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), CInt(dgSupplierOrderItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value,
                                                    If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), globaltotalqtyavailable, "S",
                                                    "" & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgSupplierOrderItems.Rows(a).Cells("ci_seasoncode").Value) & "",
                                                    CStr(dgSupplierOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", Me)
                                            End If
                                        End If
                                        If IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_bid").Value) Then
                                            If CInt(dgSupplierOrderItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                                M_I_OrderItemsA(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, posupplierid, CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), DBNull.Value, CInt(dgSupplierOrderItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgSupplierOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                                    0, "S", CStr(dgSupplierOrderItems.Rows(a).Cells("ci_productcode").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgSupplierOrderItems.Rows(a).Cells("ci_remarks").Value),
                                                    If(IsNumeric(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgSupplierOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active", Me)
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

    Private Sub dgSupplierOrderItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSupplierOrderItems.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgSupplierOrderItems.Rows.Count <> 0 Then
                If e.ColumnIndex = dgSupplierOrderItems.Columns("ci_option").Index Then
                    If IsNumeric(dgSupplierOrderItems.CurrentRow.Cells("ci_rowid").Value) Then
                        If dgSupplierOrderItems.CurrentRow.Cells("ci_rowid").Value = 0 Then
                            If dgSupplierOrderItems.SelectedRows.Count > 0 Then
                                dgSupplierOrderItems.Rows.Remove(dgSupplierOrderItems.SelectedRows(0))
                            End If
                        Else
                            getPositionID(Me)
                            If globalpositionid <> 0 Then
                                getPositionView(globalpositionid, "Purchase Orders", Me)
                                If globaldisableflg = "Y" Then
                                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    PrimaryForm.POForm = False
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
                            If dgSupplierOrderList.Rows.Count <> 0 Then
                                getOrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                                If globalorderstatus <> txtStatus.Text Then
                                    MessageBox.Show("This purchase order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                ElseIf globalorderstatus = "New" Then
                                    If MessageBox.Show("Would you like to delete this item from this list?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        Me.Cursor = Cursors.WaitCursor
                                        getOrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                                        If globalorderstatus <> "New" Then
                                            MessageBox.Show("This purchase order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Exit Try
                                        End If
                                        getOrderItemInfo(CInt(dgSupplierOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                                        getOrderTotalAmount(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                                        U_OrderTotalAmount(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalordertotalamount - Math.Round(globalorderitemsrp * globalorderitemqtyordered, 2), Me)
                                        If myModule.systemerrorfound = False Then
                                            U_OrderItemStatus(CInt(dgSupplierOrderItems.CurrentRow.Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                                        End If
                                        If myModule.systemerrorfound = False Then
                                            If dgSupplierOrderItems.SelectedRows.Count > 0 Then
                                                dgSupplierOrderItems.Rows.Remove(dgSupplierOrderItems.SelectedRows(0))
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
                        If dgSupplierOrderItems.SelectedRows.Count > 0 Then
                            dgSupplierOrderItems.Rows.Remove(dgSupplierOrderItems.SelectedRows(0))
                        End If
                    End If
                    itemno = startingpage
                    For i As Integer = 0 To dgSupplierOrderItems.Rows.Count - 1
                        dgSupplierOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
                        itemno = itemno + 1
                    Next i
                    supplierorderitemscomputations()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msPrint_Click(sender As Object, e As EventArgs) Handles msPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Purchase Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.POForm = False
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
            If dgSupplierOrderList.Rows.Count <> 0 Then
                getOrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                If globalorderstatus <> txtStatus.Text Then
                    MessageBox.Show("This purchase order has been updated by other user, please click refresh button to check the new status of this purchase order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If MessageBox.Show("Would you like to print this purchase order?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getOrderStatus(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value), Me)
                    If globalorderstatus <> txtStatus.Text Then
                        MessageBox.Show("This purchase order has been updated by other user, please click refresh button to check the new status of this purchase order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If myModule.systemerrorfound = False Then
                        printPurchaseOrder(CInt(dgSupplierOrderList.CurrentRow.Cells("so_rowid").Value))
                        Dim printreport As New PurchaseOrderPrint
                        Dim openreportviewer As New ReportViewer
                        openreportviewer.CrystalReportViewer.ReportSource = printreport
                        printdatatable = printdataset
                        printreport.SetDataSource(printdatatable)
                        openreportviewer.Show()
                        printdatatable.Dispose()
                        printdatatable = Nothing
                        printdataset.Clear()
                    End If
                End If
            Else
                errProvider.SetError(txtSupplierOrderNo, "System cannot find the Purchase Order to be printed.")
                Exit Try
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
            ElseIf cboSearch1.Text = "SupplierName" Then
                autocompleteSupplierName(cboSearch2)
                autopopulateSupplierName(cboSearch2)
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
            ElseIf cboSearch3.Text = "SupplierName" Then
                autocompleteSupplierName(cboSearch4)
                autopopulateSupplierName(cboSearch4)
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
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
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
                        If cboSearch2.Text = "" Then
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
                        If cboDate.Text = "OrderDate" Then
                            pagefilter4 = " AND (po.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "po.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        ElseIf cboDate.Text = "TargetDate" Then
                            pagefilter4 = " AND (po.targetdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "po.targetdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        Else
                            pagefilter4 = ""
                        End If
                        spagenum = neutralpage : numofpages = startingpage
                        displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
                        pageSetup3(pagefilter3, pagefilter4)
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
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
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
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
                        If cboSearch2.Text = "" Then
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
                        If cboDate.Text = "OrderDate" Then
                            pagefilter4 = " AND (po.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "po.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        ElseIf cboDate.Text = "TargetDate" Then
                            pagefilter4 = " AND (po.targetdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "po.targetdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        Else
                            pagefilter4 = ""
                        End If
                        spagenum = neutralpage : numofpages = startingpage
                        displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
                        pageSetup3(pagefilter3, pagefilter4)
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
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
                displaySupplierOrderList(spagenum)
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
                displaySupplierOrderList(spagenum)
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
                displaySupplierOrderList(spagenum)
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
                displaySupplierOrderList(spagenum)
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
                            displaySupplierOrderList(spagenum)
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

    Private Sub dgSupplierOrderItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgSupplierOrderItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgSupplierOrderItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgSupplierOrderItems.BeginEdit(True)
                Else
                    dgSupplierOrderItems.EndEdit()
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

    Private Sub dgSupplierOrderList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgSupplierOrderList.DataError
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
                dgSupplierOrderList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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

    Private Sub dgSupplierOrderItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgSupplierOrderItems.DataError
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
                dgSupplierOrderItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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