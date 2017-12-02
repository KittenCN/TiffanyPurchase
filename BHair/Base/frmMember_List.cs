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

namespace BHair.Base
{
    public partial class frmMember_List : WinFormsUI.Docking.DockContent
    {
        Users user = new Users();
        public DataTable ApplicationInfoTable;
        public frmMember_List()
        {
            InitializeComponent();
        }

        private void frmMember_List_Load(object sender, EventArgs e)
        {
            this.LoadMemberList();
            if (Login.LoginUser.Character == 7)
            {
                button1.Enabled = false;
                btnPermission.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        /// <summary>加载用户信息列表。</summary>
        public void LoadMemberList()
        {
            user.UsersDT = user.SelectAllUsers("");
            user.UsersDT.Columns.Add("selected", typeof(Int32));
            ApplicationInfoTable = user.UsersDT;
            dgvMember.AutoGenerateColumns = false;
            dgvMember.DataSource = user.UsersDT;
        }

        private void txtMember_TextChanged(object sender, EventArgs e)
        {
            string sql = string.Format(" and ([UserName] like '%{0}%' or [UID] like '%{0}%' or [EmployeeID] like '%{0}%')", txtMember.Text);
            user.UsersDT = user.SelectAllUsers(sql);
            user.UsersDT.Columns.Add("selected", typeof(Int32));
            ApplicationInfoTable = user.UsersDT;
            dgvMember.DataSource = user.UsersDT;
            //this.LoadMemberList();
        }

        /// <summary>新增用户</summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMember objfrmMember = new frmMember();
            if (objfrmMember.ShowDialog() == DialogResult.OK)
            {
                this.LoadMemberList();
            }
        }

        #region 编辑用户信息...

        /// <summary>编辑用户</summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            this.ShowMember();
        }

        /// <summary>双击编辑用户信息</summary>
        private void dgvMember_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.ShowMember();
            }
        }

        private void ShowMember()
        {
            if (this.dgvMember.CurrentRow != null)
            {
                string strMemberId = this.dgvMember.CurrentRow.Cells["UID"].Value.ToString();
                if (strMemberId != "Administrator" || Login.LoginUser.IsAdmin == 1)
                {
                    frmMember objfrmMember = new frmMember(strMemberId);
                    if (objfrmMember.ShowDialog() == DialogResult.OK)
                    {
                        this.LoadMemberList();
                    }
                }
            }
        }

        #endregion


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
                    case "5": e.Value = "HR"; break;
                    case "6": e.Value = "财务"; break;
                    case "7": e.Value = "IT Help"; break;
                    default:
                        e.Value = "无";
                        break;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("是否删除该用户", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (this.dgvMember.CurrentRow != null)
            {
                string CurrentUID = dgvMember.CurrentRow.Cells["UID"].Value.ToString();
                string CurrentID = dgvMember.CurrentRow.Cells["ID"].Value.ToString();
                if (CurrentUID != "Administrator")
                {
                    try
                    {
                        user.DeleteUser(CurrentID);
                        MessageBox.Show("已删除该用户", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMemberList();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("删除失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgvMember_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvMember.Rows)
            {
                if (dgvr.Cells["MoneyUnit"] != null && dgvr.Cells["MoneyUnit"].Value != null && dgvr.Cells["MoneyUnit"].Value.ToString() != "")
                {
                    //if ((int)dgvr.Cells["MoneyUnit"].Value == 1) dgvr.Cells["MoneyUnitState"].Value = "人民币";
                    //else if ((int)dgvr.Cells["MoneyUnit"].Value == 2) dgvr.Cells["MoneyUnitState"].Value = "美元";
                    //else dgvr.Cells["MoneyUnitState"].Value = "港币";
                    switch ((int)dgvr.Cells["MoneyUnit"].Value)
                    {
                        case 1:
                            dgvr.Cells["MoneyUnitState"].Value = "人民币";
                            break;
                        case 2:
                            dgvr.Cells["MoneyUnitState"].Value = "美元";
                            break;
                        case 3:
                            dgvr.Cells["MoneyUnitState"].Value = "港币";
                            break;
                        case 4:
                            dgvr.Cells["MoneyUnitState"].Value = "澳元";
                            break;
                        case 5:
                            dgvr.Cells["MoneyUnitState"].Value = "新元";
                            break;
                        case 6:
                            dgvr.Cells["MoneyUnitState"].Value = "马币";
                            break;
                        case 7:
                            dgvr.Cells["MoneyUnitState"].Value = "英镑";
                            break;
                        case 8:
                            dgvr.Cells["MoneyUnitState"].Value = "欧元";
                            break;
                        case 9:
                            dgvr.Cells["MoneyUnitState"].Value = "日元";
                            break;
                        case 10:
                            dgvr.Cells["MoneyUnitState"].Value = "台币";
                            break;
                        default:
                            dgvr.Cells["MoneyUnitState"].Value = "人民币";
                            break;
                    }
                }
                if (dgvr.Cells["IsAble"] != null && dgvr.Cells["IsAble"].Value != null && dgvr.Cells["IsAble"].Value.ToString() != "")
                {
                    if ((int)dgvr.Cells["IsAble"].Value == 1) dgvr.Cells["ShowIsAble"].Value = "可用";
                    else if ((int)dgvr.Cells["IsAble"].Value == 2) dgvr.Cells["ShowIsAble"].Value = "不可用";
                    else dgvr.Cells["ShowIsAble"].Value = "不可用";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMember_Import objfrmMember_Import = new frmMember_Import();
            if (objfrmMember_Import.ShowDialog() == DialogResult.OK)
            {
                this.LoadMemberList();
            }
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            frmMember_EmployeeID objfrmMember_EmployeeID = new frmMember_EmployeeID();
            if (objfrmMember_EmployeeID.ShowDialog() == DialogResult.OK)
            {
                this.LoadMemberList();
            }
        }

        private void btnOutEmpInfo_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            //点了保存按钮进入
            if (result == DialogResult.OK)
            {
                //获得文件路径
                string localFilePath = saveFileDialog.FileName.ToString();
                ExcelHelper eh = new ExcelHelper();
                try
                {
                    eh.boolOutEmpInfo(localFilePath, ApplicationInfoTable);
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAllForzen_Click(object sender, EventArgs e)
        {
            //int successRows = 0;
            //foreach (DataRow dr in ApplicationInfoTable.Rows)
            //{
            //    if (dr["selected"].ToString() == "1")
            //    {
            //        //successRows += applicationInfo.ApprovalApplication(dr["TransNo"].ToString(), Login.LoginUser, 1, DateTime.Now);
            //        successRows++;
            //    }
            //}
            //MessageBox.Show("审批通过" + successRows + "条", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BHair.Business.Table.frmMember_MassSetting.dt = user.UsersDT;
            frmMember_MassSetting fmms = new Base.frmMember_MassSetting();
            if (fmms.ShowDialog() == DialogResult.OK)
            {
                this.LoadMemberList();
            }

        }
        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvMember.CurrentCell.RowIndex;
            if (dgvMember.Rows.Count > 0 && dgvMember.SelectedRows.Count > 0)
            {

            }
        }
    }
}
