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

        private static TikNew frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static TikNew getTiknewfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikNew();
                    frm.FormClosed += new FormClosedEventHandler(frm_Closed);
                }
                return frm;
            }
        }
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
        int COMPID_ = 0;
        string itemRef;
        int TeamIdentfier;
        string Help_;
        public TikNew()
        {
            InitializeComponent();
            forms.FrmAllSub(this);
            NewTickSub();
        }
        private void NewTickSub()
        {
            FlwMend.Enabled = true;
            FlwMend.Controls.Clear();
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
            TreeView1.Enabled = true;
            TreeView1.Visible = false;
            TreeView1.CollapseAll();

            SubmitBtn.Visible = true;
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
                    c.Text = "";
                    if (TB.ReadOnly == false)
                    {
                        TB.BackColor = Color.White;
                        TB.ForeColor = Color.Black;
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
            FlwTree.Enabled = true;
            BtnDublicate.Visible = false;
            FlwMainData.Enabled = false;
            richTextBox1.Text = "";
            lblhelp.Text = "";
        }
        private void mendlstlbl()
        {
            richTextBox1.Text = "" + Environment.NewLine;
            if (PrdKind != null)
            {
                if (PrdKind.Equals("مالية", StringComparison.OrdinalIgnoreCase))
                {
                    richTextBox1.Text += ("رقم قومي") + Environment.NewLine;
                }
            }


            richTextBox1.Text += ("رقم التليفون 1") + Environment.NewLine;
            richTextBox1.Text += ("اسم العميل") + Environment.NewLine;
            richTextBox1.Text += ("مصدر الشكوى") + Environment.NewLine;
        }
        private void Mendatory()
        {
            Timer1.Stop();
            double Complete_ = 0;
            if (PrdKind.Equals("مالية", StringComparison.OrdinalIgnoreCase))
            {
                //Check Customer ID
                if (RadNID.Checked == true && IDTxtBx.Text.Replace(" ", "").Trim().Length == 14)
                {
                    if (function.validateNationalID(IDTxtBx.Text.Replace(" ", "").Trim().ToString()) == true)
                    {
                        Complete_ += 1;
                        fn.ClorTxt(richTextBox1, IDTxtBx.AccessibleName, Color.White, Color.Green, 14);
                    }
                }
                else if (RadPss.Checked == true && IDTxtBx.Text.Replace(" ", "").Trim().Length > 0)
                {
                    Complete_ += 1;
                    fn.ClorTxt(richTextBox1, IDTxtBx.AccessibleName, Color.White, Color.Green, 14);
                }
                else
                {
                    fn.ClorTxt(richTextBox1, IDTxtBx.AccessibleName, Color.White, Color.Red, 14);
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
                toolTip1.Hide(Phon1TxtBx);
                fn.ClorTxt(richTextBox1, Phon1TxtBx.AccessibleName, Color.White, Color.Green, 14);
            }
            else
            {
                if (ActiveControl == Phon1TxtBx) { toolTip1.Show("رقم التليفون لابد أنه تكون من " + Phon1TxtBx.Mask.Length + " رقم", ActiveControl, 0, 30, 1000); }
                fn.ClorTxt(richTextBox1, Phon1TxtBx.AccessibleName, Color.White, Color.Red, 14);
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
                toolTip1.Hide(NameTxtBx);
                fn.ClorTxt(richTextBox1, NameTxtBx.AccessibleName, Color.White, Color.Green, 14);
            }
            else
            {
                if (ActiveControl == NameTxtBx) { toolTip1.Show("اسم العميل لابد أن يكون ثلاثي على الأقل", NameTxtBx, 0, 30, 3000); }

                fn.ClorTxt(richTextBox1, NameTxtBx.AccessibleName, Color.White, Color.Red, 14);
            }
            //Check Complaint Source
            if (SrcCmbBx.SelectedIndex != -1)
            {
                Complete_ += 1;
                fn.ClorTxt(richTextBox1, SrcCmbBx.AccessibleName, Color.White, Color.Green, 14);
            }
            else
            {
                fn.ClorTxt(richTextBox1, SrcCmbBx.AccessibleName, Color.White, Color.Red, 14);
            }

            foreach (Control Ctrl in FlwMend.Controls)
            {
                if (Ctrl.GetType() == typeof(TextBox))
                {
                    TextBox Ctrl1 = (TextBox)Ctrl;
                    if (Ctrl.Text.Replace(" ", "").Trim().Length > 0)
                    {
                        Complete_ += 1;
                        fn.ClorTxt(richTextBox1, GetNextControl(Ctrl, false).Text.ToString().Substring(0, GetNextControl(Ctrl, false).Text.Length - 3), Color.White, Color.Green, 14);
                    }
                    else
                    {
                        if (Ctrl1.ReadOnly == true)
                        {
                            if (ActiveControl == Ctrl) { toolTip1.Show("     إضغط F1  لإختيار " + GetNextControl((TextBox)Ctrl, false).Text.Substring(0, GetNextControl((TextBox)Ctrl, false).Text.Length - 2), ActiveControl, 0, 30, 3000); };
                        }
                    }
                }
                else if (Ctrl.GetType() == typeof(MaskedTextBox))
                {
                    MaskedTextBox mskd = new MaskedTextBox();
                    mskd = (MaskedTextBox)Ctrl;
                    if (mskd.Mask.Replace(" ", "").Trim().Length == mskd.Text.Replace(" ", "").Trim().Length)
                    {
                        if (Ctrl.Tag.ToString().Split('-').Count() > 2)
                        {
                            if (Ctrl.Tag.ToString().Split('-')[2].Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                int CNT = itemRef.Split('-').Count<string>();
                                if (CNT > 1)
                                {
                                    bool chckidentefecation = false;
                                    string itemRefContent = null;
                                    for (int i = 0; i < CNT; i++)
                                    {
                                        itemRefContent = itemRef.Split('-')[i];
                                        if (mskd.Text.Replace(" ", "").Trim().Substring(0, itemRefContent.Length).ToString().Equals(itemRefContent, StringComparison.OrdinalIgnoreCase))
                                        {
                                            chckidentefecation = true;
                                            break;
                                        }
                                    }
                                    if (chckidentefecation == true)
                                    {
                                        Complete_ += 1;
                                        fn.ClorTxt(richTextBox1, GetNextControl(mskd, false).Text.ToString().Substring(0, GetNextControl(mskd, false).Text.Length - 3), Color.White, Color.Green, 14);
                                    }
                                    else
                                    {
                                        if (ActiveControl == mskd) { toolTip1.Show(GetNextControl(mskd, false).Text.Substring(0, GetNextControl(mskd, false).Text.Length - 3) + " لابد أنه يبدأ بأحد الإختيارات التالية " + Environment.NewLine + itemRef, ActiveControl, 0, 30, 3000); };
                                        //fn.msg(GetNextControl(mskd, false).Text.Substring(0, GetNextControl(mskd, false).Text.Length - 3) + " لابد أنه يبدأ بأحد الإختيارات التالية " + Environment.NewLine + itemRef, "رسالة معلومات");
                                        mskd.Text = "";
                                    }
                                }
                                else
                                {
                                    if (itemRef.Equals(mskd.Text.Replace(" ", "").Trim().Substring(0, itemRef.Length), StringComparison.OrdinalIgnoreCase))
                                    {
                                        Complete_ += 1;
                                        fn.ClorTxt(richTextBox1, GetNextControl(Ctrl, false).Text.ToString().Substring(0, GetNextControl(Ctrl, false).Text.Length - 3), Color.White, Color.Green, 14);
                                    }
                                    else
                                    {
                                        if (ActiveControl == mskd) { toolTip1.Show(GetNextControl(mskd, false).Text.Substring(0, GetNextControl(mskd, false).Text.Length - 3) + " لابد أنه يبدأ بـ " + itemRef, ActiveControl, 0, 30, 3000); };
                                        //fn.msg(GetNextControl(mskd, false).Text.Substring(0, GetNextControl(mskd, false).Text.Length - 3) + " لابد أنه يبدأ بـ " + itemRef, "رسالة معلومات");
                                        mskd.Text = itemRef;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Complete_ += 1;
                        }
                    }
                    else if (mskd.Tag.ToString().Split('-').Count() > 2 && itemRef.Length > 0)
                    {
                        if (ActiveControl == mskd) { toolTip1.Show(GetNextControl(mskd, false).Text.Substring(0, GetNextControl(mskd, false).Text.Length - 3) + " لابد أنه يبدأ بـ " + itemRef, mskd, 0, 30, 1000); };
                    }
                }
                else if (Ctrl.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker Dpkr = new DateTimePicker();
                    Dpkr = (DateTimePicker)Ctrl;
                    if (Dpkr.Value.ToString("dd/MM/yyyy") != DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"))
                    {
                        Complete_ += 1;
                        fn.ClorTxt(richTextBox1, GetNextControl(Dpkr, false).Text.ToString().Substring(0, GetNextControl(Dpkr, false).Text.Length - 3), Color.White, Color.Green, 14);
                    }
                }
                else if (Ctrl.GetType() == typeof(Label))
                {
                    fn.ClorTxt(richTextBox1, Ctrl.Text.ToString().Substring(0, Ctrl.Text.Length - 3), Color.White, Color.Red, 14);
                }
            }


            if (PrdKind.Equals("مالية", StringComparison.OrdinalIgnoreCase))
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
                else
                {
                    SubmitBtn.Enabled = false;
                    SubmitBtn.BackgroundImage = Resources.SaveRed1;
                }

            }
            else if (PrdKind.Equals("بريدية", StringComparison.OrdinalIgnoreCase))
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
            else if (PrdKind.Equals("", StringComparison.OrdinalIgnoreCase))
            {
                SubmitBtn.BackgroundImage = Resources.SaveRed;
                SubmitBtn.Enabled = false;
            }
            //if (lblhelp.Visible==true) { Timer1.Interval = 100; lblhelp.Visible = false; } else { Timer1.Interval = 100; lblhelp.Visible = true; }
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
                Statcdif.ProdCompTable.PrimaryKey = new DataColumn[] { Statcdif.ProdCompTable.Columns["FnSQL"] };
                DataRow DRW = Statcdif.ProdCompTable.Rows.Find(TreeView1.SelectedNode.Name);
                itemRef = DRW.ItemArray[7].ToString();
                TeamIdentfier = Convert.ToInt32(DRW.ItemArray[8]);
                Help_ = DRW.ItemArray[11].ToString();
                lblhelp.Text = Help_;
                Timer1.Start();
                BtnAdd.Visible = true;
                BtnClr.Visible = false;
                PrdKind = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[0];
                Prdct.Text = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[1];
                Comp.Text = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[2];
                Statcdif.MendFildsTable.DefaultView.RowFilter = "[MendCdFn]  = " + TreeView1.SelectedNode.Name + " and MendStat = 0";
                FlwMend.Controls.Clear();
                mendlstlbl();

                Font CtrlFont = new Font("Times new Roman", 12, FontStyle.Bold);
                Size Ctrlsize = new Size(150, 32);
                Size lblsize = new Size(100, 25);

                for (int i = 0; i < Statcdif.MendFildsTable.DefaultView.Count; i++)
                {
                    Label Lbl = new Label();
                    Lbl.AutoSize = false;
                    Lbl.RightToLeft = RightToLeft.Yes;
                    Lbl.TextAlign = ContentAlignment.MiddleRight;
                    Lbl.Margin = new Padding(3, 3, 3, 3);
                    Lbl.Font = CtrlFont;
                    Lbl.Size = lblsize;
                    Lbl.Text = Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"] + " : ";
                    FlwMend.Controls.Add(Lbl);
                    richTextBox1.Text += (Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"]) + Environment.NewLine;
                    if (Statcdif.MendFildsTable.DefaultView[i]["CDMendType"].ToString().Equals("TextBox", StringComparison.OrdinalIgnoreCase))
                    {
                        TextBox Ctrl = new TextBox();
                        Ctrl.TextAlign = HorizontalAlignment.Center;
                        Ctrl.RightToLeft = RightToLeft.Yes;
                        Ctrl.Font = CtrlFont;
                        Ctrl.Size = Ctrlsize;
                        Ctrl.Tag = Statcdif.MendFildsTable.DefaultView[i]["CDMendDatatype"].ToString();
                        if (DBNull.Value.Equals(Statcdif.MendFildsTable.DefaultView[i]["CDMendLenght"]) == false) { Ctrl.MaxLength = Convert.ToInt32(Statcdif.MendFildsTable.DefaultView[i]["CDMendLenght"]); };
                        FlwMend.Controls.Add(Ctrl);
                    }
                    else if (Statcdif.MendFildsTable.DefaultView[i]["CDMendType"].ToString().Equals("TextBoxC", StringComparison.OrdinalIgnoreCase))
                    {
                        TextBox Ctrl = new TextBox();
                        Ctrl.TextAlign = HorizontalAlignment.Center;
                        Ctrl.RightToLeft = RightToLeft.Yes;
                        Ctrl.Font = CtrlFont;
                        Ctrl.Size = Ctrlsize;
                        Ctrl.Tag = Statcdif.MendFildsTable.DefaultView[i]["CDMendDatatype"].ToString();
                        Ctrl.AccessibleName = Statcdif.MendFildsTable.DefaultView[i]["CDMendTbl"].ToString();
                        FlwMend.Controls.Add(Ctrl);
                        Ctrl.ReadOnly = true;
                        Ctrl.KeyDown += new KeyEventHandler(TextBox_KeyDown);
                        Ctrl.Enter += new EventHandler(TextBox_ENTER);
                        Ctrl.Leave += new EventHandler(TextBox_LEAVE);
                    }
                    else if (Statcdif.MendFildsTable.DefaultView[i]["CDMendType"].ToString().Equals("MaskedTextBox", StringComparison.OrdinalIgnoreCase))
                    {
                        MaskedTextBox Ctrl = new MaskedTextBox();
                        Ctrl.TextAlign = HorizontalAlignment.Center;
                        Ctrl.Font = CtrlFont;
                        Ctrl.Size = Ctrlsize;
                        Ctrl.Mask = Statcdif.MendFildsTable.DefaultView[i]["CDMendmask"].ToString();
                        Ctrl.Tag = Statcdif.MendFildsTable.DefaultView[i]["CDMendDatatype"].ToString();
                        Ctrl.PromptChar = Convert.ToChar(" ");
                        FlwMend.Controls.Add(Ctrl);
                    }
                    else if (Statcdif.MendFildsTable.DefaultView[i]["CDMendType"].ToString().Equals("DateTimePicker", StringComparison.OrdinalIgnoreCase))
                    {
                        DateTimePicker Ctrl = new DateTimePicker();
                        Ctrl.Font = CtrlFont;
                        Ctrl.Size = Ctrlsize;
                        Ctrl.MaxDate = DateTime.Now.AddDays(1);
                        Ctrl.Format = DateTimePickerFormat.Short;
                        Ctrl.Value = DateTime.Now.AddDays(1);
                        Ctrl.Tag = Statcdif.MendFildsTable.DefaultView[i]["CDMendDatatype"].ToString();
                        FlwMend.Controls.Add(Ctrl);
                    }

                }
                forms.FrmAllSub(this);
                FlwMainData.Enabled = true;
            }
            else if (TreeView1.SelectedNode.Level < 2)
            {
                FlwMainData.Enabled = false;
                PrdKind = "";
                Prdct.Text = "";
                Comp.Text = "";
                BtnAdd.Visible = false;
                BtnClr.Visible = false;
                FlwMend.Controls.Clear();
                richTextBox1.Text = "";
                itemRef = "";
                TeamIdentfier = 0;
                Help_ = "";
                lblhelp.Text = "";
                Timer1.Stop();
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
        private void RadioPhone1_Click(object sender, EventArgs e)
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
            TxBox.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
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
            GV.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
        }
        private void addnewFowoutpanel()
        {
            Flow = new FlowLayoutPanel();
            Flow.RightToLeft = RightToLeft.Yes;
            Flow.SetFlowBreak(TxBox, true);
            Flow.Dock = DockStyle.Fill;
            Flow.FlowDirection = FlowDirection.RightToLeft;
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Frm.Close();
            }
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
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (CurrentUser.UsrUCatLvl >= 3 && CurrentUser.UsrUCatLvl <= 5)
            {
                AddNewTicket(CurrentUser.UsrID);
            }
            else
            {
                AddNewTicket(TeamIdentfier);
            }
        }
        private DAL.DataAccessLayer.rturnStruct insertTicket(bool kind, int cdfnid, int src, string clNm, string ClPh, string ClPh1, string ClAdr, string ClNtID
                                                            , string TkDetails, int EmpNm0, int EmpNm, string ClMail, DataTable FIELDTABL)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Struc.msg = null;
            DAL.Struc.dt = null;
            DAL.Struc.ds = null;
            SqlConnection sqlcon = new SqlConnection(Statcdif.strConn);
            SqlParameter[] param = new SqlParameter[13];
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SP_ONE_TICKETS_INSERT";
            sqlcmd.Connection = sqlcon;
            param[0] = new SqlParameter("@TkKind", SqlDbType.Bit);
            param[0].Value = kind;
            param[1] = new SqlParameter("@TkFnPrdCd", SqlDbType.Int);
            param[1].Value = cdfnid;
            param[2] = new SqlParameter("@TkCompSrc", SqlDbType.Int);
            param[2].Value = src;
            param[3] = new SqlParameter("@TkClNm", SqlDbType.NVarChar, 100);
            param[3].Value = clNm;
            param[4] = new SqlParameter("@TkClPh", SqlDbType.NVarChar, 14);
            param[4].Value = ClPh;
            param[5] = new SqlParameter("@TkClPh1", SqlDbType.NVarChar, 14);
            if (ClPh1.Length == 0) { param[5].Value = DBNull.Value; }
            else { param[5].Value = ClPh1; }
            param[6] = new SqlParameter("@TkClAdr", SqlDbType.NVarChar, 255);
            if (ClAdr.Length == 0) { param[6].Value = DBNull.Value; }
            else { param[6].Value = ClAdr; }
            param[7] = new SqlParameter("@TkClNtID", SqlDbType.NVarChar, 14);
            if (ClNtID.Length == 0) { param[7].Value = DBNull.Value; }
            else { param[7].Value = ClNtID; }
            param[8] = new SqlParameter("@TkDetails", SqlDbType.NVarChar);
            if (TkDetails.Length == 0) { param[8].Value = DBNull.Value; }
            else { param[8].Value = TkDetails; }
            param[9] = new SqlParameter("@TkEmpNm0", SqlDbType.Int);
            param[9].Value = EmpNm0;
            param[10] = new SqlParameter("@TkEmpNm", SqlDbType.Int);
            if (EmpNm == 0) { param[10].Value = DBNull.Value; }
            else { param[10].Value = EmpNm; }
            param[11] = new SqlParameter("@TkMail", SqlDbType.NVarChar, 50);
            if (ClMail.Length == 0) { param[11].Value = DBNull.Value; }
            else { param[11].Value = ClMail; }
            param[12] = new SqlParameter();
            param[12].ParameterName = "@FIELDTABLETYPE";
            param[12].Value = FIELDTABL;
            // Add Out Put Parameter
            sqlcmd.Parameters.AddRange(param);
            sqlcmd.Parameters.Add("@Comdid", SqlDbType.Int);
            sqlcmd.Parameters["@Comdid"].Direction = ParameterDirection.Output;
            try
            {
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                COMPID_ = Convert.ToInt32(sqlcmd.Parameters["@Comdid"].Value);
                if (COMPID_ != 0)
                {
                    SubmitBtn.Visible = false;
                    if (TickKind == 0)
                    {
                        ComRefLbl.Text = "طلب رقم : " + Convert.ToString(COMPID_);
                    }
                    else
                    {
                        ComRefLbl.Text = "شكوى رقم : " + Convert.ToString(COMPID_);
                    }
                    TimrPhons.Stop();
                    FlwMainData.Enabled = false;
                    FlwTree.Enabled = false;
                    FlwMend.Enabled = false;
                    BtnDublicate.Visible = true;
                }
            }
            catch (Exception ex)
            {
                DAL.Struc.msg = ex.Message;
                function fn = function.getfn;
                fn.msg(Resources.ConnErr + Environment.NewLine + ex, "Create New Tickect");
            }
            return DAL.Struc;
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddNewTicket(int usrid)
        {
            DataTable mndtbl = new DataTable();
            mndtbl.Columns.Add("A", typeof(int));
            mndtbl.Columns.Add("B", typeof(string));
            mndtbl.Columns.Add("C", typeof(string));

            foreach (Control Ctrl in FlwMend.Controls)
            {
                if (Ctrl.GetType() == typeof(TextBox))
                {

                    string KK = GetNextControl(Ctrl, false).Text.Substring(0, GetNextControl(Ctrl, false).Text.Length - 3);
                    mndtbl.Rows.Add(0, KK, Ctrl.Text);
                }
                else if (Ctrl.GetType() == typeof(MaskedTextBox))
                {
                    string KK = GetNextControl(Ctrl, false).Text.Substring(0, GetNextControl(Ctrl, false).Text.Length - 3);
                    mndtbl.Rows.Add(0, KK, Ctrl.Text.Replace(" ", ""));
                }
                else if (Ctrl.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker Dpkr = new DateTimePicker();
                    Dpkr = (DateTimePicker)Ctrl;
                    string KK = GetNextControl(Ctrl, false).Text.Substring(0, GetNextControl(Ctrl, false).Text.Length - 3);
                    mndtbl.Rows.Add(0, KK, Dpkr.Value);
                }
            }
            Statcdif.ProdCompTable.DefaultView.RowFilter = "[FnSQL]  = " + TreeView1.SelectedNode.Name;
            DAL.DataAccessLayer.rturnStruct Accesslogreslt = insertTicket(
                Convert.ToBoolean(TickKind)                                         //Ticket Kind
                , Convert.ToInt32(Statcdif.ProdCompTable.DefaultView[0]["FnSQL"])  //Ticket Pcoduct & Cmplaint Code SQL
                , Convert.ToInt32(SrcCmbBx.SelectedValue)                     //Ticket Source
                , NameTxtBx.Text.ToString()                                       //Ticket Client Name
                , Phon1TxtBx.Text.ToString()                                       //Ticket Client Phone Number 1
                , Phon2TxtBx.Text.ToString().Replace(" ", "")                                       //Ticket Client Phone Number 2
                , AddTxtBx.Text.ToString().Trim()                                         //Ticket Client Address
                , IDTxtBx.Text.ToString().Trim()                                          //Ticket Clients National ID
                , DetailsTxtBx.Text.ToString().Trim()                                     //Ticket Details
                , CurrentUser.UsrID                                            //Ticket Creator ID
                , usrid                                                        //Ticket Follower ID (It must be Zero Amount To Assign Null Value to Database)
                , MailTxtBx.Text.ToString().Trim()                                        //Ticket Client Mail address
                , mndtbl);                                                     //Ticket Mend Table send it as type table to Stored Procedure
            if (COMPID_ != 0)
            {
                fn.msg("Done", "Add new Ticket");
            }
            else
            {
                fn.msg("لم ينجح الإتصال بقواعد البيانات" + Environment.NewLine + Accesslogreslt.msg, "Add new Ticket");
            }
        }
        private void NewBtn_Click(object sender, EventArgs e)
        {
            NewTickSub();
        }
        private void BtnDublicate_Click(object sender, EventArgs e)
        {
            SubmitBtn.Visible = true;
            FlwTree.Enabled = true;
            FlwMend.Enabled = true;
            ComRefLbl.Text = "";
            BtnDublicate.Visible = false;
        }
        private void RadNID_Click(object sender, EventArgs e)
        {
            IDTxtBx.Text = "";
            if (RadNID.Checked == true)
            {
                IDTxtBx.Tag = "English-Number";
                IDTxtBx.Mask = "00000000000000";
                RadNID.Checked = true;
                RadPss.Checked = false;
                Label11.Text = "الرقم القومي : ";
            }

            else
            {
                IDTxtBx.Tag = "English-TextNumber";
                IDTxtBx.Mask = "AAAAAAAAAAAAAA";
                RadNID.Checked = false;
                RadPss.Checked = true;
                Label11.Text = "رقم جواز السفر : ";
            }
        }
        private void RadioPhone2_Click(object sender, EventArgs e)
        {
            TimrPhons.Start();
            Phon2TxtBx.Enabled = true;
            Phon2TxtBx.Text = "";
            if (RadioButton11.Checked)
            {
                Phon2TxtBx.Mask = "00000000000";
            }
            else if (RadioButton12.Checked)
            {
                Phon2TxtBx.Mask = "0000000000";
            }
            Phon2TxtBx.Focus();

        }
    }
}
