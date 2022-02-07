using System.Drawing;
using System.Windows.Forms;
using gfoidl.Imaging;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Image _originalImage;
        private bool _selecting;
        private Rectangle _selection;
        //---------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------
        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Save just a copy of the image on no reference!
            _originalImage = pictureBox1.Image.Clone() as Image;
        }
        //---------------------------------------------------------------------
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Starting point of the selection:
            if (e.Button == MouseButtons.Left)
            {
                _selecting = true;
                _selection = new Rectangle(new Point(e.X, e.Y), new Size());
            }
        }
        //---------------------------------------------------------------------
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
        }
        //---------------------------------------------------------------------
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _selecting)
            {
                if (_selection.Width < 0 || _selection.Height < 0)
                {
                    MessageBox.Show("dd");
                }
                else
                {
                    // Create cropped image:
                    Image img = pictureBox1.Image.Crop(_selection);

                    // Fit image to the picturebox:
                    pictureBox1.Image = img.Fit2PictureBox(pictureBox1);
                }

                _selecting = false;
            }
        }
        //---------------------------------------------------------------------
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_selecting)
            {
                // Draw a rectangle displaying the current selection
                Pen pen = Pens.GreenYellow;
                e.Graphics.DrawRectangle(pen, _selection);
            }
        }
        //---------------------------------------------------------------------
        private void button1_Click(object sender, System.EventArgs e)
        {
            pictureBox1.Image = _originalImage.Clone() as Image;
        }
    }
}