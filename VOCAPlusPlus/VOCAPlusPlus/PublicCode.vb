Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Net.Mail
Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions
Imports Microsoft.Exchange.WebServices.Data
Imports VOCAPlusPlus.Strc
Module PublicCode

    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX


#Region "Form Adjust"
    Dim Form_ As Form
    Dim BttonCtrl As Button
    Dim TxtBoxCtrl As TextBox
    Dim TabPg As New TabPage
    Dim DefCmStrip As ContextMenuStrip
    Dim TikCmStrip As ContextMenuStrip
    Dim UpdtCmStrip As ContextMenuStrip

    Dim CmStripCopy As New ToolStripMenuItem
    Dim CmStripPast As New ToolStripMenuItem
    Dim CmStripPrvw As New ToolStripMenuItem
    Dim CmStripUpVew As New ToolStripMenuItem
    Dim CmStripUpload As New ToolStripMenuItem
    Dim CmStripDwnload As New ToolStripMenuItem

    Dim CmstripItemTmp1 As New ToolStripMenuItem
    Dim CmstripItemTmp2 As New ToolStripMenuItem
    Dim CmstripItemTmp3 As New ToolStripMenuItem
#End Region

    Dim CtlCnt As Integer = 0
    Dim CTTTRL As Control
    Dim BacCtrl As Control
    Dim Slctd As Boolean = False
    Dim bolyy As Boolean = False
    Dim CompList As New List(Of String) 'list of tickets to get tickets updates

    Public Sub Frm_Activated(sender As Object, e As EventArgs)
        FrmAllSub(sender)
    End Sub
    Function OsIP() As String              'Returns the Ip address 
#Disable Warning BC40000 ' Type or member is obsolete
        OsIP = System.Net.Dns.GetHostByName("").AddressList(0).ToString()
#Enable Warning BC40000 ' Type or member is obsolete
    End Function
    Public Sub MsgInf(MsgBdy As String)
        MessageBox.Show(MsgBdy, "رسالة معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
    End Sub
    Public Sub MsgErr(MsgBdy As String)
        MessageBox.Show(MsgBdy, "رسالة خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
    End Sub
    Public Function GetMACAddressNew() As String
        Dim mc As ManagementClass = New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        Dim MACAddress As String = String.Empty
        For Each mo As ManagementObject In moc

            If (MACAddress.Equals(String.Empty)) Then
                If CBool(mo("IPEnabled")) Then MACAddress = mo("MacAddress").ToString()
                MACAddress = MACAddress.Replace(":", String.Empty)
                mo.Dispose()
            End If
        Next
        Return MACAddress
    End Function
    Public Sub DataExp(sQlfLNm As String)
        Dim XLApp As Microsoft.Office.Interop.Excel.Application
        Dim XLWrkBk As Microsoft.Office.Interop.Excel.Workbook
        Dim XLWrkSht As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim DtCol As String = "" 'رقم عمود التاريخ عشان اعمل الفورمات بتاعه

        Try                                                                                                       'Try If there is available Connection
            If ExpDTable.Rows.Count > 0 Then
                WelcomeScreen.StatBrPnlAr.Text = "جاري استخراج عدد " & ExpDTable.Rows.Count & " بيان"
                XLApp = New Microsoft.Office.Interop.Excel.Application
                XLWrkBk = XLApp.Workbooks.Add(misValue)
                XLWrkSht = XLWrkBk.Sheets("Sheet1")

                XLWrkBk.Title = ("VOCA Plus Auto Exported Data")
                XLWrkBk.Subject = ("Export Screen")
                XLWrkBk.Author = ("Ashraf Farag")
                XLWrkBk.Comments = ("VOCA+")

                'Set Signature
                XLWrkSht.Cells(1, 1) = "Powered By VOCA Plus"
                XLWrkSht.Cells(2, 1) = "Ashraf Farag"
                XLWrkSht.Cells(3, 1) = "'- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
                XLWrkSht.Rows("1:3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                XLWrkSht.Rows("1:3").Font.FontStyle = "Bold"
                XLWrkSht.Rows("1:1").font.color = Color.Red
                XLWrkSht.Rows("1:3").Font.Size = 12
                XLWrkSht.Rows("1:1").Font.Name = "Times New Roman"
                XLWrkSht.Rows("2:2").Font.Name = "Lucida Handwriting"
                XLWrkSht.Range(XLWrkSht.Cells(2, 1), XLWrkSht.Cells(2, ExpDTable.Columns.Count)).Font.Color = Color.Black
                'Set Merge Signature Cells
                XLWrkSht.Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(1, ExpDTable.Columns.Count)).Merge()
                XLWrkSht.Range(XLWrkSht.Cells(2, 1), XLWrkSht.Cells(2, ExpDTable.Columns.Count)).Merge()
                XLWrkSht.Range(XLWrkSht.Cells(3, 1), XLWrkSht.Cells(3, ExpDTable.Columns.Count)).Merge()

                'Format All Rang as Text Befor write Rows To Prevent data lose
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).NumberFormat = "0"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"

                For Col = 0 To ExpDTable.Columns.Count - 1    ' Header Colum
                    XLWrkSht.Cells(4, Col + 1) = ExpDTable.Columns(Col).ToString
                    If ExpDTable.Columns(Col).ToString.Contains("Date") Or ExpDTable.Columns(Col).ToString.Contains("تاريخ") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "yyyy/MM/dd" 'Date Columns
                    ElseIf ExpDTable.Columns(Col).ToString.Contains("تليفون") Or ExpDTable.Columns(Col).ToString.Contains("Phone") Or ExpDTable.Columns(Col).ToString.Contains("كارت") Or ExpDTable.Columns(Col).ToString.Contains("قومي") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "@" 'Date Columns
                    End If
                Next Col

                'Set Backcolor, Wrap Text, H Aligment, font name and font size for All Header
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Interior.Color = Color.FromArgb(0, 176, 80)
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Size = 14
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).WrapText = True
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                For Rws = 0 To ExpDTable.Rows.Count - 1
                    For Col = 0 To ExpDTable.Columns.Count - 1
                        XLWrkSht.Cells(Rws + 5, Col + 1) = ExpDTable.Rows(Rws).Item(Col).ToString
                    Next Col
                    WelcomeScreen.StatBrPnlAr.Text = "جاري استخراج عدد " & Rws + 1 & " من " & ExpDTable.Rows.Count
                    'GC.Collect()
                    'FlushMemory()
                Next Rws
                With XLWrkSht
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.Color = Color.Black
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic)
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).WrapText = False
                    .Cells.Columns.AutoFit()
                    '.Cells.EntireColumn.AutoFit()
                End With
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
                Distin = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile.MyDocuments) & "\" & sQlfLNm & "_" & Format(Now, "dd-MM-yyyy_HH_mm_ss") & ".xlsx"
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
                XLWrkSht.DisplayRightToLeft = True
                XLWrkSht.SaveAs(Distin)
                XLWrkBk.Close()
                XLApp.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLApp)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkBk)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkSht)
                WelcomeScreen.StatBrPnlAr.Text = "تم استخراج عدد " & ExpDTable.Rows.Count & " بيان إلى MyDocuments"
            Else
                WelcomeScreen.StatBrPnlAr.Text = "لا توجد بيانات لإستخراجها في المدة المحددة"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo End_
        End Try

        XLApp = Nothing
        XLWrkBk = Nothing
        XLWrkSht = Nothing
        FlushMemory()
        WelcomeScreen.StatBrPnlAr.Text = ""
