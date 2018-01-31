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
Imports System.ComponentModel
Public Class ReferencesForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim cue As String
    Dim sqlquery As String
    Dim itemno, rowscount As Integer
    Dim rfcartonsizeid, rfbranchid, rfcategoryid, rfcombinecodingid, rfcodingid, rfshiftid As Integer
    Dim rfdeliverytruckid, rfdeliverytruckshiftid, rfvendorid, rfcodingida, rfcodingidb, rfcodingidc As Integer
    Private Sub ReferencesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoPopulate()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ReferencesForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , lblsavemsg, , , 1)
            myBalloon(, , pbAutoAddA, , , 1)
            myBalloon(, , pbAutoAddB, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoPopulate()
        autopopulateReferenceType()
        autopopulateStatus()
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            cboReferenceType.Text = ""
            cboReferenceType.SelectedItem = Nothing
            clearBranchInfo()
            clearBoxSizesInfo()
            clearVendorInfo()
            clearCategoryInfo()
            clearTruckInfo()
            clearShiftInfo()
            clearTruckShiftInfo()
            clearClassDescInfo()
            clearCodingInfo()
            clearDatagrids()
            visibleDatagrids(fraud)
            visibleGB(fraud)
            gbReferenceInformation.Enabled = fraud
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearBranchInfo()
        Try
            txtBranchCode.Text = ""
            txtBranchName.Text = ""
            txtBranchAddress.Text = ""
            cboBranchStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearBoxSizesInfo()
        Try
            txtSizeName.Text = ""
            txtLength.Text = ""
            cboLengthUOM.Text = ""
            txtWidth.Text = ""
            cboWidthUOM.Text = ""
            txtHeight.Text = ""
            cboHeightUOM.Text = ""
            cboLengthUOM.SelectedItem = Nothing
            cboWidthUOM.SelectedItem = Nothing
            cboHeightUOM.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearVendorInfo()
        Try
            txtVendorCode.Text = ""
            txtVendorName.Text = ""
            cboVendorStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearCategoryInfo()
        Try
            txtCategory.Text = ""
            cboCategoryStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearTruckInfo()
        Try
            txtTruckNo.Text = ""
            txtPlateNo.Text = ""
            txtTruckName.Text = ""
            cboBrandName.Text = ""
            cboMadeIn.Text = ""
            txtCBM.Text = ""
            cboTruckStatus.Text = ""
            cboBrandName.SelectedItem = Nothing
            cboMadeIn.SelectedItem = Nothing
            cboTruckStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearShiftInfo()
        Try
            txtShiftName.Text = ""
            dtpTimeFrom.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0)
            dtpTimeTo.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0)
            cboShiftStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearTruckShiftInfo()
        Try
            cboTruckInfo.Text = ""
            cboShiftInfo.Text = ""
            cboTruckShiftStatus.Text = ""
            cboTruckInfo.SelectedItem = Nothing
            cboShiftInfo.SelectedItem = Nothing
            cboTruckShiftStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearClassDescInfo()
        Try
            cboCodeA.Text = ""
            cboCodeB.Text = ""
            cboCodeC.Text = ""
            txtClassName.Text = ""
            cboClassDescStatus.Text = ""
            cboCodeA.SelectedItem = Nothing
            cboCodeB.SelectedItem = Nothing
            cboCodeC.SelectedItem = Nothing
            cboClassDescStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearCodingInfo()
        Try
            txtCodeType.Text = ""
            txtCodeNo.Text = ""
            txtCodeName.Text = ""
            cboCodingStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearDatagrids()
        Try
            dgBranches.Rows.Clear()
            dgBoxSizes.Rows.Clear()
            dgVendors.Rows.Clear()
            dgCategories.Rows.Clear()
            dgTrucks.Rows.Clear()
            dgShifts.Rows.Clear()
            dgTruckShifts.Rows.Clear()
            dgClassDescription.Rows.Clear()
            dgCodings.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub visibleDatagrids(ByVal ivisible As Boolean)
        Try
            dgBranches.Visible = ivisible
            dgBoxSizes.Visible = ivisible
            dgVendors.Visible = ivisible
            dgCategories.Visible = ivisible
            dgTrucks.Visible = ivisible
            dgShifts.Visible = ivisible
            dgTruckShifts.Visible = ivisible
            dgClassDescription.Visible = ivisible
            dgCodings.Visible = ivisible
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub visibleGB(ByVal ivisible As Boolean)
        Try
            gbBranchInfo.Visible = ivisible
            gbBoxSizes.Visible = ivisible
            gbVendorInfo.Visible = ivisible
            gbCategoryInfo.Visible = ivisible
            gbTruckInfo.Visible = ivisible
            gbShiftInfo.Visible = ivisible
            gbTruckShiftInfo.Visible = ivisible
            gbClassDescInfo.Visible = ivisible
            gbCodingInfo.Visible = ivisible
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
            callAutoPopulate()
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
            Dim cmd As New MySqlCommand("SELECT COALESCE(dt.brandname,'') AS 'brandname' FROM deliverytrucks dt WHERE dt.organizationid = " & Z_OrganizationID & " AND dt.`status` = 'Active' AND dt.brandname != '' GROUP BY dt.brandname ", conn)
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
    Sub autocompleteMadeIn(ByVal icombobox As ComboBox)
        Try
            Dim madein As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(dt.madein,'') AS 'madein' FROM deliverytrucks dt WHERE dt.organizationid = " & Z_OrganizationID & " AND dt.`status` = 'Active' AND dt.madein != '' GROUP BY dt.madein ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                madein.Add(ds.Tables(0).Rows(i)("madein").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = madein
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "AutoPopulate"
    Sub autopopulateReferenceType()
        Try

            cboReferenceType.Items.Clear()
            cboReferenceType.Items.Add("Box Sizes")
            cboReferenceType.Items.Add("Branches")
            cboReferenceType.Items.Add("Categories")
            cboReferenceType.Items.Add("Class Description")
            cboReferenceType.Items.Add("Codings")
            cboReferenceType.Items.Add("Shifts")
            cboReferenceType.Items.Add("Trucks")
            cboReferenceType.Items.Add("Truck And Shift")
            cboReferenceType.Items.Add("Vendors")
            cboReferenceType.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autopopulateStatus()
        Try
            cboBoxSizeStatus.Items.Clear() : cboBranchStatus.Items.Clear() : cboVendorStatus.Items.Clear() : cboCategoryStatus.Items.Clear() : cboTruckStatus.Items.Clear()
            cboShiftStatus.Items.Clear() : cboTruckShiftStatus.Items.Clear() : cboClassDescStatus.Items.Clear() : cboCodingStatus.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT lic FROM listofvalues WHERE type = 'Status' AND `status` = 'Active' ORDER BY lic "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                cboBoxSizeStatus.Items.Add(reader1(0).ToString())
                cboBranchStatus.Items.Add(reader1(0).ToString())
                cboVendorStatus.Items.Add(reader1(0).ToString())
                cboCategoryStatus.Items.Add(reader1(0).ToString())
                cboTruckStatus.Items.Add(reader1(0).ToString())
                cboShiftStatus.Items.Add(reader1(0).ToString())
                cboTruckShiftStatus.Items.Add(reader1(0).ToString())
                cboClassDescStatus.Items.Add(reader1(0).ToString())
                cboCodingStatus.Items.Add(reader1(0).ToString())
            End While
            reader1.Close()
            conn.Close()
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
            Dim sql1 As String = "SELECT COALESCE(dt.brandname,'') AS 'brandname' FROM deliverytrucks dt WHERE dt.organizationid = " & Z_OrganizationID & " AND dt.`status` = 'Active' AND dt.brandname != '' GROUP BY dt.brandname ORDER BY dt.brandname "
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
    Sub autopopulateMadeIn(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(dt.madein,'') AS 'madein' FROM deliverytrucks dt WHERE dt.organizationid = " & Z_OrganizationID & " AND dt.`status` = 'Active' AND dt.madein != '' GROUP BY dt.madein ORDER BY dt.madein "
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
    Sub displayBoxSizeList()
        Try
            dgBoxSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT bs.rowid,COALESCE(bs.sizename,''),COALESCE(CONCAT(COALESCE(bs.`length`,''),' ',COALESCE(bs.lengthuom,'')),'')," & _
                        "COALESCE(CONCAT(COALESCE(bs.`width`,''),' ',COALESCE(bs.widthuom,'')),''),COALESCE(CONCAT(COALESCE(bs.`height`,''),' ',COALESCE(bs.heightuom,'')),'')," & _
                        "COALESCE(bs.`status`,'') FROM cartonsizes bs WHERE bs.organizationid = " & Z_OrganizationID & " ORDER BY bs.sizename ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgBoxSizes.Rows.Add()
                    dgBoxSizes.Item(bs_seqno.Index, n).Value = seqno
                    dgBoxSizes.Item(bs_rowid.Index, n).Value = reader1(0)
                    dgBoxSizes.Item(bs_sizename.Index, n).Value = reader1(1)
                    dgBoxSizes.Item(bs_length.Index, n).Value = reader1(2)
                    dgBoxSizes.Item(bs_width.Index, n).Value = reader1(3)
                    dgBoxSizes.Item(bs_height.Index, n).Value = reader1(4)
                    dgBoxSizes.Item(bs_status.Index, n).Value = reader1(5)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgBoxSizes.Columns("bs_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBoxSizes.Columns("bs_length").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBoxSizes.Columns("bs_width").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBoxSizes.Columns("bs_height").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBoxSizes.Columns("bs_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgBoxSizes.Rows.Count <> 0 Then
                dgBoxSizes.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayBranchList()
        Try
            dgBranches.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT br.rowid,COALESCE(br.branchname,''),COALESCE(br.branchcode,''),COALESCE(br.`status`,''),COALESCE(br.branchaddress,'') " & _
                        "FROM branches br WHERE br.organizationid = " & Z_OrganizationID & " ORDER BY br.branchcode ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgBranches.Rows.Add()
                    dgBranches.Item(br_seqno.Index, n).Value = seqno
                    dgBranches.Item(br_rowid.Index, n).Value = reader1(0)
                    dgBranches.Item(br_branchname.Index, n).Value = reader1(1)
                    dgBranches.Item(br_branchcode.Index, n).Value = reader1(2)
                    dgBranches.Item(br_status.Index, n).Value = reader1(3)
                    dgBranches.Item(br_branchaddress.Index, n).Value = reader1(4)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgBranches.Columns("br_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBranches.Columns("br_branchcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBranches.Columns("br_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgBranches.Rows.Count <> 0 Then
                dgBranches.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayCategoryList()
        Try
            dgCategories.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ct.rowid,COALESCE(ct.categoryname,''),COALESCE(ct.`status`,'') FROM categories ct " & _
                        "WHERE ct.organizationid = " & Z_OrganizationID & " ORDER BY ct.categoryname ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCategories.Rows.Add()
                    dgCategories.Item(ct_seqno.Index, n).Value = seqno
                    dgCategories.Item(ct_rowid.Index, n).Value = reader1(0)
                    dgCategories.Item(ct_category.Index, n).Value = reader1(1)
                    dgCategories.Item(ct_status.Index, n).Value = reader1(2)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCategories.Columns("ct_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCategories.Columns("ct_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCategories.Rows.Count <> 0 Then
                dgCategories.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayClassDescriptionList()
        Try
            dgClassDescription.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT cc.rowid,COALESCE(cc.codename,''),COALESCE(c1.codeno,''),COALESCE(c2.codeno,''),COALESCE(c3.codeno,''),COALESCE(cc.`status`,'') FROM combinecodings cc LEFT JOIN codings c1 ON cc.codingida = c1.rowid " & _
                        "LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE cc.organizationid = " & Z_OrganizationID & " ORDER BY cc.codename ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgClassDescription.Rows.Add()
                    dgClassDescription.Item(cd_seqno.Index, n).Value = seqno
                    dgClassDescription.Item(cd_rowid.Index, n).Value = reader1(0)
                    dgClassDescription.Item(cd_classname.Index, n).Value = reader1(1)
                    dgClassDescription.Item(cd_deptcode.Index, n).Value = reader1(2)
                    dgClassDescription.Item(cd_subdeptcode.Index, n).Value = reader1(3)
                    dgClassDescription.Item(cd_classcode.Index, n).Value = reader1(4)
                    dgClassDescription.Item(cd_status.Index, n).Value = reader1(5)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgClassDescription.Columns("cd_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgClassDescription.Columns("cd_deptcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgClassDescription.Columns("cd_subdeptcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgClassDescription.Columns("cd_classcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgClassDescription.Columns("cd_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgClassDescription.Rows.Count <> 0 Then
                dgClassDescription.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayCodingList()
        Try
            dgCodings.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.codetype,''),COALESCE(co.codeno,''),COALESCE(co.codename,''),COALESCE(co.`status`,'') FROM codings co " & _
                        "WHERE co.organizationid = " & Z_OrganizationID & " ORDER BY co.codetype,co.codeno "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCodings.Rows.Add()
                    dgCodings.Item(co_seqno.Index, n).Value = seqno
                    dgCodings.Item(co_rowid.Index, n).Value = reader1(0)
                    dgCodings.Item(co_codetype.Index, n).Value = reader1(1)
                    dgCodings.Item(co_codeno.Index, n).Value = reader1(2)
                    dgCodings.Item(co_codename.Index, n).Value = reader1(3)
                    dgCodings.Item(co_status.Index, n).Value = reader1(4)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCodings.Columns("co_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCodings.Columns("co_codetype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCodings.Columns("co_codeno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCodings.Columns("co_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCodings.Rows.Count <> 0 Then
                dgCodings.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayShiftList()
        Try
            dgShifts.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT sh.rowid,COALESCE(sh.shiftname,''),COALESCE(CONCAT('From: ',COALESCE(TIME_FORMAT(sh.timefrom,'%r'),''),'  To: ',COALESCE(TIME_FORMAT(sh.timeto,'%r'),'')),'')," & _
                        "COALESCE(sh.`status`,'') FROM shifts sh WHERE sh.organizationid = " & Z_OrganizationID & " ORDER BY sh.shiftname "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgShifts.Rows.Add()
                    dgShifts.Item(sh_seqno.Index, n).Value = seqno
                    dgShifts.Item(sh_rowid.Index, n).Value = reader1(0)
                    dgShifts.Item(sh_shiftname.Index, n).Value = reader1(1)
                    dgShifts.Item(sh_fromto.Index, n).Value = reader1(2)
                    dgShifts.Item(sh_status.Index, n).Value = reader1(3)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgShifts.Columns("sh_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgShifts.Columns("sh_fromto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgShifts.Columns("sh_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgShifts.Rows.Count <> 0 Then
                dgShifts.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayTruckList()
        Try
            dgTrucks.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT tr.rowid,COALESCE(tr.truckno,''),COALESCE(tr.truckname,''),COALESCE(tr.plateno,''),COALESCE(tr.`status`,'') FROM deliverytrucks tr " & _
                        "WHERE tr.organizationid = " & Z_OrganizationID & " ORDER BY tr.truckno "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgTrucks.Rows.Add()
                    dgTrucks.Item(tr_rowid.Index, n).Value = reader1(0)
                    dgTrucks.Item(tr_truckno.Index, n).Value = reader1(1)
                    dgTrucks.Item(tr_truckname.Index, n).Value = reader1(2)
                    dgTrucks.Item(tr_plateno.Index, n).Value = reader1(3)
                    dgTrucks.Item(tr_status.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgTrucks.Columns("tr_truckno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgTrucks.Columns("tr_plateno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgTrucks.Columns("tr_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgTrucks.Rows.Count <> 0 Then
                dgTrucks.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayTruckShiftList()
        Try
            dgTruckShifts.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ts.rowid,COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.truckno,'')),''),COALESCE(sh.shiftname,''),COALESCE(ts.`status`,'') FROM deliverytruckshifts ts " & _
                        "LEFT JOIN deliverytrucks dt ON ts.deliverytruckid = dt.rowid LEFT JOIN shifts sh ON ts.shiftid = sh.rowid WHERE ts.organizationid = " & Z_OrganizationID & " ORDER BY dt.truckname "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgTruckShifts.Rows.Add()
                    dgTruckShifts.Item(ts_seqno.Index, n).Value = seqno
                    dgTruckShifts.Item(ts_rowid.Index, n).Value = reader1(0)
                    dgTruckShifts.Item(ts_truckinfo.Index, n).Value = reader1(1)
                    dgTruckShifts.Item(ts_shiftname.Index, n).Value = reader1(2)
                    dgTruckShifts.Item(ts_status.Index, n).Value = reader1(3)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgTruckShifts.Columns("ts_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgTruckShifts.Columns("ts_truckinfo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgTruckShifts.Columns("ts_shiftname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgTruckShifts.Columns("ts_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgTruckShifts.Rows.Count <> 0 Then
                dgTruckShifts.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayVendorList()
        Try
            dgVendors.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ve.rowid,COALESCE(ve.companyname,''),COALESCE(ve.companycode,''),COALESCE(ve.`status`,'') FROM companies ve " & _
                        "WHERE ve.organizationid = " & Z_OrganizationID & " ORDER BY ve.companycode ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgVendors.Rows.Add()
                    dgVendors.Item(ve_seqno.Index, n).Value = seqno
                    dgVendors.Item(ve_rowid.Index, n).Value = reader1(0)
                    dgVendors.Item(ve_vendorname.Index, n).Value = reader1(1)
                    dgVendors.Item(ve_vendorcode.Index, n).Value = reader1(2)
                    dgVendors.Item(ve_status.Index, n).Value = reader1(3)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgVendors.Columns("ve_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgVendors.Columns("ve_vendorcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgVendors.Columns("ve_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgVendors.Rows.Count <> 0 Then
                dgVendors.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Information"
    Sub getBoxSizesInfo(ByVal iboxsizeid As Integer)
        Try
            Dim dtBSin As New DataTable
            dtBSin = getDataTableForSQL("SELECT COALESCE(bs.sizename,''),COALESCE(bs.`length`,''),COALESCE(bs.lengthuom,''),COALESCE(bs.`width`,''),COALESCE(bs.widthuom,'')," & _
                            "COALESCE(bs.`height`,''),COALESCE(bs.heightuom,''),COALESCE(bs.`status`,'') FROM cartonsizes bs WHERE bs.rowid = " & iboxsizeid & " ")
            If dtBSin.Rows.Count <> 0 Then
                txtSizeName.Text = dtBSin.Rows(0)(0)
                txtLength.Text = dtBSin.Rows(0)(1)
                cboLengthUOM.Text = dtBSin.Rows(0)(2)
                txtWidth.Text = dtBSin.Rows(0)(3)
                cboWidthUOM.Text = dtBSin.Rows(0)(4)
                txtHeight.Text = dtBSin.Rows(0)(5)
                cboHeightUOM.Text = dtBSin.Rows(0)(6)
                cboBoxSizeStatus.Text = dtBSin.Rows(0)(7)
            Else
                clearBoxSizesInfo()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub getClassDescriptionInfo(ByVal iclassdescriptionid As Integer)
        Try
            Dim dtCDin As New DataTable
            dtCDin = getDataTableForSQL("SELECT COALESCE(cc.codename,''),COALESCE(CONCAT(COALESCE(c1.codeno,''),' - ',COALESCE(c1.codename,''),' / ',COALESCE(c1.codetype,'')),'')," & _
                                "COALESCE(CONCAT(COALESCE(c2.codeno,''),' - ',COALESCE(c2.codename,''),' / ',COALESCE(c2.codetype,'')),''),COALESCE(cc.`status`,'')," & _
                                "COALESCE(CONCAT(COALESCE(c3.codeno,''),' - ',COALESCE(c3.codename,''),' / ',COALESCE(c3.codetype,'')),'') FROM combinecodings cc " & _
                                "LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE cc.rowid = " & iclassdescriptionid & " ")
            If dtCDin.Rows.Count <> 0 Then
                txtClassName.Text = dtCDin.Rows(0)(0)
                cboCodeA.Text = dtCDin.Rows(0)(1)
                cboCodeB.Text = dtCDin.Rows(0)(2)
                cboClassDescStatus.Text = dtCDin.Rows(0)(3)
                cboCodeC.Text = dtCDin.Rows(0)(4)
            Else
                clearClassDescInfo()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub getShiftInfo(ByVal ishiftid As Integer)
        Try
            Dim dtSin As New DataTable
            dtSin = getDataTableForSQL("SELECT COALESCE(sh.shiftname,''),COALESCE(TIME_FORMAT(sh.timefrom,'%r'),''),COALESCE(TIME_FORMAT(sh.timeto,'%r'),''),COALESCE(sh.`status`,'') FROM shifts sh WHERE sh.rowid = " & ishiftid & " ")
            If dtSin.Rows.Count <> 0 Then
                txtShiftName.Text = dtSin.Rows(0)(0)
                dtpTimeFrom.Text = dtSin.Rows(0)(1)
                dtpTimeTo.Text = dtSin.Rows(0)(2)
                cboShiftStatus.Text = dtSin.Rows(0)(3)
            Else
                clearShiftInfo()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub getTruckInfo(ByVal itruckid As Integer)
        Try
            Dim dtTin As New DataTable
            dtTin = getDataTableForSQL("SELECT COALESCE(dt.truckno,''),COALESCE(dt.plateno,''),COALESCE(dt.truckname,''),COALESCE(dt.brandname,'')," & _
                            "COALESCE(dt.madein,''),COALESCE(dt.cbm,0.0),COALESCE(dt.`status`,'') FROM deliverytrucks dt WHERE dt.rowid = " & itruckid & " ")
            If dtTin.Rows.Count <> 0 Then
                txtTruckNo.Text = dtTin.Rows(0)(0)
                txtPlateNo.Text = dtTin.Rows(0)(1)
                txtTruckName.Text = dtTin.Rows(0)(2)
                cboBrandName.Text = dtTin.Rows(0)(3)
                cboMadeIn.Text = dtTin.Rows(0)(4)
                txtCBM.Text = dtTin.Rows(0)(5)
                cboTruckStatus.Text = dtTin.Rows(0)(6)
            Else
                clearTruckInfo()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub getTruckShiftInfo(ByVal itruckshiftid As Integer)
        Try
            Dim dtTSin As New DataTable
            dtTSin = getDataTableForSQL("SELECT COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.plateno,''),' - ',COALESCE(dt.truckno,'')),'')," & _
                            "COALESCE(CONCAT(COALESCE(sh.shiftname,''),' - From: ',COALESCE(TIME_FORMAT(sh.timefrom,'%r'),''),'  To: ',COALESCE(TIME_FORMAT(sh.timeto,'%r'),'')),''),COALESCE(ts.`status`,'') " & _
                            "FROM deliverytruckshifts ts LEFT JOIN deliverytrucks dt ON ts.deliverytruckid = dt.rowid LEFT JOIN shifts sh ON ts.shiftid = sh.rowid WHERE ts.rowid = " & itruckshiftid & " ")
            If dtTSin.Rows.Count <> 0 Then
                cboTruckInfo.Text = dtTSin.Rows(0)(0)
                cboShiftInfo.Text = dtTSin.Rows(0)(1)
                cboTruckShiftStatus.Text = dtTSin.Rows(0)(2)
            Else
                clearTruckShiftInfo()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
#End Region
#End Region
#End Region
    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.RfrncForm = False
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
            myBalloon("Automatic adding of made in.", "Auto-Add", pbAutoAddB, -15, -65)
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
            myBalloon("Automatic adding for the unit of measure of length.", "Auto-Add", pbAutoAddC, -15, -65)
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
            myBalloon("Automatic adding for the unit of measure of width.", "Auto-Add", pbAutoAddD, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddE_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddE.MouseEnter
        Try
            pbAutoAddE.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddE_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddE.MouseLeave
        Try
            pbAutoAddE.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddE_Click(sender As Object, e As EventArgs) Handles pbAutoAddE.Click
        Try
            myBalloon("Automatic adding for the unit of measure of height.", "Auto-Add", pbAutoAddE, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub btnAddBranch_Click(sender As Object, e As EventArgs) Handles btnAddBranch.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RfrncForm = False
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
            Dim addbranchcodenamelinkform As New AddBranchCodeNameForm
            addbranchcodenamelinkform.ShowInTaskbar = False
            addbranchcodenamelinkform.ShowDialog()
            If addbranchcodenamelinkform.addbranchcodenamecue = legit Then
                If cboReferenceType.Text = "Branches" Then
                    clearBranchInfo() : gbReferenceInformation.Enabled = fraud
                    displayBranchList() : cue = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnAddBoxSizes_Click(sender As Object, e As EventArgs) Handles btnAddBoxSizes.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RfrncForm = False
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
            Dim addsizelinkform As New AddSizeForm
            addsizelinkform.ShowInTaskbar = False
            addsizelinkform.ShowDialog()
            If addsizelinkform.addsizeformcue = legit Then
                If cboReferenceType.Text = "Box Sizes" Then
                    clearBoxSizesInfo() : gbReferenceInformation.Enabled = fraud
                    displayBoxSizeList() : cue = ""
                    globalautopopulateListOfValues(cboLengthUOM, "Unit Of Measure", Me)
                    globalautopopulateListOfValues(cboWidthUOM, "Unit Of Measure", Me)
                    globalautopopulateListOfValues(cboHeightUOM, "Unit Of Measure", Me)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RfrncForm = False
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
            Dim addcategorylinkform As New AddCategoryForm
            addcategorylinkform.ShowInTaskbar = False
            addcategorylinkform.ShowDialog()
            If addcategorylinkform.addcategorycue = legit Then
                If cboReferenceType.Text = "Categories" Then
                    clearCategoryInfo() : gbReferenceInformation.Enabled = fraud
                    displayCategoryList() : cue = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnAddClassDescription_Click(sender As Object, e As EventArgs) Handles btnAddClassDescription.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RfrncForm = False
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
            Dim addclassdescriptionlinkform As New AddClassDescriptionForm
            addclassdescriptionlinkform.ShowInTaskbar = False
            addclassdescriptionlinkform.ShowDialog()
            If addclassdescriptionlinkform.addclassdescriptioncue = legit Then
                If cboReferenceType.Text = "Class Description" Then
                    clearClassDescInfo() : gbReferenceInformation.Enabled = fraud
                    displayClassDescriptionList() : cue = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnAddCode_Click(sender As Object, e As EventArgs) Handles btnAddCode.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RfrncForm = False
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
            Dim addcodelinkform As New AddCodeForm
            addcodelinkform.ShowInTaskbar = False
            addcodelinkform.ShowDialog()
            If addcodelinkform.addcodecue = legit Then
                If cboReferenceType.Text = "Codings" Then
                    clearCodingInfo() : gbReferenceInformation.Enabled = fraud
                    displayCodingList() : cue = ""
                ElseIf cboReferenceType.Text = "Class Description" Then
                    globalautocompleteCodings(cboCodeA, "AND co.codetype = 'DEPT CODE'", Me)
                    globalautocompleteCodings(cboCodeB, "AND co.codetype = 'SUB DEPT CODE'", Me)
                    globalautocompleteCodings(cboCodeC, "AND co.codetype = 'CLASS CODE'", Me)
                    globalautopopulateCodings(cboCodeA, "AND co.codetype = 'DEPT CODE'", Me)
                    globalautopopulateCodings(cboCodeB, "AND co.codetype = 'SUB DEPT CODE'", Me)
                    globalautopopulateCodings(cboCodeC, "AND co.codetype = 'CLASS CODE'", Me)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnAddShift_Click(sender As Object, e As EventArgs) Handles btnAddShift.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RfrncForm = False
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
            Dim addshiftlinkform As New AddShiftForm
            addshiftlinkform.ShowInTaskbar = False
            addshiftlinkform.ShowDialog()
            If addshiftlinkform.addshiftformcue = legit Then
                If cboReferenceType.Text = "Shifts" Then
                    clearShiftInfo() : gbReferenceInformation.Enabled = fraud
                    displayShiftList() : cue = ""
                ElseIf cboReferenceType.Text = "Truck And Shift" Then
                    globalautocompleteShiftInfo(cboShiftInfo, Me)
                    globalautopopulateShiftInfo(cboShiftInfo, Me)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnAddTruck_Click(sender As Object, e As EventArgs) Handles btnAddTruck.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RfrncForm = False
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
            Dim addtrucklinkform As New AddTruckForm
            addtrucklinkform.ShowInTaskbar = False
            addtrucklinkform.ShowDialog()
            If addtrucklinkform.addtruckformcue = legit Then
                If cboReferenceType.Text = "Trucks" Then
                    clearTruckInfo() : gbReferenceInformation.Enabled = fraud
                    displayTruckList() : cue = ""
                    autocompleteBrandName(cboBrandName)
                    autocompleteMadeIn(cboMadeIn)
                    autopopulateBrandName(cboBrandName)
                    autopopulateMadeIn(cboMadeIn)
                ElseIf cboReferenceType.Text = "Truck And Shift" Then
                    globalautocompleteTruckInfo(cboTruckInfo, Me)
                    globalautopopulateTruckInfo(cboTruckInfo, Me)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnAddTruckShift_Click(sender As Object, e As EventArgs) Handles btnAddTruckShift.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RfrncForm = False
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
                If cboReferenceType.Text = "Truck And Shift" Then
                    clearTruckShiftInfo() : gbReferenceInformation.Enabled = fraud
                    displayTruckShiftList() : cue = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnAddVendor_Click(sender As Object, e As EventArgs) Handles btnAddVendor.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RfrncForm = False
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
            Dim addvendorcodenamelinkform As New AddVendorCodeNameForm
            addvendorcodenamelinkform.ShowInTaskbar = False
            addvendorcodenamelinkform.ShowDialog()
            If addvendorcodenamelinkform.addvendorcodenamecue = legit Then
                If cboReferenceType.Text = "Vendors" Then
                    clearVendorInfo() : gbReferenceInformation.Enabled = fraud
                    displayVendorList() : cue = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboReferenceType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReferenceType.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            cue = ""
            visibleDatagrids(fraud)
            visibleGB(fraud)
            gbReferenceInformation.Enabled = fraud
            If cboReferenceType.Text = "" Then
                visibleDatagrids(fraud)
                visibleGB(fraud)
            ElseIf cboReferenceType.Text = "Branches" Then
                dgBranches.Visible = legit
                gbBranchInfo.Visible = legit
                clearBranchInfo()
                displayBranchList()
            ElseIf cboReferenceType.Text = "Box Sizes" Then
                dgBoxSizes.Visible = legit
                gbBoxSizes.Visible = legit
                clearBoxSizesInfo()
                displayBoxSizeList()
                globalautopopulateListOfValues(cboLengthUOM, "Unit Of Measure", Me)
                globalautopopulateListOfValues(cboWidthUOM, "Unit Of Measure", Me)
                globalautopopulateListOfValues(cboHeightUOM, "Unit Of Measure", Me)
            ElseIf cboReferenceType.Text = "Categories" Then
                dgCategories.Visible = legit
                gbCategoryInfo.Visible = legit
                clearCategoryInfo()
                displayCategoryList()
            ElseIf cboReferenceType.Text = "Class Description" Then
                dgClassDescription.Visible = legit
                gbClassDescInfo.Visible = legit
                clearClassDescInfo()
                displayClassDescriptionList()
                globalautocompleteCodings(cboCodeA, "AND co.codetype = 'DEPT CODE'", Me)
                globalautocompleteCodings(cboCodeB, "AND co.codetype = 'SUB DEPT CODE'", Me)
                globalautocompleteCodings(cboCodeC, "AND co.codetype = 'CLASS CODE'", Me)
                globalautopopulateCodings(cboCodeA, "AND co.codetype = 'DEPT CODE'", Me)
                globalautopopulateCodings(cboCodeB, "AND co.codetype = 'SUB DEPT CODE'", Me)
                globalautopopulateCodings(cboCodeC, "AND co.codetype = 'CLASS CODE'", Me)
            ElseIf cboReferenceType.Text = "Codings" Then
                dgCodings.Visible = legit
                gbCodingInfo.Visible = legit
                clearCodingInfo()
                displayCodingList()
            ElseIf cboReferenceType.Text = "Shifts" Then
                dgShifts.Visible = legit
                gbShiftInfo.Visible = legit
                clearShiftInfo()
                displayShiftList()
            ElseIf cboReferenceType.Text = "Trucks" Then
                dgTrucks.Visible = legit
                gbTruckInfo.Visible = legit
                clearTruckInfo()
                displayTruckList()
                autocompleteBrandName(cboBrandName)
                autocompleteMadeIn(cboMadeIn)
                autopopulateBrandName(cboBrandName)
                autopopulateMadeIn(cboMadeIn)
            ElseIf cboReferenceType.Text = "Truck And Shift" Then
                dgTruckShifts.Visible = legit
                gbTruckShiftInfo.Visible = legit
                clearTruckShiftInfo()
                displayTruckShiftList()
                globalautocompleteTruckInfo(cboTruckInfo, Me)
                globalautocompleteShiftInfo(cboShiftInfo, Me)
                globalautopopulateTruckInfo(cboTruckInfo, Me)
                globalautopopulateShiftInfo(cboShiftInfo, Me)
            ElseIf cboReferenceType.Text = "Vendors" Then
                dgVendors.Visible = legit
                gbVendorInfo.Visible = legit
                clearVendorInfo()
                displayVendorList()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgBoxSizes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBoxSizes.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBoxSizes.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearBoxSizesInfo()
                gbReferenceInformation.Enabled = legit
                getBoxSizesInfo(CInt(dgBoxSizes.CurrentRow.Cells("bs_rowid").Value))
                txtSizeName.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgBoxSizes_KeyUp(sender As Object, e As KeyEventArgs) Handles dgBoxSizes.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBoxSizes.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearBoxSizesInfo()
                    gbReferenceInformation.Enabled = legit
                    getBoxSizesInfo(CInt(dgBoxSizes.CurrentRow.Cells("bs_rowid").Value))
                    txtSizeName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgBranches_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBranches.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBranches.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearBranchInfo()
                gbReferenceInformation.Enabled = legit
                txtBranchCode.Text = CStr(dgBranches.CurrentRow.Cells("br_branchcode").Value)
                txtBranchName.Text = CStr(dgBranches.CurrentRow.Cells("br_branchname").Value)
                cboBranchStatus.Text = CStr(dgBranches.CurrentRow.Cells("br_status").Value)
                txtBranchAddress.Text = CStr(dgBranches.CurrentRow.Cells("br_branchaddress").Value)
                txtBranchCode.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgBranches_KeyUp(sender As Object, e As KeyEventArgs) Handles dgBranches.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBranches.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearBranchInfo()
                    gbReferenceInformation.Enabled = legit
                    txtBranchCode.Text = CStr(dgBranches.CurrentRow.Cells("br_branchcode").Value)
                    txtBranchName.Text = CStr(dgBranches.CurrentRow.Cells("br_branchname").Value)
                    cboBranchStatus.Text = CStr(dgBranches.CurrentRow.Cells("br_status").Value)
                    txtBranchAddress.Text = CStr(dgBranches.CurrentRow.Cells("br_branchaddress").Value)
                    txtBranchCode.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgCategories_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCategories.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCategories.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearCategoryInfo()
                gbReferenceInformation.Enabled = legit
                txtCategory.Text = CStr(dgCategories.CurrentRow.Cells("ct_category").Value)
                cboCategoryStatus.Text = CStr(dgCategories.CurrentRow.Cells("ct_status").Value)
                txtCategory.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgCategories_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCategories.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCategories.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearCategoryInfo()
                    gbReferenceInformation.Enabled = legit
                    txtCategory.Text = CStr(dgCategories.CurrentRow.Cells("ct_category").Value)
                    cboCategoryStatus.Text = CStr(dgCategories.CurrentRow.Cells("ct_status").Value)
                    txtCategory.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgClassDescription_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgClassDescription.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgClassDescription.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearClassDescInfo()
                gbReferenceInformation.Enabled = legit
                getClassDescriptionInfo(CInt(dgClassDescription.CurrentRow.Cells("cd_rowid").Value))
                cboCodeA.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgClassDescription_KeyUp(sender As Object, e As KeyEventArgs) Handles dgClassDescription.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgClassDescription.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearClassDescInfo()
                    gbReferenceInformation.Enabled = legit
                    getClassDescriptionInfo(CInt(dgClassDescription.CurrentRow.Cells("cd_rowid").Value))
                    cboCodeA.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgCodings_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCodings.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCodings.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearCodingInfo()
                gbReferenceInformation.Enabled = legit
                txtCodeType.Text = CStr(dgCodings.CurrentRow.Cells("co_codetype").Value)
                txtCodeNo.Text = CStr(dgCodings.CurrentRow.Cells("co_codeno").Value)
                txtCodeName.Text = CStr(dgCodings.CurrentRow.Cells("co_codename").Value)
                cboCodingStatus.Text = CStr(dgCodings.CurrentRow.Cells("co_status").Value)
                txtCodeNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgCodings_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCodings.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCodings.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearCodingInfo()
                    gbReferenceInformation.Enabled = legit
                    txtCodeType.Text = CStr(dgCodings.CurrentRow.Cells("co_codetype").Value)
                    txtCodeNo.Text = CStr(dgCodings.CurrentRow.Cells("co_codeno").Value)
                    txtCodeName.Text = CStr(dgCodings.CurrentRow.Cells("co_codename").Value)
                    cboCodingStatus.Text = CStr(dgCodings.CurrentRow.Cells("co_status").Value)
                    txtCodeNo.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgShifts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgShifts.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgShifts.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearShiftInfo()
                gbReferenceInformation.Enabled = legit
                getShiftInfo(CInt(dgShifts.CurrentRow.Cells("sh_rowid").Value))
                txtShiftName.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgShifts_KeyUp(sender As Object, e As KeyEventArgs) Handles dgShifts.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgShifts.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearShiftInfo()
                    gbReferenceInformation.Enabled = legit
                    getShiftInfo(CInt(dgShifts.CurrentRow.Cells("sh_rowid").Value))
                    txtShiftName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgTrucks_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTrucks.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgTrucks.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearTruckInfo()
                gbReferenceInformation.Enabled = legit
                getTruckInfo(CInt(dgTrucks.CurrentRow.Cells("tr_rowid").Value))
                txtPlateNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgTrucks_KeyUp(sender As Object, e As KeyEventArgs) Handles dgTrucks.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgTrucks.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearTruckInfo()
                    gbReferenceInformation.Enabled = legit
                    getTruckInfo(CInt(dgTrucks.CurrentRow.Cells("tr_rowid").Value))
                    txtPlateNo.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgTruckShifts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTruckShifts.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgTruckShifts.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearTruckShiftInfo()
                gbReferenceInformation.Enabled = legit
                getTruckShiftInfo(CInt(dgTruckShifts.CurrentRow.Cells("ts_rowid").Value))
                cboTruckInfo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgTruckShifts_KeyUp(sender As Object, e As KeyEventArgs) Handles dgTruckShifts.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgTruckShifts.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearTruckShiftInfo()
                    gbReferenceInformation.Enabled = legit
                    getTruckShiftInfo(CInt(dgTruckShifts.CurrentRow.Cells("ts_rowid").Value))
                    cboTruckInfo.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgVendors_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgVendors.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgVendors.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearVendorInfo()
                gbReferenceInformation.Enabled = legit
                txtVendorCode.Text = CStr(dgVendors.CurrentRow.Cells("ve_vendorcode").Value)
                txtVendorName.Text = CStr(dgVendors.CurrentRow.Cells("ve_vendorname").Value)
                cboVendorStatus.Text = CStr(dgVendors.CurrentRow.Cells("ve_status").Value)
                txtVendorCode.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgVendors_KeyUp(sender As Object, e As KeyEventArgs) Handles dgVendors.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgVendors.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearVendorInfo()
                    gbReferenceInformation.Enabled = legit
                    txtVendorCode.Text = CStr(dgVendors.CurrentRow.Cells("ve_vendorname").Value)
                    txtVendorName.Text = CStr(dgVendors.CurrentRow.Cells("ve_vendorcode").Value)
                    cboVendorStatus.Text = CStr(dgVendors.CurrentRow.Cells("ve_status").Value)
                    txtVendorCode.Focus()
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
                getPositionView(globalpositionid, "References", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.RfrncForm = False
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
            If cue <> "Edit" Then
                MessageBox.Show("Please select the reference that will be updated from the reference list.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If cboReferenceType.Text = "" Then
                errProvider.SetError(cboReferenceType, "Please choose the reference type.")
                Exit Try
            End If
            If cboReferenceType.Text = "Box Sizes" Then
                If LTrim(txtSizeName.Text) <> "" Then
                    If dgBoxSizes.Rows.Count <> 0 Then
                        getCartonSizeIDA(txtSizeName.Text, "AND rowid != " & CInt(dgBoxSizes.CurrentRow.Cells("bs_rowid").Value) & "", Me)
                        rfcartonsizeid = globalcartonsizeid
                        If rfcartonsizeid <> 0 Then
                            errProvider.SetError(txtSizeName, "Size name has been created already, please type a new one.")
                            Exit Try
                        End If
                    Else
                        MessageBox.Show("System cannot find the reference to be updated.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtSizeName, "Please enter the size name.")
                    Exit Try
                End If
            ElseIf cboReferenceType.Text = "Branches" Then
                If LTrim(txtBranchName.Text) <> "" Then
                    If dgBranches.Rows.Count <> 0 Then
                        getBranchCodeIDA("AND branchname = """ & txtBranchName.Text & """", "AND rowid != " & CInt(dgBranches.CurrentRow.Cells("br_rowid").Value) & "", Me)
                        rfbranchid = globalbranchid
                        If rfbranchid <> 0 Then
                            errProvider.SetError(txtBranchName, "Branch name has been created already, please type a new one.")
                            Exit Try
                        End If
                    Else
                        MessageBox.Show("System cannot find the reference to be updated.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtBranchName, "Please enter the branch name.")
                    Exit Try
                End If
            ElseIf cboReferenceType.Text = "Categories" Then
                If LTrim(txtCategory.Text) <> "" Then
                    If dgCategories.Rows.Count <> 0 Then
                        getCategoryID(txtCategory.Text, "AND rowid != " & CInt(dgCategories.CurrentRow.Cells("ct_rowid").Value) & "", Me)
                        rfcategoryid = globalcategoryid
                        If rfcategoryid <> 0 Then
                            errProvider.SetError(txtCategory, "Category has been created already, please type a new one.")
                            Exit Try
                        End If
                    Else
                        MessageBox.Show("System cannot find the reference to be updated.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtCategory, "Please enter the category.")
                    Exit Try
                End If
            ElseIf cboReferenceType.Text = "Class Description" Then
                If LTrim(txtClassName.Text) <> "" Then
                    If dgClassDescription.Rows.Count <> 0 Then
                        'getCombineCodingsIDA(txtClassName.Text, "AND rowid != " & CInt(dgClassDescription.CurrentRow.Cells("cd_rowid").Value) & "", Me)
                        'rfcombinecodingid = globalcombinecodingid
                        'If rfcombinecodingid <> 0 Then
                        '    errProvider.SetError(txtClassName, "Class name has been created already, please type a new one.")
                        '    Exit Try
                        'End If
                    Else
                        MessageBox.Show("System cannot find the reference to be updated.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtClassName, "Please enter the class name.")
                    Exit Try
                End If
            ElseIf cboReferenceType.Text = "Codings" Then
                If LTrim(txtCodeNo.Text) <> "" Then
                    If dgCodings.Rows.Count <> 0 Then
                        getCodingsIDA(txtCodeNo.Text, txtCodeType.Text, "AND rowid != " & CInt(dgCodings.CurrentRow.Cells("co_rowid").Value) & "", Me)
                        rfcodingid = globalcodingid
                        If rfcodingid <> 0 Then
                            errProvider.SetError(txtCodeType, "Code type and code no. has been created already, please type a new one.")
                            errProvider.SetError(txtCodeNo, "Code type and code no. has been created already, please type a new one.")
                            Exit Try
                        End If
                    End If
                Else
                    errProvider.SetError(txtCodeNo, "Please enter the code no.")
                    Exit Try
                End If
            ElseIf cboReferenceType.Text = "Shifts" Then
                If LTrim(txtShiftName.Text) <> "" Then
                    If dgShifts.Rows.Count <> 0 Then
                        getShiftIDA(txtShiftName.Text, "AND rowid != " & CInt(dgShifts.CurrentRow.Cells("sh_rowid").Value) & "", Me)
                        rfshiftid = globalshiftid
                        If rfshiftid <> 0 Then
                            errProvider.SetError(txtShiftName, "Shift name has been created already, please type a new one.")
                            Exit Try
                        End If
                    Else
                        MessageBox.Show("System cannot find the reference to be updated.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtShiftName, "Please enter the shift name.")
                    Exit Try
                End If
            ElseIf cboReferenceType.Text = "Trucks" Then
                If LTrim(txtTruckName.Text) <> "" Then
                    If dgTrucks.Rows.Count = 0 Then
                        MessageBox.Show("System cannot find the reference to be updated.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtTruckName, "Please enter the truck name.")
                    Exit Try
                End If
            ElseIf cboReferenceType.Text = "Truck And Shift" Then
                If dgTruckShifts.Rows.Count = 0 Then
                    MessageBox.Show("System cannot find the reference to be updated.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If LTrim(cboTruckInfo.Text) <> "" Then
                    getDeliveryTruckIDB(cboTruckInfo.Text, Me)
                    rfdeliverytruckid = globaldeliverytruckid
                    If rfdeliverytruckid = 0 Then
                        errProvider.SetError(cboTruckInfo, "The truck info might be unavailable or inactive at this moment.")
                        cboTruckInfo.Focus()
                        Exit Try
                    End If
                Else
                    errProvider.SetError(cboTruckInfo, "Please enter the truck info.")
                    cboTruckInfo.Focus()
                    Exit Try
                End If
                If LTrim(cboShiftInfo.Text) <> "" Then
                    getShiftIDB(cboShiftInfo.Text, Me)
                    rfshiftid = globalshiftid
                    If rfshiftid = 0 Then
                        errProvider.SetError(cboShiftInfo, "The shift info might be unavailable or inactive at this moment.")
                        cboShiftInfo.Focus()
                        Exit Try
                    End If
                Else
                    errProvider.SetError(cboShiftInfo, "Please enter the shift info.")
                    cboShiftInfo.Focus()
                    Exit Try
                End If
                getDeliveryTruckShiftIDA(rfdeliverytruckid, rfshiftid, "AND rowid != " & CInt(dgTruckShifts.CurrentRow.Cells("ts_rowid").Value) & "", Me)
                rfdeliverytruckshiftid = globaldeliverytruckshiftid
                If rfdeliverytruckshiftid <> 0 Then
                    errProvider.SetError(cboTruckInfo, "The truck and shift has been created already.")
                    errProvider.SetError(cboShiftInfo, "The truck and shift has been created already.")
                    Exit Try
                End If
            ElseIf cboReferenceType.Text = "Vendors" Then
                If LTrim(txtVendorName.Text) <> "" Then
                    If dgVendors.Rows.Count <> 0 Then
                        'getCompanyIDA("AND companyname = """ & txtVendorName.Text & """", "AND rowid != " & CInt(dgVendors.CurrentRow.Cells("ve_rowid").Value) & "", Me)
                        'rfvendorid = globalcompanyid
                        'If rfvendorid <> 0 Then
                        '    errProvider.SetError(txtVendorName, "Vendor name has been created already, please type a new one.")
                        '    Exit Try
                        'End If
                    Else
                        MessageBox.Show("System cannot find the reference to be updated.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtVendorName, "Please enter the vendor name.")
                    Exit Try
                End If
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If cboReferenceType.Text = "Box Sizes" Then
                    getCartonSizeIDA(txtSizeName.Text, "AND rowid != " & CInt(dgBoxSizes.CurrentRow.Cells("bs_rowid").Value) & "", Me)
                    rfcartonsizeid = globalcartonsizeid
                    If rfcartonsizeid = 0 Then
                        U_CartonSizes(CInt(dgBoxSizes.CurrentRow.Cells("bs_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(txtLength.Text), CDec(txtLength.Text), 0.0), If(IsNumeric(txtWidth.Text), CDec(txtWidth.Text), 0.0), _
                            If(IsNumeric(txtHeight.Text), CDec(txtHeight.Text), 0.0), cboLengthUOM.Text, cboWidthUOM.Text, cboHeightUOM.Text, cboBoxSizeStatus.Text, Me)
                    End If
                ElseIf cboReferenceType.Text = "Branches" Then
                    getBranchCodeIDA("AND branchname = """ & txtBranchName.Text & """", "AND rowid != " & CInt(dgBranches.CurrentRow.Cells("br_rowid").Value) & "", Me)
                    rfbranchid = globalbranchid
                    If rfbranchid = 0 Then
                        U_Branches(CInt(dgBranches.CurrentRow.Cells("br_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtBranchCode.Text, txtBranchName.Text, txtBranchAddress.Text, cboBranchStatus.Text, Me)
                    End If
                ElseIf cboReferenceType.Text = "Categories" Then
                    getCategoryID(txtCategory.Text, "AND rowid != " & CInt(dgCategories.CurrentRow.Cells("ct_rowid").Value) & "", Me)
                    rfcategoryid = globalcategoryid
                    If rfcategoryid = 0 Then
                        U_Categories(CInt(dgCategories.CurrentRow.Cells("ct_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtCategory.Text, cboCategoryStatus.Text, Me)
                    End If
                ElseIf cboReferenceType.Text = "Class Description" Then
                    getCodingsIDB(cboCodeA.Text, Me)
                    rfcodingida = globalcodingid
                    getCodingsIDB(cboCodeB.Text, Me)
                    rfcodingidb = globalcodingid
                    getCodingsIDB(cboCodeC.Text, Me)
                    rfcodingidc = globalcodingid
                    U_CombineCodings(CInt(dgClassDescription.CurrentRow.Cells("cd_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(rfcodingida = 0, DBNull.Value, rfcodingida), If(rfcodingidb = 0, DBNull.Value, rfcodingidb), If(rfcodingidc = 0, DBNull.Value, rfcodingidc), txtClassName.Text, cboClassDescStatus.Text, Me)
                    'getCombineCodingsIDA(txtClassName.Text, "AND rowid != " & CInt(dgClassDescription.CurrentRow.Cells("cd_rowid").Value) & "", Me)
                    'rfcombinecodingid = globalcombinecodingid
                    'If rfcombinecodingid = 0 Then
                    '    U_CombineCodings(CInt(dgClassDescription.CurrentRow.Cells("cd_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(rfcodingida = 0, DBNull.Value, rfcodingida), If(rfcodingidb = 0, DBNull.Value, rfcodingidb), If(rfcodingidc = 0, DBNull.Value, rfcodingidc), txtClassName.Text, cboClassDescStatus.Text, Me)
                    'End If
                ElseIf cboReferenceType.Text = "Codings" Then
                    getCodingsIDA(txtCodeNo.Text, txtCodeType.Text, "AND rowid != " & CInt(dgCodings.CurrentRow.Cells("co_rowid").Value) & "", Me)
                    rfcodingid = globalcodingid
                    If rfcodingid = 0 Then
                        U_Codings(CInt(dgCodings.CurrentRow.Cells("co_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtCodeType.Text, txtCodeNo.Text, txtCodeName.Text, cboCodingStatus.Text, Me)
                    End If
                ElseIf cboReferenceType.Text = "Shifts" Then
                    getShiftIDA(txtShiftName.Text, "AND rowid != " & CInt(dgShifts.CurrentRow.Cells("sh_rowid").Value) & "", Me)
                    rfshiftid = globalshiftid
                    If rfshiftid = 0 Then
                        U_Shifts(CInt(dgShifts.CurrentRow.Cells("sh_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtShiftName.Text, dtpTimeFrom.Value, dtpTimeTo.Value, cboShiftStatus.Text, Me)
                    End If
                ElseIf cboReferenceType.Text = "Trucks" Then
                    U_DeliveryTrucks(CInt(dgTrucks.CurrentRow.Cells("tr_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtTruckName.Text, txtPlateNo.Text, cboBrandName.Text, cboMadeIn.Text, If(IsNumeric(txtCBM.Text), CDec(txtCBM.Text), 0.0), cboShiftStatus.Text, Me)
                ElseIf cboReferenceType.Text = "Truck And Shift" Then
                    getDeliveryTruckIDB(cboTruckInfo.Text, Me)
                    rfdeliverytruckid = globaldeliverytruckid
                    If rfdeliverytruckid = 0 Then
                        errProvider.SetError(cboTruckInfo, "The truck info might be unavailable or inactive at this moment.")
                        cboTruckInfo.Focus()
                        Exit Try
                    End If
                    getShiftIDB(cboShiftInfo.Text, Me)
                    rfshiftid = globalshiftid
                    If rfshiftid = 0 Then
                        errProvider.SetError(cboShiftInfo, "The shift info might be unavailable or inactive at this moment.")
                        cboShiftInfo.Focus()
                        Exit Try
                    End If
                    getDeliveryTruckShiftIDA(rfdeliverytruckid, rfshiftid, "AND rowid != " & CInt(dgTruckShifts.CurrentRow.Cells("ts_rowid").Value) & "", Me)
                    rfdeliverytruckshiftid = globaldeliverytruckshiftid
                    If rfdeliverytruckshiftid = 0 Then
                        U_DeliveryTruckShift(CInt(dgTruckShifts.CurrentRow.Cells("ts_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, rfdeliverytruckid, rfshiftid, cboTruckShiftStatus.Text, Me)
                    End If
                ElseIf cboReferenceType.Text = "Vendors" Then
                    'getCompanyIDA("AND companyname = """ & txtVendorName.Text & """", "AND rowid != " & CInt(dgVendors.CurrentRow.Cells("ve_rowid").Value) & "", Me)
                    'rfvendorid = globalcompanyid
                    'If rfvendorid = 0 Then
                    '    U_Companies(CInt(dgVendors.CurrentRow.Cells("ve_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtVendorCode.Text, txtVendorName.Text, cboVendorStatus.Text, Me)
                    'End If
                    U_Companies(CInt(dgVendors.CurrentRow.Cells("ve_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtVendorCode.Text, txtVendorName.Text, cboVendorStatus.Text, Me)
                End If
                If myModule.systemerrorfound = False Then
                    myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
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
#Region "Datagrid Errors"
    Private Sub dgBranches_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgBranches.DataError
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
                dgBranches.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgVendors_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgVendors.DataError
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
                dgVendors.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgCategories_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCategories.DataError
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
                dgCategories.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgTrucks_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgTrucks.DataError
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
                dgTrucks.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgShifts_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgShifts.DataError
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
                dgShifts.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgTruckShifts_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgTruckShifts.DataError
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
                dgTruckShifts.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgClassDescription_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgClassDescription.DataError
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
                dgClassDescription.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgCodings_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCodings.DataError
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
                dgCodings.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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