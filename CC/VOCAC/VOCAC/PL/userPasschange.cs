using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOCAC.PL
{
    public partial class userPasschange : Form
    {
        function fn = function.getfn;
        private static userPasschange frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
            GC.Collect();
        }
        public static userPasschange getuserPassChangefrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new userPasschange();
                }
                return frm;
            }
        }
        public userPasschange()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            frm.FormClosed -= new FormClosedEventHandler(frm_Closed);
            frm.FormClosed += new FormClosedEventHandler(frm_Closed);
            TxtUsCnt_lNm.Text = CurrentUser.UsrRlNm;
        }
        private void BtSub_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (CurrentUser.UsrPWrd.ToString().Equals(TxtUsrOPass.Text))
            {
                if (TxtUsrPass.Text.Equals(TxtUsCnt_Pass.Text))
                {
                    if (TxtUsrPass.Text.Equals("0000"))
                    {
                        LblHint.Text = "كلمة المرور يجب ألا تماثل كلمة المرور القديمة وألا تكون \"0000\"" ;
                        LblHint.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (fn.ExcuteStr("update Int_user set UsrPassNew ='" + TxtUsrPass.Text + "' where usrid = " + Statcdif.UserTable.Rows[0].Field<int>("UsrId")) == null)
                        {
                            CurrentUser.UsrPWrd = TxtUsrPass.Text;
                            LblHint.Text = "تم تغيير كلمة المرور بنجاح";
                            LblHint.ForeColor = Color.Green;
                            BtSub.Enabled = false;
                        }
                        else
                        {
                            LblHint.Text = "لم يتم تغيير كلمة المرور-برجاء إعادة المحاولة";
                            LblHint.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    function fn = function.getfn;
                    //fn.msg("كلمة المرور غير متطابقة" , "تغيير كلمة المرور");
                    LblHint.Text = "كلمة المرور غير متطابقة";
                    LblHint.ForeColor = Color.Red;
                }
            }
            else
            {
                function fn = function.getfn;
                //fn.msg("لم يتم تغيير كلمة المرور" + Environment.NewLine + "يرجى المحاولة مرة أخرى", "تغيير كلمة المرور");
                LblHint.Text = "لم يتم تغيير كلمة المرور" + Environment.NewLine + "يرجى المحاولة مرة أخرى";
                LblHint.ForeColor = Color.Red;
            }
            this.Enabled = true;
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
