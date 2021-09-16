Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Threading
Imports ClosedXML.Excel
Imports Microsoft.Exchange.WebServices.Data
Imports VOCAPlusPlus.Strc

Module Public_

    Public Menu_ As New MenuStrip
    Public CntxMenu As New ContextMenuStrip
    Public MacStr As String
    Public FltrStr As String = ""
    Public screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Public screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Public ServerCD As String = "Eg Server"
    Public ServerNm As String = "VOCA Server"
    Public strConn As String = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
    Public Bol As Boolean

    Public HardTable As DataTable = New DataTable
    Public UserTable As DataTable = New DataTable
    Public tempTable As DataTable = New DataTable
    Public AreaTable As DataTable = New DataTable
    Public OfficeTable As DataTable = New DataTable
    Public CompSurceTable As DataTable = New DataTable
    Public CountryTable As DataTable = New DataTable
    Public ProdKTable As DataTable = New DataTable
    Public ProdCompTable As DataTable = New DataTable
    Public UpdateKTable As DataTable = New DataTable
    Public FTPTable As New DataTable
    Public CtrlsTbl As DataTable = New DataTable
    Public ConTbl As New DataTable
    Public LogOfflinTbl As New DataTable
    Public CompfflinTbl As New DataTable
    Public TicTable As DataTable = New DataTable

    Public TickSrchTable As New DataTable
    Public PreciFlag As Boolean = False                 'Load princible tables
    Public PrciTblCnt As Integer = 0                    'Counter for Thread
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX



    Public MLXX As String = ""       ' Mail Password From Lib Table
    Public Errmsg As String          ' Handel error message
    Public Esc As String = ""
    Public EscCnt As Integer = 0
    Public EscID As Integer = 0
    Public EnglishInput As InputLanguage
    Public ArabicInput As InputLanguage
    Public GenSaltKey As String = "754A8DBBBE83563B7A724710FCF14FAD"
    ' CAPS LOACK
    Public Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Public Const VK_CAPITAL As Integer = &H14               ' CAPS LOACK
    Public Const KEYEVENTF_EXTENDEDKEY As Integer = &H1     ' CAPS LOACK
    Public Const KEYEVENTF_KEYUP As Integer = &H2           ' CAPS LOACK
    Public Usr As New Strc.CurrentUser
    Public SQLSTR As String
    Public Cnt_ As Integer                              'Counter
    Public EncDecTxt As String                          'Encoding decoding string
    Public Tran As SqlTransaction = Nothing             'SQL Transaction
    Public sqlComm As New SqlCommand                    'SQL Command
    Public sqlCommUpddate_ As New SqlCommand            'SQL Command
    Public sqlComminsert_1 As New SqlCommand            'SQL Command
    Public sqlComminsert_2 As New SqlCommand            'SQL Command
    Public sqlComminsert_3 As New SqlCommand            'SQL Command
    Public sqlComminsert_4 As New SqlCommand            'SQL Command
    Public Reader_ As SqlDataReader                     'SQL Reader
    Public SQLTblAdptr As New SqlDataAdapter            'SQL Table Adapter

    Public ExpDTable As New DataTable                   'Export data Function to use its count every time i use this function
    Public ExpTrFlseTable As New DataTable

    Public ExpStr As String
    Public Rws As Integer
    Public Col As Integer
    Public DataExprRtrn As Strc.ExprXlsx                     'Return Counters Structure of Export Function
    Public GridCuntRtrn As Strc.TickInfo                     'Return Counters Structure of Gridview Function
    Public StruGrdTk As Strc.TickFld                     'Return Fields Structure of Tickets Gridview Function
    Public Msg As String
    Public LblSecLvl_ As String = "" 'FOR SEC fORM
    'Public Const strConn As String = "Data Source=sql5041.site4now.net;Initial Catalog=DB_A49C49_vocaplus;Persist Security Info=True;User ID=DB_A49C49_vocaplus_admin;Password=Hemonad105046"
    'Public Const strConn As String = "Server=tcp:egyptpostazure.database.windows.net,1433;Initial Catalog=vocaplus;Persist Security Info=False;User ID=sw;Password=Hemonad105046;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
    'Public strConnCssys As String = "Data Source=10.10.26.4;Initial Catalog=CSSYS;Persist Security Info=True;User ID=import;Password=ASD_asd123"
    'Public Const strConn As String = "Data Source=HOSPC\HOSPCSQLSRV;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
    Public Distin As String = ""
    Public StrFileName As String = "X"
    Public Nw As DateTime
    Public TikIDRep_ As Integer
    Public Rslt As DialogResult
    Public Property MousePosition As Object

    Public CompIds As String ' tickets to get tickets updates
    Public TickTblMain As New DataTable
    Public UpdtCurrTbl As DataTable
    Public UpGetSql As New DataTable
    Public ProgBar As ProgressBar
    Public ElapsedTimeSpan As String
    Public NewElapsedTimeSpan As String
    Public TreadQueue As Queue(Of Thread)
    Public frm__ As Form
    Public gridview_ As DataGridView
