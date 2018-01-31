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
Public Class AddToCartonForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim itemno, rowscount As Integer
    Dim atcqtytopackerrorcue As Boolean
    Dim atcpackinglistcartonid, atccontactid, atcpackinglistcartonitemid As Integer
    Dim atctotalqtypicked, atctotalqtyincartonsum, atcqtytopacksum, atctotalqtyincarton, atcqtypicked As Integer
    Public addtocartonformcue As Boolean = False
    Public atcpackinglistid, atcorderid, atcorderitemid As Integer
    Private Sub AddToCartonForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            getPackingListInformation(atcpackinglistid)
            If atcorderitemid <> 0 Then
                displayBundleItems(atcpackinglistid, atcorderid, atcorderitemid)
            Else
                displayCustomerOrderItems()
            End If
            colorCoding() : addtocartoncomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub AddToCartonForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , pbAutoAddA, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoCompleteFunctions()
        globalautocompleteCartonNos(cboCartonNo, atcpackinglistid, Me)
        globalautocompleteContactName(cboPackerName, "Packer", Me)
        globalautocompleteSizeInfo(cboSizeInfo, Me)
        globalautocompleteListOfValues(cboWeightUOM, "Unit Of Measure", Me)
    End Sub
    Sub callAutoPopulateFunctions()
        globalautopopulateCartonNos(cboCartonNo, atcpackinglistid, Me)
        globalautopopulateContactName(cboPackerName, "Packer", Me)
        globalautopopulateSizeInfo(cboSizeInfo, Me)
        globalautopopulateListOfValues(cboWeightUOM, "Unit Of Measure", Me)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            clearAddToCartonInformation()
            clearExistingCarton(fraud)
            clearAddNewCarton(fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearAddToCartonInformation()
        Try
            txtPackingListNo.Text = ""
            txtCustomerOrderInfo.Text = ""
            txtTotalItems.Text = ""
            txtTotalQtyPicked.Text = ""
            txtTotalQtyInCartonSum.Text = ""
            rbtnExistingCarton.Checked = fraud
            rbtnAddNewCarton.Checked = fraud
            chkPackAll.Checked = fraud
            dtpPackedDate.Value = Now.Date
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearExistingCarton(ByVal ivisible As Boolean)
        Try
            lblCartonNoE.Visible = ivisible
            lblCartonNoAsteriskE.Visible = ivisible
            cboCartonNo.Visible = ivisible
            cboCartonNo.Text = ""
            cboCartonNo.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearAddNewCarton(ByVal ivisible As Boolean)
        Try
            lblCartonNoA.Visible = ivisible
            lblCartonNoAsteriskA.Visible = ivisible
            txtCartonNo.Visible = ivisible
            lblPackerName.Visible = ivisible
            cboPackerName.Visible = ivisible
            pbAddPacker.Visible = ivisible
            pbAutoAddA.Visible = ivisible
            lblPackedDate.Visible = ivisible
            dtpPackedDate.Visible = ivisible
            cboSizeInfo.Visible = ivisible
            txtWeight.Visible = ivisible
            cboWeightUOM.Visible = ivisible
            txtAmount.Visible = ivisible
            lblWeight.Visible = ivisible
            lblWeightUOM.Visible = ivisible
            lblSizeInfo.Visible = ivisible
            pbAddSize.Visible = ivisible
            lblAmount.Visible = ivisible
            lblPesoSign.Visible = ivisible
            txtCartonNo.Text = ""
            cboPackerName.Text = ""
            cboSizeInfo.Text = ""
            txtWeight.Text = "2"
            txtAmount.Text = ""
            cboPackerName.SelectedItem = Nothing
            cboSizeInfo.SelectedItem = Nothing
            cboWeightUOM.SelectedItem = Nothing
            cboWeightUOM.Text = "kg"
            dtpPackedDate.Value = Now.Date
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
            atcqtypicked = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.orderitemid = " & iorderitemid & " AND plo.orderid = " & iorderid & " AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') ")
            If dtGid.Rows.Count <> 0 Then
                getTotalQtyPicked(CInt(dtGid.Rows(0)(0)))
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
                atcqtypicked = dtGtq.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub getTotalQtyInCarton(ByVal ipackinglistid As Integer, ByVal iorderitemid As Integer)
        Try
            atctotalqtyincarton = 0
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pci.qtyincarton),0) FROM packinglistcartonitems pci LEFT JOIN packinglistcartons pc ON pci.packinglistcartonid = pc.rowid WHERE pc.packinglistid = " & ipackinglistid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' AND pci.orderitemid = " & iorderitemid & " ")
            If dtGtq.Rows.Count <> 0 Then
                atctotalqtyincarton = dtGtq.Rows(0)(0)
            Else
                atctotalqtyincarton = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub updatetotalqtyincarton()
        Try
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                    getTotalQtyInCarton(atcpackinglistid, CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value))
                    If If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), 0) <> atctotalqtyincarton Then
                        dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").ErrorText = "The Total Qty. In Carton has been updated, and the system has automatically updated the value from " & dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value & " to " & atctotalqtyincarton & ". "
                        dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value = atctotalqtyincarton
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub addtocartoncomputations()
        Try
            atctotalqtypicked = 0 : atctotalqtyincartonsum = 0 : atcqtytopacksum = 0 : atcqtytopackerrorcue = fraud
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value) Then
                        atctotalqtypicked = atctotalqtypicked + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value)
                    End If
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value) Then
                        atctotalqtyincartonsum = atctotalqtyincartonsum + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value)
                    End If
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value) Then
                        atcqtytopacksum = atcqtytopacksum + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value)
                        If If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), 0) < If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), 0) + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value) Then
                            dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").ErrorText = "Qty. Picked is less than Total Qty. In Carton plus(+) Qty. To Pack."
                            atcqtytopackerrorcue = legit
                        Else
                            dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").ErrorText = Nothing
                        End If
                    End If
                Next
            End If
            txtTotalItems.Text = dgCustomerOrderItems.Rows.Count
            txtTotalQtyPicked.Text = Format(atctotalqtypicked, "#,##0")
            txtTotalQtyInCartonSum.Text = Format(atctotalqtyincartonsum + atcqtytopacksum, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "Information"
    Sub getPackingListInformation(ByVal ipackinglistid As Integer)
        Try
            txtPackingListNo.Text = "" : txtCustomerOrderInfo.Text = ""
            Dim dtGinfo As New DataTable
            dtGinfo = getDataTableForSQL("SELECT COALESCE(pal.packinglistno,''),COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'') FROM packinglist pal LEFT JOIN orders o ON pal.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid WHERE pal.rowid = " & ipackinglistid & " ")
            If dtGinfo.Rows.Count <> 0 Then
                txtPackingListNo.Text = dtGinfo.Rows(0)(0)
                txtCustomerOrderInfo.Text = dtGinfo.Rows(0)(1)
            Else
                txtPackingListNo.Text = "" : txtCustomerOrderInfo.Text = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
#End Region
#Region "Datagrids"
    Sub displayCustomerOrderItems()
        Try
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                dgCustomerOrderItems.CurrentRow.Selected = False
                dgCustomerOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_qtypicked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_totalqtyincarton").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_qtytopack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_tags").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgCustomerOrderItems.Columns("ci_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                itemno = startingpage
                For i As Integer = 0 To dgCustomerOrderItems.Rows.Count - 1
                    dgCustomerOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayBundleItems(ByVal epackinglistid As Integer, ByVal icustomerorderid As Integer, ByVal iorderitemid As Integer)
        Try
            dgCustomerOrderItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT bi.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(bi.qtyordered,0),COALESCE(bi.`status`,''),COALESCE(pcs.sku,''),COALESCE(bi.unitofmeasure,''),COALESCE(bi.remarks,'')," & _
                    "COALESCE(CONCAT(COALESCE(pa.firstname,''),' ',COALESCE(pa.middlename,''),' ',COALESCE(pa.lastname,''),' ',COALESCE(pa.suffix,''),' - ',COALESCE(pa.contactno,'')),''),COALESCE(DATE_FORMAT(bi.packeddate,'%d-%b-%Y'),''),COALESCE(bi.tags,'') FROM orderitems bi LEFT JOIN productcolorsizes pcs ON bi.productcolorsizeid = pcs.rowid " & _
                    "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN contacts pa ON bi.packedby = pa.rowid WHERE bi.orderid = " & icustomerorderid & " " & _
                    "AND bi.organizationid = " & Z_OrganizationID & " AND bi.status != 'Inactive' AND bi.orderitemid = " & iorderitemid & " AND bi.itemtype = 'BI' ORDER BY p.productcode,c.colorname,pcs.size "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgCustomerOrderItems.Rows.Add()
                    dgCustomerOrderItems.Item(ci_seqno.Index, n).Value = seqno
                    dgCustomerOrderItems.Item(ci_rowid.Index, n).Value = reader1(0)
                    dgCustomerOrderItems.Item(ci_colorvalue.Index, n).Value = reader1(1)
                    dgCustomerOrderItems.Item(ci_productcode.Index, n).Value = reader1(2)
                    dgCustomerOrderItems.Item(ci_colorname.Index, n).Value = reader1(3)
                    dgCustomerOrderItems.Item(ci_color.Index, n).Value = ""
                    dgCustomerOrderItems.Item(ci_size.Index, n).Value = reader1(4)
                    dgCustomerOrderItems.Item(ci_seasoncode.Index, n).Value = reader1(5)
                    dgCustomerOrderItems.Item(ci_qtyordered.Index, n).Value = reader1(6)
                    getPickListOrderID(icustomerorderid, CInt(reader1(0)))
                    dgCustomerOrderItems.Item(ci_qtypicked.Index, n).Value = atcqtypicked
                    getTotalQtyInCarton(epackinglistid, CInt(reader1(0)))
                    dgCustomerOrderItems.Item(ci_totalqtyincarton.Index, n).Value = atctotalqtyincarton
                    dgCustomerOrderItems.Item(ci_qtytopack.Index, n).Value = ""
                    dgCustomerOrderItems.Item(ci_status.Index, n).Value = reader1(7)
                    dgCustomerOrderItems.Item(ci_sku.Index, n).Value = reader1(8)
                    dgCustomerOrderItems.Item(ci_unitofmeasure.Index, n).Value = reader1(9)
                    dgCustomerOrderItems.Item(ci_remarks.Index, n).Value = reader1(10)
                    dgCustomerOrderItems.Item(ci_packedby.Index, n).Value = reader1(11)
                    dgCustomerOrderItems.Item(ci_packeddate.Index, n).Value = reader1(12)
                    dgCustomerOrderItems.Item(ci_tags.Index, n).Value = reader1(13)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtypicked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_totalqtyincarton").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtytopack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_tags").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                dgCustomerOrderItems.CurrentRow.Selected = False
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
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgCustomerOrderItems.Rows.Count - 1
                    dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Style.BackColor = Color.Gainsboro
                    If CStr(dgCustomerOrderItems.Rows(i).Cells("ci_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgCustomerOrderItems.Rows(i).Cells("ci_colorvalue").Value))
                        dgCustomerOrderItems.Rows(i).Cells("ci_color").Style.BackColor = readcolor
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
#End Region
    Private Sub rbtnExistingCarton_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnExistingCarton.CheckedChanged
        Try
            If rbtnExistingCarton.Checked = legit Then
                clearExistingCarton(legit)
            Else
                clearExistingCarton(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub rbtnAddNewCarton_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnAddNewCarton.CheckedChanged
        Try
            If rbtnAddNewCarton.Checked = legit Then
                clearAddNewCarton(legit)
                getCartonNo(atcpackinglistid, Me)
                txtCartonNo.Text = globalcartonno
            Else
                clearAddNewCarton(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgCustomerOrderItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderItems.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                getOrderItemStatus(CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                If globalorderitemstatus = "Verified" Or globalorderitemstatus = "Partially Packed" Or globalorderitemstatus = "Partially Lined Up" Then
                    If If(IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_qtypicked").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_qtypicked").Value), 0) = If(IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value), 0) Then
                        ci_qtytopack.ReadOnly = legit
                    Else
                        ci_qtytopack.ReadOnly = fraud
                    End If
                Else
                    ci_qtytopack.ReadOnly = legit
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgCustomerOrderItems_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCustomerOrderItems.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    getOrderItemStatus(CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                    If globalorderitemstatus = "Verified" Or globalorderitemstatus = "Partially Packed" Or globalorderitemstatus = "Partially Lined Up" Then
                        If If(IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_qtypicked").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_qtypicked").Value), 0) = If(IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value), 0) Then
                            ci_qtytopack.ReadOnly = legit
                        Else
                            ci_qtytopack.ReadOnly = fraud
                        End If
                    Else
                        ci_qtytopack.ReadOnly = legit
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
    Private Sub dgCustomerOrderItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderItems.CellEndEdit
        Try
            addtocartoncomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgCustomerOrderItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderItems.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If atcpackinglistid <> 0 Then
                If dgCustomerOrderItems.Rows.Count <> 0 Then
                    If e.ColumnIndex = dgCustomerOrderItems.Columns("ci_totalqtyincarton").Index Then
                        If IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value) Then
                            If CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value) <> 0 Then
                                Dim viewcartonslinkform As New ViewCartonsForm
                                viewcartonslinkform.vcpackinglistid = atcpackinglistid
                                viewcartonslinkform.vcorderitemid = CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value)
                                viewcartonslinkform.ShowInTaskbar = False
                                viewcartonslinkform.ShowDialog()
                            End If
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
    Private Sub txtCartonNo_Leave(sender As Object, e As EventArgs) Handles txtCartonNo.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(txtCartonNo.Text) <> "" Then
                getPackingListCartonIDA(atcpackinglistid, txtCartonNo.Text, "AND `status` != 'Inactive' ", Me)
                atcpackinglistcartonid = globalpackinglistcartonid
                If atcpackinglistcartonid <> 0 Then
                    errProvider.SetError(txtCartonNo, "The box no. has been created already.")
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub txtCartonNo_TextChanged(sender As Object, e As EventArgs) Handles txtCartonNo.TextChanged
    '    Try
    '        errProvider.Clear()
    '        If LTrim(txtCartonNo.Text) <> "" Then
    '            getPackingListCartonIDA(atcpackinglistid, txtCartonNo.Text, "AND `status` != 'Inactive' ", Me)
    '            atcpackinglistcartonid = globalpackinglistcartonid
    '            If atcpackinglistcartonid <> 0 Then
    '                errProvider.SetError(txtCartonNo, "The box no. has been created already.")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    Private Sub cboCartonNo_Leave(sender As Object, e As EventArgs) Handles cboCartonNo.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboCartonNo.Text) <> "" Then
                getPackingListCartonIDA(atcpackinglistid, cboCartonNo.Text, "AND `status` = 'Active' ", Me)
                atcpackinglistcartonid = globalpackinglistcartonid
                If atcpackinglistcartonid = 0 Then
                    errProvider.SetError(cboCartonNo, "The box no. might be delivered or unavailable at this moment.")
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub cboCartonNo_TextChanged(sender As Object, e As EventArgs) Handles cboCartonNo.TextChanged
    '    Try
    '        errProvider.Clear()
    '        If LTrim(cboCartonNo.Text) <> "" Then
    '            getPackingListCartonIDA(atcpackinglistid, cboCartonNo.Text, "AND `status` = 'Active' ", Me)
    '            atcpackinglistcartonid = globalpackinglistcartonid
    '            If atcpackinglistcartonid = 0 Then
    '                errProvider.SetError(cboCartonNo, "The box no. might be delivered or unavailable at this moment.")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    'Private Sub cboCartonNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCartonNo.SelectedIndexChanged
    '    Try
    '        errProvider.Clear()
    '        If LTrim(cboCartonNo.Text) <> "" Then
    '            getPackingListCartonIDA(atcpackinglistid, cboCartonNo.Text, "AND `status` = 'Active' ", Me)
    '            atcpackinglistcartonid = globalpackinglistcartonid
    '            If atcpackinglistcartonid = 0 Then
    '                errProvider.SetError(cboCartonNo, "The box no. might be delivered or unavailable at this moment.")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    Private Sub pbAddPacker_MouseEnter(sender As Object, e As EventArgs) Handles pbAddPacker.MouseEnter
        Try
            pbAddPacker.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddPacker_MouseLeave(sender As Object, e As EventArgs) Handles pbAddPacker.MouseLeave
        Try
            pbAddPacker.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddPacker_Click(sender As Object, e As EventArgs) Handles pbAddPacker.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
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
            Dim addpackerlinkform As New AddPackerForm
            addpackerlinkform.ShowInTaskbar = False
            addpackerlinkform.ShowDialog()
            If addpackerlinkform.addpackerformcue = legit Then
                globalautocompleteContactName(cboPackerName, "Packer", Me)
                globalautopopulateContactName(cboPackerName, "Packer", Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub pbAddSize_MouseEnter(sender As Object, e As EventArgs) Handles pbAddSize.MouseEnter
        Try
            pbAddSize.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddSize_MouseLeave(sender As Object, e As EventArgs) Handles pbAddSize.MouseLeave
        Try
            pbAddSize.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddSize_Click(sender As Object, e As EventArgs) Handles pbAddSize.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
                globalautocompleteSizeInfo(cboSizeInfo, Me)
                globalautopopulateSizeInfo(cboSizeInfo, Me)
            End If
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
            myBalloon("Automatic adding of unit of measure.", "Auto-Add", pbAutoAddA, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub chkPackAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkPackAll.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If chkPackAll.Checked = legit Then
                If dgCustomerOrderItems.Rows.Count <> 0 Then
                    For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                        getOrderItemStatus(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Me)
                        If globalorderitemstatus = "Verified" Or globalorderitemstatus = "Partially Packed" Or globalorderitemstatus = "Partially Lined Up" Then
                            dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value = If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), 0) - If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), 0)
                        End If
                    Next
                End If
                addtocartoncomputations()
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
            dgCustomerOrderItems.CommitEdit(legit) : dgCustomerOrderItems.ClearSelection() : dgCustomerOrderItems.CurrentCell = Nothing
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
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
            If atcpackinglistid = 0 Then
                errProvider.SetError(txtPackingListNo, "System cannot find the packing list.")
                Exit Try
            End If
            If atcorderid = 0 Then
                errProvider.SetError(txtCustomerOrderInfo, "System cannot find the customer order.")
                Exit Try
            End If
            If rbtnExistingCarton.Checked = fraud And rbtnAddNewCarton.Checked = fraud Then
                errProvider.SetError(rbtnExistingCarton, "Please choose between these two options.")
                errProvider.SetError(rbtnAddNewCarton, "Please choose between these two options.")
                Exit Try
            End If
            If rbtnExistingCarton.Checked = legit Then
                If LTrim(cboCartonNo.Text) <> "" Then
                    getPackingListCartonIDA(atcpackinglistid, cboCartonNo.Text, "AND `status` = 'Active' ", Me)
                    atcpackinglistcartonid = globalpackinglistcartonid
                    If atcpackinglistcartonid = 0 Then
                        errProvider.SetError(cboCartonNo, "The box no. might be delivered or unavailable at this moment.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(cboCartonNo, "Please choose the box no.")
                    Exit Try
                End If
            End If
            If rbtnAddNewCarton.Checked = legit Then
                If LTrim(txtCartonNo.Text) <> "" Then
                    getPackingListCartonIDA(atcpackinglistid, txtCartonNo.Text, "AND `status` != 'Inactive' ", Me)
                    atcpackinglistcartonid = globalpackinglistcartonid
                    If atcpackinglistcartonid <> 0 Then
                        errProvider.SetError(txtCartonNo, "The box no. has been created already.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtCartonNo, "Please enter the box no.")
                    Exit Try
                End If
            End If
            updatetotalqtyincarton() : addtocartoncomputations()
            If atcqtytopackerrorcue = legit Then
                MessageBox.Show("One or more of Qty. Picked is less than Total Qty. In Carton plus(+) Qty. To Pack.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                    getOrderItemStatus(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Me)
                    If CStr(dgCustomerOrderItems.Rows(i).Cells("ci_status").Value) <> globalorderitemstatus Then
                        dgCustomerOrderItems.Rows(i).Cells("ci_status").ErrorText = "The status of this customer order item has been updated, and the system has automatically updated the value from " & dgCustomerOrderItems.Rows(i).Cells("ci_status").Value & " to " & globalorderitemstatus & "."
                        dgCustomerOrderItems.Rows(i).Cells("ci_status").Value = globalorderitemstatus
                        Exit Try
                    End If
                Next
            End If
            myModule.systemerrorfound = False
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If rbtnExistingCarton.Checked = legit Then
                    If LTrim(cboCartonNo.Text) <> "" Then
                        getPackingListCartonIDA(atcpackinglistid, cboCartonNo.Text, "AND `status` = 'Active' ", Me)
                        atcpackinglistcartonid = globalpackinglistcartonid
                        If atcpackinglistcartonid = 0 Then
                            errProvider.SetError(cboCartonNo, "The box no. might be delivered or unavailable at this moment.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(cboCartonNo, "Please choose the box no.")
                        Exit Try
                    End If
                End If
                If rbtnAddNewCarton.Checked = legit Then
                    If LTrim(txtCartonNo.Text) <> "" Then
                        getPackingListCartonIDA(atcpackinglistid, txtCartonNo.Text, "AND `status` != 'Inactive' ", Me)
                        atcpackinglistcartonid = globalpackinglistcartonid
                        If atcpackinglistcartonid <> 0 Then
                            errProvider.SetError(txtCartonNo, "The box no. has been created already.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(txtCartonNo, "Please enter the box no.")
                        Exit Try
                    End If
                End If
                updatetotalqtyincarton() : addtocartoncomputations()
                If atcqtytopackerrorcue = legit Then
                    MessageBox.Show("One or more of Qty. Picked is less than Total Qty. In Carton plus(+) Qty. To Pack.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgCustomerOrderItems.Rows.Count <> 0 Then
                    For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                        getOrderItemStatus(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Me)
                        If CStr(dgCustomerOrderItems.Rows(i).Cells("ci_status").Value) <> globalorderitemstatus Then
                            dgCustomerOrderItems.Rows(i).Cells("ci_status").ErrorText = "The status of this customer order item has been updated, and the system has automatically updated the value from " & dgCustomerOrderItems.Rows(i).Cells("ci_status").Value & " to " & globalorderitemstatus & "."
                            dgCustomerOrderItems.Rows(i).Cells("ci_status").Value = globalorderitemstatus
                            Exit Try
                        End If
                    Next
                End If
                If rbtnExistingCarton.Checked = legit Then
                    getPackingListCartonIDA(atcpackinglistid, cboCartonNo.Text, "", Me)
                    atcpackinglistcartonid = globalpackinglistcartonid
                    getPackingListCartonInfo(atcpackinglistcartonid, Me)
                    atccontactid = globalpackedby
                    For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                        If myModule.systemerrorfound = False Then
                            getOrderItemStatus(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Me)
                            If globalorderitemstatus = "Verified" Or globalorderitemstatus = "Partially Packed" Or globalorderitemstatus = "Partially Lined Up" Then
                                If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value) Then
                                    If CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value) > 0 Then
                                        getPackingListCartonItemID(atcpackinglistcartonid, CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Me)
                                        atcpackinglistcartonitemid = globalpackinglistcartonitemid
                                        If atcpackinglistcartonitemid <> 0 Then
                                            If globalpackinglistcartonitemstatus = "Inactive" Then
                                                U_PackingListCartonItems(atcpackinglistcartonitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value), Me)
                                                U_PackingListCartonItemStatus(atcpackinglistcartonitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Active", Me)
                                            Else
                                                U_PackingListCartonItems(atcpackinglistcartonitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalpackinglistcartonitemqtyincarton + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value), Me)
                                            End If
                                        Else
                                            I_PackingListCartonItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, atcpackinglistcartonid, CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value), "Active", Me)
                                        End If
                                        If globalorderitemstatus = "Partially Lined Up" Then
                                            U_OrderItemPacking(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Partially Lined Up", If(atccontactid = 0, DBNull.Value, atccontactid), Date.Now.ToString("yyyy/MM/dd"), Me)
                                        Else
                                            If If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), 0) - (If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), 0) + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value)) < 1 Then
                                                U_OrderItemPacking(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Packed", If(atccontactid = 0, DBNull.Value, atccontactid), Date.Now.ToString("yyyy/MM/dd"), Me)
                                            Else
                                                U_OrderItemPacking(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Partially Packed", If(atccontactid = 0, DBNull.Value, atccontactid), Date.Now.ToString("yyyy/MM/dd"), Me)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
                If rbtnAddNewCarton.Checked = legit Then
                    getContactID(cboPackerName.Text, "Packer", Me)
                    atccontactid = globalcontactid
                    getCartonSizeIDB(cboSizeInfo.Text, Me)
                    I_PackingListCartons(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(atccontactid = 0, DBNull.Value, atccontactid), If(globalcartonsizeid = 0, DBNull.Value, globalcartonsizeid), atcpackinglistid, txtCartonNo.Text, dtpPackedDate.Value, _
                                cboWeightUOM.Text, If(IsNumeric(txtWeight.Text), CDec(txtWeight.Text), 0.0), If(IsNumeric(txtAmount.Text), CDec(txtAmount.Text), 0.0), "Active", Me)
                    atcpackinglistcartonid = globalpackinglistcartonidsp
                    For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                        If myModule.systemerrorfound = False Then
                            getOrderItemStatus(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Me)
                            If globalorderitemstatus = "Verified" Or globalorderitemstatus = "Partially Packed" Or globalorderitemstatus = "Partially Lined Up" Then
                                If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value) Then
                                    If CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value) > 0 Then
                                        I_PackingListCartonItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, atcpackinglistcartonid, CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value), "Active", Me)
                                        If globalorderitemstatus = "Partially Lined Up" Then
                                            U_OrderItemPacking(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Partially Lined Up", If(atccontactid = 0, DBNull.Value, atccontactid), dtpPackedDate.Value, Me)
                                        Else
                                            If If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), 0) - (If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), 0) + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value)) < 1 Then
                                                U_OrderItemPacking(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Packed", If(atccontactid = 0, DBNull.Value, atccontactid), dtpPackedDate.Value, Me)
                                            Else
                                                U_OrderItemPacking(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Partially Packed", If(atccontactid = 0, DBNull.Value, atccontactid), dtpPackedDate.Value, Me)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addtocartonformcue = legit
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Datagrid MouseUp"
    Private Sub dgCustomerOrderItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgCustomerOrderItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgCustomerOrderItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgCustomerOrderItems.BeginEdit(True)
                Else
                    dgCustomerOrderItems.EndEdit()
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
#End Region
End Class