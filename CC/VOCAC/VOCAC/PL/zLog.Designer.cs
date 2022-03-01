namespace VOCAUltimate.PL
{
    partial class zLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblHeader = new System.Windows.Forms.Label();
            this.LogData = new System.Windows.Forms.DataGridView();
            this.BtnRdFl = new System.Windows.Forms.Button();
            this.BtnExitFrm = new System.Windows.Forms.Button();
            this.BtnWrFl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogData)).BeginInit();
            this.SuspendLayout();
            // 
            // LblHeader
            // 
            this.LblHeader.BackColor = System.Drawing.Color.Transparent;
            this.LblHeader.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblHeader.Location = new System.Drawing.Point(278, 9);
            this.LblHeader.Name = "LblHeader";
            this.LblHeader.Size = new System.Drawing.Size(716, 30);
            this.LblHeader.TabIndex = 24;
            this.LblHeader.Text = " ";
            // 
            // LogData
            // 
            this.LogData.AllowUserToAddRows = false;
            this.LogData.AllowUserToDeleteRows = false;
            this.LogData.AllowUserToOrderColumns = true;
            this.LogData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LogData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.LogData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LogData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.LogData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(250)))), ((int)(((byte)(170)))));
            this.LogData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LogData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.LogData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LogData.DefaultCellStyle = dataGridViewCellStyle3;
            this.LogData.Location = new System.Drawing.Point(0, 79);
            this.LogData.Name = "LogData";
            this.LogData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LogData.Size = new System.Drawing.Size(1336, 679);
            this.LogData.TabIndex = 22;
            // 
            // BtnRdFl
            // 
            this.BtnRdFl.BackColor = System.Drawing.Color.Transparent;
            this.BtnRdFl.BackgroundImage = global::VOCAUltimate.Properties.Resources.LoadFl;
            this.BtnRdFl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnRdFl.Location = new System.Drawing.Point(14, 0);
            this.BtnRdFl.Name = "BtnRdFl";
            this.BtnRdFl.Size = new System.Drawing.Size(64, 64);
            this.BtnRdFl.TabIndex = 21;
            this.BtnRdFl.Tag = "Load the file to Grid";
            this.BtnRdFl.UseVisualStyleBackColor = false;
            this.BtnRdFl.Click += new System.EventHandler(this.BtnRdFl_Click);
            // 
            // BtnExitFrm
            // 
            this.BtnExitFrm.BackColor = System.Drawing.Color.Transparent;
            this.BtnExitFrm.BackgroundImage = global::VOCAUltimate.Properties.Resources._Exit1;
            this.BtnExitFrm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExitFrm.Location = new System.Drawing.Point(154, 0);
            this.BtnExitFrm.Name = "BtnExitFrm";
            this.BtnExitFrm.Size = new System.Drawing.Size(64, 64);
            this.BtnExitFrm.TabIndex = 20;
            this.BtnExitFrm.Tag = "Exit to Welcome Screen";
            this.BtnExitFrm.UseVisualStyleBackColor = false;
            // 
            // BtnWrFl
            // 
            this.BtnWrFl.BackColor = System.Drawing.Color.Transparent;
            this.BtnWrFl.BackgroundImage = global::VOCAUltimate.Properties.Resources.SaveFl;
            this.BtnWrFl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnWrFl.Location = new System.Drawing.Point(84, 0);
            this.BtnWrFl.Name = "BtnWrFl";
            this.BtnWrFl.Size = new System.Drawing.Size(64, 64);
            this.BtnWrFl.TabIndex = 23;
            this.BtnWrFl.Tag = "Encode the file then Save in Txt form, Without load it.";
            this.BtnWrFl.UseVisualStyleBackColor = false;
            // 
            // zLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 758);
            this.Controls.Add(this.LblHeader);
            this.Controls.Add(this.LogData);
            this.Controls.Add(this.BtnRdFl);
            this.Controls.Add(this.BtnExitFrm);
            this.Controls.Add(this.BtnWrFl);
            this.Name = "zLog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discrypt App. Log";
            this.SizeChanged += new System.EventHandler(this.ZLog_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.LogData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label LblHeader;
        internal System.Windows.Forms.DataGridView LogData;
        internal System.Windows.Forms.Button BtnRdFl;
        internal System.Windows.Forms.Button BtnExitFrm;
        internal System.Windows.Forms.Button BtnWrFl;
    }
}