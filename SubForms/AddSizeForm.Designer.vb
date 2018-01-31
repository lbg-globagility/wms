<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSizeForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddSizeForm))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboLengthUOM = New System.Windows.Forms.ComboBox()
        Me.txtLength = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboWidthUOM = New System.Windows.Forms.ComboBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboHeightUOM = New System.Windows.Forms.ComboBox()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSizeName = New System.Windows.Forms.TextBox()
        Me.lblCartonNoA = New System.Windows.Forms.Label()
        Me.lblCartonNoAsteriskA = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pbAutoAddA = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddB = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddC = New System.Windows.Forms.PictureBox()
        Me.msMenu.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddC, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(349, 28)
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "Add Sizes"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(349, 25)
        Me.msMenu.TabIndex = 1
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(236, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "(Unit Of Measure)"
        '
        'cboLengthUOM
        '
        Me.cboLengthUOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLengthUOM.FormattingEnabled = True
        Me.cboLengthUOM.Location = New System.Drawing.Point(149, 79)
        Me.cboLengthUOM.Name = "cboLengthUOM"
        Me.cboLengthUOM.Size = New System.Drawing.Size(60, 23)
        Me.cboLengthUOM.TabIndex = 4
        '
        'txtLength
        '
        Me.txtLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLength.Location = New System.Drawing.Point(63, 79)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(80, 21)
        Me.txtLength.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(9, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Length:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(236, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "(Unit Of Measure)"
        '
        'cboWidthUOM
        '
        Me.cboWidthUOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboWidthUOM.FormattingEnabled = True
        Me.cboWidthUOM.Location = New System.Drawing.Point(149, 108)
        Me.cboWidthUOM.Name = "cboWidthUOM"
        Me.cboWidthUOM.Size = New System.Drawing.Size(60, 23)
        Me.cboWidthUOM.TabIndex = 6
        '
        'txtWidth
        '
        Me.txtWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWidth.Location = New System.Drawing.Point(63, 108)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(80, 21)
        Me.txtWidth.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(9, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Width:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(236, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "(Unit Of Measure)"
        '
        'cboHeightUOM
        '
        Me.cboHeightUOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHeightUOM.FormattingEnabled = True
        Me.cboHeightUOM.Location = New System.Drawing.Point(149, 137)
        Me.cboHeightUOM.Name = "cboHeightUOM"
        Me.cboHeightUOM.Size = New System.Drawing.Size(60, 23)
        Me.cboHeightUOM.TabIndex = 8
        '
        'txtHeight
        '
        Me.txtHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.Location = New System.Drawing.Point(63, 137)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(80, 21)
        Me.txtHeight.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(9, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Height:"
        '
        'txtSizeName
        '
        Me.txtSizeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSizeName.Location = New System.Drawing.Point(93, 52)
        Me.txtSizeName.Name = "txtSizeName"
        Me.txtSizeName.Size = New System.Drawing.Size(125, 21)
        Me.txtSizeName.TabIndex = 2
        '
        'lblCartonNoA
        '
        Me.lblCartonNoA.AutoSize = True
        Me.lblCartonNoA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartonNoA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCartonNoA.Location = New System.Drawing.Point(9, 55)
        Me.lblCartonNoA.Name = "lblCartonNoA"
        Me.lblCartonNoA.Size = New System.Drawing.Size(71, 15)
        Me.lblCartonNoA.TabIndex = 10
        Me.lblCartonNoA.Text = "Size Name:"
        '
        'lblCartonNoAsteriskA
        '
        Me.lblCartonNoAsteriskA.AutoSize = True
        Me.lblCartonNoAsteriskA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartonNoAsteriskA.ForeColor = System.Drawing.Color.Red
        Me.lblCartonNoAsteriskA.Location = New System.Drawing.Point(79, 52)
        Me.lblCartonNoAsteriskA.Name = "lblCartonNoAsteriskA"
        Me.lblCartonNoAsteriskA.Size = New System.Drawing.Size(16, 20)
        Me.lblCartonNoAsteriskA.TabIndex = 11
        Me.lblCartonNoAsteriskA.Text = "*"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'pbAutoAddA
        '
        Me.pbAutoAddA.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddA.Image = CType(resources.GetObject("pbAutoAddA.Image"), System.Drawing.Image)
        Me.pbAutoAddA.Location = New System.Drawing.Point(213, 81)
        Me.pbAutoAddA.Name = "pbAutoAddA"
        Me.pbAutoAddA.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddA.TabIndex = 531
        Me.pbAutoAddA.TabStop = False
        Me.pbAutoAddA.Tag = ""
        '
        'pbAutoAddB
        '
        Me.pbAutoAddB.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddB.Image = CType(resources.GetObject("pbAutoAddB.Image"), System.Drawing.Image)
        Me.pbAutoAddB.Location = New System.Drawing.Point(213, 110)
        Me.pbAutoAddB.Name = "pbAutoAddB"
        Me.pbAutoAddB.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddB.TabIndex = 532
        Me.pbAutoAddB.TabStop = False
        Me.pbAutoAddB.Tag = ""
        '
        'pbAutoAddC
        '
        Me.pbAutoAddC.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddC.Image = CType(resources.GetObject("pbAutoAddC.Image"), System.Drawing.Image)
        Me.pbAutoAddC.Location = New System.Drawing.Point(213, 139)
        Me.pbAutoAddC.Name = "pbAutoAddC"
        Me.pbAutoAddC.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddC.TabIndex = 533
        Me.pbAutoAddC.TabStop = False
        Me.pbAutoAddC.Tag = ""
        '
        'AddSizeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(349, 172)
        Me.Controls.Add(Me.pbAutoAddC)
        Me.Controls.Add(Me.pbAutoAddB)
        Me.Controls.Add(Me.pbAutoAddA)
        Me.Controls.Add(Me.txtSizeName)
        Me.Controls.Add(Me.lblCartonNoA)
        Me.Controls.Add(Me.lblCartonNoAsteriskA)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboHeightUOM)
        Me.Controls.Add(Me.txtHeight)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboWidthUOM)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboLengthUOM)
        Me.Controls.Add(Me.txtLength)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddSizeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboLengthUOM As System.Windows.Forms.ComboBox
    Friend WithEvents txtLength As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboWidthUOM As System.Windows.Forms.ComboBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboHeightUOM As System.Windows.Forms.ComboBox
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSizeName As System.Windows.Forms.TextBox
    Friend WithEvents lblCartonNoA As System.Windows.Forms.Label
    Friend WithEvents lblCartonNoAsteriskA As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents pbAutoAddC As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddB As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddA As System.Windows.Forms.PictureBox
End Class
