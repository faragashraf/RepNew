Public Class ReopnComp
    Private ReopnTable As DataTable = New DataTable
    'Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    'Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
    '    Get
    '        Dim myCp As CreateParams = MyBase.CreateParams
    '        myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
    '        Return myCp
    '    End Get
    'End Property
    Private Sub ReopnComp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyTeam(Usr.PUsrCat, Usr.PUsrID, "TkEmpNm", True)
        BtnGet.Tag = "تحميل"
        BtnGet.Enabled = True
        BtnGet.BackgroundImage = My.Resources.DbGet
        LblMsg.Text = ""
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub TxtCompId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCompId.KeyPress
        IntUtly.ValdtInt(e)
    End Sub
    Private Sub TxtCompId_TextChanged(sender As Object, e As EventArgs) Handles TxtCompId.TextChanged
        BtnGet.Tag = "تحميل"
        BtnGet.Enabled = True
        BtnGet.BackgroundImage = My.Resources.DbGet
        LblMsg.Text = ""
        TcktImg.BackgroundImage = My.Resources.Empty
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Name <> "TxtCompId" Then
                    ctrl.Text = ""
                End If
            End If
        Next
    End Sub
    Private Sub BtnGet_Click(sender As Object, e As EventArgs) Handles BtnGet.Click
        If TxtCompId.TextLength > 0 Then
            BtnGet.Enabled = False
            If BtnGet.Tag = "تحميل" Then
                ReopnTable.Rows.Clear()
                LblMsg.Text = "جاري تحميل البيانات ...."
                LblMsg.ForeColor = Color.Green
                '                   0          1          2         3      4      5      6       7        8         9        10             
                If GetTbl("SELECT TkSQL, TkClsStatus, TkDtStart, TkKind, TkID, TkClNm, PrdNm, CompNm, UsrRealNm, TkClPh, TkDetails FROM TicketsAll WHERE (TkID = " & TxtCompId.Text & ") AND (TkClsStatus = 1) ", ReopnTable, "1030&H") = Nothing Then
                    If ReopnTable.Rows.Count > 0 Then
                        TxtPh1.Text = ReopnTable(0).Item(9).ToString
                        TxtDt.Text = ReopnTable(0).Item(2).ToString
                        TxtNm.Text = ReopnTable(0).Item(5).ToString
                        TxtDetails.Text = ReopnTable(0).Item(10).ToString
                        TxtProd.Text = ReopnTable(0).Item(6).ToString
                        TxtComp.Text = ReopnTable(0).Item(7).ToString
                        TxtFollNm.Text = ReopnTable(0).Item(8).ToString
                        If ReopnTable(0).Item(1) = True Then
                            TcktImg.BackgroundImage = My.Resources.Tckoff
                            BtnGet.Tag = "فتح"
                            BtnGet.BackgroundImage = My.Resources.CpOpen
                            LblMsg.Text = ""
                        Else
                            TcktImg.BackgroundImage = My.Resources.Tckon
                            BtnGet.Tag = "تحميل"
                            LblMsg.Text = "الشكوى رقم " & TxtCompId.Text & " مفتوحة بالفعل"
                            LblMsg.ForeColor = Color.Red
                            Beep()
                        End If
                    Else

                        LblMsg.Text = "لا توجد شكوى مسجلة بهذا الرقم - الشكوى قد تكون مفتوحة - من فضلك تأكد من الرقم الذي قمت بإدخاله"
                        LblMsg.ForeColor = Color.Red
                        Beep()
                    End If
                Else
                    MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                End If
            Else
                Dim Rslt As DialogResult
                Rslt = MessageBox.Show("سيتم إعادة فتح الشكوى رقم " & ReopnTable(0).Item(4) & vbCrLf & "هل تريد الاستمرار؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                If Rslt = DialogResult.Yes Then
                    BtnGet.Enabled = False
                    LblMsg.Text = "جاري إعادة فتح الشكوى ...."
                    LblMsg.ForeColor = Color.Green
                    If insupdate(ReopnTable(0).Item(0), "The Complaint has been Reopened", 1, 999, OsIP(), Usr.PUsrID) = Nothing Then

                        BtnGet.Tag = "تحميل"
                        BtnGet.Enabled = True
                        BtnGet.BackgroundImage = My.Resources.DbGet
                        LblMsg.Text = "تم إعادة فتح الشكوى رقم " & ReopnTable(0).Item(4) & " بنجاح"
                        LblMsg.ForeColor = Color.Green
                        TcktImg.BackgroundImage = My.Resources.Tckon
                    End If

                    '    If InsTrans("update Tickets set TkClsStatus = 0, TkDtClose = '', TkReOp = 1 where (TkSQL = " & ReopnTable(0).Item(0) & ");",
                    '"insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" &
                    'ReopnTable(0).Item(0) & "','" & "The Complaint has been Reopened" & "','" & "1" & "','" & "999" & "','" & OsIP() & "','" & Usr.PUsrID & "')",
                    '"1031&H") = Nothing Then



                    '    Else
                    '        MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                    '    End If
                Else
                    BtnGet.Tag = "تحميل"
                    BtnGet.Enabled = True
                    BtnGet.BackgroundImage = My.Resources.DbGet
                    LblMsg.Text = ""
                    TcktImg.BackgroundImage = My.Resources.Empty
                    For Each ctrl As Control In Me.Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.Text = ""
                        End If
                    Next
                End If
            End If
        Else
            LblMsg.Text = "يرجى ادخال رقم الشكوى أولا"
            LblMsg.ForeColor = Color.Red
            Beep()
        End If
        BtnGet.Enabled = True
    End Sub
    Private Function insupdate(id As Integer, txt As String, read As Boolean, EvId As Integer, IP As String, Updateuser As Integer) As String
        Dim msg As String = Nothing
        Dim state As New APblicClss.Defntion
        Dim sqlComminsert_1 As New SqlCommand            'SQL Command
        Dim param(5) As SqlParameter
        sqlComminsert_1.CommandType = CommandType.StoredProcedure
        sqlComminsert_1.CommandText = "SP_TICKET_EVENT_INSERT"
        sqlComminsert_1.Connection = state.CONSQL
        param(0) = New SqlParameter("@TkupTkSql", SqlDbType.Int)
        param(0).Value = id
        param(1) = New SqlParameter("@TkupTxt", SqlDbType.NVarChar)
        param(1).Value = txt
        param(2) = New SqlParameter("@TkupUnread", SqlDbType.Bit)
        param(2).Value = read
        param(3) = New SqlParameter("@TkupEvtId", SqlDbType.Int)
        param(3).Value = EvId
        param(4) = New SqlParameter("@TkupUserIP", SqlDbType.NVarChar, 15)
        param(4).Value = IP
        param(5) = New SqlParameter("@TkupUser", SqlDbType.Int)
        param(5).Value = Updateuser

        For i = 0 To param.Length - 1
            sqlComminsert_1.Parameters.Add(param(i))
        Next

        Try
            If state.CONSQL.State = ConnectionState.Closed Then
                state.CONSQL.Open()
            End If
            sqlComminsert_1.ExecuteNonQuery()
        Catch ex As Exception
            msg = ex.Message
            AppLog("1011&H", ex.Message, sqlComminsert_1.CommandText)
            MsgErr("كود خطأ : " & "1011&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End Try

        Return msg
    End Function
    Private Sub BtnGet_MouseEnter(sender As Object, e As EventArgs) Handles BtnGet.MouseEnter
        ToolTip1.Show(BtnGet.Tag, BtnGet, 0, 20, 500)
    End Sub
End Class