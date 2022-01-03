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

namespace VOCAC
{
    public delegate void delagatethread();
    public partial class WelcomeScreen : Form
    {
        List<DataTable> DtblClction = new List<DataTable>();
        public WelcomeScreen()
        {
            InitializeComponent();
            this.LblClrSys.BackColor = Settings.Default.ClrSys;
            this.LblClrUsr.BackColor = Settings.Default.ClrUsr;
            this.LblClrSamCat.BackColor = Settings.Default.ClrSamCat;
            this.LblClrNotUsr.BackColor = Settings.Default.ClrNotUsr;
            this.LblClrOperation.BackColor = Settings.Default.ClrOperation;
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
            function fn = new function();
            defintions Def = new defintions();
            //intialize Languges
            foreach (InputLanguage langu in InputLanguage.InstalledInputLanguages)
            {
                if (langu.Culture.TwoLetterISOLanguageName == "ar")
                {
                    Def.ArabicInput = langu;
                }
                else if (langu.Culture.TwoLetterISOLanguageName == "en")
                {
                    Def.ArabicInput = langu;
                }
            }
            //initialize Lables
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)                       
            {
                PubVerLbl.Text = "Ver. : " + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
            }
            else
            {
                PubVerLbl.Text = "Publish Ver. : This isn't a Publish version";
            }
            defintions._MacStr = fn.GetMACAddressNew();
            TxtUsrNm.Select();
            TxtUsrNm.Text = "otp";
            TxtUsrPass.Text = "Ahmed2220";
            LblUsrIP.Text = "IP: " + fn.OsIP();
            Label1.Text = "Welcome TO VOCA Enterprise" + Environment.NewLine + "Our Mini CRM";

            Cmbo.Items.Add("Eg Server");
            Cmbo.Items.Add("My Labtop");
            Cmbo.Items.Add("Training");
            //Cmbo.Items.Add("OnLine");
            Cmbo.SelectedItem = "Eg Server";
            defintions._ServerCD = Cmbo.SelectedItem.ToString();
            this.Cmbo.SelectedIndexChanged += new System.EventHandler(this.Cmbo_SelectedIndexChanged);

            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            PubVerLbl.Text = "IP: " + fn.OsIP();
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)                       //initialize Lables
            {
                PubVerLbl.Text = "Ver. : " + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
            }
            else
            {
                PubVerLbl.Text = "Publish Ver. : This isn't a Publish version";
            }

