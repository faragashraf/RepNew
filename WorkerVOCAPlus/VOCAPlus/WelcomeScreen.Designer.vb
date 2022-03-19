<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WelcomeScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WelcomeScreen))
        Me.TimerOp = New System.Windows.Forms.Timer(Me.components)
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatBrPnlEn = New System.Windows.Forms.StatusBarPanel()
        Me.StatBrPnlAr = New System.Windows.Forms.StatusBarPanel()
        Me.TimerTikCoun = New System.Windows.Forms.Timer(Me.components)
        Me.MenuSw = New System.Windows.Forms.MenuStrip()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CntxtMnuStrp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExtBt = New System.Windows.Forms.Button()
        Me.SnOutBt = New System.Windows.Forms.Button()
        Me.TimerCon = New System.Windows.Forms.Timer(Me.components)
        Me.LblUsrIP = New System.Windows.Forms.Label()
        Me.PubVerLbl = New System.Windows.Forms.Label()
        Me.LblUsrRNm = New System.Windows.Forms.Label()
        Me.DbStat = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LblClrSys = New System.Windows.Forms.Label()
        Me.LblClrUsr = New System.Windows.Forms.Label()
        Me.LblClrNotUsr = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblClrSamCat = New System.Windows.Forms.Label()
        Me.LblClrOperation = New System.Windows.Forms.Label()
        Me.GrpCounters = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LblFolwDy = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblClsUpdted = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblRecivDy = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblReOpY = New System.Windows.Forms.Label()
        Me.LblReadYDy = New System.Windows.Forms.Label()
        Me.LblUnRead = New System.Windows.Forms.Label()
        Me.LblEvDy = New System.Windows.Forms.Label()
        Me.LblClsYDy = New System.Windows.Forms.Label()
        Me.LblFlN = New System.Windows.Forms.Label()
        Me.LblClsN = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label0 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CNTXMNUPic = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UploadYourPictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.LblSrvrNm = New System.Windows.Forms.Label()
        Me.TimrFlsh = New System.Windows.Forms.Timer(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblLanguage = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.LblLstSeen = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TimerColctLog = New System.Windows.Forms.Timer(Me.components)
        Me.WChckConn = New System.ComponentModel.BackgroundWorker()
        Me.WkrTikCount = New System.ComponentModel.BackgroundWorker()
        CType(Me.StatBrPnlEn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatBrPnlAr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbStat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GrpCounters.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CNTXMNUPic.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TimerOp
        '
        Me.TimerOp.Interval = 50
        '
        'StatusBar1
        '
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 786)
        Me.StatusBar1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatBrPnlEn, Me.StatBrPnlAr})
        Me.StatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1630, 41)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 56
        '
        'StatBrPnlEn
        '
        Me.StatBrPnlEn.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatBrPnlEn.Name = "StatBrPnlEn"
        Me.StatBrPnlEn.Width = 815
        '
        'StatBrPnlAr
        '
        Me.StatBrPnlAr.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatBrPnlAr.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatBrPnlAr.Name = "StatBrPnlAr"
        Me.StatBrPnlAr.Width = 815
        '
        'TimerTikCoun
        '
        Me.TimerTikCoun.Interval = 1000
        '
        'MenuSw
        '
        Me.MenuSw.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MenuSw.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.MenuSw.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuSw.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.MenuSw.Location = New System.Drawing.Point(0, 0)
        Me.MenuSw.Name = "MenuSw"
        Me.MenuSw.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuSw.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MenuSw.Size = New System.Drawing.Size(1630, 4)
        Me.MenuSw.TabIndex = 55
        Me.MenuSw.Text = "MenuStrip1"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.CntxtMnuStrp
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Tag = ""
        Me.NotifyIcon1.Visible = True
        '
        'CntxtMnuStrp
        '
        Me.CntxtMnuStrp.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CntxtMnuStrp.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CntxtMnuStrp.Name = "ContextMenuStrip1"
        Me.CntxtMnuStrp.Size = New System.Drawing.Size(61, 4)
        '
        'ExtBt
        '
        Me.ExtBt.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recred
        Me.ExtBt.Location = New System.Drawing.Point(13, 6)
        Me.ExtBt.Margin = New System.Windows.Forms.Padding(6, 6, 12, 6)
        Me.ExtBt.Name = "ExtBt"
        Me.ExtBt.Size = New System.Drawing.Size(107, 36)
        Me.ExtBt.TabIndex = 58
        Me.ExtBt.Text = "Exit"
        Me.ToolTip1.SetToolTip(Me.ExtBt, "إغلاق البرنامج")
        Me.ExtBt.UseVisualStyleBackColor = True
        '
        'SnOutBt
        '
        Me.SnOutBt.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recyellow
        Me.SnOutBt.Location = New System.Drawing.Point(6, 5)
        Me.SnOutBt.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.SnOutBt.Name = "SnOutBt"
        Me.SnOutBt.Size = New System.Drawing.Size(133, 36)
        Me.SnOutBt.TabIndex = 59
        Me.SnOutBt.Text = "Sign Out"
        Me.ToolTip1.SetToolTip(Me.SnOutBt, "تسجيل الخروج")
        Me.SnOutBt.UseVisualStyleBackColor = True
        '
        'TimerCon
        '
        Me.TimerCon.Interval = 1000
        '
        'LblUsrIP
        '
        Me.LblUsrIP.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.SetFlowBreak(Me.LblUsrIP, True)
        Me.LblUsrIP.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.LblUsrIP.ForeColor = System.Drawing.Color.Red
        Me.LblUsrIP.Location = New System.Drawing.Point(2074, 999)
        Me.LblUsrIP.Margin = New System.Windows.Forms.Padding(3, 0, 12, 0)
        Me.LblUsrIP.Name = "LblUsrIP"
        Me.LblUsrIP.Size = New System.Drawing.Size(433, 31)
        Me.LblUsrIP.TabIndex = 73
        Me.LblUsrIP.Text = "User IP: "
        Me.LblUsrIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LblUsrIP, "IP Address Of Current Mashine")
        '
        'PubVerLbl
        '
        Me.PubVerLbl.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.SetFlowBreak(Me.PubVerLbl, True)
        Me.PubVerLbl.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.PubVerLbl.ForeColor = System.Drawing.Color.Red
        Me.PubVerLbl.Location = New System.Drawing.Point(2074, 1030)
        Me.PubVerLbl.Margin = New System.Windows.Forms.Padding(3, 0, 12, 0)
        Me.PubVerLbl.Name = "PubVerLbl"
        Me.PubVerLbl.Size = New System.Drawing.Size(433, 31)
        Me.PubVerLbl.TabIndex = 76
        Me.PubVerLbl.Text = "Publish Ver."
        Me.PubVerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.PubVerLbl, "Publish Version Number")
        '
        'LblUsrRNm
        '
        Me.LblUsrRNm.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.SetFlowBreak(Me.LblUsrRNm, True)
        Me.LblUsrRNm.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblUsrRNm.ForeColor = System.Drawing.Color.Blue
        Me.LblUsrRNm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblUsrRNm.Location = New System.Drawing.Point(641, 484)
        Me.LblUsrRNm.Margin = New System.Windows.Forms.Padding(3, 4, 1167, 4)
        Me.LblUsrRNm.Name = "LblUsrRNm"
        Me.LblUsrRNm.Size = New System.Drawing.Size(421, 31)
        Me.LblUsrRNm.TabIndex = 77
        Me.LblUsrRNm.Text = "Welcome User: "
        Me.LblUsrRNm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DbStat
        '
        Me.DbStat.BackColor = System.Drawing.Color.Transparent
        Me.DbStat.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.DBOff
        Me.DbStat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FlowLayoutPanel1.SetFlowBreak(Me.DbStat, True)
        Me.DbStat.Location = New System.Drawing.Point(2469, 5)
        Me.DbStat.Margin = New System.Windows.Forms.Padding(3, 4, 0, 4)
        Me.DbStat.Name = "DbStat"
        Me.DbStat.Size = New System.Drawing.Size(53, 54)
        Me.DbStat.TabIndex = 79
        Me.DbStat.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recyellow
        Me.Button2.Location = New System.Drawing.Point(6, 5)
        Me.Button2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 36)
        Me.Button2.TabIndex = 59
        Me.Button2.Text = "Sign Out"
        Me.ToolTip1.SetToolTip(Me.Button2, "تسجيل الخروج")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'LblClrSys
        '
        Me.LblClrSys.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClrSys.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblClrSys.Location = New System.Drawing.Point(103, 31)
        Me.LblClrSys.Name = "LblClrSys"
        Me.LblClrSys.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblClrSys.Size = New System.Drawing.Size(234, 28)
        Me.LblClrSys.TabIndex = 82
        Me.LblClrSys.Text = "-  تحديثات النظام"
        Me.LblClrSys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblClrUsr
        '
        Me.LblClrUsr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClrUsr.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblClrUsr.Location = New System.Drawing.Point(103, 87)
        Me.LblClrUsr.Name = "LblClrUsr"
        Me.LblClrUsr.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblClrUsr.Size = New System.Drawing.Size(234, 28)
        Me.LblClrUsr.TabIndex = 85
        Me.LblClrUsr.Text = "-  تحديثات متابع الشكوى"
        Me.LblClrUsr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblClrNotUsr
        '
        Me.LblClrNotUsr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClrNotUsr.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblClrNotUsr.Location = New System.Drawing.Point(103, 59)
        Me.LblClrNotUsr.Name = "LblClrNotUsr"
        Me.LblClrNotUsr.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblClrNotUsr.Size = New System.Drawing.Size(234, 28)
        Me.LblClrNotUsr.TabIndex = 86
        Me.LblClrNotUsr.Text = "-  تحديثات الجميع"
        Me.LblClrNotUsr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LblClrSamCat)
        Me.GroupBox1.Controls.Add(Me.LblClrOperation)
        Me.GroupBox1.Controls.Add(Me.LblClrUsr)
        Me.GroupBox1.Controls.Add(Me.LblClrNotUsr)
        Me.GroupBox1.Controls.Add(Me.LblClrSys)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1064, 69)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 12, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(359, 405)
        Me.GroupBox1.TabIndex = 87
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "مفاتيح الألوان"
        '
        'LblClrSamCat
        '
        Me.LblClrSamCat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClrSamCat.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblClrSamCat.Location = New System.Drawing.Point(103, 116)
        Me.LblClrSamCat.Name = "LblClrSamCat"
        Me.LblClrSamCat.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblClrSamCat.Size = New System.Drawing.Size(234, 28)
        Me.LblClrSamCat.TabIndex = 87
        Me.LblClrSamCat.Text = "-  تحديثات رعاية العملاء"
        Me.LblClrSamCat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblClrOperation
        '
        Me.LblClrOperation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClrOperation.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblClrOperation.Location = New System.Drawing.Point(103, 144)
        Me.LblClrOperation.Name = "LblClrOperation"
        Me.LblClrOperation.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblClrOperation.Size = New System.Drawing.Size(234, 28)
        Me.LblClrOperation.TabIndex = 84
        Me.LblClrOperation.Text = "-  تحديثات العمليات"
        Me.LblClrOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GrpCounters
        '
        Me.GrpCounters.BackColor = System.Drawing.Color.Transparent
        Me.GrpCounters.Controls.Add(Me.Button1)
        Me.GrpCounters.Controls.Add(Me.LblFolwDy)
        Me.GrpCounters.Controls.Add(Me.Label10)
        Me.GrpCounters.Controls.Add(Me.LblClsUpdted)
        Me.GrpCounters.Controls.Add(Me.Label7)
        Me.GrpCounters.Controls.Add(Me.LblRecivDy)
        Me.GrpCounters.Controls.Add(Me.Label8)
        Me.GrpCounters.Controls.Add(Me.LblReOpY)
        Me.GrpCounters.Controls.Add(Me.LblReadYDy)
        Me.GrpCounters.Controls.Add(Me.LblUnRead)
        Me.GrpCounters.Controls.Add(Me.LblEvDy)
        Me.GrpCounters.Controls.Add(Me.LblClsYDy)
        Me.GrpCounters.Controls.Add(Me.LblFlN)
        Me.GrpCounters.Controls.Add(Me.LblClsN)
        Me.GrpCounters.Controls.Add(Me.Label6)
        Me.GrpCounters.Controls.Add(Me.Label5)
        Me.GrpCounters.Controls.Add(Me.Label4)
        Me.GrpCounters.Controls.Add(Me.Label3)
        Me.GrpCounters.Controls.Add(Me.Label2)
        Me.GrpCounters.Controls.Add(Me.Label1)
        Me.GrpCounters.Controls.Add(Me.Label0)
        Me.GrpCounters.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GrpCounters.ForeColor = System.Drawing.Color.ForestGreen
        Me.GrpCounters.Location = New System.Drawing.Point(568, 69)
        Me.GrpCounters.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.GrpCounters.Name = "GrpCounters"
        Me.GrpCounters.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpCounters.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GrpCounters.Size = New System.Drawing.Size(493, 405)
        Me.GrpCounters.TabIndex = 88
        Me.GrpCounters.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(142, 279)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(153, 37)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "تحديث الأرقام"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'LblFolwDy
        '
        Me.LblFolwDy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFolwDy.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFolwDy.ForeColor = System.Drawing.Color.Black
        Me.LblFolwDy.Location = New System.Drawing.Point(150, 153)
        Me.LblFolwDy.Name = "LblFolwDy"
        Me.LblFolwDy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblFolwDy.Size = New System.Drawing.Size(160, 25)
        Me.LblFolwDy.TabIndex = 19
        Me.LblFolwDy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblFolwDy.Visible = False
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(307, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label10.Size = New System.Drawing.Size(180, 25)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "تم التعامل اليوم :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Visible = False
        '
        'LblClsUpdted
        '
        Me.LblClsUpdted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClsUpdted.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClsUpdted.ForeColor = System.Drawing.Color.Black
        Me.LblClsUpdted.Location = New System.Drawing.Point(151, 251)
        Me.LblClsUpdted.Name = "LblClsUpdted"
        Me.LblClsUpdted.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblClsUpdted.Size = New System.Drawing.Size(160, 25)
        Me.LblClsUpdted.TabIndex = 17
        Me.LblClsUpdted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblClsUpdted.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(307, 251)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(180, 25)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "تحديثات شكاوى مغلقة :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Visible = False
        '
        'LblRecivDy
        '
        Me.LblRecivDy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRecivDy.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecivDy.ForeColor = System.Drawing.Color.Black
        Me.LblRecivDy.Location = New System.Drawing.Point(150, 52)
        Me.LblRecivDy.Name = "LblRecivDy"
        Me.LblRecivDy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblRecivDy.Size = New System.Drawing.Size(160, 25)
        Me.LblRecivDy.TabIndex = 15
        Me.LblRecivDy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblRecivDy.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(307, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label8.Size = New System.Drawing.Size(180, 25)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "استلام اليوم :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Visible = False
        '
        'LblReOpY
        '
        Me.LblReOpY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblReOpY.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReOpY.ForeColor = System.Drawing.Color.Black
        Me.LblReOpY.Location = New System.Drawing.Point(150, 226)
        Me.LblReOpY.Name = "LblReOpY"
        Me.LblReOpY.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblReOpY.Size = New System.Drawing.Size(160, 25)
        Me.LblReOpY.TabIndex = 13
        Me.LblReOpY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblReOpY.Visible = False
        '
        'LblReadYDy
        '
        Me.LblReadYDy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblReadYDy.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReadYDy.ForeColor = System.Drawing.Color.Black
        Me.LblReadYDy.Location = New System.Drawing.Point(150, 202)
        Me.LblReadYDy.Name = "LblReadYDy"
        Me.LblReadYDy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblReadYDy.Size = New System.Drawing.Size(160, 25)
        Me.LblReadYDy.TabIndex = 12
        Me.LblReadYDy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblReadYDy.Visible = False
        '
        'LblUnRead
        '
        Me.LblUnRead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblUnRead.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnRead.ForeColor = System.Drawing.Color.Black
        Me.LblUnRead.Location = New System.Drawing.Point(150, 177)
        Me.LblUnRead.Name = "LblUnRead"
        Me.LblUnRead.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblUnRead.Size = New System.Drawing.Size(160, 25)
        Me.LblUnRead.TabIndex = 11
        Me.LblUnRead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblUnRead.Visible = False
        '
        'LblEvDy
        '
        Me.LblEvDy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblEvDy.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEvDy.ForeColor = System.Drawing.Color.Black
        Me.LblEvDy.Location = New System.Drawing.Point(150, 127)
        Me.LblEvDy.Name = "LblEvDy"
        Me.LblEvDy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblEvDy.Size = New System.Drawing.Size(160, 25)
        Me.LblEvDy.TabIndex = 10
        Me.LblEvDy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblEvDy.Visible = False
        '
        'LblClsYDy
        '
        Me.LblClsYDy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClsYDy.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClsYDy.ForeColor = System.Drawing.Color.Black
        Me.LblClsYDy.Location = New System.Drawing.Point(150, 102)
        Me.LblClsYDy.Name = "LblClsYDy"
        Me.LblClsYDy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblClsYDy.Size = New System.Drawing.Size(160, 25)
        Me.LblClsYDy.TabIndex = 9
        Me.LblClsYDy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblClsYDy.Visible = False
        '
        'LblFlN
        '
        Me.LblFlN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFlN.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFlN.ForeColor = System.Drawing.Color.Black
        Me.LblFlN.Location = New System.Drawing.Point(150, 78)
        Me.LblFlN.Name = "LblFlN"
        Me.LblFlN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblFlN.Size = New System.Drawing.Size(160, 25)
        Me.LblFlN.TabIndex = 8
        Me.LblFlN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblFlN.Visible = False
        '
        'LblClsN
        '
        Me.LblClsN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClsN.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClsN.ForeColor = System.Drawing.Color.Black
        Me.LblClsN.Location = New System.Drawing.Point(150, 27)
        Me.LblClsN.Name = "LblClsN"
        Me.LblClsN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblClsN.Size = New System.Drawing.Size(160, 25)
        Me.LblClsN.TabIndex = 7
        Me.LblClsN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblClsN.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(307, 226)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(180, 25)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "معاد فتحها :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(307, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(180, 25)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "تحديثات مقروءه اليوم :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(307, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(180, 25)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "تحديثات غير مقروءه :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(307, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(180, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "عدد تحديثات اليوم :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(307, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(180, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "تم الإغلاق اليوم :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(307, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(180, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "لم يتم التعامل معها :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Visible = False
        '
        'Label0
        '
        Me.Label0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label0.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label0.ForeColor = System.Drawing.Color.Black
        Me.Label0.Location = New System.Drawing.Point(307, 27)
        Me.Label0.Name = "Label0"
        Me.Label0.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label0.Size = New System.Drawing.Size(180, 25)
        Me.Label0.TabIndex = 0
        Me.Label0.Text = "مفتوحة :"
        Me.Label0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label0.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.UsrResm
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ContextMenuStrip = Me.CNTXMNUPic
        Me.FlowLayoutPanel1.SetFlowBreak(Me.PictureBox1, True)
        Me.PictureBox1.Location = New System.Drawing.Point(351, 64)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(47, 0, 0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(216, 283)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 90
        Me.PictureBox1.TabStop = False
        '
        'CNTXMNUPic
        '
        Me.CNTXMNUPic.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CNTXMNUPic.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadYourPictureToolStripMenuItem})
        Me.CNTXMNUPic.Name = "CNTXMNUPic"
        Me.CNTXMNUPic.Size = New System.Drawing.Size(214, 30)
        '
        'UploadYourPictureToolStripMenuItem
        '
        Me.UploadYourPictureToolStripMenuItem.Image = Global.VOCAPlus.My.Resources.Resources.Upload_Transparent
        Me.UploadYourPictureToolStripMenuItem.Name = "UploadYourPictureToolStripMenuItem"
        Me.UploadYourPictureToolStripMenuItem.Size = New System.Drawing.Size(213, 26)
        Me.UploadYourPictureToolStripMenuItem.Text = "Upload Your Picture"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "CpAdd.png")
        Me.ImageList1.Images.SetKeyName(1, "CpOpen.png")
        Me.ImageList1.Images.SetKeyName(2, "Phone1.png")
        Me.ImageList1.Images.SetKeyName(3, "Frstaid.png")
        Me.ImageList1.Images.SetKeyName(4, "VocaIcon48.png")
        Me.ImageList1.Images.SetKeyName(5, "FTP.ico")
        Me.ImageList1.Images.SetKeyName(6, "upload-1.png")
        Me.ImageList1.Images.SetKeyName(7, "Usrresm.png")
        Me.ImageList1.Images.SetKeyName(8, "Export.png")
        Me.ImageList1.Images.SetKeyName(9, "usersLogin.png")
        '
        'LblSrvrNm
        '
        Me.LblSrvrNm.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.SetFlowBreak(Me.LblSrvrNm, True)
        Me.LblSrvrNm.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.LblSrvrNm.ForeColor = System.Drawing.Color.Red
        Me.LblSrvrNm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblSrvrNm.Location = New System.Drawing.Point(641, 525)
        Me.LblSrvrNm.Margin = New System.Windows.Forms.Padding(3, 4, 1167, 4)
        Me.LblSrvrNm.Name = "LblSrvrNm"
        Me.LblSrvrNm.Size = New System.Drawing.Size(421, 31)
        Me.LblSrvrNm.TabIndex = 91
        Me.LblSrvrNm.Text = "ccc"
        Me.LblSrvrNm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimrFlsh
        '
        Me.TimrFlsh.Interval = 1000
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.SetFlowBreak(Me.Label9, True)
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(2079, 785)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label9.Size = New System.Drawing.Size(439, 214)
        Me.Label9.TabIndex = 94
        '
        'LblLanguage
        '
        Me.LblLanguage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLanguage.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblLanguage.ForeColor = System.Drawing.Color.Red
        Me.LblLanguage.Location = New System.Drawing.Point(1793, 71)
        Me.LblLanguage.Margin = New System.Windows.Forms.Padding(0, 6, 3, 0)
        Me.LblLanguage.Name = "LblLanguage"
        Me.LblLanguage.Size = New System.Drawing.Size(725, 39)
        Me.LblLanguage.TabIndex = 95
        Me.LblLanguage.Text = "يرجى إتباع تعليمات تغيير اللغة أدناه وإعادة تشغيل البرنامج مرة أخرى"
        Me.LblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.DbStat)
        Me.FlowLayoutPanel1.Controls.Add(Me.LblLanguage)
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GrpCounters)
        Me.FlowLayoutPanel1.Controls.Add(Me.PictureBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.LblUsrRNm)
        Me.FlowLayoutPanel1.Controls.Add(Me.LblSrvrNm)
        Me.FlowLayoutPanel1.Controls.Add(Me.LblLstSeen)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label9)
        Me.FlowLayoutPanel1.Controls.Add(Me.LblUsrIP)
        Me.FlowLayoutPanel1.Controls.Add(Me.PubVerLbl)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 5)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 1167, 4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(2038, 978)
        Me.FlowLayoutPanel1.TabIndex = 96
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.RadioButton1)
        Me.FlowLayoutPanel2.Controls.Add(Me.RadioButton2)
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(1441, 69)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(348, 41)
        Me.FlowLayoutPanel2.TabIndex = 99
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(220, 4)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(125, 27)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "تثبيت الشاشات"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(82, 4)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(132, 27)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "تحريك الشاشات"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'LblLstSeen
        '
        Me.LblLstSeen.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.SetFlowBreak(Me.LblLstSeen, True)
        Me.LblLstSeen.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblLstSeen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblLstSeen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblLstSeen.Location = New System.Drawing.Point(641, 566)
        Me.LblLstSeen.Margin = New System.Windows.Forms.Padding(3, 4, 1167, 4)
        Me.LblLstSeen.Name = "LblLstSeen"
        Me.LblLstSeen.Size = New System.Drawing.Size(421, 31)
        Me.LblLstSeen.TabIndex = 98
        Me.LblLstSeen.Text = "ccc"
        Me.LblLstSeen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.ExtBt)
        Me.Panel2.Location = New System.Drawing.Point(2345, 1106)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(173, 61)
        Me.Panel2.TabIndex = 97
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.SnOutBt)
        Me.Panel1.Location = New System.Drawing.Point(2156, 1106)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(181, 60)
        Me.Panel1.TabIndex = 96
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Location = New System.Drawing.Point(1968, 1106)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(181, 60)
        Me.Panel3.TabIndex = 97
        Me.Panel3.Visible = False
        '
        'TimerColctLog
        '
        Me.TimerColctLog.Interval = 600000
        '
        'WChckConn
        '
        Me.WChckConn.WorkerReportsProgress = True
        Me.WChckConn.WorkerSupportsCancellation = True
        '
        'WkrTikCount
        '
        Me.WkrTikCount.WorkerReportsProgress = True
        Me.WkrTikCount.WorkerSupportsCancellation = True
        '
        'WelcomeScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1630, 827)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.MenuSw)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "WelcomeScreen"
        Me.Opacity = 0R
        Me.RightToLeftLayout = True
        Me.Text = "VOCA Plus"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.StatBrPnlEn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatBrPnlAr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbStat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GrpCounters.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CNTXMNUPic.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimerOp As Timer
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents StatBrPnlEn As StatusBarPanel
    Friend WithEvents TimerTikCoun As Timer
    Friend WithEvents MenuSw As MenuStrip
    Public WithEvents NotifyIcon1 As NotifyIcon
    Public WithEvents CntxtMnuStrp As ContextMenuStrip
    Friend WithEvents ExtBt As Button
    Friend WithEvents SnOutBt As Button
    Friend WithEvents TimerCon As Timer
    Friend WithEvents LblUsrIP As Label
    Friend WithEvents PubVerLbl As Label
    Friend WithEvents LblUsrRNm As Label
    Friend WithEvents StatBrPnlAr As StatusBarPanel
    Friend WithEvents DbStat As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents LblClrSys As Label
    Friend WithEvents LblClrUsr As Label
    Friend WithEvents LblClrNotUsr As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GrpCounters As GroupBox
    Friend WithEvents Label0 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblReOpY As Label
    Friend WithEvents LblReadYDy As Label
    Friend WithEvents LblUnRead As Label
    Friend WithEvents LblEvDy As Label
    Friend WithEvents LblClsYDy As Label
    Friend WithEvents LblFlN As Label
    Friend WithEvents LblClsN As Label
    Friend WithEvents LblClrSamCat As Label
    Friend WithEvents LblRecivDy As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LblClsUpdted As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LblFolwDy As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LblClrOperation As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents LblSrvrNm As Label
    Friend WithEvents TimrFlsh As Timer
    Friend WithEvents Label9 As Label
    Friend WithEvents LblLanguage As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblLstSeen As Label
    Friend WithEvents TimerColctLog As Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents WChckConn As System.ComponentModel.BackgroundWorker
    Friend WithEvents WkrTikCount As System.ComponentModel.BackgroundWorker
    Friend WithEvents CNTXMNUPic As ContextMenuStrip
    Friend WithEvents UploadYourPictureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents Button1 As Button
End Class
