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

Public Class StockAdjustmentForm
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
    Dim orderno As String
    Dim orderid, productcolorsizesid, productid, productbundleid As Integer
    Dim getilid, getrackshelfcolid, getpilocid, getrscid, getorderitemsid, getprodcolorsizeid As Integer
    Dim pcsids, orderIid As Integer

    Public creates As Char = ""
    Public updates As Char = ""
    Public disable As Char = ""
    Public reads As Char = ""

    Public Appcreates As Char = ""
    Public Appupdates As Char = ""
    Public Appdisable As Char = ""
    Public Appreads As Char = ""

    Private Sub StockAdjustment_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            displayStockAdjusmentList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
            getInventorylocid()
            UserRights(Z_PositionID, "Stock Adjustment", creates, updates, disable, reads, Me)
            UserRights(Z_PositionID, "Approve Stock Adjustment", Appcreates, Appupdates, Appdisable, Appreads, Me)
            If reads = "Y" Then
                enableGB(legit, fraud, fraud)
                enableANDvisibleMS(fraud, fraud, fraud, fraud)
            End If
            populateDataGridViewComboBox("SELECT rsc.rackno FROM rackshelfcolumn rsc WHERE rsc.`Status`='Active' AND rsc.OrganizationID=" & Z_OrganizationID & " AND rsc.InventoryLocationID=" & getilid & " GROUP BY rsc.rackno", r_rack, Me)
            populateDataGridViewComboBox("SELECT rsc.shelfno FROM rackshelfcolumn rsc WHERE rsc.`Status`='Active' AND rsc.OrganizationID=" & Z_OrganizationID & " AND rsc.InventoryLocationID=" & getilid & " GROUP BY rsc.shelfno", r_shelf, Me)
            populateDataGridViewComboBox("SELECT rsc.columnno FROM rackshelfcolumn rsc WHERE rsc.`Status`='Active' AND rsc.OrganizationID=" & Z_OrganizationID & " AND rsc.InventoryLocationID=" & getilid & " GROUP BY rsc.columnno", r_column, Me)
            autocompleteProductCode(cboItemCode)
            populateComboBox("SELECT CONCAT(COALESCE(p.productcode,''),'-', COALESCE(pcs.size,''),'-',COALESCE(c.colorname,''),'-',COALESCE(pcs.seasoncode,'')) FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " &
                    "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " ORDER BY p.productcode ", cboItemCode, Me)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub StockAdjustment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub cboItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles cboItemCode.KeyDown
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

    Private Sub chkApproveAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkApproveAll.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If Appupdates = "Y" Then
                If chkApproveAll.Checked = legit Then
                    For Each dgrow As DataGridViewRow In dgStockAdjustmentItems.Rows
                        dgrow.Cells(ci_approved.Index).Value = legit
                    Next
                Else
                    For Each dgrow As DataGridViewRow In dgStockAdjustmentItems.Rows
                        If dgrow.Cells(ci_app.Index).Value <> "Y" Then
                            dgrow.Cells(ci_approved.Index).Value = fraud
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Functions"

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearStockAdjInformation()
            clearAddProductA()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visiblesupplierOrderItems(fraud)
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
            clearStockAdjInformation()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visiblesupplierOrderItems(fraud)
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

    Sub clearStockAdjInformation()
        Try
            txtStockAdjustmentNo.Text = ""
            txtStatus.Text = ""
            txtComments.Text = ""
            dtpStockAdjustmentDate.Value = Now.Date
            txtAdjustedBy.Text = Z_UserName
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearAddProductA()
        Try
            cboItemCode.Text = ""
            cboItemCode.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRecevingOrderItems()
        Try
            chkOtherInfo.Checked = fraud
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearDatagrids()
        Try
            dgStockAdjustmentItems.Rows.Clear()
            dgrackshelfcolumn.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbStockAdjustmentOrderList.Enabled = enable1
            grpStockAdjustmentitems.Enabled = enable2
            gbStockAdjustment.Enabled = enable2
            grpStockAdjrsc.Enabled = enable2
            gbAddProductItem.Enabled = enable2
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

    Sub visiblesupplierOrderItems(ByVal visible1 As Boolean)
        Try
            ci_unitofmeasure.Visible = visible1
            ci_remarks.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub visiblereadonly(ByVal reads As Boolean, ByVal shows As Boolean)
        ci_approved.ReadOnly = reads
        ci_qtyordered.Visible = shows
    End Sub

#End Region

#Region "Click"

    Sub tsrefreshperformclick()
        Try
            errProvider.Clear()
            clearAddProductA()
            clearfields()
            displayStockAdjusmentList(spagenum)
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
            If cboItemCode.Text <> "" Then
                getProdColorSizesID(cboItemCode.Text)
                displayStockAdjustmentItemsAdd(getprodcolorsizeid)
                colorCoding()
                cboItemCode.SelectedItem = Nothing
                cboItemCode.Text = ""
                cboItemCode.Focus()
            Else
                errProvider.SetError(cboItemCode, "Please select item code.")
                cboItemCode.Focus()
                Exit Try
            End If
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
            dtCid = getDataTableForSQL("SELECT COUNT(po.rowid) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype ='{OrderType.SA.ToString()}'")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype ='{OrderType.SA.ToString()}' " &
                            " AND (po.ordernumber LIKE '%" & esearchstring & "%' OR po.status LIKE '%" & esearchstring & "%' OR su.companyname LIKE '%" & esearchstring & "%') ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype ='{OrderType.SA.ToString()}' AND " &
                            "(" & edatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype ='{OrderType.SA.ToString()}' AND " & ecommonstring & " " & edatesearch & " ")
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
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'') AS 'suppliername' FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype ='{OrderType.SA.ToString()}' GROUP BY su.accountno ORDER BY su.accountno ", conn)
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
            Dim cmd As New MySqlCommand("SELECT COALESCE(po.status,'') AS 'postatus' FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype ='{OrderType.SA.ToString()}' GROUP BY po.status ORDER BY po.status ", conn)
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

    Sub autocompleteProductCode(ByVal icombobox As ComboBox)
        Try
            Dim productcode As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT CONCAT(COALESCE(p.productcode,''),'-', COALESCE(pcs.size,''),'-',COALESCE(c.colorname,''),'-',COALESCE(pcs.seasoncode,'')) AS 'productcode' FROM productcolorsizes pcs " &
                        "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " ORDER BY p.productcode ", conn)
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

#End Region

