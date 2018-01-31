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
Public Class EditBundleItemsBForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim plnewpicklist As New ArrayList
    Dim sqlquery As String
    Dim ebipicklistorderid, ebitotalqtytopick, ebitotalqtyordered, ebitotalqtytopicksum, ebiqtytopicksum, ebiqtytopick As Integer
    Public ebibpicklistid, ebibcustomerorderid, ebiorderitemid, ebibinventorylocationid, ebibpicklistorderid, ebibpicklistorderitemid As Integer
    Private Sub EditBundleItemsBForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            txtTotalQtyOrdered.Text = ""
            txtTotalQtyToPick.Text = ""
            txtQtyToPick.Text = ""
            displayBundleItems(ebibpicklistid, ebibcustomerorderid, ebiorderitemid)
            bundleitemsrsccomputations() : colorCoding()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub EditBundleItemsBForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
#Region "Computations"
    Sub getTotalQtyToPicked(ByVal ipicklistorderid As Integer)
        Try
            ebitotalqtytopick = 0
            If conn1.State = ConnectionState.Open Then conn1.Close()
            Dim dtTQo As New DataTable
            dtTQo = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtypicked),0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND pli.status != 'Inactive' ")
            If dtTQo.Rows.Count <> 0 Then
                ebitotalqtytopick = dtTQo.Rows(0)(0)
            Else
                ebitotalqtytopick = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub
    Sub getTotalQtyToPickRSC(ByVal ipicklistorderid As Integer, ByVal iproductinventorylocationid As Integer)
        Try
            ebiqtytopick = 0
            If conn1.State = ConnectionState.Open Then conn1.Close()
            Dim dtTQo As New DataTable
            dtTQo = getDataTableForSQL("SELECT COALESCE(pli.qtypicked,0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND pli.productinventorylocationid = " & iproductinventorylocationid & " AND pli.status != 'Inactive' ")
            If dtTQo.Rows.Count <> 0 Then
                ebiqtytopick = dtTQo.Rows(0)(0)
            Else
                ebiqtytopick = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub
    Sub bundleitemsrsccomputations()
        Try
            ebitotalqtyordered = 0 : ebitotalqtytopicksum = 0 : ebiqtytopicksum = 0
            If dgBundleItems.Rows.Count <> 0 Then
                For i = 0 To dgBundleItems.Rows.Count - 1
                    If IsNumeric(dgBundleItems.Rows(i).Cells("bi_qtyordered").Value) Then
                        ebitotalqtyordered = ebitotalqtyordered + CInt(dgBundleItems.Rows(i).Cells("bi_qtyordered").Value)
                    End If
                    If IsNumeric(dgBundleItems.Rows(i).Cells("bi_totalqtytopick").Value) Then
                        ebitotalqtytopicksum = ebitotalqtytopicksum + CInt(dgBundleItems.Rows(i).Cells("bi_totalqtytopick").Value)
                    End If
                Next
            End If
            If dgRackShelfColumn.Rows.Count <> 0 Then
                For i = 0 To dgRackShelfColumn.Rows.Count - 1
                    If IsNumeric(dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Value) Then
                        ebiqtytopicksum = ebiqtytopicksum + CInt(dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Value)
                    End If
                Next
            End If
            txtTotalQtyOrdered.Text = Format(ebitotalqtyordered, "#,##0")
            txtTotalQtyToPick.Text = Format(ebitotalqtytopicksum, "#,##0")
            txtQtyToPick.Text = Format(ebiqtytopicksum, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "Datagrids"
    Sub displayBundleItems(ByVal ipicklistid As Integer, ByVal icustomerorderid As Integer, ByVal iorderitemid As Integer)
        Try
            dgBundleItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT bi.rowid,COALESCE(bi.productcolorsizeid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,'')," & _
                    "COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(bi.qtyordered,0),COALESCE(pcs.sku,''),COALESCE(bi.unitofmeasure,''),COALESCE(bi.remarks,'')," & _
                    "(SELECT plo.status FROM picklistorders plo WHERE plo.picklistid = " & ipicklistid & " AND plo.orderid = " & icustomerorderid & " AND plo.organizationid = " & Z_OrganizationID & " AND plo.orderitemid = bi.rowid)," & _
                    "COALESCE(CONCAT(COALESCE(vb.firstname,''),' ',COALESCE(vb.lastname,''),' - ',COALESCE(vb.rowid,'')),''),COALESCE(DATE_FORMAT(bi.verifieddate,'%d-%b-%Y'),'') FROM orderitems bi LEFT JOIN productcolorsizes pcs ON bi.productcolorsizeid = pcs.rowid " & _
                    "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN users vb ON bi.verifiedby = vb.rowid WHERE bi.orderid = " & icustomerorderid & " " & _
                    "AND bi.organizationid = " & Z_OrganizationID & " AND bi.status != 'Inactive' AND bi.orderitemid = " & iorderitemid & " AND bi.itemtype = 'BI' ORDER BY p.productcode,c.colorname "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgBundleItems.Rows.Add()
                    dgBundleItems.Item(bi_seqno.Index, n).Value = seqno
                    dgBundleItems.Item(bi_rowid.Index, n).Value = reader1(0)
                    dgBundleItems.Item(bi_pcsrowid.Index, n).Value = reader1(1)
                    dgBundleItems.Item(bi_colorvalue.Index, n).Value = reader1(2)
                    dgBundleItems.Item(bi_productcode.Index, n).Value = reader1(3)
                    dgBundleItems.Item(bi_colorname.Index, n).Value = reader1(4)
                    dgBundleItems.Item(bi_size.Index, n).Value = reader1(5)
                    dgBundleItems.Item(bi_seasoncode.Index, n).Value = reader1(6)
                    dgBundleItems.Item(bi_qtyordered.Index, n).Value = reader1(7)
                    getPickListOrderID(ebibpicklistid, icustomerorderid, CInt(reader1(0)), Me)
                    ebipicklistorderid = globalpicklistorderid : getTotalQtyToPicked(ebipicklistorderid)
                    dgBundleItems.Item(bi_totalqtytopick.Index, n).Value = ebitotalqtytopick
                    dgBundleItems.Item(bi_sku.Index, n).Value = reader1(8)
                    dgBundleItems.Item(bi_unitofmeasure.Index, n).Value = reader1(9)
                    dgBundleItems.Item(bi_remarks.Index, n).Value = reader1(10)
                    dgBundleItems.Item(bi_status.Index, n).Value = reader1(11)
                    dgBundleItems.Item(bi_verifiedby.Index, n).Value = reader1(12)
                    dgBundleItems.Item(bi_verifieddate.Index, n).Value = reader1(13)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgBundleItems.Columns("bi_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_totalqtytopick").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_verifieddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgBundleItems.Rows.Count <> 0 Then
                dgBundleItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayRackShelfColumn(ByVal iproductcolorsizeid As Integer, ByVal iinventorylocationid As Integer)
        Try
            dgRackShelfColumn.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pil.rowid,COALESCE(rsc.rackno,''),COALESCE(rsc.shelfno,''),COALESCE(rsc.columnno,''),COALESCE(pil.totalavailableqty,0),COALESCE(rsc.pickorderno,0),COALESCE(pil.totalallocatedqty,0) " & _
                            "FROM productinventorylocation pil LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid WHERE pil.organizationid = " & Z_OrganizationID & " " & _
                            "AND pil.productcolorsizeid = " & iproductcolorsizeid & "  AND rsc.inventorylocationid = " & iinventorylocationid & " ORDER BY rsc.pickorderno ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgRackShelfColumn.Rows.Add()
                    dgRackShelfColumn.Item(rsc_rowid.Index, n).Value = reader1(0)
                    dgRackShelfColumn.Item(rsc_rack.Index, n).Value = reader1(1)
                    dgRackShelfColumn.Item(rsc_shelf.Index, n).Value = reader1(2)
                    dgRackShelfColumn.Item(rsc_column.Index, n).Value = reader1(3)
                    getPickListOrderID(ebibpicklistid, ebibcustomerorderid, CInt(dgBundleItems.CurrentRow.Cells("bi_rowid").Value), Me)
                    ebibpicklistorderid = globalpicklistorderid
                    getTotalQtyToPickRSC(ebibpicklistorderid, CInt(reader1(0)))
                    getPickListOrderItemInfo(ebibpicklistorderid, CInt(reader1(0)), Me)
                    dgRackShelfColumn.Item(rsc_qtytopick.Index, n).Value = ebiqtytopick
                    dgRackShelfColumn.Item(rsc_qtyavailable.Index, n).Value = CInt(reader1(4))
                    dgRackShelfColumn.Item(rsc_pickorderno.Index, n).Value = CInt(reader1(5))
                    dgRackShelfColumn.Item(rsc_qtyallocated.Index, n).Value = CInt(reader1(6))
                    dgRackShelfColumn.Item(rsc_qtyorderable.Index, n).Value = CInt(reader1(4)) - CInt(reader1(6))
                    If globalpicklistorderitemissueflg = "Y" Then
                        dgRackShelfColumn.Item(rsc_issueflg.Index, n).Value = legit
                    Else
                        dgRackShelfColumn.Item(rsc_issueflg.Index, n).Value = fraud
                    End If
                    dgRackShelfColumn.Item(rsc_remarks.Index, n).Value = globalpicklistorderitemremarks
                    n = n + 1
                End If
            End While
            reader1.Close()
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
    End Sub
#End Region
#Region "Colors"
    Sub colorCoding()
        Try
            If dgBundleItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgBundleItems.Rows.Count - 1
                    If CStr(dgBundleItems.Rows(i).Cells("bi_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgBundleItems.Rows(i).Cells("bi_colorvalue").Value))
                        dgBundleItems.Rows(i).Cells("bi_color").Style.BackColor = readcolor
                    End If
                Next
            End If
            If dgRackShelfColumn.Rows.Count <> 0 Then
                For i As Integer = 0 To dgRackShelfColumn.Rows.Count - 1
                    dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Style.BackColor = Color.Gainsboro
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
#End Region
    Private Sub dgBundleItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBundleItems.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBundleItems.Rows.Count <> 0 Then
                errProvider.Clear()
                displayRackShelfColumn(CInt(dgBundleItems.CurrentRow.Cells("bi_pcsrowid").Value), ebibinventorylocationid)
                colorCoding() : bundleitemsrsccomputations()
                getPickListOrderStatus(ebibpicklistid, ebibcustomerorderid, CInt(dgBundleItems.CurrentRow.Cells("bi_rowid").Value), Me)
                If globalpicklistorderstatus = "New" Then
                    msSaveRSC.Enabled = legit
                ElseIf globalpicklistorderstatus = "Modified" Then
                    msSaveRSC.Enabled = legit
                Else
                    msSaveRSC.Enabled = fraud
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgBundleItems_KeyUp(sender As Object, e As KeyEventArgs) Handles dgBundleItems.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBundleItems.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    errProvider.Clear()
                    displayRackShelfColumn(CInt(dgBundleItems.CurrentRow.Cells("bi_pcsrowid").Value), ebibinventorylocationid)
                    colorCoding() : bundleitemsrsccomputations()
                    getPickListOrderStatus(ebibpicklistid, ebibcustomerorderid, CInt(dgBundleItems.CurrentRow.Cells("bi_rowid").Value), Me)
                    If globalpicklistorderstatus = "New" Then
                        msSaveRSC.Enabled = legit
                    ElseIf globalpicklistorderstatus = "Modified" Then
                        msSaveRSC.Enabled = legit
                    Else
                        msSaveRSC.Enabled = fraud
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
    Private Sub dgRackShelfColumn_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgRackShelfColumn.CellEndEdit
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            bundleitemsrsccomputations()
            If dgBundleItems.Rows.Count <> 0 Then
                If IsNumeric(dgBundleItems.CurrentRow.Cells("bi_qtyordered").Value) Then
                    If CInt(dgBundleItems.CurrentRow.Cells("bi_qtyordered").Value) < ebiqtytopicksum Then
                        errProvider.SetError(txtQtyToPick, "Qty. Ordered should not be less than to Total Qty. To Pick")
                    End If
                End If
            End If
            'If dgRackShelfColumn.Rows.Count <> 0 Then
            '    For i = 0 To dgRackShelfColumn.Rows.Count - 1
            '        If IsNumeric(dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Value) Then
            '            If CInt(dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Value) > CInt(dgRackShelfColumn.Rows(i).Cells("rsc_qtyallocated").Value) Then
            '                dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").ErrorText = "Qty. To Pick should not be greater than Qty. Allocated."
            '            Else
            '                dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").ErrorText = Nothing
            '            End If
            '        Else
            '            dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").ErrorText = Nothing
            '        End If
            '    Next
            'End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
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
    Private Sub msSaveRSC_Click(sender As Object, e As EventArgs) Handles msSaveRSC.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List", Me)
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
            bundleitemsrsccomputations()
            dgRackShelfColumn.CommitEdit(legit) : dgRackShelfColumn.ClearSelection() : dgRackShelfColumn.CurrentCell = Nothing
            If dgBundleItems.Rows.Count <> 0 Then
                If IsNumeric(dgBundleItems.CurrentRow.Cells("bi_qtyordered").Value) Then
                    If CInt(dgBundleItems.CurrentRow.Cells("bi_qtyordered").Value) < ebiqtytopicksum Then
                        errProvider.SetError(txtQtyToPick, "Qty. Ordered should not be less than to Total Qty. To Pick")
                        Exit Try
                    End If
                    getPickListOrderID(ebibpicklistid, ebibcustomerorderid, CInt(dgBundleItems.CurrentRow.Cells("bi_rowid").Value), Me)
                    ebibpicklistorderid = globalpicklistorderid
                    If ebibpicklistorderid = 0 Then
                        errProvider.SetError(txtQtyToPick, "System cannot find the Pick List, Customer Order and Customer Order Item to be updated.")
                        Exit Try
                    End If
                End If
            Else
                errProvider.SetError(txtTotalQtyToPick, "System cannot find the Bundle Item(s) to be updated.")
                Exit Try
            End If
            If dgRackShelfColumn.Rows.Count = 0 Then
                MessageBox.Show("There is nothing to save in the Rack / Column / Shelf assignment.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            Else
                'For i = 0 To dgRackShelfColumn.Rows.Count - 1
                '    If IsNumeric(dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Value) Then
                '        If CInt(dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").Value) > CInt(dgRackShelfColumn.Rows(i).Cells("rsc_qtyallocated").Value) Then
                '            dgRackShelfColumn.Rows(i).Cells("rsc_qtytopick").ErrorText = "Qty. To Pick should not be greater than Qty. Allocated."
                '            Exit Try
                '        End If
                '    End If
                'Next
            End If
            getPickListOrderStatus(ebibpicklistid, ebibcustomerorderid, CInt(dgBundleItems.CurrentRow.Cells("bi_rowid").Value), Me)
            If globalpicklistorderstatus <> "New" Then
                If globalpicklistorderstatus <> "Modified" Then
                    MessageBox.Show("This bundle item has been updated by other user, please close this form and open it again to check the status.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            If MessageBox.Show("Would you like to save the changes in the Rack / Column / Shelf assignment?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getPickListOrderStatus(ebibpicklistid, ebibcustomerorderid, CInt(dgBundleItems.CurrentRow.Cells("bi_rowid").Value), Me)
                If globalpicklistorderstatus <> "New" Then
                    If globalpicklistorderstatus <> "Modified" Then
                        MessageBox.Show("This bundle item has been updated by other user, please close this form and open it again to check the status.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                End If
                For a = 0 To dgRackShelfColumn.Rows.Count - 1
                    If myModule.systemerrorfound = False Then
                        If IsNumeric(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) Then
                            getPickListOrderItemID(ebibpicklistorderid, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Me)
                            ebibpicklistorderitemid = globalpicklistorderitemid
                            getPickListOrderItemInfo(ebibpicklistorderid, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Me)
                            getTotalQtyAvailableC(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Me)
                            getTotalQtyAllocatedC(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Me)
                            If CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) < CInt(dgBundleItems.CurrentRow.Cells("bi_qtyordered").Value) Then
                                If ebibpicklistorderitemid = 0 Then
                                    I_PickListOrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, ebibpicklistorderid, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value), _
                                        If(IsNumeric(dgRackShelfColumn.Rows(a).Cells("rsc_qtyavailable").Value), CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtyavailable").Value), 0), If(dgRackShelfColumn.Rows(a).Cells("rsc_issueflg").Value = legit, "Y", "N"), "Active", CStr(dgRackShelfColumn.Rows(a).Cells("rsc_remarks").Value), Me)
                                    U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated + CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value), Me)
                                Else
                                    If globalpicklistorderitemqtypicked > CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) Then
                                        U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated - (globalpicklistorderitemqtypicked - CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value)), Me)
                                    ElseIf globalpicklistorderitemqtypicked < CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) Then
                                        U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated + (CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) - globalpicklistorderitemqtypicked), Me)
                                    End If
                                    U_PickListOrderItems(ebibpicklistorderitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value), If(IsNumeric(dgRackShelfColumn.Rows(a).Cells("rsc_qtyavailable").Value), CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtyavailable").Value), 0), _
                                        If(dgRackShelfColumn.Rows(a).Cells("rsc_issueflg").Value = legit, "Y", "N"), CStr(dgRackShelfColumn.Rows(a).Cells("rsc_remarks").Value), Me)
                                End If
                            ElseIf CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) = CInt(dgBundleItems.CurrentRow.Cells("bi_qtyordered").Value) Then
                                If ebibpicklistorderitemid = 0 Then
                                    I_PickListOrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, ebibpicklistorderid, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value), _
                                        If(IsNumeric(dgRackShelfColumn.Rows(a).Cells("rsc_qtyavailable").Value), CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtyavailable").Value), 0), If(dgRackShelfColumn.Rows(a).Cells("rsc_issueflg").Value = legit, "Y", "N"), "Active", CStr(dgRackShelfColumn.Rows(a).Cells("rsc_remarks").Value), Me)
                                    U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated + CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value), Me)
                                Else
                                    If globalpicklistorderitemqtypicked > CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) Then
                                        U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated - (globalpicklistorderitemqtypicked - CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value)), Me)
                                    ElseIf globalpicklistorderitemqtypicked < CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) Then
                                        U_ProductInventoryLocationQtyAllocated(CInt(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated + (CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value) - globalpicklistorderitemqtypicked), Me)
                                    End If
                                    U_PickListOrderItems(ebibpicklistorderitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtytopick").Value), If(IsNumeric(dgRackShelfColumn.Rows(a).Cells("rsc_qtyavailable").Value), CInt(dgRackShelfColumn.Rows(a).Cells("rsc_qtyavailable").Value), 0), _
                                        If(dgRackShelfColumn.Rows(a).Cells("rsc_issueflg").Value = legit, "Y", "N"), CStr(dgRackShelfColumn.Rows(a).Cells("rsc_remarks").Value), Me)
                                End If
                            End If
                        End If
                    Else
                        Exit Try
                    End If
                Next
                If myModule.systemerrorfound = False Then
                    U_PickListOrderStatus(ebibpicklistorderid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Modified", Me)
                    U_PickListOrderModifiedFlg(ebibpicklistorderid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Y", Me)
                    getPickListStatus(ebibpicklistid, Me)
                    U_PickListStatus(ebibpicklistid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(globalpickliststatus = "New", "Modified", globalpickliststatus), Me)
                End If
                If myModule.systemerrorfound = False Then
                    myBalloon("Successfully Save Rack / Column / Shelf assignment.", "Save", lblsavemsg, -15, -65)
                    dgRackShelfColumn.Rows.Clear()
                    displayBundleItems(ebibpicklistid, ebibcustomerorderid, ebiorderitemid)
                    bundleitemsrsccomputations() : colorCoding()
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
    Private Sub dgBundleItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgBundleItems.DataError
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
                dgBundleItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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
End Class