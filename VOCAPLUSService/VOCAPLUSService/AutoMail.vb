Public Class AutoMail
    Dim AutoMailTbl As New DataTable

    Private Sub AutoMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Span_ = New TimeSpan
        Span_ = TimeSpan.Parse("00:01:00")
        CheckBox2.Checked = True
        CheckBox3.Checked = True
        FillTbl()
        ComboBox1.Items.Add("H")
        ComboBox1.Items.Add("D")
        ComboBox1.Items.Add("W")
        ComboBox1.Items.Add("M")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FillTbl()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Fn As New APblicClss.Func
        If AutoMailTbl.Rows.Count > 0 Then
            For RR = 0 To AutoMailTbl.Rows.Count - 1
                Dim _Now As Date = Format(Fn.ServrTime(), "hh:mm tt")
                Dim HourMin As DateTime = AutoMailTbl.Rows(RR).Item("MailTime")
                Dim HourMin_ As Integer = Minute(HourMin)
                Dim HourHour_ As Integer = Hour(HourMin)
                If Format(_Now, "mm") = HourMin_ And Format(_Now, "HH") = HourHour_ Then
                    MsgBox("Yes")
                End If
            Next
        End If
        Span_ = TimeSpan.Parse("00:01:00")
    End Sub
    Private Sub FillTbl()
        Dim Fn As New APblicClss.Func
        AutoMailTbl = New DataTable
        'where AutoMail.MailRule = 'H'
        If Fn.GetTbl("select [MailSQL],[MailSTR],[MailTo],[MailCc],[MailSub],[MailBody],[MailTime],[MailRun],[MailRule] ,[Week] from AutoMail ", AutoMailTbl) = Nothing Then
            DataGridView1.DataSource = AutoMailTbl
        End If
    End Sub
    Private Sub TimerSecnods_Tick(sender As Object, e As EventArgs) Handles TimerSecnods.Tick
        LblTimer.Text = "Next Job Will Be After : " & (Span_ - TimeSpan.Parse("00:00:01")).ToString
        LblTimer.Refresh()
        Span_ -= TimeSpan.Parse("00:00:01")
        Label1.Text = "Now Is : " & Now
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        STR_.Text = DataGridView1.CurrentRow.Cells(1).Value
        TO_.Text = DataGridView1.CurrentRow.Cells(2).Value
        CC_.Text = DataGridView1.CurrentRow.Cells(3).Value
        SUB_.Text = DataGridView1.CurrentRow.Cells(4).Value
        BODY_.Text = DataGridView1.CurrentRow.Cells(5).Value
        DateTimePicker1.Value = DataGridView1.CurrentRow.Cells(6).Value
        CheckBox1.Checked = DataGridView1.CurrentRow.Cells(7).Value
        ComboBox1.Text = DataGridView1.CurrentRow.Cells(8).Value
        If DataGridView1.CurrentRow.Cells(8).Value = "H" Then
            DateTimePicker1.CustomFormat = "mm"
        Else
            DateTimePicker1.CustomFormat = "HH:mm tt"
        End If
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
        CheckBox10.Checked = False
        CheckBox11.Checked = False
        For NN = 0 To Split(DataGridView1.CurrentRow.Cells(9).Value, ",").Count - 1
            If Split(DataGridView1.CurrentRow.Cells(9).Value, ",")(NN) = 1 Then
                CheckBox5.Checked = True
            ElseIf Split(DataGridView1.CurrentRow.Cells(9).Value, ",")(NN) = 2 Then
                CheckBox6.Checked = True
            ElseIf Split(DataGridView1.CurrentRow.Cells(9).Value, ",")(NN) = 3 Then
                CheckBox7.Checked = True
            ElseIf Split(DataGridView1.CurrentRow.Cells(9).Value, ",")(NN) = 4 Then
                CheckBox8.Checked = True
            ElseIf Split(DataGridView1.CurrentRow.Cells(9).Value, ",")(NN) = 5 Then
                CheckBox9.Checked = True
            ElseIf Split(DataGridView1.CurrentRow.Cells(9).Value, ",")(NN) = 6 Then
                CheckBox10.Checked = True
            ElseIf Split(DataGridView1.CurrentRow.Cells(9).Value, ",")(NN) = 7 Then
                CheckBox11.Checked = True
            End If
        Next
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = False Then TO_.Multiline = False Else TO_.Multiline = True
        Me.Refresh()
    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = False Then CC_.Multiline = False Else CC_.Multiline = True
    End Sub
End Class