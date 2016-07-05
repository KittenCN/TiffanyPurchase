using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace BHair.Business 
{
    public delegate void MyDelegate(string text);
    public partial class Login : Form
    {
        public static Business.BaseData.Users LoginUser = new Business.BaseData.Users();
        public event MyDelegate MyEvent;
        public Login()
        {
            InitializeComponent();
            LoginUser = new Business.BaseData.Users();
        }


        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {          
            //用户名 txtName.Text  密码 txtPwd.Text
            string UID = txtName.Text.Trim();
            string Pwd = GetSHA1(txtPwd.Text.Trim());
            try
            {
                DataTable UserDT = LoginUser.Login(UID, Pwd);

                if (UserDT.Rows.Count > 0)
                {
                    if (UserDT.Rows[0]["IsAble"].ToString() == "0")
                    {
                        MessageBox.Show("用户已被冻结", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        LoginUser.Character = (int)UserDT.Rows[0]["Character"];
                        LoginUser.EmployeeID = UserDT.Rows[0]["EmployeeID"].ToString();
                        LoginUser.UID = UserDT.Rows[0]["UID"].ToString();
                        LoginUser.UserName = UserDT.Rows[0]["UserName"].ToString();
                        LoginUser.Position = UserDT.Rows[0]["Position"].ToString();
                        LoginUser.IsAdmin = (int)UserDT.Rows[0]["IsAdmin"];
                        LoginUser.MoneyUnit = (int)UserDT.Rows[0]["MoneyUnit"];
                        LoginUser.TotalAmount = double.Parse(UserDT.Rows[0]["TotalAmount"].ToString());
                        LoginUser.RestAmount = double.Parse(UserDT.Rows[0]["RestAmount"].ToString());
                        LoginUser.UsedAmount = double.Parse(UserDT.Rows[0]["UsedAmount"].ToString());
                        LoginUser.ManagerID = UserDT.Rows[0]["ManagerID"].ToString();
                        LoginUser.Store = UserDT.Rows[0]["Store"].ToString();


                        EmailControl.users.UsersDT = EmailControl.users.SelectAllUsers("");
                        DataTable configDT = EmailControl.config.GetConfig();
                        if (configDT.Rows != null && configDT.Rows.Count > 0)
                        {
                            EmailControl.config.EmailID = configDT.Rows[0]["EmailID"].ToString();
                            EmailControl.config.EmailPwd = configDT.Rows[0]["EmailPwd"].ToString();
                            EmailControl.config.EmailAddress = configDT.Rows[0]["EmailAddress"].ToString();
                            EmailControl.config.EmailSMTP = configDT.Rows[0]["EmailSMTP"].ToString();
                            EmailControl.config.CNY = decimal.Parse(configDT.Rows[0]["CNY"].ToString());
                            EmailControl.config.HKD = decimal.Parse(configDT.Rows[0]["HKD"].ToString());
                            EmailControl.config.USD = decimal.Parse(configDT.Rows[0]["USD"].ToString());
                            EmailControl.config.USrate = decimal.Parse(configDT.Rows[0]["USrate"].ToString());
                            EmailControl.config.HKrate = decimal.Parse(configDT.Rows[0]["HKrate"].ToString());
                        }
                        this.DialogResult = DialogResult.OK;
                        //this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("登陆失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
           
        }

        string GetSHA1(string mystr)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();

            //将mystr转换成byte[]
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(mystr);

            //Hash运算
            byte[] dataHashed = sha.ComputeHash(dataToHash);

            //将运算结果转换成string
            string hash = BitConverter.ToString(dataHashed).Replace("-", "");

            return hash;
        }
    }
}
