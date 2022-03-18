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
    public partial class DynamicReport : Form
    {
        DataTable repMainTbl = new DataTable();
        DataTable repSubTbl = new DataTable();
        string tableName = "";
        public DynamicReport()
        {
            InitializeComponent();
        }
        private void DynamicReport_Load(object sender, EventArgs e)
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
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Visible = true;
            for (int i = 0; i < repSubTbl.DefaultView.Count; i++)
            {
                CheckBox chk = new CheckBox();
                chk.Name = repSubTbl.DefaultView[i]["rep_sub_ID"].ToString();
                chk.Text = repSubTbl.DefaultView[i]["rep_sub_text"].ToString();
                chk.TextAlign = ContentAlignment.MiddleCenter;
                chk.Appearance = Appearance.Button;
                chk.Checked = false;
                chk.BackColor = Color.White;
                chk.Font = new Font("Times new Roman", 10, FontStyle.Regular);
                chk.Height = 25;
                chk.CheckedChanged += new EventHandler(Color_);
                chk.CheckedChanged += new EventHandler(Checked_Changed);
                flowLayoutPanel2.Controls.Add(chk);
            }

            DataRow DataRW = DRW(repMainTbl, comboBox1.SelectedValue, repMainTbl.Columns[0]);
            tableName = DataRW.ItemArray[2].ToString().Split('$')[0];
            string columns = DataRW.ItemArray[2].ToString().Split('$')[1];

            for (int i = 0; i < columns.Split(',').Count(); i++)
            {
                CheckBox chck = new CheckBox();
                string col_total = columns.Split(',')[i].Trim();
                int p = col_total.Split(new char[] { 'a', 's' }).Length;
                string col_name = col_total.Split(new char[] { 'a', 's' })[0].Trim();
                string col_Capton = col_total.Split(new char[] { 'a', 's' })[2].Trim();
                int Cnt = col_Capton.Length;
                col_Capton = col_Capton.Substring(1, Cnt - 2);
                if (i == 0) { chck = createckckBox(col_name, col_Capton, true, false); }
                else { chck = createckckBox(col_name, col_Capton, true, true); }
                flowLayoutPanel1.Controls.Add(chck);
                chck.CheckedChanged += new EventHandler(Color_);
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
        private void Color_(object sender, EventArgs e)
        {
            CheckBox snder = (CheckBox)sender;
            foreach (Control c in snder.Parent.Controls)
            {
                if (c.GetType() == typeof(CheckBox))
                {
                    CheckBox chck_ = (CheckBox)c;
                    if (chck_.Checked == true)
                    {
                        chck_.BackColor = Color.LimeGreen;
                        chck_.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    }
                    else
                    {
                        chck_.BackColor = Color.White;
                        chck_.Font = new Font("Times new Roman", 10, FontStyle.Regular);
                    }
                }
            }
        }
        private Label chkBx(string name_)
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
        private void Checked_Changed(object sender, EventArgs e)
        {
            CheckBox checkBx = (CheckBox)sender;
            DataRow DataRW = DRW(repSubTbl, checkBx.Name, repSubTbl.Columns[0]);
            Label lbl = chkBx(DataRW.ItemArray[5].ToString());

            Control[] cntrolDel = flowLayoutPanel3.Controls.Find(lbl.Name, true);
            if (cntrolDel.Count() == 0)
            {
                flowLayoutPanel3.Controls.Add(lbl);
                if (DataRW.ItemArray[2].ToString() == "TextBox")
                {
                    TextBox txtbx = new TextBox();
                    txtbx.Name = DataRW.ItemArray[4].ToString();
                    txtbx.Width = 120;
                    txtbx.MaxLength = Convert.ToInt32(DataRW.ItemArray[9]);
                    txtbx.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    //flowLayoutPanel3.SetFlowBreak(txtbx, true);
                    flowLayoutPanel3.Controls.Add(txtbx);
                }
                else if (DataRW.ItemArray[2].ToString() == "DateTimePicker")
                {
                    DateTimePicker pker = new DateTimePicker();
                    pker.Name = DataRW.ItemArray[4].ToString();
                    pker.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    Label lbl1 = chkBx(" إلى ");
                    DateTimePicker pker1 = new DateTimePicker();
                    pker1.Name = DataRW.ItemArray[4].ToString() + "1";
                    pker1.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    flowLayoutPanel3.Controls.Add(pker);
                    flowLayoutPanel3.Controls.Add(lbl1);
                    flowLayoutPanel3.Controls.Add(pker1);
                    //flowLayoutPanel3.SetFlowBreak(pker1, true);
                }
            }
            else
            {
                if (cntrolDel[0].Name.Contains("تاريخ"))
                {
                    Control pikr1 = GetNextControl(cntrolDel[0], true);
                    Control pikr2 = GetNextControl(pikr1, true);
                    Control lblDel = GetNextControl(pikr2, true);

                    flowLayoutPanel3.Controls.RemoveByKey(lblDel.Name);
                    flowLayoutPanel3.Controls.RemoveByKey(pikr2.Name);
                    flowLayoutPanel3.Controls.RemoveByKey(pikr1.Name);
                    flowLayoutPanel3.Controls.RemoveByKey(cntrolDel[0].Name);
                }
                else
                {
                    flowLayoutPanel3.Controls.RemoveByKey(GetNextControl(cntrolDel[0], true).Name);
                    flowLayoutPanel3.Controls.RemoveByKey(cntrolDel[0].Name);
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
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
            List<string> lst = new List<string>();
            foreach (CheckBox ctrl in flowLayoutPanel1.Controls)
            {

                if (ctrl.Checked)
                {
                    lst.Add(ctrl.Name + " AS \"" + ctrl.Text + "\"");
                }
            }
            List<string> lst2 = new List<string>();
            bool bol = false;
            foreach (Control ctrl in flowLayoutPanel3.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    if (GetNextControl(ctrl, true).GetType() == typeof(TextBox))
                    {
                        lst2.Add(GetNextControl(ctrl, true).Name + " = '" + GetNextControl(ctrl, true).Text + "'");
                    }
                    else if (GetNextControl(ctrl, true).GetType() == typeof(DateTimePicker))
                    {
                        if (bol == false)
                        {
                            DateTimePicker pikker = (DateTimePicker)GetNextControl(ctrl, true);
                            Label pikkerXX = (Label)GetNextControl(pikker, true);
                            DateTimePicker pikker2 = (DateTimePicker)GetNextControl(pikkerXX, true);
                            lst2.Add(pikker.Name + " BETWEEN to_date('" + pikker.Value.ToString("dd/MM/yyyy") + "','DD.MM.YYYY') AND to_date('" + pikker2.Value.ToString("dd/MM/yyy") + "','DD.MM.YYYY')");
                            bol = true;
                        }
                    }
                }
            }
            string where_ = string.Join(" AND ", lst2);
            string select_ = "Select " + string.Join(", ", lst) + " From " + tableName + " Where " + where_;
            WSTransactionHandler.WSTransactionHandler ws = new WSTransactionHandler.WSTransactionHandler();
            try
            {
                dataGridView1.DataSource = ws.ExecuteQuery(select_).Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("لا توجد بيانات للعرض");
            }
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
    }
}
