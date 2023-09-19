Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices

Public Class ViewAccounsListForm
    Private _dataSource As New List(Of Contact)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ViewAccounsListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridContacts.AutoGenerateColumns = False

        CheckedChanged(rbAll, New EventArgs)
    End Sub

    Private Sub Click_Add(sender As Object, e As EventArgs) Handles tsbtnAddAgent.Click, tsbtnAddHelper.Click
        Dim contactType As ContactType
        If CType(sender, ToolStripButton).Name = tsbtnAddAgent.Name Then
            contactType = ContactType.Agent
        ElseIf CType(sender, ToolStripButton).Name = tsbtnAddHelper.Name Then
            contactType = ContactType.Helper
        End If

        Dim form = New AddContactForm(contactType:=contactType, True)
        If form.ShowDialog() = DialogResult.OK Then
            Dim checked = Panel1.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked)
            CheckedChanged(checked, New EventArgs)
        End If
    End Sub

    Private Async Sub CheckedChanged(sender As Object, e As EventArgs) Handles rbAll.CheckedChanged, rbAgent.CheckedChanged, rbHelper.CheckedChanged
        Dim contactDataService = MainServiceProvider.GetRequiredService(Of IContactDataService)
        Dim agents = Await contactDataService.GetAgentsAsync(organizationId:=Z_OrganizationID)
        Dim helpers = Await contactDataService.GetHelpersAsync(organizationId:=Z_OrganizationID)

        _dataSource = New List(Of Contact)

        Dim senderName = CType(sender, RadioButton).Name
        If senderName = rbAll.Name AndAlso rbAll.Checked Then
            _dataSource.AddRange(agents)
            _dataSource.AddRange(helpers)
        ElseIf senderName = rbAgent.Name AndAlso rbAgent.Checked Then
            _dataSource.AddRange(agents)
        ElseIf senderName = rbHelper.Name AndAlso rbHelper.Checked Then
            _dataSource.AddRange(helpers)
        End If

        gridContacts.DataSource = _dataSource.
            OrderBy(Function(t) t.LastName).
            ThenBy(Function(t) t.FirstName).
            ToList()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Trim = String.Empty Then
            gridContacts.DataSource = _dataSource.
                OrderBy(Function(t) t.LastName).
                ThenBy(Function(t) t.FirstName).
                ToList()
            Return
        End If

        gridContacts.DataSource = _dataSource.
            Where(Function(t) t.FullNameLastNameFirst.ToLower().Contains(txtSearch.Text.ToLower().Trim())).
            OrderBy(Function(t) t.LastName).
            ThenBy(Function(t) t.FirstName).
            ToList()
    End Sub

End Class