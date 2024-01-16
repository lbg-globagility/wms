Imports System.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports MySql.Data.MySqlClient
Imports OfficeOpenXml
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Interfaces.Repositories

Public Class PrimaryForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim second As Integer = 1
    Public PrdForm As Boolean = False
    Public ILForm As Boolean = False
    Public AccntsForm As Boolean = False
    Public CntctsForm As Boolean = False
    Public RfrncForm As Boolean = False
    Public BndlsForm As Boolean = False
    Public COForm As Boolean = False
    Public PLForm As Boolean = False
    Public VPLForm As Boolean = False
    Public PaLForm As Boolean = False
    Public LnUpDlvryForm As Boolean = False
    Public OrgForm As Boolean = False
    Public UsrForm As Boolean = False
    Public AbtForm As Boolean = False
    Public SysIllForm As Boolean = False
    Public PosViewForm As Boolean = False
    Public POForm As Boolean = False
    Public SuppForm As Boolean = False
    Public RRForm As Boolean = False
    Public POutForm As Boolean = False
    Public RetForm As Boolean = False
    Public SAdjForm As Boolean = False
    Public STransForm As Boolean = False
    Public CCountForm As Boolean = False
    Public BrkSzsForm As Boolean = False
    Public SllThrhForm As Boolean = False
    Public AgngForm As Boolean = False
    Public SlsQtyForm As Boolean = False
    Public DlvryPrfmForm As Boolean = False
    Public StkLvlForm As Boolean = False
    Public PckLstRForm As Boolean = False
    Private _systemOwner As SystemOwner

    Private Async Sub PrimaryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        Me.Cursor = Cursors.WaitCursor
        Try
            Me.Text = "Warehouse Management System"
            tsOrgValue.Text = Z_CompanyName
            tsUserValue.Text = Z_UserName
            tsDateValue.Text = Today.Date.ToString("dd-MMM-yyyy")
            tsTimeValue.Text = TimeOfDay
            MainLoadingBar.Visible = fraud
            Timer1.Enabled = True
            displayNewCustomerOrders()
            displayForApprovalReceiving()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default

        Dim appSettings = ConfigurationManager.AppSettings
        ToolStripLabelVersion.Text = $"v{appSettings.Get("system.version")}"
    End Sub

    Private Sub PrimaryForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            If second = 0 Then
                e.Cancel = False
                LoginForm.txtUsername.Text = ""
                LoginForm.txtPassword.Text = ""
                LoginForm.cboOrganization.SelectedItem = Nothing
                LoginForm.Show()
            Else
                If MessageBox.Show("Are you sure you want to logout? ", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                    Timer2.Enabled = True
                    MessageBox.Show("Please wait while the system is closing . . .", "Closing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Functions"

#Region "Display"

#Region "ChangeForm"

    Public Sub ChangeDisplayForm(ByVal Formname As Form, ByVal Ima As Image, ByVal tstext As String, ByVal tstooltiptext As String)
        Try
            Application.DoEvents()
            Dim NewToolStripButton As New ToolStripButton
            Dim FName As String = Formname.Name
            Formname.Icon = Icon
            Dim Duplicate As Boolean = False
            If Not Duplicate And Not FName = LoginForm.Name Then
                NewToolStripButton.Image = Ima
                NewToolStripButton.Text = Mid(tstext, 1, 5)
                NewToolStripButton.ToolTipText = tstooltiptext
                NewToolStripButton.Font = New Font("Segoe UI", 8, FontStyle.Bold)
                NewToolStripButton.TextAlign = ContentAlignment.BottomCenter
                NewToolStripButton.TextDirection = ToolStripTextDirection.Inherit
                NewToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                NewToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText
                AddHandler Formname.FormClosed, AddressOf NewToolStripButton.Dispose
                AddHandler NewToolStripButton.Click, AddressOf Formname.BringToFront
                AddHandler NewToolStripButton.Click, AddressOf Formname.Focus
                tsTaskBar.Items.Add(NewToolStripButton)
                If Formname.WindowState = FormWindowState.Maximized Then
                    Formname.WindowState = FormWindowState.Normal
                End If
                Formname.TopLevel = False
                Panel1.Controls.Add(Formname)
                Formname.Show()
                Formname.Dock = DockStyle.Fill
            End If
            Formname.BringToFront()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

#End Region

#Region "Datagrids"

    Sub displayNewCustomerOrders()
        Try
            dgNewCO.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),COALESCE(co.referencenumber,''),COALESCE(DATE_FORMAT(co.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(co.targetdate,'%d-%b-%Y'),'')," &
                        "COALESCE(DATE_FORMAT(co.enddate,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.lastname,''),' - ',COALESCE(cb.rowid,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),''),COALESCE(CONCAT(COALESCE(ve.companycode,''),' - ',COALESCE(ve.companyname,'')),''),COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'') " &
                        "FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid LEFT JOIN users cb ON co.createdby = cb.rowid LEFT JOIN branches bc ON co.branchid = bc.rowid LEFT JOIN companies ve ON co.companyid = ve.rowid LEFT JOIN combinecodings cc ON co.combinecodingid = cc.rowid " &
                        "LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'New' ORDER BY co.ordernumber DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgNewCO.Rows.Add()
                    dgNewCO.Item(nw_seqno.Index, n).Value = seqno
                    dgNewCO.Item(nw_rowid.Index, n).Value = reader1(0)
                    dgNewCO.Item(nw_cono.Index, n).Value = reader1(1)
                    dgNewCO.Item(nw_pono.Index, n).Value = reader1(2)
                    dgNewCO.Item(nw_codate.Index, n).Value = reader1(3)
                    dgNewCO.Item(nw_receiptdate.Index, n).Value = reader1(4)
                    dgNewCO.Item(nw_canceldate.Index, n).Value = reader1(5)
                    dgNewCO.Item(nw_customername.Index, n).Value = reader1(6)
                    dgNewCO.Item(nw_createdby.Index, n).Value = reader1(7)
                    dgNewCO.Item(nw_branchinfo.Index, n).Value = reader1(8)
                    dgNewCO.Item(nw_vendorinfo.Index, n).Value = reader1(9)
                    dgNewCO.Item(nw_classdescription.Index, n).Value = reader1(10)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgNewCO.Columns("nw_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgNewCO.Columns("nw_cono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgNewCO.Columns("nw_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgNewCO.Columns("nw_codate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgNewCO.Columns("nw_receiptdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgNewCO.Columns("nw_canceldate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabCustomerOrders.SelectedTab Is tabNewCO Then
                If dgNewCO.Rows.Count <> 0 Then
                    dgNewCO.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySubmittedToWarehouseCustomerOrders()
        Try
            dgSubmittedToWarehouseCO.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),COALESCE(co.referencenumber,''),COALESCE(DATE_FORMAT(co.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(co.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(co.enddate,'%d-%b-%Y'),'')," &
                        "COALESCE(DATE_FORMAT(co.datesubmitted,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.lastname,''),' - ',COALESCE(cb.rowid,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),''),COALESCE(CONCAT(COALESCE(ve.companycode,''),' - ',COALESCE(ve.companyname,'')),''),COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'') " &
                        "FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid LEFT JOIN users cb ON co.createdby = cb.rowid LEFT JOIN branches bc ON co.branchid = bc.rowid LEFT JOIN companies ve ON co.companyid = ve.rowid LEFT JOIN combinecodings cc ON co.combinecodingid = cc.rowid " &
                        "LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'Submitted To Warehouse' ORDER BY co.ordernumber DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgSubmittedToWarehouseCO.Rows.Add()
                    dgSubmittedToWarehouseCO.Item(stw_seqno.Index, n).Value = seqno
                    dgSubmittedToWarehouseCO.Item(stw_rowid.Index, n).Value = reader1(0)
                    dgSubmittedToWarehouseCO.Item(stw_cono.Index, n).Value = reader1(1)
                    dgSubmittedToWarehouseCO.Item(stw_pono.Index, n).Value = reader1(2)
                    dgSubmittedToWarehouseCO.Item(stw_codate.Index, n).Value = reader1(3)
                    dgSubmittedToWarehouseCO.Item(stw_receiptdate.Index, n).Value = reader1(4)
                    dgSubmittedToWarehouseCO.Item(stw_canceldate.Index, n).Value = reader1(5)
                    dgSubmittedToWarehouseCO.Item(stw_datesubmitted.Index, n).Value = reader1(6)
                    dgSubmittedToWarehouseCO.Item(stw_customername.Index, n).Value = reader1(7)
                    dgSubmittedToWarehouseCO.Item(stw_createdby.Index, n).Value = reader1(8)
                    dgSubmittedToWarehouseCO.Item(stw_branchinfo.Index, n).Value = reader1(9)
                    dgSubmittedToWarehouseCO.Item(stw_vendorinfo.Index, n).Value = reader1(10)
                    dgSubmittedToWarehouseCO.Item(stw_classdescription.Index, n).Value = reader1(11)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgSubmittedToWarehouseCO.Columns("stw_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSubmittedToWarehouseCO.Columns("stw_cono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSubmittedToWarehouseCO.Columns("stw_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSubmittedToWarehouseCO.Columns("stw_codate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSubmittedToWarehouseCO.Columns("stw_receiptdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSubmittedToWarehouseCO.Columns("stw_canceldate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSubmittedToWarehouseCO.Columns("stw_datesubmitted").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabCustomerOrders.SelectedTab Is tabSubmittedToWarehouseCO Then
                If dgSubmittedToWarehouseCO.Rows.Count <> 0 Then
                    dgSubmittedToWarehouseCO.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayPickListedCustomerOrders()
        Try
            dgPickListedCO.Rows.Clear()
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),COALESCE(co.referencenumber,''),COALESCE(DATE_FORMAT(co.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(co.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(co.enddate,'%d-%b-%Y'),'')," &
                        "COALESCE(DATE_FORMAT(co.datesubmitted,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.lastname,''),' - ',COALESCE(cb.rowid,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),''),COALESCE(CONCAT(COALESCE(ve.companycode,''),' - ',COALESCE(ve.companyname,'')),''),COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'') " &
                        "FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid LEFT JOIN users cb ON co.createdby = cb.rowid LEFT JOIN branches bc ON co.branchid = bc.rowid LEFT JOIN companies ve ON co.companyid = ve.rowid LEFT JOIN combinecodings cc ON co.combinecodingid = cc.rowid " &
                        "LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'Pick Listed' ORDER BY co.ordernumber DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgPickListedCO.Rows.Add()
                    dgPickListedCO.Item(pl_seqno.Index, n).Value = seqno
                    dgPickListedCO.Item(pl_rowid.Index, n).Value = reader1(0)
                    getPickListNoB(CInt(reader1(0)), Me)
                    dgPickListedCO.Item(pl_plno.Index, n).Value = globalpicklistno
                    dgPickListedCO.Item(pl_cono.Index, n).Value = reader1(1)
                    dgPickListedCO.Item(pl_pono.Index, n).Value = reader1(2)
                    dgPickListedCO.Item(pl_codate.Index, n).Value = reader1(3)
                    dgPickListedCO.Item(pl_receiptdate.Index, n).Value = reader1(4)
                    dgPickListedCO.Item(pl_canceldate.Index, n).Value = reader1(5)
                    dgPickListedCO.Item(pl_datesubmitted.Index, n).Value = reader1(6)
                    dgPickListedCO.Item(pl_customername.Index, n).Value = reader1(7)
                    dgPickListedCO.Item(pl_createdby.Index, n).Value = reader1(8)
                    dgPickListedCO.Item(pl_branchinfo.Index, n).Value = reader1(9)
                    dgPickListedCO.Item(pl_vendorinfo.Index, n).Value = reader1(10)
                    dgPickListedCO.Item(pl_classdescription.Index, n).Value = reader1(11)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPickListedCO.Columns("pl_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListedCO.Columns("pl_plno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListedCO.Columns("pl_cono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListedCO.Columns("pl_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListedCO.Columns("pl_codate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListedCO.Columns("pl_receiptdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListedCO.Columns("pl_canceldate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListedCO.Columns("pl_datesubmitted").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabCustomerOrders.SelectedTab Is tabPickListedCO Then
                If dgPickListedCO.Rows.Count <> 0 Then
                    dgPickListedCO.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayForPackingCustomerOrders()
        Try
            dgForPackingCO.Rows.Clear()
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),COALESCE(co.referencenumber,''),COALESCE(DATE_FORMAT(co.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(co.targetdate,'%d-%b-%Y'),'')," &
                        "COALESCE(DATE_FORMAT(co.enddate,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.lastname,''),' - ',COALESCE(cb.rowid,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),''),COALESCE(CONCAT(COALESCE(ve.companycode,''),' - ',COALESCE(ve.companyname,'')),''),COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'') " &
                        "FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid LEFT JOIN users cb ON co.createdby = cb.rowid LEFT JOIN branches bc ON co.branchid = bc.rowid LEFT JOIN companies ve ON co.companyid = ve.rowid LEFT JOIN combinecodings cc ON co.combinecodingid = cc.rowid " &
                        "LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'For Packing' ORDER BY co.ordernumber DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgForPackingCO.Rows.Add()
                    dgForPackingCO.Item(fp_seqno.Index, n).Value = seqno
                    dgForPackingCO.Item(fp_rowid.Index, n).Value = reader1(0)
                    getPickListNoB(CInt(reader1(0)), Me)
                    dgForPackingCO.Item(fp_plno.Index, n).Value = globalpicklistno
                    dgForPackingCO.Item(fp_cono.Index, n).Value = reader1(1)
                    dgForPackingCO.Item(fp_pono.Index, n).Value = reader1(2)
                    dgForPackingCO.Item(fp_codate.Index, n).Value = reader1(3)
                    dgForPackingCO.Item(fp_receiptdate.Index, n).Value = reader1(4)
                    dgForPackingCO.Item(fp_canceldate.Index, n).Value = reader1(5)
                    dgForPackingCO.Item(fp_customername.Index, n).Value = reader1(6)
                    dgForPackingCO.Item(fp_createdby.Index, n).Value = reader1(7)
                    dgForPackingCO.Item(fp_branchinfo.Index, n).Value = reader1(8)
                    dgForPackingCO.Item(fp_vendorinfo.Index, n).Value = reader1(9)
                    dgForPackingCO.Item(fp_classdescription.Index, n).Value = reader1(10)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgForPackingCO.Columns("fp_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgForPackingCO.Columns("fp_plno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgForPackingCO.Columns("fp_cono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgForPackingCO.Columns("fp_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgForPackingCO.Columns("fp_codate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgForPackingCO.Columns("fp_receiptdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgForPackingCO.Columns("fp_canceldate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabCustomerOrders.SelectedTab Is tabForPackingCO Then
                If dgForPackingCO.Rows.Count <> 0 Then
                    dgForPackingCO.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayPackingCustomerOrders()
        Try
            dgPackingCO.Rows.Clear()
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),COALESCE(co.referencenumber,''),COALESCE(co.drnumber,''),COALESCE(DATE_FORMAT(co.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(co.targetdate,'%d-%b-%Y'),'')," &
                        "COALESCE(DATE_FORMAT(co.enddate,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.lastname,''),' - ',COALESCE(cb.rowid,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),''),COALESCE(CONCAT(COALESCE(ve.companycode,''),' - ',COALESCE(ve.companyname,'')),''),COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'') " &
                        "FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid LEFT JOIN users cb ON co.createdby = cb.rowid LEFT JOIN branches bc ON co.branchid = bc.rowid LEFT JOIN companies ve ON co.companyid = ve.rowid LEFT JOIN combinecodings cc ON co.combinecodingid = cc.rowid " &
                        "LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'Packing' ORDER BY co.ordernumber DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgPackingCO.Rows.Add()
                    dgPackingCO.Item(pa_seqno.Index, n).Value = seqno
                    dgPackingCO.Item(pa_rowid.Index, n).Value = reader1(0)
                    getPackingListNoB(CInt(reader1(0)), Me)
                    dgPackingCO.Item(pa_pano.Index, n).Value = globalpackinglistno
                    dgPackingCO.Item(pa_cono.Index, n).Value = reader1(1)
                    dgPackingCO.Item(pa_pono.Index, n).Value = reader1(2)
                    dgPackingCO.Item(pa_sidrno.Index, n).Value = reader1(3)
                    dgPackingCO.Item(pa_codate.Index, n).Value = reader1(4)
                    dgPackingCO.Item(pa_receiptdate.Index, n).Value = reader1(5)
                    dgPackingCO.Item(pa_canceldate.Index, n).Value = reader1(6)
                    dgPackingCO.Item(pa_customername.Index, n).Value = reader1(7)
                    dgPackingCO.Item(pa_createdby.Index, n).Value = reader1(8)
                    dgPackingCO.Item(pa_branchinfo.Index, n).Value = reader1(9)
                    dgPackingCO.Item(pa_vendorinfo.Index, n).Value = reader1(10)
                    dgPackingCO.Item(pa_classdescription.Index, n).Value = reader1(11)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPackingCO.Columns("pa_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingCO.Columns("pa_pano").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingCO.Columns("pa_cono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingCO.Columns("pa_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingCO.Columns("pa_sidrno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingCO.Columns("pa_codate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingCO.Columns("pa_receiptdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingCO.Columns("pa_canceldate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabCustomerOrders.SelectedTab Is tabPackingCO Then
                If dgPackingCO.Rows.Count <> 0 Then
                    dgPackingCO.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayLinedUpCustomerOrders()
        Try
            dgLinedUpCO.Rows.Clear()
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),COALESCE(co.referencenumber,''),COALESCE(co.drnumber,''),COALESCE(DATE_FORMAT(co.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(co.targetdate,'%d-%b-%Y'),'')," &
                        "COALESCE(DATE_FORMAT(co.enddate,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.lastname,''),' - ',COALESCE(cb.rowid,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),''),COALESCE(CONCAT(COALESCE(ve.companycode,''),' - ',COALESCE(ve.companyname,'')),''),COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'') " &
                        "FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid LEFT JOIN users cb ON co.createdby = cb.rowid LEFT JOIN branches bc ON co.branchid = bc.rowid LEFT JOIN companies ve ON co.companyid = ve.rowid LEFT JOIN combinecodings cc ON co.combinecodingid = cc.rowid " &
                        "LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND co.`status` = 'Lined Up' ORDER BY co.ordernumber DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgLinedUpCO.Rows.Add()
                    dgLinedUpCO.Item(lu_seqno.Index, n).Value = seqno
                    dgLinedUpCO.Item(lu_rowid.Index, n).Value = reader1(0)
                    getLineUpNos(CInt(reader1(0)), Me)
                    dgLinedUpCO.Item(lu_lineupno.Index, n).Value = globallineupnos
                    dgLinedUpCO.Item(lu_cono.Index, n).Value = reader1(1)
                    dgLinedUpCO.Item(lu_pono.Index, n).Value = reader1(2)
                    dgLinedUpCO.Item(lu_sidrno.Index, n).Value = reader1(3)
                    dgLinedUpCO.Item(lu_codate.Index, n).Value = reader1(4)
                    dgLinedUpCO.Item(lu_receiptdate.Index, n).Value = reader1(5)
                    dgLinedUpCO.Item(lu_canceldate.Index, n).Value = reader1(6)
                    dgLinedUpCO.Item(lu_customername.Index, n).Value = reader1(7)
                    dgLinedUpCO.Item(lu_createdby.Index, n).Value = reader1(8)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgLinedUpCO.Columns("lu_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLinedUpCO.Columns("lu_lineupno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLinedUpCO.Columns("lu_cono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLinedUpCO.Columns("lu_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLinedUpCO.Columns("lu_sidrno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLinedUpCO.Columns("lu_codate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLinedUpCO.Columns("lu_receiptdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgLinedUpCO.Columns("lu_canceldate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabCustomerOrders.SelectedTab Is tabLinedUpCO Then
                If dgLinedUpCO.Rows.Count <> 0 Then
                    dgLinedUpCO.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayForApprovalReceiving()
        Try
            dgForApproval.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT rr.rowid,COALESCE(rr.ordernumber,''),DATE_FORMAT(rr.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(ac.companyname,''),' - ',COALESCE(ac.accountno,''),' - ',COALESCE(ac.accounttype,'')),'')," &
                        "COALESCE(o.ordernumber,''),COALESCE(o.ordertype,'Blank'),COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.lastname,''),' - ',COALESCE(cb.rowid,'')),'') FROM orders rr " &
                        "LEFT JOIN accounts ac ON rr.accountid = ac.rowid LEFT JOIN orders o ON rr.relatedorderid = o.rowid LEFT JOIN users cb ON rr.createdby = cb.rowid " &
                        "WHERE rr.organizationid = " & Z_OrganizationID & $" AND rr.ordertype = '{OrderType.RR.ToString()}' AND rr.`status` = 'For Approval' ORDER BY rr.orderdate ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgForApproval.Rows.Add()
                    dgForApproval.Item(fa_seqno.Index, n).Value = seqno
                    dgForApproval.Item(fa_rowid.Index, n).Value = reader1(0)
                    dgForApproval.Item(fa_rrno.Index, n).Value = reader1(1)
                    dgForApproval.Item(fa_rrdate.Index, n).Value = reader1(2)
                    dgForApproval.Item(fa_accountname.Index, n).Value = reader1(3)
                    dgForApproval.Item(fa_relatedrefno.Index, n).Value = reader1(4)
                    dgForApproval.Item(fa_rrtype.Index, n).Value = reader1(5)
                    dgForApproval.Item(fa_createdby.Index, n).Value = reader1(6)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgForApproval.Columns("fa_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgForApproval.Columns("fa_rrno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgForApproval.Columns("fa_rrdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgForApproval.Columns("fa_relatedrefno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgForApproval.Columns("fa_rrtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabReceiving.SelectedTab Is tabForApproval Then
                If dgForApproval.Rows.Count <> 0 Then
                    dgForApproval.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayPurchaseOrdersReceiving()
        Try
            dgPurchaseOrders.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(ac.companyname,''),' - ',COALESCE(ac.accountno,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.lastname,''),' - ',COALESCE(cb.rowid,'')),'') FROM orders po LEFT JOIN accounts ac ON po.accountid = ac.rowid " &
                        "LEFT JOIN users cb ON po.createdby = cb.rowid WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.PO.ToString()}' AND po.`status` = 'New' ORDER BY po.ordernumber DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPurchaseOrders.Rows.Add()
                    dgPurchaseOrders.Item(po_seqno.Index, n).Value = seqno
                    dgPurchaseOrders.Item(po_rowid.Index, n).Value = reader1(0)
                    dgPurchaseOrders.Item(po_pono.Index, n).Value = reader1(1)
                    dgPurchaseOrders.Item(po_podate.Index, n).Value = reader1(2)
                    dgPurchaseOrders.Item(po_suppliername.Index, n).Value = reader1(3)
                    dgPurchaseOrders.Item(po_createdby.Index, n).Value = reader1(4)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPurchaseOrders.Columns("po_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPurchaseOrders.Columns("po_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPurchaseOrders.Columns("po_podate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabReceiving.SelectedTab Is tabPurchaseOrders Then
                If dgPurchaseOrders.Rows.Count <> 0 Then
                    dgPurchaseOrders.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayPullOutReceiving()
        Try
            dgPullOut.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(ac.companyname,''),' - ',COALESCE(ac.accountno,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.lastname,''),' - ',COALESCE(cb.rowid,'')),'') FROM orders po LEFT JOIN accounts ac ON po.accountid = ac.rowid " &
                        "LEFT JOIN users cb ON po.createdby = cb.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Pull-Out' AND po.`status` = 'New' ORDER BY po.ordernumber DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPullOut.Rows.Add()
                    dgPullOut.Item(pu_seqno.Index, n).Value = seqno
                    dgPullOut.Item(pu_rowid.Index, n).Value = reader1(0)
                    dgPullOut.Item(pu_pulloutno.Index, n).Value = reader1(1)
                    dgPullOut.Item(pu_pulloutdate.Index, n).Value = reader1(2)
                    dgPullOut.Item(pu_customername.Index, n).Value = reader1(3)
                    dgPullOut.Item(pu_createdby.Index, n).Value = reader1(4)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPullOut.Columns("pu_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOut.Columns("pu_pulloutno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPullOut.Columns("pu_pulloutdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabReceiving.SelectedTab Is tabPullOut Then
                If dgPullOut.Rows.Count <> 0 Then
                    dgPullOut.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayReturnsReceiving()
        Try
            dgReturns.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT po.rowid,COALESCE(po.ordernumber,''),DATE_FORMAT(po.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(ac.companyname,''),' - ',COALESCE(ac.accountno,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.lastname,''),' - ',COALESCE(cb.rowid,'')),'') FROM orders po LEFT JOIN accounts ac ON po.accountid = ac.rowid " &
                        "LEFT JOIN users cb ON po.createdby = cb.rowid WHERE po.organizationid = " & Z_OrganizationID & " AND po.ordertype = 'Return' AND po.`status` = 'New' ORDER BY po.ordernumber DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgReturns.Rows.Add()
                    dgReturns.Item(rt_seqno.Index, n).Value = seqno
                    dgReturns.Item(rt_rowid.Index, n).Value = reader1(0)
                    dgReturns.Item(rt_returnno.Index, n).Value = reader1(1)
                    dgReturns.Item(rt_returndate.Index, n).Value = reader1(2)
                    dgReturns.Item(rt_customername.Index, n).Value = reader1(3)
                    dgReturns.Item(rt_createdby.Index, n).Value = reader1(4)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReturns.Columns("rt_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturns.Columns("rt_returnno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReturns.Columns("rt_returndate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabReceiving.SelectedTab Is tabReturn Then
                If dgReturns.Rows.Count <> 0 Then
                    dgReturns.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

#End Region

#Region "msClicks/tsClicks"

    Private Sub msCustomerOrders_Click(sender As Object, e As EventArgs) Handles msCustomerOrders.Click
        If IsThurston Then
            Dim form = New CustomerOrdersForm2(userId:=Z_UserID)
            form.ShowDialog()

            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If COForm = True Then
                CustomerOrdersForm.BringToFront()
            Else
                COForm = True
                ChangeDisplayForm(CustomerOrdersForm, msCustomerOrders.Image, "C.O.", "Customer Orders")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msPurchaseOrders_Click(sender As Object, e As EventArgs) Handles msPurchaseOrders.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Purchase Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If POForm = True Then
                PurchaseForm.BringToFront()
            Else
                POForm = True
                ChangeDisplayForm(PurchaseForm, msPurchaseOrders.Image, "P.O.", "Purchase Orders")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msPullOut_Click(sender As Object, e As EventArgs) Handles msPullOut.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pull-Out", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If POutForm = True Then
                PulloutForm.BringToFront()
            Else
                POutForm = True
                ChangeDisplayForm(PulloutForm, msPullOut.Image, "P.Out", "Pull-Out")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msReturns_Click(sender As Object, e As EventArgs) Handles msReturns.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Returns", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If RetForm = True Then
                ReturnsForm.BringToFront()
            Else
                RetForm = True
                ChangeDisplayForm(ReturnsForm, msReturns.Image, "Ret.", "Returns")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msPickList_Click(sender As Object, e As EventArgs) Handles msPickList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If PLForm = True Then
                PickListForm.BringToFront()
            Else
                PLForm = True
                ChangeDisplayForm(PickListForm, msPickList.Image, "P.L.", "Pick List")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msVerifyPickList_Click(sender As Object, e As EventArgs) Handles msVerifyPickList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Move From Picking To Packing", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If VPLForm = True Then
                VerifyPickListForm.BringToFront()
            Else
                VPLForm = True
                ChangeDisplayForm(VerifyPickListForm, msVerifyPickList.Image, "V.P.L.", "Move From Picking To Packing")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msPackingList_Click(sender As Object, e As EventArgs) Handles msPackingList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If PaLForm = True Then
                PackingListForm.BringToFront()
            Else
                PaLForm = True
                ChangeDisplayForm(PackingListForm, msPackingList.Image, "Pa.L.", "Packing List")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msLineUpAndDelivery_Click(sender As Object, e As EventArgs) Handles msLineUpAndDelivery.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If LnUpDlvryForm = True Then
                LineUpDeliveryForm.BringToFront()
            Else
                LnUpDlvryForm = True
                ChangeDisplayForm(LineUpDeliveryForm, msLineUpAndDelivery.Image, "L.U.Dlvry.", "Line-Up And Delivery")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msReceiving_Click(sender As Object, e As EventArgs) Handles msReceiving.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Receiving", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If RRForm = True Then
                ReceivingForm.BringToFront()
            Else
                RRForm = True
                ChangeDisplayForm(ReceivingForm, msReceiving.Image, "R.R.", "Receiving")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msProducts_Click(sender As Object, e As EventArgs) Handles msProducts.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Products", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If PrdForm = True Then
                ProductsForm.BringToFront()
            Else
                PrdForm = True
                ChangeDisplayForm(ProductsForm, msProducts.Image, "Prdcts.", "Products")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msBundles_Click(sender As Object, e As EventArgs) Handles msBundles.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Bundles", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If BndlsForm = True Then
                BundlesForm.BringToFront()
            Else
                BndlsForm = True
                ChangeDisplayForm(BundlesForm, msBundles.Image, "Bndls.", "Bundles")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msInventoryLocations_Click(sender As Object, e As EventArgs) Handles msInventoryLocations.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Inventory Locations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If ILForm = True Then
                InventoryLocationsForm.BringToFront()
            Else
                ILForm = True
                ChangeDisplayForm(InventoryLocationsForm, msInventoryLocations.Image, "I.L.", "Inventory Locations")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mStockTransfer_Click(sender As Object, e As EventArgs) Handles mStockTransfer.Click
        If IsThurston Then
            Dim form As New StockTransferForm2(userId:=Z_UserID)
            form.ShowDialog()
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Stock Transfer", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If STransForm = True Then
                StockTransferForm.BringToFront()
            Else
                STransForm = True
                ChangeDisplayForm(StockTransferForm, mStockTransfer.Image, "S.Trns.", "Stock Transfer")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msStockAdjustment_Click(sender As Object, e As EventArgs) Handles msStockAdjustment.Click
        If IsThurston Then
            Dim form As New StockAdjustmentForm2(userId:=Z_UserID)
            form.ShowDialog()
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Stock Adjustment", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If SAdjForm = True Then
                StockAdjustmentForm.BringToFront()
            Else
                SAdjForm = True
                ChangeDisplayForm(StockAdjustmentForm, msStockAdjustment.Image, "S.Adj.", "Stock Adjustment")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msAccounts_Click(sender As Object, e As EventArgs) Handles msAccounts.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Accounts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If AccntsForm = True Then
                AccountsForm.BringToFront()
            Else
                AccntsForm = True
                ChangeDisplayForm(AccountsForm, msAccounts.Image, "Accnts.", "Accounts")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msContacts_Click(sender As Object, e As EventArgs) Handles msContacts.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Contacts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If CntctsForm = True Then
                ContactsForm.BringToFront()
            Else
                CntctsForm = True
                ChangeDisplayForm(ContactsForm, msContacts.Image, "Cntcts.", "Contacts")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msReference_Click(sender As Object, e As EventArgs) Handles msReferences.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If RfrncForm = True Then
                ReferencesForm.BringToFront()
            Else
                RfrncForm = True
                ChangeDisplayForm(ReferencesForm, msReferences.Image, "Rfrnc.", "References")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msCycleCount_Click(sender As Object, e As EventArgs) Handles msCycleCount.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Cycle Count", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If CCountForm = True Then
                CycleCountForm.BringToFront()
            Else
                CCountForm = True
                ChangeDisplayForm(CycleCountForm, msCycleCount.Image, "C.Cnt.", "Cycle Count")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msBrokenSizes_Click(sender As Object, e As EventArgs) Handles msBrokenSizes.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Broken Sizes", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If BrkSzsForm = True Then
                BrokenSizesForm.BringToFront()
            Else
                BrkSzsForm = True
                ChangeDisplayForm(BrokenSizesForm, msBrokenSizes.Image, "B.Szs.", "Broken Sizes")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msSellThrough_Click(sender As Object, e As EventArgs) Handles msSellThrough.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Sell-Through", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If SllThrhForm = True Then
                SellThroughForm.BringToFront()
            Else
                SllThrhForm = True
                ChangeDisplayForm(SellThroughForm, msSellThrough.Image, "S-Thrgh.", "Sell-Through")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msAging_Click(sender As Object, e As EventArgs) Handles msAging.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Aging", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If AgngForm = True Then
                AgingReportForm.BringToFront()
            Else
                AgngForm = True
                ChangeDisplayForm(AgingReportForm, msAging.Image, "Agng", "Aging")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msSalesAndQty_Click(sender As Object, e As EventArgs) Handles msSalesAndQty.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Sales And Qty", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If SlsQtyForm = True Then
                SalesAndQtyForm.BringToFront()
            Else
                SlsQtyForm = True
                ChangeDisplayForm(SalesAndQtyForm, msSalesAndQty.Image, "S.Qty.", "Sales And Qty.")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msDeliveryPerformance_Click(sender As Object, e As EventArgs) Handles msDeliveryPerformance.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Delivery Performance", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If DlvryPrfmForm = True Then
                DeliveryPerformanceForm.BringToFront()
            Else
                DlvryPrfmForm = True
                ChangeDisplayForm(DeliveryPerformanceForm, msDeliveryPerformance.Image, "D.Prfm.", "Delivery Performance")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msStockLevel_Click(sender As Object, e As EventArgs) Handles msStockLevel.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Stock Level", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If StkLvlForm = True Then
                StockLevelForm.BringToFront()
            Else
                StkLvlForm = True
                ChangeDisplayForm(StockLevelForm, msStockLevel.Image, "S.Lvl.", "Stock Level")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msPickListed_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List Report", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If PckLstRForm = True Then
                PickListReportForm.BringToFront()
            Else
                PckLstRForm = True
                ChangeDisplayForm(PickListReportForm, ms_AvailableQty.Image, "P.L.Rprt.", "Pick List Report")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msOrganizations_Click(sender As Object, e As EventArgs) Handles msOrganizations.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Organizations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If OrgForm = True Then
                OrganizationForm.BringToFront()
            Else
                OrgForm = True
                ChangeDisplayForm(OrganizationForm, msOrganizations.Image, "Org.", "Orgnizations")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msUsers_Click(sender As Object, e As EventArgs) Handles msUsers.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Users", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If UsrForm = True Then
                UserForm.BringToFront()
            Else
                UsrForm = True
                ChangeDisplayForm(UserForm, msUsers.Image, "Usrs.", "Users")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msPositionsAndViews_Click(sender As Object, e As EventArgs) Handles msPositionsAndViews.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Positions And Views", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If PosViewForm = True Then
                PostionViewForm.BringToFront()
            Else
                PosViewForm = True
                ChangeDisplayForm(PostionViewForm, msPositionsAndViews.Image, "Pos.V.", "Position View")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msAbout_Click(sender As Object, e As EventArgs) Handles msAbout.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If AbtForm = True Then
                AboutForm.BringToFront()
            Else
                AbtForm = True
                ChangeDisplayForm(AboutForm, msAbout.Image, "Abt.", "About")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msSystemIllustration_Click(sender As Object, e As EventArgs) Handles msSystemIllustration.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If SysIllForm = True Then
                SystemIllustrationForm.BringToFront()
            Else
                SysIllForm = True
                ChangeDisplayForm(SystemIllustrationForm, msSystemIllustration.Image, "Sys.Ill.", "System Illustration")
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            tsTimeValue.Text = Date.Now.ToString("h:mm:ss tt")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            Me.Cursor = Cursors.WaitCursor
            second = second + 1
            If second = 6 Then
                Timer2.Stop()
                second = 0
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Private Sub tabCustomerOrders_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabCustomerOrders.DrawItem
        Try
            TabControlColor(tabCustomerOrders, e)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub tabReceiving_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabReceiving.DrawItem
        Try
            TabControlColor(tabReceiving, e)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub tabCustomerOrders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabCustomerOrders.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If tabCustomerOrders.SelectedTab Is tabNewCO Then
                displayNewCustomerOrders()
            ElseIf tabCustomerOrders.SelectedTab Is tabSubmittedToWarehouseCO Then
                displaySubmittedToWarehouseCustomerOrders()
            ElseIf tabCustomerOrders.SelectedTab Is tabPickListedCO Then
                displayPickListedCustomerOrders()
            ElseIf tabCustomerOrders.SelectedTab Is tabForPackingCO Then
                displayForPackingCustomerOrders()
            ElseIf tabCustomerOrders.SelectedTab Is tabPackingCO Then
                displayPackingCustomerOrders()
            ElseIf tabCustomerOrders.SelectedTab Is tabLinedUpCO Then
                displayLinedUpCustomerOrders()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tabReceiving_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabReceiving.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If tabReceiving.SelectedTab Is tabForApproval Then
                displayForApprovalReceiving()
            ElseIf tabReceiving.SelectedTab Is tabPurchaseOrders Then
                displayPurchaseOrdersReceiving()
            ElseIf tabReceiving.SelectedTab Is tabPullOut Then
                displayPullOutReceiving()
            ElseIf tabReceiving.SelectedTab Is tabReturn Then
                displayReturnsReceiving()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsRefreshCO_Click(sender As Object, e As EventArgs) Handles tsRefreshCO.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If tabCustomerOrders.SelectedTab Is tabNewCO Then
                displayNewCustomerOrders()
            ElseIf tabCustomerOrders.SelectedTab Is tabSubmittedToWarehouseCO Then
                displaySubmittedToWarehouseCustomerOrders()
            ElseIf tabCustomerOrders.SelectedTab Is tabPickListedCO Then
                displayPickListedCustomerOrders()
            ElseIf tabCustomerOrders.SelectedTab Is tabForPackingCO Then
                displayForPackingCustomerOrders()
            ElseIf tabCustomerOrders.SelectedTab Is tabPackingCO Then
                displayPackingCustomerOrders()
            ElseIf tabCustomerOrders.SelectedTab Is tabLinedUpCO Then
                displayLinedUpCustomerOrders()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsRefreshRR_Click(sender As Object, e As EventArgs) Handles tsRefreshRR.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If tabReceiving.SelectedTab Is tabForApproval Then
                displayForApprovalReceiving()
            ElseIf tabReceiving.SelectedTab Is tabPurchaseOrders Then
                displayPurchaseOrdersReceiving()
            ElseIf tabReceiving.SelectedTab Is tabPullOut Then
                displayPullOutReceiving()
            ElseIf tabReceiving.SelectedTab Is tabReturn Then
                displayReturnsReceiving()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbUnPin_Click(sender As Object, e As EventArgs) Handles pbUnPin.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            tsTaskBar.Visible = False
            pbUnPin.Visible = False
            pbPin.Visible = True
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbPin_Click(sender As Object, e As EventArgs) Handles pbPin.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            tsTaskBar.Visible = True
            pbUnPin.Visible = True
            pbPin.Visible = False
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsHome_Click(sender As Object, e As EventArgs) Handles tsHome.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = System.Windows.Forms.Application.OpenForms.Count - 1 To 1 Step -1
                Dim form As Form = System.Windows.Forms.Application.OpenForms(i)
                If TypeOf (form) Is PrimaryForm Then
                    Me.BringToFront()
                Else
                    form.SendToBack()
                End If
            Next i
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AgentHelperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgentHelperToolStripMenuItem.Click
        Dim form As New ViewAccounsListForm
        form.ShowDialog()
    End Sub

    Private ReadOnly Property IsThurston As Boolean
        Get
            Return _systemOwner.IsThurston
        End Get
    End Property

    Private Async Sub DailyDeliveriesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyDeliveriesReportToolStripMenuItem.Click
        Dim reportProvider As IReportProvider = New DailyDeliveriesReportProvider()
        Await reportProvider.RunAsync()
    End Sub

    Private Async Sub ms_AvailableQty_Click_1(sender As Object, e As EventArgs) Handles ms_AvailableQty.Click
        If MessageBox.Show("Download Available Qty. Report? ", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Using excel As New ExcelPackage

                excel.Workbook.Worksheets.Add("Zero Qty.")
                Dim worksheet = excel.Workbook.Worksheets("Zero Qty.")

                worksheet.Cells("A1").Value = "Product Inventory Report"
                worksheet.Cells("A2").Value = "Available Qty."

                Dim dateNow = DateTime.Now.ToString("MMM dd, yyyy")
                worksheet.Cells("A3").Value = $"Date Exported: {dateNow}"

                Dim productInventoryLocationDataRepository = MainServiceProvider.GetRequiredService(Of IProductInventoryLocationRepository)
                Dim productInventoryLocations = Await productInventoryLocationDataRepository.GetProductInventoryLocationsZeroQtyAsync()

                worksheet.Cells("A5").Value = $"Product Code"
                worksheet.Cells("B5").Value = $"Product Name"
                worksheet.Cells("C5").Value = $"Product Size"
                worksheet.Cells("D5").Value = $"Unit measure"
                worksheet.Cells("E5").Value = $"Qty. Orderable"
                worksheet.Cells("F5").Value = $"Season Code"
                worksheet.Cells("G5").Value = $"SKU"
                worksheet.Cells("H5").Value = $"SKU2"
                worksheet.Cells("A5:H5").Style.Font.Bold = True
                Dim index = 6
                For Each item In productInventoryLocations
                    worksheet.Cells($"A{index}").Value = {item.ProductColorSize.ProductColor.Product.ProductCode}
                    worksheet.Cells($"B{index}").Value = {item.ProductColorSize.ProductColor.Product.ProductName}
                    worksheet.Cells($"C{index}").Value = {item.ProductColorSize.Size}
                    worksheet.Cells($"D{index}").Value = {item.UnitOfMeasure}
                    worksheet.Cells($"E{index}").Value = {item.TotalAvailableQty}
                    worksheet.Cells($"E{index}").Style.Numberformat.Format = "#,##0.00"
                    worksheet.Cells($"F{index}").Value = {item.ProductColorSize.SeasonCode}
                    worksheet.Cells($"G{index}").Value = {item.ProductColorSize.SKU}
                    worksheet.Cells($"H{index}").Value = {item.ProductColorSize.SKU2}
                    index += 1
                Next
                worksheet.Cells.AutoFitColumns()
                Dim directory = "c:\AttachedFiles\ProductInventory"
                If System.IO.Directory.Exists(directory) Then
                    System.IO.Directory.CreateDirectory(directory)
                End If

                Dim unixTimestamp = Int(DateTime.Now.Subtract(New DateTime(1970, 1, 1)).TotalSeconds)
                Dim fileName = $"AvailableQuantity_({unixTimestamp}).xlsx"
                Dim path = System.IO.Path.Combine(directory, fileName)
                Dim info As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(path)
                excel.SaveAs(info)

                Process.Start("EXCEL.EXE", $"{directory}\{fileName}")
                'MessageBox.Show($"Location:{directory}\{fileName}", "File Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

        End If

    End Sub

End Class