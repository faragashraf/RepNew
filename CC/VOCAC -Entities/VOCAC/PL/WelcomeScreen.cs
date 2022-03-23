using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAUltimate.Properties;

namespace VOCAUltimate.PL
{
    public delegate void delagatethread();
    public partial class WelcomeScreen : Form
    {
        function fn = function.getfn;
        int ConterWidt = 0;
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        private string Ver = null;
        private static WelcomeScreen frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
            GC.Collect();
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
            this.LblClrSys.BackColor = Settings.Default.ClrSys;
            this.LblClrUsr.BackColor = Settings.Default.ClrUsr;
            this.LblClrSamCat.BackColor = Settings.Default.ClrSamCat;
            this.LblClrNotUsr.BackColor = Settings.Default.ClrNotUsr;
            this.LblClrOperation.BackColor = Settings.Default.ClrOperation;


            Statcdif._IP = fn.OsIP();
            LblUsrIP.Text = "IP: " + Statcdif._IP;
            lblIp.Text = "IP: " + Statcdif._IP;

            if (Encoding.Default.HeaderName != "windows-1256")
            {

            }
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                Ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
                PubVerLbl.Text = "Ver. : " + Ver;
                PubVerLbl1.Text = "Ver. : " + Ver;
            }
            else
            {
                Ver = "Publish version";
                PubVerLbl.Text = "Publish Ver. : Not Deployed Version";
                PubVerLbl1.Text = "Publish Ver. : Not Deployed Version";
            }

