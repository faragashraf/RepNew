Imports System.Threading
Imports Microsoft.Exchange.WebServices.Data

Public Class TicketEditNew
    Dim TickKind As Integer = 0       'ticket kind      0=Inquiry and 1=Complaint
    Dim PrdKind As String = ""        'Product kind     1=Financial and 2=Postal   3=Governmental and 4=Social and 5=Other
    Dim TickKindFltr As Integer = 2   'ticket kind      0=Inquiry and 1=Complaint
    Dim TicOpnFltr As Integer = 2      'ticket Sttaus   0=Open and 1=Close and 2=All
    Dim SqlCuCnt_ As Integer = 0         'Sql of Last New Ticket
    Dim RelatedTable As DataTable = New DataTable
    Dim FltrStr As String = ""
    Dim DubStr As String = ""
    Dim ReAssgnTbl As DataTable = New DataTable()
    Dim BKClr(2) As String
    Dim PrdBol As Boolean = False
    Dim TickSubmt As Thread
    Dim TickOffSubmt As Thread
    Dim UpTxt As String = ""
    Dim ReAssgnSTR As String = ""
    Dim EditTable As DataTable
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub NewTeckit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreciFlag = False Then
            Me.Close()
            WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات"
            Beep()
        Else
            WelcomeScreen.StatBrPnlAr.Text = ""
            NewTickSub()
            'Me.Width = screenWidth - 200
            Me.Size = New Point(WelcomeScreen.Width - 12, WelcomeScreen.Height - 110)
            FlowLayoutPanel4.Size = New Point((FlowLayoutPanel4.Size.Width), Me.Height - 160)
            FlowLayoutPanel2.Size = New Point((Me.Size.Width * 0.25), Me.Height - 160)
            FlowLayoutPanel3.Size = New Point((Me.Size.Width * 0.1), Me.Height - 160)
            TreeView1.Size = New Point((FlowLayoutPanel2.Width), FlowLayoutPanel2.Height - 50)
            ChckReAssign.Margin = New System.Windows.Forms.Padding(ChckReAssign.Margin.Left, ChckReAssign.Margin.Top, (WelcomeScreen.Width / 2) - 450, ChckReAssign.Margin.Bottom)
            Panel2.Margin = New System.Windows.Forms.Padding(3, WelcomeScreen.Height - 350 - Panel2.Height, WelcomeScreen.Width - 100 - Panel2.Width, 3)
            TikID.Focus()
        End If
    End Sub
    Private Sub NewTickSub()
        DubStr = ""
        BKClr(0) = 210
        BKClr(1) = 241
        BKClr(2) = 255
        TkTransDate.Value = Today.AddDays(1)
        BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TabPage1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        WelcomeScreen.StatBrPnlAr.Text = ""


        TreeView1.Enabled = True
        TreeView1.Visible = False
        TreeView1.CollapseAll()

        PostalGroup.Visible = False
        FinancialGroup.Visible = False
        CombProdRef.Visible = False

        SubmitBtn.Visible = True
        SubmitBtn.Enabled = False

        RelatedTable.Rows.Clear()


        Dim CTRLLst As New List(Of Control)
        GetAll(Me).ToList.ForEach(Sub(c)
                                      CTRLLst.Add(c)
                                  End Sub)

        For Each Ctrol As Control In CTRLLst
            If TypeOf Ctrol Is TextBox Then
                Dim TxtBox As TextBox = Ctrol
                Ctrol.Enabled = True
                If Ctrol.Name <> "TikID" Then Ctrol.Text = ""
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
                TxtBox.ResetText()
            ElseIf TypeOf Ctrol Is RadioButton Then
                Ctrol.Enabled = True
            ElseIf TypeOf Ctrol Is DateTimePicker Then
                Ctrol.Enabled = True
            End If
        Next




        TkDtStart.Enabled = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton8.Checked = False
        RadioButton9.Checked = False
        RadioButton11.Checked = False
        RadioButton12.Checked = False

        TkClPh.Enabled = False
        TkClPh1.Enabled = False
        OffArea.SelectedIndex = -1
        OffNm12TkOffNm.SelectedIndex = -1
        CounNmConsign2TkConsigCoun.SelectedIndex = -1
        SrcNm2TkCompSrc.SelectedIndex = -1
        TkCardNo.Text = ""
        TkClNtID.Text = ""
        'TkClNtID.Mask = "00000000000000"
        'RadNID.Checked = True
        TkGBNo.Text = ""
        TkAmount.Text = "0"
        TkShpNo.Text = ""
        CounNmSender.Text = ""

        TickKind = 0
        PrdKind = ""

        MyGroupBox2.Enabled = False
        FlowLayoutPanel2.Visible = False
        FlowLayoutPanel3.Visible = False
        FlowLayoutPanel4.Visible = False
        FlowLayoutPanel2.Enabled = True
        FlowLayoutPanel4.Enabled = True
        'OfficeTable.DefaultView.RowFilter = String.Empty
    End Sub
    Private Sub Mendatory()
        Dim Cnt_1 As Integer = 0
        Dim MendRw As DataRow

        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        If TikID.TextLength > 0 Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If

        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX


        If TreeView1.SelectedNode IsNot Nothing Then
            If TreeView1.SelectedNode.Level = 2 Then
                MendRw = ProdCompTable.Rows.Find(TreeView1.SelectedNode.Name)
                If DBNull.Value.Equals(MendRw.ItemArray(7)) = False Then
                    If (MendRw.ItemArray(7).Length) > 0 Then                          ' Adjust TextBox Length according to LablRef Length
                        If CombProdRef.Items.Count = 0 Then
                            For Cnt_ = 0 To Split(MendRw.ItemArray(7), "-").Count - 1
                                CombProdRef.Items.Add(Split(MendRw.ItemArray(7), "-")(Cnt_))
                            Next
                            CombProdRef.Width = 35 + Split(MendRw.ItemArray(7), "-")(0).Length * 10
                            If CombProdRef.Items.Count > 0 Then CombProdRef.SelectedIndex = 0
                        End If

                        TkShpNo.MaxLength = 15 - CombProdRef.Text.Length
                        TkCardNo.MaxLength = 19 - CombProdRef.Text.Length
                    End If
                End If
                LblHelp.Text = MendRw.ItemArray(11).ToString
                ChckReAssign.Enabled = True
            Else
                ChckReAssign.Enabled = False
                Exit Sub
            End If
        Else
            ChckReAssign.Enabled = False
            Exit Sub
        End If






        'If TickKind = 1 Then         '-----------If Complaint True ---------------
        For Cnt_ = 0 To 11
            For Each c As Control In FlowLayoutPanel4.Controls
                If c.TabIndex <= 4 And c.TabIndex > 0 Then
                    If Trim(c.Text).Length = 0 Then
                        If Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "Y" And c.TabIndex = Cnt_ Then
                            c.AccessibleName = "Mendatory"
                        ElseIf Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "X" And c.TabIndex = Cnt_ Then
                            c.AccessibleName = "None"
                        End If
                    Else
                        c.AccessibleName = "None"
                    End If
                End If
            Next c
            For Each c As Control In FlowLayoutPanel4.Controls
                If Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "Y" And c.TabIndex = Cnt_ + 2001 Then
                    c.Text = "*"
                ElseIf Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "X" And c.TabIndex = Cnt_ + 2001 Then
                    c.Text = ""
                End If
            Next c
            For Each c As Control In FinancialGroup.Controls
                If Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "Y" And c.TabIndex = Cnt_ + 2001 Then
                    c.Text = "*"
                ElseIf Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "X" And c.TabIndex = Cnt_ + 2001 Then
                    c.Text = ""
                End If
            Next c

            For Each c As Control In PostalGroup.Controls
                If Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "Y" And c.TabIndex = Cnt_ + 2001 Then
                    c.Text = "*"
                ElseIf Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "X" And c.TabIndex = Cnt_ + 2001 Then
                    c.Text = ""
                End If
            Next c
        Next Cnt_
        If Mid(MendRw.ItemArray(6), 1, 1) = "Y" Then
            Cnt_ = 0
            For Cnt_1 = 1 To 11
                If Mid(TkClPh.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            If Cnt_ < TkClPh.TextLength Then
                TkClPh.AccessibleName = "Mendatory"
            Else
                TkClPh.AccessibleName = "None"
            End If
        Else
            TkClPh.AccessibleName = "None"
        End If
        If Mid(MendRw.ItemArray(6), 6, 1) = "Y" Then
            TkShpNo.Enabled = True
            If DBNull.Value.Equals(MendRw.ItemArray(7)) = False Then
                'Put ProdRef Value in Track No Start
                TkShpNo.Text = CombProdRef.Text + Mid(TkShpNo.Text, CombProdRef.Text.Length + 1, 19 - CombProdRef.Text.Length + 1)
            End If

            If MendRw.ItemArray(9) = True Then
                TkShpNo.Mask = "LLL 00000000 LL"
                PrdBol = True
                If Mid(TkShpNo.Text, 2, 1).CompareTo("[A-Z][a-z]*") = -1 And Mid(TkShpNo.Text, 3, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TkShpNo.Text, 5, 8).CompareTo("[0-9]*") = -1 Or Mid(TkShpNo.Text, 14, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TkShpNo.Text, 15, 1).CompareTo("[A-Z][a-z]*") = -1 Then
                    TkShpNo.AccessibleName = "Mendatory"
                Else
                    TkShpNo.AccessibleName = "None"
                End If
            Else
                PrdBol = False
                TkShpNo.Mask = "LL 000000000 LL"
                If Mid(TkShpNo.Text, 2, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TkShpNo.Text, 4, 9).CompareTo("[0-9]*") = -1 Or Mid(TkShpNo.Text, 14, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TkShpNo.Text, 15, 1).CompareTo("[A-Z][a-z]*") = -1 Then
                    TkShpNo.AccessibleName = "Mendatory"
                Else
                    TkShpNo.AccessibleName = "None"
                End If
            End If

            'If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1) = "ايجى ميل" Then

            'Else

            'End If

        Else
            TkShpNo.AccessibleName = "None"
            TkShpNo.Text = ""
            TkShpNo.Enabled = False
            TkShpNo.Text = ""
        End If
        If CounNmConsign2TkConsigCoun.Text.Length = 0 Then
            If Mid(MendRw.ItemArray(6), 7, 1) = "Y" Then
                CounNmConsign2TkConsigCoun.AccessibleName = "Mendatory"
            Else
                CounNmConsign2TkConsigCoun.AccessibleName = "None"
            End If
        Else
            CounNmConsign2TkConsigCoun.AccessibleName = "None"
        End If
        Cnt_ = 0

        If Mid(MendRw.ItemArray(6), 8, 1) = "Y" Then
            TkCardNo.Enabled = True

            'If CombProdRef.Text <> Mid(Replace(TkCardNo.Text, " ", ""), 1, CombProdRef.Text.Length) Then
            '    MsgBox(Replace(Trim(Mid(TkCardNo.Text, 1, CombProdRef.Text.Length)), " ", ""))
            'End If


            If DBNull.Value.Equals(MendRw.ItemArray(7)) = False Then
                'Put ProdRef Value in Acc No No Start
                TkCardNo.Text = CombProdRef.Text + Mid(TkCardNo.Text, CombProdRef.Text.Length + 2, 19 - CombProdRef.Text.Length + 1)
            End If

            For Cnt_1 = 1 To 19
                If Mid(TkCardNo.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            If Cnt_ < 16 Then
                TkCardNo.AccessibleName = "Mendatory"
            Else
                TkCardNo.AccessibleName = "None"
            End If
        Else
            TkCardNo.AccessibleName = "None"
            TkCardNo.Text = ""
            TkCardNo.Enabled = False
            TkCardNo.Text = ""
        End If

        If Mid(MendRw.ItemArray(6), 9, 1) = "Y" Then
            Cnt_ = 0
            For Cnt_1 = 1 To 2
                If Mid(TkGBNo.Text, Cnt_1, 1).CompareTo("[A-Z][a-z]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            For Cnt_1 = 3 To 16
                If Mid(TkGBNo.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            If Cnt_ < 16 Then
                TkGBNo.AccessibleName = "Mendatory"
            Else
                TkGBNo.AccessibleName = "None"
            End If
        Else
            TkGBNo.AccessibleName = "None"
        End If
        If Mid(MendRw.ItemArray(6), 10, 1) = "Y" Then

            If IsNothing(Replace(TkClNtID.Text, " ", "")) = True Then
                TkClNtID.AccessibleName = "Mendatory"
            Else
                If Replace(TkClNtID.Text, " ", "").Length <> 14 Then
                    TkClNtID.AccessibleName = "Mendatory"
                Else
                    TkClNtID.AccessibleName = "None"
                End If
            End If
        Else
            TkClNtID.AccessibleName = "None"
        End If

        If TkAmount.Text = "0" Then
            If Mid(MendRw.ItemArray(6), 11, 1) = "Y" Then
                TkAmount.AccessibleName = "Mendatory"
            Else
                TkAmount.AccessibleName = "None"
            End If
        Else
            TkAmount.AccessibleName = "None"
        End If
        If TkTransDate.Value > Today Then
            If Mid(MendRw.ItemArray(6), 12, 1) = "Y" Then
                TkTransDate.AccessibleName = "Mendatory"
            Else
                TkTransDate.AccessibleName = "None"
            End If
        Else
            TkTransDate.AccessibleName = "None"
        End If
        'Else
        '    For Cnt_ = 0 To 11
        '        For Each c As Control In TabPage1.Controls
        '            If c.TabIndex > 0 And c.TabIndex <= 2 Or c.TabIndex = 4 Then
        '                If c.Text.Length = 0 Then
        '                    If Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "Y" And c.TabIndex = Cnt_ Then
        '                        c.AccessibleName = "Mendatory"
        '                    ElseIf Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "X" And c.TabIndex = Cnt_ Then
        '                        c.AccessibleName = "None"
        '                    End If
        '                Else
        '                    c.AccessibleName = "None"
        '                End If
        '            ElseIf c.TabIndex = 3 Then
        '                c.AccessibleName = "None"
        '            End If
        '        Next c
        '    Next Cnt_
        '    If Mid(MendRw.ItemArray(6), 1, 1) = "Y" Then
        '        Cnt_ = 0
        '        For Cnt_1 = 1 To 11
        '            If Mid(Phon1TxtBx.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
        '                Cnt_ += 1
        '            End If
        '        Next
        '        If Cnt_ < Phon1TxtBx.TextLength Then
        '            Phon1TxtBx.AccessibleName = "Mendatory"
        '        Else
        '            Phon1TxtBx.AccessibleName = "None"
        '        End If
        '    Else
        '        Phon1TxtBx.AccessibleName = "None"
        '    End If
        '    For Each c As Control In FinancialGroup.Controls
        '        c.AccessibleName = "None"
        '    Next
        '    For Each c As Control In PostalGroup.Controls
        '        c.AccessibleName = "None"
        '    Next
        'End If
Ckeck_:
        Dim TTT As String = ""
        Dim TTTCount As Integer = 0
        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX TO TEST MENDATORY
        For Each T As Control In FlowLayoutPanel4.Controls
            If T.AccessibleName = "Mendatory" Then
                TTTCount += 1
                TTT &= TTTCount & " - " & T.Tag & vbCrLf
            End If
        Next
        For Each B As Control In FinancialGroup.Controls
            If B.AccessibleName = "Mendatory" Then
                TTTCount += 1
                TTT &= TTTCount & " - " & B.Tag & vbCrLf
            End If
        Next
        For Each c As Control In PostalGroup.Controls
            If c.AccessibleName = "Mendatory" Then
                TTTCount += 1
                TTT &= TTTCount & " - " & c.Tag & vbCrLf
            End If
        Next
        If TTT.Length > 0 Then
            Label18.Text = "* حقول واجبة الإدخال" & vbCrLf & "  ---------------------------" & vbCrLf & TTT & vbCrLf
        Else
            Label18.Text = ""
        End If
        If TTTCount = 0 And TreeView1.SelectedNode IsNot Nothing Then
            Me.SubmitBtn.Enabled = True
        Else
            Me.SubmitBtn.Enabled = False
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Mendatory()
        If TreeView1.SelectedNode Is Nothing Then
            Label18.Text = ""
            Exit Sub
        Else
            If TreeView1.SelectedNode.Level = 2 Then
                Mendatory()
                TmrActv.Start()
            Else
                Label18.Text = ""
                TmrActv.Stop()
            End If
        End If
    End Sub
    Private Sub RadioButto_Click(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged, RadioButton5.CheckedChanged
        ' Change Form Caption
        If PreciFlag = False Then
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            RadioButton4.Checked = False
            RadioButton5.Checked = False
            Exit Sub
        End If
        If (RadioButton4.Checked) Then
            TickKind = 0
            Label16.Text = "مصدر الطلب :"
            Label5.Text = "نوع الطلب :"
            SrcNm2TkCompSrc.Tag = "مصدر الطلب"
            CompNm.Tag = "نوع الطلب"
        ElseIf (RadioButton5.Checked) Then
            TickKind = 1
            Label16.Text = "مصدر الشكوى :"
            Label5.Text = "نوع الشكوى :"
            SrcNm2TkCompSrc.Tag = "مصدر الشكوى"
            CompNm.Tag = "نوع الشكوى"
        End If

        If OffArea.Items.Count = 0 Then
            OffArea.DataSource = AreaTable
            OffArea.SelectedIndex = -1
        End If

        If OffNm12TkOffNm.Items.Count = 0 Then
            OffNm12TkOffNm.DataSource = OfficeTable
            AddHandler OffArea.SelectedValueChanged, AddressOf AreaCmbBx_SelectedValueChanged 'Programming add Handler
            OffNm12TkOffNm.SelectedIndex = -1
        End If

        If SrcNm2TkCompSrc.Items.Count = 0 Then
            SrcNm2TkCompSrc.DataSource = CompSurceTable.DefaultView
            SrcNm2TkCompSrc.SelectedIndex = -1
        End If

        If CounNmConsign2TkConsigCoun.Items.Count = 0 Then
            CounNmConsign2TkConsigCoun.DataSource = CountryTable
            CounNmConsign2TkConsigCoun.SelectedIndex = -1
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
        MyGroupBox2.Enabled = True
        TreeView1.SelectedNode = Nothing
        BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TreeView1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TxtTikID.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox2.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        FinancialGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        PostalGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TabPage1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
    End Sub
    'Allow Arabic, English Characters and Number From 0 to 9 Only 
    Public Sub AESpaceNumberOnly(ByVal e As KeyPressEventArgs)  ' 
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 32 Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 199 And Asc(e.KeyChar) <= 237) Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 8 Then
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow Arabic, English Characters and Number From 0 to 9 Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    'Allow Arabic and English Characters Only
    Public Sub AESpacesOnly(ByVal e As KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 199 And Asc(e.KeyChar) <= 237) Or Asc(e.KeyChar) = 32 Or Asc(e.KeyChar) = 8 Then
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow Arabic and English Characters Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    'Allow English Characters and Number From 0 to 9 Only
    Public Sub ENumberOnly(ByVal e As KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122 Or Asc(e.KeyChar) = 8 Then
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow English Characters and Number From 0 to 9 Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    'Allow Real Number Only
    Sub NumberDecimalOnly(ByVal e As KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Then
            ToolTip1.ToolTipIcon = ToolTipIcon.None
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow Number Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    'Allow number from 0 to 9 Only
    Public Sub NumberOnly(ByVal e As KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow number from 0 to 9 Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    Private Sub Mail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TkMail.Validating
        If IntUtly.IsValidEmail(TkMail.Text) Then
            ''ok
        Else
            Dim result As DialogResult _
        = MessageBox.Show("The email address you entered is not valid." &
                                   " Do you want re-enter it?", "Invalid Email Address",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If result = DialogResult.Yes Then
                e.Cancel = True
            ElseIf result = DialogResult.No Then
                TkMail.Text = ""
            End If
        End If
    End Sub
    Private Sub NameTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles TkClNm.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TkClNm.Text = Clipboard.GetText()
        End If
    End Sub
    Private Sub AddTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles TkClAdr.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TkClAdr.Text = Clipboard.GetText()
        End If
    End Sub
    Private Sub Phone1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.Click, RadioButton8.Click
        TimrPhons.Start()
        TkClPh.Enabled = True
        TkClPh.Text = ""
        If (RadioButton8.Checked) Then
            TkClPh.Mask = "00000000000"
        ElseIf (RadioButton9.Checked) Then
            TkClPh.Mask = "0000000000"
        End If
        TkClPh.Focus()
        TkClNm.Text = ""
        TkClAdr.Text = ""
        TkClPh1.Text = ""
        TkMail.Text = ""
        RelatedTable.Rows.Clear()
    End Sub
    Private Sub PhonTxtBx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TkClPh.KeyPress, TkClPh1.KeyPress    'check character kind (Only numbers)
        NumberOnly(e)
    End Sub
    Public Sub ClntData()
        Dim primaryKey(0) As DataColumn
        RelatedTable.Rows.Clear()
        '  Table            0       1        2       3      4       5       6       7        8      9        10       11       12       13        14         15         16       17        18       19             20         21      22        23         24          25      26       27         28         29           30       31          32       33    34       35
        '  Grid             1        2       3      4       5       6       7        8       9      10       11       12       13        14       15          16         17      18        19       20             21         22      23        24         25          26      27       28         29         30           31       32          33       34    35       36
        If GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm, 0 AS LstSqlEv, '1/1/0001 12:00:00 AM' AS LstUpdtTime, '' AS TkupTxt, 0 AS TkupUnread, 0 AS TkupEvtId, '' AS EvNm, 0 AS EvSusp, 0 AS TkupUser, TkReOp FROM dbo.TicketsAll  WHERE (TkClPh = '" & TkClPh.Text & "') ORDER BY TkSQL DESC;", RelatedTable, "1013&H") = Nothing Then
            primaryKey(0) = RelatedTable.Columns("TkSQL")
            RelatedTable.PrimaryKey = primaryKey

            If RelatedTable.Rows.Count > 0 Then
                Invoke(Sub() TkClNm.Text = RelatedTable(0).Item(5).ToString)
                Invoke(Sub() TkClAdr.Text = RelatedTable(0).Item(9).ToString)
                Invoke(Sub() TkClPh1.Text = RelatedTable(0).Item(7).ToString)
                If DBNull.Value.Equals(RelatedTable(0).Item(8).ToString) = False Then
                    Invoke(Sub() TkMail.Text = RelatedTable(0).Item(8).ToString)
                Else

                End If


                Dim Comp As Integer = 0
                Dim InQ As Integer = 0
                Dim Stat As Integer = 0
                For YY = 0 To RelatedTable.Rows.Count - 1
                    If RelatedTable(YY).Item("TkKind") = True Then
                        Comp += 1
                    Else
                        InQ += 1
                    End If
                    If RelatedTable(YY).Item("TkClsStatus") = True Then
                        Stat += 1
                    End If
                Next
                Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
            Else
                Invoke(Sub() TkClNm.Text = "")
                Invoke(Sub() TkClAdr.Text = "")
                Invoke(Sub() TkClPh1.Text = "")
                Invoke(Sub() TkMail.Text = "")
                Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = " لا توجد بيانات متاحة للعرض")
            End If
            Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            Invoke(Sub() LodngFrm.LblMsg.Text = My.Resources.ConnErr & " - " & My.Resources.TryAgain)
            Invoke(Sub() LodngFrm.LblMsg.ForeColor = Color.Red)
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
        End If
        FltrStr = ""
        Invoke(Sub() RelatedTable.DefaultView.RowFilter = String.Empty)
        Invoke(Sub() LodngFrm.Close())
        Invoke(Sub() Me.Enabled = True)
        Invoke(Sub() Me.Activate())

    End Sub
    'Load Customer Data If Available
    Private Sub Phon1TxtBx_TextChanged(sender As Object, e As EventArgs) Handles TkClPh.TextChanged
        Cnt_ = 0
        For cnt_1 = 1 To TkClPh.TextLength
            If Mid(TkClPh.Text, cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnt_ += 1
            End If
        Next
        If Cnt_ = TkClPh.TextLength Then

            Dim ClntThrd As New Thread(AddressOf ClntData)
            ClntThrd.IsBackground = True
            TkClPh.BackColor = Color.FromArgb(128, 255, 128)
            TkClPh.ForeColor = Color.Black
            ECnt_Label.ForeColor = Color.Green
            ECnt_Label.Text = "رقم التليفون مكتمل"
            WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ..........."
            TreeView1.Visible = True
            ClntThrd.Start()
            Me.Enabled = False
        Else
            TkClPh.BackColor = Color.OrangeRed
            TkClPh.ForeColor = Color.Yellow
            ECnt_Label.ForeColor = Color.Red
            ECnt_Label.Text = "رقم التليفون غير مكتمل"
            TreeView1.Visible = False
            TkClNm.Text = ""
            TkClAdr.Text = ""
            TkClPh1.Text = ""
            TkMail.Text = ""
        End If
    End Sub
    Private Sub Phon2TxtBx_TextChanged(sender As Object, e As EventArgs) Handles TkClPh1.TextChanged
        Cnt_ = 0
        For cnt_1 = 1 To TkClPh1.TextLength
            If Mid(TkClPh1.Text, cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnt_ += 1
            End If
        Next
        If Cnt_ = TkClPh1.TextLength Then
            TkClPh1.BackColor = Color.FromArgb(128, 255, 128)
            TkClPh1.ForeColor = Color.Black
            ECnt_Label.ForeColor = Color.Green
            ECnt_Label.Text = "رقم التليفون مكتمل"
        Else
            TkClPh1.BackColor = Color.OrangeRed
            TkClPh1.ForeColor = Color.Yellow
            ECnt_Label.ForeColor = Color.Red
            ECnt_Label.Text = "رقم التليفون غير مكتمل"
        End If
    End Sub
    Private Sub PhonTxtBx1_Leave(sender As Object, e As EventArgs) Handles TkClPh.Leave
        If String.IsNullOrEmpty(TkClPh.Text) Then
            RadioButton8.Checked = False
            RadioButton9.Checked = False
            Me.TkClPh.Enabled = False
        Else
            If TkClPh.MaskFull = False Then
                ECnt_Label.ForeColor = Color.Red
                TkClPh.Focus()
                ECnt_Label.Text = "رقم الموبايل لابد أن يتكون من " & TkClPh.MaxLength & " رقم"
                Beep()
            End If
        End If
        ECnt_Label.Text = ""
    End Sub
    Private Sub Phone2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton12.Click, RadioButton11.Click
        TimrPhons.Start()
        TkClPh1.Enabled = True
        TkClPh1.Text = ""
        If (RadioButton11.Checked) Then
            TkClPh1.Mask = "00000000000"
        ElseIf (RadioButton12.Checked) Then
            TkClPh1.Mask = "0000000000"
        End If
        TkClPh1.Focus()
        ECnt_Label.ForeColor = Color.Green
        ECnt_Label.Text = "رقم الموبايل لابد أن يتكون من " & TkClPh1.MaxLength & " رقم"
    End Sub
    Private Sub Phon2TxtBx_KeyUp(sender As Object, e As KeyEventArgs)
        If TkClPh1.TextLength < TkClPh1.MaxLength Then
            TkClPh1.BackColor = Color.OrangeRed
            TkClPh1.ForeColor = Color.Yellow
            ECnt_Label.ForeColor = Color.Red
            ECnt_Label.Text = "رقم التليفون غير مكتمل"
        ElseIf TkClPh1.TextLength = TkClPh1.MaxLength Then
            TkClPh1.BackColor = Color.FromArgb(128, 255, 128)
            TkClPh1.ForeColor = Color.Black
            ECnt_Label.ForeColor = Color.Green
            ECnt_Label.Text = "رقم التليفون مكتمل"
        End If
    End Sub
    Private Sub Phon2TxtBx_Leave(sender As Object, e As EventArgs) Handles TkClPh1.Leave
        If String.IsNullOrEmpty(TkClPh1.Text) Then
            TkClPh1.Enabled = False
            RadioButton11.Checked = False
            RadioButton12.Checked = False
            Me.TkClPh1.Enabled = False
        Else
            If TkClPh1.MaskFull = False Then
                TkClPh1.Focus()
                ECnt_Label.ForeColor = Color.Red
                ECnt_Label.Text = "رقم الموبايل لابد أن يتكون من " & TkClPh1.MaxLength & " رقم"
                Beep()
            End If
            If TkClPh1.TextLength < TkClPh1.MaxLength Then

            End If
        End If
        ECnt_Label.Text = ""
    End Sub
    Private Sub AmountTxtBx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TkAmount.KeyPress
        NumberDecimalOnly(e)
    End Sub
    Private Sub AmountTxtBx_Leave(sender As Object, e As EventArgs) Handles TkAmount.Leave
        'Try
        '    TkAmount.Text = Convert.ToDecimal(TkAmount.Text).ToString("N2")
        'Catch exp As Exception
        '    MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    TkAmount.Focus()
        'End Try
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        RemoveHandler OffArea.SelectedValueChanged, AddressOf AreaCmbBx_SelectedValueChanged 'Programming add Handler
        Timer1.Stop()
        Me.Close()
    End Sub
    Private Sub OffCmbBx_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OffNm12TkOffNm.Validating
        If Len(OffNm12TkOffNm.Text) > 0 Then
            If (OffNm12TkOffNm.SelectedIndex = -1) Then
                e.Cancel = True
                Beep()
                ToolTip1.Show("Your choice Not listed", OffNm12TkOffNm, 0, 0, 5000)
            Else
                ToolTip1.Hide(OffNm12TkOffNm)
            End If
        End If
    End Sub
    Private Sub SubmtTick()

        Dim TranDt As String
        Dim Trck As String = ""
        Dim lodingStr As String = ""


        Invoke(Sub()
                   Dim CTRLLst As New List(Of Control)
                   GetAll(Me).ToList.ForEach(Sub(c)
                                                 CTRLLst.Add(c)
                                             End Sub)

                   For Each Ctrol As Control In CTRLLst
                       If TypeOf Ctrol Is TextBox Then
                           If Ctrol.Text.Contains("'") Then
                               WelcomeScreen.StatBrPnlAr.Text = ""
                               MsgBox("غير مسموح بوضح رمز " & "' " & "بحقل " & Ctrol.Tag & " .... يرجى التأكد من البيان مرة أخرى")
                               Invoke(Sub() Me.Enabled = True)
                               Invoke(Sub() Me.Activate())
                               TickSubmt.Abort()
                           End If
                       End If

                   Next
               End Sub)


        lodingStr = "جاري تسجيل البيانات ..."
        For Cnt_ = 1 To TkShpNo.TextLength
            If Mid(TkShpNo.Text, Cnt_, 1) <> " " Then
                Trck &= Mid(TkShpNo.Text, Cnt_, 1)
            End If
        Next
        Dim sqlComminsert_3 As New SqlCommand            'SQL Command
        Dim sqlComminsert_4 As New SqlCommand            'SQL Command
        If TkTransDate.Value = Today.AddDays(1) Then
            TranDt = ""
        Else
            TranDt = Format(TkTransDate.Value, "yyyy/MM/dd").ToString
        End If
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComminsert_1.Connection = sqlCon
            sqlComminsert_2.Connection = sqlCon            'insert Update into Update Table
            sqlComminsert_3.Connection = sqlCon
            sqlComminsert_4.Connection = sqlCon
            sqlComm.Connection = sqlCon                    'Get ID & Date & UserID
            sqlComminsert_1.CommandType = CommandType.Text
            sqlComminsert_2.CommandType = CommandType.Text
            sqlComminsert_3.CommandType = CommandType.Text
            sqlComminsert_4.CommandType = CommandType.Text
            sqlComm.CommandType = CommandType.Text
            'If TickKind = 0 Then                            'Ticket Will be closed & Usr.ID will be the same User
            '    Invoke(Sub() sqlComminsert_1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail, TkClsStatus, TkEmpNm, TkFolw) VALUES (0, '" & TickKind & "','" &
            '                                   TreeView1.SelectedNode.Name & "','" & SrcCmbBx.SelectedValue & "','" & Trim(NameTxtBx.Text) & "','" & Phon1TxtBx.Text & "','" & Phon2TxtBx.Text & "','" & AddTxtBx.Text & "','" & TkClNtID.Text & "','" & Trck & "','" & TkGBNo.Text & "','" & Trim(Mid(TkCardNo.Text, 1, 4)) & Trim(Mid(TkCardNo.Text, 6, 4)) & Trim(Mid(TkCardNo.Text, 11, 4)) & Trim(Mid(TkCardNo.Text, 16, 4)) & "','" & TkAmount.Text & "','" & TranDt & "','" & DetailsTxtBx.Text & DubStr & "','" & Trim(Mid(TkShpNo.Text, 14, 2)) & "','" & CounNmConsign.SelectedValue & "','" & OffCmbBx.SelectedValue & "','" & Usr.PUsrID & "','" & MailTxtBx.Text & "','" & 1 & "','" & Usr.PUsrID & "','" & "1" & "');")

            '    sqlComminsert_2.CommandText = "INSERT into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES 
            '                                                   ((Select Max(TkSQL) As RelationTkID FROM Tickets where TkEmpNm0 = " & Usr.PUsrID & "),'" & "The Inquiry has been Recieved" & "','" & "1" & "','" & "0" & "','" & OsIP() & "','" & Usr.PUsrID & "');"
            'Else
            If Usr.PUsrCalCntr = True Then
                Invoke(Sub() sqlComminsert_1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail) VALUES (0, '" & TickKind & "','" &
                                          TreeView1.SelectedNode.Name & "','" & SrcNm2TkCompSrc.SelectedValue & "','" & Trim(TkClNm.Text) & "','" & TkClPh.Text & "','" & TkClPh1.Text & "','" & TkClAdr.Text & "','" & TkClNtID.Text & "','" & Trck & "','" & TkGBNo.Text & "','" & Trim(Mid(TkCardNo.Text, 1, 4)) & Trim(Mid(TkCardNo.Text, 6, 4)) & Trim(Mid(TkCardNo.Text, 11, 4)) & Trim(Mid(TkCardNo.Text, 16, 4)) & "','" & TkAmount.Text & "','" & TranDt & "','" & TkDetails.Text & DubStr & "','" & Trim(Mid(TkShpNo.Text, 14, 2)) & "','" & CounNmConsign2TkConsigCoun.SelectedValue & "','" & OffNm12TkOffNm.SelectedValue & "','" & Usr.PUsrID & "','" & TkMail.Text & "');")
            Else
                Invoke(Sub() sqlComminsert_1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail, TkEmpNm) VALUES (0, '" & TickKind & "','" &
                                      TreeView1.SelectedNode.Name & "','" & SrcNm2TkCompSrc.SelectedValue & "','" & Trim(TkClNm.Text) & "','" & TkClPh.Text & "','" & TkClPh1.Text & "','" & TkClAdr.Text & "','" & TkClNtID.Text & "','" & Trck & "','" & TkGBNo.Text & "','" & Trim(Mid(TkCardNo.Text, 1, 4)) & Trim(Mid(TkCardNo.Text, 6, 4)) & Trim(Mid(TkCardNo.Text, 11, 4)) & Trim(Mid(TkCardNo.Text, 16, 4)) & "','" & TkAmount.Text & "','" & TranDt & "','" & TkDetails.Text & DubStr & "','" & Trim(Mid(TkShpNo.Text, 14, 2)) & "','" & CounNmConsign2TkConsigCoun.SelectedValue & "','" & OffNm12TkOffNm.SelectedValue & "','" & Usr.PUsrID & "','" & TkMail.Text & "','" & Usr.PUsrID & "');")
            End If
            sqlComminsert_2.CommandText = "INSERT into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES 
                                                                   ((Select Max(TkSQL) As RelationTkID FROM Tickets where TkEmpNm0 = " & Usr.PUsrID & "),'" & "The Complaint has been Recieved" & "','" & "1" & "','" & "0" & "','" & OsIP() & "','" & Usr.PUsrID & "');"
            'End If
            sqlComminsert_3.CommandText = "update Tickets set TkID = MaxID from (select MAX(TkSQL) AS MaxID, MAX(TkDtStart) AS MaxDt, TkEmpNm0 from Tickets where TkEmpNm0  = " & Usr.PUsrID & " GROUP BY TkEmpNm0) As MaxTable INNER JOIN Tickets ON Tickets.TkSQL = MaxTable.MaxID;"
            sqlComminsert_4.CommandText = "select MAX(TkSQL) AS MaxID, MAX(TkDtStart) AS MaxDt, MAX(TkID) AS Max_ from TkEvent INNER JOIN Tickets ON TkEvent.TkupTkSql = Tickets.TkSQL GROUP BY TkupUser HAVING (TkupUser  = " & Usr.PUsrID & ");"
            Tran = sqlCon.BeginTransaction()
            sqlComminsert_1.Transaction = Tran
            sqlComminsert_2.Transaction = Tran
            sqlComminsert_3.Transaction = Tran
            sqlComminsert_4.Transaction = Tran
            sqlComm.Transaction = Tran
            sqlComminsert_1.ExecuteNonQuery()
            sqlComminsert_2.ExecuteNonQuery()
            sqlComminsert_3.ExecuteNonQuery()
            Reader_ = sqlComminsert_4.ExecuteReader

            Reader_.Read()
            SqlCuCnt_ = Reader_!MaxID
            If TickKind = 0 Then
                Invoke(Sub() Me.Text = "Request No.:  " & Reader_!Max_)
            Else
                Invoke(Sub() Me.Text = "Complaint No.: " & Reader_!Max_)
            End If

            Invoke(Sub() TkDtStart.Text = Reader_!MaxDt)
            Reader_.Close()
            Tran.Commit()
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
            Invoke(Sub()
                       Dim CTRLLst As New List(Of Control)
                       GetAll(Me).ToList.ForEach(Sub(c)
                                                     CTRLLst.Add(c)
                                                 End Sub)

                       For Each Ctrol As Control In CTRLLst
                           If TypeOf Ctrol Is TextBox Then
                               Dim TxtBox As TextBox = Ctrol
                               Ctrol.Enabled = False
                               If TxtBox.ReadOnly = False Then
                                   Ctrol.BackColor = Color.White
                                   Ctrol.ForeColor = Color.Black
                               End If
                           ElseIf TypeOf Ctrol Is MaskedTextBox Then
                               Dim TxtBox As MaskedTextBox = Ctrol
                               Ctrol.Enabled = False
                               If TxtBox.ReadOnly = False Then
                                   Ctrol.BackColor = Color.White
                                   Ctrol.ForeColor = Color.Black
                               End If
                           ElseIf TypeOf Ctrol Is ComboBox Then
                               Ctrol.Enabled = False
                               Dim TxtBox As ComboBox = Ctrol
                           ElseIf TypeOf Ctrol Is RadioButton Then
                               Ctrol.Enabled = False
                           ElseIf TypeOf Ctrol Is DateTimePicker Then
                               Ctrol.Enabled = False
                           End If
                       Next
                   End Sub)

            TreeView1.Enabled = False
            Invoke(Sub() SubmitBtn.Visible = False)
            Invoke(Sub() Me.BackColor = Color.FromArgb(105, 255, 123))
            Invoke(Sub() TabPage1.BackColor = Color.FromArgb(105, 255, 123))
            Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "تم تسجيل البيان بنجاح")
            DubStr = ""
            Invoke(Sub() LodngFrm.Close())
            Invoke(Sub() Me.Enabled = True)
            Invoke(Sub() Me.Activate())
            Invoke(Sub() TimrPhons.Stop())
        Catch ex As Exception
            Tran.Rollback()
            'Invoke(Sub() WelcomeScreen.TimerCon.Start())
            'Invoke(Sub() WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032)
            Invoke(Sub() LodngFrm.Close())
            AppLog("1011&H", ex.Message, sqlComminsert_1.CommandText & "_" & sqlComminsert_2.CommandText)
            'Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "لم ينجح الإتصال بالخادم .. سيتم تسجيل الشكوى بالوضع الغير متصل بالشبكة")
            'Dim Rslt As DialogResult
            'Rslt = MessageBox.Show("كود خطأ : " & "1011&H" & vbCrLf & "لم ينجح الإتصال بالخادم .. سيتم تسجيل الشكوى بالوضع الغير متصل بالشبكة" & vbCrLf & "هل تريد الإستمرار؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
            'If Rslt = DialogResult.Yes Then
            '    TickOffSubmt = New Thread(AddressOf SubmtOfflineTick)
            '    TickOffSubmt.IsBackground = True
            '    Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "جاري تسجيل البيانات ...........")
            '    Invoke(Sub() TreeView1.Visible = True)
            '    TickOffSubmt.Start()
            '    TickSubmt.Abort()
            'End If

            'TickSubmt.Abort()
            MsgErr("كود خطأ : " & "1011&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End Try
        Invoke(Sub() Me.Enabled = True)
        Invoke(Sub() Me.Activate())
        Invoke(Sub() TimrPhons.Stop())
    End Sub
    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        'TickSubmt = New Thread(AddressOf SubmtTick)
        'TickSubmt.IsBackground = True
        'WelcomeScreen.StatBrPnlAr.Text = "جاري تسجيل البيانات ..........."
        'TreeView1.Visible = True
        'TickSubmt.Start()
        'Me.Enabled = False
        Dim Fn As New APblicClss.Func
        Dim Def As New APblicClss.Defntion
        Dim CTRLLst As New List(Of Control)
        GetAll(Me).ToList.ForEach(Sub(c)
                                      CTRLLst.Add(c)
                                  End Sub)
        UpTxt = ""
        Dim UpdtTicket As String = ""
        For Each Ctrol As Control In CTRLLst
            If TypeOf Ctrol Is TextBox Then
                Dim TxtBox As TextBox = Ctrol
                If TxtBox.Name <> "TikID" And TxtBox.Name <> "CounNmSender" And TxtBox.Name <> "PrdNm" And TxtBox.Name <> "CompNm" Then
                    If TxtBox.Text <> EditTable.Rows(0).Item(TxtBox.Name).ToString Then
                        If TxtBox.TextLength = 0 Then
                            UpTxt &= vbCrLf & "تم حذف " & TxtBox.Tag & Chr(34) & EditTable.Rows(0).Item(TxtBox.Name).ToString & Chr(34)
                        ElseIf EditTable.Rows(0).Item(TxtBox.Name).ToString.Length = 0 Then
                            UpTxt &= vbCrLf & "تم إضافة " & TxtBox.Tag & Chr(34) & TxtBox.Text & Chr(34)
                        Else
                            UpTxt &= vbCrLf & "تم تعديل " & TxtBox.Tag & " من " & Chr(34) & EditTable.Rows(0).Item(TxtBox.Name).ToString & Chr(34) & " إلى " & Chr(34) & TxtBox.Text & Chr(34)
                        End If
                        UpdtTicket &= " ," & TxtBox.Name & " = '" & TxtBox.Text & "' "
                    End If
                ElseIf TxtBox.Name = "PrdNm" Or TxtBox.Name = "CompNm" Then
                    If TxtBox.Text <> EditTable.Rows(0).Item(TxtBox.Name).ToString Then
                        UpTxt &= vbCrLf & "تم تعديل " & TxtBox.Tag & " من " & Chr(34) & EditTable.Rows(0).Item(TxtBox.Name).ToString & Chr(34) & " إلى " & Chr(34) & TxtBox.Text & Chr(34)
                    End If
                End If
            ElseIf TypeOf Ctrol Is MaskedTextBox Then
                Dim TxtBox As MaskedTextBox = Ctrol
                If Replace(TxtBox.Text, " ", "") <> EditTable.Rows(0).Item(TxtBox.Name).ToString Then
                    If Trim(TxtBox.Text).Length > 0 Then
                        If EditTable.Rows(0).Item(TxtBox.Name).ToString.Length = 0 Then
                            UpTxt &= vbCrLf & "تم إضافة " & TxtBox.Tag & Chr(34) & Replace(TxtBox.Text, " ", "") & Chr(34)
                        Else
                            UpTxt &= vbCrLf & "تم تعديل " & TxtBox.Tag & " من " & Chr(34) & EditTable.Rows(0).Item(TxtBox.Name).ToString & Chr(34) & " إلى " & Chr(34) & Replace(TxtBox.Text, " ", "") & Chr(34)
                        End If
                    Else
                        UpTxt &= vbCrLf & "تم حذف " & TxtBox.Tag & Chr(34) & EditTable.Rows(0).Item(TxtBox.Name).ToString & Chr(34)
                    End If
                    UpdtTicket &= " ," & TxtBox.Name & " = '" & Replace(TxtBox.Text, " ", "") & "' "
                End If
            ElseIf TypeOf Ctrol Is ComboBox Then
                Dim CombBox As ComboBox = Ctrol
                If CombBox.Name <> "CombProdRef" And CombBox.Name <> "OffArea" Then
                    If Replace(CombBox.SelectedValue, " ", "") <> EditTable.Rows(0).Item(CombBox.Name).ToString Then
                        If CombBox.Text.Length = 0 Then
                            UpTxt &= vbCrLf & "تم حذف " & CombBox.Tag & Chr(34) & EditTable.Rows(0).Item(Split(CombBox.Name, "2")(0)).ToString & Chr(34)
                        ElseIf EditTable.Rows(0).Item(CombBox.Name).ToString.Length = 0 Then
                            UpTxt &= vbCrLf & "تم إضافة " & CombBox.Tag & Chr(34) & CombBox.Text & Chr(34)
                        Else
                            UpTxt &= vbCrLf & "تم تعديل " & CombBox.Tag & " من " & Chr(34) & EditTable.Rows(0).Item(Split(CombBox.Name, "2")(0)).ToString & Chr(34) & " إلى " & Chr(34) & CombBox.Text & Chr(34)
                        End If
                        UpdtTicket &= " ," & Split(CombBox.Name, "2")(1) & " = '" & CombBox.SelectedValue & "' "
                    End If
                End If
            End If
        Next
        If ChckReAssign.Checked = True Then
            UpdtTicket &= " ," & "TkEmpNm = " & ReAssgnTbl.Rows(0).Item(1)
            UpTxt &= vbCrLf & "تم تحويل الشكوى للفريق المختص " & ReAssgnTbl.Rows(0).Item(0).ToString
        End If
        If TreeView1.SelectedNode.Name <> EditTable.Rows(0).Item("TkFnPrdCd").ToString Then
            UpdtTicket &= " ," & "TkFnPrdCd = " & TreeView1.SelectedNode.Name
        End If

        UpdtTicket = "Update Tickets set " & Mid(UpdtTicket, 3, UpdtTicket.Length) & " where TkSQL =  " & TikID.Text
        If UpTxt.Length > 0 Then
            Dim Rslt As DialogResult
            Rslt = MessageBox.Show(UpTxt & vbCrLf & "هل تريد حفظ التعديلات؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
            If Rslt = DialogResult.Yes Then
                Try
                    If Def.CONSQL.State = ConnectionState.Closed Then
                        Def.CONSQL.Open()
                    End If
                    Def.sqlComminsert_1.Connection = Def.CONSQL
                    Def.sqlComminsert_2.Connection = Def.CONSQL            'insert Update into Update Table
                    Def.sqlComminsert_3.Connection = Def.CONSQL
                    sqlComm.Connection = Def.CONSQL                    'Get ID & Date & UserID
                    Def.sqlComminsert_1.CommandType = CommandType.Text
                    Def.sqlComminsert_2.CommandType = CommandType.Text
                    Def.sqlComminsert_3.CommandType = CommandType.Text
                    sqlComm.CommandType = CommandType.Text
                    Def.sqlComminsert_1.CommandText = UpdtTicket
                    Def.sqlComminsert_2.CommandText = "INSERT into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES 
                                                               (" & EditTable.Rows(0).Item("TkSQL") & ",'" & UpTxt & "','" & "0" & "','" & "901" & "','" & Fn.OsIP() & "','" & Usr.PUsrID & "');"
                    If ReAssgnTbl.Rows.Count > 0 Then Def.sqlComminsert_3.CommandText = "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES
(" & TikID.Text & ", 'The Complaint has been ReAssigned To " & ReAssgnTbl.Rows(0).Item(0).ToString & "', 0 , 101, '" & Fn.OsIP & "'," & Usr.PUsrID & ")"
                    Def.Tran = Def.CONSQL.BeginTransaction()
                    Def.sqlComminsert_1.Transaction = Def.Tran
                    Def.sqlComminsert_2.Transaction = Def.Tran
                    If ReAssgnTbl.Rows.Count > 0 Then Def.sqlComminsert_3.Transaction = Def.Tran
                    sqlComm.Transaction = Def.Tran
                    Def.sqlComminsert_1.ExecuteNonQuery()
                    Def.sqlComminsert_2.ExecuteNonQuery()
                    If ReAssgnTbl.Rows.Count > 0 Then Def.sqlComminsert_3.ExecuteNonQuery()
                    Def.Tran.Commit()
                    FlowLayoutPanel4.Enabled = False
                    FlowLayoutPanel2.Enabled = False
                    'FlowLayoutPanel5.Enabled = False
                    ChckReAssign.Enabled = False
                    Button1.Enabled = False
                    MsgInf("تم تسجيل التعديلات بنجاح")
                Catch ex As Exception
                    Def.Tran.Rollback()
                    Invoke(Sub() LodngFrm.Close())
                    AppLog("1011&H", ex.Message, Def.sqlComminsert_1.CommandText & "_" & Def.sqlComminsert_2.CommandText)
                    MsgErr("كود خطأ : " & "1011&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                End Try
            End If
        Else
            MsgInf("لا توجد تعديلات للحفظ")
        End If
    End Sub
    Private Sub AreaCmbBx_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OffArea.Validating
        If OffArea.Text.Length > 0 Then
            If (OffArea.SelectedIndex = -1) Then
                e.Cancel = True
                Beep()
                ToolTip1.Show("Your choice Not listed", OffArea, 0, 20, 5000)
            Else
                ToolTip1.Hide(SrcNm2TkCompSrc)
            End If
        End If
    End Sub
    Private Sub DistCmbBx_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CounNmConsign2TkConsigCoun.Validating
        If CounNmConsign2TkConsigCoun.Text.Length > 0 Then
            If (CounNmConsign2TkConsigCoun.SelectedIndex = -1) Then
                e.Cancel = True
                Beep()
                ToolTip1.Show("Your choice Not listed", CounNmConsign2TkConsigCoun, 0, 20, 5000)
            Else
                ToolTip1.Hide(SrcNm2TkCompSrc)
            End If
        End If
    End Sub
    Private Sub TrackMskBx_Leave(sender As Object, e As EventArgs) Handles TkShpNo.Leave
        Dim TempRow As DataRow
        Dim PrdNo As String
        Dim Stat_ As String
        Dim chck As Boolean = False
        TkShpNo.Text = UCase(TkShpNo.Text)

        If PrdBol = True Then
            PrdNo = Trim(Mid(TkShpNo.Text, 1, 3)) & Trim(Mid(TkShpNo.Text, 5, 8)) & Trim(Mid(TkShpNo.Text, 14, 2))
            If (Trim(Mid(TkShpNo.Text, 1, 3)) & Trim(Mid(TkShpNo.Text, 5, 8)) & Trim(Mid(TkShpNo.Text, 14, 2))).Length = 13 Then
                chck = True
            Else
                chck = False
            End If
        Else
            PrdNo = Trim(Mid(TkShpNo.Text, 1, 2)) & Trim(Mid(TkShpNo.Text, 4, 9)) & Trim(Mid(TkShpNo.Text, 14, 2))
            If (Trim(Mid(TkShpNo.Text, 1, 2)) & Trim(Mid(TkShpNo.Text, 4, 9)) & Trim(Mid(TkShpNo.Text, 14, 2))).Length = 13 Then
                chck = True
            Else
                chck = False
            End If
        End If
        If chck = True Then
            'If Mid(TkShpNo.Text, 14, 1).CompareTo("[A-Z][a-z]*") = 1 Or Mid(TkShpNo.Text, 15, 1).CompareTo("[A-Z][a-z]*") = 1 Then
            TempRow = CountryTable.Rows.Find(Mid(TkShpNo.Text, 14, 2))
            If TempRow Is Nothing Then
                MsgInf("لا توجد دولة مسجلة بهذا الاسم" & vbCrLf & "يرجى مراجعة رقم التتبع")
            Else
                CounNmSender.Text = TempRow.ItemArray(1)
                TkShpNo.BackColor = Color.FromArgb(128, 255, 128)
            End If
        Else
            Beep()
            WelcomeScreen.StatBrPnlAr.Text = "يرجى التحقق من رقم التتبع"
            TkShpNo.Text = ""
            Exit Sub
        End If
    End Sub
    Private Sub TrackMskBx_TextChanged(sender As Object, e As EventArgs) Handles TkShpNo.TextChanged
        ToolTip1.Hide(TkShpNo)
        TkShpNo.BackColor = Color.White
        CounNmSender.Text = ""
    End Sub
    Private Sub TrackMskBx_Enter(sender As Object, e As EventArgs) Handles TkShpNo.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput            'Tansfer writing to English
    End Sub
    Private Sub NameTxtBx_Enter(sender As Object, e As EventArgs) Handles TkClNm.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub DistCmbBx_Enter(sender As Object, e As EventArgs) Handles CounNmConsign2TkConsigCoun.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub MailTxtBx_Enter(sender As Object, e As EventArgs) Handles TkMail.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput
    End Sub
    Private Sub DetailsTxtBx_Enter(sender As Object, e As EventArgs) Handles TkDetails.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub AddTxtBx_Enter(sender As Object, e As EventArgs) Handles TkClAdr.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub OffCmbBx_Enter(sender As Object, e As EventArgs) Handles OffNm12TkOffNm.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim TempClr As DataRow
        SubmitBtn.Enabled = False
        TreeView1.SelectedNode.Expand()
        TempClr = ProdKTable.Rows.Find(Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0))
        BKClr = Split(TempClr.ItemArray(2), ",")
        BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TreeView1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TabPage1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TxtTikID.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox2.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        FinancialGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        PostalGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))



        If (TreeView1.SelectedNode.Level) = 2 Then
            PrdKind = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0)
            PrdNm.Text = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1)
            CompNm.Text = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(2)
        End If

        UpTxt = ""
        If (TreeView1.SelectedNode.Level) = 2 Then
            'If ChckReAssign.Checked = True Then
            '    tempTable.Rows.Clear()
            '    tempTable.Columns.Clear()
            '    GetTbl("SELECT UsrRealNm, dbo.VwFnProd.FnSQL FROM dbo.VwFnProd INNER JOIN dbo.Int_user ON dbo.VwFnProd.FnMngr = UsrId WHERE (dbo.VwFnProd.FnSQL = " & TreeView1.SelectedNode.Name & ")", tempTable, "0000&H")
            '    ReAssgnSTR = "سيتم تحويل الشكوى من " & UsrRealNm.Text & " إلى " & tempTable.Rows(0).Item(0) & " خلال 15 دقيقة" & vbCrLf
            '    LblText.Text = ReAssgnSTR
            'Else
            '    LblText.Text = ""
            'End If
        Else
            'ChckReAssign.Enabled = False
            'SubmitBtn.Enabled = False
            'ChckReAssign.Checked = False
            'ChckReAssign.BackColor = Color.Red
            'LblText.Text = ""
            PrdNm.Text = "" ' EditTable.Rows(0).Item("PrdNm").ToString
            CompNm.Text = "" ' EditTable.Rows(0).Item("CompNm").ToString
            PrdNm.BackColor = Color.White
            CompNm.BackColor = Color.White
        End If

        'If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0) <> PrdKind Then PrdKind = ""

        If PrdKind = "مالية" Then
            Me.FinancialGroup.Visible = True
            Me.PostalGroup.Visible = False
            CombProdRef.Visible = True
            TkShpNo.Text = ""
            CounNmSender.Text = ""
            CounNmConsign2TkConsigCoun.SelectedValue = ""
        ElseIf PrdKind = "بريدية" Then
            TkCardNo.Text = ""
            TkGBNo.Text = ""
            'TkClNtID.Text = ""
            TkAmount.Text = "0"
            Me.FinancialGroup.Visible = False
            Me.PostalGroup.Visible = True
            CombProdRef.Visible = True
        ElseIf PrdKind = "حكومية" Then
            Me.FinancialGroup.Visible = False
            Me.PostalGroup.Visible = False
            CombProdRef.Visible = False
            TkCardNo.Text = ""
            TkGBNo.Text = ""
            TkClNtID.Text = ""
            TkAmount.Text = "0"
            TkShpNo.Text = ""
            CounNmSender.Text = ""
            CounNmConsign2TkConsigCoun.SelectedValue = ""
        ElseIf PrdKind = "مجتمعية" Then
            Me.FinancialGroup.Visible = False
            Me.PostalGroup.Visible = False
            CombProdRef.Visible = False
            TkCardNo.Text = ""
            TkGBNo.Text = ""
            'TkClNtID.Text = ""
            TkAmount.Text = ""
            TkShpNo.Text = ""
            CounNmSender.Text = ""
            CounNmConsign2TkConsigCoun.SelectedValue = ""
        ElseIf PrdKind = "أخرى" Then
            Me.FinancialGroup.Visible = False
            Me.PostalGroup.Visible = False
            CombProdRef.Visible = False
            TkCardNo.Text = ""
            TkGBNo.Text = ""
            'TkClNtID.Text = ""
            TkAmount.Text = "0"
            TkShpNo.Text = ""
            CounNmSender.Text = ""
            CounNmConsign2TkConsigCoun.SelectedValue = ""
        ElseIf PrdKind = "" Then
            Me.FinancialGroup.Visible = False
            Me.PostalGroup.Visible = False
            CombProdRef.Visible = False
            TkCardNo.Text = ""
            TkGBNo.Text = ""
            'TkClNtID.Text = ""
            TkAmount.Text = "0"
            TkShpNo.Text = ""
            CounNmSender.Text = ""
            CounNmConsign2TkConsigCoun.SelectedValue = ""
        End If
    End Sub
    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        If TreeView1.SelectedNode Is Nothing Then
        Else
            If TreeView1.SelectedNode.Level = 2 Then
                TreeView1.SelectedNode.Parent.Parent.Collapse(False)  'True to leave the child nodes in their Current state; false to collapse the child nodes.
            ElseIf TreeView1.SelectedNode.Level = 1 Then
                CombProdRef.Items.Clear()
                TreeView1.SelectedNode.Parent.Collapse(False)
            ElseIf TreeView1.SelectedNode.Level = 0 Then
                CombProdRef.Items.Clear()
                TreeView1.SelectedNode.Collapse(False)
            End If
        End If
    End Sub
    Private Sub AreaCmbBx_SelectedValueChanged(sender As Object, e As EventArgs) 'Programming add Handler
        Dim OffData As DataView
        OffData = OfficeTable.DefaultView
        If OffArea.SelectedIndex <> -1 Then
            OfficeTable.DefaultView.RowFilter = "OffArea = '" & OffArea.SelectedValue.ToString & "'"
            OffNm12TkOffNm.SelectedIndex = -1
        End If
    End Sub
    Dim NodesThatMatch As New List(Of TreeNode)
    Private Function SearchTheTreeView(ByVal TreeView1 As TreeView, ByVal TextToFind As String) As TreeNode

        '  Empty previous
        NodesThatMatch.Clear()

        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TreeView1.Nodes
            If TN.Text.Contains(TextToFind) Then
                NodesThatMatch.Add(TN)

            End If
            RecursiveSearch(TN, TextToFind)
        Next

        If NodesThatMatch.Count > 0 Then
            For Each TN As TreeNode In TreeView1.Nodes
                If TN.Checked = True Then
                    MsgBox(TN.Text)
                    TreeView1.SelectedNode = TN
                    TN.BackColor = Color.LightGreen
                End If
            Next
            Return NodesThatMatch(0)
        Else
            Return Nothing
        End If
    End Function
    Private Sub RecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)
        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If TN.Text.Contains(TextToFind) Then
                NodesThatMatch.Add(TN)
                TN.Checked = True
            End If
            RecursiveSearch(TN, TextToFind)
        Next
    End Sub
    Private Sub AreaCmbBx_Enter(sender As Object, e As EventArgs) Handles OffArea.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput            'Tansfer writing to English
    End Sub
    Private Sub IDTxtBx_Leave(sender As Object, e As EventArgs) Handles TkClNtID.Leave
        Cnt_ = 0
        If RadNID.Checked = True Then
            For Cnt_1 = 1 To 14
                If Mid(TkClNtID.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            If Cnt_ < 14 And Cnt_ <> 0 Then
                Beep()
                TkClNtID.Text = ""
                MsgInf("الرقم القومي لابد أن يتكون من 14 رقم")
            End If
        End If
        TkClNtID.Text = UCase(TkClNtID.Text)
    End Sub
    Private Sub GBTxtBx_Leave(sender As Object, e As EventArgs) Handles TkGBNo.Leave
        For Cnt_1 = 1 To 16
            If Mid(TkGBNo.Text, Cnt_1, 1).CompareTo("[A-Z][a-z]*") = 1 Then
                Cnt_ += 1
            End If
            If Mid(TkGBNo.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnt_ += 1
            End If
        Next
        If Cnt_ < 16 And Cnt_ <> 0 Then
            Beep()
            TkGBNo.Text = ""
            MsgInf("رقم أمر الدفع لابد أن يتكون من 16 رقم")
        Else
            TkGBNo.Text = UCase(TkGBNo.Text)
        End If
    End Sub
    'Second Tab                     XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    'Private Sub TxtUpdt2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUpdt2.KeyPress
    '    IntUtly.ValdtIntLetter(e)
    'End Sub
    Private Sub IDTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles TkClNtID.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TkClNtID.Text = Clipboard.GetText()
        End If
        TkClNtID.Text = Mid(TkClNtID.Text, 1, TkClNtID.MaxLength)
    End Sub
    Private Sub AccMskdBx_KeyDown(sender As Object, e As KeyEventArgs) Handles TkCardNo.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TkCardNo.Text = Clipboard.GetText()
        End If
        TkCardNo.Text = Mid(TkCardNo.Text, 1, TkCardNo.MaxLength)
    End Sub
    Private Sub GBTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles TkGBNo.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TkGBNo.Text = Clipboard.GetText()
        End If
        TkGBNo.Text = Mid(TkGBNo.Text, 1, TkGBNo.MaxLength)
    End Sub
    Private Sub Phon1TxtBx_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TkClPh.Text = Clipboard.GetText()
        End If
        TkClPh.Text = Mid(TkClPh.Text, 1, TkClPh.MaxLength)
    End Sub
    Private Sub GBTxtBx_Enter(sender As Object, e As EventArgs) Handles TkGBNo.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput
    End Sub
    Private Sub TmrActv_Tick(sender As Object, e As EventArgs) Handles TmrActv.Tick
        Dim Cnter As Integer = 0
        For Cnt_1 = 1 To 11
            If Mid(TkClPh.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnter += 1
            End If
        Next
        If Cnter = TkClPh.TextLength Then
            PublicCode.InsUpd("UPDATE Int_user SET UsrLastSeen = '" & Format(Now, "yyyy/MM/dd h:mm:ss") & "' WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H")  'Update User Active = false
        End If

    End Sub
    Private Sub RadNID_Click(sender As Object, e As EventArgs) Handles RadNID.Click, RadPss.Click
        TkClNtID.Text = ""
        If RadNID.Checked = True Then
            TkClNtID.Tag = "الرقم القومي"
            TkClNtID.Mask = "00000000000000"
            RadNID.Checked = True
            RadPss.Checked = False
            Label11.Text = "الرقم القومي : "
        Else
            TkClNtID.Tag = "رقم جواز السفر"
            TkClNtID.Mask = "AAAAAAAAAAAAAA"
            RadNID.Checked = False
            RadPss.Checked = True
            Label11.Text = "رقم جواز السفر : "
        End If
    End Sub
    Private Sub CombProdRef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CombProdRef.SelectedIndexChanged
        CombProdRef.Width = 25 + CombProdRef.Text.Length * 8
        CombProdRef.Location = New Point(210 - (CombProdRef.Width / 2), 424)
    End Sub
    Private Sub ToolTip1_Draw(sender As Object, e As DrawToolTipEventArgs) Handles ToolTip1.Draw
        e.DrawBackground()
        e.DrawBorder()
        e.DrawText()
    End Sub
    Private Sub TimrPhons_Tick(sender As Object, e As EventArgs) Handles TimrPhons.Tick

        If RadioButton8.Checked = True Then
            If PictureBox1.Size.Width > 29 Then
                PictureBox1.Size = New Point(PictureBox1.Size.Width - 1, 35)
                PictureBox1.Location = New Point(PictureBox1.Location.X + 0.5, PictureBox1.Location.Y + 1)
            Else
                PictureBox1.Size = New Point(PictureBox1.Size.Width + 1, 35)
                PictureBox1.Location = New Point(PictureBox1.Location.X - 0.5, PictureBox1.Location.Y - 1)
            End If
        End If
        If RadioButton9.Checked = True Then
            If PictureBox2.Size.Width > 38 Then
                PictureBox2.Size = New Point(PictureBox2.Size.Width - 1, 33)
                PictureBox2.Location = New Point(PictureBox2.Location.X + 0.5, PictureBox2.Location.Y + 1)
            Else
                PictureBox2.Size = New Point(PictureBox2.Size.Width + 1, 33)
                PictureBox2.Location = New Point(PictureBox2.Location.X - 0.5, PictureBox2.Location.Y - 1)
            End If
        End If
        If RadioButton11.Checked = True Then
            If PictureBox3.Size.Width > 29 Then
                PictureBox3.Size = New Point(PictureBox3.Size.Width - 1, 35)
                PictureBox3.Location = New Point(PictureBox3.Location.X + 0.5, PictureBox3.Location.Y + 1)
            Else
                PictureBox3.Size = New Point(PictureBox3.Size.Width + 1, 35)
                PictureBox3.Location = New Point(PictureBox3.Location.X - 0.5, PictureBox3.Location.Y - 1)
            End If
        End If
        If RadioButton12.Checked = True Then
            If PictureBox4.Size.Width > 38 Then
                PictureBox4.Size = New Point(PictureBox4.Size.Width - 1, 33)
                PictureBox4.Location = New Point(PictureBox4.Location.X + 0.5, PictureBox4.Location.Y + 1)
            Else
                PictureBox4.Size = New Point(PictureBox4.Size.Width + 1, 33)
                PictureBox4.Location = New Point(PictureBox4.Location.X - 0.5, PictureBox4.Location.Y - 1)
            End If
        End If
    End Sub
    Private Sub NewTicket_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Stop()
        TimrPhons.Stop()
        TmrActv.Stop()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EditTable = New DataTable
        Dim Fn As New APblicClss.Func
        LblText.Text = "جاري تحميل البيانات ............."
        LblText.Refresh()
        LblText.ForeColor = Color.DarkGreen
        If Fn.GetTblXX("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm, 0 AS LstSqlEv, '' AS LstUpdtTime, '' AS TkupTxt, 1 AS TkupUnread, 0 AS TkupEvtId, '' AS LstUpUsr, TkReOp, TkRecieveDt, TkEscTyp, ProdKNm, CompHelp,TkFnPrdCd, SrcNm2TkCompSrc,  CounNmSender2TkSndrCoun,  CounNmConsign2TkConsigCoun,  OffNm12TkOffNm FROM dbo.TicketsAll  where TkID = " & TikID.Text & " ORDER BY TkSQL DESC;", EditTable, "1050&H") = Nothing Then
            If EditTable.Rows.Count > 0 Then
                If EditTable.Rows(0).Item("PrdKind") = 1 Then
                    PrdKind = "مالية"
                    FinancialGroup.Visible = True
                    PostalGroup.Visible = False
                ElseIf EditTable.Rows(0).Item("PrdKind") = 2 Then
                    PrdKind = "بريدية"
                    FinancialGroup.Visible = False
                    PostalGroup.Visible = True
                Else
                    FinancialGroup.Visible = False
                    PostalGroup.Visible = False
                End If
                TreeView1.CollapseAll()

                If EditTable.Rows(0).Item("TkClsStatus") = True Then
                    TreeView1.Visible = False
                    LblText.Text = ("الشكوى مغلقة ولا يمكن تعديلها")
                    LblText.ForeColor = Color.Red
                    Exit Sub
                End If
                If EditTable.Rows(0).Item("TkKind") = True Then
                    RadioButton5.Checked = True
                    RadioButton4.Checked = False
                ElseIf EditTable.Rows(0).Item("TkKind") = False Then
                    RadioButton5.Checked = False
                    RadioButton4.Checked = True
                End If

                CompSurceTable.DefaultView.RowFilter = String.Empty

                Dim Node() As TreeNode
                Node = TreeView1.Nodes.Find(EditTable.Rows(0).Item("TkFnPrdCd").ToString, True)

                TreeView1.SelectedNode = Node(0)

                TkClPh.Text = EditTable.Rows(0).Item("TkClPh").ToString
                TkClPh1.Text = EditTable.Rows(0).Item("TkClPh1").ToString
                TkDtStart.Text = EditTable.Rows(0).Item("TkDtStart").ToString
                TkClNm.Text = EditTable.Rows(0).Item("TkClNm").ToString
                TkClAdr.Text = EditTable.Rows(0).Item("TkClAdr").ToString
                TkMail.Text = EditTable.Rows(0).Item("TkMail").ToString
                TkDetails.Text = EditTable.Rows(0).Item("TkDetails").ToString
                OffArea.Text = EditTable.Rows(0).Item("OffArea").ToString
                OffNm12TkOffNm.Text = EditTable.Rows(0).Item("OffNm1").ToString
                PrdNm.Text = EditTable.Rows(0).Item("PrdNm").ToString
                CompNm.Text = EditTable.Rows(0).Item("CompNm").ToString
                SrcNm2TkCompSrc.Text = EditTable.Rows(0).Item("SrcNm")
                TkShpNo.Text = EditTable.Rows(0).Item("TkShpNo").ToString
                CounNmSender.Text = EditTable.Rows(0).Item("CounNmSender").ToString
                CounNmConsign2TkConsigCoun.Text = EditTable.Rows(0).Item("CounNmConsign").ToString
                TkCardNo.Text = EditTable.Rows(0).Item("TkCardNo").ToString
                TkGBNo.Text = EditTable.Rows(0).Item("TkGBNo").ToString
                If IsNumeric(EditTable.Rows(0).Item("TkClNtID").ToString) = True Then
                    TkClNtID.Mask = "00000000000000"
                    RadNID.Checked = True
                    RadPss.Checked = False
                    Label11.Text = "الرقم القومي : "
                Else
                    TkClNtID.Tag = "رقم جواز السفر"
                    TkClNtID.Mask = "AAAAAAAAAAAAAA"
                    RadNID.Checked = False
                    RadPss.Checked = True
                End If
                TkClNtID.Text = EditTable.Rows(0).Item("TkClNtID").ToString
                TkAmount.Text = EditTable.Rows(0).Item("TkAmount").ToString
                TkTransDate.Text = EditTable.Rows(0).Item("TkTransDate").ToString
                UsrRealNm.Text = EditTable.Rows(0).Item("UsrRealNm").ToString
                SubmitBtn.Enabled = True
                LblText.Text = ""
                TreeView1.Visible = True

                If TkClPh.TextLength = 11 Then
                    RadioButton8.Checked = True
                    RadioButton9.Checked = False
                ElseIf TkClPh.TextLength = 10 Then
                    RadioButton8.Checked = False
                    RadioButton9.Checked = True
                End If
                If TkClPh1.TextLength = 11 Then
                    RadioButton8.Checked = True
                    RadioButton9.Checked = False
                ElseIf TkClPh.TextLength = 10 Then
                    RadioButton11.Checked = False
                    RadioButton12.Checked = True
                End If
                Panel2.Margin = New System.Windows.Forms.Padding(3, FlowLayoutPanel4.Height - 300, 1, 3)

                FlowLayoutPanel2.Visible = True
                FlowLayoutPanel3.Visible = True
                FlowLayoutPanel4.Visible = True
            Else
                TreeView1.Visible = False
                LblText.Text = ("لا توجد شكوى مسجلة بهذا الرقم" & ".... يرجى التأكد من الرقم وإعادة المحاولة")
                LblText.ForeColor = Color.Red
            End If
        Else
            LblText.Text = "Error"
        End If

        'If Usr.PUsrUCatLvl = 7 Then
        '    CompSurceTable.DefaultView.RowFilter = "[SrcSusp] =" & 0 & " AND [srcCd] = '1'"     '     SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1 ORDER BY SrcNm"
        'Else
        '    CompSurceTable.DefaultView.RowFilter = "[SrcSusp] =" & 0 & " AND [srcCd] > '1'"   '   SrcStr = "Select SrcCd, SrcNm from CDSrc where SrcSusp=0 And srcCd > 1 ORDER BY SrcNm"
        'End If

    End Sub
    Private Sub TikID_TextChanged(sender As Object, e As EventArgs) Handles TikID.TextChanged
        NewTickSub()
        ChckReAssign.Checked = False
        Panel2.Margin = New System.Windows.Forms.Padding(3, WelcomeScreen.Height - 350 - Panel2.Height, WelcomeScreen.Width - 100 - Panel2.Width, 3)
    End Sub

    Private Sub ChckReAssign_CheckedChanged(sender As Object, e As EventArgs) Handles ChckReAssign.CheckedChanged
        If ChckReAssign.Checked = True Then
            Dim Fn As New APblicClss.Func
            ReAssgnTbl = New DataTable
            If Fn.GetTblXX("SELECT UsrRealNm, FnMngr, dbo.VwFnProd.FnSQL FROM dbo.VwFnProd INNER JOIN dbo.Int_user ON dbo.VwFnProd.FnMngr = UsrId WHERE (dbo.VwFnProd.FnSQL = " & TreeView1.SelectedNode.Name & ")", ReAssgnTbl, "0000&H") = Nothing Then
                If ReAssgnTbl.Rows.Count > 0 Then
                    If UsrRealNm.Text <> ReAssgnTbl.Rows(0).Item(0) Then
                        ReAssgnSTR = "سيتم تحويل الشكوى من " & UsrRealNm.Text & " إلى " & ReAssgnTbl.Rows(0).Item(0) & " الآن بعد حفظ التعديل"
                        LblText.Text = ReAssgnSTR
                        ChckReAssign.BackColor = Color.LimeGreen
                    Else
                        ChckReAssign.Checked = False
                        MsgInf("الشكوى بالفعل لدى الفريق المختص " & Chr(34) & ReAssgnTbl.Rows(0).Item(0) & Chr(34))
                    End If
                End If

            End If
        Else
            LblText.Text = ""
            ChckReAssign.BackColor = Color.Red
        End If
    End Sub
End Class