End Module
Public Class APblicClss
    Public Class Defntion
        Public Thread_ As Thread
        Public Str As String
        Public StatStr As String
        Public Errmsg As String
        Public RwCnt As Integer
        Public CONSQL As New SqlConnection(strConn) ' I Have assigned conn STR here and delete this row from all project
        Public ElapsedTimeSpan As String
        Public sqlComm As New SqlCommand                    'SQL Command
        Public sqlComminsert_1 As New SqlCommand            'SQL Command
        Public sqlComminsert_2 As New SqlCommand            'SQL Command
        Public sqlComminsert_3 As New SqlCommand            'SQL Command
        Public sqlComminsert_4 As New SqlCommand            'SQL Command

        Public Tran As SqlTransaction
        Public cntXXX As Integer
        Public Nw As DateTime
        Public TickKind As Integer = 0       'ticket kind      0=Inquiry and 1=Complaint
        Public PrdKind As String = ""        'Product kind     1=Financial and 2=Postal   3=Governmental and 4=Social and 5=Other
        Public TickKindFltr As Integer = 2   'ticket kind      0=Inquiry and 1=Complaint
        Public TicOpnFltr As Integer = 2      'ticket Sttaus   0=Open and 1=Close and 2=All


        Public reader As SqlDataReader
        Public MacTable As DataTable

        Public BolString As Boolean
        Public Admn As Boolean
        Public CompList As New List(Of String) 'list of tickets to get tickets updates

    End Class
    Public Class FuncWorker
        Public Function ConStrFn(worker As System.ComponentModel.BackgroundWorker) As String
            Dim state As New Defntion
            Dim Fn As New APblicClss.Func
            state.Errmsg = Nothing
            strConn = Nothing
            If ServerCD = "Eg Server" Then
                strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
                ServerNm = "VOCA Server"
            ElseIf ServerCD = "My Labtop" Then
                strConn = "Data Source=MyThinkbook\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
                ServerNm = "My Labtop"
            ElseIf ServerCD = "Test Database" Then
                strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlusDemo;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
                ServerNm = "Test Database"
            ElseIf ServerCD = "OnLine" Then
                strConn = "Data Source=34.123.217.183;Initial Catalog=vocaplus;Persist Security Info=True;User ID=sqlserver;Password=Hemonad105046"
                ServerNm = "OnLine"
            End If
            Try
                'sqlCon = New SqlConnection
                state.CONSQL.ConnectionString = strConn
            Catch ex As Exception
                state.Errmsg = ex.Message
                Fn.AppLog("0000&H", ex.Message, "Conecting String")
            End Try
            worker.ReportProgress(0, state)
            Return strConn
        End Function
        Public Sub MacTblSub(worker As System.ComponentModel.BackgroundWorker)
            Dim Def As New APblicClss.Defntion
            Dim FnW As New APblicClss.FuncWorker
            Def.MacTable = New DataTable
            If (FnW.GetTbl("select Mac, Admin from AMac where Mac ='" & GetMACAddressNew() & "'", Def.MacTable, "8888&H", worker)) = Nothing Then
                Def.RwCnt = Def.MacTable.Rows.Count
                worker.ReportProgress(0, Def)
                If Def.MacTable.Rows.Count > 0 Then
                    If DBNull.Value.Equals(Def.MacTable.Rows(0).Item("Admin")) = True Then
                        Def.Admn = False
                        worker.ReportProgress(0, Def)
                    ElseIf Def.MacTable.Rows(0).Item("Admin") = False Or Def.MacTable.Rows(0).Item("Admin") = True Then
                        Def.Admn = True
                        worker.ReportProgress(0, Def)
                    End If
                End If
            Else
                Def.StatStr = "Error"
            End If
            worker.ReportProgress(0, Def)
        End Sub
        Public Sub Conoff(worker As System.ComponentModel.BackgroundWorker)
            Dim state As New Defntion
            Dim Fn As New APblicClss.Func
            Dim TimeTble As New DataTable
            Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
            Try
                state.StatStr = " ..."
                worker.ReportProgress(0, state)
                state.CONSQL = New SqlConnection(strConn)
                If state.CONSQL.State <> ConnectionState.Connecting Then state.CONSQL = New SqlConnection(strConn)
                If state.CONSQL.State = ConnectionState.Closed Then
                    state.CONSQL.Open()
                End If
                Dim sqlCommW As New SqlCommand("Select GetDate() as Now_", state.CONSQL)
                state.reader = sqlCommW.ExecuteReader
                TimeTble.Load(state.reader)
                state.BolString = True
                worker.ReportProgress(0, state)
            Catch ex As Exception
                state.StatStr = "Error"
                state.BolString = False
                worker.ReportProgress(0, state)
                Fn.AppLog("0000&H", ex.Message, "Select GetDate() as Now_")
            End Try
            state.CONSQL.Close()
            SqlConnection.ClearPool(state.CONSQL)
            Bol = state.BolString
            sqlComm.CommandTimeout = 30
        End Sub
        Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable, ErrHndl As String, worker As System.ComponentModel.BackgroundWorker) As String
            Dim state As New Defntion
            Dim Fn As New APblicClss.Func
            state.StatStr = Nothing
            Dim StW As New Stopwatch
            StW.Start()
            state.CONSQL = New SqlConnection(strConn)
            Dim sqlCommW As New SqlCommand(SSqlStr, state.CONSQL)
            Try
                If state.CONSQL.State = ConnectionState.Closed Or state.CONSQL.State = ConnectionState.Broken Then
                    state.CONSQL.Open()
                End If

                state.reader = sqlCommW.ExecuteReader
                SqlTbl.Load(state.reader)
                worker.ReportProgress(0, state)
                StW.Stop()
                Dim TimSpn As TimeSpan = (StW.Elapsed)
                ElapsedTimeSpan = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds / 10)
            Catch ex As Exception
                If ex.Message.Contains("The connection is broken and recovery is not possible") Then
                    state.CONSQL.Close()
                    SqlConnection.ClearPool(state.CONSQL)
                End If
                state.StatStr = ex.Message
                Fn.AppLog(ErrHndl, ex.Message, SSqlStr)
            End Try
            state.CONSQL.Close()
            SqlConnection.ClearPool(state.CONSQL)
            state.sqlComm.Dispose()
            Return state.StatStr
        End Function
        Public Function InsUpd(SSqlStr As String, ErrHndl As String, worker As System.ComponentModel.BackgroundWorker) As String
            Errmsg = Nothing
            Dim state As New Defntion
            Dim Fn As New APblicClss.Func
            state.CONSQL = New SqlConnection(strConn)
            sqlComm = New SqlCommand(SSqlStr, state.CONSQL)
            sqlComm.Connection = state.CONSQL
            sqlComm.CommandType = CommandType.Text
            Try
                If state.CONSQL.State = ConnectionState.Closed Then
                    state.CONSQL.Open()
                End If
                sqlComm.ExecuteNonQuery()
            Catch ex As Exception
                Errmsg = ex.Message
                Fn.AppLog(ErrHndl, ex.Message, SSqlStr)
            End Try
            state.CONSQL.Close()
            SqlConnection.ClearPool(state.CONSQL)
            Return Errmsg
        End Function
        Public Function ServrTime(worker As System.ComponentModel.BackgroundWorker) As DateTime
            Dim Def As New APblicClss.Defntion
            Def.StatStr = Nothing
            worker.ReportProgress(0, Def)
            Dim TimeTble As New DataTable
            Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
            Try
                sqlComm.Connection = Def.CONSQL
                SQLGetAdptr.SelectCommand = sqlComm
                sqlComm.CommandType = CommandType.Text
                sqlComm.CommandText = "Select GetDate() as Now_"
                SQLGetAdptr.Fill(TimeTble)
                Def.Nw = Format(TimeTble.Rows(0).Item(0), "yyyy/MMM/dd hh:mm:ss tt")

            Catch ex As Exception
                Def.StatStr = "X"
                worker.ReportProgress(0, Def)
                Dim frmCollection = Application.OpenForms
                If frmCollection.OfType(Of WelcomeScreen).Any Then
                    WelcomeScreen.TimerCon.Start()
                    WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
                End If
            End Try
            Return Def.Nw
            worker.ReportProgress(0, Def)
            SQLGetAdptr.Dispose()
        End Function
        Public Sub HrdWre(worker As System.ComponentModel.BackgroundWorker)
            Dim Def As New APblicClss.Defntion
            Dim FnW As New APblicClss.FuncWorker
            Dim Fn As New APblicClss.Func
            On Error Resume Next
            HardTable = New DataTable
            Def.StatStr = "Not Updated"
            worker.ReportProgress(0, Def)
            If (FnW.GetTbl("select IpId, IpStime FROM SdHardCollc WHERE ((IpId= '" & OsIP() & "'));", HardTable, "1000&H", worker)) = Nothing Then
                If HardTable.Rows.Count = 0 Then 'insert new computer hardware information if not founded into Hardware Table
                    Fn.HrdCol()
                    FnW.InsUpd("insert into SdHardCollc (IpId, IpLocation, IpProsseccor, IpRam, IpNetwork, IpSerialNo, IpCollect) values ('" & OsIP() & "','" & "Location" & "','" & Fn.HrdCol.HProcc & "','" & Fn.HrdCol.HRam & "','" & Fn.HrdCol.HNetwrk & "','" & Fn.HrdCol.HSerNo & "','" & True & "');", "1000&H", worker) 'Append access Record
                    Def.StatStr = "Inserted"
                    worker.ReportProgress(0, Def)
                ElseIf Math.Abs(DateTime.Parse(Today).Subtract(DateTime.Parse(HardTable.Rows(0).Item(1))).TotalDays) > 30 Then
                    Fn.HrdCol()
                    FnW.InsUpd("UPDATE SdHardCollc SET IpProsseccor ='" & Fn.HrdCol.HProcc & "', IpRam ='" & Fn.HrdCol.HRam & "', IpNetwork ='" & Fn.HrdCol.HNetwrk & "', IpSerialNo ='" & Fn.HrdCol.HSerNo & "', IpStime ='" & Format(FnW.ServrTime(worker), "yyyy-MM-dd") & "' where IpId='" & OsIP() & "';", "1000&H", worker)
                    Def.StatStr = "Updated"
                    worker.ReportProgress(0, Def)
                End If
            End If
