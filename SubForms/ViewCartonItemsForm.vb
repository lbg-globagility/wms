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
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces
Public Class ViewCartonItemsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim vciqtyincartonsum As Integer
    Public vcicartonid As Integer
    Private _systemOwner As SystemOwner

    Private Async Sub ViewCartonItemsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        If IsThurston Then
            lblTitle.Text = "View Contents"
            Label4.Text = "Total Quantity (Sum):"
            cai_qtyincarton.HeaderText = "Quantity"
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            displayPackingListCartonItems(vcicartonid)
            colorCoding() : viewcartonitemscomputation()
            If dgCartonItems.Rows.Count <> 0 Then
                dgCartonItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
#Region "Computations"
    Sub viewcartonitemscomputation()
        Try
            vciqtyincartonsum = 0
            If dgCartonItems.Rows.Count <> 0 Then
                For i = 0 To dgCartonItems.Rows.Count - 1
                    If IsNumeric(dgCartonItems.Rows(i).Cells("cai_qtyincarton").Value) Then
                        vciqtyincartonsum = vciqtyincartonsum + CInt(dgCartonItems.Rows(i).Cells("cai_qtyincarton").Value)
                    End If
                Next
            End If
            txtQtyInCartonSum.Text = Format(vciqtyincartonsum, "#,##0")
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
            If dgCartonItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgCartonItems.Rows.Count - 1
                    If CStr(dgCartonItems.Rows(i).Cells("cai_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgCartonItems.Rows(i).Cells("cai_colorvalue").Value))
                        dgCartonItems.Rows(i).Cells("cai_color").Style.BackColor = readcolor
                    End If
                    If dgCartonItems.Rows(i).Cells(cai_type.Index).Value = "BI" Then
                        dgCartonItems.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.PaleGreen
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
#Region "Datagrids"
    Sub displayPackingListCartonItems(ByVal ipackinglistcartonid As Integer)
        Try
            dgCartonItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pci.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pci.qtyincarton,0),COALESCE(pcs.sku,''),COALESCE(oi.unitofmeasure,''),COALESCE(oi.itemtype,''),COALESCE(oi.sku,'') " &
                    "FROM packinglistcartonitems pci LEFT JOIN orderitems oi ON pci.orderitemid = oi.rowid LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " &
                    "LEFT JOIN products p ON pc.productid = p.rowid INNER JOIN picklistorders plo ON plo.OrderItemID=pci.OrderItemID INNER JOIN picklistorderitems ploi ON ploi.PickListOrderID=plo.RowID AND ploi.`status` NOT IN ('Cancelled', 'Inactive')
#AND oi.ProductInventoryLocationId=ploi.ProductInventoryLocationID
AND ploi.QtyPicked > 0
INNER JOIN picklist pl ON pl.RowID=plo.PickListID AND pl.`Status` NOT IN ('Cancelled', 'Cancelled')
WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.status != 'Inactive' ORDER BY p.productcode,c.colorname,pcs.size "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgCartonItems.Rows.Add()
                    dgCartonItems.Item(cai_seqno.Index, n).Value = seqno
                    dgCartonItems.Item(cai_rowid.Index, n).Value = reader1(0)
                    dgCartonItems.Item(cai_colorvalue.Index, n).Value = reader1(1)
                    dgCartonItems.Item(cai_productcode.Index, n).Value = reader1(2)
                    dgCartonItems.Item(cai_colorname.Index, n).Value = reader1(3)
                    dgCartonItems.Item(cai_color.Index, n).Value = ""
                    dgCartonItems.Item(cai_size.Index, n).Value = reader1(4)
                    dgCartonItems.Item(cai_seasoncode.Index, n).Value = reader1(5)
                    dgCartonItems.Item(cai_qtyincarton.Index, n).Value = reader1(6)
                    If LTrim(CStr(reader1(10))) = "" Then
                        dgCartonItems.Item(cai_sku.Index, n).Value = reader1(7)
                    Else
                        dgCartonItems.Item(cai_sku.Index, n).Value = reader1(10)
                    End If
                    dgCartonItems.Item(cai_unitofmeasure.Index, n).Value = reader1(8)
                    dgCartonItems.Item(cai_type.Index, n).Value = reader1(9)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCartonItems.Columns("cai_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_qtyincarton").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region

    Private ReadOnly Property IsThurston As Boolean
        Get
            Return _systemOwner.IsThurston
        End Get
    End Property
End Class