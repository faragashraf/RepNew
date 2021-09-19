Public Class TikNew
    Private RelatedTable As DataTable = New DataTable
    Private TxtBx As New TextBox
    Private GV As New DataGridView
    Private TickKind As Integer = 0       'ticket kind      0=Inquiry and 1=Complaint
    Private PrdKind As String = ""        'Product kind     1=Financial and 2=Postal   3=Governmental and 4=Social and 5=Other
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
            FlwSubMain.Size = New Point((Me.Size.Width * 0.7), Me.Height - 100)
            FlwTree.Size = New Point((Me.Size.Width * 0.25), Me.Height - 100)
            'TreeView1.Size = New Point(WelcomeScreen.Width - (FlowLayoutPanel4.Width + FlowLayoutPanel3.Width + 45), Me.Height - (130 + MyGroupBox3.Height + MyGroupBox3.Margin.Top + MyGroupBox3.Margin.Bottom))
            IDTxtBx.Focus()
        End If
    End Sub
#Region "Sub"
    Private Sub NewTickSub()
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
            If TypeOf Ctrol Is TextBox Or TypeOf Ctrol Is MaskedTextBox Then
                Ctrol.Enabled = True
                Ctrol.Text = ""
            ElseIf TypeOf Ctrol Is ComboBox Then
                Ctrol.Enabled = True
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

        BtnAdd.Enabled = False
        BtnClr.Enabled = False

        Phon1TxtBx.Enabled = False
        Phon2TxtBx.Enabled = False
        ComRefLbl.Text = ""
        IDTxtBx.Text = ""
        IDTxtBx.Mask = "00000000000000"
        RadNID.Checked = True

        TickKind = 0
        PrdKind = ""

        MyGroupBox2.Enabled = False


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
            Me.Text = "تسجيل استفسار جديد"
        ElseIf (RadioButton5.Checked) Then
            TickKind = 1
            Me.Text = "تسجيل شكوى جديدة"
        End If

Popul_:
        If TreeView1.Nodes.Count = 1 Or TreeView1.Nodes.Count = Nothing Then
            Dim Root As String = ""
            Dim Child1 As String = ""
            TreeView1.ImageList = ImgLst
            ' Populate Main Root
            TreeView1.Nodes.Clear()

            For Cnt_ = 0 To ProdKTable.Rows.Count - 1
                TreeView1.Nodes.Add(ProdKTable.Rows(Cnt_).Item(0).ToString, ProdKTable.Rows(Cnt_).Item(1).ToString, 1, 3)
            Next

            'Populate Products Nodes
            For Cnt_ = 0 To ProdCompTable.Rows.Count - 1
                For Each n As TreeNode In Me.TreeView1.Nodes
                    If n.Name = ProdCompTable.Rows(Cnt_).Item(1).ToString Then
                        TreeView1.SelectedNode = n
                    End If
                Next
                If Child1 <> ProdCompTable.Rows(Cnt_).Item("PrdNm").ToString Then
                    TreeView1.SelectedNode.Nodes.Add(ProdCompTable.Rows(Cnt_).Item("FnProdCd").ToString(), ProdCompTable.Rows(Cnt_).Item("PrdNm").ToString(), 1, 3)
                End If
                Child1 = ProdCompTable.Rows(Cnt_).Item("PrdNm").ToString
            Next

            ' Populate Complaints Nodes
            For Cnt_ = 0 To ProdCompTable.Rows.Count - 1
                For Cnt_1 = 0 To TreeView1.Nodes.Count - 1
                    For Cnt_2 = 0 To TreeView1.Nodes(Cnt_1).Nodes.Count - 1
                        If Split(TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).ToString, ": ")(1) = (ProdCompTable.Rows(Cnt_).Item("PrdNm").ToString) Then
                            TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).Nodes.Add(ProdCompTable.Rows(Cnt_).Item("FnSQL").ToString(), ProdCompTable.Rows(Cnt_).Item("CompNm").ToString(), 0, 2)
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
            BtnAdd.Enabled = True
            BtnClr.Enabled = False
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
                    Ctrl.AccessibleName = MendFildsTable.DefaultView(uu).Item("CDMendAccessNm").ToString
                    FlwMend.Controls.Add(Ctrl)
                ElseIf MendFildsTable.DefaultView(uu).Item("CDMendType").ToString = "TextBox!" Then
                    Dim Ctrl As New TextBox
                    Ctrl.TextAlign = HorizontalAlignment.Center
                    Ctrl.RightToLeft = RightToLeft.Yes
                    Ctrl.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                    Ctrl.Size = New Point(150, 25)
                    Ctrl.Name = MendFildsTable.DefaultView(uu).Item("CDMendNm").ToString
                    Ctrl.AccessibleName = MendFildsTable.DefaultView(uu).Item("CDMendAccessNm").ToString
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
                    Ctrl.AccessibleName = MendFildsTable.DefaultView(uu).Item("CDMendAccessNm").ToString
                    FlwMend.Controls.Add(Ctrl)
                ElseIf MendFildsTable.DefaultView(uu).Item("CDMendType").ToString = "DateTimePicker" Then
                    Dim Ctrl As New DateTimePicker
                    Ctrl.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                    Ctrl.Size = New Point(150, 25)
                    Ctrl.MaxDate = Today.AddDays(1)
                    Ctrl.Format = DateTimePickerFormat.Short
                    Ctrl.Name = MendFildsTable.DefaultView(uu).Item("CDMendNm").ToString
                    Ctrl.Value = Today.AddDays(1)
                    Ctrl.AccessibleName = MendFildsTable.DefaultView(uu).Item("CDMendAccessNm").ToString
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
            BtnAdd.Enabled = False
            BtnClr.Enabled = False
        End If
        If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0) <> PrdKind Then PrdKind = ""
    End Sub
#Region "Buttons"
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim Lbl As New Label
        Dim Txt As New TextBox

        Lbl.Name = InputBox("من فضلك أدخل اسم الحقل", "حقل إضافى",, 400, 400)
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
        BtnAdd.Enabled = False
        BtnClr.Enabled = True
    End Sub
    Private Sub BtnClr_Click(sender As Object, e As EventArgs) Handles BtnClr.Click
        FlwMend.Controls.RemoveAt(FlwMend.Controls.Count - 1)
        FlwMend.Controls.RemoveAt(FlwMend.Controls.Count - 1)
        BtnAdd.Enabled = True
        BtnClr.Enabled = False
    End Sub
#End Region
    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs)
        'NOTE: set form's KeyPreview property to True
        Select Case e.KeyCode
            Case Keys.F1
                Dim Frm As New Form
                GV = New DataGridView
                If sender.Name = "OffCmbBx" Then GV.DataSource = OfficeTable.Copy
                If sender.Name = "OriginTxtBx" Or sender.Name = "DistCmbBx" Then GV.DataSource = CountryTable.Copy
                TxtBx = sender
                AddHandler GV.CellDoubleClick, AddressOf DataGridView_CellClick
                GV.Dock = DockStyle.Fill
                Frm.Controls.Add(GV)
                Frm.WindowState = FormWindowState.Maximized
                Frm.Show()
        End Select
    End Sub
    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        'MsgBox(GV.CurrentCell.Value)
        TxtBx.Text = GV.CurrentCell.Value
        sender.parent.Close()
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
End Class