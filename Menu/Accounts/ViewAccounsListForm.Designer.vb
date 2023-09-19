<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAccounsListForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewAccounsListForm))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnAddAgent = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsbtnAddHelper = New System.Windows.Forms.ToolStripButton()
        Me.rbHelper = New System.Windows.Forms.RadioButton()
        Me.rbAgent = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gridContacts = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.rbHelper)
        Me.Panel1.Controls.Add(Me.rbAgent)
        Me.Panel1.Controls.Add(Me.rbAll)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 119)
        Me.Panel1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnAddAgent, Me.ToolStripLabel1, Me.tsbtnAddHelper})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(800, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtnAddAgent
        '
        Me.tsbtnAddAgent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnAddAgent.Image = CType(resources.GetObject("tsbtnAddAgent.Image"), System.Drawing.Image)
        Me.tsbtnAddAgent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAddAgent.Name = "tsbtnAddAgent"
        Me.tsbtnAddAgent.Size = New System.Drawing.Size(68, 22)
        Me.tsbtnAddAgent.Text = "Add &Agent"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripLabel1.Text = "                                "
        '
        'tsbtnAddHelper
        '
        Me.tsbtnAddHelper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnAddHelper.Image = CType(resources.GetObject("tsbtnAddHelper.Image"), System.Drawing.Image)
        Me.tsbtnAddHelper.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAddHelper.Name = "tsbtnAddHelper"
        Me.tsbtnAddHelper.Size = New System.Drawing.Size(71, 22)
        Me.tsbtnAddHelper.Text = "Add H&elper"
        '
        'rbHelper
        '
        Me.rbHelper.AutoSize = True
        Me.rbHelper.Location = New System.Drawing.Point(165, 86)
        Me.rbHelper.Name = "rbHelper"
        Me.rbHelper.Size = New System.Drawing.Size(59, 17)
        Me.rbHelper.TabIndex = 1
        Me.rbHelper.Text = "Helper"
        Me.rbHelper.UseVisualStyleBackColor = True
        '
        'rbAgent
        '
        Me.rbAgent.AutoSize = True
        Me.rbAgent.Location = New System.Drawing.Point(103, 86)
        Me.rbAgent.Name = "rbAgent"
        Me.rbAgent.Size = New System.Drawing.Size(56, 17)
        Me.rbAgent.TabIndex = 1
        Me.rbAgent.Text = "Agent"
        Me.rbAgent.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(59, 86)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(38, 17)
        Me.rbAll.TabIndex = 1
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(59, 56)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(341, 22)
        Me.txtSearch.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search"
        '
        'gridContacts
        '
        Me.gridContacts.AllowUserToAddRows = False
        Me.gridContacts.AllowUserToDeleteRows = False
        Me.gridContacts.AllowUserToOrderColumns = True
        Me.gridContacts.BackgroundColor = System.Drawing.Color.White
        Me.gridContacts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridContacts.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridContacts.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridContacts.Location = New System.Drawing.Point(0, 0)
        Me.gridContacts.MultiSelect = False
        Me.gridContacts.Name = "gridContacts"
        Me.gridContacts.ReadOnly = True
        Me.gridContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridContacts.Size = New System.Drawing.Size(800, 331)
        Me.gridContacts.TabIndex = 21
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "LastName"
        Me.Column1.HeaderText = "Last Name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "FirstName"
        Me.Column2.HeaderText = "First Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "WorkPhone"
        Me.Column3.HeaderText = "Contact No."
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "EmailAddress"
        Me.Column4.HeaderText = "Email"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "Comments"
        Me.Column5.HeaderText = "Comments"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "Type"
        Me.Column6.HeaderText = "Type"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.gridContacts)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 119)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 331)
        Me.Panel2.TabIndex = 1
        '
        'ViewAccounsListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewAccounsListForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents gridContacts As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents rbHelper As RadioButton
    Friend WithEvents rbAgent As RadioButton
    Friend WithEvents rbAll As RadioButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbtnAddAgent As ToolStripButton
    Friend WithEvents tsbtnAddHelper As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
End Class
