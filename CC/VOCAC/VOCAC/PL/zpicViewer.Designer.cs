using System.Drawing;
using System.Windows.Forms;

namespace VOCAC.PL
{
    partial class zpicViewer
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
            this.flwMainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flwCmboPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnprint = new System.Windows.Forms.Button();
            this.flwRotatePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Radio90 = new System.Windows.Forms.RadioButton();
            this.Radio180 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnchoose = new System.Windows.Forms.Button();
            this.btncdispose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.StatBrPnlEn = new System.Windows.Forms.StatusBarPanel();
            this.StatBrPnlAr = new System.Windows.Forms.StatusBarPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.flwMainPanel.SuspendLayout();
            this.flwCmboPanel.SuspendLayout();
            this.flwRotatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatBrPnlEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatBrPnlAr)).BeginInit();
            this.SuspendLayout();
            // 
            // flwMainPanel
            // 
            this.flwMainPanel.AutoScroll = true;
            this.flwMainPanel.BackColor = System.Drawing.Color.White;
            this.flwMainPanel.Controls.Add(this.flwCmboPanel);
            this.flwMainPanel.Controls.Add(this.flwRotatePanel);
            this.flwMainPanel.Controls.Add(this.pictureBox1);
            this.flwMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwMainPanel.Location = new System.Drawing.Point(0, 0);
            this.flwMainPanel.Name = "flwMainPanel";
            this.flwMainPanel.Size = new System.Drawing.Size(1289, 794);
            this.flwMainPanel.TabIndex = 0;
            // 
            // flwCmboPanel
            // 
            this.flwCmboPanel.AutoScroll = true;
            this.flwCmboPanel.Controls.Add(this.lbl);
            this.flwCmboPanel.Controls.Add(this.comboBox1);
            this.flwCmboPanel.Controls.Add(this.btnSave);
            this.flwCmboPanel.Controls.Add(this.btnprint);
            this.flwMainPanel.SetFlowBreak(this.flwCmboPanel, true);
            this.flwCmboPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flwCmboPanel.Location = new System.Drawing.Point(844, 3);
            this.flwCmboPanel.Name = "flwCmboPanel";
            this.flwCmboPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flwCmboPanel.Size = new System.Drawing.Size(442, 57);
            this.flwCmboPanel.TabIndex = 0;
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lbl.Location = new System.Drawing.Point(267, 15);
            this.lbl.Margin = new System.Windows.Forms.Padding(0, 15, 10, 10);
            this.lbl.Name = "lbl";
            this.lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl.Size = new System.Drawing.Size(165, 20);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "التحكم في حجم الصورة :";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "display";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(182, 15);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(0, 15, 10, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "value";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // btnprint
            // 
            this.btnprint.BackgroundImage = global::VOCAC.Properties.Resources.print;
            this.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprint.Location = new System.Drawing.Point(73, 15);
            this.btnprint.Margin = new System.Windows.Forms.Padding(0, 15, 10, 10);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(37, 25);
            this.btnprint.TabIndex = 3;
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Visible = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // flwRotatePanel
            // 
            this.flwRotatePanel.AutoScroll = true;
            this.flwRotatePanel.AutoSize = true;
            this.flwRotatePanel.Controls.Add(this.Radio90);
            this.flwRotatePanel.Controls.Add(this.Radio180);
            this.flwRotatePanel.Controls.Add(this.button1);
            this.flwRotatePanel.Controls.Add(this.btnchoose);
            this.flwRotatePanel.Controls.Add(this.btncdispose);
            this.flwMainPanel.SetFlowBreak(this.flwRotatePanel, true);
            this.flwRotatePanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flwRotatePanel.Location = new System.Drawing.Point(792, 66);
            this.flwRotatePanel.Name = "flwRotatePanel";
            this.flwRotatePanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flwRotatePanel.Size = new System.Drawing.Size(494, 52);
            this.flwRotatePanel.TabIndex = 11;
            // 
            // Radio90
            // 
            this.Radio90.Appearance = System.Windows.Forms.Appearance.Button;
            this.Radio90.Location = new System.Drawing.Point(380, 15);
            this.Radio90.Margin = new System.Windows.Forms.Padding(0, 15, 10, 10);
            this.Radio90.Name = "Radio90";
            this.Radio90.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Radio90.Size = new System.Drawing.Size(104, 24);
            this.Radio90.TabIndex = 0;
            this.Radio90.Text = "تدوير 90 درجة";
            this.Radio90.Click += new System.EventHandler(this.Radio90_CheckedChanged);
            // 
            // Radio180
            // 
            this.Radio180.Appearance = System.Windows.Forms.Appearance.Button;
            this.Radio180.Location = new System.Drawing.Point(266, 15);
            this.Radio180.Margin = new System.Windows.Forms.Padding(0, 15, 10, 10);
            this.Radio180.Name = "Radio180";
            this.Radio180.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Radio180.Size = new System.Drawing.Size(104, 24);
            this.Radio180.TabIndex = 0;
            this.Radio180.Text = "تدوير 180 درجة";
            this.Radio180.Click += new System.EventHandler(this.Radio180_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 15, 10, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "استعادة الحجم الطبيعي";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnResetOriginal_Click);
            // 
            // btnchoose
            // 
            this.btnchoose.BackgroundImage = global::VOCAC.Properties.Resources.Yes;
            this.btnchoose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnchoose.Location = new System.Drawing.Point(52, 6);
            this.btnchoose.Margin = new System.Windows.Forms.Padding(0, 6, 10, 10);
            this.btnchoose.Name = "btnchoose";
            this.btnchoose.Size = new System.Drawing.Size(46, 36);
            this.btnchoose.TabIndex = 2;
            this.btnchoose.UseVisualStyleBackColor = true;
            this.btnchoose.Click += new System.EventHandler(this.Btnchoose_Click);
            // 
            // btncdispose
            // 
            this.btncdispose.BackgroundImage = global::VOCAC.Properties.Resources.delete1;
            this.btncdispose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncdispose.Location = new System.Drawing.Point(0, 6);
            this.btncdispose.Margin = new System.Windows.Forms.Padding(0, 6, 10, 10);
            this.btncdispose.Name = "btncdispose";
            this.btncdispose.Size = new System.Drawing.Size(42, 36);
            this.btncdispose.TabIndex = 3;
            this.btncdispose.UseVisualStyleBackColor = true;
            this.btncdispose.Click += new System.EventHandler(this.Btncdispose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(137, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1149, 512);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // StatusBar1
            // 
            this.StatusBar1.Enabled = false;
            this.StatusBar1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.StatusBar1.Location = new System.Drawing.Point(0, 794);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.StatBrPnlEn,
            this.StatBrPnlAr});
            this.StatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusBar1.ShowPanels = true;
            this.StatusBar1.Size = new System.Drawing.Size(1289, 22);
            this.StatusBar1.SizingGrip = false;
            this.StatusBar1.TabIndex = 99;
            // 
            // StatBrPnlEn
            // 
            this.StatBrPnlEn.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.StatBrPnlEn.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.StatBrPnlEn.Name = "StatBrPnlEn";
            this.StatBrPnlEn.Width = 10;
            // 
            // StatBrPnlAr
            // 
            this.StatBrPnlAr.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.StatBrPnlAr.Name = "StatBrPnlAr";
            this.StatBrPnlAr.Width = 1279;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::VOCAC.Properties.Resources.SaveGreen1;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(120, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 5, 10, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // zpicViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1289, 816);
            this.Controls.Add(this.flwMainPanel);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.button2);
            this.Name = "zpicViewer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عرض وتجهيز الصورة";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZpicViewer_FormClosing);
            this.flwMainPanel.ResumeLayout(false);
            this.flwMainPanel.PerformLayout();
            this.flwCmboPanel.ResumeLayout(false);
            this.flwRotatePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatBrPnlEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatBrPnlAr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flwMainPanel;
        private System.Windows.Forms.FlowLayoutPanel flwCmboPanel;
        private System.Windows.Forms.FlowLayoutPanel flwRotatePanel;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton Radio90;
        private System.Windows.Forms.RadioButton Radio180;
        private System.Windows.Forms.StatusBar StatusBar1;
        private System.Windows.Forms.StatusBarPanel StatBrPnlAr;
        private System.Windows.Forms.StatusBarPanel StatBrPnlEn;
        private System.Windows.Forms.Button button1;
        private Button button2;
        public PictureBox pictureBox1;
        private Button btnchoose;
        private Button btncdispose;
        private Button btnprint;
        private Button btnSave;
    }
}