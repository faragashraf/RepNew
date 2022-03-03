namespace VOCAUltimate.PL
{
    partial class heldSearch
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
            this.BtnBckComp = new System.Windows.Forms.Button();
            this.BtnSerch = new System.Windows.Forms.Button();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.SerchTxt = new System.Windows.Forms.TextBox();
            this.FilterComb = new System.Windows.Forms.ComboBox();
            this.GridHeld = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSubmt = new System.Windows.Forms.Button();
            this.GridHeldUpdt = new System.Windows.Forms.DataGridView();
            this.Label60 = new System.Windows.Forms.Label();
            this.TxtUpdt = new System.Windows.Forms.TextBox();
            this.Btn2Bck = new System.Windows.Forms.Button();
            this.TxtOrgin = new System.Windows.Forms.TextBox();
            this.Label41 = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label34 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.TxtDoc = new System.Windows.Forms.TextBox();
            this.TxtReason = new System.Windows.Forms.TextBox();
            this.TxtWieght = new System.Windows.Forms.TextBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.Label43 = new System.Windows.Forms.Label();
            this.LblMsg = new System.Windows.Forms.Label();
            this.TxtDt = new System.Windows.Forms.TextBox();
            this.TxtNm = new System.Windows.Forms.TextBox();
            this.TxtPh = new System.Windows.Forms.TextBox();
            this.TxtAdd = new System.Windows.Forms.TextBox();
            this.Label51 = new System.Windows.Forms.Label();
            this.Label54 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.TxtTrck = new System.Windows.Forms.TextBox();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridHeld)).BeginInit();
            this.ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridHeldUpdt)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnBckComp
            // 
            this.BtnBckComp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBckComp.BackColor = System.Drawing.Color.Transparent;
            this.BtnBckComp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBckComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBckComp.Location = new System.Drawing.Point(1267, 6);
            this.BtnBckComp.Name = "BtnBckComp";
            this.BtnBckComp.Size = new System.Drawing.Size(63, 59);
            this.BtnBckComp.TabIndex = 2053;
            this.ToolTip1.SetToolTip(this.BtnBckComp, "العودة للشكاوى المرتبطة");
            this.BtnBckComp.UseVisualStyleBackColor = false;
            // 
            // BtnSerch
            // 
            this.BtnSerch.BackgroundImage = global::VOCAUltimate.Properties.Resources.Search11;
            this.BtnSerch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSerch.FlatAppearance.BorderSize = 0;
            this.BtnSerch.Location = new System.Drawing.Point(636, 3);
            this.BtnSerch.Name = "BtnSerch";
            this.BtnSerch.Size = new System.Drawing.Size(64, 64);
            this.BtnSerch.TabIndex = 2023;
            this.ToolTip1.SetToolTip(this.BtnSerch, "بحث");
            this.BtnSerch.UseVisualStyleBackColor = true;
            this.BtnSerch.Click += new System.EventHandler(this.BtnSerch_Click);
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.White;
            this.TabPage1.Controls.Add(this.BtnSerch);
            this.TabPage1.Controls.Add(this.SerchTxt);
            this.TabPage1.Controls.Add(this.FilterComb);
            this.TabPage1.Controls.Add(this.GridHeld);
            this.TabPage1.Location = new System.Drawing.Point(4, 34);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Size = new System.Drawing.Size(1342, 528);
            this.TabPage1.TabIndex = 1;
            this.TabPage1.Text = "بحث المحجوزات";
            // 
            // SerchTxt
            // 
            this.SerchTxt.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.SerchTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SerchTxt.Location = new System.Drawing.Point(723, 25);
            this.SerchTxt.Name = "SerchTxt";
            this.SerchTxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SerchTxt.Size = new System.Drawing.Size(187, 26);
            this.SerchTxt.TabIndex = 7;
            this.SerchTxt.Text = "برجاء ادخال كلمات البحث";
            this.SerchTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SerchTxt.Enter += new System.EventHandler(this.SerchTxt_Enter);
            this.SerchTxt.Leave += new System.EventHandler(this.SerchTxt_Leave);
            // 
            // FilterComb
            // 
            this.FilterComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComb.FormattingEnabled = true;
            this.FilterComb.Location = new System.Drawing.Point(916, 24);
            this.FilterComb.Name = "FilterComb";
            this.FilterComb.Size = new System.Drawing.Size(187, 27);
            this.FilterComb.TabIndex = 6;
            // 
            // GridHeld
            // 
            this.GridHeld.AllowUserToAddRows = false;
            this.GridHeld.AllowUserToDeleteRows = false;
            this.GridHeld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GridHeld.BackgroundColor = System.Drawing.Color.White;
            this.GridHeld.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridHeld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridHeld.ContextMenuStrip = this.ContextMenuStrip1;
            this.GridHeld.Location = new System.Drawing.Point(7, 72);
            this.GridHeld.MultiSelect = false;
            this.GridHeld.Name = "GridHeld";
            this.GridHeld.ReadOnly = true;
            this.GridHeld.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridHeld.Size = new System.Drawing.Size(1319, 440);
            this.GridHeld.TabIndex = 0;
            this.GridHeld.DoubleClick += new System.EventHandler(this.GridHeld_DoubleClick);
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopySelectedToolStripMenuItem});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ContextMenuStrip1.Size = new System.Drawing.Size(150, 26);
            // 
            // CopySelectedToolStripMenuItem
            // 
            this.CopySelectedToolStripMenuItem.Name = "CopySelectedToolStripMenuItem";
            this.CopySelectedToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.CopySelectedToolStripMenuItem.Text = "Copy Selected";
            // 
            // BtnSubmt
            // 
            this.BtnSubmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSubmt.BackgroundImage = global::VOCAUltimate.Properties.Resources.recgreen;
            this.BtnSubmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSubmt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnSubmt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnSubmt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnSubmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmt.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubmt.Location = new System.Drawing.Point(7, 470);
            this.BtnSubmt.Name = "BtnSubmt";
            this.BtnSubmt.Size = new System.Drawing.Size(92, 40);
            this.BtnSubmt.TabIndex = 2114;
            this.BtnSubmt.Text = "تسجيل";
            this.BtnSubmt.UseVisualStyleBackColor = true;
            this.BtnSubmt.Visible = false;
            // 
            // GridHeldUpdt
            // 
            this.GridHeldUpdt.AllowUserToAddRows = false;
            this.GridHeldUpdt.AllowUserToDeleteRows = false;
            this.GridHeldUpdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GridHeldUpdt.BackgroundColor = System.Drawing.Color.White;
            this.GridHeldUpdt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridHeldUpdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridHeldUpdt.Location = new System.Drawing.Point(8, 12);
            this.GridHeldUpdt.MultiSelect = false;
            this.GridHeldUpdt.Name = "GridHeldUpdt";
            this.GridHeldUpdt.ReadOnly = true;
            this.GridHeldUpdt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GridHeldUpdt.Size = new System.Drawing.Size(786, 419);
            this.GridHeldUpdt.TabIndex = 2113;
            // 
            // Label60
            // 
            this.Label60.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Label60.Location = new System.Drawing.Point(634, 404);
            this.Label60.Name = "Label60";
            this.Label60.Size = new System.Drawing.Size(100, 23);
            this.Label60.TabIndex = 2112;
            this.Label60.Text = "إضافة تحديث:";
            this.Label60.Visible = false;
            // 
            // TxtUpdt
            // 
            this.TxtUpdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtUpdt.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.TxtUpdt.Location = new System.Drawing.Point(106, 395);
            this.TxtUpdt.Multiline = true;
            this.TxtUpdt.Name = "TxtUpdt";
            this.TxtUpdt.Size = new System.Drawing.Size(522, 125);
            this.TxtUpdt.TabIndex = 2111;
            this.TxtUpdt.Visible = false;
            // 
            // Btn2Bck
            // 
            this.Btn2Bck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn2Bck.BackColor = System.Drawing.Color.Transparent;
            this.Btn2Bck.BackgroundImage = global::VOCAUltimate.Properties.Resources.Back1;
            this.Btn2Bck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn2Bck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn2Bck.Location = new System.Drawing.Point(1267, 6);
            this.Btn2Bck.Name = "Btn2Bck";
            this.Btn2Bck.Size = new System.Drawing.Size(63, 59);
            this.Btn2Bck.TabIndex = 2052;
            this.ToolTip1.SetToolTip(this.Btn2Bck, "العودة للشكاوى المرتبطة");
            this.Btn2Bck.UseVisualStyleBackColor = false;
            this.Btn2Bck.Click += new System.EventHandler(this.Btn2Bck_Click);
            // 
            // TxtOrgin
            // 
            this.TxtOrgin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOrgin.Location = new System.Drawing.Point(910, 224);
            this.TxtOrgin.Name = "TxtOrgin";
            this.TxtOrgin.ReadOnly = true;
            this.TxtOrgin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtOrgin.Size = new System.Drawing.Size(271, 26);
            this.TxtOrgin.TabIndex = 2107;
            this.TxtOrgin.TabStop = false;
            this.TxtOrgin.Tag = "Email Address";
            // 
            // Label41
            // 
            this.Label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label41.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label41.ForeColor = System.Drawing.Color.Blue;
            this.Label41.Location = new System.Drawing.Point(1187, 256);
            this.Label41.MaximumSize = new System.Drawing.Size(100, 50);
            this.Label41.MinimumSize = new System.Drawing.Size(100, 15);
            this.Label41.Name = "Label41";
            this.Label41.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label41.Size = new System.Drawing.Size(100, 20);
            this.Label41.TabIndex = 2105;
            this.Label41.Text = "وزن الشحنة :";
            this.Label41.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label37
            // 
            this.Label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label37.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label37.ForeColor = System.Drawing.Color.Blue;
            this.Label37.Location = new System.Drawing.Point(1183, 75);
            this.Label37.MaximumSize = new System.Drawing.Size(100, 50);
            this.Label37.MinimumSize = new System.Drawing.Size(100, 15);
            this.Label37.Name = "Label37";
            this.Label37.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label37.Size = new System.Drawing.Size(100, 20);
            this.Label37.TabIndex = 2104;
            this.Label37.Text = "تليفون العميل :";
            this.Label37.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label34
            // 
            this.Label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label34.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label34.ForeColor = System.Drawing.Color.Blue;
            this.Label34.Location = new System.Drawing.Point(1183, 44);
            this.Label34.MaximumSize = new System.Drawing.Size(100, 50);
            this.Label34.MinimumSize = new System.Drawing.Size(100, 15);
            this.Label34.Name = "Label34";
            this.Label34.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label34.Size = new System.Drawing.Size(100, 20);
            this.Label34.TabIndex = 2091;
            this.Label34.Text = "تاريخ الحجز :";
            this.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label36
            // 
            this.Label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label36.AutoSize = true;
            this.Label36.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label36.ForeColor = System.Drawing.Color.Blue;
            this.Label36.Location = new System.Drawing.Point(1183, 109);
            this.Label36.MaximumSize = new System.Drawing.Size(100, 50);
            this.Label36.MinimumSize = new System.Drawing.Size(100, 15);
            this.Label36.Name = "Label36";
            this.Label36.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label36.Size = new System.Drawing.Size(100, 17);
            this.Label36.TabIndex = 2101;
            this.Label36.Text = "المرسل إلية :";
            this.Label36.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label39
            // 
            this.Label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label39.AutoSize = true;
            this.Label39.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label39.ForeColor = System.Drawing.Color.Blue;
            this.Label39.Location = new System.Drawing.Point(1183, 147);
            this.Label39.MaximumSize = new System.Drawing.Size(100, 50);
            this.Label39.MinimumSize = new System.Drawing.Size(100, 15);
            this.Label39.Name = "Label39";
            this.Label39.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label39.Size = new System.Drawing.Size(100, 17);
            this.Label39.TabIndex = 2092;
            this.Label39.Text = "العنوان :";
            this.Label39.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TxtDoc
            // 
            this.TxtDoc.AcceptsReturn = true;
            this.TxtDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDoc.Location = new System.Drawing.Point(840, 289);
            this.TxtDoc.Multiline = true;
            this.TxtDoc.Name = "TxtDoc";
            this.TxtDoc.ReadOnly = true;
            this.TxtDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtDoc.Size = new System.Drawing.Size(341, 102);
            this.TxtDoc.TabIndex = 2099;
            this.TxtDoc.Tag = "نوع الخدمة";
            // 
            // TxtReason
            // 
            this.TxtReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtReason.Location = new System.Drawing.Point(840, 397);
            this.TxtReason.Multiline = true;
            this.TxtReason.Name = "TxtReason";
            this.TxtReason.ReadOnly = true;
            this.TxtReason.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtReason.Size = new System.Drawing.Size(341, 125);
            this.TxtReason.TabIndex = 2097;
            this.TxtReason.TabStop = false;
            this.TxtReason.Tag = "Details";
            // 
            // TxtWieght
            // 
            this.TxtWieght.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtWieght.Location = new System.Drawing.Point(910, 256);
            this.TxtWieght.Name = "TxtWieght";
            this.TxtWieght.ReadOnly = true;
            this.TxtWieght.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtWieght.Size = new System.Drawing.Size(271, 26);
            this.TxtWieght.TabIndex = 2087;
            this.TxtWieght.Tag = "تليفون العميل 2";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseBtn.BackgroundImage = global::VOCAUltimate.Properties.Resources._Exit1;
            this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.CloseBtn.Location = new System.Drawing.Point(1284, 568);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(54, 47);
            this.CloseBtn.TabIndex = 2060;
            this.ToolTip1.SetToolTip(this.CloseBtn, "خروج");
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // Label43
            // 
            this.Label43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label43.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label43.ForeColor = System.Drawing.Color.Blue;
            this.Label43.Location = new System.Drawing.Point(1187, 397);
            this.Label43.Name = "Label43";
            this.Label43.Size = new System.Drawing.Size(96, 34);
            this.Label43.TabIndex = 2098;
            this.Label43.Text = "المطلوب :";
            this.Label43.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblMsg
            // 
            this.LblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblMsg.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.LblMsg.Location = new System.Drawing.Point(100, 581);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblMsg.Size = new System.Drawing.Size(1108, 23);
            this.LblMsg.TabIndex = 2061;
            this.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtDt
            // 
            this.TxtDt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDt.Location = new System.Drawing.Point(910, 42);
            this.TxtDt.Name = "TxtDt";
            this.TxtDt.ReadOnly = true;
            this.TxtDt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtDt.Size = new System.Drawing.Size(271, 26);
            this.TxtDt.TabIndex = 2090;
            this.TxtDt.TabStop = false;
            this.TxtDt.Tag = "Date";
            // 
            // TxtNm
            // 
            this.TxtNm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNm.Location = new System.Drawing.Point(910, 105);
            this.TxtNm.Name = "TxtNm";
            this.TxtNm.ReadOnly = true;
            this.TxtNm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtNm.Size = new System.Drawing.Size(271, 26);
            this.TxtNm.TabIndex = 2086;
            this.TxtNm.TabStop = false;
            this.TxtNm.Tag = "اسم العميل";
            // 
            // TxtPh
            // 
            this.TxtPh.AccessibleDescription = "";
            this.TxtPh.AccessibleName = "";
            this.TxtPh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPh.Location = new System.Drawing.Point(910, 74);
            this.TxtPh.Name = "TxtPh";
            this.TxtPh.ReadOnly = true;
            this.TxtPh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPh.Size = new System.Drawing.Size(271, 26);
            this.TxtPh.TabIndex = 2085;
            this.TxtPh.Tag = "تليفون العميل 1";
            // 
            // TxtAdd
            // 
            this.TxtAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAdd.Location = new System.Drawing.Point(910, 137);
            this.TxtAdd.Multiline = true;
            this.TxtAdd.Name = "TxtAdd";
            this.TxtAdd.ReadOnly = true;
            this.TxtAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtAdd.Size = new System.Drawing.Size(271, 81);
            this.TxtAdd.TabIndex = 2088;
            this.TxtAdd.Tag = "Address";
            // 
            // Label51
            // 
            this.Label51.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label51.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label51.ForeColor = System.Drawing.Color.Blue;
            this.Label51.Location = new System.Drawing.Point(1187, 296);
            this.Label51.Name = "Label51";
            this.Label51.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label51.Size = new System.Drawing.Size(100, 20);
            this.Label51.TabIndex = 2093;
            this.Label51.Text = "محتويات الشحنة :";
            this.Label51.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label54
            // 
            this.Label54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label54.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label54.ForeColor = System.Drawing.Color.Blue;
            this.Label54.Location = new System.Drawing.Point(1187, 229);
            this.Label54.Name = "Label54";
            this.Label54.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label54.Size = new System.Drawing.Size(100, 20);
            this.Label54.TabIndex = 2102;
            this.Label54.Text = "بلد المنشأ :";
            this.Label54.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Blue;
            this.Label1.Location = new System.Drawing.Point(1183, 10);
            this.Label1.MaximumSize = new System.Drawing.Size(100, 50);
            this.Label1.MinimumSize = new System.Drawing.Size(100, 15);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label1.Size = new System.Drawing.Size(100, 20);
            this.Label1.TabIndex = 2110;
            this.Label1.Text = "رقم الشحنة :";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TabPage2
            // 
            this.TabPage2.BackColor = System.Drawing.Color.White;
            this.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TabPage2.Controls.Add(this.BtnSubmt);
            this.TabPage2.Controls.Add(this.GridHeldUpdt);
            this.TabPage2.Controls.Add(this.Label60);
            this.TabPage2.Controls.Add(this.TxtUpdt);
            this.TabPage2.Controls.Add(this.Btn2Bck);
            this.TabPage2.Controls.Add(this.TxtOrgin);
            this.TabPage2.Controls.Add(this.Label41);
            this.TabPage2.Controls.Add(this.Label37);
            this.TabPage2.Controls.Add(this.Label34);
            this.TabPage2.Controls.Add(this.Label36);
            this.TabPage2.Controls.Add(this.Label39);
            this.TabPage2.Controls.Add(this.TxtDoc);
            this.TabPage2.Controls.Add(this.Label43);
            this.TabPage2.Controls.Add(this.TxtReason);
            this.TabPage2.Controls.Add(this.TxtWieght);
            this.TabPage2.Controls.Add(this.TxtDt);
            this.TabPage2.Controls.Add(this.TxtNm);
            this.TabPage2.Controls.Add(this.TxtPh);
            this.TabPage2.Controls.Add(this.TxtAdd);
            this.TabPage2.Controls.Add(this.Label51);
            this.TabPage2.Controls.Add(this.Label54);
            this.TabPage2.Controls.Add(this.Label1);
            this.TabPage2.Controls.Add(this.TxtTrck);
            this.TabPage2.Location = new System.Drawing.Point(4, 34);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(1342, 528);
            this.TabPage2.TabIndex = 2;
            this.TabPage2.Text = "TabPage2";
            this.ToolTip1.SetToolTip(this.TabPage2, "تفاصيل الشكاوى أوالاستفسارات");
            // 
            // TxtTrck
            // 
            this.TxtTrck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTrck.Location = new System.Drawing.Point(910, 9);
            this.TxtTrck.Name = "TxtTrck";
            this.TxtTrck.ReadOnly = true;
            this.TxtTrck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTrck.Size = new System.Drawing.Size(271, 26);
            this.TxtTrck.TabIndex = 2109;
            this.TxtTrck.Tag = "تليفون العميل 2";
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.BtnBckComp);
            this.TabPage3.Location = new System.Drawing.Point(4, 34);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(1342, 528);
            this.TabPage3.TabIndex = 4;
            this.TabPage3.Text = "TabPage3";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // ToolTip1
            // 
            this.ToolTip1.IsBalloon = true;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabControl1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.TabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.RightToLeftLayout = true;
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.ShowToolTips = true;
            this.TabControl1.Size = new System.Drawing.Size(1350, 566);
            this.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.TabControl1.TabIndex = 2059;
            this.TabControl1.TabStop = false;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // heldSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 621);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.LblMsg);
            this.Controls.Add(this.TabControl1);
            this.MaximizeBox = false;
            this.Name = "heldSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بحث المحجوزات";
            this.Load += new System.EventHandler(this.HeldSearch_Load);
            this.SizeChanged += new System.EventHandler(this.HeldSearch_SizeChanged);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridHeld)).EndInit();
            this.ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridHeldUpdt)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button BtnBckComp;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.Button BtnSerch;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.TextBox SerchTxt;
        internal System.Windows.Forms.ComboBox FilterComb;
        internal System.Windows.Forms.DataGridView GridHeld;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem CopySelectedToolStripMenuItem;
        internal System.Windows.Forms.Button BtnSubmt;
        internal System.Windows.Forms.DataGridView GridHeldUpdt;
        internal System.Windows.Forms.Label Label60;
        internal System.Windows.Forms.TextBox TxtUpdt;
        internal System.Windows.Forms.Button Btn2Bck;
        internal System.Windows.Forms.TextBox TxtOrgin;
        internal System.Windows.Forms.Label Label41;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.Label Label34;
        internal System.Windows.Forms.Label Label36;
        internal System.Windows.Forms.Label Label39;
        internal System.Windows.Forms.TextBox TxtDoc;
        internal System.Windows.Forms.TextBox TxtReason;
        internal System.Windows.Forms.TextBox TxtWieght;
        internal System.Windows.Forms.Button CloseBtn;
        internal System.Windows.Forms.Label Label43;
        internal System.Windows.Forms.Label LblMsg;
        internal System.Windows.Forms.TextBox TxtDt;
        internal System.Windows.Forms.TextBox TxtNm;
        internal System.Windows.Forms.TextBox TxtPh;
        internal System.Windows.Forms.TextBox TxtAdd;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.Label Label54;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.TextBox TxtTrck;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.TabControl TabControl1;
    }
}