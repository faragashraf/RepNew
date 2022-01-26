namespace VOCAC.PL
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
            this.CopyToolStripitem = new System.Windows.Forms.ToolStripMenuItem();
            this.UplodAtchToolStripitem = new System.Windows.Forms.ToolStripMenuItem();
            this.DonlodAttchToolStripitem = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtUpdt = new System.Windows.Forms.TextBox();
            this.CmbEvent = new System.Windows.Forms.ComboBox();
            this.LblMsg = new System.Windows.Forms.Label();
            this.BtnBrws = new System.Windows.Forms.Button();
            this.TxtBrws = new System.Windows.Forms.TextBox();
            this.Label60 = new System.Windows.Forms.Label();
            this.BtnSubmt = new System.Windows.Forms.Button();
            this.TimerEscOpen = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridUpdt)).BeginInit();
            this.ContextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridUpdt
            // 
            this.GridUpdt.AllowUserToAddRows = false;
            this.GridUpdt.AllowUserToDeleteRows = false;
            this.GridUpdt.BackgroundColor = System.Drawing.Color.White;
            this.GridUpdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridUpdt.ContextMenuStrip = this.ContextMenuStrip2;
            this.GridUpdt.Dock = System.Windows.Forms.DockStyle.Top;
            this.GridUpdt.Location = new System.Drawing.Point(0, 0);
            this.GridUpdt.MultiSelect = false;
            this.GridUpdt.Name = "GridUpdt";
            this.GridUpdt.ReadOnly = true;
            this.GridUpdt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GridUpdt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridUpdt.Size = new System.Drawing.Size(1252, 455);
            this.GridUpdt.TabIndex = 2164;
            // 
            // ContextMenuStrip2
            // 
            this.ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToolStripitem,
            this.UplodAtchToolStripitem,
            this.DonlodAttchToolStripitem});
            this.ContextMenuStrip2.Name = "ContextMenuStrip1";
            this.ContextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ContextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ContextMenuStrip2.Size = new System.Drawing.Size(185, 70);
            // 
            // CopyToolStripitem
            // 
            this.CopyToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CopyToolStripitem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CopyToolStripitem.Name = "CopyToolStripitem";
            this.CopyToolStripitem.RightToLeftAutoMirrorImage = true;
            this.CopyToolStripitem.Size = new System.Drawing.Size(184, 22);
            this.CopyToolStripitem.Text = "Copy Selected Cell";
            // 
            // UplodAtchToolStripitem
            // 
            this.UplodAtchToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UplodAtchToolStripitem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UplodAtchToolStripitem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UplodAtchToolStripitem.Name = "UplodAtchToolStripitem";
            this.UplodAtchToolStripitem.RightToLeftAutoMirrorImage = true;
            this.UplodAtchToolStripitem.Size = new System.Drawing.Size(184, 22);
            this.UplodAtchToolStripitem.Text = "Upload Attachement";
            this.UplodAtchToolStripitem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DonlodAttchToolStripitem
            // 
            this.DonlodAttchToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DonlodAttchToolStripitem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DonlodAttchToolStripitem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.DonlodAttchToolStripitem.Name = "DonlodAttchToolStripitem";
            this.DonlodAttchToolStripitem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DonlodAttchToolStripitem.RightToLeftAutoMirrorImage = true;
            this.DonlodAttchToolStripitem.Size = new System.Drawing.Size(184, 22);
            this.DonlodAttchToolStripitem.Text = "Download attached";
            this.DonlodAttchToolStripitem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtUpdt
            // 
            this.TxtUpdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtUpdt.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.TxtUpdt.Location = new System.Drawing.Point(275, 503);
            this.TxtUpdt.Multiline = true;
            this.TxtUpdt.Name = "TxtUpdt";
            this.TxtUpdt.ReadOnly = true;
            this.TxtUpdt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtUpdt.Size = new System.Drawing.Size(632, 104);
            this.TxtUpdt.TabIndex = 2161;
            this.TxtUpdt.Tag = "Arabic-All";
            // 
            // CmbEvent
            // 
            this.CmbEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEvent.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.CmbEvent.FormattingEnabled = true;
            this.CmbEvent.Location = new System.Drawing.Point(106, 503);
            this.CmbEvent.Name = "CmbEvent";
            this.CmbEvent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CmbEvent.Size = new System.Drawing.Size(164, 27);
            this.CmbEvent.TabIndex = 2163;
            // 
            // LblMsg
            // 
            this.LblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblMsg.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.LblMsg.Location = new System.Drawing.Point(913, 586);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(339, 33);
            this.LblMsg.TabIndex = 2168;
            this.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnBrws
            // 
            this.BtnBrws.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBrws.BackgroundImage = global::VOCAC.Properties.Resources.browse_button_png_th;
            this.BtnBrws.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBrws.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnBrws.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBrws.Location = new System.Drawing.Point(923, 504);
            this.BtnBrws.Name = "BtnBrws";
            this.BtnBrws.Size = new System.Drawing.Size(60, 27);
            this.BtnBrws.TabIndex = 2166;
            this.BtnBrws.UseVisualStyleBackColor = true;
            // 
            // TxtBrws
            // 
            this.TxtBrws.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBrws.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.TxtBrws.Location = new System.Drawing.Point(991, 504);
            this.TxtBrws.Name = "TxtBrws";
            this.TxtBrws.ReadOnly = true;
            this.TxtBrws.Size = new System.Drawing.Size(249, 26);
            this.TxtBrws.TabIndex = 2167;
            // 
            // Label60
            // 
            this.Label60.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label60.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Label60.Location = new System.Drawing.Point(12, 505);
            this.Label60.Name = "Label60";
            this.Label60.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label60.Size = new System.Drawing.Size(97, 23);
            this.Label60.TabIndex = 2162;
            this.Label60.Text = "إضافة تحديث:";
            // 
            // BtnSubmt
            // 
            this.BtnSubmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSubmt.BackgroundImage = global::VOCAC.Properties.Resources.recgreen;
            this.BtnSubmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSubmt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnSubmt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnSubmt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnSubmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmt.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubmt.Location = new System.Drawing.Point(913, 543);
            this.BtnSubmt.Margin = new System.Windows.Forms.Padding(3, 65, 3, 3);
            this.BtnSubmt.Name = "BtnSubmt";
            this.BtnSubmt.Size = new System.Drawing.Size(92, 40);
            this.BtnSubmt.TabIndex = 2165;
            this.BtnSubmt.Text = "تسجيل";
            this.BtnSubmt.UseVisualStyleBackColor = true;
            // 
            // TimerEscOpen
            // 
            this.TimerEscOpen.Interval = 1000;
            // 
            // TikUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 619);
            this.Controls.Add(this.GridUpdt);
            this.Controls.Add(this.TxtUpdt);
            this.Controls.Add(this.CmbEvent);
            this.Controls.Add(this.LblMsg);
            this.Controls.Add(this.BtnBrws);
            this.Controls.Add(this.TxtBrws);
            this.Controls.Add(this.Label60);
            this.Controls.Add(this.BtnSubmt);
            this.Name = "TikUpdate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "TikUpdate";
            this.Load += new System.EventHandler(this.TikUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridUpdt)).EndInit();
            this.ContextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView GridUpdt;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip2;
        internal System.Windows.Forms.ToolStripMenuItem CopyToolStripitem;
        internal System.Windows.Forms.ToolStripMenuItem UplodAtchToolStripitem;
        internal System.Windows.Forms.ToolStripMenuItem DonlodAttchToolStripitem;
        internal System.Windows.Forms.TextBox TxtUpdt;
        internal System.Windows.Forms.ComboBox CmbEvent;
        internal System.Windows.Forms.Label LblMsg;
        internal System.Windows.Forms.Button BtnBrws;
        internal System.Windows.Forms.TextBox TxtBrws;
        internal System.Windows.Forms.Label Label60;
        internal System.Windows.Forms.Button BtnSubmt;
        internal System.Windows.Forms.Timer TimerEscOpen;
    }
}