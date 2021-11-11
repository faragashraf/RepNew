Imports System.Data.SqlClient
Imports System.Threading
Imports ClosedXML.Excel
Imports Microsoft.Exchange.WebServices.Data
Public Class EventMail
    Dim EvTsk As New Thread(AddressOf EvMail)
    Public Mail_ As New Stru.StruMail

    Private Sub VOCAPlusService_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub TimerSec_Tick_1(sender As Object, e As EventArgs) Handles TimerSecnods.Tick
        If CheckBox1.Checked = True Then
            EvTsk = New Thread(AddressOf EvMail)
            EvTsk.IsBackground = True
            EvTsk.Start()
        ElseIf CheckBox2.Checked = False Then
            EvTsk = New Thread(AddressOf MaxEvnt)
            EvTsk.IsBackground = True
            EvTsk.Start()
        End If
    End Sub

    'Send Smart Agrisive Mail
    Private Sub MaxEvnt()
        Dim Def As New APblicClss.Defntion
        Invoke(Sub() Label1.Text = Now)
        Dim Tbl As New DataTable
        Dim SQLTblAdpterXX As New SqlDataAdapter
        Dim sqlCconXX As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046")
        Def.sqlComnd.Connection = sqlCconXX
        SQLTblAdpterXX.SelectCommand = Def.sqlComnd
        Def.sqlComnd.CommandType = CommandType.Text

        Def.sqlComnd.CommandText = "select max( TkEvent.TkupSQL) from TkEvent"

        Try
            If sqlCconXX.State = ConnectionState.Closed Or sqlCconXX.State <> ConnectionState.Connecting Then
                sqlCconXX.Open()
            End If
            SQLTblAdpterXX.Fill(Tbl)
            If Tbl.Rows.Count > 0 Then
                Invoke(Sub() TextBox1.Text = Tbl.Rows(0).Item(0))
            End If
        Catch ex As Exception
            Invoke(Sub() TxtErr.Text += Now & " Max Event ___" & Tbl.TableName & ex.Message & vbCrLf)
            Invoke(Sub() TxtErr.Refresh())
        End Try
        sqlCconXX.Close()
        SqlConnection.ClearPool(sqlCconXX)
    End Sub
    Private Sub EvMail()
        Dim Def As New APblicClss.Defntion
        Invoke(Sub() Label1.Text = Now)
        Dim Tbl As New DataTable
        Dim SQLTblAdpterXX As New SqlDataAdapter
        Dim sqlCconXX As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046")
        Def.sqlComnd.Connection = sqlCconXX
        SQLTblAdpterXX.SelectCommand = Def.sqlComnd
        Def.sqlComnd.CommandType = CommandType.Text
        Def.sqlComnd.CommandText = "SELECT TkupSQL, TkupTkSql, TkupSTime, TkupTxt, TkupReDt, TkupUserIP, Int_user.UsrRealNm, UCatNm
                                FROM TkEvent INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN Int_user ON TkupUser = Int_user.UsrId INNER JOIN
                                IntUserCat ON Int_user.UsrCat = UCatId WHERE(TkupSQL > " & TextBox1.Text & ")"
        Try
            If sqlCconXX.State = ConnectionState.Closed Or sqlCconXX.State <> ConnectionState.Connecting Then
                sqlCconXX.Open()
            End If
            SQLTblAdpterXX.Fill(Tbl)
            If Tbl.Rows.Count > 0 Then
                For YY = 0 To Tbl.Rows.Count - 1
                    Dim Lction As String
                    'Try
                    If Mid(Tbl.Rows(YY).Item("TkupUserIP").ToString, 1, 9) = "10.10.200" Then
                        Lction = "المعادي"
                    ElseIf Mid(Tbl.Rows(YY).Item("TkupUserIP").ToString, 1, 5) = "10.11" Then
                        Lction = "السبيل"
                    ElseIf Tbl.Rows(YY).Item("TkupUserIP").ToString = "10.10.26.4" Then
                        Lction = "Server"
                    Else
                        Lction = "غير معروف"
                    End If
                    Dim exchange As ExchangeService
                    exchange = New ExchangeService(ExchangeVersion.Exchange2010)
                    exchange.Credentials = New WebCredentials(My.Settings.MlUsr, My.Settings.MlPss)
                    exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
                    Dim message As New EmailMessage(exchange)

                    For UU = 0 To Split(My.Settings.TO_, ";").Count - 1
                        If Trim(Split(My.Settings.TO_, ";")(UU)).Length > 0 Then
                            message.ToRecipients.Add(Trim(Split(My.Settings.TO_, ";")(UU)))
                        End If
                    Next

                    For PP = 0 To Split(My.Settings.Cc_, ";").Count - 1
                        If Trim(Split(My.Settings.Cc_, ";")(PP)).Length > 0 Then
                            message.CcRecipients.Add(Trim(Split(My.Settings.Cc_, ";")(PP)))
                        End If
                    Next


                    message.Subject = "تم عمل تحديث بواسطة " & Tbl.Rows(YY).Item("UsrRealNm") & " للشكوى رقم " & Tbl.Rows(YY).Item("TkupTkSql") & " عن طريق الجهاز " & Tbl.Rows(YY).Item("TkupUserIP") & " من مبني " & Lction & " الساعة : " & Tbl.Rows(YY).Item("TkupSTime")
                    message.Body = Tbl.Rows(YY).Item("TkupTxt").ToString
                    'message.Attachments.AddFileAttachment(FileExported)
                    'message.Attachments(0).ContentId = Mail_.Sub_ & "_" & Format(Now, "yyyy-MM-dd")
                    message.Importance = 1
                    If YY = Tbl.Rows.Count - 1 Then
                        Invoke(Sub() TextBox1.Text = Tbl.Rows(YY).Item("TkupSQL") + 1)
                    End If
                    message.SendAndSaveCopy()
                    'Catch exs As Exception
                    '    Invoke(Sub() TxtErr.Text += Now & exs.Message & vbCrLf)
                    '    Invoke(Sub() TxtErr.Refresh())
                    'End Try
                Next
            End If
        Catch ex As Exception
            Invoke(Sub() TxtErr.Text += Now & " Mail ___" & Tbl.TableName & ex.Message & vbCrLf)
            Invoke(Sub() TxtErr.Refresh())
        End Try
        If CheckBox2.Checked = True Then ThreadPool.QueueUserWorkItem(AddressOf EvMail)
        sqlCconXX.Close()
        SqlConnection.ClearPool(sqlCconXX)
    End Sub
    Private Sub EventMail_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        TxtErr.Size = New Point(TxtErr.Width, Screen.PrimaryScreen.Bounds.Height - 100)
    End Sub
    Private Sub BtnAbort_Click(sender As Object, e As EventArgs) Handles BtnAbort.Click
        Settings_.ShowDialog()
    End Sub

End Class