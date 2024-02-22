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
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Information
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Entities
Public Class StockForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim rowscount, sftotalqtytostockleft, sftotalqtytostock As Integer
    Dim sfrackcolumnshelfid, sfproductinventorylocationid As Integer
    Public sfseqno As String
    Public stockformcue As Boolean = False
    Public sforderitemid, sfprodcolorsizeid, sforderid, sfinventorylocationid, sfqtyOrdered, sfdamageqtyOrdered As Integer
    Private _systemOwner As SystemOwner

    Private Async Sub StockForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            getInventoryLocID(Me)
            If sfinventorylocationid <> 0 Then
                callAutoCompleteFunctions()
                callAutoPopulateFunctions()
                displayReceivingItems(sforderitemid, sfseqno)
                colorCoding()
                displayRackColumnShelf(sfprodcolorsizeid)
            Else
                MessageBox.Show("System cannot find the inventory location.", "Loading", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Function"
    Sub callAutoCompleteFunctions()
        autocompleteRack(cboRack)
        autocompleteShelf(cboShelf)
        autocompleteColumn(cboColumn)
    End Sub
    Sub callAutoPopulateFunctions()
        autopopulateRack(cboRack)
        autopopulateShelf(cboShelf)
        autopopulateColumn(cboColumn)
    End Sub
#Region "Clear"
    Sub clearfields()
        Try
            cboRack.Text = ""
            cboColumn.Text = ""
            cboShelf.Text = ""
            txtQtyToStock.Text = ""
            cboRack.SelectedItem = Nothing
            cboColumn.SelectedItem = Nothing
            cboShelf.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Computations"
    Sub stockformcomputation()
        Try
            sftotalqtytostockleft = 0 : sftotalqtytostock = 0
            If dgReceivingItem.Rows.Count <> 0 Then
                For i = 0 To dgReceivingItem.Rows.Count - 1
                    If IsNumeric(dgReceivingItem.Rows(i).Cells("ci_qtyleft").Value) Then
                        sftotalqtytostockleft = sftotalqtytostockleft + CInt(dgReceivingItem.Rows(i).Cells("ci_qtyleft").Value)
                    End If
                Next
            End If
            If dgRackColumnShelf.Rows.Count <> 0 Then
                For i = 0 To dgRackColumnShelf.Rows.Count - 1
                    If IsNumeric(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value) Then
                        sftotalqtytostock = sftotalqtytostock + CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value)
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
#Region "Click"
    Sub btnaddperformclick()
        Try
            errProvider.Clear()
            If dgReceivingItem.Rows.Count = 0 Then
                errProvider.SetError(btnAddRackColumnShelf, "There is no receiving item.")
                Exit Try
            End If
            If LTrim(cboRack.Text) = "" Then
                errProvider.SetError(btnAddRackColumnShelf, "Please choose for rack.")
                cboRack.Focus()
                Exit Try
            End If
            If LTrim(cboColumn.Text) = "" AndAlso Not IsThurston Then
                errProvider.SetError(btnAddRackColumnShelf, "Please choose for column.")
                cboColumn.Focus()
                Exit Try
            End If
            If LTrim(cboShelf.Text) = "" AndAlso Not IsThurston Then
                errProvider.SetError(btnAddRackColumnShelf, "Please choose for shelf.")
                cboShelf.Focus()
                Exit Try
            End If
            If Not IsNumeric(txtQtyToStock.Text) Then
                errProvider.SetError(btnAddRackColumnShelf, "Please use numbers for qty. to stock.")
                txtQtyToStock.Focus()
                Exit Try
            Else
                stockformcomputation()
                If CInt(txtQtyToStock.Text) + sftotalqtytostock > sftotalqtytostockleft Then
                    errProvider.SetError(btnAddRackColumnShelf, "The sum of all qty. to stock should not be greater than qty. left to stock.")
                    txtQtyToStock.Focus()
                    Exit Try
                End If
            End If
            getRackShelfColumnID("" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "", sfinventorylocationid, Me)
            sfrackcolumnshelfid = globalrackshelfcolumnid
            If sfrackcolumnshelfid = 0 Then
                errProvider.SetError(btnAddRackColumnShelf, "The rack, column and shelf combination is not available as of this moment.")
                cboRack.Focus()
                Exit Try
            End If
            If dgRackColumnShelf.Rows.Count <> 0 Then
                rowscount = dgRackColumnShelf.Rows.Count - 1
                For i = 0 To dgRackColumnShelf.Rows.Count - 1
                    If "" & dgRackColumnShelf.Rows(i).Cells("rcs_rack").Value & "" & dgRackColumnShelf.Rows(i).Cells("rcs_column").Value & "" & dgRackColumnShelf.Rows(i).Cells("rcs_shelf").Value & "" = "" & cboRack.Text & "" & cboColumn.Text & "" & cboShelf.Text & "" Then
                        errProvider.SetError(btnAddRackColumnShelf, "The rack,column, and shelf is in the list already.")
                        cboRack.Focus()
                        Exit Try
                    ElseIf rowscount = 0 Then
                        addRackShelfColumnRow()
                        For a = 0 To dgRackColumnShelf.Rows.Count - 1
                            dgRackColumnShelf.CurrentRow.Selected = fraud
                            If "" & dgRackColumnShelf.Rows(a).Cells("rcs_rack").Value & "" & dgRackColumnShelf.Rows(a).Cells("rcs_column").Value & "" & dgRackColumnShelf.Rows(a).Cells("rcs_shelf").Value & "" = "" & cboRack.Text & "" & cboColumn.Text & "" & cboShelf.Text & "" Then
                                dgRackColumnShelf.Rows(dgRackColumnShelf.Rows.Count - 1).Selected = legit
                                dgRackColumnShelf.FirstDisplayedScrollingRowIndex = dgRackColumnShelf.RowCount - 1
                                Exit For
                            End If
                        Next
                        clearfields() : cboRack.Focus()
                    End If
                    rowscount = rowscount - 1
                Next
            Else
                addRackShelfColumnRow()
                For a = 0 To dgRackColumnShelf.Rows.Count - 1
                    dgRackColumnShelf.CurrentRow.Selected = fraud
                    If "" & dgRackColumnShelf.Rows(a).Cells("rcs_rack").Value & "" & dgRackColumnShelf.Rows(a).Cells("rcs_column").Value & "" & dgRackColumnShelf.Rows(a).Cells("rcs_shelf").Value & "" = "" & cboRack.Text & "" & cboColumn.Text & "" & cboShelf.Text & "" Then
                        dgRackColumnShelf.Rows(dgRackColumnShelf.Rows.Count - 1).Selected = legit
                        dgRackColumnShelf.FirstDisplayedScrollingRowIndex = dgRackColumnShelf.RowCount - 1
                        Exit For
                    End If
                Next
                clearfields() : cboRack.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "AutoComplete"
    Sub autocompleteRack(ByVal icombobox As ComboBox)
        Try
            Dim rackno As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(rsc.rackno,'') AS 'rackno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & sfinventorylocationid & " GROUP BY rsc.rackno ORDER BY rsc.rackno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                rackno.Add(ds.Tables(0).Rows(i)("rackno").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = rackno
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autocompleteShelf(ByVal icombobox As ComboBox)
        Try
            Dim shelfno As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(rsc.shelfno,'') AS 'shelfno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & sfinventorylocationid & " GROUP BY rsc.shelfno ORDER BY rsc.shelfno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                shelfno.Add(ds.Tables(0).Rows(i)("shelfno").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = shelfno
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autocompleteColumn(ByVal icombobox As ComboBox)
        Try
            Dim columnno As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(rsc.columnno,'') AS 'columnno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & sfinventorylocationid & " GROUP BY rsc.columnno ORDER BY rsc.columnno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                columnno.Add(ds.Tables(0).Rows(i)("columnno").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = columnno
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "AutoPopulate"
    Sub autopopulateRack(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(rsc.rackno,'') AS 'rackno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & sfinventorylocationid & " GROUP BY rsc.rackno ORDER BY rsc.rackno "
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
    Sub autopopulateShelf(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(rsc.shelfno,'') AS 'shelfno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & sfinventorylocationid & " GROUP BY rsc.shelfno ORDER BY rsc.shelfno "
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
    Sub autopopulateColumn(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(rsc.columnno,'') AS 'columnno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & sfinventorylocationid & " GROUP BY rsc.columnno ORDER BY rsc.columnno "
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
    Sub displayReceivingItems(ByVal iorderitemid As Integer, ByVal iseqno As String)
        Try
            dgReceivingItem.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,'')," &
                    "COALESCE(pcs.seasoncode,''),COALESCE(ci.unitofmeasure,''),COALESCE(pcs.sku,''),COALESCE(ci.itemtype,''),COALESCE(ci.remarks,''),COALESCE(ci.qtyreceived,0) FROM orderitems ci " &
                    "LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " &
                    "LEFT JOIN products p ON pc.productid = p.rowid WHERE ci.rowid = " & iorderitemid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgReceivingItem.Rows.Add()
                    dgReceivingItem.Item(ci_color.Index, n).Value = ""
                    dgReceivingItem.Item(ci_seqno.Index, n).Value = iseqno
                    dgReceivingItem.Item(ci_rowid.Index, n).Value = reader1(0)
                    dgReceivingItem.Item(ci_pcsrowid.Index, n).Value = reader1(1)
                    dgReceivingItem.Item(ci_colorvalue.Index, n).Value = reader1(2)
                    dgReceivingItem.Item(ci_productcode.Index, n).Value = reader1(3)
                    dgReceivingItem.Item(ci_colorname.Index, n).Value = reader1(4)
                    dgReceivingItem.Item(ci_size.Index, n).Value = reader1(5)
                    dgReceivingItem.Item(ci_seasoncode.Index, n).Value = reader1(6)
                    dgReceivingItem.Item(ci_unitofmeasure.Index, n).Value = reader1(7)
                    dgReceivingItem.Item(ci_sku.Index, n).Value = reader1(8)
                    dgReceivingItem.Item(ci_itemtype.Index, n).Value = reader1(9)
                    dgReceivingItem.Item(ci_remarks.Index, n).Value = reader1(10)
                    dgReceivingItem.Item(ci_qtyreceived.Index, n).Value = reader1(11)
                    getTotalQtyAppliedA(CInt(reader1(0)), Me)
                    dgReceivingItem.Item(ci_qtystocked.Index, n).Value = globaltotalqtyapplied
                    dgReceivingItem.Item(ci_qtyleft.Index, n).Value = CInt(reader1(11)) - globaltotalqtyapplied
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgReceivingItem.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItem.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItem.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItem.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItem.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItem.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItem.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItem.Columns("ci_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItem.Columns("ci_qtyleft").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItem.Columns("ci_itemtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgReceivingItem.Rows.Count <> 0 Then
                dgReceivingItem.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayRackColumnShelf(ByVal iproductcolorsizeid As Integer)
        Try
            dgRackColumnShelf.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pil.rowid,COALESCE(rcs.rackNo,''),COALESCE(rcs.columnno,''),COALESCE(rcs.shelfno,''),COALESCE(pil.totalavailableqty,0),pil.rackshelfcolumnid FROM productinventorylocation pil " &
                        "LEFT JOIN rackshelfcolumn rcs ON pil.rackshelfcolumnid = rcs.rowid WHERE pil.productcolorsizeid = " & iproductcolorsizeid & " AND pil.organizationid = " & Z_OrganizationID & " AND rcs.inventorylocationid = " & sfinventorylocationid & " ORDER BY rcs.pickorderno ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgRackColumnShelf.Rows.Add()
                    dgRackColumnShelf.Item(rcs_rowid.Index, n).Value = reader1(0)
                    dgRackColumnShelf.Item(rcs_rack.Index, n).Value = reader1(1)
                    dgRackColumnShelf.Item(rcs_column.Index, n).Value = reader1(2)
                    dgRackColumnShelf.Item(rcs_shelf.Index, n).Value = reader1(3)
                    dgRackColumnShelf.Item(rcs_qtystocked.Index, n).Value = Format(CInt(reader1(4)), "#,##0")
                    dgRackColumnShelf.Item(rcs_qtytostock.Index, n).Value = ""
                    getTotalQtyAvailableD(CInt(reader1(5)), Me)
                    dgRackColumnShelf.Item(rcs_totalqtyavailable.Index, n).Value = Format(globaltotalqtyavailable, "#,##0")
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgRackColumnShelf.Columns("rcs_rack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackColumnShelf.Columns("rcs_column").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackColumnShelf.Columns("rcs_shelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackColumnShelf.Columns("rcs_totalqtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackColumnShelf.Columns("rcs_qtystocked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackColumnShelf.Columns("rcs_qtytostock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgRackColumnShelf.Rows.Count <> 0 Then
                dgRackColumnShelf.CurrentRow.Selected = False
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
            If dgReceivingItem.Rows.Count <> 0 Then
                For i As Integer = 0 To dgReceivingItem.Rows.Count - 1
                    If dgReceivingItem.Rows(i).Cells(ci_itemtype.Index).Value = "A" Then
                        dgReceivingItem.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
                    End If
                    If CStr(dgReceivingItem.Rows(i).Cells("ci_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgReceivingItem.Rows(i).Cells("ci_colorvalue").Value))
                        dgReceivingItem.Rows(i).Cells("ci_color").Style.BackColor = readcolor
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
#Region "Adding"
    Sub addRackShelfColumnRow()
        Try
            dgRackColumnShelf.Rows.Add()
            dgRackColumnShelf.Rows(dgRackColumnShelf.Rows.Count - 1).Cells("rcs_rowid").Value = ""
            dgRackColumnShelf.Rows(dgRackColumnShelf.Rows.Count - 1).Cells("rcs_rack").Value = cboRack.Text
            dgRackColumnShelf.Rows(dgRackColumnShelf.Rows.Count - 1).Cells("rcs_column").Value = cboColumn.Text
            dgRackColumnShelf.Rows(dgRackColumnShelf.Rows.Count - 1).Cells("rcs_shelf").Value = cboShelf.Text
            getTotalQtyAvailableD(sfrackcolumnshelfid, Me)
            dgRackColumnShelf.Rows(dgRackColumnShelf.Rows.Count - 1).Cells("rcs_totalqtyavailable").Value = Format(globaltotalqtyavailable, "#,##0")
            dgRackColumnShelf.Rows(dgRackColumnShelf.Rows.Count - 1).Cells("rcs_qtystocked").Value = "0"
            dgRackColumnShelf.Rows(dgRackColumnShelf.Rows.Count - 1).Cells("rcs_qtytostock").Value = CInt(txtQtyToStock.Text)
            dgRackColumnShelf.Columns("rcs_rack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackColumnShelf.Columns("rcs_column").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackColumnShelf.Columns("rcs_shelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackColumnShelf.Columns("rcs_totalqtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackColumnShelf.Columns("rcs_qtystocked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackColumnShelf.Columns("rcs_qtytostock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region
    Private Sub btnAddRackColumnShelf_Click(sender As Object, e As EventArgs) Handles btnAddRackColumnShelf.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            btnaddperformclick()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtQtyToStock_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQtyToStock.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                btnaddperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboRack_TextChanged(sender As Object, e As EventArgs) Handles cboRack.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboRack_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRack.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboColumn_TextChanged(sender As Object, e As EventArgs) Handles cboColumn.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboColumn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboColumn.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboShelf_TextChanged(sender As Object, e As EventArgs) Handles cboShelf.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboShelf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShelf.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub txtQtyToStock_TextChanged(sender As Object, e As EventArgs) Handles txtQtyToStock.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgRackColumnShelf_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgRackColumnShelf.CellEndEdit
        Try
            errProvider.Clear()
            stockformcomputation()
            If dgRackColumnShelf.Rows.Count <> 0 Then
                If sftotalqtytostock > sftotalqtytostockleft Then
                    For i = 0 To dgRackColumnShelf.Rows.Count - 1
                        dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").ErrorText = "The sum of all qty. to stock should not be greater than qty. left to stock."
                    Next
                Else
                    For i = 0 To dgRackColumnShelf.Rows.Count - 1
                        dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").ErrorText = Nothing
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgRackColumnShelf_MouseUp(sender As Object, e As MouseEventArgs) Handles dgRackColumnShelf.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgRackColumnShelf.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgRackColumnShelf.BeginEdit(True)
                Else
                    dgRackColumnShelf.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            dgRackColumnShelf.CommitEdit(legit) : dgRackColumnShelf.ClearSelection() : dgRackColumnShelf.CurrentCell = Nothing
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Stocking To Rack/Shelf/Column", Me)
                If globalupdateflg <> "Y" Then
                    MessageBox.Show("The user is not allowed stock the receiving item.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            getOrderStatus(sforderid, Me)
            If globalorderstatus = "Cancelled" Then
                MessageBox.Show("The R. R. has been cancelled.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            getOrderItemStatus(sforderitemid, Me)
            If globalorderitemstatus <> "Active" Then
                MessageBox.Show("The receiving item is not available already.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            getInventoryLocID(Me)
            If sfinventorylocationid = 0 Then
                MessageBox.Show("System cannot find the inventory location.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgReceivingItem.Rows.Count = 0 Then
                MessageBox.Show("There is no receiving item for stocking.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            Else
                For i = 0 To dgReceivingItem.Rows.Count - 1
                    getTotalQtyAppliedA(CInt(dgReceivingItem.Rows(i).Cells("ci_rowid").Value), Me)
                    If CInt(dgReceivingItem.Rows(i).Cells("ci_qtyreceived").Value) - globaltotalqtyapplied <> CInt(dgReceivingItem.Rows(i).Cells("ci_qtyleft").Value) Then
                        dgReceivingItem.Rows(i).Cells("ci_qtyleft").ErrorText = "System detected that qty. left to stock has been updated. The has automatically updated the qty. left to stock from " & CInt(dgReceivingItem.Rows(i).Cells("ci_qtyleft").Value) & " to " & CInt(dgReceivingItem.Rows(i).Cells("ci_qtyreceived").Value) - globaltotalqtyapplied & " "
                        dgReceivingItem.Rows(i).Cells("ci_qtyleft").Value = CInt(dgReceivingItem.Rows(i).Cells("ci_qtyreceived").Value) - globaltotalqtyapplied
                    Else
                        dgReceivingItem.Rows(i).Cells("ci_qtyleft").ErrorText = Nothing
                    End If
                Next
            End If
            stockformcomputation()
            If dgRackColumnShelf.Rows.Count <> 0 Then
                If sftotalqtytostock > sftotalqtytostockleft Then
                    For i = 0 To dgRackColumnShelf.Rows.Count - 1
                        dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").ErrorText = "The sum of all qty. to stock should not be greater than qty. left to stock."
                    Next
                    Exit Try
                Else
                    For i = 0 To dgRackColumnShelf.Rows.Count - 1
                        dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").ErrorText = Nothing
                    Next
                End If
            Else
                MessageBox.Show("There is no rack,column, and shelf for stocking.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("NOTE: Once you stock this receiving item, you cannot return back the stock qty. If you wanted to change the current stock qty. of a product, you can use Stock Adjustment or Stock Transfer if you have the access to do so." & vbNewLine & "" & vbNewLine & "Do you want to proceed saving this receiving item?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getPositionID(Me)
                If globalpositionid <> 0 Then
                    getPositionView(globalpositionid, "Stocking To Rack/Shelf/Column", Me)
                    If globalupdateflg <> "Y" Then
                        MessageBox.Show("The user is not allowed stock the receiving item.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        Exit Try
                    End If
                Else
                    MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                getOrderStatus(sforderid, Me)
                If globalorderstatus = "Cancelled" Then
                    MessageBox.Show("The R. R. has been cancelled.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                getOrderItemStatus(sforderitemid, Me)
                If globalorderitemstatus <> "Active" Then
                    MessageBox.Show("The receiving item is not available already.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                getInventoryLocID(Me)
                If sfinventorylocationid = 0 Then
                    MessageBox.Show("System cannot find the inventory location.", "Stocking", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgReceivingItem.Rows.Count <> 0 Then
                    For i = 0 To dgReceivingItem.Rows.Count - 1
                        getTotalQtyAppliedA(CInt(dgReceivingItem.Rows(i).Cells("ci_rowid").Value), Me)
                        If CInt(dgReceivingItem.Rows(i).Cells("ci_qtyreceived").Value) - globaltotalqtyapplied <> CInt(dgReceivingItem.Rows(i).Cells("ci_qtyleft").Value) Then
                            dgReceivingItem.Rows(i).Cells("ci_qtyleft").ErrorText = "System detected that qty. left to stock has been updated. The has automatically updated the qty. left to stock from " & CInt(dgReceivingItem.Rows(i).Cells("ci_qtyleft").Value) & " to " & CInt(dgReceivingItem.Rows(i).Cells("ci_qtyreceived").Value) - globaltotalqtyapplied & " "
                            dgReceivingItem.Rows(i).Cells("ci_qtyleft").Value = CInt(dgReceivingItem.Rows(i).Cells("ci_qtyreceived").Value) - globaltotalqtyapplied
                        Else
                            dgReceivingItem.Rows(i).Cells("ci_qtyleft").ErrorText = Nothing
                        End If
                    Next
                End If
                stockformcomputation()
                If dgRackColumnShelf.Rows.Count <> 0 Then
                    If sftotalqtytostock > sftotalqtytostockleft Then
                        For i = 0 To dgRackColumnShelf.Rows.Count - 1
                            dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").ErrorText = "The sum of all qty. to stock should not be greater than qty. left to stock."
                        Next
                        Exit Try
                    End If
                    For i = 0 To dgRackColumnShelf.Rows.Count - 1
                        If IsNumeric(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value) Then
                            If CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value) > 0 Then
                                If IsNumeric(dgRackColumnShelf.Rows(i).Cells("rcs_rowid").Value) Then
                                    If CInt(dgRackColumnShelf.Rows(i).Cells("rcs_rowid").Value) <> 0 Then
                                        getRCSOrderItemID(CInt(dgRackColumnShelf.Rows(i).Cells("rcs_rowid").Value), sforderitemid, Me)
                                        If glorcsorderitemid = 0 Then
                                            M_I_rscorderitems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_rowid").Value), sforderitemid, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), "Active", Me)
                                        Else
                                            M_U_rscorderitems(glorcsorderitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value) + gloqtyapplied, "Active", Me)
                                        End If
                                        getProductInventoryLocationTotals(CInt(dgRackColumnShelf.Rows(i).Cells("rcs_rowid").Value), Me)
                                        U_ProductInventoryLocationTotals(CInt(dgRackColumnShelf.Rows(i).Cells("rcs_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalpiltotalavailableqty + CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), globalpiltotalreserveqty, Me)
                                        I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, sforderid, DBNull.Value, DBNull.Value, sfprodcolorsizeid, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_rowid").Value),
                                                DBNull.Value, globalpiltotalavailableqty, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), globalpiltotalavailableqty + CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), "Receiving", "TotalAvailableQty", "", Me)

                                        'if leftQtyToStock is equals to qtyToStock trigger stock to damage warehouse
                                        If dgReceivingItem.Rows(i).Cells("ci_qtyleft").Value = dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value Then
                                            Console.WriteLine("test is this working")
                                            If conn.State = ConnectionState.Closed Then conn.Open()
                                            Dim sql1 As String = "SELECT pil.rowid,COALESCE(pil.totalavailableqty,0),pil.rackshelfcolumnid FROM productinventorylocation pil " &
                                            "LEFT JOIN rackshelfcolumn rcs ON pil.rackshelfcolumnid = rcs.rowid WHERE pil.productcolorsizeid = " & sfprodcolorsizeid & " AND pil.organizationid = " & Z_OrganizationID & " AND rcs.inventorylocationid = " & 6 & " ORDER BY rcs.pickorderno ASC "
                                            Dim cmd1 As New MySqlCommand(sql1, conn)
                                            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
                                            Dim damageQty = sfdamageqtyOrdered
                                            While reader1.Read()
                                                U_ProductInventoryLocationTotals(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, reader1(1) + damageQty, reader1(1), Me)
                                                I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, sforderid, DBNull.Value, DBNull.Value, sfprodcolorsizeid, reader1(0),
                                                DBNull.Value, reader1(1), damageQty, reader1(1) + damageQty, "Receiving", "TotalDamageQty", "", Me)
                                            End While
                                        End If


                                    Else

                                    End If
                                Else
                                    getRackShelfColumnID("" & dgRackColumnShelf.Rows(i).Cells("rcs_rack").Value & "" & dgRackColumnShelf.Rows(i).Cells("rcs_shelf").Value & "" & dgRackColumnShelf.Rows(i).Cells("rcs_column").Value & "", sfinventorylocationid, Me)
                                    sfrackcolumnshelfid = globalrackshelfcolumnid
                                    If sfrackcolumnshelfid <> 0 Then
                                        getProductInventoryLocID(sfrackcolumnshelfid, sfprodcolorsizeid, Me)
                                        sfproductinventorylocationid = gloprodctinvtylocid
                                        If sfproductinventorylocationid = 0 Then
                                            I_ProductInventoryLocation(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, sfrackcolumnshelfid, sfprodcolorsizeid, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), Me)
                                            sfproductinventorylocationid = globalproductinventorylocationidsp
                                            M_I_rscorderitems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, sfproductinventorylocationid, sforderitemid, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), "Active", Me)
                                            I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, sforderid, DBNull.Value, DBNull.Value, sfprodcolorsizeid, sfproductinventorylocationid,
                                                    DBNull.Value, 0, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), "New PIL", "TotalAvailableQty", "", Me)
                                        Else
                                            getRCSOrderItemID(sfproductinventorylocationid, sforderitemid, Me)
                                            If glorcsorderitemid = 0 Then
                                                M_I_rscorderitems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, sfproductinventorylocationid, sforderitemid, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), "Active", Me)
                                            Else
                                                M_U_rscorderitems(glorcsorderitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value) + gloqtyapplied, "Active", Me)
                                            End If
                                            getProductInventoryLocationTotals(sfproductinventorylocationid, Me)
                                            U_ProductInventoryLocationTotals(sfproductinventorylocationid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalpiltotalavailableqty + CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), globalpiltotalreserveqty, Me)
                                            I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, sforderid, DBNull.Value, DBNull.Value, sfprodcolorsizeid, sfproductinventorylocationid,
                                                    DBNull.Value, globalpiltotalavailableqty, CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), globalpiltotalavailableqty + CInt(dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value), "Receiving", "TotalAvailableQty", "", Me)
                                            'if leftQtyToStock is equals to qtyToStock trigger stock to damage warehouse
                                            If dgReceivingItem.Rows(i).Cells("ci_qtyleft").Value = dgRackColumnShelf.Rows(i).Cells("rcs_qtytostock").Value Then
                                                Console.WriteLine("test is this working 12345")
                                                If conn.State = ConnectionState.Closed Then conn.Open()
                                                Dim sql1 As String = "SELECT pil.rowid,COALESCE(pil.totalavailableqty,0),pil.rackshelfcolumnid FROM productinventorylocation pil " &
                                                "LEFT JOIN rackshelfcolumn rcs ON pil.rackshelfcolumnid = rcs.rowid WHERE pil.productcolorsizeid = " & sfprodcolorsizeid & " AND pil.organizationid = " & Z_OrganizationID & " AND rcs.inventorylocationid = " & 6 & " ORDER BY rcs.pickorderno ASC "
                                                Dim cmd1 As New MySqlCommand(sql1, conn)
                                                Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
                                                Dim damageQty = sfdamageqtyOrdered
                                                While reader1.Read()
                                                    U_ProductInventoryLocationTotals(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, reader1(1) + damageQty, reader1(1), Me)
                                                    I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, sforderid, DBNull.Value, DBNull.Value, sfprodcolorsizeid, reader1(0),
                                                    DBNull.Value, reader1(1), damageQty, reader1(1) + damageQty, "Receiving", "TotalDamageQty", "", Me)
                                                End While
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                    If myModule.systemerrorfound = False Then
                        MessageBox.Show("Successfully Save.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        stockformcue = legit
                        Me.Close()
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
#Region "Datagrid Errors"
    Private Sub dgReceivingItem_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgReceivingItem.DataError
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
                dgReceivingItem.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgRackColumnShelf_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgRackColumnShelf.DataError
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
                dgRackColumnShelf.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#End Region

    Private ReadOnly Property IsThurston As Boolean
        Get
            Return _systemOwner.IsThurston
        End Get
    End Property
End Class