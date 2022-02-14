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
using static VOCAC.BL.ticketCurrent;
using VOCAC.Properties;
using VOCAC.BL;

namespace VOCAC.PL
{
    public partial class TikUpdate : Form
    {
        private static TikUpdate frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static TikUpdate getTikupdatefrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikUpdate();
                    frm.FormClosed += new FormClosedEventHandler(frm_Closed);
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
        }

        private void TikUpdate_Load(object sender, EventArgs e)
        {
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
            adjustfrmsize();
            eventColor();
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

                    if(Statcdif.mainImageArray == null)
                    {
                        return;
                    }
                }
                if (ticketCurrent.addevent(currntTicket._TkSQL, TxtUpdt.Text, true, Convert.ToInt32(CmbEvent.SelectedValue), Statcdif._IP, CurrentUser.UsrID, Statcdif.mainImageArray) == null)
                {
                    getupdate();
                    eventColor();
                    CmbEvent.SelectedValue = -1;
                    TxtUpdt.Text = "";
                    TxtUpdt.ReadOnly = true;
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

            DataRow DRW = function.DRW(attchtbl, GridUpdt.CurrentRow.Cells[0].Value, attchtbl.Columns[0]);
            byte[] data = (byte[])DRW.ItemArray[1];
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
        private void cmb_selectionchanged(object sender, EventArgs e)
        {
            getimagefromarray();
        }
        private void GridUpdt_SelectionChanged(object sender, EventArgs e)
        {
            if (GridUpdt.CurrentRow != null)
            {
                if (GridUpdt.CurrentRow.Cells[11].Value.ToString().Length > 0)
                {
                    ContextMenuStrip2.Items[2].Enabled = true;
                }
                else
                {
                    ContextMenuStrip2.Items[2].Enabled = false;
                }
            }

        }
    }
}
