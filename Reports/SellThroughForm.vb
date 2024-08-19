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
Imports WarehouseManagementSystem.Core.Enums

Public Class SellThroughForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdataset As New DataSetA.SetEDataTable
    Dim printdatatable As New DataTable
    Dim sqlquery As String
    Dim stproductimage As Object
    Dim itemcount, rowscount As Integer
    Dim stdisplayprintimagecue As Boolean
    Dim streceiptdate, stconditionstringA, stconditionstringB, stconditionstringC As String
    Dim stbrandid, stcategoryid, streceivedqty, stqtysold, sttotalqtydelivered, stqtyavailable, stqtyallocated As Integer
    Dim sttotalreceivedqty, sttotalreceivedretail, sttotalqtysold, sttotalqtyonhand, sttotalpvsold, sttotalpvonhand, sttotalpsoldpercentage As Decimal

    Private Sub SellThroughForm_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            dgProducts.Rows.Clear()
            dgSellThrough.Rows.Clear()
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
            txtTotalReceivedQty.Text = ""
            txtTotalReceivedRetail.Text = ""
            txtTotalQtySold.Text = ""
            txtTotalPVSold.Text = ""
            txtTotalQtyOnHand.Text = ""
            txtTotalPVOnHand.Text = ""
            txtTotalSoldPercentage.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Computations"

    Sub sellthroughcomputations()
        Try
            sttotalreceivedqty = 0.0 : sttotalreceivedretail = 0.0 : sttotalqtysold = 0.0
            sttotalqtyonhand = 0.0 : sttotalpvsold = 0.0 : sttotalpvonhand = 0.0 : sttotalpsoldpercentage = 0.0
            If dgProducts.Rows.Count <> 0 Then
                For i = 0 To dgProducts.Rows.Count - 1
                    If IsNumeric(dgProducts.Rows(i).Cells("p_rcvdqty").Value) Then
                        sttotalreceivedqty = sttotalreceivedqty + CDec(dgProducts.Rows(i).Cells("p_rcvdqty").Value)
                    End If
                    If IsNumeric(dgProducts.Rows(i).Cells("p_rcvdretail").Value) Then
                        sttotalreceivedretail = sttotalreceivedretail + CDec(dgProducts.Rows(i).Cells("p_rcvdretail").Value)
                    End If
                Next
            End If
            If dgSellThrough.Rows.Count <> 0 Then
                For i = 0 To dgSellThrough.Rows.Count - 1
                    If IsNumeric(dgSellThrough.Rows(i).Cells("st_qtysold").Value) Then
                        sttotalqtysold = sttotalqtysold + CDec(dgSellThrough.Rows(i).Cells("st_qtysold").Value)
                    End If
                    If IsNumeric(dgSellThrough.Rows(i).Cells("st_pvsold").Value) Then
                        sttotalpvsold = sttotalpvsold + CDec(dgSellThrough.Rows(i).Cells("st_pvsold").Value)
                    End If
                    If IsNumeric(dgSellThrough.Rows(i).Cells("st_qtyonhand").Value) Then
                        sttotalqtyonhand = sttotalqtyonhand + CDec(dgSellThrough.Rows(i).Cells("st_qtyonhand").Value)
                    End If
                    If IsNumeric(dgSellThrough.Rows(i).Cells("st_pvonhand").Value) Then
                        sttotalpvonhand = sttotalpvonhand + CDec(dgSellThrough.Rows(i).Cells("st_pvonhand").Value)
                    End If
                    If IsNumeric(dgSellThrough.Rows(i).Cells("st_soldpercentage").Value) Then
                        sttotalpsoldpercentage = sttotalpsoldpercentage + CDec(dgSellThrough.Rows(i).Cells("st_soldpercentage").Value)
                    End If
                Next
            End If
            txtTotalReceivedQty.Text = Format(Math.Round(sttotalreceivedqty, 0), "#,##0")
            txtTotalReceivedRetail.Text = Format(Math.Round(sttotalreceivedretail, 0), "#,##0.00")
            txtTotalQtySold.Text = Format(Math.Round(sttotalqtysold, 0), "#,##0")
            txtTotalPVSold.Text = Format(Math.Round(sttotalpvsold, 0), "#,##0.00")
            txtTotalQtyOnHand.Text = Format(Math.Round(sttotalqtyonhand, 0), "#,##0")
            txtTotalPVOnHand.Text = Format(Math.Round(sttotalpvonhand, 0), "#,##0.00")
            If sttotalpsoldpercentage = 0 Then
                txtTotalSoldPercentage.Text = "0%"
            Else
                txtTotalSoldPercentage.Text = "" & sttotalpsoldpercentage / dgSellThrough.Rows.Count & "%"
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Display"

    Sub displaySellThroughReport(ByVal iconditionstring As String)
        Try
            dgProducts.Rows.Clear() : dgSellThrough.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT p.rowid,COALESCE(p.productcode,''),COALESCE(v.companyname,''),COALESCE(p.unitprice,0.0) FROM products p LEFT JOIN companies v ON p.companyid = v.rowid " &
                        "WHERE p.organizationid = " & Z_OrganizationID & " AND " & iconditionstring & " ORDER BY p.productcode ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    getReceivedQty(CInt(reader1(0)))
                    getCustomerOrderItems(CInt(reader1(0)))
                    getQtyAvailable(CInt(reader1(0)))
                    getQtyAllocated(CInt(reader1(0)))
                    If streceivedqty = 0 Then
                        streceivedqty = stqtysold + (stqtyavailable - stqtyallocated)
                    End If
                    dgProducts.Rows.Add()
                    dgProducts.Item(p_seqno.Index, n).Value = seqno
                    dgProducts.Item(p_rowid.Index, n).Value = reader1(0)
                    dgProducts.Item(p_productcode.Index, n).Value = reader1(1)
                    dgProducts.Item(p_vendorname.Index, n).Value = reader1(2)
                    dgProducts.Item(p_srp.Index, n).Value = Format(CDec(reader1(3)), "#,##0.00")
                    getReceiptDate(CInt(reader1(0)))
                    dgProducts.Item(p_receiptdate.Index, n).Value = streceiptdate
                    dgProducts.Item(p_rcvdqty.Index, n).Value = Format(streceivedqty, "#,##0")
                    dgProducts.Item(p_rcvdretail.Index, n).Value = Format(Math.Round(CDec(reader1(3)) * streceivedqty, 2), "#,##0.00")
                    dgSellThrough.Rows.Add()
                    dgSellThrough.Item(st_rowid.Index, n).Value = reader1(0)
                    dgSellThrough.Item(st_qtysold.Index, n).Value = Format(stqtysold, "#,##0")
                    dgSellThrough.Item(st_pvsold.Index, n).Value = Format(Math.Round(CDec(reader1(3)) * stqtysold, 2), "#,##0.00")
                    dgSellThrough.Item(st_qtyonhand.Index, n).Value = Format((stqtyavailable - stqtyallocated), "#,##0")
                    dgSellThrough.Item(st_pvonhand.Index, n).Value = Format(Math.Round(CDec(reader1(3)) * (stqtyavailable - stqtyallocated), 2), "#,##0.00")
                    dgSellThrough.Item(st_soldpercentage.Index, n).Value = "" & Math.Round((stqtysold / streceivedqty) * 100, 0) & "%"
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProducts.Columns("p_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_receiptdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_rcvdqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_rcvdretail").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProducts.Rows.Count <> 0 Then
                dgProducts.CurrentRow.Selected = False
            End If
            dgSellThrough.Columns("st_qtysold").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSellThrough.Columns("st_pvsold").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSellThrough.Columns("st_qtyonhand").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSellThrough.Columns("st_pvonhand").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSellThrough.Columns("st_soldpercentage").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgSellThrough.Rows.Count <> 0 Then
                dgSellThrough.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getReceiptDate(ByVal iproductid As Integer)
        Try
            streceiptdate = ""
            Dim dtLsd As New DataTable
            dtLsd = getDataTableForSQL("SELECT COALESCE(DATE_FORMAT(pcs.lastshipmentdate,'%d-%b-%Y'),'') FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid " &
                            "WHERE pcs.`Status`='Active' AND pcs.organizationid = " & Z_OrganizationID & " AND p.rowid = " & iproductid & " AND pcs.lastshipmentdate IS NOT NULL ORDER BY pcs.lastshipmentdate ASC LIMIT 0,1 ")
            If dtLsd.Rows.Count <> 0 Then
                streceiptdate = dtLsd.Rows(0)(0)
            Else
                streceiptdate = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getReceivedQty(ByVal iproductid As Integer)
        Try
            streceivedqty = 0
            Dim dtRqty As New DataTable
            dtRqty = getDataTableForSQL("SELECT COALESCE(SUM(oi.qtyreceived),0) FROM orderitems oi LEFT JOIN orders o ON oi.orderid = o.rowid LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid " &
                            "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE oi.organizationid = " & Z_OrganizationID & " AND p.rowid = " & iproductid & " " &
                            $"AND o.ordertype = '{OrderType.PO.ToString()}' AND oi.`approval` = 'Y' AND (oi.`status` != 'Inactive' AND oi.`status` != 'Cancelled') ")
            If dtRqty.Rows.Count <> 0 Then
                streceivedqty = dtRqty.Rows(0)(0)
            Else
                streceivedqty = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getCustomerOrderItems(ByVal iproductid As Integer)
        Try
            stqtysold = 0
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT o.rowid,oi.rowid FROM orderitems oi LEFT JOIN orders o ON oi.orderid = o.rowid LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " &
                        "LEFT JOIN products p ON pc.productid = p.rowid WHERE oi.organizationid = " & Z_OrganizationID & " AND p.rowid = " & iproductid & $" AND o.ordertype = '{OrderType.CO.ToString()}' AND (oi.`status` != 'Inactive' AND oi.`status` != 'Cancelled') "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getPickListOrderID(CInt(reader1(0)), CInt(reader1(1)))
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub getPickListOrderID(ByVal iorderid As Integer, ByVal iorderitemid As Integer)
        Try
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.orderitemid = " & iorderitemid & " AND plo.orderid = " & iorderid & " AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') ")
            If dtGid.Rows.Count <> 0 Then
                getTotalQtyDelivered(CInt(dtGid.Rows(0)(0)))
                stqtysold = stqtysold + sttotalqtydelivered
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getTotalQtyDelivered(ByVal ipicklistorderid As Integer)
        Try
            sttotalqtydelivered = 0
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtydelivered)) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND (pli.`status` != 'Inactive' AND pli.`status` != 'Cancelled') ")
            If dtGtq.Rows.Count <> 0 Then
                sttotalqtydelivered = dtGtq.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getQtyAvailable(ByVal iproductid As Integer)
        Try
            stqtyavailable = 0
            Dim dtQav As New DataTable
            dtQav = getDataTableForSQL("SELECT COALESCE(SUM(pil.totalavailableqty),0) FROM productinventorylocation pil LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pil.organizationid = " & Z_OrganizationID & " AND p.rowid = " & iproductid & " ")
            If dtQav.Rows.Count <> 0 Then
                stqtyavailable = dtQav.Rows(0)(0)
            Else
                stqtyavailable = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getQtyAllocated(ByVal iproductid As Integer)
        Try
            stqtyallocated = 0
            Dim dtQal As New DataTable
            dtQal = getDataTableForSQL("SELECT COALESCE(SUM(pil.totalallocatedqty),0) FROM productinventorylocation pil LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pil.organizationid = " & Z_OrganizationID & " AND p.rowid = " & iproductid & " ")
            If dtQal.Rows.Count <> 0 Then
                stqtyallocated = dtQal.Rows(0)(0)
            Else
                stqtyallocated = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

