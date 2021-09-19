Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(Replace(MaskedTextBox1.Text, " ", "") & vbCrLf & Replace(MaskedTextBox1.Text, " ", "").Length)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox(IsNumeric(TextBox1.Text))
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        'NOTE: set form's KeyPreview property to True
        Select Case e.KeyCode
            Case Keys.F1
                MsgBox("F1")
                e.SuppressKeyPress = True
            Case Keys.F2
            Case Keys.F3
                'do something
                e.SuppressKeyPress = True
            Case Keys.F4
                'do something else
                e.SuppressKeyPress = True
            Case Keys.F5
                'do something different
                e.SuppressKeyPress = True
            Case Keys.F6
            Case Keys.F7
            Case Keys.F8
            Case Keys.F9
            Case Keys.F10
            Case Keys.F11
            Case Keys.F12
        End Select
    End Sub
End Class
