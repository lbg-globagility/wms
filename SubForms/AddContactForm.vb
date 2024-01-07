Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class AddContactForm
    Private ReadOnly _contactType As ContactType
    Private ReadOnly _isFormDialog As Boolean

    Public Sub New(contactType As ContactType, Optional isFormDialog As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()
        autoPopulateRegion()


        ' Add any initialization after the InitializeComponent() call.

        _contactType = contactType
        _isFormDialog = isFormDialog

        Text = $"Add {_contactType}"

        If _contactType <> 1 Then
            cboRegion.Visible = False
            cboProvince.Visible = False
            citiesListBox.Visible = False
            Size = New Size(350, 304)
        ElseIf _contactType <> 3 Then
            autoPopulateRegion()
        End If
    End Sub

    Private Sub AddContactForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Visible = Not _isFormDialog
        Panel3.Visible = _isFormDialog

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        btnSave.Enabled = False
        tsbtnSave_Click(tsbtnSave, New EventArgs)

        btnSave.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        tsbtnCancel_Click(tsbtnCancel, New EventArgs)

        DialogResult = DialogResult.Cancel
    End Sub

    Private Async Sub tsbtnSave_Click(sender As Object, e As EventArgs) Handles tsbtnSave.Click
        tsbtnSave.Enabled = False
        Await FunctionUtils.TryCatchFunctionAsync(messageTitle:=String.Empty,
            Async Function()
                Dim contactDataService = GetRequiredService(Of IContactDataService)()

                Dim cities = New List(Of ContactCity)
                For Each itemChecked In citiesListBox.CheckedItems
                    Dim city = New ContactCity()
                    city.CityID = itemChecked.RowId
                    cities.Add(city)
                Next

                Dim contact = Entities.Contact.NewContact(organizationId:=Z_OrganizationID,
                    lastName:=txtLastName.Text.Trim,
                    firstName:=txtFirstName.Text.Trim,
                    workPhone:=txtContactNo.Text.Trim,
                    email:=txtEmail.Text.Trim,
                    comments:=txtComments.Text.Trim,
                    regionId:=cboRegion.SelectedValue,
                    provinceId:=cboProvince.SelectedValue,
                    cities:=cities,
                    type:=_contactType)

                Await contactDataService.SaveManyAsync(entities:=New List(Of Entities.Contact) From {contact},
                    userId:=Z_UserID)

                tsbtnSave.Enabled = True

                If _isFormDialog Then DialogResult = DialogResult.OK
            End Function)
    End Sub

    Private Sub tsbtnCancel_Click(sender As Object, e As EventArgs) Handles tsbtnCancel.Click
        Close()
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        Dim bool = Not String.IsNullOrEmpty(txtLastName.Text.Trim()) AndAlso Not String.IsNullOrEmpty(txtFirstName.Text.Trim())
        tsbtnSave.Enabled = bool
        btnSave.Enabled = bool
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        Dim bool = Not String.IsNullOrEmpty(txtFirstName.Text.Trim()) AndAlso Not String.IsNullOrEmpty(txtLastName.Text.Trim())
        tsbtnSave.Enabled = bool
        btnSave.Enabled = bool
    End Sub


    Private Sub cboRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRegion.SelectedIndexChanged
        autoPopulateChild(cboProvince, cboRegion.SelectedValue)
    End Sub

    Private Sub cboProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProvince.SelectedIndexChanged
        autoPopulateCities(citiesListBox, cboProvince.SelectedValue)
    End Sub

    Async Sub autoPopulateRegion()
        cboRegion.Items.Clear()
        Dim listOfValue = MainServiceProvider.GetRequiredService(Of IListOfValueRepository)
        Dim listOfValues = Await listOfValue.GetManyByTypeAsync(Z_OrganizationID, "Region")
        For Each type In listOfValues
            cboRegion.ValueMember = "RowId"
            cboRegion.DisplayMember = "DisplayValue"
            cboRegion.DataSource = listOfValues
        Next
    End Sub

    Async Sub autoPopulateChild(ByVal cbo As ComboBox, parentid As Integer)
        Dim listOfValue = MainServiceProvider.GetRequiredService(Of IListOfValueRepository)
        Dim listOfValues = Await listOfValue.GetManyByParentIdAsync(Z_OrganizationID, parentid)
        For Each type In listOfValues
            cbo.ValueMember = "RowId"
            cbo.DisplayMember = "DisplayValue"
            cbo.DataSource = listOfValues
        Next
    End Sub
    Async Sub autoPopulateCities(ByVal clb As CheckedListBox, parentid As Integer)
        Dim listOfValue = MainServiceProvider.GetRequiredService(Of IListOfValueRepository)
        Dim listOfValues = Await listOfValue.GetManyByParentIdAsync(Z_OrganizationID, parentid)
        For Each type In listOfValues
            clb.ValueMember = "RowId"
            clb.DisplayMember = "DisplayValue"
            clb.DataSource = listOfValues
        Next
    End Sub
End Class