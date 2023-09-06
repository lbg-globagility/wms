<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceivingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReceivingForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.gbReceivingItems = New System.Windows.Forms.GroupBox()
        Me.btnAddAdditionalItems = New System.Windows.Forms.Button()
        Me.txtTotalQtyReceivedBad = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnStockToWarehouse = New System.Windows.Forms.Button()
        Me.txtTotalQtyStocked = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkOtherInfo = New System.Windows.Forms.CheckBox()
        Me.txtTotalQtyReceivedGood = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgReceivingItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ci_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_pcsrowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_bid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_app = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyordered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyreceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtybad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtystocked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_approved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_itemtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbReceivingInformation = New System.Windows.Forms.GroupBox()
        Me.dtpTimeArrived = New System.Windows.Forms.DateTimePicker()
        Me.txtBrands = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtSealNo = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtContainerNo = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtArrivedIn = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.pbAddSupplierCustomer = New System.Windows.Forms.PictureBox()
        Me.pbAddReceivedBy = New System.Windows.Forms.PictureBox()
        Me.txtRRType = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboReceivedBy = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReferenceNo = New System.Windows.Forms.TextBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblReferenceNo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.dtpRRDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAccountName = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRRNo = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.dtpToSearch = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromSearch = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboSearch4 = New System.Windows.Forms.ComboBox()
        Me.cboSearch2 = New System.Windows.Forms.ComboBox()
        Me.cboSearch3 = New System.Windows.Forms.ComboBox()
        Me.cboSearch1 = New System.Windows.Forms.ComboBox()
        Me.txtSimpleSearch = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tabSimple = New System.Windows.Forms.TabPage()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbReceivingList = New System.Windows.Forms.GroupBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.txtPageNo = New System.Windows.Forms.TextBox()
        Me.dgReceivingList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.rr_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rr_relatedorderid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rr_receivingorderno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rr_receivingorderdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rr_suppliername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rr_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rr_rrtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.tabCommon = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.msPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.msOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmsOptionsB = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsPicker = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPacker = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsOptionsA = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.msCustomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSupplier = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabDetails.SuspendLayout()
        Me.gbReceivingItems.SuspendLayout()
        CType(Me.dgReceivingItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReceivingInformation.SuspendLayout()
        CType(Me.pbAddSupplierCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddReceivedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMain.SuspendLayout()
        Me.tabSimple.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbReceivingList.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.dgReceivingList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearch.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabCommon.SuspendLayout()
        Me.msMenu.SuspendLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsOptionsB.SuspendLayout()
        Me.cmsOptionsA.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDetails
        '
        Me.tabDetails.AutoScroll = True
        Me.tabDetails.Controls.Add(Me.gbReceivingItems)
        Me.tabDetails.Controls.Add(Me.gbReceivingInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(829, 472)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Receiving Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbReceivingItems
        '
        Me.gbReceivingItems.Controls.Add(Me.btnAddAdditionalItems)
        Me.gbReceivingItems.Controls.Add(Me.txtTotalQtyReceivedBad)
        Me.gbReceivingItems.Controls.Add(Me.Label10)
        Me.gbReceivingItems.Controls.Add(Me.btnStockToWarehouse)
        Me.gbReceivingItems.Controls.Add(Me.txtTotalQtyStocked)
        Me.gbReceivingItems.Controls.Add(Me.Label7)
        Me.gbReceivingItems.Controls.Add(Me.chkOtherInfo)
        Me.gbReceivingItems.Controls.Add(Me.txtTotalQtyReceivedGood)
        Me.gbReceivingItems.Controls.Add(Me.Label8)
        Me.gbReceivingItems.Controls.Add(Me.dgReceivingItems)
        Me.gbReceivingItems.Controls.Add(Me.Label15)
        Me.gbReceivingItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReceivingItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbReceivingItems.Location = New System.Drawing.Point(6, 155)
        Me.gbReceivingItems.Name = "gbReceivingItems"
        Me.gbReceivingItems.Size = New System.Drawing.Size(800, 410)
        Me.gbReceivingItems.TabIndex = 4
        Me.gbReceivingItems.TabStop = False
        '
        'btnAddAdditionalItems
        '
        Me.btnAddAdditionalItems.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddAdditionalItems.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddAdditionalItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddAdditionalItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddAdditionalItems.Image = CType(resources.GetObject("btnAddAdditionalItems.Image"), System.Drawing.Image)
        Me.btnAddAdditionalItems.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnAddAdditionalItems.Location = New System.Drawing.Point(647, 79)
        Me.btnAddAdditionalItems.Name = "btnAddAdditionalItems"
        Me.btnAddAdditionalItems.Size = New System.Drawing.Size(145, 116)
        Me.btnAddAdditionalItems.TabIndex = 31
        Me.btnAddAdditionalItems.Text = "Add Additional Item/s"
        Me.btnAddAdditionalItems.UseVisualStyleBackColor = False
        '
        'txtTotalQtyReceivedBad
        '
        Me.txtTotalQtyReceivedBad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyReceivedBad.Location = New System.Drawing.Point(440, 377)
        Me.txtTotalQtyReceivedBad.Name = "txtTotalQtyReceivedBad"
        Me.txtTotalQtyReceivedBad.ReadOnly = True
        Me.txtTotalQtyReceivedBad.Size = New System.Drawing.Size(95, 21)
        Me.txtTotalQtyReceivedBad.TabIndex = 35
        Me.txtTotalQtyReceivedBad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(341, 375)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 26)
        Me.Label10.TabIndex = 473
        Me.Label10.Text = "Total Received" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Qty. (Bad):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnStockToWarehouse
        '
        Me.btnStockToWarehouse.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnStockToWarehouse.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnStockToWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStockToWarehouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockToWarehouse.Image = CType(resources.GetObject("btnStockToWarehouse.Image"), System.Drawing.Image)
        Me.btnStockToWarehouse.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnStockToWarehouse.Location = New System.Drawing.Point(647, 218)
        Me.btnStockToWarehouse.Name = "btnStockToWarehouse"
        Me.btnStockToWarehouse.Size = New System.Drawing.Size(145, 116)
        Me.btnStockToWarehouse.TabIndex = 32
        Me.btnStockToWarehouse.Text = "Stock To Warehouse"
        Me.btnStockToWarehouse.UseVisualStyleBackColor = False
        '
        'txtTotalQtyStocked
        '
        Me.txtTotalQtyStocked.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyStocked.Location = New System.Drawing.Point(613, 377)
        Me.txtTotalQtyStocked.Name = "txtTotalQtyStocked"
        Me.txtTotalQtyStocked.ReadOnly = True
        Me.txtTotalQtyStocked.Size = New System.Drawing.Size(95, 21)
        Me.txtTotalQtyStocked.TabIndex = 36
        Me.txtTotalQtyStocked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(546, 375)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 26)
        Me.Label7.TabIndex = 470
        Me.Label7.Text = "Total Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Stocked:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkOtherInfo
        '
        Me.chkOtherInfo.AutoSize = True
        Me.chkOtherInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOtherInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOtherInfo.Location = New System.Drawing.Point(6, 379)
        Me.chkOtherInfo.Name = "chkOtherInfo"
        Me.chkOtherInfo.Size = New System.Drawing.Size(114, 19)
        Me.chkOtherInfo.TabIndex = 33
        Me.chkOtherInfo.Text = "View Other Info.:"
        Me.chkOtherInfo.UseVisualStyleBackColor = True
        '
        'txtTotalQtyReceivedGood
        '
        Me.txtTotalQtyReceivedGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyReceivedGood.Location = New System.Drawing.Point(238, 377)
        Me.txtTotalQtyReceivedGood.Name = "txtTotalQtyReceivedGood"
        Me.txtTotalQtyReceivedGood.ReadOnly = True
        Me.txtTotalQtyReceivedGood.Size = New System.Drawing.Size(95, 21)
        Me.txtTotalQtyReceivedGood.TabIndex = 34
        Me.txtTotalQtyReceivedGood.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(137, 375)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 26)
        Me.Label8.TabIndex = 463
        Me.Label8.Text = "Total Received " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Qty. (Good):"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgReceivingItems
        '
        Me.dgReceivingItems.AllowUserToAddRows = False
        Me.dgReceivingItems.AllowUserToDeleteRows = False
        Me.dgReceivingItems.AllowUserToOrderColumns = True
        Me.dgReceivingItems.AllowUserToResizeRows = False
        Me.dgReceivingItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReceivingItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgReceivingItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReceivingItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ci_rowid, Me.ci_pcsrowid, Me.ci_bid, Me.ci_colorvalue, Me.ci_app, Me.ci_seqno, Me.ci_productcode, Me.ci_colorname, Me.ci_color, Me.ci_size, Me.ci_seasoncode, Me.ci_sku, Me.ci_unitofmeasure, Me.ci_qtyordered, Me.ci_qtyreceived, Me.ci_qtybad, Me.ci_qtystocked, Me.ci_approved, Me.ci_remarks, Me.ci_reason, Me.ci_itemtype, Me.ci_option})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgReceivingItems.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgReceivingItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgReceivingItems.Location = New System.Drawing.Point(8, 20)
        Me.dgReceivingItems.MultiSelect = False
        Me.dgReceivingItems.Name = "dgReceivingItems"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReceivingItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgReceivingItems.RowHeadersVisible = False
        Me.dgReceivingItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgReceivingItems.Size = New System.Drawing.Size(630, 350)
        Me.dgReceivingItems.TabIndex = 30
        '
        'ci_rowid
        '
        Me.ci_rowid.HeaderText = "rowid"
        Me.ci_rowid.Name = "ci_rowid"
        Me.ci_rowid.Visible = False
        '
        'ci_pcsrowid
        '
        Me.ci_pcsrowid.HeaderText = "pcsrowid"
        Me.ci_pcsrowid.Name = "ci_pcsrowid"
        Me.ci_pcsrowid.Visible = False
        '
        'ci_bid
        '
        Me.ci_bid.HeaderText = "bid"
        Me.ci_bid.Name = "ci_bid"
        Me.ci_bid.Visible = False
        '
        'ci_colorvalue
        '
        Me.ci_colorvalue.HeaderText = "colorvalue"
        Me.ci_colorvalue.Name = "ci_colorvalue"
        Me.ci_colorvalue.Visible = False
        '
        'ci_app
        '
        Me.ci_app.HeaderText = "app"
        Me.ci_app.Name = "ci_app"
        Me.ci_app.Visible = False
        '
        'ci_seqno
        '
        Me.ci_seqno.HeaderText = "Seq. No."
        Me.ci_seqno.Name = "ci_seqno"
        Me.ci_seqno.ReadOnly = True
        Me.ci_seqno.Width = 40
        '
        'ci_productcode
        '
        Me.ci_productcode.HeaderText = "Product Code"
        Me.ci_productcode.Name = "ci_productcode"
        Me.ci_productcode.ReadOnly = True
        Me.ci_productcode.Width = 120
        '
        'ci_colorname
        '
        Me.ci_colorname.HeaderText = "Color Name"
        Me.ci_colorname.Name = "ci_colorname"
        Me.ci_colorname.ReadOnly = True
        Me.ci_colorname.Width = 60
        '
        'ci_color
        '
        Me.ci_color.HeaderText = ""
        Me.ci_color.Name = "ci_color"
        Me.ci_color.ReadOnly = True
        Me.ci_color.Width = 30
        '
        'ci_size
        '
        Me.ci_size.HeaderText = "Size"
        Me.ci_size.Name = "ci_size"
        Me.ci_size.ReadOnly = True
        Me.ci_size.Width = 40
        '
        'ci_seasoncode
        '
        Me.ci_seasoncode.HeaderText = "Season Code"
        Me.ci_seasoncode.Name = "ci_seasoncode"
        Me.ci_seasoncode.ReadOnly = True
        Me.ci_seasoncode.Width = 70
        '
        'ci_sku
        '
        Me.ci_sku.HeaderText = "SKU"
        Me.ci_sku.Name = "ci_sku"
        Me.ci_sku.ReadOnly = True
        '
        'ci_unitofmeasure
        '
        Me.ci_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.ci_unitofmeasure.Name = "ci_unitofmeasure"
        Me.ci_unitofmeasure.Width = 70
        '
        'ci_qtyordered
        '
        Me.ci_qtyordered.HeaderText = "Qty. To Receive"
        Me.ci_qtyordered.Name = "ci_qtyordered"
        Me.ci_qtyordered.ReadOnly = True
        Me.ci_qtyordered.Width = 60
        '
        'ci_qtyreceived
        '
        Me.ci_qtyreceived.HeaderText = "Qty. Received (Good)"
        Me.ci_qtyreceived.Name = "ci_qtyreceived"
        Me.ci_qtyreceived.Width = 105
        '
        'ci_qtybad
        '
        Me.ci_qtybad.HeaderText = "Qty. Received (Bad)"
        Me.ci_qtybad.Name = "ci_qtybad"
        Me.ci_qtybad.Width = 105
        '
        'ci_qtystocked
        '
        Me.ci_qtystocked.HeaderText = "Qty. Stocked"
        Me.ci_qtystocked.Name = "ci_qtystocked"
        Me.ci_qtystocked.ReadOnly = True
        Me.ci_qtystocked.Width = 60
        '
        'ci_approved
        '
        Me.ci_approved.HeaderText = "Approve for Stocking"
        Me.ci_approved.Name = "ci_approved"
        '
        'ci_remarks
        '
        Me.ci_remarks.HeaderText = "Remarks"
        Me.ci_remarks.Name = "ci_remarks"
        '
        'ci_reason
        '
        Me.ci_reason.HeaderText = "Reason"
        Me.ci_reason.Name = "ci_reason"
        '
        'ci_itemtype
        '
        Me.ci_itemtype.HeaderText = "Type"
        Me.ci_itemtype.Name = "ci_itemtype"
        Me.ci_itemtype.ReadOnly = True
        Me.ci_itemtype.Width = 40
        '
        'ci_option
        '
        Me.ci_option.HeaderText = ""
        Me.ci_option.Name = "ci_option"
        Me.ci_option.Text = "Delete"
        Me.ci_option.UseColumnTextForButtonValue = True
        Me.ci_option.Visible = False
        Me.ci_option.Width = 50
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, -3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 17)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Receiving Items:"
        '
        'gbReceivingInformation
        '
        Me.gbReceivingInformation.Controls.Add(Me.dtpTimeArrived)
        Me.gbReceivingInformation.Controls.Add(Me.txtBrands)
        Me.gbReceivingInformation.Controls.Add(Me.Label22)
        Me.gbReceivingInformation.Controls.Add(Me.Label19)
        Me.gbReceivingInformation.Controls.Add(Me.txtSealNo)
        Me.gbReceivingInformation.Controls.Add(Me.Label26)
        Me.gbReceivingInformation.Controls.Add(Me.txtContainerNo)
        Me.gbReceivingInformation.Controls.Add(Me.Label24)
        Me.gbReceivingInformation.Controls.Add(Me.txtArrivedIn)
        Me.gbReceivingInformation.Controls.Add(Me.Label20)
        Me.gbReceivingInformation.Controls.Add(Me.pbAddSupplierCustomer)
        Me.gbReceivingInformation.Controls.Add(Me.pbAddReceivedBy)
        Me.gbReceivingInformation.Controls.Add(Me.txtRRType)
        Me.gbReceivingInformation.Controls.Add(Me.Label3)
        Me.gbReceivingInformation.Controls.Add(Me.cboReceivedBy)
        Me.gbReceivingInformation.Controls.Add(Me.Label1)
        Me.gbReceivingInformation.Controls.Add(Me.txtReferenceNo)
        Me.gbReceivingInformation.Controls.Add(Me.txtComments)
        Me.gbReceivingInformation.Controls.Add(Me.Label25)
        Me.gbReceivingInformation.Controls.Add(Me.lblReferenceNo)
        Me.gbReceivingInformation.Controls.Add(Me.Label9)
        Me.gbReceivingInformation.Controls.Add(Me.txtStatus)
        Me.gbReceivingInformation.Controls.Add(Me.dtpRRDate)
        Me.gbReceivingInformation.Controls.Add(Me.Label2)
        Me.gbReceivingInformation.Controls.Add(Me.cboAccountName)
        Me.gbReceivingInformation.Controls.Add(Me.Label14)
        Me.gbReceivingInformation.Controls.Add(Me.Label12)
        Me.gbReceivingInformation.Controls.Add(Me.Label6)
        Me.gbReceivingInformation.Controls.Add(Me.txtRRNo)
        Me.gbReceivingInformation.Controls.Add(Me.Label52)
        Me.gbReceivingInformation.Controls.Add(Me.Label55)
        Me.gbReceivingInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReceivingInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbReceivingInformation.Location = New System.Drawing.Point(6, 5)
        Me.gbReceivingInformation.Name = "gbReceivingInformation"
        Me.gbReceivingInformation.Size = New System.Drawing.Size(800, 145)
        Me.gbReceivingInformation.TabIndex = 3
        Me.gbReceivingInformation.TabStop = False
        '
        'dtpTimeArrived
        '
        Me.dtpTimeArrived.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTimeArrived.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTimeArrived.Location = New System.Drawing.Point(95, 81)
        Me.dtpTimeArrived.Name = "dtpTimeArrived"
        Me.dtpTimeArrived.ShowUpDown = True
        Me.dtpTimeArrived.Size = New System.Drawing.Size(95, 21)
        Me.dtpTimeArrived.TabIndex = 19
        '
        'txtBrands
        '
        Me.txtBrands.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrands.Location = New System.Drawing.Point(580, 52)
        Me.txtBrands.Name = "txtBrands"
        Me.txtBrands.Size = New System.Drawing.Size(210, 21)
        Me.txtBrands.TabIndex = 24
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(520, 55)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(57, 15)
        Me.Label22.TabIndex = 459
        Me.Label22.Text = "Brand(s):"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(5, 82)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 15)
        Me.Label19.TabIndex = 457
        Me.Label19.Text = "Time Arrived:"
        '
        'txtSealNo
        '
        Me.txtSealNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSealNo.Location = New System.Drawing.Point(460, 108)
        Me.txtSealNo.Name = "txtSealNo"
        Me.txtSealNo.Size = New System.Drawing.Size(150, 21)
        Me.txtSealNo.TabIndex = 28
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(398, 110)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 15)
        Me.Label26.TabIndex = 453
        Me.Label26.Text = "Seal No.:"
        '
        'txtContainerNo
        '
        Me.txtContainerNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContainerNo.Location = New System.Drawing.Point(460, 81)
        Me.txtContainerNo.Name = "txtContainerNo"
        Me.txtContainerNo.Size = New System.Drawing.Size(150, 21)
        Me.txtContainerNo.TabIndex = 27
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(370, 82)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(85, 15)
        Me.Label24.TabIndex = 451
        Me.Label24.Text = "Container No.:"
        '
        'txtArrivedIn
        '
        Me.txtArrivedIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArrivedIn.Location = New System.Drawing.Point(275, 81)
        Me.txtArrivedIn.Name = "txtArrivedIn"
        Me.txtArrivedIn.Size = New System.Drawing.Size(85, 21)
        Me.txtArrivedIn.TabIndex = 25
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(210, 82)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 15)
        Me.Label20.TabIndex = 449
        Me.Label20.Text = "Arrived In:"
        '
        'pbAddSupplierCustomer
        '
        Me.pbAddSupplierCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbAddSupplierCustomer.BackColor = System.Drawing.Color.Transparent
        Me.pbAddSupplierCustomer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddSupplierCustomer.Image = CType(resources.GetObject("pbAddSupplierCustomer.Image"), System.Drawing.Image)
        Me.pbAddSupplierCustomer.Location = New System.Drawing.Point(612, 25)
        Me.pbAddSupplierCustomer.Name = "pbAddSupplierCustomer"
        Me.pbAddSupplierCustomer.Size = New System.Drawing.Size(14, 18)
        Me.pbAddSupplierCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddSupplierCustomer.TabIndex = 443
        Me.pbAddSupplierCustomer.TabStop = False
        Me.pbAddSupplierCustomer.Tag = ""
        '
        'pbAddReceivedBy
        '
        Me.pbAddReceivedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbAddReceivedBy.BackColor = System.Drawing.Color.Transparent
        Me.pbAddReceivedBy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddReceivedBy.Image = CType(resources.GetObject("pbAddReceivedBy.Image"), System.Drawing.Image)
        Me.pbAddReceivedBy.Location = New System.Drawing.Point(475, 54)
        Me.pbAddReceivedBy.Name = "pbAddReceivedBy"
        Me.pbAddReceivedBy.Size = New System.Drawing.Size(14, 18)
        Me.pbAddReceivedBy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddReceivedBy.TabIndex = 442
        Me.pbAddReceivedBy.TabStop = False
        Me.pbAddReceivedBy.Tag = ""
        '
        'txtRRType
        '
        Me.txtRRType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRRType.Location = New System.Drawing.Point(80, 108)
        Me.txtRRType.Name = "txtRRType"
        Me.txtRRType.ReadOnly = True
        Me.txtRRType.Size = New System.Drawing.Size(110, 21)
        Me.txtRRType.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 441
        Me.Label3.Text = "R.R. Type:"
        '
        'cboReceivedBy
        '
        Me.cboReceivedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReceivedBy.FormattingEnabled = True
        Me.cboReceivedBy.Location = New System.Drawing.Point(290, 52)
        Me.cboReceivedBy.Name = "cboReceivedBy"
        Me.cboReceivedBy.Size = New System.Drawing.Size(180, 23)
        Me.cboReceivedBy.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(210, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 15)
        Me.Label1.TabIndex = 437
        Me.Label1.Text = "Received By:"
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferenceNo.Location = New System.Drawing.Point(310, 108)
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.ReadOnly = True
        Me.txtReferenceNo.Size = New System.Drawing.Size(80, 21)
        Me.txtReferenceNo.TabIndex = 20
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(620, 95)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(170, 40)
        Me.txtComments.TabIndex = 29
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(674, 75)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 15)
        Me.Label25.TabIndex = 434
        Me.Label25.Text = "Comments:"
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.AutoSize = True
        Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReferenceNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblReferenceNo.Location = New System.Drawing.Point(210, 110)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(100, 15)
        Me.lblReferenceNo.TabIndex = 431
        Me.lblReferenceNo.Text = "Related Ref. No.:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(360, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 20)
        Me.Label9.TabIndex = 425
        Me.Label9.Text = "*"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(695, 23)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(95, 21)
        Me.txtStatus.TabIndex = 22
        '
        'dtpRRDate
        '
        Me.dtpRRDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpRRDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpRRDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRRDate.Location = New System.Drawing.Point(80, 52)
        Me.dtpRRDate.Name = "dtpRRDate"
        Me.dtpRRDate.Size = New System.Drawing.Size(110, 21)
        Me.dtpRRDate.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(5, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 422
        Me.Label2.Text = "R. R. Date:"
        '
        'cboAccountName
        '
        Me.cboAccountName.Enabled = False
        Me.cboAccountName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAccountName.FormattingEnabled = True
        Me.cboAccountName.Location = New System.Drawing.Point(380, 23)
        Me.cboAccountName.Name = "cboAccountName"
        Me.cboAccountName.Size = New System.Drawing.Size(230, 23)
        Me.cboAccountName.TabIndex = 21
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(210, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(155, 15)
        Me.Label14.TabIndex = 420
        Me.Label14.Text = "Supplier / Customer Name:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(645, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 414
        Me.Label12.Text = "Status:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(60, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "*"
        '
        'txtRRNo
        '
        Me.txtRRNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRRNo.Location = New System.Drawing.Point(80, 23)
        Me.txtRRNo.Name = "txtRRNo"
        Me.txtRRNo.Size = New System.Drawing.Size(110, 21)
        Me.txtRRNo.TabIndex = 17
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(5, 26)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(59, 15)
        Me.Label52.TabIndex = 272
        Me.Label52.Text = "R. R. No.:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, -1)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(167, 17)
        Me.Label55.TabIndex = 228
        Me.Label55.Text = "Receiving Information:"
        '
        'tabMain
        '
        Me.tabMain.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabMain.Controls.Add(Me.tabDetails)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabMain.ItemSize = New System.Drawing.Size(61, 23)
        Me.tabMain.Location = New System.Drawing.Point(0, 25)
        Me.tabMain.Multiline = True
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(837, 503)
        Me.tabMain.TabIndex = 223
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(231, 5)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(24, 15)
        Me.Label40.TabIndex = 255
        Me.Label40.Text = "To:"
        '
        'dtpToSearch
        '
        Me.dtpToSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpToSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpToSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToSearch.Location = New System.Drawing.Point(190, 24)
        Me.dtpToSearch.Name = "dtpToSearch"
        Me.dtpToSearch.Size = New System.Drawing.Size(110, 21)
        Me.dtpToSearch.TabIndex = 8
        '
        'dtpFromSearch
        '
        Me.dtpFromSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpFromSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromSearch.Location = New System.Drawing.Point(76, 24)
        Me.dtpFromSearch.Name = "dtpFromSearch"
        Me.dtpFromSearch.Size = New System.Drawing.Size(110, 21)
        Me.dtpFromSearch.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(107, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 15)
        Me.Label18.TabIndex = 254
        Me.Label18.Text = "From:"
        '
        'cboSearch4
        '
        Me.cboSearch4.FormattingEnabled = True
        Me.cboSearch4.Location = New System.Drawing.Point(112, 80)
        Me.cboSearch4.Name = "cboSearch4"
        Me.cboSearch4.Size = New System.Drawing.Size(198, 23)
        Me.cboSearch4.TabIndex = 12
        '
        'cboSearch2
        '
        Me.cboSearch2.FormattingEnabled = True
        Me.cboSearch2.Location = New System.Drawing.Point(112, 51)
        Me.cboSearch2.Name = "cboSearch2"
        Me.cboSearch2.Size = New System.Drawing.Size(198, 23)
        Me.cboSearch2.TabIndex = 10
        '
        'cboSearch3
        '
        Me.cboSearch3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch3.FormattingEnabled = True
        Me.cboSearch3.Location = New System.Drawing.Point(3, 80)
        Me.cboSearch3.Name = "cboSearch3"
        Me.cboSearch3.Size = New System.Drawing.Size(105, 23)
        Me.cboSearch3.TabIndex = 11
        '
        'cboSearch1
        '
        Me.cboSearch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch1.FormattingEnabled = True
        Me.cboSearch1.Location = New System.Drawing.Point(3, 52)
        Me.cboSearch1.Name = "cboSearch1"
        Me.cboSearch1.Size = New System.Drawing.Size(105, 23)
        Me.cboSearch1.TabIndex = 9
        '
        'txtSimpleSearch
        '
        Me.txtSimpleSearch.Location = New System.Drawing.Point(95, 42)
        Me.txtSimpleSearch.Name = "txtSimpleSearch"
        Me.txtSimpleSearch.Size = New System.Drawing.Size(210, 21)
        Me.txtSimpleSearch.TabIndex = 6
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(2, 45)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(91, 15)
        Me.Label30.TabIndex = 4
        Me.Label30.Text = "Search Phrase:"
        '
        'tabSimple
        '
        Me.tabSimple.Controls.Add(Me.txtSimpleSearch)
        Me.tabSimple.Controls.Add(Me.Label30)
        Me.tabSimple.Location = New System.Drawing.Point(4, 29)
        Me.tabSimple.Name = "tabSimple"
        Me.tabSimple.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSimple.Size = New System.Drawing.Size(316, 112)
        Me.tabSimple.TabIndex = 1
        Me.tabSimple.Text = "       Simple       "
        Me.tabSimple.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Thistle
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Receiving List:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Thistle
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbReceivingList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSearch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenu)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblsavemsg)
        Me.SplitContainer1.Size = New System.Drawing.Size(1200, 532)
        Me.SplitContainer1.SplitterDistance = 355
        Me.SplitContainer1.TabIndex = 242
        '
        'gbReceivingList
        '
        Me.gbReceivingList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbReceivingList.BackColor = System.Drawing.Color.Transparent
        Me.gbReceivingList.Controls.Add(Me.ToolStrip3)
        Me.gbReceivingList.Controls.Add(Me.Label4)
        Me.gbReceivingList.Controls.Add(Me.txtPage)
        Me.gbReceivingList.Controls.Add(Me.txtPageNo)
        Me.gbReceivingList.Controls.Add(Me.dgReceivingList)
        Me.gbReceivingList.Controls.Add(Me.Label16)
        Me.gbReceivingList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReceivingList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbReceivingList.Location = New System.Drawing.Point(6, 181)
        Me.gbReceivingList.Name = "gbReceivingList"
        Me.gbReceivingList.Size = New System.Drawing.Size(340, 340)
        Me.gbReceivingList.TabIndex = 2
        Me.gbReceivingList.TabStop = False
        '
        'ToolStrip3
        '
        Me.ToolStrip3.AutoSize = False
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdFirst, Me.cmdPrev, Me.cmdNext, Me.cmdLast, Me.tsRefresh})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(334, 24)
        Me.ToolStrip3.TabIndex = 13
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(50, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 15)
        Me.Label4.TabIndex = 297
        Me.Label4.Text = "Page No.:"
        '
        'txtPage
        '
        Me.txtPage.Location = New System.Drawing.Point(228, 43)
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Size = New System.Drawing.Size(41, 21)
        Me.txtPage.TabIndex = 15
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(121, 43)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.ReadOnly = True
        Me.txtPageNo.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNo.TabIndex = 14
        '
        'dgReceivingList
        '
        Me.dgReceivingList.AllowUserToAddRows = False
        Me.dgReceivingList.AllowUserToDeleteRows = False
        Me.dgReceivingList.AllowUserToOrderColumns = True
        Me.dgReceivingList.AllowUserToResizeRows = False
        Me.dgReceivingList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgReceivingList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReceivingList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgReceivingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReceivingList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rr_rowid, Me.rr_relatedorderid, Me.rr_receivingorderno, Me.rr_receivingorderdate, Me.rr_suppliername, Me.rr_status, Me.rr_rrtype})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgReceivingList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgReceivingList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgReceivingList.Location = New System.Drawing.Point(8, 68)
        Me.dgReceivingList.MultiSelect = False
        Me.dgReceivingList.Name = "dgReceivingList"
        Me.dgReceivingList.ReadOnly = True
        Me.dgReceivingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgReceivingList.Size = New System.Drawing.Size(324, 266)
        Me.dgReceivingList.TabIndex = 16
        '
        'rr_rowid
        '
        Me.rr_rowid.HeaderText = "rowid"
        Me.rr_rowid.Name = "rr_rowid"
        Me.rr_rowid.ReadOnly = True
        Me.rr_rowid.Visible = False
        '
        'rr_relatedorderid
        '
        Me.rr_relatedorderid.HeaderText = "relatedorderid"
        Me.rr_relatedorderid.Name = "rr_relatedorderid"
        Me.rr_relatedorderid.ReadOnly = True
        Me.rr_relatedorderid.Visible = False
        '
        'rr_receivingorderno
        '
        Me.rr_receivingorderno.HeaderText = "R.R. No."
        Me.rr_receivingorderno.Name = "rr_receivingorderno"
        Me.rr_receivingorderno.ReadOnly = True
        Me.rr_receivingorderno.Width = 80
        '
        'rr_receivingorderdate
        '
        Me.rr_receivingorderdate.HeaderText = "R.R. Date"
        Me.rr_receivingorderdate.Name = "rr_receivingorderdate"
        Me.rr_receivingorderdate.ReadOnly = True
        Me.rr_receivingorderdate.Width = 80
        '
        'rr_suppliername
        '
        Me.rr_suppliername.HeaderText = "Supplier/Customer Name"
        Me.rr_suppliername.Name = "rr_suppliername"
        Me.rr_suppliername.ReadOnly = True
        Me.rr_suppliername.Width = 120
        '
        'rr_status
        '
        Me.rr_status.HeaderText = "Status"
        Me.rr_status.Name = "rr_status"
        Me.rr_status.ReadOnly = True
        Me.rr_status.Width = 80
        '
        'rr_rrtype
        '
        Me.rr_rrtype.HeaderText = "R.R. Type"
        Me.rr_rrtype.Name = "rr_rrtype"
        Me.rr_rrtype.ReadOnly = True
        Me.rr_rrtype.Width = 80
        '
        'gbSearch
        '
        Me.gbSearch.BackColor = System.Drawing.Color.Transparent
        Me.gbSearch.Controls.Add(Me.Label21)
        Me.gbSearch.Controls.Add(Me.tabSearch)
        Me.gbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSearch.Location = New System.Drawing.Point(6, 5)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(340, 170)
        Me.gbSearch.TabIndex = 1
        Me.gbSearch.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Thistle
        Me.Label21.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label21.Location = New System.Drawing.Point(6, -2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 17)
        Me.Label21.TabIndex = 217
        Me.Label21.Text = "Search:"
        '
        'tabSearch
        '
        Me.tabSearch.Controls.Add(Me.tabSimple)
        Me.tabSearch.Controls.Add(Me.tabCommon)
        Me.tabSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSearch.ItemSize = New System.Drawing.Size(62, 25)
        Me.tabSearch.Location = New System.Drawing.Point(8, 16)
        Me.tabSearch.Multiline = True
        Me.tabSearch.Name = "tabSearch"
        Me.tabSearch.SelectedIndex = 0
        Me.tabSearch.Size = New System.Drawing.Size(324, 145)
        Me.tabSearch.TabIndex = 5
        '
        'tabCommon
        '
        Me.tabCommon.Controls.Add(Me.Label5)
        Me.tabCommon.Controls.Add(Me.Label40)
        Me.tabCommon.Controls.Add(Me.dtpToSearch)
        Me.tabCommon.Controls.Add(Me.dtpFromSearch)
        Me.tabCommon.Controls.Add(Me.Label18)
        Me.tabCommon.Controls.Add(Me.cboSearch4)
        Me.tabCommon.Controls.Add(Me.cboSearch2)
        Me.tabCommon.Controls.Add(Me.cboSearch3)
        Me.tabCommon.Controls.Add(Me.cboSearch1)
        Me.tabCommon.Location = New System.Drawing.Point(4, 29)
        Me.tabCommon.Name = "tabCommon"
        Me.tabCommon.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCommon.Size = New System.Drawing.Size(316, 112)
        Me.tabCommon.TabIndex = 0
        Me.tabCommon.Text = "       Common       "
        Me.tabCommon.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 442
        Me.Label5.Text = "R. R. Date:"
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNew, Me.msSave, Me.msCancel, Me.msPrint, Me.msOrder})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(837, 25)
        Me.msMenu.TabIndex = 19
        '
        'msNew
        '
        Me.msNew.Image = CType(resources.GetObject("msNew.Image"), System.Drawing.Image)
        Me.msNew.Name = "msNew"
        Me.msNew.Size = New System.Drawing.Size(63, 21)
        Me.msNew.Text = "&New"
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'msCancel
        '
        Me.msCancel.Image = CType(resources.GetObject("msCancel.Image"), System.Drawing.Image)
        Me.msCancel.Name = "msCancel"
        Me.msCancel.Size = New System.Drawing.Size(76, 21)
        Me.msCancel.Text = "&Cancel"
        '
        'msPrint
        '
        Me.msPrint.Image = CType(resources.GetObject("msPrint.Image"), System.Drawing.Image)
        Me.msPrint.Name = "msPrint"
        Me.msPrint.Size = New System.Drawing.Size(66, 21)
        Me.msPrint.Text = "&Print"
        '
        'msOrder
        '
        Me.msOrder.Image = CType(resources.GetObject("msOrder.Image"), System.Drawing.Image)
        Me.msOrder.Name = "msOrder"
        Me.msOrder.Size = New System.Drawing.Size(115, 21)
        Me.msOrder.Text = "Cancel &Order"
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(81, 5)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 193
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
        Me.lblTitle.TabIndex = 240
        Me.lblTitle.Text = "Receiving"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbClose
        '
        Me.pbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pbClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClose.Image = CType(resources.GetObject("pbClose.Image"), System.Drawing.Image)
        Me.pbClose.Location = New System.Drawing.Point(1169, 5)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(22, 19)
        Me.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbClose.TabIndex = 241
        Me.pbClose.TabStop = False
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'cmsOptionsB
        '
        Me.cmsOptionsB.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsPicker, Me.cmsPacker})
        Me.cmsOptionsB.Name = "cMenustrip"
        Me.cmsOptionsB.Size = New System.Drawing.Size(110, 48)
        '
        'cmsPicker
        '
        Me.cmsPicker.Image = CType(resources.GetObject("cmsPicker.Image"), System.Drawing.Image)
        Me.cmsPicker.Name = "cmsPicker"
        Me.cmsPicker.Size = New System.Drawing.Size(109, 22)
        Me.cmsPicker.Text = "Picker"
        '
        'cmsPacker
        '
        Me.cmsPacker.Image = CType(resources.GetObject("cmsPacker.Image"), System.Drawing.Image)
        Me.cmsPacker.Name = "cmsPacker"
        Me.cmsPacker.Size = New System.Drawing.Size(109, 22)
        Me.cmsPacker.Text = "Packer"
        '
        'cmsOptionsA
        '
        Me.cmsOptionsA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msCustomer, Me.msSupplier})
        Me.cmsOptionsA.Name = "cMenustrip"
        Me.cmsOptionsA.Size = New System.Drawing.Size(127, 48)
        '
        'msCustomer
        '
        Me.msCustomer.Image = CType(resources.GetObject("msCustomer.Image"), System.Drawing.Image)
        Me.msCustomer.Name = "msCustomer"
        Me.msCustomer.Size = New System.Drawing.Size(126, 22)
        Me.msCustomer.Text = "Customer"
        '
        'msSupplier
        '
        Me.msSupplier.Image = CType(resources.GetObject("msSupplier.Image"), System.Drawing.Image)
        Me.msSupplier.Name = "msSupplier"
        Me.msSupplier.Size = New System.Drawing.Size(126, 22)
        Me.msSupplier.Text = "Supplier"
        '
        'ReceivingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ReceivingForm"
        Me.tabDetails.ResumeLayout(False)
        Me.gbReceivingItems.ResumeLayout(False)
        Me.gbReceivingItems.PerformLayout()
        CType(Me.dgReceivingItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReceivingInformation.ResumeLayout(False)
        Me.gbReceivingInformation.PerformLayout()
        CType(Me.pbAddSupplierCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddReceivedBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMain.ResumeLayout(False)
        Me.tabSimple.ResumeLayout(False)
        Me.tabSimple.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbReceivingList.ResumeLayout(False)
        Me.gbReceivingList.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.dgReceivingList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.tabCommon.ResumeLayout(False)
        Me.tabCommon.PerformLayout()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsOptionsB.ResumeLayout(False)
        Me.cmsOptionsA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbReceivingItems As System.Windows.Forms.GroupBox
    Friend WithEvents chkOtherInfo As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotalQtyReceivedGood As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgReceivingItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gbReceivingInformation As System.Windows.Forms.GroupBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblReferenceNo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents dtpRRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAccountName As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRRNo As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents dtpToSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboSearch4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtSimpleSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tabSimple As System.Windows.Forms.TabPage
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbReceivingList As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents dgReceivingList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tabSearch As System.Windows.Forms.TabControl
    Friend WithEvents tabCommon As System.Windows.Forms.TabPage
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtReferenceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboReceivedBy As System.Windows.Forms.ComboBox
    Friend WithEvents txtRRType As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents msPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pbAddReceivedBy As System.Windows.Forms.PictureBox
    Friend WithEvents txtTotalQtyStocked As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents msCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnStockToWarehouse As System.Windows.Forms.Button
    Friend WithEvents cmsOptionsB As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsPicker As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPacker As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbAddSupplierCustomer As System.Windows.Forms.PictureBox
    Friend WithEvents cmsOptionsA As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents msCustomer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSupplier As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ci_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_pcsrowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_bid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_app As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyordered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyreceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtybad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtystocked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_approved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_reason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_itemtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_option As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents txtTotalQtyReceivedBad As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnAddAdditionalItems As System.Windows.Forms.Button
    Friend WithEvents txtSealNo As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtContainerNo As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtArrivedIn As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtBrands As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtpTimeArrived As System.Windows.Forms.DateTimePicker
    Friend WithEvents rr_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rr_relatedorderid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rr_receivingorderno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rr_receivingorderdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rr_suppliername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rr_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rr_rrtype As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
