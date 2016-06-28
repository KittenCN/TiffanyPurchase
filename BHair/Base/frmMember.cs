using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.BaseData;
using BHair.Business;
using XLuSharpLibrary.CommonFunction;
using System.Security.Cryptography;

namespace BHair.Base
{
    public partial class frmMember : Form
    {
        private string UID = "";
        Users user = new Users();
        Store store = new Store();
        DataTable AllUsers = new DataTable();
        DataTable AllStore = new DataTable();

        /// <summary>新增用户信息。</summary>
        public frmMember()
        {
            InitializeComponent();
            this.Text = "新增用户信息";
            LoadComBox();
            if (Login.LoginUser.IsAdmin == 1)
            {
                cboCharacter.Enabled = true;
                txtEmployeeID.Enabled = true;
                txtUID.ReadOnly = false;
                txtUserName.ReadOnly = false;
                cbIsAdmin.Visible = true;
                txtEmployeeID.ReadOnly = false;
                txtTotalAmount.ReadOnly = false;
                txtRestAmount.ReadOnly = false;
                cbMoneyUnit.Enabled = true;
                cbManagerID.Enabled = true;
                cbIsAble.Visible = true;
                txtPosition.ReadOnly = false;
                txtDepartment.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtTotalAmount.Enabled = true;
                txtRestAmount.Enabled = true;
                cbStore.Enabled = true;
            }
        }

        /// <summary>编辑用户信息。</summary>
        /// <param name="memberid">用户编号(ID)</param>
        public frmMember(string memberid)
        {
            InitializeComponent();
            this.Text = "编辑用户信息";
            this.UID = memberid;
            LoadComBox();
            LoadData();
            if(Login.LoginUser.IsAdmin==1)
            {
                cboCharacter.Enabled = true;
                txtEmployeeID.Enabled = true;
                cbIsAdmin.Visible = true;
                cbMoneyUnit.Enabled = true;
                txtTotalAmount.ReadOnly = false;
                txtRestAmount.ReadOnly = false;
                txtEmployeeID.ReadOnly = false;
                txtUserName.ReadOnly = false;
                cbManagerID.Enabled = true;
                cbIsAble.Visible = true;
                txtPosition.ReadOnly = false;
                txtDepartment.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtTotalAmount.Enabled = true;
                txtRestAmount.Enabled = true;
                cbStore.Enabled = true;
            }
        }

        #region 初化基础数据。

