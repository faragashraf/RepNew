<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCategories
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCategories))
        Me.UserTree = New System.Windows.Forms.TreeView()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TreeSrchBx = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnSerch = New System.Windows.Forms.Button()
        Me.BtnNxt = New System.Windows.Forms.Button()
        Me.LblCnt = New System.Windows.Forms.Label()
        Me.BtnPrvs = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UserTree
        '
        Me.UserTree.AllowDrop = True
        Me.UserTree.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.UserTree, "UserTree")
        Me.UserTree.Name = "UserTree"
        Me.UserTree.ShowLines = False
        Me.UserTree.ShowPlusMinus = False
        Me.UserTree.TabStop = False
        '
        'ImgLst
        '
        Me.ImgLst.ImageStream = CType(resources.GetObject("ImgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLst.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLst.Images.SetKeyName(0, "Arrow - Right (5).ico")
        Me.ImgLst.Images.SetKeyName(1, "Arrow - Right (4).ico")
        Me.ImgLst.Images.SetKeyName(2, "arrow-right-3.png")
        Me.ImgLst.Images.SetKeyName(3, "arrow-right-double-3.png")
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.UserTree)
        resources.ApplyResources(Me.FlowLayoutPanel1, "FlowLayoutPanel1")
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel2.Controls.Add(Me.TreeSrchBx)
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel2.Controls.Add(Me.LblCnt)
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label4)
        resources.ApplyResources(Me.FlowLayoutPanel2, "FlowLayoutPanel2")
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        '
        'TreeSrchBx
        '
        Me.TreeSrchBx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.TreeSrchBx, "TreeSrchBx")
        Me.TreeSrchBx.Name = "TreeSrchBx"
        Me.TreeSrchBx.TabStop = False
        Me.TreeSrchBx.Tag = "اسم العميل"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.BtnSerch)
        Me.FlowLayoutPanel2.SetFlowBreak(Me.Panel3, True)
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Name = "Panel3"
        '
        'BtnSerch
        '
        Me.BtnSerch.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        resources.ApplyResources(Me.BtnSerch, "BtnSerch")
        Me.BtnSerch.FlatAppearance.BorderSize = 0
        Me.BtnSerch.Name = "BtnSerch"
        Me.BtnSerch.UseVisualStyleBackColor = True
        '
        'BtnNxt
        '
        Me.BtnNxt.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Next
        resources.ApplyResources(Me.BtnNxt, "BtnNxt")
        Me.BtnNxt.FlatAppearance.BorderSize = 0
        Me.BtnNxt.Name = "BtnNxt"
        Me.BtnNxt.UseVisualStyleBackColor = True
        '
        'LblCnt
        '
        resources.ApplyResources(Me.LblCnt, "LblCnt")
        Me.LblCnt.Name = "LblCnt"
        '
        'BtnPrvs
        '
        Me.BtnPrvs.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Prev
        resources.ApplyResources(Me.BtnPrvs, "BtnPrvs")
        Me.BtnPrvs.FlatAppearance.BorderSize = 0
        Me.BtnPrvs.Name = "BtnPrvs"
        Me.BtnPrvs.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.FlowLayoutPanel2.SetFlowBreak(Me.Label4, True)
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Name = "Label4"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.BtnNxt)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.BtnPrvs)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'UCategories
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "UCategories"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UserTree As TreeView
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents TreeSrchBx As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnSerch As Button
    Friend WithEvents BtnNxt As Button
    Friend WithEvents LblCnt As Label
    Friend WithEvents BtnPrvs As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
