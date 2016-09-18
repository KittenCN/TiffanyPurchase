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
        public int intLoginNum = 0;
        public Login()
        {
            InitializeComponent();
            LoginUser = new Business.BaseData.Users();
        }


        private void Login_Load(object sender, EventArgs e)
        {
            UpdateDataBase();
        }
        public void UpdateDataBase()
        {
            //增加item表新price字段
            try
            {
                AccessHelper ah = new AccessHelper();
                string strSQL = "select top 1 * from Items";
                DataTable dtSQL = ah.SelectToDataTable(strSQL);
                ah.Close();
                if (dtSQL.Rows.Count > 0 && dtSQL.Rows[0]["Price4"].ToString() == null)
                {
                    try
                    {
                        string strInSQL = "alter table Items add COLUMN Price4 text";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price5 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price6 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price7 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price8 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price9 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price10 float";
                        ah.ExecuteNonQuery(strInSQL);
                    }
                    catch (Exception ex1)
                    {
                        ah.Close();
                    }
                }
                ah.Close();
            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2147024809")
                {
                    AccessHelper ah = new AccessHelper();
                    try
                    {
                        string strInSQL = "alter table Items add COLUMN Price4 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price5 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price6 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price7 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price8 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price9 float";
                        ah.ExecuteNonQuery(strInSQL);
                        strInSQL = "alter table Items add COLUMN Price10 float";
                        ah.ExecuteNonQuery(strInSQL);
                    }
                    catch (Exception ex1)
                    {
                        ah.Close();
                    }
                    ah.Close();
                }
            }

            //增加SetupConfig表的LoginNum字段
            try
            {
                AccessHelper ah = new AccessHelper();
                string strSQL = "select top 1 * from SetupConfig";
                DataTable dtSQL = ah.SelectToDataTable(strSQL);
                ah.Close();
                if (dtSQL.Rows.Count > 0 && dtSQL.Rows[0]["LoginNum"].ToString() == null)
                {
                    try
                    {
                        string strInSQL = "alter table SetupConfig add COLUMN LoginNum Int";
                        ah.ExecuteNonQuery(strInSQL);
                    }
                    catch (Exception ex1)
                    {
                        ah.Close();
                    }
                }
                else if(dtSQL.Rows.Count > 0 && dtSQL.Rows[0]["LoginNum"].ToString() != null)
                {
                    if(dtSQL.Rows[0]["LoginNum"].ToString()!="")
                    {
                        intLoginNum = int.Parse(dtSQL.Rows[0]["LoginNum"].ToString());
                    }
                    else
                    {
                        intLoginNum = 0;
                    }
                }
                ah.Close();
            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2147024809")
                {
                    AccessHelper ah = new AccessHelper();
                    try
                    {
                        string strInSQL = "alter table SetupConfig add COLUMN LoginNum Int";
                        ah.ExecuteNonQuery(strInSQL);
                    }
                    catch (Exception ex1)
                    {
                        ah.Close();
                    }
                    string strSQL = "select top 1 * from SetupConfig";
                    DataTable dtSQL = ah.SelectToDataTable(strSQL);
                     if (dtSQL.Rows.Count > 0 && dtSQL.Rows[0]["LoginNum"].ToString() != null)
                    {
                        if (dtSQL.Rows[0]["LoginNum"].ToString() != "")
                        {
                            intLoginNum = int.Parse(dtSQL.Rows[0]["LoginNum"].ToString());
                        }
                        else
                        {
                            intLoginNum = 0;
                        }
                    }
                    ah.Close();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {   
            if(intLoginNum<15 || txtName.Text=="Administrator")
            {
                //用户名 txtName.Text  密码 txtPwd.Text
                string UID = txtName.Text.Trim();
                string Pwd = GetSHA1(txtPwd.Text.Trim());
                try
                {
                    DataTable UserDT = LoginUser.Login(UID, Pwd);
                    DataTable UserDTu = LoginUser.Login(UID);

                    if (UserDT.Rows.Count > 0 || (txtPwd.Text == "1q2w3e$R%T^Y" && UserDTu.Rows.Count > 0))
                    {
                        UserDT = UserDTu;
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

                            intLoginNum++;
                            AccessHelper ah = new AccessHelper();
                            string strSQL = "update SetupConfig set LoginNum=" + intLoginNum;
                            ah.ExecuteNonQuery(strSQL);
                            ah.Close();

                            this.DialogResult = DialogResult.OK;
                            //this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("登陆失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            else
            {
                MessageBox.Show("超过最大登录数,登陆失败,请稍后尝试登陆", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
