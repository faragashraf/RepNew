using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using VOCAC.Properties;
using System.Drawing;
using System.Runtime.InteropServices;

namespace VOCAC
{
    //Application Definitions With Current User Class Inheritance
    public class defintions
    {
        public static int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        public static int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        public InputLanguage EnglishInput;
        public InputLanguage ArabicInput;
        #region SQL_Definition
        public static string strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocac;Password=Hemonad105046";
        public SqlConnection CONSQL;
        public SqlDataReader reader;
        public SqlDataAdapter sqladptr;
        public SqlCommand SqlComm;
        #endregion

        #region DataTables
        public static DataTable MacTble;
        public static DataTable UserTable;
        public static DataTable AreaTable;
        public static DataTable OfficeTable;
        public static DataTable CompSurceTable;
        public static DataTable CountryTable;
        public static DataTable ProdKTable;
        public static DataTable ProdCompTable;
        public static DataTable UpdateKTable;
        #endregion

        public string servrTime;
        public static String _ServerCD;
        public static String _serverNm;
        public static String _MacStr;
        public static bool CncStat;
        public static MenuStrip Menu_;
        public static ContextMenuStrip CntxMenu;
        public Thread thread_;

        #region FormAdjust

        ContextMenuStrip DefCmStrip;
        ContextMenuStrip TikCmStrip;
        ContextMenuStrip UpdtCmStrip;

        ToolStripMenuItem CmStripCopy = new ToolStripMenuItem();
        ToolStripMenuItem CmStripPast = new ToolStripMenuItem();
        ToolStripMenuItem CmStripPrvw = new ToolStripMenuItem();
        ToolStripMenuItem CmStripUpVew = new ToolStripMenuItem();
        ToolStripMenuItem CmStripUpload = new ToolStripMenuItem();
        ToolStripMenuItem CmStripDwnload = new ToolStripMenuItem();

