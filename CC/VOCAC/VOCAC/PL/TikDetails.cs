using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAC.BL;
using VOCAC.Properties;
using static VOCAC.BL.ticketCurrent;

namespace VOCAC.PL
{
    public partial class TikDetails : Form
    {
        private static TikDetails frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
            GC.Collect();
        }
        public static TikDetails gettikdetlsfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikDetails();
                }
                return frm;
            }
        }
        public TikDetails()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }
        private void TikDetails_Load(object sender, EventArgs e)
        {
            frm.FormClosed -= new FormClosedEventHandler(frm_Closed);
            frm.FormClosed += new FormClosedEventHandler(frm_Closed);
            frms forms = new frms();
            forms.FrmAllSub(this);
            //هأكمل بقيت الكود هنا
        }
        private void BtnUpd_Click(object sender, EventArgs e)
        {
            getupdate();
            TikUpdate.getTikupdatefrm.MdiParent = WelcomeScreen.ActiveForm;
            TikUpdate.getTikupdatefrm.WindowState = FormWindowState.Normal;
            TikUpdate.getTikupdatefrm.Show();
        }

        private void TimerVisInvs_Tick(object sender, EventArgs e)
        {
            if(lblRegion.Text.Length > 0 )
            {
                if(lblRegion.Visible == false)
                {
                    lblRegion.Visible = true;
                }
                else
                {
                    lblRegion.Visible = false;
                }
            }
        }
    }
}
