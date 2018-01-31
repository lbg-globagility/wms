<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditBundleItemsAForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditBundleItemsAForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgBundleItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.txtOverallQty = New System.Windows.Forms.TextBox()
        Me.lblOverallQty = New System.Windows.Forms.Label()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.chkOtherInfo = New System.Windows.Forms.CheckBox()
        Me.bi_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_totalqtyorder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtypicked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtydelivered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtyorderable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtyreserve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_tags = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.bi_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_verifiedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_verifieddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_packedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_packeddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_deliveredby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_delivereddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.msMenu.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(684, 28)
        Me.lblTitle.TabIndex = 396
        Me.lblTitle.Text = "View/Edit Bundle Items"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(684, 25)
        Me.msMenu.TabIndex = 397
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'dgBundleItems
        '
        Me.dgBundleItems.AllowUserToAddRows = False
        Me.dgBundleItems.AllowUserToDeleteRows = False
        Me.dgBundleItems.AllowUserToOrderColumns = True
        Me.dgBundleItems.AllowUserToResizeRows = False
        Me.dgBundleItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgBundleItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBundleItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgBundleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBundleItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bi_rowid, Me.bi_colorvalue, Me.bi_seqno, Me.bi_productcode, Me.bi_colorname, Me.bi_color, Me.bi_size, Me.bi_seasoncode, Me.bi_totalqtyorder, Me.bi_qtypicked, Me.bi_qtydelivered, Me.bi_qtyavailable, Me.bi_qtyallocated, Me.bi_qtyorderable, Me.bi_qtyreserve, Me.bi_sku, Me.bi_unitofmeasure, Me.bi_remarks, Me.bi_tags, Me.bi_status, Me.bi_verifiedby, Me.bi_verifieddate, Me.bi_packedby, Me.bi_packeddate, Me.bi_deliveredby, Me.bi_delivereddate, Me.bi_option})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgBundleItems.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgBundleItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgBundleItems.Location = New System.Drawing.Point(12, 60)
        Me.dgBundleItems.MultiSelect = False
        Me.dgBundleItems.Name = "dgBundleItems"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBundleItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgBundleItems.RowHeadersVisible = False
        Me.dgBundleItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBundleItems.Size = New System.Drawing.Size(660, 290)
        Me.dgBundleItems.TabIndex = 398
        '
        'txtOverallQty
        '
        Me.txtOverallQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtOverallQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOverallQty.Location = New System.Drawing.Point(343, 33)
        Me.txtOverallQty.Name = "txtOverallQty"
        Me.txtOverallQty.ReadOnly = True
        Me.txtOverallQty.Size = New System.Drawing.Size(95, 21)
        Me.txtOverallQty.TabIndex = 471
        Me.txtOverallQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOverallQty
        '
        Me.lblOverallQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOverallQty.AutoSize = True
        Me.lblOverallQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverallQty.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOverallQty.Location = New System.Drawing.Point(170, 35)
        Me.lblOverallQty.Name = "lblOverallQty"
        Me.lblOverallQty.Size = New System.Drawing.Size(170, 15)
        Me.lblOverallQty.TabIndex = 472
        Me.lblOverallQty.Text = "Total Qty. Ordered (Sum):"
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(18, 34)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 473
        '
        'chkOtherInfo
        '
        Me.chkOtherInfo.AutoSize = True
        Me.chkOtherInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOtherInfo.Location = New System.Drawing.Point(560, 35)
        Me.chkOtherInfo.Name = "chkOtherInfo"
        Me.chkOtherInfo.Size = New System.Drawing.Size(114, 19)
        Me.chkOtherInfo.TabIndex = 474
        Me.chkOtherInfo.Text = "View Other Info.:"
        Me.chkOtherInfo.UseVisualStyleBackColor = True
        '
        'bi_rowid
        '
        Me.bi_rowid.HeaderText = "rowid"
        Me.bi_rowid.Name = "bi_rowid"
        Me.bi_rowid.Visible = False
        '
        'bi_colorvalue
        '
        Me.bi_colorvalue.HeaderText = "colorvalue"
        Me.bi_colorvalue.Name = "bi_colorvalue"
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
        'bi_totalqtyorder
        '
        Me.bi_totalqtyorder.HeaderText = "Total Qty. Ordered"
        Me.bi_totalqtyorder.Name = "bi_totalqtyorder"
        Me.bi_totalqtyorder.Width = 80
        '
        'bi_qtypicked
        '
        Me.bi_qtypicked.HeaderText = "Qty. Picked"
        Me.bi_qtypicked.Name = "bi_qtypicked"
        Me.bi_qtypicked.ReadOnly = True
        Me.bi_qtypicked.Width = 60
        '
        'bi_qtydelivered
        '
        Me.bi_qtydelivered.HeaderText = "Qty. Delivered"
        Me.bi_qtydelivered.Name = "bi_qtydelivered"
        Me.bi_qtydelivered.ReadOnly = True
        Me.bi_qtydelivered.Width = 60
        '
        'bi_qtyavailable
        '
        Me.bi_qtyavailable.HeaderText = "Qty. Available"
        Me.bi_qtyavailable.Name = "bi_qtyavailable"
        Me.bi_qtyavailable.ReadOnly = True
        Me.bi_qtyavailable.Width = 60
        '
        'bi_qtyallocated
        '
        Me.bi_qtyallocated.HeaderText = "Qty. Allocated"
        Me.bi_qtyallocated.Name = "bi_qtyallocated"
        Me.bi_qtyallocated.ReadOnly = True
        Me.bi_qtyallocated.Width = 60
        '
        'bi_qtyorderable
        '
        Me.bi_qtyorderable.HeaderText = "Qty. Orderable"
        Me.bi_qtyorderable.Name = "bi_qtyorderable"
        Me.bi_qtyorderable.ReadOnly = True
        Me.bi_qtyorderable.Width = 60
        '
        'bi_qtyreserve
        '
        Me.bi_qtyreserve.HeaderText = "Qty. Reserve"
        Me.bi_qtyreserve.Name = "bi_qtyreserve"
        Me.bi_qtyreserve.ReadOnly = True
        Me.bi_qtyreserve.Width = 60
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
        Me.bi_unitofmeasure.Width = 70
        '
        'bi_remarks
        '
        Me.bi_remarks.HeaderText = "Remarks"
        Me.bi_remarks.Name = "bi_remarks"
        '
        'bi_tags
        '
        Me.bi_tags.HeaderText = "Tags"
        Me.bi_tags.Name = "bi_tags"
        Me.bi_tags.Width = 90
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
        'bi_packedby
        '
        Me.bi_packedby.HeaderText = "Packed By"
        Me.bi_packedby.Name = "bi_packedby"
        Me.bi_packedby.ReadOnly = True
        '
        'bi_packeddate
        '
        Me.bi_packeddate.HeaderText = "Packed Date"
        Me.bi_packeddate.Name = "bi_packeddate"
        Me.bi_packeddate.ReadOnly = True
        '
        'bi_deliveredby
        '
        Me.bi_deliveredby.HeaderText = "Delivered By"
        Me.bi_deliveredby.Name = "bi_deliveredby"
        Me.bi_deliveredby.ReadOnly = True
        '
        'bi_delivereddate
        '
        Me.bi_delivereddate.HeaderText = "Delivered Date"
        Me.bi_delivereddate.Name = "bi_delivereddate"
        Me.bi_delivereddate.ReadOnly = True
        '
        'bi_option
        '
        Me.bi_option.HeaderText = ""
        Me.bi_option.Name = "bi_option"
        Me.bi_option.Text = "Delete"
        Me.bi_option.UseColumnTextForButtonValue = True
        Me.bi_option.Width = 50
        '
        'EditBundleItemsAForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(684, 362)
        Me.Controls.Add(Me.chkOtherInfo)
        Me.Controls.Add(Me.lblsavemsg)
        Me.Controls.Add(Me.txtOverallQty)
        Me.Controls.Add(Me.lblOverallQty)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.dgBundleItems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditBundleItemsAForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.dgBundleItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgBundleItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtOverallQty As System.Windows.Forms.TextBox
    Friend WithEvents lblOverallQty As System.Windows.Forms.Label
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents chkOtherInfo As System.Windows.Forms.CheckBox
    Friend WithEvents bi_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_totalqtyorder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtypicked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtydelivered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtyallocated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtyorderable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtyreserve As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_tags As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents bi_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_verifiedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_verifieddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_packedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_packeddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_deliveredby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_delivereddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_option As System.Windows.Forms.DataGridViewButtonColumn
End Class
