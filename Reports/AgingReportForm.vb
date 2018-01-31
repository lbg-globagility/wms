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
Public Class AgingReportForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdataset As New DataSetA.SetEDataTable
    Dim printdatatable As New DataTable
    Dim sqlquery As String
    Dim arconditionstringA, arconditionstringB, arconditionstringC As String
    Dim itemcount, rowscount, arbrandid, arcategoryid, aptotalqtyorderablesum As Integer
    Private Sub AgingReportForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoComplete()
        globalautocompleteBrandName(cboBrandName, "", Me)
        globalautocompleteCategory(cboCategory, "", Me)
    End Sub
    Sub callAutoPopulate()
        globalautopopulateBrandName(cboBrandName, "", Me)
        globalautopopulateCategory(cboCategory, "", Me)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            clearFilters()
            clearTotals()
            dgProductColorSizes.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearFilters()
        Try
            cboBrandName.Text = ""
            cboCategory.Text = ""
            cboBrandName.SelectedItem = Nothing
            cboCategory.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearTotals()
        Try
            txtTotalProducts.Text = ""
            txtTotalQtyOrderable.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Computations"
    Sub agingcomputations()
        Try
            aptotalqtyorderablesum = 0
            If dgProductColorSizes.Rows.Count <> 0 Then
                For i = 0 To dgProductColorSizes.Rows.Count - 1
                    If IsNumeric(dgProductColorSizes.Rows(i).Cells("pcs_totalqtyorderable").Value) Then
                        aptotalqtyorderablesum = aptotalqtyorderablesum + CInt(dgProductColorSizes.Rows(i).Cells("pcs_totalqtyorderable").Value)
                    End If
                Next
            End If
            txtTotalProducts.Text = Format(Math.Round(dgProductColorSizes.Rows.Count, 0), "#,##0")
            txtTotalQtyOrderable.Text = Format(Math.Round(aptotalqtyorderablesum, 0), "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "Datagrid"
    Sub displayAgingReport(ByVal iconditionstring As String)
        Try
            dgProductColorSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,'')," & _
                    "COALESCE(DATE_FORMAT(pcs.lastshipmentdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(pcs.lastsolddate,'%d-%b-%Y'),''),COALESCE(pcs.sku,'') FROM productcolorsizes pcs " & _
                    "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
                    "WHERE pcs.organizationid = " & Z_OrganizationID & " AND " & iconditionstring & " ORDER BY p.productcode,c.colorname,pcs.size "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    getTotalQtyAllocatedA(CInt(reader1(0)), Me)
                    If globaltotalqtyavailable - globaltotalqtyallocated > 0 Then
                        dgProductColorSizes.Rows.Add()
                        dgProductColorSizes.Item(pcs_seqno.Index, n).Value = seqno
                        dgProductColorSizes.Item(pcs_rowid.Index, n).Value = reader1(0)
                        dgProductColorSizes.Item(pcs_colorvalue.Index, n).Value = reader1(1)
                        dgProductColorSizes.Item(pcs_productcode.Index, n).Value = reader1(2)
                        dgProductColorSizes.Item(pcs_colorname.Index, n).Value = reader1(3)
                        dgProductColorSizes.Item(pcs_color.Index, n).Value = ""
                        dgProductColorSizes.Item(pcs_size.Index, n).Value = reader1(4)
                        dgProductColorSizes.Item(pcs_seasoncode.Index, n).Value = reader1(5)
                        dgProductColorSizes.Item(pcs_lastreceiveddate.Index, n).Value = reader1(6)
                        dgProductColorSizes.Item(pcs_totalqtyorderable.Index, n).Value = Format(globaltotalqtyavailable - globaltotalqtyallocated, "#,##0")
                        dgProductColorSizes.Item(pcs_lastsolddate.Index, n).Value = reader1(7)
                        dgProductColorSizes.Item(pcs_sku.Index, n).Value = reader1(8)
                        seqno = seqno + 1
                        n = n + 1
                    End If
                End If
            End While
            reader1.Close()
            dgProductColorSizes.Columns("pcs_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_lastreceiveddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_totalqtyorderable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_lastsolddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region
#Region "Printing"
    Sub printAgingReport(ByVal iconditionstring As String)
        Try
            dgProductColorSizes.Rows.Clear() : aptotalqtyorderablesum = 0
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,'')," & _
                    "COALESCE(DATE_FORMAT(pcs.lastshipmentdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(pcs.lastsolddate,'%d-%b-%Y'),''),COALESCE(pcs.sku,'') FROM productcolorsizes pcs " & _
                    "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
                    "WHERE pcs.organizationid = " & Z_OrganizationID & " AND " & iconditionstring & " ORDER BY p.productcode,c.colorname,pcs.size "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    getTotalQtyAllocatedA(CInt(reader1(0)), Me)
                    If globaltotalqtyavailable - globaltotalqtyallocated > 0 Then
                        dgProductColorSizes.Rows.Add()
                        dgProductColorSizes.Item(pcs_seqno.Index, n).Value = seqno
                        dgProductColorSizes.Item(pcs_rowid.Index, n).Value = reader1(0)
                        dgProductColorSizes.Item(pcs_colorvalue.Index, n).Value = reader1(1)
                        dgProductColorSizes.Item(pcs_productcode.Index, n).Value = reader1(2)
                        dgProductColorSizes.Item(pcs_colorname.Index, n).Value = reader1(3)
                        dgProductColorSizes.Item(pcs_color.Index, n).Value = ""
                        dgProductColorSizes.Item(pcs_size.Index, n).Value = reader1(4)
                        dgProductColorSizes.Item(pcs_seasoncode.Index, n).Value = reader1(5)
                        dgProductColorSizes.Item(pcs_lastreceiveddate.Index, n).Value = reader1(6)
                        dgProductColorSizes.Item(pcs_totalqtyorderable.Index, n).Value = Format(globaltotalqtyavailable - globaltotalqtyallocated, "#,##0")
                        dgProductColorSizes.Item(pcs_lastsolddate.Index, n).Value = reader1(7)
                        dgProductColorSizes.Item(pcs_sku.Index, n).Value = reader1(8)
                        aptotalqtyorderablesum = aptotalqtyorderablesum + (globaltotalqtyavailable - globaltotalqtyallocated)
                        printdataset.AddSetERow(seqno, CStr(reader1(2)), CStr(reader1(3)), CStr(reader1(4)), CStr(reader1(5)), CStr(reader1(6)), CStr(reader1(7)), CStr(reader1(8)), globaltotalqtyavailable - globaltotalqtyallocated, 0.0, seqno, 0.0, aptotalqtyorderablesum, 0.0, 0.0, Nothing)
                        seqno = seqno + 1
                        n = n + 1
                    End If
                End If
            End While
            reader1.Close()
            dgProductColorSizes.Columns("pcs_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_lastreceiveddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_totalqtyorderable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_lastsolddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
#End Region
#End Region
    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.AgngForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboBrandName_TextChanged(sender As Object, e As EventArgs) Handles cboBrandName.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboBrandName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBrandName.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboCategory_TextChanged(sender As Object, e As EventArgs) Handles cboCategory.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Aging", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.AgngForm = False
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
            If LTrim(cboBrandName.Text) = "" And LTrim(cboCategory.Text) = "" Then
                errProvider.SetError(cboBrandName, "Please fill-up either of these two.")
                errProvider.SetError(cboCategory, "Please fill-up either of these two.")
                dgProductColorSizes.Rows.Clear() : clearTotals()
                Exit Try
            End If
            If LTrim(cboBrandName.Text) <> "" Then
                getBrandID(cboBrandName.Text, Me) : arbrandid = globalbrandid
                If arbrandid = 0 Then
                    errProvider.SetError(cboBrandName, "System cannot find the brand name or you may leave it blank.")
                    dgProductColorSizes.Rows.Clear() : clearTotals()
                    Exit Try
                End If
            End If
            If LTrim(cboCategory.Text) <> "" Then
                getCategoryID(cboCategory.Text, "", Me) : arcategoryid = globalcategoryid
                If arcategoryid = 0 Then
                    errProvider.SetError(cboCategory, "System cannot find the category or you may leave it blank.")
                    dgProductColorSizes.Rows.Clear() : clearTotals()
                    Exit Try
                End If
            End If
            If arbrandid <> 0 Then
                arconditionstringA = "p.brandid = " & arbrandid & " "
            Else
                arconditionstringA = ""
            End If
            If arcategoryid <> 0 Then
                arconditionstringB = "p.categoryid = " & arcategoryid & " "
            Else
                arconditionstringB = ""
            End If
            If arconditionstringA = "" Then
                arconditionstringC = arconditionstringB
            ElseIf arconditionstringB = "" Then
                arconditionstringC = arconditionstringA
            Else
                arconditionstringC = "" & arconditionstringA & " AND " & arconditionstringB & ""
            End If
            displayAgingReport(arconditionstringC)
            agingcomputations() : colorCoding()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Aging", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.AgngForm = False
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
            If LTrim(cboBrandName.Text) = "" And LTrim(cboCategory.Text) = "" Then
                errProvider.SetError(cboBrandName, "Please fill-up either of these two.")
                errProvider.SetError(cboCategory, "Please fill-up either of these two.")
                dgProductColorSizes.Rows.Clear() : clearTotals()
                Exit Try
            End If
            If LTrim(cboBrandName.Text) <> "" Then
                getBrandID(cboBrandName.Text, Me) : arbrandid = globalbrandid
                If arbrandid = 0 Then
                    errProvider.SetError(cboBrandName, "System cannot find the brand name or you may leave it blank.")
                    dgProductColorSizes.Rows.Clear() : clearTotals()
                    Exit Try
                End If
            End If
            If LTrim(cboCategory.Text) <> "" Then
                getCategoryID(cboCategory.Text, "", Me) : arcategoryid = globalcategoryid
                If arcategoryid = 0 Then
                    errProvider.SetError(cboCategory, "System cannot find the category or you may leave it blank.")
                    dgProductColorSizes.Rows.Clear() : clearTotals()
                    Exit Try
                End If
            End If
            If MessageBox.Show("Would you like to print the Aging Report?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If arbrandid <> 0 Then
                    arconditionstringA = "p.brandid = " & arbrandid & " "
                Else
                    arconditionstringA = ""
                End If
                If arcategoryid <> 0 Then
                    arconditionstringB = "p.categoryid = " & arcategoryid & " "
                Else
                    arconditionstringB = ""
                End If
                If arconditionstringA = "" Then
                    arconditionstringC = arconditionstringB
                ElseIf arconditionstringB = "" Then
                    arconditionstringC = arconditionstringA
                Else
                    arconditionstringC = "" & arconditionstringA & " AND " & arconditionstringB & ""
                End If
                printAgingReport(arconditionstringC)
                agingcomputations() : colorCoding()
                Dim printreport As New AgingReportPrint
                Dim openreportviewer As New ReportViewer
                openreportviewer.CrystalReportViewer.ReportSource = printreport
                printdatatable = printdataset
                printreport.SetDataSource(printdatatable)
                openreportviewer.Show()
                printdatatable.Dispose()
                printdatatable = Nothing
                printdataset.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
End Class