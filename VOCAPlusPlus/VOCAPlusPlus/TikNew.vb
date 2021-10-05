Imports System.Threading

Public Class TikNew
    Private RelatedTable As DataTable = New DataTable
    Private TxtBx As New TextBox

    Private TickKind As Integer = 0       'ticket kind      0=Inquiry and 1=Complaint
    Private PrdKind As String = ""        'Product kind     1=Financial and 2=Postal   3=Governmental and 4=Social and 5=Other
    Private TickSubmt As Thread
    Private SqlCuCnt_ As Integer = 0         'Sql of Last New Ticket
    Private Dt_ As DateTime          'Date of Last New Ticket
    Private DubStr As String = ""
    Dim Frm As New Form
    Dim TxBox As New TextBox
    Private GV As New DataGridView
    Dim SrcTbl As New DataTable
    Private Sub TikNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreciFlag = False Then
            Me.Close()
            WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات"
            Beep()
        Else
            FrmAllSub(Me)
            NewTickSub()
            WelcomeScreen.StatBrPnlAr.Text = ""
            Me.Size = New Point(WelcomeScreen.Width, WelcomeScreen.Height - 110)
            FlwSubMain.Size = New Point((Me.Size.Width * 0.65), Me.Height - 100)
            ComRefLbl.Size = New Point(TabControl2.Width, ComRefLbl.Size.Height)
            FlwTree.Size = New Point((Me.Size.Width * 0.3), Me.Height - 100)
            TreeView1.Size = New Point((Me.Size.Width * 0.3) - 20, Me.Height - 200)
            FlwMend.Size = New Point(FlwMend.Width, Me.Size.Height - TabControl2.Height - ComRefLbl.Height - 100)
            IDTxtBx.Focus()
        End If
    End Sub
