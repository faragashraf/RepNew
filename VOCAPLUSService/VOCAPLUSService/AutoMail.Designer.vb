<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoMail
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerSecnods = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblTimer = New System.Windows.Forms.Label()
        Me.STR_ = New System.Windows.Forms.TextBox()
        Me.TO_ = New System.Windows.Forms.TextBox()
        Me.CC_ = New System.Windows.Forms.TextBox()
        Me.SUB_ = New System.Windows.Forms.TextBox()
        Me.BODY_ = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 306)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1330, 462)
        Me.DataGridView1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'TimerSecnods
        '
        Me.TimerSecnods.Enabled = True
        Me.TimerSecnods.Interval = 1000
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.FlowLayoutPanel1.SetFlowBreak(Me.Label1, True)
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(149, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 19)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Label19"
        '
        'LblTimer
        '
        Me.LblTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTimer.AutoSize = True
        Me.LblTimer.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LblTimer.ForeColor = System.Drawing.Color.Red
        Me.LblTimer.Location = New System.Drawing.Point(84, 0)
        Me.LblTimer.Name = "LblTimer"
        Me.LblTimer.Size = New System.Drawing.Size(59, 19)
        Me.LblTimer.TabIndex = 94
        Me.LblTimer.Text = "Label19"
        '
        'STR_
        '
        Me.FlowLayoutPanel1.SetFlowBreak(Me.STR_, True)
        Me.STR_.Location = New System.Drawing.Point(3, 32)
        Me.STR_.Multiline = True
        Me.STR_.Name = "STR_"
        Me.STR_.Size = New System.Drawing.Size(923, 125)
        Me.STR_.TabIndex = 96
        '
        'TO_
        '
        Me.FlowLayoutPanel1.SetFlowBreak(Me.TO_, True)
        Me.TO_.Location = New System.Drawing.Point(88, 163)
        Me.TO_.Multiline = True
        Me.TO_.Name = "TO_"
        Me.TO_.Size = New System.Drawing.Size(391, 54)
        Me.TO_.TabIndex = 97
        '
        'CC_
        '
        Me.CC_.Location = New System.Drawing.Point(88, 223)
        Me.CC_.Multiline = True
        Me.CC_.Name = "CC_"
        Me.CC_.Size = New System.Drawing.Size(391, 54)
        Me.CC_.TabIndex = 98
        Me.CC_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SUB_
        '
        Me.SUB_.Location = New System.Drawing.Point(485, 223)
        Me.SUB_.Multiline = True
        Me.SUB_.Name = "SUB_"
        Me.SUB_.Size = New System.Drawing.Size(212, 54)
        Me.SUB_.TabIndex = 99
        Me.SUB_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BODY_
        '
        Me.BODY_.Location = New System.Drawing.Point(703, 223)
        Me.BODY_.Multiline = True
        Me.BODY_.Name = "BODY_"
        Me.BODY_.Size = New System.Drawing.Size(212, 54)
        Me.BODY_.TabIndex = 100
        Me.BODY_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(1018, 223)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox1.TabIndex = 101
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(1103, 223)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 102
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "HH:mm tt"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(921, 223)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(91, 20)
        Me.DateTimePicker1.TabIndex = 103
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(3, 163)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox2.TabIndex = 104
        Me.CheckBox2.Text = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(3, 223)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox3.TabIndex = 105
        Me.CheckBox3.Text = "CheckBox3"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Controls.Add(Me.LblTimer)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.STR_)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.TO_)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.CC_)
        Me.FlowLayoutPanel1.Controls.Add(Me.SUB_)
        Me.FlowLayoutPanel1.Controls.Add(Me.BODY_)
        Me.FlowLayoutPanel1.Controls.Add(Me.DateTimePicker1)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox4)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox5)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox6)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox7)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox8)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox9)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox10)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox11)
        Me.FlowLayoutPanel1.Controls.Add(Me.DataGridView1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1340, 802)
        Me.FlowLayoutPanel1.TabIndex = 106
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(1230, 223)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox4.TabIndex = 106
        Me.CheckBox4.Text = "CheckBox4"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(3, 283)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(49, 17)
        Me.CheckBox5.TabIndex = 107
        Me.CheckBox5.Text = "الأحد"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(58, 283)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(55, 17)
        Me.CheckBox6.TabIndex = 108
        Me.CheckBox6.Text = "الأثنين"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(119, 283)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(54, 17)
        Me.CheckBox7.TabIndex = 109
        Me.CheckBox7.Text = "الثلاثاء"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(179, 283)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox8.TabIndex = 110
        Me.CheckBox8.Text = "الأربعاء"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(241, 283)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(64, 17)
        Me.CheckBox9.TabIndex = 111
        Me.CheckBox9.Text = "الخميس"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(311, 283)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(58, 17)
        Me.CheckBox10.TabIndex = 112
        Me.CheckBox10.Text = "الجمعة"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(375, 283)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(58, 17)
        Me.CheckBox11.TabIndex = 113
        Me.CheckBox11.Text = "السبت"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'AutoMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1340, 802)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "AutoMail"
        Me.Text = "AutoMail"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TimerSecnods As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents LblTimer As Label
    Friend WithEvents STR_ As TextBox
    Friend WithEvents TO_ As TextBox
    Friend WithEvents CC_ As TextBox
    Friend WithEvents SUB_ As TextBox
    Friend WithEvents BODY_ As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox7 As CheckBox
    Friend WithEvents CheckBox8 As CheckBox
    Friend WithEvents CheckBox9 As CheckBox
    Friend WithEvents CheckBox10 As CheckBox
    Friend WithEvents CheckBox11 As CheckBox
End Class
