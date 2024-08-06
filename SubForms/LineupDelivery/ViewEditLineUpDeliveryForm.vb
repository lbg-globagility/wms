Imports System.IO
Imports System.Web.UI
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports OfficeOpenXml
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class ViewEditLineUpDeliveryForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim conn2 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim cue, searchmode As String
    Dim itemno, rowscount As Integer
    Dim vplloadingbar As Integer = 4
    Dim veluddeliverytruckcbm, veludlineupboxescbmsum, veludlineupboxescbm As Decimal
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim veludlineupdate, veludorderitemstatus, veludlineupcartonstatus As String
    Dim simplesearchphrase, datephrase, commonphrase, pagefilter1, pagefilter2, pagefilter3, pagefilter4 As String
    Dim veludtotalqtyincarton, veludqtyincartonbalance, veludqtytodeliver As Integer
    Dim veludcustomerid, veludcontactid, veluddeliverytruckshiftid, veludpackinglistid, veludlineupid, veludorderid, veluddeliverytruckid, veludpackinglistcartonid, veludlineupcbmid As Integer
    Dim printdatatable As New Data.DataTable()
    Dim printdatasetHthurston As New DataSetA.SetHDataTable
    Dim printdatasetJthurston As New DataSetA.SetJDataTable
    Dim printdatasetIthurston As New DataSetA.SetIDataTable
    Public veludpublicdeliverydate As String
    Public veludpublicdeliverytruckshiftid As Integer
    Public vieweditlineupdeliverycue As Boolean = False
    Public veludpublicselectedcellcue As Boolean = False
    Private _agents As List(Of WarehouseManagementSystem.Core.Entities.Contact)
    Private _helpers As List(Of WarehouseManagementSystem.Core.Entities.Contact)
    Private _systemOwner As WarehouseManagementSystem.Core.Entities.SystemOwner
    Private ReadOnly Property IsShowDialog As Boolean

    Private Async Sub ViewEditLineUpDeliveryForm_LoadAsync(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        If IsThurston Then
            Label9.Visible = False
            txtCBM.Visible = False
            Label23.Visible = False
            txtBoxCBM.Visible = False
            Label15.Text = "Contents"
            lblCartonNoE.Text = "Select Contents: "
            ca_cartonno.HeaderText = String.Empty
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            If veludpublicselectedcellcue = fraud Then
                displayLineUpList(spagenum)
                pageSetup()
            Else
                If veludpublicdeliverytruckshiftid = 0 Then
                    displaySelectedSearch(veludpublicdeliverydate, "", spagenum)
                    pageSetup4(veludpublicdeliverydate, "")
                Else
                    displaySelectedSearch(veludpublicdeliverydate, "AND lu.deliverytruckshiftid = " & veludpublicdeliverytruckshiftid & "", spagenum)
                    pageSetup4(veludpublicdeliverydate, "AND lu.deliverytruckshiftid = " & veludpublicdeliverytruckshiftid & "")
                End If
            End If
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default

        Await GetAgentsAsync()
        Await GetHelpersAsync()

        If IsThurston Then
            For Each comboBox In gbLineUpInformation.Controls.
                OfType(Of Control).
                OfType(Of ComboBox).
                ToArray()

                SetStyleToDropDownList(comboBox)
            Next

            For Each comboBox In FlowLayoutPanel1.Controls.
                OfType(Of Control).
                OfType(Of ComboBox).
                ToArray()

                SetStyleToDropDownList(comboBox)
            Next

            If _IsShowDialog Then
                Dim defaultSelectedGridRowCell = dgLineUpList.Rows?.OfType(Of DataGridViewRow)?.FirstOrDefault()?.Cells(lu_lineupno.Name)
                If defaultSelectedGridRowCell IsNot Nothing Then dgLineUpList_CellClick(sender:=dgLineUpList, e:=New DataGridViewCellEventArgs(columnIndex:=defaultSelectedGridRowCell.ColumnIndex, rowIndex:=defaultSelectedGridRowCell.RowIndex))
            End If
        End If

    End Sub

    Private Async Function GetAgentsAsync() As Task
        Dim contactDataService = GetRequiredService(Of IContactDataService)()

        _agents = Await contactDataService.GetAgentsAsync(organizationId:=Z_OrganizationID)

        Dim agentDataSource = New List(Of WarehouseManagementSystem.Core.Entities.Contact) From {WarehouseManagementSystem.Core.Entities.Contact.NewContact(organizationId:=Z_OrganizationID, lastName:=String.Empty, firstName:=String.Empty, workPhone:=String.Empty, type:=ContactType.Agent)}
        agentDataSource.AddRange(_agents)
        cboAgent.ValueMember = "RowID"
        cboAgent.DisplayMember = "FullNameLastNameFirst"
        cboAgent.DataSource = agentDataSource

    End Function

    Private Async Function GetHelpersAsync() As Task
        Dim contactDataService = GetRequiredService(Of IContactDataService)()

        _helpers = Await contactDataService.GetHelpersAsync(organizationId:=Z_OrganizationID)

        Dim helperDataSource = New List(Of WarehouseManagementSystem.Core.Entities.Contact) From {WarehouseManagementSystem.Core.Entities.Contact.NewContact(organizationId:=Z_OrganizationID, lastName:=String.Empty, firstName:=String.Empty, workPhone:=String.Empty, type:=ContactType.Driver)}
        helperDataSource.AddRange(_helpers)

        cboHelper1.ValueMember = "RowID"
        cboHelper1.DisplayMember = "FullNameLastNameFirst"
        cboHelper1.DataSource = helperDataSource

        cboHelper2.ValueMember = "RowID"
        cboHelper2.DisplayMember = "FullNameLastNameFirst"
        cboHelper2.BindingContext = New BindingContext()
        cboHelper2.DataSource = helperDataSource

    End Function

    Private Sub ViewEditLineUpDeliveryForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        globalautocompleteTruckShiftInfo(cboTruckShiftInfo, Me)
        globalautocompleteContactName(cboDriverName, "Driver", Me)
    End Sub

    Sub callAutoPopulate()
        autopopulatecboSearch()
        globalautopopulateTruckShiftInfo(cboTruckShiftInfo, Me)
        globalautopopulateContactName(cboDriverName, "Driver", Me)
    End Sub

#Region "Click"

    Sub tsrefreshperformclick()
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            displayLineUpList(spagenum)
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
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            If dgLineUpList.Rows.Count <> 0 Then
                getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                If globallineupstatus <> "Lined Up" Then
                    If globallineupstatus <> "Delivered" Then
                        errProvider.SetError(txtStatus, "The line up has been confirmed or cancelled already.")
                        Exit Try
                    End If
                End If
            Else
                errProvider.SetError(txtLineUpNo, "System cannot find the line up.")
                Exit Try
            End If
            If LTrim(cboCartonNo.Text) <> "" Then
                getPackingListCartonIDA(veludpackinglistid, cboCartonNo.Text, "AND `status` = 'Active'", Me)
                veludpackinglistcartonid = globalpackinglistcartonid
                If veludpackinglistcartonid = 0 Then
                    errProvider.SetError(cboCartonNo, "The box is not available any longer.")
                    Exit Try
                End If
            Else
                errProvider.SetError(cboCartonNo, "Please enter the box no.")
                Exit Try
            End If
            getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
            veluddeliverytruckshiftid = globaldeliverytruckshiftid
            veluddeliverytruckid = globaldeliverytruckid
            If veluddeliverytruckshiftid <> 0 Then
                veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, veludlineupdate)
                If Not IsThurston AndAlso veluddeliverytruckcbm - (veludlineupboxescbmsum + If(IsNumeric(txtBoxCBM.Text), CDec(txtBoxCBM.Text), 0.0)) < neutralpage Then
                    errProvider.SetError(txtCBM, "System detected that the truck is full already.")
                    Exit Try
                End If
                getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
                veludlineupid = globallineupid
                If veludlineupid <> 0 Then
                    errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                    errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                    errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                    Exit Try
                End If
            Else
                errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to add this box in this line up?", "Adding", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If dgLineUpList.Rows.Count <> 0 Then
                    getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                    If globallineupstatus <> "Lined Up" Then
                        If globallineupstatus <> "Delivered" Then
                            errProvider.SetError(txtLineUpNo, "The line up has been confirmed or cancelled already.")
                            Exit Try
                        End If
                    End If
                Else
                    errProvider.SetError(txtLineUpNo, "System cannot find the line up.")
                    Exit Try
                End If
                getPackingListCartonIDA(veludpackinglistid, cboCartonNo.Text, "AND `status` = 'Active'", Me)
                veludpackinglistcartonid = globalpackinglistcartonid
                If veludpackinglistcartonid = 0 Then
                    errProvider.SetError(cboCartonNo, "The box is not available any longer.")
                    Exit Try
                End If
                I_LineUpCartons(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, veludpackinglistcartonid, CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), "Lined Up", 0.0, Me)
                If myModule.systemerrorfound = False Then
                    U_PackingListCartonStatus(veludpackinglistcartonid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Lined Up", Me)
                End If
                If myModule.systemerrorfound = False Then
                    updatePackingListCartonItemsA(veludpackinglistcartonid)
                End If
                If myModule.systemerrorfound = False Then
                    myBalloon("Successfully Added", "Add", lblsavemsg, -15, -65)
                    displayLineUpCartons(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value))
                    cboCartonNo.Text = "" : cboCartonNo.SelectedItem = Nothing
                    globalautocompleteCartonNos(cboCartonNo, veludpackinglistid, Me)
                    globalautopopulateCartonNos(cboCartonNo, veludpackinglistid, Me)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Computations"

    Sub getTotalQtyInCarton(ByVal epackinglistid As Integer, ByVal eorderitemid As Integer)
        Try
            veludtotalqtyincarton = 0
            Dim dtGtq As New Data.DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pci.qtyincarton),0) FROM packinglistcartonitems pci LEFT JOIN packinglistcartons pc ON pci.packinglistcartonid = pc.rowid WHERE pc.packinglistid = " & epackinglistid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' AND pci.orderitemid = " & eorderitemid & " ")
            If dtGtq.Rows.Count <> 0 Then
                veludtotalqtyincarton = dtGtq.Rows(0)(0)
            Else
                veludtotalqtyincarton = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getDeliveryTruckCBM(ByVal edeliverytruckid As Integer)
        Try
            veluddeliverytruckcbm = 0
            Dim dtGcbm As New Data.DataTable
            dtGcbm = getDataTableForSQL("SELECT COALESCE(dt.cbm,0) FROM deliverytrucks dt WHERE dt.rowid = " & edeliverytruckid & " ")
            If dtGcbm.Rows.Count <> 0 Then
                veluddeliverytruckcbm = dtGcbm.Rows(0)(0)
            Else
                veluddeliverytruckcbm = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getLineUpID(ByVal edeliverytruckshiftid As Integer, ByVal edeliverydate As String)
        Try
            veludlineupboxescbmsum = 0.0
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT rowid FROM lineups WHERE deliverytruckshiftid = " & edeliverytruckshiftid & " AND lineupdate = """ & edeliverydate & """ AND organizationid = " & Z_OrganizationID & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getLineUpBoxesCBM(CInt(reader1(0)))
                    veludlineupboxescbmsum = veludlineupboxescbmsum + veludlineupboxescbm
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getLineUpBoxesCBM(ByVal ilineupid As Integer)
        Try
            veludlineupboxescbm = 0
            Dim dtGcbm As New Data.DataTable
            dtGcbm = getDataTableForSQL("SELECT COALESCE(SUM(luc.cbm),0.0) FROM lineupcartons luc WHERE luc.lineupid = " & ilineupid & " AND luc.`status` != 'Inactive' AND luc.organizationid = " & Z_OrganizationID & " ")
            If dtGcbm.Rows.Count <> 0 Then
                veludlineupboxescbm = dtGcbm.Rows(0)(0)
            Else
                veludlineupboxescbm = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub cbmcomputation(ByVal ideliverytruckid As Integer, ByVal ideliverytruckshiftid As Integer, ByVal ideliverydate As String)
        Try
            getLineUpCBMID(ideliverytruckshiftid, ideliverydate, Me)
            veludlineupcbmid = globallineupcbmid
            If veludlineupcbmid = 0 Then
                getDeliveryTruckCBM(ideliverytruckid)
            Else
                veluddeliverytruckcbm = globalcbm
            End If
            getLineUpID(ideliverytruckshiftid, ideliverydate)
            txtCBM.Text = Format(veluddeliverytruckcbm - veludlineupboxescbmsum, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
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
            clearLineUpInformation()
            dgCartons.Rows.Clear()
            enableGB(legit, fraud)
            enableANDvisibleMS(fraud, fraud, fraud, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cue = ""
            clearLineUpInformation()
            dgCartons.Rows.Clear()
            enableGB(legit, fraud)
            enableANDvisibleMS(fraud, fraud, fraud, fraud, fraud)
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

    Sub clearLineUpInformation()
        Try
            txtLineUpNo.Text = ""
            dtpLineUpDate.Value = Now.Date
            txtConfirmedDate.Text = ""
            txtStatus.Text = ""
            cboTruckShiftInfo.Text = ""
            cboDriverName.Text = ""
            txtCBM.Text = ""
            txtSIDRNo.Text = ""
            txtCustomerOrderInfo.Text = ""
            txtPONo.Text = ""
            txtCustomerOrderDate.Text = ""
            txtReceiptDate.Text = ""
            txtCancelDate.Text = ""
            txtDeliveryAddress.Text = ""
            txtBranchCodeNameInfo.Text = ""
            txtVendorCodeNameInfo.Text = ""
            txtClassDescription.Text = ""
            txtDeliveryHours.Text = ""
            txtComments.Text = ""
            cboCartonNo.Text = ""
            txtBoxCBM.Text = ""
            txtSizeName.Text = ""
            cboTruckShiftInfo.SelectedItem = Nothing
            cboDriverName.SelectedItem = Nothing
            cboCartonNo.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbLineUpList.Enabled = enable1
            gbLineUpInformation.Enabled = enable2
            gbCartons.Enabled = enable2
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableANDvisibleMS(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean, ByVal enable4 As Boolean, ByVal enable5 As Boolean)
        Try
            msSave.Enabled = enable1
            msToDeliver.Enabled = enable2
            msOrder.Enabled = enable3
            msPrint.Enabled = enable4
            msConfirm.Enabled = enable5
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
            Dim dtCid As New Data.DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(lu.rowid),0) FROM lineups lu WHERE lu.organizationid = " & Z_OrganizationID & " ")
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
            Dim dtCid As New Data.DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(lu.rowid),0) FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid WHERE lu.organizationid = " & Z_OrganizationID & " " &
                            "AND (lu.deliveryno LIKE ""%" & esearchstring & "%"" OR o.ordernumber LIKE ""%" & esearchstring & "%"" OR lu.lineupno LIKE ""%" & esearchstring & "%"" OR a.companyname LIKE ""%" & esearchstring & "%"" OR lu.status LIKE ""%" & esearchstring & "%"") ")
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
            Dim dtCid As New Data.DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(lu.rowid),0) FROM lineups lu WHERE lu.organizationid = " & Z_OrganizationID & " AND " &
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
            Dim dtCid As New Data.DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(lu.rowid),0) FROM lineups lu WHERE lu.organizationid = " & Z_OrganizationID & " AND " & ecommonstring & " " & edatesearch & " ")
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

    Sub pageSetup4(ByVal ilineupdate As String, ByVal iconditionstring As String)
        Try
            getCountPageNum4(ilineupdate, iconditionstring)
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

    Sub getCountPageNum4(ByVal elineupdate As String, ByVal econditionstring As String)
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New Data.DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(lu.rowid),0) FROM lineups lu WHERE lu.organizationid = " & Z_OrganizationID & " AND lu.lineupdate = '" & elineupdate & "' " & econditionstring & " ")
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
                veludcustomerid = globalcustomerid
                commonphrase = "o.accountid = " & veludcustomerid & ""
            ElseIf icommonbox.Text = "CustomerOrderNo" Then
                commonphrase = "o.ordernumber = """ & icommonstring & """"
            ElseIf icommonbox.Text = "S.I./D.R. No." Then
                commonphrase = "lu.deliveryno = """ & icommonstring & """"
            ElseIf icommonbox.Text = "DriverName" Then
                getContactID(icommonstring, "Driver", Me)
                veludcontactid = globalcontactid
                commonphrase = "lu.contactid = " & veludcontactid & ""
            ElseIf icommonbox.Text = "LineUpNo" Then
                commonphrase = "lu.lineupno = """ & icommonstring & """"
            ElseIf icommonbox.Text = "Status" Then
                commonphrase = "lu.status = """ & icommonstring & """"
            ElseIf icommonbox.Text = "TruckShiftInfo" Then
                getDeliveryTruckShiftIDB(icommonstring, "", Me)
                veluddeliverytruckshiftid = globaldeliverytruckshiftid
                commonphrase = "lu.deliverytruckshiftid = " & veluddeliverytruckshiftid & ""
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
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'') AS 'customername' FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY a.rowid ", conn)
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

    Sub autocompleteCustomerOrderNo(ByVal icombobox As ComboBox)
        Try
            Dim ordernumber As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(o.ordernumber,'') AS 'ordernumber' FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY o.rowid ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                ordernumber.Add(ds.Tables(0).Rows(i)("ordernumber").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = ordernumber
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteDeliveryNo(ByVal icombobox As ComboBox)
        Try
            Dim deliveryno As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(lu.deliveryno,'') AS 'deliveryno' FROM lineups lu WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY lu.deliveryno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                deliveryno.Add(ds.Tables(0).Rows(i)("deliveryno").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = deliveryno
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteDriverName(ByVal icombobox As ComboBox)
        Try
            Dim drivername As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'drivername' FROM lineups lu LEFT JOIN contacts c ON lu.contactid = c.rowid WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY c.rowid ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                drivername.Add(ds.Tables(0).Rows(i)("drivername").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = drivername
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteLineUpNo(ByVal icombobox As ComboBox)
        Try
            Dim lineupno As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(lu.lineupno,'') AS 'lineupno' FROM lineups lu WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY lu.lineupno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                lineupno.Add(ds.Tables(0).Rows(i)("lineupno").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = lineupno
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteStatus(ByVal icombobox As ComboBox)
        Try
            Dim lustatus As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(lu.status,'') AS 'lustatus' FROM lineups lu WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY lu.status ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                lustatus.Add(ds.Tables(0).Rows(i)("lustatus").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = lustatus
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteTruckShiftInfo(ByVal icombobox As ComboBox)
        Try
            Dim truckshiftinfo As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.truckno,''),' / ',COALESCE(s.shiftname,'')),'') AS 'truckshiftinfo' FROM lineups lu LEFT JOIN deliverytruckshifts dts ON lu.deliverytruckshiftid = dts.rowid " &
                            "LEFT JOIN deliverytrucks dt ON dts.deliverytruckid = dt.rowid LEFT JOIN shifts s ON dts.shiftid = s.rowid WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY dts.rowid ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                truckshiftinfo.Add(ds.Tables(0).Rows(i)("truckshiftinfo").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = truckshiftinfo
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
            cboDate.Items.Add("ConfirmedDate")
            cboDate.Items.Add("DeliveryDate")
            cboDate.Items.Add("")
            cboSearch1.Items.Clear()
            cboSearch3.Items.Clear()
            cboSearch1.Items.Add("CustomerName")
            cboSearch1.Items.Add("CustomerOrderNo")
            cboSearch1.Items.Add("S.I./D.R. No.")
            cboSearch1.Items.Add("DriverName")
            cboSearch1.Items.Add("LineUpNo")
            cboSearch1.Items.Add("Status")
            cboSearch1.Items.Add("TruckShiftInfo")
            cboSearch3.Items.Add("CustomerName")
            cboSearch3.Items.Add("CustomerOrderNo")
            cboSearch3.Items.Add("S.I./D.R. No.")
            cboSearch3.Items.Add("DriverName")
            cboSearch3.Items.Add("LineUpNo")
            cboSearch3.Items.Add("Status")
            cboSearch3.Items.Add("TruckShiftInfo")
            cboSearch1.Items.Add("")
            cboSearch3.Items.Add("")
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
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'') AS 'customername' FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY a.rowid ORDER BY a.companyname "
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

    Sub autopopulateCustomerOrderNo(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(o.ordernumber,'') AS 'ordernumber' FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY o.rowid ORDER BY o.ordernumber "
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

    Sub autopopulateDeliveryNo(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(lu.deliveryno,'') AS 'deliveryno' FROM lineups lu WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY lu.deliveryno ORDER BY lu.deliveryno "
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

    Sub autopopulateDriverName(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'drivername' FROM lineups lu LEFT JOIN contacts c ON lu.contactid = c.rowid WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY c.rowid ORDER BY c.firstname "
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

    Sub autopopulateLineUpNo(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(lu.lineupno,'') AS 'lineupno' FROM lineups lu WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY lu.lineupno ORDER BY lu.lineupno "
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
            Dim sql1 As String = "SELECT COALESCE(lu.status,'') AS 'lustatus' FROM lineups lu WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY lu.status ORDER BY lu.status "
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

    Sub autopopulateTruckShiftInfo(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.truckno,''),' / ',COALESCE(s.shiftname,'')),'') AS 'truckshiftinfo' FROM lineups lu LEFT JOIN deliverytruckshifts dts ON lu.deliverytruckshiftid = dts.rowid " &
                        "LEFT JOIN deliverytrucks dt ON dts.deliverytruckid = dt.rowid LEFT JOIN shifts s ON dts.shiftid = s.rowid WHERE lu.organizationid = " & Z_OrganizationID & " GROUP BY dts.rowid ORDER BY dt.truckname,s.shiftname DESC "
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

    Sub displayLineUpList(ByVal istartpage As Integer)
        Try
            dgLineUpList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT lu.rowid,COALESCE(lu.lineupno,''),COALESCE(o.drnumber,''),COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'')," &
                        "COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),'') FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid WHERE lu.organizationid = " & Z_OrganizationID & " " &
                        "ORDER BY lu.deliveryno DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgLineUpList.Rows.Add()
                    dgLineUpList.Item(lu_rowid.Index, n).Value = reader1(0)
                    dgLineUpList.Item(lu_lineupno.Index, n).Value = reader1(1)
                    dgLineUpList.Item(lu_deliveryno.Index, n).Value = reader1(2)
                    dgLineUpList.Item(lu_customerorderinfo.Index, n).Value = reader1(3)
                    dgLineUpList.Item(lu_deliverydate.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgLineUpList.Columns("lu_lineupno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLineUpList.Columns("lu_deliveryno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLineUpList.Columns("lu_deliverydate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgLineUpList.Rows.Count <> 0 Then
                dgLineUpList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgLineUpList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT lu.rowid,COALESCE(lu.lineupno,''),COALESCE(o.drnumber,''),COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'')," &
                        "COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),'') FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid WHERE lu.organizationid = " & Z_OrganizationID & " " &
                        "AND (lu.deliveryno LIKE ""%" & isearchphrase & "%"" OR o.ordernumber LIKE ""%" & isearchphrase & "%"" OR lu.lineupno LIKE ""%" & isearchphrase & "%"" OR a.companyname LIKE ""%" & isearchphrase & "%"" OR lu.status LIKE ""%" & isearchphrase & "%"") " &
                        "ORDER BY lu.deliveryno DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgLineUpList.Rows.Add()
                    dgLineUpList.Item(lu_rowid.Index, n).Value = reader1(0)
                    dgLineUpList.Item(lu_lineupno.Index, n).Value = reader1(1)
                    dgLineUpList.Item(lu_deliveryno.Index, n).Value = reader1(2)
                    dgLineUpList.Item(lu_customerorderinfo.Index, n).Value = reader1(3)
                    dgLineUpList.Item(lu_deliverydate.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgLineUpList.Columns("lu_lineupno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLineUpList.Columns("lu_deliveryno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLineUpList.Columns("lu_deliverydate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgLineUpList.Rows.Count <> 0 Then
                dgLineUpList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayDateSearch(ByVal istartpage As Integer, ByVal idatesearch As String)
        Try
            dgLineUpList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT lu.rowid,COALESCE(lu.lineupno,''),COALESCE(o.drnumber,''),COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'')," &
                        "COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),'') FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid WHERE lu.organizationid = " & Z_OrganizationID & " " &
                        "AND (" & idatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " & idatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) " &
                        "GROUP BY lu.rowid ORDER BY lu.deliveryno DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgLineUpList.Rows.Add()
                    dgLineUpList.Item(lu_rowid.Index, n).Value = reader1(0)
                    dgLineUpList.Item(lu_lineupno.Index, n).Value = reader1(1)
                    dgLineUpList.Item(lu_deliveryno.Index, n).Value = reader1(2)
                    dgLineUpList.Item(lu_customerorderinfo.Index, n).Value = reader1(3)
                    dgLineUpList.Item(lu_deliverydate.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgLineUpList.Columns("lu_lineupno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLineUpList.Columns("lu_deliveryno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLineUpList.Columns("lu_deliverydate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgLineUpList.Rows.Count <> 0 Then
                dgLineUpList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal idatesearch As String, ByVal istartpage As Integer)
        Try
            dgLineUpList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT lu.rowid,COALESCE(lu.lineupno,''),COALESCE(o.drnumber,''),COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'')," &
                        "COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),'') FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid WHERE lu.organizationid = " & Z_OrganizationID & " " &
                        "AND " & icommonphrase & " " & idatesearch & " ORDER BY lu.deliveryno DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgLineUpList.Rows.Add()
                    dgLineUpList.Item(lu_rowid.Index, n).Value = reader1(0)
                    dgLineUpList.Item(lu_lineupno.Index, n).Value = reader1(1)
                    dgLineUpList.Item(lu_deliveryno.Index, n).Value = reader1(2)
                    dgLineUpList.Item(lu_customerorderinfo.Index, n).Value = reader1(3)
                    dgLineUpList.Item(lu_deliverydate.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgLineUpList.Columns("lu_lineupno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLineUpList.Columns("lu_deliveryno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLineUpList.Columns("lu_deliverydate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgLineUpList.Rows.Count <> 0 Then
                dgLineUpList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySelectedSearch(ByVal ilineupdate As String, ByVal iconditionstring As String, ByVal istartpage As Integer)
        Try
            dgLineUpList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT lu.rowid,COALESCE(lu.lineupno,''),COALESCE(lu.deliveryno,''),COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'')," &
                        "COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),'') FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid WHERE lu.organizationid = " & Z_OrganizationID & " " &
                        "AND lu.lineupdate = '" & ilineupdate & "' " & iconditionstring & " ORDER BY lu.deliveryno DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgLineUpList.Rows.Add()
                    dgLineUpList.Item(lu_rowid.Index, n).Value = reader1(0)
                    dgLineUpList.Item(lu_lineupno.Index, n).Value = reader1(1)
                    dgLineUpList.Item(lu_deliveryno.Index, n).Value = reader1(2)
                    dgLineUpList.Item(lu_customerorderinfo.Index, n).Value = reader1(3)
                    dgLineUpList.Item(lu_deliverydate.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgLineUpList.Columns("lu_lineupno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLineUpList.Columns("lu_deliveryno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLineUpList.Columns("lu_deliverydate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgLineUpList.Rows.Count <> 0 Then
                dgLineUpList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayLineUpInformation(ByVal ilineupid As Integer)
        Try
            Dim dtLUinfo As New Data.DataTable
            dtLUinfo = getDataTableForSQL("SELECT COALESCE(lu.lineupno,''),COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),''),COALESCE(o.drnumber,''),COALESCE(DATE_FORMAT(IFNULL(lu.deliverydate, lu.ConfirmedDeliveryTimeStamp),'%d-%b-%Y'),''),IFNULL(dt.truckname, ''),COALESCE(lu.status,'')," &
                        "COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ', COALESCE(a.companyname,''),' - ', COALESCE(a.accountno,''),' / ',CONCAT(COALESCE(pl.packinglistno,''),' (Pa.L. No.)')),'')," &
                        "COALESCE(DATE_FORMAT(o.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.targetdate,'%d-%b-%Y'),''),COALESCE(o.customeraddress,''),COALESCE(lu.comments,''),COALESCE(o.deliveryhours,''),COALESCE(lu.packinglistid,0),COALESCE(lu.orderid,0),COALESCE(o.referencenumber,''),COALESCE(DATE_FORMAT(o.enddate,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(ve.companyname,''),' - ',COALESCE(ve.companycode,'')),''),COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),''), lu.AgentId, lu.Helper1Id, lu.Helper2Id FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN deliverytruckshifts dts ON lu.deliverytruckshiftid = dts.rowid LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid " &
                        "LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN companies ve ON o.companyid = ve.rowid LEFT JOIN deliverytrucks dt ON dts.deliverytruckid = dt.rowid LEFT JOIN shifts s ON dts.shiftid = s.rowid LEFT JOIN contacts c ON lu.contactid = c.rowid LEFT JOIN accounts a ON o.accountid = a.rowid LEFT JOIN packinglist pl ON lu.packinglistid = pl.rowid WHERE lu.rowid = " & ilineupid & " ")
            If dtLUinfo.Rows.Count <> 0 Then
                veludpackinglistid = dtLUinfo.Rows(0)(13)
                veludorderid = dtLUinfo.Rows(0)(14)
                txtLineUpNo.Text = dtLUinfo.Rows(0)(0)
                dtpLineUpDate.Text = dtLUinfo.Rows(0)(1)
                txtSIDRNo.Text = dtLUinfo.Rows(0)(2)
                txtConfirmedDate.Text = dtLUinfo.Rows(0)(3)
                cboTruckShiftInfo.Text = dtLUinfo.Rows(0)(4)
                txtStatus.Text = dtLUinfo.Rows(0)(5)
                cboDriverName.Text = dtLUinfo.Rows(0)(6)
                txtCustomerOrderInfo.Text = dtLUinfo.Rows(0)(7)
                txtCustomerOrderDate.Text = dtLUinfo.Rows(0)(8)
                txtReceiptDate.Text = dtLUinfo.Rows(0)(9)
                txtDeliveryAddress.Text = dtLUinfo.Rows(0)(10)
                txtComments.Text = dtLUinfo.Rows(0)(11)
                txtDeliveryHours.Text = dtLUinfo.Rows(0)(12)
                txtPONo.Text = dtLUinfo.Rows(0)(15)
                txtCancelDate.Text = dtLUinfo.Rows(0)(16)
                txtBranchCodeNameInfo.Text = dtLUinfo.Rows(0)(17)
                txtVendorCodeNameInfo.Text = dtLUinfo.Rows(0)(18)
                txtClassDescription.Text = dtLUinfo.Rows(0)(19)
                cboAgent.SelectedValue = dtLUinfo.Rows(0)(20)
                cboHelper1.SelectedValue = dtLUinfo.Rows(0)(21)
                cboHelper2.SelectedValue = dtLUinfo.Rows(0)(22)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub displayLineUpCartons(ByVal ilineupid As Integer)
        Try
            dgCartons.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT luc.rowid,luc.packinglistcartonid,COALESCE(pc.cartonno,''),COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(DATE_FORMAT(pc.packeddate,'%d-%b-%Y'),''),COALESCE(luc.`status`,''),COALESCE(cs.sizename,''),COALESCE(cs.`length`,0)," &
                        $"COALESCE(cs.`width`,0),COALESCE(cs.`height`,0) FROM packinglistcartons pc
                        INNER JOIN packinglist pl ON pl.RowID=pc.PackingListID
                        INNER JOIN lineupcartons luc ON luc.PackingListCartonID=pc.RowID
                        INNER JOIN lineups lu ON lu.RowID=luc.LineUpID AND lu.LineUpNo={ilineupid}
                        LEFT JOIN contacts c ON pc.contactid = c.rowid
                        LEFT JOIN cartonsizes cs ON pc.cartonsizeid = cs.rowid
                        INNER JOIN packinglistcartonitems plci ON plci.PackingListCartonID=pc.RowID
                        WHERE luc.organizationid = " & Z_OrganizationID & " AND luc.`status` != 'Inactive' HAVING COUNT(plci.RowID) > 0 ORDER BY pc.cartonno "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgCartons.Rows.Add()
                    dgCartons.Item(ca_seqno.Index, n).Value = seqno
                    dgCartons.Item(ca_rowid.Index, n).Value = reader1(0)
                    dgCartons.Item(ca_packinglistcartonid.Index, n).Value = reader1(1)
                    dgCartons.Item(ca_cartonno.Index, n).Value = reader1(2)
                    dgCartons.Item(ca_packername.Index, n).Value = reader1(3)
                    dgCartons.Item(ca_packeddate.Index, n).Value = reader1(4)
                    dgCartons.Item(ca_status.Index, n).Value = reader1(5)
                    dgCartons.Item(ca_sizename.Index, n).Value = reader1(6)
                    dgCartons.Item(ca_cbm.Index, n).Value = Math.Round((CDec(reader1(7)) / 1000) * (CDec(reader1(8)) / 1000) * (CDec(reader1(9)) / 1000), 2)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCartons.Columns("ca_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_cartonno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_cbm").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_sizename").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCartons.Rows.Count <> 0 Then
                dgCartons.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

#Region "Adding / Removing / Cancelling / Confirming"

    Sub cancelLineUpCartons(ByVal ilineupid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT luc.rowid,luc.packinglistcartonid FROM lineupcartons luc WHERE luc.lineupid = " & ilineupid & " AND luc.organizationid = " & Z_OrganizationID & " AND luc.`status` != 'Inactive' ORDER BY luc.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        updatePackingListCartonItemsB(CInt(reader1(1)))
                    End If
                    If myModule.systemerrorfound = False Then
                        U_PackingListCartonStatus(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Active", Me)
                    End If
                    If myModule.systemerrorfound = False Then
                        U_LineUpCartonStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
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

    Sub confirmLineUpCartons(ByVal ilineupid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT luc.rowid,luc.packinglistcartonid FROM lineupcartons luc WHERE luc.lineupid = " & ilineupid & " AND luc.organizationid = " & Z_OrganizationID & " AND luc.`status` != 'Inactive' ORDER BY luc.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        updatePackingListCartonItemsC(CInt(reader1(1)))
                    End If
                    If myModule.systemerrorfound = False Then
                        U_PackingListCartonStatus(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Delivered", Me)
                    End If
                    If myModule.systemerrorfound = False Then
                        U_LineUpCartonStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Delivered", Me)
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

    Sub getPickListOrderID(ByVal iorderid As Integer, ByVal iorderitemid As Integer, ByVal iqtyincarton As Integer)
        Try
            Dim dtGid As New Data.DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.orderitemid = " & iorderitemid & " AND plo.orderid = " & iorderid & " AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') ")
            If dtGid.Rows.Count <> 0 Then
                updatePackingListCartonItemsD(CInt(dtGid.Rows(0)(0)), iqtyincarton)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub updatePackingListCartonItemsA(ByVal ipackinglistcartonid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pci.rowid,pci.orderitemid,COALESCE(pci.qtyincarton,0),COALESCE(oi.qtyordered,0),COALESCE(oi.`status`,'') FROM packinglistcartonitems pci LEFT JOIN orderitems oi ON pci.orderitemid = oi.rowid WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    U_PackingListCartonItemStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Lined Up", Me)
                    getTotalQtyInCarton(veludpackinglistid, CInt(reader1(1)))
                    If veludtotalqtyincarton < CInt(reader1(3)) Then
                        veludorderitemstatus = "Partially Lined Up"
                    Else
                        veludorderitemstatus = "Lined Up"
                    End If
                    U_OrderItemStatus(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, veludorderitemstatus, Me)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub updatePackingListCartonItemsB(ByVal ipackinglistcartonid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pci.rowid,pci.orderitemid,COALESCE(pci.qtyincarton,0),COALESCE(oi.qtyordered,0),COALESCE(oi.`status`,'') FROM packinglistcartonitems pci LEFT JOIN orderitems oi ON pci.orderitemid = oi.rowid WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        U_PackingListCartonItemStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Active", Me)
                    End If
                    If myModule.systemerrorfound = False Then
                        getTotalQtyInCarton(veludpackinglistid, CInt(reader1(1)))
                        If veludtotalqtyincarton < CInt(reader1(3)) Then
                            veludorderitemstatus = "Partially Packed"
                        Else
                            veludorderitemstatus = "Packed"
                        End If
                        U_OrderItemStatus(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, veludorderitemstatus, Me)
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

    Sub updatePackingListCartonItemsC(ByVal ipackinglistcartonid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT pci.rowid,pci.orderitemid,COALESCE(pci.qtyincarton,0),COALESCE(oi.qtyordered,0),COALESCE(oi.`status`,'') FROM packinglistcartonitems pci LEFT JOIN orderitems oi ON pci.orderitemid = oi.rowid WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        U_PackingListCartonItemStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Delivered", Me)
                    End If
                    getPickListOrderID(veludorderid, CInt(reader1(1)), CInt(reader1(2)))
                    If myModule.systemerrorfound = False Then
                        U_OrderItemDelivery(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Delivered", If(veludcontactid = 0, DBNull.Value, veludcontactid), dtpLineUpDate.Value, Me)
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

    Sub updatePackingListCartonItemsD(ByVal epicklistorderid As Integer, ByVal eqtyincarton As Integer)
        Try
            veludqtyincartonbalance = eqtyincarton
            If conn2.State = ConnectionState.Closed Then conn2.Open()
            Dim sql1 As String = "SELECT pli.rowid,COALESCE(pli.productinventorylocationid,0),COALESCE(pli.qtypicked,0),COALESCE(pli.qtydelivered,0) FROM picklistorderitems pli WHERE pli.picklistorderid = " & epicklistorderid & " AND pli.qtypicked > 0 AND pli.organizationid = " & Z_OrganizationID & " AND (pli.`status` != 'Inactive' AND pli.`status` != 'Cancelled') "
            Dim cmd1 As New MySqlCommand(sql1, conn2)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If veludqtyincartonbalance > 0 Then
                        If CInt(reader1(2)) > CInt(reader1(3)) Then
                            veludqtytodeliver = CInt(reader1(2)) - CInt(reader1(3))
                            If veludqtyincartonbalance > veludqtytodeliver Then
                                U_PickListOrderItemQtyDelivered(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, veludqtytodeliver + CInt(reader1(3)), Me)
                                getProductInventoryLocationTotals(CInt(reader1(1)), Me)
                                U_ProductInventoryLocationTotals(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalpiltotalavailableqty, globalpiltotalreserveqty - veludqtytodeliver, Me)
                                I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, DBNull.Value, CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), DBNull.Value, DBNull.Value, CInt(reader1(1)),
                                        DBNull.Value, globalpiltotalreserveqty, veludqtytodeliver, globalpiltotalreserveqty - veludqtytodeliver, "Delivery", "TotalReserveQty", "", Me)
                                veludqtyincartonbalance = veludqtyincartonbalance - veludqtytodeliver
                            Else
                                U_PickListOrderItemQtyDelivered(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, veludqtyincartonbalance + CInt(reader1(3)), Me)
                                getProductInventoryLocationTotals(CInt(reader1(1)), Me)
                                U_ProductInventoryLocationTotals(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalpiltotalavailableqty, globalpiltotalreserveqty - veludqtyincartonbalance, Me)
                                I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, DBNull.Value, CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), DBNull.Value, DBNull.Value, CInt(reader1(1)),
                                        DBNull.Value, globalpiltotalreserveqty, veludqtyincartonbalance, globalpiltotalreserveqty - veludqtyincartonbalance, "Delivery", "TotalReserveQty", "", Me)
                                veludqtyincartonbalance = veludqtyincartonbalance - veludqtyincartonbalance
                            End If
                        End If
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

#End Region

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

    Private Sub pbAddTruckShiftInfo_MouseEnter(sender As Object, e As EventArgs) Handles pbAddTruckShiftInfo.MouseEnter
        Try
            pbAddTruckShiftInfo.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddTruckShiftInfo_MouseLeave(sender As Object, e As EventArgs) Handles pbAddTruckShiftInfo.MouseLeave
        Try
            pbAddTruckShiftInfo.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddDriver_MouseEnter(sender As Object, e As EventArgs) Handles pbAddDriver.MouseEnter
        Try
            pbAddDriver.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddDriver_MouseLeave(sender As Object, e As EventArgs) Handles pbAddDriver.MouseLeave
        Try
            pbAddDriver.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddTruckShiftInfo_Click(sender As Object, e As EventArgs) Handles pbAddTruckShiftInfo.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Dim addtruckshiftlinkform As New AddTruckShiftForm
            addtruckshiftlinkform.ShowInTaskbar = False
            addtruckshiftlinkform.ShowDialog()
            If addtruckshiftlinkform.addtruckshiftcue = legit Then
                globalautocompleteTruckShiftInfo(cboTruckShiftInfo, Me)
                globalautopopulateTruckShiftInfo(cboTruckShiftInfo, Me)
                vieweditlineupdeliverycue = legit
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAddDriver_Click(sender As Object, e As EventArgs) Handles pbAddDriver.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Dim adddriverlinkform As New AddDriverForm
            adddriverlinkform.ShowInTaskbar = False
            adddriverlinkform.ShowDialog()
            If adddriverlinkform.adddriverformcue = legit Then
                globalautocompleteContactName(cboDriverName, "Driver", Me)
                globalautopopulateContactName(cboDriverName, "Driver", Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Sub printDeliveryScheduleThurston(ByVal lineUpNo As Integer)
        Try
            printdatasetHthurston.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT
	                                CONCAT(COALESCE(c.FirstName, ''), ' ', COALESCE(c.MiddleName, ''), ' ', COALESCE(c.LastName, '')) AS Driver,
	                                REPLACE(CONCAT_WS('\r\n', CONCAT_WS(
                                        ' ',
                                        COALESCE(c2.FirstName, ''),
                                        NULLIF(COALESCE(c2.MiddleName, ''), ''),
                                        COALESCE(c2.LastName, '')
                                    ),
												CONCAT_WS(
                                        ' ',
                                        COALESCE(c3.FirstName, ''),
                                        NULLIF(COALESCE(c3.MiddleName, ''), ''),
                                        COALESCE(c3.LastName, '')
                                    )), '\n\n', '\b') AS Helper,
	                                lu.LineUpDate AS 'Date',
	                                GROUP_CONCAT(DISTINCT o.CustomerName) AS Customer,
	                                GROUP_CONCAT(DISTINCT o.ReferenceNumber) AS 'P.O. NO.',
	                                SUM(plci.QtyInCarton) AS Qty,
	                                GROUP_CONCAT(IFNULL(IFNULL(p.ProductCode, IFNULL(pcs.SKU, pcs.SKU2)), '[NO SKU]'), '/', IFNULL(plci.QtyInCarton, '') SEPARATOR ' , ') AS 'Item / Description'

		                                FROM
		                                lineups lu

		                                JOIN lineupcartons lc ON lu.RowID = lc.LineUpID
		                                LEFT JOIN contacts c  ON lu.ContactID = c.RowID
		                                LEFT JOIN contacts c2 ON lu.Helper1Id = c2.RowID
		                                LEFT JOIN contacts c3 ON lu.Helper2Id = c3.RowID
		                                JOIN orders o ON lu.OrderID = o.RowID
 		                                JOIN packinglistcartonitems plci ON lc.PackingListCartonID = plci.PackingListCartonID
 		                                JOIN orderitems oi ON plci.OrderItemID = oi.RowID
 		                                JOIN productcolorsizes pcs ON oi.ProductColorSizeID = pcs.RowID
 		                                JOIN productcolors pc ON pc.RowID=pcs.ProductColorID
 		                                JOIN products p ON p.RowID=pc.ProductID

			                                WHERE lu.LineUpNo = " & lineUpNo & " GROUP BY p.`Description`"
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    printdatasetHthurston.AddSetHRow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(2)), CStr(reader1(3)), CStr(reader1(4)), CStr(reader1(5)), CStr(reader1(6)), "")
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub printTripTicketThurston(ByVal lineUpNo As Integer)
        Try
            printdatasetHthurston.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT
	                                lu.LineUpDate AS 'Date',
	                                o.CustomerName AS Customer,
	                                o.DRNumber AS 'DR No',
	                                SUM(plci.QtyInCarton) AS Qty,
	                                CONCAT(COALESCE(c.FirstName, ''), ' ', COALESCE(c.MiddleName, ''), ' ', COALESCE(c.LastName, '')) AS Driver,
	                                CONCAT_WS(
                                        ' ',
                                        COALESCE(c2.FirstName, ''),
                                        NULLIF(COALESCE(c2.MiddleName, ''), ''),
                                        COALESCE(c2.LastName, '')
                                    ) AS Helper

		                                FROM
			                                lineups lu
			                                JOIN orders o ON lu.OrderID = o.RowID
			                                JOIN lineupcartons lc ON lu.RowID = lc.LineUpID
 			                                JOIN packinglistcartonitems plci ON lc.PackingListCartonID = plci.PackingListCartonID
			                                LEFT JOIN contacts c  ON lu.ContactID = c.RowID
			                                LEFT JOIN contacts c2 ON lu.Helper1Id = c2.RowID
				                                WHERE
					                                lu.RowID = " & lineUpNo & " AND
					                                plci.`Status` = 'Lined Up'"
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    printdatasetJthurston.AddSetJRow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(2)), CStr(reader1(3)), "", CStr(reader1(4)), CStr(reader1(5)), "", "", "", "")
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub DeliveryScheduleToolStripMenuItem_Click2(sender As Object, e As EventArgs) Handles DeliveryScheduleToolStripMenuItem.Click
        If Not IsThurston Then Return

        Dim prompt = MessageBox.Show(text:="Do you want to print DR with price? (Default: No)",
            caption:="Print DR with price (Default: No)",
            buttons:=MessageBoxButtons.YesNo,
            icon:=MessageBoxIcon.Question,
            defaultButton:=MessageBoxDefaultButton.Button2)

        Dim printreport As New DeliveryReceipt

        Dim fileContent = String.Join(separator:=Environment.NewLine, File.ReadAllLines("Report Files\DeliveryReceipt\DeliveryReceipt.json"))
        Dim deliveryReceiptDto = JsonConvert.DeserializeObject(Of DeliveryReceiptDto)(fileContent)

        Dim section = printreport.ReportDefinition.Sections.OfType(Of Section).FirstOrDefault()
        Dim companyNameTitle As TextObject = section?.ReportObjects("CompanyNameTitle1")
        companyNameTitle.Text = deliveryReceiptDto.CompanyNameTitle

        Dim supportingInfo As TextObject = section?.ReportObjects("SupportingInfo1")
        supportingInfo.Text = deliveryReceiptDto.SupportingInfo

        Dim deliveryReceiptCaption As TextObject = section?.ReportObjects("DeliveryReceiptCaption1")
        deliveryReceiptCaption.Text = deliveryReceiptDto.DeliveryReceiptCaption

        Dim receivedNote As TextObject = section?.ReportObjects("ReceivedNote1")
        receivedNote.Text = deliveryReceiptDto.ReceivedNote

        Dim footerNote As TextObject = section?.ReportObjects("FooterNote1")
        footerNote.Text = deliveryReceiptDto.FooterNote

        Dim accreditation As TextObject = section?.ReportObjects("Accreditation1")
        accreditation.Text = deliveryReceiptDto.Accreditation


        Dim sql = <![CDATA[
            SELECT
            o.DRNumber `DRNo`,
            #a.*,
            a.CompanyName,
            CONCAT_WS(', ', ad.StreetAddress1, ad.StreetAddress2, ad.Barangay, ad.CityTown, ad.Province, ad.State, ad.ZipCode, ad.Country) `Address`,
            lu.LineUpDate,
            SUM(plci.QtyInCarton) `DataColumn1`,
            pil.UnitOfMeasure2 `DataColumn2`,
            CONCAT('**', p.ProductGroupName, '**\n', GROUP_CONCAT(CONCAT(p.ProductCode, '(', plci.QtyInCarton, ')') SEPARATOR ', ')) `DataColumn3`,
            0 `DataColumn4`

            FROM lineups lu
            JOIN lineupcartons lc ON lu.RowID = lc.LineUpID
            LEFT JOIN contacts c ON lu.ContactID = c.RowID
            LEFT JOIN contacts c2 ON lu.Helper1Id = c2.RowID
            LEFT JOIN contacts c3 ON lu.Helper2Id = c3.RowID
            INNER JOIN orders o ON lu.OrderID = o.RowID
            INNER JOIN accounts a ON a.RowID=o.AccountID
            LEFT JOIN address ad ON ad.RowID=a.PrimaryAddressID
            INNER JOIN packinglistcartonitems plci ON lc.PackingListCartonID = plci.PackingListCartonID
            INNER JOIN orderitems oi ON plci.OrderItemID = oi.RowID
            INNER JOIN productcolorsizes pcs ON oi.ProductColorSizeID = pcs.RowID
            INNER JOIN productcolors pc ON pc.RowID=pcs.ProductColorID
            INNER JOIN products p ON p.RowID=pc.ProductID
            INNER JOIN productinventorylocation pil ON pil.RowID=oi.ProductInventoryLocationId
            WHERE lu.LineUpNo = @lineupNo
            GROUP BY p.ProductGroupName, pil.UnitOfMeasure2
            ]]>.Value

        If prompt = DialogResult.Yes Then sql = <![CDATA[
            SELECT
            o.DRNumber `DRNo`,
            #a.*,
            a.CompanyName,
            CONCAT_WS(', ', ad.StreetAddress1, ad.StreetAddress2, ad.Barangay, ad.CityTown, ad.Province, ad.State, ad.ZipCode, ad.Country) `Address`,
            lu.LineUpDate,
            SUM(plci.QtyInCarton) `DataColumn1`,
            pil.UnitOfMeasure2 `DataColumn2`,
            CONCAT('**', p.ProductGroupName, '**\n', GROUP_CONCAT(CONCAT(p.ProductCode, '(', plci.QtyInCarton, '×', pil.UnitPriceOfUOM2, ')') SEPARATOR ', '), '\n', 'Sub-Total: ', CAST(FORMAT(SUM(plci.QtyInCarton * pil.UnitPriceOfUOM2), 2) AS CHAR CHARACTER SET utf8)) `DataColumn3`,
            SUM(plci.QtyInCarton * pil.UnitPriceOfUOM2) `DataColumn4`

            FROM lineups lu
            JOIN lineupcartons lc ON lu.RowID = lc.LineUpID
            LEFT JOIN contacts c ON lu.ContactID = c.RowID
            LEFT JOIN contacts c2 ON lu.Helper1Id = c2.RowID
            LEFT JOIN contacts c3 ON lu.Helper2Id = c3.RowID
            INNER JOIN orders o ON lu.OrderID = o.RowID
            INNER JOIN accounts a ON a.RowID=o.AccountID
            LEFT JOIN address ad ON ad.RowID=a.PrimaryAddressID
            INNER JOIN packinglistcartonitems plci ON lc.PackingListCartonID = plci.PackingListCartonID
            INNER JOIN orderitems oi ON plci.OrderItemID = oi.RowID
            INNER JOIN productcolorsizes pcs ON oi.ProductColorSizeID = pcs.RowID
            INNER JOIN productcolors pc ON pc.RowID=pcs.ProductColorID
            INNER JOIN products p ON p.RowID=pc.ProductID
            INNER JOIN productinventorylocation pil ON pil.RowID=oi.ProductInventoryLocationId
            WHERE lu.LineUpNo = @lineupNo
            GROUP BY p.ProductGroupName, pil.UnitOfMeasure2
            ]]>.Value

        Await FunctionUtils.TryCatchFunctionAsync(messageTitle:="",
            Async Function()
                Using connection As New MySqlConnection(connectionString:=manager.GetConnString()),
            command As New MySqlCommand(sql, connection)

                    With command.Parameters
                        .AddWithValue("@lineupNo", If(dgLineUpList.CurrentRow?.Cells(lu_lineupno.Name).Value, DBNull.Value))
                    End With

                    Dim adapter = New MySqlDataAdapter()
                    adapter.SelectCommand = command
                    Dim dt As New Data.DataTable()
                    Await Task.Run(Sub()
                                       adapter.Fill(dt)
                                   End Sub)

                    If dt IsNot Nothing Then
                        printreport.SetDataSource(dt)
                    End If

                    Dim row = dt.Rows.OfType(Of DataRow).FirstOrDefault()

                    If row IsNot Nothing Then
                        Dim deliveryReceiptNo As TextObject = section?.ReportObjects("TextDeliveryReceiptNumber")
                        deliveryReceiptNo.Text = row?.Item("DRNo")

                        Dim deliveredTo As TextObject = section?.ReportObjects("TextDeliveredTo")
                        deliveredTo.Text = row?.Item("CompanyName")

                        Dim address As TextObject = section?.ReportObjects("TextAddress")
                        address.Text = row?.Item("Address")

                        'Dim tin As TextObject = section?.ReportObjects("TextTin")
                        'tin.Text = String.Empty

                        Dim [date] As TextObject = section?.ReportObjects("TextDate")
                        [date].Text = row?.Item("LineUpDate")

                        'Dim terms As TextObject = section?.ReportObjects("TextTerms")
                        'terms.Text = String.Empty

                        'Dim invoiceNo As TextObject = section?.ReportObjects("TextInvoiceNo")
                        'invoiceNo.Text = String.Empty
                    End If

                    PrintDeliveryReceiptExcel(dt)

                End Using
            End Function)

        Dim openreportviewer As New ReportViewer
        openreportviewer.CrystalReportViewer.ReportSource = printreport
        openreportviewer.Show()
    End Sub

    Private Sub PrintDeliveryReceiptExcel(dataTable As Data.DataTable)
        Dim fileName = Path.Combine(Path.GetTempPath(), "DeliveryReceiptExcel.xlsx")
        Dim template = Path.Combine(My.Application.Info.DirectoryPath, "Report Files\DeliveryReceipt\DeliveryReceiptExcel.xlsx")

        File.Copy(sourceFileName:=template, destFileName:=fileName, overwrite:=True)

        Using excel = New ExcelPackage(New FileInfo(fileName))

            Dim worksheet = excel.Workbook.Worksheets.FirstOrDefault()

            Dim row = dataTable.Rows.OfType(Of DataRow).FirstOrDefault()

            If row IsNot Nothing Then
                worksheet.Cells("E3").Value = row?.Item("DRNo")
                worksheet.Cells("B3").Value = row?.Item("CompanyName")
                worksheet.Cells("B4").Value = row?.Item("Address")
                worksheet.Cells("E4").Value = row?.Item("LineUpDate")
                worksheet.Cells("E4").Style.Numberformat.Format = "MMM/dd/yyyy"
            End If

            Dim index = 6

            For Each dr As DataRow In dataTable.Rows
                worksheet.Cells($"B{index}").Value = dr("DataColumn1")
                worksheet.Cells($"C{index}").Value = dr("DataColumn2")
                worksheet.Cells($"D{index}").Value = dr("DataColumn3")
                worksheet.Cells($"D{index}").Style.WrapText = True
                worksheet.Cells($"D{index}").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.General
                'worksheet.Row(index).

                index += 1
            Next

            worksheet.Cells($"B{index}").Value = dataTable.Select("CompanyName IS NOT NULL").Sum(Function(t) t("DataColumn1"))

            excel.Save()

            Process.Start(fileName:=fileName)
        End Using
    End Sub

    Private Sub TripTicketToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TripTicketToolStripMenuItem.Click
        If IsThurston Then
            printTripTicketThurston(CInt(dgLineUpList.CurrentRow.Cells("lu_lineupno").Value))
            Dim printreport As New TripTicket
            Dim openreportviewer As New ReportViewer
            openreportviewer.CrystalReportViewer.ReportSource = printreport
            printdatatable = printdatasetJthurston
            printreport.SetDataSource(printdatatable)
            openreportviewer.Show()
            printdatatable.Dispose()
            printdatatable = Nothing
            printdatasetJthurston.Clear()
        End If
    End Sub

    Private Sub GatePassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GatePassToolStripMenuItem.Click
        If IsThurston Then
            Return
            'printGatePassThurston(CInt(dgLineUpList.CurrentRow.Cells("lu_lineupno").Value))
            Dim printreport As New GatePass
            Dim openreportviewer As New ReportViewer
            openreportviewer.CrystalReportViewer.ReportSource = printreport
            printdatatable = printdatasetIthurston
            printreport.SetDataSource(printdatatable)
            openreportviewer.Show()
            printdatatable.Dispose()
            printdatatable = Nothing
            printdatasetIthurston.Clear()
        End If
    End Sub

    Private Async Sub GatePassToolStripMenuItem_Click2(sender As Object, e As EventArgs) Handles GatePassToolStripMenuItem.Click
        If Not IsThurston Then Return

        Await FunctionUtils.TryCatchFunctionAsync(messageTitle:="Print Gate Pass",
                Async Function()
                    Dim saveFileDialogHelperOutPut = SaveFileDialogHelper.BrowseFile(defaultFileName:="gate-pass.xlsx",
                        defaultExtension:="xlsx",
                        filter:="Excel Files|*.xls;*.xlsx;")

                    If saveFileDialogHelperOutPut.IsSuccess = False Then Return

                    File.Copy(sourceFileName:="Report Files\GatePass\GatePass.xlsx",
                        destFileName:=saveFileDialogHelperOutPut.FileInfo.FullName)

                    Dim fileInfo = saveFileDialogHelperOutPut.FileInfo

                    Using package As New ExcelPackage(fileInfo)
                        Dim defaultWorksheet = package.Workbook.
                            Worksheets.
                            OfType(Of ExcelWorksheet).
                            FirstOrDefault(Function(s) s.Name = "Sheet1")
                        If defaultWorksheet Is Nothing Then defaultWorksheet = package.Workbook.Worksheets.Add(Name:="Sheet1")

                        Dim sql = <![CDATA[
                SELECT
                dt.TruckName,
                CONCAT_WS(' ', NULLIF(SUBSTRING_INDEX(SUBSTRING_INDEX(c.FirstName, '(', -1), ')', 1), ''), LEFT(c.LastName, 1)) `Driver`,
                CONCAT_WS(' ', c2.FirstName, LEFT(c2.LastName, 1)) `Helper1`,
                CONCAT_WS(' ', c3.FirstName, LEFT(c3.LastName, 1)) `Helper2`

                FROM lineups lu
                INNER JOIN deliverytruckshifts dts ON dts.RowID=lu.DeliveryTruckShiftID
                INNER JOIN deliverytrucks dt ON dt.RowID=dts.DeliveryTruckID

                INNER JOIN lineupcartons lc ON lu.RowID = lc.LineUpID
                LEFT JOIN contacts c ON lu.ContactID = c.RowID
                LEFT JOIN contacts c2 ON lu.Helper1Id = c2.RowID
                LEFT JOIN contacts c3 ON lu.Helper2Id = c3.RowID
                INNER JOIN orders o ON lu.OrderID = o.RowID
                INNER JOIN accounts a ON a.RowID=o.AccountID
                LEFT JOIN address ad ON ad.RowID=a.PrimaryAddressID
                INNER JOIN packinglistcartonitems plci ON lc.PackingListCartonID = plci.PackingListCartonID
                INNER JOIN orderitems oi ON plci.OrderItemID = oi.RowID
                INNER JOIN productcolorsizes pcs ON oi.ProductColorSizeID = pcs.RowID
                INNER JOIN productcolors pc ON pc.RowID=pcs.ProductColorID
                INNER JOIN products p ON p.RowID=pc.ProductID
                WHERE lu.LineUpNo = @lineupNo
                GROUP BY p.ProductCode;
                ]]>.Value
                        Using connection As New MySqlConnection(connectionString:=manager.GetConnString()),
                                    command As New MySqlCommand(sql, connection)

                            With command.Parameters
                                .AddWithValue("@lineupNo", If(dgLineUpList.CurrentRow?.Cells(lu_lineupno.Name).Value, DBNull.Value))
                            End With

                            Dim adapter = New MySqlDataAdapter()
                            adapter.SelectCommand = command
                            Dim dt As New Data.DataTable
                            Await Task.Run(Sub()
                                               adapter.Fill(dt)
                                           End Sub)

                            Dim row = dt.Rows.OfType(Of DataRow).FirstOrDefault()

                            With defaultWorksheet
                                'Date
                                Dim curdate = Date.Now.ToShortDateString()
                                .Cells("B4").Value = curdate
                                .Cells("B14").Value = curdate
                                .Cells("B24").Value = curdate

                                'Truck#
                                Dim truck = row("TruckName")
                                .Cells("B5").Value = truck
                                .Cells("B15").Value = truck
                                .Cells("B25").Value = truck

                                'Driver
                                Dim driver = row("Driver")
                                .Cells("B6").Value = driver
                                .Cells("B16").Value = driver
                                .Cells("B26").Value = driver

                                'Helper
                                Dim helper1 = row("Helper1")
                                Dim helper2 = row("Helper2")
                                .Cells("B7").Value = helper1
                                .Cells("B8").Value = helper2

                                .Cells("B17").Value = helper1
                                .Cells("B18").Value = helper2

                                .Cells("B27").Value = helper1
                                .Cells("B28").Value = helper2
                            End With

                            package.Save()
                        End Using

                    End Using

                    Process.Start(saveFileDialogHelperOutPut.FileInfo.FullName)
                End Function)
    End Sub

    Private Sub dgLineUpList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineUpList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgLineUpList.Rows.Count <> 0 Then
                errProvider.Clear()
                clearLineUpInformation()
                dgCartons.Rows.Clear()
                displayLineUpInformation(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value))
                displayLineUpCartons(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value))
                globalautocompleteCartonNos(cboCartonNo, veludpackinglistid, Me)
                globalautopopulateCartonNos(cboCartonNo, veludpackinglistid, Me)
                enableGB(legit, legit)
                If txtStatus.Text = "Lined Up" Then
                    enableANDvisibleMS(legit, legit, legit, fraud, fraud)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableANDvisibleMS(fraud, fraud, fraud, fraud, fraud)
                ElseIf txtStatus.Text = "Delivered" Then
                    enableANDvisibleMS(legit, fraud, legit, legit, legit)
                ElseIf txtStatus.Text = "Confirmed Delivery" Then
                    enableANDvisibleMS(fraud, fraud, fraud, legit, fraud)
                End If
                getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                veluddeliverytruckshiftid = globaldeliverytruckshiftid
                veluddeliverytruckid = globaldeliverytruckid
                cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, Format(dtpLineUpDate.Value, "yyyy-MM-dd"))
                dtpLineUpDate.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgLineUpList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgLineUpList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgLineUpList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    errProvider.Clear()
                    clearLineUpInformation()
                    dgCartons.Rows.Clear()
                    displayLineUpInformation(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value))
                    displayLineUpCartons(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value))
                    globalautocompleteCartonNos(cboCartonNo, veludpackinglistid, Me)
                    globalautopopulateCartonNos(cboCartonNo, veludpackinglistid, Me)
                    enableGB(legit, legit)
                    If txtStatus.Text = "Lined Up" Then
                        enableANDvisibleMS(legit, legit, legit, fraud, fraud)
                    ElseIf txtStatus.Text = "Cancelled" Then
                        enableANDvisibleMS(fraud, fraud, fraud, fraud, fraud)
                    ElseIf txtStatus.Text = "Delivered" Then
                        enableANDvisibleMS(legit, fraud, fraud, legit, legit)
                    ElseIf txtStatus.Text = "Confirmed Delivery" Then
                        enableANDvisibleMS(fraud, fraud, fraud, legit, fraud)
                    End If
                    getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                    veluddeliverytruckshiftid = globaldeliverytruckshiftid
                    veluddeliverytruckid = globaldeliverytruckid
                    cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, Format(dtpLineUpDate.Value, "yyyy-MM-dd"))
                    dtpLineUpDate.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dtpLineUpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpLineUpDate.ValueChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If dgLineUpList.Rows.Count <> 0 Then
                If LTrim(cboTruckShiftInfo.Text) <> "" Then
                    getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                    veluddeliverytruckshiftid = globaldeliverytruckshiftid
                    veluddeliverytruckid = globaldeliverytruckid
                    If veluddeliverytruckshiftid <> 0 Then
                        veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                        cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, veludlineupdate)
                        getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
                        veludlineupid = globallineupid
                        If veludlineupid <> 0 Then
                            errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                            errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                        End If
                    Else
                        errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
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

    Private Sub cboTruckShiftInfo_Leave(sender As Object, e As EventArgs) Handles cboTruckShiftInfo.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If dgLineUpList.Rows.Count <> 0 Then
                If LTrim(cboTruckShiftInfo.Text) <> "" Then
                    getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                    veluddeliverytruckshiftid = globaldeliverytruckshiftid
                    veluddeliverytruckid = globaldeliverytruckid
                    If veluddeliverytruckshiftid <> 0 Then
                        veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                        cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, veludlineupdate)
                        getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
                        veludlineupid = globallineupid
                        If veludlineupid <> 0 Then
                            errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                            errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                        End If
                    Else
                        errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
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

    'Private Sub cboTruckShiftInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTruckShiftInfo.SelectedIndexChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If dgLineUpList.Rows.Count <> 0 Then
    '            If LTrim(cboTruckShiftInfo.Text) <> "" Then
    '                getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
    '                veluddeliverytruckshiftid = globaldeliverytruckshiftid
    '                veluddeliverytruckid = globaldeliverytruckid
    '                If veluddeliverytruckshiftid <> 0 Then
    '                    veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
    '                    cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, veludlineupdate)
    '                    getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
    '                    veludlineupid = globallineupid
    '                    If veludlineupid <> 0 Then
    '                        errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
    '                        errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
    '                        errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
    '                    End If
    '                Else
    '                    errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
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
    'Private Sub cboTruckShiftInfo_TextChanged(sender As Object, e As EventArgs) Handles cboTruckShiftInfo.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If dgLineUpList.Rows.Count <> 0 Then
    '            If LTrim(cboTruckShiftInfo.Text) <> "" Then
    '                getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
    '                veluddeliverytruckshiftid = globaldeliverytruckshiftid
    '                veluddeliverytruckid = globaldeliverytruckid
    '                If veluddeliverytruckshiftid <> 0 Then
    '                    veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
    '                    cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, veludlineupdate)
    '                    getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
    '                    veludlineupid = globallineupid
    '                    If veludlineupid <> 0 Then
    '                        errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
    '                        errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
    '                        errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
    '                    End If
    '                Else
    '                    errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
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
    Private Sub dgCartons_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCartons.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCartons.Rows.Count <> 0 Then
                If e.ColumnIndex = dgCartons.Columns("ca_cartonno").Index Then
                    Dim viewcartonitemslinkform As New ViewCartonItemsForm
                    viewcartonitemslinkform.vcicartonid = CInt(dgCartons.CurrentRow.Cells("ca_packinglistcartonid").Value)
                    viewcartonitemslinkform.ShowInTaskbar = False
                    viewcartonitemslinkform.ShowDialog()
                ElseIf e.ColumnIndex = dgCartons.Columns("ca_option").Index Then
                    getPositionID(Me)
                    If globalpositionid <> 0 Then
                        getPositionView(globalpositionid, "Line-Up And Delivery", Me)
                        If globaldisableflg = "Y" Then
                            MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    If dgLineUpList.Rows.Count <> 0 Then
                        getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                        If globallineupstatus <> "Lined Up" Then
                            If globallineupstatus <> "Delivered" Then
                                MessageBox.Show("The line up has been confirmed or cancelled already.", "Removing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                    Else
                        MessageBox.Show("System cannot find the line up.", "Removing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    getLineUpCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Me)
                    veludlineupcartonstatus = globallineupcartonstatus
                    If veludlineupcartonstatus <> "Lined Up" Then
                        MessageBox.Show("The box has been updated, click the line-up again to check the status.", "Removing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If MessageBox.Show("Would you like to remove this box from this line up?", "Removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgLineUpList.Rows.Count <> 0 Then
                            getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                            If globallineupstatus <> "Lined Up" Then
                                If globallineupstatus <> "Delivered" Then
                                    MessageBox.Show("The line up has been confirmed or cancelled already.", "Removing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                            End If
                        Else
                            MessageBox.Show("System cannot find the line up.", "Removing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        getLineUpCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Me)
                        veludlineupcartonstatus = globallineupcartonstatus
                        If veludlineupcartonstatus <> "Lined Up" Then
                            MessageBox.Show("The carton has been updated, click the line-up again to check the status.", "Removing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        U_LineUpCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                        If myModule.systemerrorfound = False Then
                            U_PackingListCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_packinglistcartonid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Active", Me)
                        End If
                        If myModule.systemerrorfound = False Then
                            updatePackingListCartonItemsB(CInt(dgCartons.CurrentRow.Cells("ca_packinglistcartonid").Value))
                        End If
                        If myModule.systemerrorfound = False Then
                            If dgCartons.SelectedRows.Count > 0 Then
                                dgCartons.Rows.Remove(dgCartons.SelectedRows(0))
                            End If
                            myBalloon("Successfully Removed", "Remove", lblsavemsg, -15, -65)
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

    Private Sub cboCartonNo_Leave(sender As Object, e As EventArgs) Handles cboCartonNo.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboCartonNo.Text) <> "" Then
                getPackingListCartonIDA(veludpackinglistid, cboCartonNo.Text, "AND `status` = 'Active'", Me)
                veludpackinglistcartonid = globalpackinglistcartonid
                If veludpackinglistcartonid = 0 Then
                    txtBoxCBM.Text = ""
                    txtSizeName.Text = ""
                    errProvider.SetError(cboCartonNo, "The box is not available any longer.")
                    Exit Try
                Else
                    getPackingListCartonInfo(veludpackinglistcartonid, Me)
                    txtBoxCBM.Text = globalcbm
                    txtSizeName.Text = globalboxsizename
                End If
            Else
                txtBoxCBM.Text = ""
                txtSizeName.Text = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub cboCartonNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCartonNo.SelectedIndexChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If LTrim(cboCartonNo.Text) <> "" Then
    '            getPackingListCartonIDA(veludpackinglistid, cboCartonNo.Text, "AND `status` = 'Active'", Me)
    '            veludpackinglistcartonid = globalpackinglistcartonid
    '            If veludpackinglistcartonid = 0 Then
    '                txtBoxCBM.Text = ""
    '                txtSizeName.Text = ""
    '                errProvider.SetError(cboCartonNo, "The box is not available any longer.")
    '                Exit Try
    '            Else
    '                getPackingListCartonInfo(veludpackinglistcartonid, Me)
    '                txtBoxCBM.Text = globalcbm
    '                txtSizeName.Text = globalboxsizename
    '            End If
    '        Else
    '            txtBoxCBM.Text = ""
    '            txtSizeName.Text = ""
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    'Private Sub cboCartonNo_TextChanged(sender As Object, e As EventArgs) Handles cboCartonNo.TextChanged
    '    Try
    '        errProvider.Clear()
    '        If LTrim(cboCartonNo.Text) <> "" Then
    '            getPackingListCartonIDA(veludpackinglistid, cboCartonNo.Text, "AND `status` = 'Active'", Me)
    '            veludpackinglistcartonid = globalpackinglistcartonid
    '            If veludpackinglistcartonid = 0 Then
    '                txtBoxCBM.Text = ""
    '                txtSizeName.Text = ""
    '                errProvider.SetError(cboCartonNo, "The box is not available any longer.")
    '                Exit Try
    '            Else
    '                getPackingListCartonInfo(veludpackinglistcartonid, Me)
    '                txtBoxCBM.Text = globalcbm
    '                txtSizeName.Text = globalboxsizename
    '            End If
    '        Else
    '            txtBoxCBM.Text = ""
    '            txtSizeName.Text = ""
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    Private Sub btnAddCarton_Click(sender As Object, e As EventArgs) Handles btnAddCarton.Click
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

    Private Sub cboCartonNo_KeyDown(sender As Object, e As KeyEventArgs) Handles cboCartonNo.KeyDown
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
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            If dgLineUpList.Rows.Count <> 0 Then
                getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                If globallineupstatus <> "Lined Up" Then
                    If globallineupstatus <> "Delivered" Then
                        errProvider.SetError(txtStatus, "The line up has been confirmed or cancelled already.")
                        Exit Try
                    End If
                End If
            Else
                errProvider.SetError(txtLineUpNo, "System cannot find the line up.")
                Exit Try
            End If
            If LTrim(cboTruckShiftInfo.Text) <> "" Then
                getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                veluddeliverytruckshiftid = globaldeliverytruckshiftid
                veluddeliverytruckid = globaldeliverytruckid
                cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, Format(dtpLineUpDate.Value, "yyyy-MM-dd"))
                If veluddeliverytruckshiftid <> 0 Then
                    veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                    getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
                    veludlineupid = globallineupid
                    If veludlineupid <> 0 Then
                        errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                        errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                        errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track and shift info.")
                    Exit Try
                End If
            Else
                errProvider.SetError(pbAddTruckShiftInfo, "Please choose the track and shift info.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If dgLineUpList.Rows.Count <> 0 Then
                    getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                    If globallineupstatus <> "Lined Up" Then
                        If globallineupstatus <> "Delivered" Then
                            errProvider.SetError(txtStatus, "The line up has been confirmed or cancelled already.")
                            Exit Try
                        End If
                    End If
                Else
                    errProvider.SetError(txtLineUpNo, "System cannot find the line up.")
                    Exit Try
                End If
                If LTrim(cboTruckShiftInfo.Text) <> "" Then
                    getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                    veluddeliverytruckshiftid = globaldeliverytruckshiftid
                    veluddeliverytruckid = globaldeliverytruckid
                    cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, Format(dtpLineUpDate.Value, "yyyy-MM-dd"))
                    If veluddeliverytruckshiftid <> 0 Then
                        veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                        getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
                        veludlineupid = globallineupid
                        If veludlineupid <> 0 Then
                            errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                            errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track and shift info.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddTruckShiftInfo, "Please choose the track and shift info.")
                    Exit Try
                End If
                getContactID(cboDriverName.Text, "Driver", Me)
                veludcontactid = globalcontactid
                U_LineUps(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(veludcontactid = 0, DBNull.Value, veludcontactid), veluddeliverytruckshiftid, dtpLineUpDate.Value, txtSIDRNo.Text, txtComments.Text, Me,
                    AgentId:=cboAgent.SelectedValue,
                    Helper1Id:=cboHelper1.SelectedValue,
                    Helper2Id:=cboHelper2.SelectedValue)
                If myModule.systemerrorfound = False Then
                    myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                    vieweditlineupdeliverycue = legit
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msToDeliver_Click(sender As Object, e As EventArgs) Handles msToDeliver.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalcreateflg = "N" Or globalupdateflg = "N" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgLineUpList.Rows.Count <> 0 Then
                getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                If globallineupstatus <> "Lined Up" Then
                    If globallineupstatus <> "Delivered" Then
                        errProvider.SetError(txtStatus, "The line up has been confirmed or cancelled already.")
                        Exit Try
                    End If
                End If
            Else
                errProvider.SetError(txtLineUpNo, "System cannot find the line up.")
                Exit Try
            End If
            If LTrim(cboTruckShiftInfo.Text) <> "" Then
                getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                veluddeliverytruckshiftid = globaldeliverytruckshiftid
                veluddeliverytruckid = globaldeliverytruckid
                cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, Format(dtpLineUpDate.Value, "yyyy-MM-dd"))
                If veluddeliverytruckshiftid <> 0 Then
                    veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                    getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
                    veludlineupid = globallineupid
                    If veludlineupid <> 0 Then
                        errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                        errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                        errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track and shift info.")
                    Exit Try
                End If
            Else
                errProvider.SetError(pbAddTruckShiftInfo, "Please choose the track and shift info.")
                Exit Try
            End If
            If LTrim(txtSIDRNo.Text) = "" Then
                errProvider.SetError(txtSIDRNo, "Please enter the S.I./D.R. No.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to deliver this line-up?", "Delivering", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If dgLineUpList.Rows.Count <> 0 Then
                    getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                    If globallineupstatus <> "Lined Up" Then
                        If globallineupstatus <> "Delivered" Then
                            errProvider.SetError(txtStatus, "The line up has been confirmed or cancelled already.")
                            Exit Try
                        End If
                    End If
                Else
                    errProvider.SetError(txtLineUpNo, "System cannot find the line up.")
                    Exit Try
                End If
                If LTrim(cboTruckShiftInfo.Text) <> "" Then
                    getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                    veluddeliverytruckshiftid = globaldeliverytruckshiftid
                    veluddeliverytruckid = globaldeliverytruckid
                    cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, Format(dtpLineUpDate.Value, "yyyy-MM-dd"))
                    If veluddeliverytruckshiftid <> 0 Then
                        veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                        getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
                        veludlineupid = globallineupid
                        If veludlineupid <> 0 Then
                            errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                            errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track and shift info.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddTruckShiftInfo, "Please choose the track and shift info.")
                    Exit Try
                End If
                getContactID(cboDriverName.Text, "Driver", Me)
                veludcontactid = globalcontactid
                U_LineUps(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(veludcontactid = 0, DBNull.Value, veludcontactid), veluddeliverytruckshiftid, dtpLineUpDate.Value, txtSIDRNo.Text, txtComments.Text, Me,
                    AgentId:=cboAgent.SelectedValue,
                    Helper1Id:=cboHelper1.SelectedValue,
                    Helper2Id:=cboHelper2.SelectedValue)
                U_LineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Delivered", Me)
                If myModule.systemerrorfound = False Then
                    myBalloon("Successfully Delivered", "Deliver", lblsavemsg, -15, -65)
                    vieweditlineupdeliverycue = legit
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

    Private Async Sub CancelLineUp_Click(sender As Object, e As EventArgs) Handles msOrder.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalcreateflg = "N" Or globalupdateflg = "N" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgLineUpList.Rows.Count <> 0 Then
                getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                If globallineupstatus <> "Lined Up" Then
                    If globallineupstatus <> "Delivered" Then
                        errProvider.SetError(txtStatus, "The line up has been confirmed or cancelled already.")
                        Exit Try
                    End If
                End If
            Else
                errProvider.SetError(txtLineUpNo, "System cannot find the line up.")
                Exit Try
            End If
            If MessageBox.Show("NOTE: Once you cancelled this line-up, you cannot open this line-up again." & vbNewLine & "" & vbNewLine & "Do you want to proceed cancelling this line-up?", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                cancelLineUpCartons(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value))
                If myModule.systemerrorfound = False Then
                    U_OrderStatus(veludorderid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Packing", Me)
                End If
                If myModule.systemerrorfound = False Then
                    Await FunctionUtils.TryCatchFunctionAsync(messageTitle:=String.Empty,
                        Async Function()
                            Dim lineupId = CInt(dgLineUpList.CurrentRow.Cells(lu_rowid.Name).Value)

                            Dim lineupDataService = GetRequiredService(Of ILineupDataService)()

                            Await lineupDataService.CancelDeliveryAsync(
                                lineupId:=lineupId,
                                userId:=Z_UserID)

                        End Function).
                        ContinueWith(Sub()
                                         'U_LineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)

                                         If myModule.systemerrorfound = False Then
                                             myBalloon("Successfully Cancelled", "Cancel", lblsavemsg, -15, -65)
                                             vieweditlineupdeliverycue = legit
                                             tsrefreshperformclick()
                                         End If
                                     End Sub, scheduler:=TaskScheduler.FromCurrentSynchronizationContext)
                End If

            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msConfirm_Click(sender As Object, e As EventArgs) Handles msConfirm.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalcreateflg = "N" Or globalupdateflg = "N" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgLineUpList.Rows.Count <> 0 Then
                getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                If globallineupstatus <> "Lined Up" Then
                    If globallineupstatus <> "Delivered" Then
                        errProvider.SetError(txtStatus, "The line up has been confirmed or cancelled already.")
                        Exit Try
                    End If
                End If
            Else
                errProvider.SetError(txtLineUpNo, "System cannot find the line up.")
                Exit Try
            End If
            If Not IsThurston Then
                getOrderStatus(veludorderid, Me)
                If globalorderstatus <> "Lined Up" Then
                    errProvider.SetError(txtCustomerOrderInfo, "The customer order has been updated, please check the status of the customer order.")
                    Exit Try
                End If
            End If
            If LTrim(cboTruckShiftInfo.Text) <> "" Then
                getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                veluddeliverytruckshiftid = globaldeliverytruckshiftid
                veluddeliverytruckid = globaldeliverytruckid
                cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, Format(dtpLineUpDate.Value, "yyyy-MM-dd"))
                If veluddeliverytruckshiftid <> 0 Then
                    veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                    getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
                    veludlineupid = globallineupid
                    If veludlineupid <> 0 Then
                        errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                        errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                        errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track and shift info.")
                    Exit Try
                End If
            Else
                errProvider.SetError(pbAddTruckShiftInfo, "Please choose the track and shift info.")
                Exit Try
            End If
            If LTrim(txtSIDRNo.Text) = "" Then
                errProvider.SetError(txtSIDRNo, "Please enter the S.I./D.R. No.")
                Exit Try
            End If

            Dim form = New DeliveryTimestampTrackingForm(lineupId:=CInt(dgLineUpList.CurrentRow.Cells(lu_rowid.Name).Value))
            If Not form.ShowDialog() = DialogResult.OK Then
                Me.Cursor = Cursors.Default
                Return
            End If

            Me.Cursor = Cursors.WaitCursor
            PrimaryForm.MainLoadingBar.Visible = legit
            PrimaryForm.MainLoadingBar.Maximum = vplloadingbar
            If dgLineUpList.Rows.Count <> 0 Then
                getLineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Me)
                If globallineupstatus <> "Lined Up" Then
                    If globallineupstatus <> "Delivered" Then
                        errProvider.SetError(txtStatus, "The line up has been confirmed or cancelled already.")
                        Exit Try
                    End If
                End If
            Else
                errProvider.SetError(txtLineUpNo, "System cannot find the line up.")
                Exit Try
            End If
            If Not IsThurston Then
                getOrderStatus(veludorderid, Me)
                If globalorderstatus <> "Lined Up" Then
                    errProvider.SetError(txtCustomerOrderInfo, "The customer order has been updated, please check the status of the customer order.")
                    Exit Try
                End If
            End If
            If LTrim(cboTruckShiftInfo.Text) <> "" Then
                getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                veluddeliverytruckshiftid = globaldeliverytruckshiftid
                veluddeliverytruckid = globaldeliverytruckid
                cbmcomputation(veluddeliverytruckid, veluddeliverytruckshiftid, Format(dtpLineUpDate.Value, "yyyy-MM-dd"))
                If veluddeliverytruckshiftid <> 0 Then
                    veludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                    getLineUpIDC(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), veluddeliverytruckshiftid, veludorderid, veludlineupdate, Me)
                    veludlineupid = globallineupid
                    If veludlineupid <> 0 Then
                        errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                        errProvider.SetError(txtCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                        errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track and shift info.")
                    Exit Try
                End If
            Else
                errProvider.SetError(pbAddTruckShiftInfo, "Please choose the track and shift info.")
                Exit Try
            End If
            getContactID(cboDriverName.Text, "Driver", Me)
            veludcontactid = globalcontactid
            U_LineUps(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(veludcontactid = 0, DBNull.Value, veludcontactid), veluddeliverytruckshiftid, dtpLineUpDate.Value, txtSIDRNo.Text, txtComments.Text, Me,
        AgentId:=cboAgent.SelectedValue,
        Helper1Id:=cboHelper1.SelectedValue,
        Helper2Id:=cboHelper2.SelectedValue)
            If PrimaryForm.MainLoadingBar.Value < vplloadingbar Then
                PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
            End If
            If myModule.systemerrorfound = False Then
                confirmLineUpCartons(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value))
            End If
            If PrimaryForm.MainLoadingBar.Value < vplloadingbar Then
                PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
            End If
            If myModule.systemerrorfound = False Then
                U_OrderStatus(veludorderid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Delivery", Me)
            End If
            If PrimaryForm.MainLoadingBar.Value < vplloadingbar Then
                PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
            End If
            If myModule.systemerrorfound = False Then
                U_LineUpStatus(CInt(dgLineUpList.CurrentRow.Cells("lu_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Confirmed Delivery", Me)
            End If
            If PrimaryForm.MainLoadingBar.Value < vplloadingbar Then
                PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
            End If
            If myModule.systemerrorfound = False Then
                myBalloon("Successfully Confirmed", "Confirm Delivery", lblsavemsg, -15, -65)
                vieweditlineupdeliverycue = legit
                tsrefreshperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            PrimaryForm.MainLoadingBar.Visible = fraud
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
            ElseIf cboSearch1.Text = "CustomerOrderNo" Then
                autocompleteCustomerOrderNo(cboSearch2)
                autopopulateCustomerOrderNo(cboSearch2)
            ElseIf cboSearch1.Text = "S.I./D.R. No." Then
                autocompleteDeliveryNo(cboSearch2)
                autopopulateDeliveryNo(cboSearch2)
            ElseIf cboSearch1.Text = "DriverName" Then
                autocompleteDriverName(cboSearch2)
                autopopulateDriverName(cboSearch2)
            ElseIf cboSearch1.Text = "LineUpNo" Then
                autocompleteLineUpNo(cboSearch2)
                autopopulateLineUpNo(cboSearch2)
            ElseIf cboSearch1.Text = "Status" Then
                autocompleteStatus(cboSearch2)
                autopopulateStatus(cboSearch2)
            ElseIf cboSearch1.Text = "TruckShiftInfo" Then
                autocompleteTruckShiftInfo(cboSearch2)
                autopopulateTruckShiftInfo(cboSearch2)
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
            ElseIf cboSearch3.Text = "CustomerOrderNo" Then
                autocompleteCustomerOrderNo(cboSearch4)
                autopopulateCustomerOrderNo(cboSearch4)
            ElseIf cboSearch3.Text = "S.I./D.R. No." Then
                autocompleteDeliveryNo(cboSearch4)
                autopopulateDeliveryNo(cboSearch4)
            ElseIf cboSearch3.Text = "DriverName" Then
                autocompleteDriverName(cboSearch4)
                autopopulateDriverName(cboSearch4)
            ElseIf cboSearch3.Text = "LineUpNo" Then
                autocompleteLineUpNo(cboSearch4)
                autopopulateLineUpNo(cboSearch4)
            ElseIf cboSearch3.Text = "Status" Then
                autocompleteStatus(cboSearch4)
                autopopulateStatus(cboSearch4)
            ElseIf cboSearch3.Text = "TruckShiftInfo" Then
                autocompleteTruckShiftInfo(cboSearch4)
                autopopulateTruckShiftInfo(cboSearch4)
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
                        If cboDate.Text = "ConfirmedDate" Then
                            datephrase = "lu.deliverydate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        ElseIf cboDate.Text = "DeliveryDate" Then
                            datephrase = "lu.lineupdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        End If
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                    ElseIf cboDate.Text <> "" And cboSearch2.Text = "" And cboSearch4.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "ConfirmedDate" Then
                            datephrase = "lu.deliverydate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        ElseIf cboDate.Text = "DeliveryDate" Then
                            datephrase = "lu.lineupdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
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
                        If cboDate.Text = "ConfirmedDate" Then
                            pagefilter4 = " AND (lu.deliverydate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "lu.deliverydate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        ElseIf cboDate.Text = "DeliveryDate" Then
                            pagefilter4 = " AND (lu.lineupdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "lu.lineupdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
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
                        If cboDate.Text = "ConfirmedDate" Then
                            datephrase = "lu.deliverydate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        ElseIf cboDate.Text = "DeliveryDate" Then
                            datephrase = "lu.lineupdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        End If
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                    ElseIf cboDate.Text <> "" And cboSearch2.Text = "" And cboSearch4.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "ConfirmedDate" Then
                            datephrase = "lu.deliverydate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        ElseIf cboDate.Text = "DeliveryDate" Then
                            datephrase = "lu.lineupdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
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
                        If cboDate.Text = "ConfirmedDate" Then
                            pagefilter4 = " AND (lu.deliverydate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "lu.deliverydate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        ElseIf cboDate.Text = "DeliveryDate" Then
                            pagefilter4 = " AND (lu.lineupdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "lu.lineupdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
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
                displayLineUpList(spagenum)
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
                displayLineUpList(spagenum)
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
                displayLineUpList(spagenum)
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
                displayLineUpList(spagenum)
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
                            displayLineUpList(spagenum)
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

    Private Sub dgCartons_MouseUp(sender As Object, e As MouseEventArgs) Handles dgCartons.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgCartons.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgCartons.BeginEdit(True)
                Else
                    dgCartons.EndEdit()
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

    Private Sub dgLineUp_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgLineUpList.DataError
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
                dgLineUpList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartons_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCartons.DataError
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
                dgCartons.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

    Private Async Sub btnAddAgent_Click(sender As Object, e As EventArgs) Handles btnAddAgent.Click
        Dim form As New AddContactForm(contactType:=ContactType.Agent, True)
        If form.ShowDialog() = DialogResult.OK Then
            Await GetAgentsAsync()
        End If
    End Sub

    Private Async Sub btnAddHelper1_Click(sender As Object, e As EventArgs) Handles btnAddHelper1.Click
        Dim form As New AddContactForm(contactType:=ContactType.Helper, True)
        If form.ShowDialog() = DialogResult.OK Then
            Await GetHelpersAsync()
        End If
    End Sub

    Private Async Sub btnAddHelper2_Click(sender As Object, e As EventArgs) Handles btnAddHelper2.Click
        Dim form As New AddContactForm(contactType:=ContactType.Helper, True)
        If form.ShowDialog() = DialogResult.OK Then
            Await GetHelpersAsync()
        End If
    End Sub

    Private ReadOnly Property IsThurston As Boolean
        Get
            Return _systemOwner.IsThurston
        End Get
    End Property

    Public Shadows Function ShowDialog() As DialogResult
        _IsShowDialog = True

        Return MyBase.ShowDialog()
    End Function

End Class