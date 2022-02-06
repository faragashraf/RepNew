using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attachments
{
    public partial class Form1 : Form
    {
        public SqlDataReader reader;
        public SqlDataAdapter sqladptr;
        public SqlCommand SqlComm;
        DataTable SqlTbl = new DataTable();
        SqlConnection con = new SqlConnection("Data Source=10.10.26.4;Initial Catalog=Attach_Tickets;Persist Security Info=True;User ID=vocac;Password=@VocaPlus$21-32223");
        DataTable attchtbl = new DataTable();
        Form frm = new Form();
        PictureBox picbox = new PictureBox();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string Msg = null;

            sqladptr = new SqlDataAdapter(" SELECT top(10) [id],[AttchID],[AttchNm],[AttcExt],[AttchSize] FROM[dbo].[Attch_shipment] ", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sqladptr.Fill(SqlTbl);
            }
            catch (Exception Ex)
            {
                Msg = Ex.Message;
            }

            //attchtbl = SqlTbl.Copy();
            //attchtbl.Columns.RemoveAt(3);
            //attchtbl.Columns.RemoveAt(1);
            //attchtbl.PrimaryKey = new DataColumn[] { attchtbl.Columns[0] };

            //SqlTbl.Columns.RemoveAt(2);
            dataGridView1.DataSource = SqlTbl;
            this.Text = SqlTbl.Rows.Count.ToString();
            sqladptr.Dispose();
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string gg = @"E:\FTP\AirportPaperWorkRecieved";
            textBox1.Text = gg;
            Thread thread_ = new Thread(addattachments);
            thread_.IsBackground = true;
            thread_.Start();
            //string[] files = Directory.GetFiles(startPath, "*.jpg", SearchOption.AllDirectories);
        }
        private void addattachments()
        {

            string startPath = textBox1.Text;
            for (int i = 0; i < SqlTbl.Rows.Count; i++)
            {
                DirectoryInfo d = new DirectoryInfo(startPath + "\\" + SqlTbl.Rows[i][1] + "\\");
                try
                {
                    string[] files = Directory.GetFiles(startPath + "\\" + SqlTbl.Rows[i][1] + "\\");
                    foreach (string oCurrent in files)
                    {
                        DirectoryInfo d1 = new DirectoryInfo(oCurrent);
                        //
                        byte[] image1 = File.ReadAllBytes(oCurrent);

                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "TSP_Test";
                        sqlcmd.Connection = con;
                        SqlParameter[] param = new SqlParameter[3];
                        param[0] = new SqlParameter("@id", SqlDbType.Int);
                        param[0].Value = Convert.ToInt32(SqlTbl.Rows[i][0]);
                        param[1] = new SqlParameter("@pic", SqlDbType.Image);
                        param[1].Value = image1;
                        param[2] = new SqlParameter("@txt", SqlDbType.NVarChar, 20);
                        param[2].Value = d1.Name.Split('.')[0].ToString();
                        sqlcmd.Parameters.Add(param[0]);
                        sqlcmd.Parameters.Add(param[1]);
                        sqlcmd.Parameters.Add(param[2]);
                        try
                        {
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }

                            sqlcmd.ExecuteNonQuery();
                        }
                        catch (Exception Ex)
                        {
                            string hh = Ex.Message;
                        }
                    }
                }
                catch (Exception)
                {


                }


            }
            MessageBox.Show("Done" + Environment.NewLine + DateTime.Now.ToString());
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            frm.Controls.Add(picbox);
            picbox.Dock = DockStyle.Fill;
            picbox.SizeMode = PictureBoxSizeMode.Zoom;
            frm.WindowState = FormWindowState.Maximized;
            byte[] data = dataGridView1.CurrentRow.Cells[2].Value.ToString().Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();
            List<string> ggg = new List<string>();

            Image imag;
            using (MemoryStream ms = new MemoryStream(data))
            {
                imag = Image.FromStream(ms);
                picbox.Image = imag;
            }
            frm.Show();
        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                FileInfo fl = new FileInfo("C:\\QQ.jpg");

                picbox.Image = null;
                byte[] data = dataGridView1.CurrentRow.Cells[2].Value.ToString().Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();
                Image imag;
                using (MemoryStream ms = new MemoryStream(data))
                {
                    imag = Image.FromStream(ms);
                    picbox.Image = imag;
                    //SaveFileDialog file = new SaveFileDialog();
                    //file.Filter = "All files (*.*)|";
                    //if (file.ShowDialog() == DialogResult.OK)
                    //{
                    //    imag.Save(file.FileName);
                    //}
                    //string extension = Path.GetExtension(fl.Name);
                }
            }
            catch (Exception ex)
            {
                string pp = ex.Message;
            }
        }
        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
