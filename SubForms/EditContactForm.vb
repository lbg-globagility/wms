Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class EditContactForm
    Private ReadOnly _contact As Contact

    Public Sub New(contact As Contact)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _contact = contact
    End Sub

    Private Sub EditContactForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each txtBox In Panel2.Controls.OfType(Of TextBox)
            txtBox.DataBindings.Clear()
        Next

        txtLastName.Text = _contact.LastName
        'txtLastName.DataBindings.Add("Text", _contact, "LastName", True, DataSourceUpdateMode.OnPropertyChanged)

        txtFirstName.Text = _contact.FirstName
        'txtFirstName.DataBindings.Add("Text", _contact, "FirstName", True, DataSourceUpdateMode.OnPropertyChanged)

        txtContactNo.Text = _contact.WorkPhone
        'txtContactNo.DataBindings.Add("Text", _contact, "WorkPhone", True, DataSourceUpdateMode.OnPropertyChanged)

        txtEmail.Text = _contact.EmailAddress
        'txtEmail.DataBindings.Add("Text", _contact, "EmailAddress", True, DataSourceUpdateMode.OnPropertyChanged)

        txtComments.Text = _contact.Comments
        'txtComments.DataBindings.Add("Text", _contact, "Comments", True, DataSourceUpdateMode.OnPropertyChanged)
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        Dim bool = Not String.IsNullOrEmpty(txtLastName.Text.Trim()) AndAlso Not String.IsNullOrEmpty(txtFirstName.Text.Trim())
        btnSave.Enabled = bool
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        Dim bool = Not String.IsNullOrEmpty(txtFirstName.Text.Trim()) AndAlso Not String.IsNullOrEmpty(txtLastName.Text.Trim())
        btnSave.Enabled = bool
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        btnSave.Enabled = False

        Await FunctionUtils.TryCatchFunctionAsync(messageTitle:=String.Empty,
            Async Function()
                Dim contactDataService = MainServiceProvider.GetRequiredService(Of IContactDataService)

                _contact.LastName = txtLastName.Text

                _contact.FirstName = txtFirstName.Text

                _contact.WorkPhone = txtContactNo.Text

                _contact.EmailAddress = txtEmail.Text

                _contact.Comments = txtComments.Text

                Await contactDataService.SaveManyAsync(entities:=New List(Of Contact) From {_contact},
                    userId:=Z_UserID)

                btnSave.Enabled = True

                DialogResult = DialogResult.OK
            End Function)
    End Sub

End Class