#End Region

#Region "Printing"

    Sub printSellThroughReportA(ByVal iconditionstring As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT p.rowid,COALESCE(p.productcode,''),COALESCE(v.companyname,''),COALESCE(p.unitprice,0.0),COALESCE(b.brandname,''),COALESCE(ct.categoryname,''),p.image " &
                        "FROM products p LEFT JOIN companies v ON p.companyid = v.rowid LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN categories ct ON p.categoryid = ct.rowid " &
                        "WHERE p.organizationid = " & Z_OrganizationID & " AND " & iconditionstring & " ORDER BY ct.categoryname,b.brandname,p.productcode "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getReceivedQty(CInt(reader1(0)))
                    getCustomerOrderItems(CInt(reader1(0)))
                    getQtyAvailable(CInt(reader1(0)))
                    getQtyAllocated(CInt(reader1(0)))
                    If streceivedqty = 0 Then
                        streceivedqty = stqtysold + (stqtyavailable - stqtyallocated)
                    End If
                    getReceiptDate(CInt(reader1(0)))
                    stproductimage = reader1(6)
                    If IsDBNull(stproductimage) Then
                        stproductimage = Nothing
                    End If
                    printdataset.AddSetERow(CStr(reader1(5)), CStr(reader1(4)), CStr(reader1(2)), CStr(reader1(1)), Format(CDec(reader1(3)), "#,##0.00"), streceiptdate, " As of " & Date.Now.ToString("MMM dd, yyyy") & "", "", streceivedqty, Math.Round(CDec(reader1(3)) * streceivedqty, 2), stqtysold, Math.Round(CDec(reader1(3)) * stqtysold, 2), stqtyavailable - stqtyallocated, Math.Round(CDec(reader1(3)) * (stqtyavailable - stqtyallocated), 2), Math.Round((stqtysold / streceivedqty) * 100, 0), stproductimage)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub printSellThroughReportB(ByVal iconditionstring As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT p.rowid,COALESCE(p.productcode,''),COALESCE(v.companyname,''),COALESCE(p.unitprice,0.0),COALESCE(b.brandname,''),COALESCE(ct.categoryname,'') " &
                        "FROM products p LEFT JOIN companies v ON p.companyid = v.rowid LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN categories ct ON p.categoryid = ct.rowid " &
                        "WHERE p.organizationid = " & Z_OrganizationID & " AND " & iconditionstring & " ORDER BY ct.categoryname,b.brandname,p.productcode "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getReceivedQty(CInt(reader1(0)))
                    getCustomerOrderItems(CInt(reader1(0)))
                    getQtyAvailable(CInt(reader1(0)))
                    getQtyAllocated(CInt(reader1(0)))
                    If streceivedqty = 0 Then
                        streceivedqty = stqtysold + (stqtyavailable - stqtyallocated)
                    End If
                    getReceiptDate(CInt(reader1(0)))
                    stproductimage = Nothing
                    printdataset.AddSetERow(CStr(reader1(5)), CStr(reader1(4)), CStr(reader1(2)), CStr(reader1(1)), Format(CDec(reader1(3)), "#,##0.00"), streceiptdate, " As of " & Date.Now.ToString("MMM dd, yyyy") & "", "", streceivedqty, Math.Round(CDec(reader1(3)) * streceivedqty, 2), stqtysold, Math.Round(CDec(reader1(3)) * stqtysold, 2), stqtyavailable - stqtyallocated, Math.Round(CDec(reader1(3)) * (stqtyavailable - stqtyallocated), 2), Math.Round((stqtysold / streceivedqty) * 100, 0), stproductimage)
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
                PrimaryForm.SllThrhForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProducts_Scroll(sender As Object, e As ScrollEventArgs) Handles dgProducts.Scroll
        Try
            If dgSellThrough.Rows.Count <> 0 Then
                Me.dgSellThrough.FirstDisplayedScrollingRowIndex = Me.dgProducts.FirstDisplayedScrollingRowIndex
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSellThrough_Scroll(sender As Object, e As ScrollEventArgs) Handles dgSellThrough.Scroll
        Try
            If dgProducts.Rows.Count <> 0 Then
                Me.dgProducts.FirstDisplayedScrollingRowIndex = Me.dgSellThrough.FirstDisplayedScrollingRowIndex
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
                getPositionView(globalpositionid, "Sell-Through", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.SllThrhForm = False
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
                dgProducts.Rows.Clear()
                dgSellThrough.Rows.Clear()
                clearTotals()
                Exit Try
            End If
            If LTrim(cboBrandName.Text) <> "" Then
                getBrandID(cboBrandName.Text, Me) : stbrandid = globalbrandid
                If stbrandid = 0 Then
                    errProvider.SetError(cboBrandName, "System cannot find the brand name or you may leave it blank.")
                    dgProducts.Rows.Clear()
                    dgSellThrough.Rows.Clear()
                    clearTotals()
                    Exit Try
                End If
            End If
            If LTrim(cboCategory.Text) <> "" Then
                getCategoryID(cboCategory.Text, "", Me) : stcategoryid = globalcategoryid
                If stcategoryid = 0 Then
                    errProvider.SetError(cboCategory, "System cannot find the category or you may leave it blank.")
                    dgProducts.Rows.Clear()
                    dgSellThrough.Rows.Clear()
                    clearTotals()
                    Exit Try
                End If
            End If
            If stbrandid <> 0 Then
                stconditionstringA = "p.brandid = " & stbrandid & " "
            Else
                stconditionstringA = ""
            End If
            If stcategoryid <> 0 Then
                stconditionstringB = "p.categoryid = " & stcategoryid & " "
            Else
                stconditionstringB = ""
            End If
            If stconditionstringA = "" Then
                stconditionstringC = stconditionstringB
            ElseIf stconditionstringB = "" Then
                stconditionstringC = stconditionstringA
            Else
                stconditionstringC = "" & stconditionstringA & " AND " & stconditionstringB & ""
            End If
            displaySellThroughReport(stconditionstringC)
            sellthroughcomputations()
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
                getPositionView(globalpositionid, "Sell-Through", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.SllThrhForm = False
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
                dgProducts.Rows.Clear()
                dgSellThrough.Rows.Clear()
                clearTotals()
                Exit Try
            End If
            If LTrim(cboBrandName.Text) <> "" Then
                getBrandID(cboBrandName.Text, Me) : stbrandid = globalbrandid
                If stbrandid = 0 Then
                    errProvider.SetError(cboBrandName, "System cannot find the brand name or you may leave it blank.")
                    dgProducts.Rows.Clear()
                    dgSellThrough.Rows.Clear()
                    clearTotals()
                    Exit Try
                End If
            End If
            If LTrim(cboCategory.Text) <> "" Then
                getCategoryID(cboCategory.Text, "", Me) : stcategoryid = globalcategoryid
                If stcategoryid = 0 Then
                    errProvider.SetError(cboCategory, "System cannot find the category or you may leave it blank.")
                    dgProducts.Rows.Clear()
                    dgSellThrough.Rows.Clear()
                    clearTotals()
                    Exit Try
                End If
            End If
            If MessageBox.Show("Would you like to print the Sell-Through Report with Image?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                stdisplayprintimagecue = legit
            Else
                stdisplayprintimagecue = fraud
            End If
            Me.Cursor = Cursors.WaitCursor
            If stbrandid <> 0 Then
                stconditionstringA = "p.brandid = " & stbrandid & " "
            Else
                stconditionstringA = ""
            End If
            If stcategoryid <> 0 Then
                stconditionstringB = "p.categoryid = " & stcategoryid & " "
            Else
                stconditionstringB = ""
            End If
            If stconditionstringA = "" Then
                stconditionstringC = stconditionstringB
            ElseIf stconditionstringB = "" Then
                stconditionstringC = stconditionstringA
            Else
                stconditionstringC = "" & stconditionstringA & " AND " & stconditionstringB & ""
            End If
            If stdisplayprintimagecue = legit Then
                printSellThroughReportA(stconditionstringC)
                Dim printreport As New SellThroughPrintA
                Dim openreportviewer As New ReportViewer
                openreportviewer.CrystalReportViewer.ReportSource = printreport
                printdatatable = printdataset
                printreport.SetDataSource(printdatatable)
                openreportviewer.Show()
                printdatatable.Dispose()
                printdatatable = Nothing
                printdataset.Clear()
                displaySellThroughReport(stconditionstringC)
                sellthroughcomputations()
            Else
                printSellThroughReportB(stconditionstringC)
                Dim printreport As New SellThroughPrintB
                Dim openreportviewer As New ReportViewer
                openreportviewer.CrystalReportViewer.ReportSource = printreport
                printdatatable = printdataset
                printreport.SetDataSource(printdatatable)
                openreportviewer.Show()
                printdatatable.Dispose()
                printdatatable = Nothing
                printdataset.Clear()
                displaySellThroughReport(stconditionstringC)
                sellthroughcomputations()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Datagrid Errors"

    Private Sub dgProducts_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProducts.DataError
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
                dgProducts.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSellThrough_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgSellThrough.DataError
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
                dgSellThrough.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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