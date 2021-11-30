<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TikSearchNew
    Inherits System.Windows.Forms.Form

    'Form Overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TikSearchNew))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Rdiocls = New System.Windows.Forms.RadioButton()
        Me.RdioOpen = New System.Windows.Forms.RadioButton()
        Me.RdioAll = New System.Windows.Forms.RadioButton()
        Me.FilterComb = New System.Windows.Forms.ComboBox()
        Me.SerchTxt = New System.Windows.Forms.TextBox()
        Me.BtnSerch = New System.Windows.Forms.Button()
        Me.GridTicket = New System.Windows.Forms.DataGridView()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BtnCncl = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'RadioButton3
        '
        resources.ApplyResources(Me.RadioButton3, "RadioButton3")
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        resources.ApplyResources(Me.RadioButton2, "RadioButton2")
        Me.RadioButton2.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Rdiocls)
        Me.GroupBox2.Controls.Add(Me.RdioOpen)
        Me.GroupBox2.Controls.Add(Me.RdioAll)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Rdiocls
        '
        resources.ApplyResources(Me.Rdiocls, "Rdiocls")
        Me.Rdiocls.Cursor = System.Windows.Forms.Cursors.Default
        Me.Rdiocls.Name = "Rdiocls"
        Me.Rdiocls.UseVisualStyleBackColor = True
        '
        'RdioOpen
        '
        resources.ApplyResources(Me.RdioOpen, "RdioOpen")
        Me.RdioOpen.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioOpen.Name = "RdioOpen"
        Me.RdioOpen.UseVisualStyleBackColor = True
        '
        'RdioAll
        '
        resources.ApplyResources(Me.RdioAll, "RdioAll")
        Me.RdioAll.Checked = True
        Me.RdioAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioAll.Name = "RdioAll"
        Me.RdioAll.TabStop = True
        Me.RdioAll.UseVisualStyleBackColor = True
        '
        'FilterComb
        '
        Me.FilterComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.FilterComb, "FilterComb")
        Me.FilterComb.FormattingEnabled = True
        Me.FilterComb.Name = "FilterComb"
        '
        'SerchTxt
        '
        resources.ApplyResources(Me.SerchTxt, "SerchTxt")
        Me.SerchTxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SerchTxt.Name = "SerchTxt"
        '
        'BtnSerch
        '
        Me.BtnSerch.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recblue
        resources.ApplyResources(Me.BtnSerch, "BtnSerch")
        Me.BtnSerch.FlatAppearance.BorderSize = 0
        Me.BtnSerch.Name = "BtnSerch"
        Me.BtnSerch.UseVisualStyleBackColor = True
        '
        'GridTicket
        '
        Me.GridTicket.AllowUserToAddRows = False
        Me.GridTicket.AllowUserToDeleteRows = False
        Me.GridTicket.BackgroundColor = System.Drawing.Color.White
        Me.GridTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.GridTicket, "GridTicket")
        Me.GridTicket.MultiSelect = False
        Me.GridTicket.Name = "GridTicket"
        Me.GridTicket.ReadOnly = True
        Me.GridTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        '
        'LblMsg
        '
        resources.ApplyResources(Me.LblMsg, "LblMsg")
        Me.LblMsg.Name = "LblMsg"
        '
        'CloseBtn
        '
        resources.ApplyResources(Me.CloseBtn, "CloseBtn")
        Me.CloseBtn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Exit1
        Me.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CloseBtn.FlatAppearance.BorderSize = 0
        Me.CloseBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'ProgressBar1
        '
        resources.ApplyResources(Me.ProgressBar1, "ProgressBar1")
        Me.ProgressBar1.Name = "ProgressBar1"
        '
        'BtnCncl
        '
        Me.BtnCncl.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgrey
        resources.ApplyResources(Me.BtnCncl, "BtnCncl")
        Me.BtnCncl.FlatAppearance.BorderSize = 0
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'TikSearchNew
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.GridTicket)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SerchTxt)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnSerch)
        Me.Controls.Add(Me.FilterComb)
        Me.Controls.Add(Me.Label2)
        Me.Name = "TikSearchNew"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents GridTicket As DataGridView
    Friend WithEvents FilterComb As ComboBox
    Friend WithEvents SerchTxt As TextBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RdioAll As RadioButton
    Friend WithEvents Rdiocls As RadioButton
    Friend WithEvents RdioOpen As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblMsg As Label
    Friend WithEvents BtnSerch As Button
    Friend WithEvents CloseBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents BtnCncl As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
