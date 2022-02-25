using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOCAC.PL
{
    public partial class TikFolow360 : Form
    {
        private static TikFolow360 frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
            GC.Collect();
        }
        public static TikFolow360 getTikFol360frm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikFolow360();
                }
                return frm;
            }
        }
        public TikFolow360()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }

        private void TikFolow360_Load(object sender, EventArgs e)
        {
            frm.FormClosed -= new FormClosedEventHandler(frm_Closed);
            frm.FormClosed += new FormClosedEventHandler(frm_Closed);
            Grid.DataSource = Statcdif.tik360.DefaultView;
            Grid.Columns["TkSQL"].HeaderText = "رقم الشكوى";
            Grid.Columns["TkDtStart"].HeaderText = "تاريخ الشكوى";
            Grid.Columns["TkClNm"].HeaderText = "اسم العميل";
            Grid.Columns["TkClPh"].HeaderText = "تليفون العميل1";
            Grid.Columns["TkClPh1"].HeaderText = "تليفون العميل2";
            Grid.Columns["TkClNtID"].HeaderText = "الرقم القومي";
            Grid.Columns["comp"].HeaderText = "الشكوى";
            Grid.Columns["Folower"].HeaderText = "متابع الشكوى";
            Grid.Columns["TkClsStatus"].HeaderText = "حالة الشكوى";

            Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 16, FontStyle.Bold);
            Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Text = "الملف الشخصي للعميل - جميع الشكاوى" + "   ( " + Statcdif.tik360.DefaultView.Count + " )"; ;
        }

        private void Opened_Click(object sender, EventArgs e)
        {
            Statcdif.tik360.DefaultView.RowFilter = "TkClsStatus = 'مفتوحة' and ( TkClPh = '" + TikFolow_Team.getTikFolltemfrm.GridTicket.CurrentRow.Cells["TkClPh"].Value + "' or TkClNtID = '" + TikFolow_Team.getTikFolltemfrm.GridTicket.CurrentRow.Cells["TkClNtID"].Value + "')";
            this.Text = "الملف الشخصي للعميل - الشكاوى المفتوحة" + "   ( " + Statcdif.tik360.DefaultView.Count + " )"; ;
        }

        private void Closed_Click(object sender, EventArgs e)
        {
            Statcdif.tik360.DefaultView.RowFilter = "TkClsStatus = 'مغلقة' and ( TkClPh = '" + TikFolow_Team.getTikFolltemfrm.GridTicket.CurrentRow.Cells["TkClPh"].Value + "' or TkClNtID = '" + TikFolow_Team.getTikFolltemfrm.GridTicket.CurrentRow.Cells["TkClNtID"].Value + "')";
            this.Text = "الملف الشخصي للعميل - الشكاوى المغلقة" + "   ( " + Statcdif.tik360.DefaultView.Count + " )"; ;
        }

        private void All_Click(object sender, EventArgs e)
        {
            Statcdif.tik360.DefaultView.RowFilter = "(TkClPh = '" + TikFolow_Team.getTikFolltemfrm.GridTicket.CurrentRow.Cells["TkClPh"].Value + "') or (TkClNtID = '" + TikFolow_Team.getTikFolltemfrm.GridTicket.CurrentRow.Cells["TkClNtID"].Value + "')";
            this.Text = "الملف الشخصي للعميل - جميع الشكاوى" + "   ( " + Statcdif.tik360.DefaultView.Count + " )"; ;
        }
    }
}
