namespace VOCAC
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
            this.CloseBtn = new System.Windows.Forms.Button();
            this.BtnCncl = new System.Windows.Forms.Button();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.LblMsg = new System.Windows.Forms.Label();
            this.GridTicket = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioButton3 = new System.Windows.Forms.RadioButton();
            this.RadioButton1 = new System.Windows.Forms.RadioButton();
            this.RadioButton2 = new System.Windows.Forms.RadioButton();
            this.SerchTxt = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Rdiocls = new System.Windows.Forms.RadioButton();
            this.RdioOpen = new System.Windows.Forms.RadioButton();
            this.RdioAll = new System.Windows.Forms.RadioButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.GridTicket)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.CloseBtn.Location = new System.Drawing.Point(1320, 563);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(50, 43);
            this.CloseBtn.TabIndex = 2175;
            this.CloseBtn.UseVisualStyleBackColor = true;
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
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ProgressBar1.Location = new System.Drawing.Point(922, 53);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(306, 20);
            this.ProgressBar1.TabIndex = 2178;
            this.ProgressBar1.Visible = false;
            // 
            // LblMsg
            // 
            this.LblMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblMsg.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.LblMsg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblMsg.Location = new System.Drawing.Point(0, 589);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblMsg.Size = new System.Drawing.Size(1382, 33);
            this.LblMsg.TabIndex = 2176;
            this.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GridTicket
            // 
            this.GridTicket.AllowUserToAddRows = false;
            this.GridTicket.AllowUserToDeleteRows = false;
            this.GridTicket.BackgroundColor = System.Drawing.Color.White;
            this.GridTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTicket.Location = new System.Drawing.Point(28, 124);
            this.GridTicket.MultiSelect = false;
            this.GridTicket.Name = "GridTicket";
            this.GridTicket.ReadOnly = true;
            this.GridTicket.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GridTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridTicket.Size = new System.Drawing.Size(1323, 424);
            this.GridTicket.TabIndex = 2172;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.RadioButton3);
            this.GroupBox1.Controls.Add(this.RadioButton1);
            this.GroupBox1.Controls.Add(this.RadioButton2);
            this.GroupBox1.Location = new System.Drawing.Point(15, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(250, 38);
            this.GroupBox1.TabIndex = 2173;
            this.GroupBox1.TabStop = false;
            // 
            // RadioButton3
            // 
            this.RadioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButton3.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.RadioButton3.Checked = true;
            this.RadioButton3.Cursor = System.Windows.Forms.Cursors.Default;
            this.RadioButton3.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.RadioButton3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RadioButton3.Location = new System.Drawing.Point(20, 11);
            this.RadioButton3.Name = "RadioButton3";
            this.RadioButton3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RadioButton3.Size = new System.Drawing.Size(65, 22);
            this.RadioButton3.TabIndex = 502;
            this.RadioButton3.TabStop = true;
            this.RadioButton3.Text = "الكل";
            this.RadioButton3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButton3.UseVisualStyleBackColor = true;
            // 
            // RadioButton1
            // 
            this.RadioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButton1.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.RadioButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.RadioButton1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.RadioButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RadioButton1.Location = new System.Drawing.Point(162, 11);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RadioButton1.Size = new System.Drawing.Size(75, 22);
            this.RadioButton1.TabIndex = 500;
            this.RadioButton1.Text = "طلب";
            this.RadioButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButton1.UseVisualStyleBackColor = true;
            // 
            // RadioButton2
            // 
            this.RadioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.RadioButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.RadioButton2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.RadioButton2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RadioButton2.Location = new System.Drawing.Point(89, 11);
            this.RadioButton2.Name = "RadioButton2";
            this.RadioButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RadioButton2.Size = new System.Drawing.Size(65, 22);
            this.RadioButton2.TabIndex = 501;
            this.RadioButton2.Text = "شكوى";
            this.RadioButton2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButton2.UseVisualStyleBackColor = true;
            // 
            // SerchTxt
            // 
            this.SerchTxt.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.SerchTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SerchTxt.Location = new System.Drawing.Point(818, 12);
            this.SerchTxt.Name = "SerchTxt";
            this.SerchTxt.Size = new System.Drawing.Size(187, 26);
            this.SerchTxt.TabIndex = 2169;
            this.SerchTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SerchTxt.TextChanged += new System.EventHandler(this.SerchTxt_TextChanged);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Rdiocls);
            this.GroupBox2.Controls.Add(this.RdioOpen);
            this.GroupBox2.Controls.Add(this.RdioAll);
            this.GroupBox2.Location = new System.Drawing.Point(283, 6);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(250, 38);
            this.GroupBox2.TabIndex = 2174;
            this.GroupBox2.TabStop = false;
            // 
            // Rdiocls
            // 
            this.Rdiocls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rdiocls.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.Rdiocls.Cursor = System.Windows.Forms.Cursors.Default;
            this.Rdiocls.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Rdiocls.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Rdiocls.Location = new System.Drawing.Point(89, 13);
            this.Rdiocls.Name = "Rdiocls";
            this.Rdiocls.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Rdiocls.Size = new System.Drawing.Size(65, 22);
            this.Rdiocls.TabIndex = 504;
            this.Rdiocls.Text = "مغلقة";
            this.Rdiocls.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Rdiocls.UseVisualStyleBackColor = true;
            // 
            // RdioOpen
            // 
            this.RdioOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RdioOpen.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.RdioOpen.Cursor = System.Windows.Forms.Cursors.Default;
            this.RdioOpen.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.RdioOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RdioOpen.Location = new System.Drawing.Point(160, 13);
            this.RdioOpen.Name = "RdioOpen";
            this.RdioOpen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RdioOpen.Size = new System.Drawing.Size(75, 22);
            this.RdioOpen.TabIndex = 503;
            this.RdioOpen.Text = "مفتوحة";
            this.RdioOpen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RdioOpen.UseVisualStyleBackColor = true;
            // 
            // RdioAll
            // 
            this.RdioAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RdioAll.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.RdioAll.Checked = true;
            this.RdioAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.RdioAll.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.RdioAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RdioAll.Location = new System.Drawing.Point(18, 13);
            this.RdioAll.Name = "RdioAll";
            this.RdioAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RdioAll.Size = new System.Drawing.Size(65, 22);
            this.RdioAll.TabIndex = 505;
            this.RdioAll.TabStop = true;
            this.RdioAll.Text = "الكل";
            this.RdioAll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RdioAll.UseVisualStyleBackColor = true;
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
            this.panel4.Location = new System.Drawing.Point(362, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 48);
            this.panel4.TabIndex = 2180;
            // 
            // Rd_strtwith
            // 
            this.Rd_strtwith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rd_strtwith.AutoSize = true;
            this.Rd_strtwith.Location = new System.Drawing.Point(168, 14);
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
            this.Rd_contain.Location = new System.Drawing.Point(10, 14);
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
            this.Rd_endwith.Location = new System.Drawing.Point(98, 14);
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
            this.panel5.Location = new System.Drawing.Point(598, 53);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(143, 48);
            this.panel5.TabIndex = 2181;
            // 
            // Rd_Equal
            // 
            this.Rd_Equal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rd_Equal.AutoSize = true;
            this.Rd_Equal.Location = new System.Drawing.Point(87, 14);
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
            this.Rd_Like.Location = new System.Drawing.Point(15, 14);
            this.Rd_Like.Name = "Rd_Like";
            this.Rd_Like.Size = new System.Drawing.Size(52, 23);
            this.Rd_Like.TabIndex = 2173;
            this.Rd_Like.TabStop = true;
            this.Rd_Like.Text = "like";
            this.Rd_Like.UseVisualStyleBackColor = true;
            this.Rd_Like.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            // 
            // TikSearchNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1382, 622);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.BtnCncl);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.LblMsg);
            this.Controls.Add(this.GridTicket);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.SerchTxt);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.BtnSerch);
            this.Controls.Add(this.FilterComb);
            this.Controls.Add(this.Label2);
            this.Name = "TikSearchNew";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "TikSearchNew";
            this.Load += new System.EventHandler(this.TikSearchNew_Load);
            this.SizeChanged += new System.EventHandler(this.TikSearchNew_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.GridTicket)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button CloseBtn;
        internal System.Windows.Forms.Button BtnCncl;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.Label LblMsg;
        internal System.Windows.Forms.DataGridView GridTicket;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.RadioButton RadioButton3;
        internal System.Windows.Forms.RadioButton RadioButton1;
        internal System.Windows.Forms.RadioButton RadioButton2;
        internal System.Windows.Forms.TextBox SerchTxt;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.RadioButton Rdiocls;
        internal System.Windows.Forms.RadioButton RdioOpen;
        internal System.Windows.Forms.RadioButton RdioAll;
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
    }
}