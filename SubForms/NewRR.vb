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
Public Class NewRR
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Public nrorderid As Integer = 0
    Public nrrnewrrtype As String = ""
    Public newrrcue As Boolean = False
    Private Sub NewRR_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            gloPoNo = 0
            rdPO.Checked = fraud
            cboPONo.Text = ""
            rdReturnNo.Checked = fraud
            cboReturned.Text = ""
            rdPulloutno.Checked = fraud
            cboPullout.Text = ""
            rdBlankRR.Checked = fraud
            cboPONo.SelectedItem = Nothing
            cboReturned.SelectedItem = Nothing
            cboPullout.SelectedItem = Nothing
            cboPONo.Visible = fraud
            cboReturned.Visible = fraud
            cboPullout.Visible = fraud
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboPONo_TextChanged(sender As Object, e As EventArgs) Handles cboPONo.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboPONo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPONo.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboReturned_TextChanged(sender As Object, e As EventArgs) Handles cboReturned.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboReturned_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReturned.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboPullout_TextChanged(sender As Object, e As EventArgs) Handles cboPullout.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboPullout_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPullout.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub rdPO_CheckedChanged(sender As Object, e As EventArgs) Handles rdPO.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If rdPO.Checked = True Then
                errProvider.Clear()
                cboPONo.Text = ""
                cboPONo.SelectedItem = Nothing
                cboPONo.Visible = True
                cboReturned.Visible = False
                cboPullout.Visible = False
                PopulatePRNO(cboPONo, "PO", Me)
            Else
                cboPONo.Visible = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub rdPulloutno_CheckedChanged(sender As Object, e As EventArgs) Handles rdPulloutno.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If rdPulloutno.Checked = True Then
                errProvider.Clear()
                cboPullout.Text = ""
                cboPullout.SelectedItem = Nothing
                cboPullout.Visible = True
                cboReturned.Visible = False
                cboPONo.Visible = False
                PopulatePRNO(cboPullout, "Pull-Out", Me)
            Else
                cboPullout.Visible = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub rdReturnNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdReturnNo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If rdReturnNo.Checked = True Then
                errProvider.Clear()
                cboReturned.Text = ""
                cboReturned.SelectedItem = Nothing
                cboReturned.Visible = True
                cboPONo.Visible = False
                cboPullout.Visible = False
                PopulatePRNO(cboReturned, "Return", Me)
            Else
                cboReturned.Visible = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub rdBlankRR_CheckedChanged(sender As Object, e As EventArgs) Handles rdBlankRR.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If rdBlankRR.Checked = True Then
                errProvider.Clear()
                cboPONo.Visible = False
                cboReturned.Visible = False
                cboPullout.Visible = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnOKRR_Click(sender As Object, e As EventArgs) Handles btnOKRR.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If rdBlankRR.Checked = False AndAlso rdPO.Checked = False AndAlso rdReturnNo.Checked = False AndAlso rdPulloutno.Checked = False Then
                If MessageBox.Show("No item selected. Do you want to close this page?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    Me.Close()
                End If
            ElseIf rdPO.Checked = True And cboPONo.Text = "" Then
                errProvider.SetError(cboPONo, "Please choose P.O. No.")
            ElseIf rdPulloutno.Checked = True And cboPullout.Text = "" Then
                errProvider.SetError(cboPullout, "Please choose Pull-Out No.")
            ElseIf rdReturnNo.Checked = True And cboReturned.Text = "" Then
                errProvider.SetError(cboReturned, "Please choose Return No.")
            Else
                If rdPO.Checked = True Then
                    getIDPRNOB(cboPONo.Text, "PO", Me.Name)
                    If gloPoNo = 0 Then
                        errProvider.SetError(cboPONo, "P.O. No. is not available any longer, please choose another P.O. No.")
                        Exit Try
                    End If
                    nrrnewrrtype = "PO"
                ElseIf rdPulloutno.Checked = True Then
                    getIDPRNOB(cboPullout.Text, "Pull-Out", Me.Name)
                    If gloPoNo = 0 Then
                        errProvider.SetError(cboPONo, "Pull-Out No. is not available any longer, please choose another Pull-Out No.")
                        Exit Try
                    End If
                    nrrnewrrtype = "Pull-Out"
                ElseIf rdReturnNo.Checked = True Then
                    getIDPRNOB(cboReturned.Text, "Return", Me.Name)
                    If gloPoNo = 0 Then
                        errProvider.SetError(cboPONo, "Return No. is not available any longer, please choose another Return No.")
                        Exit Try
                    End If
                    nrrnewrrtype = "Return"
                ElseIf rdBlankRR.Checked = True Then
                    nrrnewrrtype = "Blank"
                End If
                nrorderid = gloPoNo
                newrrcue = legit
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
End Class