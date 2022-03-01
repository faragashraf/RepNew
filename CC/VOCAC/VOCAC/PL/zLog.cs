using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOCAUltimate.PL
{
    public partial class zLog : Form
    {
        public zLog()
        {
            InitializeComponent();
        }

        private void BtnRdFl_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Time", typeof(DateTime));
            tbl.Columns.Add("Erro Messege", typeof(string));
            tbl.Columns.Add("Inner Messege", typeof(string));
            tbl.Columns.Add("Erro Code", typeof(string));
            tbl.Columns.Add("Statement/Proc", typeof(string));
            string[] Lines = function.readLog();
            if (Lines.Length > 0)
            {
                foreach (string line in Lines)
                {
                    string DateTime = line.Split(',')[0];
                    string LogMsg = line.Split(',')[1].ToString().Split('$')[0];
                    string LogMsg1 = function.discrypt(LogMsg);
                    string InnerJoin = LogMsg1.ToString().Split('$')[1];

                    string ErrCd = line.Split(',')[1].ToString().Split('$')[1];
                    string ErrCd1 = function.discrypt(ErrCd);
                    string SSqlStrs = line.Split(',')[1].ToString().Split('$')[2];
                    string SSqlStrs1 = function.discrypt(SSqlStrs);
                    tbl.Rows.Add(DateTime, LogMsg1, InnerJoin, ErrCd1, SSqlStrs1);
                }
                LogData.DataSource = tbl;
            }
            Resize_();
        }

        private void ZLog_SizeChanged(object sender, EventArgs e)
        {
            Resize_();
        }
        private void Resize_()
        {
            LogData.Size = new Size(this.Width, this.Height - 100);
            LogData.AutoResizeColumns();
            LogData.AutoResizeRows();
        }
    }
}