            defintions def = new defintions();
            def.thread_ = new Thread(Chckcont);
            def.thread_.IsBackground = true;
            def.thread_.Start();
        }
         private void LogInBtn_Click(object sender, EventArgs e)
        {
            Log();
        }
        public string Msgs;
        public string SQLSTR;
        private void Log()
        {
            function fn = new function();
           
            LogInBtn.Enabled = false;


            Image LblImg = Resources.Empty;
            StatBrPnlEn.Text = "Connecting ...........";
            LblLogin.Text = "          Authenticating";
            LblLogin.Image = Resources.Info;
            LblLogin.ForeColor = Color.Blue;
            LblLogin.Refresh();
            defintions.UserTable = new DataTable();
            if (fn.Gettable("SELECT UsrId, UsrCat, UsrNm, UsrPass, UsrLevel, UsrRealNm, UsrGender, UsrActive, UsrLastSeen, UsrSusp, UsrTkCount, RIGHT(dbo.IntGuid.PRGUID, CAST(LEFT(dbo.IntGuid.Id, 2) AS int) / 2) + SUBSTRING(dbo.IntGuid.GUID, 3, 5) + LEFT(dbo.IntGuid.PRGUID, CAST(RIGHT(dbo.IntGuid.Id, 2) AS int) / 2) AS SaltKey, UCatNm, UsrSisco, UsrGsm, UsrCalCntr, UsrClsN, UsrFlN, UsrReOpY, UsrUnRead, UsrEvDy, UsrClsYDy, UsrReadYDy, UCatLvl, UsrRecevDy, UsrClsUpdtd, UsrTikFlowDy, UsrEmail,UsrPassTmp FROM int_user INNER JOIN dbo.IntGuid ON int_user.UsrKey = SUBSTRING(dbo.IntGuid.GUID, 26, 11) INNER JOIN dbo.IntUserCat ON int_user.UsrCat = dbo.IntUserCat.UCatId Where (UsrNm = N'" + this.TxtUsrNm.Text + "');", defintions.UserTable, "1001&H") == null)
            {
                this.Text = "Welcome Screen _ " + fn.ElapsedTimeSpan;
                if (defintions.UserTable.Rows.Count > 0)
                {
                    CurrentUser.PUsrID = defintions.UserTable.Rows[0].Field<int>("UsrId");                  //store user ID
                    CurrentUser.PUsrCat = defintions.UserTable.Rows[0].Field<int>("UsrCat");                //Current User Catagory
                    CurrentUser.PUsrNm = defintions.UserTable.Rows[0].Field<String>("UsrNm");               //Current User Name
                    CurrentUser.PUsrPWrd = defintions.UserTable.Rows[0].Field<String>("UsrPassTmp");           //Current User Password
                    CurrentUser.PUsrLvl = defintions.UserTable.Rows[0].Field<String>("UsrLevel");           //Current User Class
                    CurrentUser.PUsrRlNm = defintions.UserTable.Rows[0].Field<String>("UsrRealNm");         //Current user Real Name
                    CurrentUser.PUsrMail = defintions.UserTable.Rows[0].Field<String>("UsrEmail");          //Current user UsrEmail
                    CurrentUser.PUsrSisco = defintions.UserTable.Rows[0].Field<String>("UsrSisco");         //Current user UsrSisco
                    CurrentUser.PUsrGsm = defintions.UserTable.Rows[0].Field<String>("UsrGsm");             //Current user UsrGsm
                    CurrentUser.PUsrGndr = defintions.UserTable.Rows[0].Field<String>("UsrGender");         //Current user Gender
                    CurrentUser.PUsrActv = defintions.UserTable.Rows[0].Field<bool>("UsrActive");           //Current User Active Or not
                    CurrentUser.PUsrLstS = defintions.UserTable.Rows[0].Field<DateTime>("UsrLastSeen");       //Current User LastSeen
                    CurrentUser.PUsrSusp = defintions.UserTable.Rows[0].Field<bool>("UsrSusp");           //Current User Suspended Or not
                    CurrentUser.PUsrTcCnt = defintions.UserTable.Rows[0].Field<int>("UsrTkCount");          //Ticket Count
                    CurrentUser.PUsrSltKy = defintions.UserTable.Rows[0].Field<String>("SaltKey");          //SaltKey
                    CurrentUser.PUsrCatNm = defintions.UserTable.Rows[0].Field<String>("UCatNm");           //Catagory name
                    CurrentUser.PUsrCalCntr = defintions.UserTable.Rows[0].Field<bool>("UsrCalCntr");       //Call Center Boolean
                    CurrentUser.PUsrUCatLvl = defintions.UserTable.Rows[0].Field<Int16>("UCatLvl");           //User Cat. Level
                    CurrentUser.PUsrClsN = defintions.UserTable.Rows[0].Field<int>("UsrClsN");              //Open Complaint Count
                    CurrentUser.PUsrFlN = defintions.UserTable.Rows[0].Field<int>("UsrFlN");                //No Follow Count
                    CurrentUser.PUsrReOpY = defintions.UserTable.Rows[0].Field<int>("UsrReOpY");            //ReOPen Couunt
                    CurrentUser.PUsrUnRead = defintions.UserTable.Rows[0].Field<int>("UsrUnRead");          //Unread Events Count
                    CurrentUser.PUsrEvDy = defintions.UserTable.Rows[0].Field<int>("UsrEvDy");              //Event Count Per Day
                    CurrentUser.PUsrClsYDy = defintions.UserTable.Rows[0].Field<int>("UsrClsYDy");          //Closed Complaint Per day
                    CurrentUser.PUsrReadYDy = defintions.UserTable.Rows[0].Field<int>("UsrReadYDy");        //Read Events Count Per Day
                    CurrentUser.PUsrRecvDy = defintions.UserTable.Rows[0].Field<int>("UsrRecevDy");         //RecievedTickets Count Per Day
                    CurrentUser.PUsrClsUpdtd = defintions.UserTable.Rows[0].Field<int>("UsrClsUpdtd");      //Closed Tickets with New Updates
                    CurrentUser.PUsrFolwDay = defintions.UserTable.Rows[0].Field<int>("UsrTikFlowDy");      //Closed Tickets with New Updates
                }
                else                                                                         //if user Name is Error
                {
                    SQLSTR = "insert into Int_access (UaccNm, UaccUsrIP, UaccStat) values ('" + TxtUsrNm.Text + "','" + fn.OsIP() + "','" + "Fa" + "');"; //Append access Record
                    Msgs = "          Invalid User Name Or Password";
                    LblImg = Resources.Check_Marks2;
                    LblLogin.ForeColor = Color.Red;
                    goto sec_UsrErr_;
                }
            }
            if (CurrentUser.PUsrSusp == true)  //f user is suspended
            {
                SQLSTR = "insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat) values ('" + TxtUsrNm.Text + "','" + CurrentUser.PUsrID + "','" + fn.OsIP() + "','" + "Su" + "');"; //Append access Record with Su Stat
                Msgs = "          User has been suspended" + " - " + "Please Call System Administrator";
                LblImg = Resources.Check_Marks2;
                LblLogin.ForeColor = Color.Red;
                goto sec_UsrErr_;
            }

            if (defintions.MacTble.Rows.Count > 0)
            {
                TxtUsrPass.Text = CurrentUser.PUsrPWrd;
            }

            if (defintions.MacTble.Rows.Count > 0 && defintions.MacTble.Rows[0].Field<bool>("Admin") == true)
            {
                TxtUsrPass.Text = CurrentUser.PUsrPWrd;
            }

            if (TxtUsrNm.Text == CurrentUser.PUsrNm && TxtUsrPass.Text == CurrentUser.PUsrPWrd)       //check user name and password status
            {
                SQLSTR = "insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat) values ('" + TxtUsrNm.Text + "','" + CurrentUser.PUsrID + "','" + fn.OsIP() + "','" + "KK" + "');"; //Append access Record with Su Stat
                LblLogin.Text = "          Login has been succeeded";
                LblLogin.Image = Resources.Check_Marks1;
                LblLogin.ForeColor = Color.Green;
                LblLogin.Refresh();
                intializMainTbls();
                fn.SwitchBoard();
                this.Text = "Welcome " + CurrentUser.PUsrRlNm + " _ "+ fn.ElapsedTimeSpan;
                defintions.Menu_.BackColor = Color.FromArgb(0, 192, 0);
                defintions.Menu_.Font = new Font("Times New Roman", 14, FontStyle.Regular);
                defintions.Menu_.RightToLeft = RightToLeft.Yes;
                defintions.Menu_.Dock = DockStyle.Right;
                defintions.Menu_.TextDirection = ToolStripTextDirection.Vertical270;
                this.Controls.Add(defintions.Menu_);
                string Ver = null;
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    Ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
                }
                if (fn.InsUpdate("UPDATE Int_user SET UsrActive = 1, UsrIP ='" + fn.OsIP() + "', UsrVer = '" + Ver + "', UsrLastSeen = CONVERT(datetime,'" + fn.ServrTime().ToString() + "',103) WHERE (UsrId = " + CurrentUser.PUsrID + ");", "1007&H") != null)   //Update User Active =  True    
                {

                }
                panellgin.Visible = false;
                FlowLayoutPanel1.Size = new Size(defintions.screenWidth- defintions.Menu_.Width, defintions.screenHeight- 130);
                FlowLayoutPanel1.Location = new Point(0, 0);
                FlowLayoutPanel1.Visible = true;
                return;
            }
            else
            {
                SQLSTR = "insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat) values ('" + TxtUsrNm.Text + "','" + CurrentUser.PUsrID + "','" + fn.OsIP() + "','" + "Fa" + "');"; //Append access Record
                Msgs = "          Invalid User Name Or Password";
                LblImg = Resources.Check_Marks2;
                LblLogin.ForeColor = Color.Red;
            }
        sec_UsrErr_:
            LogInBtn.Enabled = true;
            if (fn.InsUpdate(SQLSTR, "1010&H") == null)
            {
                LblLogin.Text = Msgs;
                LblLogin.Image = LblImg;
                this.Refresh();
                GC.Collect();
            }
        }

        private void Chckcont()
        {
            defintions def = new defintions();
            function fn = new function();
            def.thread_ = new Thread(() =>
            {

                //defintions.CncStat = false;
                //if (defintions.MacTble == null)
                { getMac(); }

                fn.CheckConnection();

                Action action = () =>
                {
                    //StatBrPnlEn.Text = "connecting ...";
                    if(defintions.MacTble != null)
                    {
                    if (defintions.MacTble.Rows.Count > 0)
                    {
                        this.Cmbo.Visible = true;
                    }
                    else
                    {
                        this.Cmbo.Visible = false;
                    }
                    }
                    
                    if (defintions.CncStat == true)
                    {
                        StatBrPnlEn.Text = "Online";
                        LogInBtn.Enabled = true;
                        ExitBtn.Enabled = true;
                    }
                    else if (defintions.CncStat == false)
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
            function fn = new function();
            //defintions.CncStat = false;
            defintions._ServerCD = Cmbo.SelectedItem.ToString();
            fn.ConStrFn();
            if (defintions._serverNm == "VOCA Server")
            {
                this.BackgroundImage = Resources.VocaWtr;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.BackColor = Color.FromArgb(192, 255, 192);
                this.panellgin.BackColor = Color.FromArgb(192, 255, 192);
            }
            else if (defintions._serverNm == "My Labtop")
            {
                this.BackgroundImage = Resources.Empty;
                this.BackColor = Color.White;
                this.panellgin.BackColor = Color.White;
            }
            else if (defintions._serverNm == "Training")
            {
                this.BackgroundImage = Resources.Demo;
                this.BackgroundImageLayout = ImageLayout.Center;
                this.BackColor = Color.White;
                this.panellgin.BackColor = Color.White;
            }
        }
        private void intializMainTbls()
        {
            defintions.AreaTable = new DataTable();
            defintions.OfficeTable = new DataTable();
            defintions.CompSurceTable = new DataTable();
            defintions.CountryTable = new DataTable();
            defintions.ProdKTable = new DataTable();
            defintions.ProdCompTable = new DataTable();
            defintions.UpdateKTable = new DataTable();
            DtblClction.Add(defintions.AreaTable);
            DtblClction.Add(defintions.OfficeTable);
            DtblClction.Add(defintions.CompSurceTable);
            DtblClction.Add(defintions.CountryTable);
            DtblClction.Add(defintions.ProdKTable);
            DtblClction.Add(defintions.ProdCompTable);
            DtblClction.Add(defintions.UpdateKTable);
            function fn = new function();
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
            primaryKey = defintions.CountryTable.Columns["CounCd"];
            primaryKey1 = defintions.ProdKTable.Columns["ProdKNm"];
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
            Form[] dd = this.MdiChildren;
            if (dd.Count() > 0)
            {
                foreach (Form mdic in dd)
                {
                    if (mdic.WindowState == FormWindowState.Normal || mdic.WindowState == FormWindowState.Maximized)
                    {
                        FlowLayoutPanel1.SendToBack();
                        break;
                    }
                    else
                    {
                        FlowLayoutPanel1.BringToFront();
                    }
                }
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
            defintions.Menu_.Dispose();
            DtblClction.Clear();
            this.Controls.RemoveByKey(defintions.Menu_.Name);
            FlowLayoutPanel1.Visible = false;
            panellgin.Visible = true;
            this.Text = "Login Screen";
        }
        private void getMac()
        {
            //Populate ComboBox If MAC Table rows > 0
            if (defintions.MacTble == null) defintions.MacTble = new DataTable();
            function fn = new function();
            if (fn.Gettable("SELECT * from AMac WHERE Mac='" + defintions._MacStr + "'", defintions.MacTble, "1000&H") == null)
            {

            }
        }
    }
}
