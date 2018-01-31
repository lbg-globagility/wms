<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddressForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddressForm))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtStreetAddress1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStreetAddress2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboBarangay = New System.Windows.Forms.ComboBox()
        Me.cboCityTown = New System.Windows.Forms.ComboBox()
        Me.cboProvince = New System.Windows.Forms.ComboBox()
        Me.cboState = New System.Windows.Forms.ComboBox()
        Me.cboZIPCode = New System.Windows.Forms.ComboBox()
        Me.cboCountry = New System.Windows.Forms.ComboBox()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.pbAutoAddA = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddB = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddC = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddD = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddE = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddF = New System.Windows.Forms.PictureBox()
        Me.msMenu.SuspendLayout()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddF, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(381, 28)
        Me.lblTitle.TabIndex = 395
        Me.lblTitle.Text = "Address"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(381, 25)
        Me.msMenu.TabIndex = 1
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'txtStreetAddress1
        '
        Me.txtStreetAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreetAddress1.Location = New System.Drawing.Point(116, 65)
        Me.txtStreetAddress1.Name = "txtStreetAddress1"
        Me.txtStreetAddress1.Size = New System.Drawing.Size(235, 21)
        Me.txtStreetAddress1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(11, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 399
        Me.Label1.Text = "Street Address 1:"
        '
        'txtStreetAddress2
        '
        Me.txtStreetAddress2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreetAddress2.Location = New System.Drawing.Point(116, 92)
        Me.txtStreetAddress2.Name = "txtStreetAddress2"
        Me.txtStreetAddress2.Size = New System.Drawing.Size(235, 21)
        Me.txtStreetAddress2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(11, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 15)
        Me.Label2.TabIndex = 401
        Me.Label2.Text = "Street Address 2:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(11, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 15)
        Me.Label3.TabIndex = 403
        Me.Label3.Text = "Barangay:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(11, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 15)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "City/Town:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(11, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 407
        Me.Label5.Text = "Province:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(11, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 409
        Me.Label6.Text = "State:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(11, 238)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 15)
        Me.Label7.TabIndex = 411
        Me.Label7.Text = "ZIP Code:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(11, 267)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 15)
        Me.Label8.TabIndex = 413
        Me.Label8.Text = "Country:"
        '
        'cboBarangay
        '
        Me.cboBarangay.BackColor = System.Drawing.SystemColors.Window
        Me.cboBarangay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBarangay.FormattingEnabled = True
        Me.cboBarangay.Location = New System.Drawing.Point(116, 119)
        Me.cboBarangay.Name = "cboBarangay"
        Me.cboBarangay.Size = New System.Drawing.Size(235, 23)
        Me.cboBarangay.TabIndex = 4
        '
        'cboCityTown
        '
        Me.cboCityTown.BackColor = System.Drawing.SystemColors.Window
        Me.cboCityTown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCityTown.FormattingEnabled = True
        Me.cboCityTown.Location = New System.Drawing.Point(116, 148)
        Me.cboCityTown.Name = "cboCityTown"
        Me.cboCityTown.Size = New System.Drawing.Size(235, 23)
        Me.cboCityTown.TabIndex = 5
        '
        'cboProvince
        '
        Me.cboProvince.BackColor = System.Drawing.SystemColors.Window
        Me.cboProvince.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProvince.FormattingEnabled = True
        Me.cboProvince.Location = New System.Drawing.Point(116, 177)
        Me.cboProvince.Name = "cboProvince"
        Me.cboProvince.Size = New System.Drawing.Size(235, 23)
        Me.cboProvince.TabIndex = 6
        '
        'cboState
        '
        Me.cboState.BackColor = System.Drawing.SystemColors.Window
        Me.cboState.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboState.FormattingEnabled = True
        Me.cboState.Location = New System.Drawing.Point(116, 206)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(235, 23)
        Me.cboState.TabIndex = 7
        '
        'cboZIPCode
        '
        Me.cboZIPCode.BackColor = System.Drawing.SystemColors.Window
        Me.cboZIPCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZIPCode.FormattingEnabled = True
        Me.cboZIPCode.Location = New System.Drawing.Point(116, 235)
        Me.cboZIPCode.Name = "cboZIPCode"
        Me.cboZIPCode.Size = New System.Drawing.Size(235, 23)
        Me.cboZIPCode.TabIndex = 8
        '
        'cboCountry
        '
        Me.cboCountry.BackColor = System.Drawing.SystemColors.Window
        Me.cboCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCountry.FormattingEnabled = True
        Me.cboCountry.Location = New System.Drawing.Point(116, 264)
        Me.cboCountry.Name = "cboCountry"
        Me.cboCountry.Size = New System.Drawing.Size(235, 23)
        Me.cboCountry.TabIndex = 9
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(18, 33)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 420
        '
        'pbAutoAddA
        '
        Me.pbAutoAddA.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddA.Image = CType(resources.GetObject("pbAutoAddA.Image"), System.Drawing.Image)
        Me.pbAutoAddA.Location = New System.Drawing.Point(357, 121)
        Me.pbAutoAddA.Name = "pbAutoAddA"
        Me.pbAutoAddA.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddA.TabIndex = 556
        Me.pbAutoAddA.TabStop = False
        Me.pbAutoAddA.Tag = ""
        '
        'pbAutoAddB
        '
        Me.pbAutoAddB.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddB.Image = CType(resources.GetObject("pbAutoAddB.Image"), System.Drawing.Image)
        Me.pbAutoAddB.Location = New System.Drawing.Point(357, 150)
        Me.pbAutoAddB.Name = "pbAutoAddB"
        Me.pbAutoAddB.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddB.TabIndex = 557
        Me.pbAutoAddB.TabStop = False
        Me.pbAutoAddB.Tag = ""
        '
        'pbAutoAddC
        '
        Me.pbAutoAddC.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddC.Image = CType(resources.GetObject("pbAutoAddC.Image"), System.Drawing.Image)
        Me.pbAutoAddC.Location = New System.Drawing.Point(357, 179)
        Me.pbAutoAddC.Name = "pbAutoAddC"
        Me.pbAutoAddC.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddC.TabIndex = 558
        Me.pbAutoAddC.TabStop = False
        Me.pbAutoAddC.Tag = ""
        '
        'pbAutoAddD
        '
        Me.pbAutoAddD.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddD.Image = CType(resources.GetObject("pbAutoAddD.Image"), System.Drawing.Image)
        Me.pbAutoAddD.Location = New System.Drawing.Point(357, 208)
        Me.pbAutoAddD.Name = "pbAutoAddD"
        Me.pbAutoAddD.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddD.TabIndex = 559
        Me.pbAutoAddD.TabStop = False
        Me.pbAutoAddD.Tag = ""
        '
        'pbAutoAddE
        '
        Me.pbAutoAddE.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddE.Image = CType(resources.GetObject("pbAutoAddE.Image"), System.Drawing.Image)
        Me.pbAutoAddE.Location = New System.Drawing.Point(357, 237)
        Me.pbAutoAddE.Name = "pbAutoAddE"
        Me.pbAutoAddE.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddE.TabIndex = 560
        Me.pbAutoAddE.TabStop = False
        Me.pbAutoAddE.Tag = ""
        '
        'pbAutoAddF
        '
        Me.pbAutoAddF.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddF.Image = CType(resources.GetObject("pbAutoAddF.Image"), System.Drawing.Image)
        Me.pbAutoAddF.Location = New System.Drawing.Point(357, 266)
        Me.pbAutoAddF.Name = "pbAutoAddF"
        Me.pbAutoAddF.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddF.TabIndex = 561
        Me.pbAutoAddF.TabStop = False
        Me.pbAutoAddF.Tag = ""
        '
        'AddressForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(381, 304)
        Me.Controls.Add(Me.pbAutoAddF)
        Me.Controls.Add(Me.pbAutoAddE)
        Me.Controls.Add(Me.pbAutoAddD)
        Me.Controls.Add(Me.pbAutoAddC)
        Me.Controls.Add(Me.pbAutoAddB)
        Me.Controls.Add(Me.pbAutoAddA)
        Me.Controls.Add(Me.lblsavemsg)
        Me.Controls.Add(Me.cboCountry)
        Me.Controls.Add(Me.cboZIPCode)
        Me.Controls.Add(Me.cboState)
        Me.Controls.Add(Me.cboProvince)
        Me.Controls.Add(Me.cboCityTown)
        Me.Controls.Add(Me.cboBarangay)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtStreetAddress2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStreetAddress1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddressForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtStreetAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtStreetAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboBarangay As System.Windows.Forms.ComboBox
    Friend WithEvents cboCityTown As System.Windows.Forms.ComboBox
    Friend WithEvents cboProvince As System.Windows.Forms.ComboBox
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents cboZIPCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboCountry As System.Windows.Forms.ComboBox
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents pbAutoAddA As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddB As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddC As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddD As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddE As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddF As System.Windows.Forms.PictureBox
End Class
