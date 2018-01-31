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
Public Class StockLevelForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdataset As New DataSetA.SetADataTable
    Dim printdatatable As New DataTable
    Dim sqlquery As String
    Dim slproductimage As Object
    Dim slbrandid, slcategoryid As Integer
    Dim slconditionstringA, slconditionstringB, slconditionstringC As String
    Private Sub StockLevelForm_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        globalautocompleteBrandName(cboBrandName, "AND `status` = 'Active'", Me)
        globalautocompleteCategory(cboCategory, "AND `status` = 'Active'", Me)
    End Sub
    Sub callAutoPopulate()
        globalautopopulateBrandName(cboBrandName, "AND `status` = 'Active'", Me)
        globalautopopulateCategory(cboCategory, "AND `status` = 'Active'", Me)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            clearFilters()
            dgProductColorSizes.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearFilters()
        Try
            rbtnGoodStocks.Checked = fraud
            rbtnDamageStocks.Checked = fraud
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
#End Region
#Region "Display"
    Sub displayGoodStocks(ByVal iconditionstring As String)
        Try
            dgProductColorSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,0.0),COALESCE(pcs.seasoncode,''),COALESCE(p.unitprice,0.00),COALESCE(pcs.sku,'') FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
                        "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN companies v ON p.companyid = v.rowid LEFT JOIN brands b ON p.brandid = b.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " AND " & iconditionstring & " ORDER BY b.brandname,p.productcode,c.colorname "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductColorSizes.Rows.Add()
                    dgProductColorSizes.Item(pcs_seqno.Index, n).Value = seqno
                    dgProductColorSizes.Item(pcs_color.Index, n).Value = ""
                    dgProductColorSizes.Item(pcs_rowid.Index, n).Value = reader1(0)
                    dgProductColorSizes.Item(pcs_colorvalue.Index, n).Value = reader1(1)
                    dgProductColorSizes.Item(pcs_productcode.Index, n).Value = reader1(2)
                    dgProductColorSizes.Item(pcs_colorname.Index, n).Value = reader1(3)
                    dgProductColorSizes.Item(pcs_size.Index, n).Value = reader1(4)
                    dgProductColorSizes.Item(pcs_seasoncode.Index, n).Value = reader1(5)
                    dgProductColorSizes.Item(pcs_srp.Index, n).Value = CDec(reader1(6))
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    dgProductColorSizes.Item(pcs_totalqtyavailable.Index, n).Value = globaltotalqtyavailable
                    dgProductColorSizes.Item(pcs_sku.Index, n).Value = reader1(7)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductColorSizes.Columns("pcs_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_totalqtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
    Sub displayDamageStocks(ByVal iconditionstring As String)
        Try
            dgProductColorSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,0.0),COALESCE(pcs.seasoncode,''),COALESCE(p.unitprice,0.00),COALESCE(pcs.totaldamageqty,0),COALESCE(pcs.sku,'') FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
                        "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN companies v ON p.companyid = v.rowid LEFT JOIN brands b ON p.brandid = b.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " AND " & iconditionstring & " ORDER BY b.brandname,p.productcode,c.colorname "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductColorSizes.Rows.Add()
                    dgProductColorSizes.Item(pcs_seqno.Index, n).Value = seqno
                    dgProductColorSizes.Item(pcs_color.Index, n).Value = ""
                    dgProductColorSizes.Item(pcs_rowid.Index, n).Value = reader1(0)
                    dgProductColorSizes.Item(pcs_colorvalue.Index, n).Value = reader1(1)
                    dgProductColorSizes.Item(pcs_productcode.Index, n).Value = reader1(2)
                    dgProductColorSizes.Item(pcs_colorname.Index, n).Value = reader1(3)
                    dgProductColorSizes.Item(pcs_size.Index, n).Value = reader1(4)
                    dgProductColorSizes.Item(pcs_seasoncode.Index, n).Value = reader1(5)
                    dgProductColorSizes.Item(pcs_srp.Index, n).Value = CDec(reader1(6))
                    dgProductColorSizes.Item(pcs_totalqtyavailable.Index, n).Value = reader1(7)
                    dgProductColorSizes.Item(pcs_sku.Index, n).Value = reader1(8)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductColorSizes.Columns("pcs_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_totalqtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
#Region "Printing"
    Sub printGoodStocks(ByVal iconditionstring As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT * FROM vw_stocklevelreport WHERE organizationid = " & Z_OrganizationID & " AND " & iconditionstring & " AND totalavailableqty > 0 ORDER BY brandname,productcode,colorname,rowid ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    slproductimage = reader1(10)
                    If IsDBNull(slproductimage) Then
                        slproductimage = Nothing
                    End If
                    printdataset.AddSetARow(CStr(reader1(7)), CStr(reader1(1)), CStr(reader1(2)), CInt(reader1(9)), CInt(reader1(8)), Format(CDec(reader1(3)), "#,##0"), Date.Now.ToString("dd-MMM-yyyy"), Z_UserName, CStr(reader1(4)), Format(CDec(reader1(5)), "#,##0.00"), "", slproductimage, "", "", "")
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub printDamageStocks(ByVal iconditionstring As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,0.0),COALESCE(pcs.seasoncode,''),COALESCE(p.unitprice,0.00),COALESCE(pcs.sku,''),COALESCE(b.brandname,''),p.image,COALESCE(pcs.totaldamageqty,0) FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
                        "LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN companies v ON p.companyid = v.rowid LEFT JOIN brands b ON p.brandid = b.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " AND " & iconditionstring & " ORDER BY b.brandname,p.productcode,c.colorname,pcs.rowid ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    slproductimage = reader1(8)
                    If IsDBNull(slproductimage) Then
                        slproductimage = Nothing
                    End If
                    getPrintOrder(CStr(reader1(3)), Me)
                    If CInt(reader1(9)) > 0 Then
                        printdataset.AddSetARow(CStr(reader1(7)), CStr(reader1(1)), CStr(reader1(2)), globalprintorder, CInt(reader1(9)), "" & CStr(reader1(3)) & " " & CStr(reader1(4)) & "", Date.Now.ToString("dd-MMM-yyyy"), Z_UserName, "", "", "", slproductimage, "", "", "")
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
#End Region
#End Region
    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.StkLvlForm = False
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
                getPositionView(globalpositionid, "Stock Level", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.StkLvlForm = False
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
                dgProductColorSizes.Rows.Clear()
                Exit Try
            End If
            If LTrim(cboBrandName.Text) <> "" Then
                getBrandID(cboBrandName.Text, Me) : slbrandid = globalbrandid
                If slbrandid = 0 Then
                    errProvider.SetError(cboBrandName, "System cannot find the brand name or you may leave it blank.")
                    dgProductColorSizes.Rows.Clear()
                    Exit Try
                End If
            End If
            If LTrim(cboCategory.Text) <> "" Then
                getCategoryID(cboCategory.Text, "", Me) : slcategoryid = globalcategoryid
                If slcategoryid = 0 Then
                    errProvider.SetError(cboCategory, "System cannot find the category or you may leave it blank.")
                    dgProductColorSizes.Rows.Clear()
                    Exit Try
                End If
            End If
            If rbtnGoodStocks.Checked = fraud AndAlso rbtnDamageStocks.Checked = fraud Then
                errProvider.SetError(rbtnGoodStocks, "Please choose either of these two.")
                errProvider.SetError(rbtnDamageStocks, "Please choose either of these two.")
                dgProductColorSizes.Rows.Clear()
                Exit Try
            End If
            Me.Cursor = Cursors.WaitCursor
            If slbrandid <> 0 Then
                slconditionstringA = "p.brandid = " & slbrandid & " "
            Else
                slconditionstringA = ""
            End If
            If slcategoryid <> 0 Then
                slconditionstringB = "p.categoryid = " & slcategoryid & " "
            Else
                slconditionstringB = ""
            End If
            If slconditionstringA = "" Then
                slconditionstringC = slconditionstringB
            ElseIf slconditionstringB = "" Then
                slconditionstringC = slconditionstringA
            Else
                slconditionstringC = "" & slconditionstringA & " AND " & slconditionstringB & ""
            End If
            If rbtnGoodStocks.Checked = legit Then
                displayGoodStocks(slconditionstringC)
                pcs_totalqtyavailable.HeaderText = "Total Qty. Available"
            ElseIf rbtnDamageStocks.Checked = legit Then
                displayDamageStocks(slconditionstringC)
                pcs_totalqtyavailable.HeaderText = "Total Damage Qty."
            End If
            colorCoding()
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
                getPositionView(globalpositionid, "Stock Level", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.StkLvlForm = False
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
                dgProductColorSizes.Rows.Clear()
                Exit Try
            End If
            If LTrim(cboBrandName.Text) <> "" Then
                getBrandID(cboBrandName.Text, Me) : slbrandid = globalbrandid
                If slbrandid = 0 Then
                    errProvider.SetError(cboBrandName, "System cannot find the brand name or you may leave it blank.")
                    dgProductColorSizes.Rows.Clear()
                    Exit Try
                End If
            End If
            If LTrim(cboCategory.Text) <> "" Then
                getCategoryID(cboCategory.Text, "", Me) : slcategoryid = globalcategoryid
                If slcategoryid = 0 Then
                    errProvider.SetError(cboCategory, "System cannot find the category or you may leave it blank.")
                    dgProductColorSizes.Rows.Clear()
                    Exit Try
                End If
            End If
            If rbtnGoodStocks.Checked = fraud AndAlso rbtnDamageStocks.Checked = fraud Then
                errProvider.SetError(rbtnGoodStocks, "Please choose either of these two.")
                errProvider.SetError(rbtnDamageStocks, "Please choose either of these two.")
                dgProductColorSizes.Rows.Clear()
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this Stock Level Report?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If rbtnGoodStocks.Checked = legit Then
                    If slbrandid <> 0 Then
                        slconditionstringA = "brandid = " & slbrandid & " "
                    Else
                        slconditionstringA = ""
                    End If
                    If slcategoryid <> 0 Then
                        slconditionstringB = "categoryid = " & slcategoryid & " "
                    Else
                        slconditionstringB = ""
                    End If
                    If slconditionstringA = "" Then
                        slconditionstringC = slconditionstringB
                    ElseIf slconditionstringB = "" Then
                        slconditionstringC = slconditionstringA
                    Else
                        slconditionstringC = "" & slconditionstringA & " AND " & slconditionstringB & ""
                    End If
                    printGoodStocks(slconditionstringC)
                ElseIf rbtnDamageStocks.Checked = legit Then
                    If slbrandid <> 0 Then
                        slconditionstringA = "p.brandid = " & slbrandid & " "
                    Else
                        slconditionstringA = ""
                    End If
                    If slcategoryid <> 0 Then
                        slconditionstringB = "p.categoryid = " & slcategoryid & " "
                    Else
                        slconditionstringB = ""
                    End If
                    If slconditionstringA = "" Then
                        slconditionstringC = slconditionstringB
                    ElseIf slconditionstringB = "" Then
                        slconditionstringC = slconditionstringA
                    Else
                        slconditionstringC = "" & slconditionstringA & " AND " & slconditionstringB & ""
                    End If
                    printDamageStocks(slconditionstringC)
                End If
                Dim printreport As New StockLevelPrint
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
#Region "Datagrid Errors"
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
#End Region
End Class