<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdditionalItemsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdditionalItemsForm))
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle56 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle57 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle58 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle59 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle60 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbAddProducts = New System.Windows.Forms.GroupBox()
        Me.gbAddProductItem = New System.Windows.Forms.GroupBox()
        Me.txtQtyReceivedBad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtQtyReceivedGood = New System.Windows.Forms.TextBox()
        Me.cboByPhrase = New System.Windows.Forms.ComboBox()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboBy = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgProductColors = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.c_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgProductSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.s_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_sizes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qtyreceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qtybad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgProductColorSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pcs_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbSupplierOrderItems = New System.Windows.Forms.GroupBox()
        Me.txtTotalQtyReceivedBad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotalQtyReceivedGood = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgReceivingItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ci_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_pcsrowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyreceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtybad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbAddProducts.SuspendLayout()
        Me.gbAddProductItem.SuspendLayout()
        CType(Me.dgProductColors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProductSizes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSupplierOrderItems.SuspendLayout()
        CType(Me.dgReceivingItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbAddProducts
        '
        Me.gbAddProducts.Controls.Add(Me.gbAddProductItem)
        Me.gbAddProducts.Controls.Add(Me.Label1)
        Me.gbAddProducts.Controls.Add(Me.dgProductColors)
        Me.gbAddProducts.Controls.Add(Me.dgProductSizes)
        Me.gbAddProducts.Controls.Add(Me.dgProductColorSizes)
        Me.gbAddProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAddProducts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbAddProducts.Location = New System.Drawing.Point(7, 53)
        Me.gbAddProducts.Name = "gbAddProducts"
        Me.gbAddProducts.Size = New System.Drawing.Size(720, 200)
        Me.gbAddProducts.TabIndex = 2
        Me.gbAddProducts.TabStop = False
        '
        'gbAddProductItem
        '
        Me.gbAddProductItem.Controls.Add(Me.txtQtyReceivedBad)
        Me.gbAddProductItem.Controls.Add(Me.Label2)
        Me.gbAddProductItem.Controls.Add(Me.txtQtyReceivedGood)
        Me.gbAddProductItem.Controls.Add(Me.cboByPhrase)
        Me.gbAddProductItem.Controls.Add(Me.btnAddProduct)
        Me.gbAddProductItem.Controls.Add(Me.Label5)
        Me.gbAddProductItem.Controls.Add(Me.cboBy)
        Me.gbAddProductItem.Controls.Add(Me.Label3)
        Me.gbAddProductItem.Location = New System.Drawing.Point(10, 12)
        Me.gbAddProductItem.Name = "gbAddProductItem"
        Me.gbAddProductItem.Size = New System.Drawing.Size(700, 41)
        Me.gbAddProductItem.TabIndex = 4
        Me.gbAddProductItem.TabStop = False
        '
        'txtQtyReceivedBad
        '
        Me.txtQtyReceivedBad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyReceivedBad.Location = New System.Drawing.Point(576, 12)
        Me.txtQtyReceivedBad.Name = "txtQtyReceivedBad"
        Me.txtQtyReceivedBad.Size = New System.Drawing.Size(45, 21)
        Me.txtQtyReceivedBad.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(512, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 30)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Qty. (Bad)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Received:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtQtyReceivedGood
        '
        Me.txtQtyReceivedGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyReceivedGood.Location = New System.Drawing.Point(455, 12)
        Me.txtQtyReceivedGood.Name = "txtQtyReceivedGood"
        Me.txtQtyReceivedGood.Size = New System.Drawing.Size(45, 21)
        Me.txtQtyReceivedGood.TabIndex = 7
        '
        'cboByPhrase
        '
        Me.cboByPhrase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboByPhrase.FormattingEnabled = True
        Me.cboByPhrase.Location = New System.Drawing.Point(117, 11)
        Me.cboByPhrase.Name = "cboByPhrase"
        Me.cboByPhrase.Size = New System.Drawing.Size(260, 23)
        Me.cboByPhrase.TabIndex = 6
        '
        'btnAddProduct
        '
        Me.btnAddProduct.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddProduct.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProduct.Image = CType(resources.GetObject("btnAddProduct.Image"), System.Drawing.Image)
        Me.btnAddProduct.Location = New System.Drawing.Point(635, 6)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(45, 34)
        Me.btnAddProduct.TabIndex = 9
        Me.btnAddProduct.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(385, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 30)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Qty. (Good)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Received:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboBy
        '
        Me.cboBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBy.FormattingEnabled = True
        Me.cboBy.Location = New System.Drawing.Point(27, 11)
        Me.cboBy.Name = "cboBy"
        Me.cboBy.Size = New System.Drawing.Size(85, 23)
        Me.cboBy.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "By:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(9, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Add Products:"
        '
        'dgProductColors
        '
        Me.dgProductColors.AllowUserToAddRows = False
        Me.dgProductColors.AllowUserToDeleteRows = False
        Me.dgProductColors.AllowUserToOrderColumns = True
        Me.dgProductColors.AllowUserToResizeRows = False
        Me.dgProductColors.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle49.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColors.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle49
        Me.dgProductColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_rowid, Me.c_colorvalue, Me.c_seqno, Me.c_colorname, Me.c_color})
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColors.DefaultCellStyle = DataGridViewCellStyle50
        Me.dgProductColors.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColors.Location = New System.Drawing.Point(10, 58)
        Me.dgProductColors.MultiSelect = False
        Me.dgProductColors.Name = "dgProductColors"
        Me.dgProductColors.ReadOnly = True
        DataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle51.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColors.RowHeadersDefaultCellStyle = DataGridViewCellStyle51
        Me.dgProductColors.RowHeadersVisible = False
        Me.dgProductColors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColors.Size = New System.Drawing.Size(205, 135)
        Me.dgProductColors.TabIndex = 10
        '
        'c_rowid
        '
        Me.c_rowid.HeaderText = "rowid"
        Me.c_rowid.Name = "c_rowid"
        Me.c_rowid.ReadOnly = True
        Me.c_rowid.Visible = False
        '
        'c_colorvalue
        '
        Me.c_colorvalue.HeaderText = "colorvalue"
        Me.c_colorvalue.Name = "c_colorvalue"
        Me.c_colorvalue.ReadOnly = True
        Me.c_colorvalue.Visible = False
        '
        'c_seqno
        '
        Me.c_seqno.HeaderText = "Seq. No."
        Me.c_seqno.Name = "c_seqno"
        Me.c_seqno.ReadOnly = True
        Me.c_seqno.Width = 77
        '
        'c_colorname
        '
        Me.c_colorname.HeaderText = "Color Name"
        Me.c_colorname.Name = "c_colorname"
        Me.c_colorname.ReadOnly = True
        Me.c_colorname.Width = 97
        '
        'c_color
        '
        Me.c_color.HeaderText = ""
        Me.c_color.Name = "c_color"
        Me.c_color.ReadOnly = True
        Me.c_color.Width = 30
        '
        'dgProductSizes
        '
        Me.dgProductSizes.AllowUserToAddRows = False
        Me.dgProductSizes.AllowUserToDeleteRows = False
        Me.dgProductSizes.AllowUserToOrderColumns = True
        Me.dgProductSizes.AllowUserToResizeRows = False
        Me.dgProductSizes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle52.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle52.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle52.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle52.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle52.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle52
        Me.dgProductSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.s_rowid, Me.s_sizes, Me.s_seasoncode, Me.s_sku, Me.s_qtyreceived, Me.s_qtybad, Me.s_qtyavailable})
        DataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle53.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle53.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle53.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle53.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductSizes.DefaultCellStyle = DataGridViewCellStyle53
        Me.dgProductSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductSizes.Location = New System.Drawing.Point(220, 58)
        Me.dgProductSizes.MultiSelect = False
        Me.dgProductSizes.Name = "dgProductSizes"
        DataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle54.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle54.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle54.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle54
        Me.dgProductSizes.RowHeadersVisible = False
        Me.dgProductSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductSizes.Size = New System.Drawing.Size(490, 135)
        Me.dgProductSizes.TabIndex = 11
        '
        's_rowid
        '
        Me.s_rowid.HeaderText = "rowid"
        Me.s_rowid.Name = "s_rowid"
        Me.s_rowid.Visible = False
        '
        's_sizes
        '
        Me.s_sizes.HeaderText = "Size"
        Me.s_sizes.Name = "s_sizes"
        Me.s_sizes.ReadOnly = True
        Me.s_sizes.Width = 50
        '
        's_seasoncode
        '
        Me.s_seasoncode.HeaderText = "Season Code"
        Me.s_seasoncode.Name = "s_seasoncode"
        Me.s_seasoncode.ReadOnly = True
        Me.s_seasoncode.Width = 70
        '
        's_sku
        '
        Me.s_sku.HeaderText = "SKU"
        Me.s_sku.Name = "s_sku"
        Me.s_sku.ReadOnly = True
        '
        's_qtyreceived
        '
        Me.s_qtyreceived.HeaderText = "Qty. Received (Good)"
        Me.s_qtyreceived.Name = "s_qtyreceived"
        Me.s_qtyreceived.Width = 105
        '
        's_qtybad
        '
        Me.s_qtybad.HeaderText = "Qty. Received (Bad)"
        Me.s_qtybad.Name = "s_qtybad"
        Me.s_qtybad.Width = 105
        '
        's_qtyavailable
        '
        Me.s_qtyavailable.HeaderText = "Qty. Available"
        Me.s_qtyavailable.Name = "s_qtyavailable"
        Me.s_qtyavailable.ReadOnly = True
        Me.s_qtyavailable.Width = 60
        '
        'dgProductColorSizes
        '
        Me.dgProductColorSizes.AllowUserToAddRows = False
        Me.dgProductColorSizes.AllowUserToDeleteRows = False
        Me.dgProductColorSizes.AllowUserToOrderColumns = True
        Me.dgProductColorSizes.AllowUserToResizeRows = False
        Me.dgProductColorSizes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle55.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle55.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle55.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle55
        Me.dgProductColorSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColorSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcs_rowid, Me.pcs_colorvalue, Me.pcs_productcode, Me.pcs_colorname, Me.pcs_color, Me.pcs_size, Me.pcs_seasoncode, Me.pcs_sku, Me.pcs_qtyavailable})
        DataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle56.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle56.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColorSizes.DefaultCellStyle = DataGridViewCellStyle56
        Me.dgProductColorSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColorSizes.Location = New System.Drawing.Point(10, 58)
        Me.dgProductColorSizes.MultiSelect = False
        Me.dgProductColorSizes.Name = "dgProductColorSizes"
        Me.dgProductColorSizes.ReadOnly = True
        DataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle57.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle57.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle57.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle57.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle57
        Me.dgProductColorSizes.RowHeadersVisible = False
        Me.dgProductColorSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColorSizes.Size = New System.Drawing.Size(700, 135)
        Me.dgProductColorSizes.TabIndex = 12
        '
        'pcs_rowid
        '
        Me.pcs_rowid.HeaderText = "rowid"
        Me.pcs_rowid.Name = "pcs_rowid"
        Me.pcs_rowid.ReadOnly = True
        Me.pcs_rowid.Visible = False
        '
        'pcs_colorvalue
        '
        Me.pcs_colorvalue.HeaderText = "colorvalue"
        Me.pcs_colorvalue.Name = "pcs_colorvalue"
        Me.pcs_colorvalue.ReadOnly = True
        Me.pcs_colorvalue.Visible = False
        '
        'pcs_productcode
        '
        Me.pcs_productcode.HeaderText = "Product Code"
        Me.pcs_productcode.Name = "pcs_productcode"
        Me.pcs_productcode.ReadOnly = True
        Me.pcs_productcode.Width = 120
        '
        'pcs_colorname
        '
        Me.pcs_colorname.HeaderText = "Color Name"
        Me.pcs_colorname.Name = "pcs_colorname"
        Me.pcs_colorname.ReadOnly = True
        Me.pcs_colorname.Width = 80
        '
        'pcs_color
        '
        Me.pcs_color.HeaderText = ""
        Me.pcs_color.Name = "pcs_color"
        Me.pcs_color.ReadOnly = True
        Me.pcs_color.Width = 40
        '
        'pcs_size
        '
        Me.pcs_size.HeaderText = "Size"
        Me.pcs_size.Name = "pcs_size"
        Me.pcs_size.ReadOnly = True
        Me.pcs_size.Width = 50
        '
        'pcs_seasoncode
        '
        Me.pcs_seasoncode.HeaderText = "Season Code"
        Me.pcs_seasoncode.Name = "pcs_seasoncode"
        Me.pcs_seasoncode.ReadOnly = True
        Me.pcs_seasoncode.Width = 70
        '
        'pcs_sku
        '
        Me.pcs_sku.HeaderText = "SKU"
        Me.pcs_sku.Name = "pcs_sku"
        Me.pcs_sku.ReadOnly = True
        '
        'pcs_qtyavailable
        '
        Me.pcs_qtyavailable.HeaderText = "Qty. Available"
        Me.pcs_qtyavailable.Name = "pcs_qtyavailable"
        Me.pcs_qtyavailable.ReadOnly = True
        Me.pcs_qtyavailable.Width = 60
        '
        'gbSupplierOrderItems
        '
        Me.gbSupplierOrderItems.Controls.Add(Me.txtTotalQtyReceivedBad)
        Me.gbSupplierOrderItems.Controls.Add(Me.Label4)
        Me.gbSupplierOrderItems.Controls.Add(Me.txtTotalQtyReceivedGood)
        Me.gbSupplierOrderItems.Controls.Add(Me.Label8)
        Me.gbSupplierOrderItems.Controls.Add(Me.dgReceivingItems)
        Me.gbSupplierOrderItems.Controls.Add(Me.Label15)
        Me.gbSupplierOrderItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSupplierOrderItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSupplierOrderItems.Location = New System.Drawing.Point(7, 256)
        Me.gbSupplierOrderItems.Name = "gbSupplierOrderItems"
        Me.gbSupplierOrderItems.Size = New System.Drawing.Size(720, 200)
        Me.gbSupplierOrderItems.TabIndex = 3
        Me.gbSupplierOrderItems.TabStop = False
        '
        'txtTotalQtyReceivedBad
        '
        Me.txtTotalQtyReceivedBad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyReceivedBad.Location = New System.Drawing.Point(552, 173)
        Me.txtTotalQtyReceivedBad.Name = "txtTotalQtyReceivedBad"
        Me.txtTotalQtyReceivedBad.ReadOnly = True
        Me.txtTotalQtyReceivedBad.Size = New System.Drawing.Size(87, 21)
        Me.txtTotalQtyReceivedBad.TabIndex = 15
        Me.txtTotalQtyReceivedBad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(377, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(173, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Total Qty. Received (Bad):"
        '
        'txtTotalQtyReceivedGood
        '
        Me.txtTotalQtyReceivedGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyReceivedGood.Location = New System.Drawing.Point(274, 173)
        Me.txtTotalQtyReceivedGood.Name = "txtTotalQtyReceivedGood"
        Me.txtTotalQtyReceivedGood.ReadOnly = True
        Me.txtTotalQtyReceivedGood.Size = New System.Drawing.Size(87, 21)
        Me.txtTotalQtyReceivedGood.TabIndex = 14
        Me.txtTotalQtyReceivedGood.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(90, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(182, 15)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Total Qty. Received (Good):"
        '
        'dgReceivingItems
        '
        Me.dgReceivingItems.AllowUserToAddRows = False
        Me.dgReceivingItems.AllowUserToDeleteRows = False
        Me.dgReceivingItems.AllowUserToOrderColumns = True
        Me.dgReceivingItems.AllowUserToResizeRows = False
        Me.dgReceivingItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle58.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle58.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle58.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle58.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle58.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReceivingItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle58
        Me.dgReceivingItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReceivingItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ci_rowid, Me.ci_pcsrowid, Me.ci_colorvalue, Me.ci_seqno, Me.ci_productcode, Me.ci_colorname, Me.ci_color, Me.ci_size, Me.ci_seasoncode, Me.ci_sku, Me.ci_qtyreceived, Me.ci_qtybad, Me.ci_unitofmeasure, Me.ci_remarks, Me.ci_reason, Me.ci_option})
        DataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle59.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle59.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgReceivingItems.DefaultCellStyle = DataGridViewCellStyle59
        Me.dgReceivingItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgReceivingItems.Location = New System.Drawing.Point(10, 20)
        Me.dgReceivingItems.MultiSelect = False
        Me.dgReceivingItems.Name = "dgReceivingItems"
        DataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle60.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle60.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle60.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReceivingItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle60
        Me.dgReceivingItems.RowHeadersVisible = False
        Me.dgReceivingItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgReceivingItems.Size = New System.Drawing.Size(700, 150)
        Me.dgReceivingItems.TabIndex = 13
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
        'ci_colorvalue
        '
        Me.ci_colorvalue.HeaderText = "colorvalue"
        Me.ci_colorvalue.Name = "ci_colorvalue"
        Me.ci_colorvalue.Visible = False
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
        Me.ci_sku.Width = 80
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
        'ci_unitofmeasure
        '
        Me.ci_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.ci_unitofmeasure.Name = "ci_unitofmeasure"
        Me.ci_unitofmeasure.Width = 70
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
        'ci_option
        '
        Me.ci_option.HeaderText = ""
        Me.ci_option.Name = "ci_option"
        Me.ci_option.Text = "Delete"
        Me.ci_option.UseColumnTextForButtonValue = True
        Me.ci_option.Width = 50
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, -2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 17)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Receiving Items:"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(734, 25)
        Me.msMenu.TabIndex = 1
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(36, 7)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 470
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(734, 28)
        Me.lblTitle.TabIndex = 16
        Me.lblTitle.Text = "Add Additional Items"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AdditionalItemsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(734, 462)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblsavemsg)
        Me.Controls.Add(Me.gbSupplierOrderItems)
        Me.Controls.Add(Me.gbAddProducts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdditionalItemsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbAddProducts.ResumeLayout(False)
        Me.gbAddProducts.PerformLayout()
        Me.gbAddProductItem.ResumeLayout(False)
        Me.gbAddProductItem.PerformLayout()
        CType(Me.dgProductColors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProductSizes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSupplierOrderItems.ResumeLayout(False)
        Me.gbSupplierOrderItems.PerformLayout()
        CType(Me.dgReceivingItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbAddProducts As System.Windows.Forms.GroupBox
    Friend WithEvents dgProductColorSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbAddProductItem As System.Windows.Forms.GroupBox
    Friend WithEvents txtQtyReceivedGood As System.Windows.Forms.TextBox
    Friend WithEvents cboByPhrase As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgProductColors As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents c_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgProductSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbSupplierOrderItems As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dgReceivingItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTotalQtyReceivedGood As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pcs_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtQtyReceivedBad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents s_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_sizes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qtyreceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qtybad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTotalQtyReceivedBad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ci_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_pcsrowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyreceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtybad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_reason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_option As System.Windows.Forms.DataGridViewButtonColumn
End Class