        ToolStripMenuItem CmstripItemTmp1 = new ToolStripMenuItem();
        ToolStripMenuItem CmstripItemTmp2 = new ToolStripMenuItem();
        ToolStripMenuItem CmstripItemTmp3 = new ToolStripMenuItem();
        #endregion
    }
    //Application Functions With Definitions Class Inheritance
    public class function : defintions
    {
        public string ElapsedTimeSpan;
        public string ConStrFn()
        {
            strConn = null;
            if (_ServerCD == "Eg Server")
            {
                strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaenterprise;Password=@VocaPlus$21-7";
                _serverNm = "VOCA Server";
            }
            else if (_ServerCD == "My Labtop")
            {
                strConn = @"Data Source=MyThinkbook\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046";
                _serverNm = "My Labtop";
            }
            else if (_ServerCD == "Training")
            {
                strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlusDemo;Persist Security Info=True;User ID=vocaenterprise;Password=@VocaPlus$21-7";
                _serverNm = "Training";
            }
            else if (_ServerCD == "OnLine")
            {
                strConn = "Data Source=34.123.217.183;Initial Catalog=vocaplus;Persist Security Info=True;User ID=sqlserver;Password=Hemonad105046_Q";
                _serverNm = "OnLine";
            }
            try
            {
                CONSQL.ConnectionString = strConn;
                MacTble.Rows.Clear();
                if (Gettable("SELECT * from AMac WHERE Mac='" + _MacStr + "'", MacTble, "1000&H") == null)
                {
                    if (MacTble.Rows.Count > 0)
                    {
                    }
                }
            }
            catch (global::System.Exception ex)
            {
                AppLog("0000&H", ex.Message, "Conecting String");
            }
            return strConn;
        }
        public bool CheckConnection()                                                                        //Check Connection
        {
            defintions def = new defintions();
            def.CONSQL = new SqlConnection(defintions.strConn);
            if (def.CONSQL != null)
            {
                if (def.CONSQL.State == ConnectionState.Closed)
                {
                    try
                    {
                        def.CONSQL.Open();
                        CncStat = true;
                    }
                    catch (SqlException Ex)
                    {
                        CncStat = false;
                        AppLog("1002&H", Ex.Message, "Trying To Open Connection");
                    }
                }
                else
                {
                    CncStat = false;
                }
            }
            def.CONSQL.Close();
            SqlConnection.ClearPool(def.CONSQL);
            return CncStat;
        }
        public string Gettable(String SSqlStr, DataTable SqlTbl, String ErrHndl)                             //Get Data and Fill DataTable
        {
            defintions def = new defintions();
            string Msg = null;
            Stopwatch Stp = new Stopwatch();
            def.CONSQL = new SqlConnection(defintions.strConn);
            this.sqladptr = new SqlDataAdapter(SSqlStr, def.CONSQL);
            Stp.Start();
            try
            {
                if (def.CONSQL.State == ConnectionState.Closed)
                {
                    def.CONSQL.Open();
                }
                this.sqladptr.Fill(SqlTbl);
                TimeSpan TimSpn = (Stp.Elapsed);
                Stp.Stop();
                this.ElapsedTimeSpan = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds);
            }
            catch (Exception Ex)
            {
                Msg = Ex.Message;
                AppLog(" ", Ex.Message, SSqlStr);
            }
            def.CONSQL.Close();
            SqlConnection.ClearPool(def.CONSQL);
            return Msg;
        }
        public List<DataTable> Gettable(String SSqlStr, List<DataTable> LstDTbl, String ErrHndl)                             //Get Data and Fill List of DataTable
        {
            defintions def = new defintions();
            Stopwatch Stp = new Stopwatch();
            def.CONSQL = new SqlConnection(defintions.strConn);
            Stp.Start();
            try
            {
                string[] Str = SSqlStr.Split('$');
                for (int i = 0; i < Str.Length - 1; i++)
                {
                    if (def.CONSQL.State == ConnectionState.Closed)
                    {
                        def.CONSQL.Open();
                    }
                    this.sqladptr = new SqlDataAdapter(Str[i], def.CONSQL);
                    DataTable dd = LstDTbl[i];
                    this.sqladptr.Fill(LstDTbl[i]);
                }
                TimeSpan TimSpn = (Stp.Elapsed);
                Stp.Stop();
                this.ElapsedTimeSpan = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds);
            }
            catch (Exception Ex)
            {
                AppLog(" ", Ex.Message, SSqlStr);
            }
            def.CONSQL.Close();
            SqlConnection.ClearPool(def.CONSQL);
            return LstDTbl;
        }
        public string InsUpdate(String SSqlStr, String ErrHndl)
        {
            defintions def = new defintions();
            string Errmsg = null;
            Stopwatch Stp = new Stopwatch();
            def.CONSQL = new SqlConnection(defintions.strConn);
            def.SqlComm = new SqlCommand(SSqlStr, def.CONSQL);
            def.SqlComm.CommandType = CommandType.Text;
            Stp.Start();
            try
            {
                if (def.CONSQL.State == ConnectionState.Closed)
                {
                    def.CONSQL.Open();
                }
                def.SqlComm.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Errmsg = Ex.Message;
                AppLog(" ", Ex.Message, SSqlStr);
            }
            def.CONSQL.Close();
            SqlConnection.ClearPool(def.CONSQL);
            return Errmsg;
        }
        public string OsIP()                                                                                 //Get User IP Address
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            string address = localIPs.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).Select(_ip => _ip.ToString()).First();
            return address;
        }
        public string GetMACAddressNew()                                                                     //Get User MAC Address
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty && adapter.OperationalStatus == OperationalStatus.Up)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
        public string ServrTime()
        {

            DataTable TimeTbl = new DataTable();
            if (Gettable("Select GetDate() as Now_", TimeTbl, "1003&H") == null)
            {
                servrTime = TimeTbl.Rows[0].Field<DateTime>("Now_").ToString(); // TimeTbl.Rows[0].Field<DateTime>("Now_");
            }
            return servrTime;
        }
        public void AppLog(String ErrHndls, String LogMsg, String SSqlStrs)                                  //Insert Exception Into Log FIle
        {
            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VOCALog" + Convert.ToDateTime(DateTime.Now).ToString("MM-yy") + ".Vlg";
            string _content = DateTime.Now + " ," + ErrHndls + LogMsg + " &H" + SSqlStrs + Environment.NewLine;
            File.AppendAllText(_path, _content);
        }
        public void SwitchBoard()
        {
            WelcomeScreen Logfrm = new WelcomeScreen();

            Menu_ = new MenuStrip();
            CntxMenu = new ContextMenuStrip();
            DataTable SwichTabTable = new DataTable();
            DataTable SwichButTable = new DataTable();
            defintions Def = new defintions();

            if (Gettable("SELECT SwNm, SwSer, SwID, SwObjNew,SwObjNm, SwObjImg, SwType,NewNew FROM ASwitchboard ORDER BY SwID", SwichTabTable, "1004&H") == null)
            {
                SwichButTable = SwichTabTable.Copy();
                SwichTabTable.DefaultView.RowFilter = "(SwType = 'Tab') AND (SwNm <> 'NA')";
                DataTable tabTable = SwichTabTable.DefaultView.ToTable();
                for (int i = 0; i < SwichTabTable.DefaultView.Count - 1; i++)
                {

                    ToolStripMenuItem NewTab = new ToolStripMenuItem(tabTable.Rows[i].Field<string>("SwNm"));
                    ToolStripMenuItem NewTabCx = new ToolStripMenuItem(tabTable.Rows[i].Field<string>("SwNm"));  //YYYYYYYYYYY

                    if (CurrentUser.PUsrLvl.ToString().Substring(tabTable.Rows[i].Field<int>("SwID")-1, 1) == "A" ||
                        CurrentUser.PUsrLvl.ToString().Substring(tabTable.Rows[i].Field<int>("SwID")-1, 1) == "H")
                    {
                        Menu_.Items.Add(NewTab);
                        CntxMenu.Items.Add(NewTabCx);                    //YYYYYYYYYYY

                        String Filtr_ = tabTable.Rows[i].Field<string>("SwSer");
                        SwichButTable.DefaultView.RowFilter = "(([SwType] <> '" + "Tab" + "') AND ([SwNm] <> '" + "NA" + "') AND ([SwSer] ='" + Filtr_ + "'))";
                        DataTable butTable = SwichButTable.DefaultView.ToTable();
                        for (int u = 0; u < SwichButTable.DefaultView.Count - 1; u++)
                        {
                            ToolStripMenuItem subItem = new ToolStripMenuItem(butTable.Rows[u].Field<string>("SwNm").ToString());
                            ToolStripMenuItem subItemCx = new ToolStripMenuItem(butTable.Rows[u].Field<string>("SwNm").ToString());
                            if (CurrentUser.PUsrLvl.ToString().Substring(butTable.Rows[u].Field<int>("SwID"), 1) == "A" ||
                                CurrentUser.PUsrLvl.ToString().Substring(butTable.Rows[u].Field<int>("SwID"), 1) == "H")
                            {
                                if (butTable.Rows[u].Field<bool>("NewNew") == true)  // Populate Switchboard Button If form Added
                                {
                                    subItem.Tag = butTable.Rows[u].Field<string>("SwObjNm");
                                    if (CurrentUser.PUsrLvl.ToString().Substring(butTable.Rows[u].Field<int>("SwID"), 1) == "H")
                                    {
                                        subItem.AccessibleName = "True";
                                        subItemCx.AccessibleName = "True";
                                    }
                                    // Assign Icon To every Button
                                    if (DBNull.Value.Equals(butTable.Rows[u].Field<string>("SwObjImg")) == false)
                                    {
                                        ImageList imglst = new ImageList();
                                        //imglst = Login.ControlCollection["ImageList1"];
                                        Image Cnt_ = Logfrm.ImageList1.Images[butTable.Rows[u].Field<string>("SwObjImg")];
                                        //Image Cnt_ = (Image)Resources.ResourceManager.GetObject(butTable.Rows[u].Field<string>("SwObjImg"));
                                        subItem.Image = Cnt_;
                                        subItemCx.Image = Cnt_;
                                        subItemCx.Tag = butTable.Rows[u].Field<string>("SwObjNm");
                                        NewTab.DropDownItems.Add(subItem);
                                        NewTabCx.DropDownItems.Add(subItemCx);
                                        frms GG = new frms();
                                        subItem.Click += new System.EventHandler(GG.ClkEvntClick);
                                        subItemCx.Click += new System.EventHandler(GG.ClkEvntClick);
                                    }
                                }
                            }
                        }
                    }
                }
                SwichTabTable.Dispose();
                SwichButTable.Dispose();
            }



            //        Def.Str = " Menu has been builded  "
            //        worker.ReportProgress(0, Def)
            //        Def.Str = "جاري تحميل البيانات ..."
            //        worker.ReportProgress(0, Def)
            //        If Def.Str = "جاري تحميل البيانات ..." Then
            //            Dim primaryKey(0) As DataColumn
            //            AreaTable = New DataTable
            //            OfficeTable = New DataTable
            //            CompSurceTable = New DataTable
            //            CountryTable = New DataTable
            //            ProdKTable = New DataTable
            //            ProdCompTable = New DataTable
            //            UpdateKTable = New DataTable
            //            Def.Str = "جاري تحميل أسماء المناطق ..."
            //            worker.ReportProgress(0, Def)
            //            If(Fn.GetTbl("SELECT OffArea FROM PostOff GROUP BY OffArea ORDER BY OffArea;", AreaTable, "1012&H", worker)) = Nothing Then
            //               PrciTblCnt += 1
            //            Else
            //                Def.Str = "لم يتم تحميل  أسماء المناطق "
            //                worker.ReportProgress(0, Def)
            //            End If

            //            Def.Str = "جاري تحميل أسماء المكاتب ..."
            //            worker.ReportProgress(0, Def)

            //            If(Fn.GetTbl("select OffNm1, OffFinCd, OffArea from PostOff ORDER BY OffNm1;", OfficeTable, "1012&H", worker)) = Nothing Then
            //               PrciTblCnt += 1
            //            Else
            //                Def.Str = "لم يتم تحميل  أسماء المكاتب  "
            //                worker.ReportProgress(0, Def)
            //            End If



            //            Def.Str = "جاري تحميل مصادر الشكوى ..."
            //            worker.ReportProgress(0, Def)

            //            If(Fn.GetTbl("select SrcCd, SrcNm,SrcSusp from CDSrc ORDER BY SrcNm", CompSurceTable, "1012&H", worker)) = Nothing Then
            //               PrciTblCnt += 1
            //                If Usr.PUsrUCatLvl = 7 Then
            //                    CompSurceTable.DefaultView.RowFilter = "[SrcSusp] =" & 0 & " AND [srcCd] = '1'"     '     SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1 ORDER BY SrcNm"
            //                Else
            //                    CompSurceTable.DefaultView.RowFilter = "[SrcSusp] =" & 0 & " AND [srcCd] > '1'"   '   SrcStr = "Select SrcCd, SrcNm from CDSrc where SrcSusp=0 And srcCd > 1 ORDER BY SrcNm"
            //                End If
            //            Else
            //                Def.Str = "لم يتم تحميل  مصادر الشكوى  "
            //                worker.ReportProgress(0, Def)
            //            End If


            //            Def.Str = "جاري تحميل أسماء الدول ..."
            //            worker.ReportProgress(0, Def)

            //            If(Fn.GetTbl("Select CounCd,CounNm from CDCountry order by CounNm", CountryTable, "1012&H", worker)) = Nothing Then
            //                primaryKey(0) = CountryTable.Columns("CounCd")
            //                CountryTable.PrimaryKey = primaryKey
            //                PrciTblCnt += 1
            //            Else
            //                Def.Str = "لم يتم تحميل  أسماء الدول  "
            //                worker.ReportProgress(0, Def)
            //            End If


            //            Def.Str = "جاري تحميل أنواع الخدمات ..."
            //            worker.ReportProgress(0, Def)

            //            If(Fn.GetTbl("Select ProdKCd, ProdKNm, ProdKClr from CDProdK where ProdKSusp = 0 order by ProdKCd", ProdKTable, "1012&H", worker)) = Nothing Then
            //                primaryKey(0) = ProdKTable.Columns("ProdKNm")
            //                ProdKTable.PrimaryKey = primaryKey
            //                PrciTblCnt += 1
            //            Else
            //                Def.Str = "لم يتم تحميل  أنواع الخدمات "
            //                worker.ReportProgress(0, Def)
            //            End If


            //            Def.Str = "جاري تحميل أنواع المنتجات ..."
            //            worker.ReportProgress(0, Def)

            //            If(Fn.GetTbl("Select FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp,CompHlp,CompReqst FROM VwFnProd where FnSusp = 0 ORDER BY PrdKind, PrdNm, CompNm", ProdCompTable, "1012&H", worker)) = Nothing Then
            //                primaryKey(0) = ProdCompTable.Columns("FnSQL")
            //                ProdCompTable.PrimaryKey = primaryKey
            //                PrciTblCnt += 1
            //            Else
            //                Def.Str = "لم يتم تحميل أنواع المنتجات  "
            //                worker.ReportProgress(0, Def)
            //            End If

            //            Def.Str = "جاري تحميل أنواع التحديثات ..."
            //            worker.ReportProgress(0, Def)
            //            If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
            //                If(Fn.GetTbl("Select EvId, EvNm FROM CDEvent where EvSusp = 0 And EvBkOfic = 1 ORDER BY EvNm", UpdateKTable, "1012&H", worker)) = Nothing Then
            //                   PrciTblCnt += 1
            //                Else
            //                    Def.Str = "لم يتم تحميل  أنواع التحديثات "
            //                    worker.ReportProgress(0, Def)
            //                End If
            //            Else
            //                If(Fn.GetTbl("Select EvId, EvNm FROM CDEvent where EvSusp = 0 And EvBkOfic = 0 ORDER BY EvNm", UpdateKTable, "1012&H", worker)) = Nothing Then
            //                   PrciTblCnt += 1
            //                Else
            //                    Def.Str = " أنواع التحديثات / "
            //                    worker.ReportProgress(0, Def)
            //                End If
            //            End If
            //        End If

            //        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            //    Else
            //        worker.ReportProgress(0, Def)
            //        Fn.MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf)
            //    End If
        }
        public void msg(string Messd, string titl, MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK, MessageBoxOptions messageBoxOptions = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign)
        {
            MessageBox.Show(Messd, titl, messageBoxButtons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, messageBoxOptions);
        }
    }
    // Current User Class
    public static class CurrentUser
    {
        public static int PUsrID;          //UsrId
        public static int PUsrCat;         //UsrCat
        public static String PUsrNm;        //UsrNm
        public static String PUsrPWrd;       //UsrPass
        public static String PUsrLvl;      //UsrLevel
        public static String PUsrRlNm;    //UsrRealNm
        public static String PUsrMail;   //UsrEmail
        public static String PUsrSisco;  //UsrSisco
        public static String PUsrGsm;  //UsrMobile
        public static String PUsrGndr;    //UsrGender
        public static Boolean PUsrActv;   //UsrActive(Yes/No)
        public static DateTime PUsrLstS;    //UsrLastSeen
        public static bool PUsrSusp;   //UsrSusp(Yes/No)
        public static int PUsrTcCnt;       //UsrTkCount
        public static String PUsrSltKy;  //SaltKey
        public static String PUsrCatNm;    //Catagory name
        public static Boolean PUsrCalCntr;     //Call Center
        public static Int16 PUsrUCatLvl;     //Close Count
        public static int PUsrFlN;         //Follow Count
        public static int PUsrClsN;    //Open Count
        public static int PUsrReOpY;   //ReOpen Count
        public static int PUsrUnRead;  //Read Count
        public static int PUsrEvDy;    //Enent Count
        public static int PUsrReadYDy;  //Read Count
        public static int PUsrClsYDy;      //Close Count
        public static int PUsrRecvDy;      //Recieved Count
        public static int PUsrClsUpdtd;    //Closed updated Count
        public static int PUsrFolwDay;     //Followed Tickets Count
    }
    public class frms
    {
        //Return All any form control
        public IEnumerable<Control> GetAll(Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls);
        }
        //Return All any form control where exact type condition
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        public void FrmAllSub(Form frm)
        {
            List<Control> ctrl = GetAll(frm).ToList();

            foreach (Control c in ctrl)
            {
                if (c.GetType() == typeof(Button))
                {
                    this.CalIfBtn((Button)c);
                }
                //else if (c.GetType() == typeof(TextBox))
                //{
                //    this.CalIfTxt((TextBox)c);
                //}
            }
            List<Control> ctrl1 = GetAll(frm, typeof(Button)).ToList();
        }
        #region Events         
        //format button void and assign Events
        public void CalIfBtn(Button Btn)
        {
            VCtheme.BtnCtrl(Btn); //format Button Style
            Btn.MouseEnter -= new EventHandler(Btn_MouseEnter);
            Btn.MouseLeave -= new EventHandler(Btn_MouseLeave);

            Btn.MouseEnter += new EventHandler(Btn_MouseEnter);
            Btn.MouseLeave += new EventHandler(Btn_MouseLeave);
        }
        public void CalIfTxt(TextBox Txtbx)
        {

        }
        //Increase Button Size on Mouse Enter Event
        public void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button Botn = (Button)sender;
            VCtheme.BtnIncrease(Botn);
        }
        //Dicrease Button Size on Mouse Leave Event
        public void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button Botn = (Button)sender;
            VCtheme.BtnDecrease(Botn);
        }
        //Event To Open All Forms
        public void ClkEvntClick(object sender, EventArgs e)
        {
            ToolStripMenuItem _item = (ToolStripMenuItem)sender;
            String formName = "VOCAC." + _item.Tag;
            Form frm = (Form)Activator.CreateInstance(Type.GetType(formName));
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == frm.Name)
                {
                    frm.BringToFront();
                    if (frm.WindowState == FormWindowState.Minimized || frm.WindowState == FormWindowState.Normal)
                    {
                        f.WindowState = FormWindowState.Maximized;
                        f.BringToFront();
                    }
                    return;
                }
            }
            frm.MdiParent = WelcomeScreen.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        #endregion
    }
}

