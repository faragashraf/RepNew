using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAC.PL;

namespace VOCAC.BL
{
    class pictureViewer_
    {
        //public static Form frm;
        //public static FlowLayoutPanel flwMainPanel;
        //public static FlowLayoutPanel flwCmboPanel;
        //public static FlowLayoutPanel flwRotatePanel;
        //public static Label lbl;
        //public static ComboBox comboBox1;
        //public static RadioButton Radio90;
        //public static RadioButton Radio180;
        //public static PictureBox pictureBox1;
        //public static StatusBar StatusBar1;
        //public static StatusBarPanel StatBrPnlAr;
        //public static StatusBarPanel StatBrPnlEn;
        //public static Button button1;
        //public static Image imge;
        //private static int _X;
        //private static int _Y;

        //private static DataTable tbl;

        //public static Image _originalImage;
        //public static Rectangle _selection;
        //public static bool _selecting;
        //public static string Bar;

        public static void intialize_()
        {
            //tbl = new DataTable();
            //tbl.Columns.Add("value");
            //tbl.Columns.Add("display");
            //tbl.Rows.Add(1, "100 %");
            //tbl.Rows.Add(2, "50 %");
            //tbl.Rows.Add(3, "33 %");
            //tbl.Rows.Add(4, "25 %");
            //tbl.Rows.Add(5, "20 %");
            //tbl.Rows.Add(6, "15 %");
            //flwMainPanel = new FlowLayoutPanel();
            //flwCmboPanel = new FlowLayoutPanel();
            //flwRotatePanel = new FlowLayoutPanel();
            //lbl = new Label();
            //comboBox1 = new ComboBox();
            //pictureBox1 = new PictureBox();
            //StatusBar1 = new StatusBar();
            //StatBrPnlAr = new StatusBarPanel();
            //StatBrPnlEn = new StatusBarPanel();
            //button1 = new Button();
            //Radio90 = new RadioButton();
            //Radio180 = new RadioButton();
            //// 
            //// flwMainPanel
            //// 
            //flwMainPanel.Dock = DockStyle.Fill;
            //flwMainPanel.Location = new Point(0, 0);
            //flwMainPanel.Name = "flwMainPanel";
            //flwMainPanel.Size = new Size(1011, 566);
            //flwMainPanel.AutoScroll = true;
            //// 
            //// flwCmboPaenl
            //// 
            //flwMainPanel.SetFlowBreak(flwCmboPanel, false);
            //flwCmboPanel.Name = "flwCmboPaenl";
            //flwCmboPanel.SetFlowBreak(comboBox1, false);
            //flwCmboPanel.FlowDirection = FlowDirection.LeftToRight;
            //// 
            //// 
            //// flwRotatePanel
            //// 
            //flwMainPanel.SetFlowBreak(flwRotatePanel, true);
            //flwRotatePanel.TabIndex = 11;
            //flwRotatePanel.SetFlowBreak(Radio90, false);
            //flwRotatePanel.FlowDirection = FlowDirection.LeftToRight;
            //flwRotatePanel.AutoScroll = true;
            //flwRotatePanel.Margin = new Padding(0, 0, 0, 0);
            //// 
            //// Labele
            //// 
            //lbl.Name = "lbl";
            //lbl.Size = new Size(165, 20);
            //lbl.Margin = new Padding(10, 10, 0, 10);
            //lbl.Text = "التحكم في حجم الصورة :";
            //lbl.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            //lbl.TextAlign = ContentAlignment.MiddleLeft;
            ////
            //// comboBox1
            //// 
            //comboBox1.FormattingEnabled = true;
            //comboBox1.DataSource = tbl;
            //comboBox1.ValueMember = "value";
            //comboBox1.DisplayMember = "display";
            //comboBox1.Margin = new Padding(0, 10, 10, 10);
            //comboBox1.Name = "comboBox1";
            //comboBox1.Size = new Size(75, 21);
            //comboBox1.TabIndex = 0;
            //comboBox1.RightToLeft = RightToLeft.Yes;
            //comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox1.SelectedIndexChanged += new System.EventHandler(ComboBox1_SelectedIndexChanged);
            ////
            //// Radio90
            //// 
            //Radio90.Name = "Radio90";
            //Radio90.RightToLeft = RightToLeft.Yes;
            //Radio90.Text = "تدوير 90 درجة";
            //Radio90.Appearance = Appearance.Button;
            //Radio90.Margin = new Padding(0, 10, 10, 10);
            //Radio90.Click += new System.EventHandler(Radio90_CheckedChanged);
            ////
            //// Radio180
            //// 
            //Radio180.Name = "Radio180";
            //Radio180.RightToLeft = RightToLeft.Yes;
            //Radio180.Text = "تدوير 180 درجة";
            //Radio180.Appearance = Appearance.Button;
            //Radio180.Margin = new Padding(0, 10, 10, 10);
            //Radio180.Click += new System.EventHandler(Radio180_CheckedChanged);
            //// 
            //// pictureBox1
            //// 
            //pictureBox1.Name = "pictureBox1";
            //pictureBox1.TabIndex = 1;
            //pictureBox1.TabStop = false;
            //pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            //pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            //pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            //pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            //pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            //// 
            //// picviewer
            //// 

            //// 
            //// StatusBar1
            //// 
            //StatusBar1.Font = new Font("Times New Roman", 14F);
            //StatusBar1.Location = new Point(0, 412);
            //StatusBar1.Name = "StatusBar1";
            //StatusBar1.Panels.AddRange(new StatusBarPanel[] {
            //StatBrPnlEn,StatBrPnlAr});
            //StatusBar1.ShowPanels = true;
            //StatusBar1.TabIndex = 99;
            //StatBrPnlAr.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            //StatBrPnlEn.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            //// 
            //// StatBrPnlAr
            //// 
            //StatBrPnlAr.AutoSize = StatusBarPanelAutoSize.Spring;
            //StatBrPnlAr.Name = "StatBrPnlAr";
            //StatusBar1.RightToLeft = RightToLeft.Yes;
            //StatusBar1.Dock = DockStyle.Bottom;
            //// 
            //// StatBrPnlEn
            //// 
            //StatBrPnlEn.Alignment = HorizontalAlignment.Right;
            //StatBrPnlEn.AutoSize = StatusBarPanelAutoSize.Contents;
            //StatBrPnlEn.Name = "StatBrPnlEn";
            //StatBrPnlEn.Width = 10;
            //// 
            //// button1
            //// new Point(645, 9);
            //button1.Location = new System.Drawing.Point(400, 9);
            //button1.Name = "button1";
            //button1.Size = new System.Drawing.Size(148, 23);
            //button1.TabIndex = 1;
            //button1.Text = "استعادة الحجم الطبيعي";
            //button1.UseVisualStyleBackColor = true;
            //button1.Margin = new Padding(0, 10, 10, 10);

            //button1.Click += new System.EventHandler(btnResetOriginal_Click);
            //flwMainPanel.ResumeLayout(false);
            ////panel1.ResumeLayout(false);

            //frm = new Form();
            //frm.Text = "عرض الصورة";
            //frm.RightToLeft = RightToLeft.Yes;
            //frm.RightToLeftLayout = true;
            //frm.Controls.Add(flwMainPanel);
            //flwCmboPanel.Controls.Add(lbl);
            //flwMainPanel.Controls.Add(flwCmboPanel);
            //flwMainPanel.Controls.Add(flwRotatePanel);
            //flwMainPanel.Controls.Add(pictureBox1);
            //flwRotatePanel.Controls.Add(Radio90);
            //flwRotatePanel.Controls.Add(Radio180);
            //flwCmboPanel.Controls.Add(comboBox1);
            //flwRotatePanel.Controls.Add(button1);
            //frm.Controls.Add(StatusBar1);
            ////frm.MdiParent = WelcomeScreen.ActiveForm;
            ////frm.WindowState = FormWindowState.Normal;
            //frm.MaximizeBox = false;
            //_originalImage = imge.Clone() as Image;
            //frm.FormClosed += new FormClosedEventHandler(form_closed_eventHandler);
        }

