<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddLineUpForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddLineUpForm))
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbCartonItems = New System.Windows.Forms.GroupBox()
        Me.txtQtyInCartonSum = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgCartonItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cai_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_qtyincarton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbCartons = New System.Windows.Forms.GroupBox()
        Me.dgCartons = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ca_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_cartonno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_lineup = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ca_cbm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_sizename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_packername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_packeddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbLineUpInformation = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cboHelper2 = New System.Windows.Forms.ComboBox()
        Me.cboHelper1 = New System.Windows.Forms.ComboBox()
        Me.cboAgent = New System.Windows.Forms.ComboBox()
        Me.txtCBM = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtClassDescription = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtVendorCodeNameInfo = New System.Windows.Forms.TextBox()
        Me.txtBranchCodeNameInfo = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtCancelDate = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtSIDRNo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.txtDeliveryHours = New System.Windows.Forms.TextBox()
        Me.txtReceiptDate = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboCustomerOrderInfo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbAddDriver = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDeliveryAddress = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCustomerOrderDate = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.pbAddTruckShiftInfo = New System.Windows.Forms.PictureBox()
        Me.cboDriverName = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTruckShiftInfo = New System.Windows.Forms.ComboBox()
        Me.dtpLineUpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtLineUpNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnAddAgent = New System.Windows.Forms.PictureBox()
        Me.btnAddHelper1 = New System.Windows.Forms.PictureBox()
        Me.btnAddHelper2 = New System.Windows.Forms.PictureBox()
        Me.msMenu.SuspendLayout()
        Me.gbCartonItems.SuspendLayout()
        CType(Me.dgCartonItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCartons.SuspendLayout()
        CType(Me.dgCartons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLineUpInformation.SuspendLayout()
        CType(Me.pbAddDriver, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddTruckShiftInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAddAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAddHelper1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAddHelper2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(972, 28)
        Me.lblTitle.TabIndex = 240
        Me.lblTitle.Text = "Add New Line-Up"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(972, 25)
        Me.msMenu.TabIndex = 1
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'gbCartonItems
        '
        Me.gbCartonItems.Controls.Add(Me.txtQtyInCartonSum)
        Me.gbCartonItems.Controls.Add(Me.Label4)
        Me.gbCartonItems.Controls.Add(Me.dgCartonItems)
        Me.gbCartonItems.Controls.Add(Me.Label6)
        Me.gbCartonItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCartonItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCartonItems.Location = New System.Drawing.Point(482, 319)
        Me.gbCartonItems.Name = "gbCartonItems"
        Me.gbCartonItems.Size = New System.Drawing.Size(490, 240)
        Me.gbCartonItems.TabIndex = 4
        Me.gbCartonItems.TabStop = False
        '
        'txtQtyInCartonSum
        '
        Me.txtQtyInCartonSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyInCartonSum.Location = New System.Drawing.Point(278, 211)
        Me.txtQtyInCartonSum.Name = "txtQtyInCartonSum"
        Me.txtQtyInCartonSum.ReadOnly = True
        Me.txtQtyInCartonSum.Size = New System.Drawing.Size(75, 21)
        Me.txtQtyInCartonSum.TabIndex = 25
        Me.txtQtyInCartonSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(137, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 15)
        Me.Label4.TabIndex = 468
        Me.Label4.Text = "Qty. In Carton (Sum):"
        '
        'dgCartonItems
        '
        Me.dgCartonItems.AllowUserToAddRows = False
        Me.dgCartonItems.AllowUserToDeleteRows = False
        Me.dgCartonItems.AllowUserToOrderColumns = True
        Me.dgCartonItems.AllowUserToResizeRows = False
        Me.dgCartonItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartonItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgCartonItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCartonItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cai_rowid, Me.cai_colorvalue, Me.cai_seqno, Me.cai_productcode, Me.cai_colorname, Me.cai_color, Me.cai_size, Me.cai_seasoncode, Me.cai_qtyincarton, Me.cai_sku, Me.cai_unitofmeasure, Me.cai_type})
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCartonItems.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgCartonItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCartonItems.Location = New System.Drawing.Point(8, 17)
        Me.dgCartonItems.MultiSelect = False
        Me.dgCartonItems.Name = "dgCartonItems"
        Me.dgCartonItems.ReadOnly = True
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartonItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgCartonItems.RowHeadersVisible = False
        Me.dgCartonItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCartonItems.Size = New System.Drawing.Size(475, 190)
        Me.dgCartonItems.TabIndex = 24
        '
        'cai_rowid
        '
        Me.cai_rowid.HeaderText = "rowid"
        Me.cai_rowid.Name = "cai_rowid"
        Me.cai_rowid.ReadOnly = True
        Me.cai_rowid.Visible = False
        '
        'cai_colorvalue
        '
        Me.cai_colorvalue.HeaderText = "colorvalue"
        Me.cai_colorvalue.Name = "cai_colorvalue"
        Me.cai_colorvalue.ReadOnly = True
        Me.cai_colorvalue.Visible = False
        '
        'cai_seqno
        '
        Me.cai_seqno.HeaderText = "Seq. No."
        Me.cai_seqno.Name = "cai_seqno"
        Me.cai_seqno.ReadOnly = True
        Me.cai_seqno.Width = 40
        '
        'cai_productcode
        '
        Me.cai_productcode.HeaderText = "Product Code"
        Me.cai_productcode.Name = "cai_productcode"
        Me.cai_productcode.ReadOnly = True
        '
        'cai_colorname
        '
        Me.cai_colorname.HeaderText = "Color Name"
        Me.cai_colorname.Name = "cai_colorname"
        Me.cai_colorname.ReadOnly = True
        Me.cai_colorname.Width = 60
        '
        'cai_color
        '
        Me.cai_color.HeaderText = ""
        Me.cai_color.Name = "cai_color"
        Me.cai_color.ReadOnly = True
        Me.cai_color.Width = 30
        '
        'cai_size
        '
        Me.cai_size.HeaderText = "Size"
        Me.cai_size.Name = "cai_size"
        Me.cai_size.ReadOnly = True
        Me.cai_size.Width = 40
        '
        'cai_seasoncode
        '
        Me.cai_seasoncode.HeaderText = "Season Code"
        Me.cai_seasoncode.Name = "cai_seasoncode"
        Me.cai_seasoncode.ReadOnly = True
        Me.cai_seasoncode.Width = 70
        '
        'cai_qtyincarton
        '
        Me.cai_qtyincarton.HeaderText = "Qty. In Carton"
        Me.cai_qtyincarton.Name = "cai_qtyincarton"
        Me.cai_qtyincarton.ReadOnly = True
        Me.cai_qtyincarton.Width = 60
        '
        'cai_sku
        '
        Me.cai_sku.HeaderText = "SKU"
        Me.cai_sku.Name = "cai_sku"
        Me.cai_sku.ReadOnly = True
        '
        'cai_unitofmeasure
        '
        Me.cai_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.cai_unitofmeasure.Name = "cai_unitofmeasure"
        Me.cai_unitofmeasure.ReadOnly = True
        Me.cai_unitofmeasure.Width = 70
        '
        'cai_type
        '
        Me.cai_type.HeaderText = "Type"
        Me.cai_type.Name = "cai_type"
        Me.cai_type.ReadOnly = True
        Me.cai_type.Width = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(9, -2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 17)
        Me.Label6.TabIndex = 228
        Me.Label6.Text = "Box Items:"
        '
        'gbCartons
        '
        Me.gbCartons.Controls.Add(Me.dgCartons)
        Me.gbCartons.Controls.Add(Me.Label9)
        Me.gbCartons.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCartons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCartons.Location = New System.Drawing.Point(12, 319)
        Me.gbCartons.Name = "gbCartons"
        Me.gbCartons.Size = New System.Drawing.Size(460, 240)
        Me.gbCartons.TabIndex = 3
        Me.gbCartons.TabStop = False
        '
        'dgCartons
        '
        Me.dgCartons.AllowUserToAddRows = False
        Me.dgCartons.AllowUserToDeleteRows = False
        Me.dgCartons.AllowUserToOrderColumns = True
        Me.dgCartons.AllowUserToResizeRows = False
        Me.dgCartons.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartons.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgCartons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCartons.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ca_rowid, Me.ca_seqno, Me.ca_cartonno, Me.ca_lineup, Me.ca_cbm, Me.ca_sizename, Me.ca_packername, Me.ca_status, Me.ca_packeddate})
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCartons.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgCartons.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCartons.Location = New System.Drawing.Point(8, 17)
        Me.dgCartons.MultiSelect = False
        Me.dgCartons.Name = "dgCartons"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartons.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgCartons.RowHeadersVisible = False
        Me.dgCartons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCartons.Size = New System.Drawing.Size(445, 215)
        Me.dgCartons.TabIndex = 23
        '
        'ca_rowid
        '
        Me.ca_rowid.HeaderText = "rowid"
        Me.ca_rowid.Name = "ca_rowid"
        Me.ca_rowid.Visible = False
        '
        'ca_seqno
        '
        Me.ca_seqno.HeaderText = "Seq. No."
        Me.ca_seqno.Name = "ca_seqno"
        Me.ca_seqno.ReadOnly = True
        Me.ca_seqno.Width = 50
        '
        'ca_cartonno
        '
        Me.ca_cartonno.HeaderText = "Box No."
        Me.ca_cartonno.Name = "ca_cartonno"
        Me.ca_cartonno.ReadOnly = True
        Me.ca_cartonno.Width = 70
        '
        'ca_lineup
        '
        Me.ca_lineup.HeaderText = "Line-Up"
        Me.ca_lineup.Name = "ca_lineup"
        Me.ca_lineup.Width = 60
        '
        'ca_cbm
        '
        Me.ca_cbm.HeaderText = "CBM"
        Me.ca_cbm.Name = "ca_cbm"
        Me.ca_cbm.ReadOnly = True
        Me.ca_cbm.Width = 80
        '
        'ca_sizename
        '
        Me.ca_sizename.HeaderText = "Size Name"
        Me.ca_sizename.Name = "ca_sizename"
        Me.ca_sizename.ReadOnly = True
        Me.ca_sizename.Width = 80
        '
        'ca_packername
        '
        Me.ca_packername.HeaderText = "Packer Name"
        Me.ca_packername.Name = "ca_packername"
        Me.ca_packername.ReadOnly = True
        Me.ca_packername.Width = 120
        '
        'ca_status
        '
        Me.ca_status.HeaderText = "Status"
        Me.ca_status.Name = "ca_status"
        Me.ca_status.ReadOnly = True
        Me.ca_status.Width = 80
        '
        'ca_packeddate
        '
        Me.ca_packeddate.HeaderText = "Packed Date"
        Me.ca_packeddate.Name = "ca_packeddate"
        Me.ca_packeddate.ReadOnly = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(9, -2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 17)
        Me.Label9.TabIndex = 228
        Me.Label9.Text = "Boxes:"
        '
        'gbLineUpInformation
        '
        Me.gbLineUpInformation.Controls.Add(Me.btnAddHelper2)
        Me.gbLineUpInformation.Controls.Add(Me.btnAddHelper1)
        Me.gbLineUpInformation.Controls.Add(Me.btnAddAgent)
        Me.gbLineUpInformation.Controls.Add(Me.Label32)
        Me.gbLineUpInformation.Controls.Add(Me.Label28)
        Me.gbLineUpInformation.Controls.Add(Me.Label26)
        Me.gbLineUpInformation.Controls.Add(Me.cboHelper2)
        Me.gbLineUpInformation.Controls.Add(Me.cboHelper1)
        Me.gbLineUpInformation.Controls.Add(Me.cboAgent)
        Me.gbLineUpInformation.Controls.Add(Me.txtCBM)
        Me.gbLineUpInformation.Controls.Add(Me.Label16)
        Me.gbLineUpInformation.Controls.Add(Me.txtClassDescription)
        Me.gbLineUpInformation.Controls.Add(Me.Label31)
        Me.gbLineUpInformation.Controls.Add(Me.txtVendorCodeNameInfo)
        Me.gbLineUpInformation.Controls.Add(Me.txtBranchCodeNameInfo)
        Me.gbLineUpInformation.Controls.Add(Me.Label41)
        Me.gbLineUpInformation.Controls.Add(Me.Label29)
        Me.gbLineUpInformation.Controls.Add(Me.txtCancelDate)
        Me.gbLineUpInformation.Controls.Add(Me.Label14)
        Me.gbLineUpInformation.Controls.Add(Me.Label27)
        Me.gbLineUpInformation.Controls.Add(Me.txtSIDRNo)
        Me.gbLineUpInformation.Controls.Add(Me.Label15)
        Me.gbLineUpInformation.Controls.Add(Me.txtPONo)
        Me.gbLineUpInformation.Controls.Add(Me.txtDeliveryHours)
        Me.gbLineUpInformation.Controls.Add(Me.txtReceiptDate)
        Me.gbLineUpInformation.Controls.Add(Me.Label20)
        Me.gbLineUpInformation.Controls.Add(Me.cboCustomerOrderInfo)
        Me.gbLineUpInformation.Controls.Add(Me.Label10)
        Me.gbLineUpInformation.Controls.Add(Me.Label1)
        Me.gbLineUpInformation.Controls.Add(Me.pbAddDriver)
        Me.gbLineUpInformation.Controls.Add(Me.Label7)
        Me.gbLineUpInformation.Controls.Add(Me.txtDeliveryAddress)
        Me.gbLineUpInformation.Controls.Add(Me.Label19)
        Me.gbLineUpInformation.Controls.Add(Me.txtCustomerOrderDate)
        Me.gbLineUpInformation.Controls.Add(Me.Label22)
        Me.gbLineUpInformation.Controls.Add(Me.pbAddTruckShiftInfo)
        Me.gbLineUpInformation.Controls.Add(Me.cboDriverName)
        Me.gbLineUpInformation.Controls.Add(Me.Label17)
        Me.gbLineUpInformation.Controls.Add(Me.txtComments)
        Me.gbLineUpInformation.Controls.Add(Me.Label25)
        Me.gbLineUpInformation.Controls.Add(Me.txtStatus)
        Me.gbLineUpInformation.Controls.Add(Me.Label12)
        Me.gbLineUpInformation.Controls.Add(Me.Label5)
        Me.gbLineUpInformation.Controls.Add(Me.cboTruckShiftInfo)
        Me.gbLineUpInformation.Controls.Add(Me.dtpLineUpDate)
        Me.gbLineUpInformation.Controls.Add(Me.Label11)
        Me.gbLineUpInformation.Controls.Add(Me.txtLineUpNo)
        Me.gbLineUpInformation.Controls.Add(Me.Label2)
        Me.gbLineUpInformation.Controls.Add(Me.Label3)
        Me.gbLineUpInformation.Controls.Add(Me.Label8)
        Me.gbLineUpInformation.Controls.Add(Me.Label13)
        Me.gbLineUpInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLineUpInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbLineUpInformation.Location = New System.Drawing.Point(12, 52)
        Me.gbLineUpInformation.Name = "gbLineUpInformation"
        Me.gbLineUpInformation.Size = New System.Drawing.Size(960, 262)
        Me.gbLineUpInformation.TabIndex = 2
        Me.gbLineUpInformation.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(360, 223)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(57, 15)
        Me.Label32.TabIndex = 599
        Me.Label32.Text = "Helper 2:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(360, 196)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 15)
        Me.Label28.TabIndex = 600
        Me.Label28.Text = "Helper 1:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(38, 196)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(41, 15)
        Me.Label26.TabIndex = 601
        Me.Label26.Text = "Agent:"
        '
        'cboHelper2
        '
        Me.cboHelper2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHelper2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHelper2.FormattingEnabled = True
        Me.cboHelper2.Location = New System.Drawing.Point(433, 215)
        Me.cboHelper2.Name = "cboHelper2"
        Me.cboHelper2.Size = New System.Drawing.Size(212, 23)
        Me.cboHelper2.TabIndex = 596
        '
        'cboHelper1
        '
        Me.cboHelper1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHelper1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHelper1.FormattingEnabled = True
        Me.cboHelper1.Location = New System.Drawing.Point(433, 188)
        Me.cboHelper1.Name = "cboHelper1"
        Me.cboHelper1.Size = New System.Drawing.Size(212, 23)
        Me.cboHelper1.TabIndex = 597
        '
        'cboAgent
        '
        Me.cboAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(85, 188)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(243, 23)
        Me.cboAgent.TabIndex = 598
        '
        'txtCBM
        '
        Me.txtCBM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCBM.Location = New System.Drawing.Point(259, 79)
        Me.txtCBM.Name = "txtCBM"
        Me.txtCBM.ReadOnly = True
        Me.txtCBM.Size = New System.Drawing.Size(85, 21)
        Me.txtCBM.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(220, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 15)
        Me.Label16.TabIndex = 589
        Me.Label16.Text = "CBM:"
        '
        'txtClassDescription
        '
        Me.txtClassDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClassDescription.Location = New System.Drawing.Point(469, 161)
        Me.txtClassDescription.Name = "txtClassDescription"
        Me.txtClassDescription.ReadOnly = True
        Me.txtClassDescription.Size = New System.Drawing.Size(296, 21)
        Me.txtClassDescription.TabIndex = 21
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(360, 164)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(105, 15)
        Me.Label31.TabIndex = 587
        Me.Label31.Text = "Class Description:"
        '
        'txtVendorCodeNameInfo
        '
        Me.txtVendorCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorCodeNameInfo.Location = New System.Drawing.Point(510, 134)
        Me.txtVendorCodeNameInfo.Name = "txtVendorCodeNameInfo"
        Me.txtVendorCodeNameInfo.ReadOnly = True
        Me.txtVendorCodeNameInfo.Size = New System.Drawing.Size(255, 21)
        Me.txtVendorCodeNameInfo.TabIndex = 20
        '
        'txtBranchCodeNameInfo
        '
        Me.txtBranchCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchCodeNameInfo.Location = New System.Drawing.Point(510, 106)
        Me.txtBranchCodeNameInfo.Name = "txtBranchCodeNameInfo"
        Me.txtBranchCodeNameInfo.ReadOnly = True
        Me.txtBranchCodeNameInfo.Size = New System.Drawing.Size(255, 21)
        Me.txtBranchCodeNameInfo.TabIndex = 19
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(360, 109)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(147, 15)
        Me.Label41.TabIndex = 585
        Me.Label41.Text = "Branch Code / Name Info:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(360, 137)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(147, 15)
        Me.Label29.TabIndex = 584
        Me.Label29.Text = "Vendor Code / Name Info:"
        '
        'txtCancelDate
        '
        Me.txtCancelDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCancelDate.Location = New System.Drawing.Point(858, 50)
        Me.txtCancelDate.Name = "txtCancelDate"
        Me.txtCancelDate.ReadOnly = True
        Me.txtCancelDate.Size = New System.Drawing.Size(90, 21)
        Me.txtCancelDate.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(780, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 15)
        Me.Label14.TabIndex = 581
        Me.Label14.Text = "Cancel Date:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(780, 82)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(76, 15)
        Me.Label27.TabIndex = 580
        Me.Label27.Text = "S.I./D.R. No.:"
        '
        'txtSIDRNo
        '
        Me.txtSIDRNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIDRNo.Location = New System.Drawing.Point(858, 79)
        Me.txtSIDRNo.Name = "txtSIDRNo"
        Me.txtSIDRNo.ReadOnly = True
        Me.txtSIDRNo.Size = New System.Drawing.Size(90, 21)
        Me.txtSIDRNo.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(789, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 15)
        Me.Label15.TabIndex = 579
        Me.Label15.Text = "P.O. No.:"
        '
        'txtPONo
        '
        Me.txtPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPONo.Location = New System.Drawing.Point(848, 21)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.ReadOnly = True
        Me.txtPONo.Size = New System.Drawing.Size(100, 21)
        Me.txtPONo.TabIndex = 13
        '
        'txtDeliveryHours
        '
        Me.txtDeliveryHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryHours.Location = New System.Drawing.Point(778, 123)
        Me.txtDeliveryHours.Multiline = True
        Me.txtDeliveryHours.Name = "txtDeliveryHours"
        Me.txtDeliveryHours.ReadOnly = True
        Me.txtDeliveryHours.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDeliveryHours.Size = New System.Drawing.Size(170, 59)
        Me.txtDeliveryHours.TabIndex = 22
        '
        'txtReceiptDate
        '
        Me.txtReceiptDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiptDate.Location = New System.Drawing.Point(675, 50)
        Me.txtReceiptDate.Name = "txtReceiptDate"
        Me.txtReceiptDate.ReadOnly = True
        Me.txtReceiptDate.Size = New System.Drawing.Size(90, 21)
        Me.txtReceiptDate.TabIndex = 15
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(592, 53)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 15)
        Me.Label20.TabIndex = 567
        Me.Label20.Text = "Receipt Date:"
        '
        'cboCustomerOrderInfo
        '
        Me.cboCustomerOrderInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomerOrderInfo.FormattingEnabled = True
        Me.cboCustomerOrderInfo.Location = New System.Drawing.Point(498, 21)
        Me.cboCustomerOrderInfo.Name = "cboCustomerOrderInfo"
        Me.cboCustomerOrderInfo.Size = New System.Drawing.Size(267, 23)
        Me.cboCustomerOrderInfo.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(360, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 15)
        Me.Label10.TabIndex = 555
        Me.Label10.Text = "Customer Order Info.:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(481, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 20)
        Me.Label1.TabIndex = 556
        Me.Label1.Text = "*"
        '
        'pbAddDriver
        '
        Me.pbAddDriver.BackColor = System.Drawing.Color.Transparent
        Me.pbAddDriver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddDriver.Image = CType(resources.GetObject("pbAddDriver.Image"), System.Drawing.Image)
        Me.pbAddDriver.Location = New System.Drawing.Point(331, 108)
        Me.pbAddDriver.Name = "pbAddDriver"
        Me.pbAddDriver.Size = New System.Drawing.Size(14, 18)
        Me.pbAddDriver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddDriver.TabIndex = 575
        Me.pbAddDriver.TabStop = False
        Me.pbAddDriver.Tag = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(360, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 15)
        Me.Label7.TabIndex = 572
        Me.Label7.Text = "Delivery Address:"
        '
        'txtDeliveryAddress
        '
        Me.txtDeliveryAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryAddress.Location = New System.Drawing.Point(463, 79)
        Me.txtDeliveryAddress.Name = "txtDeliveryAddress"
        Me.txtDeliveryAddress.ReadOnly = True
        Me.txtDeliveryAddress.Size = New System.Drawing.Size(302, 21)
        Me.txtDeliveryAddress.TabIndex = 17
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(826, 104)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 15)
        Me.Label19.TabIndex = 569
        Me.Label19.Text = "Delivery Hours:"
        '
        'txtCustomerOrderDate
        '
        Me.txtCustomerOrderDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerOrderDate.Location = New System.Drawing.Point(488, 50)
        Me.txtCustomerOrderDate.Name = "txtCustomerOrderDate"
        Me.txtCustomerOrderDate.ReadOnly = True
        Me.txtCustomerOrderDate.Size = New System.Drawing.Size(90, 21)
        Me.txtCustomerOrderDate.TabIndex = 14
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(360, 53)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(126, 15)
        Me.Label22.TabIndex = 568
        Me.Label22.Text = "Customer Order Date:"
        '
        'pbAddTruckShiftInfo
        '
        Me.pbAddTruckShiftInfo.BackColor = System.Drawing.Color.Transparent
        Me.pbAddTruckShiftInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddTruckShiftInfo.Image = CType(resources.GetObject("pbAddTruckShiftInfo.Image"), System.Drawing.Image)
        Me.pbAddTruckShiftInfo.Location = New System.Drawing.Point(331, 52)
        Me.pbAddTruckShiftInfo.Name = "pbAddTruckShiftInfo"
        Me.pbAddTruckShiftInfo.Size = New System.Drawing.Size(14, 18)
        Me.pbAddTruckShiftInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddTruckShiftInfo.TabIndex = 563
        Me.pbAddTruckShiftInfo.TabStop = False
        Me.pbAddTruckShiftInfo.Tag = ""
        '
        'cboDriverName
        '
        Me.cboDriverName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDriverName.FormattingEnabled = True
        Me.cboDriverName.Location = New System.Drawing.Point(94, 106)
        Me.cboDriverName.Name = "cboDriverName"
        Me.cboDriverName.Size = New System.Drawing.Size(234, 23)
        Me.cboDriverName.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(9, 109)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 15)
        Me.Label17.TabIndex = 562
        Me.Label17.Text = "Driver Name:"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(85, 134)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(257, 48)
        Me.txtComments.TabIndex = 11
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(9, 137)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 15)
        Me.Label25.TabIndex = 560
        Me.Label25.Text = "Comments:"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(240, 21)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(100, 21)
        Me.txtStatus.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(193, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 558
        Me.Label12.Text = "Status:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(9, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 15)
        Me.Label5.TabIndex = 553
        Me.Label5.Text = "Truck And Shift Info:"
        '
        'cboTruckShiftInfo
        '
        Me.cboTruckShiftInfo.BackColor = System.Drawing.SystemColors.Window
        Me.cboTruckShiftInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTruckShiftInfo.FormattingEnabled = True
        Me.cboTruckShiftInfo.Location = New System.Drawing.Point(137, 50)
        Me.cboTruckShiftInfo.Name = "cboTruckShiftInfo"
        Me.cboTruckShiftInfo.Size = New System.Drawing.Size(191, 23)
        Me.cboTruckShiftInfo.TabIndex = 7
        '
        'dtpLineUpDate
        '
        Me.dtpLineUpDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpLineUpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpLineUpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLineUpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLineUpDate.Location = New System.Drawing.Point(106, 79)
        Me.dtpLineUpDate.Name = "dtpLineUpDate"
        Me.dtpLineUpDate.Size = New System.Drawing.Size(110, 21)
        Me.dtpLineUpDate.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(9, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 551
        Me.Label11.Text = "Delivery Date:"
        '
        'txtLineUpNo
        '
        Me.txtLineUpNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLineUpNo.Location = New System.Drawing.Point(87, 21)
        Me.txtLineUpNo.Name = "txtLineUpNo"
        Me.txtLineUpNo.ReadOnly = True
        Me.txtLineUpNo.Size = New System.Drawing.Size(100, 21)
        Me.txtLineUpNo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(9, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 549
        Me.Label2.Text = "Line-Up No.:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(121, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 20)
        Me.Label3.TabIndex = 564
        Me.Label3.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(9, -2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(153, 17)
        Me.Label8.TabIndex = 228
        Me.Label8.Text = "Line-Up Information:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(89, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 20)
        Me.Label13.TabIndex = 565
        Me.Label13.Text = "*"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'btnAddAgent
        '
        Me.btnAddAgent.BackColor = System.Drawing.Color.Transparent
        Me.btnAddAgent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddAgent.Image = CType(resources.GetObject("btnAddAgent.Image"), System.Drawing.Image)
        Me.btnAddAgent.Location = New System.Drawing.Point(331, 190)
        Me.btnAddAgent.Name = "btnAddAgent"
        Me.btnAddAgent.Size = New System.Drawing.Size(14, 18)
        Me.btnAddAgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAddAgent.TabIndex = 602
        Me.btnAddAgent.TabStop = False
        Me.btnAddAgent.Tag = ""
        '
        'btnAddHelper1
        '
        Me.btnAddHelper1.BackColor = System.Drawing.Color.Transparent
        Me.btnAddHelper1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddHelper1.Image = CType(resources.GetObject("btnAddHelper1.Image"), System.Drawing.Image)
        Me.btnAddHelper1.Location = New System.Drawing.Point(648, 190)
        Me.btnAddHelper1.Name = "btnAddHelper1"
        Me.btnAddHelper1.Size = New System.Drawing.Size(14, 18)
        Me.btnAddHelper1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAddHelper1.TabIndex = 603
        Me.btnAddHelper1.TabStop = False
        Me.btnAddHelper1.Tag = ""
        '
        'btnAddHelper2
        '
        Me.btnAddHelper2.BackColor = System.Drawing.Color.Transparent
        Me.btnAddHelper2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddHelper2.Image = CType(resources.GetObject("btnAddHelper2.Image"), System.Drawing.Image)
        Me.btnAddHelper2.Location = New System.Drawing.Point(648, 217)
        Me.btnAddHelper2.Name = "btnAddHelper2"
        Me.btnAddHelper2.Size = New System.Drawing.Size(14, 18)
        Me.btnAddHelper2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAddHelper2.TabIndex = 604
        Me.btnAddHelper2.TabStop = False
        Me.btnAddHelper2.Tag = ""
        '
        'AddLineUpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(984, 492)
        Me.Controls.Add(Me.gbLineUpInformation)
        Me.Controls.Add(Me.gbCartonItems)
        Me.Controls.Add(Me.gbCartons)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddLineUpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        Me.gbCartonItems.ResumeLayout(False)
        Me.gbCartonItems.PerformLayout()
        CType(Me.dgCartonItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCartons.ResumeLayout(False)
        Me.gbCartons.PerformLayout()
        CType(Me.dgCartons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLineUpInformation.ResumeLayout(False)
        Me.gbLineUpInformation.PerformLayout()
        CType(Me.pbAddDriver, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddTruckShiftInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAddAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAddHelper1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAddHelper2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbCartonItems As System.Windows.Forms.GroupBox
    Friend WithEvents txtQtyInCartonSum As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgCartonItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbCartons As System.Windows.Forms.GroupBox
    Friend WithEvents dgCartons As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gbLineUpInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pbAddDriver As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents txtCustomerOrderDate As System.Windows.Forms.TextBox
    Private WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtReceiptDate As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents pbAddTruckShiftInfo As System.Windows.Forms.PictureBox
    Friend WithEvents cboDriverName As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerOrderInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboTruckShiftInfo As System.Windows.Forms.ComboBox
    Friend WithEvents dtpLineUpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtLineUpNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cai_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_qtyincarton As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtDeliveryHours As System.Windows.Forms.TextBox
    Friend WithEvents txtCancelDate As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtSIDRNo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Private WithEvents txtVendorCodeNameInfo As System.Windows.Forms.TextBox
    Private WithEvents txtBranchCodeNameInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Private WithEvents txtClassDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Private WithEvents txtCBM As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ca_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_cartonno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_lineup As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ca_cbm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_sizename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_packername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_packeddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label32 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents cboHelper2 As ComboBox
    Friend WithEvents cboHelper1 As ComboBox
    Friend WithEvents cboAgent As ComboBox
    Friend WithEvents btnAddAgent As PictureBox
    Friend WithEvents btnAddHelper1 As PictureBox
    Friend WithEvents btnAddHelper2 As PictureBox
End Class
