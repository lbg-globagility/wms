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
Public Class AddPullOutDetailsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlquery As String
    Dim printdataset As New DataSetA.SetADataTable
    Dim printdatatable As New DataTable
    Dim apodbranchid, apodvendorid, apodcombinecodingid As Integer
    Public apodorderid As Integer
    Private Sub AddPullOutDetailsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            displayPullOutInformation(apodorderid)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub clearfields()
        Try
            txtSCPOANo.Text = ""
            cboBranchCodeNameInfo.Text = ""
            cboVendorCodeNameInfo.Text = ""
            cboClassDescription.Text = ""
            cboBranchCodeNameInfo.SelectedItem = Nothing
            cboVendorCodeNameInfo.SelectedItem = Nothing
            cboClassDescription.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub callAutoComplete()
        globalautocompleteBranchCodeName(cboBranchCodeNameInfo, Me)
        globalautocompleteVendorCodeName(cboVendorCodeNameInfo, Me)
        globalautocompleteClassDescription(cboClassDescription, Me)
    End Sub
    Sub callAutoPopulate()
        globalautopopulateBranchCodeName(cboBranchCodeNameInfo, Me)
        globalautopopulateVendorCodeName(cboVendorCodeNameInfo, Me)
        globalautopopulateClassDescription(cboClassDescription, Me)
    End Sub
    Sub displayPullOutInformation(ByVal iorderid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(po.referencenumber,''),COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),''),COALESCE(CONCAT(COALESCE(ve.companyname,''),' - ',COALESCE(ve.companycode,'')),'')," & _
                        "COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'') FROM orders po LEFT JOIN branches bc ON po.branchid = bc.rowid " & _
                        "LEFT JOIN companies ve ON po.companyid = ve.rowid LEFT JOIN combinecodings cc ON po.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid " & _
                        "LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE po.rowid = " & iorderid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtSCPOANo.Text = reader1(0)
                    cboBranchCodeNameInfo.Text = reader1(1)
                    cboVendorCodeNameInfo.Text = reader1(2)
                    cboClassDescription.Text = reader1(3)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub printandsavePullOut(ByVal iorderid As Integer)
        Try
            getBranchCodeIDB(cboBranchCodeNameInfo.Text, Me)
            apodbranchid = globalbranchid
            getCompanyIDB(cboVendorCodeNameInfo.Text, Me)
            apodvendorid = globalcompanyid
            getCombineCodingsIDB(cboClassDescription.Text, Me)
            apodcombinecodingid = globalcombinecodingid
            M_U_OrderB(iorderid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, apodbranchid, apodvendorid, apodcombinecodingid, txtSCPOANo.Text, Me)
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(ve.companycode,''),COALESCE(o.referencenumber,''),COALESCE(br.branchcode,''),DATE_FORMAT(o.orderdate,'%d-%b-%Y'),COALESCE(c1.codeno,''),COALESCE(c2.codeno,''),COALESCE(c3.codeno,'')," & _
                        "COALESCE(CONCAT(COALESCE(p.productcode,''),' ',COALESCE(c.colorname,''),' ',COALESCE(pcs.size,''),' ',COALESCE(pcs.seasoncode,'')),''),COALESCE(pcs.sku,''),COALESCE(ci.qtyordered,0) FROM orderitems ci " & _
                        "LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
                        "LEFT JOIN orders o ON ci.orderid = o.rowid LEFT JOIN companies ve ON o.companyid = ve.rowid LEFT JOIN branches br ON o.branchid = br.rowid LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid " & _
                        "LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid " & _
                        "WHERE ci.orderid = " & iorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.`status` != 'Inactive' AND (ci.itemtype != 'BI' AND ci.itemtype != 'A') ORDER BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    printdataset.AddSetARow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(2)), CStr(reader1(3)), CInt(reader1(9)), CStr(reader1(4)), CStr(reader1(5)), CStr(reader1(6)), "0", CStr(reader1(7)), CStr(reader1(8)), Nothing, "", "", "")
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
    Private Sub pbAddBranchCodeName_MouseEnter(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.MouseEnter
        Try
            pbAddBranchCodeName.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddBranchCodeName_MouseLeave(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.MouseLeave
        Try
            pbAddBranchCodeName.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddBranchCodeName_Click(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim addbranchcodenamelinkform As New AddBranchCodeNameForm
            addbranchcodenamelinkform.ShowInTaskbar = False
            addbranchcodenamelinkform.ShowDialog()
            If addbranchcodenamelinkform.addbranchcodenamecue = legit Then
                globalautocompleteBranchCodeName(cboBranchCodeNameInfo, Me)
                globalautopopulateBranchCodeName(cboBranchCodeNameInfo, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub pbAddVendorCodeName_MouseEnter(sender As Object, e As EventArgs) Handles pbAddVendorCodeName.MouseEnter
        Try
            pbAddVendorCodeName.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddVendorCodeName_MouseLeave(sender As Object, e As EventArgs) Handles pbAddVendorCodeName.MouseLeave
        Try
            pbAddVendorCodeName.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddVendorCodeName_Click(sender As Object, e As EventArgs) Handles pbAddVendorCodeName.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim addvendorcodenamelinkform As New AddVendorCodeNameForm
            addvendorcodenamelinkform.ShowInTaskbar = False
            addvendorcodenamelinkform.ShowDialog()
            If addvendorcodenamelinkform.addvendorcodenamecue = legit Then
                globalautocompleteVendorCodeName(cboVendorCodeNameInfo, Me)
                globalautopopulateVendorCodeName(cboVendorCodeNameInfo, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub pbAddClassDescription_MouseEnter(sender As Object, e As EventArgs) Handles pbAddClassDescription.MouseEnter
        Try
            pbAddClassDescription.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddClassDescription_MouseLeave(sender As Object, e As EventArgs) Handles pbAddClassDescription.MouseLeave
        Try
            pbAddClassDescription.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddClassDescription_Click(sender As Object, e As EventArgs) Handles pbAddClassDescription.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim addclassdescriptionlinkform As New AddClassDescriptionForm
            addclassdescriptionlinkform.ShowInTaskbar = False
            addclassdescriptionlinkform.ShowDialog()
            If addclassdescriptionlinkform.addclassdescriptioncue = legit Then
                globalautocompleteClassDescription(cboClassDescription, Me)
                globalautopopulateClassDescription(cboClassDescription, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub msPrintSave_Click(sender As Object, e As EventArgs) Handles msPrintSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            If apodorderid <> 0 Then
                getOrderStatus(apodorderid, Me)
                If globalorderstatus = "Cancelled" Then
                    MessageBox.Show("This pull-out has been cancelled already.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If MessageBox.Show("Would you like to print and save this pull-out?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    printandsavePullOut(apodorderid)
                    Dim printreport As New PullOutBPrint
                    Dim openreportviewer As New ReportViewer
                    openreportviewer.CrystalReportViewer.ReportSource = printreport
                    printdatatable = printdataset
                    printreport.SetDataSource(printdatatable)
                    openreportviewer.Show()
                    printdatatable.Dispose()
                    printdatatable = Nothing
                    printdataset.Clear()
                End If
            Else
                errProvider.SetError(txtSCPOANo, "System cannot find the Pull-Out to be printed.")
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
End Class