<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TikUpdate
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
        Me.GridUpdt = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UplodAtchToolStripitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DonlodAttchToolStripitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.CmbEvent = New System.Windows.Forms.ComboBox()
        Me.TxtUpdt = New System.Windows.Forms.TextBox()
        Me.BtnSubmt = New System.Windows.Forms.Button()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.TimerEscOpen = New System.Windows.Forms.Timer(Me.components)
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TxtBrws = New System.Windows.Forms.TextBox()
        CType(Me.GridUpdt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridUpdt
        '
        Me.GridUpdt.AllowUserToAddRows = False
        Me.GridUpdt.AllowUserToDeleteRows = False
        Me.GridUpdt.BackgroundColor = System.Drawing.Color.White
        Me.GridUpdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridUpdt.ContextMenuStrip = Me.ContextMenuStrip2
        Me.FlowLayoutPanel1.SetFlowBreak(Me.GridUpdt, True)
        Me.GridUpdt.Location = New System.Drawing.Point(540, 0)
        Me.GridUpdt.Margin = New System.Windows.Forms.Padding(0)
        Me.GridUpdt.MultiSelect = False
        Me.GridUpdt.Name = "GridUpdt"
        Me.GridUpdt.ReadOnly = True
        Me.GridUpdt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridUpdt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridUpdt.Size = New System.Drawing.Size(719, 356)
        Me.GridUpdt.TabIndex = 2057
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripitem, Me.UplodAtchToolStripitem, Me.DonlodAttchToolStripitem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(185, 70)
        '
        'CopyToolStripitem
        '
        Me.CopyToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.CopyToolStripitem.Image = Global.VOCAPlus.My.Resources.Resources.Copy
        Me.CopyToolStripitem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CopyToolStripitem.Name = "CopyToolStripitem"
        Me.CopyToolStripitem.RightToLeftAutoMirrorImage = True
        Me.CopyToolStripitem.Size = New System.Drawing.Size(184, 22)
        Me.CopyToolStripitem.Text = "Copy Selected Cell"
        '
        'UplodAtchToolStripitem
        '
        Me.UplodAtchToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.UplodAtchToolStripitem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.UplodAtchToolStripitem.Image = Global.VOCAPlus.My.Resources.Resources.upload_1
        Me.UplodAtchToolStripitem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UplodAtchToolStripitem.Name = "UplodAtchToolStripitem"
        Me.UplodAtchToolStripitem.RightToLeftAutoMirrorImage = True
        Me.UplodAtchToolStripitem.Size = New System.Drawing.Size(184, 22)
        Me.UplodAtchToolStripitem.Text = "Upload Attachement"
        Me.UplodAtchToolStripitem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DonlodAttchToolStripitem
        '
        Me.DonlodAttchToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.DonlodAttchToolStripitem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.DonlodAttchToolStripitem.Image = Global.VOCAPlus.My.Resources.Resources.Download
        Me.DonlodAttchToolStripitem.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.DonlodAttchToolStripitem.Name = "DonlodAttchToolStripitem"
        Me.DonlodAttchToolStripitem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DonlodAttchToolStripitem.RightToLeftAutoMirrorImage = True
        Me.DonlodAttchToolStripitem.Size = New System.Drawing.Size(184, 22)
        Me.DonlodAttchToolStripitem.Text = "Download attached"
        Me.DonlodAttchToolStripitem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label60
        '
        Me.Label60.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label60.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label60.Location = New System.Drawing.Point(908, 14)
        Me.Label60.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.Label60.Name = "Label60"
        Me.Label60.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label60.Size = New System.Drawing.Size(97, 23)
        Me.Label60.TabIndex = 2055
        Me.Label60.Text = "إضافة تحديث:"
        '
        'CmbEvent
        '
        Me.CmbEvent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FlowLayoutPanel2.SetFlowBreak(Me.CmbEvent, True)
        Me.CmbEvent.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.CmbEvent.FormattingEnabled = True
        Me.CmbEvent.Location = New System.Drawing.Point(744, 10)
        Me.CmbEvent.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.CmbEvent.Name = "CmbEvent"
        Me.CmbEvent.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbEvent.Size = New System.Drawing.Size(164, 27)
        Me.CmbEvent.TabIndex = 2056
        '
        'TxtUpdt
        '
        Me.TxtUpdt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUpdt.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.TxtUpdt.Location = New System.Drawing.Point(171, 40)
        Me.TxtUpdt.Multiline = True
        Me.TxtUpdt.Name = "TxtUpdt"
        Me.TxtUpdt.ReadOnly = True
        Me.TxtUpdt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtUpdt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtUpdt.Size = New System.Drawing.Size(831, 146)
        Me.TxtUpdt.TabIndex = 2054
        '
        'BtnSubmt
        '
        Me.BtnSubmt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSubmt.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtnSubmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSubmt.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnSubmt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnSubmt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.BtnSubmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSubmt.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSubmt.Location = New System.Drawing.Point(14, 5)
        Me.BtnSubmt.Margin = New System.Windows.Forms.Padding(3, 65, 3, 3)
        Me.BtnSubmt.Name = "BtnSubmt"
        Me.BtnSubmt.Size = New System.Drawing.Size(92, 40)
        Me.BtnSubmt.TabIndex = 2059
        Me.BtnSubmt.Text = "تسجيل"
        Me.BtnSubmt.UseVisualStyleBackColor = True
        '
        'LblMsg
        '
        Me.LblMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblMsg.Location = New System.Drawing.Point(0, 665)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(1259, 33)
        Me.LblMsg.TabIndex = 2160
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerEscOpen
        '
        Me.TimerEscOpen.Interval = 1000
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label60)
        Me.FlowLayoutPanel2.Controls.Add(Me.CmbEvent)
        Me.FlowLayoutPanel2.Controls.Add(Me.TxtUpdt)
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel2.Controls.Add(Me.TxtBrws)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(251, 359)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(1005, 266)
        Me.FlowLayoutPanel2.TabIndex = 2161
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.BtnSubmt)
        Me.Panel1.Location = New System.Drawing.Point(40, 135)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 98, 3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(125, 51)
        Me.Panel1.TabIndex = 2160
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.GridUpdt)
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1259, 665)
        Me.FlowLayoutPanel1.TabIndex = 2162
        '
        'TxtBrws
        '
        Me.TxtBrws.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBrws.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtBrws.Location = New System.Drawing.Point(875, 192)
        Me.TxtBrws.Name = "TxtBrws"
        Me.TxtBrws.ReadOnly = True
        Me.TxtBrws.Size = New System.Drawing.Size(127, 26)
        Me.TxtBrws.TabIndex = 2159
        Me.TxtBrws.Visible = False
        '
        'TikUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1259, 698)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.LblMsg)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Location = New System.Drawing.Point(0, 52)
        Me.Name = "TikUpdate"
        Me.Text = "TikUpdate"
        CType(Me.GridUpdt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridUpdt As DataGridView
    Friend WithEvents Label60 As Label
    Friend WithEvents CmbEvent As ComboBox
    Friend WithEvents TxtUpdt As TextBox
    Friend WithEvents BtnSubmt As Button
    Friend WithEvents LblMsg As Label
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents CopyToolStripitem As ToolStripMenuItem
    Friend WithEvents UplodAtchToolStripitem As ToolStripMenuItem
    Friend WithEvents DonlodAttchToolStripitem As ToolStripMenuItem
    Friend WithEvents TimerEscOpen As Timer
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtBrws As TextBox
End Class
