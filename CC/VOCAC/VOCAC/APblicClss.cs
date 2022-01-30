using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using VOCAC.BL;
using VOCAC.PL;
using VOCAC.Properties;

namespace VOCAC
{
    //Application Definitions With Current User Class Inheritance
    public class Statcdif
    {
        public static int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        public static int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        public static InputLanguage EnglishInput;
        public static InputLanguage ArabicInput;
        public static string strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlusDemo;Persist Security Info=True;User ID=vocac;Password=@VocaPlus$21-32223";
        public SqlConnection CONSQL;
        public static String _ServerCD;
        public static String _serverNm;
        public static string servrTime;
        public static String _MacStr, _IP;
        public static List<string> FildList = new List<string>();
        public static bool bolyy = false;
        public static bool CncStat;
        public static MenuStrip Menu_;
        public static ContextMenuStrip CntxMenu;
        #region DataTables
        public static DataTable MacTble, UserTable;
        public static TreeView _tree;
        public static DataTable CompSurceTable, ProdKTable, ProdCompTable, UpdateKTable, CDHolDay, MendFildsTable, TreeUsrTbl;
        #endregion
    }
    class menustrp
    {
        #region FormAdjust
        ContextMenuStrip DefCmStrip, TikCmStrip, UpdtCmStrip;
        ToolStripMenuItem CmStripCopy, CmStripPast, CmStripPrvw, CmStripUpVew, CmStripUpload, CmStripDwnload = new ToolStripMenuItem();
        ToolStripMenuItem CmstripItemTmp1, CmstripItemTmp2, CmstripItemTmp3 = new ToolStripMenuItem();
        #endregion
    }
    public class defintions
    {
        #region SQL_Definition

