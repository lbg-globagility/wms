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
Public Class EditBundleItemsAForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim conn1 As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim ebioverallqtyordered, ebitotalqtydelivered, ebitotalqtypicked, itemno As Integer
    Public ebiacustomerorderid, ebiaorderitemid, ebiacustomerid As Integer
    Private Sub EditBundleItems_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            txtOverallQty.Text = ""
            autopopulateTags()
            visibleBundleItems(fraud)
            displayBundleItems(ebiacustomerorderid, ebiaorderitemid)
            overallcomputations() : colorCoding()
            getOrderStatus(ebiacustomerorderid, Me)
            If globalorderstatus = "New" Then
                msSave.Enabled = legit
            Else
                msSave.Enabled = fraud
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub EditBundleItems_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
#Region "Clear/Enable/Visible"
    Sub visibleBundleItems(ByVal visible1 As Boolean)
        Try
            bi_qtypicked.Visible = visible1
            bi_qtydelivered.Visible = visible1
            bi_qtyavailable.Visible = visible1
            bi_qtyallocated.Visible = visible1
            bi_qtyreserve.Visible = visible1
            bi_verifiedby.Visible = visible1
            bi_verifieddate.Visible = visible1
            bi_packedby.Visible = visible1
            bi_packeddate.Visible = visible1
            bi_deliveredby.Visible = visible1
            bi_delivereddate.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Computations"
    Sub getPickListOrderID(ByVal iorderid As Integer, ByVal iorderitemid As Integer)
        Try
            ebitotalqtydelivered = 0 : ebitotalqtypicked = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.orderitemid = " & iorderitemid & " AND plo.orderid = " & iorderid & " AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') ")
            If dtGid.Rows.Count <> 0 Then
                getTotalQtyPicked(CInt(dtGid.Rows(0)(0)))
                getTotalQtyDelivered(CInt(dtGid.Rows(0)(0)))
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub getTotalQtyDelivered(ByVal ipicklistorderid As Integer)
        Try
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtydelivered)) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND (pli.`status` != 'Inactive' AND pli.`status` != 'Cancelled') ")
            If dtGtq.Rows.Count <> 0 Then
                ebitotalqtydelivered = dtGtq.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub getTotalQtyPicked(ByVal ipicklistorderid As Integer)
        Try
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtypicked),0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND (pli.`status` != 'Inactive' AND pli.`status` != 'Cancelled') ")
            If dtGtq.Rows.Count <> 0 Then
                ebitotalqtypicked = dtGtq.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub overallcomputations()
        Try
            ebioverallqtyordered = 0
            If dgBundleItems.Rows.Count <> 0 Then
                For i = 0 To dgBundleItems.Rows.Count - 1
                    If IsNumeric(dgBundleItems.Rows(i).Cells("bi_totalqtyorder").Value) Then
                        ebioverallqtyordered = ebioverallqtyordered + CInt(dgBundleItems.Rows(i).Cells("bi_totalqtyorder").Value)
                    End If
                Next
            End If
            txtOverallQty.Text = Format(ebioverallqtyordered, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
    Sub displayBundleItems(ByVal icustomerorderid As Integer, ByVal iorderitemid As Integer)
        Try
            dgBundleItems.Rows.Clear()
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,''),COALESCE(ci.qtyordered,0),COALESCE(ci.productcolorsizeid,0),COALESCE(ci.unitofmeasure,'')," & _
                    "COALESCE(ci.remarks,''),COALESCE(ci.status,''),COALESCE(CONCAT(COALESCE(vb.firstname,''),' ',COALESCE(vb.lastname,''),' - ',COALESCE(vb.rowid,'')),''),COALESCE(DATE_FORMAT(ci.verifieddate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(ci.packeddate,'%d-%b-%Y'),'')," & _
                    "COALESCE(CONCAT(COALESCE(pa.firstname,''),' ',COALESCE(pa.middlename,''),' ',COALESCE(pa.lastname,''),' ',COALESCE(pa.suffix,''),' - ',COALESCE(pa.contactno,'')),''),COALESCE(DATE_FORMAT(ci.delivereddate,'%d-%b-%Y'),'')," & _
                    "COALESCE(CONCAT(COALESCE(dr.firstname,''),' ',COALESCE(dr.middlename,''),' ',COALESCE(dr.lastname,''),' ',COALESCE(dr.suffix,''),' - ',COALESCE(dr.contactno,'')),''),COALESCE(ci.tags,'') FROM orderitems ci LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid " & _
                    "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN users vb ON ci.verifiedby = vb.rowid LEFT JOIN contacts pa ON ci.packedby = pa.rowid " & _
                    "LEFT JOIN contacts dr ON ci.deliveredby = dr.rowid WHERE ci.orderid = " & icustomerorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.status != 'Inactive' AND ci.orderitemid = " & iorderitemid & " AND ci.itemtype = 'BI' ORDER BY p.productcode,c.colorname "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgBundleItems.Rows.Add()
                    dgBundleItems.Item(bi_seqno.Index, n).Value = seqno
                    dgBundleItems.Item(bi_rowid.Index, n).Value = reader1(0)
                    dgBundleItems.Item(bi_colorvalue.Index, n).Value = reader1(1)
                    dgBundleItems.Item(bi_productcode.Index, n).Value = reader1(2)
                    dgBundleItems.Item(bi_colorname.Index, n).Value = reader1(3)
                    dgBundleItems.Item(bi_size.Index, n).Value = reader1(4)
                    dgBundleItems.Item(bi_seasoncode.Index, n).Value = reader1(5)
                    dgBundleItems.Item(bi_sku.Index, n).Value = reader1(6)
                    dgBundleItems.Item(bi_totalqtyorder.Index, n).Value = reader1(7)
                    getPickListOrderID(ebiacustomerorderid, CInt(reader1(0)))
                    dgBundleItems.Item(bi_qtypicked.Index, n).Value = ebitotalqtypicked
                    dgBundleItems.Item(bi_qtydelivered.Index, n).Value = ebitotalqtydelivered
                    getTotalQtyAvailableA(CInt(reader1(8)), Me)
                    dgBundleItems.Item(bi_qtyavailable.Index, n).Value = globaltotalqtyavailable
                    getTotalQtyAllocatedA(CInt(reader1(8)), Me)
                    dgBundleItems.Item(bi_qtyallocated.Index, n).Value = globaltotalqtyallocated
                    getTotalQtyOrderedA(CInt(reader1(8)), "AND oi.`status` = 'New' AND o.`status` = 'Submitted To Warehouse' AND o.ordertype = 'CO'", Me)
                    dgBundleItems.Item(bi_qtyorderable.Index, n).Value = globaltotalqtyavailable - globaltotalqtyallocated + globaltotalqtyordered
                    getTotalQtyReserveA(CInt(reader1(8)), Me)
                    dgBundleItems.Item(bi_qtyreserve.Index, n).Value = globaltotalqtyreserve
                    dgBundleItems.Item(bi_unitofmeasure.Index, n).Value = reader1(9)
                    dgBundleItems.Item(bi_remarks.Index, n).Value = reader1(10)
                    dgBundleItems.Item(bi_status.Index, n).Value = reader1(11)
                    dgBundleItems.Item(bi_verifiedby.Index, n).Value = reader1(12)
                    dgBundleItems.Item(bi_verifieddate.Index, n).Value = reader1(13)
                    dgBundleItems.Item(bi_packeddate.Index, n).Value = reader1(14)
                    dgBundleItems.Item(bi_packedby.Index, n).Value = reader1(15)
                    dgBundleItems.Item(bi_delivereddate.Index, n).Value = reader1(16)
                    dgBundleItems.Item(bi_deliveredby.Index, n).Value = reader1(17)
                    dgBundleItems.Item(bi_tags.Index, n).Value = reader1(18)
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
            dgBundleItems.Columns("bi_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_totalqtyorder").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtypicked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtydelivered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyorderable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyreserve").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_tags").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_verifieddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_delivereddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgBundleItems.Rows.Count <> 0 Then
                dgBundleItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub
    Sub autopopulateTags()
        Try
            bi_tags.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT lic FROM listofvalues WHERE type = 'Tags' ORDER BY lic "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                bi_tags.Items.Add(reader1(0).ToString())
            End While
            bi_tags.Items.Add("")
            reader1.Close()
            conn.Close()
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
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region
    Private Sub chkOtherInfo_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtherInfo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If chkOtherInfo.Checked = legit Then
                visibleBundleItems(legit)
            Else
                visibleBundleItems(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgBundleItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgBundleItems.CellEndEdit
        Try
            overallcomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgBundleItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgBundleItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgBundleItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgBundleItems.BeginEdit(True)
                Else
                    dgBundleItems.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgBundleItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBundleItems.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgBundleItems.Rows.Count <> 0 Then
                If e.ColumnIndex = dgBundleItems.Columns("bi_option").Index Then
                    getOrderStatus(ebiacustomerorderid, Me)
                    If globalorderstatus = "New" Then
                        If MessageBox.Show("Would you like to delete this item from this list?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Me.Cursor = Cursors.WaitCursor
                            getOrderStatus(ebiacustomerorderid, Me)
                            If globalorderstatus <> "New" Then
                                MessageBox.Show("This customer order has been updated by other user.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                            U_OrderItemStatus(CInt(dgBundleItems.CurrentRow.Cells("bi_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                            If myModule.systemerrorfound = False Then
                                If dgBundleItems.SelectedRows.Count > 0 Then
                                    dgBundleItems.Rows.Remove(dgBundleItems.SelectedRows(0))
                                End If
                                myBalloon("Successfully Deleted", "Delete", lblsavemsg, -15, -65)
                            End If
                            itemno = startingpage
                            For i As Integer = 0 To dgBundleItems.Rows.Count - 1
                                dgBundleItems.Rows(i).Cells("bi_seqno").Value = itemno
                                itemno = itemno + 1
                            Next i
                        End If
                    Else
                        MessageBox.Show("This customer order has been updated by other user.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
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
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            dgBundleItems.CommitEdit(legit) : dgBundleItems.ClearSelection() : dgBundleItems.CurrentCell = Nothing
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
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
            getOrderStatus(ebiacustomerorderid, Me)
            If globalorderstatus <> "New" Then
                MessageBox.Show("This customer order has been updated by other user.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getOrderStatus(ebiacustomerorderid, Me)
                If globalorderstatus <> "New" Then
                    MessageBox.Show("This customer order has been updated by other user.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgBundleItems.Rows.Count <> 0 Then
                    For a = 0 To dgBundleItems.Rows.Count - 1
                        U_OrderItems(CInt(dgBundleItems.Rows(a).Cells("bi_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, ebiacustomerid, If(IsNumeric(dgBundleItems.Rows(a).Cells("bi_totalqtyorder").Value), CInt(dgBundleItems.Rows(a).Cells("bi_totalqtyorder").Value), 0.0), _
                            0.0, CStr(dgBundleItems.Rows(a).Cells("bi_sku").Value), CStr(dgBundleItems.Rows(a).Cells("bi_unitofmeasure").Value), CStr(dgBundleItems.Rows(a).Cells("bi_remarks").Value), CStr(dgBundleItems.Rows(a).Cells("bi_tags").Value), Me)
                    Next
                End If
                If myModule.systemerrorfound = False Then
                    myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
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
#End Region
End Class