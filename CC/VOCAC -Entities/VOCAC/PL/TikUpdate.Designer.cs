namespace VOCAUltimate.PL
{
    partial class TikUpdate
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
            this.GridUpdt = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DonlodAttchToolStripitem = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtUpdt = new System.Windows.Forms.TextBox();
            this.CmbEvent = new System.Windows.Forms.ComboBox();
            this.LblMsg = new System.Windows.Forms.Label();
            this.Label60 = new System.Windows.Forms.Label();
            this.BtnSubmt = new System.Windows.Forms.Button();
            this.TimerEscOpen = new System.Windows.Forms.Timer(this.components);
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkboxattach = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridUpdt)).BeginInit();
            this.ContextMenuStrip2.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            this.FlowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridUpdt
            // 
            this.GridUpdt.AllowUserToAddRows = false;
            this.GridUpdt.AllowUserToDeleteRows = false;
            this.GridUpdt.AllowUserToResizeColumns = false;
            this.GridUpdt.AllowUserToResizeRows = false;
            this.GridUpdt.BackgroundColor = System.Drawing.Color.White;
            this.GridUpdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridUpdt.ContextMenuStrip = this.ContextMenuStrip2;
            this.GridUpdt.Location = new System.Drawing.Point(477, 3);
            this.GridUpdt.MultiSelect = false;
            this.GridUpdt.Name = "GridUpdt";
            this.GridUpdt.ReadOnly = true;
            this.GridUpdt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GridUpdt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridUpdt.Size = new System.Drawing.Size(773, 355);
            this.GridUpdt.TabIndex = 2164;
            this.GridUpdt.SelectionChanged += new System.EventHandler(this.GridUpdt_SelectionChanged);
            // 
            // ContextMenuStrip2
            // 
            this.ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DonlodAttchToolStripitem});
            this.ContextMenuStrip2.Name = "ContextMenuStrip1";
            this.ContextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ContextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ContextMenuStrip2.Size = new System.Drawing.Size(181, 48);
            // 
            // DonlodAttchToolStripitem
            // 
            this.DonlodAttchToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DonlodAttchToolStripitem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DonlodAttchToolStripitem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.DonlodAttchToolStripitem.Name = "DonlodAttchToolStripitem";
            this.DonlodAttchToolStripitem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DonlodAttchToolStripitem.RightToLeftAutoMirrorImage = true;
            this.DonlodAttchToolStripitem.Size = new System.Drawing.Size(180, 22);
            this.DonlodAttchToolStripitem.Text = "Download attached";
            this.DonlodAttchToolStripitem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DonlodAttchToolStripitem.Click += new System.EventHandler(this.DonlodAttchToolStripitem_Click);
            // 
            // TxtUpdt
            // 
            this.TxtUpdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtUpdt.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.TxtUpdt.Location = new System.Drawing.Point(208, 37);
            this.TxtUpdt.Margin = new System.Windows.Forms.Padding(0, 10, 40, 0);
            this.TxtUpdt.Multiline = true;
            this.TxtUpdt.Name = "TxtUpdt";
            this.TxtUpdt.ReadOnly = true;
            this.TxtUpdt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtUpdt.Size = new System.Drawing.Size(990, 162);
            this.TxtUpdt.TabIndex = 2161;
            this.TxtUpdt.Tag = "Arabic-All";
            // 
            // CmbEvent
            // 
            this.CmbEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlowLayoutPanel2.SetFlowBreak(this.CmbEvent, true);
            this.CmbEvent.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.CmbEvent.FormattingEnabled = true;
            this.CmbEvent.Location = new System.Drawing.Point(977, 0);
            this.CmbEvent.Margin = new System.Windows.Forms.Padding(0);
            this.CmbEvent.Name = "CmbEvent";
            this.CmbEvent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CmbEvent.Size = new System.Drawing.Size(164, 27);
            this.CmbEvent.TabIndex = 2163;
            // 
            // LblMsg
            // 
            this.LblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblMsg.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.LblMsg.Location = new System.Drawing.Point(47, 199);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(1188, 46);
            this.LblMsg.TabIndex = 2168;
            this.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label60
            // 
            this.Label60.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label60.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Label60.Location = new System.Drawing.Point(13, 647);
            this.Label60.Name = "Label60";
            this.Label60.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label60.Size = new System.Drawing.Size(97, 23);
            this.Label60.TabIndex = 2162;
            this.Label60.Text = "إضافة تحديث:";
            // 
            // BtnSubmt
            // 
            this.BtnSubmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSubmt.BackgroundImage = global::VOCAUltimate.Properties.Resources.recgreen;
            this.BtnSubmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSubmt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnSubmt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnSubmt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnSubmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmt.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubmt.Location = new System.Drawing.Point(113, 156);
            this.BtnSubmt.Margin = new System.Windows.Forms.Padding(3, 65, 3, 3);
            this.BtnSubmt.Name = "BtnSubmt";
            this.BtnSubmt.Size = new System.Drawing.Size(92, 40);
            this.BtnSubmt.TabIndex = 2165;
            this.BtnSubmt.Text = "تسجيل";
            this.BtnSubmt.UseVisualStyleBackColor = true;
            this.BtnSubmt.Click += new System.EventHandler(this.BtnSubmt_Click);
            // 
            // TimerEscOpen
            // 
            this.TimerEscOpen.Enabled = true;
            this.TimerEscOpen.Interval = 1000;
            this.TimerEscOpen.Tick += new System.EventHandler(this.TimerEscOpen_Tick);
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.AutoScroll = true;
            this.FlowLayoutPanel1.Controls.Add(this.GridUpdt);
            this.FlowLayoutPanel1.Controls.Add(this.FlowLayoutPanel2);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(1253, 761);
            this.FlowLayoutPanel1.TabIndex = 2169;
            // 
            // FlowLayoutPanel2
            // 
            this.FlowLayoutPanel2.Controls.Add(this.label1);
            this.FlowLayoutPanel2.Controls.Add(this.CmbEvent);
            this.FlowLayoutPanel2.Controls.Add(this.TxtUpdt);
            this.FlowLayoutPanel2.Controls.Add(this.BtnSubmt);
            this.FlowLayoutPanel2.Controls.Add(this.chkboxattach);
            this.FlowLayoutPanel2.Controls.Add(this.LblMsg);
            this.FlowLayoutPanel1.SetFlowBreak(this.FlowLayoutPanel2, true);
            this.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel2.Location = new System.Drawing.Point(12, 364);
            this.FlowLayoutPanel2.Name = "FlowLayoutPanel2";
            this.FlowLayoutPanel2.Size = new System.Drawing.Size(1238, 288);
            this.FlowLayoutPanel2.TabIndex = 2161;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label1.Location = new System.Drawing.Point(1141, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(97, 23);
            this.label1.TabIndex = 2055;
            this.label1.Text = "إضافة تحديث:";
            // 
            // chkboxattach
            // 
            this.chkboxattach.AutoSize = true;
            this.chkboxattach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.chkboxattach.Location = new System.Drawing.Point(14, 167);
            this.chkboxattach.Margin = new System.Windows.Forms.Padding(3, 140, 3, 3);
            this.chkboxattach.Name = "chkboxattach";
            this.chkboxattach.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkboxattach.Size = new System.Drawing.Size(93, 23);
            this.chkboxattach.TabIndex = 2166;
            this.chkboxattach.Text = "إضافة مرفق";
            this.chkboxattach.UseVisualStyleBackColor = true;
            // 
            // TikUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1253, 761);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.Label60);
            this.Name = "TikUpdate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TikUpdate";
            this.Load += new System.EventHandler(this.TikUpdate_Load);
            this.SizeChanged += new System.EventHandler(this.TikUpdate_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.GridUpdt)).EndInit();
            this.ContextMenuStrip2.ResumeLayout(false);
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel2.ResumeLayout(false);
            this.FlowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView GridUpdt;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip2;
        internal System.Windows.Forms.ToolStripMenuItem DonlodAttchToolStripitem;
        internal System.Windows.Forms.TextBox TxtUpdt;
        internal System.Windows.Forms.ComboBox CmbEvent;
        internal System.Windows.Forms.Label LblMsg;
        internal System.Windows.Forms.Label Label60;
        internal System.Windows.Forms.Button BtnSubmt;
        internal System.Windows.Forms.Timer TimerEscOpen;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel2;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkboxattach;
        internal System.Windows.Forms.ToolTip toolTip1;
    }
}