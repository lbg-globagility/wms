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
Imports System.Data.OleDb
Public Class AddressForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Public afaddressid As Integer
    Private Sub AddressForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            If afaddressid <> 0 Then
                displayAddressInformation(afaddressid)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub AddressForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , pbAutoAddA, , , 1)
            myBalloon(, , pbAutoAddB, , , 1)
            myBalloon(, , pbAutoAddC, , , 1)
            myBalloon(, , pbAutoAddD, , , 1)
            myBalloon(, , pbAutoAddE, , , 1)
            myBalloon(, , pbAutoAddF, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoCompleteFunctions()
        autocompleteBarangay(cboBarangay)
        autocompleteCityTown(cboCityTown)
        autocompleteProvince(cboProvince)
        autocompleteState(cboState)
        autocompleteZIPCode(cboZIPCode)
        autocompleteCountry(cboCountry)
    End Sub
    Sub callAutoPopulateFunctions()
        autopopulateBarangay(cboBarangay)
        autopopulateCityTown(cboCityTown)
        autopopulateProvince(cboProvince)
        autopopulateState(cboState)
        autopopulateZIPCode(cboZIPCode)
        autopopulateCountry(cboCountry)
    End Sub
#Region "Clear/Enable/Visible Functions"
    Sub clearfields()
        Try
            txtStreetAddress1.Text = ""
            txtStreetAddress2.Text = ""
            cboBarangay.Text = ""
            cboCityTown.Text = ""
            cboProvince.Text = ""
            cboState.Text = ""
            cboZIPCode.Text = ""
            cboCountry.Text = ""
            cboBarangay.SelectedItem = Nothing
            cboCityTown.SelectedItem = Nothing
            cboProvince.SelectedItem = Nothing
            cboState.SelectedItem = Nothing
            cboZIPCode.SelectedItem = Nothing
            cboCountry.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display Functions"
#Region "AutoComplete"
    Sub autocompleteBarangay(ByVal icombobox As ComboBox)
        Try
            Dim barangay As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(ad.barangay,'') AS 'barangay' FROM address ad GROUP BY ad.barangay ORDER BY ad.barangay ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                barangay.Add(ds.Tables(0).Rows(i)("barangay").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = barangay
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
    Sub autocompleteCityTown(ByVal icombobox As ComboBox)
        Try
            Dim citytown As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(ad.citytown,'') AS 'citytown' FROM address ad GROUP BY ad.citytown ORDER BY ad.citytown ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                citytown.Add(ds.Tables(0).Rows(i)("citytown").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = citytown
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
    Sub autocompleteProvince(ByVal icombobox As ComboBox)
        Try
            Dim province As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(ad.province,'') AS 'province' FROM address ad GROUP BY ad.province ORDER BY ad.province ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                province.Add(ds.Tables(0).Rows(i)("province").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = province
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
    Sub autocompleteState(ByVal icombobox As ComboBox)
        Try
            Dim state As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(ad.state,'') AS 'state' FROM address ad GROUP BY ad.state ORDER BY ad.state ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                state.Add(ds.Tables(0).Rows(i)("state").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = state
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
    Sub autocompleteZIPCode(ByVal icombobox As ComboBox)
        Try
            Dim zipcode As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(ad.zipcode,'') AS 'zipcode' FROM address ad GROUP BY ad.zipcode ORDER BY ad.zipcode ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                zipcode.Add(ds.Tables(0).Rows(i)("zipcode").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = zipcode
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
    Sub autocompleteCountry(ByVal icombobox As ComboBox)
        Try
            Dim country As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(ad.country,'') AS 'country' FROM address ad GROUP BY ad.country ORDER BY ad.country ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                country.Add(ds.Tables(0).Rows(i)("country").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = country
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
#End Region
#Region "AutoPopulate"
    Sub autopopulateBarangay(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(ad.barangay,'') AS 'barangay' FROM address ad GROUP BY ad.barangay ORDER BY ad.barangay "
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
    Sub autopopulateCityTown(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(ad.citytown,'') AS 'citytown' FROM address ad GROUP BY ad.citytown ORDER BY ad.citytown "
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
    Sub autopopulateProvince(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(ad.province,'') AS 'province' FROM address ad GROUP BY ad.province ORDER BY ad.province "
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
    Sub autopopulateState(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(ad.state,'') AS 'state' FROM address ad GROUP BY ad.state ORDER BY ad.state "
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
    Sub autopopulateZIPCode(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(ad.zipcode,'') AS 'zipcode' FROM address ad GROUP BY ad.zipcode ORDER BY ad.zipcode "
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
    Sub autopopulateCountry(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(ad.country,'') AS 'country' FROM address ad GROUP BY ad.country ORDER BY ad.country "
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
    Sub displayAddressInformation(ByVal iaddressid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(ad.streetaddress1,''),COALESCE(ad.streetaddress2,''),COALESCE(ad.barangay,''),COALESCE(ad.citytown,'')," & _
                        "COALESCE(ad.province,''),COALESCE(ad.state,''),COALESCE(ad.zipcode,''),COALESCE(ad.country,'') FROM address ad WHERE ad.rowid = " & iaddressid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtStreetAddress1.Text = reader1(0)
                    txtStreetAddress2.Text = reader1(1)
                    cboBarangay.Text = reader1(2)
                    cboCityTown.Text = reader1(3)
                    cboProvince.Text = reader1(4)
                    cboState.Text = reader1(5)
                    cboZIPCode.Text = reader1(6)
                    cboCountry.Text = reader1(7)
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
            myBalloon("Automatic adding of barangay.", "Auto-Add", pbAutoAddA, -15, -65)
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
            myBalloon("Automatic adding of city/town.", "Auto-Add", pbAutoAddB, -15, -65)
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
            myBalloon("Automatic adding of province.", "Auto-Add", pbAutoAddC, -15, -65)
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
            myBalloon("Automatic adding of state.", "Auto-Add", pbAutoAddD, -15, -65)
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
            myBalloon("Automatic adding of zip code.", "Auto-Add", pbAutoAddE, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddF_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddF.MouseEnter
        Try
            pbAutoAddF.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddF_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddF.MouseLeave
        Try
            pbAutoAddF.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddF_Click(sender As Object, e As EventArgs) Handles pbAutoAddF.Click
        Try
            myBalloon("Automatic adding of country.", "Auto-Add", pbAutoAddF, -15, -65)
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
            If LTrim(txtStreetAddress1.Text) = "" And LTrim(txtStreetAddress2.Text) = "" And LTrim(cboBarangay.Text) = "" And LTrim(cboCityTown.Text) = "" And LTrim(cboProvince.Text) = "" And LTrim(cboState.Text) = "" And LTrim(cboZIPCode.Text) = "" And LTrim(cboCountry.Text) = "" Then
                MessageBox.Show("Please fill-up at least one field.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtStreetAddress1.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    If afaddressid <> 0 Then
                        U_Address(afaddressid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtStreetAddress1.Text, txtStreetAddress2.Text, cboBarangay.Text, cboCityTown.Text, cboProvince.Text, cboState.Text, cboZIPCode.Text, cboCountry.Text, Me)
                    Else
                        I_Address(Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, txtStreetAddress1.Text, txtStreetAddress2.Text, cboBarangay.Text, cboCityTown.Text, cboProvince.Text, cboState.Text, cboZIPCode.Text, cboCountry.Text, Me)
                        afaddressid = globaladdressidsp
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