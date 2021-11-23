<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TikNew
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rooting")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TikNew))
        Me.FlwMain = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlwTree = New System.Windows.Forms.FlowLayoutPanel()
        Me.MyGroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.FlwSubMain = New System.Windows.Forms.FlowLayoutPanel()
        Me.ComRefLbl = New System.Windows.Forms.TextBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.FlwMainData = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.IDTxtBx = New System.Windows.Forms.MaskedTextBox()
        Me.RadNID = New System.Windows.Forms.RadioButton()
        Me.RadPss = New System.Windows.Forms.RadioButton()
        Me.MyGroupBox2 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.RadioButton9 = New System.Windows.Forms.RadioButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Phon1TxtBx = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTxtBx = New System.Windows.Forms.TextBox()
        Me.MyGroupBox1 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.RadioButton11 = New System.Windows.Forms.RadioButton()
        Me.RadioButton12 = New System.Windows.Forms.RadioButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Phon2TxtBx = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.NameTxtBx = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.MailTxtBx = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SrcCmbBx = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Prdct = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Comp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AddTxtBx = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DetailsTxtBx = New System.Windows.Forms.TextBox()
        Me.FlwMend = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.BtnClr = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.NewBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SubmitBtn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnDublicate = New System.Windows.Forms.Button()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.TimrPhons = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FlwMain.SuspendLayout()
        Me.FlwTree.SuspendLayout()
        Me.MyGroupBox3.SuspendLayout()
        Me.FlwSubMain.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.FlwMainData.SuspendLayout()
        Me.MyGroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MyGroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlwMain
        '
        Me.FlwMain.AutoScroll = True
        Me.FlwMain.Controls.Add(Me.FlwTree)
        Me.FlwMain.Controls.Add(Me.FlwSubMain)
        Me.FlwMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlwMain.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlwMain.Location = New System.Drawing.Point(0, 0)
        Me.FlwMain.Name = "FlwMain"
        Me.FlwMain.Size = New System.Drawing.Size(1796, 847)
        Me.FlwMain.TabIndex = 0
        '
        'FlwTree
        '
        Me.FlwTree.AutoScroll = True
        Me.FlwTree.Controls.Add(Me.MyGroupBox3)
        Me.FlwTree.Controls.Add(Me.TreeView1)
        Me.FlwTree.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlwTree.Location = New System.Drawing.Point(1372, 3)
        Me.FlwTree.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.FlwTree.Name = "FlwTree"
        Me.FlwTree.Size = New System.Drawing.Size(414, 744)
        Me.FlwTree.TabIndex = 0
        '
        'MyGroupBox3
        '
        Me.MyGroupBox3.Controls.Add(Me.RadioButton4)
        Me.MyGroupBox3.Controls.Add(Me.RadioButton5)
        Me.MyGroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.MyGroupBox3.Location = New System.Drawing.Point(228, 3)
        Me.MyGroupBox3.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.MyGroupBox3.Name = "MyGroupBox3"
        Me.MyGroupBox3.Size = New System.Drawing.Size(176, 42)
        Me.MyGroupBox3.TabIndex = 2021
        Me.MyGroupBox3.TabStop = False
        '
        'RadioButton4
        '
        Me.RadioButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton4.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RadioButton4.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton4.Enabled = False
        Me.RadioButton4.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RadioButton4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadioButton4.Location = New System.Drawing.Point(89, 12)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioButton4.Size = New System.Drawing.Size(75, 22)
        Me.RadioButton4.TabIndex = 500
        Me.RadioButton4.Text = "طلب"
        Me.RadioButton4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton5.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RadioButton5.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton5.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RadioButton5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadioButton5.Location = New System.Drawing.Point(15, 12)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioButton5.Size = New System.Drawing.Size(65, 22)
        Me.RadioButton5.TabIndex = 501
        Me.RadioButton5.Text = "شكوى"
        Me.RadioButton5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TreeView1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TreeView1.ImageKey = "Add.ico"
        Me.TreeView1.Location = New System.Drawing.Point(11, 51)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        TreeNode1.ForeColor = System.Drawing.Color.Red
        TreeNode1.Name = "Rooting"
        TreeNode1.Text = "Rooting"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TreeView1.RightToLeftLayout = True
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.Size = New System.Drawing.Size(400, 679)
        Me.TreeView1.TabIndex = 2022
        Me.TreeView1.Tag = "نوع الخدمة & نوع الشكوى"
        '
        'FlwSubMain
        '
        Me.FlwSubMain.AutoScroll = True
        Me.FlwSubMain.Controls.Add(Me.ComRefLbl)
        Me.FlwSubMain.Controls.Add(Me.TabControl2)
        Me.FlwSubMain.Controls.Add(Me.FlwMend)
        Me.FlwSubMain.Controls.Add(Me.Panel6)
        Me.FlwSubMain.Controls.Add(Me.Panel5)
        Me.FlwSubMain.Controls.Add(Me.FlowLayoutPanel5)
        Me.FlwSubMain.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlwSubMain.Location = New System.Drawing.Point(106, 3)
        Me.FlwSubMain.Name = "FlwSubMain"
        Me.FlwSubMain.Size = New System.Drawing.Size(1260, 744)
        Me.FlwSubMain.TabIndex = 2034
        '
        'ComRefLbl
        '
        Me.ComRefLbl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FlwSubMain.SetFlowBreak(Me.ComRefLbl, True)
        Me.ComRefLbl.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.ComRefLbl.Location = New System.Drawing.Point(31, 3)
        Me.ComRefLbl.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.ComRefLbl.Name = "ComRefLbl"
        Me.ComRefLbl.ReadOnly = True
        Me.ComRefLbl.Size = New System.Drawing.Size(1192, 25)
        Me.ComRefLbl.TabIndex = 2034
        Me.ComRefLbl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.TabControl2.Location = New System.Drawing.Point(41, 34)
        Me.TabControl2.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl2.RightToLeftLayout = True
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1182, 528)
        Me.TabControl2.TabIndex = 2033
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.FlwMainData)
        Me.TabPage3.Location = New System.Drawing.Point(4, 32)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1174, 492)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "البيانات الأساسية"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'FlwMainData
        '
        Me.FlwMainData.AutoScroll = True
        Me.FlwMainData.Controls.Add(Me.Label11)
        Me.FlwMainData.Controls.Add(Me.Label29)
        Me.FlwMainData.Controls.Add(Me.IDTxtBx)
        Me.FlwMainData.Controls.Add(Me.RadNID)
        Me.FlwMainData.Controls.Add(Me.RadPss)
        Me.FlwMainData.Controls.Add(Me.MyGroupBox2)
        Me.FlwMainData.Controls.Add(Me.Label20)
        Me.FlwMainData.Controls.Add(Me.Phon1TxtBx)
        Me.FlwMainData.Controls.Add(Me.Label1)
        Me.FlwMainData.Controls.Add(Me.DateTxtBx)
        Me.FlwMainData.Controls.Add(Me.MyGroupBox1)
        Me.FlwMainData.Controls.Add(Me.Label22)
        Me.FlwMainData.Controls.Add(Me.Phon2TxtBx)
        Me.FlwMainData.Controls.Add(Me.Label2)
        Me.FlwMainData.Controls.Add(Me.Label21)
        Me.FlwMainData.Controls.Add(Me.NameTxtBx)
        Me.FlwMainData.Controls.Add(Me.Label15)
        Me.FlwMainData.Controls.Add(Me.MailTxtBx)
        Me.FlwMainData.Controls.Add(Me.Label16)
        Me.FlwMainData.Controls.Add(Me.Label7)
        Me.FlwMainData.Controls.Add(Me.SrcCmbBx)
        Me.FlwMainData.Controls.Add(Me.Label4)
        Me.FlwMainData.Controls.Add(Me.Label24)
        Me.FlwMainData.Controls.Add(Me.Prdct)
        Me.FlwMainData.Controls.Add(Me.Label5)
        Me.FlwMainData.Controls.Add(Me.Comp)
        Me.FlwMainData.Controls.Add(Me.Label3)
        Me.FlwMainData.Controls.Add(Me.AddTxtBx)
        Me.FlwMainData.Controls.Add(Me.Label6)
        Me.FlwMainData.Controls.Add(Me.DetailsTxtBx)
        Me.FlwMainData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlwMainData.Location = New System.Drawing.Point(3, 3)
        Me.FlwMainData.Name = "FlwMainData"
        Me.FlwMainData.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FlwMainData.Size = New System.Drawing.Size(1168, 486)
        Me.FlwMainData.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(959, 3)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label11.Size = New System.Drawing.Size(206, 34)
        Me.Label11.TabIndex = 1010
        Me.Label11.Text = "الرقم القومي :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(925, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label29.Size = New System.Drawing.Size(28, 30)
        Me.Label29.TabIndex = 2010
        Me.Label29.Text = "*"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IDTxtBx
        '
        Me.IDTxtBx.AccessibleName = ""
        Me.IDTxtBx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IDTxtBx.Location = New System.Drawing.Point(633, 0)
        Me.IDTxtBx.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.IDTxtBx.Mask = "AAAAAAAAAAAAA"
        Me.IDTxtBx.Name = "IDTxtBx"
        Me.IDTxtBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.IDTxtBx.Size = New System.Drawing.Size(286, 32)
        Me.IDTxtBx.TabIndex = 9
        Me.IDTxtBx.Tag = "English-Number"
        '
        'RadNID
        '
        Me.RadNID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadNID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RadNID.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadNID.Location = New System.Drawing.Point(525, 0)
        Me.RadNID.Margin = New System.Windows.Forms.Padding(0)
        Me.RadNID.Name = "RadNID"
        Me.RadNID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadNID.Size = New System.Drawing.Size(105, 38)
        Me.RadNID.TabIndex = 504
        Me.RadNID.Text = "رقم قومي"
        Me.RadNID.UseVisualStyleBackColor = True
        '
        'RadPss
        '
        Me.RadPss.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadPss.Cursor = System.Windows.Forms.Cursors.Default
        Me.FlwMainData.SetFlowBreak(Me.RadPss, True)
        Me.RadPss.Location = New System.Drawing.Point(309, 0)
        Me.RadPss.Margin = New System.Windows.Forms.Padding(0)
        Me.RadPss.Name = "RadPss"
        Me.RadPss.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadPss.Size = New System.Drawing.Size(216, 38)
        Me.RadPss.TabIndex = 505
        Me.RadPss.TabStop = True
        Me.RadPss.Text = "جواز سفر"
        Me.RadPss.UseVisualStyleBackColor = True
        '
        'MyGroupBox2
        '
        Me.MyGroupBox2.Controls.Add(Me.PictureBox2)
        Me.MyGroupBox2.Controls.Add(Me.PictureBox1)
        Me.MyGroupBox2.Controls.Add(Me.RadioButton8)
        Me.MyGroupBox2.Controls.Add(Me.RadioButton9)
        Me.MyGroupBox2.Location = New System.Drawing.Point(959, 43)
        Me.MyGroupBox2.Name = "MyGroupBox2"
        Me.MyGroupBox2.Size = New System.Drawing.Size(206, 50)
        Me.MyGroupBox2.TabIndex = 2034
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackgroundImage = Global.VOCAPlusPlus.My.Resources.Resources.Phone1
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(98, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(43, 42)
        Me.PictureBox2.TabIndex = 2034
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = Global.VOCAPlusPlus.My.Resources.Resources.Mobile
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(18, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 44)
        Me.PictureBox1.TabIndex = 2033
        Me.PictureBox1.TabStop = False
        '
        'RadioButton8
        '
        Me.RadioButton8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton8.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton8.Location = New System.Drawing.Point(56, 13)
        Me.RadioButton8.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioButton8.Size = New System.Drawing.Size(17, 25)
        Me.RadioButton8.TabIndex = 505
        Me.RadioButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'RadioButton9
        '
        Me.RadioButton9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RadioButton9.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton9.Location = New System.Drawing.Point(151, 10)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioButton9.Size = New System.Drawing.Size(19, 27)
        Me.RadioButton9.TabIndex = 504
        Me.RadioButton9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton9.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(925, 53)
        Me.Label20.Margin = New System.Windows.Forms.Padding(3, 13, 3, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label20.Size = New System.Drawing.Size(28, 30)
        Me.Label20.TabIndex = 2001
        Me.Label20.Text = " *"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Phon1TxtBx
        '
        Me.Phon1TxtBx.AccessibleName = ""
        Me.Phon1TxtBx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Phon1TxtBx.Location = New System.Drawing.Point(633, 53)
        Me.Phon1TxtBx.Margin = New System.Windows.Forms.Padding(3, 13, 3, 3)
        Me.Phon1TxtBx.Mask = "00000000000"
        Me.Phon1TxtBx.Name = "Phon1TxtBx"
        Me.Phon1TxtBx.Size = New System.Drawing.Size(286, 32)
        Me.Phon1TxtBx.TabIndex = 0
        Me.Phon1TxtBx.Tag = "English-Number"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(509, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 13, 3, 3)
        Me.Label1.MinimumSize = New System.Drawing.Size(70, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(118, 27)
        Me.Label1.TabIndex = 2044
        Me.Label1.Text = "التاريخ :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTxtBx
        '
        Me.DateTxtBx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DateTxtBx.Enabled = False
        Me.FlwMainData.SetFlowBreak(Me.DateTxtBx, True)
        Me.DateTxtBx.Location = New System.Drawing.Point(11, 53)
        Me.DateTxtBx.Margin = New System.Windows.Forms.Padding(3, 13, 3, 3)
        Me.DateTxtBx.Name = "DateTxtBx"
        Me.DateTxtBx.ReadOnly = True
        Me.DateTxtBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DateTxtBx.Size = New System.Drawing.Size(492, 32)
        Me.DateTxtBx.TabIndex = 2043
        Me.DateTxtBx.TabStop = False
        Me.DateTxtBx.Tag = "Date"
        Me.ToolTip1.SetToolTip(Me.DateTxtBx, "تاريخ الشكوى")
        '
        'MyGroupBox1
        '
        Me.MyGroupBox1.Controls.Add(Me.PictureBox4)
        Me.MyGroupBox1.Controls.Add(Me.PictureBox3)
        Me.MyGroupBox1.Controls.Add(Me.RadioButton11)
        Me.MyGroupBox1.Controls.Add(Me.RadioButton12)
        Me.MyGroupBox1.Location = New System.Drawing.Point(959, 99)
        Me.MyGroupBox1.Name = "MyGroupBox1"
        Me.MyGroupBox1.Size = New System.Drawing.Size(206, 50)
        Me.MyGroupBox1.TabIndex = 2035
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = Global.VOCAPlusPlus.My.Resources.Resources.Phone1
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox4.Location = New System.Drawing.Point(98, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(43, 42)
        Me.PictureBox4.TabIndex = 2035
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.VOCAPlusPlus.My.Resources.Resources.Mobile
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Location = New System.Drawing.Point(18, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 44)
        Me.PictureBox3.TabIndex = 2035
        Me.PictureBox3.TabStop = False
        '
        'RadioButton11
        '
        Me.RadioButton11.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton11.Location = New System.Drawing.Point(56, 13)
        Me.RadioButton11.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton11.Name = "RadioButton11"
        Me.RadioButton11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioButton11.Size = New System.Drawing.Size(17, 25)
        Me.RadioButton11.TabIndex = 508
        Me.RadioButton11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton11.UseVisualStyleBackColor = True
        '
        'RadioButton12
        '
        Me.RadioButton12.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton12.Location = New System.Drawing.Point(151, 10)
        Me.RadioButton12.Name = "RadioButton12"
        Me.RadioButton12.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioButton12.Size = New System.Drawing.Size(19, 27)
        Me.RadioButton12.TabIndex = 507
        Me.RadioButton12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton12.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(925, 109)
        Me.Label22.Margin = New System.Windows.Forms.Padding(3, 13, 3, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label22.Size = New System.Drawing.Size(28, 30)
        Me.Label22.TabIndex = 2003
        Me.Label22.Text = " "
        '
        'Phon2TxtBx
        '
        Me.Phon2TxtBx.AccessibleName = ""
        Me.Phon2TxtBx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlwMainData.SetFlowBreak(Me.Phon2TxtBx, True)
        Me.Phon2TxtBx.Location = New System.Drawing.Point(633, 109)
        Me.Phon2TxtBx.Margin = New System.Windows.Forms.Padding(3, 13, 3, 3)
        Me.Phon2TxtBx.Mask = "00000000000"
        Me.Phon2TxtBx.Name = "Phon2TxtBx"
        Me.Phon2TxtBx.Size = New System.Drawing.Size(286, 32)
        Me.Phon2TxtBx.TabIndex = 2
        Me.Phon2TxtBx.Tag = "English-Number"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(959, 152)
        Me.Label2.MinimumSize = New System.Drawing.Size(70, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(206, 34)
        Me.Label2.TabIndex = 1002
        Me.Label2.Text = "اسم العميل :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(925, 152)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label21.Size = New System.Drawing.Size(28, 30)
        Me.Label21.TabIndex = 2002
        Me.Label21.Text = "*"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NameTxtBx
        '
        Me.NameTxtBx.AccessibleName = ""
        Me.NameTxtBx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NameTxtBx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NameTxtBx.Location = New System.Drawing.Point(633, 155)
        Me.NameTxtBx.Name = "NameTxtBx"
        Me.NameTxtBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NameTxtBx.Size = New System.Drawing.Size(286, 32)
        Me.NameTxtBx.TabIndex = 1
        Me.NameTxtBx.TabStop = False
        Me.NameTxtBx.Tag = "English-Text"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(507, 155)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label15.Size = New System.Drawing.Size(120, 27)
        Me.Label15.TabIndex = 87
        Me.Label15.Text = "البريد الإلكتروني :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MailTxtBx
        '
        Me.MailTxtBx.AccessibleName = ""
        Me.MailTxtBx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlwMainData.SetFlowBreak(Me.MailTxtBx, True)
        Me.MailTxtBx.Location = New System.Drawing.Point(165, 155)
        Me.MailTxtBx.Name = "MailTxtBx"
        Me.MailTxtBx.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MailTxtBx.Size = New System.Drawing.Size(336, 32)
        Me.MailTxtBx.TabIndex = 73
        Me.MailTxtBx.TabStop = False
        Me.MailTxtBx.Tag = "English-Special"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(959, 190)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label16.Size = New System.Drawing.Size(206, 34)
        Me.Label16.TabIndex = 2041
        Me.Label16.Text = "مصدر الشكوى :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(925, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(28, 30)
        Me.Label7.TabIndex = 2047
        Me.Label7.Text = "*"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SrcCmbBx
        '
        Me.SrcCmbBx.AllowDrop = True
        Me.SrcCmbBx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SrcCmbBx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.SrcCmbBx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SrcCmbBx.BackColor = System.Drawing.Color.White
        Me.SrcCmbBx.DisplayMember = "SrcNm"
        Me.SrcCmbBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FlwMainData.SetFlowBreak(Me.SrcCmbBx, True)
        Me.SrcCmbBx.FormattingEnabled = True
        Me.SrcCmbBx.ItemHeight = 23
        Me.SrcCmbBx.Location = New System.Drawing.Point(633, 193)
        Me.SrcCmbBx.Name = "SrcCmbBx"
        Me.SrcCmbBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SrcCmbBx.Size = New System.Drawing.Size(286, 31)
        Me.SrcCmbBx.TabIndex = 2040
        Me.SrcCmbBx.Tag = "مصدر الشكوى"
        Me.ToolTip1.SetToolTip(Me.SrcCmbBx, "مصدر الشكوى")
        Me.SrcCmbBx.ValueMember = "SrcCd"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(959, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(206, 34)
        Me.Label4.TabIndex = 2036
        Me.Label4.Text = "نوع الخدمة :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(925, 227)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label24.Size = New System.Drawing.Size(28, 30)
        Me.Label24.TabIndex = 2042
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Prdct
        '
        Me.Prdct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Prdct.Location = New System.Drawing.Point(633, 230)
        Me.Prdct.Name = "Prdct"
        Me.Prdct.ReadOnly = True
        Me.Prdct.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Prdct.Size = New System.Drawing.Size(286, 32)
        Me.Prdct.TabIndex = 2038
        Me.Prdct.Tag = "نوع الخدمة"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(507, 235)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(120, 27)
        Me.Label5.TabIndex = 2037
        Me.Label5.Text = "نوع الشكوى :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Comp
        '
        Me.Comp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlwMainData.SetFlowBreak(Me.Comp, True)
        Me.Comp.Location = New System.Drawing.Point(11, 230)
        Me.Comp.Name = "Comp"
        Me.Comp.ReadOnly = True
        Me.Comp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Comp.Size = New System.Drawing.Size(490, 32)
        Me.Comp.TabIndex = 2039
        Me.Comp.Tag = "نوع الشكوى"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(959, 265)
        Me.Label3.MinimumSize = New System.Drawing.Size(70, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(206, 34)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "العنوان :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AddTxtBx
        '
        Me.AddTxtBx.AccessibleName = ""
        Me.AddTxtBx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddTxtBx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.FlwMainData.SetFlowBreak(Me.AddTxtBx, True)
        Me.AddTxtBx.Location = New System.Drawing.Point(11, 268)
        Me.AddTxtBx.Margin = New System.Windows.Forms.Padding(35, 3, 3, 3)
        Me.AddTxtBx.Multiline = True
        Me.AddTxtBx.Name = "AddTxtBx"
        Me.AddTxtBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AddTxtBx.Size = New System.Drawing.Size(910, 86)
        Me.AddTxtBx.TabIndex = 68
        Me.AddTxtBx.Tag = "Arabic-All"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(959, 357)
        Me.Label6.MinimumSize = New System.Drawing.Size(70, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(206, 34)
        Me.Label6.TabIndex = 2046
        Me.Label6.Text = "تفاصيل الشكوى :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DetailsTxtBx
        '
        Me.FlwMainData.SetFlowBreak(Me.DetailsTxtBx, True)
        Me.DetailsTxtBx.Location = New System.Drawing.Point(11, 360)
        Me.DetailsTxtBx.Margin = New System.Windows.Forms.Padding(35, 3, 3, 3)
        Me.DetailsTxtBx.Multiline = True
        Me.DetailsTxtBx.Name = "DetailsTxtBx"
        Me.DetailsTxtBx.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.DetailsTxtBx.Size = New System.Drawing.Size(910, 114)
        Me.DetailsTxtBx.TabIndex = 2045
        Me.DetailsTxtBx.Tag = "Arabic-All"
        '
        'FlwMend
        '
        Me.FlwMend.AutoScroll = True
        Me.FlwMend.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlwMend.Location = New System.Drawing.Point(689, 568)
        Me.FlwMend.Name = "FlwMend"
        Me.FlwMend.Size = New System.Drawing.Size(551, 266)
        Me.FlwMend.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.BtnClr)
        Me.Panel6.Location = New System.Drawing.Point(571, 568)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(112, 55)
        Me.Panel6.TabIndex = 2037
        Me.Panel6.Visible = False
        '
        'BtnClr
        '
        Me.BtnClr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClr.BackgroundImage = Global.VOCAPlusPlus.My.Resources.Resources.recorange
        Me.BtnClr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClr.Enabled = False
        Me.BtnClr.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnClr.Location = New System.Drawing.Point(2, 5)
        Me.BtnClr.Name = "BtnClr"
        Me.BtnClr.Size = New System.Drawing.Size(105, 40)
        Me.BtnClr.TabIndex = 3
        Me.BtnClr.Text = "Clear"
        Me.BtnClr.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.BtnAdd)
        Me.Panel5.Location = New System.Drawing.Point(458, 568)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(107, 55)
        Me.Panel5.TabIndex = 2036
        Me.Panel5.Visible = False
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.BackgroundImage = Global.VOCAPlusPlus.My.Resources.Resources.recpurple
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdd.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnAdd.Location = New System.Drawing.Point(3, 5)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(100, 40)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "إضافة حقل"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.AutoScroll = True
        Me.FlowLayoutPanel5.Controls.Add(Me.Panel4)
        Me.FlowLayoutPanel5.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel5.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel5.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(188, 565)
        Me.FlowLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(267, 202)
        Me.FlowLayoutPanel5.TabIndex = 2035
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.NewBtn)
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(115, 86)
        Me.Panel4.TabIndex = 2038
        '
        'NewBtn
        '
        Me.NewBtn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewBtn.BackgroundImage = Global.VOCAPlusPlus.My.Resources.Resources.CpAdd
        Me.NewBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NewBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.NewBtn.FlatAppearance.BorderSize = 0
        Me.NewBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.NewBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.NewBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.NewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NewBtn.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.NewBtn.Location = New System.Drawing.Point(8, 6)
        Me.NewBtn.Name = "NewBtn"
        Me.NewBtn.Size = New System.Drawing.Size(100, 74)
        Me.NewBtn.TabIndex = 2021
        Me.NewBtn.Tag = "New Ticket"
        Me.NewBtn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.SubmitBtn)
        Me.Panel1.Location = New System.Drawing.Point(124, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(115, 86)
        Me.Panel1.TabIndex = 2035
        '
        'SubmitBtn
        '
        Me.SubmitBtn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SubmitBtn.BackgroundImage = Global.VOCAPlusPlus.My.Resources.Resources.SaveFl
        Me.SubmitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SubmitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.SubmitBtn.FlatAppearance.BorderSize = 0
        Me.SubmitBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.SubmitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.SubmitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.SubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SubmitBtn.Font = New System.Drawing.Font("Times New Roman", 14.25!)
        Me.SubmitBtn.Location = New System.Drawing.Point(8, 6)
        Me.SubmitBtn.Name = "SubmitBtn"
        Me.SubmitBtn.Size = New System.Drawing.Size(100, 74)
        Me.SubmitBtn.TabIndex = 92
        Me.SubmitBtn.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.CloseBtn)
        Me.Panel2.Location = New System.Drawing.Point(3, 95)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(115, 86)
        Me.Panel2.TabIndex = 2036
        '
        'CloseBtn
        '
        Me.CloseBtn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseBtn.BackgroundImage = Global.VOCAPlusPlus.My.Resources.Resources._Exit1
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CloseBtn.FlatAppearance.BorderSize = 0
        Me.CloseBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseBtn.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.CloseBtn.Location = New System.Drawing.Point(8, 6)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(100, 74)
        Me.CloseBtn.TabIndex = 86
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.BtnDublicate)
        Me.Panel3.Location = New System.Drawing.Point(124, 95)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(115, 86)
        Me.Panel3.TabIndex = 2037
        '
        'BtnDublicate
        '
        Me.BtnDublicate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDublicate.BackgroundImage = Global.VOCAPlusPlus.My.Resources.Resources.Dublicte1
        Me.BtnDublicate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDublicate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDublicate.FlatAppearance.BorderSize = 0
        Me.BtnDublicate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDublicate.Location = New System.Drawing.Point(8, 6)
        Me.BtnDublicate.Name = "BtnDublicate"
        Me.BtnDublicate.Size = New System.Drawing.Size(100, 74)
        Me.BtnDublicate.TabIndex = 2034
        Me.BtnDublicate.UseVisualStyleBackColor = True
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
        'TimrPhons
        '
        Me.TimrPhons.Interval = 200
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'TikNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1796, 847)
        Me.Controls.Add(Me.FlwMain)
        Me.Name = "TikNew"
        Me.Text = "TikNew"
        Me.FlwMain.ResumeLayout(False)
        Me.FlwTree.ResumeLayout(False)
        Me.MyGroupBox3.ResumeLayout(False)
        Me.FlwSubMain.ResumeLayout(False)
        Me.FlwSubMain.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.FlwMainData.ResumeLayout(False)
        Me.FlwMainData.PerformLayout()
        Me.MyGroupBox2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MyGroupBox1.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FlwMain As FlowLayoutPanel
    Friend WithEvents FlwTree As FlowLayoutPanel
    Friend WithEvents MyGroupBox3 As GroupBox
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents FlwMend As FlowLayoutPanel
    Friend WithEvents BtnClr As Button
    Friend WithEvents FlwSubMain As FlowLayoutPanel
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents FlwMainData As FlowLayoutPanel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents IDTxtBx As MaskedTextBox
    Friend WithEvents RadNID As RadioButton
    Friend WithEvents RadPss As RadioButton
    Friend WithEvents MyGroupBox2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents RadioButton8 As RadioButton
    Friend WithEvents RadioButton9 As RadioButton
    Friend WithEvents Label20 As Label
    Friend WithEvents Phon1TxtBx As MaskedTextBox
    Friend WithEvents MyGroupBox1 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents RadioButton11 As RadioButton
    Friend WithEvents RadioButton12 As RadioButton
    Friend WithEvents Label22 As Label
    Friend WithEvents Phon2TxtBx As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents NameTxtBx As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents AddTxtBx As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents MailTxtBx As TextBox
    Friend WithEvents ComRefLbl As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Prdct As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Comp As TextBox
    Friend WithEvents FlowLayoutPanel5 As FlowLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents NewBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SubmitBtn As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents CloseBtn As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnDublicate As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BtnAdd As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents TimrPhons As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label16 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents SrcCmbBx As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTxtBx As TextBox
    Friend WithEvents DetailsTxtBx As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Timer1 As Timer
End Class