            //Cmbo.Items.Add("My Labtop");
            Cmbo.Items.Add("Eg Server");
            Cmbo.Items.Add("Training");
            //Cmbo.Items.Add("servrMe");
            //Cmbo.Items.Add("Lab");
        }
        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            panellgin.Location = new Point((this.Width - panellgin.Width) / 2, (this.Height - 150 - panellgin.Height) / 2);
            function.populateEncryptTbl();
            if (Encoding.Default.HeaderName == "windows-1256") // Current Languaes for non-Unocode Programs is Arabic
            {
                MdiClient Mdiclnt1;
                foreach (Control ctrl in this.Controls)
                {
                    try
                    {
                        Mdiclnt1 = (MdiClient)ctrl;
                        Mdiclnt1.BackColor = Color.White;
                    }
                    catch (Exception)
                    {

                    }
                }
                frms forms = new frms();
                forms.FrmAllSub(this);
                //initialize Lables

                Statcdif._MacStr = fn.GetMACAddressNew();
                TxtUsrNm.Select();
                //TxtUsrNm.Text = "ahmed_emam";
                //TxtUsrPass.Text = "hemonad";

                //Cmbo.SelectedItem = "Training";
                Cmbo.SelectedItem = "Eg Server";
                Statcdif._ServerCD = Cmbo.SelectedItem.ToString();
                LblSrvrNm.Text = Statcdif._ServerCD;
                this.Cmbo.SelectedIndexChanged += new System.EventHandler(this.Cmbo_SelectedIndexChanged);
            }
            else
            {
                FlowLayoutPanel1.Size = new Size(Statcdif.screenWidth, Statcdif.screenHeight - 120);
                FlowLayoutPanel1.Dock = DockStyle.Fill;
                FlowLayoutPanel1.Visible = true;
                panellgin.Visible = false;
                GroupBox1.Visible = false;
                //GrpCounters.Visible = false;
                PictureBox1.Visible = false;
                LblUsrIP.Visible = false;
                PubVerLbl.Visible = false;
                Panel2.Visible = false;
                FlowLayoutPanel1.BackgroundImage = Resources.Language_for_Non_Unicode_Programs;
                FlowLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch;
                StatBrPnlAr.Text = "يرجى إتباع تعليمات تغيير اللغة أعلاه وإعادة تشغيل البرنامج مرة أخرى";
                StatBrPnlAr.Alignment = HorizontalAlignment.Center;
            }

        }
        private void LogInBtn_Click(object sender, EventArgs e)
        {
            Log();
        }
        public string SQLSTR;
        private void Log()
        {
            Statcdif.servrTime = fn.ServrTime();
            LogInBtn.Enabled = false;
            StatBrPnlEn.Text = "Connecting ...........";
            LblLogin.Text = "          Authenticating";
            LblLogin.Image = Resources.Info;
            LblLogin.ForeColor = Color.Blue;
            this.Refresh();

            DAL.DataAccessLayer.rturnStruct logreslt = log.LOGIN(TxtUsrNm.Text, TxtUsrPass.Text, Ver, Statcdif._IP);
            if (logreslt.msg == null)
            {
                if (logreslt.dt.Rows.Count > 0)
                {
                    Statcdif.UserTable = logreslt.dt;
                    CurrentUser.UsrPWrd = Statcdif.UserTable.Rows[0].Field<String>("UsrPassNew");
                    CurrentUser.UsrRlNm = Statcdif.UserTable.Rows[0].Field<String>("UsrRealNm");
                    if (Statcdif.UserTable.Rows[0].Field<String>("UsrPassNew").Equals("0000") == true)
                    {
                        userPasschange usrfrm = new userPasschange();
                        usrfrm.ShowDialog();
                        panellgin.Enabled = false;
                    }
                    if (CurrentUser.UsrPWrd.Equals("0000") == true)
                    {
                        LogInBtn.Enabled = true;
                        panellgin.Enabled = true;
                        return;
                    }
                    StatBrPnlEn.Text = "Loging In ...";
                    IntializeUser();
                    SelctMainTables();
                    IntializeSwitchBoard(fn);
                    getusrPic();
                    LblLogin.Text = "";
                    LblLogin.Image = Resources.Empty;
                    DbStat.BackgroundImage = Resources.DBOn;
                    panellgin.Enabled = true;
                    StatBrPnlEn.Text = "";
                    pikerFromTo.Value = Convert.ToDateTime(Statcdif.servrTime);
                }
                else
                {
                    LblLogin.Text = "          Invalid User Name Or Password";
                    LblLogin.Image = Resources.Check_Marks2;
                    LblLogin.ForeColor = Color.Red;
                    StatBrPnlEn.Text = "Offline";
                    DbStat.BackgroundImage = Resources.DBOff;
                }
            }
            else
            {
                LblLogin.Text = "لم ينجح الإتصال بقواعد البيانات";
                LblLogin.ForeColor = Color.Red;
                StatBrPnlAr.Text = "لم ينجح الإتصال بقواعد البيانات";
                LblLogin.Image = null;
                //this.Refresh();
                //fn.msg("لم ينجح الإتصال بقواعد البيانات" + Environment.NewLine, "Login", MessageBoxButtons.OK);
            }

            LogInBtn.Enabled = true;
            GC.Collect();

            MdiClient Mdiclnt;
            foreach (Control ctrl in this.Controls)
            {
                try
                {
                    Mdiclnt = (MdiClient)ctrl;
                    if (Statcdif._ServerCD == "Eg Server")
                    {
                        FlowLayoutPanel1.BackColor = Color.FromArgb(192, 255, 192);
                        FlowLayoutPanel1.BackgroundImage = Resources.VOCAUltimatePicture2;
                        FlowLayoutPanel1.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (Statcdif._ServerCD == "Training")
                    {
                        FlowLayoutPanel1.BackColor = Color.White;
                        FlowLayoutPanel1.BackgroundImage = Resources.Demo;
                        FlowLayoutPanel1.BackgroundImageLayout = ImageLayout.Center;
                    }
                }
                catch (Exception)
                {
                    //Ignore Cast Error
                }
            }
        }
        private void IntializeSwitchBoard(function fn)
        {
            if (Statcdif.SwitchTbl.Rows.Count > 0)
            {
                fn.SwitchBoard(Statcdif.SwitchTbl);
            }
            this.Text = "VOCA Ultimate - " + Cmbo.Text;
            Statcdif.Menu_.BackColor = Color.FromArgb(0, 192, 0);
            Statcdif.Menu_.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            Statcdif.Menu_.RightToLeft = RightToLeft.Yes;
            Statcdif.Menu_.Dock = DockStyle.Left;
            Statcdif.Menu_.TextDirection = ToolStripTextDirection.Vertical270;
            this.Controls.Add(Statcdif.Menu_);
            FlowLayoutPanel1.Size = new Size(Statcdif.screenWidth - Statcdif.Menu_.Width, Statcdif.screenHeight - 120);
            FlowLayoutPanel1.Dock = DockStyle.Fill;
            FlowLayoutPanel1.Visible = true;
            panellgin.Visible = false;
        }
        private void SelctMainTables()
        {
            Statcdif.CompSurceTable = new DataTable();
            Statcdif.ProdKTable = new DataTable();
            Statcdif.ProdCompTable = new DataTable();
            Statcdif.UpdateKTable = new DataTable();
            Statcdif.CDHolDay = new DataTable();
            Statcdif.MendFildsTable = new DataTable();
            Statcdif.TreeUsrTbl = new DataTable();
            Statcdif.SwitchTbl = new DataTable();
            Statcdif.CDCountry = new DataTable();
            DAL.DataAccessLayer.rturnStruct SlctMainreslt = log.slctmaintbls();
            if (SlctMainreslt.ds.Tables.Count > 0)
            {
                Statcdif.CompSurceTable = SlctMainreslt.ds.Tables[0];                   // Tickets Source Table
                Statcdif.ProdKTable = SlctMainreslt.ds.Tables[1];                       // Product Kind Table
                Statcdif.ProdCompTable = SlctMainreslt.ds.Tables[2];                    // Finished Product + complaints Table
                Statcdif.UpdateKTable = SlctMainreslt.ds.Tables[3];                     // Event kinds Table
                Statcdif.CDHolDay = SlctMainreslt.ds.Tables[4];                         // Calendar Table
                Statcdif.MendFildsTable = SlctMainreslt.ds.Tables[5];                   // Medatory Fields VS Products & complaints CDFN Table
                Statcdif.TreeUsrTbl = SlctMainreslt.ds.Tables[6];                       // Users Table
                Statcdif.SwitchTbl = SlctMainreslt.ds.Tables[7];                        // Switchboard Table
                Statcdif.CDCountry = SlctMainreslt.ds.Tables[8];                        // CDCountry Table
                Statcdif.CDMend = SlctMainreslt.ds.Tables[9];                           // CDMend Table
                Statcdif.AppSettings = SlctMainreslt.ds.Tables[10];                     // ALib Table
                if (CurrentUser.UsrUCatLvl == 7)
                {
                    Statcdif.CompSurceTable.DefaultView.RowFilter = "[SrcSusp] = 0 AND [srcCd] = '1'";     //     SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1 ORDER BY SrcNm";
                }
                else
                {
                    Statcdif.CompSurceTable.DefaultView.RowFilter = "[SrcSusp] = 0 AND [srcCd] > '1'";   //  SrcStr = "Select SrcCd, SrcNm from CDSrc where SrcSusp=0 And srcCd > 1 ORDER BY SrcNm"
                }
                if (CurrentUser.UsrUCatLvl >= 3 && CurrentUser.UsrUCatLvl <= 5)
                {
                    Statcdif.UpdateKTable.DefaultView.RowFilter = "EvBkOfic = 1";
                }
                else
                {
                    Statcdif.UpdateKTable.DefaultView.RowFilter = "EvBkOfic = 0";
                }
                CurrentUser.UsrTeam = MyTeamOnSelect(CurrentUser.UsrID);
            }
        }
        private void IntializeUser()
        {
            StatBrPnlEn.Text = "Online";
            CurrentUser.UsrID = Statcdif.UserTable.Rows[0].Field<int>("UsrId");                  //store user ID
            CurrentUser.UsrCat = Statcdif.UserTable.Rows[0].Field<int>("UsrCat");                //Current User Catagory
            CurrentUser.UsrNm = Statcdif.UserTable.Rows[0].Field<String>("UsrNm");               //Current User Name
            CurrentUser.UsrPWrd = Statcdif.UserTable.Rows[0].Field<String>("UsrPassNew");        //Current User Password
            CurrentUser.UsrLvl = Statcdif.UserTable.Rows[0].Field<String>("UsrLevel_New");           //Current User Class
            CurrentUser.UsrRlNm = Statcdif.UserTable.Rows[0].Field<String>("UsrRealNm");         //Current user Real Name
            CurrentUser.UsrMail = Statcdif.UserTable.Rows[0].Field<String>("UsrEmail");          //Current user UsrEmail
            CurrentUser.UsrSisco = Statcdif.UserTable.Rows[0].Field<String>("UsrSisco");         //Current user UsrSisco
            CurrentUser.UsrGsm = Statcdif.UserTable.Rows[0].Field<String>("UsrGsm");             //Current user UsrGsm
            CurrentUser.UsrGndr = Statcdif.UserTable.Rows[0].Field<String>("UsrGender");         //Current user Gender
            CurrentUser.UsrActv = Statcdif.UserTable.Rows[0].Field<bool>("UsrActive");           //Current User Active Or not
            if (Statcdif.UserTable.Rows[0]["UsrLastSeen"] != null && Statcdif.UserTable.Rows[0]["UsrLastSeen"].ToString().Length > 0)
            { CurrentUser.UsrLstS = Statcdif.UserTable.Rows[0].Field<DateTime>("UsrLastSeen"); }    //Current User LastSeen
            CurrentUser.UsrSusp = Statcdif.UserTable.Rows[0].Field<bool>("UsrSusp");             //Current User Suspended Or not
            CurrentUser.UsrSltKy = Statcdif.UserTable.Rows[0].Field<String>("SaltKey");          //SaltKey
            CurrentUser.UsrCatNm = Statcdif.UserTable.Rows[0].Field<String>("UCatNm");           //Catagory name
            CurrentUser.UsrCalCntr = Statcdif.UserTable.Rows[0].Field<bool>("UsrCalCntr");       //Call Center Boolean
            CurrentUser.UsrUCatLvl = Statcdif.UserTable.Rows[0].Field<Int16>("UCatLvl");         //User Cat. Level

            LblLogin.Text = "          Login has been succeeded";
            LblLogin.Image = Resources.Check_Marks1;
            LblLogin.ForeColor = Color.Green;
            LblLogin.Refresh();


            LblUsrRNm.Text = "Welcome ( " + CurrentUser.UsrID + " ) " + CurrentUser.UsrRlNm;
            ConterWidt = 0;
            if (CurrentUser.UsrUCatLvl >= 3 && CurrentUser.UsrUCatLvl <= 5)
            {
                userRecords();
                ConterWidt = GrpCounters.Width + GrpCounters.Margin.Left + GrpCounters.Margin.Right;
            }
            else
            {
                GrpCounters.Visible = false;
                ConterWidt = 0;
            }
            AdjustSize();
        }
        private string MyTeamOnSelect(int slctdId)
        {
            List<string> UsrStr = new List<string>();
            TreeNode[] TempNode = new TreeNode[0];
            TreeView trvw = new TreeView();
            Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UsrId = " + slctdId;
            trvw.Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[0]["UCatId"].ToString(), Statcdif.TreeUsrTbl.DefaultView[0]["UsrMix"].ToString());
            UsrStr.Add(slctdId.ToString());
            Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatId > = " + CurrentUser.UsrCat;
            for (int i = 0; i < Statcdif.TreeUsrTbl.DefaultView.Count; i++)
            {
                TempNode = trvw.Nodes.Find(Statcdif.TreeUsrTbl.DefaultView[i][2].ToString(), true);
                if (TempNode.Length > 0)
                {
                    TempNode[0].Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[i]["UCatId"].ToString(), Statcdif.TreeUsrTbl.DefaultView[i]["UsrMix"].ToString());
                    UsrStr.Add(Statcdif.TreeUsrTbl.DefaultView[i][0].ToString());
                }
            }
            trvw.Dispose();
            return string.Join(", ", UsrStr);
        }
        private void userRecords()
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@dtFrom", SqlDbType.Date, 30);
            param[0].Value = pikerFromTo.Value.ToString();
            param[1] = new SqlParameter("@dtTo", SqlDbType.Date, 30);
            param[1].Value = pikerFromTo.Value.ToString();
            param[2] = new SqlParameter("@ID", SqlDbType.NVarChar);
            param[2].Value = CurrentUser.UsrID;
            DAL.Struc = DAL.SelectData("SP_USER_COUNTERS", param);
            GrpCounters.Visible = true;
            GrpCounters.Text = "ملخص أرقامي حتى : " + pikerFromTo.Value.ToString();
            GrpCounters.Visible = true;
            LblClsN.Text = DAL.Struc.dt.Rows[0]["OpnY"].ToString();
            LblFlN.Text = DAL.Struc.dt.Rows[0]["FlwNOpn"].ToString();
            LblClsYDy.Text = DAL.Struc.dt.Rows[0]["ClsCnt"].ToString();
            LblEvDy.Text = DAL.Struc.dt.Rows[0]["EvCnt"].ToString();
            LblUsrTskOwnr.Text = DAL.Struc.dt.Rows[0]["TskOwnr"].ToString();
            LblReOpY.Text = DAL.Struc.dt.Rows[0]["ReopnY"].ToString();
            LblRecivDy.Text = DAL.Struc.dt.Rows[0]["RecvCnt"].ToString();
            LblClsUpdted.Text = DAL.Struc.dt.Rows[0]["ClsUpdtd"].ToString();
            LblFolwDy.Text = DAL.Struc.dt.Rows[0]["DealCnt"].ToString();
            LblUsrEventflowr.Text = DAL.Struc.dt.Rows[0]["Follower"].ToString();
            LblUsrEventColeg.Text = DAL.Struc.dt.Rows[0]["Colleague"].ToString();
            LblUsrEventOther.Text = DAL.Struc.dt.Rows[0]["Others"].ToString();
        }

        private void getusrPic()
        {
            try
            {
                byte[] image = (byte[])Statcdif.UserTable.Rows[0]["UsrPic"];
                Image img;
                using (MemoryStream ms = new MemoryStream(image))
                {
                    img = Image.FromStream(ms);
                    PictureBox1.Image = img;
                }
            }
            catch (Exception ex)
            {
                string hh = ex.Message;
                PictureBox1.Image = Resources.UsrResm;
            }
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
            //defintions.CncStat = false;
            Statcdif._ServerCD = Cmbo.SelectedItem.ToString();
            fn.ConStrFn();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            getusrPic();
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
            this.Controls.RemoveByKey(Statcdif.Menu_.Name);
            List<Form> frmlst = new List<Form>();
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name != this.Name)
                {
                    frmlst.Add(f);
                }
            }
            foreach (Form f in frmlst)
            {
                f.Close();
            }
            FlowLayoutPanel1.Visible = false;
            panellgin.Visible = true;
            this.Text = "Login Screen";
            Cmbo.Visible = false;
        }
        private void getMac()
        {
            Statcdif.MacTble = new DataTable();
            Statcdif.MacTble = fn.returntbl("SELECT * from AMac WHERE Mac='" + Statcdif._MacStr + "'");

            if (Statcdif.MacTble != null)
            {
                if (Statcdif.MacTble.Rows.Count > 0)
                {
                    Cmbo.Visible = true;
                }
                else
                {
                    Cmbo.Visible = false;
                    fn.msg("Your Mac Address is : " + Statcdif._MacStr, "MAC Address", MessageBoxButtons.OK);
                    Clipboard.SetText(Statcdif._MacStr.ToString());
                }
            }
        }
        private void TxtUsrPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Log();
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string startPath = @"C:\Users\ashraf\Desktop\CompUpdates\";
            DirectoryInfo d = new DirectoryInfo(startPath);
            string[] files = Directory.GetFiles(startPath);
            //string[] files = Directory.GetFiles(startPath, "*.jpg", SearchOption.AllDirectories);

            foreach (string oCurrent in files)
            {
                DirectoryInfo d1 = new DirectoryInfo(oCurrent);
                //
                byte[] image1 = File.ReadAllBytes(oCurrent);

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "TSP_Test";
                SqlConnection con = new SqlConnection(Statcdif.strConn);
                sqlcmd.Connection = con;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@id", SqlDbType.Int);
                param[0].Value = Convert.ToInt32(d1.Name.Split('.')[0]);
                param[1] = new SqlParameter("@pic", SqlDbType.Image);
                param[1].Value = image1;
                sqlcmd.Parameters.Add(param[0]);
                sqlcmd.Parameters.Add(param[1]);
                try
                {
                    con.Open();
                    sqlcmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    fn.msg("dd", "frfff", MessageBoxButtons.OK);
                }
            }


            //MemoryStream mr = new MemoryStream();
            //PictureBox1.Image.Save(mr, PictureBox1.Image.RawFormat);
            ////byte[] image = File.ReadAllBytes(@"C:\\Users\ashraf\\Desktop\\مطبخ غاده\\1.jpg");
            //byte[] byteImage = mr.ToArray();


        }
        private void UploadYourPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (function.preapareattachment() != null)
            {
                //Get the path of specified file
                DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@id", SqlDbType.Int);
                param[0].Value = CurrentUser.UsrID;
                param[1] = new SqlParameter("@pic", SqlDbType.Image);
                param[1].Value = Statcdif.mainImageArray;
                try
                {
                    DAL.ExcuteCommand("SP_A_USR_PIC", param);
                    using (MemoryStream ms = new MemoryStream(Statcdif.mainImageArray))
                    {
                        Image.FromStream(ms).Save(@"c:\\AAA.jpg");
                        Size sze = new Size();
                        sze = Image.FromStream(ms).Size;
                        int lql = Image.FromStream(ms).Height;
                        function.ResizeImage(Image.FromStream(ms), sze.Width / 8, sze.Height / 8).Save(@"c:\\AAASized.jpg");
                        PictureBox1.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    fn.msg("خطأ في تحميل الصوره", "تحميل الصورة الشخصية", MessageBoxButtons.OK);
                    function.AppLog(ex.Message + "$" + ex.InnerException, ex.HResult.ToString(), "SP_A_USR_PIC");
                }
            }
        }
        private void WelcomeScreen_SizeChanged(object sender, EventArgs e)
        {
            AdjustSize();
        }
        private void AdjustSize()
        {
            LblUsrIP.Margin = new Padding(LblUsrIP.Margin.Left, this.Height - (GroupBox1.Height + GrpCounters.Height + 370), LblUsrIP.Margin.Right, LblUsrIP.Margin.Bottom);
            panellgin.Location = new Point((this.Width - panellgin.Width) / 2, (this.Height - 150 - panellgin.Height) / 2);
            DbStat.Margin = new Padding(DbStat.Margin.Left, 30, this.Width - 100 - (DbStat.Width + DbStat.Margin.Left), DbStat.Margin.Bottom);
            PictureBox1.Margin = new Padding(PictureBox1.Margin.Left, 50, this.Width - 100 - (GroupBox1.Width + GroupBox1.Margin.Right + GroupBox1.Margin.Left + ConterWidt + PictureBox1.Width + PictureBox1.Margin.Left + 20), PictureBox1.Margin.Bottom);
            LblUsrRNm.Margin = new Padding(LblUsrRNm.Margin.Left, LblUsrRNm.Margin.Top, this.Width - 100 - (LblUsrRNm.Width + LblUsrRNm.Margin.Left), LblUsrRNm.Margin.Bottom);
            LblSrvrNm.Margin = new Padding(LblSrvrNm.Margin.Left, LblSrvrNm.Margin.Top, this.Width - 100 - (LblSrvrNm.Width + LblUsrRNm.Margin.Left), LblSrvrNm.Margin.Bottom);
            LblLstSeen.Margin = new Padding(LblLstSeen.Margin.Left, LblLstSeen.Margin.Top, this.Width - 100 - (LblLstSeen.Width + LblUsrRNm.Margin.Left), LblLstSeen.Margin.Bottom);
        }
        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Bitmap tt = (Bitmap)PictureBox1.Image;
            tt.RotateFlip(RotateFlipType.Rotate90FlipX);
            PictureBox1.Image = tt;

            PictureBox1.Refresh();
        }
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Bitmap tt = (Bitmap)PictureBox1.Image;
            tt.RotateFlip(RotateFlipType.Rotate180FlipY);
            PictureBox1.Image = tt;
            PictureBox1.Refresh();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            VOCAServiceGet.VOCAServiceGet vocaservice = new VOCAServiceGet.VOCAServiceGet();
            DataTable tbl = vocaservice.ExcuteQury("select * from CDMend");
            string ll = "Ashraf Farag";
            string hhws = function.encrypt(ll);
            string hh = function.discrypt(hhws);
            string[] dd = null;
            dd = function.readLog();
            string jjj = dd.ToString();
            int oo = CountNumberOfLinesInCSFilesOfDirectory(@"E:\RepNew\CC\VOCAUltimate\VOCAUltimate");
        }
        #region Project Code Lines Count In any Directory
        private int CountNumberOfLinesInCSFilesOfDirectory(string dirPath)
        {
            FileInfo[] csFiles = new DirectoryInfo(dirPath.Trim())
                                        .GetFiles("*.cs", SearchOption.AllDirectories);

            int totalNumberOfLines = 0;
            Parallel.ForEach(csFiles, fo =>
            {
                Interlocked.Add(ref totalNumberOfLines, CountNumberOfLine(fo));
            });
            return totalNumberOfLines;
        }
        private int CountNumberOfLine(Object tc)
        {
            FileInfo fo = (FileInfo)tc;
            int count = 0;
            int inComment = 0;
            using (StreamReader sr = fo.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (IsRealCode(line.Trim(), ref inComment))
                        count++;
                }
            }
            return count;
        }
        private bool IsRealCode(string trimmed, ref int inComment)
        {
            if (trimmed.StartsWith("/*") && trimmed.EndsWith("*/"))
                return false;
            else if (trimmed.StartsWith("/*"))
            {
                inComment++;
                return false;
            }
            else if (trimmed.EndsWith("*/"))
            {
                inComment--;
                return false;
            }

            return
                   inComment == 0
                && !trimmed.StartsWith("//")
                && (trimmed.StartsWith("if")
                    || trimmed.StartsWith("else if")
                    || trimmed.StartsWith("using (")
                    || trimmed.StartsWith("else  if")
                    || trimmed.Contains(";")
                    || trimmed.StartsWith("public") //method signature
                    || trimmed.StartsWith("private") //method signature
                    || trimmed.StartsWith("protected") //method signature
                    );
        }
        #endregion
        private void LblIp_Click(object sender, EventArgs e)
        {
            getMac();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            userRecords();
        }
    }
}
