Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class AddContactForm
    Private ReadOnly _contactType As ContactType
    Private ReadOnly _isFormDialog As Boolean

    Public Sub New(contactType As ContactType, Optional isFormDialog As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _contactType = contactType
        _isFormDialog = isFormDialog

        Text = $"Add {_contactType}"
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
                Dim contactDataService = MainServiceProvider.GetRequiredService(Of IContactDataService)

                Dim contact = Entities.Contact.NewContact(organizationId:=Z_OrganizationID,
                    lastName:=txtLastName.Text.Trim,
                    firstName:=txtFirstName.Text.Trim,
                    workPhone:=txtContactNo.Text.Trim,
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

End Class