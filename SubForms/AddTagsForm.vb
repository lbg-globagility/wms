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
Public Class AddTagsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim atlistofvalueid As Integer
    Public addtagscue As Boolean = False
    Private Sub AddTagsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            txtTagName.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            If LTrim(txtTagName.Text) = "" Then
                errProvider.SetError(txtTagName, "Please enter the tag name.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getListOfValuesID(txtTagName.Text, "Tags", Me)
                If globallistofvaluesid = 0 Then
                    I_ListOfValues(Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, txtTagName.Text, txtTagName.Text, "Tags", "", "", "Active", "N", "Y", DBNull.Value, Me)
                Else
                    U_ListOfValueStatus(globallistofvaluesid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Active", Me)
                End If
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addtagscue = legit
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