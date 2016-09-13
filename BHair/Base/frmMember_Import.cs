using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.BaseData;
using BHair.Business;
using BHair.Business.Table;
using System.IO;
using System.Drawing.Printing;
using System.Security.Cryptography;

namespace BHair.Base
{
    public partial class frmMember_Import : WinFormsUI.Docking.DockContent
    {
        Users users = new Users();
        DataTable memberDT = new DataTable();
        DataTable MemberDT = new DataTable();
        string sha1pwd;
        string filePath;
        public frmMember_Import()
        {
            InitializeComponent();
        }


        /// <summary>加载用户信息列表。</summary>
        public void LoadMemberList()
        {
            //user.UsersDT=user.SelectAllUsers("");
            //dgvMember.AutoGenerateColumns = false;
            //dgvMember.DataSource = user.UsersDT;


        }




        private void ShowMember()
        {
            if (this.dgvMember.CurrentRow != null)
            {
                string strMemberId = this.dgvMember.CurrentRow.Cells["UID"].Value.ToString();
                frmMember objfrmMember = new frmMember(strMemberId);
                if (objfrmMember.ShowDialog() == DialogResult.OK)
                {
                    this.LoadMemberList();
                }
            }
        }




        private void dgvMember_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            StaticValue.ShowRows_DataGridView_RowPostPaint(this.dgvMember, sender, e);
        }

        private void dgvMember_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMember.Columns[e.ColumnIndex].Name == "Character")
            {
                string str = e.Value.ToString();
                switch (str)
                {
                    case "1": e.Value = "商品部"; break;
                    case "2": e.Value = "经理"; break;
                    case "3": e.Value = "员工"; break;
                    case "4": e.Value = "店面"; break;
                    default:
                        e.Value = "无";
                        break;
                }
            }
        }


        private void dgvMember_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvMember.Rows)
            {
                if (dgvr.Cells["MoneyUnit"] != null && dgvr.Cells["MoneyUnit"].Value != null && dgvr.Cells["MoneyUnit"].Value.ToString() != "")
                {
                    if ((int)dgvr.Cells["MoneyUnit"].Value == 1) dgvr.Cells["MoneyUnitState"].Value = "人民币";
                    else if ((int)dgvr.Cells["MoneyUnit"].Value == 2) dgvr.Cells["MoneyUnitState"].Value = "美元";
                    else dgvr.Cells["MoneyUnitState"].Value = "港币";
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text == "")
            {
                MessageBox.Show("请填写用户默认密码", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel文件|*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sha1pwd = GetSHA1(txtPwd.Text.Trim());
                        label1.Text = "正在导入Excel数据....";
                        filePath = openFileDialog.FileName;
                        DataTable resultDT = users.SelectUsersByUID("");
                        DataTable sourceDT = users.SelectAllUsers("");
                        resultDT.Clear();
                        ExcelHelper eh = new ExcelHelper();
                        memberDT = eh.ExcelToDataTable_Member(filePath, resultDT, sha1pwd);
                        MemberDT = resultDT.Clone();

                        foreach (DataRow dr in memberDT.Rows)
                        {

                            Business.BaseData.Store stores = new Business.BaseData.Store();
                            stores.StoreDT = stores.SelectAllStoreInfo();

                            //上属经理
                            Boolean boolFlag = true;
                            foreach (DataRow drUsers in memberDT.Rows)
                            {
                                if (dr["ManagerID"].ToString() == drUsers["UID"].ToString() && dr["UID"].ToString() != "Administrator")
                                {
                                    //所属店铺
                                    if (dr["Character"].ToString() == "4")
                                    {
                                        foreach (DataRow drStore in stores.StoreDT.Rows)
                                        {
                                            if (dr["Store"].ToString() == drStore["StoreName"].ToString())
                                            {
                                                MemberDT.Rows.Add(dr.ItemArray);
                                                boolFlag = false;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MemberDT.Rows.Add(dr.ItemArray);
                                        boolFlag = false;
                                        break;
                                    }

                                }
                            }
                            if (boolFlag)
                            {
                                Boolean boolFlag2 = true;
                                foreach (DataRow drUsers in sourceDT.Rows)
                                {
                                    if (dr["ManagerID"].ToString() == drUsers["UID"].ToString() && dr["UID"].ToString() != "Administrator")
                                    {
                                        //所属店铺
                                        if (dr["Character"].ToString() == "4")
                                        {
                                            foreach (DataRow drStore in stores.StoreDT.Rows)
                                            {
                                                if (dr["Store"].ToString() == drStore["StoreName"].ToString())
                                                {
                                                    MemberDT.Rows.Add(dr.ItemArray);
                                                    boolFlag2 = false;
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MemberDT.Rows.Add(dr.ItemArray);
                                            boolFlag2 = false;
                                            break;
                                        }
                                    }
                                }
                                //所属店铺
                                if (dr["Character"].ToString() == "4" && boolFlag2)
                                {
                                    foreach (DataRow drStore in stores.StoreDT.Rows)
                                    {
                                        if (dr["Store"].ToString() == drStore["StoreName"].ToString())
                                        {
                                            MemberDT.Rows.Add(dr.ItemArray);
                                            break;
                                        }
                                    }
                                }
                            }

                            }

                        dgvMember.AutoGenerateColumns = false;
                        dgvMember.DataSource = MemberDT;
                        label1.Text = "Excel数据导入完成";
                    }
                    catch (Exception ex)
                    {
                        label1.Text = "Excel数据导入失败";
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            label1.Text = "正在覆盖到数据库....";
            try
            {

                //清空表
                users.ClearUsers();
                //插入新datatable表
                users.QuickImportUsers(MemberDT);
                label1.Text = "数据库覆盖完成";
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                label1.Text = "数据库覆盖失败::" + ex.ToString();
            }
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            label1.Text = "正在插入到数据库....";
            try
            {

                //清空表
                users.ClearUsers();
                //插入新datatable表
                users.QuickInsertUser(MemberDT);
                label1.Text = "数据库插入完成";
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                label1.Text = "数据库插入失败::" + ex.ToString();
            }
        }
    }
}
