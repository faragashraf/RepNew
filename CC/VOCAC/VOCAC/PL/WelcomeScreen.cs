using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAC.Properties;

namespace VOCAC.PL
{
    public delegate void delagatethread();
    public partial class WelcomeScreen : Form
    {
        List<DataTable> DtblClction = new List<DataTable>();
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        private string Ver = null;
        private static WelcomeScreen frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
            frm.Dispose();
        }
        public static WelcomeScreen getwecmscrnfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new WelcomeScreen();
                    frm.FormClosed += new FormClosedEventHandler(frm_Closed);
                }
                return frm;
            }
        }
        public WelcomeScreen()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
            this.LblClrSys.BackColor = Settings.Default.ClrSys;
            this.LblClrUsr.BackColor = Settings.Default.ClrUsr;
            this.LblClrSamCat.BackColor = Settings.Default.ClrSamCat;
            this.LblClrNotUsr.BackColor = Settings.Default.ClrNotUsr;
            this.LblClrOperation.BackColor = Settings.Default.ClrOperation;

            Label1.Text = "Welcome TO VOCA Enterprise" + Environment.NewLine + "Our Mini CRM";
            function fn = function.getfn;
            Statcdif._IP = fn.OsIP();
            LblUsrIP.Text = "IP: " + Statcdif._IP;
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                Ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
                PubVerLbl.Text = "Ver. : " + Ver;
                PubVerLbl1.Text = "Ver. : " + Ver;
            }
            else
            {
                Ver = "Publish version";
                PubVerLbl.Text = "Publish Ver. : This isn't a Publish version";
                PubVerLbl1.Text = "Publish Ver. : This isn't a Publish version";
            }

            Cmbo.Items.Add("Eg Server");
            Cmbo.Items.Add("My Labtop");
            Cmbo.Items.Add("Training");
            //Cmbo.Items.Add("OnLine");

            Statcdif.servrTime = fn.ServrTime();
        }
        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            MdiClient Mdiclnt;
            foreach (Control ctrl in this.Controls)
            {
                try
                {
                    Mdiclnt = (MdiClient)ctrl;
                    Mdiclnt.BackColor = Color.White;
                }
                catch (Exception)
                {
                    //Ignore Cast Error
                }
            }
            frms forms = new frms();
            forms.FrmAllSub(this);
            function fn = function.getfn;
            //intialize Languges
            foreach (InputLanguage langu in InputLanguage.InstalledInputLanguages)
            {
                if (langu.Culture.TwoLetterISOLanguageName == "ar")
                {
                    Statcdif.ArabicInput = langu;
                }
                else if (langu.Culture.TwoLetterISOLanguageName == "en")
                {
                    Statcdif.ArabicInput = langu;
                }
            }
            //initialize Lables

            Statcdif._MacStr = fn.GetMACAddressNew();
            Statcdif._IP = fn.OsIP();
            TxtUsrNm.Select();
            TxtUsrNm.Text = "otp";
            TxtUsrPass.Text = "Ahmed2220";

            Cmbo.SelectedItem = "Eg Server";
            Statcdif._ServerCD = Cmbo.SelectedItem.ToString();
            this.Cmbo.SelectedIndexChanged += new System.EventHandler(this.Cmbo_SelectedIndexChanged);

            //defintions def = new defintions();
            //def.thread_ = new Thread(Chckcont);
            //def.thread_.IsBackground = true;
            //def.thread_.Start();
        }
        private void LogInBtn_Click(object sender, EventArgs e)
        {
            Log();
        }
        public string SQLSTR;
        private void Log()
        {
            function fn = function.getfn;

            LogInBtn.Enabled = false;
            StatBrPnlEn.Text = "Connecting ...........";
            LblLogin.Text = "          Authenticating";
            LblLogin.Image = Resources.Info;
            LblLogin.ForeColor = Color.Blue;
            this.Refresh();

            DAL.DataAccessLayer.rturnStruct logreslt = log.LOGIN(TxtUsrNm.Text, TxtUsrPass.Text);
            if (logreslt.msg == null)
            {
                if (logreslt.dt.Rows.Count > 0)
                {
                    Statcdif.UserTable = logreslt.dt;
                    IntializeUser();
                    DAL.DataAccessLayer.rturnStruct Accesslogreslt = log.UsrUpdate(Statcdif._IP, Ver, CurrentUser.UsrID);
                    DAL.DataAccessLayer.rturnStruct Updtereslt = log.int_Access(CurrentUser.UsrID, CurrentUser.UsrNm, "OK", Statcdif._IP);
                    if (Accesslogreslt.msg == null && Updtereslt.msg == null)
                    {
                        SelctMainTables();
                        IntializeSwitchBoard(fn);
                        LblLogin.Text = "";
                        LblLogin.Image = Resources.Empty;
                    }
                }
                else
                {
                    log.int_Access(Convert.ToInt32(0), TxtUsrNm.Text, "Fa", Statcdif._IP);
                    LblLogin.Text = "          Invalid User Name Or Password";
                    LblLogin.Image = Resources.Check_Marks2;
                    LblLogin.ForeColor = Color.Red;
                    StatBrPnlEn.Text = "Offline";
                }
            }
            else
            {
                LblLogin.Text = "";
                StatBrPnlEn.Text = "Offline";
                this.Refresh();
                fn.msg("لم ينجح الإتصال بقواعد البيانات", "Login");
            }
            LogInBtn.Enabled = true;
            GC.Collect();
        }
        private void IntializeSwitchBoard(function fn)
        {
            DAL.DataAccessLayer.rturnStruct Swtchbordreslt = log.SwtchBoard();
            if (Swtchbordreslt.dt.Rows.Count > 0)
            {
                fn.SwitchBoard(Swtchbordreslt.dt);
            }
            this.Text = "Welcome " + CurrentUser.UsrRlNm;
            Statcdif.Menu_.BackColor = Color.FromArgb(0, 192, 0);
            Statcdif.Menu_.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            Statcdif.Menu_.RightToLeft = RightToLeft.Yes;
            Statcdif.Menu_.Dock = DockStyle.Left;
            Statcdif.Menu_.TextDirection = ToolStripTextDirection.Vertical270;
            this.Controls.Add(Statcdif.Menu_);
            panellgin.Visible = false;
            FlowLayoutPanel1.Size = new Size(Statcdif.screenWidth - Statcdif.Menu_.Width, Statcdif.screenHeight - 120);
            //FlowLayoutPanel1.Location = new Point(100, 30);
            FlowLayoutPanel1.Visible = true;
            FlowLayoutPanel1.Dock = DockStyle.Fill;
        }
        private void SelctMainTables()
        {
            Statcdif.AreaTable = new DataTable();
            Statcdif.OfficeTable = new DataTable();
            Statcdif.CompSurceTable = new DataTable();
            Statcdif.CountryTable = new DataTable();
            Statcdif.ProdKTable = new DataTable();
            Statcdif.ProdCompTable = new DataTable();
            Statcdif.UpdateKTable = new DataTable();
            Statcdif.CDHolDay = new DataTable();
            Statcdif.MendFildsTable = new DataTable();
            Statcdif.MendPvtTable = new DataTable();
            DAL.DataAccessLayer.rturnStruct SlctMainreslt = log.slctmaintbls();
            if (SlctMainreslt.ds.Tables.Count > 0)
            {
                Statcdif.AreaTable = SlctMainreslt.ds.Tables[0];
                Statcdif.OfficeTable = SlctMainreslt.ds.Tables[1];
                Statcdif.CompSurceTable = SlctMainreslt.ds.Tables[2];
                Statcdif.CountryTable = SlctMainreslt.ds.Tables[3];
                Statcdif.ProdKTable = SlctMainreslt.ds.Tables[4];
                Statcdif.ProdCompTable = SlctMainreslt.ds.Tables[5];
                Statcdif.UpdateKTable = SlctMainreslt.ds.Tables[6];
                Statcdif.CDHolDay = SlctMainreslt.ds.Tables[7];
                Statcdif.MendFildsTable = SlctMainreslt.ds.Tables[8];
                Statcdif.MendPvtTable = SlctMainreslt.ds.Tables[9];
                if (CurrentUser.UsrUCatLvl == 7)
                {
                    Statcdif.CompSurceTable.DefaultView.RowFilter = "[SrcSusp] =" + 0 + " AND [srcCd] = '1'";     //     SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1 ORDER BY SrcNm";
                }
                else
                {
                    Statcdif.CompSurceTable.DefaultView.RowFilter = "[SrcSusp] =" + 0 + " AND [srcCd] > '1'";   //  SrcStr = "Select SrcCd, SrcNm from CDSrc where SrcSusp=0 And srcCd > 1 ORDER BY SrcNm"
                }
                Statcdif.FildList.Clear();
                for (int i = 0; i < Statcdif.MendPvtTable.Rows.Count; i++)
                {
                    Statcdif.FildList.Add("[" + Statcdif.MendPvtTable.Rows[i].Field<string>("FildKind") + "]");
                }
            }
        }
        private void IntializeUser()
        {
            StatBrPnlEn.Text = "Online";
            CurrentUser.UsrID = Statcdif.UserTable.Rows[0].Field<int>("UsrId");                  //store user ID
            CurrentUser.UsrCat = Statcdif.UserTable.Rows[0].Field<int>("UsrCat");                //Current User Catagory
            CurrentUser.UsrNm = Statcdif.UserTable.Rows[0].Field<String>("UsrNm");               //Current User Name
            CurrentUser.UsrPWrd = Statcdif.UserTable.Rows[0].Field<String>("UsrPassTmp");        //Current User Password
            CurrentUser.UsrLvl = Statcdif.UserTable.Rows[0].Field<String>("UsrLevel");           //Current User Class
            CurrentUser.UsrRlNm = Statcdif.UserTable.Rows[0].Field<String>("UsrRealNm");         //Current user Real Name
            CurrentUser.UsrMail = Statcdif.UserTable.Rows[0].Field<String>("UsrEmail");          //Current user UsrEmail
            CurrentUser.UsrSisco = Statcdif.UserTable.Rows[0].Field<String>("UsrSisco");         //Current user UsrSisco
            CurrentUser.UsrGsm = Statcdif.UserTable.Rows[0].Field<String>("UsrGsm");             //Current user UsrGsm
            CurrentUser.UsrGndr = Statcdif.UserTable.Rows[0].Field<String>("UsrGender");         //Current user Gender
            CurrentUser.UsrActv = Statcdif.UserTable.Rows[0].Field<bool>("UsrActive");           //Current User Active Or not
            if (Statcdif.UserTable.Rows[0]["UsrLastSeen"] != null && Statcdif.UserTable.Rows[0]["UsrLastSeen"].ToString().Length > 0)
            {CurrentUser.UsrLstS = Statcdif.UserTable.Rows[0].Field<DateTime>("UsrLastSeen");}    //Current User LastSeen
            CurrentUser.UsrSusp = Statcdif.UserTable.Rows[0].Field<bool>("UsrSusp");             //Current User Suspended Or not
            CurrentUser.UsrTcCnt = Statcdif.UserTable.Rows[0].Field<int>("UsrTkCount");          //Ticket Count
            CurrentUser.UsrSltKy = Statcdif.UserTable.Rows[0].Field<String>("SaltKey");          //SaltKey
            CurrentUser.UsrCatNm = Statcdif.UserTable.Rows[0].Field<String>("UCatNm");           //Catagory name
            CurrentUser.UsrCalCntr = Statcdif.UserTable.Rows[0].Field<bool>("UsrCalCntr");       //Call Center Boolean
            CurrentUser.UsrUCatLvl = Statcdif.UserTable.Rows[0].Field<Int16>("UCatLvl");         //User Cat. Level
            CurrentUser.UsrClsN = Statcdif.UserTable.Rows[0].Field<int>("UsrClsN");              //Open Complaint Count
            CurrentUser.UsrFlN = Statcdif.UserTable.Rows[0].Field<int>("UsrFlN");                //No Follow Count
            CurrentUser.UsrReOpY = Statcdif.UserTable.Rows[0].Field<int>("UsrReOpY");            //ReOPen Couunt
            CurrentUser.UsrUnRead = Statcdif.UserTable.Rows[0].Field<int>("UsrUnRead");          //Unread Events Count
            CurrentUser.UsrEvDy = Statcdif.UserTable.Rows[0].Field<int>("UsrEvDy");              //Event Count Per Day
            CurrentUser.UsrClsYDy = Statcdif.UserTable.Rows[0].Field<int>("UsrClsYDy");          //Closed Complaint Per day
            CurrentUser.UsrReadYDy = Statcdif.UserTable.Rows[0].Field<int>("UsrReadYDy");        //Read Events Count Per Day
            CurrentUser.UsrRecvDy = Statcdif.UserTable.Rows[0].Field<int>("UsrRecevDy");         //RecievedTickets Count Per Day
            CurrentUser.UsrClsUpdtd = Statcdif.UserTable.Rows[0].Field<int>("UsrClsUpdtd");      //Closed Tickets with New Updates
            CurrentUser.UsrFolwDay = Statcdif.UserTable.Rows[0].Field<int>("UsrTikFlowDy");      //Closed Tickets with New Updates
            CurrentUser.UsrTeam = log.MyTeam(CurrentUser.UsrCat, CurrentUser.UsrID, "", false).msg;
            LblLogin.Text = "          Login has been succeeded";
            LblLogin.Image = Resources.Check_Marks1;
            LblLogin.ForeColor = Color.Green;
            LblLogin.Refresh();


            LblUsrRNm.Text = "Welcome " + CurrentUser.UsrRlNm;

        }
        private void Chckcont()
        {
            defintions def = new defintions();
            function fn = function.getfn;
            def.thread_ = new Thread(() =>
            {

                //defintions.CncStat = false;
                //if (defintions.MacTble == null)
                //{ getMac(); }

                fn.CheckConnection();

                Action action = () =>
                {
                    //StatBrPnlEn.Text = "connecting ...";
                    if (Statcdif.MacTble != null)
                    {
                        if (Statcdif.MacTble.Rows.Count > 0)
                        {
                            this.Cmbo.Visible = true;
                        }
                        else
                        {
                            this.Cmbo.Visible = false;
                        }
                    }

                    if (Statcdif.CncStat == true)
                    {
                        StatBrPnlEn.Text = "Online";
                        LogInBtn.Enabled = true;
                        ExitBtn.Enabled = true;
                    }
                    else if (Statcdif.CncStat == false)
                    {
                        StatBrPnlEn.Text = "Offline";
                        LogInBtn.Enabled = false;
                        ExitBtn.Enabled = false;
                        //def.thread_.Abort();
                    }
                };
                try
                {
                    this.BeginInvoke(action);
                    Chckcont();
                }
                catch (Exception)
                {

                    return;
                }
            });
            def.thread_.IsBackground = true;
            def.thread_.Start();
        }
        public bool ThreadResult;
        public void threadresltAction()
        {
            if (ThreadResult == true)
            {
                StatBrPnlEn.Text = "Online";
                LogInBtn.Enabled = true;
                ExitBtn.Enabled = true;
            }
            else if (ThreadResult == false)
            {
                StatBrPnlEn.Text = "Offline";
                LogInBtn.Enabled = false;
                ExitBtn.Enabled = false;
            }
            else
            {
                StatBrPnlEn.Text = " ";
            }
        }
        private void Cmbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            function fn = function.getfn;
            //defintions.CncStat = false;
            Statcdif._ServerCD = Cmbo.SelectedItem.ToString();
            fn.ConStrFn();
            if (Statcdif._serverNm == "VOCA Server")
            {
                this.BackgroundImage = Resources.VocaWtr;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.BackColor = Color.FromArgb(192, 255, 192);
                this.panellgin.BackColor = Color.FromArgb(192, 255, 192);
            }
            else if (Statcdif._serverNm == "My Labtop")
            {
                this.BackgroundImage = Resources.Empty;
                this.BackColor = Color.White;
                this.panellgin.BackColor = Color.White;
            }
            else if (Statcdif._serverNm == "Training")
            {
                this.BackgroundImage = Resources.Demo;
                this.BackgroundImageLayout = ImageLayout.Center;
                this.BackColor = Color.White;
                this.panellgin.BackColor = Color.White;
            }
        }
        private void intializMainTbls()
        {
            Statcdif.AreaTable = new DataTable();
            Statcdif.OfficeTable = new DataTable();
            Statcdif.CompSurceTable = new DataTable();
            Statcdif.CountryTable = new DataTable();
            Statcdif.ProdKTable = new DataTable();
            Statcdif.ProdCompTable = new DataTable();
            Statcdif.UpdateKTable = new DataTable();
            DtblClction.Add(Statcdif.AreaTable);
            DtblClction.Add(Statcdif.OfficeTable);
            DtblClction.Add(Statcdif.CompSurceTable);
            DtblClction.Add(Statcdif.CountryTable);
            DtblClction.Add(Statcdif.ProdKTable);
            DtblClction.Add(Statcdif.ProdCompTable);
            DtblClction.Add(Statcdif.UpdateKTable);
            function fn = function.getfn;
            fn.Gettable("SELECT OffArea FROM PostOff GROUP BY OffArea ORDER BY OffArea;$" +
                        "select OffNm1, OffFinCd, OffArea from PostOff ORDER BY OffNm1;$" +
                        "select SrcCd, SrcNm,SrcSusp from CDSrc ORDER BY SrcNm$" +
                        "Select CounCd,CounNm from CDCountry order by CounNm$" +
                        "Select ProdKCd, ProdKNm, ProdKClr from CDProdK where ProdKSusp = 0 order by ProdKCd$" +
                        "Select FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp,CompHlp,CompReqst FROM VwFnProd where FnSusp = 0 ORDER BY PrdKind, PrdNm, CompNm$" +
                        "Select EvId, EvNm FROM CDEvent where EvSusp = 0 And EvBkOfic = 1 ORDER BY EvNm", DtblClction, "test");
            this.Text = "Welcome Screen _ " + fn.ElapsedTimeSpan;
            DataColumn primaryKey = new DataColumn();
            DataColumn primaryKey1 = new DataColumn();
            primaryKey = Statcdif.CountryTable.Columns["CounCd"];
            primaryKey1 = Statcdif.ProdKTable.Columns["ProdKNm"];
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Form[] dd = this.MdiChildren;
            foreach (Form f in dd)
            {
                MessageBox.Show(f.Text);
            }
        }
        private void tmrbringfront1(object sender, EventArgs e)
        {
            int Tst = 0;
            Form[] dd = getwecmscrnfrm.MdiChildren;
            if (dd.Count() > 0)
            {
                foreach (Form mdic in dd)
                {
                    if (mdic.WindowState == FormWindowState.Normal || mdic.WindowState == FormWindowState.Maximized)
                    {
                        Tst++;
                        break;
                    }
                }
                if (Tst > 0) { FlowLayoutPanel1.SendToBack(); } else { FlowLayoutPanel1.BringToFront(); };
            }
            else
            {
                FlowLayoutPanel1.BringToFront();
            }
        }
        private void ExtBt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void SnOutBt_Click(object sender, EventArgs e)
        {
            Statcdif.Menu_.Dispose();
            DtblClction.Clear();
            this.Controls.RemoveByKey(Statcdif.Menu_.Name);
            FlowLayoutPanel1.Visible = false;
            panellgin.Visible = true;
            this.Text = "Login Screen";
        }
        private void getMac()
        {
            //Populate ComboBox If MAC Table rows > 0
            if (Statcdif.MacTble == null) Statcdif.MacTble = new DataTable();
            function fn = function.getfn;
            if (fn.Gettable("SELECT * from AMac WHERE Mac='" + Statcdif._MacStr + "'", Statcdif.MacTble, "1000&H") == null)
            {
            }
            else
            {
                fn.msg(fn.Gettable("SELECT * from AMac WHERE Mac='" + Statcdif._MacStr + "'", Statcdif.MacTble, "1000&H").ToString(), "ddd");
            }
        }
        private void TxtUsrPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Log();
            }
        }
    }
}
