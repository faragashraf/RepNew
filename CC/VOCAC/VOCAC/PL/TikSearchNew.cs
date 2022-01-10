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

namespace VOCAC
{
    public partial class TikSearchNew : Form
    {
        public TikSearchNew()
        {
            InitializeComponent();
        }

        private void TikSearchNew_Load(object sender, EventArgs e)
        {

        }

        private void SerchTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Filter()
        {
            StringBuilder FltrStr = new StringBuilder();
            string LK = " like ";
            string strt = "'%";
            string end_ = "%'";

            if (Rd_strtwith.Checked) { strt = "'"; end_ = "%'"; }
            else if (Rd_contain.Checked) { strt = "'%"; end_ = "%'"; }
            else if (Rd_endwith.Checked) { strt = "'%"; end_ = "'"; }

            if (Rd_Equal.Checked) { LK = " = "; strt = "'"; end_ = "'"; }
            else if (Rd_Like.Checked) { LK = " Like "; };

            //FltrStr.Append(" (");
            //FltrStr.Append(" [TkSQL]" + LK + strt + SerchTxt.Text + end_);
            FltrStr.Append(" where  [TkSQL]" + LK + strt + SerchTxt.Text + end_);

            DAL.DataAccessLayer.myStruct Struc = new DAL.DataAccessLayer.myStruct();
            Struc = Search_(FltrStr.ToString());
            GridTicket.DataSource = Struc.dt;
            this.Text += Struc.dt.Rows.Count.ToString();
        }

        private DAL.DataAccessLayer.myStruct Search_(string Where_)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Wher_", SqlDbType.VarChar,3000);
            param[0].Value = Where_;
            //param[0] = new SqlParameter("@slct", SqlDbType.VarChar, 1);
            //param[0].Value = Empty;
            //
            DAL.Struc = DAL.SelectData("AAA", param);
            DAL.Close();
            return DAL.Struc;
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Chckfltr_CheckedChanged(object sender, EventArgs e)
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

        private void BtnSerch_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void TikSearchNew_SizeChanged(object sender, EventArgs e)
        {
            GridTicket.Size = new Size(this.Width - 50, this.Height - 260);
            //FlowLayoutPanel2.Margin = new Padding((this.Width - FlowLayoutPanel2.Width) / 2, FlowLayoutPanel2.Margin.Top, FlowLayoutPanel2.Margin.Right, FlowLayoutPanel2.Margin.Bottom);
            GridTicket.Margin = new Padding((this.Width - GridTicket.Width) / 2, GridTicket.Margin.Top, GridTicket.Margin.Right, GridTicket.Margin.Bottom);
            //flowLayoutPanel3.Margin = new Padding((this.Width - flowLayoutPanel3.Width) / 2, flowLayoutPanel3.Margin.Top, flowLayoutPanel3.Margin.Right, flowLayoutPanel3.Margin.Bottom);
        }
    }
}
