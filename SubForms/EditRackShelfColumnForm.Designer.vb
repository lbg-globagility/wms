<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditRackShelfColumnForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditRackShelfColumnForm))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboColumn = New System.Windows.Forms.ComboBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.cboShelf = New System.Windows.Forms.ComboBox()
        Me.cboRack = New System.Windows.Forms.ComboBox()
        Me.lblQtyIssued = New System.Windows.Forms.Label()
        Me.lblQtyReceived = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtPickOrderNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pbAutoAddShelf = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddColumn = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddRack = New System.Windows.Forms.PictureBox()
        Me.msMenu.SuspendLayout()
        CType(Me.pbAutoAddShelf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddRack, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(353, 28)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Edit - Rack / Column / Shelf"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Column:"
        '
        'cboColumn
        '
        Me.cboColumn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboColumn.FormattingEnabled = True
        Me.cboColumn.Location = New System.Drawing.Point(65, 89)
        Me.cboColumn.Name = "cboColumn"
        Me.cboColumn.Size = New System.Drawing.Size(65, 23)
        Me.cboColumn.TabIndex = 2
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(179, 100)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(155, 41)
        Me.txtRemarks.TabIndex = 5
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRemarks.Location = New System.Drawing.Point(226, 81)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(60, 15)
        Me.lblRemarks.TabIndex = 12
        Me.lblRemarks.Text = "Remarks:"
        '
        'cboShelf
        '
        Me.cboShelf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShelf.FormattingEnabled = True
        Me.cboShelf.Location = New System.Drawing.Point(65, 118)
        Me.cboShelf.Name = "cboShelf"
        Me.cboShelf.Size = New System.Drawing.Size(65, 23)
        Me.cboShelf.TabIndex = 3
        '
        'cboRack
        '
        Me.cboRack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRack.FormattingEnabled = True
        Me.cboRack.Location = New System.Drawing.Point(65, 60)
        Me.cboRack.Name = "cboRack"
        Me.cboRack.Size = New System.Drawing.Size(65, 23)
        Me.cboRack.TabIndex = 1
        '
        'lblQtyIssued
        '
        Me.lblQtyIssued.AutoSize = True
        Me.lblQtyIssued.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQtyIssued.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblQtyIssued.Location = New System.Drawing.Point(8, 121)
        Me.lblQtyIssued.Name = "lblQtyIssued"
        Me.lblQtyIssued.Size = New System.Drawing.Size(38, 15)
        Me.lblQtyIssued.TabIndex = 10
        Me.lblQtyIssued.Text = "Shelf:"
        '
        'lblQtyReceived
        '
        Me.lblQtyReceived.AutoSize = True
        Me.lblQtyReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQtyReceived.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblQtyReceived.Location = New System.Drawing.Point(8, 61)
        Me.lblQtyReceived.Name = "lblQtyReceived"
        Me.lblQtyReceived.Size = New System.Drawing.Size(38, 15)
        Me.lblQtyReceived.TabIndex = 8
        Me.lblQtyReceived.Text = "Rack:"
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(353, 25)
        Me.msMenu.TabIndex = 6
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'txtPickOrderNo
        '
        Me.txtPickOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPickOrderNo.Location = New System.Drawing.Point(267, 58)
        Me.txtPickOrderNo.Name = "txtPickOrderNo"
        Me.txtPickOrderNo.Size = New System.Drawing.Size(67, 21)
        Me.txtPickOrderNo.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(176, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 15)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Pick Order No.:"
        '
        'pbAutoAddShelf
        '
        Me.pbAutoAddShelf.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddShelf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddShelf.Image = CType(resources.GetObject("pbAutoAddShelf.Image"), System.Drawing.Image)
        Me.pbAutoAddShelf.Location = New System.Drawing.Point(134, 121)
        Me.pbAutoAddShelf.Name = "pbAutoAddShelf"
        Me.pbAutoAddShelf.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddShelf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddShelf.TabIndex = 537
        Me.pbAutoAddShelf.TabStop = False
        Me.pbAutoAddShelf.Tag = ""
        '
        'pbAutoAddColumn
        '
        Me.pbAutoAddColumn.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddColumn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddColumn.Image = CType(resources.GetObject("pbAutoAddColumn.Image"), System.Drawing.Image)
        Me.pbAutoAddColumn.Location = New System.Drawing.Point(134, 92)
        Me.pbAutoAddColumn.Name = "pbAutoAddColumn"
        Me.pbAutoAddColumn.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddColumn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddColumn.TabIndex = 536
        Me.pbAutoAddColumn.TabStop = False
        Me.pbAutoAddColumn.Tag = ""
        '
        'pbAutoAddRack
        '
        Me.pbAutoAddRack.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddRack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddRack.Image = CType(resources.GetObject("pbAutoAddRack.Image"), System.Drawing.Image)
        Me.pbAutoAddRack.Location = New System.Drawing.Point(134, 63)
        Me.pbAutoAddRack.Name = "pbAutoAddRack"
        Me.pbAutoAddRack.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddRack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddRack.TabIndex = 535
        Me.pbAutoAddRack.TabStop = False
        Me.pbAutoAddRack.Tag = ""
        '
        'EditRackShelfColumnForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(353, 154)
        Me.Controls.Add(Me.pbAutoAddShelf)
        Me.Controls.Add(Me.pbAutoAddColumn)
        Me.Controls.Add(Me.pbAutoAddRack)
        Me.Controls.Add(Me.txtPickOrderNo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboColumn)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.cboShelf)
        Me.Controls.Add(Me.cboRack)
        Me.Controls.Add(Me.lblQtyIssued)
        Me.Controls.Add(Me.lblQtyReceived)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditRackShelfColumnForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbAutoAddShelf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddColumn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddRack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboColumn As System.Windows.Forms.ComboBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents cboShelf As System.Windows.Forms.ComboBox
    Friend WithEvents cboRack As System.Windows.Forms.ComboBox
    Friend WithEvents lblQtyIssued As System.Windows.Forms.Label
    Friend WithEvents lblQtyReceived As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtPickOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pbAutoAddShelf As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddColumn As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddRack As System.Windows.Forms.PictureBox
End Class
