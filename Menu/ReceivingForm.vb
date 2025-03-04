Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Interfaces.Repositories

Public Class ReceivingForm
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
    Dim rrreceivingitemsqtystockedcue As Boolean
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim rrorderno, rrprintaccountlabel, rrprintrrno, rrrelatedrefno As String
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim rrtotalqtyreceivedgood, rrtotalqtyreceivedbad, rrtotalqtystocked As Integer
    Dim simplesearchphrase, datephrase, commonphrase, pagefilter1, pagefilter2, pagefilter3, pagefilter4 As String
    Dim rrsuppliercustomerid, rrorderid, rrproductcolorsizesid, rrproductid, rrproductbundleid, rrrelatedorderid, rrcontactid As Integer
    Private _systemOwner As SystemOwner

    Private Async Sub ReceivingForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            displayReceivingOrderList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default

        If IsThurston Then
            For Each comboBox In gbReceivingInformation.Controls.
                OfType(Of Control).
                OfType(Of ComboBox).
                ToArray()

                SetStyleToDropDownList(comboBox)
            Next
        End If

    End Sub

    Private Sub ReceivingOrderForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        globalautocompleteAccountNameReceiving(cboAccountName, Me)
        globalautocompleteReceivedBy(cboReceivedBy, Me)

    End Sub

    Sub callAutoPopulate()
        autopopulatecboSearch()
        globalautopopulateAccountNameReceiving(cboAccountName, Me)
        globalautopopulateReceivedBy(cboReceivedBy, Me)
        globalautopopulateInventorySource(cboInventorySource, Me)
        LoadInventoryLocationsAsync()
    End Sub

