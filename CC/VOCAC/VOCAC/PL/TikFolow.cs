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
namespace VOCAC
{
    public partial class TikFolow : Form
    {
        BL.CLS_TIKFOLLOW CLS = new BL.CLS_TIKFOLLOW();
        SqlConnection sqlcon = new SqlConnection("Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocac;Password=Hemonad105046");
        SqlDataAdapter da;
        BindingManagerBase bmb;
        SqlCommandBuilder sqlcmb;
        DataTable TickTblMain = new DataTable();
        DataView TempData = new DataView();
        public TikFolow()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, " +
                            "TkDetails, TkClsStatus, TkFolw, TkEmpNm, tk.UsrRealNm as 'folowusr', TkReOp, format(TkRecieveDt, 'yyyy/MM/dd') As TkRecieveDt, TkEscTyp, ProdKNm, CompHelp, TkupSTime, EvNm, TkupTxt, upusr.UsrRealNm as 'updtusr', TkupReDt, TkupUser, TkupSQL, TkupTkSql," +
                            "TkupEvtId, EvSusp, UCatLvl, TkupUnread" +
                            " from TicketsAll tk inner join TkEvent Ev on Ev.TkupSQL = TkEvSql INNER JOIN Int_user upusr ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON upusr.UsrCat = IntUserCat.UCatId where tk.TkClsStatus = 0 and " +
                            "tk.TkEmpNm = " + CurrentUser.PUsrID + " order by TkSQL", sqlcon);
            da.Fill(TickTblMain);
            GridTicket.DataSource = TickTblMain.DefaultView;
            CLS.struFollow.TickCount = Convert.ToInt32(TickTblMain.Compute("count(TkKind) ", String.Empty));
            CLS.struFollow.CompCount = Convert.ToInt32(TickTblMain.Compute("count(TkKind) ", "TkKind = 1"));
            CLS.struFollow.RequestCount = Convert.ToInt32(TickTblMain.Compute("count(TkKind) ", "TkKind = 0"));
            CLS.struFollow.NoFlwCount = Convert.ToInt32(TickTblMain.Compute("count(TkFolw)", "TkFolw = 'False'"));
            CLS.struFollow.Recved = Convert.ToInt32(TickTblMain.Compute("count(TkRecieveDt)", "TkRecieveDt = '" + DateTime.Parse(Statcdif.servrTime).ToString("yyyy/MM/dd") + "'"));
            CLS.struFollow.ClsCount = Convert.ToInt32(TickTblMain.Compute("count(TkClsStatus)", "TkClsStatus = 'True' And TkKind = 'True'"));
            CLS.struFollow.UpdtFollow = Convert.ToInt32(TickTblMain.Compute("count(folowusr)", "[folowusr] = updtusr"));
            CLS.struFollow.UpdtColleg = Convert.ToInt32(TickTblMain.Compute("count(updtusr)", "[updtusr] <> folowusr AND UCatLvl >= 3 And UCatLvl <= 5"));
            CLS.struFollow.UpdtOthrs = Convert.ToInt32(TickTblMain.Compute("count(updtusr)", "[updtusr] <> folowusr AND UCatLvl < 3 or UCatLvl > 5"));
            CLS.struFollow.UnReadCount = Convert.ToInt32(TickTblMain.Compute("count(TkupUnread)", "TkupUnread = 'False'"));
            CLS.struFollow.Esc1 = Convert.ToInt32(TickTblMain.Compute("count(TkupEvtId)", "TkupEvtId = 902"));
            CLS.struFollow.Esc2 = Convert.ToInt32(TickTblMain.Compute("count(TkupEvtId)", "TkupEvtId = 903"));
            CLS.struFollow.Esc3 = Convert.ToInt32(TickTblMain.Compute("count(TkupEvtId)", "TkupEvtId = 904"));
            //bmb = this.BindingContext[TickTblMain];
            //TikDetails.gettikdetlsfrm.TxtPh1.DataBindings.Add("text", TickTblMain, "TkClPh");
            //TikDetails.gettikdetlsfrm.TxtPh2.DataBindings.Add("text", TickTblMain, "TkClPh1");
            gridadjst();
            Filtr();
            frmAdjust();
            this.GridTicket.SelectionChanged += new System.EventHandler(this.GridTicket_SelectionChanged);
            this.Rd_Like.Click += new System.EventHandler(this.Radio_CheckedChanged);
            this.Rd_Equal.Click += new System.EventHandler(this.Radio_CheckedChanged);
        }
        function fn = function.getfn;
        defintions Def = new defintions();
        private void TikFolow_Load(object sender, EventArgs e)
        {
            frms forms = new frms();
            forms.FrmAllSub(this);
        }
        private void gridadjst()
        {
            if (this.GridTicket.Columns.Count > 0)
            {
                for (int i = 0; i < GridTicket.Columns.Count - 1; i++)
                {
                    GridTicket.Columns[i].Visible = false;
                }
                GridTicket.Columns["TkSQL"].Visible = true;
                GridTicket.Columns["TkKind"].Visible = true;
                GridTicket.Columns["TkDtStart"].Visible = true;
                GridTicket.Columns["TkClNm"].Visible = true;
                GridTicket.Columns["TkClPh"].Visible = true;
                GridTicket.Columns["TkCardNo"].Visible = true;
                GridTicket.Columns["TkGBNo"].Visible = true;
                GridTicket.Columns["TkClNtID"].Visible = true;
                GridTicket.Columns["TkAmount"].Visible = true;
                GridTicket.Columns["TkTransDate"].Visible = true;
                GridTicket.Columns["TkShpNo"].Visible = true;
                GridTicket.Columns["PrdNm"].Visible = true;
                GridTicket.Columns["CompNm"].Visible = true;
                GridTicket.Columns["TkDetails"].Visible = true;
                GridTicket.Columns["TkupTxt"].Visible = true;
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
        }
        private void Filtr()
        {
            StringBuilder FltrStr = new StringBuilder();
            string LK = " like ";
            string strt = "'%";
            string end_ = "%'";
            TempData = TickTblMain.DefaultView;

            if (SerchTxt.TextLength > 0)
            {
                if (Rd_strtwith.Checked) { strt = "'"; end_ = "%'"; }
                else if (Rd_contain.Checked) { strt = "'%"; end_ = "%'"; }
                else if (Rd_endwith.Checked) { strt = "'%"; end_ = "'"; }

                if (Rd_Equal.Checked) { LK = " = "; strt = "'"; end_ = "'"; }
                else if (Rd_Like.Checked) { LK = " Like "; };

                FltrStr.Append("Convert([TkSQL],System.String)" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClPh]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClPh1]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkCardNo]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkShpNo]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkGBNo]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClNtID]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [PrdNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [CompNm]" + LK + strt + SerchTxt.Text + end_);
            }
            if (FltrStr.ToString().Length > 0)
            {
                TickTblMain.DefaultView.RowFilter = FltrStr.ToString();
            }
            else
            {
                TickTblMain.DefaultView.RowFilter = string.Empty;
            }
            LblAll.Text = CLS.struFollow.TickCount.ToString();
            LblRequest.Text = CLS.struFollow.RequestCount.ToString();
            LabelCompCount.Text = CLS.struFollow.CompCount.ToString();
            LblUpdtFollow.Text = CLS.struFollow.UpdtFollow.ToString();
            LblUpdtColleg.Text = CLS.struFollow.UpdtColleg.ToString();
            LblUpdtOthrs.Text = CLS.struFollow.UpdtOthrs.ToString();
            LblNoFlwCount.Text = CLS.struFollow.NoFlwCount.ToString();
            LblRecved.Text = CLS.struFollow.Recved.ToString();
            LblUnReadCount.Text = CLS.struFollow.UnReadCount.ToString();
            LblFl1.Text = CLS.struFollow.Esc1.ToString();
            LblFl2.Text = CLS.struFollow.Esc2.ToString();
            LblFl3.Text = CLS.struFollow.Esc3.ToString();
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
                    Fltrreslt = "نتيجة الفلتر  : ";
                }
                else
                {
                    Fltrreslt = "العدد الإجمالي :";
                }
                if (GridTicket.CurrentRow != null)
                {
                    this.StatBrPnlAr.Text = Fltrreslt + (GridTicket.CurrentRow.Index + 1) + " / " + TickTblMain.DefaultView.Count.ToString();
                }
            }
            else
            {
                this.StatBrPnlAr.Text = "";
            }
        }
        private void GridTicket_DoubleClick(object sender, EventArgs e)
        {
            TikDetails.gettikdetlsfrm.MdiParent = WelcomeScreen.ActiveForm;
            TikDetails.gettikdetlsfrm.WindowState = FormWindowState.Normal;
            TikDetails.gettikdetlsfrm.Show();
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
                Rd_strtwith.Checked = true;
                Rd_endwith.Checked = false;
                Rd_contain.Checked = false;
                Rd_strtwith.Enabled = true;
                Rd_endwith.Enabled = true;
                Rd_contain.Enabled = true;
            }
        }
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            Filtr();
        }
    }
}
