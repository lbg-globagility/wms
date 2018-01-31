<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DummyForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DummyForm))
        Me.bccTestImage = New Spire.Barcode.Forms.BarCodeControl()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.dgSubmittedToWarehouseCO = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.stw_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stw_cono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stw_pono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stw_codate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stw_receiptdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stw_canceldate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stw_datesubmitted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stw_customername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stw_createdby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.gbBrandName = New System.Windows.Forms.GroupBox()
        Me.cboBrandName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbReceivingInformation = New System.Windows.Forms.GroupBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.gbContactInformation = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        CType(Me.dgSubmittedToWarehouseCO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.gbBrandName.SuspendLayout()
        Me.gbReceivingInformation.SuspendLayout()
        Me.gbContactInformation.SuspendLayout()
        Me.msMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'bccTestImage
        '
        Me.bccTestImage.BorderWidth = 0.6!
        Me.bccTestImage.Data = "000"
        Me.bccTestImage.Data2D = "000"
        Me.bccTestImage.DpiX = 96.0!
        Me.bccTestImage.DpiY = 96.0!
        Me.bccTestImage.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.bccTestImage.ImageHeight = 30.0!
        Me.bccTestImage.ImageWidth = 120.0!
        Me.bccTestImage.Location = New System.Drawing.Point(513, 88)
        Me.bccTestImage.Name = "bccTestImage"
        Me.bccTestImage.Rotate = 0.0!
        Me.bccTestImage.ShowText = False
        Me.bccTestImage.Size = New System.Drawing.Size(289, 29)
        Me.bccTestImage.SupSpace = 4.0!
        Me.bccTestImage.TabIndex = 0
        Me.bccTestImage.Tag = ""
        Me.bccTestImage.TextFont = New System.Drawing.Font("Arial", 8.0!)
        Me.bccTestImage.TopText = ""
        Me.bccTestImage.TopTextAligment = System.Drawing.StringAlignment.Center
        Me.bccTestImage.TopTextFont = New System.Drawing.Font("Arial", 8.0!)
        Me.bccTestImage.Type = CType(((Spire.Barcode.BarCodeType.Codabar Or Spire.Barcode.BarCodeType.Code93Extended) _
            Or Spire.Barcode.BarCodeType.ITF14), Spire.Barcode.BarCodeType)
        Me.bccTestImage.UseChecksum = Spire.Barcode.CheckSumMode.[Auto]
        Me.bccTestImage.WideNarrowRatio = 3.0!
        Me.bccTestImage.X = 1.0!
        Me.bccTestImage.XYRatio = 1.0!
        Me.bccTestImage.Y = 1.0!
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(144, 41)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(133, 101)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(321, 41)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(133, 101)
        Me.btnImport.TabIndex = 2
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'dgSubmittedToWarehouseCO
        '
        Me.dgSubmittedToWarehouseCO.AllowUserToAddRows = False
        Me.dgSubmittedToWarehouseCO.AllowUserToDeleteRows = False
        Me.dgSubmittedToWarehouseCO.AllowUserToOrderColumns = True
        Me.dgSubmittedToWarehouseCO.AllowUserToResizeRows = False
        Me.dgSubmittedToWarehouseCO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgSubmittedToWarehouseCO.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSubmittedToWarehouseCO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSubmittedToWarehouseCO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSubmittedToWarehouseCO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.stw_rowid, Me.stw_cono, Me.stw_pono, Me.stw_codate, Me.stw_receiptdate, Me.stw_canceldate, Me.stw_datesubmitted, Me.stw_customername, Me.stw_createdby})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSubmittedToWarehouseCO.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgSubmittedToWarehouseCO.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgSubmittedToWarehouseCO.Location = New System.Drawing.Point(750, 324)
        Me.dgSubmittedToWarehouseCO.MultiSelect = False
        Me.dgSubmittedToWarehouseCO.Name = "dgSubmittedToWarehouseCO"
        Me.dgSubmittedToWarehouseCO.ReadOnly = True
        Me.dgSubmittedToWarehouseCO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSubmittedToWarehouseCO.Size = New System.Drawing.Size(168, 84)
        Me.dgSubmittedToWarehouseCO.TabIndex = 19
        '
        'stw_rowid
        '
        Me.stw_rowid.HeaderText = "rowid"
        Me.stw_rowid.Name = "stw_rowid"
        Me.stw_rowid.ReadOnly = True
        Me.stw_rowid.Visible = False
        '
        'stw_cono
        '
        Me.stw_cono.HeaderText = "Customer Order No."
        Me.stw_cono.Name = "stw_cono"
        Me.stw_cono.ReadOnly = True
        Me.stw_cono.Width = 90
        '
        'stw_pono
        '
        Me.stw_pono.HeaderText = "P.O. No."
        Me.stw_pono.Name = "stw_pono"
        Me.stw_pono.ReadOnly = True
        Me.stw_pono.Width = 80
        '
        'stw_codate
        '
        Me.stw_codate.HeaderText = "Customer Order Date"
        Me.stw_codate.Name = "stw_codate"
        Me.stw_codate.ReadOnly = True
        '
        'stw_receiptdate
        '
        Me.stw_receiptdate.HeaderText = "Receipt Date"
        Me.stw_receiptdate.Name = "stw_receiptdate"
        Me.stw_receiptdate.ReadOnly = True
        '
        'stw_canceldate
        '
        Me.stw_canceldate.HeaderText = "Cancel Date"
        Me.stw_canceldate.Name = "stw_canceldate"
        Me.stw_canceldate.ReadOnly = True
        '
        'stw_datesubmitted
        '
        Me.stw_datesubmitted.HeaderText = "Date Submitted"
        Me.stw_datesubmitted.Name = "stw_datesubmitted"
        Me.stw_datesubmitted.ReadOnly = True
        '
        'stw_customername
        '
        Me.stw_customername.HeaderText = "Customer Name"
        Me.stw_customername.Name = "stw_customername"
        Me.stw_customername.ReadOnly = True
        '
        'stw_createdby
        '
        Me.stw_createdby.HeaderText = "Created By"
        Me.stw_createdby.Name = "stw_createdby"
        Me.stw_createdby.ReadOnly = True
        '
        'ToolStrip3
        '
        Me.ToolStrip3.AutoSize = False
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdFirst, Me.cmdPrev, Me.cmdNext, Me.cmdLast, Me.tsRefresh})
        Me.ToolStrip3.Location = New System.Drawing.Point(-29, 174)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(334, 24)
        Me.ToolStrip3.TabIndex = 20
        Me.ToolStrip3.Text = "toolbar1"
        '
        'cmdFirst
        '
        Me.cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFirst.Image = CType(resources.GetObject("cmdFirst.Image"), System.Drawing.Image)
        Me.cmdFirst.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(24, 21)
        '
        'cmdPrev
        '
        Me.cmdPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrev.Image = CType(resources.GetObject("cmdPrev.Image"), System.Drawing.Image)
        Me.cmdPrev.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.Size = New System.Drawing.Size(24, 21)
        '
        'cmdNext
        '
        Me.cmdNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
        Me.cmdNext.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(24, 21)
        '
        'cmdLast
        '
        Me.cmdLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLast.Image = CType(resources.GetObject("cmdLast.Image"), System.Drawing.Image)
        Me.cmdLast.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(24, 21)
        '
        'tsRefresh
        '
        Me.tsRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsRefresh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tsRefresh.Image = CType(resources.GetObject("tsRefresh.Image"), System.Drawing.Image)
        Me.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefresh.Name = "tsRefresh"
        Me.tsRefresh.Size = New System.Drawing.Size(75, 21)
        Me.tsRefresh.Text = "&Refresh"
        '
        'gbBrandName
        '
        Me.gbBrandName.Controls.Add(Me.cboBrandName)
        Me.gbBrandName.Controls.Add(Me.Label5)
        Me.gbBrandName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBrandName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbBrandName.Location = New System.Drawing.Point(682, 209)
        Me.gbBrandName.Name = "gbBrandName"
        Me.gbBrandName.Size = New System.Drawing.Size(305, 55)
        Me.gbBrandName.TabIndex = 21
        Me.gbBrandName.TabStop = False
        '
        'cboBrandName
        '
        Me.cboBrandName.FormattingEnabled = True
        Me.cboBrandName.Location = New System.Drawing.Point(89, 19)
        Me.cboBrandName.Name = "cboBrandName"
        Me.cboBrandName.Size = New System.Drawing.Size(195, 21)
        Me.cboBrandName.TabIndex = 428
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(6, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 429
        Me.Label5.Text = "Brand Name:"
        '
        'gbReceivingInformation
        '
        Me.gbReceivingInformation.Controls.Add(Me.Label55)
        Me.gbReceivingInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReceivingInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbReceivingInformation.Location = New System.Drawing.Point(501, 303)
        Me.gbReceivingInformation.Name = "gbReceivingInformation"
        Me.gbReceivingInformation.Size = New System.Drawing.Size(128, 57)
        Me.gbReceivingInformation.TabIndex = 22
        Me.gbReceivingInformation.TabStop = False
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, -1)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(76, 17)
        Me.Label55.TabIndex = 228
        Me.Label55.Text = "R.R. Type:"
        '
        'gbContactInformation
        '
        Me.gbContactInformation.Controls.Add(Me.Label20)
        Me.gbContactInformation.Controls.Add(Me.lblsavemsg)
        Me.gbContactInformation.Controls.Add(Me.cboStatus)
        Me.gbContactInformation.Controls.Add(Me.Label6)
        Me.gbContactInformation.Controls.Add(Me.msMenu)
        Me.gbContactInformation.Controls.Add(Me.Label2)
        Me.gbContactInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbContactInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbContactInformation.Location = New System.Drawing.Point(80, 303)
        Me.gbContactInformation.Name = "gbContactInformation"
        Me.gbContactInformation.Size = New System.Drawing.Size(357, 190)
        Me.gbContactInformation.TabIndex = 250
        Me.gbContactInformation.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(84, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(16, 20)
        Me.Label20.TabIndex = 592
        Me.Label20.Text = "*"
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(84, 21)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 589
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(101, 74)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(113, 23)
        Me.cboStatus.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(41, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 15)
        Me.Label6.TabIndex = 588
        Me.Label6.Text = "Status:"
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(3, 16)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(72, 25)
        Me.msMenu.TabIndex = 17
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Snow
        Me.Label2.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(9, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 17)
        Me.Label2.TabIndex = 228
        Me.Label2.Text = "Contact Information:"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(333, 149)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 251
        '
        'DummyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1211, 524)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.gbContactInformation)
        Me.Controls.Add(Me.gbReceivingInformation)
        Me.Controls.Add(Me.gbBrandName)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.dgSubmittedToWarehouseCO)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.bccTestImage)
        Me.Name = "DummyForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DummyForm"
        CType(Me.dgSubmittedToWarehouseCO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.gbBrandName.ResumeLayout(False)
        Me.gbBrandName.PerformLayout()
        Me.gbReceivingInformation.ResumeLayout(False)
        Me.gbReceivingInformation.PerformLayout()
        Me.gbContactInformation.ResumeLayout(False)
        Me.gbContactInformation.PerformLayout()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bccTestImage As Spire.Barcode.Forms.BarCodeControl
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents dgSubmittedToWarehouseCO As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents stw_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stw_cono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stw_pono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stw_codate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stw_receiptdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stw_canceldate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stw_datesubmitted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stw_customername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stw_createdby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbBrandName As System.Windows.Forms.GroupBox
    Friend WithEvents cboBrandName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbReceivingInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents gbContactInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
