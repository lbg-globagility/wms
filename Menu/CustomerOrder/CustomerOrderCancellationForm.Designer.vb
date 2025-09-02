<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomerOrderCancellationForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tgvLineup = New TreeGridView.TreeGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tgvPackingList = New TreeGridView.TreeGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.tgvPickList = New TreeGridView.TreeGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tgvLineup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.tgvPackingList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.tgvPickList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 386)
        Me.Panel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 64)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(800, 322)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tgvLineup)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(792, 296)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lineup/Delivery"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tgvLineup
        '
        Me.tgvLineup.AllowUserToAddRows = False
        Me.tgvLineup.AllowUserToDeleteRows = False
        Me.tgvLineup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tgvLineup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.tgvLineup.ImageList = Nothing
        Me.tgvLineup.Location = New System.Drawing.Point(3, 3)
        Me.tgvLineup.MultiSelect = False
        Me.tgvLineup.Name = "tgvLineup"
        Me.tgvLineup.RowHeadersVisible = False
        Me.tgvLineup.RowTemplate.Height = 23
        Me.tgvLineup.Size = New System.Drawing.Size(786, 290)
        Me.tgvLineup.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tgvPackingList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(792, 296)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Packing List"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tgvPackingList
        '
        Me.tgvPackingList.AllowUserToAddRows = False
        Me.tgvPackingList.AllowUserToDeleteRows = False
        Me.tgvPackingList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tgvPackingList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.tgvPackingList.ImageList = Nothing
        Me.tgvPackingList.Location = New System.Drawing.Point(3, 3)
        Me.tgvPackingList.MultiSelect = False
        Me.tgvPackingList.Name = "tgvPackingList"
        Me.tgvPackingList.RowHeadersVisible = False
        Me.tgvPackingList.RowTemplate.Height = 23
        Me.tgvPackingList.Size = New System.Drawing.Size(786, 290)
        Me.tgvPackingList.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.tgvPickList)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(792, 296)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Pick List"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'tgvPickList
        '
        Me.tgvPickList.AllowUserToAddRows = False
        Me.tgvPickList.AllowUserToDeleteRows = False
        Me.tgvPickList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tgvPickList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.tgvPickList.ImageList = Nothing
        Me.tgvPickList.Location = New System.Drawing.Point(3, 3)
        Me.tgvPickList.MultiSelect = False
        Me.tgvPickList.Name = "tgvPickList"
        Me.tgvPickList.RowHeadersVisible = False
        Me.tgvPickList.RowTemplate.Height = 23
        Me.tgvPickList.Size = New System.Drawing.Size(786, 290)
        Me.tgvPickList.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(800, 64)
        Me.Panel3.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 386)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 64)
        Me.Panel2.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(548, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Revoke Order"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(713, 29)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CustomerOrderCancellationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "CustomerOrderCancellationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tgvLineup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.tgvPackingList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.tgvPickList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Private WithEvents tgvLineup As TreeGridView.TreeGridView
    Private WithEvents tgvPackingList As TreeGridView.TreeGridView
    Private WithEvents tgvPickList As TreeGridView.TreeGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
