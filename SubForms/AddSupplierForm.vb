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
Public Class AddSupplierForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim acfdeliveryaddressid, acfcontactpersonid, acfparentsupplierid, acfpicklistgroupid As Integer
    Public addsupplierformcue As Boolean = False
    Private Sub AddSupplierForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoPopulate()
            getAccountNo("Supplier", Me)
            txtSupplierNo.Text = globalaccountno
            acfdeliveryaddressid = 0 : acfcontactpersonid = 0
            txtSupplierName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoPopulate()
        autopopulateStatus(cboStatus)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            clearSupplierInformation()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearSupplierInformation()
        Try
            txtSupplierNo.Text = ""
            txtSupplierName.Text = ""
            txtMainPhone.Text = ""
            txtContactPerson.Text = ""
            txtEmailAddress.Text = ""
            txtFaxNo.Text = ""
            txtAlternatePhone.Text = ""
            txtWebsite.Text = ""
            txtTIN.Text = ""
            txtComments.Text = ""
            cboStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "AutoPopulate"
    Sub autopopulateStatus(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT lic FROM listofvalues WHERE type = 'Status' AND status = 'Active' ORDER BY lic "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                icombobox.Items.Add(reader1(0).ToString())
            End While
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region
#End Region
    Private Sub pbEditContactPerson_MouseEnter(sender As Object, e As EventArgs) Handles pbEditContactPerson.MouseEnter
        Try
            pbEditContactPerson.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbEditContactPerson_MouseLeave(sender As Object, e As EventArgs) Handles pbEditContactPerson.MouseLeave
        Try
            pbEditContactPerson.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbEditContactPerson_Click(sender As Object, e As EventArgs) Handles pbEditContactPerson.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim contactslinkform As New ContactPersonForm
            contactslinkform.cfcontactid = acfcontactpersonid
            contactslinkform.ShowInTaskbar = False
            contactslinkform.ShowDialog()
            acfcontactpersonid = contactslinkform.cfcontactid
            If acfcontactpersonid <> 0 Then
                getContactNameA(acfcontactpersonid, Me)
                txtContactPerson.Text = globalcontactname
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
            myModule.systemerrorfound = False
            If LTrim(txtSupplierName.Text) = "" Then
                errProvider.SetError(txtSupplierName, "Please enter the supplier name.")
                txtSupplierName.Focus()
            ElseIf LTrim(cboStatus.Text) = "" Then
                errProvider.SetError(cboStatus, "Please choose the status of the supplier.")
                cboStatus.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes on this page? ", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getAccountNo("Supplier", Me)
                    M_I_Accounts(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(acfcontactpersonid = 0, DBNull.Value, acfcontactpersonid), If(acfdeliveryaddressid = 0, DBNull.Value, acfdeliveryaddressid), DBNull.Value, _
                            If(acfpicklistgroupid = 0, DBNull.Value, acfpicklistgroupid), globalaccountno, "Supplier", txtSupplierName.Text, txtSupplierName.Text, txtMainPhone.Text, txtAlternatePhone.Text, txtFaxNo.Text, txtEmailAddress.Text, txtTIN.Text, txtWebsite.Text, txtComments.Text, cboStatus.Text, Me)
                    If CInt(txtSupplierNo.Text) <> globalaccountno Then
                        MessageBox.Show("Please take note that the Supplier No. will change from " & CInt(txtSupplierNo.Text) & " to " & globalaccountno & "." & vbNewLine & "Another user used the Supplier No. " & CInt(txtSupplierNo.Text) & " for its new supplier", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtSupplierNo.Text = globalaccountno
                    End If
                    If myModule.systemerrorfound = False Then
                        MessageBox.Show("Successfully Save, Supplier No. " & globalaccountno, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        addsupplierformcue = legit
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
End Class