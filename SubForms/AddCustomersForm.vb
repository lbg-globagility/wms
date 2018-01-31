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
Public Class AddCustomersForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim acfdeliveryaddressid, acfcontactpersonid, acfparentcustomerid, acfpicklistgroupid, acfbranchid As Integer
    Public addcustomerformcue As Boolean = False
    Private Sub AddCustomersForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            getAccountNo("Customer", Me)
            txtCustomerNo.Text = globalaccountno
            txtStatus.Text = "Active"
            acfdeliveryaddressid = 0 : acfcontactpersonid = 0
            txtCustomerName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub AddCustomersForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , pbAutoAddA, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoComplete()
        autocompleteParentCustomerA(cboParentCustomer)
        autocompletePickingGroup(cboPickingGroup)
        globalautocompleteBranchCodeName(cboBranchCodeNameInfo, Me)
    End Sub
    Sub callAutoPopulate()
        autopopulateParentCustomerA(cboParentCustomer)
        autopopulatePickingGroup(cboPickingGroup)
        globalautopopulateBranchCodeName(cboBranchCodeNameInfo, Me)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            clearCustomerInformation()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearCustomerInformation()
        Try
            txtCustomerNo.Text = ""
            txtCustomerName.Text = ""
            cboParentCustomer.Text = ""
            cboPickingGroup.Text = ""
            txtMainPhone.Text = ""
            txtContactPerson.Text = ""
            txtEmailAddress.Text = ""
            txtDeliveryAddress.Text = ""
            txtFaxNo.Text = ""
            txtAlternatePhone.Text = ""
            txtWebsite.Text = ""
            txtTIN.Text = ""
            txtComments.Text = ""
            txtStatus.Text = ""
            txtDeliveryHours.Text = ""
            cboPickingGroup.SelectedItem = Nothing
            cboParentCustomer.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "AutoComplete"
    Sub autocompleteParentCustomerA(ByVal icombobox As ComboBox)
        Try
            Dim parentcustomer As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.companyname,''),' - ',COALESCE(c.accountno,'')),'') AS 'parentcustomer' FROM accounts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' GROUP BY c.accountno ORDER BY c.accountno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                parentcustomer.Add(ds.Tables(0).Rows(i)("parentcustomer").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = parentcustomer
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autocompletePickingGroup(ByVal icombobox As ComboBox)
        Try
            Dim groupname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(pg.groupname,'') AS 'groupname' FROM accounts c LEFT JOIN picklistgroup pg ON c.picklistgroupid = pg.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' AND c.picklistgroupid IS NOT NULL GROUP BY pg.groupname ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                groupname.Add(ds.Tables(0).Rows(i)("groupname").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = groupname
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "AutoPopulate"
    Sub autopopulateParentCustomerA(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(c.companyname,''),' - ',COALESCE(c.accountno,'')),'') AS 'parentcustomer' FROM accounts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' GROUP BY c.accountno ORDER BY c.companyname "
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
    Sub autopopulatePickingGroup(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(pg.groupname,'') AS 'groupname' FROM accounts c LEFT JOIN picklistgroup pg ON c.picklistgroupid = pg.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' AND c.picklistgroupid IS NOT NULL GROUP BY pg.groupname ORDER BY pg.groupname "
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
#End Region
#End Region
    Private Sub pbEditDeliveryAddress_MouseEnter(sender As Object, e As EventArgs) Handles pbEditDeliveryAddress.MouseEnter
        Try
            pbEditDeliveryAddress.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbEditDeliveryAddress_MouseLeave(sender As Object, e As EventArgs) Handles pbEditDeliveryAddress.MouseLeave
        Try
            pbEditDeliveryAddress.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
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
    Private Sub pbEditDeliveryAddress_Click(sender As Object, e As EventArgs) Handles pbEditDeliveryAddress.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim addresslinkform As New AddressForm
            addresslinkform.afaddressid = acfdeliveryaddressid
            addresslinkform.ShowInTaskbar = False
            addresslinkform.ShowDialog()
            acfdeliveryaddressid = addresslinkform.afaddressid
            If acfdeliveryaddressid <> 0 Then
                getAddressName(acfdeliveryaddressid, Me)
                txtDeliveryAddress.Text = globaladdressname
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub pbAddBranchCodeName_MouseEnter(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.MouseEnter
        Try
            pbAddBranchCodeName.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddBranchCodeName_MouseLeave(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.MouseLeave
        Try
            pbAddBranchCodeName.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddBranchCodeName_Click(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim addbranchcodenamelinkform As New AddBranchCodeNameForm
            addbranchcodenamelinkform.ShowInTaskbar = False
            addbranchcodenamelinkform.ShowDialog()
            If addbranchcodenamelinkform.addbranchcodenamecue = legit Then
                globalautocompleteBranchCodeName(cboBranchCodeNameInfo, Me)
                globalautopopulateBranchCodeName(cboBranchCodeNameInfo, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
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
            myBalloon("Automatic adding of pick list group.", "Auto-Add", pbAutoAddA, -15, -65)
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
            myModule.systemerrorfound = False
            If LTrim(txtCustomerName.Text) = "" Then
                errProvider.SetError(txtCustomerName, "Please enter the customer name.")
                txtCustomerName.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getCustomerID(cboParentCustomer.Text, Me)
                    acfparentcustomerid = globalcustomerid
                    getBranchCodeIDB(cboBranchCodeNameInfo.Text, Me)
                    acfbranchid = globalbranchid
                    If LTrim(cboPickingGroup.Text) <> "" Then
                        getPickListGroupID(cboPickingGroup.Text, Me) : acfpicklistgroupid = globalpicklistgroupid
                        If acfpicklistgroupid = 0 Then
                            I_PickListGroup(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboPickingGroup.Text, "Active", Me)
                            getPickListGroupID(cboPickingGroup.Text, Me) : acfpicklistgroupid = globalpicklistgroupid
                        End If
                    Else
                        acfpicklistgroupid = 0
                    End If
                    getAccountNo("Customer", Me)
                    I_Accounts(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(acfcontactpersonid = 0, DBNull.Value, acfcontactpersonid), If(acfdeliveryaddressid = 0, DBNull.Value, acfdeliveryaddressid), If(acfparentcustomerid = 0, DBNull.Value, acfparentcustomerid), If(acfpicklistgroupid = 0, DBNull.Value, acfpicklistgroupid), _
                            If(acfbranchid = 0, DBNull.Value, acfbranchid), globalaccountno, "Customer", txtCustomerName.Text, txtCustomerName.Text, txtMainPhone.Text, txtAlternatePhone.Text, txtFaxNo.Text, txtEmailAddress.Text, txtTIN.Text, txtWebsite.Text, txtDeliveryHours.Text, txtComments.Text, txtStatus.Text, Me)
                    If CInt(txtCustomerNo.Text) <> globalaccountno Then
                        MessageBox.Show("Please take note that the Customer No. will change from " & CInt(txtCustomerNo.Text) & " to " & globalaccountno & "." & vbNewLine & "Another user used Customer No. " & CInt(txtCustomerNo.Text) & " for its new customer", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCustomerNo.Text = globalaccountno
                    End If
                    If myModule.systemerrorfound = False Then
                        MessageBox.Show("Successfully Save, Customer No. " & globalaccountno, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        addcustomerformcue = legit
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