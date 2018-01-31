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
Public Class ViewCartonsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim vcqtyincartonsum As Integer
    Public vcpackinglistid, vcorderitemid As Integer
    Private Sub ViewCartons_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            displayPackingListCartons(vcpackinglistid, vcorderitemid)
            packinglistcomputations()
            If dgCartons.Rows.Count <> 0 Then
                dgCartons.CurrentRow.Selected = False
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
    Sub packinglistcomputations()
        Try
            vcqtyincartonsum = 0
            If dgCartons.Rows.Count <> 0 Then
                For i = 0 To dgCartons.Rows.Count - 1
                    If IsNumeric(dgCartons.Rows(i).Cells("ca_qtyincarton").Value) Then
                        vcqtyincartonsum = vcqtyincartonsum + CInt(dgCartons.Rows(i).Cells("ca_qtyincarton").Value)
                    End If
                Next
            End If
            txtQtyInCartonSum.Text = Format(vcqtyincartonsum, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Datagrids"
    Sub displayPackingListCartons(ByVal ipackinglistid As Integer, ByVal iorderitemid As Integer)
        Try
            dgCartons.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pci.rowid,COALESCE(pc.cartonno,''),COALESCE(pci.qtyincarton,0),COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(DATE_FORMAT(pc.packeddate,'%d-%b-%Y'),''),COALESCE(pc.`status`,'') " & _
                        "FROM packinglistcartonitems pci LEFT JOIN packinglistcartons pc ON pci.packinglistcartonid = pc.rowid LEFT JOIN contacts c ON pc.contactid = c.rowid WHERE pc.packinglistid = " & ipackinglistid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' AND pci.orderitemid = " & iorderitemid & " ORDER BY pc.cartonno "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCartons.Rows.Add()
                    dgCartons.Item(ca_rowid.Index, n).Value = reader1(0)
                    dgCartons.Item(ca_cartonno.Index, n).Value = reader1(1)
                    dgCartons.Item(ca_qtyincarton.Index, n).Value = reader1(2)
                    dgCartons.Item(ca_packername.Index, n).Value = reader1(3)
                    dgCartons.Item(ca_packeddate.Index, n).Value = reader1(4)
                    dgCartons.Item(ca_status.Index, n).Value = reader1(5)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCartons.Columns("ca_cartonno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_qtyincarton").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region
End Class