End_:

    End Sub
    Function TrckNo(ByVal source As String) As String 'Extract Email Addresses From String
        Dim mc As MatchCollection
        Dim i As Integer
        Dim Emails As String = ""
        ' expression garnered from www.regexlib.com - thanks guys!
        mc = Regex.Matches(source, "([A-Z]+) ([0-9]+) ([A-Z])")

        '               "([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})"
        For i = 0 To mc.Count - 1
            Emails &= mc(i).Value & "; "
        Next
        Emails = Left(Emails, Emails.Length - 2)
        Return Emails
    End Function


    Public Function CompGrdTikFill(GrdTick As DataGridView, Tbl As DataTable, ProgBar As ProgressBar) As String
        Errmsg = Nothing
        Try
            GrdTick.DataSource = Tbl.DefaultView
            CompList = New List(Of String)
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
            For GG = 0 To GrdTick.Rows.Count - 1
                ProgBar.Value = GG + 1
                ProgBar.Refresh()
                CompList.Add("TkupTkSql = " & GrdTick.Rows(GG).Cells("TkSQL").Value)
            Next
            CompIds = String.Join(" OR ", CompList)
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
            Errmsg = ex.Message
        End Try
        ProgBar.Visible = False
        Return Errmsg
    End Function
    Public Function UpdateFormt(GridUpd As DataGridView, Optional StrTick As String = "") As String
        Errmsg = Nothing

        Try
            For Cnt_ = 0 To GridUpd.Rows.Count - 1
                If GridUpd.Rows(Cnt_).Cells("TkupUnread").Value = False Then                              'Read Status
                    GridUpd.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                End If
                GridUpd.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                If GridUpd.Rows(Cnt_).Cells("TkupEvtId").Value = 902 Then                             'Event Sys True
                    GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = Color.Red
                    GridUpd.Rows(Cnt_).DefaultCellStyle.ForeColor = Color.Yellow
                    GridUpd.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                ElseIf GridUpd.Rows(Cnt_).Cells("EvSusp").Value = True Then                             'Event Sys True
                    GridUpd.Rows(Cnt_).Cells("TkupReDt").Value = ""                                    'Read Date
                    GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrSys
                ElseIf StrTick <> "" Then
                    If GridUpd.Rows(Cnt_).Cells("TkupUser").Value = StrTick Then                        'Event UserId
                        GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrUsr
                    ElseIf GridUpd.Rows(Cnt_).Cells("TkupUser").Value <> StrTick Then                        'Event UserId
                        If GridUpd.Rows(Cnt_).Cells("UCatLvl").Value >= 3 And GridUpd.Rows(Cnt_).Cells("UCatLvl").Value <= 5 Then
                            GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrSamCat
                        ElseIf GridUpd.Rows(Cnt_).Cells("UCatLvl").Value = 12 Then
                            GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrOperation
                        Else
                            GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrNotUsr
                        End If
                    End If
                End If

                If Year(GridUpd.Rows(Cnt_).Cells("TkupReDt").Value) < 2000 Then
                    GridUpd.Rows(Cnt_).Cells("TkupReDt").Value = ""                                    'Read Date
                End If
            Next
            'TkupSTime, TkupTxt, UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread
            GridUpd.Columns("TkupSTime").DefaultCellStyle.Format = "dd/MM/yyyy ddd HH:mm"
            GridUpd.Columns("TkupSTime").HeaderText = "تاريخ التحديث"
            GridUpd.Columns("TkupTxt").HeaderText = "نص التحديث"
            GridUpd.Columns("UsrRealNm").HeaderText = "محرر التحديث"
            GridUpd.Columns("TkupReDt").HeaderText = "قراءة التحديث"
            GridUpd.Columns("TkupUser").Visible = False
            GridUpd.Columns("TkupSQL").Visible = False
            GridUpd.Columns("TkupTkSql").Visible = False
            GridUpd.Columns("TkupEvtId").Visible = False
            GridUpd.Columns("EvSusp").Visible = False
            GridUpd.Columns("UCatLvl").Visible = False
            GridUpd.Columns("TkupUnread").Visible = False
            GridUpd.AutoResizeColumns()
            GridUpd.Columns("TkupTxt").Width = GridUpd.Width - (GridUpd.Columns("TkupSTime").Width + GridUpd.Columns("UsrRealNm").Width + GridUpd.Columns("TkupReDt").Width + GridUpd.Columns("File").Width + 50)
            GridUpd.Columns("TkupTxt").DefaultCellStyle.WrapMode = DataGridViewTriState.True
            GridUpd.AutoResizeRows()
            GridUpd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            GridUpd.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            RemoveHandler GridUpd.FindForm.Activated, AddressOf Frm_Activated
            AddHandler GridUpd.FindForm.Activated, AddressOf Frm_Activated
        Catch ex As Exception
            Errmsg = ex.Message
        End Try
        Return Errmsg
    End Function
    Public Function TikFormat(TblTicket As DataTable, TblUpdt As DataTable, ProgBar As ProgressBar) As TickInfo ' Function to Adjust Ticket Gridview
        GridCuntRtrn = New TickInfo
        ProgBar.Visible = True
        For Rws = 0 To TblTicket.Rows.Count - 1
            GridCuntRtrn.TickCount += 1                                          'Grid record count
            ProgBar.Maximum = TblTicket.Rows.Count
            ProgBar.Value = GridCuntRtrn.TickCount
            ProgBar.Refresh()
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
    Public Sub SubGrdTikFill(GrdTick As DataGridView, Tbl As DataTable) 'To Delete Because The new one is "CompGrdTikFill"
        GrdTick.DataSource = Tbl
        If GrdTick.Columns(0).HeaderText <> "م" Then GrdTick.Columns.Insert(0, New DataGridViewTextBoxColumn())
        GrdTick.Columns(0).HeaderText = "م"
        GrdTick.Columns(0).Visible = False                                  '.HeaderText = "م"
        GrdTick.Columns(1).Visible = False                                 '.HeaderText = "SQL"
        GrdTick.Columns(2).Visible = False                                 '.HeaderText = "Product Kind"
        GrdTick.Columns(3).HeaderText = "تاريخ الشكوى"
        GrdTick.Columns(4).HeaderText = "رقم الشكوى"
        GrdTick.Columns(5).HeaderText = "مصدر الشكوى"
        GrdTick.Columns(6).HeaderText = "اسم العميل"
        GrdTick.Columns(7).HeaderText = "تليفون العميل1"
        GrdTick.Columns(8).HeaderText = "تليفون العميل2"
        GrdTick.Columns(9).Visible = False                                  '.HeaderText = "ايميل العميل"
        GrdTick.Columns(10).Visible = False                                 '.HeaderText = "عنوان العميل"
        GrdTick.Columns(11).HeaderText = "رقم الكارت"
        GrdTick.Columns(12).HeaderText = "رقم الشحنة"
        GrdTick.Columns(13).Visible = False                                 '.HeaderText = "رقم أمر الدقع"
        GrdTick.Columns(14).Visible = False                                 '.HeaderText = "الرقم القومي"
        GrdTick.Columns(15).Visible = False                                 '.HeaderText = "مبلغ العملية"
        GrdTick.Columns(16).Visible = False                                 '.HeaderText = "تاريخ العملية"
        GrdTick.Columns(17).Visible = False                                 '.HeaderText = "نوع المنتج"
        GrdTick.Columns(18).HeaderText = "نوع الخدمة"
        GrdTick.Columns(19).HeaderText = "نوع الشكوى"
        GrdTick.Columns(20).Visible = False                                 '.HeaderText = "بلد الراسل"
        GrdTick.Columns(21).Visible = False                                 '.HeaderText = "بلد المرسل إلية"
        GrdTick.Columns(22).HeaderText = "اسم المكتب"
        GrdTick.Columns(23).Visible = False                                 '.HeaderText = "اسم المنطقة"
        GrdTick.Columns(24).HeaderText = "تفاصيل الشكوى"
        GrdTick.Columns(25).Visible = False                                 '.HeaderText = "حالة الشكوى"
        GrdTick.Columns(26).Visible = False                                 '.HeaderText = "حالة المتابعة"
        GrdTick.Columns(27).Visible = False                                 '.HeaderText = "كود متابع الشكوى"
        GrdTick.Columns(28).HeaderText = "متابع الشكوى"
        GrdTick.Columns(29).Visible = False                                 '.HeaderText = "LstSqlEv"
        GrdTick.Columns(30).HeaderText = "تاريخ آخر تحديث"
        GrdTick.Columns(31).HeaderText = "نص آخر تحديث"
        GrdTick.Columns(32).Visible = False                                 '.HeaderText = "TkupUnread"
        GrdTick.Columns(33).Visible = False                                 '.HeaderText = "TkupEvtId"
        GrdTick.Columns(34).Visible = False                                 '.HeaderText = "EvNm"
        GrdTick.Columns(35).Visible = False                                 '.HeaderText = "EvSusp"
        GrdTick.Columns(36).HeaderText = "محرر آخر تحديث"                  '.HeaderText = "محرر اخر تحديث"
        GrdTick.Columns(37).Visible = False                                 '.HeaderText = "TkReOp"
        On Error Resume Next
        GrdTick.Columns(38).Visible = False                                 'Columns(16) "تاريخ استلام الشكوى"
        GrdTick.Columns(39).Visible = False                                 'Columns(36) عدد المتابعات
        GrdTick.Columns(40).Visible = False                                 ' نوع المنتج
        GrdTick.Columns(41).Visible = False
        GrdTick.Columns(42).Visible = False

        GrdTick.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        GrdTick.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GrdTick.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
        'GrdTick.AutoResizeColumns()
        GrdTick.Columns(24).Width = 400
        GrdTick.Columns(31).Width = 400
        GrdTick.Columns(24).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        GrdTick.Columns(31).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'GrdTick.AutoResizeRows()
        GrdTick.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrdTick.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
    End Sub
    Public Sub GrdTikFill(GrdTick As DataGridView, Tbl As DataTable)
        GrdTick.DataSource = Tbl
        'If GrdTick.Columns(0).HeaderText <> "م" Then GrdTick.Columns.Insert(0, New DataGridViewTextBoxColumn())

        GrdTick.Columns(0).HeaderText = "م"
        GrdTick.Columns(1).Visible = False                                 '.HeaderText = "SQL"
        GrdTick.Columns(2).Visible = False                                 '.HeaderText = "Product Kind"
        GrdTick.Columns(3).HeaderText = "تاريخ الشكوى"
        GrdTick.Columns(4).HeaderText = "رقم الشكوى"
        GrdTick.Columns(5).HeaderText = "مصدر الشكوى"
        GrdTick.Columns(6).HeaderText = "اسم العميل"
        GrdTick.Columns(7).HeaderText = "تليفون العميل1"
        GrdTick.Columns(8).HeaderText = "تليفون العميل2"
        GrdTick.Columns(9).Visible = False                                  '.HeaderText = "ايميل العميل"
        GrdTick.Columns(10).Visible = False                                 '.HeaderText = "عنوان العميل"
        GrdTick.Columns(11).HeaderText = "رقم الكارت"
        GrdTick.Columns(12).HeaderText = "رقم الشحنة"
        GrdTick.Columns(13).Visible = False                                 '.HeaderText = "رقم أمر الدقع"
        GrdTick.Columns(14).Visible = False                                 '.HeaderText = "الرقم القومي"
        GrdTick.Columns(15).Visible = False                                 '.HeaderText = "مبلغ العملية"
        GrdTick.Columns(16).Visible = False                                 '.HeaderText = "تاريخ العملية"
        GrdTick.Columns(17).Visible = False                                 '.HeaderText = "نوع المنتج"
        GrdTick.Columns(18).HeaderText = "نوع الخدمة"
        GrdTick.Columns(19).HeaderText = "نوع الشكوى"
        GrdTick.Columns(20).Visible = False                                 '.HeaderText = "بلد الراسل"
        GrdTick.Columns(21).Visible = False                                 '.HeaderText = "بلد المرسل إلية"
        GrdTick.Columns(22).HeaderText = "اسم المكتب"
        GrdTick.Columns(23).Visible = False                                 '.HeaderText = "اسم المنطقة"
        GrdTick.Columns(24).HeaderText = "تفاصيل الشكوى"
        GrdTick.Columns(25).Visible = False                                 '.HeaderText = "حالة الشكوى"
        GrdTick.Columns(26).Visible = False                                 '.HeaderText = "حالة المتابعة"
        GrdTick.Columns(27).Visible = False                                 '.HeaderText = "كود متابع الشكوى"
        GrdTick.Columns(28).HeaderText = "متابع الشكوى"
        GrdTick.Columns(29).Visible = False                                 '.HeaderText = "LstSqlEv"
        GrdTick.Columns(30).HeaderText = "تاريخ آخر تحديث"
        GrdTick.Columns(31).HeaderText = "نص آخر تحديث"
        GrdTick.Columns(32).Visible = False                                 '.HeaderText = "TkupUnread"
        GrdTick.Columns(33).Visible = False                                 '.HeaderText = "TkupEvtId"
        GrdTick.Columns(34).Visible = False                                 '.HeaderText = "EvNm"
        GrdTick.Columns(35).Visible = False                                 '.HeaderText = "EvSusp"
        GrdTick.Columns(36).Visible = False                                 '.HeaderText = "TkupUser"
        GrdTick.Columns(37).Visible = False                                 '.HeaderText = "TkReOp"
        GrdTick.Columns(38).Visible = False                                 '.HeaderText = "TkRecieveDt"
        GrdTick.Columns(39).HeaderText = "محرر التحديث"
        GrdTick.Columns(40).Visible = False                                 '.HeaderText = "UpdtUserLvl"
        GrdTick.Columns(41).Visible = False                                 '.HeaderText = "UpdtUserCase"
        GrdTick.Columns(42).Visible = False                                 '.HeaderText = "Help"

        GrdTick.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        GrdTick.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GrdTick.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
        GrdTick.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'GrdTick.AutoResizeColumns()
        'GrdTick.Columns(24).Width = 400
        'GrdTick.Columns(31).Width = 400
        GrdTick.Columns(24).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        GrdTick.Columns(31).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'GrdTick.AutoResizeRows()

        'GrdTick.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
    End Sub
    Public Function FncGrdCurrRow(GrdTicket As DataGridView, CurRw As Integer) As TickFld
        StruGrdTk.Ser = GrdTicket.Rows(CurRw).Cells(0).Value
        StruGrdTk.Sql = GrdTicket.Rows(CurRw).Cells(1).Value
        StruGrdTk.Tick = GrdTicket.Rows(CurRw).Cells(2).Value
        StruGrdTk.DtStrt = GrdTicket.Rows(CurRw).Cells(3).Value
        StruGrdTk.TkId = GrdTicket.Rows(CurRw).Cells(4).Value
        StruGrdTk.Src = GrdTicket.Rows(CurRw).Cells(5).Value
        StruGrdTk.ClNm = GrdTicket.Rows(CurRw).Cells(6).Value
        StruGrdTk.Ph1 = GrdTicket.Rows(CurRw).Cells(7).Value
        StruGrdTk.Ph2 = GrdTicket.Rows(CurRw).Cells(8).Value.ToString
        StruGrdTk.Email = GrdTicket.Rows(CurRw).Cells(9).Value.ToString
        StruGrdTk.Adress = GrdTicket.Rows(CurRw).Cells(10).Value.ToString
        StruGrdTk.Card = GrdTicket.Rows(CurRw).Cells(11).Value.ToString
        StruGrdTk.Trck = GrdTicket.Rows(CurRw).Cells(12).Value.ToString
        StruGrdTk.Gp = GrdTicket.Rows(CurRw).Cells(13).Value.ToString
        StruGrdTk.NID = GrdTicket.Rows(CurRw).Cells(14).Value.ToString
        StruGrdTk.Amnt = GrdTicket.Rows(CurRw).Cells(15).Value.ToString
        If DBNull.Value.Equals(GrdTicket.Rows(CurRw).Cells(16).Value) = False Then StruGrdTk.TransDt = GrdTicket.Rows(CurRw).Cells(16).Value
        StruGrdTk.ProdK = GrdTicket.Rows(CurRw).Cells(17).Value.ToString
        StruGrdTk.ProdNm = GrdTicket.Rows(CurRw).Cells(18).Value.ToString
        StruGrdTk.CompNm = GrdTicket.Rows(CurRw).Cells(19).Value.ToString
        StruGrdTk.Orig = GrdTicket.Rows(CurRw).Cells(20).Value.ToString
        StruGrdTk.Dist = GrdTicket.Rows(CurRw).Cells(21).Value.ToString
        StruGrdTk.Offic = GrdTicket.Rows(CurRw).Cells(22).Value.ToString
        StruGrdTk.Area = GrdTicket.Rows(CurRw).Cells(23).Value.ToString
        StruGrdTk.Detls = GrdTicket.Rows(CurRw).Cells(24).Value.ToString
        StruGrdTk.ClsStat = GrdTicket.Rows(CurRw).Cells(25).Value
        StruGrdTk.FlwStat = GrdTicket.Rows(CurRw).Cells(26).Value
        'If GrdTicket.Rows(CurRw).Cells(27).Value.ToString IsNot Nothing Then StruGrdTk.UserId = GrdTicket.Rows(CurRw).Cells(27).Value
        If DBNull.Value.Equals(GrdTicket.Rows(CurRw).Cells(27).Value) = False Then
            StruGrdTk.UserId = GrdTicket.Rows(CurRw).Cells(27).Value
        End If
        StruGrdTk.UsrNm = GrdTicket.Rows(CurRw).Cells(28).Value.ToString
        StruGrdTk.LstUpSql = GrdTicket.Rows(CurRw).Cells(29).Value
        'StruGrdTk.LstUpDt = GrdTicket.Rows(CurRw).Cells(30).Value
        StruGrdTk.LstUpTxt = GrdTicket.Rows(CurRw).Cells(31).Value
        StruGrdTk.LstUpUnRd = GrdTicket.Rows(CurRw).Cells(32).Value
        StruGrdTk.LstUpEvId = GrdTicket.Rows(CurRw).Cells(33).Value
        StruGrdTk.LstUpEnNm = GrdTicket.Rows(CurRw).Cells(34).Value
        StruGrdTk.LstUpSys = GrdTicket.Rows(CurRw).Cells(35).Value
        StruGrdTk.LstUpUsrNm = GrdTicket.Rows(CurRw).Cells(36).Value.ToString
        'On Error Resume Next
        On Error Resume Next
        If DBNull.Value.Equals(GrdTicket.Rows(CurRw).Cells(38).Value) = False Then StruGrdTk.RecvDt = GrdTicket.Rows(CurRw).Cells(38).Value
        StruGrdTk.EscCnt = GrdTicket.Rows(CurRw).Cells(39).Value
        StruGrdTk.PrdKNm = GrdTicket.Rows(CurRw).Cells(40).Value

        StruGrdTk.Help_ = GrdTicket.Rows(CurRw).Cells("CompHelp").Value.ToString
        Return StruGrdTk 'Return Grid Columns Structure
    End Function
    Public Function FncGrdTickInfo(GrdTicket As DataGridView) As TickInfo ' Function to Adjust Ticket Gridview
        GridCuntRtrn.TickCount = 0
        GridCuntRtrn.CompCount = 0
        GridCuntRtrn.NoFlwCount = 0
        GridCuntRtrn.UnReadCount = 0
        GridCuntRtrn.ClsCount = 0
        For Rws = 0 To GrdTicket.Rows.Count - 1
            GrdTicket.Rows(Rws).Cells(0).Value = Rws + 1                         'Set Grid Serial
            GridCuntRtrn.TickCount += 1                                          'Grid record count
            If GrdTicket.Rows(Rws).Cells(2).Value = True Then                    'if ticket kind is complaint
                GridCuntRtrn.CompCount += 1
            End If    'if Close Status is True                      if Ticket Kind is Complaint
            If GrdTicket.Rows(Rws).Cells(25).Value = True And GrdTicket.Rows(Rws).Cells(2).Value = True Then
                GridCuntRtrn.ClsCount += 1
            End If
            If GrdTicket.Rows(Rws).Cells(26).Value = False Then                   'if No Follow Status is True
                GridCuntRtrn.NoFlwCount += 1
            End If
            If GrdTicket.Rows(Rws).Cells(32).Value = False Then                   'if Read Status is false
                GridCuntRtrn.UnReadCount += 1
                GrdTicket.Rows(Rws).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
            End If
        Next
        GrdTicket.AutoResizeColumns()
        Return GridCuntRtrn 'Return Counters Structure
    End Function
    Public Sub UpGrgFrmt(GridUpd As DataGridView, Optional StrTick As String = "")     'UpGrgFrmt(GridUpdt, GridTicket)
        For Cnt_ = 0 To GridUpd.Rows.Count - 1
            If GridUpd.Rows(Cnt_).Cells(5).Value = True Then                             'Event Sys True
                GridUpd.Rows(Cnt_).Cells(8).Value = ""                                    'Read Date
                GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrSys
            ElseIf StrTick <> "" Then
                If GridUpd.Rows(Cnt_).Cells(4).Value = StrTick Then                        'Event UserId
                    If Year(GridUpd.Rows(Cnt_).Cells(8).Value) < 2000 Then
                        GridUpd.Rows(Cnt_).Cells(8).Value = ""                                  'Read Date
                    End If
                    GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrUsr
                ElseIf GridUpd.Rows(Cnt_).Cells(4).Value <> StrTick Then                        'Event UserId
                    If GridUpd.Rows(Cnt_).Cells(9).Value >= 3 And GridUpd.Rows(Cnt_).Cells(9).Value <= 5 Then
                        GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrSamCat
                    ElseIf GridUpd.Rows(Cnt_).Cells(9).Value = 12 Then
                        GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrOperation
                    Else
                        GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrNotUsr
                    End If
                End If
            End If
            If GridUpd.Rows(Cnt_).Cells(6).Value = False Then                              'Read Status
                If Year(GridUpd.Rows(Cnt_).Cells(8).Value) < 2000 Then
                    GridUpd.Rows(Cnt_).Cells(8).Value = ""                                    'Read Date
                End If
                GridUpd.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
            Else
                GridUpd.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
            End If

        Next
        GridUpd.Columns(0).Visible = False                                                'Event SQL
        GridUpd.Columns(1).HeaderText = "تاريخ التحديث"
        GridUpd.Columns(2).HeaderText = "نص التحديث"
        GridUpd.Columns(3).HeaderText = "محرر التحديث"
        GridUpd.Columns(4).Visible = False                                               'Event UserId
        GridUpd.Columns(5).Visible = False                                               'Event Sys True
        GridUpd.Columns(6).Visible = False                                               'Read Status
        GridUpd.Columns(7).Visible = False                                               'Ticket SQL Relation
        GridUpd.Columns(8).HeaderText = "قراءة التحديث"
        GridUpd.Columns(9).Visible = False                                               '.HeaderText = "UCatLvl"
        GridUpd.AutoResizeColumns()
        GridUpd.Columns(2).Width = 600
        GridUpd.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        GridUpd.AutoResizeRows()
        GridUpd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridUpd.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
    End Sub
    Public Function MyTeam(LedrCat As Integer, LedrId As Integer, UsrCas As String, Optional OnlyBckOff As Boolean = False) As String
        Dim Fn As New APblicClss.Func
        Dim UsrTable As DataTable = New DataTable
        Dim UsrStr As String = Nothing
        Dim BckOff As String = ""
        Dim TempNode() As TreeNode
        Dim TreeTemp As TreeView = New TreeView
        UsrTable.Rows.Clear()
        TreeTemp.Nodes.Clear()
        TreeTemp.Nodes.Add(LedrCat, LedrId)
        If OnlyBckOff = True Then
            BckOff = "AND (UCatLvl between 3 and 5)"
        End If
        UsrStr = UsrCas & " = " & Usr.PUsrID & " OR "
        'TkEmpNm
        '                   0  ,    1  ,     2     ***   
        If Fn.GetTblXX("Select UsrId, UCatId, UCatIdSub From Int_user RIGHT OUTER Join IntUserCat On UsrCat = UCatId Where (UsrSusp = 0) " & BckOff & " Order By UCatIdSub, UsrRealNm", UsrTable, "1048&H") = Nothing Then
            For Cnt_ = 0 To UsrTable.Rows.Count - 1
                TempNode = TreeTemp.Nodes.Find(UsrTable(Cnt_).Item(2).ToString, True)
                If TempNode.Length > 0 Then
                    TempNode(0).Nodes.Add(UsrTable(Cnt_).Item(1).ToString, UsrTable(Cnt_).Item(0).ToString)
                    UsrStr &= UsrCas & " = " & UsrTable(Cnt_).Item(0).ToString & " OR "
                End If
            Next Cnt_
            If UsrStr.Length > 0 Then UsrStr = "(" & Mid(UsrStr, 1, UsrStr.Length - 4) & ")" Else UsrStr = ""
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If

        Return UsrStr
    End Function
    Public Function GetAll(ByVal sender As Control) As IEnumerable(Of Control)
        Dim controls = sender.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(controls)
    End Function
    Public Sub FrmAllSub(Frm As Form)
        Form_ = Frm
        If Frm.Name <> "Login" Then
            Frm.Location = New Point(0, 52)
        End If
        'MsgBox(Frm.Name)
        Slctd = False
