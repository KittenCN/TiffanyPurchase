namespace XLuSharpLibrary.CommonFunction
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordClass
    {
        public static string EncryptMD5(string strtext)
        {
            MD5 md = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md.ComputeHash(Encoding.UTF8.GetBytes(strtext))).Replace("-", "");
        }
    }
}

