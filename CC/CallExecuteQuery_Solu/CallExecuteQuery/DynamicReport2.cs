using ClosedXML.Excel;
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
    public partial class DynamicReport2 : Form
    {
        DataTable repMainTbl = new DataTable();
        DataTable repSubTbl = new DataTable();
        List<string> Fieldlst = new List<string>();
        string tableName = "";
        public DynamicReport2()
        {
            InitializeComponent();
        }
        private void DynamicReport2_Load(object sender, EventArgs e)
        {
            WSTransactionHandler.WSTransactionHandler ws = new WSTransactionHandler.WSTransactionHandler();
            repMainTbl = ws.ExecuteQuery("select * from ZZZ_rep_main").Tables[0];
            repSubTbl = ws.ExecuteQuery("select REP_SUB_ID,REP_SUB_RELATION,REP_SUB_TYPE,REP_SUB_DATA_TYPE,REP_SUB_NAME,REP_SUB_TEXT,REP_SUB_SELECT_STMNT,REP_SUB_CREATION,REP_SUB_STATUS,REP_SUB_LENGTH from ZZZ_rep_sub").Tables[0];
            comboBox1.DataSource = repMainTbl;
            comboBox1.ValueMember = "REP_ID";
            comboBox1.DisplayMember = "REP_NAME";
            comboBox1.SelectedIndex = -1;
            comboBox1.SelectedIndexChanged += new EventHandler(SelectedIndexChanged_Changed);
        }
        private void SelectedIndexChanged_Changed(object sender, EventArgs e)
        {
            repSubTbl.DefaultView.RowFilter = "REP_SUB_RELATION = " + comboBox1.SelectedValue;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Visible = true;
            for (int i = 0; i < repSubTbl.DefaultView.Count; i++)
            {
                Label lbl = Lbl(repSubTbl.DefaultView[i]["rep_sub_text"].ToString());
                flowLayoutPanel3.Controls.Add(lbl);
                if (repSubTbl.DefaultView[i]["REP_SUB_TYPE"].ToString().Equals("DateTimePicker"))
                {
                    DateTimePicker pker = new DateTimePicker();
                    pker.Name = repSubTbl.DefaultView[i]["REP_SUB_NAME"].ToString();
                    pker.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    Label lbl1 = Lbl(" إلى ");
                    DateTimePicker pker1 = new DateTimePicker();
                    pker1.Name = repSubTbl.DefaultView[i]["REP_SUB_NAME"].ToString() + "1";
                    pker1.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    flowLayoutPanel3.Controls.Add(pker);
                    flowLayoutPanel3.Controls.Add(lbl1);
                    flowLayoutPanel3.Controls.Add(pker1);
                }
                else if (repSubTbl.DefaultView[i]["REP_SUB_TYPE"].ToString().Equals("TextBox"))
                {
                    TextBox txtbx = new TextBox();
                    txtbx.Name = repSubTbl.DefaultView[i]["REP_SUB_NAME"].ToString();
                    txtbx.Width = 120;
                    txtbx.MaxLength = Convert.ToInt32(repSubTbl.DefaultView[i]["REP_SUB_LENGTH"].ToString());
                    txtbx.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    //flowLayoutPanel3.SetFlowBreak(txtbx, true);
                    flowLayoutPanel3.Controls.Add(txtbx);
                }
            }

            DataRow DataRW = DRW(repMainTbl, comboBox1.SelectedValue, repMainTbl.Columns[0]);
            tableName = DataRW.ItemArray[2].ToString().Split('$')[0];
            string columns = DataRW.ItemArray[2].ToString().Split('$')[1];

            for (int i = 0; i < columns.Split(',').Count(); i++)
            {
                CheckBox chck = new CheckBox();
                string col_total = columns.Split(',')[i].Trim();
                string col_name = col_total.Split(new char[] { 'a', 's' })[0].Trim();
                Fieldlst.Add(col_total);
            }
        }
        private static CheckBox createckckBox(string NM, string txt, bool Stat, bool mandatoryNo)
        {
            CheckBox chck = new CheckBox();
            chck.Name = NM;
            chck.Text = txt;
            chck.TextAlign = ContentAlignment.MiddleCenter;
            chck.Appearance = Appearance.Button;
            chck.Checked = Stat;
            chck.Enabled = mandatoryNo;
            chck.BackColor = Color.LimeGreen;
            chck.Font = new Font("Times new Roman", 12, FontStyle.Bold);
            chck.Height = 27;
            return chck;
        }
             private Label Lbl(string name_)
        {
            Label lbl = new Label();
            lbl.Text = name_ + " : ";
            lbl.Name = name_;
            lbl.Font = new Font("Times new Roman", 14, FontStyle.Bold);
            lbl.RightToLeft = RightToLeft.Yes;
            lbl.Height = 30;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            return lbl;
        }
        private static DataRow DRW(DataTable tbl, object key, DataColumn col)
        {
            tbl.PrimaryKey = new DataColumn[] { col };
            DataRow DRW = tbl.Rows.Find(key);

            return DRW;
        }
        private IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        private void DynamicReport_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 50;
            dataGridView1.Height = this.Height - 300;
        }
        public string exportxlsx(DataTable tbl, string filename)
        {
            string rslt = null;
            using (SaveFileDialog d = new SaveFileDialog())
            {
                d.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                d.Filter = "Excel File|*.xlsx";
                d.FilterIndex = 1;
                d.RestoreDirectory = true;
                d.Title = "Save Excel File";
                d.FileName = "Test";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook Workbook = new XLWorkbook())
                    {
                        try
                        {
                            IXLWorksheet worksheet = Workbook.AddWorksheet(tbl, filename);
                            worksheet.Style.Alignment.WrapText = false;
                            Workbook.SaveAs(d.FileName);
                        }
                        catch (Exception ex)
                        {
                            rslt = ex.Message;
                        }
                    }
                }
                else
                {
                    rslt = "X";
                }
            }
            return rslt;
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            IEnumerable<Control> txtbxs = GetAll(flowLayoutPanel3, typeof(TextBox));

            foreach (TextBox item in txtbxs)
            {
                if (item.Text.Trim().Length == 0)
                {
                    item.Select();
                    MessageBox.Show("برجاء إدخال " + GetNextControl(item, false).Name);
                    return;
                }
            }
            List<string> wherelst = new List<string>();
            bool bol = false;
            foreach (Control ctrl in flowLayoutPanel3.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    if (GetNextControl(ctrl, true).GetType() == typeof(TextBox))
                    {
                        wherelst.Add(GetNextControl(ctrl, true).Name + " = '" + GetNextControl(ctrl, true).Text + "'");
                    }
                    else if (GetNextControl(ctrl, true).GetType() == typeof(DateTimePicker))
                    {
                        if (bol == false)
                        {
                            DateTimePicker pikker = (DateTimePicker)GetNextControl(ctrl, true);
                            Label pikkerXX = (Label)GetNextControl(pikker, true);
                            DateTimePicker pikker2 = (DateTimePicker)GetNextControl(pikkerXX, true);
                            var t = pikker2.Value.Subtract(pikker.Value).Days;
                            if (pikker2.Value.Subtract(pikker.Value).Days <= 31)
                            {
                            wherelst.Add(pikker.Name + " BETWEEN to_date('" + pikker.Value.ToString("dd/MM/yyyy") + "','DD.MM.YYYY') AND to_date('" + pikker2.Value.ToString("dd/MM/yyy") + "','DD.MM.YYYY')");
                            bol = true;
                            }
                            else
                            {
                                MessageBox.Show("أقصى فترة متاحه للتقرير 30 يوم" + Environment.NewLine + "يرجى تقليل المدة وإعادة المحاولة","عرض تقرير " + comboBox1.Text,MessageBoxButtons.OK,MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign |MessageBoxOptions.RtlReading);
                                return;
                            }
                        }
                    }
                }
            }
            string where_ = string.Join(" AND ", wherelst);
            string select_ = "Select " + string.Join(", ", Fieldlst) + " From " + tableName + " Where " + where_;
            WSTransactionHandler.WSTransactionHandler ws = new WSTransactionHandler.WSTransactionHandler();
            try
            {
                dataGridView1.DataSource = ws.ExecuteQuery(select_).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show( "لا توجد بيانات للعرض", "عرض تقرير " + comboBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }
    }
}
