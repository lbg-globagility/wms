<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockLevelForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockLevelForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.gbFilter = New System.Windows.Forms.GroupBox()
        Me.rbtnDamageStocks = New System.Windows.Forms.RadioButton()
        Me.rbtnGoodStocks = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboBrandName = New System.Windows.Forms.ComboBox()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbProductColorSizes = New System.Windows.Forms.GroupBox()
        Me.dgProductColorSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pcs_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_totalqtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFilter.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.gbProductColorSizes.SuspendLayout()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(1200, 28)
        Me.lblTitle.TabIndex = 10
        Me.lblTitle.Text = "Stock Level"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.pbClose.TabIndex = 238
        Me.pbClose.TabStop = False
        '
        'gbFilter
        '
        Me.gbFilter.Controls.Add(Me.rbtnDamageStocks)
        Me.gbFilter.Controls.Add(Me.rbtnGoodStocks)
        Me.gbFilter.Controls.Add(Me.Label1)
        Me.gbFilter.Controls.Add(Me.cboCategory)
        Me.gbFilter.Controls.Add(Me.Label5)
        Me.gbFilter.Controls.Add(Me.cboBrandName)
        Me.gbFilter.Controls.Add(Me.pnlOptions)
        Me.gbFilter.Controls.Add(Me.Label3)
        Me.gbFilter.Location = New System.Drawing.Point(20, 45)
        Me.gbFilter.Name = "gbFilter"
        Me.gbFilter.Size = New System.Drawing.Size(340, 160)
        Me.gbFilter.TabIndex = 1
        Me.gbFilter.TabStop = False
        '
        'rbtnDamageStocks
        '
        Me.rbtnDamageStocks.AutoSize = True
        Me.rbtnDamageStocks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnDamageStocks.Location = New System.Drawing.Point(180, 20)
        Me.rbtnDamageStocks.Name = "rbtnDamageStocks"
        Me.rbtnDamageStocks.Size = New System.Drawing.Size(112, 19)
        Me.rbtnDamageStocks.TabIndex = 4
        Me.rbtnDamageStocks.Text = "Damage Stocks"
        Me.rbtnDamageStocks.UseVisualStyleBackColor = True
        '
        'rbtnGoodStocks
        '
        Me.rbtnGoodStocks.AutoSize = True
        Me.rbtnGoodStocks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnGoodStocks.Location = New System.Drawing.Point(50, 20)
        Me.rbtnGoodStocks.Name = "rbtnGoodStocks"
        Me.rbtnGoodStocks.Size = New System.Drawing.Size(94, 19)
        Me.rbtnGoodStocks.TabIndex = 3
        Me.rbtnGoodStocks.Text = "Good Stocks"
        Me.rbtnGoodStocks.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Category:"
        '
        'cboCategory
        '
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(105, 75)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(200, 23)
        Me.cboCategory.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Brand Name:"
        '
        'cboBrandName
        '
        Me.cboBrandName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBrandName.FormattingEnabled = True
        Me.cboBrandName.Location = New System.Drawing.Point(105, 45)
        Me.cboBrandName.Name = "cboBrandName"
        Me.cboBrandName.Size = New System.Drawing.Size(200, 23)
        Me.cboBrandName.TabIndex = 5
        '
        'pnlOptions
        '
        Me.pnlOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlOptions.BackColor = System.Drawing.Color.Salmon
        Me.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOptions.Controls.Add(Me.btnEnter)
        Me.pnlOptions.Controls.Add(Me.btnPrint)
        Me.pnlOptions.Location = New System.Drawing.Point(0, 109)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(340, 40)
        Me.pnlOptions.TabIndex = 14
        '
        'btnEnter
        '
        Me.btnEnter.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnEnter.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnter.Location = New System.Drawing.Point(74, 2)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(95, 35)
        Me.btnEnter.TabIndex = 7
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
        Me.btnPrint.Location = New System.Drawing.Point(180, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(95, 35)
        Me.btnPrint.TabIndex = 8
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
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Filters:"
        '
        'gbProductColorSizes
        '
        Me.gbProductColorSizes.Controls.Add(Me.dgProductColorSizes)
        Me.gbProductColorSizes.Controls.Add(Me.Label2)
        Me.gbProductColorSizes.Location = New System.Drawing.Point(380, 45)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgProductColorSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColorSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcs_rowid, Me.pcs_colorvalue, Me.pcs_seqno, Me.pcs_productcode, Me.pcs_colorname, Me.pcs_color, Me.pcs_size, Me.pcs_seasoncode, Me.pcs_srp, Me.pcs_totalqtyavailable, Me.pcs_sku})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColorSizes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgProductColorSizes.EnableHeadersVisualStyles = False
        Me.dgProductColorSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColorSizes.Location = New System.Drawing.Point(15, 25)
        Me.dgProductColorSizes.Name = "dgProductColorSizes"
        Me.dgProductColorSizes.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgProductColorSizes.RowHeadersWidth = 67
        Me.dgProductColorSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColorSizes.Size = New System.Drawing.Size(730, 460)
        Me.dgProductColorSizes.TabIndex = 9
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
        'pcs_seqno
        '
        Me.pcs_seqno.HeaderText = "Seq. No."
        Me.pcs_seqno.Name = "pcs_seqno"
        Me.pcs_seqno.ReadOnly = True
        Me.pcs_seqno.Visible = False
        Me.pcs_seqno.Width = 50
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
        'pcs_srp
        '
        Me.pcs_srp.HeaderText = "SRP"
        Me.pcs_srp.Name = "pcs_srp"
        Me.pcs_srp.ReadOnly = True
        Me.pcs_srp.Width = 80
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
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'StockLevelForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.gbProductColorSizes)
        Me.Controls.Add(Me.gbFilter)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StockLevelForm"
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFilter.ResumeLayout(False)
        Me.gbFilter.PerformLayout()
        Me.pnlOptions.ResumeLayout(False)
        Me.gbProductColorSizes.ResumeLayout(False)
        Me.gbProductColorSizes.PerformLayout()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents gbFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboBrandName As System.Windows.Forms.ComboBox
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents rbtnGoodStocks As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnDamageStocks As System.Windows.Forms.RadioButton
    Friend WithEvents gbProductColorSizes As System.Windows.Forms.GroupBox
    Friend WithEvents dgProductColorSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents pcs_rowid As DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorvalue As DataGridViewTextBoxColumn
    Friend WithEvents pcs_seqno As DataGridViewTextBoxColumn
    Friend WithEvents pcs_productcode As DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorname As DataGridViewTextBoxColumn
    Friend WithEvents pcs_color As DataGridViewTextBoxColumn
    Friend WithEvents pcs_size As DataGridViewTextBoxColumn
    Friend WithEvents pcs_seasoncode As DataGridViewTextBoxColumn
    Friend WithEvents pcs_srp As DataGridViewTextBoxColumn
    Friend WithEvents pcs_totalqtyavailable As DataGridViewTextBoxColumn
    Friend WithEvents pcs_sku As DataGridViewTextBoxColumn
End Class
