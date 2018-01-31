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
Public Class BrokenSizesForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdataset As New DataSetA.SetDDataTable
    Dim printdatatable As New DataTable
    Dim sqlquery As String
    Dim bsconditionstring As String
    Dim bsproductid, bsbrandid, bscategoryid As Integer
    Dim itemcount, rowscount, seqno, bsproductcodecount As Integer
    Private Sub BrokenSizesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
#Region "Functions"
    Sub callAutoPopulate()
        autopopulatecboFilterBy()
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            cboFilterBy.SelectedItem = Nothing
            cboFilterPhrase.SelectedItem = Nothing
            cboFilterPhrase.Text = ""
            chkAll.Checked = fraud
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "AutoPopulate"
    Sub autopopulatecboFilterBy()
        Try
            cboFilterBy.Items.Clear()
            cboFilterBy.Items.Add("ProductCode")
            cboFilterBy.Items.Add("BrandName")
            cboFilterBy.Items.Add("Category")
            cboFilterBy.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Datagrids"
    Sub displayBrokenSizes(ByVal iconditionstring As String)
        Try
            dgProductColorSizesA.Rows.Clear() : dgProductColorSizesB.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pil.productcolorsizeid,pc.rowid FROM productinventorylocation pil LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid " & _
                        "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
                        "WHERE pil.organizationid = " & Z_OrganizationID & " " & iconditionstring & " GROUP BY pil.productcolorsizeid ORDER BY p.productcode,c.colorname  "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim m As Integer = 0
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    If globaltotalqtyavailable < startingpage Then
                        dgProductColorSizesB.Rows.Add()
                        dgProductColorSizesB.Item(pb_productcolorsizeid.Index, n).Value = reader1(0)
                        dgProductColorSizesB.Item(pb_productcolorid.Index, n).Value = reader1(1)
                        n = n + 1
                    Else
                        dgProductColorSizesA.Rows.Add()
                        dgProductColorSizesA.Item(pa_productcolorsizeid.Index, m).Value = reader1(0)
                        dgProductColorSizesA.Item(pa_productcolorid.Index, m).Value = reader1(1)
                        m = m + 1
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
    Sub groupProductID()
        Try
            dgProductColorSizes.Rows.Clear() : itemcount = 0 : seqno = 1 : bsproductcodecount = 0
            If dgProductColorSizesB.Rows.Count <> 0 Then
                If dgProductColorSizesA.Rows.Count <> 0 Then
                    For p = 0 To dgProductColorSizesB.Rows.Count - 1
                        For i = 0 To dgProductColorSizesA.Rows.Count - 1
                            If CInt(dgProductColorSizesA.Rows(i).Cells("pa_productcolorid").Value) = CInt(dgProductColorSizesB.Rows(p).Cells("pb_productcolorid").Value) Then
                                If dgProductColorSizes.Rows.Count <> 0 Then
                                    rowscount = dgProductColorSizes.Rows.Count - 1
                                    For e = 0 To dgProductColorSizes.Rows.Count - 1
                                        If CInt(dgProductColorSizes.Rows(e).Cells("pcs_productid").Value) = CInt(dgProductColorSizesB.Rows(p).Cells("pb_productcolorid").Value) Then
                                            Exit For
                                        ElseIf rowscount = 0 Then
                                            displayProductColorSizes(CInt(dgProductColorSizesB.Rows(p).Cells("pb_productcolorid").Value))
                                            bsproductcodecount = bsproductcodecount + startingpage
                                        End If
                                        rowscount = rowscount - 1
                                    Next
                                Else
                                    displayProductColorSizes(CInt(dgProductColorSizesB.Rows(p).Cells("pb_productcolorid").Value))
                                    bsproductcodecount = bsproductcodecount + startingpage
                                End If
                            End If
                        Next
                    Next
                Else
                    MessageBox.Show("All of the products are sold out as of this moment.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("All of the products are still available as of this moment.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayProductColorSizes(ByVal iproductid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pil.productcolorsizeid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.`size`,'')," & _
                        "COALESCE(pcs.seasoncode,''),COALESCE(pcs.`sku`,'') FROM productinventorylocation pil LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid " & _
                        "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
                        "WHERE pil.organizationid = " & Z_OrganizationID & " AND pc.rowid = " & iproductid & " GROUP BY pil.productcolorsizeid ORDER BY p.productcode,c.colorname,pcs.`size` "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductColorSizes.Rows.Add()
                    dgProductColorSizes.Item(pcs_productid.Index, itemcount).Value = iproductid
                    dgProductColorSizes.Item(pcs_seqno.Index, itemcount).Value = seqno
                    dgProductColorSizes.Item(pcs_rowid.Index, itemcount).Value = reader1(0)
                    dgProductColorSizes.Item(pcs_colorvalue.Index, itemcount).Value = reader1(1)
                    dgProductColorSizes.Item(pcs_productcode.Index, itemcount).Value = reader1(2)
                    dgProductColorSizes.Item(pcs_colorname.Index, itemcount).Value = reader1(3)
                    dgProductColorSizes.Item(pcs_color.Index, itemcount).Value = ""
                    dgProductColorSizes.Item(pcs_size.Index, itemcount).Value = reader1(4)
                    dgProductColorSizes.Item(pcs_seasoncode.Index, itemcount).Value = reader1(5)
                    dgProductColorSizes.Item(pcs_sku.Index, itemcount).Value = reader1(6)
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    dgProductColorSizes.Item(pcs_totalqtyavailable.Index, itemcount).Value = globaltotalqtyavailable
                    seqno = seqno + 1
                    itemcount = itemcount + 1
                End If
            End While
            reader1.Close()
            dgProductColorSizes.Columns("pcs_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_totalqtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
#Region "Printing"
    Sub printBrokenSizes(ByVal iconditionstring As String)
        Try
            dgProductColorSizesA.Rows.Clear() : dgProductColorSizesB.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pil.productcolorsizeid,pc.rowid FROM productinventorylocation pil LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid " & _
                        "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
                        "WHERE pil.organizationid = " & Z_OrganizationID & " " & iconditionstring & " GROUP BY pil.productcolorsizeid ORDER BY p.productcode,c.colorname  "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim m As Integer = 0
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    If globaltotalqtyavailable < startingpage Then
                        dgProductColorSizesB.Rows.Add()
                        dgProductColorSizesB.Item(pb_productcolorsizeid.Index, n).Value = reader1(0)
                        dgProductColorSizesB.Item(pb_productcolorid.Index, n).Value = reader1(1)
                        n = n + 1
                    Else
                        dgProductColorSizesA.Rows.Add()
                        dgProductColorSizesA.Item(pa_productcolorsizeid.Index, m).Value = reader1(0)
                        dgProductColorSizesA.Item(pa_productcolorid.Index, m).Value = reader1(1)
                        m = m + 1
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
    Sub printgroupProductID(ByVal ifirstgroup As String)
        Try
            dgProductColorSizes.Rows.Clear() : itemcount = 0 : seqno = 1 : bsproductcodecount = 0
            If dgProductColorSizesB.Rows.Count <> 0 Then
                If dgProductColorSizesA.Rows.Count <> 0 Then
                    For p = 0 To dgProductColorSizesB.Rows.Count - 1
                        For i = 0 To dgProductColorSizesA.Rows.Count - 1
                            If CInt(dgProductColorSizesA.Rows(i).Cells("pa_productcolorid").Value) = CInt(dgProductColorSizesB.Rows(p).Cells("pb_productcolorid").Value) Then
                                If dgProductColorSizes.Rows.Count <> 0 Then
                                    rowscount = dgProductColorSizes.Rows.Count - 1
                                    For e = 0 To dgProductColorSizes.Rows.Count - 1
                                        If CInt(dgProductColorSizes.Rows(e).Cells("pcs_productid").Value) = CInt(dgProductColorSizesB.Rows(p).Cells("pb_productcolorid").Value) Then
                                            Exit For
                                        ElseIf rowscount = 0 Then
                                            displayProductColorSizes(CInt(dgProductColorSizesB.Rows(p).Cells("pb_productcolorid").Value))
                                            printProductColorSizes(CInt(dgProductColorSizesB.Rows(p).Cells("pb_productcolorid").Value), ifirstgroup)
                                            bsproductcodecount = bsproductcodecount + startingpage
                                        End If
                                        rowscount = rowscount - 1
                                    Next
                                Else
                                    displayProductColorSizes(CInt(dgProductColorSizesB.Rows(p).Cells("pb_productcolorid").Value))
                                    printProductColorSizes(CInt(dgProductColorSizesB.Rows(p).Cells("pb_productcolorid").Value), ifirstgroup)
                                    bsproductcodecount = bsproductcodecount + startingpage
                                End If
                            End If
                        Next
                    Next
                Else
                    MessageBox.Show("All of the products are sold out as of this moment.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("All of the products are still available as of this moment.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub printProductColorSizes(ByVal iproductid As Integer, ByVal efirstgroup As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT " & efirstgroup & "COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.`size`,'')," & _
                        "COALESCE(pcs.seasoncode,''),COALESCE(pcs.`sku`,''),pil.productcolorsizeid FROM productinventorylocation pil LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid " & _
                        "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
                        "LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN categories ca ON p.categoryid = ca.rowid " & _
                        "WHERE pil.organizationid = " & Z_OrganizationID & " AND pc.rowid = " & iproductid & " GROUP BY pil.productcolorsizeid ORDER BY p.productcode,c.colorname,pcs.`size` "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyAvailableA(CInt(reader1(6)), Me)
                    printdataset.AddSetDRow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(2)), CStr(reader1(3)), CStr(reader1(4)), Format(globaltotalqtyavailable, "#,##0"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
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
                PrimaryForm.BrkSzsForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboFilterBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterBy.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cboFilterBy.Text = "" Then
                cboFilterPhrase.Items.Clear() : cboFilterPhrase.AutoCompleteCustomSource.Clear()
            ElseIf cboFilterBy.Text = "ProductCode" Then
                globalautocompleteByProductCode(cboFilterPhrase, Me)
                globalautopopulateByProductCode(cboFilterPhrase, Me)
            ElseIf cboFilterBy.Text = "BrandName" Then
                globalautocompleteBrandName(cboFilterPhrase, "AND b.`status` = 'Active'", Me)
                globalautopopulateBrandName(cboFilterPhrase, "AND b.`status` = 'Active'", Me)
            ElseIf cboFilterBy.Text = "Category" Then
                globalautocompleteCategory(cboFilterPhrase, "AND c.`status` = 'Active'", Me)
                globalautopopulateCategory(cboFilterPhrase, "AND c.`status` = 'Active'", Me)
            End If
            cboFilterPhrase.Text = "" : cboFilterPhrase.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If chkAll.Checked = legit Then
                cboFilterBy.Enabled = fraud
                cboFilterPhrase.Enabled = fraud
                cboFilterBy.Text = "" : cboFilterBy.SelectedItem = Nothing
                cboFilterPhrase.Text = "" : cboFilterPhrase.SelectedItem = Nothing
            Else
                cboFilterBy.Enabled = legit
                cboFilterPhrase.Enabled = legit
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Broken Sizes", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.BrkSzsForm = False
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
            If chkAll.Checked <> legit Then
                If cboFilterBy.Text = "" Then
                    errProvider.SetError(cboFilterBy, "Please choose the filter option.")
                    cboFilterBy.Focus()
                    Exit Try
                ElseIf LTrim(cboFilterPhrase.Text) = "" Then
                    errProvider.SetError(cboFilterPhrase, "Please fill-up this box.")
                    cboFilterPhrase.Focus()
                    Exit Try
                ElseIf cboFilterBy.Text = "ProductCode" Then
                    getProductIDB(cboFilterPhrase.Text, Me)
                    bsproductid = globalproductid
                    If bsproductid = 0 Then
                        errProvider.SetError(cboFilterPhrase, "System cannot find the product code.")
                        cboFilterPhrase.Focus()
                        Exit Try
                    End If
                ElseIf cboFilterBy.Text = "BrandName" Then
                    getBrandID(cboFilterPhrase.Text, Me)
                    bsbrandid = globalbrandid
                    If bsbrandid = 0 Then
                        errProvider.SetError(cboFilterPhrase, "System cannot find the brand name.")
                        cboFilterPhrase.Focus()
                        Exit Try
                    End If
                ElseIf cboFilterBy.Text = "Category" Then
                    getCategoryID(cboFilterPhrase.Text, "", Me)
                    bscategoryid = globalcategoryid
                    If bscategoryid = 0 Then
                        errProvider.SetError(cboFilterPhrase, "System cannot find the category.")
                        cboFilterPhrase.Focus()
                        Exit Try
                    End If
                End If
            End If
            If chkAll.Checked = legit Then
                bsconditionstring = ""
            Else
                If cboFilterBy.Text = "ProductCode" Then
                    bsconditionstring = "AND p.rowid = " & bsproductid & ""
                ElseIf cboFilterBy.Text = "BrandName" Then
                    bsconditionstring = "AND p.brandid = " & bsbrandid & ""
                ElseIf cboFilterBy.Text = "Category" Then
                    bsconditionstring = "AND p.categoryid = " & bscategoryid & ""
                End If
            End If
            displayBrokenSizes(bsconditionstring)
            groupProductID()
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
                getPositionView(globalpositionid, "Broken Sizes", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.BrkSzsForm = False
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
            If chkAll.Checked <> legit Then
                If cboFilterBy.Text = "" Then
                    errProvider.SetError(cboFilterBy, "Please choose the filter option.")
                    cboFilterBy.Focus()
                    Exit Try
                ElseIf LTrim(cboFilterPhrase.Text) = "" Then
                    errProvider.SetError(cboFilterPhrase, "Please fill-up this box.")
                    cboFilterPhrase.Focus()
                    Exit Try
                ElseIf cboFilterBy.Text = "ProductCode" Then
                    getProductIDB(cboFilterPhrase.Text, Me)
                    bsproductid = globalproductid
                    If bsproductid = 0 Then
                        errProvider.SetError(cboFilterPhrase, "System cannot find the product code.")
                        cboFilterPhrase.Focus()
                        Exit Try
                    End If
                ElseIf cboFilterBy.Text = "BrandName" Then
                    getBrandID(cboFilterPhrase.Text, Me)
                    bsbrandid = globalbrandid
                    If bsbrandid = 0 Then
                        errProvider.SetError(cboFilterPhrase, "System cannot find the brand name.")
                        cboFilterPhrase.Focus()
                        Exit Try
                    End If
                ElseIf cboFilterBy.Text = "Category" Then
                    getCategoryID(cboFilterPhrase.Text, "", Me)
                    bscategoryid = globalcategoryid
                    If bscategoryid = 0 Then
                        errProvider.SetError(cboFilterPhrase, "System cannot find the category.")
                        cboFilterPhrase.Focus()
                        Exit Try
                    End If
                End If
            End If
            If chkAll.Checked = legit Then
                bsconditionstring = ""
            Else
                If cboFilterBy.Text = "ProductCode" Then
                    bsconditionstring = "AND p.rowid = " & bsproductid & ""
                ElseIf cboFilterBy.Text = "BrandName" Then
                    bsconditionstring = "AND p.brandid = " & bsbrandid & ""
                ElseIf cboFilterBy.Text = "Category" Then
                    bsconditionstring = "AND p.categoryid = " & bscategoryid & ""
                End If
            End If
            If MessageBox.Show("Would you like to print this Broken Size Report?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                printBrokenSizes(bsconditionstring)
                If cboFilterBy.Text = "ProductCode" Then
                    printgroupProductID("p.productcode,")
                ElseIf cboFilterBy.Text = "BrandName" Then
                    printgroupProductID("b.brandname,")
                ElseIf cboFilterBy.Text = "Category" Then
                    printgroupProductID("ca.categoryname")
                End If
                Dim printreport As New BrokenSizesPrint
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
    Private Sub dgProductColorSizesA_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductColorSizesA.DataError
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
                dgProductColorSizesA.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgProductColorSizesB_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductColorSizesB.DataError
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
                dgProductColorSizesB.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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
#End Region
End Class