
Imports System.Text
Public Class DistribTicket
    Private ReadOnly UserTable As DataTable = New DataTable
    Private CompCountTable As DataTable = New DataTable
    Private ClintPhTable As DataTable = New DataTable
    Dim DisributeTable As DataTable = New DataTable
    Dim ClintPhView As DataView
    Dim LoadBol As Boolean = False
    Dim Filtr As String
    Dim UsrStr As String = ""
    Dim UsrStr1 As StringBuilder
    Dim UsrEmStr As String = ""
    Dim PhonStr As String = ""
    Dim CompIdStr As String = ""
    Dim TemIDStr As String = ""
    Dim AgentCount As Integer = 0
    Dim TickCount As Integer = 0
    Dim chgd As Boolean
    'Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    'Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
    '    Get
    '        Dim myCp As CreateParams = MyBase.CreateParams
    '        myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
    '        Return myCp
    '    End Get
    'End Property
    Private Sub DistribTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim TempNode() As TreeNode
        UserTree.ImageList = ImgLst
        UsrEmStr = "TkEmpNm = " & Usr.PUsrID & " OR "
        UserTree.Nodes.Add(Usr.PUsrCat.ToString, Usr.PUsrID & " - " & Usr.PUsrCatNm & " - " & Usr.PUsrRlNm, 1, 3)
        Dim Fn As New APblicClss.Func
        '                   0  ,    1  ,     2    ,    3   ,     4     as mix name                 ***   
        If Fn.GetTblXX("Select UsrId, UCatId, UCatIdSub, UCatLvl, UCatNm + N' - ' + UsrRealNm AS UsrMix From Int_user RIGHT OUTER Join IntUserCat On UsrCat = UCatId Where (UsrSusp = 0) AND (UCatLvl between 3 and 5) Order By UCatIdSub, UsrRealNm", UserTable, "1025&H") = Nothing Then
            UsrStr1 = New StringBuilder
            UsrStr1.Append(" UsrId In (")
            For Cnt_ = 0 To UserTable.Rows.Count - 1
                TempNode = UserTree.Nodes.Find(UserTable(Cnt_).Item(2).ToString, True)
                If TempNode.Length > 0 Then
                    TempNode(0).Nodes.Add(UserTable(Cnt_).Item(1).ToString, UserTable(Cnt_).Item(0).ToString & " - " & UserTable(Cnt_).Item(4).ToString, 0, 2)
                    UsrStr1.Append(UserTable(Cnt_).Item(0).ToString & " , ")
                    UsrStr &= "UsrId = " & UserTable(Cnt_).Item(0).ToString & " OR "
                    UsrEmStr &= "TkEmpNm = " & UserTable(Cnt_).Item(0).ToString & " OR "
                    If TempNode(0).Nodes.Count > 0 Then
                        TempNode(0).ImageIndex = 1
                        TempNode(0).SelectedImageIndex = 3
                    End If
                End If
            Next Cnt_
            UsrStr = Mid(String.Join(",", UsrStr1.ToString), 1, UsrStr1.ToString.Length - 2) & ")"
            'If UsrStr.Length > 0 Then UsrStr = Mid(UsrStr, 1, UsrStr.Length - 4) Else UsrStr = ""
            If UsrEmStr.Length > 0 Then UsrEmStr = Mid(UsrEmStr, 1, UsrEmStr.Length - 4) Else UsrEmStr = ""
            UserTree.ExpandAll()

            FilTbls()
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
        Me.Size = New Point(WelcomeScreen.Width - 12, WelcomeScreen.Height - 110)
        FlowLayoutPanel1.Size = New Point(WelcomeScreen.Width - 12, WelcomeScreen.Height - 400)
        GridUsrTickCount.Size = New Point((WelcomeScreen.Width - 12) * 0.15, WelcomeScreen.Height - 450)
        UserTree.Size = New Point((WelcomeScreen.Width - 12) * 0.15, WelcomeScreen.Height - 450)
        GridTicket.Size = New Point((WelcomeScreen.Width - 12) * 0.67, WelcomeScreen.Height - 450)
        'BtnSubmit.Margin = New System.Windows.Forms.Padding(3, 0, WelcomeScreen.Width - 100 - BtnSubmit.Width, 3)
        '
    End Sub
    Private Sub BtnBck_Click(sender As Object, e As EventArgs) Handles BtnBck.Click
        TabControl1.TabPages.Remove(TabPage2)
    End Sub
    Private Sub UserTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles UserTree.AfterSelect
        UserTree.SelectedNode.BackColor = Color.FromArgb(100, 100, 235)
        UserTree.SelectedNode.ForeColor = Color.White
        For Cnt_ = 0 To GridUsrTickCount.Rows.Count - 1
            If Split(UserTree.SelectedNode.Text, " - ")(2) = GridUsrTickCount.Rows(Cnt_).Cells(0).Value Then
                GridUsrTickCount.Rows(Cnt_).Selected = True
                GridUsrTickCount.Rows(Cnt_).Cells(1).Selected = True
                Exit For
            Else
                GridUsrTickCount.ClearSelection()
            End If
        Next Cnt_
    End Sub
    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        submt()
        FilTbls()
    End Sub
    Private Sub UserTree_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles UserTree.BeforeSelect
        If UserTree.SelectedNode IsNot Nothing Then
            UserTree.SelectedNode.BackColor = Color.White
            UserTree.SelectedNode.ForeColor = Color.Black
        End If
    End Sub
    Private Sub FilTbls()
        Dim column As New DataGridViewButtonColumn()
        RemoveHandler GridTicket.SelectionChanged, AddressOf GridTicket_SelectionChanged
        With column
            .Name = "توزيع/إستعادة"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Popup
            .Text = "توزيع"
            '.CellTemplate = New DataGridViewButtonColumn()
        End With
        GridTicket.DataSource = ""
        GridTicket.Columns.Clear()
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل الشكاوى قيد التوزيع ..................."
        chgd = False
        AgentCount = 0
        TickCount = 0
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)
        DisributeTable.Rows.Clear()
        CompCountTable.Rows.Clear()
        GridUsrTickCount.DataSource = ""
        Dim Fn As New APblicClss.Func


        If Fn.GetTblXX("SELECT TkSQL, TkDtStart As [تاريخ الشكوى], TkID As [رقم الشكوى], SrcNm As [مصدر الشكوى], TkClNm As [اسم العميل], TkClPh As [رقم التليفون], TkClPh1 As [تليفون2], TkMail, TkClAdr, TkCardNo  As [رقم الكارت], TkShpNo As [رقم الشحنة], TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm As [اسم الخدمة], CompNm As [نوع الشكوى], CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm AS [متابع الشكوى] FROM TicketsAll WHERE ((TkRecieveDt is Null) And (" & UsrEmStr & ") And (TkClsStatus = 0)) Or (TkEmpNm = " & Usr.PUsrID & " And (TkClsStatus = 0)) ORDER BY TkSQL;", DisributeTable, "1026&H") = Nothing Then
            If DisributeTable.Rows.Count > 0 Then
                AddHandler GridTicket.SelectionChanged, AddressOf GridTicket_SelectionChanged
                GridTicket.DataSource = DisributeTable
                GridTicket.Columns.Insert(27, column)
                GridTicket.Columns(0).Visible = False
                GridTicket.Columns(7).Visible = False
                GridTicket.Columns(8).Visible = False
                GridTicket.Columns(11).Visible = False
                GridTicket.Columns(12).Visible = False
                GridTicket.Columns(13).Visible = False
                GridTicket.Columns(14).Visible = False
                GridTicket.Columns(15).Visible = False
                GridTicket.Columns(18).Visible = False
                GridTicket.Columns(19).Visible = False
                GridTicket.Columns(20).Visible = False
                GridTicket.Columns(21).Visible = False
                GridTicket.Columns(22).Visible = False
                GridTicket.Columns(23).Visible = False
                GridTicket.Columns(24).Visible = False
                GridTicket.Columns(25).Visible = False

                If LoadBol = False Then
                    WelcomeScreen.StatBrPnlAr.Text = "جاري تجهيز بيانات العملاء المتعلقة ..............."
                    For Rws = 0 To DisributeTable.Rows.Count - 1
                        GridTicket.Rows(Rws).Cells(27).Value = "توزيع"
                        'GridTicket.Rows(Rws).Cells(26).Value = ""
                        WelcomeScreen.StatBrPnlAr.Text = " جاري تجهيز بيانات العملاء المتعلقة" & "  ..." & Rws + 1
                        PhonStr &= "TkClPh = '" & DisributeTable(Rws).Item(5).ToString & "' OR "
                        CompIdStr &= "TkSQL <> " & DisributeTable(Rws).Item("TkSQL").ToString & " AND "
                        TemIDStr = MyTeam(Usr.PUsrCat, Usr.PUsrID, "TkEmpNm")
                    Next


                    If PhonStr.Length > 0 Then PhonStr = "(" & Mid(PhonStr, 1, PhonStr.Length - 4) & ")" Else PhonStr = ""
                    If CompIdStr.Length > 0 Then CompIdStr = "(" & Mid(CompIdStr, 1, CompIdStr.Length - 4) & ")" Else CompIdStr = ""

                    ClintPhTable.Rows.Clear()
                    ClintPhTable.Columns.Clear()
                    GetTbl("SELECT TicketsAll.UsrRealNm As [متابع الشكوى], TkDtStart As [تاريخ الشكوى], TkID As [رقم الشكوى], SrcNm As [مصدر الشكوى], TkClNm As [اسم العميل], TkClPh As [تليفون العميل], PrdNm As [اسم المنتج], CompNm As [نوع الشكوى], TkClsStatus As [حالة الشكوى], TicLstEv.LstUpdtTime As [تاريخ آخر تحديث] FROM TicketsAll INNER JOIN TkEvent ON TkSQL = TkEvent.TkupTkSql INNER JOIN TicLstEv ON TkEvent.TkupSQL = TicLstEv.LstSqlEv INNER JOIN CDEvent ON TkEvent.TkupEvtId = CDEvent.EvId INNER JOIN Int_user ON TkEvent.TkupUser = Int_user.UsrId INNER JOIN dbo.IntUserCat ON dbo.Int_user.UsrCat = dbo.IntUserCat.UCatId Where" & PhonStr & " AND " & CompIdStr & " AND " & TemIDStr & " ORDER BY TkClsStatus;", ClintPhTable, "0000&H")
                    ClintPhView = (ClintPhTable.DefaultView)
                    DataGridView1.DataSource = ClintPhView
                    WelcomeScreen.StatBrPnlAr.Text = "جاري إعداد البيانات النهائية ........................."
                    For Cnt_ = 0 To GridTicket.Rows.Count - 1
                        Filtr = ""
                        Filtr = "([تليفون العميل] like '%" & GridTicket.Rows(Cnt_).Cells(5).Value & "%')"
                        ClintPhTable.DefaultView.RowFilter = Filtr
                        If ClintPhView.Count > 0 Then
                            GridTicket.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                            GridTicket.Rows(Cnt_).DefaultCellStyle.ForeColor = Color.Blue
                        End If
                    Next Cnt_



                    LoadBol = True
                End If

                If LoadBol = True Then
                    For Rws = 0 To DisributeTable.Rows.Count - 1
                        GridTicket.Rows(Rws).Cells(27).Value = "توزيع"
                        GridTicket.Rows(Rws).Cells("متابع الشكوى").Value = ""
                    Next
                End If

                GridTicket.Rows(0).Cells(1).Selected = True
            Else
                MsgInf("لا توجد شكاوى للتوزيع حالياً")
            End If
        Else
            MsgErr("كود خطأ : " & "1026&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)

        End If

        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل أعداد الشكاوى لكل موظف ........................."

        If Fn.GetTblXX("select UsrRealNm AS [اسم الموظف], case when (select count(TkSQL) from Tickets  where CONVERT(VARCHAR, TkRecieveDt, 111)= CONVERT(VARCHAR, GETDATE(), 111) and Tickets.TkEmpNm = UsrId group by format( TkRecieveDt,'yyyy/MM/dd') ) IS NULL then 0 else (select count(TkSQL) from Tickets  where CONVERT(VARCHAR, TkRecieveDt, 111)= CONVERT(VARCHAR, GETDATE(), 111) and Tickets.TkEmpNm = UsrId group by format( TkRecieveDt,'yyyy/MM/dd') ) end AS [العدد] from int_User WHERE (" & UsrStr & ") ORDER BY [اسم الموظف]", CompCountTable, "1026&H") = Nothing Then
            GridUsrTickCount.DataSource = CompCountTable
            'GridUsrTickCount.Columns(2).Visible = False
            GridUsrTickCount.AutoResizeColumns()
            GridUsrTickCount.ClearSelection()
            GridUsrTickCount.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For Cnt_ = 0 To GridUsrTickCount.Rows.Count - 1
                AgentCount += 1
                If IsDBNull(GridUsrTickCount.Rows(Cnt_).Cells(1).Value) = True Then
                    GridUsrTickCount.Rows(Cnt_).Cells(1).Value = 0
                Else
                    TickCount += GridUsrTickCount.Rows(Cnt_).Cells(1).Value
                End If
            Next

            LblTickCount.Text = TickCount
            LblAgentCount.Text = AgentCount
            WelcomeScreen.StatBrPnlAr.Text = ""
        Else
            MsgErr("كود خطأ : " & "1026&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub submt()
        Dim TrnsErr As Boolean = False
        Dim TrnsECnt_Count As Integer = 0
        Dim TrnsCnt As Integer = 0


        'GridTicket.Rows(DisributeTable.Rows.Count - 1).Selected = True
        'GridTicket.Refresh()
        'MsgBox(Convert.ToInt32(DisributeTable.Compute("count(TkSQL) ", "[متابع الشكوى] =''")))
        Dim Tbl As New DataTable
        Tbl.Columns.Add("SQLID")
        Tbl.Columns.Add("UserID")
        For Cnt_ = 0 To GridTicket.Rows.Count - 1
            If GridTicket.Rows(Cnt_).Cells(26).Value.ToString.Length > 0 Then
                Tbl.Rows.Add(GridTicket.Rows(Cnt_).Cells(0).Value, GridTicket.Rows(Cnt_).Cells(25).Value)
            End If
#Region "Old Code"

            '    TrnsCnt += 1
            '    LblMsg.Text = "جاري تحويل " & TrnsCnt & " من " & (From row As DataGridViewRow In GridTicket.Rows
            '                                                      Where Len(row.Cells(26).Value.ToString) > 0 And row.Cells(26).Value IsNot DBNull.Value.ToString
            '                                                      Select row.Cells(26).Value).Count().ToString("N0") & " شكوى"
            '    LblMsg.Refresh()
            '    LblMsg.ForeColor = Color.Green
            '    Try
            '        If sqlCon.State = ConnectionState.Closed Then
            '            sqlCon.Open()
            '        End If
            '        sqlComminsert_1.Connection = sqlCon
            '        sqlComminsert_2.Connection = sqlCon
            '        sqlComminsert_1.CommandType = CommandType.Text
            '        sqlComminsert_2.CommandType = CommandType.Text

            '        sqlComminsert_1.CommandText = "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & GridTicket.Rows(Cnt_).Cells(0).Value.ToString & "','" & "The Complaint has been sent to " & GridTicket.Rows(Cnt_).Cells(26).Value.ToString & "','" & "1" & "','" & "2" & "','" & OsIP() & "','" & Usr.PUsrID & "')"
            '        sqlComminsert_2.CommandText = "update Tickets set TkEmpNm = " & GridTicket.Rows(Cnt_).Cells(25).Value.ToString & ", TkRecieveDt = (Select GetDate()) Where (TkSQL = " & GridTicket.Rows(Cnt_).Cells(0).Value & ")"
            '        '                                                                                                                                 
            '        Tran = sqlCon.BeginTransaction()
            '        sqlComminsert_1.Transaction = Tran
            '        sqlComminsert_2.Transaction = Tran
            '        sqlComminsert_1.ExecuteNonQuery()
            '        sqlComminsert_2.ExecuteNonQuery()
            '        Tran.Commit()
            '        sqlCon.Close()
            '        SqlConnection.ClearPool(sqlCon)
            '    Catch ex As Exception
            '        Tran.Rollback()
            '        AppLog("1027&H", Errmsg, sqlComminsert_1.CommandText & "_" & sqlComminsert_2.CommandText)
            '        TrnsErr = True
            '        TrnsECnt_Count += 1
            '    End Try

#End Region

        Next Cnt_

        Dim msg As String = Nothing
        Dim state As New APblicClss.Defntion
        Dim sqlComminsert_1 As New SqlCommand            'SQL Command
        Dim param(2) As SqlParameter
        sqlComminsert_1.CommandType = CommandType.StoredProcedure
        sqlComminsert_1.CommandText = "SP_TICKET_Distribute"
        sqlComminsert_1.Connection = state.CONSQL
        param(0) = New SqlParameter("@TkupUserIP", SqlDbType.NVarChar, 15)
        param(0).Value = OsIP()
        param(1) = New SqlParameter("@UserDisID", SqlDbType.Int)
        param(1).Value = Usr.PUsrID
        param(2) = New SqlParameter()
        param(2).ParameterName = "@TicketsCollection"
        param(2).Value = Tbl

        For i = 0 To param.Length - 1
            sqlComminsert_1.Parameters.Add(param(i))
        Next

        Try
            If state.CONSQL.State = ConnectionState.Closed Then
                state.CONSQL.Open()
            End If
            sqlComminsert_1.ExecuteNonQuery()
            LblMsg.ForeColor = Color.Green
        Catch ex As Exception
            msg = ex.Message
            AppLog("1011&H", ex.Message, sqlComminsert_1.CommandText)
            MsgErr("كود خطأ : " & "1011&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End Try
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Dim Rslt As DialogResult
        If chgd = True Then
            Rslt = MessageBox.Show("هناك بعض التغييرات" & vbCrLf & "هل تريد حفظ التعديلات؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
            If Rslt = DialogResult.Yes Then
                submt()
            End If
        End If
        Me.Close()
    End Sub
    Private Sub GridTicketDisDis_DoubleClick(sender As Object, e As EventArgs) Handles GridTicket.DoubleClick
        If TabControl1.TabPages.Contains(TabPage2) = False Then TabControl1.TabPages.Insert(1, TabPage2)
        If GridTicket.Rows.Count > 0 Then
            'FncGrdCurrRow(GridTicket, GridTicket.CurrentRow.Index)
            TxtPh1.Text = GridTicket.CurrentRow.Cells(5).Value
            TxtPh2.Text = GridTicket.CurrentRow.Cells(6).Value
            TxtDt.Text = GridTicket.CurrentRow.Cells(1).Value
            TxtNm.Text = GridTicket.CurrentRow.Cells(4).Value
            TxtAdd.Text = GridTicket.CurrentRow.Cells(8).Value
            TxtEmail.Text = GridTicket.CurrentRow.Cells(7).Value
            TxtDetails.Text = GridTicket.CurrentRow.Cells(22).Value
            TxtArea.Text = GridTicket.CurrentRow.Cells(21).Value.ToString
            TxtOff.Text = GridTicket.CurrentRow.Cells(20).Value.ToString
            TxtProd.Text = GridTicket.CurrentRow.Cells(16).Value
            TxtComp.Text = GridTicket.CurrentRow.Cells(17).Value
            TxtSrc.Text = GridTicket.CurrentRow.Cells(3).Value
            TxtTrck.Text = GridTicket.CurrentRow.Cells(10).Value
            TxtOrgin.Text = GridTicket.CurrentRow.Cells(18).Value.ToString
            TxtDist.Text = GridTicket.CurrentRow.Cells(19).Value.ToString
            TxtCard.Text = GridTicket.CurrentRow.Cells(9).Value
            TxtGP.Text = GridTicket.CurrentRow.Cells(11).Value
            TxtNId.Text = GridTicket.CurrentRow.Cells(12).Value
            TxtAmount.Text = GridTicket.CurrentRow.Cells(13).Value
            TxtTransDt.Text = GridTicket.CurrentRow.Cells(14).Value
            If GridTicket.CurrentRow.Cells(15).Value = 1 Then
                GroupBox3.Visible = True
                GroupBox4.Visible = False
            ElseIf GridTicket.CurrentRow.Cells(15).Value = 2 Then
                GroupBox3.Visible = False
                GroupBox4.Visible = True
            Else
                GroupBox3.Visible = False
                GroupBox4.Visible = False
            End If
        End If
        TabPage2.Text = "Ticket No.: " & GridTicket.CurrentRow.Cells(0).Value
        TabControl1.SelectedTab = TabPage2
    End Sub
    Private Sub GridTicketDis_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridTicket.CellClick
        If (GridTicket.CurrentRow.Index) <> -1 Then
            Filtr = ""
            If ClintPhTable.Rows.Count > 0 Then Filtr = "([تليفون العميل] like '%" & GridTicket.CurrentRow.Cells(5).Value.ToString & "%')"
            ClintPhTable.DefaultView.RowFilter = Filtr
            If IsNothing(ClintPhView) = False And ClintPhView.Count > 0 Then
                GridTicket.CurrentRow.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                GridTicket.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue
                If TabControl1.TabPages.Contains(TabPage3) = False Then TabControl1.TabPages.Insert(1, TabPage3)
                If TabControl1.TabPages.Contains(TabPage3) = True Then
                    TabPage3.Text = "شكاوى مرتبطه بـ" & GridTicket.CurrentRow.Cells(4).Value & " مع " & ClintPhView.Item(0).Row.ItemArray(0) & " (" & ClintPhView.Count & ")"
                Else
                    TabPage3.Text = "شكاوى مرتبطه بـ"
                End If
            Else
                TabControl1.TabPages.Remove(TabPage3)
                GridTicket.CurrentRow.DefaultCellStyle.BackColor = Color.White
            End If


            If GridTicket.Columns(e.ColumnIndex).Name = "توزيع/إستعادة" Then
                If GridTicket.CurrentRow.Cells(27).Value = "توزيع" Then
                    If UserTree.SelectedNode IsNot Nothing Then
                        LblMsg.Text = ""
                        'If UserTree.SelectedNode.Level = 0 Then
                        '    LblMsg.Text = "الشكوى موجودة بـ" & Split(UserTree.SelectedNode.Text, " - ")(2) & " بالفعل"
                        'Else
                        LblMsg.Text = ""
                        If DBNull.Value.Equals(GridTicket.CurrentRow.Cells(27).Value.ToString) Then
                            For Cnt_ = 0 To GridUsrTickCount.Rows.Count - 1
                                If GridTicket.CurrentRow.Cells(26).Value = GridUsrTickCount.Rows(Cnt_).Cells(0).Value Then
                                    GridUsrTickCount.Rows(Cnt_).Cells(1).Value -= 1
                                    TickCount -= 1
                                    Exit For
                                End If
                            Next Cnt_
                        End If
                        GridTicket.CurrentRow.Cells(26).Value = Split(UserTree.SelectedNode.Text, " - ")(2)
                        GridTicket.CurrentRow.Cells(25).Value = Split(UserTree.SelectedNode.Text, " - ")(0)
                        GridTicket.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen
                        GridTicket.CurrentRow.Cells(27).Value = "استعادة"
                        GridTicket.CurrentRow.Cells(27).Style.BackColor = Color.Aqua
                        'PublicCode.FncGrdCurrRow(GridTicket, GridTicket.CurrentRow.Index)
                        For Cnt_ = 0 To GridUsrTickCount.Rows.Count - 1
                            If GridTicket.CurrentRow.Cells(26).Value = GridUsrTickCount.Rows(Cnt_).Cells(0).Value Then
                                'CompCountTable.Rows(Cnt_).Item(1) += 1
                                TickCount += 1
                                chgd = True
                                Exit For
                            End If
                        Next Cnt_
                        'End If
                    Else
                        LblMsg.Text = "برجاء اختيار اسم الموظف أولاً"
                        Beep()
                    End If
                Else
                    GridTicket.CurrentRow.Cells(25).Value = Usr.PUsrID
                    GridTicket.CurrentRow.DefaultCellStyle.BackColor = Color.White
                    GridTicket.CurrentRow.Cells(27).Value = "توزيع"
                    GridTicket.CurrentRow.Cells(27).Style.BackColor = Color.AliceBlue
                    For Cnt_ = 0 To GridUsrTickCount.Rows.Count - 1
                        If GridTicket.CurrentRow.Cells(26).Value = GridUsrTickCount.Rows(Cnt_).Cells(0).Value Then
                            'GridUsrTickCount.Rows(Cnt_).Cells(1).Value -= 1
                            TickCount -= 1
                            Exit For
                        End If
                    Next Cnt_
                    GridTicket.CurrentRow.Cells(26).Value = ""
                End If
            End If

            LblTickCount.Text = TickCount
            GridTicket.Columns(27).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Name = "TabPage3" Then
            DataGridView1.Columns(8).Visible = False
            For vvv = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(vvv).Cells(8).Value = True Then
                    DataGridView1.Rows(vvv).DefaultCellStyle.BackColor = Color.LimeGreen
                Else
                    DataGridView1.Rows(vvv).DefaultCellStyle.BackColor = Color.White
                End If
            Next
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub GridTicket_Sorted(sender As Object, e As EventArgs) Handles GridTicket.Sorted
        For Cnt_ = 0 To GridTicket.Rows.Count - 1
            If GridTicket.Rows(Cnt_).Cells(27).Value = "" Then
                GridTicket.Rows(Cnt_).Cells(27).Value = "توزيع"
                GridTicket.CurrentRow.DefaultCellStyle.BackColor = Color.White
            Else
                GridTicket.Rows(Cnt_).Cells(27).Value = "إستعادة"
                GridTicket.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen
            End If
            Filtr = ""
            Filtr = "([تليفون العميل] like '%" & GridTicket.Rows(Cnt_).Cells(5).Value.ToString & "%')"
            ClintPhTable.DefaultView.RowFilter = Filtr
            If ClintPhView.Count > 0 Then
                GridTicket.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                GridTicket.Rows(Cnt_).DefaultCellStyle.ForeColor = Color.Blue
            End If
        Next
    End Sub
    Private Sub GridTicket_SelectionChanged(sender As Object, e As EventArgs)
        'On Error Resume Next
        If GridTicket.Rows.Count > 0 Then
            'GridTicket.Rows(0).Cells(1).Selected = True
            If GridTicket.SelectedRows.Count > 0 Then
                StatBrPnlEn.Text = GridTicket.CurrentRow.Index + 1 & " Of " & GridTicket.Rows.Count.ToString("N0")
            End If
        End If

    End Sub
    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        If Len(GridTicket.CurrentCell.Value.ToString) > 0 Then Clipboard.SetText(GridTicket.CurrentCell.Value)
    End Sub
End Class