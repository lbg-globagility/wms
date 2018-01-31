<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditBundleItemsBForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditBundleItemsBForm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtTotalQtyToPick = New System.Windows.Forms.TextBox()
        Me.txtTotalQtyOrdered = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgRackShelfColumn = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.txtQtyToPick = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.msSaveRSC = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgBundleItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.bi_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_pcsrowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtyordered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_totalqtytopick = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_verifiedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_verifieddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_shelf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtytopick = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtyorderable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_pickorderno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_issueflg = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.rsc_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgRackShelfColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgBundleItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(944, 28)
        Me.lblTitle.TabIndex = 397
        Me.lblTitle.Text = "View/Edit Bundle Items - Rack / Column / Shelf"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalQtyToPick
        '
        Me.txtTotalQtyToPick.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalQtyToPick.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyToPick.Location = New System.Drawing.Point(426, 354)
        Me.txtTotalQtyToPick.Name = "txtTotalQtyToPick"
        Me.txtTotalQtyToPick.ReadOnly = True
        Me.txtTotalQtyToPick.Size = New System.Drawing.Size(85, 21)
        Me.txtTotalQtyToPick.TabIndex = 5
        Me.txtTotalQtyToPick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalQtyOrdered
        '
        Me.txtTotalQtyOrdered.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalQtyOrdered.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyOrdered.Location = New System.Drawing.Point(246, 354)
        Me.txtTotalQtyOrdered.Name = "txtTotalQtyOrdered"
        Me.txtTotalQtyOrdered.ReadOnly = True
        Me.txtTotalQtyOrdered.Size = New System.Drawing.Size(85, 21)
        Me.txtTotalQtyOrdered.TabIndex = 4
        Me.txtTotalQtyOrdered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(332, 349)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 26)
        Me.Label11.TabIndex = 480
        Me.Label11.Text = "Total Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To Pick (Sum):"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(157, 350)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 26)
        Me.Label7.TabIndex = 478
        Me.Label7.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Qty. Ordered:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgRackShelfColumn
        '
        Me.dgRackShelfColumn.AllowUserToAddRows = False
        Me.dgRackShelfColumn.AllowUserToDeleteRows = False
        Me.dgRackShelfColumn.AllowUserToOrderColumns = True
        Me.dgRackShelfColumn.AllowUserToResizeRows = False
        Me.dgRackShelfColumn.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackShelfColumn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgRackShelfColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRackShelfColumn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rsc_rowid, Me.rsc_rack, Me.rsc_column, Me.rsc_shelf, Me.rsc_qtytopick, Me.rsc_qtyavailable, Me.rsc_qtyallocated, Me.rsc_qtyorderable, Me.rsc_pickorderno, Me.rsc_issueflg, Me.rsc_remarks})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRackShelfColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgRackShelfColumn.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgRackShelfColumn.Location = New System.Drawing.Point(630, 56)
        Me.dgRackShelfColumn.MultiSelect = False
        Me.dgRackShelfColumn.Name = "dgRackShelfColumn"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackShelfColumn.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgRackShelfColumn.RowHeadersVisible = False
        Me.dgRackShelfColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRackShelfColumn.Size = New System.Drawing.Size(300, 290)
        Me.dgRackShelfColumn.TabIndex = 3
        '
        'txtQtyToPick
        '
        Me.txtQtyToPick.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtQtyToPick.BackColor = System.Drawing.SystemColors.Control
        Me.txtQtyToPick.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyToPick.Location = New System.Drawing.Point(806, 354)
        Me.txtQtyToPick.Name = "txtQtyToPick"
        Me.txtQtyToPick.ReadOnly = True
        Me.txtQtyToPick.Size = New System.Drawing.Size(69, 21)
        Me.txtQtyToPick.TabIndex = 6
        Me.txtQtyToPick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(681, 357)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 15)
        Me.Label8.TabIndex = 479
        Me.Label8.Text = "Total Qty. To Pick:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSaveRSC})
        Me.MenuStrip1.Location = New System.Drawing.Point(619, 29)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(211, 25)
        Me.MenuStrip1.TabIndex = 2
        '
        'msSaveRSC
        '
        Me.msSaveRSC.Image = CType(resources.GetObject("msSaveRSC.Image"), System.Drawing.Image)
        Me.msSaveRSC.Name = "msSaveRSC"
        Me.msSaveRSC.Size = New System.Drawing.Size(203, 21)
        Me.msSaveRSC.Text = "Save &Rack / Column / Shelf"
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(637, 34)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 481
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'dgBundleItems
        '
        Me.dgBundleItems.AllowUserToAddRows = False
        Me.dgBundleItems.AllowUserToDeleteRows = False
        Me.dgBundleItems.AllowUserToOrderColumns = True
        Me.dgBundleItems.AllowUserToResizeRows = False
        Me.dgBundleItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBundleItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgBundleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBundleItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bi_rowid, Me.bi_pcsrowid, Me.bi_colorvalue, Me.bi_seqno, Me.bi_productcode, Me.bi_colorname, Me.bi_color, Me.bi_size, Me.bi_seasoncode, Me.bi_qtyordered, Me.bi_totalqtytopick, Me.bi_sku, Me.bi_unitofmeasure, Me.bi_remarks, Me.bi_status, Me.bi_verifiedby, Me.bi_verifieddate})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgBundleItems.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgBundleItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgBundleItems.Location = New System.Drawing.Point(12, 56)
        Me.dgBundleItems.MultiSelect = False
        Me.dgBundleItems.Name = "dgBundleItems"
        Me.dgBundleItems.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBundleItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgBundleItems.RowHeadersVisible = False
        Me.dgBundleItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBundleItems.Size = New System.Drawing.Size(610, 290)
        Me.dgBundleItems.TabIndex = 1
        '
        'bi_rowid
        '
        Me.bi_rowid.HeaderText = "rowid"
        Me.bi_rowid.Name = "bi_rowid"
        Me.bi_rowid.ReadOnly = True
        Me.bi_rowid.Visible = False
        '
        'bi_pcsrowid
        '
        Me.bi_pcsrowid.HeaderText = "pcsrowid"
        Me.bi_pcsrowid.Name = "bi_pcsrowid"
        Me.bi_pcsrowid.ReadOnly = True
        Me.bi_pcsrowid.Visible = False
        '
        'bi_colorvalue
        '
        Me.bi_colorvalue.HeaderText = "colorvalue"
        Me.bi_colorvalue.Name = "bi_colorvalue"
        Me.bi_colorvalue.ReadOnly = True
        Me.bi_colorvalue.Visible = False
        '
        'bi_seqno
        '
        Me.bi_seqno.HeaderText = "Seq. No."
        Me.bi_seqno.Name = "bi_seqno"
        Me.bi_seqno.ReadOnly = True
        Me.bi_seqno.Width = 40
        '
        'bi_productcode
        '
        Me.bi_productcode.HeaderText = "Product Code"
        Me.bi_productcode.Name = "bi_productcode"
        Me.bi_productcode.ReadOnly = True
        Me.bi_productcode.Width = 120
        '
        'bi_colorname
        '
        Me.bi_colorname.HeaderText = "Color Name"
        Me.bi_colorname.Name = "bi_colorname"
        Me.bi_colorname.ReadOnly = True
        Me.bi_colorname.Width = 60
        '
        'bi_color
        '
        Me.bi_color.HeaderText = ""
        Me.bi_color.Name = "bi_color"
        Me.bi_color.ReadOnly = True
        Me.bi_color.Width = 30
        '
        'bi_size
        '
        Me.bi_size.HeaderText = "Size"
        Me.bi_size.Name = "bi_size"
        Me.bi_size.ReadOnly = True
        Me.bi_size.Width = 40
        '
        'bi_seasoncode
        '
        Me.bi_seasoncode.HeaderText = "Season Code"
        Me.bi_seasoncode.Name = "bi_seasoncode"
        Me.bi_seasoncode.ReadOnly = True
        Me.bi_seasoncode.Width = 70
        '
        'bi_qtyordered
        '
        Me.bi_qtyordered.HeaderText = "Qty. Ordered"
        Me.bi_qtyordered.Name = "bi_qtyordered"
        Me.bi_qtyordered.ReadOnly = True
        Me.bi_qtyordered.Width = 60
        '
        'bi_totalqtytopick
        '
        Me.bi_totalqtytopick.HeaderText = "Total Qty. To Pick"
        Me.bi_totalqtytopick.Name = "bi_totalqtytopick"
        Me.bi_totalqtytopick.ReadOnly = True
        Me.bi_totalqtytopick.Width = 80
        '
        'bi_sku
        '
        Me.bi_sku.HeaderText = "SKU"
        Me.bi_sku.Name = "bi_sku"
        Me.bi_sku.ReadOnly = True
        '
        'bi_unitofmeasure
        '
        Me.bi_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.bi_unitofmeasure.Name = "bi_unitofmeasure"
        Me.bi_unitofmeasure.ReadOnly = True
        Me.bi_unitofmeasure.Width = 75
        '
        'bi_remarks
        '
        Me.bi_remarks.HeaderText = "Remarks"
        Me.bi_remarks.Name = "bi_remarks"
        Me.bi_remarks.ReadOnly = True
        '
        'bi_status
        '
        Me.bi_status.HeaderText = "Status"
        Me.bi_status.Name = "bi_status"
        Me.bi_status.ReadOnly = True
        '
        'bi_verifiedby
        '
        Me.bi_verifiedby.HeaderText = "Verified By"
        Me.bi_verifiedby.Name = "bi_verifiedby"
        Me.bi_verifiedby.ReadOnly = True
        '
        'bi_verifieddate
        '
        Me.bi_verifieddate.HeaderText = "Verified Date"
        Me.bi_verifieddate.Name = "bi_verifieddate"
        Me.bi_verifieddate.ReadOnly = True
        '
        'rsc_rowid
        '
        Me.rsc_rowid.HeaderText = "rowid"
        Me.rsc_rowid.Name = "rsc_rowid"
        Me.rsc_rowid.Visible = False
        '
        'rsc_rack
        '
        Me.rsc_rack.HeaderText = "Rack"
        Me.rsc_rack.Name = "rsc_rack"
        Me.rsc_rack.ReadOnly = True
        Me.rsc_rack.Width = 50
        '
        'rsc_column
        '
        Me.rsc_column.HeaderText = "Column"
        Me.rsc_column.Name = "rsc_column"
        Me.rsc_column.ReadOnly = True
        Me.rsc_column.Width = 60
        '
        'rsc_shelf
        '
        Me.rsc_shelf.HeaderText = "Shelf"
        Me.rsc_shelf.Name = "rsc_shelf"
        Me.rsc_shelf.ReadOnly = True
        Me.rsc_shelf.Width = 50
        '
        'rsc_qtytopick
        '
        Me.rsc_qtytopick.HeaderText = "Qty. To Pick"
        Me.rsc_qtytopick.Name = "rsc_qtytopick"
        Me.rsc_qtytopick.Width = 67
        '
        'rsc_qtyavailable
        '
        Me.rsc_qtyavailable.HeaderText = "Qty. Available"
        Me.rsc_qtyavailable.Name = "rsc_qtyavailable"
        Me.rsc_qtyavailable.ReadOnly = True
        Me.rsc_qtyavailable.Visible = False
        Me.rsc_qtyavailable.Width = 60
        '
        'rsc_qtyallocated
        '
        Me.rsc_qtyallocated.HeaderText = "Qty. Allocated"
        Me.rsc_qtyallocated.Name = "rsc_qtyallocated"
        Me.rsc_qtyallocated.ReadOnly = True
        Me.rsc_qtyallocated.Visible = False
        Me.rsc_qtyallocated.Width = 60
        '
        'rsc_qtyorderable
        '
        Me.rsc_qtyorderable.HeaderText = "Qty. Orderable"
        Me.rsc_qtyorderable.Name = "rsc_qtyorderable"
        Me.rsc_qtyorderable.ReadOnly = True
        Me.rsc_qtyorderable.Visible = False
        Me.rsc_qtyorderable.Width = 60
        '
        'rsc_pickorderno
        '
        Me.rsc_pickorderno.HeaderText = "Pick Order No."
        Me.rsc_pickorderno.Name = "rsc_pickorderno"
        Me.rsc_pickorderno.ReadOnly = True
        Me.rsc_pickorderno.Width = 83
        '
        'rsc_issueflg
        '
        Me.rsc_issueflg.HeaderText = "With Issue"
        Me.rsc_issueflg.Name = "rsc_issueflg"
        Me.rsc_issueflg.Width = 50
        '
        'rsc_remarks
        '
        Me.rsc_remarks.HeaderText = "Remarks"
        Me.rsc_remarks.Name = "rsc_remarks"
        '
        'EditBundleItemsBForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(944, 382)
        Me.Controls.Add(Me.lblsavemsg)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtTotalQtyToPick)
        Me.Controls.Add(Me.txtTotalQtyOrdered)
        Me.Controls.Add(Me.dgBundleItems)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgRackShelfColumn)
        Me.Controls.Add(Me.txtQtyToPick)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditBundleItemsBForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgRackShelfColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgBundleItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtTotalQtyToPick As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalQtyOrdered As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgRackShelfColumn As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtQtyToPick As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents msSaveRSC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgBundleItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents bi_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_pcsrowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtyordered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_totalqtytopick As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_verifiedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_verifieddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_rack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_shelf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtytopick As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtyallocated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtyorderable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_pickorderno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_issueflg As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents rsc_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
