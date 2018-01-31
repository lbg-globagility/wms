<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditCartonForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditCartonForm))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtpPackedDate = New System.Windows.Forms.DateTimePicker()
        Me.lblPackedDate = New System.Windows.Forms.Label()
        Me.pbAddPacker = New System.Windows.Forms.PictureBox()
        Me.lblPackerName = New System.Windows.Forms.Label()
        Me.txtCartonNo = New System.Windows.Forms.TextBox()
        Me.lblCartonNoA = New System.Windows.Forms.Label()
        Me.lblCartonNoAsteriskA = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPackerName = New System.Windows.Forms.ComboBox()
        Me.cboWeightUOM = New System.Windows.Forms.ComboBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSizeInfo = New System.Windows.Forms.ComboBox()
        Me.pbAddSize = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pbAutoAddA = New System.Windows.Forms.PictureBox()
        Me.msMenu.SuspendLayout()
        CType(Me.pbAddPacker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(404, 28)
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "Edit Box"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(404, 25)
        Me.msMenu.TabIndex = 1
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'dtpPackedDate
        '
        Me.dtpPackedDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpPackedDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPackedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPackedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPackedDate.Location = New System.Drawing.Point(276, 55)
        Me.dtpPackedDate.Name = "dtpPackedDate"
        Me.dtpPackedDate.Size = New System.Drawing.Size(110, 21)
        Me.dtpPackedDate.TabIndex = 3
        '
        'lblPackedDate
        '
        Me.lblPackedDate.AutoSize = True
        Me.lblPackedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackedDate.Location = New System.Drawing.Point(192, 58)
        Me.lblPackedDate.Name = "lblPackedDate"
        Me.lblPackedDate.Size = New System.Drawing.Size(80, 15)
        Me.lblPackedDate.TabIndex = 12
        Me.lblPackedDate.Text = "Packed Date:"
        '
        'pbAddPacker
        '
        Me.pbAddPacker.BackColor = System.Drawing.Color.Transparent
        Me.pbAddPacker.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddPacker.Image = CType(resources.GetObject("pbAddPacker.Image"), System.Drawing.Image)
        Me.pbAddPacker.Location = New System.Drawing.Point(375, 84)
        Me.pbAddPacker.Name = "pbAddPacker"
        Me.pbAddPacker.Size = New System.Drawing.Size(14, 18)
        Me.pbAddPacker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddPacker.TabIndex = 503
        Me.pbAddPacker.TabStop = False
        Me.pbAddPacker.Tag = ""
        '
        'lblPackerName
        '
        Me.lblPackerName.AutoSize = True
        Me.lblPackerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackerName.Location = New System.Drawing.Point(7, 85)
        Me.lblPackerName.Name = "lblPackerName"
        Me.lblPackerName.Size = New System.Drawing.Size(85, 15)
        Me.lblPackerName.TabIndex = 13
        Me.lblPackerName.Text = "Packer Name:"
        '
        'txtCartonNo
        '
        Me.txtCartonNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCartonNo.Location = New System.Drawing.Point(73, 55)
        Me.txtCartonNo.Name = "txtCartonNo"
        Me.txtCartonNo.Size = New System.Drawing.Size(100, 21)
        Me.txtCartonNo.TabIndex = 2
        '
        'lblCartonNoA
        '
        Me.lblCartonNoA.AutoSize = True
        Me.lblCartonNoA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartonNoA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCartonNoA.Location = New System.Drawing.Point(7, 58)
        Me.lblCartonNoA.Name = "lblCartonNoA"
        Me.lblCartonNoA.Size = New System.Drawing.Size(53, 15)
        Me.lblCartonNoA.TabIndex = 10
        Me.lblCartonNoA.Text = "Box No.:"
        '
        'lblCartonNoAsteriskA
        '
        Me.lblCartonNoAsteriskA.AutoSize = True
        Me.lblCartonNoAsteriskA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartonNoAsteriskA.ForeColor = System.Drawing.Color.Red
        Me.lblCartonNoAsteriskA.Location = New System.Drawing.Point(59, 55)
        Me.lblCartonNoAsteriskA.Name = "lblCartonNoAsteriskA"
        Me.lblCartonNoAsteriskA.Size = New System.Drawing.Size(16, 20)
        Me.lblCartonNoAsteriskA.TabIndex = 11
        Me.lblCartonNoAsteriskA.Text = "*"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'txtWeight
        '
        Me.txtWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(12, 158)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(60, 21)
        Me.txtWeight.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(55, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Weight:"
        '
        'cboPackerName
        '
        Me.cboPackerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPackerName.FormattingEnabled = True
        Me.cboPackerName.Location = New System.Drawing.Point(101, 82)
        Me.cboPackerName.Name = "cboPackerName"
        Me.cboPackerName.Size = New System.Drawing.Size(271, 23)
        Me.cboPackerName.TabIndex = 4
        '
        'cboWeightUOM
        '
        Me.cboWeightUOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboWeightUOM.FormattingEnabled = True
        Me.cboWeightUOM.Location = New System.Drawing.Point(77, 158)
        Me.cboWeightUOM.Name = "cboWeightUOM"
        Me.cboWeightUOM.Size = New System.Drawing.Size(60, 23)
        Me.cboWeightUOM.TabIndex = 7
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(294, 158)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(95, 21)
        Me.txtAmount.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(320, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Amount:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(7, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Size Info:"
        '
        'cboSizeInfo
        '
        Me.cboSizeInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSizeInfo.FormattingEnabled = True
        Me.cboSizeInfo.Location = New System.Drawing.Point(73, 111)
        Me.cboSizeInfo.Name = "cboSizeInfo"
        Me.cboSizeInfo.Size = New System.Drawing.Size(299, 23)
        Me.cboSizeInfo.TabIndex = 5
        '
        'pbAddSize
        '
        Me.pbAddSize.BackColor = System.Drawing.Color.Transparent
        Me.pbAddSize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddSize.Image = CType(resources.GetObject("pbAddSize.Image"), System.Drawing.Image)
        Me.pbAddSize.Location = New System.Drawing.Point(375, 114)
        Me.pbAddSize.Name = "pbAddSize"
        Me.pbAddSize.Size = New System.Drawing.Size(14, 18)
        Me.pbAddSize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddSize.TabIndex = 512
        Me.pbAddSize.TabStop = False
        Me.pbAddSize.Tag = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(160, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "(Unit Of Measure)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(270, 161)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 15)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "(₱)"
        '
        'pbAutoAddA
        '
        Me.pbAutoAddA.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddA.Image = CType(resources.GetObject("pbAutoAddA.Image"), System.Drawing.Image)
        Me.pbAutoAddA.Location = New System.Drawing.Point(141, 161)
        Me.pbAutoAddA.Name = "pbAutoAddA"
        Me.pbAutoAddA.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddA.TabIndex = 533
        Me.pbAutoAddA.TabStop = False
        Me.pbAutoAddA.Tag = ""
        '
        'EditCartonForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(404, 187)
        Me.Controls.Add(Me.pbAutoAddA)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.pbAddSize)
        Me.Controls.Add(Me.cboSizeInfo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboWeightUOM)
        Me.Controls.Add(Me.txtWeight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpPackedDate)
        Me.Controls.Add(Me.lblPackedDate)
        Me.Controls.Add(Me.pbAddPacker)
        Me.Controls.Add(Me.cboPackerName)
        Me.Controls.Add(Me.lblPackerName)
        Me.Controls.Add(Me.txtCartonNo)
        Me.Controls.Add(Me.lblCartonNoA)
        Me.Controls.Add(Me.lblCartonNoAsteriskA)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditCartonForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbAddPacker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpPackedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPackedDate As System.Windows.Forms.Label
    Friend WithEvents pbAddPacker As System.Windows.Forms.PictureBox
    Friend WithEvents lblPackerName As System.Windows.Forms.Label
    Friend WithEvents txtCartonNo As System.Windows.Forms.TextBox
    Friend WithEvents lblCartonNoA As System.Windows.Forms.Label
    Friend WithEvents lblCartonNoAsteriskA As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboWeightUOM As System.Windows.Forms.ComboBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPackerName As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSizeInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pbAddSize As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents pbAutoAddA As System.Windows.Forms.PictureBox
End Class
