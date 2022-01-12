using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAC.Properties;

namespace VOCAC.PL
{
    public partial class TikNew : Form
    {
        frms forms = new frms();
        DataTable RelatedTable = new DataTable();
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
            int Complete_ = 0;
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
            if (NameTxtBx.Text.Replace(" ", "").Trim().Length > 0)
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
                    else if (Ctrl.GetType() == typeof(MaskedTextBox))
                    {
                        MaskedTextBox mskd = new MaskedTextBox();
                        mskd = (MaskedTextBox)Ctrl;
                        if (mskd.Mask.Replace(" ", "").Trim().Length > 0)
                        { Complete_ += 1; }
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
            }

            double gg = Complete_ / (4 + (FlwMend.Controls.Count) / 2);

            //if (Complete_ / (5 + (FlwMend.Controls.Count) / 2) < 0.7 
            //    SubmitBtn.BackgroundImage = My.Resources.SaveRed1
            //else if Complete_ / (5 + (FlwMend.Controls.Count) / 2) > 0.5 
            //    SubmitBtn.BackgroundImage = My.Resources.SaveGreen1
            //End if
            if (PrdKind == "مالية")
            {
                if (Complete_ == 5 + (FlwMend.Controls.Count) / 2)
                {
                    SubmitBtn.Enabled = true;
                    SubmitBtn.BackgroundImage = Resources.SaveGreen1;
                }
                else if (Complete_ / (5 + (FlwMend.Controls.Count) / 2) <= 0.5)
                {
                    SubmitBtn.BackgroundImage = Resources.SaveRed;
                    SubmitBtn.Enabled = false;
                }
                else if (Complete_ / (5 + (FlwMend.Controls.Count) / 2) > 0.5)
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
        }
        private void CompReqst_CheckedChanged(object sender, EventArgs e)
        {
            this.TreeView1.AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
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
            this.TreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
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
                Statcdif.MendFildsTable.DefaultView.RowFilter = "[MendCdFn]" + " = " + TreeView1.SelectedNode.Name;
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
                        FlwMend.Controls.Add(Ctrl);
                        Ctrl.ReadOnly = true;
                        //AddHandler Ctrl.KeyDown, AddressOf TextBox_KeyDown
                    }

                    else if (Statcdif.MendFildsTable.DefaultView[i]["CDMendType"].ToString() == "MaskedTextBox")
                    {
                        MaskedTextBox Ctrl = new MaskedTextBox();
                        Ctrl.TextAlign = HorizontalAlignment.Center;
                        Ctrl.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                        Ctrl.Size = new Size(150, 25);
                        Ctrl.Mask = Statcdif.MendFildsTable.DefaultView[i]["CDMendMskd"].ToString();
                        Ctrl.Name = Statcdif.MendFildsTable.DefaultView[i]["CDMendNm"].ToString();
                        Ctrl.Tag = Statcdif.MendFildsTable.DefaultView[i]["CDMendAccessNm"].ToString();
                        //AddHandler Ctrl.Enter, AddressOf Masked_Enter
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
                //    FrmAllSub(Me)
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
                Timer1.Stop();
            }
            if (TreeView1.SelectedNode.FullPath.ToString().Split('\\')[0] != PrdKind)
            {
                PrdKind = "";
            }
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
    }
}