#Region "Default ContextMenuStrip"
        DefCmStrip = New ContextMenuStrip
        DefCmStrip.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        CmStripPast = New ToolStripMenuItem


        DefCmStrip.Items.Add(CmStripPast)

        CmStripPast.Image = My.Resources.Paste1

        CmStripPast.Text = "Paste"


        RemoveHandler CmStripPast.Click, AddressOf Paste_Click
        AddHandler CmStripPast.Click, AddressOf Paste_Click

#End Region

#Region "Ticket ContextMenuStrip"
        TikCmStrip = New ContextMenuStrip
        TikCmStrip.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        CmStripCopy = New ToolStripMenuItem
        CmStripPast = New ToolStripMenuItem
        CmStripPrvw = New ToolStripMenuItem



        TikCmStrip.Items.Add(CmStripCopy)
        TikCmStrip.Items.Add(CmStripPast)
        TikCmStrip.Items.Add(CmStripPrvw)
        TikCmStrip.Items.Add(CmStripUpVew)


        CmStripCopy.Image = My.Resources.Copy
        CmStripPast.Image = My.Resources.Paste1
        CmStripPrvw.Image = My.Resources.Preview
        CmStripUpVew.Image = My.Resources.Update



        CmStripCopy.Text = "Copy Selected Cell"
        CmStripPast.Text = "Paste"
        CmStripPrvw.Text = "Preview And Print"
        CmStripUpVew.Text = "Preview Updates"

        RemoveHandler CmStripCopy.Click, AddressOf CopySelectedToolStripMenuItem_Click_1
        RemoveHandler CmStripPast.Click, AddressOf Paste_Click
        RemoveHandler CmStripPrvw.Click, AddressOf PreviewTik_Click
        RemoveHandler CmStripUpVew.Click, AddressOf PreviewUpdt_Click

        AddHandler CmStripCopy.Click, AddressOf CopySelectedToolStripMenuItem_Click_1
        AddHandler CmStripPast.Click, AddressOf Paste_Click
        AddHandler CmStripPrvw.Click, AddressOf PreviewTik_Click
        AddHandler CmStripUpVew.Click, AddressOf PreviewUpdt_Click


