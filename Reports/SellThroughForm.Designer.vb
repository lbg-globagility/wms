<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SellThroughForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SellThroughForm))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbProducts = New System.Windows.Forms.GroupBox()
        Me.txtTotalReceivedRetail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalReceivedQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgProducts = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.p_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_vendorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_receiptdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_rcvdqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_rcvdretail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbFilter = New System.Windows.Forms.GroupBox()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cboBrandName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbSellThrough = New System.Windows.Forms.GroupBox()
        Me.txtTotalSoldPercentage = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalPVOnHand = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalQtyOnHand = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalPVSold = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalQtySold = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgSellThrough = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.st_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.st_qtysold = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.st_pvsold = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.st_qtyonhand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.st_pvonhand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.st_soldpercentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProducts.SuspendLayout()
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFilter.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.gbSellThrough.SuspendLayout()
        CType(Me.dgSellThrough, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.TabIndex = 17
        Me.lblTitle.Text = "Sell-Through"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbProducts
        '
        Me.gbProducts.Controls.Add(Me.txtTotalReceivedRetail)
        Me.gbProducts.Controls.Add(Me.Label6)
        Me.gbProducts.Controls.Add(Me.txtTotalReceivedQty)
        Me.gbProducts.Controls.Add(Me.Label7)
        Me.gbProducts.Controls.Add(Me.dgProducts)
        Me.gbProducts.Controls.Add(Me.Label2)
        Me.gbProducts.Location = New System.Drawing.Point(20, 95)
        Me.gbProducts.Name = "gbProducts"
        Me.gbProducts.Size = New System.Drawing.Size(700, 455)
        Me.gbProducts.TabIndex = 2
        Me.gbProducts.TabStop = False
        '
        'txtTotalReceivedRetail
        '
        Me.txtTotalReceivedRetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalReceivedRetail.Location = New System.Drawing.Point(550, 430)
        Me.txtTotalReceivedRetail.Name = "txtTotalReceivedRetail"
        Me.txtTotalReceivedRetail.ReadOnly = True
        Me.txtTotalReceivedRetail.Size = New System.Drawing.Size(100, 21)
        Me.txtTotalReceivedRetail.TabIndex = 11
        Me.txtTotalReceivedRetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(555, 400)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 26)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Total Received " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Retail:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalReceivedQty
        '
        Me.txtTotalReceivedQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalReceivedQty.Location = New System.Drawing.Point(475, 430)
        Me.txtTotalReceivedQty.Name = "txtTotalReceivedQty"
        Me.txtTotalReceivedQty.ReadOnly = True
        Me.txtTotalReceivedQty.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalReceivedQty.TabIndex = 10
        Me.txtTotalReceivedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(463, 400)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 26)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Received Qty.:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgProducts
        '
        Me.dgProducts.AllowUserToAddRows = False
        Me.dgProducts.AllowUserToDeleteRows = False
        Me.dgProducts.AllowUserToOrderColumns = True
        Me.dgProducts.AllowUserToResizeRows = False
        Me.dgProducts.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.p_rowid, Me.p_seqno, Me.p_productcode, Me.p_vendorname, Me.p_srp, Me.p_receiptdate, Me.p_rcvdqty, Me.p_rcvdretail})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProducts.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgProducts.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProducts.Location = New System.Drawing.Point(10, 19)
        Me.dgProducts.MultiSelect = False
        Me.dgProducts.Name = "dgProducts"
        Me.dgProducts.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProducts.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProducts.Size = New System.Drawing.Size(680, 380)
        Me.dgProducts.TabIndex = 8
        '
        'p_rowid
        '
        Me.p_rowid.HeaderText = "rowid"
        Me.p_rowid.Name = "p_rowid"
        Me.p_rowid.ReadOnly = True
        Me.p_rowid.Visible = False
        '
        'p_seqno
        '
        Me.p_seqno.HeaderText = "Seq. No."
        Me.p_seqno.Name = "p_seqno"
        Me.p_seqno.ReadOnly = True
        Me.p_seqno.Width = 50
        '
        'p_productcode
        '
        Me.p_productcode.HeaderText = "Product Code"
        Me.p_productcode.Name = "p_productcode"
        Me.p_productcode.ReadOnly = True
        Me.p_productcode.Width = 110
        '
        'p_vendorname
        '
        Me.p_vendorname.HeaderText = "Vendor Name"
        Me.p_vendorname.Name = "p_vendorname"
        Me.p_vendorname.ReadOnly = True
        Me.p_vendorname.Width = 140
        '
        'p_srp
        '
        Me.p_srp.HeaderText = "SRP"
        Me.p_srp.Name = "p_srp"
        Me.p_srp.ReadOnly = True
        '
        'p_receiptdate
        '
        Me.p_receiptdate.HeaderText = "Receipt Date"
        Me.p_receiptdate.Name = "p_receiptdate"
        Me.p_receiptdate.ReadOnly = True
        Me.p_receiptdate.Width = 80
        '
        'p_rcvdqty
        '
        Me.p_rcvdqty.HeaderText = "Received Qty."
        Me.p_rcvdqty.Name = "p_rcvdqty"
        Me.p_rcvdqty.ReadOnly = True
        Me.p_rcvdqty.Width = 70
        '
        'p_rcvdretail
        '
        Me.p_rcvdretail.HeaderText = "Received Retail"
        Me.p_rcvdretail.Name = "p_rcvdretail"
        Me.p_rcvdretail.ReadOnly = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(6, -4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Products:"
        '
        'gbFilter
        '
        Me.gbFilter.Controls.Add(Me.cboCategory)
        Me.gbFilter.Controls.Add(Me.Label4)
        Me.gbFilter.Controls.Add(Me.Label5)
        Me.gbFilter.Controls.Add(Me.pnlOptions)
        Me.gbFilter.Controls.Add(Me.cboBrandName)
        Me.gbFilter.Controls.Add(Me.Label3)
        Me.gbFilter.Location = New System.Drawing.Point(20, 40)
        Me.gbFilter.Name = "gbFilter"
        Me.gbFilter.Size = New System.Drawing.Size(860, 50)
        Me.gbFilter.TabIndex = 1
        Me.gbFilter.TabStop = False
        '
        'cboCategory
        '
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(380, 15)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(200, 23)
        Me.cboCategory.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(320, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Category:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Brand Name:"
        '
        'pnlOptions
        '
        Me.pnlOptions.BackColor = System.Drawing.Color.Salmon
        Me.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOptions.Controls.Add(Me.btnEnter)
        Me.pnlOptions.Controls.Add(Me.btnPrint)
        Me.pnlOptions.Location = New System.Drawing.Point(607, 7)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(245, 42)
        Me.pnlOptions.TabIndex = 21
        '
        'btnEnter
        '
        Me.btnEnter.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnEnter.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnter.Location = New System.Drawing.Point(18, 2)
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
        Me.btnPrint.Location = New System.Drawing.Point(128, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(95, 35)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "   Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'cboBrandName
        '
        Me.cboBrandName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBrandName.FormattingEnabled = True
        Me.cboBrandName.Location = New System.Drawing.Point(100, 15)
        Me.cboBrandName.Name = "cboBrandName"
        Me.cboBrandName.Size = New System.Drawing.Size(200, 23)
        Me.cboBrandName.TabIndex = 4
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
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Filters:"
        '
        'gbSellThrough
        '
        Me.gbSellThrough.Controls.Add(Me.txtTotalSoldPercentage)
        Me.gbSellThrough.Controls.Add(Me.Label12)
        Me.gbSellThrough.Controls.Add(Me.txtTotalPVOnHand)
        Me.gbSellThrough.Controls.Add(Me.Label11)
        Me.gbSellThrough.Controls.Add(Me.txtTotalQtyOnHand)
        Me.gbSellThrough.Controls.Add(Me.Label10)
        Me.gbSellThrough.Controls.Add(Me.txtTotalPVSold)
        Me.gbSellThrough.Controls.Add(Me.Label9)
        Me.gbSellThrough.Controls.Add(Me.txtTotalQtySold)
        Me.gbSellThrough.Controls.Add(Me.Label8)
        Me.gbSellThrough.Controls.Add(Me.dgSellThrough)
        Me.gbSellThrough.Controls.Add(Me.Label1)
        Me.gbSellThrough.Location = New System.Drawing.Point(726, 95)
        Me.gbSellThrough.Name = "gbSellThrough"
        Me.gbSellThrough.Size = New System.Drawing.Size(450, 455)
        Me.gbSellThrough.TabIndex = 3
        Me.gbSellThrough.TabStop = False
        '
        'txtTotalSoldPercentage
        '
        Me.txtTotalSoldPercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSoldPercentage.Location = New System.Drawing.Point(385, 430)
        Me.txtTotalSoldPercentage.Name = "txtTotalSoldPercentage"
        Me.txtTotalSoldPercentage.ReadOnly = True
        Me.txtTotalSoldPercentage.Size = New System.Drawing.Size(60, 21)
        Me.txtTotalSoldPercentage.TabIndex = 16
        Me.txtTotalSoldPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(390, 400)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 26)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Total %" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sold:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalPVOnHand
        '
        Me.txtTotalPVOnHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPVOnHand.Location = New System.Drawing.Point(296, 430)
        Me.txtTotalPVOnHand.Name = "txtTotalPVOnHand"
        Me.txtTotalPVOnHand.ReadOnly = True
        Me.txtTotalPVOnHand.Size = New System.Drawing.Size(80, 21)
        Me.txtTotalPVOnHand.TabIndex = 15
        Me.txtTotalPVOnHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(300, 399)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 26)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Total PV" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "On Hand:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalQtyOnHand
        '
        Me.txtTotalQtyOnHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyOnHand.Location = New System.Drawing.Point(214, 430)
        Me.txtTotalQtyOnHand.Name = "txtTotalQtyOnHand"
        Me.txtTotalQtyOnHand.ReadOnly = True
        Me.txtTotalQtyOnHand.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalQtyOnHand.TabIndex = 14
        Me.txtTotalQtyOnHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(217, 399)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 26)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Total Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "On Hand:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalPVSold
        '
        Me.txtTotalPVSold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPVSold.Location = New System.Drawing.Point(129, 430)
        Me.txtTotalPVSold.Name = "txtTotalPVSold"
        Me.txtTotalPVSold.ReadOnly = True
        Me.txtTotalPVSold.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalPVSold.TabIndex = 13
        Me.txtTotalPVSold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(134, 400)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 26)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Total PV" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sold:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalQtySold
        '
        Me.txtTotalQtySold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtySold.Location = New System.Drawing.Point(43, 430)
        Me.txtTotalQtySold.Name = "txtTotalQtySold"
        Me.txtTotalQtySold.ReadOnly = True
        Me.txtTotalQtySold.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalQtySold.TabIndex = 12
        Me.txtTotalQtySold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(49, 400)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 26)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Total Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sold:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgSellThrough
        '
        Me.dgSellThrough.AllowUserToAddRows = False
        Me.dgSellThrough.AllowUserToDeleteRows = False
        Me.dgSellThrough.AllowUserToOrderColumns = True
        Me.dgSellThrough.AllowUserToResizeRows = False
        Me.dgSellThrough.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSellThrough.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgSellThrough.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSellThrough.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.st_rowid, Me.st_qtysold, Me.st_pvsold, Me.st_qtyonhand, Me.st_pvonhand, Me.st_soldpercentage})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSellThrough.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgSellThrough.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgSellThrough.Location = New System.Drawing.Point(10, 19)
        Me.dgSellThrough.MultiSelect = False
        Me.dgSellThrough.Name = "dgSellThrough"
        Me.dgSellThrough.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSellThrough.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgSellThrough.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSellThrough.Size = New System.Drawing.Size(430, 380)
        Me.dgSellThrough.TabIndex = 9
        '
        'st_rowid
        '
        Me.st_rowid.HeaderText = "rowid"
        Me.st_rowid.Name = "st_rowid"
        Me.st_rowid.ReadOnly = True
        Me.st_rowid.Visible = False
        '
        'st_qtysold
        '
        Me.st_qtysold.HeaderText = "Qty. Sold"
        Me.st_qtysold.Name = "st_qtysold"
        Me.st_qtysold.ReadOnly = True
        Me.st_qtysold.Width = 60
        '
        'st_pvsold
        '
        Me.st_pvsold.HeaderText = "PV Sold"
        Me.st_pvsold.Name = "st_pvsold"
        Me.st_pvsold.ReadOnly = True
        Me.st_pvsold.Width = 90
        '
        'st_qtyonhand
        '
        Me.st_qtyonhand.HeaderText = "Qty. On Hand"
        Me.st_qtyonhand.Name = "st_qtyonhand"
        Me.st_qtyonhand.ReadOnly = True
        Me.st_qtyonhand.Width = 70
        '
        'st_pvonhand
        '
        Me.st_pvonhand.HeaderText = "PV On Hand"
        Me.st_pvonhand.Name = "st_pvonhand"
        Me.st_pvonhand.ReadOnly = True
        '
        'st_soldpercentage
        '
        Me.st_soldpercentage.HeaderText = "% Sold"
        Me.st_soldpercentage.Name = "st_soldpercentage"
        Me.st_soldpercentage.ReadOnly = True
        Me.st_soldpercentage.Width = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(6, -4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 17)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Sell-Through Report:"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'SellThroughForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.gbSellThrough)
        Me.Controls.Add(Me.gbProducts)
        Me.Controls.Add(Me.gbFilter)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SellThroughForm"
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProducts.ResumeLayout(False)
        Me.gbProducts.PerformLayout()
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFilter.ResumeLayout(False)
        Me.gbFilter.PerformLayout()
        Me.pnlOptions.ResumeLayout(False)
        Me.gbSellThrough.ResumeLayout(False)
        Me.gbSellThrough.PerformLayout()
        CType(Me.dgSellThrough, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents gbProducts As System.Windows.Forms.GroupBox
    Friend WithEvents dgProducts As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboBrandName As System.Windows.Forms.ComboBox
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbSellThrough As System.Windows.Forms.GroupBox
    Friend WithEvents dgSellThrough As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalReceivedQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalReceivedRetail As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSoldPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPVOnHand As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQtyOnHand As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPVSold As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQtySold As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents p_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_vendorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_receiptdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_rcvdqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_rcvdretail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st_qtysold As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st_pvsold As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st_qtyonhand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st_pvonhand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st_soldpercentage As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
