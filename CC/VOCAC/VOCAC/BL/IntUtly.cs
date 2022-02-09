using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Media;

namespace VOCAC.BL
{
    public static class IntUtly
    {
        public static void ValdtInt(KeyPressEventArgs e) // numeric only int
        {
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }
        public static void ValdtAll(KeyPressEventArgs e) // numeric only int
        {
            if ((e.KeyChar)==8)
            {

            }
            else if (char.IsControl(e.KeyChar) == true && (Keys)e.KeyChar != Keys.V)

            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }
        public static void ValdtNumber(object sender, KeyPressEventArgs e) //numeric decmal
        {
            TextBox TempNum = (TextBox)sender;
            if (((Keys)e.KeyChar != Keys.Back && ("0123456789.").IndexOf(e.KeyChar) == -1) ||
                e.KeyChar == Convert.ToChar(".") && TempNum.Text.ToCharArray().Count(c => c == Convert.ToChar(".")) > 0)
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }
        public static void ValdtIntLetter(KeyPressEventArgs e) // numeric & Letters & White Space & Backspace
        {
            if (char.IsControl(e.KeyChar) == true && (char.IsDigit(e.KeyChar)) ||
                                             (char.IsLetter(e.KeyChar)) ||
                                             (char.IsWhiteSpace(e.KeyChar)) ||
                                               (Keys)e.KeyChar == Keys.Back ||
                ((Keys)e.KeyChar == Keys.ShiftKey) && (char.IsLetter(e.KeyChar)))
            { }
            else
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }
        public static void ValdtLetter(object sender, KeyPressEventArgs e) //  Letters & White Space & Backspace
        {
            TextBox TempNum = (TextBox)sender;
            if (char.IsControl(e.KeyChar) == false && (char.IsLetter(e.KeyChar)) ||
                                                      (char.IsWhiteSpace(e.KeyChar)) ||
                                                        (Keys)e.KeyChar == Keys.Back ||
                ((Keys)e.KeyChar == Keys.ShiftKey) && char.IsLetter(e.KeyChar))
            { }
            else
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }
        public static void ValdtNotNull(object sender, EventArgs e) //  Check Null Value
        {
            TextBox No = (TextBox)sender;
            if (No.Text.Trim() == "")
            {
                SystemSounds.Beep.Play();
                No.Focus();
            }
        }
    }
}