#Region "Sub"
    Private Sub NewTickSub()
        FlwMainData.Enabled = False
        FlwMend.Enabled = True
        FlwMend.Controls.Clear()
        WelcomeScreen.StatBrPnlAr.Text = ""
        TreeView1.Enabled = True
        TreeView1.Visible = False
        TreeView1.CollapseAll()

        SubmitBtn.Visible = True
        SubmitBtn.Enabled = False
        BtnDublicate.Visible = False
        RelatedTable.Rows.Clear()
        Dim CTRLLst As New List(Of Control)
        GetAll(Me).ToList.ForEach(Sub(c)
                                      CTRLLst.Add(c)
                                  End Sub)

        For Each Ctrol As Control In CTRLLst
            If TypeOf Ctrol Is TextBox Then
                Dim TxtBox As TextBox = Ctrol
                Ctrol.Enabled = True
                Ctrol.Text = ""
                If TxtBox.ReadOnly = False Then
                    Ctrol.BackColor = Color.White
                    Ctrol.ForeColor = Color.Black
                End If
            ElseIf TypeOf Ctrol Is MaskedTextBox Then
                Dim TxtBox As MaskedTextBox = Ctrol
                Ctrol.Enabled = True
                Ctrol.Text = ""
                If TxtBox.ReadOnly = False Then
                    Ctrol.BackColor = Color.White
                    Ctrol.ForeColor = Color.Black
                End If
            ElseIf TypeOf Ctrol Is ComboBox Then
                Ctrol.Enabled = True
                Dim TxtBox As ComboBox = Ctrol
                TxtBox.SelectedIndex = -1
            ElseIf TypeOf Ctrol Is RadioButton Then
                Ctrol.Enabled = True
            End If
        Next
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton8.Checked = False
        RadioButton9.Checked = False
        RadioButton11.Checked = False
        RadioButton12.Checked = False

        BtnAdd.Visible = False
        BtnClr.Visible = False

        Phon1TxtBx.Enabled = False
        Phon2TxtBx.Enabled = False
        ComRefLbl.Text = ""
        IDTxtBx.Text = ""
        IDTxtBx.Mask = "00000000000000"
        RadNID.Checked = True

        TickKind = 0
        PrdKind = ""
        MyGroupBox3.Enabled = True
        MyGroupBox2.Enabled = False
        SubmitBtn.BackgroundImage = My.Resources.SaveRed

    End Sub
    Private Sub Mendatory()
        Timer1.Stop()
        Dim Complete_ As Integer = 0
        If PrdKind = "مالية" Then
            'Check Customer ID
            If RadNID.Checked = True And Trim(Replace(IDTxtBx.Text, " ", "")).Length = 14 Then
                Complete_ += 1
            ElseIf RadPss.Checked = True And Trim(Replace(IDTxtBx.Text, " ", "")).Length > 0 Then
                Complete_ += 1
            End If
            Label29.Visible = True
        Else
            Label29.Visible = False
        End If

        'Check Customer Phone 1
        If Phon1TxtBx.Mask.Length = Trim(Replace(Phon1TxtBx.Text, " ", "")).Length Then
            Complete_ += 1
        End If
        'Check Tree Selection
        If IsNothing(TreeView1.SelectedNode) = False Then
            If TreeView1.SelectedNode.Level = 2 Then
                Complete_ += 1
            End If
        End If


        'Check Customer Name
        If Trim(Replace(NameTxtBx.Text, " ", "")).Length > 0 Then
            Complete_ += 1
        End If
        'Check Complaint Source
        If SrcCmbBx.SelectedIndex <> -1 Then
            Complete_ += 1
        End If
        For Each Ctrl In FlwMend.Controls
            If TypeOf (Ctrl) Is TextBox Then
                If Trim(Replace(Ctrl.Text, " ", "")).Length > 0 Then
                    Complete_ += 1
                End If
            ElseIf TypeOf (Ctrl) Is MaskedTextBox Then
                If Trim(Replace(Ctrl.Mask, " ", "")).Length = Trim(Replace(Ctrl.Text, " ", "")).Length Then
                    Complete_ += 1
                End If
            ElseIf TypeOf (Ctrl) Is DateTimePicker Then
                Dim dd As Date = Format(Ctrl.MaxDate, "dd/MM/yyyy")
                Dim dd1 As Date = Format(Today.AddDays(1), "dd/MM/yyyy")
                If Format(Ctrl.value, "dd/MM/yyyy") <> Format(Today.AddDays(1), "dd/MM/yyyy") Then
                    Complete_ += 1
                End If
            End If
        Next
        Dim gg As Double = Complete_ / (4 + (FlwMend.Controls.Count) / 2)
        'If Complete_ / (5 + (FlwMend.Controls.Count) / 2) < 0.7 Then
        '    SubmitBtn.BackgroundImage = My.Resources.SaveRed1
        'ElseIf Complete_ / (5 + (FlwMend.Controls.Count) / 2) > 0.5 Then
        '    SubmitBtn.BackgroundImage = My.Resources.SaveGreen1
        'End If
        If PrdKind = "مالية" Then
            If Complete_ = 5 + (FlwMend.Controls.Count) / 2 Then
                SubmitBtn.Enabled = True
                SubmitBtn.BackgroundImage = My.Resources.SaveGreen1
            ElseIf Complete_ / (5 + (FlwMend.Controls.Count) / 2) <= 0.5 Then
                SubmitBtn.BackgroundImage = My.Resources.SaveRed
                SubmitBtn.Enabled = False
            ElseIf Complete_ / (5 + (FlwMend.Controls.Count) / 2) > 0.5 Then
                SubmitBtn.BackgroundImage = My.Resources.SaveGreen
                SubmitBtn.Enabled = False
                'Else
                '    SubmitBtn.Enabled = False
                'SubmitBtn.BackgroundImage = My.Resources.SaveRed1
            End If
        ElseIf PrdKind = "بريدية" Then
            If Complete_ = 4 + (FlwMend.Controls.Count) / 2 Then
                SubmitBtn.Enabled = True
                SubmitBtn.BackgroundImage = My.Resources.SaveGreen1
            ElseIf Complete_ / (4 + (FlwMend.Controls.Count) / 2) <= 0.5 Then
                SubmitBtn.BackgroundImage = My.Resources.SaveRed
                SubmitBtn.Enabled = False
            ElseIf Complete_ / (4 + (FlwMend.Controls.Count) / 2) > 0.5 Then
                SubmitBtn.BackgroundImage = My.Resources.SaveGreen
                SubmitBtn.Enabled = False
                'Else
                '    SubmitBtn.Enabled = False
                'SubmitBtn.BackgroundImage = My.Resources.SaveRed1
            End If
        ElseIf PrdKind = "" Then
            SubmitBtn.BackgroundImage = My.Resources.SaveRed
            SubmitBtn.Enabled = False
        End If
        Timer1.Start()
    End Sub
    Public Sub ClntData()
        Dim Fn As New APblicClss.Func
        Dim primaryKey(0) As DataColumn
        RelatedTable = New DataTable
        Invoke(Sub() NameTxtBx.Text = "")
        Invoke(Sub() AddTxtBx.Text = "")
        Invoke(Sub() Phon2TxtBx.Text = "")
        Invoke(Sub() IDTxtBx.Text = "")
        If Fn.GetTblXX("SELECT * from 

(SELECT        TkID, TkDtStart, TkDtClose, TkDuration, TkKind, TkFnPrdCd, TkCompSrc,
                             (SELECT SrcNm FROM CDSrc WHERE (SrcCd = TkCompSrc)) AS SrcNm, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkMail, dbo.TKMendFields.FildKind, dbo.TKMendFields.FildTxt
FROM            dbo.Tickets LEFT OUTER JOIN TKMendFields ON TKMendFields.FildRelted = TkID) ps
pivot (max(FildTxt) for FildKind in ([رقم الكارت],[مبلغ العملية],[تاريخ العملية],[رقم أمر الدفع],[اسم المكتب],[رقم الشحنة],[بلد الراسل],[بلد المرسل إلية])) as pvt  WHERE (TkClPh = '" & Phon1TxtBx.Text & "') ORDER BY TkID DESC;", RelatedTable, "1013&H") = Nothing Then
            primaryKey(0) = RelatedTable.Columns("TkID")
            RelatedTable.PrimaryKey = primaryKey

            If RelatedTable.Rows.Count > 0 Then

                'Invoke(Sub() Phon1TxtBx.Text = "")

                Invoke(Sub() NameTxtBx.Text = RelatedTable(0).Item("TkClNm").ToString)
                Invoke(Sub() AddTxtBx.Text = RelatedTable(0).Item("TkClAdr").ToString)
                Invoke(Sub() Phon2TxtBx.Text = RelatedTable(0).Item("TkClPh1").ToString)
                Invoke(Sub() IDTxtBx.Text = RelatedTable(0).Item("TkClNtID").ToString)
                'Invoke(Sub() Phon1TxtBx.Text = RelatedTable(0).Item("TkClPh").ToString)
                If DBNull.Value.Equals(RelatedTable(0).Item("TkMail")) = False Or (Trim(RelatedTable(0).Item("TkMail"))).Length > 0 Then
                    Invoke(Sub() MailTxtBx.Text = RelatedTable(0).Item("TkMail").ToString)
                End If
                'If Phon1TxtBx.TextLength = Phon1TxtBx.Mask.Length Then

                'ElseIf IDTxtBx.TextLength = IDTxtBx.Mask.Length Then

                'End If



                Dim Comp As Integer = 0
                Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
            End If
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
        FltrStr = ""
        Invoke(Sub() RelatedTable.DefaultView.RowFilter = String.Empty)
        Invoke(Sub() Me.Enabled = True)
        Invoke(Sub() Me.Activate())

    End Sub
#End Region
#Region "Radio Buttons"
    Private Sub RadioButto_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click, RadioButton5.Click
        ' Change Form Caption
        If PreciFlag = False Then
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            RadioButton4.Checked = False
            RadioButton5.Checked = False
            Exit Sub
        End If
        If (RadioButton4.Checked) Then
            TickKind = 0
            Me.Text = "تسجيل طلب جديد"
        ElseIf (RadioButton5.Checked) Then
            TickKind = 1
            Me.Text = "تسجيل شكوى جديدة"
        End If
        If SrcCmbBx.Items.Count = 0 Then
            SrcCmbBx.DataSource = CompSurceTable
            SrcCmbBx.SelectedIndex = -1
        End If
Popul_:
        TreeView1.Visible = True
        TreeView1.Nodes.Clear()
        If TreeView1.Nodes.Count = 1 Or TreeView1.Nodes.Count = Nothing Then
            Dim Root As String = ""
            Dim Child1 As String = ""
            TreeView1.ImageList = ImgLst
            ' Populate Main Root

            For Cnt_ = 0 To ProdKTable.Rows.Count - 1
                TreeView1.Nodes.Add(ProdKTable.Rows(Cnt_).Item(0).ToString, ProdKTable.Rows(Cnt_).Item(1).ToString, 1, 3)
            Next
            If TickKind = 0 Then
                ProdCompTable.DefaultView.RowFilter = "[CompReqst] = " & True
            Else
                ProdCompTable.DefaultView.RowFilter = "[CompReqst] = " & False
            End If

            'Populate Products Nodes
            For Cnt_ = 0 To ProdCompTable.DefaultView.Count - 1
                For Each n As TreeNode In Me.TreeView1.Nodes
                    If n.Name = ProdCompTable.DefaultView(Cnt_).Item(1).ToString Then
                        TreeView1.SelectedNode = n
                    End If
                Next
                If Child1 <> ProdCompTable.DefaultView(Cnt_).Item("PrdNm").ToString Then
                    TreeView1.SelectedNode.Nodes.Add(ProdCompTable.Rows(Cnt_).Item("FnProdCd").ToString(), ProdCompTable.DefaultView(Cnt_).Item("PrdNm").ToString(), 1, 3)
                End If
                Child1 = ProdCompTable.DefaultView(Cnt_).Item("PrdNm").ToString
            Next



            ' Populate Complaints Nodes
            For Cnt_ = 0 To ProdCompTable.DefaultView.Count - 1
                For Cnt_1 = 0 To TreeView1.Nodes.Count - 1
                    For Cnt_2 = 0 To TreeView1.Nodes(Cnt_1).Nodes.Count - 1
                        If Split(TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).ToString, ": ")(1) = (ProdCompTable.DefaultView(Cnt_).Item("PrdNm").ToString) Then
                            TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).Nodes.Add(ProdCompTable.DefaultView(Cnt_).Item("FnSQL").ToString(), ProdCompTable.DefaultView(Cnt_).Item("CompNm").ToString(), 0, 2)
                            For Cont As Integer = 0 To TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).GetNodeCount(True) - 1
                                TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).Nodes.Item(Cont).ForeColor = Color.Green
                            Next Cont
                            TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).ForeColor = Color.FromArgb(165, 42, 42)
                        End If
                    Next Cnt_2
                Next Cnt_1
            Next Cnt_
        End If

        TreeView1.Visible = True
        TreeView1.SelectedNode = Nothing
        MyGroupBox2.Enabled = True
        FlwMainData.Enabled = True
    End Sub
    Private Sub Phone1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.Click, RadioButton8.Click
        TimrPhons.Start()
        Phon1TxtBx.Enabled = True
        Phon1TxtBx.Text = ""
        If (RadioButton8.Checked) Then
            Phon1TxtBx.Mask = "00000000000"
        ElseIf (RadioButton9.Checked) Then
            Phon1TxtBx.Mask = "0000000000"
        End If
        Phon1TxtBx.Focus()
        NameTxtBx.Text = ""
        AddTxtBx.Text = ""
        Phon2TxtBx.Text = ""
        MailTxtBx.Text = ""
        RelatedTable.Rows.Clear()
    End Sub
    Private Sub RadNID_Click(sender As Object, e As EventArgs) Handles RadNID.Click, RadPss.Click
        IDTxtBx.Text = ""
        If RadNID.Checked = True Then
            IDTxtBx.Tag = "الرقم القومي"
            IDTxtBx.Mask = "00000000000000"
            RadNID.Checked = True
            RadPss.Checked = False
            Label11.Text = "الرقم القومي : "
        Else
            IDTxtBx.Tag = "رقم جواز السفر"
            IDTxtBx.Mask = "AAAAAAAAAAAAAA"
            RadNID.Checked = False
            RadPss.Checked = True
            Label11.Text = "رقم جواز السفر : "
        End If
    End Sub
    Private Sub Phone2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton12.Click, RadioButton11.Click
        TimrPhons.Start()
        Phon2TxtBx.Enabled = True
        Phon2TxtBx.Text = ""
        If (RadioButton11.Checked) Then
            Phon2TxtBx.Mask = "00000000000"
        ElseIf (RadioButton12.Checked) Then
            Phon2TxtBx.Mask = "0000000000"
        End If
        Phon2TxtBx.Focus()
    End Sub
