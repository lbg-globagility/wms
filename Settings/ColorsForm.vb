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
Public Class ColorsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim colorpane As New ColorDialog
    Dim userpref As String
    Public cfcue As Boolean = False
    Private Sub ColorsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            displayProductColors()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
#Region "Display"
    Sub displayProductColors()
        Try
            dgColors.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT c.rowid,COALESCE(c.colorvalue,''),COALESCE(c.colorname,'') FROM colors c WHERE c.organizationid = " & Z_OrganizationID & " ORDER BY c.colorname ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgColors.Rows.Add()
                    dgColors.Item(c_seqno.Index, n).Value = seqno
                    dgColors.Item(c_rowid.Index, n).Value = reader1(0)
                    dgColors.Item(c_colorvalue.Index, n).Value = reader1(1)
                    dgColors.Item(c_colorname.Index, n).Value = reader1(2)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgColors.Columns("c_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgColors.Columns("c_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgColors.Rows.Count <> 0 Then
                dgColors.CurrentRow.Selected = False
            End If
            colorCoding()
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
            If dgColors.Rows.Count <> 0 Then
                For i As Integer = 0 To dgColors.Rows.Count - 1
                    If CStr(dgColors.Rows(i).Cells("c_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgColors.Rows(i).Cells("c_colorvalue").Value))
                        dgColors.Rows(i).Cells("c_color").Style.BackColor = readcolor
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
    Private Sub dgColors_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgColors.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.ColumnIndex = dgColors.Columns("c_choosecolor").Index Then
                If (colorpane.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                    userpref = colorconverter.ConvertToString(colorpane.Color)
                    dgColors.CurrentRow.Cells("c_colorvalue").Value = userpref
                    colorCoding()
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
            dgColors.CommitEdit(True)
            myModule.systemerrorfound = False
            If dgColors.Rows.Count = 0 Then
                MessageBox.Show("There is nothing to save in this form.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    For u = 0 To dgColors.Rows.Count - 1
                        If myModule.systemerrorfound = False Then
                            U_Colors(CInt(dgColors.Rows(u).Cells("c_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, dgColors.Rows(u).Cells("c_colorname").Value, dgColors.Rows(u).Cells("c_colorvalue").Value, Me)
                        Else
                            Exit Sub
                        End If
                    Next
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cfcue = legit
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
End Class