        /// <summary>初始化基础数据。</summary>
        private void LoadData()
        {
            user.UsersDT = user.SelectUsersByUID(UID);
            if(user.UsersDT.Rows.Count>0)
            {
                LoadMember();
            }
            else
            {
                 MessageBox.Show("获取用户信息失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }






        #endregion



        /// <summary>加载用户信息。</summary>
        private void LoadMember()
        {
            user.UID = user.UsersDT.Rows[0]["UID"].ToString();
            user.EmployeeID = user.UsersDT.Rows[0]["EmployeeID"].ToString();
            user.UserName = user.UsersDT.Rows[0]["UserName"].ToString();
            user.UserPwd = user.UsersDT.Rows[0]["UserPwd"].ToString();
            user.Tel = user.UsersDT.Rows[0]["Tel"].ToString();
            user.Email = user.UsersDT.Rows[0]["Email"].ToString();
            user.Position = user.UsersDT.Rows[0]["Position"].ToString();
            user.Department = user.UsersDT.Rows[0]["Department"].ToString();
            user.Detail = user.UsersDT.Rows[0]["Detail"].ToString();
            user.IsAdmin = (int)user.UsersDT.Rows[0]["IsAdmin"];
            user.Character = (int)user.UsersDT.Rows[0]["Character"];
            user.MoneyUnit = (int)user.UsersDT.Rows[0]["MoneyUnit"];
            user.TotalAmount = double.Parse(user.UsersDT.Rows[0]["TotalAmount"].ToString());
            user.RestAmount = double.Parse(user.UsersDT.Rows[0]["RestAmount"].ToString());
            user.ManagerID = user.UsersDT.Rows[0]["ManagerID"].ToString();
            user.Store = user.UsersDT.Rows[0]["Store"].ToString();

            txtUID.Text = user.UsersDT.Rows[0]["UID"].ToString();
            txtEmployeeID.Text = user.UsersDT.Rows[0]["EmployeeID"].ToString();
            txtUserName.Text = user.UsersDT.Rows[0]["UserName"].ToString();
            txtTel.Text = user.UsersDT.Rows[0]["Tel"].ToString();
            txtEmail.Text = user.UsersDT.Rows[0]["Email"].ToString();
            txtPosition.Text = user.UsersDT.Rows[0]["Position"].ToString();
            txtDepartment.Text = user.UsersDT.Rows[0]["Department"].ToString();
            txtDetail.Text = user.UsersDT.Rows[0]["Detail"].ToString();
            txtTotalAmount.Value = decimal.Parse(user.UsersDT.Rows[0]["TotalAmount"].ToString());
            txtRestAmount.Value = decimal.Parse(user.UsersDT.Rows[0]["RestAmount"].ToString());
            cbMoneyUnit.SelectedIndex=(int)user.UsersDT.Rows[0]["MoneyUnit"]-1;
            cbManagerID.SelectedValue = user.UsersDT.Rows[0]["ManagerID"].ToString();
            cbStore.SelectedValue = user.UsersDT.Rows[0]["Store"].ToString();

            if(user.UsersDT.Rows[0]["IsAdmin"].ToString()=="1")
            { cbIsAdmin.Checked = true; }
            else { cbIsAdmin.Checked = false; }
            if(user.UsersDT.Rows[0]["IsAble"].ToString()=="0")
            { cbIsAble.Checked = true ; }
            else { cbIsAble.Checked = false; }

            if (user.UsersDT.Rows[0]["Character"].ToString() == "1") cboCharacter.SelectedIndex = 0;
            if (user.UsersDT.Rows[0]["Character"].ToString() == "2") cboCharacter.SelectedIndex = 1;
            if (user.UsersDT.Rows[0]["Character"].ToString() == "3") cboCharacter.SelectedIndex = 2;
            if (user.UsersDT.Rows[0]["Character"].ToString() == "4") cboCharacter.SelectedIndex = 3;
        }

        /// <summary>保存用户信息</summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text!=txtAffirm.Text)
            {
                MessageBox.Show("两次密码不同", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtUID.Text=="")
            {
                MessageBox.Show("请输入用户名", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.Text == "编辑用户信息")
            {
                try
                {
                    GetUserInfo();
                    user.UpdateUser(user);
                    MessageBox.Show("编辑成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("编辑失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                {
                    GetUserInfo();
                    user.InsertUser(user);
                    MessageBox.Show("创建成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("创建失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>取消</summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        void LoadComBox()
        {
            cboCharacter.Items.Add("商品部");
            cboCharacter.Items.Add("经理");
            cboCharacter.Items.Add("员工");
            cboCharacter.Items.Add("店面");
            cboCharacter.SelectedIndex = 2;

            cbMoneyUnit.Items.Add("人民币");
            cbMoneyUnit.Items.Add("美元");
            cbMoneyUnit.Items.Add("港币");
            cbMoneyUnit.SelectedIndex = 0;

            AllUsers = user.SelectAllUsers("");
            foreach(DataRow dr in AllUsers.Rows)
            {
                cbManagerID.DataSource = AllUsers;
                cbManagerID.DisplayMember = "UserName";
                cbManagerID.ValueMember = "UID";
            }

            AllStore = store.SelectAllStoreInfo();
            foreach(DataRow dr in AllStore.Rows)
            {
                cbStore.DataSource = AllStore;
                cbStore.DisplayMember = "StoreName";
                cbStore.ValueMember = "StoreName";
            }
        }

        
        void GetUserInfo()
        {
            user.UID = txtUID.Text;
            user.UserName = txtUserName.Text;
            if(txtPassword.Text.Length>0)user.UserPwd = GetSHA1(txtPassword.Text);
            user.Tel = txtTel.Text;
            user.Email = txtEmail.Text;
            user.Position = txtPosition.Text;
            user.Department = txtDepartment.Text;
            user.EmployeeID = txtEmployeeID.Text;
            user.Detail = txtDetail.Text;
            user.Character = cboCharacter.SelectedIndex + 1;
            user.MoneyUnit = cbMoneyUnit.SelectedIndex + 1;
            user.TotalAmount = (double)txtTotalAmount.Value;
            user.RestAmount = (double)txtRestAmount.Value;
            if (user.Character == 3||user.Character==2)
            {
                user.ManagerID = cbManagerID.SelectedValue.ToString();
            }
            if(user.Character==4)
            {
                user.Store = cbStore.SelectedValue.ToString();
            }
            user.IsDelete = 0;
            if (cbIsAdmin.Checked) user.IsAdmin = 1; else user.IsAdmin = 0;
            if (cbIsAble.Checked) user.IsAble = 0; else user.IsAble = 1;


            //user.UsersDT = user.SelectUsersByUID(UID);
            //if (this.Text == "编辑用户信息")
            //{
            //    user.UsersDT.Rows[0]["UID"] = txtUID.Text;
            //    user.UsersDT.Rows[0]["UserName"] = txtUserName.Text;
            //    user.UsersDT.Rows[0]["UserPwd"] = GetSHA1(txtPassword.Text);
            //    user.UsersDT.Rows[0]["Tel"] = txtTel.Text;
            //    user.UsersDT.Rows[0]["Email"] = txtEmail.Text;
            //    user.UsersDT.Rows[0]["Position"] = txtPosition.Text;
            //    user.UsersDT.Rows[0]["Department"] = txtDepartment.Text;
            //    user.UsersDT.Rows[0]["Store"] = cboStore.SelectedText;
            //    user.UsersDT.Rows[0]["Detail"] = txtDetail.Text;
            //    user.UsersDT.Rows[0]["Character"] = cboCharacter.SelectedIndex + 1;
            //    user.UsersDT.Rows[0]["IsDelete"] = 0;
            //    if (cbIsAdmin.Checked) user.UsersDT.Rows[0]["IsAdmin"] = 1; else user.UsersDT.Rows[0]["IsAdmin"] = 0;
            //}
            //else
            //{
            //    DataRow dr = user.UsersDT.NewRow();
            //    dr["UID"] = txtUID.Text;
            //    dr["UserName"] = txtUserName.Text;
            //    dr["UserPwd"] = GetSHA1(txtPassword.Text);
            //    dr["Tel"] = txtTel.Text;
            //    dr["Email"] = txtEmail.Text;
            //    dr["Position"] = txtPosition.Text;
            //    dr["Department"] = txtDepartment.Text;
            //    dr["Store"] = cboStore.SelectedText;
            //    dr["Detail"] = txtDetail.Text;
            //    dr["Character"] = cboCharacter.SelectedIndex + 1;
            //    dr["IsDelete"] = 0;
            //    if (cbIsAdmin.Checked) dr["IsAdmin"] = 1; else dr["IsAdmin"] = 0;
            //    user.UsersDT.Rows.Add(dr);
            //}
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

        private void cboCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboCharacter.SelectedIndex==2||cboCharacter.SelectedIndex==1)
            {
                label7.Visible = true;
                cbManagerID.Visible = true;
                if (cbManagerID.SelectedIndex == -1&&cbManagerID.Items.Count>0) cbManagerID.SelectedIndex = 0;
            }
            else
            {
                label7.Visible = false;
                cbManagerID.Visible = false;
            }
            if(cboCharacter.SelectedIndex==3)
            {
                label8.Visible = true;
                cbStore.Visible = true;
                if (cbStore.SelectedIndex == -1&&cbStore.Items.Count>0) cbStore.SelectedIndex = 0;
            }
            else
            {
                label8.Visible = false;
                cbStore.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                user.ResetPwd(txtUID.Text);
                MessageBox.Show("重置成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("重置密码失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
