using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;
namespace VOCAC.PL
{
    public partial class TikSetup : Form
    {
        private static TikSetup frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static TikSetup getTiksetupfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikSetup();
                    frm.FormClosed += new FormClosedEventHandler(frm_Closed);
                }
                return frm;
            }
        }
        DataTable MendfildTable;
        int TickKind;
        string PrdKind;
        string fieldtyp = null;
        string langues = null;
        string datatype = null;
        string length = null;
        string mask = null;
        SqlConnection sqlcon = new SqlConnection(Statcdif.strConn);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlCommandBuilder sqlcmb;
        public TikSetup()
        {
            InitializeComponent();
        }
        private void TikSetup_Load(object sender, EventArgs e)
        {
            getmendtbl();
        }
        private void PopulateTree()
        {

            if (RadioButton4.Checked)
            {
                TickKind = 0;
                this.Text = "إعدادات الطبات";
            }

            else if (RadioButton5.Checked)
            {
                TickKind = 1;
                this.Text = "إعدادات الشكاوى";
            }

            TreeView1.Visible = true;
            TreeView1.Nodes.Clear();

            if (TreeView1.Nodes.Count == 0)
            {
                String Child1 = "";
                TreeView1.ImageList = ImgLst;
                for (int i = 0; i < Statcdif.ProdKTable.Rows.Count; i++)
                {
                    TreeView1.Nodes.Add(Statcdif.ProdKTable.Rows[i][0].ToString(), Statcdif.ProdKTable.Rows[i][1].ToString(), 1, 3);
                }
                if (TickKind == 0)
                {
                    Statcdif.ProdCompTable.DefaultView.RowFilter = "[CompReqst] = " + true;
                }
                else
                {
                    Statcdif.ProdCompTable.DefaultView.RowFilter = "[CompReqst] = " + false;
                }
                //Populate Products Nodes
                for (int i = 0; i < Statcdif.ProdCompTable.DefaultView.Count; i++)
                {
                    foreach (TreeNode n in this.TreeView1.Nodes)
                    {
                        if (n.Name.Equals(Statcdif.ProdCompTable.DefaultView[i][1].ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            TreeView1.SelectedNode = n;
                        }
                    }
                    if (Child1 != Statcdif.ProdCompTable.DefaultView[i]["PrdNm"].ToString())
                    {
                        TreeView1.SelectedNode.Nodes.Add(Statcdif.ProdCompTable.Rows[i]["FnProdCd"].ToString(), Statcdif.ProdCompTable.DefaultView[i]["PrdNm"].ToString(), 1, 3);
                    }
                    Child1 = Statcdif.ProdCompTable.DefaultView[i]["PrdNm"].ToString();
                }
                for (int i = 0; i < Statcdif.ProdCompTable.DefaultView.Count; i++)
                {
                    for (int o = 0; o < TreeView1.Nodes.Count; o++)
                    {
                        for (int p = 0; p < TreeView1.Nodes[o].Nodes.Count; p++)
                        {
                            if (TreeView1.Nodes[o].Nodes[p].ToString().Split(':')[1].Trim().Equals(Statcdif.ProdCompTable.DefaultView[i]["PrdNm"].ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                TreeView1.Nodes[o].Nodes[p].Nodes.Add(Statcdif.ProdCompTable.DefaultView[i]["FnSQL"].ToString(), Statcdif.ProdCompTable.DefaultView[i]["CompNm"].ToString(), 0, 2);
                                for (int q = 0; q < TreeView1.Nodes[o].Nodes[p].GetNodeCount(true); q++)
                                {
                                    TreeView1.Nodes[o].Nodes[p].Nodes[q].ForeColor = Color.Green;
                                }
                                TreeView1.Nodes[o].Nodes[p].ForeColor = Color.FromArgb(165, 42, 42);
                            }
                        }
                    }

                }
            }
            TreeView1.Visible = true;
            TreeView1.SelectedNode = null;
        }
        private void RadClick_CheckedChanged(object sender, EventArgs e)
        {
            PopulateTree();
        }
        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (TreeView1.SelectedNode == null)
            {
            }
            else if (TreeView1.SelectedNode.Level == 2)
                TreeView1.SelectedNode.Parent.Parent.Collapse(false);  // True to leave the child nodes in their Current state; false to collapse the child nodes.
            else if (TreeView1.SelectedNode.Level == 1)
                // CombProdRef.Items.Clear()
                TreeView1.SelectedNode.Parent.Collapse(false);
            else if (TreeView1.SelectedNode.Level == 0)
                // CombProdRef.Items.Clear()
                TreeView1.SelectedNode.Collapse(false);
        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView1.SelectedNode.Expand();
            if (TreeView1.SelectedNode.Level == 2)
            {
                btnaddnew.Visible = true;
                PrdKind = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[0];
                Prdct.Text = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[1];
                Comp.Text = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[2];
                CdfnID.Text = TreeView1.SelectedNode.Name;
                Statcdif.MendFildsTable.DefaultView.RowFilter = "[MendCdFn]  = " + TreeView1.SelectedNode.Name;
                FlwMend.Controls.Clear();
                Statcdif.FildList.Clear();
                for (int i = 0; i < Statcdif.MendFildsTable.DefaultView.Count; i++)
                {
                    addfieldtoflow(Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"].ToString(), 
                        Statcdif.MendFildsTable.DefaultView[i]["CDMendDatatype"].ToString(), 
                        Convert.ToBoolean(Statcdif.MendFildsTable.DefaultView[i]["MendStat"]));
                }
                if (Statcdif.FildList.Count > 0)
                {
                    MendfildTable.DefaultView.RowFilter = "CDMendTxt not in (" + string.Join(" ,", Statcdif.FildList) + ")";
                }
                else { MendfildTable.DefaultView.RowFilter = string.Empty; }

                dataGridView1.DataSource = MendfildTable.DefaultView;
            }
            else if (TreeView1.SelectedNode.Level < 2)
            {
                PrdKind = "";
                Prdct.Text = "";
                Comp.Text = "";
                FlwMend.Controls.Clear();
                CdfnID.Text = "";
                btnaddnew.Visible = false;
                DisposeAdditionFlowpanel();
            }
            if (TreeView1.SelectedNode.FullPath.ToString().Split('\\')[0] != PrdKind)
            {
                PrdKind = "";
            }
        }
        private void Timertrigger_Tick(object sender, EventArgs e)
        {

            int validation = 0;
            //Validate If Field Name length > 0 and Validate if Exists
            if (txtfldnm.Text.Trim().Length > 0)
            {
                if (validateFledName() == false)
                {
                    validation++;
                }
            }
            else
            {
                labfldNm.Text = "";
            }
            //Return Field Type
            fieldtyp = validateflowPanelChoice(flowfieldtyp);

            //Validate and Return Field Type
            if (fieldtyp != null) { validation++; }

            //Exclude Langueges & Data Type Validation And ++ Validation Counter
            if (DateTimePicker.Checked == true || TextBoxC.Checked == true)
            {
                validation++;
                validation++;
                flowLangues.Enabled = false;
                flowdatatype.Enabled = false;
            }
            else if (DateTimePicker.Checked == false || TextBoxC.Checked == false)
            {
                flowLangues.Enabled = true;
                flowdatatype.Enabled = true;

                langues = validateflowPanelChoice(flowLangues);
                datatype = validateflowPanelChoice(flowdatatype);
                if (langues != null) { validation++; }
                if (datatype != null) { validation++; }

                if (TextBox.Checked == true)
                {
                    if (txtlength.Text.Length > 0 && Convert.ToInt32(txtlength.Text) > 0)
                    {
                        validation++;
                        length = txtlength.Text;
                    }
                    else
                    {
                        txtlength.Text = "0";
                        length = null;
                    }
                }
                else if (MaskedTextBox.Checked == true)
                {
                    if (txtmask.Text.Length > 0)
                    {
                        validation++;
                        mask = txtmask.Text;
                    }
                    else
                    {
                        mask = null;
                    }
                }
                langues += "-" + datatype;
                if (chckprodindent.Checked == true)
                {
                    langues += "-" + "N";
                }
            }
            //Deduct Validation Value -- if TextBoxC has been selected
            if (TextBoxC.Checked == true) { validation--; }

            if (validation == 5)
            {
                btnsubmit.Enabled = true;
            }
            else
            {
                btnsubmit.Enabled = false;
            }
        }
        private bool validateFledName()
        {
            bool exists = false;
            if (txtfldnm.Text.Trim().Length > 0)
            {
                for (int i = 0; i < MendfildTable.Rows.Count; i++)
                {
                    if (MendfildTable.Rows[i]["CDMendTxt"].ToString().Trim().Contains(txtfldnm.Text))
                    {
                        exists = true;
                        labfldNm.Text = "- هناك حقل بالفعل باسم \"" + MendfildTable.Rows[i]["CDMendTxt"].ToString() + "\"";
                        break;
                    }
                    else if (txtfldnm.Text.Trim().Equals(MendfildTable.Rows[i]["CDMendTxt"].ToString()))
                    {
                        exists = true;
                        labfldNm.Text = "- اسم الحقل موجود بالفعل" + Environment.NewLine;
                        break;
                    }
                    else
                    {
                        labfldNm.Text = "";
                    }
                }
            }
            return exists;
        }
        private string validateflowPanelChoice(FlowLayoutPanel Flw)
        {
            string strrtrn = null;
            foreach (RadioButton chbx in Flw.Controls)
            {
                if (chbx.Checked == true)
                {
                    strrtrn = chbx.Name;
                    chbx.ForeColor = Color.Green;
                    chbx.Font = new Font("Times new Roman", 14, FontStyle.Bold);
                }
                else
                {
                    chbx.ForeColor = Color.Black;
                    chbx.Font = new Font("Times new Roman", 14, FontStyle.Regular);
                }
            }
            return strrtrn;
        }
        private void Btnaddnew_Click(object sender, EventArgs e)
        {
            timertrigger.Start();
            btnaddnew.Enabled = false;
            flowMend.Visible = true;
        }
        private void Btnsubmit_Click(object sender, EventArgs e)
        {

            if (insertnewMendField(fieldtyp, txtfldnm.Text, langues, Convert.ToInt32(length), mask) != null)
            {
                function fn = function.getfn;
                fn.msg("هناك خطأ في الإتصال بقواعد البيانات", "متابعة الشكاوى");
            }
            else
            {
                //MendfildTable.Rows.Add(fieldtyp, txtfldnm.Text, null, langues, length, mask);
                DisposeAdditionFlowpanel();
                sqlcmb = new SqlCommandBuilder(da);
                MendfildTable.Rows.Clear();
                da.Fill(MendfildTable);
            }
        }
        private void Btncancel_Click(object sender, EventArgs e)
        {
            DisposeAdditionFlowpanel();
        }
        private void DisposeAdditionFlowpanel()
        {
            txtfldnm.Text = "";
            txtmask.Text = "";
            txtlength.Text = "0";
            timertrigger.Stop();
            DisposeflowPanelChoice(flowfieldtyp);
            DisposeflowPanelChoice(flowLangues);
            DisposeflowPanelChoice(flowdatatype);
            btnaddnew.Enabled = true;
            flowMend.Visible = false;
        }
        private void DisposeflowPanelChoice(FlowLayoutPanel Flw)
        {

            foreach (RadioButton chbx in Flw.Controls)
            {
                if (chbx.Checked == true)
                {
                    chbx.Checked = false;
                }
            }
        }
        private void TextBoxC_CheckedChanged(object sender, EventArgs e)
        {
            if (TextBoxC.Checked == true)
            {
                lblcaution.Text = "- اختيار الحقل من هذا النوع يتطلب إضافة على قواعد البيانات" + Environment.NewLine + "- يرجى الرجوع لمدير قواعد البيانات" + Environment.NewLine + "--------------------------------------------";
                txtmask.Text = "";
                txtlength.Text = "0";
            }
            else
            {
                lblcaution.Text = "";

            }
        }
        private void MaskedTextBox_ClientSizeChanged(object sender, EventArgs e)
        {
            if (MaskedTextBox.Checked == true)
            {
                txtmask.Enabled = true;
                txtlength.Text = "0";
            }
            else
            {
                txtmask.Enabled = false;
            }
        }
        private void TextBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TextBox.Checked == true)
            {
                txtlength.Enabled = true;
                txtmask.Text = "";
            }
            else
            {
                txtlength.Enabled = false;
            }
        }
        private void DateTimePicker_CheckedChanged(object sender, EventArgs e)
        {
            if (DateTimePicker.Checked == true)
            {
                txtlength.Text = "0";
                txtmask.Text = "";
            }
        }
        private void Txtmask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Back || (Keys)e.KeyChar == Keys.Space || ("0").IndexOf(e.KeyChar) == 0 ||
                e.KeyChar == 76)
            { }
            else
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
                toolTip1.Show("الحقل يقبل فقط حرف L ورقم 0" + Environment.NewLine + "حرف L يرمز للحروف، ورقم 0 يرمز للأرقام", ActiveControl, 0, 20, 1000);
            }
        }
        private void Txtlength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtlength.Text.Length == 0)
            {
                txtlength.Text = "0";
            }
            else
            {
                if ((Keys)e.KeyChar == Keys.Back || char.IsDigit(e.KeyChar) && Convert.ToInt32(txtlength.Text) <= 3200)
                { }
                else
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    txtlength.Focus();
                    toolTip1.Show("الحقل يقبل فقط أرقام من 0 إلى 9" + Environment.NewLine + "والرقم أقل من أو يساوي 32000", ActiveControl, 0, 20, 1000);
                }
            }

        }
        private void Txtfldnm_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox TempNum = (TextBox)sender;
            if (char.IsControl(e.KeyChar) == false && char.IsDigit(e.KeyChar) && TempNum.Text.ToCharArray().Count(c => c == Convert.ToChar("1")) < 1 ||
                                  (char.IsLetter(e.KeyChar)) ||
                                  (char.IsWhiteSpace(e.KeyChar)) ||
                                    (Keys)e.KeyChar == Keys.Back ||
     ((Keys)e.KeyChar == Keys.ShiftKey) && (char.IsLetter(e.KeyChar)))
            {

            }
            else
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
                toolTip1.Show("الحقل يقبل حروف عربية وانجليزية ورقم واحد فقط", ActiveControl, 0, 20, 1000);
            }
        }
        private DataTable getmendtbl()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Mend_SLCT";
            cmd.Connection = sqlcon;
            da = new SqlDataAdapter(cmd);
            MendfildTable = new DataTable();
            try
            {
                da.Fill(MendfildTable);
            }
            catch (Exception ex)
            {
                function fn = function.getfn;
                fn.msg("هناك خطأ في الإتصال بقواعد البيانات", "متابعة الشكاوى");
            }
            DAL.Close();
            return MendfildTable;
        }
        private string insertnewMendField(string fieldtyp, string txtfldnm, string langues, int length, string mask)
        {
            string msg = null;
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            cmd = new SqlCommand();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@fieldtype", SqlDbType.VarChar, 50);
            param[0].Value = fieldtyp;
            param[1] = new SqlParameter("@fieldname", SqlDbType.VarChar, 50);
            param[1].Value = txtfldnm;
            param[2] = new SqlParameter("@datatype", SqlDbType.VarChar, 50);
            param[2].Value = langues;
            param[3] = new SqlParameter("@length", SqlDbType.Int);
            param[3].Value = length;
            param[4] = new SqlParameter("@mask", SqlDbType.VarChar, 30);
            param[4].Value = mask;
            DAL.Open();
            try
            {
                DAL.Struc = DAL.ExcuteCommand("SP_Mend_INSERT", param);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            DAL.Close();
            return msg;
        }
        private string addMendField(string MendCdFn, string MendField, bool MendStat)
        {
            string msg = null;
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            cmd = new SqlCommand();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@MendCdFn", SqlDbType.Int);
            param[0].Value = MendCdFn;
            param[1] = new SqlParameter("@MendField", SqlDbType.VarChar, 50);
            param[1].Value = MendField;
            param[2] = new SqlParameter("@MendStat", SqlDbType.Bit);
            param[2].Value = MendStat;
            DAL.Open();
            try
            {
                DAL.Struc = DAL.ExcuteCommand("SP_MendCDFN_INSERT", param);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            DAL.Close();
            return msg;
        }
        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (addMendField(TreeView1.SelectedNode.Name, dataGridView1.CurrentRow.Cells[1].Value.ToString(),true) != null)
            {
                function fn = function.getfn;
                fn.msg("هناك خطأ في الإتصال بقواعد البيانات", "متابعة الشكاوى");
            }
            else
            {
                addfieldtoflow(dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString(), true);
                if (Statcdif.FildList.Count > 0)
                {
                    MendfildTable.DefaultView.RowFilter = "CDMendTxt not in (" + string.Join(" ,", Statcdif.FildList) + ")";
                }
                else { MendfildTable.DefaultView.RowFilter = string.Empty; }

                dataGridView1.DataSource = MendfildTable.DefaultView;
            }
          
        }
        private void addfieldtoflow(string fildname, string datatype, bool status)
        {
            CheckBox txtfld = new CheckBox();
            CheckBox ProdIdentefication = new CheckBox();
            txtfld.Font = new Font("Times new Roman", 12, FontStyle.Bold);
            txtfld.TextAlign = ContentAlignment.MiddleCenter;
            txtfld.Size = new Size(100, 30);

            if (status == true)
            {
                txtfld.BackColor = Color.Red;
            }
            else
            {
                txtfld.BackColor = Color.LimeGreen;
            }

            txtfld.Text = fildname;
            txtfld.Appearance = Appearance.Button;
            FlwMend.Controls.Add(txtfld);
            if (datatype.Split('-').Count() > 2)
            {
                if (datatype.Split('-')[2].Equals("N"))
                {
                    FlwMend.SetFlowBreak(txtfld, false);
                    ProdIdentefication.Checked = true;
                    ProdIdentefication.Enabled = false;
                    ProdIdentefication.Width = 150;
                    ProdIdentefication.RightToLeft = RightToLeft.Yes;
                    ProdIdentefication.Text = "مطابقة رقم تعريف المنتج";
                    FlwMend.SetFlowBreak(ProdIdentefication, true);
                    FlwMend.Controls.Add(ProdIdentefication);
                }
            }
            else { FlwMend.SetFlowBreak(txtfld, true); }
            Statcdif.FildList.Add("'" + fildname + "'");        
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            TEST hh = new TEST();
            hh.ShowDialog();
        }
    }
}

