<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DeliveryReceiptPrintOptions
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxBasedOnPOnumber = New System.Windows.Forms.CheckBox()
        Me.CheckBoxExcelCopyforDotMatrix = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxDoNotDisplayUOM = New System.Windows.Forms.CheckBox()
        Me.CheckBoxMeterYardWithPrice = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRollWithPrice = New System.Windows.Forms.CheckBox()
        Me.RadioBtnUnitNonRoll = New System.Windows.Forms.RadioButton()
        Me.RadioBtnUnitRoll = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(256, 237)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBoxBasedOnPOnumber)
        Me.GroupBox3.Controls.Add(Me.CheckBoxExcelCopyforDotMatrix)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 128)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(256, 109)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Others"
        '
        'CheckBoxBasedOnPOnumber
        '
        Me.CheckBoxBasedOnPOnumber.AutoSize = True
        Me.CheckBoxBasedOnPOnumber.Location = New System.Drawing.Point(11, 46)
        Me.CheckBoxBasedOnPOnumber.Name = "CheckBoxBasedOnPOnumber"
        Me.CheckBoxBasedOnPOnumber.Size = New System.Drawing.Size(158, 17)
        Me.CheckBoxBasedOnPOnumber.TabIndex = 1
        Me.CheckBoxBasedOnPOnumber.Text = "Print DR based on PO No."
        Me.CheckBoxBasedOnPOnumber.UseVisualStyleBackColor = True
        '
        'CheckBoxExcelCopyforDotMatrix
        '
        Me.CheckBoxExcelCopyforDotMatrix.AutoSize = True
        Me.CheckBoxExcelCopyforDotMatrix.Location = New System.Drawing.Point(11, 22)
        Me.CheckBoxExcelCopyforDotMatrix.Name = "CheckBoxExcelCopyforDotMatrix"
        Me.CheckBoxExcelCopyforDotMatrix.Size = New System.Drawing.Size(160, 17)
        Me.CheckBoxExcelCopyforDotMatrix.TabIndex = 0
        Me.CheckBoxExcelCopyforDotMatrix.Text = "Print a copy for dot-matrix"
        Me.CheckBoxExcelCopyforDotMatrix.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBoxDoNotDisplayUOM)
        Me.GroupBox2.Controls.Add(Me.CheckBoxMeterYardWithPrice)
        Me.GroupBox2.Controls.Add(Me.CheckBoxRollWithPrice)
        Me.GroupBox2.Controls.Add(Me.RadioBtnUnitNonRoll)
        Me.GroupBox2.Controls.Add(Me.RadioBtnUnitRoll)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 128)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Unit of Measure"
        '
        'CheckBoxDoNotDisplayUOM
        '
        Me.CheckBoxDoNotDisplayUOM.AutoSize = True
        Me.CheckBoxDoNotDisplayUOM.Location = New System.Drawing.Point(11, 90)
        Me.CheckBoxDoNotDisplayUOM.Name = "CheckBoxDoNotDisplayUOM"
        Me.CheckBoxDoNotDisplayUOM.Size = New System.Drawing.Size(136, 17)
        Me.CheckBoxDoNotDisplayUOM.TabIndex = 4
        Me.CheckBoxDoNotDisplayUOM.Text = "Do not display UOM?"
        Me.CheckBoxDoNotDisplayUOM.UseVisualStyleBackColor = True
        '
        'CheckBoxMeterYardWithPrice
        '
        Me.CheckBoxMeterYardWithPrice.AutoSize = True
        Me.CheckBoxMeterYardWithPrice.Enabled = False
        Me.CheckBoxMeterYardWithPrice.Location = New System.Drawing.Point(159, 45)
        Me.CheckBoxMeterYardWithPrice.Name = "CheckBoxMeterYardWithPrice"
        Me.CheckBoxMeterYardWithPrice.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxMeterYardWithPrice.TabIndex = 3
        Me.CheckBoxMeterYardWithPrice.Text = "with price?"
        Me.CheckBoxMeterYardWithPrice.UseVisualStyleBackColor = True
        '
        'CheckBoxRollWithPrice
        '
        Me.CheckBoxRollWithPrice.AutoSize = True
        Me.CheckBoxRollWithPrice.Location = New System.Drawing.Point(118, 22)
        Me.CheckBoxRollWithPrice.Name = "CheckBoxRollWithPrice"
        Me.CheckBoxRollWithPrice.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxRollWithPrice.TabIndex = 1
        Me.CheckBoxRollWithPrice.Text = "with price?"
        Me.CheckBoxRollWithPrice.UseVisualStyleBackColor = True
        '
        'RadioBtnUnitNonRoll
        '
        Me.RadioBtnUnitNonRoll.AutoSize = True
        Me.RadioBtnUnitNonRoll.Location = New System.Drawing.Point(11, 44)
        Me.RadioBtnUnitNonRoll.Name = "RadioBtnUnitNonRoll"
        Me.RadioBtnUnitNonRoll.Size = New System.Drawing.Size(142, 17)
        Me.RadioBtnUnitNonRoll.TabIndex = 2
        Me.RadioBtnUnitNonRoll.Text = "Based on `Meter`/`Yard`"
        Me.RadioBtnUnitNonRoll.UseVisualStyleBackColor = True
        '
        'RadioBtnUnitRoll
        '
        Me.RadioBtnUnitRoll.AutoSize = True
        Me.RadioBtnUnitRoll.Checked = True
        Me.RadioBtnUnitRoll.Location = New System.Drawing.Point(11, 21)
        Me.RadioBtnUnitRoll.Name = "RadioBtnUnitRoll"
        Me.RadioBtnUnitRoll.Size = New System.Drawing.Size(101, 17)
        Me.RadioBtnUnitRoll.TabIndex = 0
        Me.RadioBtnUnitRoll.TabStop = True
        Me.RadioBtnUnitRoll.Text = "Based on `Roll`"
        Me.RadioBtnUnitRoll.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ButtonCancel)
        Me.Panel2.Controls.Add(Me.ButtonOK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 237)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(256, 36)
        Me.Panel2.TabIndex = 1
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(169, 6)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "&Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Location = New System.Drawing.Point(88, 6)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 0
        Me.ButtonOK.Text = "O&K"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'DeliveryReceiptPrintOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(256, 273)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DeliveryReceiptPrintOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioBtnUnitRoll As RadioButton
    Friend WithEvents RadioBtnUnitNonRoll As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CheckBoxExcelCopyforDotMatrix As CheckBox
    Friend WithEvents CheckBoxRollWithPrice As CheckBox
    Friend WithEvents CheckBoxMeterYardWithPrice As CheckBox
    Friend WithEvents CheckBoxDoNotDisplayUOM As CheckBox
    Friend WithEvents CheckBoxBasedOnPOnumber As CheckBox
End Class
