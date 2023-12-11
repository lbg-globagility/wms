<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RackShelfColumnSelectorDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gridRackShelfColumn = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabelSeeSample = New System.Windows.Forms.LinkLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        CType(Me.gridRackShelfColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridRackShelfColumn
        '
        Me.gridRackShelfColumn.AllowUserToAddRows = False
        Me.gridRackShelfColumn.AllowUserToDeleteRows = False
        Me.gridRackShelfColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridRackShelfColumn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Quantity, Me.Column14})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridRackShelfColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.gridRackShelfColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRackShelfColumn.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridRackShelfColumn.Location = New System.Drawing.Point(0, 16)
        Me.gridRackShelfColumn.Name = "gridRackShelfColumn"
        Me.gridRackShelfColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridRackShelfColumn.Size = New System.Drawing.Size(757, 327)
        Me.gridRackShelfColumn.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "PickOrderNo"
        Me.Column1.HeaderText = "Pick Order No."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "RackNo"
        Me.Column2.HeaderText = "Rack"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 64
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "ShelfNo"
        Me.Column3.HeaderText = "Shelf"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 64
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "ColumnNo"
        Me.Column4.HeaderText = "Column"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 64
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "AvailableQty"
        Me.Column5.HeaderText = "Available Qty"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "DistributedQty"
        Me.Column6.HeaderText = "Column6"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "ReservedQty"
        Me.Column7.HeaderText = "Reserved Qty"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "DamagedQty"
        Me.Column8.HeaderText = "Column8"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "InRepairQty"
        Me.Column9.HeaderText = "Column9"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "SupplierProblemQty"
        Me.Column10.HeaderText = "Column10"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Visible = False
        '
        'Column11
        '
        Me.Column11.DataPropertyName = "LastShippedToLocDate"
        Me.Column11.HeaderText = "Column11"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Visible = False
        '
        'Column12
        '
        Me.Column12.DataPropertyName = "LastCycleCountDate"
        Me.Column12.HeaderText = "Column12"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Visible = False
        '
        'Column13
        '
        Me.Column13.DataPropertyName = "Remarks"
        Me.Column13.HeaderText = "Remarks"
        Me.Column13.Name = "Column13"
        '
        'Quantity
        '
        '
        '
        '
        Me.Quantity.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Quantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Quantity.DataPropertyName = "Quantity"
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.MinValue = 0
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Quantity.ShowUpDown = True
        '
        'Column14
        '
        Me.Column14.DataPropertyName = "ErrorMessage"
        Me.Column14.HeaderText = ""
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 255
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gridRackShelfColumn)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(757, 343)
        Me.Panel1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.LinkLabelSeeSample)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(757, 16)
        Me.FlowLayoutPanel1.TabIndex = 1
        Me.FlowLayoutPanel1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(569, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NOTE: Quantity to be inputted is based on the difference of the `Correct Quantity" &
    "` and current `Available Qty`."
        '
        'LinkLabelSeeSample
        '
        Me.LinkLabelSeeSample.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelSeeSample.AutoSize = True
        Me.LinkLabelSeeSample.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
        Me.LinkLabelSeeSample.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabelSeeSample.Location = New System.Drawing.Point(578, 0)
        Me.LinkLabelSeeSample.Name = "LinkLabelSeeSample"
        Me.LinkLabelSeeSample.Size = New System.Drawing.Size(73, 13)
        Me.LinkLabelSeeSample.TabIndex = 8
        Me.LinkLabelSeeSample.TabStop = True
        Me.LinkLabelSeeSample.Text = "See example."
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ButtonCancel)
        Me.Panel2.Controls.Add(Me.ButtonOK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 343)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(757, 36)
        Me.Panel2.TabIndex = 1
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(675, 6)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(594, 6)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 0
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'RackShelfColumnSelectorDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(757, 379)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RackShelfColumnSelectorDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.gridRackShelfColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridRackShelfColumn As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents LinkLabelSeeSample As LinkLabel
    Friend WithEvents Label1 As Label
End Class
