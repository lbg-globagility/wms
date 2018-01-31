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
Public Class ContactPersonForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Public cfcontactid As Integer
    Private Sub ContactsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            If cfcontactid <> 0 Then
                displayContactInformation(cfcontactid)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ContactPersonForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , pbAutoAddA, , , 1)
            myBalloon(, , pbAutoAddB, , , 1)
            myBalloon(, , pbAutoAddC, , , 1)
            myBalloon(, , pbAutoAddD, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoComplete()
        autocompleteSuffix(cboSuffix)
        autocompleteSalutation(cboSalutation)
        autocompleteGender(cboGender)
        autocompleteCivilStatus(cboCivilStatus)
        autocompleteJobTitle(cboJobTitle)
    End Sub
    Sub callAutoPopulate()
        autopopulateSuffix(cboSuffix)
        autopopulateSalutation(cboSalutation)
        autopopulateGender(cboGender)
        autopopulateCivilStatus(cboCivilStatus)
        autopopulateJobTitle(cboJobTitle)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            txtFName.Text = ""
            txtMName.Text = ""
            txtLName.Text = ""
            cboSuffix.Text = ""
            txtNickName.Text = ""
            cboSalutation.Text = ""
            cboGender.Text = ""
            cboCivilStatus.Text = ""
            cboJobTitle.Text = ""
            txtMainPhone.Text = ""
            txtFaxNo.Text = ""
            txtAlternatePhone.Text = ""
            txtTIN.Text = ""
            dtpBirthday.Value = Now.Date
            txtEmailAddress.Text = ""
            txtComments.Text = ""
            cboSuffix.SelectedItem = Nothing
            cboSalutation.SelectedItem = Nothing
            cboGender.SelectedItem = Nothing
            cboCivilStatus.SelectedItem = Nothing
            cboJobTitle.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "AutoComplete"
    Sub autocompleteSuffix(ByVal icombobox As ComboBox)
        Try
            Dim suffix As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.suffix,'') AS 'suffix' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.suffix != '' GROUP BY c.suffix ORDER BY c.suffix ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                suffix.Add(ds.Tables(0).Rows(i)("suffix").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = suffix
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
    Sub autocompleteSalutation(ByVal icombobox As ComboBox)
        Try
            Dim salutation As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.salutation,'') AS 'salutation' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.salutation != '' GROUP BY c.salutation ORDER BY c.salutation ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                salutation.Add(ds.Tables(0).Rows(i)("salutation").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = salutation
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
    Sub autocompleteGender(ByVal icombobox As ComboBox)
        Try
            Dim gender As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.gender,'') AS 'gender' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.gender != '' GROUP BY c.gender ORDER BY c.gender ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                gender.Add(ds.Tables(0).Rows(i)("gender").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = gender
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
    Sub autocompleteCivilStatus(ByVal icombobox As ComboBox)
        Try
            Dim civilstatus As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.civilstatus,'') AS 'civilstatus' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.civilstatus != '' GROUP BY c.civilstatus ORDER BY c.civilstatus ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                civilstatus.Add(ds.Tables(0).Rows(i)("civilstatus").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = civilstatus
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
    Sub autocompleteJobTitle(ByVal icombobox As ComboBox)
        Try
            Dim jobtitle As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.jobtitle,'') AS 'jobtitle' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.jobtitle != '' GROUP BY c.jobtitle ORDER BY c.jobtitle ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                jobtitle.Add(ds.Tables(0).Rows(i)("jobtitle").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = jobtitle
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
#End Region
#Region "AutoPopulate"
    Sub autopopulateSuffix(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.suffix,'') AS 'suffix' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.suffix != '' GROUP BY c.suffix ORDER BY c.suffix "
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
    Sub autopopulateSalutation(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.salutation,'') AS 'salutation' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.salutation != '' GROUP BY c.salutation ORDER BY c.salutation "
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
    Sub autopopulateGender(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.gender,'') AS 'gender' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.gender != '' GROUP BY c.gender ORDER BY c.gender "
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
    Sub autopopulateCivilStatus(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.civilstatus,'') AS 'civilstatus' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.civilstatus != '' GROUP BY c.civilstatus ORDER BY c.civilstatus "
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
    Sub autopopulateJobTitle(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.jobtitle,'') AS 'jobtitle' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.jobtitle != '' GROUP BY c.jobtitle ORDER BY c.jobtitle "
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
#Region "Display"
    Sub displayContactInformation(ByVal icontactid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(c.firstname,''),COALESCE(c.middlename,''),COALESCE(c.lastname,''),COALESCE(c.suffix,'')," & _
                        "COALESCE(c.nickname,''),COALESCE(c.salutation,''),COALESCE(c.gender,''),COALESCE(c.civilstatus,''),COALESCE(c.jobtitle,'')," & _
                        "COALESCE(c.mainphone,''),COALESCE(c.faxnumber,''),COALESCE(c.alternatephone,''),COALESCE(c.tinnumber,''),COALESCE(c.birthday,'')," & _
                        "COALESCE(c.emailaddress,''),COALESCE(c.comments,'') FROM contacts c WHERE c.rowid = " & icontactid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtFName.Text = reader1(0)
                    txtMName.Text = reader1(1)
                    txtLName.Text = reader1(2)
                    cboSuffix.Text = reader1(3)
                    txtNickName.Text = reader1(4)
                    cboSalutation.Text = reader1(5)
                    cboGender.Text = reader1(6)
                    cboCivilStatus.Text = reader1(7)
                    cboJobTitle.Text = reader1(8)
                    txtMainPhone.Text = reader1(9)
                    txtFaxNo.Text = reader1(10)
                    txtAlternatePhone.Text = reader1(11)
                    txtTIN.Text = reader1(12)
                    dtpBirthday.Text = reader1(13)
                    txtEmailAddress.Text = reader1(14)
                    txtComments.Text = reader1(15)
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
#End Region
    Private Sub pbAutoAddA_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddA.MouseEnter
        Try
            pbAutoAddA.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddA_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddA.MouseLeave
        Try
            pbAutoAddA.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddA_Click(sender As Object, e As EventArgs) Handles pbAutoAddA.Click
        Try
            myBalloon("Automatic adding of suffix.", "Auto-Add", pbAutoAddA, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddB_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddB.MouseEnter
        Try
            pbAutoAddB.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddB_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddB.MouseLeave
        Try
            pbAutoAddB.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddB_Click(sender As Object, e As EventArgs) Handles pbAutoAddB.Click
        Try
            myBalloon("Automatic adding of gender.", "Auto-Add", pbAutoAddB, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddC_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddC.MouseEnter
        Try
            pbAutoAddC.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddC_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddC.MouseLeave
        Try
            pbAutoAddC.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddC_Click(sender As Object, e As EventArgs) Handles pbAutoAddC.Click
        Try
            myBalloon("Automatic adding of civil status.", "Auto-Add", pbAutoAddC, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddD_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddD.MouseEnter
        Try
            pbAutoAddD.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddD_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddD.MouseLeave
        Try
            pbAutoAddD.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddD_Click(sender As Object, e As EventArgs) Handles pbAutoAddD.Click
        Try
            myBalloon("Automatic adding of salutation.", "Auto-Add", pbAutoAddD, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddE_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddE.MouseEnter
        Try
            pbAutoAddE.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddE_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddE.MouseLeave
        Try
            pbAutoAddE.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddE_Click(sender As Object, e As EventArgs) Handles pbAutoAddE.Click
        Try
            myBalloon("Automatic adding of job title.", "Auto-Add", pbAutoAddE, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            myModule.systemerrorfound = False
            If LTrim(txtFName.Text) = "" And LTrim(txtLName.Text) = "" Then
                MessageBox.Show("Please fill-up either the first name or the last name.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFName.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    If cfcontactid <> 0 Then
                        U_Contacts(cfcontactid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cboSalutation.Text, txtFName.Text, txtMName.Text, txtLName.Text, cboSuffix.Text, txtMainPhone.Text, txtAlternatePhone.Text, dtpBirthday.Value, _
                                cboGender.Text, cboCivilStatus.Text, txtEmailAddress.Text, txtTIN.Text, txtComments.Text, "", "", txtFaxNo.Text, cboJobTitle.Text, txtNickName.Text, "Active", Me)
                    Else
                        getContactNo("Contact", Me)
                        I_Contact(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, globalcontactno, "Contact", cboSalutation.Text, txtFName.Text, txtMName.Text, txtLName.Text, cboSuffix.Text, txtMainPhone.Text, txtAlternatePhone.Text, dtpBirthday.Value, _
                                cboGender.Text, cboCivilStatus.Text, txtEmailAddress.Text, txtTIN.Text, txtComments.Text, "Active", "", "", txtFaxNo.Text, cboJobTitle.Text, txtNickName.Text, Me)
                        cfcontactid = globalcontactidsp
                    End If
                    If myModule.systemerrorfound = False Then
                        MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
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