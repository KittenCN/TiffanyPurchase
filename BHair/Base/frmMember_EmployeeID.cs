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
    public partial class frmMember_EmployeeID : WinFormsUI.Docking.DockContent
    {
        Users users = new Users();
        DataTable employeeIDDT = new DataTable();
        DataTable MemberDT = new DataTable();
        string filePath;
        public frmMember_EmployeeID()
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

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel文件|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    label1.Text = "正在导入Excel数据....";
                    filePath = openFileDialog.FileName;
                    DataTable resultDT = users.SelectAllUsers("");
                    ExcelHelper eh = new ExcelHelper();
                    employeeIDDT = eh.ExcelToDataTable_EmployeeID(filePath);
                    MemberDT = resultDT.Clone();

                    foreach (DataRow dr in employeeIDDT.Rows)
                    {
                        foreach (DataRow drUsers in resultDT.Rows)
                            {
                                if (dr["EmployeeID"].ToString() == drUsers["EmployeeID"].ToString())
                                {
                                    drUsers["IsAble"] = 1;
                                    MemberDT.Rows.Add(drUsers.ItemArray);
                                }
                            }
                    }

                    dgvMember.AutoGenerateColumns = false;
                    dgvMember.DataSource = MemberDT;
                    label1.Text = "Excel数据导入完成";
                }
                catch
                {
                    label1.Text = "Excel数据导入失败";
                }
            }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            label1.Text = "正在导入到数据库....";
            try
            {
                //插入新datatable表
                users.UpdateEmployeeID(MemberDT);
                label1.Text = "数据库导入完成";
                DialogResult = DialogResult.OK;
            }
            catch
            {
                label1.Text = "数据库导入失败";
            }
        }


     
    }
}
