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
    Dim UpdtCurrTbl As DataTable = New DataTable()
    Dim BKClr(2) As String
    Dim PrdBol As Boolean = False
    Dim TickSubmt As Thread
    Dim TickOffSubmt As Thread
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
            Me.Size = New Point(WelcomeScreen.Width, WelcomeScreen.Height - 110)
            FlowLayoutPanel4.Size = New Point((Me.Size.Width * 0.55), Me.Height - 100)
            FlowLayoutPanel2.Size = New Point((Me.Size.Width * 0.2), Me.Height - 100)
            FlowLayoutPanel3.Size = New Point((Me.Size.Width * 0.16), Me.Height - 100)
            TreeView1.Size = New Point((FlowLayoutPanel2.Width), FlowLayoutPanel2.Height - 100)
            TxtNId.Focus()
        End If
    End Sub
    Private Sub NewTickSub()
        DubStr = ""
        BKClr(0) = 210
        BKClr(1) = 241
        BKClr(2) = 255
        TxtTransDt.Value = Today.AddDays(1)
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




        TxtDt.Enabled = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton8.Checked = False
        RadioButton9.Checked = False
        RadioButton11.Checked = False
        RadioButton12.Checked = False

        TxtPh1.Enabled = False
        TxtPh2.Enabled = False
        TxtArea.SelectedIndex = -1
        TxtOff.SelectedIndex = -1
        TxtDist.SelectedIndex = -1
        TxtSrc.SelectedIndex = -1
        TxtCard.Text = ""
        TxtNId.Text = ""
        TxtNId.Mask = "00000000000000"
        RadNID.Checked = True
        TxtGP.Text = ""
        TxtAmount.Text = "0"
        TxtTrck.Text = ""
        TxtOrgin.Text = ""

        TickKind = 0
        PrdKind = ""

        MyGroupBox2.Enabled = False
        LblComp.Text = 0
        LblInq.Text = 0
        LblClsOp.Text = 0
        LblClsCls.Text = 0
        LblDublicate.Text = "Ticket(s) Before :"
        LblDublicate.ForeColor = Color.Black
        'OfficeTable.DefaultView.RowFilter = String.Empty
    End Sub
    Private Sub Mendatory()
        Dim Cnt_1 As Integer = 0
        Dim MendRw As DataRow = ProdCompTable.Rows.Find(TreeView1.SelectedNode.Name)
        If DBNull.Value.Equals(MendRw.ItemArray(7)) = False Then
            If (MendRw.ItemArray(7).Length) > 0 Then                          ' Adjust TextBox Length according to LablRef Length
                If CombProdRef.Items.Count = 0 Then
                    For Cnt_ = 0 To Split(MendRw.ItemArray(7), "-").Count - 1
                        CombProdRef.Items.Add(Split(MendRw.ItemArray(7), "-")(Cnt_))
                    Next
                    CombProdRef.Width = 35 + Split(MendRw.ItemArray(7), "-")(0).Length * 10
                    If CombProdRef.Items.Count > 0 Then CombProdRef.SelectedIndex = 0
                End If

                TxtTrck.MaxLength = 15 - CombProdRef.Text.Length
                TxtCard.MaxLength = 19 - CombProdRef.Text.Length
            End If


        End If
        LblHelp.Text = MendRw.ItemArray(11).ToString
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
                If Mid(TxtPh1.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            If Cnt_ < TxtPh1.TextLength Then
                TxtPh1.AccessibleName = "Mendatory"
            Else
                TxtPh1.AccessibleName = "None"
            End If
        Else
            TxtPh1.AccessibleName = "None"
        End If
        If Mid(MendRw.ItemArray(6), 6, 1) = "Y" Then
            TxtTrck.Enabled = True
            If DBNull.Value.Equals(MendRw.ItemArray(7)) = False Then
                'Put ProdRef Value in Track No Start
                TxtTrck.Text = CombProdRef.Text + Mid(TxtTrck.Text, CombProdRef.Text.Length + 1, 19 - CombProdRef.Text.Length + 1)
            End If

            If MendRw.ItemArray(9) = True Then
                TxtTrck.Mask = "LLL 00000000 LL"
                PrdBol = True
                If Mid(TxtTrck.Text, 2, 1).CompareTo("[A-Z][a-z]*") = -1 And Mid(TxtTrck.Text, 3, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TxtTrck.Text, 5, 8).CompareTo("[0-9]*") = -1 Or Mid(TxtTrck.Text, 14, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TxtTrck.Text, 15, 1).CompareTo("[A-Z][a-z]*") = -1 Then
                    TxtTrck.AccessibleName = "Mendatory"
                Else
                    TxtTrck.AccessibleName = "None"
                End If
            Else
                PrdBol = False
                TxtTrck.Mask = "LL 000000000 LL"
                If Mid(TxtTrck.Text, 2, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TxtTrck.Text, 4, 9).CompareTo("[0-9]*") = -1 Or Mid(TxtTrck.Text, 14, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TxtTrck.Text, 15, 1).CompareTo("[A-Z][a-z]*") = -1 Then
                    TxtTrck.AccessibleName = "Mendatory"
                Else
                    TxtTrck.AccessibleName = "None"
                End If
            End If

            'If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1) = "ايجى ميل" Then

            'Else

            'End If

        Else
            TxtTrck.AccessibleName = "None"
            TxtTrck.Text = ""
            TxtTrck.Enabled = False
            TxtTrck.Text = ""
        End If
        If TxtDist.Text.Length = 0 Then
            If Mid(MendRw.ItemArray(6), 7, 1) = "Y" Then
                TxtDist.AccessibleName = "Mendatory"
            Else
                TxtDist.AccessibleName = "None"
            End If
        Else
            TxtDist.AccessibleName = "None"
        End If
        Cnt_ = 0

        If Mid(MendRw.ItemArray(6), 8, 1) = "Y" Then
            TxtCard.Enabled = True

            'If CombProdRef.Text <> Mid(Replace(AccMskdBx.Text, " ", ""), 1, CombProdRef.Text.Length) Then
            '    MsgBox(Replace(Trim(Mid(AccMskdBx.Text, 1, CombProdRef.Text.Length)), " ", ""))
            'End If


            If DBNull.Value.Equals(MendRw.ItemArray(7)) = False Then
                'Put ProdRef Value in Acc No No Start
                TxtCard.Text = CombProdRef.Text + Mid(TxtCard.Text, CombProdRef.Text.Length + 2, 19 - CombProdRef.Text.Length + 1)
            End If

            For Cnt_1 = 1 To 19
                If Mid(TxtCard.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            If Cnt_ < 16 Then
                TxtCard.AccessibleName = "Mendatory"
            Else
                TxtCard.AccessibleName = "None"
            End If
        Else
            TxtCard.AccessibleName = "None"
            TxtCard.Text = ""
            TxtCard.Enabled = False
            TxtCard.Text = ""
        End If






        If Mid(MendRw.ItemArray(6), 9, 1) = "Y" Then
            Cnt_ = 0
            For Cnt_1 = 1 To 2
                If Mid(TxtGP.Text, Cnt_1, 1).CompareTo("[A-Z][a-z]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            For Cnt_1 = 3 To 16
                If Mid(TxtGP.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            If Cnt_ < 16 Then
                TxtGP.AccessibleName = "Mendatory"
            Else
                TxtGP.AccessibleName = "None"
            End If
        Else
            TxtGP.AccessibleName = "None"
        End If
        If Mid(MendRw.ItemArray(6), 10, 1) = "Y" Then

            If IsNothing(Replace(TxtNId.Text, " ", "")) = True Then
                TxtNId.AccessibleName = "Mendatory"
            Else
                If Replace(TxtNId.Text, " ", "").Length <> 14 Then
                    TxtNId.AccessibleName = "Mendatory"
                Else
                    TxtNId.AccessibleName = "None"
                End If
            End If
        Else
            TxtNId.AccessibleName = "None"
        End If

        If TxtAmount.Text = "0" Then
            If Mid(MendRw.ItemArray(6), 11, 1) = "Y" Then
                TxtAmount.AccessibleName = "Mendatory"
            Else
                TxtAmount.AccessibleName = "None"
            End If
        Else
            TxtAmount.AccessibleName = "None"
        End If
        If TxtTransDt.Value > Today Then
            If Mid(MendRw.ItemArray(6), 12, 1) = "Y" Then
                TxtTransDt.AccessibleName = "Mendatory"
            Else
                TxtTransDt.AccessibleName = "None"
            End If
        Else
            TxtTransDt.AccessibleName = "None"
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
            Me.Text = "تسجيل طلب جديد"
            Label16.Text = "مصدر الطلب :"
            Label5.Text = "نوع الطلب :"
            TxtSrc.Tag = "مصدر الطلب"
            TxtComp.Tag = "نوع الطلب"
        ElseIf (RadioButton5.Checked) Then
            TickKind = 1
            Me.Text = "تسجيل شكوى جديدة"
            Label16.Text = "مصدر الشكوى :"
            Label5.Text = "نوع الشكوى :"
            TxtSrc.Tag = "مصدر الشكوى"
            TxtComp.Tag = "نوع الشكوى"
        End If

        If TxtArea.Items.Count = 0 Then
            TxtArea.DataSource = AreaTable
            TxtArea.SelectedIndex = -1
        End If

        If TxtOff.Items.Count = 0 Then
            TxtOff.DataSource = OfficeTable
            AddHandler TxtArea.SelectedValueChanged, AddressOf AreaCmbBx_SelectedValueChanged 'Programming add Handler
            TxtOff.SelectedIndex = -1
        End If

        If TxtSrc.Items.Count = 0 Then
            TxtSrc.DataSource = CompSurceTable
            TxtSrc.SelectedIndex = -1
        End If

        If TxtDist.Items.Count = 0 Then
            TxtDist.DataSource = CountryTable
            TxtDist.SelectedIndex = -1
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
    Private Sub Mail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtEmail.Validating
        If IntUtly.IsValidEmail(TxtEmail.Text) Then
            ''ok
        Else
            Dim result As DialogResult _
        = MessageBox.Show("The email address you entered is not valid." &
                                   " Do you want re-enter it?", "Invalid Email Address",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If result = DialogResult.Yes Then
                e.Cancel = True
            ElseIf result = DialogResult.No Then
                TxtEmail.Text = ""
            End If
        End If
    End Sub
    Private Sub NameTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNm.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TxtNm.Text = Clipboard.GetText()
        End If
    End Sub
    Private Sub AddTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAdd.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TxtAdd.Text = Clipboard.GetText()
        End If
    End Sub
    Private Sub Phone1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.Click, RadioButton8.Click
        TimrPhons.Start()
        TxtPh1.Enabled = True
        TxtPh1.Text = ""
        If (RadioButton8.Checked) Then
            TxtPh1.Mask = "00000000000"
        ElseIf (RadioButton9.Checked) Then
            TxtPh1.Mask = "0000000000"
        End If
        TxtPh1.Focus()
        TxtNm.Text = ""
        TxtAdd.Text = ""
        TxtPh2.Text = ""
        TxtEmail.Text = ""
        RelatedTable.Rows.Clear()
    End Sub
    Private Sub PhonTxtBx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPh1.KeyPress, TxtPh2.KeyPress    'check character kind (Only numbers)
        NumberOnly(e)
    End Sub
    Public Sub ClntData()
        Dim primaryKey(0) As DataColumn
        RelatedTable.Rows.Clear()
        '  Table            0       1        2       3      4       5       6       7        8      9        10       11       12       13        14         15         16       17        18       19             20         21      22        23         24          25      26       27         28         29           30       31          32       33    34       35
        '  Grid             1        2       3      4       5       6       7        8       9      10       11       12       13        14       15          16         17      18        19       20             21         22      23        24         25          26      27       28         29         30           31       32          33       34    35       36
        If GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm, 0 AS LstSqlEv, '1/1/0001 12:00:00 AM' AS LstUpdtTime, '' AS TkupTxt, 0 AS TkupUnread, 0 AS TkupEvtId, '' AS EvNm, 0 AS EvSusp, 0 AS TkupUser, TkReOp FROM dbo.TicketsAll  WHERE (TkClPh = '" & TxtPh1.Text & "') ORDER BY TkSQL DESC;", RelatedTable, "1013&H") = Nothing Then
            primaryKey(0) = RelatedTable.Columns("TkSQL")
            RelatedTable.PrimaryKey = primaryKey

            If RelatedTable.Rows.Count > 0 Then
                Invoke(Sub() TxtNm.Text = RelatedTable(0).Item(5).ToString)
                Invoke(Sub() TxtAdd.Text = RelatedTable(0).Item(9).ToString)
                Invoke(Sub() TxtPh2.Text = RelatedTable(0).Item(7).ToString)
                If DBNull.Value.Equals(RelatedTable(0).Item(8).ToString) = False Then
                    Invoke(Sub() TxtEmail.Text = RelatedTable(0).Item(8).ToString)
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


                Invoke(Sub() LblComp.Text = Comp)
                Invoke(Sub() LblInq.Text = InQ)
                Invoke(Sub() LblClsCls.Text = Stat)
                Invoke(Sub() LblClsOp.Text = RelatedTable.Rows.Count - Stat)
                Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
            Else
                Invoke(Sub() TxtNm.Text = "")
                Invoke(Sub() TxtAdd.Text = "")
                Invoke(Sub() TxtPh2.Text = "")
                Invoke(Sub() TxtEmail.Text = "")
                Invoke(Sub() LblComp.Text = 0)
                Invoke(Sub() LblInq.Text = 0)
                Invoke(Sub() LblClsOp.Text = 0)
                Invoke(Sub() LblClsCls.Text = 0)
                Invoke(Sub() LblDublicate.Text = "Ticket(s) Before :")
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
    Private Sub Phon1TxtBx_TextChanged(sender As Object, e As EventArgs) Handles TxtPh1.TextChanged
        Cnt_ = 0
        For cnt_1 = 1 To TxtPh1.TextLength
            If Mid(TxtPh1.Text, cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnt_ += 1
            End If
        Next
        If Cnt_ = TxtPh1.TextLength Then

            Dim ClntThrd As New Thread(AddressOf ClntData)
            ClntThrd.IsBackground = True
            TxtPh1.BackColor = Color.FromArgb(128, 255, 128)
            TxtPh1.ForeColor = Color.Black
            ECnt_Label.ForeColor = Color.Green
            ECnt_Label.Text = "رقم التليفون مكتمل"
            WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ..........."
            TreeView1.Visible = True
            ClntThrd.Start()
            Me.Enabled = False
        Else
            TxtPh1.BackColor = Color.OrangeRed
            TxtPh1.ForeColor = Color.Yellow
            ECnt_Label.ForeColor = Color.Red
            ECnt_Label.Text = "رقم التليفون غير مكتمل"
            TreeView1.Visible = False
            TxtNm.Text = ""
            TxtAdd.Text = ""
            TxtPh2.Text = ""
            TxtEmail.Text = ""
            LblComp.Text = 0
            LblInq.Text = 0
            LblClsOp.Text = 0
            LblClsCls.Text = 0
            LblDublicate.Text = "Ticket(s) Before :"
        End If
    End Sub
    Private Sub Phon2TxtBx_TextChanged(sender As Object, e As EventArgs) Handles TxtPh2.TextChanged
        Cnt_ = 0
        For cnt_1 = 1 To TxtPh2.TextLength
            If Mid(TxtPh2.Text, cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnt_ += 1
            End If
        Next
        If Cnt_ = TxtPh2.TextLength Then
            TxtPh2.BackColor = Color.FromArgb(128, 255, 128)
            TxtPh2.ForeColor = Color.Black
            ECnt_Label.ForeColor = Color.Green
            ECnt_Label.Text = "رقم التليفون مكتمل"
        Else
            TxtPh2.BackColor = Color.OrangeRed
            TxtPh2.ForeColor = Color.Yellow
            ECnt_Label.ForeColor = Color.Red
            ECnt_Label.Text = "رقم التليفون غير مكتمل"
        End If
    End Sub
    Private Sub PhonTxtBx1_Leave(sender As Object, e As EventArgs) Handles TxtPh1.Leave
        If String.IsNullOrEmpty(TxtPh1.Text) Then
            RadioButton8.Checked = False
            RadioButton9.Checked = False
            Me.TxtPh1.Enabled = False
        Else
            If TxtPh1.MaskFull = False Then
                ECnt_Label.ForeColor = Color.Red
                TxtPh1.Focus()
                ECnt_Label.Text = "رقم الموبايل لابد أن يتكون من " & TxtPh1.MaxLength & " رقم"
                Beep()
            End If
        End If
        ECnt_Label.Text = ""
    End Sub
    Private Sub Phone2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton12.Click, RadioButton11.Click
        TimrPhons.Start()
        TxtPh2.Enabled = True
        TxtPh2.Text = ""
        If (RadioButton11.Checked) Then
            TxtPh2.Mask = "00000000000"
        ElseIf (RadioButton12.Checked) Then
            TxtPh2.Mask = "0000000000"
        End If
        TxtPh2.Focus()
        ECnt_Label.ForeColor = Color.Green
        ECnt_Label.Text = "رقم الموبايل لابد أن يتكون من " & TxtPh2.MaxLength & " رقم"
    End Sub
    Private Sub Phon2TxtBx_KeyUp(sender As Object, e As KeyEventArgs)
        If TxtPh2.TextLength < TxtPh2.MaxLength Then
            TxtPh2.BackColor = Color.OrangeRed
            TxtPh2.ForeColor = Color.Yellow
            ECnt_Label.ForeColor = Color.Red
            ECnt_Label.Text = "رقم التليفون غير مكتمل"
        ElseIf TxtPh2.TextLength = TxtPh2.MaxLength Then
            TxtPh2.BackColor = Color.FromArgb(128, 255, 128)
            TxtPh2.ForeColor = Color.Black
            ECnt_Label.ForeColor = Color.Green
            ECnt_Label.Text = "رقم التليفون مكتمل"
        End If
    End Sub
    Private Sub Phon2TxtBx_Leave(sender As Object, e As EventArgs) Handles TxtPh2.Leave
        If String.IsNullOrEmpty(TxtPh2.Text) Then
            TxtPh2.Enabled = False
            RadioButton11.Checked = False
            RadioButton12.Checked = False
            Me.TxtPh2.Enabled = False
        Else
            If TxtPh2.MaskFull = False Then
                TxtPh2.Focus()
                ECnt_Label.ForeColor = Color.Red
                ECnt_Label.Text = "رقم الموبايل لابد أن يتكون من " & TxtPh2.MaxLength & " رقم"
                Beep()
            End If
            If TxtPh2.TextLength < TxtPh2.MaxLength Then

            End If
        End If
        ECnt_Label.Text = ""
    End Sub
    Private Sub AmountTxtBx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAmount.KeyPress
        NumberDecimalOnly(e)
    End Sub
    Private Sub AmountTxtBx_Leave(sender As Object, e As EventArgs) Handles TxtAmount.Leave
        'Try
        '    AmountTxtBx.Text = Convert.ToDecimal(AmountTxtBx.Text).ToString("N2")
        'Catch exp As Exception
        '    MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    AmountTxtBx.Focus()
        'End Try
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        RemoveHandler TxtArea.SelectedValueChanged, AddressOf AreaCmbBx_SelectedValueChanged 'Programming add Handler
        Timer1.Stop()
        Me.Close()
    End Sub
    Private Sub OffCmbBx_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtOff.Validating
        If Len(TxtOff.Text) > 0 Then
            If (TxtOff.SelectedIndex = -1) Then
                e.Cancel = True
                Beep()
                ToolTip1.Show("Your choice Not listed", TxtOff, 0, 0, 5000)
            Else
                ToolTip1.Hide(TxtOff)
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
        For Cnt_ = 1 To TxtTrck.TextLength
            If Mid(TxtTrck.Text, Cnt_, 1) <> " " Then
                Trck &= Mid(TxtTrck.Text, Cnt_, 1)
            End If
        Next
        Dim sqlComminsert_3 As New SqlCommand            'SQL Command
        Dim sqlComminsert_4 As New SqlCommand            'SQL Command
        If TxtTransDt.Value = Today.AddDays(1) Then
            TranDt = ""
        Else
            TranDt = Format(TxtTransDt.Value, "yyyy/MM/dd").ToString
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
            '                                   TreeView1.SelectedNode.Name & "','" & SrcCmbBx.SelectedValue & "','" & Trim(NameTxtBx.Text) & "','" & Phon1TxtBx.Text & "','" & Phon2TxtBx.Text & "','" & AddTxtBx.Text & "','" & IDTxtBx.Text & "','" & Trck & "','" & GBTxtBx.Text & "','" & Trim(Mid(AccMskdBx.Text, 1, 4)) & Trim(Mid(AccMskdBx.Text, 6, 4)) & Trim(Mid(AccMskdBx.Text, 11, 4)) & Trim(Mid(AccMskdBx.Text, 16, 4)) & "','" & AmountTxtBx.Text & "','" & TranDt & "','" & DetailsTxtBx.Text & DubStr & "','" & Trim(Mid(TrackMskBx.Text, 14, 2)) & "','" & DistCmbBx.SelectedValue & "','" & OffCmbBx.SelectedValue & "','" & Usr.PUsrID & "','" & MailTxtBx.Text & "','" & 1 & "','" & Usr.PUsrID & "','" & "1" & "');")

            '    sqlComminsert_2.CommandText = "INSERT into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES 
            '                                                   ((Select Max(TkSQL) As RelationTkID FROM Tickets where TkEmpNm0 = " & Usr.PUsrID & "),'" & "The Inquiry has been Recieved" & "','" & "1" & "','" & "0" & "','" & OsIP() & "','" & Usr.PUsrID & "');"
            'Else
            If Usr.PUsrCalCntr = True Then
                Invoke(Sub() sqlComminsert_1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail) VALUES (0, '" & TickKind & "','" &
                                          TreeView1.SelectedNode.Name & "','" & TxtSrc.SelectedValue & "','" & Trim(TxtNm.Text) & "','" & TxtPh1.Text & "','" & TxtPh2.Text & "','" & TxtAdd.Text & "','" & TxtNId.Text & "','" & Trck & "','" & TxtGP.Text & "','" & Trim(Mid(TxtCard.Text, 1, 4)) & Trim(Mid(TxtCard.Text, 6, 4)) & Trim(Mid(TxtCard.Text, 11, 4)) & Trim(Mid(TxtCard.Text, 16, 4)) & "','" & TxtAmount.Text & "','" & TranDt & "','" & TxtDetails.Text & DubStr & "','" & Trim(Mid(TxtTrck.Text, 14, 2)) & "','" & TxtDist.SelectedValue & "','" & TxtOff.SelectedValue & "','" & Usr.PUsrID & "','" & TxtEmail.Text & "');")
            Else
                Invoke(Sub() sqlComminsert_1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail, TkEmpNm) VALUES (0, '" & TickKind & "','" &
                                      TreeView1.SelectedNode.Name & "','" & TxtSrc.SelectedValue & "','" & Trim(TxtNm.Text) & "','" & TxtPh1.Text & "','" & TxtPh2.Text & "','" & TxtAdd.Text & "','" & TxtNId.Text & "','" & Trck & "','" & TxtGP.Text & "','" & Trim(Mid(TxtCard.Text, 1, 4)) & Trim(Mid(TxtCard.Text, 6, 4)) & Trim(Mid(TxtCard.Text, 11, 4)) & Trim(Mid(TxtCard.Text, 16, 4)) & "','" & TxtAmount.Text & "','" & TranDt & "','" & TxtDetails.Text & DubStr & "','" & Trim(Mid(TxtTrck.Text, 14, 2)) & "','" & TxtDist.SelectedValue & "','" & TxtOff.SelectedValue & "','" & Usr.PUsrID & "','" & TxtEmail.Text & "','" & Usr.PUsrID & "');")
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

            Invoke(Sub() TxtDt.Text = Reader_!MaxDt)
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
            Timer1.Stop()
            Invoke(Sub() BtnDublicate.Visible = True)
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
        TickSubmt = New Thread(AddressOf SubmtTick)
        TickSubmt.IsBackground = True
        WelcomeScreen.StatBrPnlAr.Text = "جاري تسجيل البيانات ..........."
        TreeView1.Visible = True
        TickSubmt.Start()
        Me.Enabled = False
    End Sub
    Private Sub AreaCmbBx_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtArea.Validating
        If TxtArea.Text.Length > 0 Then
            If (TxtArea.SelectedIndex = -1) Then
                e.Cancel = True
                Beep()
                ToolTip1.Show("Your choice Not listed", TxtArea, 0, 20, 5000)
            Else
                ToolTip1.Hide(TxtSrc)
            End If
        End If
    End Sub
    Private Sub DistCmbBx_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDist.Validating
        If TxtDist.Text.Length > 0 Then
            If (TxtDist.SelectedIndex = -1) Then
                e.Cancel = True
                Beep()
                ToolTip1.Show("Your choice Not listed", TxtDist, 0, 20, 5000)
            Else
                ToolTip1.Hide(TxtSrc)
            End If
        End If
    End Sub
    Private Sub TrackMskBx_Leave(sender As Object, e As EventArgs) Handles TxtTrck.Leave
        Dim TempRow As DataRow
        Dim PrdNo As String
        Dim Stat_ As String
        Dim chck As Boolean = False

        LblDublicate.Text = "Ticket(s) Before :"
        TxtTrck.Text = UCase(TxtTrck.Text)

        If PrdBol = True Then
            PrdNo = Trim(Mid(TxtTrck.Text, 1, 3)) & Trim(Mid(TxtTrck.Text, 5, 8)) & Trim(Mid(TxtTrck.Text, 14, 2))
            If (Trim(Mid(TxtTrck.Text, 1, 3)) & Trim(Mid(TxtTrck.Text, 5, 8)) & Trim(Mid(TxtTrck.Text, 14, 2))).Length = 13 Then
                chck = True
            Else
                chck = False
            End If
        Else
            PrdNo = Trim(Mid(TxtTrck.Text, 1, 2)) & Trim(Mid(TxtTrck.Text, 4, 9)) & Trim(Mid(TxtTrck.Text, 14, 2))
            If (Trim(Mid(TxtTrck.Text, 1, 2)) & Trim(Mid(TxtTrck.Text, 4, 9)) & Trim(Mid(TxtTrck.Text, 14, 2))).Length = 13 Then
                chck = True
            Else
                chck = False
            End If
        End If
        If chck = True Then
            'If Mid(TrackMskBx.Text, 14, 1).CompareTo("[A-Z][a-z]*") = 1 Or Mid(TrackMskBx.Text, 15, 1).CompareTo("[A-Z][a-z]*") = 1 Then
            TempRow = CountryTable.Rows.Find(Mid(TxtTrck.Text, 14, 2))
            If TempRow Is Nothing Then
                MsgInf("لا توجد دولة مسجلة بهذا الاسم" & vbCrLf & "يرجى مراجعة رقم التتبع")
            Else
                TxtOrgin.Text = TempRow.ItemArray(1)
                TxtTrck.BackColor = Color.FromArgb(128, 255, 128)
            End If
        Else
            Beep()
            WelcomeScreen.StatBrPnlAr.Text = "يرجى التحقق من رقم التتبع"
            TxtTrck.Text = ""
            Exit Sub
        End If

        If PrdNo.Length = 13 Then
            If RelatedTable.Rows.Count > 0 Then
                For PrdRefCount = 0 To RelatedTable.Rows.Count - 1
                    If RelatedTable.Rows(PrdRefCount).Item(11).ToString = PrdNo Then
                        If RelatedTable.Rows(PrdRefCount).Item(24) = False Then
                            Stat_ = " ( Open )"
                        Else
                            Stat_ = " ( Closed )"
                        End If
                        LblDublicate.Text &= vbCrLf & "           - " & RelatedTable.Rows(PrdRefCount).Item(3).ToString & Stat_
                        LblDublicate.ForeColor = Color.Red
                        Beep()
                    End If
                Next
            End If
        Else
            LblDublicate.Text = "Ticket(s) Before :"
            LblDublicate.ForeColor = Color.Black
            TxtTrck.Text = ""
        End If
    End Sub
    Private Sub TrackMskBx_TextChanged(sender As Object, e As EventArgs) Handles TxtTrck.TextChanged
        ToolTip1.Hide(TxtTrck)
        TxtTrck.BackColor = Color.White
        TxtOrgin.Text = ""
    End Sub
    Private Sub TrackMskBx_Enter(sender As Object, e As EventArgs) Handles TxtTrck.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput            'Tansfer writing to English
    End Sub
    Private Sub NameTxtBx_Enter(sender As Object, e As EventArgs) Handles TxtNm.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub DistCmbBx_Enter(sender As Object, e As EventArgs) Handles TxtDist.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub MailTxtBx_Enter(sender As Object, e As EventArgs) Handles TxtEmail.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput
    End Sub
    Private Sub DetailsTxtBx_Enter(sender As Object, e As EventArgs) Handles TxtDetails.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub AddTxtBx_Enter(sender As Object, e As EventArgs) Handles TxtAdd.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub OffCmbBx_Enter(sender As Object, e As EventArgs) Handles TxtOff.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim TempClr As DataRow
        LblDublicate.Text = "Ticket(s) Before :"
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

            '    'If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1) = "ايجى ميل" Then

            '    'End If
            Timer1.Start()
            PrdKind = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0)
        TxtProd.Text = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1)
        TxtComp.Text = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(2)

            'ElseIf (TreeView1.SelectedNode.Level) < 2 Then
            '    PrdBol = False
            '    Timer1.Stop()
            '    TxtProd.Text = ""
            '    TxtComp.Text = ""
            '    TxtCard.Text = ""
            '    TxtTrck.Text = ""
            '    Label18.Text = ""
        End If

        'If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0) <> PrdKind Then PrdKind = ""

        'If PrdKind = "مالية" Then
        '    Me.FinancialGroup.Visible = True
        '    Me.PostalGroup.Visible = False
        '    CombProdRef.Visible = True
        '    TxtTrck.Text = ""
        '    TxtOrgin.Text = ""
        '    TxtDist.SelectedValue = ""
        'ElseIf PrdKind = "بريدية" Then
        '    TxtCard.Text = ""
        '    TxtGP.Text = ""
        '    TxtNId.Text = ""
        '    TxtAmount.Text = "0"
        '    Me.FinancialGroup.Visible = False
        '    Me.PostalGroup.Visible = True
        '    CombProdRef.Visible = True
        'ElseIf PrdKind = "حكومية" Then
        '    Me.FinancialGroup.Visible = False
        '    Me.PostalGroup.Visible = False
        '    CombProdRef.Visible = False
        '    TxtCard.Text = ""
        '    TxtGP.Text = ""
        '    TxtNId.Text = ""
        '    TxtAmount.Text = "0"
        '    TxtTrck.Text = ""
        '    TxtOrgin.Text = ""
        '    TxtDist.SelectedValue = ""
        'ElseIf PrdKind = "مجتمعية" Then
        '    Me.FinancialGroup.Visible = False
        '    Me.PostalGroup.Visible = False
        '    CombProdRef.Visible = False
        '    TxtCard.Text = ""
        '    TxtGP.Text = ""
        '    TxtNId.Text = ""
        '    TxtAmount.Text = ""
        '    TxtTrck.Text = ""
        '    TxtOrgin.Text = ""
        '    TxtDist.SelectedValue = ""
        'ElseIf PrdKind = "أخرى" Then
        '    Me.FinancialGroup.Visible = False
        '    Me.PostalGroup.Visible = False
        '    CombProdRef.Visible = False
        '    TxtCard.Text = ""
        '    TxtGP.Text = ""
        '    TxtNId.Text = ""
        '    TxtAmount.Text = "0"
        '    TxtTrck.Text = ""
        '    TxtOrgin.Text = ""
        '    TxtDist.SelectedValue = ""
        'ElseIf PrdKind = "" Then
        '    Me.FinancialGroup.Visible = False
        '    Me.PostalGroup.Visible = False
        '    CombProdRef.Visible = False
        '    TxtCard.Text = ""
        '    TxtGP.Text = ""
        '    TxtNId.Text = ""
        '    TxtAmount.Text = "0"
        '    TxtTrck.Text = ""
        '    TxtOrgin.Text = ""
        '    TxtDist.SelectedValue = ""
        'End If
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
        If TxtArea.SelectedIndex <> -1 Then
            OfficeTable.DefaultView.RowFilter = "OffArea = '" & TxtArea.SelectedValue.ToString & "'"
            TxtOff.SelectedIndex = -1
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
    Private Sub AreaCmbBx_Enter(sender As Object, e As EventArgs) Handles TxtArea.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput            'Tansfer writing to English
    End Sub
    Private Sub IDTxtBx_Leave(sender As Object, e As EventArgs) Handles TxtNId.Leave
        Cnt_ = 0
        If RadNID.Checked = True Then
            For Cnt_1 = 1 To 14
                If Mid(TxtNId.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            If Cnt_ < 14 And Cnt_ <> 0 Then
                Beep()
                TxtNId.Text = ""
                MsgInf("الرقم القومي لابد أن يتكون من 14 رقم")
            End If
        End If
        TxtNId.Text = UCase(TxtNId.Text)
    End Sub
    Private Sub GBTxtBx_Leave(sender As Object, e As EventArgs) Handles TxtGP.Leave
        For Cnt_1 = 1 To 16
            If Mid(TxtGP.Text, Cnt_1, 1).CompareTo("[A-Z][a-z]*") = 1 Then
                Cnt_ += 1
            End If
            If Mid(TxtGP.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnt_ += 1
            End If
        Next
        If Cnt_ < 16 And Cnt_ <> 0 Then
            Beep()
            TxtGP.Text = ""
            MsgInf("رقم أمر الدفع لابد أن يتكون من 16 رقم")
        Else
            TxtGP.Text = UCase(TxtGP.Text)
        End If
    End Sub
    Private Sub NewBtn_Click(sender As Object, e As EventArgs) Handles NewBtn.Click
        NewTickSub()
    End Sub
    'Second Tab                     XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub AccMskdBx_Leave(sender As Object, e As EventArgs) Handles TxtCard.Leave
        Dim PrdRefCount As Integer = 0
        Dim PrdNo As String
        Dim Stat_ As String
        LblDublicate.Text = "Ticket(s) Before :"
        PrdNo = Trim(Mid(TxtCard.Text, 1, 4)) & Trim(Mid(TxtCard.Text, 6, 4)) & Trim(Mid(TxtCard.Text, 11, 4)) & Trim(Mid(TxtCard.Text, 16, 4))
        If PrdNo.Length = 16 Then
            If RelatedTable.Rows.Count > 0 Then
                For PrdRefCount = 0 To RelatedTable.Rows.Count - 1
                    If RelatedTable.Rows(PrdRefCount).Item(10).ToString = PrdNo Then
                        If RelatedTable.Rows(PrdRefCount).Item(24) = False Then
                            Stat_ = " ( Open )"
                        Else
                            Stat_ = " ( Closed )"
                        End If
                        LblDublicate.Text &= vbCrLf & "           - " & RelatedTable.Rows(PrdRefCount).Item(3).ToString & Stat_
                        LblDublicate.ForeColor = Color.Red
                        Beep()
                    End If
                Next
            End If
        Else
            LblDublicate.Text = "Ticket(s) Before :"
            LblDublicate.ForeColor = Color.Black
            TxtCard.Text = ""
        End If
    End Sub
    'Private Sub TxtUpdt2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUpdt2.KeyPress
    '    IntUtly.ValdtIntLetter(e)
    'End Sub
    Private Sub IDTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNId.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TxtNId.Text = Clipboard.GetText()
        End If
        TxtNId.Text = Mid(TxtNId.Text, 1, TxtNId.MaxLength)
    End Sub
    Private Sub AccMskdBx_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCard.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TxtCard.Text = Clipboard.GetText()
        End If
        TxtCard.Text = Mid(TxtCard.Text, 1, TxtCard.MaxLength)
    End Sub
    Private Sub GBTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtGP.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TxtGP.Text = Clipboard.GetText()
        End If
        TxtGP.Text = Mid(TxtGP.Text, 1, TxtGP.MaxLength)
    End Sub
    Private Sub Phon1TxtBx_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TxtPh1.Text = Clipboard.GetText()
        End If
        TxtPh1.Text = Mid(TxtPh1.Text, 1, TxtPh1.MaxLength)
    End Sub
    Private Sub GBTxtBx_Enter(sender As Object, e As EventArgs) Handles TxtGP.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput
    End Sub
    Private Sub TmrActv_Tick(sender As Object, e As EventArgs) Handles TmrActv.Tick
        Dim Cnter As Integer = 0
        For Cnt_1 = 1 To 11
            If Mid(TxtPh1.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnter += 1
            End If
        Next
        If Cnter = TxtPh1.TextLength Then
            PublicCode.InsUpd("UPDATE Int_user SET UsrLastSeen = '" & Format(Now, "yyyy/MM/dd h:mm:ss") & "' WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H")  'Update User Active = false
        End If

    End Sub
    Private Sub RadNID_Click(sender As Object, e As EventArgs) Handles RadNID.Click, RadPss.Click
        TxtNId.Text = ""
        If RadNID.Checked = True Then
            TxtNId.Tag = "الرقم القومي"
            TxtNId.Mask = "00000000000000"
            RadNID.Checked = True
            RadPss.Checked = False
            Label11.Text = "الرقم القومي : "
        Else
            TxtNId.Tag = "رقم جواز السفر"
            TxtNId.Mask = "AAAAAAAAAAAAAA"
            RadNID.Checked = False
            RadPss.Checked = True
            Label11.Text = "رقم جواز السفر : "
        End If
    End Sub
    Private Sub BtnDublicate_Click(sender As Object, e As EventArgs) Handles BtnDublicate.Click
        DubStr = vbCrLf & vbCrLf & "إضافة تلقائية من النظام: " & vbCrLf & "تم تسجيل هذه الشكوى للعميل عن طريق استخدم زر التكرار"
        Invoke(Sub()
                   Dim CTRLLst As New List(Of Control)
                   GetAll(Me).ToList.ForEach(Sub(c)
                                                 CTRLLst.Add(c)
                                             End Sub)

                   For Each Ctrol As Control In CTRLLst
                       If TypeOf Ctrol Is TextBox Then
                           Dim TxtBox As TextBox = Ctrol
                           Ctrol.Enabled = True
                           If TxtBox.ReadOnly = False Then
                               Ctrol.BackColor = Color.White
                               Ctrol.ForeColor = Color.Black
                           End If
                       ElseIf TypeOf Ctrol Is MaskedTextBox Then
                           Dim TxtBox As MaskedTextBox = Ctrol
                           Ctrol.Enabled = True
                           If TxtBox.ReadOnly = False Then
                               Ctrol.BackColor = Color.White
                               Ctrol.ForeColor = Color.Black
                           End If
                       ElseIf TypeOf Ctrol Is ComboBox Then
                           Ctrol.Enabled = True
                           Dim TxtBox As ComboBox = Ctrol
                       ElseIf TypeOf Ctrol Is RadioButton Then
                           Ctrol.Enabled = True
                       ElseIf TypeOf Ctrol Is DateTimePicker Then
                           Ctrol.Enabled = True
                       End If
                   Next
               End Sub)
        TreeView1.Enabled = True
        Invoke(Sub() SubmitBtn.Visible = True)
        Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
        BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TreeView1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TabPage1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TxtTikID.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox2.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        FinancialGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        PostalGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        Timer1.Start()
        Invoke(Sub() BtnDublicate.Visible = False)
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
        Dim EditTable As DataTable = New DataTable
        Dim Fn As New APblicClss.Func
        lblMsg.Text = "جاري تحميل البيانات ............."
        lblMsg.Refresh()
        lblMsg.ForeColor = Color.DarkGreen
        If Fn.GetTblXX("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm, 0 AS LstSqlEv, '' AS LstUpdtTime, '' AS TkupTxt, 1 AS TkupUnread, 0 AS TkupEvtId, '' AS LstUpUsr, TkReOp, TkRecieveDt, TkEscTyp, ProdKNm, CompHelp,TkFnPrdCd FROM dbo.TicketsAll  where TkID = " & TikID.Text & " ORDER BY TkSQL DESC;", EditTable, "1050&H") = Nothing Then
            If EditTable.Rows.Count > 0 Then
                If EditTable.Rows(0).Item("PrdKind") = 1 Then
                    FinancialGroup.Visible = True
                    PostalGroup.Visible = False
                ElseIf EditTable.Rows(0).Item("PrdKind") = 2 Then
                    FinancialGroup.Visible = False
                    PostalGroup.Visible = True
                Else
                    FinancialGroup.Visible = False
                    PostalGroup.Visible = False
                End If
                TreeView1.CollapseAll()

                If EditTable.Rows(0).Item("TkClsStatus") = True Then
                    TreeView1.Visible = False
                    lblMsg.Text = ("الشكوى مغلقة ولا يمكن تعديلها")
                    lblMsg.ForeColor = Color.Red
                    Exit Sub
                End If

                If EditTable.Rows(0).Item("TkKind") = True Then
                    RadioButton5.Checked = True
                    RadioButton4.Checked = False
                ElseIf EditTable.Rows(0).Item("TkKind") = False Then
                    RadioButton5.Checked = False
                    RadioButton4.Checked = True
                End If
                Dim Node() As TreeNode
                Node = TreeView1.Nodes.Find(EditTable.Rows(0).Item("TkFnPrdCd").ToString, True)

                TreeView1.SelectedNode = Node(0)

                TxtPh1.Text = EditTable.Rows(0).Item("TkClPh").ToString
                TxtPh2.Text = EditTable.Rows(0).Item("TkClPh1").ToString
                TxtDt.Text = EditTable.Rows(0).Item("TkDtStart").ToString
                TxtNm.Text = EditTable.Rows(0).Item("TkClNm").ToString
                TxtAdd.Text = EditTable.Rows(0).Item("TkClAdr").ToString
                TxtEmail.Text = EditTable.Rows(0).Item("TkMail").ToString
                TxtDetails.Text = EditTable.Rows(0).Item("TkDetails").ToString
                TxtArea.Text = EditTable.Rows(0).Item("OffArea").ToString
                TxtOff.Text = EditTable.Rows(0).Item("OffNm1").ToString
                TxtProd.Text = EditTable.Rows(0).Item("PrdNm").ToString
                TxtComp.Text = EditTable.Rows(0).Item("CompNm").ToString
                TxtSrc.Text = EditTable.Rows(0).Item("SrcNm")
                TxtTrck.Text = EditTable.Rows(0).Item("TkShpNo").ToString
                TxtOrgin.Text = EditTable.Rows(0).Item("CounNmSender").ToString
                TxtDist.Text = EditTable.Rows(0).Item("CounNmConsign").ToString
                TxtCard.Text = EditTable.Rows(0).Item("TkCardNo").ToString
                TxtGP.Text = EditTable.Rows(0).Item("TkGBNo").ToString
                TxtNId.Text = EditTable.Rows(0).Item("TkClNtID").ToString
                TxtAmount.Text = EditTable.Rows(0).Item("TkAmount").ToString
                TxtTransDt.Text = EditTable.Rows(0).Item("TkTransDate").ToString
                'TxtFolw.Text = EditTable.Rows(0).Item("UsrRealNm").ToString
                SubmitBtn.Enabled = True
                lblMsg.Text = ""
                TreeView1.Visible = True

                If TxtPh1.TextLength = 11 Then
                    RadioButton8.Checked = True
                    RadioButton9.Checked = False
                ElseIf TxtPh1.TextLength = 10 Then
                    RadioButton8.Checked = False
                    RadioButton9.Checked = True
                End If
                If TxtPh2.TextLength = 11 Then
                    RadioButton8.Checked = True
                    RadioButton9.Checked = False
                ElseIf TxtPh1.TextLength = 10 Then
                    RadioButton11.Checked = False
                    RadioButton12.Checked = True
                End If
            Else
                TreeView1.Visible = False
                lblMsg.Text = ("لا توجد شكوى مسجلة بهذا الرقم" & vbCrLf & "يرجى التأكد من الرقم وإعادة المحاولة")
                lblMsg.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub TikID_TextChanged(sender As Object, e As EventArgs) Handles TikID.TextChanged
        NewTickSub()
    End Sub
End Class