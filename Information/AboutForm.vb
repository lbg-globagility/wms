Imports System.Configuration
Imports System.Runtime
Imports MySql.Data.MySqlClient

Public Class AboutForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Public ReadOnly Property VersionNo As String

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            PrimaryForm.AbtForm = False
            Me.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadVersionNo()
        Dim appSettings = ConfigurationManager.AppSettings
        _VersionNo = appSettings.Get("system.version")

        If VersionNo IsNot Nothing Then
            SystemVerNo.Text = Me._VersionNo
        Else
            SystemVerNo.Text = "Version no is missing."
        End If
    End Sub

    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadVersionNo()
    End Sub
End Class