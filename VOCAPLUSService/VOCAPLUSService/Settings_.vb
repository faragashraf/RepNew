Public Class Settings_
    Private Sub Settings__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.MlUsr
        TextBox2.Text = My.Settings.MlPss
        TimeStrt.Value = My.Settings.TimeStart
        TimeEnd.Value = My.Settings.TimeEnd
        ACBStrt.Value = My.Settings.ACBStart
        ACBEnd.Value = My.Settings.ACBEnd
        Min_.Value = My.Settings.Min
        _To.Text = My.Settings.TO_
        _Cc.Text = My.Settings.Cc_
    End Sub

    Private Sub BtnSbmt_Click(sender As Object, e As EventArgs) Handles BtnSbmt.Click
        My.Settings.MlUsr = TextBox1.Text
        My.Settings.MlPss = TextBox2.Text
        My.Settings.TimeStart = TimeStrt.Value
        My.Settings.TimeEnd = TimeEnd.Value
        My.Settings.ACBStart = ACBStrt.Value
        My.Settings.ACBEnd = ACBEnd.Value
        My.Settings.Min = Min_.Value
        My.Settings.TO_ = _To.Text
        My.Settings.Cc_ = _Cc.Text
        My.Settings.Save()
    End Sub
End Class