#End Region
    Private Sub TikNew_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        If TreeView1.SelectedNode Is Nothing Then
        Else
            If TreeView1.SelectedNode.Level = 2 Then
                TreeView1.SelectedNode.Parent.Parent.Collapse(False)  'True to leave the child nodes in their Current state; false to collapse the child nodes.
            ElseIf TreeView1.SelectedNode.Level = 1 Then
                'CombProdRef.Items.Clear()
                TreeView1.SelectedNode.Parent.Collapse(False)
            ElseIf TreeView1.SelectedNode.Level = 0 Then
                'CombProdRef.Items.Clear()
                TreeView1.SelectedNode.Collapse(False)
            End If
        End If
    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        TreeView1.SelectedNode.Expand()
        BtnAdd.Enabled = True
        If (TreeView1.SelectedNode.Level) = 2 Then
            BtnAdd.Visible = True
            BtnClr.Visible = False
            MendFildsTable.DefaultView.RowFilter = "[MendCdFn]" & " = " & TreeView1.SelectedNode.Name
            FlwMend.Controls.Clear()
            For uu = 0 To MendFildsTable.DefaultView.Count - 1
                Dim Lbl As New Label
                Lbl.AutoSize = False
                Lbl.RightToLeft = RightToLeft.Yes
                Lbl.TextAlign = ContentAlignment.MiddleRight
                Lbl.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                Lbl.Size = New Point(100, 25)
                Lbl.Text = MendFildsTable.DefaultView(uu).Item("CDMendTxt") & " : "
                FlwMend.Controls.Add(Lbl)
                If MendFildsTable.DefaultView(uu).Item("CDMendType").ToString = "TextBox" Then
                    Dim Ctrl As New TextBox
                    Ctrl.TextAlign = HorizontalAlignment.Center
                    Ctrl.RightToLeft = RightToLeft.Yes
                    Ctrl.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                    Ctrl.Size = New Point(150, 25)
                    Ctrl.Name = MendFildsTable.DefaultView(uu).Item("CDMendNm").ToString
                    Ctrl.Tag = MendFildsTable.DefaultView(uu).Item("CDMendAccessNm").ToString
                    FlwMend.Controls.Add(Ctrl)
                ElseIf MendFildsTable.DefaultView(uu).Item("CDMendType").ToString = "TextBox!" Then
                    Dim Ctrl As New TextBox
                    Ctrl.TextAlign = HorizontalAlignment.Center
                    Ctrl.RightToLeft = RightToLeft.Yes
                    Ctrl.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                    Ctrl.Size = New Point(150, 25)
                    Ctrl.Name = MendFildsTable.DefaultView(uu).Item("CDMendNm").ToString
                    Ctrl.Tag = MendFildsTable.DefaultView(uu).Item("CDMendAccessNm").ToString
                    FlwMend.Controls.Add(Ctrl)
                    Ctrl.ReadOnly = True
                    AddHandler Ctrl.KeyDown, AddressOf TextBox_KeyDown
                ElseIf MendFildsTable.DefaultView(uu).Item("CDMendType").ToString = "MaskedTextBox" Then
                    Dim Ctrl As New MaskedTextBox
                    Ctrl.TextAlign = HorizontalAlignment.Center
                    Ctrl.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                    Ctrl.Size = New Point(150, 25)
                    Ctrl.Mask = MendFildsTable.DefaultView(uu).Item("CDMendMskd").ToString
                    Ctrl.Name = MendFildsTable.DefaultView(uu).Item("CDMendNm").ToString
                    Ctrl.Tag = MendFildsTable.DefaultView(uu).Item("CDMendAccessNm").ToString
                    AddHandler Ctrl.Enter, AddressOf Masked_Enter
                    FlwMend.Controls.Add(Ctrl)
                ElseIf MendFildsTable.DefaultView(uu).Item("CDMendType").ToString = "DateTimePicker" Then
                    Dim Ctrl As New DateTimePicker
                    Ctrl.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                    Ctrl.Size = New Point(150, 25)
                    Ctrl.MaxDate = Today.AddDays(1)
                    Ctrl.Format = DateTimePickerFormat.Short
                    Ctrl.Name = MendFildsTable.DefaultView(uu).Item("CDMendNm").ToString
                    Ctrl.Value = Today.AddDays(1)
                    Ctrl.Tag = MendFildsTable.DefaultView(uu).Item("CDMendAccessNm").ToString
                    FlwMend.Controls.Add(Ctrl)
                End If
            Next
            FrmAllSub(Me)
            'TempClr = MendFildsTable.Rows.Find(TreeView1.SelectedNode.Name)
            'Dim BKClr = Split(TempClr.ItemArray(2), ",")
            'Timer1.Start()
            PrdKind = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0)
            Prdct.Text = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1)
            Comp.Text = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(2)
        ElseIf (TreeView1.SelectedNode.Level) < 2 Then
            PrdKind = ""
            Prdct.Text = ""
            Comp.Text = ""
            BtnAdd.Visible = False
            BtnClr.Visible = False
        End If
        If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0) <> PrdKind Then PrdKind = ""
    End Sub