        //private static void form_closed_eventHandler(object sender, FormClosedEventArgs e)
        //{
        //    frm.Dispose();
        //    GC.Collect();
        //}

        //public static void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    manupilateIMAGE();
        //}

        //private static void manupilateIMAGE()
        //{
        //    Size sze, frmsze;
        //    string imgeLengthMB;
        //    double fileSize_;

        //    sze = new Size(imge.Width / Convert.ToInt32(comboBox1.SelectedValue), imge.Height / Convert.ToInt32(comboBox1.SelectedValue));
        //    frmsze = new Size(sze.Width + 50, sze.Height + flwCmboPanel.Height + StatusBar1.Height + 55);

        //    pictureBox1.Size = sze;
        //    frm.Size = frmsze;
        //    frm.MaximumSize = frmsze;
        //    frm.MinimumSize = frmsze;

        //    flwCmboPanel.Size = new Size((comboBox1.Width + lbl.Width + 50), 50);
        //    flwRotatePanel.Size = new Size(Radio90.Width + Radio180.Width + button1.Width + 55, 50);
        //    flwCmboPanel.Margin = new Padding(((frmsze.Width - flwCmboPanel.Width - flwRotatePanel.Width) / 2) - 45, 0, 0, 0);
        //    pictureBox1.Margin = new Padding(((frmsze.Width - sze.Width) / 2) - 10, 0, 0, 0);