Sec2:
            HardTable.Dispose()
            GC.Collect()
        End Sub
        Public Sub SwitchBoard(worker As System.ComponentModel.BackgroundWorker)
            Dim SwichTabTable As New DataTable
            Dim SwichButTable As New DataTable
            Dim Def As New APblicClss.Defntion
            Dim Fnw As New APblicClss.FuncWorker
            Dim Fn As New APblicClss.Func

            Menu_ = New MenuStrip
            CntxMenu = New ContextMenuStrip

            If (Fnw.GetTbl("SELECT SwNm, SwSer, SwID, SwObjNew,SwObjNm, SwObjImg, SwType FROM ASwitchboard ORDER BY SwID", SwichTabTable, "1002&H", worker)) = Nothing Then
                Def.Str = " Building Main Menu ..."
                worker.ReportProgress(0, Def)
                SwichButTable = SwichTabTable.Copy
                SwichTabTable.DefaultView.RowFilter = "(SwType = 'Tab') AND (SwNm <> 'NA')"
                For Cnt_ = 0 To SwichTabTable.DefaultView.Count - 1
                    Dim NewTab As New ToolStripMenuItem(SwichTabTable.DefaultView(Cnt_).Item("SwNm").ToString)
                    Dim NewTabCx As New ToolStripMenuItem(SwichTabTable.DefaultView(Cnt_).Item("SwNm").ToString)  'YYYYYYYYYYY

                    If Mid(Usr.PUsrLvl, SwichTabTable.DefaultView(Cnt_).Item("SwID").ToString, 1) = "A" Or
                        Mid(Usr.PUsrLvl, SwichTabTable.DefaultView(Cnt_).Item("SwID").ToString, 1) = "H" Then
                        Menu_.Items.Add(NewTab)
                        CntxMenu.Items.Add(NewTabCx)                     'YYYYYYYYYYY

                        Def.Str = " Adding Menu " & NewTab.Text
                        worker.ReportProgress(0, Def)
                        Def.Str = " Building Menu " & NewTab.Text
                        worker.ReportProgress(0, Def)
                        Dim Filtr_ As String = SwichTabTable.DefaultView(Cnt_).Item("SwSer").ToString
                        SwichButTable.DefaultView.RowFilter = "(([SwType] <> '" & "Tab" & "') AND ([SwNm] <> '" & "NA" & "') AND ([SwSer] ='" & Filtr_ & "'))"
                        For Cnt_1 = 0 To SwichButTable.DefaultView.Count - 1
                            Dim subItem As New ToolStripMenuItem(SwichButTable.DefaultView(Cnt_1).Item("SwNm").ToString)
                            Dim subItemCx As New ToolStripMenuItem(SwichButTable.DefaultView(Cnt_1).Item("SwNm").ToString)  'YYYYYYYYYYY
                            If Mid(Usr.PUsrLvl, SwichButTable.DefaultView(Cnt_1).Item("SwID").ToString, 1) = "A" Or
                                   Mid(Usr.PUsrLvl, SwichButTable.DefaultView(Cnt_1).Item("SwID").ToString, 1) = "H" Then

                                Def.Str = " Adding Button " & NewTab.Text
                                worker.ReportProgress(0, Def)
                                subItem.Tag = SwichButTable.DefaultView(Cnt_1).Item("SwObjNm").ToString
                                If Mid(Usr.PUsrLvl, SwichButTable.DefaultView(Cnt_1).Item("SwID").ToString, 1) = "H" Then
                                    subItem.AccessibleName = "True"
                                    subItemCx.AccessibleName = "True"
                                End If
                                If DBNull.Value.Equals(SwichButTable.DefaultView(Cnt_1).Item("SwObjImg")) = False Then
                                    Dim imglst As New ImageList
                                    Dim Cnt_ = imglst.Images(SwichButTable.DefaultView(Cnt_1).Item("SwObjImg"))
                                    Dim dd = My.Resources.ResourceManager.GetObject(SwichButTable.DefaultView(Cnt_1).Item("SwObjImg"))
                                    NewTab.Image = Cnt_
                                End If
                                subItemCx.Tag = SwichButTable.DefaultView(Cnt_1).Item("SwObjNm").ToString  'YYYYYYYYYYY
                                NewTab.DropDownItems.Add(subItem)
                                NewTabCx.DropDownItems.Add(subItemCx)    'YYYYYYYYYYY
                            End If
                            If Mid(Usr.PUsrLvl, SwichTabTable.DefaultView(Cnt_).Item(2).ToString, 1) = "H" Then
                                NewTab.AccessibleName = "True"
                                NewTabCx.AccessibleName = "True"
                            End If
                        Next Cnt_1
                    End If
                    NewTab = Nothing
                Next Cnt_
                PrciTblCnt = 0
                SwichTabTable.Dispose()
                SwichButTable.Dispose()
                Def.Str = " Menu has been builded  "
                worker.ReportProgress(0, Def)
                Def.Str = "جاري تحميل البيانات ..."
                worker.ReportProgress(0, Def)
                If Def.Str = "جاري تحميل البيانات ..." Then
                    Dim primaryKey(0) As DataColumn
                    AreaTable = New DataTable
                    OfficeTable = New DataTable
                    CompSurceTable = New DataTable
                    CountryTable = New DataTable
                    ProdKTable = New DataTable
                    ProdCompTable = New DataTable
                    UpdateKTable = New DataTable
                    Def.Str = "جاري تحميل أسماء المناطق ..."
                    worker.ReportProgress(0, Def)
                    If (Fnw.GetTbl("SELECT OffArea FROM PostOff GROUP BY OffArea ORDER BY OffArea;", AreaTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء المناطق "
                        worker.ReportProgress(0, Def)
                    End If

                    Def.Str = "جاري تحميل أسماء المكاتب ..."
                    worker.ReportProgress(0, Def)

                    If (Fnw.GetTbl("select OffNm1, OffFinCd, OffArea from PostOff ORDER BY OffNm1;", OfficeTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء المكاتب  "
                        worker.ReportProgress(0, Def)
                    End If

                    Dim SrcStr As String = ""
                    If Usr.PUsrUCatLvl = 7 Then
                        SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1"
                    Else
                        SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd > 1 ORDER BY SrcNm"
                    End If
                    Def.Str = "جاري تحميل مصادر الشكوى ..."
                    worker.ReportProgress(0, Def)

                    If (Fnw.GetTbl(SrcStr, CompSurceTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  مصادر الشكوى  "
                        worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أسماء الدول ..."
                    worker.ReportProgress(0, Def)

                    If (Fnw.GetTbl("select CounCd,CounNm from CDCountry order by CounNm", CountryTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = CountryTable.Columns("CounCd")
                        CountryTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء الدول  "
                        worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أنواع الخدمات ..."
                    worker.ReportProgress(0, Def)

                    If (Fnw.GetTbl("select ProdKCd, ProdKNm, ProdKClr from CDProdK where ProdKSusp = 0 order by ProdKCd", ProdKTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = ProdKTable.Columns("ProdKNm")
                        ProdKTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أنواع الخدمات "
                        worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أنواع المنتجات ..."
                    worker.ReportProgress(0, Def)

                    If (Fnw.GetTbl("SELECT FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp,CompHlp FROM VwFnProd where FnSusp = 0 ORDER BY PrdKind, PrdNm, CompNm", ProdCompTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = ProdCompTable.Columns("FnSQL")
                        ProdCompTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل أنواع المنتجات  "
                        worker.ReportProgress(0, Def)
                    End If

                    Def.Str = "جاري تحميل أنواع التحديثات ..."
                    worker.ReportProgress(0, Def)
                    If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
                        If (Fnw.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 1 ORDER BY EvNm", UpdateKTable, "1012&H", worker)) = Nothing Then
                            PrciTblCnt += 1
                        Else
                            Def.Str = "لم يتم تحميل  أنواع التحديثات "
                            worker.ReportProgress(0, Def)
                        End If
                    Else
                        If (Fnw.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 0 ORDER BY EvNm", UpdateKTable, "1012&H", worker)) = Nothing Then
                            PrciTblCnt += 1
                        Else
                            Def.Str = " أنواع التحديثات / "
                            worker.ReportProgress(0, Def)
                        End If
                    End If
                End If
            Else
                worker.ReportProgress(0, Def)
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf)
            End If
        End Sub
        Public Sub TikCntrSub(worker As System.ComponentModel.BackgroundWorker)
            Dim state As New APblicClss.Defntion
            Dim Fn As New APblicClss.Func
            TicTable = New DataTable
            If GetTbl("select UsrClsN, UsrFlN, UsrReOpY, UsrUnRead, UsrEvDy, UsrClsYDy, UsrReadYDy, UsrRecevDy, UsrClsUpdtd, UsrLastSeen, UsrTikFlowDy, UsrActive,UsrLogSnd from Int_user where UsrId = " & Usr.PUsrID & ";", TicTable, "0000&H", worker) = Nothing Then
            End If
        End Sub
    End Class
    Public Class Func
        Public Function ServrTime() As DateTime
            Dim Def As New APblicClss.Defntion
            Def.StatStr = Nothing
            Dim TimeTble As New DataTable
            Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
            Try
                sqlComm.Connection = Def.CONSQL
                SQLGetAdptr.SelectCommand = sqlComm
                sqlComm.CommandType = CommandType.Text
                sqlComm.CommandText = "Select GetDate() as Now_"
                SQLGetAdptr.Fill(TimeTble)
                Def.Nw = Format(TimeTble.Rows(0).Item(0), "yyyy/MMM/dd hh:mm:ss tt")

            Catch ex As Exception
                Def.StatStr = "X"
                Dim frmCollection = Application.OpenForms
                If frmCollection.OfType(Of WelcomeScreen).Any Then
                    WelcomeScreen.TimerCon.Start()
                    WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
                End If
            End Try
            Return Def.Nw
            SQLGetAdptr.Dispose()
        End Function
        Public Function GetTblXX(SSqlStr As String, SqlTbl As DataTable, ErrHndl As String) As String
            Dim state As New Defntion
            state.StatStr = Nothing
            Dim StW As New Stopwatch
            StW.Start()
            state.CONSQL = New SqlConnection(strConn)
            Dim sqlCommW As New SqlCommand(SSqlStr, state.CONSQL)
            Try
                If state.CONSQL.State = ConnectionState.Closed Or state.CONSQL.State = ConnectionState.Broken Then
                    state.CONSQL.Open()
                End If

                state.reader = sqlCommW.ExecuteReader
                SqlTbl.Load(state.reader)
                StW.Stop()
                Dim TimSpn As TimeSpan = (StW.Elapsed)
                ElapsedTimeSpan = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds / 10)
            Catch ex As Exception
                If ex.Message.Contains("The connection is broken and recovery is not possible") Then
                    state.CONSQL.Close()
                    SqlConnection.ClearPool(state.CONSQL)
                End If
                state.StatStr = ex.Message
                AppLog(ErrHndl, ex.Message, SSqlStr)
            End Try
            state.CONSQL.Close()
            SqlConnection.ClearPool(state.CONSQL)
            state.sqlComm.Dispose()
            Return state.StatStr
        End Function
        Public Function InsUpdate(SSqlStr As String, ErrHndl As String) As String
            Errmsg = Nothing
            Dim state As New Defntion
            state.CONSQL = New SqlConnection(strConn)
            sqlComm = New SqlCommand(SSqlStr, state.CONSQL)
            sqlComm.Connection = state.CONSQL
            sqlComm.CommandType = CommandType.Text
            Try
                If state.CONSQL.State = ConnectionState.Closed Then
                    state.CONSQL.Open()
                End If
                sqlComm.ExecuteNonQuery()
            Catch ex As Exception
                Errmsg = ex.Message
                AppLog(ErrHndl, ex.Message, SSqlStr)
            End Try
            state.CONSQL.Close()
            SqlConnection.ClearPool(state.CONSQL)
            Return Errmsg
        End Function
        Public Function InsTrans(TranStr1 As String, TranStr2 As String, ErrHndl As String) As String
            Dim state As New APblicClss.Defntion
            state.StatStr = Nothing
            Try
                If state.CONSQL.State = ConnectionState.Closed Then
                    state.CONSQL.Open()
                End If
                state.sqlComminsert_1.Connection = state.CONSQL
                state.sqlComminsert_2.Connection = state.CONSQL
                state.sqlComminsert_1.CommandType = CommandType.Text
                state.sqlComminsert_2.CommandType = CommandType.Text
                state.sqlComminsert_1.CommandText = TranStr1
                state.sqlComminsert_2.CommandText = TranStr2
                state.Tran = state.CONSQL.BeginTransaction()
                state.sqlComminsert_1.Transaction = Tran
                state.sqlComminsert_2.Transaction = Tran
                state.sqlComminsert_1.ExecuteNonQuery()
                state.sqlComminsert_2.ExecuteNonQuery()
                state.Tran.Commit()
            Catch ex As Exception
                state.Tran.Rollback()

                Dim frmCollection = Application.OpenForms
                If frmCollection.OfType(Of WelcomeScreen).Any Then
                    WelcomeScreen.TimerCon.Start()
                    WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
                End If
                AppLog(ErrHndl, ex.Message, TranStr1 & "_" & TranStr2)
            End Try
            state.CONSQL.Close()
            SqlConnection.ClearPool(state.CONSQL)
            Return state.StatStr
        End Function
        Public Sub AppLog(ErrHndls As String, LogMsg As String, SSqlStrs As String)
            On Error Resume Next
            My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) _
          & "\VOCALog" & Format(Now, "yyyyMM") & ".Vlg", Format(Now, "yyyyMMdd HH:mm:ss") & " ," & ErrHndls & LogMsg & " &H" & PassEncoding(SSqlStrs, GenSaltKey) & vbCrLf, True)
        End Sub
        Public Function CalDate(StDt As Date, ByRef EnDt As Date, ErrHndl As String) As Integer    ' Returns the number of CalDate between StDt and EnDt Using the table CDHolDay
            Dim WdyCount As Integer = 0
            Dim SQLcalDtAdptr As New SqlDataAdapter
            Dim CaldtTbl As New DataTable
            Dim Def As New APblicClss.Defntion
            Try

                StDt = DateValue(StDt)     ' DateValue returns the date part only if U use stamptime as example.
                EnDt = DateValue(EnDt)
                Def.sqlComm.Connection = Def.CONSQL ' Get ID & Date & UserID                        
                Def.sqlComm.CommandText = "SELECT Count(HDate) AS WDaysCount FROM CDHolDay WHERE (HDy = 1) AND (HDate BETWEEN CONVERT(DATETIME, '" & Format(StDt, "dd/MM/yyyy") & "', 103) AND CONVERT(DATETIME, '" & Format(EnDt, "dd/MM/yyyy") & "', 103));"
                Def.sqlComm.CommandType = CommandType.Text
                SQLcalDtAdptr.SelectCommand = Def.sqlComm
                'If sqlCon.State = ConnectionState.Closed Then
                '    sqlCon.Open()
                'End If
                SQLcalDtAdptr.Fill(CaldtTbl)
                WdyCount = CaldtTbl.Rows(0).Item("WDaysCount")
            Catch ex As Exception
                Def.StatStr = ex.Message
                WdyCount = 1
            End Try
            Return WdyCount
        End Function
        Function PassEncoding(password As String, FSaltKey As String) As String
            Dim Wrapper As New Simple3Des(FSaltKey)
            EncDecTxt = Wrapper.EncryptData(password)
            Return EncDecTxt
        End Function
        Function PassDecoding(password As String, FSaltKey As String) As String
            Dim wrapper As New Simple3Des(FSaltKey)
            Try '        DecryptData throws if the wrong password is used.
                EncDecTxt = wrapper.DecryptData(password)
            Catch ex As System.Security.Cryptography.CryptographicException
                EncDecTxt = "false"
            End Try
            Return EncDecTxt
        End Function
        Function HrdCol() As Strc.HrdColc
            Dim MyOBJ As Object
            Dim Items As New Strc.HrdColc
            MyOBJ = GetObject("WinMgmts:").instancesof("Win32_Processor") ' Proccessor Information
            For Each Device In MyOBJ
                Items.HProcc &= Device.Name.ToString + " " + Device.CurrentClockSpeed.ToString + " Mhz"
            Next
            MyOBJ = GetObject("WinMgmts:").instancesof("Win32_NetworkAdapter") ' Network Information
            For Each Device In MyOBJ
                Items.HNetwrk &= Device.Name.ToString & " & "
            Next

            MyOBJ = GetObject("WinMgmts:").instancesof("Win32_PhysicalMemory")  ' Ram Information
            For Each Device In MyOBJ
                Items.HRam &= " Ram Capacity : " & Device.Capacity / 1024 / 1024 / 1024 & " Giga " & "Manufacturer : " & Device.Manufacturer
            Next

            MyOBJ = GetObject("WinMgmts:").instancesof("Win32_bios")  ' Bios Information
            For Each Device In MyOBJ
                Items.HSerNo &= "Serial Number: " & Device.serialNumber & " Manufacturer : " & Device.Manufacturer
            Next
            Return Items
        End Function
        Public Function Exprt(FileNm As String, Tbl As DataTable) As String
            Dim ExrtErr As String = Nothing
            Dim D As SaveFileDialog = New SaveFileDialog
            With D
                .Title = "Save Excel File"
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .Filter = "Excel File|*.xlsx"
                .FilterIndex = 1
                .RestoreDirectory = True
            End With
            D.FileName = FileNm & "_" & Format(Now, "yyyy-MM-dd_HHmm") '& GroupBox1.Tag & GroupBox2.Tag & GroupBox3.Tag & GrpDtKnd.Tag
            If D.ShowDialog() = DialogResult.OK Then
                Try
                    Dim Workbook As XLWorkbook = New XLWorkbook()
                    Workbook.Worksheets.Add(Tbl, "FileNm")
                    Workbook.SaveAs(D.FileName)
                    MsgBox("Done")
                Catch ex As Exception

                    Exprt = "X"
                    MsgBox(ex.Message)
                End Try
            End If
            Return ExrtErr
        End Function
#Region "Tik"
        Public Sub GetUpdtEvnt_(worker As System.ComponentModel.BackgroundWorker)
            Dim Fnw As New APblicClss.Func
            Dim Def As New APblicClss.Defntion
            UpdtCurrTbl = New DataTable
            '                                 0        1         2         3         4        5        6         7         8         9
            'If Fn.GetTbl("SELECT TkupSTime, TkupTxt, UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread FROM TkEvent INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId Where ( " & CompIds & ") ORDER BY TkupTkSql,TkupSQL DESC", UpdtCurrTbl, "1019&H", worker) = Nothing Then
            If Fnw.GetTblXX("SELECT TkupSTime, TkupTxt, UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread FROM TkEvent inner join Tickets on Tickets.TkSQL = TkEvent.TkupTkSql INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId   " & FltrStr & " ORDER BY TkupTkSql,TkupSQL DESC", UpdtCurrTbl, "1019&H") = Nothing Then
                UpdtCurrTbl.Columns.Add("File")        ' Add files Columns 
            Else
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & Errmsg)
            End If
        End Sub
        Public Function CompGrdTikFill(GrdTick As DataGridView, Tbl As DataTable, ProgBar As ProgressBar, worker As System.ComponentModel.BackgroundWorker) As String
            Dim Def As New APblicClss.Defntion
            Dim Fn As New APblicClss.Func
            Def.Errmsg = Nothing
            worker.ReportProgress(0, Def)
            Try
                GrdTick.DataSource = Tbl.DefaultView
                Def.CompList = New List(Of String)
                ProgBar.Visible = True
                ProgBar.Maximum = Tbl.Columns.Count
                For HH = 0 To Tbl.Columns.Count - 1
                    ProgBar.Value = HH + 1
                    ProgBar.Refresh()
                    If Tbl.Columns(HH).ColumnName = "TkDtStart" Then
                        GrdTick.Columns(HH).HeaderText = "تاريخ الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkID" Then
                        GrdTick.Columns(HH).HeaderText = "رقم الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "SrcNm" Then
                        GrdTick.Columns(HH).HeaderText = "مصدر الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkClNm" Then
                        GrdTick.Columns(HH).HeaderText = "اسم العميل"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkClPh" Then
                        GrdTick.Columns(HH).HeaderText = "تليفون العميل1"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkClPh1" Then
                        GrdTick.Columns(HH).HeaderText = "تليفون العميل2"
                    ElseIf Tbl.Columns(HH).ColumnName = "PrdNm" Then
                        GrdTick.Columns(HH).HeaderText = "اسم المنتج"
                    ElseIf Tbl.Columns(HH).ColumnName = "CompNm" Then
                        GrdTick.Columns(HH).HeaderText = "نوع الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "UsrRealNm" Then
                        GrdTick.Columns(HH).HeaderText = "متابع الشكوى"
                    Else
                        GrdTick.Columns(HH).HeaderText = "unknown"
                        GrdTick.Columns(HH).Visible = False
                    End If
                Next
                ProgBar.Maximum = GrdTick.Rows.Count
                'For GG = 0 To GrdTick.Rows.Count - 1
                '    ProgBar.Value = GG + 1
                '    ProgBar.Refresh()
                '    Def.CompList.Add("TkupTkSql = " & GrdTick.Rows(GG).Cells("TkSQL").Value)
                'Next
                'CompIds = String.Join(" OR ", Def.CompList)
                Tbl.Columns.Add("تاريخ آخر تحديث")
                Tbl.Columns.Add("نص آخر تحديث")
                Tbl.Columns.Add("محرر آخر تحديث")
                Tbl.Columns.Add("TkupReDt")
                Tbl.Columns.Add("TkupUser")
                Tbl.Columns.Add("LastUpdateID")
                Tbl.Columns.Add("EvSusp")
                Tbl.Columns.Add("UCatLvl")
                Tbl.Columns.Add("TkupUnread")
            Catch ex As Exception
                Def.Errmsg = ex.Message
                worker.ReportProgress(0, Def)
            End Try
            ProgBar.Visible = False
            Return Errmsg
        End Function
#End Region
#Region "Tik1"
        Public Sub GetUpdtEvnt_1()
            Dim Fn As New APblicClss.Func
            Dim Def As New APblicClss.Defntion
            UpdtCurrTbl = New DataTable
            '                                 0        1         2         3         4        5        6         7         8         9
            'If Fn.GetTbl("SELECT TkupSTime, TkupTxt, UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread FROM TkEvent INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId Where ( " & CompIds & ") ORDER BY TkupTkSql,TkupSQL DESC", UpdtCurrTbl, "1019&H", worker) = Nothing Then
            If Fn.GetTblXX("SELECT TkupSTime, TkupTxt, UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread FROM TkEvent inner join Tickets on Tickets.TkSQL = TkEvent.TkupTkSql INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId   " & FltrStr & " ORDER BY TkupTkSql,TkupSQL DESC", UpdtCurrTbl, "1019&H") = Nothing Then
                UpdtCurrTbl.Columns.Add("File")        ' Add files Columns 
            Else
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & Errmsg)
            End If
        End Sub
        Public Function CompGrdTikFill1(GrdTick As DataGridView, Tbl As DataTable, ProgBar As ProgressBar) As String
            Dim Def As New APblicClss.Defntion
            Dim Fn As New APblicClss.Func
            Def.Errmsg = Nothing
            Try
                GrdTick.DataSource = Tbl.DefaultView
                Def.CompList = New List(Of String)
                ProgBar.Visible = True
                ProgBar.Maximum = Tbl.Columns.Count
                For HH = 0 To Tbl.Columns.Count - 1
                    ProgBar.Value = HH + 1
                    'ProgBar.Refresh()
                    If Tbl.Columns(HH).ColumnName = "TkDtStart" Then
                        GrdTick.Columns(HH).HeaderText = "تاريخ الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkID" Then
                        GrdTick.Columns(HH).HeaderText = "رقم الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "SrcNm" Then
                        GrdTick.Columns(HH).HeaderText = "مصدر الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkClNm" Then
                        GrdTick.Columns(HH).HeaderText = "اسم العميل"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkClPh" Then
                        GrdTick.Columns(HH).HeaderText = "تليفون العميل1"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkClPh1" Then
                        GrdTick.Columns(HH).HeaderText = "تليفون العميل2"
                    ElseIf Tbl.Columns(HH).ColumnName = "PrdNm" Then
                        GrdTick.Columns(HH).HeaderText = "اسم المنتج"
                    ElseIf Tbl.Columns(HH).ColumnName = "CompNm" Then
                        GrdTick.Columns(HH).HeaderText = "نوع الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "UsrRealNm" Then
                        GrdTick.Columns(HH).HeaderText = "متابع الشكوى"
                    Else
                        GrdTick.Columns(HH).HeaderText = "unknown"
                        GrdTick.Columns(HH).Visible = False
                    End If
                Next
                ProgBar.Maximum = GrdTick.Rows.Count
                'For GG = 0 To GrdTick.Rows.Count - 1
                '    ProgBar.Value = GG + 1
                '    'ProgBar.Refresh()
                '    Def.CompList.Add("TkupTkSql = " & GrdTick.Rows(GG).Cells("TkSQL").Value)
                'Next
                'CompIds = String.Join(" OR ", Def.CompList)
                Tbl.Columns.Add("تاريخ آخر تحديث")
                Tbl.Columns.Add("نص آخر تحديث")
                Tbl.Columns.Add("محرر آخر تحديث")
                Tbl.Columns.Add("TkupReDt")
                Tbl.Columns.Add("TkupUser")
                Tbl.Columns.Add("LastUpdateID")
                Tbl.Columns.Add("EvSusp")
                Tbl.Columns.Add("UCatLvl")
                Tbl.Columns.Add("TkupUnread")
            Catch ex As Exception
                Def.Errmsg = ex.Message
            End Try
            ProgBar.Visible = False
            Return Errmsg
        End Function
        Public Function TikFormat1(TblTicket As DataTable, TblUpdt As DataTable, ProgBar As ProgressBar) As TickInfo ' Function to Adjust Ticket Gridview
            GridCuntRtrn = New TickInfo
            ProgBar.Visible = True
            For Rws = 0 To TblTicket.Rows.Count - 1
                GridCuntRtrn.TickCount += 1                                          'Grid record count
                ProgBar.Maximum = TblTicket.Rows.Count
                ProgBar.Value = GridCuntRtrn.TickCount
                'ProgBar.Refresh()
                Try
                    TblUpdt.DefaultView.RowFilter = "[TkupTkSql]" & " = " & TblTicket.Rows(Rws).Item("TkSQL")
                    TblTicket.Rows(Rws).Item("تاريخ آخر تحديث") = TblUpdt.DefaultView(0).Item("TkupSTime")
                    TblTicket.Rows(Rws).Item("نص آخر تحديث") = TblUpdt.DefaultView(0).Item("TkupTxt")
                    TblTicket.Rows(Rws).Item("محرر آخر تحديث") = TblUpdt.DefaultView(0).Item("UsrRealNm")
                    TblTicket.Rows(Rws).Item("TkupReDt") = TblUpdt.DefaultView(0).Item("TkupReDt")
                    TblTicket.Rows(Rws).Item("TkupUser") = TblUpdt.DefaultView(0).Item("TkupUser")
                    TblTicket.Rows(Rws).Item("LastUpdateID") = TblUpdt.DefaultView(0).Item("TkupEvtId")
                    TblTicket.Rows(Rws).Item("EvSusp") = TblUpdt.DefaultView(0).Item("EvSusp")
                    TblTicket.Rows(Rws).Item("UCatLvl") = TblUpdt.DefaultView(0).Item("UCatLvl")
                    TblTicket.Rows(Rws).Item("TkupUnread") = TblUpdt.DefaultView(0).Item("TkupUnread")

                    StruGrdTk.LstUpDt = TblUpdt.DefaultView(0).Item("TkupSTime")
                    StruGrdTk.LstUpTxt = TblUpdt.DefaultView(0).Item("TkupTxt")
                    StruGrdTk.LstUpUsrNm = TblUpdt.DefaultView(0).Item("UsrRealNm")
                    StruGrdTk.LstUpEvId = TblUpdt.DefaultView(0).Item("TkupEvtId")
                Catch ex As Exception
                    TblTicket.Rows(Rws).Delete()
                End Try
            Next Rws
            GridCuntRtrn.CompCount = Convert.ToInt32(TblTicket.Compute("count(TkSQL)", String.Empty))
            GridCuntRtrn.NoFlwCount = Convert.ToInt32(TblTicket.Compute("count(TkFolw)", "TkFolw = 'False'"))
            GridCuntRtrn.Recved = Convert.ToInt32(TblTicket.Compute("count(TkRecieveDt)", "TkRecieveDt = '" & Format(Nw, "yyyy/MM/dd").ToString & "'"))
            GridCuntRtrn.ClsCount = Convert.ToInt32(TblTicket.Compute("count(TkClsStatus)", "TkClsStatus = 'True' And TkKind = 'True'"))
            GridCuntRtrn.UpdtFollow = Convert.ToInt32(TblTicket.Compute("count(UsrRealNm)", "[محرر آخر تحديث] = UsrRealNm"))
            GridCuntRtrn.UpdtColleg = Convert.ToInt32(TblTicket.Compute("count(UsrRealNm)", "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl >= 3 And UCatLvl <= 5"))
            GridCuntRtrn.UpdtOthrs = Convert.ToInt32(TblTicket.Compute("count(UsrRealNm)", "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl < 3 And UCatLvl > 5"))
            GridCuntRtrn.UnReadCount = Convert.ToInt32(TblTicket.Compute("count(TkupUnread)", "TkupUnread = 'False'"))
            GridCuntRtrn.Esc1 = Convert.ToInt32(TblTicket.Compute("count(LastUpdateID)", "LastUpdateID = 902"))
            GridCuntRtrn.Esc2 = Convert.ToInt32(TblTicket.Compute("count(LastUpdateID)", "LastUpdateID = 903"))
            GridCuntRtrn.Esc3 = Convert.ToInt32(TblTicket.Compute("count(LastUpdateID)", "LastUpdateID = 904"))
            ProgBar.Visible = False
            Return GridCuntRtrn 'Return Counters Structure
        End Function
        Public Function GetPrntrFrm(Frm As Form, GV As DataGridView) As String
            Errmsg = Nothing
            Try
                Dim GrivVw_ As DataGridView = Frm.Controls(GV.Name)
                GrivVw_.CurrentRow.Cells("TkDetails").Value = StruGrdTk.Detls
                GrivVw_.CurrentRow.Cells("تاريخ آخر تحديث").Value = StruGrdTk.LstUpDt
                GrivVw_.CurrentRow.Cells("نص آخر تحديث").Value = StruGrdTk.LstUpTxt
                GrivVw_.CurrentRow.Cells("محرر آخر تحديث").Value = StruGrdTk.LstUpUsrNm
                GrivVw_.CurrentRow.Cells("LastUpdateID").Value = StruGrdTk.LstUpEvId
                GrivVw_.CurrentRow.Cells("TkClsStatus").Value = StruGrdTk.ClsStat

                If Frm.Name = "TikFolow" Then
                    If StruGrdTk.ClsStat = True Then
                        GrivVw_.Rows.RemoveAt(GrivVw_.CurrentRow.Index)
                    End If
                End If
            Catch ex As Exception
                Errmsg = ex.Message
            End Try
            Return Errmsg
        End Function
        Public Function TikGVDblClck(GrdTick As DataGridView) As String
            Errmsg = Nothing
            Dim Def As New APblicClss.Defntion
            Try
                StruGrdTk.Tick = GrdTick.CurrentRow.Cells("TkKind").Value
                StruGrdTk.FlwStat = GrdTick.CurrentRow.Cells("TkClsStatus").Value
                StruGrdTk.Sql = GrdTick.CurrentRow.Cells("TkSQL").Value
                StruGrdTk.Ph1 = GrdTick.CurrentRow.Cells("TkClPh").Value
                StruGrdTk.Ph2 = GrdTick.CurrentRow.Cells("TkClPh1").Value.ToString
                StruGrdTk.DtStrt = GrdTick.CurrentRow.Cells("TkDtStart").Value
                StruGrdTk.ClNm = GrdTick.CurrentRow.Cells("TkClNm").Value
                StruGrdTk.Adress = GrdTick.CurrentRow.Cells("TkClAdr").Value.ToString
                StruGrdTk.Email = GrdTick.CurrentRow.Cells("TkMail").Value.ToString
                StruGrdTk.Detls = GrdTick.CurrentRow.Cells("TkDetails").Value.ToString
                StruGrdTk.Area = GrdTick.CurrentRow.Cells("OffArea").Value.ToString
                StruGrdTk.Offic = GrdTick.CurrentRow.Cells("OffNm1").Value.ToString
                StruGrdTk.ProdNm = GrdTick.CurrentRow.Cells("PrdNm").Value
                StruGrdTk.CompNm = GrdTick.CurrentRow.Cells("CompNm").Value
                StruGrdTk.Src = GrdTick.CurrentRow.Cells("SrcNm").Value
                StruGrdTk.Trck = GrdTick.CurrentRow.Cells("TkShpNo").Value.ToString
                StruGrdTk.Orig = GrdTick.CurrentRow.Cells("CounNmSender").Value.ToString
                StruGrdTk.Dist = GrdTick.CurrentRow.Cells("CounNmConsign").Value.ToString
                StruGrdTk.Card = GrdTick.CurrentRow.Cells("TkCardNo").Value.ToString
                StruGrdTk.Gp = GrdTick.CurrentRow.Cells("TkGBNo").Value.ToString
                StruGrdTk.NID = GrdTick.CurrentRow.Cells("TkClNtID").Value.ToString
                StruGrdTk.Amnt = GrdTick.CurrentRow.Cells("TkAmount").Value
                If DBNull.Value.Equals(GrdTick.CurrentRow.Cells("TkTransDate").Value) = False Then StruGrdTk.TransDt = GrdTick.CurrentRow.Cells("TkTransDate").Value
                StruGrdTk.UsrNm = GrdTick.CurrentRow.Cells("UsrRealNm").Value
                StruGrdTk.Help_ = GrdTick.CurrentRow.Cells("CompHelp").Value.ToString
                StruGrdTk.ProdK = GrdTick.CurrentRow.Cells("PrdKind").Value
                StruGrdTk.UserId = GrdTick.CurrentRow.Cells("TkEmpNm").Value

                StruGrdTk.LstUpDt = GrdTick.CurrentRow.Cells("تاريخ آخر تحديث").Value
                StruGrdTk.LstUpTxt = GrdTick.CurrentRow.Cells("نص آخر تحديث").Value
                StruGrdTk.LstUpUsrNm = GrdTick.CurrentRow.Cells("محرر آخر تحديث").Value
                StruGrdTk.LstUpEvId = GrdTick.CurrentRow.Cells("LastUpdateID").Value

                frm__ = GrdTick.FindForm
                gridview_ = GrdTick
            Catch ex As Exception
                Errmsg = ex.Message
            End Try
            Return Errmsg
        End Function
#End Region
        Public Function SndExchngMil(To_ As String, Optional Cc_ As String = "", Optional Bcc_ As String = "" _
                             , Optional Suj As String = "", Optional Body_ As String = "", Optional Import As Integer = 0) As String
            Dim MailRsult As String = Nothing

            Dim exchange As ExchangeService
            exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
            exchange.Credentials = New WebCredentials("egyptpost\voca-support", "asd_ASD123")
            exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
            Dim message As New EmailMessage(exchange)
            message.ToRecipients.Add(To_)
            If Cc_.Length > 0 Then message.CcRecipients.Add(Cc_)
            If Bcc_.Length > 0 Then message.BccRecipients.Add(Bcc_)
            message.Subject = Suj
            message.Body = Body_
            'message.Attachments.AddFileAttachment(AttchNam, AttchLction)
            'message.Attachments(0).ContentId = AttchNam
            message.Importance = Import
            Try
                message.SendAndSaveCopy()
            Catch ex As Exception
                MailRsult = "X"
            End Try
            Return MailRsult
        End Function
        Public Function SelctSerchTxt(richtxtbx As RichTextBox, Strng As String, Optional bL As Boolean = True) As String
            Dim HH As String = Nothing
            Try
                RemoveHandler richtxtbx.FindForm.Activated, AddressOf Frm_Activated
                AddHandler richtxtbx.FindForm.Activated, AddressOf Frm_Activated
                'richtxtbx = New RichTextBox
                Dim starttxt As Integer = 0
                Dim endtxt As Integer
                endtxt = richtxtbx.Text.LastIndexOf(Strng)
                'richtxtbx.SelectAll()
                'richtxtbx.SelectionBackColor = Color.White
                While starttxt < endtxt
                    If richtxtbx.Find(Strng, starttxt, richtxtbx.TextLength, RichTextBoxFinds.MatchCase) > 0 Then
                        If bL = False Then
                            richtxtbx.SelectionBackColor = Color.GreenYellow
                        Else
                            richtxtbx.SelectionBackColor = Color.Red
                            richtxtbx.SelectionColor = Color.Yellow
                            richtxtbx.SelectionFont = New Font("Times New Roman", 14, FontStyle.Bold)
                        End If

                    End If
                    starttxt += 1
                End While
            Catch ex As Exception
                HH = "X"
                MsgBox(ex.Message)
            End Try
            Return HH
        End Function
        Public Function ClorTxt(richtxtbx As RichTextBox, Strng As String, Clr As Color) As String
            Dim HH As String = Nothing
            Try
                'richtxtbx = New RichTextBox
                Dim starttxt As Integer = 0
                Dim endtxt As Integer
                endtxt = richtxtbx.Text.LastIndexOf(Strng)
                'richtxtbx.SelectAll()
                'richtxtbx.SelectionBackColor = Color.White
                While starttxt < endtxt
                    If richtxtbx.Find(Strng, starttxt, richtxtbx.TextLength, RichTextBoxFinds.MatchCase) > 0 Then
                        richtxtbx.SelectionColor = Clr
                        'richtxtbx.SelectionFont = New Font("Times New Roman", 14, FontStyle.Bold)
                    End If
                    starttxt += 1
                End While
            Catch ex As Exception
                HH = "X"
            End Try
            Return HH
        End Function
    End Class
End Class
