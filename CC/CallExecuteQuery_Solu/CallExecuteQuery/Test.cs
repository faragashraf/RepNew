using CallExecuteQuery.WiproInterface;
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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrackingResource[] rr;
            rr = trackReturn(textBox1.Text);
            rr.First();
            dataGridView1.DataSource = rr;
            iTEM_IDField.Text = rr[0].ITEM_ID;
            EVENT_DATE.Text = rr[0].EVENT_DATE.ToString();
            textBox2.Text = rr[0].LOCATION.ToString();
            textBox3.Text = rr[0].LOCATION_AR.ToString();
            textBox4.Text = rr[0].LATEST_STATUS_DESC_AR.ToString();
            textBox5.Text = rr[0].CITY_AR.ToString();
            textBox6.Text = rr[0].SERVICE_DESC_AR.ToString();
        }

        private static TrackingResource[] trackReturn(string Tack)
        {
            WiproInterface.WiproInterface wbs = new WiproInterface.WiproInterface();
            TrackingResource[] ddd = wbs.ItemTrackingByBarcode(Tack);
            return ddd;
        }
    }
}
