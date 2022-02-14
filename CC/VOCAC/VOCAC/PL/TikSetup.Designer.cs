namespace VOCAC.PL
{
    partial class TikSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TikSetup));
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.ImgLst = new System.Windows.Forms.ImageList(this.components);
            this.MyGroupBox3 = new System.Windows.Forms.GroupBox();
            this.RadioButton4 = new System.Windows.Forms.RadioButton();
            this.RadioButton5 = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.timertrigger = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtmask = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowMend = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfldnm = new System.Windows.Forms.TextBox();
            this.chckprodindent = new System.Windows.Forms.CheckBox();
            this.flowfieldtyp = new System.Windows.Forms.FlowLayoutPanel();
            this.TextBox = new System.Windows.Forms.RadioButton();
            this.TextBoxC = new System.Windows.Forms.RadioButton();
            this.MaskedTextBox = new System.Windows.Forms.RadioButton();
            this.DateTimePicker = new System.Windows.Forms.RadioButton();
            this.flowLangues = new System.Windows.Forms.FlowLayoutPanel();
            this.Arabic = new System.Windows.Forms.RadioButton();
            this.English = new System.Windows.Forms.RadioButton();
            this.flowdatatype = new System.Windows.Forms.FlowLayoutPanel();
            this.TextNumber = new System.Windows.Forms.RadioButton();
            this.Number = new System.Windows.Forms.RadioButton();
            this.Amount = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtlength = new System.Windows.Forms.TextBox();
            this.lblcaution = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btncancel = new System.Windows.Forms.Button();
            this.labfldNm = new System.Windows.Forms.Label();
            this.btnaddnew = new System.Windows.Forms.Button();
            this.FlwMend = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CdfnID = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Comp = new System.Windows.Forms.TextBox();
            this.Prdct = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtprodIdent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radactive = new System.Windows.Forms.RadioButton();
            this.raddisactive = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MyGroupBox3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowMend.SuspendLayout();
            this.flowfieldtyp.SuspendLayout();
            this.flowLangues.SuspendLayout();
            this.flowdatatype.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView1
            // 
            this.TreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.TreeView1.ImageKey = "Add.ico";
            this.TreeView1.Location = new System.Drawing.Point(17, 51);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TreeView1.RightToLeftLayout = true;
            this.TreeView1.ShowNodeToolTips = true;
            this.TreeView1.ShowPlusMinus = false;
            this.TreeView1.Size = new System.Drawing.Size(483, 628);
            this.TreeView1.TabIndex = 2023;
            this.TreeView1.TabStop = false;
            this.TreeView1.Tag = "نوع الخدمة & نوع الشكوى";
            this.TreeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeSelect);
            this.TreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // ImgLst
            // 
            this.ImgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgLst.ImageStream")));
            this.ImgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgLst.Images.SetKeyName(0, "Arrow - Right (5).ico");
            this.ImgLst.Images.SetKeyName(1, "Arrow - Right (4).ico");
            this.ImgLst.Images.SetKeyName(2, "arrow-right-3.png");
            this.ImgLst.Images.SetKeyName(3, "arrow-right-double-3.png");
            // 
            // MyGroupBox3
            // 
            this.MyGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyGroupBox3.Controls.Add(this.RadioButton4);
            this.MyGroupBox3.Controls.Add(this.RadioButton5);
            this.MyGroupBox3.Location = new System.Drawing.Point(317, 3);
            this.MyGroupBox3.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.MyGroupBox3.Name = "MyGroupBox3";
            this.MyGroupBox3.Size = new System.Drawing.Size(176, 42);
            this.MyGroupBox3.TabIndex = 2024;
            this.MyGroupBox3.TabStop = false;
            // 
            // RadioButton4
            // 
            this.RadioButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButton4.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.RadioButton4.Cursor = System.Windows.Forms.Cursors.Default;
            this.RadioButton4.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.RadioButton4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RadioButton4.Location = new System.Drawing.Point(89, 12);
            this.RadioButton4.Name = "RadioButton4";
            this.RadioButton4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RadioButton4.Size = new System.Drawing.Size(75, 22);
            this.RadioButton4.TabIndex = 500;
            this.RadioButton4.Text = "طلب";
            this.RadioButton4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButton4.UseVisualStyleBackColor = true;
            this.RadioButton4.Click += new System.EventHandler(this.RadClick_CheckedChanged);
            // 
            // RadioButton5
            // 
            this.RadioButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButton5.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.RadioButton5.Cursor = System.Windows.Forms.Cursors.Default;
            this.RadioButton5.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.RadioButton5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RadioButton5.Location = new System.Drawing.Point(15, 12);
            this.RadioButton5.Name = "RadioButton5";
            this.RadioButton5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RadioButton5.Size = new System.Drawing.Size(65, 22);
            this.RadioButton5.TabIndex = 501;
            this.RadioButton5.Text = "شكوى";
            this.RadioButton5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButton5.UseVisualStyleBackColor = true;
            this.RadioButton5.Click += new System.EventHandler(this.RadClick_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.MyGroupBox3);
            this.flowLayoutPanel2.Controls.Add(this.TreeView1);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(503, 688);
            this.flowLayoutPanel2.TabIndex = 2046;
            // 
            // timertrigger
            // 
            this.timertrigger.Tick += new System.EventHandler(this.Timertrigger_Tick);
            // 
            // txtmask
            // 
            this.txtmask.Enabled = false;
            this.txtmask.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.txtmask.Location = new System.Drawing.Point(413, 144);
            this.txtmask.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtmask.Name = "txtmask";
            this.txtmask.Size = new System.Drawing.Size(165, 29);
            this.txtmask.TabIndex = 2055;
            this.toolTip1.SetToolTip(this.txtmask, "الحقل يقبل فقط \"حرف L ورقم 0\"");
            this.txtmask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtmask_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1088, 447);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(215, 290);
            this.dataGridView1.TabIndex = 2047;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_CellMouseDoubleClick);
            // 
            // flowMend
            // 
            this.flowMend.AutoScroll = true;
            this.flowMend.Controls.Add(this.label1);
            this.flowMend.Controls.Add(this.txtfldnm);
            this.flowMend.Controls.Add(this.chckprodindent);
            this.flowMend.Controls.Add(this.flowfieldtyp);
            this.flowMend.Controls.Add(this.flowLangues);
            this.flowMend.Controls.Add(this.flowdatatype);
            this.flowMend.Controls.Add(this.label6);
            this.flowMend.Controls.Add(this.txtmask);
            this.flowMend.Controls.Add(this.label7);
            this.flowMend.Controls.Add(this.txtlength);
            this.flowMend.Controls.Add(this.panel4);
            this.flowMend.Controls.Add(this.panel3);
            this.flowMend.Controls.Add(this.lblcaution);
            this.flowMend.Controls.Add(this.labfldNm);
            this.flowMend.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowMend.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.flowMend.Location = new System.Drawing.Point(28, 85);
            this.flowMend.MinimumSize = new System.Drawing.Size(150, 100);
            this.flowMend.Name = "flowMend";
            this.flowMend.Size = new System.Drawing.Size(652, 356);
            this.flowMend.TabIndex = 2049;
            this.flowMend.TabStop = true;
            this.flowMend.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(567, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "اسم الحقل : ";
            // 
            // txtfldnm
            // 
            this.txtfldnm.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.txtfldnm.Location = new System.Drawing.Point(369, 6);
            this.txtfldnm.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtfldnm.Name = "txtfldnm";
            this.txtfldnm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfldnm.Size = new System.Drawing.Size(192, 29);
            this.txtfldnm.TabIndex = 3;
            this.txtfldnm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtfldnm_KeyPress);
            // 
            // chckprodindent
            // 
            this.chckprodindent.AutoSize = true;
            this.flowMend.SetFlowBreak(this.chckprodindent, true);
            this.chckprodindent.Location = new System.Drawing.Point(167, 3);
            this.chckprodindent.Name = "chckprodindent";
            this.chckprodindent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chckprodindent.Size = new System.Drawing.Size(196, 25);
            this.chckprodindent.TabIndex = 2051;
            this.chckprodindent.Text = "مطابقة الرقم التعريفي للمنتج";
            this.chckprodindent.UseVisualStyleBackColor = true;
            // 
            // flowfieldtyp
            // 
            this.flowfieldtyp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowfieldtyp.Controls.Add(this.TextBox);
            this.flowfieldtyp.Controls.Add(this.TextBoxC);
            this.flowfieldtyp.Controls.Add(this.MaskedTextBox);
            this.flowfieldtyp.Controls.Add(this.DateTimePicker);
            this.flowMend.SetFlowBreak(this.flowfieldtyp, true);
            this.flowfieldtyp.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowfieldtyp.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.flowfieldtyp.Location = new System.Drawing.Point(16, 38);
            this.flowfieldtyp.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.flowfieldtyp.Name = "flowfieldtyp";
            this.flowfieldtyp.Size = new System.Drawing.Size(631, 33);
            this.flowfieldtyp.TabIndex = 5;
            // 
            // TextBox
            // 
            this.TextBox.AutoSize = true;
            this.TextBox.Location = new System.Drawing.Point(529, 3);
            this.TextBox.Name = "TextBox";
            this.TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TextBox.Size = new System.Drawing.Size(97, 25);
            this.TextBox.TabIndex = 2;
            this.TextBox.Text = "Text Box";
            this.TextBox.UseVisualStyleBackColor = true;
            this.TextBox.CheckedChanged += new System.EventHandler(this.TextBox_CheckedChanged);
            // 
            // TextBoxC
            // 
            this.TextBoxC.AutoSize = true;
            this.TextBoxC.Location = new System.Drawing.Point(363, 3);
            this.TextBoxC.Name = "TextBoxC";
            this.TextBoxC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TextBoxC.Size = new System.Drawing.Size(160, 25);
            this.TextBoxC.TabIndex = 0;
            this.TextBoxC.Text = "Text Box Choose";
            this.TextBoxC.UseVisualStyleBackColor = true;
            this.TextBoxC.CheckedChanged += new System.EventHandler(this.TextBoxC_CheckedChanged);
            // 
            // MaskedTextBox
            // 
            this.MaskedTextBox.AutoSize = true;
            this.MaskedTextBox.Location = new System.Drawing.Point(201, 3);
            this.MaskedTextBox.Name = "MaskedTextBox";
            this.MaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MaskedTextBox.Size = new System.Drawing.Size(156, 25);
            this.MaskedTextBox.TabIndex = 1;
            this.MaskedTextBox.Text = "Masked TextBox";
            this.MaskedTextBox.UseVisualStyleBackColor = true;
            this.MaskedTextBox.CheckedChanged += new System.EventHandler(this.MaskedTextBox_CheckedChanged);
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.AutoSize = true;
            this.DateTimePicker.Location = new System.Drawing.Point(39, 3);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DateTimePicker.Size = new System.Drawing.Size(156, 25);
            this.DateTimePicker.TabIndex = 3;
            this.DateTimePicker.Text = "Date Time Picker";
            this.DateTimePicker.UseVisualStyleBackColor = true;
            this.DateTimePicker.CheckedChanged += new System.EventHandler(this.DateTimePicker_CheckedChanged);
            // 
            // flowLangues
            // 
            this.flowLangues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLangues.Controls.Add(this.Arabic);
            this.flowLangues.Controls.Add(this.English);
            this.flowMend.SetFlowBreak(this.flowLangues, true);
            this.flowLangues.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLangues.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.flowLangues.Location = new System.Drawing.Point(189, 71);
            this.flowLangues.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.flowLangues.Name = "flowLangues";
            this.flowLangues.Size = new System.Drawing.Size(458, 33);
            this.flowLangues.TabIndex = 0;
            // 
            // Arabic
            // 
            this.Arabic.AutoSize = true;
            this.Arabic.Location = new System.Drawing.Point(296, 3);
            this.Arabic.Name = "Arabic";
            this.Arabic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Arabic.Size = new System.Drawing.Size(157, 25);
            this.Arabic.TabIndex = 0;
            this.Arabic.Text = "Arabic Keyboard";
            this.Arabic.UseVisualStyleBackColor = true;
            // 
            // English
            // 
            this.English.AutoSize = true;
            this.English.Location = new System.Drawing.Point(129, 3);
            this.English.Name = "English";
            this.English.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.English.Size = new System.Drawing.Size(161, 25);
            this.English.TabIndex = 1;
            this.English.Text = "English Keyboard";
            this.English.UseVisualStyleBackColor = true;
            // 
            // flowdatatype
            // 
            this.flowdatatype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowdatatype.Controls.Add(this.TextNumber);
            this.flowdatatype.Controls.Add(this.Number);
            this.flowdatatype.Controls.Add(this.Amount);
            this.flowMend.SetFlowBreak(this.flowdatatype, true);
            this.flowdatatype.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowdatatype.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.flowdatatype.Location = new System.Drawing.Point(189, 104);
            this.flowdatatype.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.flowdatatype.Name = "flowdatatype";
            this.flowdatatype.Size = new System.Drawing.Size(458, 33);
            this.flowdatatype.TabIndex = 2;
            // 
            // TextNumber
            // 
            this.TextNumber.AutoSize = true;
            this.TextNumber.Location = new System.Drawing.Point(317, 3);
            this.TextNumber.Name = "TextNumber";
            this.TextNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TextNumber.Size = new System.Drawing.Size(136, 25);
            this.TextNumber.TabIndex = 2;
            this.TextNumber.Text = "Text / Number";
            this.TextNumber.UseVisualStyleBackColor = true;
            // 
            // Number
            // 
            this.Number.AutoSize = true;
            this.Number.Location = new System.Drawing.Point(223, 3);
            this.Number.Name = "Number";
            this.Number.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Number.Size = new System.Drawing.Size(88, 25);
            this.Number.TabIndex = 0;
            this.Number.Text = "Number";
            this.Number.UseVisualStyleBackColor = true;
            // 
            // Amount
            // 
            this.Amount.AutoSize = true;
            this.Amount.Location = new System.Drawing.Point(52, 3);
            this.Amount.Name = "Amount";
            this.Amount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Amount.Size = new System.Drawing.Size(165, 25);
            this.Amount.TabIndex = 1;
            this.Amount.Text = "Amount (Decimal)";
            this.Amount.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(65, 21);
            this.label6.TabIndex = 2057;
            this.label6.Text = "Mask : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(108, 21);
            this.label7.TabIndex = 2058;
            this.label7.Text = "Text Length :";
            // 
            // txtlength
            // 
            this.txtlength.Enabled = false;
            this.flowMend.SetFlowBreak(this.txtlength, true);
            this.txtlength.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.txtlength.Location = new System.Drawing.Point(187, 144);
            this.txtlength.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtlength.Name = "txtlength";
            this.txtlength.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtlength.Size = new System.Drawing.Size(106, 29);
            this.txtlength.TabIndex = 2056;
            this.txtlength.Text = "0";
            this.txtlength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtlength_KeyPress);
            // 
            // lblcaution
            // 
            this.lblcaution.AutoSize = true;
            this.flowMend.SetFlowBreak(this.lblcaution, true);
            this.lblcaution.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.lblcaution.ForeColor = System.Drawing.Color.Red;
            this.lblcaution.Location = new System.Drawing.Point(649, 249);
            this.lblcaution.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.lblcaution.Name = "lblcaution";
            this.lblcaution.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblcaution.Size = new System.Drawing.Size(0, 20);
            this.lblcaution.TabIndex = 2050;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.btnsubmit);
            this.panel4.Location = new System.Drawing.Point(123, 179);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 3, 420, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(109, 57);
            this.panel4.TabIndex = 2059;
            // 
            // btnsubmit
            // 
            this.btnsubmit.BackgroundImage = global::VOCAC.Properties.Resources.recgreen;
            this.btnsubmit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubmit.Location = new System.Drawing.Point(6, 8);
            this.btnsubmit.Margin = new System.Windows.Forms.Padding(3, 3, 420, 3);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(97, 41);
            this.btnsubmit.TabIndex = 2052;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.Btnsubmit_Click);
            this.btnsubmit.MouseEnter += new System.EventHandler(this.Btnsubmit_MouseEnter);
            this.btnsubmit.MouseLeave += new System.EventHandler(this.Btnsubmit_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btncancel);
            this.flowMend.SetFlowBreak(this.panel3, true);
            this.panel3.Location = new System.Drawing.Point(8, 179);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(109, 57);
            this.panel3.TabIndex = 2060;
            // 
            // btncancel
            // 
            this.btncancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncancel.BackgroundImage = global::VOCAC.Properties.Resources.recred;
            this.btncancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(6, 8);
            this.btncancel.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(97, 41);
            this.btncancel.TabIndex = 2054;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.Btncancel_Click);
            this.btncancel.MouseEnter += new System.EventHandler(this.Btncancel_MouseEnter);
            this.btncancel.MouseLeave += new System.EventHandler(this.Btncancel_MouseLeave);
            // 
            // labfldNm
            // 
            this.labfldNm.AutoSize = true;
            this.flowMend.SetFlowBreak(this.labfldNm, true);
            this.labfldNm.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.labfldNm.ForeColor = System.Drawing.Color.Red;
            this.labfldNm.Location = new System.Drawing.Point(649, 282);
            this.labfldNm.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.labfldNm.Name = "labfldNm";
            this.labfldNm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labfldNm.Size = new System.Drawing.Size(0, 20);
            this.labfldNm.TabIndex = 2053;
            // 
            // btnaddnew
            // 
            this.btnaddnew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnaddnew.BackgroundImage = global::VOCAC.Properties.Resources.recorange;
            this.btnaddnew.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddnew.Location = new System.Drawing.Point(162, 148);
            this.btnaddnew.Name = "btnaddnew";
            this.btnaddnew.Size = new System.Drawing.Size(160, 39);
            this.btnaddnew.TabIndex = 2046;
            this.btnaddnew.Text = "إضافة حقل إلزامي جديد";
            this.btnaddnew.UseVisualStyleBackColor = true;
            this.btnaddnew.Click += new System.EventHandler(this.Btnaddnew_Click);
            this.btnaddnew.MouseEnter += new System.EventHandler(this.Btnaddnew_MouseEnter);
            this.btnaddnew.MouseLeave += new System.EventHandler(this.Btnaddnew_MouseLeave);
            // 
            // FlwMend
            // 
            this.FlwMend.AutoScroll = true;
            this.FlwMend.BackColor = System.Drawing.Color.Transparent;
            this.FlwMend.Location = new System.Drawing.Point(1031, 85);
            this.FlwMend.Name = "FlwMend";
            this.FlwMend.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlwMend.Size = new System.Drawing.Size(272, 356);
            this.FlwMend.TabIndex = 2025;
            this.FlwMend.TabStop = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CdfnID);
            this.panel1.Controls.Add(this.Label4);
            this.panel1.Controls.Add(this.Comp);
            this.panel1.Controls.Add(this.Prdct);
            this.panel1.Controls.Add(this.Label5);
            this.flowLayoutPanel1.SetFlowBreak(this.panel1, true);
            this.panel1.Location = new System.Drawing.Point(49, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1254, 76);
            this.panel1.TabIndex = 2048;
            // 
            // CdfnID
            // 
            this.CdfnID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CdfnID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CdfnID.ForeColor = System.Drawing.Color.Blue;
            this.CdfnID.Location = new System.Drawing.Point(1183, 26);
            this.CdfnID.Name = "CdfnID";
            this.CdfnID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CdfnID.Size = new System.Drawing.Size(57, 25);
            this.CdfnID.TabIndex = 2045;
            this.CdfnID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(1094, 26);
            this.Label4.Margin = new System.Windows.Forms.Padding(3);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label4.Size = new System.Drawing.Size(95, 25);
            this.Label4.TabIndex = 2040;
            this.Label4.Text = "نوع الخدمة :";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Comp
            // 
            this.Comp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Comp.Location = new System.Drawing.Point(356, 26);
            this.Comp.Name = "Comp";
            this.Comp.ReadOnly = true;
            this.Comp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Comp.Size = new System.Drawing.Size(376, 29);
            this.Comp.TabIndex = 2043;
            this.Comp.TabStop = false;
            this.Comp.Tag = "نوع الشكوى";
            // 
            // Prdct
            // 
            this.Prdct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Prdct.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Prdct.Location = new System.Drawing.Point(846, 26);
            this.Prdct.Name = "Prdct";
            this.Prdct.ReadOnly = true;
            this.Prdct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Prdct.Size = new System.Drawing.Size(242, 29);
            this.Prdct.TabIndex = 2042;
            this.Prdct.TabStop = false;
            this.Prdct.Tag = "نوع الخدمة";
            // 
            // Label5
            // 
            this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(738, 26);
            this.Label5.Margin = new System.Windows.Forms.Padding(3);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label5.Size = new System.Drawing.Size(102, 25);
            this.Label5.TabIndex = 2041;
            this.Label5.Text = "نوع الشكوى :";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.FlwMend);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.flowMend);
            this.flowLayoutPanel1.Controls.Add(this.dataGridView1);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(522, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1306, 747);
            this.flowLayoutPanel1.TabIndex = 2045;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtprodIdent);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnaddnew);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(686, 85);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(339, 202);
            this.panel2.TabIndex = 2057;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.label3.Location = new System.Drawing.Point(200, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 19);
            this.label3.TabIndex = 2059;
            this.label3.Text = "الرقم التعريفي للمنتج : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtprodIdent
            // 
            this.txtprodIdent.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.txtprodIdent.Location = new System.Drawing.Point(5, 54);
            this.txtprodIdent.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtprodIdent.Name = "txtprodIdent";
            this.txtprodIdent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtprodIdent.Size = new System.Drawing.Size(194, 29);
            this.txtprodIdent.TabIndex = 2058;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.label2.Location = new System.Drawing.Point(200, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 19);
            this.label2.TabIndex = 2057;
            this.label2.Text = "المدير المسئول : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(194, 29);
            this.comboBox1.TabIndex = 2056;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::VOCAC.Properties.Resources.recgreen;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 95);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 420, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 29);
            this.button1.TabIndex = 2052;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.raddisactive);
            this.panel5.Controls.Add(this.radactive);
            this.panel5.Location = new System.Drawing.Point(800, 447);
            this.panel5.Name = "panel5";
            this.panel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel5.Size = new System.Drawing.Size(282, 35);
            this.panel5.TabIndex = 2060;
            this.panel5.Visible = false;
            // 
            // radactive
            // 
            this.radactive.AutoSize = true;
            this.radactive.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.radactive.Location = new System.Drawing.Point(175, 3);
            this.radactive.Name = "radactive";
            this.radactive.Size = new System.Drawing.Size(93, 23);
            this.radactive.TabIndex = 0;
            this.radactive.TabStop = true;
            this.radactive.Text = "الشكوى تعمل";
            this.radactive.UseVisualStyleBackColor = true;
            // 
            // raddisactive
            // 
            this.raddisactive.AutoSize = true;
            this.raddisactive.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.raddisactive.Location = new System.Drawing.Point(48, 3);
            this.raddisactive.Name = "raddisactive";
            this.raddisactive.Size = new System.Drawing.Size(106, 23);
            this.raddisactive.TabIndex = 1;
            this.raddisactive.TabStop = true;
            this.raddisactive.Text = "الشكوى لا تعمل";
            this.raddisactive.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.label8.Location = new System.Drawing.Point(561, 447);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(233, 19);
            this.label8.TabIndex = 2062;
            this.label8.Text = "رسالة المساعدة لتسجيل الشكوى : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.textBox1.Location = new System.Drawing.Point(44, 450);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(511, 166);
            this.textBox1.TabIndex = 2061;
            this.textBox1.Visible = false;
            // 
            // TikSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1855, 782);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TikSetup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اعدادات الشكاوى والطلبات";
            this.Load += new System.EventHandler(this.TikSetup_Load);
            this.MyGroupBox3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowMend.ResumeLayout(false);
            this.flowMend.PerformLayout();
            this.flowfieldtyp.ResumeLayout(false);
            this.flowfieldtyp.PerformLayout();
            this.flowLangues.ResumeLayout(false);
            this.flowLangues.PerformLayout();
            this.flowdatatype.ResumeLayout(false);
            this.flowdatatype.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.TreeView TreeView1;
        internal System.Windows.Forms.ImageList ImgLst;
        internal System.Windows.Forms.GroupBox MyGroupBox3;
        internal System.Windows.Forms.RadioButton RadioButton4;
        internal System.Windows.Forms.RadioButton RadioButton5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Timer timertrigger;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.FlowLayoutPanel flowMend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfldnm;
        private System.Windows.Forms.CheckBox chckprodindent;
        private System.Windows.Forms.FlowLayoutPanel flowfieldtyp;
        private System.Windows.Forms.RadioButton TextBox;
        private System.Windows.Forms.RadioButton TextBoxC;
        private System.Windows.Forms.RadioButton MaskedTextBox;
        private System.Windows.Forms.RadioButton DateTimePicker;
        private System.Windows.Forms.FlowLayoutPanel flowLangues;
        private System.Windows.Forms.RadioButton Arabic;
        private System.Windows.Forms.RadioButton English;
        private System.Windows.Forms.FlowLayoutPanel flowdatatype;
        private System.Windows.Forms.RadioButton TextNumber;
        private System.Windows.Forms.RadioButton Number;
        private System.Windows.Forms.RadioButton Amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmask;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtlength;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label lblcaution;
        private System.Windows.Forms.Label labfldNm;
        private System.Windows.Forms.Button btnaddnew;
        internal System.Windows.Forms.FlowLayoutPanel FlwMend;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label CdfnID;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox Comp;
        internal System.Windows.Forms.TextBox Prdct;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtprodIdent;
        internal System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton raddisactive;
        private System.Windows.Forms.RadioButton radactive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
    }
}