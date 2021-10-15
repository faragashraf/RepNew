<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EventMail
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
        Me.components = New System.ComponentModel.Container()
        Me.BtnAbort = New System.Windows.Forms.Button()
        Me.TimerSecnods = New System.Windows.Forms.Timer(Me.components)
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtErr = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BtnAbort
        '
        Me.BtnAbort.Location = New System.Drawing.Point(52, 85)
        Me.BtnAbort.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnAbort.Name = "BtnAbort"
        Me.BtnAbort.Size = New System.Drawing.Size(210, 44)
        Me.BtnAbort.TabIndex = 70
        Me.BtnAbort.Text = "Settings"
        Me.BtnAbort.UseVisualStyleBackColor = True
        '
        'TimerSecnods
        '
        Me.TimerSecnods.Enabled = True
        Me.TimerSecnods.Interval = 1000
        '
        'CheckBox1
        '
        Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.White
        Me.CheckBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime
        Me.CheckBox1.Location = New System.Drawing.Point(318, 85)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(68, 37)
        Me.CheckBox1.TabIndex = 94
        Me.CheckBox1.Text = "Start"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(417, 94)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(196, 33)
        Me.TextBox1.TabIndex = 95
        '
        'CheckBox2
        '
        Me.CheckBox2.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.White
        Me.CheckBox2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime
        Me.CheckBox2.Location = New System.Drawing.Point(298, 127)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(6)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(107, 37)
        Me.CheckBox2.TabIndex = 96
        Me.CheckBox2.Text = "Continue"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(445, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 25)
        Me.Label1.TabIndex = 97
        '
        'TxtErr
        '
        Me.TxtErr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtErr.Location = New System.Drawing.Point(750, 15)
        Me.TxtErr.Margin = New System.Windows.Forms.Padding(6)
        Me.TxtErr.Multiline = True
        Me.TxtErr.Name = "TxtErr"
        Me.TxtErr.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtErr.Size = New System.Drawing.Size(519, 366)
        Me.TxtErr.TabIndex = 98
        '
        'EventMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1284, 622)
        Me.Controls.Add(Me.TxtErr)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.BtnAbort)
        Me.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "EventMail"
        Me.RightToLeftLayout = True
        Me.Text = "VOCAPlusService"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnAbort As Button
    Friend WithEvents TimerSecnods As Timer
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtErr As TextBox
End Class
