using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallExecuteQuery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WSTransactionHandler.WSTransactionHandler ws = new WSTransactionHandler.WSTransactionHandler();
            DataTable dt = ws.ExecuteQuery
                ("select * from CORPORATE_SUPPLY_TRANS WHERE SERVICE_CODE IN ('CA','ES')")
                .Tables[0];

            dataGridView1.DataSource = dt;
            string gg="";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                gg += dt.Columns[i].ColumnName + ",";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DynamicReport o = new DynamicReport();
            o.Show();
        }
    }
}
