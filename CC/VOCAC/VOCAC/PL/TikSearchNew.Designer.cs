namespace VOCAC.PL
{
    partial class TikSearchNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.BtnCncl = new System.Windows.Forms.Button();
            this.GridTicket = new System.Windows.Forms.DataGridView();
            this.SerchTxt = new System.Windows.Forms.TextBox();
            this.BtnSerch = new System.Windows.Forms.Button();
            this.FilterComb = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.Rd_strtwith = new System.Windows.Forms.RadioButton();
            this.Rd_contain = new System.Windows.Forms.RadioButton();
            this.Rd_endwith = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Rd_Equal = new System.Windows.Forms.RadioButton();
            this.Rd_Like = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.StatBrPnlEn = new System.Windows.Forms.StatusBarPanel();
            this.StatBrPnlAr = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.GridTicket)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatBrPnlEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatBrPnlAr)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.BackgroundImage = global::VOCAC.Properties.Resources._Exit1;
            this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.CloseBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CloseBtn.Location = new System.Drawing.Point(1482, 690);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(50, 43);
            this.CloseBtn.TabIndex = 2175;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // BtnCncl
            // 
            this.BtnCncl.BackgroundImage = global::VOCAC.Properties.Resources.recblue;
            this.BtnCncl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCncl.FlatAppearance.BorderSize = 0;
            this.BtnCncl.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.BtnCncl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnCncl.Location = new System.Drawing.Point(1159, 6);
            this.BtnCncl.Name = "BtnCncl";
            this.BtnCncl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BtnCncl.Size = new System.Drawing.Size(69, 34);
            this.BtnCncl.TabIndex = 2179;
            this.BtnCncl.Text = "Cancel";
            this.BtnCncl.UseVisualStyleBackColor = true;
            this.BtnCncl.Visible = false;
            // 
            // GridTicket
            // 
            this.GridTicket.AllowUserToAddRows = false;
            this.GridTicket.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GridTicket.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GridTicket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridTicket.BackgroundColor = System.Drawing.Color.White;
            this.GridTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridTicket.DefaultCellStyle = dataGridViewCellStyle6;
            this.GridTicket.Location = new System.Drawing.Point(28, 60);
            this.GridTicket.MultiSelect = false;
            this.GridTicket.Name = "GridTicket";
            this.GridTicket.ReadOnly = true;
            this.GridTicket.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GridTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridTicket.Size = new System.Drawing.Size(1482, 611);
            this.GridTicket.TabIndex = 2172;
            this.GridTicket.Visible = false;
            this.GridTicket.SelectionChanged += new System.EventHandler(this.GridTicket_SelectionChanged);
            this.GridTicket.DoubleClick += new System.EventHandler(this.GridTicket_DoubleClick);
            // 
            // SerchTxt
            // 
            this.SerchTxt.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.SerchTxt.ForeColor = System.Drawing.Color.Black;
            this.SerchTxt.Location = new System.Drawing.Point(818, 12);
            this.SerchTxt.Name = "SerchTxt";
            this.SerchTxt.Size = new System.Drawing.Size(187, 26);
            this.SerchTxt.TabIndex = 2169;
            this.SerchTxt.Tag = "Arabic-All";
            this.SerchTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SerchTxt.TextChanged += new System.EventHandler(this.SerchTxt_TextChanged);
            // 
            // BtnSerch
            // 
            this.BtnSerch.BackgroundImage = global::VOCAC.Properties.Resources.recgreen;
            this.BtnSerch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSerch.FlatAppearance.BorderSize = 0;
            this.BtnSerch.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.BtnSerch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnSerch.Location = new System.Drawing.Point(1023, 7);
            this.BtnSerch.Name = "BtnSerch";
            this.BtnSerch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BtnSerch.Size = new System.Drawing.Size(113, 34);
            this.BtnSerch.TabIndex = 2170;
            this.BtnSerch.Text = "بحث";
            this.BtnSerch.UseVisualStyleBackColor = true;
            this.BtnSerch.Click += new System.EventHandler(this.BtnSerch_Click);
            // 
            // FilterComb
            // 
            this.FilterComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComb.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.FilterComb.FormattingEnabled = true;
            this.FilterComb.Location = new System.Drawing.Point(625, 12);
            this.FilterComb.Name = "FilterComb";
            this.FilterComb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FilterComb.Size = new System.Drawing.Size(187, 27);
            this.FilterComb.TabIndex = 2171;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(550, 17);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label2.Size = new System.Drawing.Size(69, 19);
            this.Label2.TabIndex = 2177;
            this.Label2.Text = "نوع البحث :";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToolTip1
            // 
            this.ToolTip1.IsBalloon = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Rd_strtwith);
            this.panel4.Controls.Add(this.Rd_contain);
            this.panel4.Controls.Add(this.Rd_endwith);
            this.panel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.panel4.Location = new System.Drawing.Point(120, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 35);
            this.panel4.TabIndex = 2180;
            // 
            // Rd_strtwith
            // 
            this.Rd_strtwith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rd_strtwith.AutoSize = true;
            this.Rd_strtwith.Location = new System.Drawing.Point(168, 7);
            this.Rd_strtwith.Name = "Rd_strtwith";
            this.Rd_strtwith.Size = new System.Drawing.Size(55, 23);
            this.Rd_strtwith.TabIndex = 2172;
            this.Rd_strtwith.Text = "يبدأ بـ";
            this.Rd_strtwith.UseVisualStyleBackColor = true;
            this.Rd_strtwith.Click += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // Rd_contain
            // 
            this.Rd_contain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rd_contain.AutoSize = true;
            this.Rd_contain.Checked = true;
            this.Rd_contain.Location = new System.Drawing.Point(10, 7);
            this.Rd_contain.Name = "Rd_contain";
            this.Rd_contain.Size = new System.Drawing.Size(86, 23);
            this.Rd_contain.TabIndex = 2174;
            this.Rd_contain.TabStop = true;
            this.Rd_contain.Text = "يحتوى على";
            this.Rd_contain.UseVisualStyleBackColor = true;
            this.Rd_contain.Click += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // Rd_endwith
            // 
            this.Rd_endwith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rd_endwith.AutoSize = true;
            this.Rd_endwith.Location = new System.Drawing.Point(98, 7);
            this.Rd_endwith.Name = "Rd_endwith";
            this.Rd_endwith.Size = new System.Drawing.Size(66, 23);
            this.Rd_endwith.TabIndex = 2173;
            this.Rd_endwith.Text = "ينتهي بـ";
            this.Rd_endwith.UseVisualStyleBackColor = true;
            this.Rd_endwith.Click += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Rd_Equal);
            this.panel5.Controls.Add(this.Rd_Like);
            this.panel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.panel5.Location = new System.Drawing.Point(356, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(143, 35);
            this.panel5.TabIndex = 2181;
            // 
            // Rd_Equal
            // 
            this.Rd_Equal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rd_Equal.AutoSize = true;
            this.Rd_Equal.Location = new System.Drawing.Point(87, 7);
            this.Rd_Equal.Name = "Rd_Equal";
            this.Rd_Equal.Size = new System.Drawing.Size(36, 23);
            this.Rd_Equal.TabIndex = 2172;
            this.Rd_Equal.Text = "=";
            this.Rd_Equal.UseVisualStyleBackColor = true;
            this.Rd_Equal.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            // 
            // Rd_Like
            // 
            this.Rd_Like.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rd_Like.AutoSize = true;
            this.Rd_Like.Checked = true;
            this.Rd_Like.Location = new System.Drawing.Point(15, 7);
            this.Rd_Like.Name = "Rd_Like";
            this.Rd_Like.Size = new System.Drawing.Size(52, 23);
            this.Rd_Like.TabIndex = 2173;
            this.Rd_Like.TabStop = true;
            this.Rd_Like.Text = "like";
            this.Rd_Like.UseVisualStyleBackColor = true;
            this.Rd_Like.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(600, 200);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 2182;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBar1
            // 
            this.StatusBar1.Enabled = false;
            this.StatusBar1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.StatusBar1.Location = new System.Drawing.Point(0, 739);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.StatBrPnlEn,
            this.StatBrPnlAr});
            this.StatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusBar1.ShowPanels = true;
            this.StatusBar1.Size = new System.Drawing.Size(1562, 36);
            this.StatusBar1.SizingGrip = false;
            this.StatusBar1.TabIndex = 2183;
            // 
            // StatBrPnlEn
            // 
            this.StatBrPnlEn.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.StatBrPnlEn.Name = "StatBrPnlEn";
            this.StatBrPnlEn.Width = 10;
            // 
            // StatBrPnlAr
            // 
            this.StatBrPnlAr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatBrPnlAr.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.StatBrPnlAr.Name = "StatBrPnlAr";
            this.StatBrPnlAr.Width = 1552;
            // 
            // TikSearchNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1562, 775);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.BtnCncl);
            this.Controls.Add(this.GridTicket);
            this.Controls.Add(this.SerchTxt);
            this.Controls.Add(this.BtnSerch);
            this.Controls.Add(this.FilterComb);
            this.Controls.Add(this.Label2);
            this.Name = "TikSearchNew";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة البحث";
            this.Load += new System.EventHandler(this.TikSearchNew_Load);
            this.SizeChanged += new System.EventHandler(this.TikSearchNew_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.GridTicket)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatBrPnlEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatBrPnlAr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button CloseBtn;
        internal System.Windows.Forms.Button BtnCncl;
        internal System.Windows.Forms.DataGridView GridTicket;
        internal System.Windows.Forms.TextBox SerchTxt;
        internal System.Windows.Forms.Button BtnSerch;
        internal System.Windows.Forms.ComboBox FilterComb;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton Rd_strtwith;
        private System.Windows.Forms.RadioButton Rd_contain;
        private System.Windows.Forms.RadioButton Rd_endwith;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton Rd_Equal;
        private System.Windows.Forms.RadioButton Rd_Like;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.StatusBar StatusBar1;
        internal System.Windows.Forms.StatusBarPanel StatBrPnlAr;
        private System.Windows.Forms.StatusBarPanel StatBrPnlEn;
    }
}