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
using VOCAC.BL;
using VOCAC.Properties;

namespace VOCAC.PL
{
    public partial class TikNew : Form
    {
        frms forms = new frms();
        function fn = function.getfn;
        DataTable RelatedTable = new DataTable();
        Form Frm;
        DataGridView GV;
        DataTable tbl;
        FlowLayoutPanel Flow;
        TextBox TxBox;
        TextBox sndr;
        int TickKind;
        string PrdKind;
        public TikNew()
        {
            InitializeComponent();
            forms.FrmAllSub(this);
            NewTickSub();
        }
        private void TikNew_Load(object sender, EventArgs e)
        {

        }
        private void NewTickSub()
        {
            FlwMainData.Enabled = false;
            FlwMend.Enabled = true;
            FlwMend.Controls.Clear();
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
            TreeView1.Enabled = true;
            TreeView1.Visible = false;
            TreeView1.CollapseAll();

            SubmitBtn.Visible = true;
            SubmitBtn.Enabled = false;
            BtnDublicate.Visible = false;
            RelatedTable.Rows.Clear();

            List<Control> CTRLLst = new List<Control>();
            CTRLLst = forms.GetAll(this).ToList();

            foreach (Control c in CTRLLst)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(MaskedTextBox))
                {
                    TextBox TB = new TextBox();
                    MaskedTextBox MTB = new MaskedTextBox();
                    try { TB = (TextBox)c; } catch (Exception) { MTB = (MaskedTextBox)c; }
                    TB.Text = "";
                    if (TB.ReadOnly == false)
                    {
                        c.BackColor = Color.White;
                        c.ForeColor = Color.Black;
                    }
                }
                else if (c.GetType() == typeof(ComboBox))
                {
                    ComboBox TB = (ComboBox)c;
                    TB.SelectedIndex = -1;
                }
                c.Enabled = true;
            }
            RadioButton4.Checked = false;
            RadioButton5.Checked = false;
            RadioButton8.Checked = false;
            RadioButton9.Checked = false;
            RadioButton11.Checked = false;
            RadioButton12.Checked = false;

            BtnAdd.Visible = false;
            BtnClr.Visible = false;

            Phon1TxtBx.Enabled = false;
            Phon2TxtBx.Enabled = false;
            ComRefLbl.Text = "";
            IDTxtBx.Text = "";
            IDTxtBx.Mask = "00000000000000";
            RadNID.Checked = true;