#End Region
        Dim CTRLLst As New List(Of Control)
        GetAll(Frm).ToList.ForEach(Sub(c)
                                       CTRLLst.Add(c)
                                   End Sub)

        For UU = 0 To CTRLLst.Count - 1
            If TypeOf CTRLLst(UU) Is Button Then
                CalIfBtn(CTRLLst(UU))
            ElseIf TypeOf CTRLLst(UU) Is TextBox Then
                CalIfTxt(CTRLLst(UU))
            ElseIf TypeOf CTRLLst(UU) Is TextBox Then
                CalIfTxt(CTRLLst(UU))
            End If
            CmstripAsgn(CTRLLst(UU))
        Next
#Region ""
        'For Each CTTTRL In Frm.Controls


        '    If TypeOf CTTTRL Is TabControl Then
        '        For Each TabPg In CTTTRL.Controls
        '            For Each Crl In TabPg.Controls
        '                If TypeOf Crl Is FlowLayoutPanel Then
        '                    For Each C In Crl.Controls
        '                        If TypeOf C Is Button Then
        '                            BttonCtrl = C
        '                            CalIfBtn(BttonCtrl)
        '                        ElseIf TypeOf C Is TextBox Then
        '                            TxtBoxCtrl = C
        '                            CalIfTxt(TxtBoxCtrl)
        '                        ElseIf TypeOf C Is GroupBox Then
        '                            For Each CRLS In C.Controls
        '                                If TypeOf CRLS Is Button Then
        '                                    BttonCtrl = CRLS
        '                                    CalIfBtn(BttonCtrl)
        '                                ElseIf TypeOf CRLS Is TextBox Then
        '                                    TxtBoxCtrl = CRLS
        '                                    CalIfTxt(TxtBoxCtrl)
        '                                End If
        '                            Next
        '                        ElseIf TypeOf C Is FlowLayoutPanel Then
        '                            For Each CRLSA In C.Controls
        '                                If TypeOf CRLSA Is FlowLayoutPanel Then
        '                                    For Each H In CRLSA.Controls
        '                                        If TypeOf H Is Panel Then
        '                                            For Each V In H.Controls
        '                                                If TypeOf V Is Button Then
        '                                                    BttonCtrl = V
        '                                                    CalIfBtn(BttonCtrl)
        '                                                End If
        '                                            Next
        '                                        ElseIf TypeOf H Is FlowLayoutPanel Then
        '                                            For Each V In H.Controls
        '                                                If TypeOf V Is Panel Then
        '                                                    For Each VF In V.Controls
        '                                                        If TypeOf VF Is Button Then
        '                                                            BttonCtrl = VF
        '                                                            CalIfBtn(BttonCtrl)
        '                                                        End If
        '                                                    Next
        '                                                End If
        '                                            Next
        '                                        End If
        '                                    Next
        '                                ElseIf TypeOf CRLSA Is Panel Then
        '                                    For Each V In CRLSA.Controls
        '                                        If TypeOf V Is Button Then
        '                                            BttonCtrl = V
        '                                            CalIfBtn(BttonCtrl)
        '                                        End If
        '                                    Next
        '                                End If
        '                            Next CRLSA
        '                        End If
        '                        CmstripAsgn(C)
        '                    Next
        '                ElseIf TypeOf Crl Is Button Then
        '                    BttonCtrl = Crl
        '                    CalIfBtn(BttonCtrl)
        '                ElseIf TypeOf Crl Is TextBox Then
        '                    TxtBoxCtrl = Crl
        '                    CalIfTxt(TxtBoxCtrl)
        '                End If
        '                CmstripAsgn(Crl)
        '            Next
        '        Next
        '    ElseIf TypeOf CTTTRL Is FlowLayoutPanel Then
        '        For Each Crl In CTTTRL.Controls
        '            If TypeOf Crl Is Button Then
        '                BttonCtrl = Crl
        '                CalIfBtn(BttonCtrl)
        '            ElseIf TypeOf Crl Is TextBox Then
        '                TxtBoxCtrl = Crl
        '                CalIfTxt(TxtBoxCtrl)
        '            ElseIf TypeOf Crl Is GroupBox Then
        '                For Each C In Crl.Controls
        '                    If TypeOf C Is Button Then
        '                        BttonCtrl = C
        '                        CalIfBtn(BttonCtrl)
        '                    ElseIf TypeOf C Is TextBox Then
        '                        TxtBoxCtrl = C
        '                        CalIfTxt(TxtBoxCtrl)
        '                    End If
        '                Next
        '            ElseIf TypeOf Crl Is FlowLayoutPanel Then
        '                For Each C In Crl.Controls
        '                    If TypeOf C Is Panel Then
        '                        If TypeOf C Is Button Then
        '                            BttonCtrl = C
        '                            CalIfBtn(BttonCtrl)
        '                        ElseIf TypeOf C Is Panel Then
        '                            For Each D In C.Controls
        '                                If TypeOf D Is Button Then
        '                                    BttonCtrl = D
        '                                    CalIfBtn(BttonCtrl)
        '                                End If
        '                            Next
        '                        End If
        '                    End If
        '                Next
        '            ElseIf TypeOf Crl Is Panel Then
        '                For Each C In Crl.Controls
        '                    If TypeOf C Is Button Then
        '                        BttonCtrl = C
        '                        CalIfBtn(BttonCtrl)
        '                    End If
        '                Next
        '            End If
        '            CmstripAsgn(Crl)
        '        Next
        '    ElseIf TypeOf CTTTRL Is Button Then
        '        BttonCtrl = CTTTRL
        '        CalIfBtn(BttonCtrl)
        '    ElseIf TypeOf CTTTRL Is TextBox Then
        '        TxtBoxCtrl = CTTTRL
        '        CalIfTxt(TxtBoxCtrl)
        '    ElseIf TypeOf CTTTRL Is Panel Then
        '        For Each C In CTTTRL.Controls
        '            If TypeOf C Is Button Then
        '                BttonCtrl = C
        '                CalIfBtn(BttonCtrl)
        '            ElseIf TypeOf C Is TextBox Then
        '                TxtBoxCtrl = C
        '                CalIfTxt(TxtBoxCtrl)
        '            End If
        '        Next
        '    End If
        '    CmstripAsgn(CTTTRL)
        'Next
