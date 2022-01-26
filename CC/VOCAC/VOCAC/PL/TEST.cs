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
    public partial class TEST : Form
    {
        SqlCommand cmdSelectCommand;
        SqlConnection sqlcon;
        SqlDataAdapter dadPurchaseInfo = new SqlDataAdapter();
        SqlCommandBuilder builder;
        DataTable CompSurceTable;
        public TEST()
        {
            InitializeComponent();
        }

        private void TEST_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(Statcdif.strConn);
            cmdSelectCommand = new SqlCommand("select *,(select Int_user.UsrRealNm from Int_user where Int_user.UsrId = FnMngr) from CDFnProd order by FnSQL	", sqlcon);
            dadPurchaseInfo.SelectCommand = cmdSelectCommand;
            CompSurceTable = new DataTable();
            dadPurchaseInfo.Fill(CompSurceTable);
            builder = new SqlCommandBuilder(dadPurchaseInfo);
            dataGridView1.DataSource = CompSurceTable;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dadPurchaseInfo.Update(CompSurceTable);
            CompSurceTable.Rows.Clear();
            dadPurchaseInfo.Fill(CompSurceTable);
            dataGridView1.DataSource = CompSurceTable;
        }
    }
}
