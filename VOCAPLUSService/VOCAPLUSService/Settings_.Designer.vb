<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings_
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.BtnSbmt = New System.Windows.Forms.Button()
        Me.TimeStrt = New System.Windows.Forms.DateTimePicker()
        Me.TimeEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ACBEnd = New System.Windows.Forms.DateTimePicker()
        Me.ACBStrt = New System.Windows.Forms.DateTimePicker()
        Me.Min_ = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me._Cc = New System.Windows.Forms.TextBox()
        Me._To = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(150, 66)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(338, 29)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(150, 103)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(338, 29)
        Me.TextBox2.TabIndex = 1
        '
        'BtnSbmt
        '
        Me.BtnSbmt.Location = New System.Drawing.Point(447, 415)
        Me.BtnSbmt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.BtnSbmt.Name = "BtnSbmt"
        Me.BtnSbmt.Size = New System.Drawing.Size(125, 38)
        Me.BtnSbmt.TabIndex = 2
        Me.BtnSbmt.Text = "Submit"
        Me.BtnSbmt.UseVisualStyleBackColor = True
        '
        'TimeStrt
        '
        Me.TimeStrt.CustomFormat = "hh:mm tt"
        Me.TimeStrt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TimeStrt.Location = New System.Drawing.Point(188, 326)
        Me.TimeStrt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TimeStrt.Name = "TimeStrt"
        Me.TimeStrt.ShowUpDown = True
        Me.TimeStrt.Size = New System.Drawing.Size(100, 29)
        Me.TimeStrt.TabIndex = 3
        '
        'TimeEnd
        '
        Me.TimeEnd.CustomFormat = "hh:mm tt"
        Me.TimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TimeEnd.Location = New System.Drawing.Point(298, 326)
        Me.TimeEnd.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TimeEnd.Name = "TimeEnd"
        Me.TimeEnd.ShowUpDown = True
        Me.TimeEnd.Size = New System.Drawing.Size(100, 29)
        Me.TimeEnd.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 330)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 21)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Working Day:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 372)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 21)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ACB:"
        '
        'ACBEnd
        '
        Me.ACBEnd.CustomFormat = "hh:mm tt"
        Me.ACBEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ACBEnd.Location = New System.Drawing.Point(298, 368)
        Me.ACBEnd.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ACBEnd.Name = "ACBEnd"
        Me.ACBEnd.ShowUpDown = True
        Me.ACBEnd.Size = New System.Drawing.Size(100, 29)
        Me.ACBEnd.TabIndex = 7
        '
        'ACBStrt
        '
        Me.ACBStrt.CustomFormat = "hh:mm tt"
        Me.ACBStrt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ACBStrt.Location = New System.Drawing.Point(188, 368)
        Me.ACBStrt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ACBStrt.Name = "ACBStrt"
        Me.ACBStrt.ShowUpDown = True
        Me.ACBStrt.Size = New System.Drawing.Size(100, 29)
        Me.ACBStrt.TabIndex = 6
        '
        'Min_
        '
        Me.Min_.CustomFormat = "mm"
        Me.Min_.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Min_.Location = New System.Drawing.Point(298, 415)
        Me.Min_.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Min_.Name = "Min_"
        Me.Min_.ShowUpDown = True
        Me.Min_.Size = New System.Drawing.Size(60, 29)
        Me.Min_.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 108)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 21)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(61, 66)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 21)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Mail:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(109, 246)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 21)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Cc:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(110, 162)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 21)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "To:"
        '
        '_Cc
        '
        Me._Cc.Location = New System.Drawing.Point(150, 224)
        Me._Cc.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me._Cc.Multiline = True
        Me._Cc.Name = "_Cc"
        Me._Cc.Size = New System.Drawing.Size(767, 71)
        Me._Cc.TabIndex = 13
        '
        '_To
        '
        Me._To.Location = New System.Drawing.Point(150, 140)
        Me._To.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me._To.Multiline = True
        Me._To.Name = "_To"
        Me._To.Size = New System.Drawing.Size(767, 76)
        Me._To.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(0, 140)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 21)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Event contacts"
        '
        'Settings_
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 466)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me._Cc)
        Me.Controls.Add(Me._To)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Min_)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ACBEnd)
        Me.Controls.Add(Me.ACBStrt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TimeEnd)
        Me.Controls.Add(Me.TimeStrt)
        Me.Controls.Add(Me.BtnSbmt)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "Settings_"
        Me.Text = "Settings_"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents BtnSbmt As Button
    Friend WithEvents TimeStrt As DateTimePicker
    Friend WithEvents TimeEnd As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ACBEnd As DateTimePicker
    Friend WithEvents ACBStrt As DateTimePicker
    Friend WithEvents Min_ As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents _Cc As TextBox
    Friend WithEvents _To As TextBox
    Friend WithEvents Label7 As Label
End Class