#End Region
        WelcomeScreen.StatBrPnlAr.Text = ""
    End Sub
    Public Function CmstripAsgn(Cnrol As Control) As Control
        If Cnrol.Name = "GridUpdt" Then
            If Cnrol.ContextMenuStrip IsNot Nothing Then
                Cnrol.ContextMenuStrip.Font = New Font("Times New Roman", 12, FontStyle.Regular)
            End If
        Else
            Cnrol.ContextMenuStrip = TikCmStrip
        End If
        RemoveHandler Cnrol.MouseEnter, AddressOf Ctrl_MouseEnter
        AddHandler Cnrol.MouseEnter, AddressOf Ctrl_MouseEnter
        Return Cnrol
    End Function
    Public Sub CalIfBtn(Btn As Button)
        VCtheme.BtnCtrl(Btn)
        RemoveHandler Btn.MouseEnter, (AddressOf Btn_MouseEnter)
        RemoveHandler Btn.MouseLeave, (AddressOf Btn_MouseLeave)
        AddHandler Btn.MouseEnter, (AddressOf Btn_MouseEnter)
        AddHandler Btn.MouseLeave, (AddressOf Btn_MouseLeave)
    End Sub
    Public Sub CalIfTxt(TxtBox As TextBox)
        RemoveHandler TxtBox.Click, (AddressOf TxtSlctOn_Click)
        AddHandler TxtBox.Click, (AddressOf TxtSlctOn_Click)
    End Sub
    Public Sub Ctrl_MouseEnter(sender As Object, e As EventArgs)
        If Slctd = False Then
            CTTTRL = sender
            BacCtrl = CTTTRL.Parent
            'CTTTRL.BringToFront()
            If TypeOf CTTTRL Is DataGridView Then
                CmStripPast.Enabled = False
                If CTTTRL.Name = "GridTicket" Then
                    CmStripPrvw.Enabled = True
                    CmStripUpVew.Enabled = True
                ElseIf CTTTRL.Name = "GridHeld" Then
                    CmStripPrvw.Enabled = False
                    CmStripUpVew.Enabled = False
                ElseIf CTTTRL.Name = "GridHeldUpdt" Then
                    CmStripPrvw.Enabled = False
                    CmStripUpVew.Enabled = False
                End If
            ElseIf TypeOf CTTTRL Is TextBox Or TypeOf CTTTRL Is MaskedTextBox Then
                CmStripPrvw.Enabled = False
                CmStripUpVew.Enabled = False
                CmStripPast.Enabled = True
            Else
                CmStripPrvw.Enabled = False
                CmStripUpVew.Enabled = False
                CmStripPast.Enabled = False
            End If
        End If
    End Sub
    Public Sub Btn_MouseEnter(sender As Object, e As EventArgs)
        Dim Botn As Button = sender
        BtnIncrease(Botn)
    End Sub
    Public Sub Btn_MouseLeave(sender As Object, e As EventArgs)
        Dim Botn As Control = sender
        BtnDecrease(Botn)
    End Sub
    Private Sub SndCntls(Ctrl As Control)
        If Ctrl.Dock = DockStyle.None Then
            Ctrl.ContextMenuStrip = DefCmStrip
            CtrlsTbl.Rows.Add()
            CtrlsTbl.Rows(CtlCnt).Item(1) = Form_.Name
            CtrlsTbl.Rows(CtlCnt).Item(2) = Ctrl.Name
            Dim Typ_ As Type = Ctrl.GetType
            CtrlsTbl.Rows(CtlCnt).Item(3) = Split(Typ_.ToString, ".")(3)
            CtrlsTbl.Rows(CtlCnt).Item(4) = Ctrl.Location.X
            CtrlsTbl.Rows(CtlCnt).Item(5) = Ctrl.Location.Y
            CtrlsTbl.Rows(CtlCnt).Item(6) = Ctrl.Font.SizeInPoints
            CtrlsTbl.Rows(CtlCnt).Item(7) = (Ctrl.Width)
            CtrlsTbl.Rows(CtlCnt).Item(8) = (Ctrl.Height)
            Dim rr As FlowLayoutPanel = Ctrl.Parent
            CtrlsTbl.Rows(CtlCnt).Item(9) = rr.Controls.GetChildIndex(Ctrl)
            CtrlsTbl.Rows(CtlCnt).Item(10) = Ctrl.Margin.Left
            CtrlsTbl.Rows(CtlCnt).Item(11) = Ctrl.Margin.Top
            CtrlsTbl.Rows(CtlCnt).Item(12) = Ctrl.Margin.Right
            CtrlsTbl.Rows(CtlCnt).Item(13) = Ctrl.Margin.Bottom
            CtrlsTbl.Rows(CtlCnt).Item(14) = rr.GetFlowBreak(Ctrl)
            CtlCnt += 1
        End If
    End Sub
    Private Sub CopySelectedToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Dim sms = (sender.GetCurrentParent()).SourceControl
        If TypeOf sms Is DataGridView Then
            Clipboard.SetText(sms.CurrentCell.Value)
        ElseIf TypeOf sms Is TextBox Or TypeOf sms Is MaskedTextBox Then
            Clipboard.SetText(sms.Text)
        End If
    End Sub
    Private Sub Paste_Click(sender As Object, e As EventArgs)
        Dim sms = (sender.GetCurrentParent()).SourceControl
        sms.Text = Clipboard.GetText()
    End Sub
    Private Sub PreviewTik_Click(sender As Object, e As EventArgs)
        Dim sms = sender.GetCurrentParent().SourceControl
        If sms.SelectedCells.Count > 0 Then
            TikIDRep_ = sms.CurrentRow.Cells("TkSQL").Value
            TikFrmRep.ShowDialog()
        Else
            MsgInf("برجاء اختيار الشكوى المراد عرضها أولاً")
        End If
    End Sub
    Private Sub PreviewUpdt_Click(sender As Object, e As EventArgs)
        'Dim hit As DataGridView.HitTestInfo = GridTicket.HitTest()
        Dim Fn As New APblicClss.Func
        Dim sms As DataGridView = sender.GetCurrentParent().SourceControl
        Dim smss = sms.Parent
        If sms.SelectedCells.Count > 0 Then

            If Fn.TikGVDblClck(sms) = Nothing Then
                TikUpdate.Text = "تحديثات شكوى رقم " & StruGrdTk.Sql
                TikUpdate.ShowDialog()
            Else
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & Errmsg)
            End If

        Else
            MsgInf("برجاء اختيار الشكوى المراد عرضها أولاً")
        End If
    End Sub
    Private Sub UpdtCtrl(UpdtCtrl As Control)
        Dim Fn As New APblicClss.Func
        Fn.InsUpdate("Update AUsrControls set UCtlX = " & UpdtCtrl.Location.X & ", UCtlY = " & UpdtCtrl.Location.Y & ", UCtlFntSize = " & UpdtCtrl.Font.Size & ", UCtlFntWidth = " & UpdtCtrl.Width & ", UCtlFntHeight = " & UpdtCtrl.Height &
             " Where UCtlUsrId = " & Usr.PUsrID & " AND UCtlFormName = '" & Form_.Name & "' AND UCtlControlName = '" & UpdtCtrl.Name & "'", "0000&H")
    End Sub
    Private Sub TxtSlctOn_Click(sender As Object, e As EventArgs)
        Dim TxtBox As TextBox = sender
        If bolyy = False Then
            bolyy = True
            TxtBox.SelectAll()
        Else
            bolyy = False
        End If
    End Sub
    Public Sub GettAttchUpdtesFils()
        Dim lol As String
        Dim arr() As String
        FTPTable.Rows.Clear()
        FTPTable.Columns.Clear()
        Dim colInt32 As New DataColumn("ID")
        colInt32.DataType = Type.GetType("System.Int32")
        FTPTable.Columns.Add(colInt32)
        FTPTable.Columns.Add("Name")
        FTPTable.Columns.Add("Date Modified")
        FTPTable.Columns.Add("Type")
        FTPTable.Columns.Add("Size")

        'UpdtCurrTbl
        Dim request As FtpWebRequest = WebRequest.Create("ftp://10.10.26.4/CompUpdates/")
        request.Credentials = New NetworkCredential("administrator", "Hemonad105046")
        request.Method = WebRequestMethods.Ftp.ListDirectoryDetails
        request.Timeout = 10000
        Try
            Dim response As FtpWebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            responseStream.ReadTimeout = 20000
            Dim reader As StreamReader = New StreamReader(responseStream)
            Do
                lol = reader.ReadLine
                If Len(lol) < 1 Then Exit Do
                arr = Split(lol, vbNewLine)
                For i = 0 To Split(lol, vbNewLine).Count - 1
                    If Len(arr(i)) > 0 Then
                        Dim FilNm As String = 0
                        Dim FileDt As DateTime = Split(Split(arr(i), " ")(0), "-")(1) & "/" & Split(Split(arr(i), " ")(0), "-")(0) & "/" & Split(Split(arr(i), " ")(0), "-")(2) & " " & Split(arr(i), " ")(2)
                        Dim FileType As String = ""
                        Dim INT_ As Integer = Nothing
                        Dim FilSize As Double = 0
                        Dim FilSize2 As String = ""

                        If Split(arr(i), " ").Count > 1 Then
                            INT_ = Split(arr(i), " ").Count - 1
                            If (Split(arr(i), " ")(9)) = "<DIR>" Then
                                FilNm = Trim(Split(arr(i), ">")(1))
                                FileType = "Folder"
                                FilSize = 0
                            ElseIf IsNumeric(Split(Trim(Mid(arr(i), 20, Len(arr(i)))), " ")(0)) = True Then
                                FilSize = Split(Trim(Mid(arr(i), 20, Len(arr(i)))), " ")(0)
                                FilNm = Mid(Trim(Mid(arr(i), 20, Len(arr(i)))), (FilSize).ToString.Length + 2)
                                FileType = "oooo"
                            End If
                            If FileType <> "Folder" Then
                                INT_ = Split(FilNm, ".").Count - 1
                                Dim tyrtr As String = Split(FilNm, ".")(INT_)
                                Select Case tyrtr
                                    Case "exe"
                                        FileType = "Application"
                                    Case "rar"
                                        FileType = "WinRAR archive"
                                    Case "xlsm"
                                        FileType = "Microsoft Excel Macro-Enabled Worksheet"
                                    Case "xlsx"
                                        FileType = "Microsoft Excel Worksheet"
                                    Case "jpg"
                                        FileType = "JPG File"
                                    Case "xls"
                                        FileType = "Microsoft Excel 97-2003"
                                    Case "pptx"
                                        FileType = "Microsoft PowerPoint Presentation"
                                    Case "accdb"
                                        FileType = "Microsoft Access"
                                    Case "doc"
                                        FileType = "Microsoft Word"
                                    Case "docx"
                                        FileType = "Microsoft Word"
                                    Case "csv"
                                        FileType = "Microsoft Excel Comma Separated Values File"
                                    Case "iso"
                                        FileType = "iso"
                                    Case "txt"
                                        FileType = "Text Document"
                                    Case "pdf"
                                        FileType = "PDF"
                                    Case "msg"
                                        FileType = "MSG File"
                                    Case "png"
                                        FileType = "PNG File"
                                    Case Else
                                        FileType = "Unknown"
                                End Select
                            End If
                            If FilSize > 0 Then
                                FilSize2 = (FilSize / 1024).ToString("N0") & " KB"
                            End If
                            FTPTable.Rows.Add(Split(FilNm, ".")(0), FilNm, FileDt, FileType, FilSize2)
                        End If
                    End If
                Next
            Loop
            request.Abort()
            reader.Close()
            response.Close()
            WelcomeScreen.StatBrPnlAr.Text = ""
        Catch ex As Exception
            WelcomeScreen.StatBrPnlAr.Text = "لم يتم تحميل قائمة المرفقات"
            request.Abort()
        End Try
    End Sub ' Attached Table
    Public Sub FlushMemory()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
    End Sub
    Public Sub CreateShortCut(ByVal TargetName As String, ByVal ShortCutPath As String, ByVal ShortCutName As String)
        Dim oShell As Object
        Dim oLink As Object
        'you don’t need to import anything in the project reference to create the Shell Object
        Try
            oShell = CreateObject("WScript.Shell")
            oLink = oShell.CreateShortcut(ShortCutPath & "\" & ShortCutName & ".lnk")

            oLink.TargetPath = TargetName
            oLink.WindowStyle = 1
            oLink.Save()
        Catch ex As Exception

        End Try
    End Sub
    Public Function GetParntCtrl(Contl As Control) As List(Of Control)
        Dim CtrlTree As New List(Of Control)
        Do
            If Nothing Is Contl.Parent Then
                Return CtrlTree
            Else
                Contl = Contl.Parent
            End If
            CtrlTree.Add(Contl)
        Loop
    End Function



End Module

