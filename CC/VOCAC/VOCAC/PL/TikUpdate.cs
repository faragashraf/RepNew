using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static VOCAUltimate.BL.ticketCurrent;
using VOCAUltimate.Properties;
using VOCAUltimate.BL;

namespace VOCAUltimate.PL
{
    public partial class TikUpdate : Form
    {
        private static TikUpdate frm;
        string[] arr = { ".JPG", ".JPEG", ".PNG" };
        private DataRow DRW;
        byte[] data;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            getTikupdatefrm.TimerEscOpen.Stop();
            getTikupdatefrm.WindowState = FormWindowState.Normal;
            frm = null;
            GC.Collect();
        }
        public static TikUpdate getTikupdatefrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikUpdate();
                }
                return frm;
            }
        }
        public TikUpdate()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
            TikUpdate.getTikupdatefrm.Load += new EventHandler(TikUpdate_SizeChanged);
        }
        private void TikUpdate_Load(object sender, EventArgs e)
        {
            frm.FormClosed -= new FormClosedEventHandler(frm_Closed);
            frm.FormClosed += new FormClosedEventHandler(frm_Closed);
            GridUpdt.Columns["TkupSTime"].HeaderText = "تاريخ التحديث";
            GridUpdt.Columns["EvNm"].HeaderText = "نوع التحديث";
            GridUpdt.Columns["TkupTxt"].HeaderText = "نص التحديث";
            GridUpdt.Columns["UsrRealNm"].HeaderText = "محرر التحديث";

            GridUpdt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            GridUpdt.ColumnHeadersDefaultCellStyle.Font = new Font("Times new Roman", 16, FontStyle.Bold);
            GridUpdt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            GridUpdt.DefaultCellStyle.Font = new Font("Times new Roman", 14, FontStyle.Regular);

            GridUpdt.Columns["File"].DefaultCellStyle.ForeColor = Color.Green;
            GridUpdt.Columns["File"].DefaultCellStyle.Font = new Font("Lucida Handwriting", 16, FontStyle.Bold);
            GridUpdt.Columns["File"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridUpdt.Columns["TkupSQL"].Visible = false;
            GridUpdt.Columns["TkupEvtId"].Visible = false;
            GridUpdt.Columns["TkupUser"].Visible = false;
            GridUpdt.Columns["EvSusp"].Visible = false;
            GridUpdt.Columns["UCatLvl"].Visible = false;
            GridUpdt.Columns["TkupUnread"].Visible = false;
            if (currntTicket._TkupEvtId == 902)
            {
                TimerEscOpen.Start();
            }
            else
            {
                TimerEscOpen.Stop();
            }
        }
        private void TikUpdate_SizeChanged(object sender, EventArgs e)
        {
            adjustfrmsize();
            eventColor();
        }
        private static void adjustfrmsize()
        {
            TikUpdate.getTikupdatefrm.GridUpdt.Size = new Size(TikUpdate.getTikupdatefrm.Size.Width - 30, TikUpdate.getTikupdatefrm.Size.Height - TikUpdate.getTikupdatefrm.FlowLayoutPanel2.Height - 70);
            TikUpdate.getTikupdatefrm.FlowLayoutPanel2.Margin = new Padding(TikUpdate.getTikupdatefrm.FlowLayoutPanel2.Margin.Left, TikUpdate.getTikupdatefrm.FlowLayoutPanel2.Margin.Top, (TikUpdate.getTikupdatefrm.GridUpdt.Width - TikUpdate.getTikupdatefrm.FlowLayoutPanel2.Width) / 2, TikUpdate.getTikupdatefrm.FlowLayoutPanel2.Margin.Bottom);
        }
        private void BtnSubmt_Click(object sender, EventArgs e)
        {
            Statcdif.mainImageArray = null;
            function fn = function.getfn;
            if (TxtUpdt.Text.Trim().Length > 0 && Convert.ToInt32(CmbEvent.SelectedValue) != -1)
            {
                if (chkboxattach.Checked)
                {
                    function.preapareattachment();

                    if (Statcdif.mainImageArray == null)
                    {
                        return;
                    }
                }
                if (ticketCurrent.addevent(currntTicket._TkSQL, TxtUpdt.Text, Convert.ToInt32(CmbEvent.SelectedValue), Statcdif._IP, CurrentUser.UsrID, null, Statcdif.mainImageArray, Statcdif.extAttch) == null)
                {
                    //if (TikFolow_Team.getTikFolltemfrm != null)
                    bool bolTikSearch = frms.FormIsOpen(Application.OpenForms, typeof(TikFolow_Team));
                    if (bolTikSearch == true)
                    {
                        DataRow DRW = function.DRW(Statcdif.TickTblMain, currntTicket._TkSQL, Statcdif.TickTblMain.Columns[0]);
                        Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkupTxt"] = TxtUpdt.Text;
                        Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkupEvtId"] = CmbEvent.SelectedValue;
                        Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["EvNm"] = CmbEvent.Text;
                        Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkupSTime"] = Statcdif.servrTime;
                        Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["updtusr"] = CurrentUser.UsrRlNm;
                        Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkupUser"] = CurrentUser.UsrID;
                    }
                    getupdate();
                    eventColor();
                    if (Convert.ToInt32(GridUpdt.Rows[0].Cells["TkupEvtId"].Value) == 902)
                    {
                        TimerEscOpen.Start();
                    }
                    Statcdif.mainImageArray = null;
                    chkboxattach.Checked = false;
                }
            }
            else
            {
                fn.msg("برجاء كتابة التحديث أولاً", "إضافة تحديث جديد", MessageBoxButtons.OK);
            }

        }
        public void CmbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(CmbEvent.SelectedValue) != -1)
            {
                TxtUpdt.ReadOnly = false;
                TxtUpdt.Focus();
            }
            else
            {
                TxtUpdt.ReadOnly = true;
            }
        }
        private void getimageToArray()
        {
            //pictureViewer_.pictureBox1.Image = Resources.Empty;
            //Size sze = new Size(pictureViewer_.imge.Width / Convert.ToInt32(pictureViewer_.comboBox1.SelectedItem), pictureViewer_.imge.Height / Convert.ToInt32(pictureViewer_.comboBox1.SelectedItem));
            //pictureViewer_.frm.Size = sze;
            //pictureViewer_.pictureBox1.Size = sze;
            //pictureViewer_.pictureBox1.Image = function.ResizeImage(pictureViewer_.imge, sze.Width, sze.Height);

        }
        private void DonlodAttchToolStripitem_Click(object sender, EventArgs e)
        {
            getimagefromarray();
        }
        private void getimagefromarray()
        {
            if (!arr.Contains(DRW.ItemArray[2].ToString().ToUpper()))
            {
                using (SaveFileDialog sv = new SaveFileDialog() { Filter = DRW.ItemArray[2].ToString().ToUpper() + " files| *" + DRW.ItemArray[2].ToString(), ValidateNames = true })
                {
                    if (sv.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(sv.FileName, data);
                    }
                }
            }
            else
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
                {
                    Statcdif.imge = Image.FromStream(ms);
                    zpicViewer.getviewerfrm.Load += new System.EventHandler(zpicViewer.getviewerfrm.ComboBox1_SelectedIndexChanged);
                    zpicViewer.getviewerfrm.ShowDialog();
                    //Size sze = new Size(Image.FromStream(ms).Width / Convert.ToInt32(cmb.SelectedItem), Image.FromStream(ms).Height / Convert.ToInt32(cmb.SelectedItem));
                    //frmpic.Size = sze;
                    //picBox.Size = sze;
                    //picBox.Image = function.ResizeImage(Image.FromStream(ms), sze.Width, sze.Height);
                    //picBox.Dock = DockStyle.Fill;
                }
            }


        }
        private void cmb_selectionchanged(object sender, EventArgs e)
        {
            getimagefromarray();
        }
        private void GridUpdt_SelectionChanged(object sender, EventArgs e)
        {
            if (GridUpdt.CurrentRow != null)
            {
                var k = attchtbl.Rows.Count;
                var k1 = attchtbl;
                if (GridUpdt.CurrentRow.Cells["File"].Value.ToString().Length > 0)
                {
                    DRW = function.DRW(attchtbl, GridUpdt.CurrentRow.Cells[0].Value, attchtbl.Columns[0]);
                    if(DRW !=null)
                    {
                        data = (byte[])DRW.ItemArray[1];
                        Statcdif.extAttch = DRW.ItemArray[2].ToString();
                        //toolTip1.Show("رقم التليفون لابد أن يبدأ بكود المحافظة" + Environment.NewLine + "مثال : \"02XXXXXXXX", GridUpdt, 0, 30, 1000);
                        ContextMenuStrip2.Items[0].Enabled = true;
                        if (arr.Contains(Statcdif.extAttch.ToString().ToUpper()))
                        {
                            ContextMenuStrip2.Items[0].Text = "DownLoad Picture";
                        }
                        else
                        {
                            ContextMenuStrip2.Items[0].Text = "DownLoad File";
                        }
                    }
                }
                else
                {
                    ContextMenuStrip2.Items[0].Enabled = false;
                }
            }

        }
        private void TimerEscOpen_Tick(object sender, EventArgs e)
        {
            function fn = function.getfn;

            DateTime Minutws = Convert.ToDateTime(fn.ServrTime());
            double Minuts = Convert.ToDateTime(Minutws).Subtract(Convert.ToDateTime(GridUpdt.Rows[0].Cells["TkupSTime"].Value)).TotalMinutes;
            double MinutsDef = (120 - Minuts);
            if (Convert.ToInt32(GridUpdt.Rows[0].Cells["TkupEvtId"].Value) == 902)
            {
                if (Minuts < 120)
                {
                    LblMsg.Text = ("تم عمل متابعه 1 وسيتم الرد عليها خلال " + 120 + " متبقى " + TimeSpan.FromMinutes(MinutsDef).ToString().Split('.')[0]);
                    //LblMsg.Refresh();
                    CmbEvent.Enabled = false;
                    BtnSubmt.Enabled = false;
                    chkboxattach.Enabled = false;
                    TxtUpdt.Text = "لا يمكن عمل تحديث أثناء فترة المتابعه، ويتم السماح بإضافة تعديل إما بإنتهاء فترة المتابعه أو عمل تحديث من الخطوط الخلفية";
                    TxtUpdt.Font = new Font("Times New Roman", 16, FontStyle.Regular);
                    TxtUpdt.TextAlign = HorizontalAlignment.Center;
                    TxtUpdt.ReadOnly = true;
                    return;
                }
                else
                {
                    LblMsg.Text = "";
                    CmbEvent.Enabled = true;
                    BtnSubmt.Enabled = true;
                    chkboxattach.Enabled = true;
                    // TxtUpdt.Text = ""
                    TxtUpdt.Font = new Font("Times New Roman", 14, FontStyle.Regular);
                    TxtUpdt.TextAlign = HorizontalAlignment.Left;
                    TxtUpdt.ReadOnly = false;
                }
            }
            else
            {
                LblMsg.Text = "";
                CmbEvent.Enabled = true;
                BtnSubmt.Enabled = true;
                chkboxattach.Enabled = true;
                TxtUpdt.Text = "";
                TxtUpdt.Font = new Font("Times New Roman", 14, FontStyle.Regular);
                TxtUpdt.TextAlign = HorizontalAlignment.Left;
                TxtUpdt.ReadOnly = false;
            }
            GC.Collect();
        }
    }
}