#Region "AutoPopulate"

    Sub autopopulatecboSearch()
        Try
            cboSearch1.Items.Clear()
            cboSearch3.Items.Clear()
            cboSearch1.Items.Add("Status")
            cboSearch3.Items.Add("Status")
            cboSearch1.Items.Add("")
            cboSearch3.Items.Add("")
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
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'') AS 'suppliername' FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype ='{OrderType.SA.ToString()}' GROUP BY su.accountno ORDER BY su.companyname "
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
            Dim sql1 As String = "SELECT COALESCE(po.status,'') AS 'postatus' FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype ='{OrderType.SA.ToString()}' GROUP BY po.status ORDER BY po.status "
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

    Sub displayStockAdjusmentList(ByVal istartpage As Integer)
        Try
            dgStockAdjusmentList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT s.rowid,COALESCE(s.ordernumber,''),DATE_FORMAT(s.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(s.status,''),COALESCE(s.RelatedOrderID,0) FROM orders s LEFT JOIN accounts su ON s.accountid = su.rowid WHERE s.organizationid = " & Z_OrganizationID & $" AND s.ordertype = '{OrderType.SA.ToString()}' " &
                        "ORDER BY s.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgStockAdjusmentList.Rows.Add()
                    dgStockAdjusmentList.Item(s_rowid.Index, n).Value = reader1(0)
                    dgStockAdjusmentList.Item(s_StockNo.Index, n).Value = reader1(1)
                    dgStockAdjusmentList.Item(s_stockadjdate.Index, n).Value = reader1(2)
                    dgStockAdjusmentList.Item(s_stockadjstatus.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgStockAdjusmentList.Columns("s_StockNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjusmentList.Columns("s_stockadjdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjusmentList.Columns("s_stockadjstatus").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgStockAdjusmentList.Rows.Count <> 0 Then
                dgStockAdjusmentList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgStockAdjusmentList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT s.rowid,COALESCE(s.ordernumber,''),DATE_FORMAT(s.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(s.status,''),COALESCE(s.RelatedOrderID,0) FROM orders s LEFT JOIN accounts su ON s.accountid = su.rowid WHERE s.organizationid = " & Z_OrganizationID & $" AND s.ordertype ='{OrderType.SA.ToString()}' AND " &
                        "(s.ordernumber LIKE '%" & isearchphrase & "%' OR s.status LIKE '%" & isearchphrase & "%' OR cu.companyname LIKE '%" & isearchphrase & "%') " &
                        "ORDER BY s.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgStockAdjusmentList.Rows.Add()
                    dgStockAdjusmentList.Item(s_rowid.Index, n).Value = reader1(0)
                    dgStockAdjusmentList.Item(s_StockNo.Index, n).Value = reader1(1)
                    dgStockAdjusmentList.Item(s_stockadjdate.Index, n).Value = reader1(2)
                    dgStockAdjusmentList.Item(s_stockadjstatus.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgStockAdjusmentList.Columns("s_StockNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjusmentList.Columns("s_stockadjdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjusmentList.Columns("s_stockadjstatus").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgStockAdjusmentList.Rows.Count <> 0 Then
                dgStockAdjusmentList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayDateSearch(ByVal istartpage As Integer, ByVal idatesearch As String)
        Try
            dgStockAdjusmentList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(s.ordernumber,''),DATE_FORMAT(s.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(s.status,''),COALESCE(s.RelatedOrderID,0) FROM orders s LEFT JOIN accounts su ON s.accountid = su.rowid WHERE s.organizationid = " & Z_OrganizationID & $" AND s.ordertype ='{OrderType.SA.ToString()}' AND " &
                        "(" & idatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                        "" & idatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) " &
                        "GROUP BY s.rowid ORDER BY s.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgStockAdjusmentList.Rows.Add()
                    dgStockAdjusmentList.Item(s_rowid.Index, n).Value = reader1(0)
                    dgStockAdjusmentList.Item(s_StockNo.Index, n).Value = reader1(1)
                    dgStockAdjusmentList.Item(s_stockadjdate.Index, n).Value = reader1(2)
                    dgStockAdjusmentList.Item(s_stockadjstatus.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgStockAdjusmentList.Columns("s_StockNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjusmentList.Columns("s_stockadjdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjusmentList.Columns("s_stockadjstatus").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgStockAdjusmentList.Rows.Count <> 0 Then
                dgStockAdjusmentList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal idatesearch As String, ByVal istartpage As Integer)
        Try
            dgStockAdjusmentList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT s.rowid,COALESCE(s.ordernumber,''),DATE_FORMAT(s.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                        "COALESCE(s.status,''),COALESCE(s.RelatedOrderID,0) FROM orders s LEFT JOIN accounts su ON s.accountid = su.rowid WHERE s.organizationid = " & Z_OrganizationID & $" AND s.ordertype ='{OrderType.SA.ToString()}' " &
                        " AND " & icommonphrase & " " & idatesearch & " ORDER BY s.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgStockAdjusmentList.Rows.Add()
                    dgStockAdjusmentList.Item(s_rowid.Index, n).Value = reader1(0)
                    dgStockAdjusmentList.Item(s_StockNo.Index, n).Value = reader1(1)
                    dgStockAdjusmentList.Item(s_stockadjdate.Index, n).Value = reader1(2)
                    dgStockAdjusmentList.Item(s_stockadjstatus.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgStockAdjusmentList.Columns("s_StockNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjusmentList.Columns("s_stockadjdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjusmentList.Columns("s_stockadjstatus").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgStockAdjusmentList.Rows.Count <> 0 Then
                dgStockAdjusmentList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayStockAdjustmentInformation(ByVal isupplierorderid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String
            sql1 = "SELECT COALESCE(s.ordernumber),DATE_FORMAT(s.orderdate,'%d-%b-%Y'),DATE_FORMAT(s.targetdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,'')),'')," &
                 "COALESCE(s.comments,''),COALESCE(s.status,''),COALESCE(s.ReceivedBy,'') FROM orders s " &
                 "LEFT JOIN accounts su ON s.accountid = su.rowid " &
                 "WHERE s.rowid = " & isupplierorderid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtStockAdjustmentNo.Text = reader1(0)
                    dtpStockAdjustmentDate.Text = reader1(1)
                    txtComments.Text = reader1(4)
                    txtStatus.Text = reader1(5)
                    txtAdjustedBy.Text = reader1(6)
                Else
                    txtStatus.Text = "For Approval"
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayStockAdjustmentItems(ByVal isupplierorderid As Integer)
        Try
            dgStockAdjustmentItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(ci.productbundleid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(b.bundlename,''),COALESCE(c.colorname,''),COALESCE(pcs.size,'')," &
                    "COALESCE(pcs.seasoncode,''),COALESCE(ci.unitofmeasure,''),COALESCE(ci.qtyordered,0),COALESCE(ci.srp,0.0),COALESCE(pcs.sku,''),COALESCE(b.sku,''),COALESCE(ci.itemtype,''),COALESCE(ci.remarks,''), COALESCE(ci.qtyreceived,0),COALESCE(ci.approval,'N'),COALESCE(SUM(rsc.QtyApplied),0) FROM orderitems ci " &
                    "LEFT JOIN productbundles b ON ci.productbundleid = b.rowid LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " &
                    "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN rscorderitems rsc ON rsc.OrderItemsID = ci.RowID WHERE ci.orderid = " & isupplierorderid & " AND ci.organizationid = " & Z_OrganizationID & " " &
                    "AND ci.status != 'Inactive' AND ci.itemtype != 'BI' GROUP BY pcs.rowid ORDER BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgStockAdjustmentItems.Rows.Add()
                    dgStockAdjustmentItems.Item(ci_seqno.Index, n).Value = seqno
                    dgStockAdjustmentItems.Item(ci_rowid.Index, n).Value = reader1(0)
                    dgStockAdjustmentItems.Item(ci_pcsrowid.Index, n).Value = reader1(1)
                    dgStockAdjustmentItems.Item(ci_bid.Index, n).Value = reader1(2)
                    dgStockAdjustmentItems.Item(ci_colorvalue.Index, n).Value = reader1(3)
                    If CInt(reader1(1)) <> 0 Then
                        dgStockAdjustmentItems.Item(ci_productcode.Index, n).Value = reader1(4)
                    Else
                        dgStockAdjustmentItems.Item(ci_productcode.Index, n).Value = reader1(5)
                    End If
                    dgStockAdjustmentItems.Item(ci_colorname.Index, n).Value = reader1(6)
                    dgStockAdjustmentItems.Item(ci_size.Index, n).Value = reader1(7)
                    dgStockAdjustmentItems.Item(ci_seasoncode.Index, n).Value = reader1(8)
                    dgStockAdjustmentItems.Item(ci_unitofmeasure.Index, n).Value = reader1(9)
                    dgStockAdjustmentItems.Item(ci_qtyordered.Index, n).Value = reader1(10)
                    dgStockAdjustmentItems.Item(ci_srp.Index, n).Value = reader1(11)
                    If CInt(reader1(1)) <> 0 Then
                        dgStockAdjustmentItems.Item(ci_sku.Index, n).Value = reader1(12)
                    Else
                        dgStockAdjustmentItems.Item(ci_sku.Index, n).Value = reader1(13)
                    End If
                    dgStockAdjustmentItems.Item(ci_remarks.Index, n).Value = reader1(15)
                    dgStockAdjustmentItems.Item(ci_qtyreceived.Index, n).Value = reader1(16)
                    dgStockAdjustmentItems.Item(ci_app.Index, n).Value = reader1(17)
                    If reader1(17) = "Y" Then
                        dgStockAdjustmentItems.Item(ci_approved.Index, n).Value = True
                    Else
                        dgStockAdjustmentItems.Item(ci_approved.Index, n).Value = False
                    End If
                    If Appcreates = "Y" Or Appupdates = "Y" Then
                        ci_approved.ReadOnly = False
                    Else
                        ci_approved.ReadOnly = True
                    End If
                    If reader1(17) = "Y" Then
                        ci_approved.ReadOnly = True
                    End If
                    If reader1(14) = "A" Then
                        dgStockAdjustmentItems.Rows(n).DefaultCellStyle.BackColor = Color.BurlyWood
                    End If
                    dgStockAdjustmentItems.Item(ci_qtystocked.Index, n).Value = reader1(18)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgStockAdjustmentItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_approved").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_qtystocked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgStockAdjustmentItems.Rows.Count <> 0 Then
                dgStockAdjustmentItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayStockAdjustmentItemsAdd(ByVal ipcsid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            'Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(ci.productbundleid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(b.bundlename,''),COALESCE(c.colorname,''),COALESCE(pcs.size,'')," & _
            '        "COALESCE(pcs.seasoncode,''),COALESCE(ci.unitofmeasure,''),COALESCE(ci.qtyordered,0),COALESCE(ci.srp,0.0),COALESCE(pcs.sku,''),COALESCE(b.sku,''),COALESCE(ci.itemtype,''),COALESCE(ci.remarks,''), COALESCE(ci.qtyreceived,0),COALESCE(ci.approval,'N'),COALESCE(SUM(rsc.QtyApplied),0) FROM orderitems ci " & _
            '        "LEFT JOIN productbundles b ON ci.productbundleid = b.rowid LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
            '        "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN rscorderitems rsc ON rsc.OrderItemsID = ci.RowID WHERE ci.ProductColorSizeID=" & pcsid & " AND ci.organizationid = " & Z_OrganizationID & " " & _
            '        "AND ci.status != 'Inactive' AND ci.itemtype != 'BI' GROUP BY pcs.RowID ORDER BY ci.rowid "
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(p.unitofmeasure,''),COALESCE(p.unitprice,0.0),COALESCE(pcs.sku,'') FROM productcolorsizes pcs " &
                    "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.rowid = " & ipcsid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = dgStockAdjustmentItems.Rows.Count
            ' Dim seqno As Integer = 1
            Dim seqno As Integer = dgStockAdjustmentItems.Rows.Count + 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgStockAdjustmentItems.Rows.Add()
                    dgStockAdjustmentItems.Item(ci_seqno.Index, n).Value = seqno
                    'dgStockAdjustmentItems.Item(ci_rowid.Index, n).Value = reader1(0)
                    dgStockAdjustmentItems.Item(ci_rowid.Index, n).Value = 0
                    'dgStockAdjustmentItems.Item(ci_pcsrowid.Index, n).Value = reader1(1)
                    dgStockAdjustmentItems.Item(ci_pcsrowid.Index, n).Value = reader1(0)
                    ' dgStockAdjustmentItems.Item(ci_bid.Index, n).Value = reader1(2)
                    dgStockAdjustmentItems.Item(ci_bid.Index, n).Value = 0
                    'dgStockAdjustmentItems.Item(ci_colorvalue.Index, n).Value = reader1(3)
                    dgStockAdjustmentItems.Item(ci_colorvalue.Index, n).Value = reader1(1)
                    'If CInt(reader1(1)) <> 0 Then
                    '    dgStockAdjustmentItems.Item(ci_productcode.Index, n).Value = reader1(4)
                    'Else
                    '    dgStockAdjustmentItems.Item(ci_productcode.Index, n).Value = reader1(5)
                    'End If
                    dgStockAdjustmentItems.Item(ci_productcode.Index, n).Value = reader1(2)
                    dgStockAdjustmentItems.Item(ci_colorname.Index, n).Value = reader1(3)
                    ' dgStockAdjustmentItems.Item(ci_size.Index, n).Value = reader1(7)
                    dgStockAdjustmentItems.Item(ci_size.Index, n).Value = reader1(4)
                    ' dgStockAdjustmentItems.Item(ci_seasoncode.Index, n).Value = reader1(8)
                    dgStockAdjustmentItems.Item(ci_seasoncode.Index, n).Value = reader1(5)
                    'dgStockAdjustmentItems.Item(ci_unitofmeasure.Index, n).Value = reader1(9)
                    dgStockAdjustmentItems.Item(ci_unitofmeasure.Index, n).Value = reader1(6)
                    ' dgStockAdjustmentItems.Item(ci_qtyordered.Index, n).Value = reader1(10)
                    dgStockAdjustmentItems.Item(ci_qtyordered.Index, n).Value = 0
                    'dgStockAdjustmentItems.Item(ci_srp.Index, n).Value = reader1(11)
                    dgStockAdjustmentItems.Item(ci_srp.Index, n).Value = reader1(7)
                    'If CInt(reader1(1)) <> 0 Then
                    '    dgStockAdjustmentItems.Item(ci_sku.Index, n).Value = reader1(12)
                    'Else
                    '    dgStockAdjustmentItems.Item(ci_sku.Index, n).Value = reader1(13)
                    'End If
                    dgStockAdjustmentItems.Item(ci_sku.Index, n).Value = reader1(8)
                    'If reader1(14) = "A" Then
                    '    dgStockAdjustmentItems.Rows(n).DefaultCellStyle.BackColor = Color.BurlyWood
                    'End If
                    'dgStockAdjustmentItems.Item(ci_remarks.Index, n).Value = reader1(15)
                    dgStockAdjustmentItems.Item(ci_remarks.Index, n).Value = ""
                    'dgStockAdjustmentItems.Item(ci_qtyreceived.Index, n).Value = reader1(16)
                    dgStockAdjustmentItems.Item(ci_qtyreceived.Index, n).Value = 0
                    'dgStockAdjustmentItems.Item(ci_app.Index, n).Value = reader1(17)
                    dgStockAdjustmentItems.Item(ci_app.Index, n).Value = ""
                    'If reader1(17) = "Y" Then
                    '    dgStockAdjustmentItems.Item(ci_approved.Index, n).Value = True
                    'Else
                    '    dgStockAdjustmentItems.Item(ci_approved.Index, n).Value = False
                    'End If
                    dgStockAdjustmentItems.Item(ci_approved.Index, n).Value = fraud
                    'dgStockAdjustmentItems.Item(ci_qtystocked.Index, n).Value = reader1(18)
                    dgStockAdjustmentItems.Item(ci_qtystocked.Index, n).Value = 0
                    If Appcreates = "Y" Or Appupdates = "Y" Then
                        ci_approved.ReadOnly = False
                    Else
                        ci_approved.ReadOnly = True
                    End If
                    'seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgStockAdjustmentItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_approved").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockAdjustmentItems.Columns("ci_qtystocked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgStockAdjustmentItems.Rows.Count <> 0 Then
                dgStockAdjustmentItems.CurrentRow.Selected = fraud
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayProductRSC(ByVal pcsid As Integer)
        Try
            dgrackshelfcolumn.Rows.Clear()
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(pil.totalavailableqty,0),COALESCE(r.rackno,0),COALESCE(r.shelfno,0),COALESCE(r.columnno,0),COALESCE(pil.rowid,0),COALESCE(SUM(rsc.qtyapplied),0),COALESCE(rsc.rowid,0),COALESCE(COALESCE(rsc.lastupd,rsc.created),''),COALESCE(pil.totalallocatedqty,0) FROM productinventorylocation pil " &
                    "LEFT JOIN rackshelfcolumn r ON pil.rackshelfcolumnid = r.rowid LEFT JOIN rscorderitems rsc ON pil.rowid = rsc.prodinventorylocid WHERE pil.productcolorsizeid = " & pcsid & " and pil.organizationid = " & Z_OrganizationID & " ORDER BY r.rackno,r.columnno,r.shelfno "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    If Not IsDBNull(reader1(4)) Then
                        If CInt(reader1(4)) <> 0 Then
                            dgrackshelfcolumn.Rows.Add()
                            dgrackshelfcolumn.Item(r_qtystock.Index, n).Value = reader1(0)
                            dgrackshelfcolumn.Item(r_rack.Index, n).Value = reader1(1)
                            dgrackshelfcolumn.Item(r_shelf.Index, n).Value = reader1(2)
                            dgrackshelfcolumn.Item(r_column.Index, n).Value = reader1(3)
                            dgrackshelfcolumn.Item(r_qtyapply.Index, n).Value = 0 'CInt(reader1(5))
                            dgrackshelfcolumn.Item(r_prodinvlocinventoryid.Index, n).Value = reader1(4)
                            dgrackshelfcolumn.Item(r_rscid.Index, n).Value = reader1(6)
                            dgrackshelfcolumn.Item(r_qtystocked.Index, n).Value = CInt(reader1(5))
                            dgrackshelfcolumn.Item(r_datestocked.Index, n).Value = reader1(7)
                            dgrackshelfcolumn.Item(r_qtyallocated.Index, n).Value = reader1(8)
                            dgrackshelfcolumn.Rows(n).Cells("r_rack").ReadOnly = True
                            dgrackshelfcolumn.Rows(n).Cells("r_shelf").ReadOnly = True
                            dgrackshelfcolumn.Rows(n).Cells("r_column").ReadOnly = True
                            n = n + 1
                        End If
                    End If
                End If
            End While
            reader1.Close()
            dgrackshelfcolumn.Columns("r_qtystock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgrackshelfcolumn.Columns("r_rack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgrackshelfcolumn.Columns("r_shelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgrackshelfcolumn.Columns("r_column").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgrackshelfcolumn.Columns("r_qtyapply").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgrackshelfcolumn.Columns("r_qtystocked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgrackshelfcolumn.Columns("r_datestocked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgrackshelfcolumn.Columns("r_qtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgrackshelfcolumn.Rows.Count <> 0 Then
                dgrackshelfcolumn.CurrentRow.Selected = fraud
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

#End Region

#End Region

#Region "Update"

    Sub updatestatusToApproved(ByVal rowid As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim cApproved As Integer
            For x = 0 To dgStockAdjustmentItems.Rows.Count - 1
                If dgStockAdjustmentItems.Rows(x).Cells("ci_approved").Value = legit Then
                    cApproved = cApproved + 1
                End If
            Next
            If cApproved = dgStockAdjustmentItems.Rows.Count Then
                DirectCommand("UPDATE orders SET `status` = 'Approved' WHERE rowid = " & rowid & "")
                'Else
                '    DirectCommand("Update Orders set Status = 'For Approval' where OrganizationID=" & Z_OrganizationID & " AND rowid=" & rowid & "")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub

    Sub updatestatusofrelatedno(ByVal rowid As Integer, ByVal stat As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            DirectCommand("Update Orders set Status = """ & stat & """ where OrganizationID=" & Z_OrganizationID & " AND rowid=" & rowid & "")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub

#End Region

#Region "GETID"

    Sub getInventorylocid()
        Try
            getilid = 0
            Dim ID As String = getStringItem("Select RowID from inventorylocations Where Type='Main' And OrganizationID = " & Z_OrganizationID & "")
            getilid = Val(ID)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getrackid(ByVal rack As String, ByVal shelf As String, ByVal column As String)
        Try
            getrackshelfcolid = 0
            Dim ID As String = getStringItem("Select RowID from rackshelfcolumn Where InventoryLocationID=" & getilid & " AND RackNo=""" & rack & """ And ShelfNo=""" & shelf & """  AND ColumnNo=""" & column & """ And OrganizationID = " & Z_OrganizationID & "")
            getrackshelfcolid = Val(ID)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getProdColorSizesID(ByVal itemcode As String)
        Try
            getorderitemsid = 0
            getprodcolorsizeid = 0
            Dim dt As New DataTable
            dt = getDataTableForSQL("SELECT pcs.rowid FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " &
                            "LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " AND CONCAT(COALESCE(p.ProductCode,''),'-', COALESCE(pcs.Size,''),'-',COALESCE(c.ColorName,''),'-',COALESCE(pcs.SeasonCode,'')) = """ & itemcode & """ ")
            If dt.Rows.Count <> 0 Then
                getorderitemsid = dt.Rows(0)("rowid")
                getprodcolorsizeid = dt.Rows(0)("rowid")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getProdinvLocID(ByVal prodcolorsizes As Integer)
        Try
            getpilocid = 0
            Dim ID As String = getStringItem("Select RowID from productinventorylocation where RackShelfColumnID=" & getrackshelfcolid & " And ProductColorSizeID=" & prodcolorsizes & " AND organizationid=" & Z_OrganizationID & "")
            getpilocid = Val(ID)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getrscOrderitemsid(ByVal orderitemsid As Integer)
        Try
            getrscid = 0
            Dim ID As String = getStringItem("Select RowID from rscorderitems where ProdInventoryLocID=" & getpilocid & " And OrderItemsID=" & orderitemsid & " AND organizationid=" & Z_OrganizationID & "")
            getrscid = Val(ID)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

#Region "Menustrip"

    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Try
            errProvider.Clear()
            dgStockAdjustmentItems.CommitEdit(legit) : dgStockAdjustmentItems.ClearSelection() ' dgStockAdjustmentItems.CurrentCell = Nothing
            dgrackshelfcolumn.CommitEdit(legit) : dgrackshelfcolumn.ClearSelection() : dgrackshelfcolumn.CurrentCell = Nothing
            If cue = "New" Then
                'If creates = "N" Then
                '    MessageBox.Show("You are not allowed to create new record. Please check your user rights.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Try
                'End If
                If creates = "N" And updates = "N" Then
                    MessageBox.Show("You are not allowed to update a record. Please check your user rights.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If
                'If LTrim(txtStockAdjustmentNo.Text) <> "" Then
                '    getOrderIDSupB(txtStockAdjustmentNo.Text, "Stock Adj.", Me)
                '    orderid = globalorderid
                '    If orderid <> 0 Then
                '        errProvider.SetError(txtStockAdjustmentNo, "Stock Adj. no. and supplier name has been created already, please type a new one.")
                '        Exit Try
                '    End If

                'Else
                '    errProvider.SetError(txtStockAdjustmentNo, "Please enter the Stock Adj. no.")
                '    Exit Try
                'End If
                If txtAdjustedBy.Text = "" Then
                    errProvider.SetError(txtAdjustedBy, "Please enter the name of a person adjusted the stock")
                    Exit Try
                End If
            ElseIf cue = "Edit" Then
                'If updates = "N" Then
                '    MessageBox.Show("You are not allowed to update a record. Please check your user rights.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Try
                'End If
                If creates = "N" And updates = "N" Then
                    MessageBox.Show("You are not allowed to update a record. Please check your user rights.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If
                If dgStockAdjusmentList.Rows.Count <> 0 Then
                    'If LTrim(txtStockAdjustmentNo.Text) <> "" Then

                    '    getOrderIDSupA(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), txtStockAdjustmentNo.Text, "Stock Adj.", Me)
                    '    orderid = globalorderid
                    '    If orderid <> 0 Then
                    '        errProvider.SetError(txtStockAdjustmentNo, "Stock Adj. no. been created already, please type a new one.")
                    '        Exit Try
                    '    End If

                    'Else
                    '    errProvider.SetError(txtStockAdjustmentNo, "Please enter the Stock Adj. no.")
                    '    Exit Try
                    'End If
                    If txtAdjustedBy.Text = "" Then
                        errProvider.SetError(txtAdjustedBy, "Please enter the name of a person adjusted the stock")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtStockAdjustmentNo, "System cannot find the existing Stock Adjusment.")
                    Exit Try
                End If
                If dgStockAdjusmentList.Rows.Count <> 0 Then
                    getOrderStatus(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Me)
                    If globalorderstatus <> txtStatus.Text Then
                        MessageBox.Show("This Stock Adj. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                End If
            End If
            If dgStockAdjusmentList.Rows.Count = 0 Then
                errProvider.SetError(cboItemCode, "Please add an item first to be adjusted.")
                Exit Try
            End If
            myModule.systemerrorfound = False
            If MessageBox.Show("Would you like to save the changes on this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If cue = "New" Then
                    'getOrderIDSupB(txtStockAdjustmentNo.Text, "Stock Adj.", Me)
                    'orderid = globalorderid
                    'If orderid <> 0 Then
                    '    errProvider.SetError(txtStockAdjustmentNo, "Stock Adj. no. has been created already, please type a new one.")
                    '    Exit Try
                    'End If
                    getOrderNo(globaliordertype:=OrderType.SA.ToString(), Me)
                    M_I_Orders(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, DBNull.Value, globalorderno, OrderType:=OrderType.SA.ToString(),
                            dtpStockAdjustmentDate.Value, DBNull.Value, "", txtComments.Text, "For Approval", 0, txtAdjustedBy.Text, DBNull.Value, DBNull.Value, DBNull.Value, "", "", "", "", Nothing, Me)
                    orderid = globalorderidsp
                    If dgStockAdjustmentItems.Rows.Count <> 0 Then
                        For a = 0 To dgStockAdjustmentItems.Rows.Count - 1
                            If myModule.systemerrorfound = False Then
                                If IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                    If CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                        getTotalQtyAvailableA(CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                        M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, Nothing, orderid, CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value,
                                                    If(IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyordered").Value), 0), globaltotalqtyavailable, "S",
                                                    "" & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_seasoncode").Value) & "",
                                                    CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_sku").Value), CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_srp").Value), CDec(dgStockAdjustmentItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active",
                                                    If(IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyreceived").Value), 0), If(dgStockAdjustmentItems.Rows(a).Cells("ci_approved").Value = False, "N", "Y"), 0, "", Me)
                                    End If
                                End If
                            Else
                                Exit Sub
                            End If
                        Next
                        'displayStockAdjustmentItems(orderid)
                        'If dgStockAdjustmentItems.CurrentRow.Cells("ci_app").Value = "Y" Then
                        '    For x = 0 To dgrackshelfcolumn.Rows.Count - 1
                        '        getrackid(dgrackshelfcolumn.Rows(x).Cells("r_rack").Value, dgrackshelfcolumn.Rows(x).Cells("r_shelf").Value, dgrackshelfcolumn.Rows(x).Cells("r_column").Value)
                        '        getProdinvLocID(pcsids)
                        '        getrscOrderitemsid(orderIid)
                        '        If myModule.systemerrorfound = False Then
                        '            If dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value <> 0 Then
                        '                If getpilocid = 0 Then
                        '                    M_I_productinventorylocation(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, getrackshelfcolid, pcsids, _
                        '                              If(IsNumeric(dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value), CInt(dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value), 0), 0, 0, 0, 0, 0, 0, 0, 0, Me)
                        '                    getrackid(dgrackshelfcolumn.Rows(x).Cells("r_rack").Value, dgrackshelfcolumn.Rows(x).Cells("r_shelf").Value, dgrackshelfcolumn.Rows(x).Cells("r_column").Value)
                        '                    getProdinvLocID(pcsids)
                        '                    M_I_rscorderitems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, getpilocid, orderIid, dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Active", Me)
                        '                    M_I_productmovementhistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Nothing, pcsids, getpilocid, Nothing, dgrackshelfcolumn.Rows(x).Cells("r_qtystock").Value, dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Stock Adjustment", "TotalAvailableQty", "", Me)
                        '                Else
                        '                    DirectCommand("Update productinventorylocation set TotalAvailableQty = " & CInt(dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value) & " where rowid=" & getpilocid)
                        '                    If getrscid = 0 Then
                        '                        M_I_rscorderitems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, getpilocid, orderIid, dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Active", Me)
                        '                    Else
                        '                        M_U_rscorderitems(dgrackshelfcolumn.Rows(x).Cells("r_rscid").Value, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Active", Me)
                        '                    End If
                        '                    M_I_productmovementhistoryStockAdjustment(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Nothing, pcsids, getpilocid, Nothing, dgrackshelfcolumn.Rows(x).Cells("r_qtystock").Value, dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Stock Adjustment", "TotalAvailableQty", "", Me)
                        '                End If
                        '            End If
                        '        Else
                        '            Exit Sub
                        '        End If
                        '    Next
                        'End If
                    End If
                    updatestatusToApproved(orderid)
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                    End If
                ElseIf cue = "Edit" Then
                    'If txtStatus.Text = "Approved" Then
                    '    MessageBox.Show("This is an Approved Stock Adjustment You can't change this", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Me.Cursor = Cursors.Default
                    '    Exit Sub
                    'End If
                    If dgStockAdjusmentList.Rows.Count <> 0 Then
                        'getOrderIDSupA(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), txtStockAdjustmentNo.Text, "Stock Adj.", Me)
                        'orderid = globalorderid
                        'If orderid <> 0 Then
                        '    errProvider.SetError(txtStockAdjustmentNo, "Stock Adj. no.has been created already, please type a new one.")
                        '    Exit Try
                        'End If
                        M_U_Orders(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Nothing, txtStockAdjustmentNo.Text, dtpStockAdjustmentDate.Value,
                                        Nothing, txtComments.Text, 0, txtAdjustedBy.Text, DBNull.Value, DBNull.Value, "", "", "", "", Me)
                        If dgStockAdjustmentItems.Rows.Count <> 0 Then
                            For a = 0 To dgStockAdjustmentItems.Rows.Count - 1
                                If myModule.systemerrorfound = False Then
                                    If IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                        If CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                            If IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_rowid").Value) Then
                                                If CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                                                    getTotalQtyAvailableA(CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                    M_U_OrderItems(CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyreceived").Value), 0),
                                                             0, CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_remarks").Value), "", If(dgStockAdjustmentItems.Rows(a).Cells("ci_approved").Value = False, "N", "Y"), Me)
                                                Else
                                                    getTotalQtyAvailableA(CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                    M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, Nothing, CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value,
                                                                If(IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyordered").Value), 0), globaltotalqtyavailable, "S",
                                                                "" & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_seasoncode").Value) & "",
                                                                CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_sku").Value), CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_srp").Value), CDec(dgStockAdjustmentItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active",
                                                                If(IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyreceived").Value), 0), If(dgStockAdjustmentItems.Rows(a).Cells("ci_approved").Value = False, "N", "Y"), 0, "", Me)
                                                End If
                                            Else
                                                getTotalQtyAvailableA(CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, Nothing, CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value,
                                                            If(IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyordered").Value), 0), globaltotalqtyavailable, "S",
                                                            "" & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_seasoncode").Value) & "",
                                                            CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_sku").Value), CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgStockAdjustmentItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_srp").Value), CDec(dgStockAdjustmentItems.Rows(a).Cells("ci_srp").Value), 0.0), "Active",
                                                            If(IsNumeric(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgStockAdjustmentItems.Rows(a).Cells("ci_qtyreceived").Value), 0), If(dgStockAdjustmentItems.Rows(a).Cells("ci_approved").Value = False, "N", "Y"), 0, "", Me)
                                            End If
                                        End If
                                    End If
                                Else
                                    Exit Sub
                                End If
                            Next
                            'displayStockAdjustmentItems(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value))
                            If dgStockAdjustmentItems.CurrentRow.Cells("ci_app").Value = "Y" Or dgStockAdjustmentItems.CurrentRow.Cells("ci_approved").Value = legit Then
                                For x = 0 To dgrackshelfcolumn.Rows.Count - 1
                                    getrackid(dgrackshelfcolumn.Rows(x).Cells("r_rack").Value, dgrackshelfcolumn.Rows(x).Cells("r_shelf").Value, dgrackshelfcolumn.Rows(x).Cells("r_column").Value)
                                    getProdinvLocID(pcsids)
                                    ' getrscOrderitemsid(orderIid)
                                    If getrackshelfcolid <> 0 Then
                                        If myModule.systemerrorfound = False Then
                                            If IsNumeric(dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value) Then
                                                If CInt(dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value) > neutralpage Or CInt(dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value) = neutralpage Then
                                                    If getpilocid = 0 Then
                                                        M_I_productinventorylocation(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, getrackshelfcolid, pcsids,
                                                                  If(IsNumeric(dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value), CInt(dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value), 0), 0, 0, 0, 0, 0, 0, 0, 0, Me)
                                                        getrackid(dgrackshelfcolumn.Rows(x).Cells("r_rack").Value, dgrackshelfcolumn.Rows(x).Cells("r_shelf").Value, dgrackshelfcolumn.Rows(x).Cells("r_column").Value)
                                                        getProdinvLocID(pcsids)
                                                        M_I_rscorderitems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, getpilocid, If(orderIid = 0, DBNull.Value, orderIid), dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Active", Me)
                                                        M_I_productmovementhistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Nothing, pcsids, getpilocid, Nothing, dgrackshelfcolumn.Rows(x).Cells("r_qtystock").Value, dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Stock Adjustment", "TotalAvailableQty", "", Me)
                                                    Else
                                                        DirectCommand("Update productinventorylocation set TotalAvailableQty = " & CInt(dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value) & " where rowid=" & getpilocid)
                                                        M_I_rscorderitems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, getpilocid, If(orderIid = 0, DBNull.Value, orderIid), dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Active", Me)
                                                        'If getrscid = 0 Then
                                                        '    M_I_rscorderitems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, getpilocid, orderIid, dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Active", Me)
                                                        'Else
                                                        '    M_U_rscorderitems(dgrackshelfcolumn.Rows(x).Cells("r_rscid").Value, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Active", Me)
                                                        'End If
                                                        M_I_productmovementhistoryStockAdjustment(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Nothing, pcsids, getpilocid, Nothing, dgrackshelfcolumn.Rows(x).Cells("r_qtystock").Value, dgrackshelfcolumn.Rows(x).Cells("r_qtyapply").Value, "Stock Adjustment", "TotalAvailableQty", "", Me)
                                                    End If
                                                End If
                                            End If
                                        Else
                                            Exit Sub
                                        End If
                                    End If
                                Next
                            End If
                        End If
                        updatestatusToApproved(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value))
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                        End If
                    End If
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

    Private Sub msCancel_Click(sender As Object, e As EventArgs) Handles msCancel.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgStockAdjusmentList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearAddProductA()
                clearStockAdjInformation()
                clearDatagrids()
                visiblesupplierOrderItems(fraud)
                If dgStockAdjusmentList.Rows.Count <> 0 Then
                    dgStockAdjusmentList.CurrentRow.Selected = legit
                End If
                displayStockAdjustmentInformation(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value)
                displayStockAdjustmentItems(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value)
                'If dgStockAdjusmentList.CurrentRow.Cells("s_stockadjstatus").Value <> "Cancelled" Then
                '    updatestatusToApproved(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value))
                'End If
                'displayStockAdjustmentInformation(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value)
                colorCoding()
                If txtStatus.Text = "For Approval" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Approved" Then
                    enableGB(legit, fraud, fraud)
                    grpStockAdjustmentitems.Enabled = True
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                End If
                txtStockAdjustmentNo.Focus()
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

    Private Sub msNew_Click(sender As Object, e As EventArgs) Handles msNew.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If creates = "N" And updates = "N" Then
                MessageBox.Show("You are not allowed to create new record. Please check your user rights.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            End If
            cue = "New"
            errProvider.Clear()
            clearStockAdjInformation()
            clearDatagrids()
            enableGB(fraud, legit, legit)
            visiblesupplierOrderItems(fraud)
            enableANDvisibleMS(fraud, legit, legit, fraud)
            If dgStockAdjusmentList.Rows.Count <> 0 Then
                dgStockAdjusmentList.CurrentRow.Selected = False
            End If
            getOrderNo(globaliordertype:=OrderType.SA.ToString(), Me)
            txtStockAdjustmentNo.Text = CStr(globalorderno)
            txtStatus.Text = "For Approval"
            UserRights(Z_PositionID, "Stock Adjustment", creates, updates, disable, reads, Me)
            UserRights(Z_PositionID, "Approve Stock Adjustment", Appcreates, Appupdates, Appdisable, Appreads, Me)
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

    Private Sub msOrder_Click(sender As Object, e As EventArgs) Handles msOrder.Click
        Try
            myModule.systemerrorfound = False
            If dgStockAdjusmentList.Rows.Count <> 0 Then
                getOrderStatus(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Me)
                If globalorderstatus <> txtStatus.Text Then
                    MessageBox.Show("This Stock Adj. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                ElseIf globalorderstatus = "For Approval" Then
                    If MessageBox.Show("Would you like to cancel?", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgStockAdjusmentList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This Stock Adj. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        U_OrderStatus(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
                        'updatestatusofrelatedno(gloPoNo, "Received")
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Cancelled", "Cancel", lblsavemsg, -15, -65)
                            tsrefreshperformclick()
                        End If
                    End If
                ElseIf globalorderstatus = "Cancelled" Then
                    If MessageBox.Show("Would you like to re-open this order?", "Opening", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgStockAdjusmentList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This Stock Adj. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        'updatestatusofrelatedno(gloPoNo, "Received")
                        U_OrderStatus(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "For Approval", Me)
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

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.SAdjForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Colors"

    Sub colorCoding()
        Try
            If dgStockAdjustmentItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgStockAdjustmentItems.Rows.Count - 1
                    'If dgSupplierOrderItems.Rows(i).Cells(ci_type.Index).Value = "B" Then
                    '    dgSupplierOrderItems.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
                    'Else
                    If CStr(dgStockAdjustmentItems.Rows(i).Cells("ci_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgStockAdjustmentItems.Rows(i).Cells("ci_colorvalue").Value))
                        dgStockAdjustmentItems.Rows(i).Cells("ci_color").Style.BackColor = readcolor
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

#Region "TabPage"

    Private Sub tabMain_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabMain.DrawItem
        Try
            TabControlColor(tabMain, e)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Textbox"

    Private Sub txtComments_Leave(sender As Object, e As EventArgs) Handles txtComments.Leave
        Try
            txtStockAdjustmentNo.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

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
                            displayStockAdjusmentList(spagenum)
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

    Private Sub txtAdjustedBy_TextChanged(sender As Object, e As EventArgs) Handles txtAdjustedBy.TextChanged
        Try
            If txtAdjustedBy.Text <> "" Then
                errProvider.SetError(txtAdjustedBy, "")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Toolstrip"

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

#End Region

#Region "Datagridview"

    Public Sub dgStockAdjusmentList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStockAdjusmentList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            UserRights(Z_PositionID, "Stock Adjustment", creates, updates, disable, reads, Me)
            UserRights(Z_PositionID, "Approve Stock Adjustment", Appcreates, Appupdates, Appdisable, Appreads, Me)
            If dgStockAdjusmentList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearAddProductA()
                clearStockAdjInformation()
                clearDatagrids()
                visiblesupplierOrderItems(fraud)
                displayStockAdjustmentInformation(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value)
                displayStockAdjustmentItems(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value)
                'If dgStockAdjusmentList.CurrentRow.Cells("s_stockadjstatus").Value <> "Cancelled" Then
                '    updatestatusToApproved(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value))
                'End If
                'displayStockAdjustmentInformation(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value)
                colorCoding()
                If txtStatus.Text = "For Approval" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Approved" Then
                    enableGB(legit, fraud, fraud)
                    grpStockAdjustmentitems.Enabled = True
                    enableANDvisibleMS(legit, legit, fraud, fraud)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                End If
                txtStockAdjustmentNo.Focus()
            End If
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

    Private Sub dgStockAdjusmentList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgStockAdjusmentList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgStockAdjusmentList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearAddProductA()
                clearStockAdjInformation()
                clearDatagrids()
                visiblesupplierOrderItems(fraud)
                displayStockAdjustmentInformation(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value)
                displayStockAdjustmentItems(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value)
                'If dgStockAdjusmentList.CurrentRow.Cells("s_stockadjstatus").Value <> "Cancelled" Then
                '    updatestatusToApproved(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value))
                'End If
                'displayStockAdjustmentInformation(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value)
                colorCoding()
                If txtStatus.Text = "For Approval" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Approved" Then
                    enableGB(legit, fraud, fraud)
                    grpStockAdjustmentitems.Enabled = True
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                End If
                txtStockAdjustmentNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgStockAdjustmentItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStockAdjustmentItems.CellClick
        Try
            Me.Cursor = Cursors.WaitCursor
            If dgStockAdjustmentItems.CurrentRow.Cells("ci_app").Value = "N" Then
                grpStockAdjrsc.Enabled = False
            Else
                grpStockAdjrsc.Enabled = True
            End If
            msSave.Enabled = True
            displayProductRSC(dgStockAdjustmentItems.CurrentRow.Cells("ci_pcsrowid").Value)
            pcsids = CInt(dgStockAdjustmentItems.CurrentRow.Cells("ci_pcsrowid").Value)
            orderIid = CInt(dgStockAdjustmentItems.CurrentRow.Cells("ci_rowid").Value)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub

    Private Sub dgStockAdjustmentItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStockAdjustmentItems.CellContentClick
        Try
            If dgStockAdjustmentItems.Rows.Count <> 0 Then
                If e.ColumnIndex = dgStockAdjustmentItems.Columns("ci_option").Index Then
                    If cue = "Edit" Then
                        If updates = "N" Then
                            MessageBox.Show("You are not allowed to delete this record. Please check your user rights.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Try
                        End If
                    End If
                    If IsNumeric(dgStockAdjustmentItems.CurrentRow.Cells("ci_rowid").Value) Then
                        If dgStockAdjustmentItems.CurrentRow.Cells("ci_rowid").Value = 0 Then
                            If dgStockAdjustmentItems.SelectedRows.Count > 0 Then
                                dgStockAdjustmentItems.Rows.Remove(dgStockAdjustmentItems.SelectedRows(0))
                            End If
                            dgrackshelfcolumn.Rows.Clear()
                        Else
                            If dgStockAdjusmentList.Rows.Count <> 0 Then
                                getOrderStatus(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Me)
                                If globalorderstatus <> txtStatus.Text Then
                                    MessageBox.Show("This stock adj has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                ElseIf globalorderstatus = "For Approval" Then
                                    If MessageBox.Show("Would you like to delete this item from this list?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        Me.Cursor = Cursors.WaitCursor
                                        getOrderStatus(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Me)
                                        If globalorderstatus <> "For Approval" Then
                                            MessageBox.Show("This stock adj. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Exit Try
                                        End If
                                        getOrderItemInfo(CInt(dgStockAdjustmentItems.CurrentRow.Cells("ci_rowid").Value), Me)
                                        getOrderTotalAmount(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Me)
                                        U_OrderTotalAmount(CInt(dgStockAdjusmentList.CurrentRow.Cells("s_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalordertotalamount - Math.Round(globalorderitemsrp * globalorderitemqtyordered, 2), Me)
                                        If myModule.systemerrorfound = False Then
                                            U_OrderItemStatus(CInt(dgStockAdjustmentItems.CurrentRow.Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                                        End If
                                        If myModule.systemerrorfound = False Then
                                            If dgStockAdjustmentItems.SelectedRows.Count > 0 Then
                                                dgStockAdjustmentItems.Rows.Remove(dgStockAdjustmentItems.SelectedRows(0))
                                            End If
                                            dgrackshelfcolumn.Rows.Clear()
                                            myBalloon("Successfully Deleted", "Delete", lblsavemsg, -15, -65)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If dgStockAdjustmentItems.SelectedRows.Count > 0 Then
                            dgStockAdjustmentItems.Rows.Remove(dgStockAdjustmentItems.SelectedRows(0))
                        End If
                        dgrackshelfcolumn.Rows.Clear()
                    End If
                    itemno = startingpage
                    For i As Integer = 0 To dgStockAdjustmentItems.Rows.Count - 1
                        dgStockAdjustmentItems.Rows(i).Cells("ci_seqno").Value = itemno
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

    Private Sub dgStockAdjusmentList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgStockAdjusmentList.DataError
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
                dgStockAdjusmentList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgStockAdjustmentItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgStockAdjustmentItems.CellEndEdit
        Try
            itemno = 0
            If dgStockAdjustmentItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgStockAdjustmentItems.Rows.Count - 1
                    If dgStockAdjustmentItems.Rows(i).Cells("ci_approved").Value = legit Then
                        itemno = itemno + startingpage
                    End If
                Next
                If itemno <> dgStockAdjustmentItems.Rows.Count Then
                    chkApproveAll.Checked = fraud
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Private Sub dgStockAdjustmentItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgStockAdjustmentItems.DataError
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
                dgStockAdjustmentItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgrackshelfcolumn_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgrackshelfcolumn.DataError
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
                dgrackshelfcolumn.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgrackshelfcolumn_MouseUp(sender As Object, e As MouseEventArgs) Handles dgrackshelfcolumn.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgrackshelfcolumn.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgrackshelfcolumn.BeginEdit(True)
                Else
                    dgrackshelfcolumn.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgStockAdjustmentItems_Mouseup(sender As Object, e As MouseEventArgs) Handles dgStockAdjustmentItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgrackshelfcolumn.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgStockAdjustmentItems.BeginEdit(True)
                Else
                    dgStockAdjustmentItems.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgvprodinv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgrackshelfcolumn.CellEndEdit
        'Try
        '    Me.Cursor = Cursors.WaitCursor
        '    dgrackshelfcolumn.CommitEdit(DataGridViewDataErrorContexts.Commit)
        '    dgrackshelfcolumn.EndEdit(True)
        '    If e.ColumnIndex = dgrackshelfcolumn.Columns("r_rack").Index Or e.ColumnIndex = dgrackshelfcolumn.Columns("r_shelf").Index Or e.ColumnIndex = dgrackshelfcolumn.Columns("r_column").Index Then
        '        getrackid(dgrackshelfcolumn.CurrentRow.Cells("r_rack").Value, dgrackshelfcolumn.CurrentRow.Cells("r_shelf").Value, dgrackshelfcolumn.CurrentRow.Cells("r_column").Value)
        '        Dim totalqty As String = getStringItem("Select COALESCE(TotalAvailableQty,0) from productinventorylocation where RackShelfColumnID=" & getrackshelfcolid & " AND ProductColorSizeID=" & dgStockAdjustmentItems.CurrentRow.Cells("ci_pcsrowid").Value & "")
        '        dgrackshelfcolumn.CurrentRow.Cells("r_qtystock").Value = Val(totalqty)
        '    End If
        'Catch ex As Exception
        '    MsgBox(getErrExcptn(ex, Me.Name))
        'Finally
        '    Me.Cursor = Cursors.Default
        '    conn.Close()
        'End Try
    End Sub

#End Region

#Region "CheckBox"

    Private Sub chkOtherInfo_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtherInfo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If chkOtherInfo.Checked = legit Then
                visiblesupplierOrderItems(legit)
            Else
                visiblesupplierOrderItems(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Button"

    Private Sub cmdFirst_Click(sender As Object, e As EventArgs) Handles cmdFirst.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            spagenum = neutralpage
            numofpages = startingpage
            If searchmode = "Basic" Then
                displayStockAdjusmentList(spagenum)
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
                displayStockAdjusmentList(spagenum)
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
                displayStockAdjusmentList(spagenum)
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
                displayStockAdjusmentList(spagenum)
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

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            btnAddperformclick()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Picturebox"

    Private Sub pcAddtnlItems_Click(sender As Object, e As EventArgs) Handles pcAddtnlItems.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            dgrackshelfcolumn.Rows.Add()
            Dim n As Integer = dgrackshelfcolumn.Rows.Count - 1
            dgrackshelfcolumn.Rows(n).Cells("r_rack").ReadOnly = False
            dgrackshelfcolumn.Rows(n).Cells("r_shelf").ReadOnly = False
            dgrackshelfcolumn.Rows(n).Cells("r_column").ReadOnly = False
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub

#End Region

End Class