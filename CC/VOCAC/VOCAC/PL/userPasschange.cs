﻿using System;
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
        private static userPasschange frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
            frm.Dispose();
        }
        public static userPasschange getuserPassChangefrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new userPasschange();
                    frm.FormClosed += new FormClosedEventHandler(frm_Closed);
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
                        if (changePasswrd("update Int_user set UsrPassNew ='" + TxtUsrPass.Text + "' where usrid = " + Statcdif.UserTable.Rows[0].Field<int>("UsrId")) == null)
                        {
                            CurrentUser.UsrPWrd = TxtUsrPass.Text;
                            LblHint.Text = "تم تغيير كملمة المرور بنجاج";
                            LblHint.ForeColor = Color.Green;
                            BtSub.Enabled = false;
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
        private string changePasswrd(string selct)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@slctstat", SqlDbType.VarChar);
            param[0].Value = selct;
            DAL.DataAccessLayer.rturnStruct RsultPopulateChoice = DAL.ExcuteCommand("SP_CHOICE_SLCT", param);
            DAL.Close();
            return RsultPopulateChoice.msg;
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
