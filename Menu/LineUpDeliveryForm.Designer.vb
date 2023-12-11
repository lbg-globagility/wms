<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LineUpDeliveryForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LineUpDeliveryForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.dtpToSearch = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromSearch = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dgLineUpCalendar = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.lud_basisdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lud_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msViewEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblsavemsg = New System.Windows.Forms.Label()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgLineUpCalendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbClose
        '
        Me.pbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pbClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClose.Image = CType(resources.GetObject("pbClose.Image"), System.Drawing.Image)
        Me.pbClose.Location = New System.Drawing.Point(1175, 5)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(19, 19)
        Me.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbClose.TabIndex = 240
        Me.pbClose.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1200, 28)
        Me.lblTitle.TabIndex = 239
        Me.lblTitle.Text = "Line-Up And Delivery"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(626, 63)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(24, 15)
        Me.Label40.TabIndex = 259
        Me.Label40.Text = "To:"
        '
        'dtpToSearch
        '
        Me.dtpToSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpToSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpToSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToSearch.Location = New System.Drawing.Point(656, 60)
        Me.dtpToSearch.Name = "dtpToSearch"
        Me.dtpToSearch.Size = New System.Drawing.Size(110, 20)
        Me.dtpToSearch.TabIndex = 257
        '
        'dtpFromSearch
        '
        Me.dtpFromSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpFromSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromSearch.Location = New System.Drawing.Point(498, 60)
        Me.dtpFromSearch.Name = "dtpFromSearch"
        Me.dtpFromSearch.Size = New System.Drawing.Size(110, 20)
        Me.dtpFromSearch.TabIndex = 256
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(457, 63)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 15)
        Me.Label18.TabIndex = 258
        Me.Label18.Text = "From:"
        '
        'dgLineUpCalendar
        '
        Me.dgLineUpCalendar.AllowUserToAddRows = False
        Me.dgLineUpCalendar.AllowUserToDeleteRows = False
        Me.dgLineUpCalendar.AllowUserToOrderColumns = True
        Me.dgLineUpCalendar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLineUpCalendar.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLineUpCalendar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLineUpCalendar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lud_basisdate, Me.lud_date})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLineUpCalendar.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgLineUpCalendar.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgLineUpCalendar.Location = New System.Drawing.Point(15, 86)
        Me.dgLineUpCalendar.MultiSelect = False
        Me.dgLineUpCalendar.Name = "dgLineUpCalendar"
        Me.dgLineUpCalendar.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLineUpCalendar.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgLineUpCalendar.RowTemplate.Height = 60
        Me.dgLineUpCalendar.Size = New System.Drawing.Size(1170, 462)
        Me.dgLineUpCalendar.TabIndex = 260
        '
        'lud_basisdate
        '
        Me.lud_basisdate.HeaderText = "basisdate"
        Me.lud_basisdate.Name = "lud_basisdate"
        Me.lud_basisdate.ReadOnly = True
        Me.lud_basisdate.Visible = False
        '
        'lud_date
        '
        Me.lud_date.HeaderText = "Delivery Date"
        Me.lud_date.Name = "lud_date"
        Me.lud_date.ReadOnly = True
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msRefresh, Me.msNew, Me.msViewEdit})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(1200, 25)
        Me.msMenu.TabIndex = 262
        '
        'msRefresh
        '
        Me.msRefresh.Image = CType(resources.GetObject("msRefresh.Image"), System.Drawing.Image)
        Me.msRefresh.Name = "msRefresh"
        Me.msRefresh.Size = New System.Drawing.Size(82, 21)
        Me.msRefresh.Text = "&Refresh"
        '
        'msNew
        '
        Me.msNew.Image = CType(resources.GetObject("msNew.Image"), System.Drawing.Image)
        Me.msNew.Name = "msNew"
        Me.msNew.Size = New System.Drawing.Size(63, 21)
        Me.msNew.Text = "&New"
        '
        'msViewEdit
        '
        Me.msViewEdit.Image = CType(resources.GetObject("msViewEdit.Image"), System.Drawing.Image)
        Me.msViewEdit.Name = "msViewEdit"
        Me.msViewEdit.Size = New System.Drawing.Size(239, 21)
        Me.msViewEdit.Text = "&View / Edit Line-Up and Delivery"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(18, 34)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 263
        '
        'LineUpDeliveryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.lblsavemsg)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.dgLineUpCalendar)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.dtpToSearch)
        Me.Controls.Add(Me.dtpFromSearch)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LineUpDeliveryForm"
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgLineUpCalendar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents dtpToSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dgLineUpCalendar As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents msViewEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lud_basisdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lud_date As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
