Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Drawing
Public Class vocamonitor
    Inherits System.Web.UI.Page
    Dim Errmsg As String
    Dim sqlComm As New SqlCommand                    'SQL Command
    Dim sqlCon As New SqlConnection '(strConn) ' I Have assigned conn STR here and delete this row from all project
    Dim sqlCConCCSYS As New SqlConnection ' I Have assigned conn STR here and delete this row from all project
    Dim SQLTblAdptr As New SqlDataAdapter            'SQL Table Adapter
    Dim strConn As String = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
    Dim IP_ As String
    Dim EvTble As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label5.Text = "Loading ..."
        IP_ = Request.UserHostAddress
        If Left(IP_, 9) = "10.10.200" Then
        ElseIf Left(IP_, 8) = "10.11.51" _
            Or Left(IP_, 8) = "10.11.56" _
            Or Left(IP_, 8) = "10.11.58" Then
        ElseIf Left(IP_, 9) = "10.10.220" Then
        Else
            'Server.Transfer("~/NotAllowed.aspx")
        End If
    End Sub
    Private Function GetTbl(SSqlStr As String, SqlTbl As DataTable) As String
        Errmsg = Nothing
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        sqlCon.ConnectionString = strConn
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            SQLTblAdptr.Fill(SqlTbl)
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception
            Errmsg = "X"
        End Try
        Return Errmsg
    End Function
    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Dim StW As New Stopwatch
        'StW.Start()
        Dim TimeTble As New DataTable
        '   If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
        '       Label5.Text = "Server Time : " & Format(TimeTble.Rows(0).Item(0), "yyyy/MM/dd hh:mm:ss tt")
        '   End If

        '   EvTble = New DataTable
        '   If GetTbl("SELECT top (100) ROW_NUMBER() Over (Order by TkupSQL desc) As [Ser],  TkupSQL as [ID], TkupTkSql as [رقم الشكوى],  format( TkupSTime,'HH:mm:ss' )  as [وقت التحديث], TkupTxt as [نص التحديث], 
        '               case when SUBSTRING(TkupUserIP,1,8) ='10.10.26' then 'Server' else case when SUBSTRING(TkupUserIP,1,5) ='10.11' then 'Sabeel' else case when SUBSTRING(TkupUserIP,1,9) ='10.10.200' then 'Maadi' end end end as [Location], Int_user.UsrRealNm as [محرر التحديث], UCatNm as [Team Leader], 
        'case when CDEvent.EvSusp = 1 then 'Sys' else
        'case when (select TkEmpNm from Tickets where TkupTkSql=TkSQL) = TkEvent.TkupUser then 'Follower' else
        'case when CDEvent.EvSusp = 0 then 'User' 				
        'end end end
        '                           FROM TkEvent INNER JOIN CDEvent ON TkupEvtId = EvId 
        '			INNER JOIN Int_user ON TkupUser = Int_user.UsrId 
        '			INNER JOIN IntUserCat ON Int_user.UsrCat = UCatId 
        '			WHERE  (CONVERT(VARCHAR, TkupSTime, 111) = CONVERT(VARCHAR, GETDATE(), 111)) order by TkupSQL desc", EvTble) = Nothing Then
        '       GridView1.DataSource = EvTble

        '       GridView1.DataBind()
        '   End If
        'StW.Stop()
        'Dim TimSpn As TimeSpan = (StW.Elapsed)
        'Label1.Text = "Retriving Duration: " & String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds)




        Tansaction()

        'Dim sqlComminsert_1 As New SqlCommand            'SQL Command
        'Dim Tran As SqlTransaction = Nothing             'SQL Transaction
        'Dim TimeReder As SqlDataReader                     'SQL Reader
        'sqlCon.ConnectionString = strConn
        'Try
        '    If sqlCon.State = ConnectionState.Closed Then
        '        sqlCon.Open()
        '    End If

        '    sqlComminsert_1.Connection = sqlCon
        '    sqlComminsert_1.CommandType = CommandType.Text
        '    sqlComminsert_1.CommandText = "Select GetDate() as Now_"
        '    Tran = sqlCon.BeginTransaction()
        '    sqlComminsert_1.Transaction = Tran
        '    TimeReder = sqlComminsert_1.ExecuteReader
        '    TimeTble.Load(TimeReder)
        '    Tran.Commit()
        '    Label5.Text = "Server Time : " & Format(TimeTble.Rows(0).Item(0), "yyyy/MM/dd hh:mm:ss tt")
        'Catch ex As Exception
        '    Label5.Text = ex.Message
        '    Tran.Rollback()
        'End Try
    End Sub


    Private Sub Tansaction()
        Dim StW As New Stopwatch

        If Label3.Text.Length > 1600 Then
            Label3.Text = ""
        End If


        Label2.Text = "-------------------------------------------"
        StW.Start()
        Dim TimeTble As New DataTable
        Dim TotTble As New DataTable
        Dim CompTble As New DataTable
        EvTble = New DataTable
        Dim sqlComminsert_1 As New SqlCommand            'SQL Command
        Dim sqlComminsert_2 As New SqlCommand            'SQL Command
        Dim sqlComminsert_3 As New SqlCommand            'SQL Command
        Dim sqlComminsert_4 As New SqlCommand            'SQL Command
        Dim TimeReder As SqlDataReader                     'SQL Reader
        Dim EvnReder As SqlDataReader                     'SQL Reader
        Dim TotEvReder As SqlDataReader                     'SQL Reader
        Dim CompReder As SqlDataReader                     'SQL Reader
        Dim Tran As SqlTransaction = Nothing             'SQL Transaction
        Dim StatStr As String = Nothing
        sqlCon.ConnectionString = strConn
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComminsert_1.Connection = sqlCon
            sqlComminsert_2.Connection = sqlCon
            'sqlComminsert_3.Connection = sqlCon
            'sqlComminsert_4.Connection = sqlCon
            sqlComminsert_1.CommandType = CommandType.Text
            sqlComminsert_2.CommandType = CommandType.Text
            'sqlComminsert_3.CommandType = CommandType.Text
            'sqlComminsert_4.CommandType = CommandType.Text
            sqlComminsert_1.CommandText = "Select GetDate() as Now_"
            sqlComminsert_2.CommandText = "SELECT top (100) ROW_NUMBER() Over (Order by TkupSQL desc) As [Ser],  TkupSQL as [ID], TkupTkSql as [رقم الشكوى],  format( TkupSTime,'HH:mm:ss' )  as [وقت التحديث], TkupTxt as [نص التحديث], 
                    case when SUBSTRING(TkupUserIP,1,8) ='10.10.26' then 'Server' else case when SUBSTRING(TkupUserIP,1,5) ='10.11' then 'Sabeel' else case when SUBSTRING(TkupUserIP,1,9) ='10.10.200' then 'Maadi' end end end as [Location], Int_user.UsrRealNm as [محرر التحديث], UCatNm as [Team Leader], 
					case when CDEvent.EvSusp = 1 then 'Sys' else
					case when (select TkEmpNm from Tickets where TkupTkSql=TkSQL) = TkEvent.TkupUser then 'Follower' else
					case when CDEvent.EvSusp = 0 then 'User' 				
					end end end
                                FROM TkEvent INNER JOIN CDEvent ON TkupEvtId = EvId 
								INNER JOIN Int_user ON TkupUser = Int_user.UsrId 
								INNER JOIN IntUserCat ON Int_user.UsrCat = UCatId 
								WHERE  (CONVERT(VARCHAR, TkupSTime, 111) = CONVERT(VARCHAR, GETDATE(), 111)) order by TkupSQL desc"
            'sqlComminsert_3.CommandText = "select COUNT(tkupsql) as count_ from TkEvent where   (CONVERT(VARCHAR, TkupSTime, 111) = CONVERT(VARCHAR, GETDATE(), 111))"
            'sqlComminsert_4.CommandText = "select COUNT(Tickets.TkSQL) from Tickets where   (CONVERT(VARCHAR, TkDtStart, 111) = CONVERT(VARCHAR, GETDATE(), 111)) "
            Tran = sqlCon.BeginTransaction()
            sqlComminsert_1.Transaction = Tran
            sqlComminsert_2.Transaction = Tran
            'sqlComminsert_3.Transaction = Tran
            'sqlComminsert_4.Transaction = Tran
            TimeReder = sqlComminsert_1.ExecuteReader
            TimeTble.Load(TimeReder)
            EvnReder = sqlComminsert_2.ExecuteReader
            EvTble.Load(EvnReder)
            'TotEvReder = sqlComminsert_3.ExecuteReader
            'TotTble.Load(TotEvReder)
            'CompReder = sqlComminsert_4.ExecuteReader
            'CompTble.Load(CompReder)
            Tran.Commit()
            StW.Stop()
            'Label3.Text = "Total Updates: " & TotTble.Rows(0).Item(0).ToString
            'Label4.Text = "Today Complaints: " & CompTble.Rows(0).Item(0).ToString
            Label5.Text = "Server Time : " & Format(TimeTble.Rows(0).Item(0), "yyyy/MM/dd hh:mm:ss tt")
            Dim TimSpn As TimeSpan = (StW.Elapsed)
            Label1.Text = "Retriving Duration: " & String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds)
            GridView1.DataSource = EvTble
            GridView1.DataBind()
            Label3.Text = String.Format("{0:00}:{1:00}.{2:00}", TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds) & vbCrLf & Label3.Text
        Catch ex As Exception
            EvTble = New DataTable
            Label5.Text = "Loading ..."
            Label1.Text = "Loading ..."
            Label3.Text = Format(Now, "hh:mm:ss tt") & " : " & ex.Message & vbCrLf & Label3.Text
            Tran.Rollback()
        End Try
        'sqlCon.Close()
        'SqlConnection.ClearPool(sqlCon)
    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        e.Row.Cells(8).Visible = False
        e.Row.Cells(3).Wrap = False
        e.Row.Cells(4).Wrap = True
        e.Row.Cells(6).Wrap = False
        e.Row.Cells(7).Wrap = False
        If e.Row.RowType = DataControlRowType.DataRow Then

            For Each cell As TableCell In e.Row.Cells
                Dim quantity As String = (e.Row.Cells(8).Text)
                If quantity = "Sys" Then
                    cell.BackColor = Color.FromArgb(192, 192, 255)
                ElseIf quantity = "User" Then
                    cell.BackColor = Color.FromArgb(239, 255, 156)
                ElseIf quantity = "Follower" Then
                    cell.BackColor = Color.FromArgb(128, 255, 128)
                End If
            Next
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.DataSource = EvTble
        GridView1.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim TimeTble As New DataTable
        EvTble = New DataTable
        Dim sqlCommUpddate_ As New SqlCommand            'SQL Command
        Dim sqlComminsert_1 As New SqlCommand            'SQL Command
        Dim sqlComminsert_2 As New SqlCommand            'SQL Command
        Dim sqlComminsert_3 As New SqlCommand            'SQL Command
        Dim sqlComminsert_4 As New SqlCommand            'SQL Command
        Dim TimeReder As SqlDataReader                     'SQL Reader
        Dim EvnReder As SqlDataReader                     'SQL Reader
        Dim Tran As SqlTransaction = Nothing             'SQL Transaction
        Dim StatStr As String = Nothing
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComminsert_1.Connection = sqlCon
            sqlComminsert_2.Connection = sqlCon
            sqlComminsert_1.CommandType = CommandType.Text
            sqlComminsert_2.CommandType = CommandType.Text
            sqlComminsert_1.CommandText = "Select GetDate() as Now_"
            sqlComminsert_2.CommandText = "SELECT top (100) ROW_NUMBER() Over (Order by TkupSQL desc) As [Ser],  TkupSQL as [ID], TkupTkSql as [رقم الشكوى],  format( TkupSTime,'HH:mm:ss' )  as [وقت التحديث], TkupTxt as [نص التحديث], 
                    case when SUBSTRING(TkupUserIP,1,8) ='10.10.26' then 'Server' else case when SUBSTRING(TkupUserIP,1,5) ='10.11' then 'Sabeel' else case when SUBSTRING(TkupUserIP,1,9) ='10.10.200' then 'Maadi' end end end as [Location], Int_user.UsrRealNm as [محرر التحديث], UCatNm as [Team Leader], 
					case when CDEvent.EvSusp = 1 then 'Sys' else
					case when (select TkEmpNm from Tickets where TkupTkSql=TkSQL) = TkEvent.TkupUser then 'Follower' else
					case when CDEvent.EvSusp = 0 then 'User' 				
					end end end
                                FROM TkEvent INNER JOIN CDEvent ON TkupEvtId = EvId 
								INNER JOIN Int_user ON TkupUser = Int_user.UsrId 
								INNER JOIN IntUserCat ON Int_user.UsrCat = UCatId 
								WHERE  (CONVERT(VARCHAR, TkupSTime, 111) = CONVERT(VARCHAR, GETDATE(), 111)) order by TkupSQL desc"

            Tran = sqlCon.BeginTransaction()
            sqlComminsert_1.Transaction = Tran
            sqlComminsert_2.Transaction = Tran
            TimeReder = sqlComminsert_1.ExecuteReader
            TimeTble.Load(TimeReder)
            EvnReder = sqlComminsert_2.ExecuteReader
            EvTble.Load(EvnReder)
            Tran.Commit()
            GridView1.DataSource = EvTble
            GridView1.DataBind()
        Catch ex As Exception
            Tran.Rollback()
            Label5.Text = ex.Message
        End Try
        sqlCon.Close()
        SqlConnection.ClearPool(sqlCon)
    End Sub
End Class