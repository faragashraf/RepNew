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
    public partial class TikNew : Form
    {

        private static TikNew frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
            GC.Collect();
        }
        public static TikNew getTiknewfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikNew();
                }
                return frm;
            }
        }
        frms forms = new frms();
        function fn = function.getfn;
        DataTable customerTable = new DataTable();
        Form Frm;
        DataGridView GV;
        DataTable choicetbl;
        FlowLayoutPanel Flow;
        TextBox TxBox;
        TextBox sndr;
        int TickKind;
        string PrdKind;
        //int COMPID_ = 0;
        string itemRef;
        int TeamIdentfier;
        string Help_;
        DataTable DublicatedTbl;
        bool bolDublicted = false;
        int lblColor = 35;
        public TikNew()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
            forms.FrmAllSub(this);
            NewTickSub();
            this.Phon1TxtBx.TextChanged += new System.EventHandler(this.Phon1TxtBx_TextChanged);
            this.IDTxtBx.TextChanged += new System.EventHandler(this.IDTxtBx_TextChanged);
            if (CurrentUser.UsrUCatLvl == 7)
            {
                Statcdif.CompSurceTable.DefaultView.RowFilter = "[SrcSusp] = 0 AND [srcCd] = '1'";     //     SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1 ORDER BY SrcNm";
            }
            else
            {
                Statcdif.CompSurceTable.DefaultView.RowFilter = "[SrcSusp] = 0 AND [srcCd] > '1'";   //  SrcStr = "Select SrcCd, SrcNm from CDSrc where SrcSusp=0 And srcCd > 1 ORDER BY SrcNm"
            }
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
            chckIDChange.Text = "تغيير الرقم القومي";

            TickKind = 0;
            PrdKind = "";
            MyGroupBox3.Enabled = true;
            FlwTree.Enabled = true;
            BtnDublicate.Visible = false;
            FlwMainData.Enabled = false;
            FlwMainData.BackColor = Color.FromArgb(192, 255, 255);
            label8.Text = "";
            label8.BackColor = Color.White;
            richTextBox1.Text = "";
            lblhelp.Text = "";
            chckIDChange.Checked = false;
            chckphonechange.Checked = false;

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
                if (RadNID.Checked == true && IDTxtBx.Text.Replace(" ", "").Trim().Length == 14)
                {
                    if (function.validateNationalID(IDTxtBx.Text.Replace(" ", "").Trim().ToString()) == true)
                    {
                        DublicatedTik();
                        Complete_ += 1;
                        fn.ClorTxt(richTextBox1, IDTxtBx.AccessibleName, Color.White, Color.Green, 14);
                    }
                    else
                    {
                        fn.ClorTxt(richTextBox1, IDTxtBx.AccessibleName, Color.White, Color.Red, 14);
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
                factor += 4;
                Label29.Visible = false;
            }

            //Check Customer Phone 1
            if (function.validatePhoneNumber(Phon1TxtBx.Text.Trim()) == true)
            {
                DublicatedTik();
                Complete_ += 1;
                toolTip1.Hide(Phon1TxtBx);
                fn.ClorTxt(richTextBox1, Phon1TxtBx.AccessibleName, Color.White, Color.Green, 14);
            }
            else
            {
                bolDublicted = false;
                FlwMainData.BackColor = Color.FromArgb(192, 255, 255);
                label8.Text = "";
                label8.BackColor = Color.White;
                if (RadioButton8.Checked == true)
                {
                    if (ActiveControl == Phon1TxtBx) { toolTip1.Show("رقم الموبايل لابد أنه يبدأ بـ " + Environment.NewLine + " 010, 011, 012 أو 015 ", ActiveControl, 0, 30, 1000); }
                }
                else if (RadioButton9.Checked == true)
                {
                    if (ActiveControl == Phon1TxtBx) { toolTip1.Show("رقم التليفون لابد أن يبدأ بكود المحافظة" + Environment.NewLine + "مثال : \"02XXXXXXXX", ActiveControl, 0, 30, 1000); }
                }
                fn.ClorTxt(richTextBox1, Phon1TxtBx.AccessibleName, Color.White, Color.Red, 14);
            }

            if (function.validatePhoneNumber(Phon2TxtBx.Text.Trim()) == true)
            {
                toolTip1.Hide(Phon2TxtBx);
                fn.ClorTxt(richTextBox1, Phon2TxtBx.AccessibleName, Color.White, Color.Green, 14);
            }
            else
            {
                if (RadioButton11.Checked == true)
                {
                    if (ActiveControl == Phon2TxtBx) { toolTip1.Show("رقم الموبايل لابد أنه يبدأ بـ " + Environment.NewLine + " 010, 011, 012 أو 015 ", ActiveControl, 0, 30, 1000); }
                }
                else if (RadioButton12.Checked == true)
                {
                    if (ActiveControl == Phon2TxtBx) { toolTip1.Show("رقم التليفون لابد أن يبدأ بكود المحافظة" + Environment.NewLine + "مثال : \"02XXXXXXXX", ActiveControl, 0, 30, 1000); }
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
                if (lblColor >= 150 && lblColor <= 250)
                {
                    lblhelp.ForeColor = Color.FromArgb(lblColor, 10, lblColor);
                    lblColor -= 5;
                }
                else if (lblColor >= 10 && lblColor < 150)
                {
                    lblhelp.ForeColor = Color.FromArgb(0, 255, 0);
                    lblColor +=30;
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
            FlwMainData.Enabled = false;
            this.TreeView1.AfterSelect += new TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.TreeView1.BeforeSelect += new TreeViewCancelEventHandler(this.TreeView1_BeforeSelect);
        }
        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (TreeView1.SelectedNode == null)
            {
            }
            else
            {
                bolDublicted = false;
                if (TreeView1.SelectedNode.Level == 2)
                    TreeView1.SelectedNode.Parent.Parent.Collapse(false);  // True to leave the child nodes in their Current state; false to collapse the child nodes.
                else if (TreeView1.SelectedNode.Level == 1)
                    // CombProdRef.Items.Clear()
                    TreeView1.SelectedNode.Parent.Collapse(false);
                else if (TreeView1.SelectedNode.Level == 0)
                    // CombProdRef.Items.Clear()
                    TreeView1.SelectedNode.Collapse(false);
            }
        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView1.SelectedNode.Expand();
            BtnAdd.Enabled = true;
            if (TreeView1.SelectedNode.Level == 2)
            {
                DublicatedTik();
                DataRow DRW = function.DRW(Statcdif.ProdCompTable, TreeView1.SelectedNode.Name, Statcdif.ProdCompTable.Columns["FnSQL"]);
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
                        Ctrl.MaxDate = DateTime.Now.AddDays(2);
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
                bolDublicted = false;
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
            if (!chckphonechange.Checked)
            {
                NameTxtBx.Text = "";
                AddTxtBx.Text = "";
                Phon2TxtBx.Text = "";
                MailTxtBx.Text = "";
                customerTable.Rows.Clear();
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
                choicetbl = new DataTable();
                choicetbl = fn.returntbl(sndr.AccessibleName);
                if (choicetbl.Rows.Count > 0)
                {
                    choicetbl.DefaultView.RowFilter = string.Empty;
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
                    choicetbl.Dispose();
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
            Frm.Text = "اختيار " + GetNextControl(sndr, false).Text + " عدد البيانات " + choicetbl.Rows.Count;
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
            GV.DataSource = choicetbl.DefaultView;
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
            choicetbl.DefaultView.RowFilter = "[" + choicetbl.Columns[0].ColumnName + "]" + " like '%" + TxBox.Text + "%'";
            GV.DataSource = choicetbl.DefaultView;
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
            this.RadioButton4.Click -= new System.EventHandler(this.CompReqst_CheckedChanged);
            this.RadioButton5.Click -= new System.EventHandler(this.CompReqst_CheckedChanged);
            if (CurrentUser.UsrUCatLvl >= 3 && CurrentUser.UsrUCatLvl <= 5)
            {
                AddNewTicket(CurrentUser.UsrID);
            }
            else
            {
                AddNewTicket(TeamIdentfier);
            }
            this.RadioButton4.Click += new System.EventHandler(this.CompReqst_CheckedChanged);
            this.RadioButton5.Click += new System.EventHandler(this.CompReqst_CheckedChanged);
        }
        private int insertTicket(bool kind, int cdfnid, int src, string clNm, string ClPh, string ClPh1, string ClAdr, string ClNtID
                                                            , string TkDetails, int EmpNm0, int EmpNm, string ClMail, string IP, DataTable FIELDTABL)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[15];
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
            param[13] = new SqlParameter("@TkUserIP", SqlDbType.NVarChar, 15);
            param[13].Value = IP;

            // Add Out Put Parameter
            param[14] = new SqlParameter();
            param[14].Direction = ParameterDirection.Output;
            param[14].ParameterName = "@Comdid";
            param[14].SqlDbType = SqlDbType.Int;


            DAL.DataAccessLayer.rturnStruct RsultPopulateChoice = DAL.ExcuteCommand("SP_TICKETS_INSERT", param);
            DAL.Close();
            return Convert.ToInt32(param[14].Value);
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
            //Statcdif.ProdCompTable.DefaultView.RowFilter = "[FnSQL]  = " + TreeView1.SelectedNode.Name;
            int Insertreslt = insertTicket(
                Convert.ToBoolean(TickKind)                                         //Ticket Kind
                , Convert.ToInt32(TreeView1.SelectedNode.Name)  //Ticket Pcoduct & Cmplaint Code SQL
                , Convert.ToInt32(SrcCmbBx.SelectedValue)                     //Ticket Source
                , NameTxtBx.Text.ToString().Trim()                                      //Ticket Client Name
                , Phon1TxtBx.Text.ToString().Trim()                                       //Ticket Client Phone Number 1
                , Phon2TxtBx.Text.ToString().Replace(" ", "")                                       //Ticket Client Phone Number 2
                , AddTxtBx.Text.ToString().Trim()                                         //Ticket Client Address
                , IDTxtBx.Text.ToString().Trim()                                          //Ticket Clients National ID
                , DetailsTxtBx.Text.ToString().Trim()                                     //Ticket Details
                , CurrentUser.UsrID                                            //Ticket Creator ID
                , usrid                                                        //Ticket Follower ID (It must be Zero Amount To Assign Null Value to Database)
                , MailTxtBx.Text.ToString().Trim()                                        //Ticket Client Mail address
                , Statcdif._IP
                , mndtbl);                                                     //Ticket Mend Table send it as type table to Stored Procedure

            if (Insertreslt != 0)
            {
                SubmitBtn.Visible = false;
                if (TickKind == 0)
                {
                    ComRefLbl.Text = "طلب رقم : " + Convert.ToString(Insertreslt);
                }

                else
                {
                    ComRefLbl.Text = "شكوى رقم : " + Convert.ToString(Insertreslt);
                }
                TimrPhons.Stop();
                FlwMainData.Enabled = false;
                FlwTree.Enabled = false;
                FlwMend.Enabled = false;
                BtnDublicate.Visible = true;
            }
            else
            {
                fn.msg("لم ينجح الإتصال بقواعد البيانات", "تسجيل شكوى جديدة", MessageBoxButtons.OK);
            }
        }
        private void NewBtn_Click(object sender, EventArgs e)
        {
            NewTickSub();
        }
        private void BtnDublicate_Click(object sender, EventArgs e)
        {
            this.RadioButton4.Click -= new System.EventHandler(this.CompReqst_CheckedChanged);
            this.RadioButton5.Click -= new System.EventHandler(this.CompReqst_CheckedChanged);
            SubmitBtn.Visible = true;
            FlwTree.Enabled = true;
            FlwMend.Enabled = true;
            FlwMainData.Enabled = true;
            ComRefLbl.Text = "";
            BtnDublicate.Visible = false;
            this.RadioButton4.Click += new System.EventHandler(this.CompReqst_CheckedChanged);
            this.RadioButton5.Click += new System.EventHandler(this.CompReqst_CheckedChanged);
        }
        private void RadNID_Click(object sender, EventArgs e)
        {



        }
        private void Phon1TxtBx_TextChanged(object sender, EventArgs e)
        {
            if (!chckphonechange.Checked)
            {
                customerdata(Phon1TxtBx, "select top(1) TkClNm,TkClPh1,TkClNtID,TkClAdr,TkMail from Tickets where TkClPh ='");
            }
        }
        private void IDTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (!chckIDChange.Checked)
            {
                customerdata(IDTxtBx, "select top(1) TkClNm,TkClPh,TkClPh1,TkClAdr,TkMail from Tickets where TkClNtID ='");
            }
        }
        private void customerdata(MaskedTextBox mskdTextBox, string SlctString)
        {
            this.Phon1TxtBx.TextChanged -= new System.EventHandler(this.Phon1TxtBx_TextChanged);
            this.IDTxtBx.TextChanged -= new System.EventHandler(this.IDTxtBx_TextChanged);
            string tmp = "";
            bolDublicted = false;
            if (mskdTextBox.Text.Trim().Length == mskdTextBox.Mask.Length)
            {
                tmp = lblhelp.Text;
                Timer1.Stop();
                this.Enabled = false;
                lblhelp.Text = "جاري البحث عن بيانات العميل ....";
                StringBuilder selectString = new StringBuilder();
                customerTable.Rows.Clear();
                selectString.Append(SlctString + mskdTextBox.Text.ToString());
                if (mskdTextBox == Phon1TxtBx) { selectString.Append("' or  TkClPh1 ='" + mskdTextBox.Text.ToString()); }
                selectString.Append("'  order by TkSQL desc");

                customerTable = fn.returntbl(selectString.ToString());

                if (customerTable.Rows.Count > 0)
                {
                    if (mskdTextBox != Phon1TxtBx)
                    {
                        Phon1TxtBx.Text = customerTable.Rows[0]["TkClPh"].ToString();
                    }
                    if (mskdTextBox != IDTxtBx)
                    {
                        bool bol = true;
                        for (int i = 0; i < customerTable.Rows[0]["TkClNtID"].ToString().Length; i++)
                        {
                            try
                            {
                                int hh = Convert.ToInt32(customerTable.Rows[0]["TkClNtID"].ToString().Substring(i, 1));
                            }
                            catch (Exception)
                            {
                                bol = false;

                            }
                        }
                        if (bol == true)
                        {
                            RadNID.Checked = true;
                        }
                        else
                        {
                            RadPss.Checked = true;
                        }

                        IDTxtBx.Text = customerTable.Rows[0]["TkClNtID"].ToString();
                    }
                    NameTxtBx.Text = customerTable.Rows[0]["TkClNm"].ToString();
                    Phon2TxtBx.Text = customerTable.Rows[0]["TkClPh1"].ToString();
                    AddTxtBx.Text = customerTable.Rows[0]["TkClAdr"].ToString();
                    MailTxtBx.Text = customerTable.Rows[0]["TkMail"].ToString();
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
            this.Phon1TxtBx.TextChanged += new System.EventHandler(this.Phon1TxtBx_TextChanged);
            this.IDTxtBx.TextChanged += new System.EventHandler(this.IDTxtBx_TextChanged);
            this.Enabled = true;
            lblhelp.Text = tmp;
            Timer1.Start();
        }
        private void clearcustomerdata(MaskedTextBox mskdTextBox)
        {
            if (mskdTextBox != Phon1TxtBx)
            {
                if (!chckphonechange.Checked) { Phon1TxtBx.Text = ""; }
            }
            if (mskdTextBox != IDTxtBx)
            {
                if (!chckIDChange.Checked) { IDTxtBx.Text = ""; };
            }
            NameTxtBx.Text = "";
            Phon2TxtBx.Text = "";
            AddTxtBx.Text = "";
            MailTxtBx.Text = "";
            customerTable.Rows.Clear();
        }
        private void RadPss_CheckedChanged(object sender, EventArgs e)
        {
            IDTxtBx.Text = "";
            if (RadPss.Checked == true)
            {
                IDTxtBx.Tag = "English-TextNumber";
                IDTxtBx.Mask = "AAAAAAAAAAAAA";
                RadNID.Checked = false;
                RadPss.Checked = true;
                Label11.Text = "رقم جواز السفر : ";
                IDTxtBx.AccessibleName = "رقم جواز السفر";
                chckIDChange.Text = "تغيير رقم جواز السفر";
                richTextBox1.Text = richTextBox1.Text.Replace("الرقم القومي", "رقم جواز السفر");
            }
        }
        private void RadNID_CheckedChanged(object sender, EventArgs e)
        {
            IDTxtBx.Text = "";
            if (RadNID.Checked == true)
            {
                IDTxtBx.Tag = "English-Number";
                IDTxtBx.Mask = "00000000000000";
                RadNID.Checked = true;
                RadPss.Checked = false;
                Label11.Text = "الرقم القومي : ";
                IDTxtBx.AccessibleName = "الرقم القومي";
                chckIDChange.Text = "تغيير الرقم القومي";
                richTextBox1.Text = richTextBox1.Text.Replace("رقم جواز السفر", "الرقم القومي");
            }
        }
        private void MailTxtBx_Validating(object sender, CancelEventArgs e)
        {
            if (function.EmailIsValid(MailTxtBx.Text) == false && MailTxtBx.Text.Length > 0)
            {
                fn.msg("الإيميل الذي تم إدخاله غير صحيح", "فحص الإيميل", MessageBoxButtons.OK);
                MailTxtBx.Focus();
            }
        }
        private void TikNew_Load(object sender, EventArgs e)
        {
            frm.FormClosed -= new FormClosedEventHandler(frm_Closed);
            frm.FormClosed += new FormClosedEventHandler(frm_Closed);
        }
        private void DublicatedTik()
        {
            if (TreeView1.SelectedNode != null)
            {
                if (TreeView1.SelectedNode.Level == 2 && Phon1TxtBx.Text.Length == Phon1TxtBx.Mask.Length)
                {
                    if (bolDublicted == false)
                    {
                        DublicatedTbl = new DataTable();

                        bolDublicted = true;
                        choicetbl = fn.returntbl("select TkSQL, TkDtStart, TkClNm, Tikfolowusr + ' \\ ' + TikfolowusrTeam 'Folower' " +
                                "from All_Tickets where (TkClPh= '" + Phon1TxtBx.Text + "' OR TkClNtID = '" + IDTxtBx.Text + "') AND (TkFnPrdCd = " + TreeView1.SelectedNode.Name + ") AND TkClsStatus = 0");
                        if (choicetbl.Rows.Count > 0)
                        {
                            FlwMainData.BackColor = Color.FromArgb(128, 255, 128);
                            string L;
                            if (TickKind == 0) { L = "طلب"; } else { L = "شكوى"; }
                            label8.Text = "هناك " + L + " قيد المتابعة الآن من نفس النوع لدى " + choicetbl.Rows[0]["Folower"];
                            label8.BackColor = Color.Black;
                            label8.Margin = new Padding(label8.Margin.Left, label8.Margin.Top, (FlwSubMain.Width - label8.Width) / 2, label8.Margin.Bottom);
                        }
                        else
                        {
                            label8.Text = "";
                            label8.BackColor = Color.White;
                            FlwMainData.BackColor = Color.FromArgb(192, 255, 255);
                        }
                    }
                }
            }
        }
    }
}
