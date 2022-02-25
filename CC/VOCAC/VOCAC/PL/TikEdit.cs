using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAC.BL;
using VOCAC.Properties;

namespace VOCAC.PL
{
    public partial class TikEdit : Form
    {

        private static TikEdit frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
            GC.Collect();
        }
        public static TikEdit getTiknewfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikEdit();

                }
                return frm;
            }
        }
        frms forms = new frms();
        function fn = function.getfn;
        DataTable customerTable = new DataTable();
        Form Frm;
        DataGridView GV;
        DataTable tbl;
        FlowLayoutPanel Flow;
        TextBox TxBox;
        TextBox sndr;
        int TickKind;
        string PrdKind;
        string itemRef;
        int TeamIdentfier;
        string Help_;
        int lblColor = 35;
        TreeNode[] TempNode = new TreeNode[0];
        List<string> ctrlList;
        Size Ctrlsize = new Size(150, 32);
        Size lblsize = new Size(100, 25);
        Font CtrlFont = new Font("Times new Roman", 12, FontStyle.Bold);
        public TikEdit()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
            forms.FrmAllSub(this);
            NewTickSub();
            this.TkClPh.TextChanged += new System.EventHandler(this.Phon1TxtBx_TextChanged);
            this.TkClNtID.TextChanged += new System.EventHandler(this.IDTxtBx_TextChanged);
            Statcdif.CompSurceTable.DefaultView.RowFilter = string.Empty;
        }
        private void NewTickSub()
        {
            FlwMend.Enabled = true;
            FlwMend.Controls.Clear();
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
            //TreeView1.Enabled = true;
            //TreeView1.Visible = false;
            //TreeView1.Nodes.Clear();

            SubmitBtn.Visible = true;
            customerTable.Rows.Clear();

            List<Control> CTRLLst = new List<Control>();
            CTRLLst = forms.GetAll(this).ToList();

            foreach (Control c in CTRLLst)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(MaskedTextBox))
                {
                    TextBox TB = new TextBox();
                    MaskedTextBox MTB = new MaskedTextBox();
                    try { TB = (TextBox)c; } catch (Exception) { MTB = (MaskedTextBox)c; }
                    if (c.Name != ComRefLbl.Name) { c.Text = ""; }
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


            TkClPh.Enabled = false;
            TkClPh1.Enabled = false;
            //ComRefLbl.Text = "";
            TkClNtID.Text = "";
            TkClNtID.Mask = "00000000000000";
            RadNID.Checked = true;
            chckIDChange.Text = "تغيير الرقم القومي";

            TickKind = 0;
            PrdKind = "";
            MyGroupBox3.Enabled = true;
            FlwTree.Enabled = true;
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
                    if (RadNID.Checked)
                    {
                        richTextBox1.Text += ("الرقم القومي") + Environment.NewLine;
                    }
                    else
                    {
                        richTextBox1.Text += ("رقم جواز السفر") + Environment.NewLine;
                    }

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
            double factor = FlwMend.Controls.Count / 2;
            if (PrdKind.Equals("مالية", StringComparison.OrdinalIgnoreCase))
            {
                factor += 5;
                //Check Customer ID
                if (RadNID.Checked == true && TkClNtID.Text.Replace(" ", "").Trim().Length == 14)
                {
                    if (function.validateNationalID(TkClNtID.Text.Replace(" ", "").Trim().ToString()) == true)
                    {
                        Complete_ += 1;
                        fn.ClorTxt(richTextBox1, TkClNtID.AccessibleName, Color.White, Color.Green, 14);
                    }
                    else
                    {
                        fn.ClorTxt(richTextBox1, TkClNtID.AccessibleName, Color.White, Color.Red, 14);
                    }
                }
                else if (RadPss.Checked == true && TkClNtID.Text.Replace(" ", "").Trim().Length > 0)
                {
                    Complete_ += 1;
                    fn.ClorTxt(richTextBox1, TkClNtID.AccessibleName, Color.White, Color.Green, 14);
                }
                else
                {
                    fn.ClorTxt(richTextBox1, TkClNtID.AccessibleName, Color.White, Color.Red, 14);
                }
                Label29.Visible = true;
            }
            else
            {
                factor += 4;
                Label29.Visible = false;
            }

            //Check Customer Phone 1
            if (function.validatePhoneNumber(TkClPh.Text.Trim()) == true)
            {
                Complete_ += 1;
                toolTip1.Hide(TkClPh);
                fn.ClorTxt(richTextBox1, TkClPh.AccessibleName, Color.White, Color.Green, 14);
            }
            else
            {
                if (RadioButton8.Checked == true)
                {
                    if (ActiveControl == TkClPh) { toolTip1.Show("رقم الموبايل لابد أنه يبدأ بـ " + Environment.NewLine + " 010, 011, 012 أو 015 ", ActiveControl, 0, 30, 1000); }
                }
                else if (RadioButton9.Checked == true)
                {
                    if (ActiveControl == TkClPh) { toolTip1.Show("رقم التليفون لابد أن يبدأ بكود المحافظة" + Environment.NewLine + "مثال : \"02XXXXXXXX", ActiveControl, 0, 30, 1000); }
                }
                fn.ClorTxt(richTextBox1, TkClPh.AccessibleName, Color.White, Color.Red, 14);
            }

            if (function.validatePhoneNumber(TkClPh1.Text.Trim()) == true)
            {
                toolTip1.Hide(TkClPh1);
                fn.ClorTxt(richTextBox1, TkClPh1.AccessibleName, Color.White, Color.Green, 14);
            }
            else
            {
                if (RadioButton11.Checked == true)
                {
                    if (ActiveControl == TkClPh1) { toolTip1.Show("رقم الموبايل لابد أنه يبدأ بـ " + Environment.NewLine + " 010, 011, 012 أو 015 ", ActiveControl, 0, 30, 1000); }
                }
                else if (RadioButton12.Checked == true)
                {
                    if (ActiveControl == TkClPh1) { toolTip1.Show("رقم التليفون لابد أن يبدأ بكود المحافظة" + Environment.NewLine + "مثال : \"02XXXXXXXX", ActiveControl, 0, 30, 1000); }
                }
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
            if (TkClNm.Text.Trim().ToCharArray().Count(c => c == Convert.ToChar(" ")) > 1)
            {
                Complete_ += 1;
                toolTip1.Hide(TkClNm);
                fn.ClorTxt(richTextBox1, TkClNm.AccessibleName, Color.White, Color.Green, 14);
            }
            else
            {
                if (ActiveControl == TkClNm) { toolTip1.Show("اسم العميل لابد أن يكون ثلاثي على الأقل", TkClNm, 0, 30, 3000); }

                fn.ClorTxt(richTextBox1, TkClNm.AccessibleName, Color.White, Color.Red, 14);
            }
            //Check Complaint Source
            if (TkCompSrc.SelectedIndex != -1)
            {
                Complete_ += 1;
                fn.ClorTxt(richTextBox1, TkCompSrc.AccessibleName, Color.White, Color.Green, 14);
            }
            else
            {
                fn.ClorTxt(richTextBox1, TkCompSrc.AccessibleName, Color.White, Color.Red, 14);
            }

            foreach (Control Ctrl in FlwMend.Controls)
            {
                Complete_ += validatectrl(Ctrl);
            }

            progressBar1.Maximum = 100;
            double gg = Convert.ToInt32((Complete_ / factor) * 100);
            progressBar1.Value = Convert.ToInt32(gg);
            progressBar1.ForeColor = Color.Red;

            if (Complete_ / factor == 1)
            {
                SubmitBtn.Enabled = true;
                SubmitBtn.BackgroundImage = Resources.SaveGreen1;
            }
            else if (Complete_ / factor <= 0.5)
            {
                SubmitBtn.BackgroundImage = Resources.SaveRed;
                SubmitBtn.Enabled = false;
            }
            else if (Complete_ / factor > 0.5)
            {
                SubmitBtn.BackgroundImage = Resources.SaveGreen;
                SubmitBtn.Enabled = false;
            }

            if (lblhelp.Text.Length > 0)
            {
                if (lblColor >= 100 && lblColor <= 250)
                {
                    lblhelp.ForeColor = Color.FromArgb(lblColor, lblColor, lblColor);
                    lblColor -= 5;
                }
                else if (lblColor >= 10 && lblColor < 100)
                {
                    lblhelp.ForeColor = Color.FromArgb(lblColor, 230, lblColor);
                    lblColor += 25;
                }
            }

            GC.Collect();
            Timer1.Start();
        }
        private int validatectrl(Control C)
        {
            int intrsult = 0;
            if (C.GetType() == typeof(TextBox))
            {
                TextBox Ctrl = (TextBox)C;
                if (Ctrl.Text.Replace(" ", "").Trim().Length > 0)
                {
                    intrsult = 1;
                    colorRichCox(Ctrl, Color.White, Color.Green);
                }
                else
                {
                    if (Ctrl.ReadOnly == true)
                    {
                        tooltipShow(Ctrl, " إضغط F1 ");
                    }
                }
            }
            else if (C.GetType() == typeof(MaskedTextBox))
            {
                MaskedTextBox mskd = new MaskedTextBox();
                mskd = (MaskedTextBox)C;
                if (mskd.Mask.Replace(" ", "").Trim().Length == mskd.Text.Replace(" ", "").Trim().Length)
                {
                    string mskedTag = mskd.Tag.ToString();                  //--------------------- Masked Box Tag Value ---------------------------
                    int splitlength = mskedTag.Split('-').Count();          //--------------------- Masked Box Tag Split Count ---------------------
                    if (splitlength > 2 &&
                        mskedTag.Split('-')[2].Equals("N", StringComparison.OrdinalIgnoreCase) &&
                                                                            itemRef.Length > 0)
                    {
                        int RefCnt = itemRef.Split('-').Count<string>();
                        if (RefCnt > 1)
                        {
                            bool chckidentefecation = false;
                            string itemRefContent;
                            int validationresultkind = 0;
                            for (int i = 0; i < RefCnt; i++)
                            {
                                itemRefContent = itemRef.Split('-')[i];
                                string mskedMathrefLength = mskd.Text.Replace(" ", "").Trim().Substring(0, itemRefContent.Length).ToString();  //--------------------- Masked Box Matched With Product Ref. Length ---------------------
                                if (mskedMathrefLength.Equals(itemRefContent, StringComparison.OrdinalIgnoreCase))
                                {
                                    string CtrlLblText = GetNextControl(mskd, false).Text.Substring(0, GetNextControl(mskd, false).Text.Length - 3);
                                    if (CtrlLblText == "رقم الشحنة" || CtrlLblText == "رقم الشحنة 3")
                                    {

                                        DataRow DRW = function.DRW(Statcdif.CDCountry, mskd.Text.Substring(13, 2), Statcdif.CDCountry.Columns["CounCd"]);
                                        if (DRW != null)
                                        {
                                            chckidentefecation = true;
                                            break;
                                        }
                                        else
                                        {
                                            validationresultkind = 2;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        chckidentefecation = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    validationresultkind = 1;
                                }
                            }
                            if (chckidentefecation == true)
                            {
                                intrsult = 1;
                                colorRichCox(mskd, Color.White, Color.Green);
                            }
                            else
                            {
                                if (validationresultkind == 1)
                                {
                                    tooltipShow(mskd, " لابد أنه يبدأ بأحد الإختيارات التالية ", 1);
                                }
                                else if (validationresultkind == 2)
                                {
                                    tooltipShow(mskd, " لم يتم التعرف على كود الدولة ", 2);
                                }
                            }
                        }
                        else
                        {
                            if (itemRef.Equals(mskd.Text.Replace(" ", "").Trim().Substring(0, itemRef.Length), StringComparison.OrdinalIgnoreCase))
                            {
                                if (mskd.Text.Replace(" ", "").Trim().Substring(0, itemRef.Length).ToString().Equals(itemRef, StringComparison.OrdinalIgnoreCase))
                                {
                                    string CtrlLblText = GetNextControl(mskd, false).Text.Substring(0, GetNextControl(mskd, false).Text.Length - 3);
                                    if (CtrlLblText == "رقم الشحنة" || CtrlLblText == "رقم الشحنة 3")
                                    {

                                        DataRow DRW = function.DRW(Statcdif.CDCountry, mskd.Text.Substring(13, 2), Statcdif.CDCountry.Columns["CounCd"]);
                                        if (DRW != null)
                                        {
                                            intrsult = 1;
                                            colorRichCox(mskd, Color.White, Color.Green);
                                        }
                                        else
                                        {
                                            tooltipShow(mskd, "لم يتم التعرف على كود رمز الدولة", 2);
                                        }
                                    }
                                    else
                                    {
                                        intrsult = 1;
                                        colorRichCox(mskd, Color.White, Color.Green);
                                    }
                                }
                            }
                            else
                            {
                                tooltipShow(mskd, " لابد أنه يبدأ بـ ");
                            }
                        }
                    }
                    else
                    {
                        intrsult = 1;
                        colorRichCox(mskd, Color.White, Color.Green);
                    }
                }
                else if (C.Tag.ToString().Split('-').Count() > 2 && itemRef.Length > 0)
                {
                    tooltipShow(C, " لابد أنه يبدأ بـ ");
                }
            }
            else if (C.GetType() == typeof(DateTimePicker))
            {
                DateTimePicker Dpkr = new DateTimePicker();
                Dpkr = (DateTimePicker)C;
                if (Dpkr.Value.ToString("dd/MM/yyyy") != DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"))
                {
                    intrsult = 1;
                    colorRichCox(Dpkr, Color.White, Color.Green);
                }
                else
                {
                    tooltipShow(Dpkr, " لابد أنه يكون يساوي أو أقل تاريخ اليوم");
                }
            }
            else if (C.GetType() == typeof(Label))
            {
                fn.ClorTxt(richTextBox1, C.Text.ToString().Substring(0, C.Text.Length - 3), Color.White, Color.Red, 14);
            }
            return intrsult;
        }
        private void tooltipShow(Control c, string msg, [Optional] int Err)
        {
            string CtrlLblText = GetNextControl(c, false).Text.Substring(0, GetNextControl(c, false).Text.Length - 3);
            if (c.GetType() == typeof(MaskedTextBox))
            {
                string nwline;
                if (Err == 1)
                {
                    nwline = Environment.NewLine + itemRef;
                }
                else if (Err == 2)
                {
                    nwline = null;
                }
                else
                {
                    nwline = Environment.NewLine + itemRef;
                }
                if (ActiveControl == c) { toolTip1.Show(msg + nwline, ActiveControl, 0, 30, 3000); };
            }
            else
            {
                if (ActiveControl == c) { toolTip1.Show(CtrlLblText + msg, ActiveControl, 0, 30, 3000); };
            }

        }
        private void colorRichCox(Control T, Color backclr, Color fontkclr)
        {
            string CtrlLblText = GetNextControl(T, false).Text;
            fn.ClorTxt(richTextBox1, CtrlLblText.ToString().Substring(0, CtrlLblText.Length - 3), backclr, fontkclr, 14);
        }
        private void CompReqst_CheckedChanged(object sender, EventArgs e)
        {
            populateTree();
        }
        private void populateTree()
        {
            this.TreeView1.AfterSelect -= new TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.TreeView1.BeforeSelect -= new TreeViewCancelEventHandler(TreeView1_BeforeSelect);
            if (RadioButton4.Checked)
            {
                TickKind = 0;
                this.Text = "طلب " + ComRefLbl.Text;
            }

            else if (RadioButton5.Checked)
            {
                TickKind = 1;
                this.Text = "شكوى " + ComRefLbl.Text;
            }

            if (TkCompSrc.Items.Count == 0)
            {
                TkCompSrc.DataSource = Statcdif.CompSurceTable;
                TkCompSrc.SelectedIndex = -1;
            }

            TreeView1.Visible = true;

            TreeView1.Nodes.Clear();


            if (TreeView1.Nodes.Count == 0)
            {
                String Child1 = "";
                TreeView1.ImageList = ImgLst;
                //;
                Statcdif.ProdKTable.DefaultView.RowFilter = "ProdKNm = '" + editStruct.dt.Rows[0]["ProdKNm"].ToString() + "'";
                for (int i = 0; i < Statcdif.ProdKTable.DefaultView.Count; i++)
                {
                    TreeView1.Nodes.Add(Statcdif.ProdKTable.DefaultView[i][0].ToString(), Statcdif.ProdKTable.DefaultView[i][1].ToString(), 1, 3);
                }
                if (TickKind == 0)
                {
                    Statcdif.ProdCompTable.DefaultView.RowFilter = "[CompReqst] = " + 1 + " AND PrdKind = '" + Statcdif.ProdKTable.DefaultView[0][0].ToString() + "'";
                }
                else
                {
                    Statcdif.ProdCompTable.DefaultView.RowFilter = "[CompReqst] = " + 0 + " AND PrdKind = '" + Statcdif.ProdKTable.DefaultView[0][0].ToString() + "'";
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

                                if (editStruct.dt.Rows[0]["TkFnPrdCd"].ToString() == Statcdif.ProdCompTable.DefaultView[i]["FnSQL"].ToString())
                                {   //this Node Value Will Be a Selected Node
                                    TempNode = TreeView1.Nodes.Find(editStruct.dt.Rows[0]["TkFnPrdCd"].ToString(), true);  //this Node Value Will Be a Selected Node
                                }
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
            FlwMainData.Enabled = false;
            this.TreeView1.AfterSelect -= new TreeViewEventHandler(this.TreeView1_AfterSelect);
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
            if (e.Action != TreeViewAction.Unknown)
            {
                TreeView1.SelectedNode.Expand();
                if (TreeView1.SelectedNode.Level == 2)
                {
                    DataRow DRW = function.DRW(Statcdif.ProdCompTable, TreeView1.SelectedNode.Name, Statcdif.ProdCompTable.Columns["FnSQL"]);
                    itemRef = DRW.ItemArray[7].ToString();
                    TeamIdentfier = Convert.ToInt32(DRW.ItemArray[8]);
                    Help_ = DRW.ItemArray[11].ToString();
                    lblhelp.Text = Help_;
                    Timer1.Start();
                    PrdKind = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[0];
                    PrdNm.Text = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[1];
                    CompNm.Text = TreeView1.SelectedNode.FullPath.ToString().Split('\\')[2];
                    Statcdif.MendFildsTable.DefaultView.RowFilter = "[MendCdFn]  = " + TreeView1.SelectedNode.Name + " and MendStat = 0";

                    mendFlowWithText();
                    populateFlowMend();
                    FlwMainData.Enabled = true;
                }
                else if (TreeView1.SelectedNode.Level < 2)
                {
                    FlwMainData.Enabled = false;
                    PrdKind = "";
                    PrdNm.Text = "";
                    CompNm.Text = "";
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
        }
        private void populateFlowMend()
        {
            //FlwMend.Controls.Clear();
            for (int i = 0; i < Statcdif.MendFildsTable.DefaultView.Count; i++)
            {
                if (!ctrlList.Contains(Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"]))
                {
                    Label Lbl = new Label();
                    Lbl.AutoSize = false;
                    Lbl.RightToLeft = RightToLeft.Yes;
                    Lbl.TextAlign = ContentAlignment.MiddleRight;
                    Lbl.Margin = new Padding(3, 3, 3, 3);
                    Lbl.Font = CtrlFont;
                    Lbl.Size = lblsize;
                    Lbl.Text = Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"] + " : ";
                    Lbl.Name = Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"].ToString();
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
                        Ctrl.Name = Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"].ToString();
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
                        Ctrl.Name = Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"].ToString();
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
                        Ctrl.Name = Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"].ToString();
                        Ctrl.PromptChar = Convert.ToChar(" ");
                        FlwMend.Controls.Add(Ctrl);
                    }
                    else if (Statcdif.MendFildsTable.DefaultView[i]["CDMendType"].ToString().Equals("DateTimePicker", StringComparison.OrdinalIgnoreCase))
                    {
                        DateTimePicker Ctrl = new DateTimePicker();
                        Ctrl.Font = CtrlFont;
                        Ctrl.Size = Ctrlsize;
                        Ctrl.MaxDate = DateTime.Now.AddDays(2);
                        Ctrl.Format = DateTimePickerFormat.Short;
                        Ctrl.Value = DateTime.Now.AddDays(1);
                        Ctrl.Tag = Statcdif.MendFildsTable.DefaultView[i]["CDMendDatatype"].ToString();
                        Ctrl.Name = Statcdif.MendFildsTable.DefaultView[i]["CDMendTxt"].ToString();
                        FlwMend.Controls.Add(Ctrl);
                    }
                }
            }
            forms.FrmAllSub(this);
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
            TkClPh.Enabled = true;
            TkClPh.Text = "";
            if (RadioButton8.Checked)
            {
                TkClPh.Mask = "00000000000";
            }
            else if (RadioButton9.Checked)
            {
                TkClPh.Mask = "0000000000";
            }
            TkClPh.Focus();
            if (!chckphonechange.Checked)
            {
                TkClNm.Text = "";
                TkClAdr.Text = "";
                TkClPh1.Text = "";
                TkMail.Text = "";
                customerTable.Rows.Clear();
            }

        }
        private void RadioPhone2_Click(object sender, EventArgs e)
        {
            TimrPhons.Start();
            TkClPh1.Enabled = true;
            TkClPh1.Text = "";
            if (RadioButton11.Checked)
            {
                TkClPh1.Mask = "00000000000";
            }
            else if (RadioButton12.Checked)
            {
                TkClPh1.Mask = "0000000000";
            }
            TkClPh1.Focus();

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
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // NOTE: set form's KeyPreview property to True
            if (e.KeyCode == Keys.F1)
            {
                sndr = (TextBox)sender;
                tbl = new DataTable();
                tbl = fn.returntbl(sndr.AccessibleName);
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
                    //fn.msg("هناك خطأ في الإتصال بقواعد البيانات", "تحميل البيانات");
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
            TxBox.Enter += new EventHandler(TxtEnter);
        }
        private void TxtEnter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = Statcdif.ArabicInput;
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
            this.RadioButton4.Click -= new EventHandler(this.CompReqst_CheckedChanged);
            this.RadioButton5.Click -= new EventHandler(this.CompReqst_CheckedChanged);
            List<string> updateString = new List<string>();
            List<string> updateStrMend = new List<string>();
            StringBuilder UpTxt = new StringBuilder();
            if (TkCompSrc.Text != editStruct.dt.Rows[0]["SrcNm"].ToString())
            {
                UpTxt.Append(Environment.NewLine + "تم تعديل " + TkCompSrc.AccessibleName + " من " + "\"" + editStruct.dt.Rows[0]["SrcNm"].ToString() + "\"" + " إلى " + "\"" + TkCompSrc.Text + "\"");
                updateString.Add("TkCompSrc ='" + TkCompSrc.SelectedValue + "'");
            }

            IEnumerable<Control> lstCTRL;
            frms frm = new frms();
            lstCTRL = frm.GetAll(this, typeof(TextBox));

            foreach (Control item in lstCTRL)
            {
                TextBox c = (TextBox)item;
                if (function.CheckArlanguage(c.Name))
                {
                    if (ctrlList.Contains(c.Name))
                    {
                        if (c.Text != editStruct.dt.Rows[0][c.Name].ToString())
                        {
                            UpTxt.Append(Environment.NewLine + "تم تعديل " + c.Name + " من " + "\"" + editStruct.dt.Rows[0][c.Name].ToString() + "\"" + " إلى " + "\"" + c.Text + "\"");
                            updateStrMend.Add("Update TKMendFields set FildTxt = '" + c.Text.Replace(" ", "") + "' where FildKind = '" + c.Name + "' AND FildRelted = " + ComRefLbl.Text);
                        }
                    }
                    else if (!ctrlList.Contains(c.Name))
                    {
                        UpTxt.Append(Environment.NewLine + "تم إضاقة " + c.Name + "\"" + c.Text + "\"");
                        updateStrMend.Add("INSERT INTO TKMendFields (FildRelted, FildKind, FildTxt) VALUES (" + ComRefLbl.Text + ", '" + c.Name + "', '" + c.Text.Replace(" ", "") + "')");
                    }
                }
                else if (!function.CheckArlanguage(c.Name))
                {
                    if (c.ReadOnly == false && c.Name != "ComRefLbl")
                    {
                        if (c.Text != editStruct.dt.Rows[0][c.Name].ToString())
                        {
                            if (c.Text.Length == 0)
                            {
                                UpTxt.Append(Environment.NewLine + "تم حذف " + c.AccessibleName + "\"" + editStruct.dt.Rows[0][c.Name].ToString() + "\"");
                            }
                            else if (editStruct.dt.Rows[0][c.Name].ToString().Length == 0)
                            {
                                UpTxt.Append(Environment.NewLine + "تم إضافة " + c.AccessibleName + "\"" + c.Text + "\"");
                            }
                            else
                            {
                                UpTxt.Append(Environment.NewLine + "تم تعديل " + c.AccessibleName + " من " + "\"" + editStruct.dt.Rows[0][c.Name].ToString() + "\"" + " إلى " + "\"" + c.Text + "\"");
                            }
                            updateString.Add(c.Name + " ='" + c.Text + "'");
                        }
                    }
                }
            }

            lstCTRL = frm.GetAll(this, typeof(MaskedTextBox));

            foreach (Control item in lstCTRL)
            {
                MaskedTextBox c = (MaskedTextBox)item;
                if (function.CheckArlanguage(c.Name))
                {
                    if (ctrlList.Contains(c.Name))
                    {
                        if (c.Text.Replace(" ", "") != editStruct.dt.Rows[0][c.Name].ToString())
                        {
                            UpTxt.Append(Environment.NewLine + "تم تعديل " + c.Name + " من " + "\"" + editStruct.dt.Rows[0][c.Name].ToString() + "\"" + " إلى " + "\"" + c.Text.Replace(" ", "") + "\"");
                            updateStrMend.Add("Update TKMendFields set FildTxt = '" + c.Text.Replace(" ", "") + "' where FildKind = '" + c.Name + "' AND FildRelted = " + ComRefLbl.Text);
                        }
                    }
                    else if (!ctrlList.Contains(c.Name))
                    {
                        UpTxt.Append(Environment.NewLine + "تم إضاقة " + c.Name + "\"" + c.Text.Replace(" ", "") + "\"");
                        updateStrMend.Add("INSERT INTO TKMendFields (FildRelted, FildKind, FildTxt) VALUES (" + ComRefLbl.Text + ", '" + c.Name + "', '" + c.Text.Replace(" ", "") + "')");
                    }
                }
                else if (!function.CheckArlanguage(c.Name))
                {
                    if (c.Text.Replace(" ", "") != editStruct.dt.Rows[0][c.Name].ToString())
                    {
                        if (c.Text.Replace(" ", "").Length == 0)
                        {
                            UpTxt.Append(Environment.NewLine + "تم حذف " + c.AccessibleName + "\"" + editStruct.dt.Rows[0][c.Name].ToString() + "\"");
                        }
                        else if (editStruct.dt.Rows[0][c.Name].ToString().Length == 0)
                        {
                            UpTxt.Append(Environment.NewLine + "تم إضافة " + c.AccessibleName + "\"" + c.Text.Replace(" ", "") + "\"");
                        }
                        else
                        {
                            UpTxt.Append(Environment.NewLine + "تم تعديل " + c.AccessibleName + " من " + "\"" + editStruct.dt.Rows[0][c.Name].ToString() + "\"" + " إلى " + "\"" + c.Text.Replace(" ", "") + "\"");
                        }
                        updateString.Add(c.Name + " ='" + c.Text.Replace(" ", "") + "'");
                    }
                }
            }
            lstCTRL = frm.GetAll(this, typeof(DateTimePicker));
            foreach (Control item in lstCTRL)
            {
                DateTimePicker c = (DateTimePicker)item;
                if (ctrlList.Contains(c.Name))
                {
                    if (c.Text != editStruct.dt.Rows[0][c.Name].ToString())
                    {
                        UpTxt.Append(Environment.NewLine + "تم تعديل " + c.Name + " من " + "\"" + editStruct.dt.Rows[0][c.Name].ToString() + "\"" + " إلى " + "\"" + c.Text + "\"");
                        updateStrMend.Add("Update TKMendFields set FildTxt = " + "CONVERT(VARCHAR, '" + c.Text + "', 111)" + " where FildKind = '" + c.Name + "' AND FildRelted = " + ComRefLbl.Text);
                    }
                }
                else if (!ctrlList.Contains(c.Name))
                {
                    UpTxt.Append(Environment.NewLine + "تم إضاقة " + c.Name + "\"" + string.Format(c.Text, "yyyy-mm-dd") + "\"");
                    updateStrMend.Add("INSERT INTO TKMendFields (FildRelted, FildKind, FildTxt) VALUES (" + ComRefLbl.Text + ", '" + c.Name + "', " + "CONVERT(VARCHAR, '" + c.Text + "', 111)" + ")");
                }

            }

            if (TreeView1.SelectedNode.Name != editStruct.dt.Rows[0]["TkFnPrdCd"].ToString())
            {
                updateString.Add("TkFnPrdCd =" + TreeView1.SelectedNode.Name);
                if (PrdNm.Text != editStruct.dt.Rows[0]["PrdNm"].ToString())
                {
                    UpTxt.Append(Environment.NewLine + "تم تعديل الخدمة من " + "\"" + editStruct.dt.Rows[0]["PrdNm"].ToString().Trim() + "\"" + " إلى " + "\"" + PrdNm.Text.Trim() + "\"");
                }
                if (CompNm.Text != editStruct.dt.Rows[0]["CompNm"].ToString())
                {
                    UpTxt.Append(Environment.NewLine + "تم تعديل الشكوى من " + "\"" + editStruct.dt.Rows[0]["CompNm"].ToString().Trim() + "\"" + " إلى " + "\"" + CompNm.Text.Trim() + "\"");
                }
            }
            string UpdtString = UpTxt.ToString();
            string Up_Insrt_Str = string.Join(" ; ", updateStrMend);
            string TickStrUpdateStr = "";
            if (updateString.Count > 0)
            {
                TickStrUpdateStr = "Update Tickets set " + string.Join(", ", updateString) + " Where TKSQL = " + Convert.ToInt32(ComRefLbl.Text);
            }
            if (UpdtString.Length > 0)
            {
                DialogResult dialogResult = MessageBox.Show("سيتم عمل التالي وتسجيل هذا التحديث: " + Environment.NewLine + UpdtString + Environment.NewLine + "هل تريد الإستمرار؟", "شاشة التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                if (dialogResult == DialogResult.Yes)
                {

                    if (ticketCurrent.addevent(Convert.ToInt32(ComRefLbl.Text), UpdtString, 901, Statcdif._IP, CurrentUser.UsrID, TickStrUpdateStr + ";" + Up_Insrt_Str, null, null) == null)
                    {
                        GetTicket(" AND TKSQL = " + ComRefLbl.Text);
                        assignTicket();
                        fn.msg("تم تعديل الشكوى بنجاح", "تعديل الشكوى", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                fn.msg("لا توجد تعديلات للحفظ", "تعديل الشكوى", MessageBoxButtons.OK);
            }

            this.RadioButton4.Click += new EventHandler(this.CompReqst_CheckedChanged);
            this.RadioButton5.Click += new EventHandler(this.CompReqst_CheckedChanged);
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RadNID_Click(object sender, EventArgs e)
        {



        }
        private void Phon1TxtBx_TextChanged(object sender, EventArgs e)
        {
            if (!chckphonechange.Checked)
            {
                customerdata(TkClPh, "select top(1) TkClNm,TkClPh1,TkClNtID,TkClAdr,TkMail from Tickets where TkClPh ='");
            }
        }
        private void IDTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (!chckIDChange.Checked)
            {
                customerdata(TkClNtID, "select top(1) TkClNm,TkClPh,TkClPh1,TkClAdr,TkMail from Tickets where TkClNtID ='");
            }
        }
        private void customerdata(MaskedTextBox mskdTextBox, string SlctString)
        {
            this.TkClPh.TextChanged -= new System.EventHandler(this.Phon1TxtBx_TextChanged);
            this.TkClNtID.TextChanged -= new System.EventHandler(this.IDTxtBx_TextChanged);
            string tmp = "";
            if (mskdTextBox.Text.Trim().Length == mskdTextBox.Mask.Length)
            {
                tmp = lblhelp.Text;
                Timer1.Stop();
                this.Enabled = false;
                lblhelp.Text = "جاري البحث عن بيانات العميل ....";
                StringBuilder selectString = new StringBuilder();
                customerTable.Rows.Clear();

                selectString.Append(SlctString + mskdTextBox.Text.ToString());
                if (mskdTextBox == TkClPh) { selectString.Append("' or  TkClPh1 ='" + mskdTextBox.Text.ToString()); }
                selectString.Append("'  order by TkSQL desc");

                customerTable = fn.returntbl(selectString.ToString());
                if (customerTable.Rows.Count > 0)
                {
                    if (mskdTextBox != TkClPh)
                    {
                        TkClPh.Text = customerTable.Rows[0]["TkClPh"].ToString();
                    }
                    if (mskdTextBox != TkClNtID)
                    {
                        TkClNtID.Text = customerTable.Rows[0]["TkClNtID"].ToString();
                    }
                    TkClNm.Text = customerTable.Rows[0]["TkClNm"].ToString();
                    TkClPh1.Text = customerTable.Rows[0]["TkClPh1"].ToString();
                    TkClAdr.Text = customerTable.Rows[0]["TkClAdr"].ToString();
                    TkMail.Text = customerTable.Rows[0]["TkMail"].ToString();
                }
                else
                {
                    clearcustomerdata(mskdTextBox);
                }
            }
            else
            {
                clearcustomerdata(mskdTextBox);
            }
            this.TkClPh.TextChanged += new System.EventHandler(this.Phon1TxtBx_TextChanged);
            this.TkClNtID.TextChanged += new System.EventHandler(this.IDTxtBx_TextChanged);
            this.Enabled = true;
            lblhelp.Text = tmp;
            Timer1.Start();
        }
        private void clearcustomerdata(MaskedTextBox mskdTextBox)
        {
            if (mskdTextBox != TkClPh)
            {
                if (!chckphonechange.Checked) { TkClPh.Text = ""; }
            }
            if (mskdTextBox != TkClNtID)
            {
                if (!chckIDChange.Checked) { TkClNtID.Text = ""; };
            }
            TkClNm.Text = "";
            TkClPh1.Text = "";
            TkClAdr.Text = "";
            TkMail.Text = "";
            customerTable.Rows.Clear();
        }
        private void RadPss_CheckedChanged(object sender, EventArgs e)
        {
            TkClNtID.Text = "";
            if (RadPss.Checked == true)
            {
                TkClNtID.Tag = "English-TextNumber";
                TkClNtID.Mask = "AAAAAAAAAAAAAA";
                RadNID.Checked = false;
                RadPss.Checked = true;
                Label11.Text = "رقم جواز السفر : ";
                TkClNtID.AccessibleName = "رقم جواز السفر";
                chckIDChange.Text = "تغيير رقم جواز السفر";
                richTextBox1.Text = richTextBox1.Text.Replace("الرقم القومي", "رقم جواز السفر");
            }
        }
        private void RadNID_CheckedChanged(object sender, EventArgs e)
        {
            TkClNtID.Text = "";
            if (RadNID.Checked == true)
            {
                TkClNtID.Tag = "English-Number";
                TkClNtID.Mask = "00000000000000";
                RadNID.Checked = true;
                RadPss.Checked = false;
                Label11.Text = "الرقم القومي : ";
                TkClNtID.AccessibleName = "الرقم القومي";
                chckIDChange.Text = "تغيير الرقم القومي";
                richTextBox1.Text = richTextBox1.Text.Replace("رقم جواز السفر", "الرقم القومي");
            }
        }
        private void MailTxtBx_Validating(object sender, CancelEventArgs e)
        {
            if (function.EmailIsValid(TkMail.Text) == false && TkMail.Text.Length > 0)
            {
                fn.msg("الإيميل الذي تم إدخاله غير صحيح", "فحص الإيميل", MessageBoxButtons.OK);
                TkMail.Focus();
            }
        }
        DAL.DataAccessLayer.rturnStruct editStruct;
        private String GetTicket(string SQLID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Any", SqlDbType.NVarChar);
            param[0].Value = SQLID;
            editStruct = DAL.SelectData("SP_TICKETS_SLCT", param);
            DAL.Close();
            return editStruct.msg;
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            NewTickSub();
            TreeView1.CollapseAll();
            if (GetTicket(" AND TKSQL = " + ComRefLbl.Text) == null && editStruct.dt.Rows.Count > 0)
            {
                if (editStruct.dt.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(editStruct.dt.Rows[0]["TkClsStatus"]) == false)
                    {
                        assignTicket();
                    }
                    else
                    {
                        fn.msg("الشكوى مغلقة ولا يمكن تعديلها", "تعديل الشكوى", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                fn.msg("لم يتم العثور على الشكوى" + Environment.NewLine + "من فضلك تأكد من الرقم وأعد المحاولة", "تعديل الشكوى", MessageBoxButtons.OK);
            }
        }
        private void assignTicket()
        {

            this.TkClPh.TextChanged -= new EventHandler(this.Phon1TxtBx_TextChanged);
            this.TkClNtID.TextChanged -= new EventHandler(this.IDTxtBx_TextChanged);
            this.TreeView1.AfterSelect -= new TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.TreeView1.BeforeSelect -= new TreeViewCancelEventHandler(TreeView1_BeforeSelect);

            if (editStruct.dt.Rows[0]["TkKind"].ToString() == "شكوى") { RadioButton5.Checked = true; TickKind = 1; this.Text = "شكوى رقم : " + ComRefLbl.Text; } else { RadioButton4.Checked = true; TickKind = 0; this.Text = "طلب رقم : " + ComRefLbl.Text; }
            populateTree();
            TreeView1.SelectedNode = TempNode[0];
            DateTxtBx.Text = editStruct.dt.Rows[0]["TkDtStart"].ToString();

            TkCompSrc.Text = editStruct.dt.Rows[0]["SrcNm"].ToString();

            TkClNm.Text = editStruct.dt.Rows[0]["TkClNm"].ToString();
            if (editStruct.dt.Rows[0]["TkClPh"].ToString().Length > 0)
            {
                if (editStruct.dt.Rows[0]["TkClPh"].ToString().Length == 11)
                {
                    TkClPh.Text = editStruct.dt.Rows[0]["TkClPh"].ToString();
                    RadioButton8.Checked = true;
                }
                else if (editStruct.dt.Rows[0]["TkClPh"].ToString().Length == 10)
                {
                    TkClPh.Text = editStruct.dt.Rows[0]["TkClPh"].ToString();
                    RadioButton9.Checked = true;
                }
                TkClPh.Enabled = true;
            }
            else
            {
                TkClPh.Enabled = false;
            }
            if (editStruct.dt.Rows[0]["TkClPh1"].ToString().Length > 0)
            {
                if (editStruct.dt.Rows[0]["TkClPh1"].ToString().Length == 11)
                {
                    TkClPh1.Text = editStruct.dt.Rows[0]["TkClPh1"].ToString();
                    RadioButton11.Checked = true;
                }
                else if (editStruct.dt.Rows[0]["TkClPh1"].ToString().Length == 10)
                {
                    TkClPh1.Text = editStruct.dt.Rows[0]["TkClPh1"].ToString();
                    RadioButton12.Checked = true;
                }
                TkClPh1.Enabled = true;
            }
            else
            {
                TkClPh1.Enabled = false;
            }
            TkMail.Text = editStruct.dt.Rows[0]["TkMail"].ToString();
            TkClAdr.Text = editStruct.dt.Rows[0]["TkClAdr"].ToString();

            bool isnumber = true;
            for (int i = 0; i < editStruct.dt.Rows[0]["TkClNtID"].ToString().Length; i++)
            {
                if (!char.IsNumber(Convert.ToChar(editStruct.dt.Rows[0]["TkClNtID"].ToString().Substring(i, 1))))
                {
                    isnumber = false;
                    break;
                }
            }

            if (isnumber == true)
            {
                RadNID.Checked = true;
            }
            else
            {
                RadPss.Checked = true;
            }
            TkClNtID.Text = editStruct.dt.Rows[0]["TkClNtID"].ToString();
            PrdNm.Text = editStruct.dt.Rows[0]["PrdNm"].ToString();
            CompNm.Text = editStruct.dt.Rows[0]["CompNm"].ToString();
            TkDetails.Text = editStruct.dt.Rows[0]["TkDetails"].ToString();

            FlwMend.Refresh();

            ctrlList = new List<string>();
            for (int i = 0; i < editStruct.dt.Columns.Count; i++)
            {
                if (function.CheckArlanguage(editStruct.dt.Columns[i].ColumnName) == true)
                {
                    ctrlList.Add(editStruct.dt.Columns[i].ColumnName);
                }
            }
            //Statcdif.MendFildsTable.DefaultView.RowFilter = "[MendCdFn]  = " + TreeView1.SelectedNode.Name + " and MendStat = 0";

            //populateFlowMend();
            mendFlowWithText();
            this.TkClPh.TextChanged += new EventHandler(this.Phon1TxtBx_TextChanged);
            this.TkClNtID.TextChanged += new EventHandler(this.IDTxtBx_TextChanged);
            this.TreeView1.AfterSelect -= new TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.TreeView1.AfterSelect += new TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.TreeView1.BeforeSelect += new TreeViewCancelEventHandler(TreeView1_BeforeSelect);
        }
        private void mendFlowWithText()
        {
            FlwMend.Controls.Clear();
            FlwMainData.Enabled = true;
            DataRow DRW1 = function.DRW(Statcdif.ProdCompTable, TreeView1.SelectedNode.Name, Statcdif.ProdCompTable.Columns["FnSQL"]);
            itemRef = DRW1.ItemArray[7].ToString();
            mendlstlbl();
            for (int i = 0; i < ctrlList.Count; i++)
            {
                DataRow DRW = function.DRW(Statcdif.CDMend, ctrlList[i].ToString(), Statcdif.CDMend.Columns[2]);
                Label Lbl = new Label();
                Lbl.AutoSize = false;
                Lbl.RightToLeft = RightToLeft.Yes;
                Lbl.TextAlign = ContentAlignment.MiddleRight;
                Lbl.Margin = new Padding(3, 3, 3, 3);
                Lbl.Font = CtrlFont;
                Lbl.Size = lblsize;
                Lbl.Text = DRW.ItemArray[2] + " : ";
                Lbl.Name = DRW.ItemArray[2].ToString();
                FlwMend.Controls.Add(Lbl);
                richTextBox1.Text += DRW.ItemArray[2].ToString() + Environment.NewLine;

                Control Ctrl = new Control();

                if (DRW.ItemArray[1].ToString().Equals("TextBox", StringComparison.OrdinalIgnoreCase))
                {
                    TextBox txtBx = new TextBox();
                    txtBx.RightToLeft = RightToLeft.Yes;
                    txtBx.Font = CtrlFont;
                    txtBx.Size = Ctrlsize;
                    txtBx.Tag = DRW.ItemArray[4].ToString();
                    txtBx.AccessibleName = DRW.ItemArray[3].ToString();
                    txtBx.TextAlign = HorizontalAlignment.Center;
                    if (DBNull.Value.Equals(DRW.ItemArray[5]) == false) { txtBx.MaxLength = Convert.ToInt32(DRW.ItemArray[5]); };
                    FlwMend.Controls.Add(txtBx);
                }
                else if (DRW.ItemArray[1].ToString().Equals("TextBoxC", StringComparison.OrdinalIgnoreCase))
                {
                    TextBox txtBx = new TextBox();
                    txtBx.RightToLeft = RightToLeft.Yes;
                    txtBx.Font = CtrlFont;
                    txtBx.Size = Ctrlsize;
                    txtBx.Tag = DRW.ItemArray[4].ToString();
                    txtBx.AccessibleName = DRW.ItemArray[3].ToString();
                    txtBx.TextAlign = HorizontalAlignment.Center;
                    txtBx.ReadOnly = true;
                    txtBx.KeyDown += new KeyEventHandler(TextBox_KeyDown);
                    txtBx.Enter += new EventHandler(TextBox_ENTER);
                    txtBx.Leave += new EventHandler(TextBox_LEAVE);
                    FlwMend.Controls.Add(txtBx);
                }
                else if (DRW.ItemArray[1].ToString().Equals("MaskedTextBox", StringComparison.OrdinalIgnoreCase))
                {
                    MaskedTextBox MsktxtBx = new MaskedTextBox();
                    MsktxtBx.RightToLeft = RightToLeft.No;
                    MsktxtBx.Font = CtrlFont;
                    MsktxtBx.Size = Ctrlsize;
                    MsktxtBx.Tag = DRW.ItemArray[4].ToString();
                    MsktxtBx.AccessibleName = DRW.ItemArray[3].ToString();
                    MsktxtBx.TextAlign = HorizontalAlignment.Center;
                    MsktxtBx.Mask = DRW.ItemArray[6].ToString();
                    MsktxtBx.PromptChar = Convert.ToChar(" ");
                    FlwMend.Controls.Add(MsktxtBx);
                }
                else if (DRW.ItemArray[1].ToString().Equals("DateTimePicker", StringComparison.OrdinalIgnoreCase))
                {
                    DateTimePicker pkrtxtBx = new DateTimePicker();
                    pkrtxtBx.RightToLeft = RightToLeft.No;
                    pkrtxtBx.Font = CtrlFont;
                    pkrtxtBx.Size = Ctrlsize;
                    pkrtxtBx.Tag = DRW.ItemArray[4].ToString();
                    pkrtxtBx.MaxDate = DateTime.Now.AddDays(2);
                    pkrtxtBx.Format = DateTimePickerFormat.Short;
                    pkrtxtBx.Value = DateTime.Now.AddDays(1);
                    FlwMend.Controls.Add(pkrtxtBx);
                }
                GetNextControl(Lbl, true).Text = editStruct.dt.Rows[0][ctrlList[i].ToString()].ToString();
                GetNextControl(Lbl, true).Name = Lbl.Text.ToString().Split(':')[0].ToString().Trim();
            }

            Timer1.Start();
        }
        private void ComRefLbl_TextChanged(object sender, EventArgs e)
        {
            Statcdif.CompSurceTable.DefaultView.RowFilter = string.Empty;
            if (editStruct.dt != null && editStruct.dt.Rows.Count > 0)
            {
                editStruct.dt.Rows.Clear();
                NewTickSub();
            }
            if (ComRefLbl.Text.Length > 0)
            {
                btnLoad.Enabled = true;
            }
            else
            {
                btnLoad.Enabled = false;
            }
        }
        private void TikEdit_Load(object sender, EventArgs e)
        {
            frm.FormClosed -= new FormClosedEventHandler(frm_Closed);
            frm.FormClosed += new FormClosedEventHandler(frm_Closed);
            ComRefLbl.Select();
        }
    }
}
