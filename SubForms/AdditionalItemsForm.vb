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
Public Class AdditionalItemsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim conn1 As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim itemno, rowscount, aifproductcolorsizesid, aifproductid, aiftotalqtyreceivedgood, aiftotalqtyreceivedbad As Integer
    Public aifordertype As String
    Public additionalitemsformcue As Boolean = False
    Public aiforderid, aifrrid, aifaccountid As Integer
    Private Sub AdditionalItemsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoPopulate()
            If aifordertype = "Blank" Then
                msSave.Text = "&Add"
            ElseIf aifordertype = "PO" Then
                msSave.Text = "&Save"
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Function"
    Sub callAutoPopulate()
        autopopulatecboBy()
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            txtTotalQtyReceivedGood.Text = ""
            txtTotalQtyReceivedBad.Text = ""
            clearAddProductA()
            clearDatagrids()
            visibleGB(fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearAddProductA()
        Try
            cboByPhrase.Text = ""
            txtQtyReceivedGood.Text = ""
            txtQtyReceivedBad.Text = ""
            cboBy.SelectedItem = Nothing
            cboByPhrase.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearDatagrids()
        Try
            dgProductColorSizes.Rows.Clear()
            dgProductColors.Rows.Clear()
            dgProductSizes.Rows.Clear()
            dgReceivingItems.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub visibleGB(ByVal visible1 As Boolean, ByVal visible2 As Boolean)
        Try
            dgProductColorSizes.Visible = visible1
            dgProductColors.Visible = visible2
            dgProductSizes.Visible = visible2
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Computations"
    Sub receivingitemscomputations()
        Try
            aiftotalqtyreceivedgood = 0 : aiftotalqtyreceivedbad = 0
            If dgReceivingItems.Rows.Count <> 0 Then
                For i = 0 To dgReceivingItems.Rows.Count - 1
                    If IsNumeric(dgReceivingItems.Rows(i).Cells("ci_qtyreceived").Value) Then
                        aiftotalqtyreceivedgood = aiftotalqtyreceivedgood + CInt(dgReceivingItems.Rows(i).Cells("ci_qtyreceived").Value)
                    End If
                    If IsNumeric(dgReceivingItems.Rows(i).Cells("ci_qtybad").Value) Then
                        aiftotalqtyreceivedbad = aiftotalqtyreceivedbad + CInt(dgReceivingItems.Rows(i).Cells("ci_qtybad").Value)
                    End If
                Next
            End If
            txtTotalQtyReceivedGood.Text = Format(aiftotalqtyreceivedgood, "#,##0")
            txtTotalQtyReceivedBad.Text = Format(aiftotalqtyreceivedbad, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Click"
    Sub btnAddperformclick()
        Try
            errProvider.Clear()
            If cboBy.Text <> "" Then
                If LTrim(cboByPhrase.Text) = "" Then
                    errProvider.SetError(btnAddProduct, "Please fill-up this box.")
                    cboByPhrase.Focus()
                    Exit Try
                ElseIf cboBy.Text = "Combination" Then
                    If Not IsNumeric(txtQtyReceivedGood.Text) AndAlso Not IsNumeric(txtQtyReceivedBad.Text) Then
                        errProvider.SetError(btnAddProduct, "Please use numbers for qty. received (good) and qty. received (bad).")
                        txtQtyReceivedGood.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(btnAddProduct, "System cannot find the combination code.")
                        cboByPhrase.Focus()
                    Else
                        checkSupplierOrderItemsA()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    If dgProductSizes.Rows.Count = 0 Then
                        errProvider.SetError(btnAddProduct, "System cannot find the sizes.")
                        cboByPhrase.Focus()
                    Else
                        checkSupplierOrderItemsB()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    If Not IsNumeric(txtQtyReceivedGood.Text) AndAlso Not IsNumeric(txtQtyReceivedBad.Text) Then
                        errProvider.SetError(btnAddProduct, "Please use numbers for qty. received (good) and qty. received (bad).")
                        txtQtyReceivedGood.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(btnAddProduct, "System cannot find the sku.")
                        cboByPhrase.Focus()
                    Else
                        If dgProductColorSizes.Rows.Count <> 0 Then
                            checkSupplierOrderItemsA()
                        End If
                    End If
                End If
            Else
                errProvider.SetError(btnAddProduct, "Please select the By options.")
                cboBy.Focus()
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "AutoPopulate"
    Sub autopopulatecboBy()
        Try
            cboBy.Items.Clear()
            cboBy.Items.Add("Combination")
            cboBy.Items.Add("ProductCode")
            cboBy.Items.Add("SKU")
            cboBy.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Datagrids"
    Sub displayProductsA(ByVal iproductcolorsizeid As Integer)
        Try
            dgProductColorSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,'') FROM productcolorsizes pcs  " & _
                        "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.rowid = " & iproductcolorsizeid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductColorSizes.Rows.Add()
                    dgProductColorSizes.Item(pcs_rowid.Index, n).Value = reader1(0)
                    dgProductColorSizes.Item(pcs_colorvalue.Index, n).Value = reader1(1)
                    dgProductColorSizes.Item(pcs_productcode.Index, n).Value = reader1(2)
                    dgProductColorSizes.Item(pcs_colorname.Index, n).Value = reader1(3)
                    dgProductColorSizes.Item(pcs_color.Index, n).Value = ""
                    dgProductColorSizes.Item(pcs_size.Index, n).Value = reader1(4)
                    dgProductColorSizes.Item(pcs_seasoncode.Index, n).Value = reader1(5)
                    dgProductColorSizes.Item(pcs_sku.Index, n).Value = reader1(6)
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    dgProductColorSizes.Item(pcs_qtyavailable.Index, n).Value = globaltotalqtyavailable
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductColorSizes.Columns("pcs_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductColorSizes.Rows.Count <> 0 Then
                dgProductColorSizes.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayProductsB(ByVal iproductid As Integer)
        Try
            dgProductColors.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pc.rowid,COALESCE(c.colorvalue,''),COALESCE(c.colorname,'') FROM productcolors pc LEFT JOIN colors c ON pc.colorid = c.rowid " & _
                            "WHERE pc.organizationid = " & Z_OrganizationID & " AND pc.productid = " & iproductid & " ORDER BY c.colorname ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductColors.Rows.Add()
                    dgProductColors.Item(c_seqno.Index, n).Value = seqno
                    dgProductColors.Item(c_rowid.Index, n).Value = reader1(0)
                    dgProductColors.Item(c_colorvalue.Index, n).Value = reader1(1)
                    dgProductColors.Item(c_colorname.Index, n).Value = reader1(2)
                    dgProductColors.Item(c_color.Index, n).Value = ""
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductColors.Columns("c_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColors.Columns("c_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductColors.Rows.Count <> 0 Then
                dgProductColors.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayProductsC(ByVal iproductcolorid As Integer)
        Try
            dgProductSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(pcs.size,0.0),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,'') FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
                        "LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.productcolorid = " & iproductcolorid & " AND pcs.status = 'Active' ORDER BY pcs.size ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductSizes.Rows.Add()
                    dgProductSizes.Item(s_rowid.Index, n).Value = reader1(0)
                    dgProductSizes.Item(s_sizes.Index, n).Value = reader1(1)
                    dgProductSizes.Item(s_seasoncode.Index, n).Value = reader1(2)
                    dgProductSizes.Item(s_sku.Index, n).Value = reader1(3)
                    dgProductSizes.Item(s_qtyreceived.Index, n).Value = ""
                    getTotalQtyAvailableA(CInt(reader1(0)), Me)
                    dgProductSizes.Item(s_qtyavailable.Index, n).Value = globaltotalqtyavailable
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductSizes.Columns("s_sizes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductSizes.Rows.Count <> 0 Then
                dgProductSizes.CurrentRow.Selected = False
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
            If dgProductColors.Rows.Count <> 0 Then
                For i As Integer = 0 To dgProductColors.Rows.Count - 1
                    If CStr(dgProductColors.Rows(i).Cells("c_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgProductColors.Rows(i).Cells("c_colorvalue").Value))
                        dgProductColors.Rows(i).Cells("c_color").Style.BackColor = readcolor
                    End If
                Next
            End If
            If dgReceivingItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgReceivingItems.Rows.Count - 1
                    If CStr(dgReceivingItems.Rows(i).Cells("ci_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgReceivingItems.Rows(i).Cells("ci_colorvalue").Value))
                        dgReceivingItems.Rows(i).Cells("ci_color").Style.BackColor = readcolor
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
#Region "Adding Functions"
    Sub checkSupplierOrderItemsA()
        Try
            If dgProductColorSizes.Rows.Count <> 0 Then
                For p = 0 To dgProductColorSizes.Rows.Count - 1
                    If aifordertype = "PO" Then
                        getOrderItemIDA(aiforderid, CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), Me)
                        If globalorderitemid <> 0 Then
                            errProvider.SetError(btnAddProduct, "Product is in the list already.")
                            cboByPhrase.Focus()
                            Exit Try
                        End If
                    End If
                    If dgReceivingItems.Rows.Count <> 0 Then
                        rowscount = dgReceivingItems.Rows.Count - 1
                        For i = 0 To dgReceivingItems.Rows.Count - 1
                            If dgReceivingItems.Rows(i).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                errProvider.SetError(btnAddProduct, "Product is in the list already.")
                                cboByPhrase.Focus()
                                Exit Try
                            ElseIf rowscount = 0 Then
                                addSupplierOrderItemA(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CStr(txtQtyReceivedGood.Text), CStr(txtQtyReceivedBad.Text))
                                For a = 0 To dgReceivingItems.Rows.Count - 1
                                    dgReceivingItems.CurrentRow.Selected = fraud
                                    If dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                        dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Selected = legit
                                        dgReceivingItems.FirstDisplayedScrollingRowIndex = dgReceivingItems.RowCount - 1
                                        Exit For
                                    End If
                                Next
                                cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyReceivedGood.Text = "" : txtQtyReceivedBad.Text = "" : cboByPhrase.Focus()
                            End If
                            rowscount = rowscount - 1
                        Next
                    Else
                        addSupplierOrderItemA(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CStr(txtQtyReceivedGood.Text), CStr(txtQtyReceivedBad.Text))
                        For a = 0 To dgReceivingItems.Rows.Count - 1
                            dgReceivingItems.CurrentRow.Selected = fraud
                            If dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Selected = legit
                                dgReceivingItems.FirstDisplayedScrollingRowIndex = dgReceivingItems.RowCount - 1
                                Exit For
                            End If
                        Next
                        cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyReceivedGood.Text = "" : txtQtyReceivedBad.Text = "" : cboByPhrase.Focus()
                    End If
                Next
                itemno = 1 : colorCoding() : receivingitemscomputations()
                For i As Integer = 0 To dgReceivingItems.Rows.Count - 1
                    dgReceivingItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub checkSupplierOrderItemsB()
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                For p = 0 To dgProductSizes.Rows.Count - 1
                    If IsNumeric(dgProductSizes.Rows(p).Cells("s_qtyreceived").Value) Then
                        If CInt(dgProductSizes.Rows(p).Cells("s_qtyreceived").Value) > 0 Then
                            If dgReceivingItems.Rows.Count <> 0 Then
                                rowscount = dgReceivingItems.Rows.Count - 1
                                For i = 0 To dgReceivingItems.Rows.Count - 1
                                    If aifordertype = "PO" Then
                                        getOrderItemIDA(aiforderid, CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), Me)
                                        If globalorderitemid <> 0 Then
                                            Exit For
                                        End If
                                    End If
                                    If dgReceivingItems.Rows(i).Cells("ci_pcsrowid").Value = dgProductSizes.Rows(p).Cells("s_rowid").Value Then
                                        Exit For
                                    ElseIf rowscount = 0 Then
                                        addSupplierOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CStr(dgProductSizes.Rows(p).Cells("s_qtyreceived").Value), CStr(dgProductSizes.Rows(p).Cells("s_qtybad").Value))
                                    End If
                                    rowscount = rowscount - 1
                                Next
                            Else
                                If aifordertype = "PO" Then
                                    getOrderItemIDA(aiforderid, CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), Me)
                                    If globalorderitemid = 0 Then
                                        addSupplierOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CStr(dgProductSizes.Rows(p).Cells("s_qtyreceived").Value), CStr(dgProductSizes.Rows(p).Cells("s_qtybad").Value))
                                    End If
                                Else
                                    addSupplierOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CStr(dgProductSizes.Rows(p).Cells("s_qtyreceived").Value), CStr(dgProductSizes.Rows(p).Cells("s_qtybad").Value))
                                End If
                            End If
                        End If
                    End If
                Next
                itemno = 1 : colorCoding() : receivingitemscomputations()
                For i As Integer = 0 To dgReceivingItems.Rows.Count - 1
                    dgReceivingItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
                If dgReceivingItems.Rows.Count <> 0 Then
                    dgReceivingItems.CurrentRow.Selected = False
                    dgReceivingItems.FirstDisplayedScrollingRowIndex = dgReceivingItems.RowCount - 1
                End If
                cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyReceivedGood.Text = "" : txtQtyReceivedBad.Text = "" : cboByPhrase.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub addSupplierOrderItemA(ByVal iproductcolorsizeid As Integer, ByVal iqtyreceivedgood As String, ByVal iqtyreceivedbad As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(p.unitofmeasure,''),COALESCE(pcs.sku,''),COALESCE(pcs.seasoncode,'') " & _
                "FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.rowid = " & iproductcolorsizeid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    dgReceivingItems.Rows.Add()
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_rowid").Value = ""
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_remarks").Value = ""
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_reason").Value = ""
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = reader1(0)
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_colorvalue").Value = reader1(1)
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_productcode").Value = reader1(2)
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_colorname").Value = reader1(3)
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_size").Value = reader1(4)
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = reader1(5)
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_sku").Value = reader1(6)
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_seasoncode").Value = reader1(7)
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_qtyreceived").Value = iqtyreceivedgood
                    dgReceivingItems.Rows(dgReceivingItems.Rows.Count - 1).Cells("ci_qtybad").Value = iqtyreceivedbad
                End If
            End While
            reader1.Close()
            dgReceivingItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_qtyreceived").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_qtybad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgReceivingItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region
    Private Sub btnAddProduct_Leave(sender As Object, e As EventArgs) Handles btnAddProduct.Leave
        Try
            cboByPhrase.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBy.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            txtQtyReceivedGood.Text = ""
            txtQtyReceivedBad.Text = ""
            If cboBy.Text = "" Then
                cboByPhrase.Items.Clear() : cboByPhrase.AutoCompleteCustomSource.Clear()
                visibleGB(fraud, fraud)
            ElseIf cboBy.Text = "Combination" Then
                globalautocompleteByCombination(cboByPhrase, Me)
                globalautopopulateByCombination(cboByPhrase, Me)
                visibleGB(legit, fraud)
            ElseIf cboBy.Text = "ProductCode" Then
                globalautocompleteByProductCode(cboByPhrase, Me)
                globalautopopulateByProductCode(cboByPhrase, Me)
                visibleGB(fraud, legit)
            ElseIf cboBy.Text = "SKU" Then
                globalautocompleteBySKU(cboByPhrase, Me)
                globalautopopulateBySKU(cboByPhrase, Me)
                visibleGB(legit, fraud)
            End If
            cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub cboByPhrase_Leave(sender As Object, e As EventArgs) Handles cboByPhrase.Leave
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cboByPhrase.Text <> "" Then
    '            If cboBy.Text = "" Then
    '                dgProductColorSizes.Rows.Clear()
    '                dgProductColors.Rows.Clear()
    '                dgProductSizes.Rows.Clear()
    '            ElseIf cboBy.Text = "Combination" Then
    '                getProductColorSizesIDB(cboByPhrase.Text, Me)
    '                aifproductcolorsizesid = globalproductcolorsizesid
    '                If aifproductcolorsizesid <> 0 Then
    '                    displayProductsA(aifproductcolorsizesid)
    '                    colorCoding()
    '                Else
    '                    dgProductColorSizes.Rows.Clear()
    '                End If
    '            ElseIf cboBy.Text = "ProductCode" Then
    '                getProductIDB(cboByPhrase.Text, Me)
    '                aifproductid = globalproductid
    '                If aifproductid <> 0 Then
    '                    displayProductsB(aifproductid)
    '                    colorCoding()
    '                Else
    '                    dgProductColors.Rows.Clear()
    '                    dgProductSizes.Rows.Clear()
    '                End If
    '            ElseIf cboBy.Text = "SKU" Then
    '                getProductColorSizesSKUA(cboByPhrase.Text, Me)
    '                aifproductcolorsizesid = globalskuid
    '                If aifproductcolorsizesid <> 0 Then
    '                    displayProductsA(aifproductcolorsizesid)
    '                    colorCoding()
    '                Else
    '                    dgProductColorSizes.Rows.Clear()
    '                End If
    '            End If
    '        Else
    '            dgProductColorSizes.Rows.Clear()
    '            dgProductColors.Rows.Clear()
    '            dgProductSizes.Rows.Clear()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub cboByPhrase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboByPhrase.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cboByPhrase.Text <> "" Then
                If cboBy.Text = "" Then
                    dgProductColorSizes.Rows.Clear()
                    dgProductColors.Rows.Clear()
                    dgProductSizes.Rows.Clear()
                ElseIf cboBy.Text = "Combination" Then
                    getProductColorSizesIDB(cboByPhrase.Text, Me)
                    aifproductcolorsizesid = globalproductcolorsizesid
                    If aifproductcolorsizesid <> 0 Then
                        displayProductsA(aifproductcolorsizesid)
                        colorCoding()
                    Else
                        dgProductColorSizes.Rows.Clear()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    getProductIDB(cboByPhrase.Text, Me)
                    aifproductid = globalproductid
                    If aifproductid <> 0 Then
                        displayProductsB(aifproductid)
                        colorCoding()
                    Else
                        dgProductColors.Rows.Clear()
                        dgProductSizes.Rows.Clear()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    getProductColorSizesSKUA(cboByPhrase.Text, Me)
                    aifproductcolorsizesid = globalskuid
                    If aifproductcolorsizesid <> 0 Then
                        displayProductsA(aifproductcolorsizesid)
                        colorCoding()
                    Else
                        dgProductColorSizes.Rows.Clear()
                    End If
                End If
            Else
                dgProductColorSizes.Rows.Clear()
                dgProductColors.Rows.Clear()
                dgProductSizes.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboByPhrase_TextChanged(sender As Object, e As EventArgs) Handles cboByPhrase.TextChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cboByPhrase.Text <> "" Then
                If cboBy.Text = "" Then
                    dgProductColorSizes.Rows.Clear()
                    dgProductColors.Rows.Clear()
                    dgProductSizes.Rows.Clear()
                ElseIf cboBy.Text = "Combination" Then
                    getProductColorSizesIDB(cboByPhrase.Text, Me)
                    aifproductcolorsizesid = globalproductcolorsizesid
                    If aifproductcolorsizesid <> 0 Then
                        displayProductsA(aifproductcolorsizesid)
                        colorCoding()
                    Else
                        dgProductColorSizes.Rows.Clear()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    getProductIDB(cboByPhrase.Text, Me)
                    aifproductid = globalproductid
                    If aifproductid <> 0 Then
                        displayProductsB(aifproductid)
                        colorCoding()
                    Else
                        dgProductColors.Rows.Clear()
                        dgProductSizes.Rows.Clear()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    getProductColorSizesSKUA(cboByPhrase.Text, Me)
                    aifproductcolorsizesid = globalskuid
                    If aifproductcolorsizesid <> 0 Then
                        displayProductsA(aifproductcolorsizesid)
                        colorCoding()
                    Else
                        dgProductColorSizes.Rows.Clear()
                    End If
                End If
            Else
                dgProductColorSizes.Rows.Clear()
                dgProductColors.Rows.Clear()
                dgProductSizes.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            btnAddperformclick()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgProductColors_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductColors.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductColors.Rows.Count <> 0 Then
                displayProductsC(CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value))
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgProductColors_KeyUp(sender As Object, e As KeyEventArgs) Handles dgProductColors.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductColors.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    displayProductsC(CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value))
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgProductSizes_KeyDown(sender As Object, e As KeyEventArgs) Handles dgProductSizes.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Enter Then
                    btnAddperformclick()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtQtyReceivedGood_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQtyReceivedGood.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                btnAddperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtQtyReceivedBad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQtyReceivedBad.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                btnAddperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtQtyReceivedGood_TextChanged(sender As Object, e As EventArgs) Handles txtQtyReceivedGood.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub txtQtyReceivedBad_TextChanged(sender As Object, e As EventArgs) Handles txtQtyReceivedBad.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgReceivingOrderItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReceivingItems.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgReceivingItems.Rows.Count <> 0 Then
                If e.ColumnIndex = dgReceivingItems.Columns("ci_option").Index Then
                    If IsNumeric(dgReceivingItems.CurrentRow.Cells("ci_rowid").Value) Then
                        If dgReceivingItems.CurrentRow.Cells("ci_rowid").Value = 0 Then
                            If dgReceivingItems.SelectedRows.Count > 0 Then
                                dgReceivingItems.Rows.Remove(dgReceivingItems.SelectedRows(0))
                            End If
                        End If
                    Else
                        If dgReceivingItems.SelectedRows.Count > 0 Then
                            dgReceivingItems.Rows.Remove(dgReceivingItems.SelectedRows(0))
                        End If
                    End If
                    itemno = startingpage
                    For i As Integer = 0 To dgReceivingItems.Rows.Count - 1
                        dgReceivingItems.Rows(i).Cells("ci_seqno").Value = itemno
                        itemno = itemno + 1
                    Next i
                    receivingitemscomputations()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgReceivingOrderItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgReceivingItems.CellEndEdit
        Try
            receivingitemscomputations()
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
            receivingitemscomputations()
            dgReceivingItems.CommitEdit(legit) : dgReceivingItems.ClearSelection() : dgReceivingItems.CurrentCell = Nothing
            myModule.systemerrorfound = False
            If dgReceivingItems.Rows.Count <> 0 Then
                If aifordertype = "Blank" Then
                    If ReceivingForm.dgReceivingItems.Rows.Count = 0 Then
                        For i As Integer = 0 To dgReceivingItems.Rows.Count - 1
                            ReceivingForm.dgReceivingItems.Rows.Add()
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_color").Value = ""
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_bid").Value = ""
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_rowid").Value = dgReceivingItems.Rows(i).Cells("ci_rowid").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = dgReceivingItems.Rows(i).Cells("ci_pcsrowid").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_colorvalue").Value = dgReceivingItems.Rows(i).Cells("ci_colorvalue").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_productcode").Value = dgReceivingItems.Rows(i).Cells("ci_productcode").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_colorname").Value = dgReceivingItems.Rows(i).Cells("ci_colorname").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_size").Value = dgReceivingItems.Rows(i).Cells("ci_size").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_seasoncode").Value = dgReceivingItems.Rows(i).Cells("ci_seasoncode").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_sku").Value = dgReceivingItems.Rows(i).Cells("ci_sku").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = dgReceivingItems.Rows(i).Cells("ci_unitofmeasure").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_qtyreceived").Value = If(IsNumeric(dgReceivingItems.Rows(i).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(i).Cells("ci_qtyreceived").Value), 0)
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_qtybad").Value = If(IsNumeric(dgReceivingItems.Rows(i).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(i).Cells("ci_qtybad").Value), 0)
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_remarks").Value = dgReceivingItems.Rows(i).Cells("ci_remarks").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_reason").Value = dgReceivingItems.Rows(i).Cells("ci_reason").Value
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_qtyordered").Value = 0
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_qtystocked").Value = 0
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_itemtype").Value = "S"
                            ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_approved").Value = fraud
                        Next
                    Else
                        For i As Integer = 0 To dgReceivingItems.Rows.Count - 1
                            rowscount = ReceivingForm.dgReceivingItems.Rows.Count - 1
                            For b As Integer = 0 To ReceivingForm.dgReceivingItems.Rows.Count - 1
                                If dgReceivingItems.Rows(i).Cells("ci_pcsrowid").Value = ReceivingForm.dgReceivingItems.Rows(b).Cells("ci_pcsrowid").Value Then
                                    Exit For
                                ElseIf rowscount = 0 Then
                                    ReceivingForm.dgReceivingItems.Rows.Add()
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_color").Value = ""
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_bid").Value = ""
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_rowid").Value = dgReceivingItems.Rows(i).Cells("ci_rowid").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = dgReceivingItems.Rows(i).Cells("ci_pcsrowid").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_colorvalue").Value = dgReceivingItems.Rows(i).Cells("ci_colorvalue").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_productcode").Value = dgReceivingItems.Rows(i).Cells("ci_productcode").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_colorname").Value = dgReceivingItems.Rows(i).Cells("ci_colorname").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_size").Value = dgReceivingItems.Rows(i).Cells("ci_size").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_seasoncode").Value = dgReceivingItems.Rows(i).Cells("ci_seasoncode").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_sku").Value = dgReceivingItems.Rows(i).Cells("ci_sku").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = dgReceivingItems.Rows(i).Cells("ci_unitofmeasure").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_qtyreceived").Value = If(IsNumeric(dgReceivingItems.Rows(i).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(i).Cells("ci_qtyreceived").Value), 0)
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_qtybad").Value = If(IsNumeric(dgReceivingItems.Rows(i).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(i).Cells("ci_qtybad").Value), 0)
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_remarks").Value = dgReceivingItems.Rows(i).Cells("ci_remarks").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_reason").Value = dgReceivingItems.Rows(i).Cells("ci_reason").Value
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_qtyordered").Value = 0
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_qtystocked").Value = 0
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_itemtype").Value = "S"
                                    ReceivingForm.dgReceivingItems.Rows(ReceivingForm.dgReceivingItems.Rows.Count - 1).Cells("ci_approved").Value = fraud
                                End If
                                rowscount = rowscount - 1
                            Next
                        Next
                    End If
                    additionalitemsformcue = legit
                    Me.Close()
                ElseIf aifordertype = "PO" Then
                    getOrderStatus(aifrrid, Me)
                    If globalorderstatus <> "For Approval" Then
                        MessageBox.Show("This R. R. has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If MessageBox.Show("NOTE: Receiving Item/s will be directly added to the related order." & vbNewLine & "" & vbNewLine & "Would you like to save this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        For a = 0 To dgReceivingItems.Rows.Count - 1
                            If myModule.systemerrorfound = False Then
                                If IsNumeric(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                    If CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                        If IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value) Or IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value) Then
                                            If If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0) > 0 Or If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0) > 0 Then
                                                getOrderItemIDA(aiforderid, CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                If globalorderitemid = 0 Then
                                                    getTotalQtyAvailableA(CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                    M_I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(aifaccountid = 0, DBNull.Value, aifaccountid), aiforderid, CInt(dgReceivingItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, 0, globaltotalqtyavailable, "A", _
                                                            "" & CStr(dgReceivingItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgReceivingItems.Rows(a).Cells("ci_seasoncode").Value) & "", _
                                                            CStr(dgReceivingItems.Rows(a).Cells("ci_sku").Value), CStr(dgReceivingItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgReceivingItems.Rows(a).Cells("ci_remarks").Value), 0.0, "Active",
                                                            If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtyreceived").Value), 0), "N", If(IsNumeric(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), CInt(dgReceivingItems.Rows(a).Cells("ci_qtybad").Value), 0), CStr(dgReceivingItems.Rows(a).Cells("ci_reason").Value), Me)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                Exit Sub
                            End If
                        Next
                        If myModule.systemerrorfound = False Then
                            MessageBox.Show("Successfully Save.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            additionalitemsformcue = legit
                            Me.Close()
                        End If
                    End If
                End If
            Else
                MessageBox.Show("There is nothing to Add/Save in this page.", "Adding/Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Datagrid MouseUp"
    Private Sub dgProductSizes_MouseUp(sender As Object, e As MouseEventArgs) Handles dgProductSizes.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgProductSizes.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgProductSizes.BeginEdit(True)
                Else
                    dgProductSizes.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgReceivingItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgReceivingItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgReceivingItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgReceivingItems.BeginEdit(True)
                Else
                    dgReceivingItems.EndEdit()
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
    Private Sub dgProductColors_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductColors.DataError
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
                dgProductColors.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgProductSizes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductSizes.DataError
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
                dgProductSizes.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgReceivingItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgReceivingItems.DataError
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
                dgReceivingItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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