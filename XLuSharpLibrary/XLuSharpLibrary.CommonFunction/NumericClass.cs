namespace XLuSharpLibrary.CommonFunction
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class NumericClass
    {
        public static bool IsNumber(string strtext)
        {
            Regex regex = new Regex("[^0-9.-]");
            Regex regex2 = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex regex3 = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            string str = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            string str2 = "^([-]|[0-9])[0-9]*$";
            Regex regex4 = new Regex("(" + str + ")|(" + str2 + ")");
            return (((!regex.IsMatch(strtext) && !regex2.IsMatch(strtext)) && !regex3.IsMatch(strtext)) && regex4.IsMatch(strtext));
        }

        public static void NumberAccpter(object sender, KeyPressEventArgs e, bool point)
        {
            int keyChar = e.KeyChar;
            if ((((keyChar >= 0x30) && (keyChar <= 0x39)) || (keyChar == 8)) || (keyChar == 0x2e))
            {
                if (!(point || (keyChar != 0x2e)))
                {
                    e.Handled = true;
                }
                else
                {
                    string text = "";
                    if ((sender != null) && (sender is TextBox))
                    {
                        text = ((TextBox) sender).Text;
                    }
                    if ((text == "") && (keyChar == 0x2e))
                    {
                        e.Handled = true;
                    }
                    else if ((text.IndexOf(".") >= 0) && (keyChar == 0x2e))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}

