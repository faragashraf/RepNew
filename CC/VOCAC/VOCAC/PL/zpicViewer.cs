using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOCAC.PL
{
    public partial class zpicViewer : Form
    {
        private static zpicViewer frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
            GC.Collect();
        }
        public static zpicViewer getviewerfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new zpicViewer();
                    frm.FormClosed += new FormClosedEventHandler(frm_Closed);
                }
                return frm;
            }
        }

        private int _X;
        private int _Y;

        private static DataTable tbl;

        public Image _originalImage;
        public Rectangle _selection;
        public bool _selecting;
        public string Bar;
        bool rsult = false;
        public zpicViewer()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
            tbl = new DataTable();
            tbl.Columns.Add("value");
            tbl.Columns.Add("display");
            tbl.Rows.Add(1, "100 %");
            tbl.Rows.Add(2, "50 %");
            tbl.Rows.Add(3, "33 %");
            tbl.Rows.Add(4, "25 %");
            tbl.Rows.Add(5, "20 %");
            tbl.Rows.Add(6, "15 %");
            comboBox1.DataSource = tbl;
            comboBox1.ValueMember = "value";
            comboBox1.DisplayMember = "display";
            _originalImage = Statcdif.imge;
        }

        private void manupilateIMAGE()
        {
            Size sze, frmsze;
            string imgeLengthMB;
            double fileSize_;

            sze = new Size(Statcdif.imge.Width / Convert.ToInt32(comboBox1.SelectedValue), Statcdif.imge.Height / Convert.ToInt32(comboBox1.SelectedValue));
            frmsze = new Size(sze.Width + 50, sze.Height + flwCmboPanel.Height + flwRotatePanel.Height + StatusBar1.Height + 55);

            pictureBox1.Size = sze;
            if (frmsze.Width > Statcdif.screenWidth)
            {
                frmsze.Width = Statcdif.screenWidth - 50;
            }
            if (frmsze.Height > Statcdif.screenHeight)
            {
                frmsze.Height = Statcdif.screenHeight - 50;
            }
            this.Size = frmsze;
            //this.MaximumSize = frmsze;
            this.MinimumSize = new Size (800,600);

            pictureBox1.Margin = new Padding(((frmsze.Width - sze.Width) / 2) - 10, 0, 0, 0);
            pictureBox1.Image = function.ResizeImage(Statcdif.imge, sze.Width, sze.Height);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            using (var ms = new System.IO.MemoryStream())
            {
                pictureBox1.Image.Save(ms, ImageFormat.Png);
                Statcdif.mainImageArray = ms.ToArray();
            }

            pictureBox1.Image.Save(@"C:\\temp.jpg");
            System.IO.FileInfo fileinfo = new System.IO.FileInfo(@"C:\\temp.jpg");
            fileSize_ = fileinfo.Length;
            imgeLengthMB = Math.Round((fileSize_ / 1024 / 1024), 2).ToString();
            string imgeLengthKB = Math.Round((fileSize_ / 1024), 0).ToString();
            fileinfo.Delete();
            StatBrPnlAr.Text = "حجم الصورة : " + pictureBox1.Image.Size.ToString() + "........" + " حجم الملف = " + imgeLengthMB + "  { KB " + imgeLengthKB + "} MB";
            Bar = StatBrPnlAr.Text;
        }

        public void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            manupilateIMAGE();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Starting point of the selection:
            if (e.Button == MouseButtons.Left)
            {
                _selecting = true;
                _selection = new Rectangle(new Point(e.X, e.Y), new Size());
                _X = e.X;
                _Y = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the actual size of the selection:
            if (_selecting)
            {
                _selection.Width = e.X - _selection.X;
                _selection.Height = e.Y - _selection.Y;
                // Redraw the picturebox:
                pictureBox1.Refresh();
            }
            StatBrPnlEn.Text = "X :" + e.X.ToString() + " Y : " + e.Y.ToString();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _selecting)
            {
                if (_selection.Width < 0 || _selection.Height < 0)
                {
                    MessageBox.Show("تحديد مساحة قص الصورة يكون من اليسار لليمين", "قص الصورة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    if (_selection.Width > 0 && _selection.Height > 0)
                    {
                        if (_X + _selection.Width > pictureBox1.Width)
                        {
                            _selection.Width = pictureBox1.Width - _X;
                        }
                        if (_Y + _selection.Height > pictureBox1.Height)
                        {
                            _selection.Height = pictureBox1.Height - _Y;
                        }
                        //else
                        //{
                        //    MessageBox.Show("تحديد المساحة خارج نطاق الصورة", "قص الصورة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        //}
                        // Create cropped image:
                        Image img = function.Crop(pictureBox1.Image, _selection);

                        // Fit image to the picturebox:
                        Statcdif.imge = function.Fit2PictureBox(img, pictureBox1);
                        comboBox1.SelectedIndex = 0;
                        manupilateIMAGE();
                    }

                }
                _selecting = false;
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_selecting)
            {

                // Draw a rectangle displaying the current selection
                Pen pen = Pens.GreenYellow;
                e.Graphics.DrawRectangle(pen, _selection);
            }
        }

        private void btnResetOriginal_Click(object sender, EventArgs e)
        {
            Statcdif.imge = _originalImage;
            manupilateIMAGE();
        }

        private void Radio90_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap tt = (Bitmap)pictureBox1.Image;
            tt.RotateFlip(RotateFlipType.Rotate90FlipX);
            Statcdif.imge = tt;
            manupilateIMAGE();

            //pictureBox1.Refresh();
            if (Radio90.BackColor == Color.LimeGreen)
            {
                Radio90.BackColor = Color.White;
            }
            else
            {
                Radio90.BackColor = Color.LimeGreen;
            }
        }
        private void Radio180_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap tt = (Bitmap)pictureBox1.Image;
            tt.RotateFlip(RotateFlipType.Rotate180FlipY);
            Statcdif.imge = tt;
            manupilateIMAGE();
            if (Radio180.BackColor == Color.LimeGreen)
            {
                Radio180.BackColor = Color.White;
            }
            else
            {
                Radio180.BackColor = Color.LimeGreen;
            }
        }

        private void Btnchoose_Click(object sender, EventArgs e)
        {
            rsult = true;
            this.Close();
        }

        private void Btncdispose_Click(object sender, EventArgs e)
        {
            rsult = false;
            this.Close();
        }

        private void ZpicViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rsult == false)
            {
                Statcdif.mainImageArray = null;
                Statcdif.extAttch = null;
                Statcdif.imge = null;
            }
            GC.Collect();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            //PrintPreviewDialog prv = new PrintPreviewDialog();
            //prv.Document = Doc_printpage;
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.OriginAtMargins = true;
            doc.PrintPage += Doc_printpage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void Doc_printpage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sv = new SaveFileDialog() { Filter = Statcdif.extAttch.Split('.')[1].ToUpper() +" files| *" + Statcdif.extAttch, ValidateNames = true })
            {
                sv.FilterIndex = 2;
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    using (MemoryStream ms = new MemoryStream(Statcdif.mainImageArray))
                    {
                        pictureBox1.Image.Save(sv.FileName);
                        //Image.FromStream(ms).Save(@"c:\\AAA.jpg");
                        //Size sze = new Size();
                        //sze = Image.FromStream(ms).Size;
                        //int lql = Image.FromStream(ms).Height;
                    }
                }
            }

        }
    }
}

