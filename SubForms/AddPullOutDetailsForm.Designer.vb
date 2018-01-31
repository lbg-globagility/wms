<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPullOutDetailsForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddPullOutDetailsForm))
        Me.pbAddBranchCodeName = New System.Windows.Forms.PictureBox()
        Me.cboBranchCodeNameInfo = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.pbAddVendorCodeName = New System.Windows.Forms.PictureBox()
        Me.cboVendorCodeNameInfo = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msPrintSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbAddClassDescription = New System.Windows.Forms.PictureBox()
        Me.cboClassDescription = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtSCPOANo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.pbAddBranchCodeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddVendorCodeName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        CType(Me.pbAddClassDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbAddBranchCodeName
        '
        Me.pbAddBranchCodeName.BackColor = System.Drawing.Color.Transparent
        Me.pbAddBranchCodeName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddBranchCodeName.Image = CType(resources.GetObject("pbAddBranchCodeName.Image"), System.Drawing.Image)
        Me.pbAddBranchCodeName.Location = New System.Drawing.Point(395, 85)
        Me.pbAddBranchCodeName.Name = "pbAddBranchCodeName"
        Me.pbAddBranchCodeName.Size = New System.Drawing.Size(14, 18)
        Me.pbAddBranchCodeName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddBranchCodeName.TabIndex = 460
        Me.pbAddBranchCodeName.TabStop = False
        Me.pbAddBranchCodeName.Tag = ""
        '
        'cboBranchCodeNameInfo
        '
        Me.cboBranchCodeNameInfo.BackColor = System.Drawing.SystemColors.Window
        Me.cboBranchCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchCodeNameInfo.FormattingEnabled = True
        Me.cboBranchCodeNameInfo.Location = New System.Drawing.Point(170, 83)
        Me.cboBranchCodeNameInfo.Name = "cboBranchCodeNameInfo"
        Me.cboBranchCodeNameInfo.Size = New System.Drawing.Size(220, 23)
        Me.cboBranchCodeNameInfo.TabIndex = 3
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(15, 86)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(147, 15)
        Me.Label41.TabIndex = 8
        Me.Label41.Text = "Branch Code / Name Info:"
        '
        'pbAddVendorCodeName
        '
        Me.pbAddVendorCodeName.BackColor = System.Drawing.Color.Transparent
        Me.pbAddVendorCodeName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddVendorCodeName.Image = CType(resources.GetObject("pbAddVendorCodeName.Image"), System.Drawing.Image)
        Me.pbAddVendorCodeName.Location = New System.Drawing.Point(395, 114)
        Me.pbAddVendorCodeName.Name = "pbAddVendorCodeName"
        Me.pbAddVendorCodeName.Size = New System.Drawing.Size(14, 18)
        Me.pbAddVendorCodeName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddVendorCodeName.TabIndex = 458
        Me.pbAddVendorCodeName.TabStop = False
        Me.pbAddVendorCodeName.Tag = ""
        '
        'cboVendorCodeNameInfo
        '
        Me.cboVendorCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendorCodeNameInfo.FormattingEnabled = True
        Me.cboVendorCodeNameInfo.Location = New System.Drawing.Point(170, 112)
        Me.cboVendorCodeNameInfo.Name = "cboVendorCodeNameInfo"
        Me.cboVendorCodeNameInfo.Size = New System.Drawing.Size(220, 23)
        Me.cboVendorCodeNameInfo.TabIndex = 4
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(15, 115)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(147, 15)
        Me.Label29.TabIndex = 9
        Me.Label29.Text = "Vendor Code / Name Info:"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(434, 28)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "Add Pull-Out Details"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msPrintSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(434, 25)
        Me.msMenu.TabIndex = 1
        '
        'msPrintSave
        '
        Me.msPrintSave.Image = CType(resources.GetObject("msPrintSave.Image"), System.Drawing.Image)
        Me.msPrintSave.Name = "msPrintSave"
        Me.msPrintSave.Size = New System.Drawing.Size(127, 21)
        Me.msPrintSave.Text = "&Print And Save"
        '
        'pbAddClassDescription
        '
        Me.pbAddClassDescription.BackColor = System.Drawing.Color.Transparent
        Me.pbAddClassDescription.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddClassDescription.Image = CType(resources.GetObject("pbAddClassDescription.Image"), System.Drawing.Image)
        Me.pbAddClassDescription.Location = New System.Drawing.Point(395, 143)
        Me.pbAddClassDescription.Name = "pbAddClassDescription"
        Me.pbAddClassDescription.Size = New System.Drawing.Size(14, 18)
        Me.pbAddClassDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddClassDescription.TabIndex = 498
        Me.pbAddClassDescription.TabStop = False
        Me.pbAddClassDescription.Tag = ""
        '
        'cboClassDescription
        '
        Me.cboClassDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboClassDescription.FormattingEnabled = True
        Me.cboClassDescription.Location = New System.Drawing.Point(170, 141)
        Me.cboClassDescription.Name = "cboClassDescription"
        Me.cboClassDescription.Size = New System.Drawing.Size(220, 23)
        Me.cboClassDescription.TabIndex = 5
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(15, 144)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(105, 15)
        Me.Label31.TabIndex = 10
        Me.Label31.Text = "Class Description:"
        '
        'txtSCPOANo
        '
        Me.txtSCPOANo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSCPOANo.Location = New System.Drawing.Point(170, 55)
        Me.txtSCPOANo.Name = "txtSCPOANo"
        Me.txtSCPOANo.Size = New System.Drawing.Size(220, 21)
        Me.txtSCPOANo.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(15, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 15)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "SCPOA No.:"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'AddPullOutDetailsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(434, 177)
        Me.Controls.Add(Me.txtSCPOANo)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.pbAddClassDescription)
        Me.Controls.Add(Me.cboClassDescription)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pbAddBranchCodeName)
        Me.Controls.Add(Me.cboBranchCodeNameInfo)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.pbAddVendorCodeName)
        Me.Controls.Add(Me.cboVendorCodeNameInfo)
        Me.Controls.Add(Me.Label29)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddPullOutDetailsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbAddBranchCodeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddVendorCodeName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbAddClassDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbAddBranchCodeName As System.Windows.Forms.PictureBox
    Friend WithEvents cboBranchCodeNameInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents pbAddVendorCodeName As System.Windows.Forms.PictureBox
    Friend WithEvents cboVendorCodeNameInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msPrintSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbAddClassDescription As System.Windows.Forms.PictureBox
    Friend WithEvents cboClassDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtSCPOANo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
End Class
