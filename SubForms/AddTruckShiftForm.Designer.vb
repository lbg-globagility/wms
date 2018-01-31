<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddTruckShiftForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddTruckShiftForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbAddTruck = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboTruckInfo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pbAddShift = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboShiftInfo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.msMenu.SuspendLayout()
        CType(Me.pbAddTruck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddShift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(434, 28)
        Me.Label1.TabIndex = 398
        Me.Label1.Text = "Add Truck And Shift"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(434, 25)
        Me.msMenu.TabIndex = 1
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'pbAddTruck
        '
        Me.pbAddTruck.BackColor = System.Drawing.Color.Transparent
        Me.pbAddTruck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddTruck.Image = CType(resources.GetObject("pbAddTruck.Image"), System.Drawing.Image)
        Me.pbAddTruck.Location = New System.Drawing.Point(397, 59)
        Me.pbAddTruck.Name = "pbAddTruck"
        Me.pbAddTruck.Size = New System.Drawing.Size(14, 18)
        Me.pbAddTruck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddTruck.TabIndex = 439
        Me.pbAddTruck.TabStop = False
        Me.pbAddTruck.Tag = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(76, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 20)
        Me.Label9.TabIndex = 438
        Me.Label9.Text = "*"
        '
        'cboTruckInfo
        '
        Me.cboTruckInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTruckInfo.FormattingEnabled = True
        Me.cboTruckInfo.Location = New System.Drawing.Point(94, 57)
        Me.cboTruckInfo.Name = "cboTruckInfo"
        Me.cboTruckInfo.Size = New System.Drawing.Size(300, 23)
        Me.cboTruckInfo.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(11, 60)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 15)
        Me.Label14.TabIndex = 437
        Me.Label14.Text = "Truck Info.:"
        '
        'pbAddShift
        '
        Me.pbAddShift.BackColor = System.Drawing.Color.Transparent
        Me.pbAddShift.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddShift.Image = CType(resources.GetObject("pbAddShift.Image"), System.Drawing.Image)
        Me.pbAddShift.Location = New System.Drawing.Point(397, 88)
        Me.pbAddShift.Name = "pbAddShift"
        Me.pbAddShift.Size = New System.Drawing.Size(14, 18)
        Me.pbAddShift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddShift.TabIndex = 443
        Me.pbAddShift.TabStop = False
        Me.pbAddShift.Tag = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(76, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 20)
        Me.Label2.TabIndex = 442
        Me.Label2.Text = "*"
        '
        'cboShiftInfo
        '
        Me.cboShiftInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShiftInfo.FormattingEnabled = True
        Me.cboShiftInfo.Location = New System.Drawing.Point(94, 86)
        Me.cboShiftInfo.Name = "cboShiftInfo"
        Me.cboShiftInfo.Size = New System.Drawing.Size(300, 23)
        Me.cboShiftInfo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 441
        Me.Label3.Text = "Shift Info.:"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'AddTruckShiftForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(434, 122)
        Me.Controls.Add(Me.pbAddShift)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboShiftInfo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pbAddTruck)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboTruckInfo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddTruckShiftForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbAddTruck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddShift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbAddTruck As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboTruckInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pbAddShift As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboShiftInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
End Class