#Region "Computations"

    Sub receivingitemscomputation()
        Try
            rrtotalqtyreceivedgood = 0 : rrtotalqtyreceivedbad = 0 : rrtotalqtystocked = 0
            If dgReceivingItems.Rows.Count <> 0 Then
                For i = 0 To dgReceivingItems.Rows.Count - 1
                    If IsNumeric(dgReceivingItems.Rows(i).Cells("ci_qtyreceived").Value) Then
                        rrtotalqtyreceivedgood = rrtotalqtyreceivedgood + CInt(dgReceivingItems.Rows(i).Cells("ci_qtyreceived").Value)
                    End If
                    If IsNumeric(dgReceivingItems.Rows(i).Cells("ci_qtybad").Value) Then
                        rrtotalqtyreceivedbad = rrtotalqtyreceivedbad + CInt(dgReceivingItems.Rows(i).Cells("ci_qtybad").Value)
                    End If
                    If IsNumeric(dgReceivingItems.Rows(i).Cells("ci_qtystocked").Value) Then
                        rrtotalqtystocked = rrtotalqtystocked + CInt(dgReceivingItems.Rows(i).Cells("ci_qtystocked").Value)
                    End If
                Next
            End If
            txtTotalQtyReceivedGood.Text = Format(rrtotalqtyreceivedgood, "#,##0")
            txtTotalQtyReceivedBad.Text = Format(rrtotalqtyreceivedbad, "#,##0")
            txtTotalQtyStocked.Text = Format(rrtotalqtystocked, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearReceivingInformation()
            clearReceivingItems()
            clearDatagrids()
            enableGB(legit, fraud)
            normalHideReceivingItems(fraud)
            viewHideReceivingItems(fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cue = ""
            clearReceivingInformation()
            clearReceivingItems()
            clearDatagrids()
            enableGB(legit, fraud)
            normalHideReceivingItems(fraud)
            viewHideReceivingItems(fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
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

    Sub clearReceivingInformation()
        Try
            txtRRNo.Text = ""
            cboAccountName.Text = ""
            txtRRType.Text = ""
            txtStatus.Text = ""
            txtReferenceNo.Text = ""
            cboReceivedBy.Text = ""
            txtComments.Text = ""
            txtBrands.Text = ""
            txtContainerNo.Text = ""
            txtArrivedIn.Text = ""
            txtSealNo.Text = ""
            cboReceivedBy.SelectedItem = Nothing
            cboAccountName.SelectedItem = Nothing
            cboInventorySource.SelectedItem = "Main"
            cboInventoryLocation.SelectedItem = 1
            dtpRRDate.Value = Now.Date
            dtpTimeArrived.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearReceivingItems()
        Try
            chkOtherInfo.Checked = fraud
            txtTotalQtyReceivedGood.Text = ""
            txtTotalQtyReceivedBad.Text = ""
            txtTotalQtyStocked.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearDatagrids()
        Try
            dgReceivingItems.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbReceivingList.Enabled = enable1
            gbReceivingInformation.Enabled = enable2
            gbReceivingItems.Enabled = enable2
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

    Sub normalHideReceivingItems(ByVal visible1 As Boolean)
        Try
            ci_unitofmeasure.Visible = visible1
            ci_itemtype.Visible = visible1
            ci_reason.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub viewHideReceivingItems(ByVal visible1 As Boolean)
        ci_approved.Visible = visible1

        'Dim systemOwnerService = MainServiceProvider.GetRequiredService(Of ISystemOwnerService)
        'Dim currentSystemOwner = Await systemOwnerService.GetCurrentSystemOwnerEntityAsync()
        'ci_qtyordered.Visible = Not currentSystemOwner.IsThurston
        ci_qtyordered.Visible = visible1
    End Sub

    Public Async Function globalautopopulateInventorySource(ByVal globalicombobox As ComboBox, ByVal globalformname As Object) As Task
        globalicombobox.ValueMember = "Value"
        globalicombobox.DisplayMember = "Name"

        Dim customerOrderTypes = InventoryLocation.GetTypes.
            OfType(Of Object).
            Select(Function(t) New InvetoryTypeModel(CType(t, InventoryLocationType))).
            ToList()
        globalicombobox.DataSource = customerOrderTypes
    End Function
    Private Class InvetoryTypeModel
        Public ReadOnly Property Name As String
        Public ReadOnly Property Value As InventoryLocationType

        Public Sub New(inventoryLocationType As InventoryLocationType)
            _Name = $"{inventoryLocationType}"
            _Value = inventoryLocationType
        End Sub

    End Class
#End Region

#Region "Click"

    Sub tsrefreshperformclick()
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            displayReceivingOrderList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
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
            dtCid = getDataTableForSQL("SELECT COUNT(rr.rowid) FROM orders rr WHERE rr.organizationid = " & Z_OrganizationID & $" AND rr.ordertype = '{OrderType.RR.ToString()}' ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(rr.rowid),0) FROM orders rr LEFT JOIN accounts ac ON rr.accountid = ac.rowid WHERE rr.organizationid = " & Z_OrganizationID & $" AND rr.ordertype = '{OrderType.RR.ToString()}' " &
                            "AND (rr.ordernumber LIKE '%" & esearchstring & "%' OR rr.status LIKE '%" & esearchstring & "%' OR ac.companyname LIKE '%" & esearchstring & "%') ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(rr.rowid),0) FROM orders rr WHERE rr.organizationid = " & Z_OrganizationID & $" AND rr.ordertype = '{OrderType.RR.ToString()}' AND " &
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(rr.rowid),0) FROM orders rr WHERE rr.organizationid = " & Z_OrganizationID & $" AND rr.ordertype = '{OrderType.RR.ToString()}' AND " & ecommonstring & " " & edatesearch & " ")
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
            If icommonbox.Text = "SupplierName/CustomerName" Then
                getSupplierCustomerID(icommonstring, Me)
                rrsuppliercustomerid = globalsuppliercustomerid
                commonphrase = "rr.accountid = " & rrsuppliercustomerid & ""
            ElseIf icommonbox.Text = "Status" Then
                commonphrase = "rr.status = """ & icommonstring & """"
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
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,''),' - ',COALESCE(su.accounttype,'')),'') AS 'suppliercustomername' FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype =""" & gloOrType & """ ORDER BY su.accounttype ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                suppliername.Add(ds.Tables(0).Rows(i)("suppliercustomername").ToString())
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
            Dim cmd As New MySqlCommand("SELECT COALESCE(po.status,'') AS 'postatus' FROM orders po WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype =""" & gloOrType & """ GROUP BY po.status ORDER BY po.status ", conn)
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
            cboSearch1.Items.Add("SupplierName/CustomerName")
            cboSearch1.Items.Add("Status")
            cboSearch3.Items.Add("SupplierName/CustomerName")
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
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(su.companyname,''),' - ',COALESCE(su.accountno,''),' - ',COALESCE(su.accounttype,'')),'') AS 'suppliercustomername' FROM orders po LEFT JOIN accounts su ON po.accountid = su.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype =""" & gloOrType & """ ORDER BY su.accounttype "
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
            Dim sql1 As String = "SELECT COALESCE(po.status,'') AS 'postatus' FROM orders po WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype =""" & gloOrType & """ GROUP BY po.status ORDER BY po.status "
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

    Sub displayReceivingOrderList(ByVal istartpage As Integer)
        Try
            dgReceivingList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT rr.rowid,COALESCE(rr.ordernumber,''),DATE_FORMAT(rr.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(ac.companyname,''),' - ',COALESCE(ac.accountno,''),' - ',COALESCE(ac.accounttype,'')),'')," &
                        "COALESCE(rr.status,''),COALESCE(rr.relatedorderid,0),COALESCE(o.ordertype,'Blank') FROM orders rr LEFT JOIN accounts ac ON rr.accountid = ac.rowid LEFT JOIN orders o ON rr.relatedorderid = o.rowid " &
                        "WHERE rr.organizationid = " & Z_OrganizationID & $" AND rr.ordertype = '{OrderType.RR.ToString()}' ORDER BY rr.created DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgReceivingList.Rows.Add()
                    dgReceivingList.Item(rr_rowid.Index, n).Value = reader1(0)
                    dgReceivingList.Item(rr_receivingorderno.Index, n).Value = reader1(1)
                    dgReceivingList.Item(rr_receivingorderdate.Index, n).Value = reader1(2)
                    dgReceivingList.Item(rr_suppliername.Index, n).Value = reader1(3)
                    dgReceivingList.Item(rr_status.Index, n).Value = reader1(4)
                    dgReceivingList.Item(rr_relatedorderid.Index, n).Value = reader1(5)
                    dgReceivingList.Item(rr_rrtype.Index, n).Value = reader1(6)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReceivingList.Columns("rr_receivingorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_receivingorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_rrtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReceivingList.Rows.Count <> 0 Then
                dgReceivingList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgReceivingList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT rr.rowid,COALESCE(rr.ordernumber,''),DATE_FORMAT(rr.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(ac.companyname,''),' - ',COALESCE(ac.accountno,''),' - ',COALESCE(ac.accounttype,'')),'')," &
                        "COALESCE(rr.status,''),COALESCE(rr.relatedorderid,0),COALESCE(o.ordertype,'Blank') FROM orders rr LEFT JOIN accounts ac ON rr.accountid = ac.rowid LEFT JOIN orders o ON rr.relatedorderid = o.rowid WHERE rr.organizationid = " & Z_OrganizationID & " " &
                        $"AND rr.ordertype = '{OrderType.RR.ToString()}' AND (rr.ordernumber LIKE '%" & isearchphrase & "%' OR rr.status LIKE '%" & isearchphrase & "%' OR ac.companyname LIKE '%" & isearchphrase & "%') ORDER BY rr.created DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgReceivingList.Rows.Add()
                    dgReceivingList.Item(rr_rowid.Index, n).Value = reader1(0)
                    dgReceivingList.Item(rr_receivingorderno.Index, n).Value = reader1(1)
                    dgReceivingList.Item(rr_receivingorderdate.Index, n).Value = reader1(2)
                    dgReceivingList.Item(rr_suppliername.Index, n).Value = reader1(3)
                    dgReceivingList.Item(rr_status.Index, n).Value = reader1(4)
                    dgReceivingList.Item(rr_relatedorderid.Index, n).Value = reader1(5)
                    dgReceivingList.Item(rr_rrtype.Index, n).Value = reader1(6)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReceivingList.Columns("rr_receivingorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_receivingorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_rrtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReceivingList.Rows.Count <> 0 Then
                dgReceivingList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayDateSearch(ByVal istartpage As Integer, ByVal idatesearch As String)
        Try
            dgReceivingList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT rr.rowid,COALESCE(rr.ordernumber,''),DATE_FORMAT(rr.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(ac.companyname,''),' - ',COALESCE(ac.accountno,''),' - ',COALESCE(ac.accounttype,'')),'')," &
                        "COALESCE(rr.status,''),COALESCE(rr.relatedorderid,0),COALESCE(o.ordertype,'Blank') FROM orders rr LEFT JOIN accounts ac ON rr.accountid = ac.rowid LEFT JOIN orders o ON rr.relatedorderid = o.rowid " &
                        "WHERE rr.organizationid = " & Z_OrganizationID & $" AND rr.ordertype = '{OrderType.RR.ToString()}' AND (" & idatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' " &
                        "AND " & idatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) GROUP BY rr.rowid ORDER BY rr.created DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgReceivingList.Rows.Add()
                    dgReceivingList.Item(rr_rowid.Index, n).Value = reader1(0)
                    dgReceivingList.Item(rr_receivingorderno.Index, n).Value = reader1(1)
                    dgReceivingList.Item(rr_receivingorderdate.Index, n).Value = reader1(2)
                    dgReceivingList.Item(rr_suppliername.Index, n).Value = reader1(3)
                    dgReceivingList.Item(rr_status.Index, n).Value = reader1(4)
                    dgReceivingList.Item(rr_relatedorderid.Index, n).Value = reader1(5)
                    dgReceivingList.Item(rr_rrtype.Index, n).Value = reader1(6)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReceivingList.Columns("rr_receivingorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_receivingorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_rrtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReceivingList.Rows.Count <> 0 Then
                dgReceivingList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal idatesearch As String, ByVal istartpage As Integer)
        Try
            dgReceivingList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT rr.rowid,COALESCE(rr.ordernumber,''),DATE_FORMAT(rr.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(ac.companyname,''),' - ',COALESCE(ac.accountno,''),' - ',COALESCE(ac.accounttype,'')),'')," &
                        "COALESCE(rr.status,''),COALESCE(rr.relatedorderid,0),COALESCE(o.ordertype,'Blank') FROM orders rr LEFT JOIN accounts ac ON rr.accountid = ac.rowid LEFT JOIN orders o ON rr.relatedorderid = o.rowid " &
                        "WHERE rr.organizationid = " & Z_OrganizationID & $" AND rr.ordertype = '{OrderType.RR.ToString()}' AND " & icommonphrase & " " & idatesearch & " ORDER BY rr.created DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgReceivingList.Rows.Add()
                    dgReceivingList.Item(rr_rowid.Index, n).Value = reader1(0)
                    dgReceivingList.Item(rr_receivingorderno.Index, n).Value = reader1(1)
                    dgReceivingList.Item(rr_receivingorderdate.Index, n).Value = reader1(2)
                    dgReceivingList.Item(rr_suppliername.Index, n).Value = reader1(3)
                    dgReceivingList.Item(rr_status.Index, n).Value = reader1(4)
                    dgReceivingList.Item(rr_relatedorderid.Index, n).Value = reader1(5)
                    dgReceivingList.Item(rr_rrtype.Index, n).Value = reader1(6)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReceivingList.Columns("rr_receivingorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_receivingorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingList.Columns("rr_rrtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReceivingList.Rows.Count <> 0 Then
                dgReceivingList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayReceivingInformation(ByVal iorderid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(rr.ordernumber,''),DATE_FORMAT(rr.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(ac.companyname,''),' - ',COALESCE(ac.accountno,''),' - ',COALESCE(ac.accounttype,'')),''),COALESCE(rr.`status`,''),COALESCE(o.ordertype,'Blank')," &
                         "COALESCE(o.ordernumber,''),COALESCE(rr.comments,''),COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,''),' / ',COALESCE(c.`type`,'')),''),COALESCE(rr.receivedbrands,'')," &
                         "COALESCE(TIME_FORMAT(rr.timearrived,'%r'),''),COALESCE(rr.containerno,''),COALESCE(rr.arrivedin,''),COALESCE(rr.sealno,''),COALESCE(il.type,''),COALESCE(il.name,'') FROM orders rr LEFT JOIN accounts ac ON rr.accountid = ac.rowid LEFT JOIN orders o ON rr.relatedorderid = o.rowid LEFT JOIN contacts c ON rr.contactid = c.rowid LEFT JOIN inventorylocations il on rr.inventorylocationid=il.rowid WHERE rr.rowid = " & iorderid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    cboAccountName.Text = reader1(2)
                    cboInventorySource.Text = reader1(13)
                    cboInventoryLocation.Text = reader1(14)
                    If cue = "New" Then
                        txtReferenceNo.Text = reader1(0)
                        txtStatus.Text = "For Approval"
                    ElseIf cue = "Edit" Then
                        txtRRNo.Text = reader1(0)
                        dtpRRDate.Text = reader1(1)
                        txtStatus.Text = reader1(3)
                        txtRRType.Text = reader1(4)
                        txtReferenceNo.Text = reader1(5)
                        txtComments.Text = reader1(6)
                        cboReceivedBy.Text = reader1(7)
                        txtBrands.Text = reader1(8)
                        dtpTimeArrived.Text = reader1(9)
                        txtContainerNo.Text = reader1(10)
                        txtArrivedIn.Text = reader1(11)
                        txtSealNo.Text = reader1(12)
                    End If
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayReceivingItems(ByVal iorderid As Integer)
        Try
            dgReceivingItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(ci.productbundleid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(b.bundlename,''),COALESCE(c.colorname,''),COALESCE(pcs.size,'')," &
                    "COALESCE(pcs.seasoncode,''),COALESCE(ci.unitofmeasure,''),COALESCE(ci.qtyordered,0),COALESCE(pcs.sku,''),COALESCE(b.sku,''),COALESCE(ci.itemtype,''),COALESCE(ci.remarks,''),COALESCE(ci.qtyreceived,0),COALESCE(ci.approval,'N')," &
                    "COALESCE(ci.qtydamaged,0),COALESCE(ci.reasons,'') FROM orderitems ci LEFT JOIN productbundles b ON ci.productbundleid = b.rowid LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " &
                    "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE ci.orderid = " & iorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.`status` != 'Inactive' AND ci.itemtype != 'BI' GROUP BY ci.rowid ORDER BY p.productcode,c.colorname,pcs.size "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgReceivingItems.Rows.Add()
                    dgReceivingItems.Item(ci_seqno.Index, n).Value = seqno
                    dgReceivingItems.Item(ci_rowid.Index, n).Value = reader1(0)
                    dgReceivingItems.Item(ci_pcsrowid.Index, n).Value = reader1(1)
                    dgReceivingItems.Item(ci_bid.Index, n).Value = reader1(2)
                    dgReceivingItems.Item(ci_colorvalue.Index, n).Value = reader1(3)
                    dgReceivingItems.Item(ci_color.Index, n).Value = ""
                    If CInt(reader1(1)) <> 0 Then
                        dgReceivingItems.Item(ci_productcode.Index, n).Value = reader1(4)
                    Else
                        dgReceivingItems.Item(ci_productcode.Index, n).Value = reader1(5)
                    End If
                    dgReceivingItems.Item(ci_colorname.Index, n).Value = reader1(6)
                    dgReceivingItems.Item(ci_size.Index, n).Value = reader1(7)
                    dgReceivingItems.Item(ci_seasoncode.Index, n).Value = reader1(8)
                    dgReceivingItems.Item(ci_unitofmeasure.Index, n).Value = reader1(9)
                    dgReceivingItems.Item(ci_qtyordered.Index, n).Value = reader1(10)
                    If CInt(reader1(1)) <> 0 Then
                        dgReceivingItems.Item(ci_sku.Index, n).Value = reader1(11)
                    Else
                        dgReceivingItems.Item(ci_sku.Index, n).Value = reader1(12)
                    End If
                    dgReceivingItems.Item(ci_itemtype.Index, n).Value = reader1(13)
                    dgReceivingItems.Item(ci_remarks.Index, n).Value = reader1(14)
                    dgReceivingItems.Item(ci_qtyreceived.Index, n).Value = reader1(15)
                    dgReceivingItems.Item(ci_qtybad.Index, n).Value = reader1(17)
                    dgReceivingItems.Item(ci_reason.Index, n).Value = reader1(18)
                    If CStr(reader1(16)) = "N" Then
                        dgReceivingItems.Item(ci_approved.Index, n).Value = fraud
                        dgReceivingItems.Item(ci_approved.Index, n).ReadOnly = fraud
                        dgReceivingItems.Item(ci_qtyreceived.Index, n).ReadOnly = fraud
                        dgReceivingItems.Item(ci_qtybad.Index, n).ReadOnly = fraud
                        dgReceivingItems.Item(ci_unitofmeasure.Index, n).ReadOnly = fraud
                        dgReceivingItems.Item(ci_remarks.Index, n).ReadOnly = fraud
                        dgReceivingItems.Item(ci_reason.Index, n).ReadOnly = fraud
                    Else
                        dgReceivingItems.Item(ci_approved.Index, n).Value = legit
                        dgReceivingItems.Item(ci_approved.Index, n).ReadOnly = legit
                        dgReceivingItems.Item(ci_qtyreceived.Index, n).ReadOnly = legit
                        dgReceivingItems.Item(ci_qtybad.Index, n).ReadOnly = legit
                        dgReceivingItems.Item(ci_unitofmeasure.Index, n).ReadOnly = legit
                        dgReceivingItems.Item(ci_remarks.Index, n).ReadOnly = legit
                        dgReceivingItems.Item(ci_reason.Index, n).ReadOnly = legit
                    End If
                    dgReceivingItems.Item(ci_app.Index, n).Value = reader1(16)
                    getTotalQtyAppliedA(CInt(reader1(0)), Me)
                    dgReceivingItems.Item(ci_qtystocked.Index, n).Value = globaltotalqtyapplied
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReceivingItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_qtybad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_qtystocked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_approved").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_itemtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReceivingItems.Rows.Count <> 0 Then
                dgReceivingItems.CurrentRow.Selected = False
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
            If dgReceivingItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgReceivingItems.Rows.Count - 1
                    If dgReceivingItems.Rows(i).Cells(ci_itemtype.Index).Value = "A" Then
                        dgReceivingItems.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.BurlyWood
                    End If
                    If CStr(dgReceivingItems.Rows(i).Cells("ci_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgReceivingItems.Rows(i).Cells("ci_colorvalue").Value))
                        dgReceivingItems.Rows(i).Cells("ci_color").Style.BackColor = readcolor
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

#Region "Update"

    Sub updateStatusToApproved(ByVal iorderid As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim cApproved As Integer
            For x = 0 To dgReceivingItems.Rows.Count - 1
                If dgReceivingItems.Rows(x).Cells("ci_approved").Value = legit Then
                    cApproved = cApproved + 1
                End If
            Next
            If cApproved = dgReceivingItems.Rows.Count Then
                DirectCommand("UPDATE orders SET `status` = 'Approved' WHERE rowid = " & iorderid & " ")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub

    Sub updateRelatedOrderStatus(ByVal iorderid As Integer, ByVal istatus As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            DirectCommand("UPDATE orders SET `status` = """ & istatus & """ WHERE rowid = " & iorderid & " ")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Cancel"

    Sub checkReceivingItemsQtyStocked(ByVal iorderid As Integer)
        Try
            rrreceivingitemsqtystockedcue = fraud
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid FROM orderitems ci WHERE ci.orderid = " & iorderid & " AND ci.organizationid = " & Z_OrganizationID & " " &
                    "AND ci.`status` != 'Inactive' AND ci.itemtype != 'BI' GROUP BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyAppliedA(CInt(reader1(0)), Me)
                    If globaltotalqtyapplied > 0 Then
                        rrreceivingitemsqtystockedcue = legit
                    End If
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub cancelReceivingItems(ByVal iorderid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.remarks,'') FROM orderitems ci WHERE ci.orderid = " & iorderid & " AND ci.organizationid = " & Z_OrganizationID & " " &
                    "AND ci.`status` != 'Inactive' AND ci.itemtype != 'BI' GROUP BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    M_U_OrderItems(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, 0, 0, CStr(reader1(1)), "", "N", Me)
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

#Region "Printing"

    Sub printReceivingItems(ByVal iorderid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,''),COALESCE(ci.unitofmeasure,'')," &
                    "COALESCE(rr.ordernumber,''),COALESCE(rr.ordertype,'Blank'),COALESCE(o.ordernumber,''),COALESCE(CONCAT(COALESCE(ac.companyname,''),' - ',COALESCE(ac.accountno,'')),''),COALESCE(ac.accounttype,'') " &
                    "FROM orderitems ci LEFT JOIN productbundles b ON ci.productbundleid = b.rowid LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " &
                    "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN orders rr ON ci.orderid = rr.rowid LEFT JOIN accounts ac ON rr.accountid = ac.rowid LEFT JOIN orders o ON rr.relatedorderid = o.rowid " &
                    "WHERE ci.orderid = " & iorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.`status` != 'Inactive' AND ci.itemtype != 'BI' GROUP BY ci.rowid ORDER BY p.productcode,c.colorname "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    If CStr(reader1(10)) = "Customer" Then
                        rrprintaccountlabel = "Customer Name:"
                    ElseIf CStr(reader1(10)) = "Supplier" Then
                        rrprintaccountlabel = "Supplier Name:"
                    End If
                    If txtRRType.Text <> "Blank" Then
                        rrprintrrno = CStr(dgReceivingList.CurrentRow.Cells("rr_receivingorderno").Value)
                        rrrelatedrefno = CStr(reader1(6))
                    Else
                        rrprintrrno = CStr(reader1(6))
                        rrrelatedrefno = "n/a"
                    End If
                    printdataset.AddSetDRow("R.R. No.: " & rrprintrrno & "", "Received Date: _______________", "Related Ref. No.: " & rrrelatedrefno & "", "R.R. Type: " & If(CStr(reader1(7)) = OrderType.RR.ToString(), "Blank", CStr(reader1(7))) & "", "" & rrprintaccountlabel & " " & CStr(reader1(9)) & "",
                            "Received By: ________________________________________________", CStr(seqno), CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(2)), CStr(reader1(3)), CStr(reader1(4)), CStr(reader1(5)), "", "", "", "", "", "", "", "")
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
                PrimaryForm.RRForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
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

    Private Sub chkOtherInfo_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtherInfo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If chkOtherInfo.Checked = legit Then
                normalHideReceivingItems(legit)
            Else
                normalHideReceivingItems(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAddSupplierCustomer_MouseEnter(sender As Object, e As EventArgs) Handles pbAddSupplierCustomer.MouseEnter
        Try
            pbAddSupplierCustomer.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddSupplierCustomer_MouseLeave(sender As Object, e As EventArgs) Handles pbAddSupplierCustomer.MouseLeave
        Try
            pbAddSupplierCustomer.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddSupplierCustomer_Click(sender As Object, e As EventArgs) Handles pbAddSupplierCustomer.Click
        Try
            cmsOptionsA.Show(Cursor.Position)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub msCustomer_Click(sender As Object, e As EventArgs) Handles msCustomer.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
                globalautocompleteAccountNameReceiving(cboAccountName, Me)
                globalautopopulateAccountNameReceiving(cboAccountName, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msSupplier_Click(sender As Object, e As EventArgs) Handles msSupplier.Click
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
                globalautocompleteAccountNameReceiving(cboAccountName, Me)
                globalautopopulateAccountNameReceiving(cboAccountName, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAddReceivedBy_MouseEnter(sender As Object, e As EventArgs) Handles pbAddReceivedBy.MouseEnter
        Try
            pbAddReceivedBy.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddReceivedBy_MouseLeave(sender As Object, e As EventArgs) Handles pbAddReceivedBy.MouseLeave
        Try
            pbAddReceivedBy.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddReceivedBy_Click(sender As Object, e As EventArgs) Handles pbAddReceivedBy.Click
        Try
            cmsOptionsB.Show(Cursor.Position)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cmsPicker_Click(sender As Object, e As EventArgs) Handles cmsPicker.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Receiving", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RRForm = False
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
            Dim addpickerlinkform As New AddPickerForm
            addpickerlinkform.ShowInTaskbar = False
            addpickerlinkform.ShowDialog()
            If addpickerlinkform.addpickerformcue = legit Then
                globalautocompleteReceivedBy(cboReceivedBy, Me)
                globalautopopulateReceivedBy(cboReceivedBy, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmsPacker_Click(sender As Object, e As EventArgs) Handles cmsPacker.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Receiving", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RRForm = False
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
            Dim addpackerlinkform As New AddPackerForm
            addpackerlinkform.ShowInTaskbar = False
            addpackerlinkform.ShowDialog()
            If addpackerlinkform.addpackerformcue = legit Then
                globalautocompleteReceivedBy(cboReceivedBy, Me)
                globalautopopulateReceivedBy(cboReceivedBy, Me)
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
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Receiving", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RRForm = False
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
            Dim newrrlinkform As New NewRR
            newrrlinkform.ShowInTaskbar = False
            newrrlinkform.ShowDialog()
            If newrrlinkform.newrrcue = legit Then
                cue = "New"
                errProvider.Clear()
                clearReceivingInformation()
                clearReceivingItems()
                clearDatagrids()
                enableGB(fraud, legit)
                normalHideReceivingItems(fraud)
                enableANDvisibleMS(fraud, legit, fraud, legit, fraud)

                getPositionView(globalpositionid, "Show Quantity to Receive", Me)
                If globalupdateflg = "Y" Then
                    viewHideReceivingItems(legit)
                Else
                    viewHideReceivingItems(fraud)
                End If
                If dgReceivingList.Rows.Count <> 0 Then
                    dgReceivingList.CurrentRow.Selected = False
                End If
                getOrderNo(globaliordertype:=OrderType.RR.ToString(), Me)
                txtRRNo.Text = CStr(globalorderno)
                ci_option.Visible = fraud
                cboAccountName.Enabled = fraud
                'btnStockToWarehouse.Enabled = fraud
                btnAddAdditionalItems.Enabled = fraud
                rrrelatedorderid = newrrlinkform.nrorderid
                cboInventorySource.Enabled = legit
                If newrrlinkform.nrrnewrrtype = OrderType.PO.ToString() Then
                    txtRRType.Text = OrderType.PO.ToString()
                    lblReferenceNo.Text = "Related P.O. No.:"
                ElseIf newrrlinkform.nrrnewrrtype = "Pull-Out" Then
                    txtRRType.Text = "Pull-Out"
                    lblReferenceNo.Text = "Related Pull-Out No.:"
                ElseIf newrrlinkform.nrrnewrrtype = "Return" Then
                    txtRRType.Text = "Return"
                    lblReferenceNo.Text = "Related Return No.:"
                ElseIf newrrlinkform.nrrnewrrtype = "Blank" Then
                    txtRRType.Text = "Blank"
                    lblReferenceNo.Text = "Related Ref. No.:"
                    cboAccountName.Enabled = legit
                    btnAddAdditionalItems.Enabled = legit
                    ci_option.Visible = legit
                End If
                If newrrlinkform.nrrnewrrtype <> "Blank" Then
                    displayReceivingInformation(rrrelatedorderid)
                    displayReceivingItems(rrrelatedorderid)
                    receivingitemscomputation() : colorCoding()
                End If
                txtRRNo.Focus()
            Else
                tsrefreshperformclick() : rrrelatedorderid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()

            If IsThurston Then cboInventorySource_SelectedIndexChanged(cboInventorySource, New EventArgs())
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msCancel_Click(sender As Object, e As EventArgs) Handles msCancel.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgReceivingList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearReceivingInformation()
                clearReceivingItems()
                clearDatagrids()
                enableGB(legit, legit)
                normalHideReceivingItems(fraud)
                getPositionView(globalpositionid, "Show Quantity to Receive", Me)
                If globalupdateflg = "Y" Then
                    viewHideReceivingItems(legit)
                Else
                    viewHideReceivingItems(fraud)
                End If
                dgReceivingList.CurrentRow.Selected = legit
                cboAccountName.Enabled = fraud
                'btnStockToWarehouse.Enabled = fraud
                btnAddAdditionalItems.Enabled = legit
                cboInventorySource.Enabled = fraud
                displayReceivingInformation(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                If txtRRType.Text <> "Blank" Then
                    ci_option.Visible = fraud
                    displayReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value))
                    If txtRRType.Text = OrderType.PO.ToString() Then
                        lblReferenceNo.Text = "Related P.O. No.:"
                    ElseIf txtRRType.Text = "Pull-Out" Then
                        lblReferenceNo.Text = "Related Pull-Out No.:"
                        btnAddAdditionalItems.Enabled = fraud
                    ElseIf txtRRType.Text = "Return" Then
                        lblReferenceNo.Text = "Related Return No.:"
                        btnAddAdditionalItems.Enabled = fraud
                    End If
                Else
                    ci_option.Visible = legit
                    displayReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                    lblReferenceNo.Text = "Related Ref. No.:"
                    cboAccountName.Enabled = legit
                End If
                receivingitemscomputation() : colorCoding()
                If txtStatus.Text = "For Approval" Then
                    enableANDvisibleMS(legit, legit, legit, fraud, legit)
                Else
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                End If
                txtRRNo.Focus()
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

    Private Sub cboCustomerOrderType_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label35_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs)

    End Sub
    Private Async Function LoadInventoryLocationsAsync() As Task
        Dim inventoryLocationRepository = GetRequiredService(Of IInventoryLocationRepository)()
        Dim inventoryLocations = Await inventoryLocationRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)

        cboInventoryLocation.ValueMember = "RowID"
        cboInventoryLocation.DisplayMember = "Name"
        cboInventoryLocation.DataSource = inventoryLocations.
            OrderByDescending(Function(t) t.IsMainWarehouse).
            ThenBy(Function(t) t.Name).
            ToList()
    End Function
    Private Sub cboInventorySource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInventorySource.SelectedIndexChanged
        cboCustomerOrderType_SelectedValueChanged(sender, e)
    End Sub
    Private Sub cboCustomerOrderType_SelectedValueChanged(sender As Object, e As EventArgs)
        'If cboCustomerOrderType.SelectedValue IsNot Nothing Then errProvider.SetError(cboCustomerOrderType, String.Empty),
        If msNew.Enabled AndAlso Not cboInventorySource.SelectedIndex = -1 And Not cboInventoryLocation.SelectedIndex = -1 Then Return
        Dim inventoryLocationType = CType(cboInventorySource.SelectedValue, InventoryLocationType)

        Dim source = cboInventoryLocation.Items?.
            OfType(Of Object)
        If Not If(source?.Any(), False) Then Return

        Dim dataSource = source?.
            Select(Function(t) CType(t, InventoryLocation)).
            Where(Function(t) t.Type = inventoryLocationType).
            ToList()

        If Not dataSource.Any() Then
            MessageBox.Show(text:=$"No Inventory Location for type `{inventoryLocationType}`.{Environment.NewLine}{Environment.NewLine}You need to create a new Inventory Location with type `{inventoryLocationType}`.{Environment.NewLine}{Environment.NewLine}Go to `Menu` > `Inventory Management` > `(L) Inventory Locations`",
                caption:="No Inventory Location",
                icon:=MessageBoxIcon.Error,
                buttons:=MessageBoxButtons.OK)

            cboInventorySource.SelectedIndex = -1
            Return
        End If

        If dataSource.Count() > 1 Then
            Dim form = New CustomerOrderInventoryLocationSelectorDialog(inventoryLocations:=dataSource)
            If form.ShowDialog() = DialogResult.OK Then
                cboInventoryLocation.SelectedValue = form.InventoryLocationId
            Else
                cboInventorySource.SelectedIndex = -1
            End If
        Else
            cboInventoryLocation.SelectedItem = dataSource.FirstOrDefault()
        End If
    End Sub

    Private Sub dgReceivingList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReceivingList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgReceivingList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearReceivingInformation()
                clearReceivingItems()
                clearDatagrids()
                enableGB(legit, legit)
                normalHideReceivingItems(fraud)
                getPositionView(globalpositionid, "Show Quantity to Receive", Me)
                If globalupdateflg = "Y" Then
                    viewHideReceivingItems(legit)
                Else
                    viewHideReceivingItems(fraud)
                End If
                cboAccountName.Enabled = fraud
                'btnStockToWarehouse.Enabled = fraud
                btnAddAdditionalItems.Enabled = legit
                cboInventorySource.Enabled = fraud
                displayReceivingInformation(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                If txtRRType.Text <> "Blank" Then
                    ci_option.Visible = fraud
                    displayReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value))
                    If txtRRType.Text = OrderType.PO.ToString() Then
                        lblReferenceNo.Text = "Related P.O. No.:"
                    ElseIf txtRRType.Text = "Pull-Out" Then
                        lblReferenceNo.Text = "Related Pull-Out No.:"
                        btnAddAdditionalItems.Enabled = fraud
                    ElseIf txtRRType.Text = "Return" Then
                        lblReferenceNo.Text = "Related Return No.:"
                        btnAddAdditionalItems.Enabled = fraud
                    End If
                Else
                    ci_option.Visible = legit
                    displayReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                    lblReferenceNo.Text = "Related Ref. No.:"
                    cboAccountName.Enabled = legit
                End If
                receivingitemscomputation() : colorCoding()
                If txtStatus.Text = "For Approval" Then
                    enableANDvisibleMS(legit, legit, legit, fraud, legit)
                Else
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                End If
                txtRRNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgReceivingList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgReceivingList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgReceivingList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearReceivingInformation()
                    clearReceivingItems()
                    clearDatagrids()
                    enableGB(legit, legit)
                    normalHideReceivingItems(fraud)
                    getPositionView(globalpositionid, "Show Quantity to Receive", Me)
                    If globalupdateflg = "Y" Then
                        viewHideReceivingItems(legit)
                    Else
                        viewHideReceivingItems(fraud)
                    End If
                    cboAccountName.Enabled = fraud
                    'btnStockToWarehouse.Enabled = fraud
                    btnAddAdditionalItems.Enabled = legit
                    displayReceivingInformation(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                    If txtRRType.Text <> "Blank" Then
                        ci_option.Visible = fraud
                        displayReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value))
                        If txtRRType.Text = OrderType.PO.ToString() Then
                            lblReferenceNo.Text = "Related P.O. No.:"
                        ElseIf txtRRType.Text = "Pull-Out" Then
                            lblReferenceNo.Text = "Related Pull-Out No.:"
                            btnAddAdditionalItems.Enabled = fraud
                        ElseIf txtRRType.Text = "Return" Then
                            lblReferenceNo.Text = "Related Return No.:"
                            btnAddAdditionalItems.Enabled = fraud
                        End If
                    Else
                        ci_option.Visible = legit
                        displayReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                        lblReferenceNo.Text = "Related Ref. No.:"
                        cboAccountName.Enabled = legit
                    End If
                    receivingitemscomputation() : colorCoding()
                    If txtStatus.Text = "For Approval" Then
                        enableANDvisibleMS(legit, legit, legit, fraud, legit)
                    Else
                        enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                    End If
                    txtRRNo.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtRRNo_Leave(sender As Object, e As EventArgs) Handles txtRRNo.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                If LTrim(txtRRNo.Text) <> "" Then
                    getOrderIDSupB(txtRRNo.Text, globaliordertype:=OrderType.RR.ToString(), Me)
                    rrorderid = globalorderid
                    If rrorderid <> 0 Then
                        errProvider.SetError(txtRRNo, "R.R. No. has been created already, please type a new one.")
                    End If
                End If
            ElseIf cue = "Edit" Then
                If dgReceivingList.Rows.Count <> 0 Then
                    If LTrim(txtRRNo.Text) <> "" Then
                        getOrderIDSupA(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), txtRRNo.Text, globaliordertype:=OrderType.RR.ToString(), Me)
                        rrorderid = globalorderid
                        If rrorderid <> 0 Then
                            errProvider.SetError(txtRRNo, "R.R. No. has been created already, please type a new one.")
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

    'Private Sub txtRRNo_TextChanged(sender As Object, e As EventArgs) Handles txtRRNo.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            If LTrim(txtRRNo.Text) <> "" Then
    '                getOrderIDSupB(txtRRNo.Text, "RR", Me)
    '                rrorderid = globalorderid
    '                If rrorderid <> 0 Then
    '                    errProvider.SetError(txtRRNo, "R.R. No. has been created already, please type a new one.")
    '                End If
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgReceivingList.Rows.Count <> 0 Then
    '                If LTrim(txtRRNo.Text) <> "" Then
    '                    getOrderIDSupA(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), txtRRNo.Text, "RR", Me)
    '                    rrorderid = globalorderid
    '                    If rrorderid <> 0 Then
    '                        errProvider.SetError(txtRRNo, "R.R. No. has been created already, please type a new one.")
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
    Private Sub dgReceivingOrderItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReceivingItems.CellClick
        Try
            If cue = "Edit" Then
                If dgReceivingItems.Rows.Count <> 0 Then
                    If dgReceivingItems.CurrentRow.Cells("ci_app").Value = "Y" Then
                        'btnStockToWarehouse.Enabled = legit
                    Else
                        'btnStockToWarehouse.Enabled = fraud
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgReceivingOrderItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgReceivingItems.CellEndEdit
        Try
            receivingitemscomputation()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub btnAddAdditionalItems_Click(sender As Object, e As EventArgs) Handles btnAddAdditionalItems.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Receiving", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RRForm = False
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
            If cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                getOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Me)
                If globalorderstatus <> "For Approval" Then
                    MessageBox.Show("This R. R. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            getSupplierCustomerID(cboAccountName.Text, Me)
            rrsuppliercustomerid = globalsuppliercustomerid
            Dim additionalitemslinkform As New AdditionalItemsForm
            If cue = "Edit" Then
                If txtRRType.Text = OrderType.PO.ToString() Then
                    additionalitemslinkform.aiforderid = CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value)
                End If
                additionalitemslinkform.aifrrid = CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value)
            End If
            additionalitemslinkform.aifordertype = txtRRType.Text
            additionalitemslinkform.aifaccountid = rrsuppliercustomerid
            additionalitemslinkform.ShowInTaskbar = False
            additionalitemslinkform.ShowDialog()
            If additionalitemslinkform.additionalitemsformcue = legit Then
                If txtRRType.Text = OrderType.PO.ToString() Then
                    displayReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value))
                    receivingitemscomputation() : colorCoding()
                ElseIf txtRRType.Text = "Blank" Then
                    dgReceivingItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_qtybad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_qtystocked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_approved").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgReceivingItems.Columns("ci_itemtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    itemno = 1
                    For i As Integer = 0 To dgReceivingItems.Rows.Count - 1
                        dgReceivingItems.Rows(i).Cells("ci_seqno").Value = itemno
                        itemno = itemno + 1
                    Next i
                    If dgReceivingItems.Rows.Count <> 0 Then
                        dgReceivingItems.CurrentRow.Selected = False
                    End If
                    dgReceivingItems.FirstDisplayedScrollingRowIndex = dgReceivingItems.RowCount - 1
                    receivingitemscomputation()
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
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Receiving", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RRForm = False
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
            receivingitemscomputation()
            dgReceivingItems.CommitEdit(legit) : dgReceivingItems.ClearSelection() : dgReceivingItems.CurrentCell = Nothing
            If LTrim(cboAccountName.Text) <> "" Then
                getSupplierCustomerID(cboAccountName.Text, Me)
                rrsuppliercustomerid = globalsuppliercustomerid
                If rrsuppliercustomerid = 0 Then
                    errProvider.SetError(pbAddSupplierCustomer, "System cannot find the supplier/customer name.")
                    Exit Try
                End If
            Else
                errProvider.SetError(pbAddSupplierCustomer, "Please choose the supplier/customer name.")
                Exit Try
            End If
            If cue = "New" Then
                If LTrim(txtRRNo.Text) <> "" Then
                    getOrderIDSupB(txtRRNo.Text, globaliordertype:=OrderType.RR.ToString(), Me)
                    rrorderid = globalorderid
                    If rrorderid <> 0 Then
                        errProvider.SetError(txtRRNo, "R.R. No. has been created already, please type a new one.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtRRNo, "Please enter the R. R. No.")
                    Exit Try
                End If
            ElseIf cue = "Edit" Then
                If globalupdateflg = "N" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgReceivingList.Rows.Count <> 0 Then
                    getOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Me)
                    If globalorderstatus <> txtStatus.Text Then
                        MessageBox.Show("This R.R. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If LTrim(txtRRNo.Text) <> "" Then
                        getOrderIDSupA(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), txtRRNo.Text, globaliordertype:=OrderType.RR.ToString(), Me)
                        rrorderid = globalorderid
                        If rrorderid <> 0 Then
                            errProvider.SetError(txtRRNo, "R.R. No. has been created already, please type a new one.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(txtRRNo, "Please enter the R.R. No.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtRRNo, "System cannot find the existing R.R. No.")
                    Exit Try
                End If
            End If

            If IsThurston AndAlso Not CInt(cboInventoryLocation.SelectedValue) > 0 Then
                errProvider.SetError(cboInventoryLocation, "Please select a valid `Inventory`")
                cboInventorySource_SelectedIndexChanged(cboInventorySource, New EventArgs())
                Exit Try
            End If

            If MessageBox.Show("Would you like to save the changes on this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getSupplierCustomerID(cboAccountName.Text, Me)
                rrsuppliercustomerid = globalsuppliercustomerid
                getReceivedBy(cboReceivedBy.Text, Me)
                rrcontactid = globalcontactid
                If cue = "New" Then
                    getOrderIDSupB(txtRRNo.Text, globaliordertype:=OrderType.RR.ToString(), Me)
                    rrorderid = globalorderid
                    If rrorderid <> 0 Then
                        errProvider.SetError(txtRRNo, "R.R. No. has been created already, please type a new one.")
                        Exit Try
                    End If
                    M_I_Orders(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, rrsuppliercustomerid, txtRRNo.Text, OrderType:=OrderType.RR.ToString(), dtpRRDate.Value, DBNull.Value, cboAccountName.Text, txtComments.Text,
                            "For Approval", 0, "", If(rrrelatedorderid = 0, DBNull.Value, rrrelatedorderid), If(rrcontactid = 0, DBNull.Value, rrcontactid), dtpTimeArrived.Value, txtBrands.Text, txtContainerNo.Text, txtSealNo.Text, txtArrivedIn.Text, cboInventoryLocation.SelectedValue, Me)
                    rrorderid = globalorderidsp
                    If txtRRType.Text <> "Blank" Then
                        If rrrelatedorderid <> 0 Then
                            updateRelatedOrderStatus(rrrelatedorderid, "Received")
                        End If
                        If dgReceivingItems.Rows.Count <> 0 Then
                            For a = 0 To dgReceivingItems.Rows.Count - 1
                                If myModule.systemerrorfound = False Then
                                    If IsNumeric(dgReceivingItems.Rows(a).Cells("ci_rowid").Value) Then
                                        If CInt(dgReceivingItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                                            M_U_OrderItems(CInt(dgReceivingItems.Rows(a).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0),
                                                    If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), CStr(dgReceivingItems.Rows(a).Cells("ci_remarks").Value), CStr(dgReceivingItems.Rows(a).Cells("ci_reason").Value), If(dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit, "Y", "N"), Me)
                                            If If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0) > 0 Then
                                                DirectCommand("UPDATE productcolorsizes SET lastshipmentdate = """ & Format(dtpRRDate.Value, "yyyy/MM/dd") & """ WHERE rowid = " & CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) & " ")
                                            End If
                                            If dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit Then
                                                getProductColorSizeTotalDamageQty((dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                U_ProductColorSizeTotalDamageQty(CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtydamage + If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), Me)
                                                I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, rrorderid, DBNull.Value, DBNull.Value, CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, DBNull.Value, globaltotalqtydamage,
                                                        If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), globaltotalqtydamage + If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), "Receiving", "TotalDamageQty", "", Me)
                                            End If
                                        End If
                                    End If
                                Else
                                    Exit Try
                                End If
                            Next
                        End If
                    Else
                        If dgReceivingItems.Rows.Count <> 0 Then
                            For a = 0 To dgReceivingItems.Rows.Count - 1
                                If myModule.systemerrorfound = False Then
                                    If IsNumeric(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                        If CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                            getTotalQtyAvailableA(CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                            M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, rrsuppliercustomerid, rrorderid, CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                                    globaltotalqtyavailable, "S", "" & CStr(dgReceivingItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_seasoncode").Value) & "", CStr(dgReceivingItems.Rows(a).Cells("ci_sku").Value),
                                                    CStr(dgReceivingItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgReceivingItems.Rows(a).Cells("ci_remarks").Value), 0, "Active", If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0), If(dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit, "Y", "N"), 0, "", Me)
                                            If If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0) > 0 Then
                                                DirectCommand("UPDATE productcolorsizes SET lastshipmentdate = """ & Format(dtpRRDate.Value, "yyyy/MM/dd") & """ WHERE rowid = " & CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) & " ")
                                            End If
                                        End If
                                    End If
                                Else
                                    Exit Try
                                End If
                            Next
                        End If
                    End If
                    If myModule.systemerrorfound = False Then
                        If dgReceivingItems.Rows.Count <> 0 Then
                            updateStatusToApproved(rrorderid)
                        End If
                        myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                    End If
                ElseIf cue = "Edit" Then
                    If dgReceivingList.Rows.Count <> 0 Then
                        getOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Me)
                        If globalorderstatus <> txtStatus.Text Then
                            MessageBox.Show("This R.R. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        getOrderIDSupA(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), txtRRNo.Text, globaliordertype:=OrderType.RR.ToString(), Me)
                        rrorderid = globalorderid
                        If rrorderid <> 0 Then
                            errProvider.SetError(txtRRNo, "R.R. No. has been created already, please type a new one.")
                            Exit Try
                        End If
                        M_U_Orders(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, rrsuppliercustomerid, txtRRNo.Text, dtpRRDate.Value,
                                DBNull.Value, txtComments.Text, 0, cboReceivedBy.Text, If(rrcontactid = 0, DBNull.Value, rrcontactid), dtpTimeArrived.Value, txtBrands.Text, txtContainerNo.Text, txtSealNo.Text, txtArrivedIn.Text, Me)
                        If txtRRType.Text <> "Blank" Then
                            If dgReceivingItems.Rows.Count <> 0 Then
                                For a = 0 To dgReceivingItems.Rows.Count - 1
                                    If myModule.systemerrorfound = False Then
                                        If IsNumeric(dgReceivingItems.Rows(a).Cells("ci_rowid").Value) Then
                                            If CInt(dgReceivingItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                                                getOrderItemApproveFlg(CInt(dgReceivingItems.Rows(a).Cells("ci_rowid").Value), Me)
                                                If globalorderitemapproveflg <> "Y" Then
                                                    M_U_OrderItems(CInt(dgReceivingItems.Rows(a).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0),
                                                        If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), CStr(dgReceivingItems.Rows(a).Cells("ci_remarks").Value), CStr(dgReceivingItems.Rows(a).Cells("ci_reason").Value), If(dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit, "Y", "N"), Me)
                                                    If dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit Then
                                                        getProductColorSizeTotalDamageQty((dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                        U_ProductColorSizeTotalDamageQty(CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtydamage + If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), Me)
                                                        I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), DBNull.Value, DBNull.Value, CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, DBNull.Value, globaltotalqtydamage,
                                                                If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), globaltotalqtydamage + If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), "Receiving", "TotalDamageQty", "", Me)
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Else
                                        Exit Try
                                    End If
                                Next
                            End If
                        Else
                            If dgReceivingItems.Rows.Count <> 0 Then
                                For a = 0 To dgReceivingItems.Rows.Count - 1
                                    If myModule.systemerrorfound = False Then
                                        If IsNumeric(dgReceivingItems.Rows(a).Cells("ci_rowid").Value) Then
                                            If CInt(dgReceivingItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                                                getOrderItemApproveFlg(CInt(dgReceivingItems.Rows(a).Cells("ci_rowid").Value), Me)
                                                If globalorderitemapproveflg <> "Y" Then
                                                    M_U_OrderItems(CInt(dgReceivingItems.Rows(a).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0),
                                                            If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), CStr(dgReceivingItems.Rows(a).Cells("ci_remarks").Value), CStr(dgReceivingItems.Rows(a).Cells("ci_reason").Value), If(dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit, "Y", "N"), Me)
                                                    If dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit Then
                                                        getProductColorSizeTotalDamageQty((dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                        U_ProductColorSizeTotalDamageQty(CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtydamage + If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), Me)
                                                        I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), DBNull.Value, DBNull.Value, CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, DBNull.Value, globaltotalqtydamage,
                                                                If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), globaltotalqtydamage + If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), "Receiving", "TotalDamageQty", "", Me)
                                                    End If
                                                End If
                                            Else
                                                If IsNumeric(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                                    If CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                                        getTotalQtyAvailableA(CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                        M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, rrsuppliercustomerid, CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                                                globaltotalqtyavailable, "S", "" & CStr(dgReceivingItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_seasoncode").Value) & "", CStr(dgReceivingItems.Rows(a).Cells("ci_sku").Value),
                                                                CStr(dgReceivingItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgReceivingItems.Rows(a).Cells("ci_remarks").Value), 0, "Active", If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0), If(dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit, "Y", "N"),
                                                                If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), CStr(dgReceivingItems.Rows(a).Cells("ci_reason").Value), Me)
                                                        If If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0) > 0 Then
                                                            DirectCommand("UPDATE productcolorsizes SET lastshipmentdate = """ & Format(dtpRRDate.Value, "yyyy/MM/dd") & """ WHERE rowid = " & CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) & " ")
                                                        End If
                                                        If dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit Then
                                                            getProductColorSizeTotalDamageQty((dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                            U_ProductColorSizeTotalDamageQty(CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtydamage + If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), Me)
                                                            I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), DBNull.Value, DBNull.Value, CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, DBNull.Value, globaltotalqtydamage,
                                                                    If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), globaltotalqtydamage + If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), "Receiving", "TotalDamageQty", "", Me)
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Else
                                            If IsNumeric(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                                If CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                                    getTotalQtyAvailableA(CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                    M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, rrsuppliercustomerid, CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                                            globaltotalqtyavailable, "S", "" & CStr(dgReceivingItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_seasoncode").Value) & "", CStr(dgReceivingItems.Rows(a).Cells("ci_sku").Value),
                                                            CStr(dgReceivingItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgReceivingItems.Rows(a).Cells("ci_remarks").Value), 0, "Active", If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0), If(dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit, "Y", "N"),
                                                            If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), CStr(dgReceivingItems.Rows(a).Cells("ci_reason").Value), Me)
                                                    If If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0) > 0 Then
                                                        DirectCommand("UPDATE productcolorsizes SET lastshipmentdate = """ & Format(dtpRRDate.Value, "yyyy/MM/dd") & """ WHERE rowid = " & CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) & " ")
                                                    End If
                                                    If dgReceivingItems.Rows(a).Cells("ci_approved").Value = legit Then
                                                        getProductColorSizeTotalDamageQty((dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                        U_ProductColorSizeTotalDamageQty(CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtydamage + If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), Me)
                                                        I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), DBNull.Value, DBNull.Value, CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, DBNull.Value, globaltotalqtydamage,
                                                                If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), globaltotalqtydamage + If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), "Receiving", "TotalDamageQty", "", Me)
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Else
                                        Exit Try
                                    End If
                                Next
                            End If
                        End If
                        If myModule.systemerrorfound = False Then
                            If dgReceivingItems.Rows.Count <> 0 Then
                                updateStatusToApproved(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                            End If
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

    Private Async Sub msOrder_Click(sender As Object, e As EventArgs) Handles msOrder.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Receiving", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RRForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgReceivingList.Rows.Count <> 0 Then
                If txtRRType.Text <> "Blank" Then
                    checkReceivingItemsQtyStocked(CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value))
                Else
                    checkReceivingItemsQtyStocked(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                End If
                If rrreceivingitemsqtystockedcue = legit Then
                    MessageBox.Show("System cannot cancel this R.R., since some receiving item/s has/have been stocked already.", "Cancelling", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                getOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Me)
                If globalorderstatus <> txtStatus.Text Then
                    MessageBox.Show("This R.R. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                ElseIf globalorderstatus = "For Approval" Then
                    If MessageBox.Show("NOTE: Once you cancelled this R.R., you cannot open this R.R. again." & vbNewLine & "" & vbNewLine & "Do you want to proceed cancelling this R.R.?", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgReceivingList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This R. R. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        If CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value) <> 0 Then
                            cancelReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value))
                            updateRelatedOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value), "New")
                        End If
                        If myModule.systemerrorfound = False Then
                            U_OrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
                            myBalloon("Successfully Cancelled", "Cancel", lblsavemsg, -15, -65)
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

    Private Sub btnStockToWarehouse_Click(sender As Object, e As EventArgs) Handles btnStockToWarehouse.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Stocking To Rack/Shelf/Column", Me)
                If globalupdateflg <> "Y" Then
                    MessageBox.Show("The user is not allowed stock the receiving items.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgReceivingList.Rows.Count <> 0 Then
                getOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Me)
                If globalorderstatus = "Cancelled" Then
                    MessageBox.Show("This R. R. has been cancelled.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            If dgReceivingItems.Rows.Count <> 0 Then
                getOrderItemStatus(CInt(dgReceivingItems.CurrentRow.Cells("ci_rowid").Value), Me)
                If globalorderitemstatus <> "Active" Then
                    MessageBox.Show("This receiving item is not available already.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If IsNumeric(dgReceivingItems.CurrentRow.Cells("ci_qtyreceived").Value) Then
                    If CInt(dgReceivingItems.CurrentRow.Cells("ci_qtyreceived").Value) > 0 Then
                        If CInt(dgReceivingItems.CurrentRow.Cells("ci_qtyreceived").Value) = If(IsNumeric(dgReceivingItems.CurrentRow.Cells("ci_qtystocked").Value), CInt(dgReceivingItems.CurrentRow.Cells("ci_qtystocked").Value), 0) Then
                            MessageBox.Show("Qty. received is equal to qty. stocked already.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                    Else
                        MessageBox.Show("There is no qty. received from this receiving item.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    MessageBox.Show("There is no qty. received from this receiving item.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("There is no receiving items.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            Dim stocklinkform As New StockForm
            stocklinkform.sforderitemid = CInt(dgReceivingItems.CurrentRow.Cells("ci_rowid").Value)
            stocklinkform.sfseqno = CStr(dgReceivingItems.CurrentRow.Cells("ci_seqno").Value)
            stocklinkform.sfprodcolorsizeid = CInt(dgReceivingItems.CurrentRow.Cells("ci_pcsrowid").Value)
            stocklinkform.sforderid = CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value)
            stocklinkform.sfinventorylocationid = CInt(cboInventoryLocation.SelectedValue)
            stocklinkform.sfqtyOrdered = CInt(dgReceivingItems.CurrentRow.Cells("ci_qtyordered").Value)
            stocklinkform.sfdamageqtyOrdered = CInt(dgReceivingItems.CurrentRow.Cells("ci_qtybad").Value)
            stocklinkform.ShowInTaskbar = False
            stocklinkform.ShowDialog()
            If stocklinkform.stockformcue = legit Then
                cboAccountName.Enabled = fraud
                'btnStockToWarehouse.Enabled = fraud
                btnAddAdditionalItems.Enabled = legit
                displayReceivingInformation(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                If txtRRType.Text <> "Blank" Then
                    ci_option.Visible = fraud
                    displayReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value))
                    If txtRRType.Text = OrderType.PO.ToString() Then
                        lblReferenceNo.Text = "Related P.O. No.:"
                    ElseIf txtRRType.Text = "Pull-Out" Then
                        lblReferenceNo.Text = "Related Pull-Out No.:"
                        btnAddAdditionalItems.Enabled = fraud
                    ElseIf txtRRType.Text = "Return" Then
                        lblReferenceNo.Text = "Related Return No.:"
                        btnAddAdditionalItems.Enabled = fraud
                    End If
                Else
                    ci_option.Visible = legit
                    displayReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                    lblReferenceNo.Text = "Related Ref. No.:"
                    cboAccountName.Enabled = legit
                End If
                receivingitemscomputation() : colorCoding()
                If txtStatus.Text = "For Approval" Then
                    enableANDvisibleMS(legit, legit, legit, fraud, legit)
                Else
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                End If
                txtRRNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub dgReceivingOrderItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReceivingItems.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgReceivingItems.Rows.Count <> 0 Then
                If e.ColumnIndex = dgReceivingItems.Columns("ci_option").Index Then
                    If txtRRType.Text <> "Blank" Then
                        Exit Try
                    End If
                    If IsNumeric(dgReceivingItems.CurrentRow.Cells("ci_rowid").Value) Then
                        If dgReceivingItems.CurrentRow.Cells("ci_rowid").Value = 0 Then
                            If dgReceivingItems.SelectedRows.Count > 0 Then
                                dgReceivingItems.Rows.Remove(dgReceivingItems.SelectedRows(0))
                            End If
                        Else
                            getPositionID(Me)
                            If globalpositionid <> 0 Then
                                getPositionView(globalpositionid, "Receiving", Me)
                                If globaldisableflg = "Y" Then
                                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    PrimaryForm.RRForm = False
                                    Me.Close()
                                End If
                                If globalreadonlyflg = "Y" Then
                                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                            Else
                                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                            If dgReceivingList.Rows.Count <> 0 Then
                                getOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Me)
                                If globalorderstatus <> "For Approval" Then
                                    MessageBox.Show("This R.R. has been cancelled or approved already.", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                                getOrderItemApproveFlg(CInt(dgReceivingItems.CurrentRow.Cells("ci_rowid").Value), Me)
                                If globalorderitemapproveflg = "Y" Then
                                    MessageBox.Show("This receiving item has been approved already.", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                                getTotalQtyAppliedA(CInt(dgReceivingItems.CurrentRow.Cells("ci_rowid").Value), Me)
                                If globaltotalqtyapplied <> 0 Then
                                    MessageBox.Show("This receiving item has been stocked already.", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                                If MessageBox.Show("Would you like to delete this item from this list?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    Me.Cursor = Cursors.WaitCursor
                                    getOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Me)
                                    If globalorderstatus <> "For Approval" Then
                                        MessageBox.Show("This R.R. has been cancelled or approved already.", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Try
                                    End If
                                    getOrderItemApproveFlg(CInt(dgReceivingItems.CurrentRow.Cells("ci_rowid").Value), Me)
                                    If globalorderitemapproveflg = "Y" Then
                                        MessageBox.Show("This receiving item has been approved already.", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Try
                                    End If
                                    getTotalQtyAppliedA(CInt(dgReceivingItems.CurrentRow.Cells("ci_rowid").Value), Me)
                                    If globaltotalqtyapplied <> 0 Then
                                        MessageBox.Show("This receiving item has been stocked already.", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Try
                                    End If
                                    If myModule.systemerrorfound = False Then
                                        U_OrderItemStatus(CInt(dgReceivingItems.CurrentRow.Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                                    End If
                                    If myModule.systemerrorfound = False Then
                                        If dgReceivingItems.SelectedRows.Count > 0 Then
                                            dgReceivingItems.Rows.Remove(dgReceivingItems.SelectedRows(0))
                                        End If
                                        myBalloon("Successfully Deleted", "Delete", lblsavemsg, -15, -65)
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If dgReceivingItems.SelectedRows.Count > 0 Then
                            dgReceivingItems.Rows.Remove(dgReceivingItems.SelectedRows(0))
                        End If
                    End If
                    itemno = startingpage
                    For i As Integer = 0 To dgReceivingItems.Rows.Count - 1
                        dgReceivingItems.Rows(i).Cells("ci_seqno").Value = itemno
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

    Private Sub msPrint_Click(sender As Object, e As EventArgs) Handles msPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Receiving", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RRForm = False
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
            If dgReceivingList.Rows.Count <> 0 Then
                getOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Me)
                If globalorderstatus <> txtStatus.Text Then
                    MessageBox.Show("This receiving has been updated by other user, please click refresh button to check the new status of this receiving.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If MessageBox.Show("Would you like to print this receiving?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getOrderStatus(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value), Me)
                    If globalorderstatus <> txtStatus.Text Then
                        MessageBox.Show("This receiving has been updated by other user, please click refresh button to check the new status of this receiving.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If myModule.systemerrorfound = False Then
                        If txtRRType.Text <> "Blank" Then
                            printReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_relatedorderid").Value))
                        Else
                            printReceivingItems(CInt(dgReceivingList.CurrentRow.Cells("rr_rowid").Value))
                        End If
                        Dim printreport As New ReceivingPrint
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
                errProvider.SetError(txtRRNo, "System cannot find the Receiving List to be printed.")
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
            ElseIf cboSearch1.Text = "SupplierName/CustomerName" Then
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
            ElseIf cboSearch3.Text = "SupplierName/CustomerName" Then
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
                If cboSearch1.Text = "" And cboSearch3.Text = "" Then
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "DateSearch"
                    spagenum = neutralpage : numofpages = startingpage
                    datephrase = "rr.orderdate"
                    displayDateSearch(spagenum, datephrase)
                    pageSetup2(datephrase)
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                ElseIf cboSearch2.Text = "" And cboSearch4.Text = "" Then
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "DateSearch"
                    spagenum = neutralpage : numofpages = startingpage
                    datephrase = "rr.orderdate"
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
                    pagefilter4 = "AND (rr.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                            "rr.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') GROUP BY po.rowid "
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
                    datephrase = "rr.orderdate"
                    displayDateSearch(spagenum, datephrase)
                    pageSetup2(datephrase)
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                ElseIf cboSearch2.Text = "" And cboSearch4.Text = "" Then
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "DateSearch"
                    spagenum = neutralpage : numofpages = startingpage
                    datephrase = "rr.orderdate"
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
                    pagefilter4 = "AND (rr.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                            "rr.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') GROUP BY po.rowid "
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
                displayReceivingOrderList(spagenum)
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
                displayReceivingOrderList(spagenum)
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
                displayReceivingOrderList(spagenum)
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
                displayReceivingOrderList(spagenum)
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
                            displayReceivingOrderList(spagenum)
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

    Private Sub dgReceivingItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgReceivingItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgReceivingItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgReceivingItems.BeginEdit(True)
                Else
                    dgReceivingItems.EndEdit()
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

    Private Sub dgReceivingList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgReceivingList.DataError
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
                dgReceivingList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgReceivingItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgReceivingItems.DataError
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
                dgReceivingItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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