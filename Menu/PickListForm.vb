Imports System.Threading
Imports CrystalDecisions.CrystalReports.Engine
Imports log4net
Imports Microsoft.Extensions.DependencyInjection
Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Helpers
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Desktop.Utilities
Imports PickListEntity = WarehouseManagementSystem.Core.Entities.PickList

Public Class PickListForm
    Private _logger As ILog = LogManager.GetLogger("PickListLogger")
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim conn2 As New MySqlConnection(manager.GetConnString)
    Dim conn3 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim plnewpicklist As New ArrayList
    Dim printdataset As New DataSetA.SetADataTable
    Dim printdatasetthurston As New DataSetA.SetGDataTable
    Dim printdatatable As New DataTable
    Dim sqlTran As MySqlTransaction
    Dim sqlquery As String
    Dim productimage As Object
    Dim cue, searchmode As String
    Dim itemno, rowscount As Integer
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim plincompleteqtytopickcue, plinsufficientqtyorderablecue As Boolean
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim simplesearchphrase, datephrase, commonphrase, pagefilter1, pagefilter2, plnewpicklistcreated, plgeneratepickliststatus As String
    Dim pluserid, plcountcos, plloadingbar, plinventorylocationdid, plpicklistid, plpicklistorderid, plcontactid, plpicklistorderitemid, plcustomerid, pllistofvalueid As Integer
    Dim ploverallqtyordered, pltotalqtyordered, pltotalqtypicked, ploverallqtytopick, plqtytopick, plqtytopickbalance, plqtyorderedsum, pltotalqtytopicksum, plqtytopicksum As Integer
    Private _systemOwner As WarehouseManagementSystem.Core.Entities.SystemOwner

    Private ReadOnly DEFAULT_PAGEOPTIONS As PageOptions = New PageOptions(pageIndex:=0, pageSize:=100, sort:="PickListDate,PickListNo", direction:="desc,asc")
    Private _pageOptions As PageOptions = DEFAULT_PAGEOPTIONS

    Private Async Sub PickListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayPickList(spagenum)
            colorCoding() : pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            ShowOrHideUserInterface()
        End Try
        Me.Cursor = Cursors.Default

        If IsThurston Then
            For Each comboBox In gbPickListInformation.Controls.
                OfType(Of Control).
                OfType(Of ComboBox).
                ToArray()

                SetStyleToDropDownList(comboBox)
            Next
        End If
    End Sub

    Private Sub PickListForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Sub callAutoCompleteFunctions()
        globalautocompleteContactName(cboPickerName, "Picker", Me)
        globalautocompleteLocationName(cboLocationName, Me)
    End Sub

    Sub callAutoPopulateFunctions()
        autopopulatecboSearch()
        globalautopopulateContactName(cboPickerName, "Picker", Me)
        globalautopopulateLocationName(cboLocationName, Me)
    End Sub

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearPickListInformation()
            clearCustomerOrders()
            clearCustomerOrderItems()
            clearRackShelfColumn()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visibleCustomerOrderItems(fraud)
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
            clearPickListInformation()
            clearCustomerOrders()
            clearCustomerOrderItems()
            clearRackShelfColumn()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visibleCustomerOrderItems(fraud)
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
            cboDate.SelectedItem = Nothing
            cboSearch1.SelectedItem = Nothing
            cboSearch2.SelectedItem = Nothing
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
            cboSearch2.Items.Clear() : cboSearch2.AutoCompleteCustomSource.Clear()
            cboSearch2.Text = "" : cboSearch2.SelectedItem = Nothing
            dtpFromSearch.Value = Now.Date.AddDays(-(Now.Day) + 1)
            dtpToSearch.Value = Now.Date
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearPickListInformation()
        Try
            txtPickListNo.Text = ""
            txtPickListDate.Text = ""
            txtStatus.Text = ""
            txtCompletedDate.Text = ""
            txtComments.Text = ""
            cboPickerName.Text = ""
            cboPickerName.SelectedItem = Nothing
            cboLocationName.Text = ""
            cboLocationName.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearCustomerOrders()
        Try
            txtOverallQtyOrdered.Text = ""
            txtOverallQtyToPick.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearCustomerOrderItems()
        Try
            chkOtherInfo.Checked = fraud
            lnkViewEditBundleItems.Visible = fraud
            txtTotalQtyOrdered.Text = ""
            txtTotalQtyToPick.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRackShelfColumn()
        Try
            txtQtyToPick.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearDatagrids()
        Try
            dgCustomerOrders.Rows.Clear()
            dgCustomerOrderItems.Rows.Clear()
            dgRackShelfColumn.Rows.Clear()
            msPrint.Text = "&Print"
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbPickList.Enabled = enable1
            gbPickListInformation.Enabled = enable2
            gbCustomerOrders.Enabled = enable2
            gbCustomerOrderItems.Enabled = enable2
            gbRackShelfColumn.Enabled = enable3
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub visibleCustomerOrderItems(ByVal visible1 As Boolean)
        Try
            ci_verifiedby.Visible = visible1
            ci_verifieddate.Visible = visible1
            ci_unitofmeasure.Visible = visible1
            ci_type.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub enableANDvisibleMS(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean, ByVal visible1 As Boolean)
        Try
            msNew.Enabled = enable1
            msSave.Enabled = enable2
            'msPrint.Enabled = enable3
            msOrder.Visible = visible1
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
            displayPickList(spagenum)
            colorCoding() : pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Computations"

    Sub getTotalQtyOrdered(ByVal icustomerorderid As Integer)
        Try
            pltotalqtyordered = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtTQo As New DataTable
            dtTQo = getDataTableForSQL("SELECT COALESCE(SUM(ci.qtyordered),0) FROM orderitems ci WHERE ci.orderid = " & icustomerorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.`status` != 'Inactive' AND ci.itemtype != 'B' ")
            If dtTQo.Rows.Count <> 0 Then
                pltotalqtyordered = dtTQo.Rows(0)(0)
            Else
                pltotalqtyordered = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getOverallQtyToPicked(ByVal ipicklistid As Integer, ByVal icustomerorderid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT plo.rowid FROM picklistorders plo LEFT JOIN orderitems ci ON plo.orderitemid = ci.rowid WHERE plo.picklistid = " & ipicklistid & " " &
                    "AND plo.orderid = " & icustomerorderid & " AND plo.organizationid = " & Z_OrganizationID & " AND plo.`status` != 'Inactive' AND ci.itemtype != 'B' "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyPickedA(CInt(reader1(0)))
                    ploverallqtytopick = ploverallqtytopick + pltotalqtypicked
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getTotalQtyPickedA(ByVal ipicklistorderid As Integer)
        Try
            pltotalqtypicked = 0
            If conn1.State = ConnectionState.Open Then conn1.Close()
            Dim dtTQo As New DataTable
            dtTQo = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtypicked),0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND pli.`status` != 'Inactive' ")
            If dtTQo.Rows.Count <> 0 Then
                pltotalqtypicked = dtTQo.Rows(0)(0)
            Else
                pltotalqtypicked = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub getTotalQtyPickedB(ByVal ipicklistorderid As Integer, ByVal iproductinventorylocationid As Integer)
        Try
            pltotalqtypicked = 0
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim dtTQo As New DataTable
            dtTQo = getDataTableForSQL("SELECT COALESCE(pli.qtypicked,0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND pli.productinventorylocationid = " & iproductinventorylocationid & "")
            If dtTQo.Rows.Count <> 0 Then
                pltotalqtypicked = dtTQo.Rows(0)(0)
            Else
                pltotalqtypicked = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub picklistformcomputations()
        Try
            ploverallqtyordered = 0 : ploverallqtytopick = 0 : plqtyorderedsum = 0 : pltotalqtytopicksum = 0 : plqtytopicksum = 0
            If dgPickList.Rows.Count <> 0 Then
                If dgCustomerOrders.Rows.Count <> 0 Then
                    For i = 0 To dgCustomerOrders.Rows.Count - 1
                        getTotalQtyOrdered(CInt(dgCustomerOrders.Rows(i).Cells("co_rowid").Value))
                        ploverallqtyordered = ploverallqtyordered + pltotalqtyordered
                        getOverallQtyToPicked(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.Rows(i).Cells("co_rowid").Value))
                    Next
                End If
            End If
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value) Then
                        If CStr(dgCustomerOrderItems.Rows(i).Cells("ci_type").Value) = "S" Then
                            plqtyorderedsum = plqtyorderedsum + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value)
                        End If
                    End If
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtytopick").Value) Then
                        If CStr(dgCustomerOrderItems.Rows(i).Cells("ci_type").Value) = "S" Then
                            pltotalqtytopicksum = pltotalqtytopicksum + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtytopick").Value)
                        End If
                    End If
                Next
            End If
            If dgRackShelfColumn.Rows.Count <> 0 Then
                For i = 0 To dgRackShelfColumn.Rows.Count - 1
                    If IsNumeric(dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Value) Then
                        plqtytopicksum = plqtytopicksum + CInt(dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Value)
                    End If
                Next
            End If
            txtOverallQtyOrdered.Text = Format(ploverallqtyordered, "#,##0")
            txtOverallQtyToPick.Text = Format(ploverallqtytopick, "#,##0")
            txtTotalQtyOrdered.Text = Format(plqtyorderedsum, "#,##0")
            txtTotalQtyToPick.Text = Format(pltotalqtytopicksum, "#,##0")
            txtQtyToPick.Text = Format(plqtytopicksum, "#,##0")
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
            dtCid = getDataTableForSQL("SELECT COUNT(pl.rowid) FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " ")
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
            dtCid = getDataTableForSQL("Select COALESCE(COUNT(pl.rowid),0) FROM picklist pl LEFT JOIN contacts co On pl.contactid = co.rowid WHERE pl.organizationid = " & Z_OrganizationID & " And " &
                            "(pl.picklistno Like ""%" & esearchstring & "%"" Or pl.status Like ""%" & esearchstring & "%"" Or co.firstname Like ""%" & esearchstring & "%"" Or co.lastname Like ""%" & esearchstring & "%"") ")
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
            dtCid = getDataTableForSQL("Select COALESCE(COUNT(pl.rowid),0) FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " And " &
                            "(" & edatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' " &
                            "AND " & edatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(pl.rowid),0) FROM picklist pl LEFT JOIN picklistorders plo ON pl.rowid = plo.picklistid LEFT JOIN orders co ON plo.orderid = co.rowid WHERE pl.organizationid = " & Z_OrganizationID & " AND " & ecommonstring & " " & edatesearch & " ")
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
                plcustomerid = globalcustomerid
                commonphrase = "co.accountid =  " & plcustomerid & ""
            ElseIf icommonbox.Text = "PickerName" Then
                getContactID(icommonstring, "Picker", Me)
                plcontactid = globalcontactid
                commonphrase = "pl.contactid = " & plcontactid & ""
            ElseIf icommonbox.Text = "Status" Then
                commonphrase = "pl.status = """ & icommonstring & """"
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
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'') AS 'customername' FROM picklist pl LEFT JOIN picklistorders plo ON pl.rowid = plo.picklistid " &
                            "LEFT JOIN orders co ON plo.orderid = co.rowid LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE pl.organizationid = " & Z_OrganizationID & " GROUP BY cu.rowid ", conn)
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

    Sub autocompletePickerName(ByVal icombobox As ComboBox)
        Try
            Dim contactname As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'firstname' FROM picklist pl LEFT JOIN contacts c ON pl.contactid = c.rowid WHERE pl.organizationid = " & Z_OrganizationID & " GROUP BY c.rowid ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.lastname,''),', ',COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'lastname' FROM picklist pl LEFT JOIN contacts c ON pl.contactid = c.rowid WHERE pl.organizationid = " & Z_OrganizationID & " GROUP BY c.rowid ", globalconn)
            Dim da1 As New MySqlDataAdapter(cmd1)
            Dim da2 As New MySqlDataAdapter(cmd2)
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            da1.Fill(ds1, "list1")
            da2.Fill(ds2, "list2")
            Dim i As Integer
            For i = 0 To ds1.Tables(0).Rows.Count - 1
                contactname.Add(ds1.Tables(0).Rows(i)("firstname").ToString())
            Next
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                contactname.Add(ds2.Tables(0).Rows(i)("lastname").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = contactname
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub autocompleteStatus(ByVal icombobox As ComboBox)
        Try
            Dim plstatus As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(pl.status,'') AS 'plstatus' FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " GROUP BY pl.status ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                plstatus.Add(ds.Tables(0).Rows(i)("plstatus").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = plstatus
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
            cboDate.Items.Add("CompletedDate")
            cboDate.Items.Add("PickListDate")
            cboDate.Items.Add("")
            cboSearch1.Items.Clear()
            cboSearch1.Items.Add("CustomerName")
            cboSearch1.Items.Add("PickerName")
            cboSearch1.Items.Add("Status")
            cboSearch1.Items.Add("")
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
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'') AS 'customername' FROM picklist pl LEFT JOIN picklistorders plo ON pl.rowid = plo.picklistid " &
                            "LEFT JOIN orders co ON plo.orderid = co.rowid LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE pl.organizationid = " & Z_OrganizationID & " GROUP BY cu.rowid ORDER BY cu.companyname "
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

    Sub autopopulatePickerName(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'firstname' FROM picklist pl LEFT JOIN contacts c ON pl.contactid = c.rowid WHERE pl.organizationid = " & Z_OrganizationID & " GROUP BY c.rowid ORDER BY c.firstname "
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
            Dim sql1 As String = "SELECT COALESCE(pl.status,'') AS 'plstatus' FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " GROUP BY pl.status ORDER BY pl.status "
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

    Async Sub displayPickList(ByVal istartpage As Integer)
        Try
            dgPickList.Rows.Clear()
            'If conn.State = ConnectionState.Closed Then conn.Open()
            'Dim sql1 As String = "SELECT pl.rowid,COALESCE(pl.picklistno,''),DATE_FORMAT(pl.picklistdate,'%d-%b-%Y'),COALESCE(pl.status,'') FROM picklist pl " &
            '            "WHERE pl.organizationid = " & Z_OrganizationID & " ORDER BY pl.picklistdate DESC,pl.picklistno LIMIT " & istartpage & "," & pagedivisor & " "
            'Dim cmd1 As New MySqlCommand(sql1, conn)
            'Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            'While reader1.Read()
            '    If reader1.HasRows Then
            '        dgPickList.Rows.Add()
            '        dgPickList.Item(pl_rowid.Index, n).Value = reader1(0)
            '        dgPickList.Item(pl_picklistno.Index, n).Value = reader1(1)
            '        dgPickList.Item(pl_picklistdate.Index, n).Value = reader1(2)
            '        dgPickList.Item(pl_status.Index, n).Value = reader1(3)
            '        n = n + 1
            '    End If
            'End While
            'reader1.Close()

            Dim pickLists = (Await LoadPickListsAsync()).Items
            For Each pickList In pickLists
                dgPickList.Rows.Add()
                dgPickList.Item(pl_rowid.Name, n).Value = pickList.RowID
                dgPickList.Item(pl_picklistno.Name, n).Value = pickList.PickListNo
                dgPickList.Item(pl_picklistdate.Name, n).Value = $"{pickList.PickListDate:MMM dd, yyyy}"
                dgPickList.Item(pl_status.Name, n).Value = pickList.Status.ToString()
                n += 1
            Next

            dgPickList.Columns("pl_picklistno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_picklistdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPickList.Rows.Count <> 0 Then
                dgPickList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Function LoadPickListsAsync() As Task(Of PaginatedList(Of WarehouseManagementSystem.Core.Entities.PickList))
        Dim pickListDataService = GetRequiredService(Of IPickListDataService)()
        Dim result = Await pickListDataService.GetPaginatedPickListsAsync(
            pageOptions:=_pageOptions,
            organizationId:=Z_OrganizationID,
            searchText:=String.Empty)
        Return result
    End Function

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgPickList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pl.rowid,COALESCE(pl.picklistno,''),DATE_FORMAT(pl.picklistdate,'%d-%b-%Y'),COALESCE(pl.status,'') FROM picklist pl " &
                        "LEFT JOIN contacts co ON pl.contactid = co.rowid WHERE pl.organizationid = " & Z_OrganizationID & " AND " &
                        "(pl.picklistno LIKE ""%" & isearchphrase & "%"" OR pl.status LIKE ""%" & isearchphrase & "%"" OR co.firstname LIKE ""%" & isearchphrase & "%"" OR co.lastname LIKE ""%" & isearchphrase & "%"") " &
                        "ORDER BY pl.picklistdate DESC,pl.picklistno LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPickList.Rows.Add()
                    dgPickList.Item(pl_rowid.Index, n).Value = reader1(0)
                    dgPickList.Item(pl_picklistno.Index, n).Value = reader1(1)
                    dgPickList.Item(pl_picklistdate.Index, n).Value = reader1(2)
                    dgPickList.Item(pl_status.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPickList.Columns("pl_picklistno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_picklistdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPickList.Rows.Count <> 0 Then
                dgPickList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayDateSearch(ByVal istartpage As Integer, ByVal idatesearch As String)
        Try
            dgPickList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pl.rowid,COALESCE(pl.picklistno,''),DATE_FORMAT(pl.picklistdate,'%d-%b-%Y'),COALESCE(pl.status,'') FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " " &
                        "AND (" & idatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                        "" & idatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) " &
                        "GROUP BY pl.rowid ORDER BY pl.picklistdate DESC,pl.picklistno LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPickList.Rows.Add()
                    dgPickList.Item(pl_rowid.Index, n).Value = reader1(0)
                    dgPickList.Item(pl_picklistno.Index, n).Value = reader1(1)
                    dgPickList.Item(pl_picklistdate.Index, n).Value = reader1(2)
                    dgPickList.Item(pl_status.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPickList.Columns("pl_picklistno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_picklistdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPickList.Rows.Count <> 0 Then
                dgPickList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal idatesearch As String, ByVal istartpage As Integer)
        Try
            dgPickList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pl.rowid,COALESCE(pl.picklistno,''),DATE_FORMAT(pl.picklistdate,'%d-%b-%Y'),COALESCE(pl.status,'') FROM picklist pl " &
                        "LEFT JOIN picklistorders plo ON pl.rowid = plo.picklistid LEFT JOIN orders co ON plo.orderid = co.rowid " &
                        "LEFT JOIN accounts cu ON co.accountid = cu.rowid LEFT JOIN picklistgroup pg ON cu.picklistgroupid = pg.rowid " &
                        "WHERE pl.organizationid = " & Z_OrganizationID & " AND " & icommonphrase & " " & idatesearch & " " &
                        "GROUP BY pl.rowid ORDER BY pl.picklistdate DESC,pl.picklistno LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPickList.Rows.Add()
                    dgPickList.Item(pl_rowid.Index, n).Value = reader1(0)
                    dgPickList.Item(pl_picklistno.Index, n).Value = reader1(1)
                    dgPickList.Item(pl_picklistdate.Index, n).Value = reader1(2)
                    dgPickList.Item(pl_status.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPickList.Columns("pl_picklistno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_picklistdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPickList.Rows.Count <> 0 Then
                dgPickList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayPickListInformation(ByVal ipicklistid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(pl.picklistno,''),DATE_FORMAT(pl.picklistdate,'%d-%b-%Y'),COALESCE(DATE_FORMAT(pl.completeddate,'%d-%b-%Y'),'')," &
                        "COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'')," &
                        "COALESCE(pl.status,''),COALESCE(il.name,''),COALESCE(pl.comments,'') FROM picklist pl LEFT JOIN contacts c ON pl.contactid = c.rowid " &
                        "LEFT JOIN inventorylocations il ON pl.inventorylocationid = il.rowid WHERE pl.rowid = " & ipicklistid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtPickListNo.Text = reader1(0)
                    txtPickListDate.Text = reader1(1)
                    txtCompletedDate.Text = reader1(2)
                    cboPickerName.Text = reader1(3)
                    txtStatus.Text = reader1(4)
                    cboLocationName.Text = reader1(5)
                    txtComments.Text = reader1(6)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Async Sub displayCustomerOrdersA(ByVal ipicklistid As Integer)
        Try
            dgCustomerOrders.Rows.Clear()

            Dim sql = <![CDATA[SELECT GROUP_CONCAT(i.`Result`) `Result` FROM (SELECT COALESCE(plo.orderid,0) `Result` FROM picklistorders plo LEFT JOIN orders co ON plo.orderid = co.rowid WHERE plo.organizationid = @organizationId AND plo.picklistid = @picklistid AND plo.`status` != 'Inactive' GROUP BY plo.orderid ORDER BY co.targetdate ASC) i;]]>.Value

            Using connection As New MySqlConnection(manager.GetConnString),
                command As New MySqlCommand(sql, connection)

                With command.Parameters
                    .AddWithValue("@organizationId", Z_OrganizationID)
                    .AddWithValue("@picklistid", ipicklistid)
                End With

                Await connection.OpenAsync()
                Dim reader = Await command.ExecuteReaderAsync()

                While Await reader.ReadAsync()
                    Dim icustomerorderid As String = ""

                    If Not reader.IsDBNull(0) Then icustomerorderid = reader.GetFieldValue(Of String)(0)

                    displayCustomerOrdersB(icustomerorderid)
                End While
            End Using

            dgCustomerOrders.Columns("co_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_customerorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_customerorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_targetdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_canceldate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Async Sub displayCustomerOrdersB(ByVal icustomerorderid As String)
        Try
            Dim sql = <![CDATA[
                SELECT co.rowid,
                COALESCE(co.ordernumber, ''),
                COALESCE(CONCAT(COALESCE(cu.companyname, ''), ' - ', COALESCE(cu.accountno, '')), ''),
                DATE_FORMAT(co.orderdate, '%d-%b-%Y'),
                DATE_FORMAT(co.targetdate, '%d-%b-%Y'),
                COALESCE(co.status, ''),
                COALESCE(pg.groupname, ''),
                COALESCE(co.referencenumber, ''),
                DATE_FORMAT(co.enddate, '%d-%b-%Y'),
                i.`InventoryLocationNames`,
                co.accountid
                FROM orders co
                LEFT JOIN accounts cu ON co.accountid = cu.rowid
                LEFT JOIN picklistgroup pg ON cu.picklistgroupid = pg.rowid
                INNER JOIN (SELECT o.RowID, GROUP_CONCAT(IFNULL(il.Name, '')) `InventoryLocationNames` FROM orders o INNER JOIN orderitems oi ON oi.OrderID=o.RowID INNER JOIN productinventorylocation pil ON pil.RowID=oi.ProductInventoryLocationId INNER JOIN rackshelfcolumn r ON r.RowID=pil.RackShelfColumnID INNER JOIN inventorylocations il ON il.RowID=r.InventoryLocationID WHERE FIND_IN_SET(o.RowID, @orderIds) > 0 GROUP BY o.RowID) i ON i.RowID=co.RowID
                WHERE FIND_IN_SET(co.rowid, @orderIds) > 0;
            ]]>.Value

            Using connection As New MySqlConnection(manager.GetConnString),
                command As New MySqlCommand(sql, connection)

                With command.Parameters
                    .AddWithValue("@organizationId", Z_OrganizationID)
                    .AddWithValue("@orderIds", icustomerorderid)
                End With

                Await connection.OpenAsync()
                Dim reader = Await command.ExecuteReaderAsync()

                While Await reader.ReadAsync()
                    Dim rowIndex = dgCustomerOrders.Rows.Add()
                    With dgCustomerOrders.Rows(rowIndex)
                        '.Cells(TickBoxOrdersColumn.Name).Value = False
                        .Cells(co_seqno.Name).Value = rowIndex + 1
                        .Cells(co_rowid.Name).Value = reader(0)
                        .Cells(co_customerorderno.Name).Value = reader(1)
                        .Cells(co_customername.Name).Value = reader(2)
                        .Cells(co_customerorderdate.Name).Value = reader(3)
                        .Cells(co_targetdate.Name).Value = reader(4)
                        .Cells(co_status.Name).Value = reader(5)
                        .Cells(co_pono.Name).Value = reader(7)
                        .Cells(co_canceldate.Name).Value = reader(8)
                        .Cells(co_inventorylocation.Name).Value = reader(9)
                        .Tag = CInt(reader(10))
                    End With
                End While
            End Using
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Private Async Function displayCustomerOrderItems(ByVal ipicklistid As Integer, ByVal icustomerorderid As Integer) As Task
        Try
            dgCustomerOrderItems.Rows.Clear()

            Dim sql = <![CDATA[
                SELECT
	                ci.rowid,
	                COALESCE(ci.productcolorsizeid, 0),
	                COALESCE(ci.productbundleid, 0),
	                COALESCE(c.colorvalue, ''),
	                COALESCE(p.productcode, ''),
	                COALESCE(b.bundlename, ''),
	                COALESCE(c.colorname, ''),
	                COALESCE(pcs.size, ''),
	                COALESCE(pcs.seasoncode, ''),
	                COALESCE(ci.qtyordered, 0),
	                COALESCE(pcs.sku, ''),
	                COALESCE(b.sku, ''),
	                COALESCE(ci.unitofmeasure, ''),
	                COALESCE(ci.itemtype, ''),
	                COALESCE(ci.remarks, ''),
	                plo.`Status`,
	                COALESCE(
		                CONCAT(
			                COALESCE(vb.firstname, ''),
			                ' ',
			                COALESCE(vb.lastname, ''),
			                ' - ',
			                COALESCE(vb.rowid, '')
		                ),
		                ''
	                ),
	                COALESCE(
		                DATE_FORMAT(ci.verifieddate, '%d-%b-%Y'),
		                ''
	                ),
	                COALESCE(ci.sku, ''),
					il.`Name` `InventoryLocationName`,
					ci.ProductInventoryLocationId,
					pil.RackShelfColumnID,
					r.InventoryLocationID
                FROM
	                orderitems ci
	                LEFT JOIN productbundles b ON ci.productbundleid = b.rowid
	                LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid
	                LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid
	                LEFT JOIN colors c ON pc.colorid = c.rowid
	                LEFT JOIN products p ON pc.productid = p.rowid
	                LEFT JOIN users vb ON ci.verifiedby = vb.rowid
	                INNER JOIN picklistorders plo ON plo.picklistid = @ipicklistid
	                AND plo.orderid = ci.OrderID
	                AND plo.organizationid = ci.organizationid
	                AND plo.orderitemid = ci.rowid
						INNER JOIN productinventorylocation pil ON pil.RowID=ci.ProductInventoryLocationId
						INNER JOIN rackshelfcolumn r ON r.RowID=pil.RackShelfColumnID
						INNER JOIN inventorylocations il ON il.RowID=r.InventoryLocationID
                WHERE
	                ci.orderid = @icustomerorderid
	                AND ci.organizationid = @organizationId
	                AND ci.status != 'Inactive'
	                AND ci.itemtype != 'BI'
                ORDER BY
	                ci.rowid;
            ]]>.Value

            Using connection As New MySqlConnection(manager.GetConnString),
                command As New MySqlCommand(sql, connection),
                adapter As New MySqlDataAdapter

                With command.Parameters
                    .AddWithValue("@organizationId", Z_OrganizationID)
                    .AddWithValue("@ipicklistid", ipicklistid)
                    .AddWithValue("@icustomerorderid", icustomerorderid)
                End With

                Await connection.OpenAsync()

                adapter.SelectCommand = command
                Dim dataSet As New DataSet
                adapter.Fill(dataSet)
                Dim datasource = dataSet.Tables.OfType(Of DataTable).FirstOrDefault()

                For Each drow As DataRow In datasource.Rows
                    Dim n = dgCustomerOrderItems.Rows.Add()

                    dgCustomerOrderItems.Item(ci_seqno.Index, n).Value = n + 1
                    dgCustomerOrderItems.Item(ci_rowid.Index, n).Value = drow(0)
                    dgCustomerOrderItems.Item(ci_pcsrowid.Index, n).Value = drow(1)
                    dgCustomerOrderItems.Item(ci_bid.Index, n).Value = drow(2)
                    dgCustomerOrderItems.Item(ci_colorvalue.Index, n).Value = drow(3)
                    If CInt(drow(1)) <> 0 Then
                        dgCustomerOrderItems.Item(ci_itemcode.Index, n).Value = drow(4)
                    Else
                        dgCustomerOrderItems.Item(ci_itemcode.Index, n).Value = drow(5)
                    End If
                    dgCustomerOrderItems.Item(ci_colorname.Index, n).Value = drow(6)
                    dgCustomerOrderItems.Item(ci_size.Index, n).Value = drow(7)
                    dgCustomerOrderItems.Item(ci_seasoncode.Index, n).Value = drow(8)
                    dgCustomerOrderItems.Item(ci_qtyordered.Index, n).Value = drow(9)
                    getPickListOrderID(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value), CInt(drow(0)), Me)
                    plpicklistorderid = globalpicklistorderid : getTotalQtyPickedA(plpicklistorderid)
                    If CInt(drow(1)) <> 0 Then
                        dgCustomerOrderItems.Item(ci_totalqtytopick.Index, n).Value = pltotalqtypicked
                        If LTrim(CStr(drow(18))) = "" Then
                            dgCustomerOrderItems.Item(ci_sku.Index, n).Value = drow(10)
                        Else
                            dgCustomerOrderItems.Item(ci_sku.Index, n).Value = drow(18)
                        End If
                    Else
                        dgCustomerOrderItems.Item(ci_sku.Index, n).Value = drow(11)
                        dgCustomerOrderItems.Item(ci_totalqtytopick.Index, n).Value = ""
                    End If
                    dgCustomerOrderItems.Item(ci_unitofmeasure.Index, n).Value = drow(12)
                    dgCustomerOrderItems.Item(ci_type.Index, n).Value = drow(13)
                    dgCustomerOrderItems.Item(ci_remarks.Index, n).Value = drow(14)
                    If CInt(drow(1)) <> 0 Then
                        dgCustomerOrderItems.Item(ci_status.Index, n).Value = drow(15)
                        dgCustomerOrderItems.Item(ci_verifiedby.Index, n).Value = drow(16)
                        dgCustomerOrderItems.Item(ci_verifieddate.Index, n).Value = drow(17)
                    Else
                        dgCustomerOrderItems.Item(ci_status.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_verifiedby.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_verifieddate.Index, n).Value = ""
                    End If

                    If Not CInt(dgCustomerOrderItems.Item(ci_qtyordered.Index, n).Value) = CInt(dgCustomerOrderItems.Item(ci_totalqtytopick.Index, n).Value) Then
                        Dim row = dgCustomerOrderItems.Rows.OfType(Of DataGridViewRow).Where(Function(t) t.Index = n).FirstOrDefault()

                        If row IsNot Nothing Then
                            With row.DefaultCellStyle
                                .ForeColor = Drawing.Color.Red
                                .SelectionForeColor = Drawing.Color.Red
                            End With
                        End If
                    End If

                    dgCustomerOrderItems.Item(Column1.Name, n).Value = drow(19)
                    dgCustomerOrderItems.Item(Column2.Name, n).Value = drow(20)
                    dgCustomerOrderItems.Item(Column3.Name, n).Value = drow(21)
                    dgCustomerOrderItems.Item(Column4.Name, n).Value = drow(22)
                Next
            End Using

            dgCustomerOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_itemcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_totalqtytopick").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_verifieddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                dgCustomerOrderItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Function

    Private Async Function displayRackShelfColumn(ByVal iproductcolorsizeid As Integer, ByVal iinventorylocationid As Integer) As Task
        Try
            dgRackShelfColumn.Rows.Clear()

            Dim sql = <![CDATA[
                SELECT
	                pil.rowid,
	                COALESCE(rsc.rackno, ''),
	                COALESCE(rsc.shelfno, ''),
	                COALESCE(rsc.columnno, ''),
	                COALESCE(pil.totalavailableqty, 0),
	                COALESCE(rsc.pickorderno, 0),
	                COALESCE(pil.totalallocatedqty, 0)
                FROM
	                productinventorylocation pil
	                INNER JOIN rackshelfcolumn rsc ON rsc.`Status` != 'Inactive'
	                AND pil.rackshelfcolumnid = rsc.rowid
	                AND rsc.inventorylocationid = @iinventorylocationid
                WHERE
	                pil.organizationid = @organizationId
	                AND pil.productcolorsizeid = @iproductcolorsizeid
                ORDER BY
	                rsc.pickorderno ASC;
            ]]>.Value

            Using connection As New MySqlConnection(manager.GetConnString),
            command As New MySqlCommand(sql, connection),
                adapter As New MySqlDataAdapter

                With command.Parameters
                    .AddWithValue("@organizationId", Z_OrganizationID)
                    .AddWithValue("@iproductcolorsizeid", iproductcolorsizeid)
                    .AddWithValue("@iinventorylocationid", iinventorylocationid)
                End With

                Await connection.OpenAsync()

                adapter.SelectCommand = command
                Dim dataSet As New DataSet
                adapter.Fill(dataSet)
                Dim datasource = dataSet.Tables.OfType(Of DataTable).FirstOrDefault()

                For Each drow As DataRow In datasource.Rows
                    Dim n = dgRackShelfColumn.Rows.Add()
                    dgRackShelfColumn.Item(rsc_rowid.Name, n).Value = drow(0)
                    dgRackShelfColumn.Item(rsc_rack.Name, n).Value = drow(1)
                    dgRackShelfColumn.Item(rsc_shelf.Name, n).Value = drow(2)
                    dgRackShelfColumn.Item(rsc_column.Name, n).Value = drow(3)
                    getPickListOrderID(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                    plpicklistorderid = globalpicklistorderid
                    getTotalQtyPickedB(plpicklistorderid, CInt(drow(0)))
                    getPickListOrderItemInfo(plpicklistorderid, CInt(drow(0)), Me)
                    dgRackShelfColumn.Item(rsc_qtytopick.Name, n).Value = pltotalqtypicked
                    dgRackShelfColumn.Item(rsc_qtyavailable.Name, n).Value = drow(4)
                    dgRackShelfColumn.Item(rsc_pickorderno.Name, n).Value = drow(5)
                    dgRackShelfColumn.Item(rsc_qtyallocated.Name, n).Value = drow(6)
                    dgRackShelfColumn.Item(rsc_qtyorderable.Name, n).Value = CInt(drow(4)) - CInt(drow(6))
                    If globalpicklistorderitemissueflg = "Y" Then
                        dgRackShelfColumn.Item(rsc_issueflg.Name, n).Value = legit
                    Else
                        dgRackShelfColumn.Item(rsc_issueflg.Name, n).Value = fraud
                    End If
                    dgRackShelfColumn.Item(rsc_remarks.Name, n).Value = globalpicklistorderitemremarks
                Next
            End Using

            dgRackShelfColumn.Columns("rsc_rack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_shelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_column").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_qtytopick").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_qtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_qtyorderable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_pickorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgRackShelfColumn.Rows.Count <> 0 Then
                dgRackShelfColumn.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Function

    Function getPickQty(ByVal orderItemId As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim dtTQo As New DataTable
            dtTQo = getDataTableForSQL("SELECT ploi.QtyPicked
	                                        FROM picklistorderitems ploi JOIN 
	                                        (orderitems oi JOIN picklistorders plo ON oi.RowID = plo.OrderItemID) ON ploi.PickListOrderID = plo.RowID
	
	                                        WHERE 
		                                        oi.RowID = " & orderItemId & "")

            If dtTQo.Rows.Count <> 0 Then
                Return dtTQo.Rows(0)(0)
            End If
            Return 0

        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Function

#End Region

#Region "Colors"

    Sub colorCoding()
        Try
            If dgPickList.Rows.Count <> 0 Then
                For i As Integer = 0 To dgPickList.Rows.Count - 1
                    If dgPickList.Rows(i).Cells(pl_status.Index).Value = "New" Then
                        dgPickList.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.LightYellow
                    ElseIf dgPickList.Rows(i).Cells(pl_status.Index).Value = "Modified" Then
                        dgPickList.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.PowderBlue
                    ElseIf dgPickList.Rows(i).Cells(pl_status.Index).Value = "Cancelled" Then
                        dgPickList.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.MistyRose
                    ElseIf dgPickList.Rows(i).Cells(pl_status.Index).Value = "Completed" Then
                        dgPickList.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.Honeydew
                    End If
                Next
            End If
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgCustomerOrderItems.Rows.Count - 1
                    If dgCustomerOrderItems.Rows(i).Cells(ci_type.Index).Value = "B" Then
                        dgCustomerOrderItems.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.PaleGreen
                    Else
                        If CStr(dgCustomerOrderItems.Rows(i).Cells("ci_colorvalue").Value) <> "" Then
                            readcolor = colorconverter.ConvertFromString(CStr(dgCustomerOrderItems.Rows(i).Cells("ci_colorvalue").Value))
                            dgCustomerOrderItems.Rows(i).Cells("ci_color").Style.BackColor = readcolor
                        End If
                    End If
                Next
            End If
            If dgRackShelfColumn.Rows.Count <> 0 Then
                For i As Integer = 0 To dgRackShelfColumn.Rows.Count - 1
                    dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Style.BackColor = Drawing.Color.Gainsboro
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

#Region "Generating"

    Sub countCustomerOrders()
        Try
            plloadingbar = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCOs As New DataTable
            dtCOs = getDataTableForSQL("SELECT COALESCE(COUNT(co.rowid),0) FROM orders co WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'Submitted To Warehouse' ")
            If dtCOs.Rows.Count <> 0 Then
                plloadingbar = dtCOs.Rows(0)(0)
            Else
                plloadingbar = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub countPickListGroupsA()
        Try
            plcountcos = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCOs As New DataTable
            dtCOs = getDataTableForSQL("SELECT COALESCE(COUNT(co.rowid),0) FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & $"  AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'Submitted To Warehouse' AND cu.picklistgroupid IS NOT NULL ")
            If dtCOs.Rows.Count <> 0 Then
                plcountcos = dtCOs.Rows(0)(0)
            Else
                plcountcos = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub countPickListGroupsB()
        Try
            plcountcos = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCOs As New DataTable
            dtCOs = getDataTableForSQL("SELECT COALESCE(COUNT(co.rowid),0) FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'Submitted To Warehouse' AND cu.picklistgroupid IS NULL ")
            If dtCOs.Rows.Count <> 0 Then
                plcountcos = dtCOs.Rows(0)(0)
            Else
                plcountcos = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCustomerPickListGroups()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(cu.picklistgroupid,0) FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & " " &
                        $"AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'Submitted To Warehouse' AND cu.picklistgroupid IS NOT NULL GROUP BY cu.picklistgroupid ORDER BY co.targetdate ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getPickListNoA(Me)
                    I_PickList(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, plinventorylocationdid, globalpicklistno, Date.Now.ToString("yyyy/MM/dd"), "New", "", Me)
                    plpicklistid = globalpicklistidsp : plnewpicklist.Add(globalpicklistno)
                    If myModule.systemerrorfound = False Then
                        getCustomerOrdersA(CInt(reader1(0)))
                    Else
                        Exit Try
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

    Sub getCustomerOrdersA(ByVal ipicklistgroupid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT co.rowid FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & " " &
                        $"AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'Submitted To Warehouse' AND cu.picklistgroupid = " & ipicklistgroupid & " ORDER BY co.targetdate ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    plinsufficientqtyorderablecue = fraud
                    checkCustomerOrderItemsQtyOrderable(CInt(reader1(0)))
                    'If plinsufficientqtyorderablecue = fraud Then
                    getCustomerOrderItems(CInt(reader1(0)), plpicklistid)
                    If myModule.systemerrorfound = False Then
                        U_OrderStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Pick Listed", Me)
                        If PrimaryForm.MainLoadingBar.Value < plloadingbar Then
                            PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                        End If
                    Else
                        Exit Try
                    End If
                    'Else
                    '    If PrimaryForm.MainLoadingBar.Value < plloadingbar Then
                    '        PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                    '    End If
                    'End If
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub getCustomerOrdersB()
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT co.rowid FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & " " &
                        $"AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'Submitted To Warehouse' AND cu.picklistgroupid IS NULL ORDER BY co.targetdate ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getPickListNoA(Me)
                    I_PickList(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, plinventorylocationdid, globalpicklistno, Date.Now.ToString("yyyy/MM/dd"), "New", "", Me)
                    plpicklistid = globalpicklistidsp : plnewpicklist.Add(globalpicklistno)
                    If myModule.systemerrorfound = False Then
                        plinsufficientqtyorderablecue = fraud
                        checkCustomerOrderItemsQtyOrderable(CInt(reader1(0)))
                        If plinsufficientqtyorderablecue = fraud Then
                            getCustomerOrderItems(CInt(reader1(0)), plpicklistid)
                            If myModule.systemerrorfound = False Then
                                U_OrderStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Pick Listed", Me)
                                If PrimaryForm.MainLoadingBar.Value < plloadingbar Then
                                    PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                                End If
                            Else
                                Exit Try
                            End If
                        Else
                            If PrimaryForm.MainLoadingBar.Value < plloadingbar Then
                                PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                            End If
                        End If
                    Else
                        Exit Try
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

    Sub getCustomerOrderItems(ByVal icustomerorderid As Integer, ByVal ipicklistid As Integer)
        Try
            If conn2.State = ConnectionState.Closed Then conn2.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(ci.qtyordered,0) FROM orderitems ci " &
                        "WHERE ci.orderid = " & icustomerorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.`status` = 'New' AND ci.itemtype != 'B' ORDER BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn2)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    I_PickListOrders(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, ipicklistid, icustomerorderid, CInt(reader1(0)), "N", "New", Me)
                    plpicklistorderid = globalpicklistorderidsp
                    If myModule.systemerrorfound = False Then
                        getRackShelfColumn(CInt(reader1(1)), CInt(reader1(2)), plpicklistorderid, plinventorylocationdid)
                    Else
                        Exit Try
                    End If
                    If myModule.systemerrorfound = False Then
                        U_OrderItemStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Pick Listed", Me)
                    Else
                        Exit Try
                    End If
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn2.Close()
        End Try
    End Sub

    Sub getRackShelfColumn(ByVal iproductcolorsizeid As Integer, ByVal iqtyordered As Integer, ByVal ipicklistorderid As Integer, ByVal iinventorylocationid As Integer)
        Try
            plqtytopickbalance = pagedivisor : rowscount = 0
            If conn3.State = ConnectionState.Closed Then conn3.Open()
            Dim sql1 As String = "SELECT pil.rowid,COALESCE(pil.totalavailableqty,0),COALESCE(pil.totalallocatedqty,0) FROM productinventorylocation pil LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " &
                    "WHERE pil.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & iinventorylocationid & " AND pil.productcolorsizeid = " & iproductcolorsizeid & " " &
                    "AND ((IFNULL(pil.totalavailableqty,0) - IFNULL(pil.totalallocatedqty,0)) > 0) ORDER BY pil.totalavailableqty ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn3)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If plqtytopickbalance > 0 Then
                        If rowscount = 0 Then
                            If iqtyordered > CInt(reader1(1)) - CInt(reader1(2)) Then
                                plqtytopick = CInt(reader1(1)) - CInt(reader1(2))
                                plqtytopickbalance = iqtyordered - (CInt(reader1(1)) - CInt(reader1(2)))
                            Else
                                plqtytopick = iqtyordered
                                plqtytopickbalance = iqtyordered - (CInt(reader1(1)) - CInt(reader1(2)))
                            End If
                        Else
                            If plqtytopickbalance > CInt(reader1(1)) - CInt(reader1(2)) Then
                                plqtytopick = CInt(reader1(1)) - CInt(reader1(2))
                                plqtytopickbalance = plqtytopickbalance - (CInt(reader1(1)) - CInt(reader1(2)))
                            Else
                                plqtytopick = plqtytopickbalance
                                plqtytopickbalance = plqtytopickbalance - (CInt(reader1(1)) - CInt(reader1(2)))
                            End If
                        End If
                        I_PickListOrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, ipicklistorderid, CInt(reader1(0)), plqtytopick, CInt(reader1(1)), "N", "Active", "", Me)
                        U_ProductInventoryLocationQtyAllocated(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, CInt(reader1(2)) + plqtytopick, Me)
                        If myModule.systemerrorfound = False Then
                            rowscount = rowscount + startingpage
                        Else
                            Exit Try
                        End If
                    End If
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn3.Close()
        End Try
    End Sub

    Sub getGeneratePickListInfo()
        Try
            pllistofvalueid = 0 : plgeneratepickliststatus = ""
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtPls As New DataTable
            dtPls = getDataTableForSQL("SELECT lov.rowid,lov.`status` FROM listofvalues lov WHERE lov.lic = 'Generate Pick List' AND lov.`type` = 'Generate Pick List' ")
            If dtPls.Rows.Count <> 0 Then
                pllistofvalueid = dtPls.Rows(0)(0)
                plgeneratepickliststatus = dtPls.Rows(0)(1)
            Else
                pllistofvalueid = 0 : plgeneratepickliststatus = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Checking"

    Sub checkCustomerOrderItemsQtyOrderable(ByVal icustomerorderid As Integer)
        Try
            If conn2.State = ConnectionState.Closed Then conn2.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(ci.qtyordered,0) FROM orderitems ci " &
                        "WHERE ci.orderid = " & icustomerorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.`status` = 'New' AND ci.itemtype != 'B' ORDER BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn2)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyAvailableA(CInt(reader1(1)), Me)
                    getTotalQtyAllocatedA(CInt(reader1(1)), Me)
                    If globaltotalqtyavailable - globaltotalqtyallocated < CInt(reader1(2)) Then
                        plinsufficientqtyorderablecue = legit
                        Exit Try
                    End If
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn2.Close()
        End Try
    End Sub

#End Region

#Region "Deleting"

    Sub getAllPickListOrdersID(ByVal ipicklistid As Integer, ByVal iorderid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT plo.rowid,COALESCE(plo.orderitemid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " " &
                        "AND plo.picklistid = " & ipicklistid & " AND plo.orderid = " & iorderid & " ORDER BY plo.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getAllPickListOrdersItemID(CInt(reader1(0)), "Inactive")
                    If myModule.systemerrorfound = False Then
                        U_PickListOrderStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                    End If
                    If myModule.systemerrorfound = False Then
                        U_OrderItemStatus(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "New", Me)
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

    Sub getAllPickListOrdersItemID(ByVal ipicklistorderid As Integer, ByVal istatus As String)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT pli.rowid,pli.productinventorylocationid,COALESCE(pli.qtypicked,0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND pli.status != 'Inactive' ORDER BY pli.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If CInt(reader1(2)) > neutralpage Then
                        getTotalQtyAllocatedC(CInt(reader1(1)), Me)
                        U_ProductInventoryLocationQtyAllocated(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated - CInt(reader1(2)), Me)
                    End If
                    U_PickListOrderItemStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, istatus, Me)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

#End Region

#Region "Cancelling"

    Sub cancelPickList(ByVal ipicklistid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT plo.rowid,COALESCE(plo.orderitemid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.picklistid = " & ipicklistid & " AND plo.status != 'Inactive' ORDER BY plo.orderid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getAllPickListOrdersItemID(CInt(reader1(0)), "Cancelled")
                    If myModule.systemerrorfound = False Then
                        U_PickListOrderStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
                    End If
                    If myModule.systemerrorfound = False Then
                        U_OrderItemStatus(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "New", Me)
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

    Sub reopenCustomerOrders(ByVal ipicklistid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(plo.orderid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.picklistid = " & ipicklistid & " AND plo.status != 'Inactive' GROUP BY plo.orderid ORDER BY plo.orderid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    U_OrderStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "New", Me)
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

    Sub checkCustomerOrderItems(ByVal ipicklistid As Integer)
        Try
            plincompleteqtytopickcue = fraud
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT plo.rowid,COALESCE(oi.qtyordered,0) FROM picklistorders plo LEFT JOIN orderitems oi ON plo.orderitemid = oi.rowid WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.picklistid = " & ipicklistid & " AND plo.`status` != 'Inactive' "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyPickedA(CInt(reader1(0)))
                    If pltotalqtypicked <> CInt(reader1(1)) Then
                        plincompleteqtytopickcue = legit
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

    Sub printPickList(ByVal ipicklistid As Integer, ByVal iinventorylocationid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(rsc.rackno,''),' / ',COALESCE(rsc.columnno,''),' / ',COALESCE(rsc.shelfno,'')),''),COALESCE(CONCAT(COALESCE(p.productcode,''),' - ',COALESCE(pcs.seasoncode,'')),''),COALESCE(co.colorname,''),COALESCE(pcs.size,''),COALESCE(pli.qtypicked,0)," &
                        "COALESCE(pl.picklistno,''),COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(DATE_FORMAT(pl.picklistdate,'%d-%b-%Y')),COALESCE(il.name,''),p.image," &
                        "COALESCE(CONCAT('C.O. No.: ',COALESCE(o.ordernumber,''),' / P.O. No.: ',COALESCE(o.referencenumber,''),' / Branch: ',COALESCE(bc.branchname,''),' - ',COALESCE(bc.branchcode,'')),'') FROM picklistorderitems pli LEFT JOIN picklistorders plo ON pli.picklistorderid = plo.rowid " &
                        "LEFT JOIN orders o ON plo.orderid = o.rowid LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN picklist pl ON plo.picklistid = pl.rowid LEFT JOIN inventorylocations il ON pl.inventorylocationid = il.rowid LEFT JOIN contacts c ON pl.contactid = c.rowid " &
                        "LEFT JOIN productinventorylocation pil ON pli.productinventorylocationid = pil.rowid LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid " &
                        "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors co ON pc.colorid = co.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pl.organizationid = " & Z_OrganizationID & " AND " &
                        "pl.rowid = " & ipicklistid & " AND plo.`status` != 'Inactive' AND pli.`status` != 'Inactive' AND pl.inventorylocationid = " & iinventorylocationid & " AND pli.qtypicked > 0 ORDER BY rsc.pickorderno ASC,p.productcode ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    productimage = reader1(9)
                    If IsDBNull(productimage) Then
                        productimage = Nothing
                    End If
                    printdataset.AddSetARow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(2)), CStr(reader1(3)), CInt(reader1(4)), "Pick List No.: " & CStr(reader1(5)) & "", "Picker Name: " & CStr(reader1(6)) & "", "Pick List Date: " & CStr(reader1(7)) & "", "Location Name: " & CStr(reader1(8)) & "", CStr(reader1(10)), "", productimage, "", "", "")
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub printPickListThurston(ByVal orderNumber As Integer, ByVal iinventorylocationid As Integer)
        Try
            printdatasetthurston.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT DISTINCT  o.OrderDate AS Date
	                                , o.OrderNumber AS 'S.O. No.'
	                                , CONCAT_WS('\n', CONCAT(acc.CompanyName, '\n'), o.CustomerAddress) AS 'Ship To'
	                                , o.TargetDate AS 'Ship Date'
	                                , p.ProductCode AS Item
	                                , CONCAT(p.Description	, ' ', c.ColorName, ' ', pcs.Size ) AS Description	
	                                , oi.QtyOrdered AS Needed
	                                , oi.RowID AS OrderItemID


                                FROM 
                                ((((((orderitems oi JOIN productcolorsizes pcs ON oi.ProductColorSizeID = pcs.RowID) 
                                JOIN orders o ON oi.OrderID = o.RowID)
                                JOIN productcolors pc ON pcs.ProductColorId = pc.RowID)
                                JOIN products p ON pc.ProductID = p.RowID)
                                JOIN colors c ON pc.ColorID = c.RowID)

                                JOIN picklistorders plo ON o.RowID = plo.OrderID)
                                INNER JOIN accounts acc ON acc.RowID=o.AccountID
                                WHERE o.OrderNumber = " & orderNumber & "
                                ORDER BY p.ProductCode ASC"
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    printdatasetthurston.AddSetGRow(String.Empty,
                        If(IsDBNull(reader1(0)), String.Empty, reader1(0)),
                        If(IsDBNull(reader1(1)), String.Empty, reader1(1)),
                        If(IsDBNull(reader1(2)), String.Empty, reader1(2)),
                        If(IsDBNull(reader1(3)), String.Empty, reader1(3)),
                        String.Empty,
                        If(IsDBNull(reader1(4)), String.Empty, reader1(4)),
                        If(IsDBNull(reader1(5)), String.Empty, reader1(5)),
                        If(IsDBNull(reader1(6)), String.Empty, reader1(6)),
                        getPickQty(If(IsDBNull(reader1(7)), 0, CInt(reader1(7)))),
                        String.Empty,
                        String.Empty)
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
                PrimaryForm.PLForm = False
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

    Private Sub msNew_Click2(sender As Object, e As EventArgs) Handles msNew.Click
        If Not IsThurston Then Return

        Dim form = New GeneratePickListCustomerOrderSelectorForm(organizationId:=Z_OrganizationID, userId:=Z_UserID)
        If Not form.ShowDialog() = DialogResult.OK Then Return

        cmdFirst_Click(cmdFirst, New EventArgs())

    End Sub

    Private Sub msNew_Click(sender As Object, e As EventArgs) Handles msNew.Click
        If IsThurston Then Return

        Me.Cursor = Cursors.WaitCursor
        Try
            myModule.systemerrorfound = False : plnewpicklistcreated = ""
            getGeneratePickListInfo()
            If plgeneratepickliststatus <> "Active" Then
                MessageBox.Show("Other user is still generating a pick list, please try again later.", "Generating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PLForm = False
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
            getInventorylocationIDC(Me)
            plinventorylocationdid = globalinventorylocationid
            If plinventorylocationdid = 0 Then
                MessageBox.Show("There is no inventory location that has been created yet.", "Generating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            countCustomerOrders()
            If plloadingbar = 0 Then
                MessageBox.Show("There is no customer order available to be pick listed at this moment.", "Generating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to generate new Pick List No(s).?", "Generating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                countCustomerOrders()
                If myModule.systemerrorfound = False Then
                    If plloadingbar = 0 Then
                        MessageBox.Show("There is no customer order available to be pick listed at this moment.", "Generating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    Else
                        PrimaryForm.MainLoadingBar.Visible = legit
                        PrimaryForm.MainLoadingBar.Maximum = plloadingbar
                    End If
                Else
                    Exit Try
                End If
                getGeneratePickListInfo()
                If plgeneratepickliststatus <> "Active" Then
                    MessageBox.Show("Other user is still generating a pick list, please try again later.", "Generating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                U_ListOfValueStatus(pllistofvalueid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                plnewpicklist.Clear()
                countPickListGroupsA()
                If myModule.systemerrorfound = False Then
                    If plcountcos <> 0 Then
                        getCustomerPickListGroups()
                    End If
                Else
                    Exit Try
                End If
                countPickListGroupsB()
                If myModule.systemerrorfound = False Then
                    If plcountcos <> 0 Then
                        getCustomerOrdersB()
                    End If
                Else
                    Exit Try
                End If
                If myModule.systemerrorfound = False Then
                    If plnewpicklist.Count <> 0 Then
                        itemno = plnewpicklist.Count
                        For i = 0 To plnewpicklist.Count - 1
                            itemno = plnewpicklist.Count - 1
                            If itemno = 0 Then
                                plnewpicklistcreated = plnewpicklistcreated + CStr(plnewpicklist(i)) + "."
                            Else
                                plnewpicklistcreated = plnewpicklistcreated + CStr(plnewpicklist(i)) + " / "
                            End If
                        Next
                    End If
                    MessageBox.Show("Successfully Created Pick List No(s).: " & plnewpicklistcreated, "Generated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tsrefreshperformclick()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            PrimaryForm.MainLoadingBar.Visible = fraud
            U_ListOfValueStatus(pllistofvalueid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Active", Me)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgPickList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPickList.CellContentClick

    End Sub

    Private Sub dgPickList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPickList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPickList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearPickListInformation()
                clearCustomerOrders()
                clearCustomerOrderItems()
                clearRackShelfColumn()
                clearDatagrids()
                displayPickListInformation(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                displayCustomerOrdersA(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                picklistformcomputations()
                enableGB(legit, legit, fraud)
                visibleCustomerOrderItems(fraud)
                If txtStatus.Text = "New" Then
                    enableANDvisibleMS(legit, legit, legit, legit)
                ElseIf txtStatus.Text = "Modified" Then
                    enableANDvisibleMS(legit, legit, legit, legit)
                ElseIf txtStatus.Text = "Partially Verified" Then
                    enableANDvisibleMS(legit, legit, legit, fraud)
                Else
                    enableANDvisibleMS(legit, fraud, fraud, fraud)
                End If
                cboPickerName.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgPickList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgPickList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPickList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearPickListInformation()
                    clearCustomerOrders()
                    clearCustomerOrderItems()
                    clearRackShelfColumn()
                    clearDatagrids()
                    displayPickListInformation(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                    displayCustomerOrdersA(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                    picklistformcomputations()
                    enableGB(legit, legit, fraud)
                    visibleCustomerOrderItems(fraud)
                    If txtStatus.Text = "New" Then
                        enableANDvisibleMS(legit, legit, legit, legit)
                    ElseIf txtStatus.Text = "Modified" Then
                        enableANDvisibleMS(legit, legit, legit, legit)
                    ElseIf txtStatus.Text = "Partially Verified" Then
                        enableANDvisibleMS(legit, legit, legit, fraud)
                    Else
                        enableANDvisibleMS(legit, fraud, fraud, fraud)
                    End If
                    cboPickerName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAddPicker_MouseEnter(sender As Object, e As EventArgs) Handles pbAddPicker.MouseEnter
        Try
            pbAddPicker.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddPicker_MouseLeave(sender As Object, e As EventArgs) Handles pbAddPicker.MouseLeave
        Try
            pbAddPicker.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddPicker_Click(sender As Object, e As EventArgs) Handles pbAddPicker.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PLForm = False
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
                globalautocompleteContactName(cboPickerName, "Picker", Me)
                globalautopopulateContactName(cboPickerName, "Picker", Me)
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
                visibleCustomerOrderItems(legit)
            Else
                visibleCustomerOrderItems(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub dgCustomerOrders_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrders.CellClick
        If Not dgCustomerOrders.Rows.Count <> 0 Then Return

        Try
            If Not e.ColumnIndex = dgCustomerOrders.Columns(TickBoxOrdersColumn.Name).Index Then

                errProvider.Clear()
                dgRackShelfColumn.Rows.Clear() : enableGB(legit, legit, fraud) : lnkViewEditBundleItems.Visible = fraud
                Await displayCustomerOrderItems(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value))
                colorCoding() : picklistformcomputations()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub dgCustomerOrders_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCustomerOrders.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrders.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    errProvider.Clear()
                    dgRackShelfColumn.Rows.Clear() : enableGB(legit, legit, fraud) : lnkViewEditBundleItems.Visible = fraud
                    Await displayCustomerOrderItems(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value))
                    colorCoding() : picklistformcomputations()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrderItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderItems.CellContentClick

    End Sub

    Private Async Sub dgCustomerOrderItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderItems.CellClick
        Try
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                errProvider.Clear()
                dgRackShelfColumn.Rows.Clear()
                lnkViewEditBundleItems.Visible = fraud
                If CStr(dgCustomerOrderItems.CurrentRow.Cells("ci_type").Value) = "S" Then
                    enableGB(legit, legit, legit)
                    getPickListOrderStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                    If globalpicklistorderstatus = "New" Then
                        msSaveRSC.Enabled = legit
                    ElseIf globalpicklistorderstatus = "Modified" Then
                        msSaveRSC.Enabled = legit
                    Else
                        msSaveRSC.Enabled = fraud
                    End If

                    If IsThurston Then
                        getInventorylocationIDA(If(dgCustomerOrders.CurrentRow?.Cells(co_inventorylocation.Name).Value, cboLocationName.Text), Me)
                    Else
                        getInventorylocationIDA(cboLocationName.Text, Me)
                    End If

                    plinventorylocationdid = globalinventorylocationid
                    If IsThurston Then
                        Await displayRackShelfColumn(CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_pcsrowid").Value),
                            iinventorylocationid:=CInt(dgCustomerOrderItems.CurrentRow.Cells(Column4.Name).Value))
                    ElseIf plinventorylocationdid <> 0 Then
                        Await displayRackShelfColumn(CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_pcsrowid").Value),
                            iinventorylocationid:=plinventorylocationdid)
                    Else
                        errProvider.SetError(cboLocationName, "Please choose or enter the location name.")
                    End If
                Else
                    enableGB(legit, legit, fraud)
                    lnkViewEditBundleItems.Visible = legit
                End If
                colorCoding() : picklistformcomputations()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub dgCustomerOrderItems_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCustomerOrderItems.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    errProvider.Clear()
                    dgRackShelfColumn.Rows.Clear()
                    lnkViewEditBundleItems.Visible = fraud
                    If CStr(dgCustomerOrderItems.CurrentRow.Cells("ci_type").Value) = "S" Then
                        enableGB(legit, legit, legit)
                        getPickListOrderStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                        If globalpicklistorderstatus = "New" Then
                            msSaveRSC.Enabled = legit
                        ElseIf globalpicklistorderstatus = "Modified" Then
                            msSaveRSC.Enabled = legit
                        Else
                            msSaveRSC.Enabled = fraud
                        End If
                        getInventorylocationIDA(cboLocationName.Text, Me)
                        plinventorylocationdid = globalinventorylocationid
                        If plinventorylocationdid <> 0 Then
                            Await displayRackShelfColumn(CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_pcsrowid").Value),
                                iinventorylocationid:=CInt(dgCustomerOrderItems.CurrentRow.Cells(Column4.Name).Value))
                        Else
                            errProvider.SetError(cboLocationName, "Please choose or enter the location name.")
                        End If
                    Else
                        enableGB(legit, legit, fraud)
                        lnkViewEditBundleItems.Visible = legit
                    End If
                    colorCoding() : picklistformcomputations()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgRackShelfColumn_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgRackShelfColumn.CellEndEdit
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            picklistformcomputations()
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                If IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_qtyordered").Value) Then
                    If CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_qtyordered").Value) < plqtytopicksum Then
                        errProvider.SetError(txtQtyToPick, "Qty. Ordered should not be less than to Total Qty. To Pick.")
                    End If
                End If
            End If

            If IsThurston Then
                If (If(dgCustomerOrderItems.Rows.OfType(Of DataGridViewRow)?.Any(), False) And dgCustomerOrderItems.CurrentRow IsNot Nothing) AndAlso
                If(dgRackShelfColumn.Rows.OfType(Of DataGridViewRow)?.Any(), False) Then

                    Dim userTotalPickedQty = dgRackShelfColumn.Rows.
                        OfType(Of DataGridViewRow).
                        Sum(Function(r) r.Cells(rsc_qtytopick.Name).Value)

                    Dim qty = CInt(dgCustomerOrderItems.CurrentRow.Cells(ci_qtyordered.Name).Value)

                    Dim boolSatisfied = userTotalPickedQty = qty
                    msSaveRSC.Enabled = boolSatisfied

                    If Not boolSatisfied Then
                        errProvider.SetError(txtQtyToPick, $"it should be {qty}")
                    Else
                        errProvider.SetError(txtQtyToPick, String.Empty)
                    End If
                Else
                    msSaveRSC.Enabled = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub msSaveRSC_Click(sender As Object, e As EventArgs) Handles msSaveRSC.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PLForm = False
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
            picklistformcomputations()
            myModule.systemerrorfound = False
            dgRackShelfColumn.CommitEdit(legit) : dgRackShelfColumn.ClearSelection() : dgRackShelfColumn.CurrentCell = Nothing
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                If IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_qtyordered").Value) Then
                    If CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_qtyordered").Value) < plqtytopicksum Then
                        errProvider.SetError(txtQtyToPick, "Qty. Ordered should not be less than to Total Qty. To Pick")
                        Exit Try
                    End If
                End If
            End If
            'If dgRackShelfColumn.Rows.Count <> 0 Then
            '    For i = 0 To dgRackShelfColumn.Rows.Count - 1
            '        If IsNumeric(dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Value) Then
            '            If CInt(dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Value) > CInt(dgRackShelfColumn.Rows(i).Cells("rsc_qtyallocated").Value) Then
            '                dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").ErrorText = "Qty. To Pick should not be greater than Qty. Allocated."
            '                Exit Try
            '            End If
            '        End If
            '    Next
            'End If
            getInventorylocationIDA(cboLocationName.Text, Me)
            plinventorylocationdid = globalinventorylocationid
            If plinventorylocationdid = 0 Then
                errProvider.SetError(cboLocationName, "Please choose or enter the location name.")
                Exit Try
            End If
            If dgRackShelfColumn.Rows.Count = 0 Then
                MessageBox.Show("There is nothing to save in the Rack / Column / Shelf assignment.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgPickList.Rows.Count <> 0 Then
                If dgCustomerOrders.Rows.Count <> 0 Then
                    If dgCustomerOrderItems.Rows.Count <> 0 Then
                        getPickListOrderID(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                        plpicklistorderid = globalpicklistorderid
                        If plpicklistorderid = 0 Then
                            errProvider.SetError(txtPickListNo, "System cannot find the Pick List, Customer Order and Customer Order Item to be updated.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(txtPickListNo, "System cannot find the Pick List, Customer Order and Customer Order Item to be updated.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtPickListNo, "System cannot find the Pick List, Customer Order and Customer Order Item to be updated.")
                    Exit Try
                End If
                getPickListOrderStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                If globalpicklistorderstatus <> "New" Then
                    If globalpicklistorderstatus <> "Modified" Then
                        MessageBox.Show("This customer order item has been updated by other user, click the customer order again to check the status.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                End If

                If IsThurston Then
                    If (If(dgCustomerOrderItems.Rows.OfType(Of DataGridViewRow)?.Any(), False) And dgCustomerOrderItems.CurrentRow IsNot Nothing) AndAlso
                If(dgRackShelfColumn.Rows.OfType(Of DataGridViewRow)?.Any(), False) Then

                        Dim userTotalPickedQty = dgRackShelfColumn.Rows.
                        OfType(Of DataGridViewRow).
                        Sum(Function(r) r.Cells(rsc_qtytopick.Name).Value)

                        Dim qty = CInt(dgCustomerOrderItems.CurrentRow.Cells(ci_qtyordered.Name).Value)

                        Dim boolSatisfied = userTotalPickedQty = qty
                        msSaveRSC.Enabled = boolSatisfied

                        If Not boolSatisfied Then
                            errProvider.SetError(txtQtyToPick, $"it should be {qty}")
                        Else
                            errProvider.SetError(txtQtyToPick, String.Empty)
                        End If
                    Else
                        msSaveRSC.Enabled = False
                    End If

                    If Not msSaveRSC.Enabled Then Me.Cursor = Cursors.Default : Return
                End If

                If MessageBox.Show("Would you like to save the changes in the Rack / Column / Shelf assignment?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getPickListOrderStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                    If globalpicklistorderstatus <> "New" Then
                        If globalpicklistorderstatus <> "Modified" Then
                            MessageBox.Show("This customer order item has been updated by other user, click the customer order again to check the status.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                    End If
                    If cue = "Edit" Then
                        For a = 0 To dgRackShelfColumn.Rows.Count - 1
                            If myModule.systemerrorfound = False Then
                                If IsNumeric(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) Then
                                    getPickListOrderItemID(plpicklistorderid, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Me)
                                    plpicklistorderitemid = globalpicklistorderitemid
                                    getPickListOrderItemInfo(plpicklistorderid, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Me)
                                    getTotalQtyAvailableC(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Me)
                                    getTotalQtyAllocatedC(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Me)
                                    If CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) < CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_qtyordered").Value) Then
                                        If plpicklistorderitemid = 0 Then
                                            I_PickListOrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, plpicklistorderid, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value),
                                                globaltotalqtyavailable - globaltotalqtyallocated, If(dgRackShelfColumn.Rows(a).Cells("rsc_issueflg").Value = legit, "Y", "N"), "Active", CStr(dgRackShelfColumn.Rows(a).Cells("rsc_remarks").Value), Me)
                                            U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated + CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value), Me)
                                        Else
                                            If globalpicklistorderitemqtypicked > CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) Then
                                                U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated - (globalpicklistorderitemqtypicked - CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value)), Me)
                                            ElseIf globalpicklistorderitemqtypicked < CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) Then
                                                U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated + (CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) - globalpicklistorderitemqtypicked), Me)
                                            End If
                                            U_PickListOrderItems(plpicklistorderitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value), globaltotalqtyavailable - globaltotalqtyallocated,
                                                If(dgRackShelfColumn.Rows(a).Cells("rsc_issueflg").Value = legit, "Y", "N"), CStr(dgRackShelfColumn.Rows(a).Cells("rsc_remarks").Value), Me)
                                        End If
                                    ElseIf CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) = CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_qtyordered").Value) Then
                                        If plpicklistorderitemid = 0 Then
                                            I_PickListOrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, plpicklistorderid, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value),
                                                globaltotalqtyavailable - globaltotalqtyallocated, If(dgRackShelfColumn.Rows(a).Cells("rsc_issueflg").Value = legit, "Y", "N"), "Active", CStr(dgRackShelfColumn.Rows(a).Cells("rsc_remarks").Value), Me)
                                            U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated + CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value), Me)
                                        Else
                                            If globalpicklistorderitemqtypicked > CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) Then
                                                U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated - (globalpicklistorderitemqtypicked - CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value)), Me)
                                            ElseIf globalpicklistorderitemqtypicked < CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) Then
                                                U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated + (CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) - globalpicklistorderitemqtypicked), Me)
                                            End If
                                            U_PickListOrderItems(plpicklistorderitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value), globaltotalqtyavailable - globaltotalqtyallocated,
                                                If(dgRackShelfColumn.Rows(a).Cells("rsc_issueflg").Value = legit, "Y", "N"), CStr(dgRackShelfColumn.Rows(a).Cells("rsc_remarks").Value), Me)
                                        End If
                                    End If
                                End If
                            Else
                                Exit Try
                            End If
                        Next
                        If myModule.systemerrorfound = False Then
                            U_PickListOrderStatus(plpicklistorderid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Modified", Me)
                            U_PickListOrderModifiedFlg(plpicklistorderid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Y", Me)
                            getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                            U_PickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(globalpickliststatus = "New", "Modified", globalpickliststatus), Me)
                        End If
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Save Rack / Column / Shelf assignment.", "Save", lblsavemsg, -15, -65)
                        dgRackShelfColumn.Rows.Clear() : enableGB(legit, legit, fraud) : lnkViewEditBundleItems.Visible = fraud
                        Await displayCustomerOrderItems(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value))
                        colorCoding() : picklistformcomputations()
                    End If
                End If
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List, Customer Order and Customer Order Item to be updated.")
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PLForm = False
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
            getInventorylocationIDA(cboLocationName.Text, Me)
            plinventorylocationdid = globalinventorylocationid
            If plinventorylocationdid = 0 Then
                errProvider.SetError(cboLocationName, "Please choose or enter the location name.")
                Exit Try
            End If
            getContactID(cboPickerName.Text, "Picker", Me)
            plcontactid = globalcontactid
            If plcontactid = 0 Then
                errProvider.SetError(pbAddPicker, "Please choose or enter the picker name.")
                Exit Try
            End If
            If dgPickList.Rows.Count <> 0 Then
                getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                If globalpickliststatus = "Completed" Then
                    MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                    If globalpickliststatus = "Completed" Then
                        MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If cue = "Edit" Then
                        getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                        U_PickList(RowID:=CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), LastUpd:=Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), LastUpdBy:=Z_UserID, InventoryLocationID:=plinventorylocationdid, ContactID:=plcontactid, Comments:=txtComments.Text, Status:=If(globalpickliststatus = "New", "Modified", globalpickliststatus), globalformname:=Me)
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                        tsrefreshperformclick()
                    End If
                End If
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List to be updated.")
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub dgCustomerOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrders.CellContentClick
        If Not dgCustomerOrders.Rows.Count <> 0 Then Return

        Try

            If e.ColumnIndex = dgCustomerOrders.Columns("co_option").Index Then
                errProvider.Clear()
                myModule.systemerrorfound = False
                If globalpositionid <> 0 Then
                    getPositionView(globalpositionid, "Pick List", Me)
                    If globaldisableflg = "Y" Then
                        MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        PrimaryForm.PLForm = False
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
                If dgPickList.Rows.Count <> 0 Then
                    getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                    If globalpickliststatus <> "New" Then
                        If globalpickliststatus <> "Modified" Then
                            MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                    End If
                    If MessageBox.Show("NOTE: Once you remove this order, you cannot add this order again." & vbNewLine & "" & vbNewLine & "Do you want to proceed deleting this order?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                        If globalpickliststatus <> "New" Then
                            If globalpickliststatus <> "Modified" Then
                                MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        getAllPickListOrdersID(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value))
                        If myModule.systemerrorfound = False Then
                            U_OrderStatus(CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "New", Me)
                        End If
                        If myModule.systemerrorfound = False Then
                            getCountPickListOrder(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), "AND (plo.status = 'New' OR plo.status = 'Modified' OR plo.status = 'Verified')", Me)
                            If globalpicklistordercount = 0 Then
                                getInventorylocationIDA(cboLocationName.Text, Me)
                                plinventorylocationdid = globalinventorylocationid
                                getContactID(cboPickerName.Text, "Picker", Me)
                                plcontactid = globalcontactid
                                U_PickList(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(plinventorylocationdid = 0, DBNull.Value, plinventorylocationdid), If(plcontactid = 0, DBNull.Value, plcontactid), txtComments.Text, "Cancelled", Me)
                                myBalloon("Successfully Deleted", "Delete", lblsavemsg, -15, -65)
                                tsrefreshperformclick()
                                Exit Try
                            End If
                        End If
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Deleted", "Delete", lblsavemsg, -15, -65)
                            cue = "Edit"
                            errProvider.Clear()
                            clearPickListInformation()
                            clearCustomerOrders()
                            clearCustomerOrderItems()
                            clearRackShelfColumn()
                            clearDatagrids()
                            displayPickListInformation(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                            displayCustomerOrdersA(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                            picklistformcomputations()
                            enableGB(legit, legit, fraud)
                            visibleCustomerOrderItems(fraud)
                            If txtStatus.Text = "New" Then
                                enableANDvisibleMS(legit, legit, legit, legit)
                            ElseIf txtStatus.Text = "Modified" Then
                                enableANDvisibleMS(legit, legit, legit, legit)
                            ElseIf txtStatus.Text = "Partially Verified" Then
                                enableANDvisibleMS(legit, legit, legit, fraud)
                            Else
                                enableANDvisibleMS(legit, fraud, fraud, fraud)
                            End If
                            cboPickerName.Focus()
                        End If
                    End If
                Else
                    errProvider.SetError(txtPickListNo, "System cannot find the Pick List to be updated.")
                    Exit Try
                End If

            ElseIf e.ColumnIndex = TickBoxOrdersColumn.Index Then
                txtOverallQtyOrdered.Focus()
                dgCustomerOrders.CurrentCell = dgCustomerOrders.Item(columnIndex:=co_seqno.Index, rowIndex:=e.RowIndex)
                dgCustomerOrders.EndEdit()
                dgCustomerOrders.CurrentCell = dgCustomerOrders.Item(columnIndex:=e.ColumnIndex, rowIndex:=e.RowIndex)

                Dim count = If(dgCustomerOrders.Rows.OfType(Of DataGridViewRow).Where(Function(t) CBool(t.Cells(TickBoxOrdersColumn.Name).Value))?.ToList()?.Count(), 0)
                msPrint.Text = If(count = 0, "&Print", $"&Print({count})")
            End If

        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()

            Dim sdfsd = Panel1.Controls.OfType(Of RadioButton)
            For Each s In sdfsd
                s.Checked = False
            Next
        End Try
    End Sub

    Private Async Sub msOrder_Click(sender As Object, e As EventArgs) Handles msOrder.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PLForm = False
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
            If dgPickList.Rows.Count <> 0 Then
                getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                If globalpickliststatus <> "New" Then
                    If globalpickliststatus <> "Modified" Then
                        MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                End If
                If MessageBox.Show("NOTE: Once you cancelled this pick list, you cannot open this pick list again." & vbNewLine & "" & vbNewLine & "Do you want to proceed cancelling this pick list?", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                    If globalpickliststatus <> "New" Then
                        If globalpickliststatus <> "Modified" Then
                            MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                    End If
                    cancelPickList(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                    If myModule.systemerrorfound = False Then
                        reopenCustomerOrders(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                    End If
                    If myModule.systemerrorfound = False Then
                        getInventorylocationIDA(cboLocationName.Text, Me)
                        plinventorylocationdid = globalinventorylocationid
                        getContactID(cboPickerName.Text, "Picker", Me)
                        plcontactid = globalcontactid
                        U_PickList(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(plinventorylocationdid = 0, DBNull.Value, plinventorylocationdid), If(plcontactid = 0, DBNull.Value, plcontactid), txtComments.Text, "Cancelled", Me)
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Cancelled", "Cancel", lblsavemsg, -15, -65)
                        tsrefreshperformclick()
                    End If
                End If
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List to be updated.")
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub lnkViewEditBundleItems_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkViewEditBundleItems.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Try
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PLForm = False
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
            Dim editbundleitemslinkform As New EditBundleItemsBForm
            If dgPickList.Rows.Count <> 0 Then
                editbundleitemslinkform.ebibpicklistid = CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value)
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List, Customer Order and Customer Order Item to be updated.")
                Exit Try
            End If
            If dgCustomerOrders.Rows.Count <> 0 Then
                editbundleitemslinkform.ebibcustomerorderid = CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value)
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List, Customer Order and Customer Order Item to be updated.")
                Exit Try
            End If
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                editbundleitemslinkform.ebiorderitemid = CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value)
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List, Customer Order and Customer Order Item to be updated.")
                Exit Try
            End If
            getInventorylocationIDA(cboLocationName.Text, Me)
            plinventorylocationdid = globalinventorylocationid
            If plinventorylocationdid <> 0 Then
                editbundleitemslinkform.ebibinventorylocationid = plinventorylocationdid
            Else
                errProvider.SetError(cboLocationName, "Please choose or enter the location name.")
                Exit Try
            End If
            editbundleitemslinkform.ShowInTaskbar = False
            editbundleitemslinkform.ShowDialog()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub msPrint_Click(sender As Object, e As EventArgs) Handles msPrint.Click
        If IsThurston Then Return

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PLForm = False
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
            If dgPickList.Rows.Count <> 0 Then
                getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                If globalpickliststatus <> txtStatus.Text Then
                    MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalpickliststatus <> "Cancelled" Then
                    getInventorylocationIDA(cboLocationName.Text, Me)
                    plinventorylocationdid = globalinventorylocationid
                    If plinventorylocationdid = 0 Then
                        errProvider.SetError(cboLocationName, "Please choose or enter the location name.")
                        Exit Try
                    End If
                    getContactID(cboPickerName.Text, "Picker", Me)
                    plcontactid = globalcontactid
                    If plcontactid = 0 Then
                        errProvider.SetError(pbAddPicker, "Please choose or enter the picker name.")
                        Exit Try
                    End If
                    checkCustomerOrderItems(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                    If plincompleteqtytopickcue = legit Then
                        If MessageBox.Show("NOTE: System detected that one or more Customer Order Item Qty. Ordered is not equal to Total Qty. To Pick." & vbNewLine & "" & vbNewLine & "Do you want to proceed printing this pick list?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Me.Cursor = Cursors.WaitCursor
                            getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                            If globalpickliststatus = "Cancelled" Then
                                MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                            U_PickList(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, plinventorylocationdid, If(plcontactid = 0, DBNull.Value, plcontactid), txtComments.Text, txtStatus.Text, Me)
                            If myModule.systemerrorfound = False Then
                                getUserName(Z_UserID, Me)
                                Dim systemOwnerService = MainServiceProvider.GetRequiredService(Of ISystemOwnerService)
                                Dim currentSystemOwner = Await systemOwnerService.GetCurrentSystemOwnerEntityAsync()
                                If currentSystemOwner.IsThurston Then
                                    If dgCustomerOrders.CurrentRow.Selected Then
                                        printPickListThurston(CInt(dgCustomerOrders.CurrentRow.Cells("co_customerorderno").Value), plinventorylocationdid)
                                        Dim printreport As New PickList
                                        Dim openreportviewer As New ReportViewer
                                        openreportviewer.CrystalReportViewer.ReportSource = printreport
                                        printdatatable = printdatasetthurston
                                        printreport.SetDataSource(printdatatable)
                                        openreportviewer.Show()
                                        printdatatable.Dispose()
                                        printdatatable = Nothing
                                        printdatasetthurston.Clear()
                                    Else
                                        MessageBox.Show("Select a customer order")
                                    End If
                                Else
                                    printPickList(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), plinventorylocationdid)
                                    Dim printreport As New PickListPrint
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
                            Exit Try
                        Else
                            Exit Try
                        End If
                    End If
                    If MessageBox.Show("Would you like to print this pick list?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                        If globalpickliststatus = "Cancelled" Then
                            MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        U_PickList(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, plinventorylocationdid, If(plcontactid = 0, DBNull.Value, plcontactid), txtComments.Text, txtStatus.Text, Me)
                        If myModule.systemerrorfound = False Then
                            getUserName(Z_UserID, Me)
                            Dim systemOwnerService = MainServiceProvider.GetRequiredService(Of ISystemOwnerService)
                            Dim currentSystemOwner = Await systemOwnerService.GetCurrentSystemOwnerEntityAsync()
                            If currentSystemOwner.IsThurston Then
                                If dgCustomerOrders.CurrentRow.Selected Then
                                    printPickListThurston(CInt(dgCustomerOrders.CurrentRow.Cells("co_customerorderno").Value), plinventorylocationdid)
                                    Dim printreport As New PickList
                                    Dim openreportviewer As New ReportViewer
                                    openreportviewer.CrystalReportViewer.ReportSource = printreport
                                    printdatatable = printdatasetthurston
                                    printreport.SetDataSource(printdatatable)
                                    openreportviewer.Show()
                                    printdatatable.Dispose()
                                    printdatatable = Nothing
                                    printdatasetthurston.Clear()
                                Else
                                    MessageBox.Show("Select a customer order")
                                End If
                            Else
                                printPickList(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), plinventorylocationdid)
                                Dim printreport As New PickListPrint
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
                    End If
                End If
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List to be printed.")
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub PrintPickListReportForm_Click(sender As Object, e As EventArgs) Handles msPrint.Click
        Dim pickListId = If(dgPickList.CurrentRow Is Nothing, 0,
            CInt(dgPickList.CurrentRow?.Cells("pl_rowid").Value))
        Dim customerRows = dgCustomerOrders.Rows.OfType(Of DataGridViewRow).Where(Function(t) CBool(t.Cells(TickBoxOrdersColumn.Name).Value))?.ToList()
        If Not IsThurston AndAlso pickListId = 0 AndAlso If(customerRows?.Any(), False) Then Return

        Dim printreport As New DeliverySchedule

        Await FunctionUtils.TryCatchFunctionAsync(messageTitle:="Print Picklist",
            Async Function()
                Using connection As New MySqlConnection(connectionString:=manager.GetConnString()),
            command As New MySqlCommand("CALL PRINT_PICKLIST(@pickListId, @customerIds, @referenceNos, @customerOrderNos);", connection)

                    With command.Parameters
                        .AddWithValue("@pickListId", pickListId)

                        Dim customerIds = String.Join(separator:=",", customerRows.Select(Function(t) CInt(t.Tag)).ToArray())
                        .AddWithValue("@customerIds", customerIds)

                        Dim poNos = String.Join(separator:=",", customerRows.Select(Function(t) CInt(t.Cells(co_pono.Name).Value)).ToArray())
                        .AddWithValue("@referenceNos", poNos)

                        Dim customerOrderNos = String.Join(separator:=",", customerRows.Select(Function(t) CInt(t.Cells(co_customerorderno.Name).Value)).ToArray())
                        .AddWithValue("@customerOrderNos", customerOrderNos)
                    End With

                    Dim adapter = New MySqlDataAdapter()
                    adapter.SelectCommand = command
                    Dim dt As New DataTable
                    Await Task.Run(Sub()
                                       adapter.Fill(dt)
                                   End Sub)

                    If dt IsNot Nothing Then
                        printreport.SetDataSource(dt)
                    End If

                End Using
            End Function)

        Dim openreportviewer As New ReportViewer

        Dim section = printreport.ReportDefinition.Sections.OfType(Of Section).FirstOrDefault()
        Dim deliveryDate As TextObject = CType((section?.ReportObjects("deliveryDate1")), TextObject)

        Dim sfdfsd = Date.Parse(If(String.IsNullOrEmpty(txtPickListDate?.Text), Date.Now.ToShortDateString(), txtPickListDate.Text))
        Dim form = New PrintPickListDateDialog(sfdfsd)
        If form.ShowDialog() = DialogResult.OK Then
            deliveryDate.Text = form.SelectedDate
        Else
            deliveryDate.Text = Date.Now
        End If

        Dim pickListNo As TextObject = CType((section?.ReportObjects("driver1")), TextObject)
        pickListNo.Text = txtPickListNo.Text

        Dim pickerName As TextObject = CType((section?.ReportObjects("helper1")), TextObject)
        pickerName.Text = cboPickerName.Text

        openreportviewer.CrystalReportViewer.ReportSource = printreport
        openreportviewer.Show()
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
                    colorCoding() : pageSetup1(simplesearchphrase)
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
            ElseIf cboSearch1.Text = "PickerName" Then
                autocompletePickerName(cboSearch2)
                autopopulatePickerName(cboSearch2)
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

    Private Sub cboSearch2_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSearch2.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If cboDate.Text = "" And cboSearch1.Text = "" Then
                    tsrefreshperformclick()
                Else
                    If cboDate.Text <> "" And cboSearch1.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "CompletedDate" Then
                            datephrase = "pl.completeddate"
                        ElseIf cboDate.Text = "PickListDate" Then
                            datephrase = "pl.picklistdate"
                        End If
                        displayDateSearch(spagenum, datephrase)
                        colorCoding() : pageSetup2(datephrase)
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                    ElseIf cboDate.Text <> "" And cboSearch2.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "CompletedDate" Then
                            datephrase = "pl.completeddate"
                        ElseIf cboDate.Text = "PickListDate" Then
                            datephrase = "pl.picklistdate"
                        End If
                        displayDateSearch(spagenum, datephrase)
                        colorCoding() : pageSetup2(datephrase)
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
                        If cboDate.Text = "CompletedDate" Then
                            pagefilter2 = " AND (pl.completeddate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                "pl.completeddate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        ElseIf cboDate.Text = "PickListDate" Then
                            pagefilter2 = " AND (pl.picklistdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                "pl.picklistdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        Else
                            pagefilter2 = ""
                        End If
                        spagenum = neutralpage : numofpages = startingpage
                        displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
                        colorCoding() : pageSetup3(pagefilter1, pagefilter2)
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
        _pageOptions.MoveToFirst()
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            spagenum = neutralpage
            numofpages = startingpage
            If searchmode = "Basic" Then
                displayPickList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
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
        _pageOptions.MoveToPrevious()
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
                displayPickList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
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
        _pageOptions.MoveToNext()
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
                displayPickList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
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

    Private Async Sub cmdLast_Click(sender As Object, e As EventArgs) Handles cmdLast.Click
        _pageOptions.MoveToLast(total:=(Await LoadPickListsAsync()).TotalCount)

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
                displayPickList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
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
                            displayPickList(spagenum)
                        ElseIf searchmode = "CommonSearch" Then
                            displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
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

    Private Sub dgRackShelfColumn_MouseUp(sender As Object, e As MouseEventArgs) Handles dgRackShelfColumn.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgRackShelfColumn.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgRackShelfColumn.BeginEdit(True)
                Else
                    dgRackShelfColumn.EndEdit()
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

    Private Sub dgPickList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgPickList.DataError
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
                dgPickList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrders_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCustomerOrders.DataError
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
                dgCustomerOrders.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrderItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCustomerOrderItems.DataError
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
                dgCustomerOrderItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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

    Private Sub ShowOrHideUserInterface()
        If IsThurston Then
            Dim visibility = Not IsThurston
            cboLocationName.Visible = visibility
            Label10.Visible = visibility
            Label22.Visible = visibility

            co_inventorylocation.Visible = IsThurston
        End If
    End Sub

    Private Sub dgCustomerOrders_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgCustomerOrders.CellBeginEdit
        If If(dgCustomerOrders.Rows?.Count(), 0) = 0 Then Return

        If e.ColumnIndex = TickBoxOrdersColumn.Index Then

        End If
    End Sub

    Private Async Sub RadioButtonAll_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAll.CheckedChanged
        If Not RadioButtonAll.Checked Then Return

        If dgPickList.CurrentRow Is Nothing AndAlso dgCustomerOrders.CurrentRow Is Nothing Then Return

        Await displayCustomerOrderItems(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value))

        RadioButtonNotFullyPicked.Text = "Not fully picked"
    End Sub

    Private Sub RadioButtonNotFullyPicked_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNotFullyPicked.CheckedChanged

        If Not RadioButtonNotFullyPicked.Checked Then Return

        Dim fsdfsd = dgCustomerOrderItems.Rows.OfType(Of DataGridViewRow).
            Where(Function(t) t.DefaultCellStyle.ForeColor = Drawing.Color.Red).
            ToList()

        dgCustomerOrderItems.Rows.Clear()
        For Each row In fsdfsd
            dgCustomerOrderItems.Rows.Add(row)
        Next

        RadioButtonNotFullyPicked.Text = $"Not fully picked ({fsdfsd.Count()})"
    End Sub

    Private Async Sub ButtonAutomatePickList_Click(sender As Object, e As EventArgs) Handles ButtonAutomatePickList.Click
        ButtonAutomatePickList.Enabled = False
        gbRackShelfColumn.Enabled = False

        If Not (dgPickList.CurrentRow IsNot Nothing AndAlso MessageBox.Show($"Proceed automate-picking item(s) on rack(s) (shelf/column) for Pick List #{dgPickList.CurrentRow.Cells(pl_picklistno.Name).Value}?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes) Then
            ButtonAutomatePickList.Enabled = True
            gbRackShelfColumn.Enabled = True
            Return
        End If

        Dim pickListDataService = GetRequiredService(Of IPickListDataService)()
        Dim pickList = Await pickListDataService.GetByIdAsync(id:=CInt(dgPickList.CurrentRow.Cells(pl_rowid.Name).Value))

        If pickList.Status = PickListStatus.Cancelled Or
            pickList.Status = PickListStatus.Completed Then

            MessageBox.Show(text:=$"Automate-picking can not be performed on Pick List #{dgPickList.CurrentRow.Cells(pl_picklistno.Name).Value}.", caption:=String.Empty, buttons:=MessageBoxButtons.OK, icon:=MessageBoxIcon.Information)

            ButtonAutomatePickList.Enabled = True
            gbRackShelfColumn.Enabled = True

            Return
        End If

        Dim pickLists = New List(Of PickListEntity) From {pickList}

        Dim pickListOrderItems = New List(Of PickListOrderItem)
        pickList.PickListOrders.ToList().ForEach(
            Function(t)
                pickListOrderItems.AddRange(t.PickListOrderItems.ToList())
            End Function)

        Dim orderDataService = GetRequiredService(Of IOrderDataService)()
        Dim orderIds = pickList.PickListOrders.GroupBy(Function(t) t.OrderID).Select(Function(t) t.Key).ToArray()
        Dim orders = Await orderDataService.GetManyByIdsAsync(ids:=orderIds)

        Dim inventoryLocationIds = New List(Of Integer)
        orders.
            ForEach(Sub(o)
                        inventoryLocationIds.AddRange(o.InventoryLocationIds)
                    End Sub)
        inventoryLocationIds = inventoryLocationIds.GroupBy(Function(t) t).Select(Function(t) t.Key).ToList()

        Dim productColorSizeIds = New List(Of Integer)
        orders.ForEach(Sub(t)
                           productColorSizeIds.AddRange(t.OrderItems.Select(Function(f) f.ProductColorSizeID.Value).ToList())
                       End Sub)
        Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()
        Dim productInventoryLocations = (Await productInventoryLocationDataService.GetByInventoryLocationIdsAndProductColorSizeIdsAsync(inventoryLocationIds:=inventoryLocationIds.ToArray(),
            productColorSizeIds:=productColorSizeIds.ToArray())).ToList()

        Dim pickListAutomation = New PickListAutomation(pickLists, 1)

        pickListAutomation.SetCurrentMessage("Loading resources...")
        pickListAutomation.IncreaseProgress("Finished loading resources.")

        Await Task.Run(
            Async Function()
                Await pickListAutomation.Start(orders:=orders,
                    pickListOrderItems:=pickListOrderItems,
                    productInventoryLocations:=productInventoryLocations)
            End Function).
        ContinueWith(
            Async Function(antecedent1)
                If Not antecedent1.IsCompleted Then Return

                Dim poNos = orders.GroupBy(Function(t) t.ReferenceNumber).Select(Function(t) t.Key).ToArray()

                MessageBox.Show($"Done automate-picking for Pick List #{dgPickList.CurrentRow.Cells(pl_picklistno.Name).Value} with P.O. no(s): {String.Join(", ", poNos)}.", caption:="Finish Automate-Picking", buttons:=MessageBoxButtons.OK, icon:=MessageBoxIcon.Information)

            End Function,
            cancellationToken:=CancellationToken.None,
            continuationOptions:=TaskContinuationOptions.OnlyOnRanToCompletion,
            scheduler:=TaskScheduler.FromCurrentSynchronizationContext).
        ContinueWith(
            Async Function(antecedent2)
                If Not antecedent2.IsFaulted Then Return

                MessageBox.Show("Something went wrong while generating the payroll . Please contact Globagility Inc. for assistance.", caption:="Fail Automate-Picking", buttons:=MessageBoxButtons.OK, icon:=MessageBoxIcon.Error)

            End Function,
            cancellationToken:=CancellationToken.None,
            continuationOptions:=TaskContinuationOptions.OnlyOnFaulted,
            scheduler:=TaskScheduler.FromCurrentSynchronizationContext).
        ContinueWith(
            Async Function()
                Await displayCustomerOrderItems(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value))

                ButtonAutomatePickList.Enabled = True
                gbRackShelfColumn.Enabled = True

            End Function,
            scheduler:=TaskScheduler.FromCurrentSynchronizationContext)

    End Sub

End Class