        public SqlDataReader reader;
        public SqlDataAdapter sqladptr;
        public SqlCommand SqlComm;
        #endregion
        public Thread thread_;
    }
    //Application Functions With Definitions Class Inheritance
    public sealed class function : Statcdif
    {
        private static readonly Lazy<function> fn = new Lazy<function>(() => new function());
        public static function getfn
        {
            get
            {
                return fn.Value;
            }
        }
        private function()
        {

        }
        public string ElapsedTimeSpan;
        public string ConStrFn()
        {
            strConn = null;
            WelcomeScreen WlcmScren = WelcomeScreen.getwecmscrnfrm;
            if (_ServerCD == "Eg Server")
            {
                Statcdif.strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocac;Password=@VocaPlus$21-32223";
                _serverNm = "VOCA Server";
                WlcmScren.BackgroundImage = Resources.VocaWtr;
                WlcmScren.BackgroundImageLayout = ImageLayout.Stretch;
                WlcmScren.BackColor = Color.FromArgb(192, 255, 192);
                WlcmScren.panellgin.BackColor = Color.FromArgb(192, 255, 192);
            }
            else if (_ServerCD == "Lab")
            {
                Statcdif.strConn = @"Data Source=MyThinkbook\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046";
                _serverNm = "Lab";
            }
            else if (_ServerCD == "Training")
            {
                Statcdif.strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlusDemo;Persist Security Info=True;User ID=vocac;Password=@VocaPlus$21-32223";
                _serverNm = "Training";
                WlcmScren.BackgroundImage = Resources.Empty;
                WlcmScren.BackColor = Color.White;
                WlcmScren.panellgin.BackColor = Color.White;
            }
            else if (_ServerCD == "servrMe")
            {
                Statcdif.strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlusashraf;Persist Security Info=True;User ID=vocac;Password=@VocaPlus$21-32223";
                _serverNm = "servrMe";
                WlcmScren.BackgroundImage = Resources.Demo;
                WlcmScren.BackgroundImageLayout = ImageLayout.Center;
                WlcmScren.BackColor = Color.White;
                WlcmScren.panellgin.BackColor = Color.White;
            }
            WlcmScren.LblSrvrNm.Text = Statcdif._ServerCD;
            try
            {
                CONSQL.ConnectionString = Statcdif.strConn;
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
            Statcdif defstac = new Statcdif();
            defstac.CONSQL = new SqlConnection(strConn);
            //if (defstac.CONSQL != null)
            //{
            if (defstac.CONSQL.State == ConnectionState.Closed)
            {
                try
                {
                    if (defstac.CONSQL.State == ConnectionState.Closed)
                    {
                        defstac.CONSQL.Open();
                        CncStat = true;
                    }
                }
                catch (SqlException Ex)
                {
                    CncStat = false;
                    AppLog("1002&H", Ex.Message, "Trying To Open Connection");
                }
            }
            else
            {
                CncStat = true;
            }
            defstac.CONSQL.Close();
            SqlConnection.ClearPool(defstac.CONSQL);
            return CncStat;
        }
        public string Gettable(String SSqlStr, DataTable SqlTbl, String ErrHndl)                             //Get Data and Fill DataTable
        {
            defintions def = new defintions();
            Statcdif defstac = new Statcdif();
            string Msg = null;
            Stopwatch Stp = new Stopwatch();
            defstac.CONSQL = new SqlConnection(strConn);
            def.sqladptr = new SqlDataAdapter(SSqlStr, defstac.CONSQL);
            Stp.Start();
            try
            {
                if (defstac.CONSQL.State == ConnectionState.Closed)
                {
                    defstac.CONSQL.Open();
                }
                def.sqladptr.Fill(SqlTbl);
                TimeSpan TimSpn = (Stp.Elapsed);
                Stp.Stop();
                this.ElapsedTimeSpan = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds);
            }
            catch (Exception Ex)
            {
                Msg = Ex.Message;
                AppLog(" ", Ex.Message, SSqlStr);
            }
            def.sqladptr.Dispose();
            defstac.CONSQL.Close();
            SqlConnection.ClearPool(defstac.CONSQL);
            return Msg;
        }
        public List<DataTable> Gettable(String SSqlStr, List<DataTable> LstDTbl, String ErrHndl)             //Get Data and Fill List of DataTable
        {
            defintions def = new defintions();
            Statcdif defstac = new Statcdif();
            Stopwatch Stp = new Stopwatch();
            defstac.CONSQL = new SqlConnection(strConn);
            Stp.Start();
            try
            {
                string[] Str = SSqlStr.Split('$');
                for (int i = 0; i < Str.Length - 1; i++)
                {
                    if (defstac.CONSQL.State == ConnectionState.Closed)
                    {
                        defstac.CONSQL.Open();
                    }
                    def.sqladptr = new SqlDataAdapter(Str[i], defstac.CONSQL);
                    DataTable dd = LstDTbl[i];
                    def.sqladptr.Fill(LstDTbl[i]);
                }
                TimeSpan TimSpn = (Stp.Elapsed);
                Stp.Stop();
                this.ElapsedTimeSpan = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds);
            }
            catch (Exception Ex)
            {
                AppLog(" ", Ex.Message, SSqlStr);
            }
            defstac.CONSQL.Close();
            SqlConnection.ClearPool(defstac.CONSQL);
            return LstDTbl;
        }
        public string InsUpdate(String SSqlStr, String ErrHndl)
        {
            defintions def = new defintions();
            Statcdif defstac = new Statcdif();
            string Errmsg = null;
            Stopwatch Stp = new Stopwatch();
            defstac.CONSQL = new SqlConnection(strConn);
            def.SqlComm = new SqlCommand(SSqlStr, defstac.CONSQL);
            def.SqlComm.CommandType = CommandType.Text;
            Stp.Start();
            try
            {
                if (defstac.CONSQL.State == ConnectionState.Closed)
                {
                    defstac.CONSQL.Open();
                }
                def.SqlComm.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Errmsg = Ex.Message;
                AppLog(" ", Ex.Message, SSqlStr);
            }
            def.SqlComm.Dispose();
            defstac.CONSQL.Close();
            SqlConnection.ClearPool(defstac.CONSQL);
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
                    break;
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
        public void SwitchBoard(DataTable dt)
        {
            WelcomeScreen Logfrm = new WelcomeScreen();

            Menu_ = new MenuStrip();
            CntxMenu = new ContextMenuStrip();
            DataTable SwichButTable = new DataTable();
            defintions Def = new defintions();

            SwichButTable = dt.Copy();
            dt.DefaultView.RowFilter = "(SwType = 'Tab') AND (SwNm <> 'NA')";
            DataTable tabTable = dt.DefaultView.ToTable();
            for (int i = 0; i < dt.DefaultView.Count; i++)
            {

                ToolStripMenuItem NewTab = new ToolStripMenuItem(tabTable.Rows[i].Field<string>("SwNm"));
                ToolStripMenuItem NewTabCx = new ToolStripMenuItem(tabTable.Rows[i].Field<string>("SwNm"));  //YYYYYYYYYYY

                if (CurrentUser.UsrLvl.ToString().Substring(tabTable.Rows[i].Field<int>("SwID") - 1, 1) == "A" ||
                    CurrentUser.UsrLvl.ToString().Substring(tabTable.Rows[i].Field<int>("SwID") - 1, 1) == "H")
                {
                    Menu_.Items.Add(NewTab);
                    CntxMenu.Items.Add(NewTabCx);                    //YYYYYYYYYYY

                    String Filtr_ = tabTable.Rows[i].Field<string>("SwSer");
                    SwichButTable.DefaultView.RowFilter = "(([SwType] <> '" + "Tab" + "') AND ([SwNm] <> '" + "NA" + "') AND ([SwSer] ='" + Filtr_ + "'))";
                    DataTable butTable = SwichButTable.DefaultView.ToTable();
                    for (int u = 0; u < SwichButTable.DefaultView.Count; u++)
                    {
                        ToolStripMenuItem subItem = new ToolStripMenuItem(butTable.Rows[u].Field<string>("SwNm").ToString());
                        ToolStripMenuItem subItemCx = new ToolStripMenuItem(butTable.Rows[u].Field<string>("SwNm").ToString());
                        if (CurrentUser.UsrLvl.ToString().Substring(butTable.Rows[u].Field<int>("SwID") - 1, 1) == "A")
                        {
                            if (butTable.Rows[u].Field<bool>("NewNew") == true)  // Populate Switchboard Button If form Added
                            {
                                subItem.Tag = butTable.Rows[u].Field<string>("SwObjNm1");
                                if (CurrentUser.UsrLvl.ToString().Substring(butTable.Rows[u].Field<int>("SwID") - 1, 1) == "A")
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
                                    subItemCx.Tag = butTable.Rows[u].Field<string>("SwObjNm1");
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
            dt.Dispose();
            SwichButTable.Dispose();
        }
        public void msg(string Messd, string titl, MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK, MessageBoxOptions messageBoxOptions = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign)
        {
            MessageBox.Show(Messd, titl, messageBoxButtons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, messageBoxOptions);
        }
        public int CalDate(string StDt, string EnDt)
        {
            Statcdif.CDHolDay.DefaultView.RowFilter = "HDate >= '" + StDt + "' and HDate <= '" + EnDt + "'";
            int Wdays = Statcdif.CDHolDay.DefaultView.Count;
            return Wdays;
        }
        public void ClorTxt(RichTextBox richtxtbx, String Strng, Color backClr, Color FontClr, int fontsize)
        {
            try
            {
                int starttxt = 0;
                int endtxt;
                endtxt = richtxtbx.Text.LastIndexOf(Strng);
                while (starttxt < endtxt)
                {
                    if (richtxtbx.Find(Strng, starttxt, richtxtbx.TextLength, RichTextBoxFinds.None) > 0)
                    {
                        richtxtbx.SelectionBackColor = backClr;
                        richtxtbx.SelectionColor = FontClr;
                        richtxtbx.SelectionFont = new Font("Times new Roman", fontsize, FontStyle.Bold);
                    }
                    starttxt += 1;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static bool validateNationalID(string NationalID)
        {
            try
            {
                string centery = NationalID.Substring(0, 1);
                string BirthDateS = "";
                if (centery == "2")
                    BirthDateS = "19";
                else if (centery == "3")
                    BirthDateS = "20";
                BirthDateS += NationalID.Substring(1, 2) + "/" + NationalID.Substring(3, 2) + "/" + NationalID.Substring(5, 2);

                try
                {
                    DateTime BithDateD = Convert.ToDateTime(BirthDateS);
                }
                catch
                {
                    return false;
                }

                SetGov();
                string NaIdGovCode = NationalID.Substring(7, 2);
                if (!GovCodeList.Contains(NaIdGovCode))
                    return false;

                string Factor = "2765432765432";
                int Total = 0;
                for (int i = 0; i < 13; i++)
                {
                    Total += int.Parse(Factor.Substring(i, 1)) * int.Parse(NationalID.Substring(i, 1));
                }
                int PreCode = Total % 11;
                int code = 11 - PreCode;
                if (code > 9)
                {
                    code = code - 10;
                }
                if (code != int.Parse(NationalID.Substring(13, 1)))
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static List<string> GovCodeList = new List<string>();
        private static void SetGov()
        {
            string[] arr = { "01","02","03","04","05","06","07","08","09","10","11","12","13","14","15","16","17","18","19","20"
            ,"21","22","23","24","25","26","27","28","29","30","31","32","33","34","35","88"};

            foreach (string item in arr)
            {
                GovCodeList.Add(item);
            }
        }
        public string exportxlsx(DataTable tbl, string filename)
        {
            string rslt = null;
            using (SaveFileDialog d = new SaveFileDialog())
            {
                d.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                d.Filter = "Excel File|*.xlsx";
                d.FilterIndex = 1;
                d.RestoreDirectory = true;
                d.Title = "Save Excel File";
                d.FileName = CurrentUser.UsrRlNm;
                if (d.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook Workbook = new XLWorkbook())
                    {
                        try
                        {
                            IXLWorksheet worksheet = Workbook.AddWorksheet(tbl, filename);
                            worksheet.Style.Alignment.WrapText = false;
                            Workbook.SaveAs(d.FileName);
                        }
                        catch (Exception ex)
                        {
                            rslt = ex.Message;
                        }
                    }
                }
            }
            return rslt;
        }
    }
    // Current User Class
    public static class CurrentUser
    {
        public static int UsrID = 0;          //UsrId
        public static int UsrCat;         //UsrCat
        public static String UsrNm;        //UsrNm
        public static String UsrPWrd;       //UsrPass
        public static String UsrLvl;      //UsrLevel
        public static String UsrRlNm;    //UsrRealNm
        public static String UsrMail;   //UsrEmail
        public static String UsrSisco;  //UsrSisco
        public static String UsrGsm;  //UsrMobile
        public static String UsrGndr;    //UsrGender
        public static Boolean UsrActv;   //UsrActive(Yes/No)
        public static DateTime UsrLstS;    //UsrLastSeen
        public static bool UsrSusp;   //UsrSusp(Yes/No)
        public static int UsrTcCnt;       //UsrTkCount
        public static String UsrSltKy;  //SaltKey
        public static String UsrCatNm;    //Catagory name
        public static Boolean UsrCalCntr;     //Call Center
        public static Int16 UsrUCatLvl;     //Close Count
        public static int UsrFlN;         //Follow Count
        public static int UsrClsN;    //Open Count
        public static int UsrReOpY;   //ReOpen Count
        public static int UsrUnRead;  //Read Count
        public static int UsrEvDy;    //Enent Count
        public static int UsrReadYDy;  //Read Count
        public static int UsrClsYDy;      //Close Count
        public static int UsrRecvDy;      //Recieved Count
        public static int UsrClsUpdtd;    //Closed updated Count
        public static int UsrFolwDay;     //Followed Tickets Count
        public static string UsrTeam;     //User Team Agents IDs 
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
                else if (c.GetType() == typeof(TextBox))
                {
                    this.CalIfTxt((TextBox)c);
                }
                else if (c.GetType() == typeof(MaskedTextBox))
                {
                    this.CalIfTxt((MaskedTextBox)c);
                }
            }
            //List<Control> ctrl1 = GetAll(frm, typeof(Button)).ToList();
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
        public void CalIfTxt(Control Txtbx)
        {
            if (Txtbx is MaskedTextBox)
            {
                MaskedTextBox TxtBox = (MaskedTextBox)Txtbx;
            }
            else
            {
                TextBox TxtBox = (TextBox)Txtbx;
            }

            Txtbx.Click -= new EventHandler(TxtSlctOn_Click);
            Txtbx.Click += new EventHandler(TxtSlctOn_Click);
            Txtbx.Enter -= new EventHandler(Text_Enter);
            Txtbx.Enter += new EventHandler(Text_Enter);
            Txtbx.KeyDown -= new KeyEventHandler(TxtBox_KeyDown);
            Txtbx.KeyDown += new KeyEventHandler(TxtBox_KeyDown);
        }
        private void TxtSlctOn_Click(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox TxtBox = (TextBox)sender;
                if (Statcdif.bolyy == false)
                {
                    Statcdif.bolyy = true;
                    TxtBox.SelectAll();
                }
                else
                    Statcdif.bolyy = false;
            }
            else if (sender is MaskedTextBox)
            {
                MaskedTextBox TxtBox = (MaskedTextBox)sender;
                if (Statcdif.bolyy == false)
                {
                    Statcdif.bolyy = true;
                    TxtBox.SelectAll();
                }
                else
                    Statcdif.bolyy = false;
            }
        }
        private void Text_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox TxtBox = (TextBox)sender;
                if (TxtBox.ReadOnly == false)
                {
                    if (TxtBox.Tag.ToString().Split('-')[0].Trim() == "English")
                    { InputLanguage.CurrentInputLanguage = Statcdif.EnglishInput; }            // Tansfer writing to English
                    else if (TxtBox.Tag.ToString().Split('-')[0].Trim() == "Arabic")
                    { InputLanguage.CurrentInputLanguage = Statcdif.ArabicInput; }
                }
            }
            else if (sender is MaskedTextBox)
            {
                MaskedTextBox TxtBox = (MaskedTextBox)sender;
                if (TxtBox.ReadOnly == false)
                {
                    if (TxtBox.Tag.ToString().Split('-')[0].Trim() == "English")
                    { InputLanguage.CurrentInputLanguage = Statcdif.EnglishInput; }            // Tansfer writing to English
                    else if (TxtBox.Tag.ToString().Split('-')[0].Trim() == "Arabic")
                    { InputLanguage.CurrentInputLanguage = Statcdif.ArabicInput; }
                }
            }
        }
        private void TxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox TxtBox = (TextBox)sender;
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    if (TxtBox.ReadOnly == false)
                    {
                        var ASDS = Clipboard.GetText();
                        TxtBox.Text += Clipboard.GetText();
                    }

                }
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
                {
                    if (TxtBox.Text.Trim().Length > 0)
                        Clipboard.SetText(TxtBox.Text);
                }
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.X)
                {
                    if (TxtBox.Text.Trim().Length > 0)
                        Clipboard.SetText(TxtBox.Text);
                    TxtBox.Text = "";
                }
                else
                {
                    TxtBox.KeyPress -= new KeyPressEventHandler(Txt_KeyPress);
                    TxtBox.KeyPress += new KeyPressEventHandler(Txt_KeyPress);
                }
            }
            else if (sender is MaskedTextBox)
            {
                MaskedTextBox TxtBox = (MaskedTextBox)sender;
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    //if (TxtBox.ReadOnly == false)
                    //TxtBox.Text = Clipboard.GetText();
                }
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
                {
                    //if (TxtBox.Text.Trim().Length > 0)
                    //Clipboard.SetText(TxtBox.Text);
                }
                else
                {
                    TxtBox.KeyPress -= new KeyPressEventHandler(Txt_KeyPress);
                    TxtBox.KeyPress += new KeyPressEventHandler(Txt_KeyPress);
                }
            }
        }
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox TxtBox = (TextBox)sender;
                if (TxtBox.ReadOnly == false)
                {
                    if (TxtBox.Tag.ToString().Split('-')[1].Trim() == "Number")
                        IntUtly.ValdtInt(e);
                    else if (TxtBox.Tag.ToString().Split('-')[1].Trim() == "Amount")
                        IntUtly.ValdtNumber(TxtBox, e);
                    else if (TxtBox.Tag.ToString().Split('-')[1].Trim() == "TextNumber")
                        IntUtly.ValdtIntLetter(e);
                    else if (TxtBox.Tag.ToString().Split('-')[1].Trim() == "Text")
                        IntUtly.ValdtLetter(TxtBox, e);
                    else if (TxtBox.Tag.ToString().Split('-')[1].Trim() == "All")
                    {
                        IntUtly.ValdtAll(e);
                    }
                }
            }
            else if (sender is MaskedTextBox)
            {
                MaskedTextBox TxtBox = (MaskedTextBox)sender;
                if (TxtBox.ReadOnly == false)
                {
                    if (TxtBox.Tag.ToString().Split('-')[1].Trim() == "Number")
                        IntUtly.ValdtInt(e);
                    else if (TxtBox.Tag.ToString().Split('-')[1].Trim() == "Amount")
                        IntUtly.ValdtNumber(TxtBox, e);
                    else if (TxtBox.Tag.ToString().Split('-')[1].Trim() == "TextNumber")
                        IntUtly.ValdtIntLetter(e);
                    else if (TxtBox.Tag.ToString().Split('-')[1].Trim() == "Text")
                        IntUtly.ValdtLetter(TxtBox, e);
                    else if (TxtBox.Tag.ToString().Split('-')[1].Trim() == "All")
                    {
                    }
                }
            }
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
            String formName = "VOCAC.PL." + _item.Tag;
            Form frm = (Form)Activator.CreateInstance(Type.GetType(formName));

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == frm.Name)
                {
                    f.BringToFront();
                    if (f.WindowState == FormWindowState.Minimized || f.WindowState == FormWindowState.Normal)
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                    }
                    return;
                }
            }
            frm.MdiParent = WelcomeScreen.ActiveForm;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }
        #endregion

        public static bool FormIsOpen(FormCollection application, Type formType)
        {
            //usage sample: FormIsOpen(Application.OpenForms,typeof(Form2)
            return Application.OpenForms.Cast<Form>().Any(openForm => openForm.GetType() == formType);
        }

    }
}