            TickKind = 0;
            PrdKind = "";
            MyGroupBox3.Enabled = true;
        }
        private void Mendatory()
        {
            Timer1.Stop();
            double Complete_ = 0;
            if (PrdKind == "مالية")
            {
                //Check Customer ID
                if (RadNID.Checked == true && IDTxtBx.Text.Replace(" ", "").Trim().Length == 14)
                {
                    Complete_ += 1;
                }
                else if (RadPss.Checked == true && IDTxtBx.Text.Replace(" ", "").Trim().Length > 0)
                {
                    Complete_ += 1;
                }
                Label29.Visible = true;
            }
            else
            {
                Label29.Visible = false;
            }

            //Check Customer Phone 1
            if (Phon1TxtBx.Mask.Length == Phon1TxtBx.Text.Replace(" ", "").Trim().Length)
            {
                Complete_ += 1;
            }
            //Check Tree Selection
            if (TreeView1.SelectedNode != null)
            {
                if (TreeView1.SelectedNode.Level == 2)
                {
                    Complete_ += 1;
                }
            }
            //Check Customer Name 
            if (NameTxtBx.Text.Trim().ToCharArray().Count(c => c == Convert.ToChar(" ")) > 1)
            {
                Complete_ += 1;
            }
            //Check Complaint Source
            if (SrcCmbBx.SelectedIndex != -1)
            {
                Complete_ += 1;
            }
            foreach (Control Ctrl in FlwMend.Controls)
            {
                if (Ctrl.GetType() == typeof(TextBox))
                {
                    if (Ctrl.Text.Replace(" ", "").Trim().Length > 0)
                    {
                        Complete_ += 1;
                    }
                }
                else if (Ctrl.GetType() == typeof(MaskedTextBox))
                {
                    MaskedTextBox mskd = new MaskedTextBox();
                    mskd = (MaskedTextBox)Ctrl;
                    if (mskd.Mask.Replace(" ", "").Trim().Length == mskd.Text.Replace(" ", "").Trim().Length)
                    {
                        Complete_ += 1;
                    }
                }
                else if (Ctrl.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker Dpkr = new DateTimePicker();
                    Dpkr = (DateTimePicker)Ctrl;
                    if (Dpkr.Value.ToString("dd/MM/yyyy") != DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"))
                    {
                        Complete_ += 1;
                    }
                }
            }


            //if (Complete_ / (5 + (FlwMend.Controls.Count) / 2) < 0.7 
            //    SubmitBtn.BackgroundImage = My.Resources.SaveRed1
            //else if Complete_ / (5 + (FlwMend.Controls.Count) / 2) > 0.5 
            //    SubmitBtn.BackgroundImage = My.Resources.SaveGreen1
            //End if
            if (PrdKind == "مالية")
            {
                if (Complete_ == 5 + (FlwMend.Controls.Count / 2))
                {
                    SubmitBtn.Enabled = true;
                    SubmitBtn.BackgroundImage = Resources.SaveGreen1;
                }
                else if (Complete_ / (5 + (FlwMend.Controls.Count / 2)) <= 0.5)
                {
                    SubmitBtn.BackgroundImage = Resources.SaveRed;
                    SubmitBtn.Enabled = false;
                }
                else if (Complete_ / (5 + (FlwMend.Controls.Count / 2)) > 0.5)
                {
                    SubmitBtn.BackgroundImage = Resources.SaveGreen;
                    SubmitBtn.Enabled = false;
                }
                //else
                //    SubmitBtn.Enabled = false
                //SubmitBtn.BackgroundImage = My.Resources.SaveRed1
            }
            else if (PrdKind == "بريدية")
            {
                if (Complete_ == 4 + (FlwMend.Controls.Count) / 2)
                {
                    SubmitBtn.Enabled = true;
                    SubmitBtn.BackgroundImage = Resources.SaveGreen1;
                }
                else if (Complete_ / (4 + (FlwMend.Controls.Count) / 2) <= 0.5)
                {
                    SubmitBtn.BackgroundImage = Resources.SaveRed;
                    SubmitBtn.Enabled = false;
                }
                else if (Complete_ / (4 + (FlwMend.Controls.Count) / 2) > 0.5)
                {
                    SubmitBtn.BackgroundImage = Resources.SaveGreen;
                    SubmitBtn.Enabled = false;
                }
                //else
                //    SubmitBtn.Enabled = false
                //SubmitBtn.BackgroundImage = My.Resources.SaveRed1
            }
            else if (PrdKind == "")
            {
                SubmitBtn.BackgroundImage = Resources.SaveRed;
                SubmitBtn.Enabled = false;
            }
            GC.Collect();
            Timer1.Start();
        }
        private void CompReqst_CheckedChanged(object sender, EventArgs e)
        {
            this.TreeView1.AfterSelect -= new TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.TreeView1.BeforeSelect -= new TreeViewCancelEventHandler(TreeView1_BeforeSelect);
            if (RadioButton4.Checked)
            {
                TickKind = 0;
                this.Text = "تسجيل طلب جديد";
            }

            else if (RadioButton5.Checked)
            {
                TickKind = 1;
                this.Text = "تسجيل شكوى جديدة";
            }

            if (SrcCmbBx.Items.Count == 0)
            {
                SrcCmbBx.DataSource = Statcdif.CompSurceTable;
                SrcCmbBx.SelectedIndex = -1;
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
                        if (n.Name == Statcdif.ProdCompTable.DefaultView[i][1].ToString())
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
                            if (TreeView1.Nodes[o].Nodes[p].ToString().Split(':')[1].Trim() == Statcdif.ProdCompTable.DefaultView[i]["PrdNm"].ToString())
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
            MyGroupBox2.Enabled = true;
            FlwMainData.Enabled = true;
            this.TreeView1.AfterSelect += new TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.TreeView1.BeforeSelect += new TreeViewCancelEventHandler(this.TreeView1_BeforeSelect);
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
            BtnAdd.Enabled = true;
            if (TreeView1.SelectedNode.Level == 2)
            {
                Timer1.Start();
                BtnAdd.Visible = true;
                BtnClr.Visible = false;
                Statcdif.MendFildsTable.DefaultView.RowFilter = "[MendCdFn]  = " + TreeView1.SelectedNode.Name;
                FlwMend.Controls.Clear();

                for (int i = 0; i < Statcdif.MendFildsTable.DefaultView.Count; i++)
                {
                    Label Lbl = new Label();
                    Lbl.AutoSize = false;
                    Lbl.RightToLeft = RightToLeft.Yes;
                    Lbl.TextAlign = ContentAlignment.MiddleRight;
                    Lbl.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    Lbl.Size = new Size(100, 25);
                    Lbl.Text = Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"] + " : ";
                    FlwMend.Controls.Add(Lbl);
                    if (Statcdif.MendFildsTable.DefaultView[i]["CDMendType"].ToString() == "TextBox")
                    {
                        TextBox Ctrl = new TextBox();
                        Ctrl.TextAlign = HorizontalAlignment.Center;
                        Ctrl.RightToLeft = RightToLeft.Yes;
                        Ctrl.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                        Ctrl.Size = new Size(150, 25);
                        Ctrl.Name = Statcdif.MendFildsTable.DefaultView[i]["CDMendNm"].ToString();
                        Ctrl.Tag = Statcdif.MendFildsTable.DefaultView[i]["CDMendAccessNm"].ToString();
                        Ctrl.MaxLength = Convert.ToInt32(Statcdif.MendFildsTable.DefaultView[i]["MendLenght"]);
                        FlwMend.Controls.Add(Ctrl);
                    }
                    else if (Statcdif.MendFildsTable.DefaultView[i]["CDMendType"].ToString() == "TextBox!")
                    {
                        TextBox Ctrl = new TextBox();
                        Ctrl.TextAlign = HorizontalAlignment.Center;
                        Ctrl.RightToLeft = RightToLeft.Yes;
                        Ctrl.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                        Ctrl.Size = new Size(150, 25);
                        Ctrl.Name = Statcdif.MendFildsTable.DefaultView[i]["CDMendNm"].ToString();
                        Ctrl.Tag = Statcdif.MendFildsTable.DefaultView[i]["CDMendAccessNm"].ToString();
                        Ctrl.AccessibleName = Statcdif.MendFildsTable.DefaultView[i]["CDMendTbl"].ToString();
                        FlwMend.Controls.Add(Ctrl);
                        Ctrl.ReadOnly = true;
                        Ctrl.KeyDown += new KeyEventHandler(TextBox_KeyDown);
                        Ctrl.Enter += new EventHandler(TextBox_ENTER);
                        Ctrl.Leave += new EventHandler(TextBox_LEAVE);
                    }
                    else if (Statcdif.MendFildsTable.DefaultView[i]["CDMendType"].ToString() == "MaskedTextBox")
                    {
                        MaskedTextBox Ctrl = new MaskedTextBox();
                        Ctrl.TextAlign = HorizontalAlignment.Center;
                        Ctrl.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                        Ctrl.Size = new Size(150, 25);
                        Ctrl.Mask = Statcdif.MendFildsTable.DefaultView[i]["MendMask"].ToString();
                        Ctrl.Name = Statcdif.MendFildsTable.DefaultView[i]["CDMendNm"].ToString();
                        Ctrl.Tag = Statcdif.MendFildsTable.DefaultView[i]["CDMendAccessNm"].ToString();
                        FlwMend.Controls.Add(Ctrl);
                    }
                    else if (Statcdif.MendFildsTable.DefaultView[i]["CDMendType"].ToString() == "DateTimePicker")
                    {
                        DateTimePicker Ctrl = new DateTimePicker();
                        Ctrl.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                        Ctrl.Size = new Size(150, 25);
                        Ctrl.MaxDate = DateTime.Now.AddDays(1);
                        Ctrl.Format = DateTimePickerFormat.Short;
                        Ctrl.Name = Statcdif.MendFildsTable.DefaultView[i]["CDMendNm"].ToString();
                        Ctrl.Value = DateTime.Now.AddDays(1);
                        Ctrl.Tag = Statcdif.MendFildsTable.DefaultView[i]["CDMendAccessNm"].ToString();
                        FlwMend.Controls.Add(Ctrl);
                    }
                }
                forms.FrmAllSub(this);
                //'TempClr = Statcdif.MendFildsTable.Rows.Find(TreeView1.SelectedNode.Name)
                //'Dim BKClr = Split(TempClr.ItemArray(2), ",")
                //'Timer1.Start()
                PrdKind = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[0];
                Prdct.Text = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[1];
                Comp.Text = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[2];
            }
            else if (TreeView1.SelectedNode.Level < 2)
            {
                PrdKind = "";
                Prdct.Text = "";
                Comp.Text = "";
                BtnAdd.Visible = false;
                BtnClr.Visible = false;
                FlwMend.Controls.Clear();
                //Timer1.Stop();
            }
            if (TreeView1.SelectedNode.FullPath.ToString().Split('\\')[0] != PrdKind)
            {
                PrdKind = "";
            }
        }
        private void TextBox_LEAVE(object sender, EventArgs e)
        {
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
        }
        private void TextBox_ENTER(object sender, EventArgs e)
        {
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "     إضغط F1  لإختيار " + GetNextControl((TextBox)sender, false).Text.Substring(0, GetNextControl((TextBox)sender, false).Text.Length - 2);
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Mendatory();
        }
        private void RadioButton8_Click(object sender, EventArgs e)
        {
            TimrPhons.Start();
            Phon1TxtBx.Enabled = true;
            Phon1TxtBx.Text = "";
            if (RadioButton8.Checked)
            {
                Phon1TxtBx.Mask = "00000000000";
            }
            else if (RadioButton9.Checked)
            {
                Phon1TxtBx.Mask = "0000000000";
            }
            Phon1TxtBx.Focus();
            NameTxtBx.Text = "";
            AddTxtBx.Text = "";
            Phon2TxtBx.Text = "";
            MailTxtBx.Text = "";
            RelatedTable.Rows.Clear();
        }
        private void TimrPhons_Tick(object sender, EventArgs e)
        {
            if (RadioButton8.Checked == true)
            {
                if (PictureBox1.Size.Width > 24)
                {
                    PictureBox1.Size = new Size(PictureBox1.Size.Width - 1, 44);
                    PictureBox1.Location = new Point(PictureBox1.Location.X + 1, PictureBox1.Location.Y + 1);
                }
                else
                {
                    PictureBox1.Size = new Size(PictureBox1.Size.Width + 1, 44);
                    PictureBox1.Location = new Point(PictureBox1.Location.X - 1, PictureBox1.Location.Y - 1);
                }
            }
            if (RadioButton9.Checked == true)
            {
                if (PictureBox2.Size.Width > 43)
                {
                    PictureBox2.Size = new Size(PictureBox2.Size.Width - 1, 42);
                    PictureBox2.Location = new Point(PictureBox2.Location.X + 1, PictureBox2.Location.Y + 1);
                }
                else
                {
                    PictureBox2.Size = new Size(PictureBox2.Size.Width + 1, 42);
                    PictureBox2.Location = new Point(PictureBox2.Location.X - 1, PictureBox2.Location.Y - 1);
                }
            }
            if (RadioButton11.Checked == true)
            {
                if (PictureBox3.Size.Width > 24)
                {
                    PictureBox3.Size = new Size(PictureBox3.Size.Width - 1, 44);
                    PictureBox3.Location = new Point(PictureBox3.Location.X + 1, PictureBox3.Location.Y + 1);
                }
                else
                {
                    PictureBox3.Size = new Size(PictureBox3.Size.Width + 1, 44);
                    PictureBox3.Location = new Point(PictureBox3.Location.X - 1, PictureBox3.Location.Y - 1);
                }
            }
            if (RadioButton12.Checked == true)
            {
                if (PictureBox4.Size.Width > 43)
                {
                    PictureBox4.Size = new Size(PictureBox4.Size.Width - 1, 42);
                    PictureBox4.Location = new Point(PictureBox4.Location.X + 1, PictureBox4.Location.Y + 1);
                }
                else
                {
                    PictureBox4.Size = new Size(PictureBox4.Size.Width + 1, 42);
                    PictureBox4.Location = new Point(PictureBox4.Location.X - 1, PictureBox4.Location.Y - 1);
                }
            }
        }
        private DataTable populateTextCoise(DataTable Tbl, string selct)
        {
            SqlConnection sqlcon = new SqlConnection(Statcdif.strConn);
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlCommand cmd;
            SqlDataAdapter da;
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@slctstat", SqlDbType.VarChar);
            param[0].Value = selct;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CHOISE_SLCT";
            cmd.Connection = sqlcon;
            cmd.Parameters.Add(param[0]);
            da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(Tbl);
            }
            catch (Exception ex)
            {
                fn.msg("هناك خطأ في الإتصال بقواعد البيانات", "أختيار حقل");
            }
            DAL.Close();
            return Tbl;
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // NOTE: set form's KeyPreview property to True
            if (e.KeyCode == Keys.F1)
            {
                sndr = (TextBox)sender;
                tbl = new DataTable();
                tbl = populateTextCoise(tbl, sndr.AccessibleName);
                if (tbl.Rows.Count > 0)
                {
                    tbl.DefaultView.RowFilter = string.Empty;
                    addnewTextBox();
                    addnewGridview();
                    addnewFowoutpanel();
                    addnewform_();

                    Frm.Controls.Add(Flow);
                    Flow.Controls.Add(TxBox);
                    Flow.Controls.Add(GV);

                    WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "    يرجى الضغط المزدوج على " + GetNextControl((TextBox)sender, false).Text.Substring(0, GetNextControl((TextBox)sender, false).Text.Length - 2) + " للرجوع بالإختيار وإغلاق شاشة البحث.";
                    Frm.ShowDialog();
                    WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
                    tbl.Dispose();
                    Frm.Dispose();
                    GC.Collect();
                }
                else
                {
                    fn.msg("هناك خطأ في الإتصال بقواعد البيانات", "تحميل البيانات");
                }
            }
        }
        private void addnewform_()
        {
            Frm = new Form();
            Frm.RightToLeft = RightToLeft.Yes;
            Frm.RightToLeftLayout = true;
            Frm.WindowState = FormWindowState.Normal;
            Frm.StartPosition = FormStartPosition.CenterScreen;
            Frm.SizeChanged += new EventHandler(Frm_sizechanged);
            Frm.Size = new Size(GV.Width, TxBox.Height + GV.Height + 50);
            Frm.Text = "اختيار " + GetNextControl(sndr, false).Text + " عدد البيانات " + tbl.Rows.Count;
            Frm.BackColor = Color.White;
        }
        private void addnewTextBox()
        {
            TxBox = new TextBox();
            TxBox.Size = new Size(200, 30);
            TxBox.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            TxBox.TextChanged += new EventHandler(Txt_TextChanged);
        }
        private void addnewGridview()
        {
            GV = new DataGridView();
            GV.DataSource = tbl.DefaultView;
            GV.AllowUserToAddRows = false;
            GV.AllowUserToDeleteRows = false;
            GV.ReadOnly = true;
            GV.AutoResizeColumns();
            GV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GV.Size = new Size(800, 800);
            GV.BackgroundColor = Color.White;
            GV.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            GV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GV.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 16, FontStyle.Bold);
            GV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GV.CellDoubleClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }
        private void addnewFowoutpanel()
        {
            Flow = new FlowLayoutPanel();
            Flow.RightToLeft = RightToLeft.Yes;
            Flow.SetFlowBreak(TxBox, true);
            Flow.Dock = DockStyle.Fill;
            Flow.FlowDirection = FlowDirection.RightToLeft;
        }
        private void Txt_TextChanged(object sender, EventArgs e)
        {
            tbl.DefaultView.RowFilter = "[" + tbl.Columns[0].ColumnName + "]" + " like '%" + TxBox.Text + "%'";
            GV.DataSource = tbl.DefaultView;
        }
        private void DataGridView_CellClick(object sender, EventArgs e)
        {
            sndr.Text = GV.CurrentRow.Cells[0].Value.ToString();
            Frm.Close();
        }
        private void Frm_sizechanged(object sender, EventArgs e)
        {
            TxBox.Margin = new Padding(TxBox.Margin.Left, TxBox.Margin.Top, (Frm.Width - TxBox.Width) / 2, TxBox.Margin.Bottom);
            GV.Margin = new Padding(GV.Margin.Left, GV.Margin.Top, (Frm.Width - GV.Width) / 2, GV.Margin.Bottom);
        }
    }
}
