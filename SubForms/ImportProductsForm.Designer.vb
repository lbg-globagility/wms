<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportProductsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportProductsForm))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.dgImportProducts = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.im_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_brandname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_categoryname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_companyname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.im_lognotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgImportProducts, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(1145, 28)
        Me.lblTitle.TabIndex = 396
        Me.lblTitle.Text = "Import Products"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgImportProducts
        '
        Me.dgImportProducts.AllowUserToAddRows = False
        Me.dgImportProducts.AllowUserToDeleteRows = False
        Me.dgImportProducts.AllowUserToOrderColumns = True
        Me.dgImportProducts.AllowUserToResizeRows = False
        Me.dgImportProducts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgImportProducts.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgImportProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgImportProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgImportProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.im_seqno, Me.im_productcode, Me.im_brandname, Me.im_categoryname, Me.im_companyname, Me.im_srp, Me.im_unitofmeasure, Me.im_description, Me.im_colorname, Me.im_size, Me.im_seasoncode, Me.im_sku, Me.im_status, Me.im_lognotes})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgImportProducts.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgImportProducts.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgImportProducts.Location = New System.Drawing.Point(14, 47)
        Me.dgImportProducts.MultiSelect = False
        Me.dgImportProducts.Name = "dgImportProducts"
        Me.dgImportProducts.ReadOnly = True
        Me.dgImportProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgImportProducts.Size = New System.Drawing.Size(1117, 378)
        Me.dgImportProducts.TabIndex = 397
        '
        'im_seqno
        '
        Me.im_seqno.HeaderText = "Seq. No."
        Me.im_seqno.Name = "im_seqno"
        Me.im_seqno.ReadOnly = True
        Me.im_seqno.Width = 50
        '
        'im_productcode
        '
        Me.im_productcode.HeaderText = "Product Code"
        Me.im_productcode.Name = "im_productcode"
        Me.im_productcode.ReadOnly = True
        '
        'im_brandname
        '
        Me.im_brandname.HeaderText = "Brand Name"
        Me.im_brandname.Name = "im_brandname"
        Me.im_brandname.ReadOnly = True
        '
        'im_categoryname
        '
        Me.im_categoryname.HeaderText = "Category"
        Me.im_categoryname.Name = "im_categoryname"
        Me.im_categoryname.ReadOnly = True
        '
        'im_companyname
        '
        Me.im_companyname.HeaderText = "Company"
        Me.im_companyname.Name = "im_companyname"
        Me.im_companyname.ReadOnly = True
        '
        'im_srp
        '
        Me.im_srp.HeaderText = "SRP"
        Me.im_srp.Name = "im_srp"
        Me.im_srp.ReadOnly = True
        '
        'im_unitofmeasure
        '
        Me.im_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.im_unitofmeasure.Name = "im_unitofmeasure"
        Me.im_unitofmeasure.ReadOnly = True
        Me.im_unitofmeasure.Width = 60
        '
        'im_description
        '
        Me.im_description.HeaderText = "Description"
        Me.im_description.Name = "im_description"
        Me.im_description.ReadOnly = True
        '
        'im_colorname
        '
        Me.im_colorname.HeaderText = "Color"
        Me.im_colorname.Name = "im_colorname"
        Me.im_colorname.ReadOnly = True
        Me.im_colorname.Width = 70
        '
        'im_size
        '
        Me.im_size.HeaderText = "Size"
        Me.im_size.Name = "im_size"
        Me.im_size.ReadOnly = True
        Me.im_size.Width = 50
        '
        'im_seasoncode
        '
        Me.im_seasoncode.HeaderText = "Season Code"
        Me.im_seasoncode.Name = "im_seasoncode"
        Me.im_seasoncode.ReadOnly = True
        Me.im_seasoncode.Width = 80
        '
        'im_sku
        '
        Me.im_sku.HeaderText = "SKU"
        Me.im_sku.Name = "im_sku"
        Me.im_sku.ReadOnly = True
        '
        'im_status
        '
        Me.im_status.HeaderText = "Status"
        Me.im_status.Name = "im_status"
        Me.im_status.ReadOnly = True
        '
        'im_lognotes
        '
        Me.im_lognotes.HeaderText = "Log Notes"
        Me.im_lognotes.Name = "im_lognotes"
        Me.im_lognotes.ReadOnly = True
        Me.im_lognotes.Width = 250
        '
        'ImportProductsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1145, 437)
        Me.Controls.Add(Me.dgImportProducts)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImportProductsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgImportProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgImportProducts As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents im_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_brandname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_categoryname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_companyname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents im_lognotes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
