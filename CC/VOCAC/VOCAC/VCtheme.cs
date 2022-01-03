using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOCAC
{
    public static class VCtheme
    {
        public static void BtnCtrl(Button VCBtn)
        {
            VCBtn.BackColor = Color.Transparent;
            VCBtn.BackgroundImageLayout = ImageLayout.Stretch;
            if (VCBtn.Text.Split(' ').Count() > 1)
            {
                VCBtn.Font = new Font("Times new Roman", VCBtn.Width / 14, FontStyle.Regular, GraphicsUnit.Point);
            }
            else
            {
                VCBtn.Font = new Font("Times new Roman", VCBtn.Width / 8, FontStyle.Regular, GraphicsUnit.Point);
            }

            VCBtn.TextAlign = ContentAlignment.MiddleCenter;
            VCBtn.FlatStyle = FlatStyle.Flat;
            VCBtn.FlatAppearance.BorderSize = 0;
            VCBtn.BringToFront();
        }
        public static void BtnIncrease(Button VCBtn)
        {
            VCBtn.Width += 10;
            VCBtn.Height += 10;
            VCBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            VCBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            VCBtn.Location = new Point(VCBtn.Location.X - 5, VCBtn.Location.Y - 5);
            VCBtn.Font = new Font(VCBtn.Font.Name, VCBtn.Font.Size + 2, FontStyle.Bold, VCBtn.Font.Unit);
            VCBtn.Padding = new Padding(VCBtn.Padding.Left, -2, VCBtn.Padding.Right, -2);
        }
        public static void BtnDecrease(Button VCBtn)
        {
            VCBtn.Width -= 10;
            VCBtn.Height -= 10;
            VCBtn.Location = new Point(VCBtn.Location.X + 5, VCBtn.Location.Y + 5);
            VCBtn.Font = new Font(VCBtn.Font.Name, VCBtn.Font.Size - 2, FontStyle.Regular, VCBtn.Font.Unit);
            VCBtn.Padding = new Padding(VCBtn.Padding.Left, 0, VCBtn.Padding.Right, 0);
        }
    }
}