#Region "Buttons"
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim Lbl As New Label
        Dim Txt As New TextBox

        Lbl.Name = "Other" ' InputBox("من فضلك أدخل اسم الحقل", "حقل إضافى",, 400, 400)
        Lbl.Text = Lbl.Name & " : "
        Lbl.AutoSize = False
        Lbl.RightToLeft = RightToLeft.Yes
        Lbl.TextAlign = ContentAlignment.MiddleRight
        Lbl.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        Lbl.Size = New Point(100, 25)
        Txt.RightToLeft = RightToLeft.Yes
        Txt.TextAlign = HorizontalAlignment.Center
        Txt.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        Txt.Size = New Point(150, 25)
        Txt.Name = "Other"
        FlwMend.Controls.Add(Lbl)
        FlwMend.Controls.Add(Txt)
        BtnAdd.Visible = False
        BtnClr.Visible = True
    End Sub
    Private Sub BtnClr_Click(sender As Object, e As EventArgs) Handles BtnClr.Click
        FlwMend.Controls.RemoveAt(FlwMend.Controls.Count - 1)
        FlwMend.Controls.RemoveAt(FlwMend.Controls.Count - 1)
        BtnAdd.Visible = True
        BtnClr.Visible = False
    End Sub
#End Region
    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs)
        'NOTE: set form's KeyPreview property to True
        Select Case e.KeyCode
            Case Keys.F1
                Frm = New Form
                GV = New DataGridView
                Dim Flow As New FlowLayoutPanel
                TxBox = New TextBox
                SrcTbl = New DataTable
                If sender.Name = "OffCmbBx" Then SrcTbl = OfficeTable.Copy
                If sender.Name = "OriginTxtBx" Or sender.Name = "DistCmbBx" Then SrcTbl = CountryTable.Copy
                TxtBx = sender
                SrcTbl.DefaultView.RowFilter = String.Empty
                GV.DataSource = SrcTbl.DefaultView
                AddHandler GV.CellDoubleClick, AddressOf DataGridView_CellClick
                AddHandler TxBox.TextChanged, AddressOf Txt_TextChanged
                AddHandler Frm.Load, AddressOf Frm_Load
                Flow.SetFlowBreak(TxBox, False)
                Flow.Dock = DockStyle.Fill
                Flow.FlowDirection = FlowDirection.RightToLeft
                GV.AllowUserToAddRows = False
                GV.AllowUserToDeleteRows = False
                GV.ReadOnly = True
                TxBox.Font = New Font("Times New Roman", 14, FontStyle.Regular)
                GV.DefaultCellStyle.Font = New Font("Times New Roman", 14, FontStyle.Regular)
                Frm.Controls.Add(Flow)
                Flow.Controls.Add(TxBox)
                Flow.Controls.Add(GV)
                Frm.ShowDialog()
        End Select
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs)
        Frm.BackColor = Color.White
        GV.AutoResizeColumns()
        GV.RightToLeft = RightToLeft.Yes
        If Me.ActiveControl.Name = "OriginTxtBx" Or ActiveControl.Name = "DistCmbBx" Then
            sender.Text = "أسماء الدول"
        ElseIf ActiveControl.Name = "OffCmbBx" Then
            sender.Text = "أسماء المكاتب"
            'GV.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End If
        TxBox.Size = New Point(250, 50)
        TxBox.TextAlign = HorizontalAlignment.Center
        Frm.Size = New Point(GV.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 80, 600)
        Frm.MaximumSize = New Point(GV.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 80, 600)
        Frm.MinimumSize = New Point(GV.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 80, 600)
        GV.Size = New Point(GV.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 60, 530)
        Frm.Location = New Point(0, 35)
    End Sub
    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If Me.ActiveControl.Name = "OriginTxtBx" Or ActiveControl.Name = "DistCmbBx" Then TxtBx.Text = GV.CurrentRow.Cells(1).Value
        If ActiveControl.Name = "OffCmbBx" Then TxtBx.Text = GV.CurrentRow.Cells(0).Value
        sender.parent.parent.Close()
    End Sub
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs)
        If Frm.Text = "أسماء المكاتب" Then SrcTbl.DefaultView.RowFilter = "OffNm1 like '%" & TxBox.Text & "%'"
        If Frm.Text = "أسماء الدول" Then
            SrcTbl.DefaultView.RowFilter = "[CounNm] like '%" & TxBox.Text & "%'"
        End If
        GV.DataSource = SrcTbl.DefaultView
    End Sub
    Private Sub TimrPhons_Tick(sender As Object, e As EventArgs) Handles TimrPhons.Tick
        If RadioButton8.Checked = True Then
            If PictureBox1.Size.Width > 24 Then
                PictureBox1.Size = New Point(PictureBox1.Size.Width - 1, 44)
                PictureBox1.Location = New Point(PictureBox1.Location.X + 0.5, PictureBox1.Location.Y + 1)
            Else
                PictureBox1.Size = New Point(PictureBox1.Size.Width + 1, 44)
                PictureBox1.Location = New Point(PictureBox1.Location.X - 0.5, PictureBox1.Location.Y - 1)
            End If
        End If
        If RadioButton9.Checked = True Then
            If PictureBox2.Size.Width > 43 Then
                PictureBox2.Size = New Point(PictureBox2.Size.Width - 1, 42)
                PictureBox2.Location = New Point(PictureBox2.Location.X + 0.5, PictureBox2.Location.Y + 1)
            Else
                PictureBox2.Size = New Point(PictureBox2.Size.Width + 1, 42)
                PictureBox2.Location = New Point(PictureBox2.Location.X - 0.5, PictureBox2.Location.Y - 1)
            End If
        End If
        If RadioButton11.Checked = True Then
            If PictureBox3.Size.Width > 24 Then
                PictureBox3.Size = New Point(PictureBox3.Size.Width - 1, 44)
                PictureBox3.Location = New Point(PictureBox3.Location.X + 0.5, PictureBox3.Location.Y + 1)
            Else
                PictureBox3.Size = New Point(PictureBox3.Size.Width + 1, 44)
                PictureBox3.Location = New Point(PictureBox3.Location.X - 0.5, PictureBox3.Location.Y - 1)
            End If
        End If
        If RadioButton12.Checked = True Then
            If PictureBox4.Size.Width > 43 Then
                PictureBox4.Size = New Point(PictureBox4.Size.Width - 1, 42)
                PictureBox4.Location = New Point(PictureBox4.Location.X + 0.5, PictureBox4.Location.Y + 1)
            Else
                PictureBox4.Size = New Point(PictureBox4.Size.Width + 1, 42)
                PictureBox4.Location = New Point(PictureBox4.Location.X - 0.5, PictureBox4.Location.Y - 1)
            End If
        End If
    End Sub
    Private Sub Masked_Enter(sender As Object, e As EventArgs)
        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    End Sub
    Private Sub Phon1TxtBx_TextChanged(sender As Object, e As EventArgs) Handles Phon1TxtBx.TextChanged
        Cnt_ = 0
        For cnt_1 = 1 To Phon1TxtBx.TextLength
            If Mid(Phon1TxtBx.Text, cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnt_ += 1
            End If
            Trim(Phon1TxtBx.Text)
        Next
        'If Cnt_ = Phon1TxtBx.TextLength Then
        'End If
        If Trim(Phon1TxtBx.Text).Length = Phon1TxtBx.Mask.Length Then
            Dim ClntThrd As New Thread(AddressOf ClntData)
            ClntThrd.IsBackground = True
            Phon1TxtBx.BackColor = Color.FromArgb(128, 255, 128)
            Phon1TxtBx.ForeColor = Color.Black
            WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ............."
            TreeView1.Visible = True
            ClntThrd.Start()
            Me.Enabled = False
        Else
            Phon1TxtBx.BackColor = Color.OrangeRed
            Phon1TxtBx.ForeColor = Color.Yellow
            TreeView1.Visible = False
            WelcomeScreen.StatBrPnlAr.Text = ""
            NameTxtBx.Text = ""
            AddTxtBx.Text = ""
            Phon2TxtBx.Text = ""
            MailTxtBx.Text = ""
        End If
    End Sub
    Private Sub SubmtTick()
        Dim Def As New APblicClss.Defntion
        Dim Fn As New APblicClss.Func
        Dim Trck As String = ""
        Dim lodingStr As String = ""

        lodingStr = "جاري تسجيل البيانات ..."

        'For Cnt_ = 1 To TrackMskBx.TextLength
        '    If Mid(TrackMskBx.Text, Cnt_, 1) <> " " Then
        '        Trck &= Mid(TrackMskBx.Text, Cnt_, 1)
        '    End If
        'Next
        'If TransDtPicker.Value = Today.AddDays(1) Then
        '    TranDt = ""
        'Else
        '    TranDt = Format(TransDtPicker.Value, "yyyy/MM/dd").ToString
        'End If

        Dim sqlComminsert_3 As New SqlCommand            'SQL Command
        Dim sqlComminsert_4 As New SqlCommand            'SQL Command
        Def.sqlComminsert_1 = New SqlCommand
        Def.sqlComminsert_2 = New SqlCommand
        Try
            If Def.CONSQL.State = ConnectionState.Closed Then
                Def.CONSQL.Open()
            End If
            Def.sqlComminsert_1.Connection = Def.CONSQL
        Def.sqlComminsert_2.Connection = Def.CONSQL            'insert Update into Update Table
        sqlComminsert_3.Connection = Def.CONSQL
        sqlComminsert_4.Connection = Def.CONSQL
        sqlComm.Connection = Def.CONSQL                    'Get ID & Date & UserID
        Def.sqlComminsert_1.CommandType = CommandType.Text
        Def.sqlComminsert_2.CommandType = CommandType.Text
        sqlComminsert_3.CommandType = CommandType.Text
        sqlComminsert_4.CommandType = CommandType.Text
        sqlComm.CommandType = CommandType.Text


            Dim Flwer As String = Nothing
            Dim Flwer_ As String = Nothing
            Dim Evnt_ As String = Nothing


            If TickKind = 0 Then
                Flwer = ", TkEmpNm"
                Flwer_ = "','" & Usr.PUsrID
                Evnt_ = "The Request has been Recieved"

            ElseIf TickKind = 1 Then
                If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
                    Flwer = ", TkEmpNm"
                    Flwer_ = "','" & Usr.PUsrID
                ElseIf Usr.PUsrCalCntr = False Then

                End If
                Evnt_ = "The Complaint has been Recieved"
            End If
            Invoke(Sub() Def.sqlComminsert_1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID,TkDetails, TkEmpNm0, TkMail" & Flwer & ") VALUES (0, '" & TickKind & "','" &
                            TreeView1.SelectedNode.Name & "','" & SrcCmbBx.SelectedValue & "','" & Trim(NameTxtBx.Text) & "','" & Phon1TxtBx.Text & "','" & Phon2TxtBx.Text & "','" & AddTxtBx.Text & "','" & IDTxtBx.Text & "','" & DetailsTxtBx.Text & DubStr & "','" & Usr.PUsrID & "','" & MailTxtBx.Text & Flwer_ & "');")

            Invoke(Sub() Def.sqlComminsert_2.CommandText = "INSERT into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES 
                                                                   ((Select Max(TkSQL) As RelationTkID FROM Tickets where TkEmpNm0 = " & Usr.PUsrID & "),'" & Evnt_ & "','" & "1" & "','" & "0" & "','" & OsIP() & "','" & Usr.PUsrID & "');")

            sqlComminsert_3.CommandText = "update Tickets set TkID = MaxID from (select MAX(TkSQL) AS MaxID, MAX(TkDtStart) AS MaxDt, TkEmpNm0 from Tickets where TkEmpNm0  = " & Usr.PUsrID & " GROUP BY TkEmpNm0) As MaxTable INNER JOIN Tickets ON Tickets.TkSQL = MaxTable.MaxID;"
            sqlComminsert_4.CommandText = "select MAX(TkSQL) AS MaxID, MAX(TkDtStart) AS MaxDt, MAX(TkID) AS Max_ from TkEvent INNER JOIN Tickets ON TkEvent.TkupTkSql = Tickets.TkSQL GROUP BY TkupUser HAVING (TkupUser  = " & Usr.PUsrID & ");"
            Tran = Def.CONSQL.BeginTransaction()
            Def.sqlComminsert_1.Transaction = Tran
            Def.sqlComminsert_2.Transaction = Tran
            sqlComminsert_3.Transaction = Tran
            sqlComminsert_4.Transaction = Tran
            Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(Def.CONSQL, SqlBulkCopyOptions.Default, Tran)
            sqlComm.Transaction = Tran
            Def.sqlComminsert_1.ExecuteNonQuery()
            Def.sqlComminsert_2.ExecuteNonQuery()
            sqlComminsert_3.ExecuteNonQuery()
            Reader_ = sqlComminsert_4.ExecuteReader

            Reader_.Read()
            SqlCuCnt_ = Reader_!MaxID
            Dt_ = Reader_!MaxDt
            Reader_.Close()

            If TickKind = 0 Then
                Invoke(Sub() ComRefLbl.Text = "طلب رقم :  " & SqlCuCnt_)
            Else
                Invoke(Sub() ComRefLbl.Text = "شكوى رقم : " & SqlCuCnt_)
            End If


            SQLBulkCopy.DestinationTableName = "TKMendFields"

            Dim MedTbl As New DataTable
            MedTbl.Columns.Add("FildRelted")
            MedTbl.Columns.Add("FildKind")
            MedTbl.Columns.Add("FildTxt")

            Dim Kind_ As New List(Of String)
            Dim Data_ As New List(Of String)

            For Each Ctrl In FlwMend.Controls
                If TypeOf (Ctrl) Is Label Then
                    Kind_.Add(Mid(Ctrl.Text, 1, Ctrl.Text.Length - 3))
                ElseIf TypeOf (Ctrl) Is Label = False Then
                    Data_.Add(Trim(Replace(Ctrl.Text, " ", "")))
                End If
            Next
            For GG = 0 To Kind_.Count - 1
                MedTbl.Rows.Add(SqlCuCnt_, Kind_(GG), Data_(GG))
            Next

            SQLBulkCopy.ColumnMappings.Add("FildRelted", "FildRelted")
            SQLBulkCopy.ColumnMappings.Add("FildKind", "FildKind")
            SQLBulkCopy.ColumnMappings.Add("FildTxt", "FildTxt")
            SQLBulkCopy.WriteToServer(MedTbl)
            Tran.Commit()
            SQLBulkCopy.Close()
            Invoke(Sub() DateTxtBx.Text = Dt_)

            'Def.CONSQL.Close()
            'SqlConnection.ClearPool(Def.CONSQL)

            TreeView1.Enabled = False
            Invoke(Sub() SubmitBtn.Visible = False)
            Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "تم تسجيل البيان بنجاح")
            Invoke(Sub() BtnDublicate.Visible = True)
            DubStr = ""
            Invoke(Sub() Me.Enabled = True)
            Invoke(Sub() Me.Activate())
            Invoke(Sub() TimrPhons.Stop())
            Invoke(Sub() FlwMainData.Enabled = False)
            Invoke(Sub() FlwMend.Enabled = False)
            Invoke(Sub() MyGroupBox3.Enabled = False)
        Catch ex As Exception
            Tran.Rollback()
            Fn.AppLog("0000&H", ex.Message, sqlComminsert_1.CommandText & "_" & sqlComminsert_2.CommandText & "_" & sqlComminsert_3.CommandText & "_" & sqlComminsert_4.CommandText)
            MsgErr("كود خطأ : " & "1011&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & ex.Message)
        End Try
        Invoke(Sub() Me.Enabled = True)
        Invoke(Sub() Me.Activate())
        Invoke(Sub() TimrPhons.Stop())
    End Sub
    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        TickSubmt = New Thread(AddressOf SubmtTick)
        TickSubmt.IsBackground = True
        WelcomeScreen.StatBrPnlAr.Text = "جاري تسجيل البيانات ..........."
        TreeView1.Visible = True
        TickSubmt.Start()
        Me.Enabled = False
    End Sub
    Private Sub SrcCmbBx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SrcCmbBx.SelectedIndexChanged
        SubmitBtn.Enabled = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'If TreeView1.SelectedNode Is Nothing Then
        '    'Label18.Text = ""
        '    Exit Sub
        'Else
        '    If TreeView1.SelectedNode.Level = 2 Then
        Mendatory()
        '        'TmrActv.Start()
        '    Else
        '        'Label18.Text = ""
        '        'TmrActv.Stop()
        '    End If
        'End If
    End Sub
    Private Sub MailTxtBx_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MailTxtBx.Validating
        If IntUtly.IsValidEmail(MailTxtBx.Text) Then
            ''ok
        Else
            Dim result As DialogResult _
        = MessageBox.Show("The email address you entered is not valid." &
                                   " Do you want re-enter it?", "Invalid Email Address",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If result = DialogResult.Yes Then
                e.Cancel = True
            ElseIf result = DialogResult.No Then
                MailTxtBx.Text = ""
            End If
        End If
    End Sub
    Private Sub NewBtn_Click(sender As Object, e As EventArgs) Handles NewBtn.Click
        NewTickSub()
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Close()
    End Sub
    Private Sub BtnDublicate_Click(sender As Object, e As EventArgs) Handles BtnDublicate.Click
        DubStr = vbCrLf & vbCrLf & "إضافة تلقائية من النظام: " & vbCrLf & "تم تسجيل هذه الشكوى للعميل عن طريق استخدم زر التكرار"
        ComRefLbl.Text = ""
        Invoke(Sub() FlwMainData.Enabled = True)
        Invoke(Sub() FlwMend.Enabled = True)
        TreeView1.Enabled = True
        Invoke(Sub() SubmitBtn.Visible = True)
        Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
        Timer1.Start()
        Invoke(Sub() BtnDublicate.Visible = False)
        Invoke(Sub() MyGroupBox3.Enabled = True)
    End Sub
End Class