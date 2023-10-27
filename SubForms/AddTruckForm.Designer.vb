<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddTruckForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddTruckForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtTruckNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTruckName = New System.Windows.Forms.TextBox()
        Me.txtPlateNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboBrandName = New System.Windows.Forms.ComboBox()
        Me.cboMadeIn = New System.Windows.Forms.ComboBox()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pbAutoAddA = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddB = New System.Windows.Forms.PictureBox()
        Me.txtCBM = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMaxCapacity = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtYearModel = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.msMenu.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(484, 28)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Add Truck"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(484, 25)
        Me.msMenu.TabIndex = 1
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(8, 85)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(77, 15)
        Me.Label52.TabIndex = 10
        Me.Label52.Text = "Truck Name:"
        '
        'txtTruckNo
        '
        Me.txtTruckNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTruckNo.Location = New System.Drawing.Point(101, 55)
        Me.txtTruckNo.Name = "txtTruckNo"
        Me.txtTruckNo.ReadOnly = True
        Me.txtTruckNo.Size = New System.Drawing.Size(142, 21)
        Me.txtTruckNo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Truck No.:"
        '
        'txtTruckName
        '
        Me.txtTruckName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTruckName.Location = New System.Drawing.Point(101, 82)
        Me.txtTruckName.Name = "txtTruckName"
        Me.txtTruckName.Size = New System.Drawing.Size(142, 21)
        Me.txtTruckName.TabIndex = 3
        '
        'txtPlateNo
        '
        Me.txtPlateNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlateNo.Location = New System.Drawing.Point(324, 82)
        Me.txtPlateNo.Name = "txtPlateNo"
        Me.txtPlateNo.Size = New System.Drawing.Size(146, 21)
        Me.txtPlateNo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(264, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Plate No.:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Brand Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(264, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Made In:"
        '
        'cboBrandName
        '
        Me.cboBrandName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBrandName.FormattingEnabled = True
        Me.cboBrandName.Location = New System.Drawing.Point(101, 110)
        Me.cboBrandName.Name = "cboBrandName"
        Me.cboBrandName.Size = New System.Drawing.Size(120, 23)
        Me.cboBrandName.TabIndex = 4
        '
        'cboMadeIn
        '
        Me.cboMadeIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMadeIn.FormattingEnabled = True
        Me.cboMadeIn.Location = New System.Drawing.Point(325, 110)
        Me.cboMadeIn.Name = "cboMadeIn"
        Me.cboMadeIn.Size = New System.Drawing.Size(121, 23)
        Me.cboMadeIn.TabIndex = 7
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(84, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "*"
        '
        'pbAutoAddA
        '
        Me.pbAutoAddA.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddA.Image = CType(resources.GetObject("pbAutoAddA.Image"), System.Drawing.Image)
        Me.pbAutoAddA.Location = New System.Drawing.Point(224, 113)
        Me.pbAutoAddA.Name = "pbAutoAddA"
        Me.pbAutoAddA.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddA.TabIndex = 532
        Me.pbAutoAddA.TabStop = False
        Me.pbAutoAddA.Tag = ""
        '
        'pbAutoAddB
        '
        Me.pbAutoAddB.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddB.Image = CType(resources.GetObject("pbAutoAddB.Image"), System.Drawing.Image)
        Me.pbAutoAddB.Location = New System.Drawing.Point(451, 112)
        Me.pbAutoAddB.Name = "pbAutoAddB"
        Me.pbAutoAddB.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddB.TabIndex = 533
        Me.pbAutoAddB.TabStop = False
        Me.pbAutoAddB.Tag = ""
        '
        'txtCBM
        '
        Me.txtCBM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCBM.Location = New System.Drawing.Point(324, 55)
        Me.txtCBM.Name = "txtCBM"
        Me.txtCBM.Size = New System.Drawing.Size(146, 21)
        Me.txtCBM.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(264, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "CBM:"
        '
        'txtMaxCapacity
        '
        Me.txtMaxCapacity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxCapacity.Location = New System.Drawing.Point(101, 141)
        Me.txtMaxCapacity.Name = "txtMaxCapacity"
        Me.txtMaxCapacity.Size = New System.Drawing.Size(146, 21)
        Me.txtMaxCapacity.TabIndex = 534
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 15)
        Me.Label8.TabIndex = 535
        Me.Label8.Text = "Max Capacity:"
        '
        'txtYearModel
        '
        Me.txtYearModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYearModel.Location = New System.Drawing.Point(367, 141)
        Me.txtYearModel.Name = "txtYearModel"
        Me.txtYearModel.Size = New System.Drawing.Size(103, 21)
        Me.txtYearModel.TabIndex = 536
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(264, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 15)
        Me.Label9.TabIndex = 537
        Me.Label9.Text = "Year And Model:"
        '
        'AddTruckForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(484, 174)
        Me.Controls.Add(Me.txtYearModel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtMaxCapacity)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCBM)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.pbAutoAddB)
        Me.Controls.Add(Me.pbAutoAddA)
        Me.Controls.Add(Me.cboMadeIn)
        Me.Controls.Add(Me.cboBrandName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPlateNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.txtTruckNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTruckName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddTruckForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtTruckNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTruckName As System.Windows.Forms.TextBox
    Friend WithEvents txtPlateNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboBrandName As System.Windows.Forms.ComboBox
    Friend WithEvents cboMadeIn As System.Windows.Forms.ComboBox
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pbAutoAddB As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddA As System.Windows.Forms.PictureBox
    Friend WithEvents txtCBM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtYearModel As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtMaxCapacity As TextBox
    Friend WithEvents Label8 As Label
End Class
