<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockForm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.dgReceivingItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgRackColumnShelf = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.rcs_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcs_rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcs_column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcs_shelf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcs_totalqtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcs_qtystocked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcs_qtytostock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbRackColumnShelf = New System.Windows.Forms.GroupBox()
        Me.gbAddRackColumnShelf = New System.Windows.Forms.GroupBox()
        Me.txtQtyToStock = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboShelf = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboColumn = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboRack = New System.Windows.Forms.ComboBox()
        Me.btnAddRackColumnShelf = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.gbReceivingItem = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ci_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_pcsrowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtystocked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyreceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyleft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_itemtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgReceivingItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        CType(Me.dgRackColumnShelf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRackColumnShelf.SuspendLayout()
        Me.gbAddRackColumnShelf.SuspendLayout()
        Me.gbReceivingItem.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(844, 28)
        Me.lblTitle.TabIndex = 12
        Me.lblTitle.Text = "Stock To Warehouse"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgReceivingItem
        '
        Me.dgReceivingItem.AllowUserToAddRows = False
        Me.dgReceivingItem.AllowUserToDeleteRows = False
        Me.dgReceivingItem.AllowUserToOrderColumns = True
        Me.dgReceivingItem.AllowUserToResizeRows = False
        Me.dgReceivingItem.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReceivingItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgReceivingItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReceivingItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ci_rowid, Me.ci_pcsrowid, Me.ci_colorvalue, Me.ci_qtystocked, Me.ci_seqno, Me.ci_productcode, Me.ci_colorname, Me.ci_color, Me.ci_size, Me.ci_seasoncode, Me.ci_sku, Me.ci_qtyreceived, Me.ci_qtyleft, Me.ci_remarks, Me.ci_unitofmeasure, Me.ci_itemtype})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgReceivingItem.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgReceivingItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgReceivingItem.Location = New System.Drawing.Point(5, 21)
        Me.dgReceivingItem.MultiSelect = False
        Me.dgReceivingItem.Name = "dgReceivingItem"
        Me.dgReceivingItem.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReceivingItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgReceivingItem.RowHeadersVisible = False
        Me.dgReceivingItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgReceivingItem.Size = New System.Drawing.Size(820, 100)
        Me.dgReceivingItem.TabIndex = 4
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(844, 25)
        Me.msMenu.TabIndex = 1
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'dgRackColumnShelf
        '
        Me.dgRackColumnShelf.AllowUserToAddRows = False
        Me.dgRackColumnShelf.AllowUserToDeleteRows = False
        Me.dgRackColumnShelf.AllowUserToOrderColumns = True
        Me.dgRackColumnShelf.AllowUserToResizeRows = False
        Me.dgRackColumnShelf.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackColumnShelf.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgRackColumnShelf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRackColumnShelf.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rcs_rowid, Me.rcs_rack, Me.rcs_column, Me.rcs_shelf, Me.rcs_totalqtyavailable, Me.rcs_qtystocked, Me.rcs_qtytostock})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRackColumnShelf.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgRackColumnShelf.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgRackColumnShelf.Location = New System.Drawing.Point(50, 60)
        Me.dgRackColumnShelf.MultiSelect = False
        Me.dgRackColumnShelf.Name = "dgRackColumnShelf"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackColumnShelf.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgRackColumnShelf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRackColumnShelf.Size = New System.Drawing.Size(470, 140)
        Me.dgRackColumnShelf.TabIndex = 11
        '
        'rcs_rowid
        '
        Me.rcs_rowid.HeaderText = "rowid"
        Me.rcs_rowid.Name = "rcs_rowid"
        Me.rcs_rowid.Visible = False
        '
        'rcs_rack
        '
        Me.rcs_rack.HeaderText = "Rack"
        Me.rcs_rack.Name = "rcs_rack"
        Me.rcs_rack.ReadOnly = True
        Me.rcs_rack.Width = 55
        '
        'rcs_column
        '
        Me.rcs_column.HeaderText = "Column"
        Me.rcs_column.Name = "rcs_column"
        Me.rcs_column.ReadOnly = True
        Me.rcs_column.Width = 65
        '
        'rcs_shelf
        '
        Me.rcs_shelf.HeaderText = "Shelf"
        Me.rcs_shelf.Name = "rcs_shelf"
        Me.rcs_shelf.ReadOnly = True
        Me.rcs_shelf.Width = 55
        '
        'rcs_totalqtyavailable
        '
        Me.rcs_totalqtyavailable.HeaderText = "Total Qty. Available"
        Me.rcs_totalqtyavailable.Name = "rcs_totalqtyavailable"
        Me.rcs_totalqtyavailable.ReadOnly = True
        Me.rcs_totalqtyavailable.Width = 80
        '
        'rcs_qtystocked
        '
        Me.rcs_qtystocked.HeaderText = "Current Stocked Qty."
        Me.rcs_qtystocked.Name = "rcs_qtystocked"
        Me.rcs_qtystocked.ReadOnly = True
        Me.rcs_qtystocked.Width = 97
        '
        'rcs_qtytostock
        '
        Me.rcs_qtytostock.HeaderText = "Qty. To Stock"
        Me.rcs_qtytostock.Name = "rcs_qtytostock"
        Me.rcs_qtytostock.Width = 67
        '
        'gbRackColumnShelf
        '
        Me.gbRackColumnShelf.Controls.Add(Me.gbAddRackColumnShelf)
        Me.gbRackColumnShelf.Controls.Add(Me.Label55)
        Me.gbRackColumnShelf.Controls.Add(Me.dgRackColumnShelf)
        Me.gbRackColumnShelf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRackColumnShelf.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbRackColumnShelf.Location = New System.Drawing.Point(150, 185)
        Me.gbRackColumnShelf.Name = "gbRackColumnShelf"
        Me.gbRackColumnShelf.Size = New System.Drawing.Size(570, 210)
        Me.gbRackColumnShelf.TabIndex = 3
        Me.gbRackColumnShelf.TabStop = False
        '
        'gbAddRackColumnShelf
        '
        Me.gbAddRackColumnShelf.Controls.Add(Me.txtQtyToStock)
        Me.gbAddRackColumnShelf.Controls.Add(Me.Label9)
        Me.gbAddRackColumnShelf.Controls.Add(Me.cboShelf)
        Me.gbAddRackColumnShelf.Controls.Add(Me.Label8)
        Me.gbAddRackColumnShelf.Controls.Add(Me.cboColumn)
        Me.gbAddRackColumnShelf.Controls.Add(Me.Label6)
        Me.gbAddRackColumnShelf.Controls.Add(Me.cboRack)
        Me.gbAddRackColumnShelf.Controls.Add(Me.btnAddRackColumnShelf)
        Me.gbAddRackColumnShelf.Controls.Add(Me.Label7)
        Me.gbAddRackColumnShelf.Location = New System.Drawing.Point(5, 15)
        Me.gbAddRackColumnShelf.Name = "gbAddRackColumnShelf"
        Me.gbAddRackColumnShelf.Size = New System.Drawing.Size(560, 40)
        Me.gbAddRackColumnShelf.TabIndex = 5
        Me.gbAddRackColumnShelf.TabStop = False
        '
        'txtQtyToStock
        '
        Me.txtQtyToStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyToStock.Location = New System.Drawing.Point(421, 12)
        Me.txtQtyToStock.Name = "txtQtyToStock"
        Me.txtQtyToStock.Size = New System.Drawing.Size(60, 21)
        Me.txtQtyToStock.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(340, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 15)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Qty. To Stock:"
        '
        'cboShelf
        '
        Me.cboShelf.FormattingEnabled = True
        Me.cboShelf.Location = New System.Drawing.Point(271, 12)
        Me.cboShelf.Name = "cboShelf"
        Me.cboShelf.Size = New System.Drawing.Size(60, 21)
        Me.cboShelf.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(232, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 15)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Shelf:"
        '
        'cboColumn
        '
        Me.cboColumn.FormattingEnabled = True
        Me.cboColumn.Location = New System.Drawing.Point(163, 12)
        Me.cboColumn.Name = "cboColumn"
        Me.cboColumn.Size = New System.Drawing.Size(60, 21)
        Me.cboColumn.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(110, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Column:"
        '
        'cboRack
        '
        Me.cboRack.FormattingEnabled = True
        Me.cboRack.Location = New System.Drawing.Point(42, 12)
        Me.cboRack.Name = "cboRack"
        Me.cboRack.Size = New System.Drawing.Size(60, 21)
        Me.cboRack.TabIndex = 6
        '
        'btnAddRackColumnShelf
        '
        Me.btnAddRackColumnShelf.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddRackColumnShelf.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddRackColumnShelf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddRackColumnShelf.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddRackColumnShelf.Image = CType(resources.GetObject("btnAddRackColumnShelf.Image"), System.Drawing.Image)
        Me.btnAddRackColumnShelf.Location = New System.Drawing.Point(494, 5)
        Me.btnAddRackColumnShelf.Name = "btnAddRackColumnShelf"
        Me.btnAddRackColumnShelf.Size = New System.Drawing.Size(45, 35)
        Me.btnAddRackColumnShelf.TabIndex = 10
        Me.btnAddRackColumnShelf.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 15)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Rack:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, -1)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(163, 17)
        Me.Label55.TabIndex = 14
        Me.Label55.Text = "Rack / Column / Shelf:"
        '
        'gbReceivingItem
        '
        Me.gbReceivingItem.Controls.Add(Me.Label5)
        Me.gbReceivingItem.Controls.Add(Me.dgReceivingItem)
        Me.gbReceivingItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReceivingItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbReceivingItem.Location = New System.Drawing.Point(7, 55)
        Me.gbReceivingItem.Name = "gbReceivingItem"
        Me.gbReceivingItem.Size = New System.Drawing.Size(830, 130)
        Me.gbReceivingItem.TabIndex = 2
        Me.gbReceivingItem.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(9, -2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Receiving Item:"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'ci_rowid
        '
        Me.ci_rowid.HeaderText = "rowid"
        Me.ci_rowid.Name = "ci_rowid"
        Me.ci_rowid.ReadOnly = True
        Me.ci_rowid.Visible = False
        '
        'ci_pcsrowid
        '
        Me.ci_pcsrowid.HeaderText = "pcsrowid"
        Me.ci_pcsrowid.Name = "ci_pcsrowid"
        Me.ci_pcsrowid.ReadOnly = True
        Me.ci_pcsrowid.Visible = False
        '
        'ci_colorvalue
        '
        Me.ci_colorvalue.HeaderText = "colorvalue"
        Me.ci_colorvalue.Name = "ci_colorvalue"
        Me.ci_colorvalue.ReadOnly = True
        Me.ci_colorvalue.Visible = False
        '
        'ci_qtystocked
        '
        Me.ci_qtystocked.HeaderText = "qty. stocked"
        Me.ci_qtystocked.Name = "ci_qtystocked"
        Me.ci_qtystocked.ReadOnly = True
        Me.ci_qtystocked.Visible = False
        Me.ci_qtystocked.Width = 60
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
        'ci_qtyreceived
        '
        Me.ci_qtyreceived.HeaderText = "Qty. Received (Good)"
        Me.ci_qtyreceived.Name = "ci_qtyreceived"
        Me.ci_qtyreceived.ReadOnly = True
        Me.ci_qtyreceived.Width = 105
        '
        'ci_qtyleft
        '
        Me.ci_qtyleft.HeaderText = "Qty. Left To Stock"
        Me.ci_qtyleft.Name = "ci_qtyleft"
        Me.ci_qtyleft.ReadOnly = True
        Me.ci_qtyleft.Width = 78
        '
        'ci_remarks
        '
        Me.ci_remarks.HeaderText = "Remarks"
        Me.ci_remarks.Name = "ci_remarks"
        Me.ci_remarks.ReadOnly = True
        '
        'ci_unitofmeasure
        '
        Me.ci_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.ci_unitofmeasure.Name = "ci_unitofmeasure"
        Me.ci_unitofmeasure.ReadOnly = True
        Me.ci_unitofmeasure.Width = 70
        '
        'ci_itemtype
        '
        Me.ci_itemtype.HeaderText = "Type"
        Me.ci_itemtype.Name = "ci_itemtype"
        Me.ci_itemtype.ReadOnly = True
        Me.ci_itemtype.Width = 40
        '
        'StockForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(844, 402)
        Me.Controls.Add(Me.gbReceivingItem)
        Me.Controls.Add(Me.gbRackColumnShelf)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StockForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgReceivingItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.dgRackColumnShelf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRackColumnShelf.ResumeLayout(False)
        Me.gbRackColumnShelf.PerformLayout()
        Me.gbAddRackColumnShelf.ResumeLayout(False)
        Me.gbAddRackColumnShelf.PerformLayout()
        Me.gbReceivingItem.ResumeLayout(False)
        Me.gbReceivingItem.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgReceivingItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgRackColumnShelf As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbRackColumnShelf As System.Windows.Forms.GroupBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents gbReceivingItem As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbAddRackColumnShelf As System.Windows.Forms.GroupBox
    Friend WithEvents cboRack As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddRackColumnShelf As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboColumn As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboShelf As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtQtyToStock As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rcs_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rcs_rack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rcs_column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rcs_shelf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rcs_totalqtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rcs_qtystocked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rcs_qtytostock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents ci_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_pcsrowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtystocked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyreceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyleft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_itemtype As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
