<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCartonItemsForm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewCartonItemsForm))
        Me.lblTitle = New System.Windows.Forms.Label()
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
        CType(Me.dgCartonItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(464, 28)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "View Carton Items"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQtyInCartonSum
        '
        Me.txtQtyInCartonSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyInCartonSum.Location = New System.Drawing.Point(249, 258)
        Me.txtQtyInCartonSum.Name = "txtQtyInCartonSum"
        Me.txtQtyInCartonSum.ReadOnly = True
        Me.txtQtyInCartonSum.Size = New System.Drawing.Size(75, 21)
        Me.txtQtyInCartonSum.TabIndex = 2
        Me.txtQtyInCartonSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(108, 262)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 15)
        Me.Label4.TabIndex = 471
        Me.Label4.Text = "Qty. In Carton (Sum):"
        '
        'dgCartonItems
        '
        Me.dgCartonItems.AllowUserToAddRows = False
        Me.dgCartonItems.AllowUserToDeleteRows = False
        Me.dgCartonItems.AllowUserToOrderColumns = True
        Me.dgCartonItems.AllowUserToResizeRows = False
        Me.dgCartonItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartonItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCartonItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCartonItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cai_rowid, Me.cai_colorvalue, Me.cai_seqno, Me.cai_productcode, Me.cai_colorname, Me.cai_color, Me.cai_size, Me.cai_seasoncode, Me.cai_qtyincarton, Me.cai_sku, Me.cai_unitofmeasure, Me.cai_type})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCartonItems.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCartonItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCartonItems.Location = New System.Drawing.Point(9, 41)
        Me.dgCartonItems.MultiSelect = False
        Me.dgCartonItems.Name = "dgCartonItems"
        Me.dgCartonItems.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartonItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCartonItems.RowHeadersVisible = False
        Me.dgCartonItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCartonItems.Size = New System.Drawing.Size(445, 210)
        Me.dgCartonItems.TabIndex = 1
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
        'ViewCartonItemsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(464, 287)
        Me.Controls.Add(Me.txtQtyInCartonSum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgCartonItems)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewCartonItemsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgCartonItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtQtyInCartonSum As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgCartonItems As DevComponents.DotNetBar.Controls.DataGridViewX
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
End Class
