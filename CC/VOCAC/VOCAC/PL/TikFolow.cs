using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAC.BL;
using VOCAC.Properties;
using static VOCAC.BL.ticketCurrent;

namespace VOCAC.PL
{
    public partial class TikFolow : Form
    {
        BL.ticketCurrent Crnt = new ticketCurrent();
        private static TikFolow frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static TikFolow getTikFollowfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikFolow();
                    frm.FormClosed += new FormClosedEventHandler(frm_Closed);
                }
                return frm;
            }
        }
        SqlConnection sqlcon = new SqlConnection("Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocac;Password=@VocaPlus$21-323");
        SqlCommand cmd;
        SqlDataAdapter da;
        BindingManagerBase bmb;
        SqlCommandBuilder sqlcmb;
        DataTable TickTblMain = new DataTable();
        public TikFolow()
        {
            InitializeComponent();
        }
        //assign Filtr TEXT into Control Tag and assign Event EventHandler
        private void assignfltrTXTintoCtrlTag()
        {
            ChckAll.Tag = string.Empty;
            ChckRequest.Tag = "TkKind = 0";
            ChckComp.Tag = "TkKind = 1";
            ChckUpdMe.Tag = "[folowusr] = updtusr";
            ChckUpdColeg.Tag = "[updtusr] <> folowusr AND UCatLvl >= 3 And UCatLvl <= 5";
            ChckUpdOther.Tag = "[updtusr] <> folowusr AND UCatLvl < 3 or UCatLvl > 5";
            ChckFlN.Tag = "TkFolw = 'False'";
            ChckTrnsDy.Tag = "TkRecieveDt = '" + DateTime.Parse(Statcdif.servrTime).ToString("yyyy/MM/dd") + "'";
            ChckRead.Tag = "TkupUnread = 'False'";
            ChckEsc1.Tag = "TkupEvtId = 902";
            ChckEsc2.Tag = "TkupEvtId = 903";
            ChckEsc3.Tag = "TkupEvtId = 904";

            this.Rd_Like.Click += new System.EventHandler(this.Radio_CheckedChanged);
            this.Rd_Equal.Click += new System.EventHandler(this.Radio_CheckedChanged);
            this.ChckAll.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckComp.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckEsc1.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckEsc2.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckEsc3.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckFlN.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckRead.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckRequest.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckTrnsDy.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckUpdColeg.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckUpdMe.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckUpdOther.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
        }
        function fn = function.getfn;
        defintions Def = new defintions();
        private void TikFolow_Load(object sender, EventArgs e)
        {
            frms forms = new frms();
            forms.FrmAllSub(this);
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "  جاري تحميل البيانات .......";
            if (filtbl().Rows.Count > 0)
            {
                try
                {
                    GridTicket.DataSource = TickTblMain.DefaultView;
                    WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
                }
                catch (Exception)
                {
                    fn.msg("هناك خطأ في الإتصال بقواعد البيانات", "متابعة الشكاوى");
                }
                gridadjst();
                Filtr();
                frmAdjust();
                assignfltrTXTintoCtrlTag();
                this.GridTicket.SelectionChanged += new System.EventHandler(this.GridTicket_SelectionChanged);
            }
        }
        private void gridadjst()
        {
            if (this.GridTicket.Columns.Count > 0)
            {
                for (int i = 0; i < 32; i++)
                {
                    GridTicket.Columns[i].Visible = false;
                }
                GridTicket.Columns["TkSQL"].Visible = true;
                GridTicket.Columns["TkKind"].Visible = true;
                GridTicket.Columns["TkDtStart"].Visible = true;
                GridTicket.Columns["TkClNm"].Visible = true;
                GridTicket.Columns["TkClPh"].Visible = true;
                GridTicket.Columns["TkClNtID"].Visible = true;
                GridTicket.Columns["PrdNm"].Visible = true;
                GridTicket.Columns["CompNm"].Visible = true;
                GridTicket.Columns["TkupSTime"].Visible = true;
                GridTicket.Columns["TkupTxt"].Visible = true;
                GridTicket.Columns["updtusr"].Visible = true;
                GridTicket.Columns["EvNm"].Visible = true;
                for (int i = 33; i < GridTicket.Columns.Count; i++)
                {
                    GridTicket.Columns[i].Visible = true;
                }
            }
        }
        private void Fill_()
        {
            Def.thread_ = new Thread(() =>
            {
                Action action1 = () =>
                {
                    GridTicket.Visible = false;
                    flowLayoutPanel3.Visible = false;
                    BtnRefrsh.Enabled = false;
                    CloseBtn.Visible = false;
                };
                try
                {
                    this.BeginInvoke(action1);
                }
                catch (Exception)
                {
                    return;
                };
                Action action = () =>
                {
                    GridTicket.DataSource = TickTblMain.DefaultView;
                    this.Text = "متابعة الشكاوى " + " _ " + fn.ElapsedTimeSpan;
                    GridTicket.Visible = true;
                    flowLayoutPanel3.Visible = true;
                    BtnRefrsh.Enabled = true;
                    CloseBtn.Visible = true;
                    gridadjst();
                    Filtr();
                };
                try
                {
                    this.BeginInvoke(action);
                }
                catch (Exception)
                {
                    return;
                }
            });  // New Thread -------------------------

            Def.thread_.IsBackground = true;
            if (Def.thread_ is null)
            {
                Def.thread_.Start();
            }
            else
            {
                if (Def.thread_.IsAlive != true)
                {
                    Def.thread_.Start();
                }
                else
                {
                    fn.msg("البيانات قيد التحميل .." + Environment.NewLine + "يرجى الإتنظار", "رسالة معلومات", MessageBoxButtons.OK);
                }
            }
        }
        private void BtnRefrsh_Click(object sender, EventArgs e)
        {
            sqlcmb = new SqlCommandBuilder(da);
            TickTblMain.Rows.Clear();
            da.Fill(TickTblMain);
            Filtr();
            this.StatBrPnlEn.Text = "إجمالي العدد : " + TickTblMain.Rows.Count.ToString();
        }
        private void Filtr()
        {
            StringBuilder FltrStr = new StringBuilder();
            string LK = " like ";
            string strt = "'%";
            string end_ = "%'";

            if (SerchTxt.TextLength > 0)
            {
                if (Rd_strtwith.Checked) { strt = "'"; end_ = "%'"; }
                else if (Rd_contain.Checked) { strt = "'%"; end_ = "%'"; }
                else if (Rd_endwith.Checked) { strt = "'%"; end_ = "'"; }

                if (Rd_Equal.Checked) { LK = " = "; strt = "'"; end_ = "'"; }
                else if (Rd_Like.Checked) { LK = " Like "; };
                FltrStr.Append("(");
                FltrStr.Append("Convert([TkSQL],System.String)" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClPh]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClPh1]" + LK + strt + SerchTxt.Text + end_);
                for (int i = 33; i < GridTicket.Columns.Count; i++)
                {
                    FltrStr.Append(" or [" + GridTicket.Columns[i].Name.ToString() + "]" + LK + strt + SerchTxt.Text + end_);
                }
                FltrStr.Append(" or [TkClNtID]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [PrdNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [CompNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [EvNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(")");
            }

            foreach (Control c in flowLayoutPanel3.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    RadioButton RD = (RadioButton)c;
                    if (RD.Checked == true)
                    {
                        if (RD.Tag.ToString().Length > 0)
                        {
                            if (FltrStr.Length > 0) { FltrStr.Append(" and "); };
                            FltrStr.Append("(");
                            FltrStr.Append(RD.Tag);
                            FltrStr.Append(")");
                        }
                        break;
                    }
                }
            }
            if (FltrStr.ToString().Length > 2)
            {
                TickTblMain.DefaultView.RowFilter = FltrStr.ToString();
            }
            else
            {
                TickTblMain.DefaultView.RowFilter = string.Empty;
            }
            this.StatBrPnlEn.Text = "إجمالي العدد : " + TickTblMain.Rows.Count.ToString();

            LblAll.Text = Convert.ToString(TickTblMain.Compute("count(TkKind) ", String.Empty));
            LblRequest.Text = Convert.ToString(TickTblMain.Compute("count(TkKind) ", "TkKind = 0"));
            LabelCompCount.Text = Convert.ToString(TickTblMain.Compute("count(TkKind) ", "TkKind = 1"));
            LblUpdtFollow.Text = Convert.ToString(TickTblMain.Compute("count(folowusr)", "[folowusr] = updtusr"));
            LblUpdtColleg.Text = Convert.ToString(TickTblMain.Compute("count(updtusr)", "[updtusr] <> folowusr AND UCatLvl >= 3 And UCatLvl <= 5"));
            LblUpdtOthrs.Text = Convert.ToString(TickTblMain.Compute("count(updtusr)", "[updtusr] <> folowusr AND UCatLvl < 3 or UCatLvl > 5"));
            LblNoFlwCount.Text = Convert.ToString(TickTblMain.Compute("count(TkFolw)", "TkFolw = 'False'"));
            LblRecved.Text = Convert.ToString(TickTblMain.Compute("count(TkRecieveDt)", "TkRecieveDt = '" + DateTime.Parse(Statcdif.servrTime).ToString("yyyy/MM/dd") + "'"));
            LblUnReadCount.Text = Convert.ToString(TickTblMain.Compute("count(TkupUnread)", "TkupUnread = 'False'"));
            LblFl1.Text = Convert.ToString(TickTblMain.Compute("count(TkupEvtId)", "TkupEvtId = 902"));
            LblFl2.Text = Convert.ToString(TickTblMain.Compute("count(TkupEvtId)", "TkupEvtId = 903"));
            LblFl3.Text = Convert.ToString(TickTblMain.Compute("count(TkupEvtId)", "TkupEvtId = 904"));
            Color_();
        }
        private void Color_()
        {
            foreach (Control c in flowLayoutPanel3.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    RadioButton RD = (RadioButton)c;
                    if (RD.Checked == true)
                    {
                        RD.BackColor = Color.LimeGreen;
                        RD.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    }
                    else
                    {
                        RD.BackColor = Color.White;
                        RD.Font = new Font("Times new Roman", 10, FontStyle.Regular);
                    }
                }
                else if (c.GetType() == typeof(Label))
                {
                    if (Convert.ToInt32(c.Text) > 0)
                    {
                        c.ForeColor = Color.Green;
                        c.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    }
                    else
                    {
                        c.BackColor = Color.White;
                        c.Font = new Font("Times new Roman", 6, FontStyle.Regular);
                    }
                }
            }
        }
        private void TikFolow_SizeChanged(object sender, EventArgs e)
        {
            frmAdjust();
            //FlowLayoutPanel2.Size = new Size(this.Width - 200, this.FlowLayoutPanel2.Height);
        }
        private void frmAdjust()
        {
            GridTicket.Size = new Size(this.Width - 50, this.Height - 260);
            FlowLayoutPanel2.Margin = new Padding((this.Width - FlowLayoutPanel2.Width) / 2, FlowLayoutPanel2.Margin.Top, FlowLayoutPanel2.Margin.Right, FlowLayoutPanel2.Margin.Bottom);
            GridTicket.Margin = new Padding((this.Width - GridTicket.Width) / 2, GridTicket.Margin.Top, GridTicket.Margin.Right, GridTicket.Margin.Bottom);
            flowLayoutPanel3.Margin = new Padding((this.Width - flowLayoutPanel3.Width) / 2, flowLayoutPanel3.Margin.Top, flowLayoutPanel3.Margin.Right, flowLayoutPanel3.Margin.Bottom);
        }
        private void SerchTxt_TextChanged(object sender, EventArgs e)
        {
            Filtr();
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string Fltrreslt;
        private void GridTicket_SelectionChanged(object sender, EventArgs e)
        {
            if (GridTicket.Rows.Count > 0)
            {
                if (TickTblMain.DefaultView.Count < TickTblMain.Rows.Count)
                {
                    Fltrreslt = "الفلتر يعمل  : ";
                    this.StatBrPnlAr.Icon = Resources.FilterOn;
                }
                else
                {
                    Fltrreslt = "الفلتر لا يعمل : ";
                    this.StatBrPnlAr.Icon = Resources.FilterOff;
                }
                if (GridTicket.CurrentRow != null)
                {
                    this.StatBrPnlAr.Text = Fltrreslt + (GridTicket.CurrentRow.Index + 1) + " / " + TickTblMain.DefaultView.Count.ToString() + "     ";
                }

                ShowResult();
                GC.Collect();
            }
            else if (GridTicket.Rows.Count == 0 && TickTblMain.Rows.Count > 0)
            {
                this.StatBrPnlAr.Text = "الفلتر يعمل     ";
                this.StatBrPnlAr.Icon = Resources.FilterOn;
                TikDetails.gettikdetlsfrm.Hide();
            }
        }
        private void ShowResult()
        {

            Crnt.currentRow(GridTicket);
            Crnt.AssignToForm();
            if (checkBox1.Checked) { TikDetails.gettikdetlsfrm.BringToFront(); };
        }
        private void RadioLikeEqual_CheckedChanged(object sender, EventArgs e)
        {
            if (Rd_Equal.Checked)
            {
                Rd_strtwith.Checked = false;
                Rd_endwith.Checked = false;
                Rd_contain.Checked = false;

                Rd_strtwith.Enabled = false;
                Rd_endwith.Enabled = false;
                Rd_contain.Enabled = false;
            }
            else if (Rd_Like.Checked)
            {
                Rd_strtwith.Checked = false;
                Rd_endwith.Checked = false;
                Rd_contain.Checked = true;

                Rd_strtwith.Enabled = true;
                Rd_endwith.Enabled = true;
                Rd_contain.Enabled = true;
            }
        }
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            Filtr();
        }
        private void Chckfltr_CheckedChanged(object sender, EventArgs e)
        {
            Filtr();
        }
        private DataTable filtbl()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", SqlDbType.VarChar);
            param[0].Value = " in (" + CurrentUser.UsrID.ToString() + ")";
            param[1] = new SqlParameter("@STATUS_", SqlDbType.Bit);
            param[1].Value = 0;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_TICKETS_SLCT";
            cmd.Connection = sqlcon;
            cmd.Parameters.Add(param[0]);
            cmd.Parameters.Add(param[1]);
            da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(TickTblMain);
            }
            catch (Exception ex)
            {
                fn.msg("SSS", "متابعة الشكاوى");
            }
            DAL.Close();
            return TickTblMain;
        }
        private void GridTicket_DoubleClick(object sender, EventArgs e)
        {
            if (GridTicket.SelectedRows != null)
            {
                if (frms.FormIsOpen(Application.OpenForms,typeof(TikDetails)) == false)
                {
                ShowResult();
                TikDetails.gettikdetlsfrm.MdiParent = WelcomeScreen.ActiveForm;
                TikDetails.gettikdetlsfrm.WindowState = FormWindowState.Normal;
                TikDetails.gettikdetlsfrm.Show();
                }
            }
        }
    }
}