        //    pictureBox1.Image =  function.ResizeImage(imge, sze.Width, sze.Height);
        //    using (var ms = new System.IO.MemoryStream())
        //    {
        //        pictureBox1.Image.Save(ms, ImageFormat.Png);
        //        Statcdif.mainImageArray = ms.ToArray();
        //    }

        //    pictureBox1.Image.Save(@"C:\\temp.jpg");
        //    System.IO.FileInfo fileinfo = new System.IO.FileInfo(@"C:\\temp.jpg");
        //    fileSize_ = fileinfo.Length;
        //    imgeLengthMB = Math.Round((fileSize_ / 1024 / 1024), 2).ToString();
        //    string imgeLengthKB = Math.Round((fileSize_ / 1024), 0).ToString();
        //    fileinfo.Delete();
        //    StatBrPnlAr.Text = "حجم الصورة : " + pictureBox1.Image.Size.ToString() + "........" + " حجم الملف = " + imgeLengthMB + "  { KB " + imgeLengthKB + "} MB";
        //    Bar = StatBrPnlAr.Text;
        //    frm.Location = new Point(0, 0);
        //}

        //private static void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    // Starting point of the selection:
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        _selecting = true;
        //        _selection = new Rectangle(new Point(e.X, e.Y), new Size());
        //        _X = e.X;
        //        _Y = e.Y;
        //    }
        //}

        //private static void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    // Update the actual size of the selection:
        //    if (_selecting)
        //    {
        //        _selection.Width = e.X - _selection.X;
        //        _selection.Height = e.Y - _selection.Y;
        //        // Redraw the picturebox:
        //        pictureBox1.Refresh();
        //    }
        //    StatBrPnlEn.Text = "X :" + e.X.ToString() + " Y : " + e.Y.ToString();
        //}

        //private static void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left && _selecting)
        //    {
        //        if (_selection.Width < 0 || _selection.Height < 0)
        //        {
        //            MessageBox.Show("dd");
        //        }
        //        else
        //        {
        //            if (_X + _selection.Width < pictureBox1.Width && _Y + _selection.Height < pictureBox1.Height)
        //            {
        //                // Create cropped image:
        //                Image img = Crop(pictureBox1.Image, _selection);

        //                // Fit image to the picturebox:
        //                imge = Fit2PictureBox(img, pictureBox1);
        //                comboBox1.SelectedIndex = 0;
        //                manupilateIMAGE();
        //            }
        //        }
        //        _selecting = false;
        //    }
        //}

        //private static void pictureBox1_Paint(object sender, PaintEventArgs e)
        //{
        //    if (_selecting)
        //    {

        //        // Draw a rectangle displaying the current selection
        //        Pen pen = Pens.GreenYellow;
        //        e.Graphics.DrawRectangle(pen, _selection);
        //    }
        //}

        //private static void btnResetOriginal_Click(object sender, EventArgs e)
        //{
        //    imge = _originalImage;
        //    manupilateIMAGE();
        //}

        //private static void Radio90_CheckedChanged(object sender, EventArgs e)
        //{
        //    Bitmap tt = (Bitmap)pictureBox1.Image;
        //    tt.RotateFlip(RotateFlipType.Rotate90FlipX);
        //    pictureBox1.Image = tt;
        //    pictureBox1.Refresh();
        //    if (Radio90.BackColor == Color.LimeGreen)
        //    {
        //        Radio90.BackColor = Color.White;
        //    }
        //    else
        //    {
        //        Radio90.BackColor = Color.LimeGreen;
        //    }
        //}
        //private static void Radio180_CheckedChanged(object sender, EventArgs e)
        //{
        //    Bitmap tt = (Bitmap)pictureBox1.Image;
        //    tt.RotateFlip(RotateFlipType.Rotate180FlipY);
        //    pictureBox1.Image = tt;
        //    pictureBox1.Refresh();
        //    if (Radio180.BackColor == Color.LimeGreen)
        //    {
        //        Radio180.BackColor = Color.White;
        //    }
        //    else
        //    {
        //        Radio180.BackColor = Color.LimeGreen;
        //    }
        //}

    }

}
