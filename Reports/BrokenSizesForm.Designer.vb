<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrokenSizesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BrokenSizesForm))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbFilter = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFilterBy = New System.Windows.Forms.ComboBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.cboFilterPhrase = New System.Windows.Forms.ComboBox()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbProductColorSizes = New System.Windows.Forms.GroupBox()
        Me.dgProductColorSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pcs_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_productid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_totalqtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgProductColorSizesA = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pa_productcolorsizeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pa_productcolorid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgProductColorSizesB = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pb_productcolorsizeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pb_productcolorid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFilter.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.gbProductColorSizes.SuspendLayout()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProductColorSizesA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProductColorSizesB, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pbClose.TabIndex = 237
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
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "Broken Sizes"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbFilter
        '
        Me.gbFilter.Controls.Add(Me.Label5)
        Me.gbFilter.Controls.Add(Me.cboFilterBy)
        Me.gbFilter.Controls.Add(Me.cboFilterPhrase)
        Me.gbFilter.Controls.Add(Me.pnlOptions)
        Me.gbFilter.Controls.Add(Me.Label3)
        Me.gbFilter.Controls.Add(Me.chkAll)
        Me.gbFilter.Location = New System.Drawing.Point(20, 45)
        Me.gbFilter.Name = "gbFilter"
        Me.gbFilter.Size = New System.Drawing.Size(370, 110)
        Me.gbFilter.TabIndex = 1
        Me.gbFilter.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "By:"
        '
        'cboFilterBy
        '
        Me.cboFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilterBy.FormattingEnabled = True
        Me.cboFilterBy.Location = New System.Drawing.Point(30, 25)
        Me.cboFilterBy.Name = "cboFilterBy"
        Me.cboFilterBy.Size = New System.Drawing.Size(95, 23)
        Me.cboFilterBy.TabIndex = 3
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(327, 28)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(42, 19)
        Me.chkAll.TabIndex = 5
        Me.chkAll.Text = "All:"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'cboFilterPhrase
        '
        Me.cboFilterPhrase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilterPhrase.FormattingEnabled = True
        Me.cboFilterPhrase.Location = New System.Drawing.Point(130, 25)
        Me.cboFilterPhrase.Name = "cboFilterPhrase"
        Me.cboFilterPhrase.Size = New System.Drawing.Size(180, 23)
        Me.cboFilterPhrase.TabIndex = 4
        '
        'pnlOptions
        '
        Me.pnlOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlOptions.BackColor = System.Drawing.Color.Salmon
        Me.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOptions.Controls.Add(Me.btnEnter)
        Me.pnlOptions.Controls.Add(Me.btnPrint)
        Me.pnlOptions.Location = New System.Drawing.Point(0, 60)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(370, 40)
        Me.pnlOptions.TabIndex = 12
        '
        'btnEnter
        '
        Me.btnEnter.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnEnter.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnter.Location = New System.Drawing.Point(90, 2)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(95, 35)
        Me.btnEnter.TabIndex = 6
        Me.btnEnter.Text = "Enter"
        Me.btnEnter.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.Location = New System.Drawing.Point(200, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(95, 35)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "   Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(6, -4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Filters:"
        '
        'gbProductColorSizes
        '
        Me.gbProductColorSizes.Controls.Add(Me.dgProductColorSizes)
        Me.gbProductColorSizes.Controls.Add(Me.Label2)
        Me.gbProductColorSizes.Location = New System.Drawing.Point(420, 45)
        Me.gbProductColorSizes.Name = "gbProductColorSizes"
        Me.gbProductColorSizes.Size = New System.Drawing.Size(760, 500)
        Me.gbProductColorSizes.TabIndex = 2
        Me.gbProductColorSizes.TabStop = False
        '
        'dgProductColorSizes
        '
        Me.dgProductColorSizes.AllowUserToAddRows = False
        Me.dgProductColorSizes.AllowUserToDeleteRows = False
        Me.dgProductColorSizes.AllowUserToOrderColumns = True
        Me.dgProductColorSizes.AllowUserToResizeRows = False
        Me.dgProductColorSizes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgProductColorSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColorSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcs_rowid, Me.pcs_productid, Me.pcs_colorvalue, Me.pcs_seqno, Me.pcs_productcode, Me.pcs_colorname, Me.pcs_color, Me.pcs_size, Me.pcs_seasoncode, Me.pcs_totalqtyavailable, Me.pcs_sku})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColorSizes.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgProductColorSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColorSizes.Location = New System.Drawing.Point(15, 25)
        Me.dgProductColorSizes.MultiSelect = False
        Me.dgProductColorSizes.Name = "dgProductColorSizes"
        Me.dgProductColorSizes.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgProductColorSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColorSizes.Size = New System.Drawing.Size(730, 460)
        Me.dgProductColorSizes.TabIndex = 8
        '
        'pcs_rowid
        '
        Me.pcs_rowid.HeaderText = "rowid"
        Me.pcs_rowid.Name = "pcs_rowid"
        Me.pcs_rowid.ReadOnly = True
        Me.pcs_rowid.Visible = False
        '
        'pcs_productid
        '
        Me.pcs_productid.HeaderText = "productid"
        Me.pcs_productid.Name = "pcs_productid"
        Me.pcs_productid.ReadOnly = True
        Me.pcs_productid.Visible = False
        '
        'pcs_colorvalue
        '
        Me.pcs_colorvalue.HeaderText = "colorvalue"
        Me.pcs_colorvalue.Name = "pcs_colorvalue"
        Me.pcs_colorvalue.ReadOnly = True
        Me.pcs_colorvalue.Visible = False
        '
        'pcs_seqno
        '
        Me.pcs_seqno.HeaderText = "Seq. No."
        Me.pcs_seqno.Name = "pcs_seqno"
        Me.pcs_seqno.ReadOnly = True
        Me.pcs_seqno.Width = 50
        '
        'pcs_productcode
        '
        Me.pcs_productcode.HeaderText = "Product Code"
        Me.pcs_productcode.Name = "pcs_productcode"
        Me.pcs_productcode.ReadOnly = True
        Me.pcs_productcode.Width = 140
        '
        'pcs_colorname
        '
        Me.pcs_colorname.HeaderText = "Color Name"
        Me.pcs_colorname.Name = "pcs_colorname"
        Me.pcs_colorname.ReadOnly = True
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
        'pcs_totalqtyavailable
        '
        Me.pcs_totalqtyavailable.HeaderText = "Total Qty. Available"
        Me.pcs_totalqtyavailable.Name = "pcs_totalqtyavailable"
        Me.pcs_totalqtyavailable.ReadOnly = True
        Me.pcs_totalqtyavailable.Width = 80
        '
        'pcs_sku
        '
        Me.pcs_sku.HeaderText = "SKU"
        Me.pcs_sku.Name = "pcs_sku"
        Me.pcs_sku.ReadOnly = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(6, -4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(328, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Product Code / Color / Sizes And Season Code:"
        '
        'dgProductColorSizesA
        '
        Me.dgProductColorSizesA.AllowUserToAddRows = False
        Me.dgProductColorSizesA.AllowUserToDeleteRows = False
        Me.dgProductColorSizesA.AllowUserToOrderColumns = True
        Me.dgProductColorSizesA.AllowUserToResizeRows = False
        Me.dgProductColorSizesA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgProductColorSizesA.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizesA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgProductColorSizesA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColorSizesA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pa_productcolorsizeid, Me.pa_productcolorid})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColorSizesA.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgProductColorSizesA.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColorSizesA.Location = New System.Drawing.Point(140, 170)
        Me.dgProductColorSizesA.MultiSelect = False
        Me.dgProductColorSizesA.Name = "dgProductColorSizesA"
        Me.dgProductColorSizesA.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizesA.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgProductColorSizesA.RowHeadersVisible = False
        Me.dgProductColorSizesA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColorSizesA.Size = New System.Drawing.Size(65, 45)
        Me.dgProductColorSizesA.TabIndex = 13
        Me.dgProductColorSizesA.Visible = False
        '
        'pa_productcolorsizeid
        '
        Me.pa_productcolorsizeid.HeaderText = "productcolorsizeid"
        Me.pa_productcolorsizeid.Name = "pa_productcolorsizeid"
        Me.pa_productcolorsizeid.ReadOnly = True
        Me.pa_productcolorsizeid.Width = 120
        '
        'pa_productcolorid
        '
        Me.pa_productcolorid.HeaderText = "productcolorid"
        Me.pa_productcolorid.Name = "pa_productcolorid"
        Me.pa_productcolorid.ReadOnly = True
        Me.pa_productcolorid.Width = 60
        '
        'dgProductColorSizesB
        '
        Me.dgProductColorSizesB.AllowUserToAddRows = False
        Me.dgProductColorSizesB.AllowUserToDeleteRows = False
        Me.dgProductColorSizesB.AllowUserToOrderColumns = True
        Me.dgProductColorSizesB.AllowUserToResizeRows = False
        Me.dgProductColorSizesB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgProductColorSizesB.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizesB.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgProductColorSizesB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColorSizesB.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pb_productcolorsizeid, Me.pb_productcolorid})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColorSizesB.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgProductColorSizesB.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColorSizesB.Location = New System.Drawing.Point(209, 170)
        Me.dgProductColorSizesB.MultiSelect = False
        Me.dgProductColorSizesB.Name = "dgProductColorSizesB"
        Me.dgProductColorSizesB.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizesB.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgProductColorSizesB.RowHeadersVisible = False
        Me.dgProductColorSizesB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColorSizesB.Size = New System.Drawing.Size(65, 45)
        Me.dgProductColorSizesB.TabIndex = 14
        Me.dgProductColorSizesB.Visible = False
        '
        'pb_productcolorsizeid
        '
        Me.pb_productcolorsizeid.HeaderText = "productcolorsizeid"
        Me.pb_productcolorsizeid.Name = "pb_productcolorsizeid"
        Me.pb_productcolorsizeid.ReadOnly = True
        Me.pb_productcolorsizeid.Width = 120
        '
        'pb_productcolorid
        '
        Me.pb_productcolorid.HeaderText = "productcolorid"
        Me.pb_productcolorid.Name = "pb_productcolorid"
        Me.pb_productcolorid.ReadOnly = True
        Me.pb_productcolorid.Width = 60
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'BrokenSizesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.dgProductColorSizesB)
        Me.Controls.Add(Me.dgProductColorSizesA)
        Me.Controls.Add(Me.gbProductColorSizes)
        Me.Controls.Add(Me.gbFilter)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BrokenSizesForm"
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFilter.ResumeLayout(False)
        Me.gbFilter.PerformLayout()
        Me.pnlOptions.ResumeLayout(False)
        Me.gbProductColorSizes.ResumeLayout(False)
        Me.gbProductColorSizes.PerformLayout()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProductColorSizesA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProductColorSizesB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents gbFilter As System.Windows.Forms.GroupBox
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents cboFilterPhrase As System.Windows.Forms.ComboBox
    Friend WithEvents cboFilterBy As System.Windows.Forms.ComboBox
    Friend WithEvents gbProductColorSizes As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgProductColorSizesA As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents dgProductColorSizesB As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgProductColorSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pcs_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_productid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_totalqtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pa_productcolorsizeid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pa_productcolorid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pb_productcolorsizeid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pb_productcolorid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
