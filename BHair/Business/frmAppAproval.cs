using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.Table;
using System.Text.RegularExpressions;

namespace BHair.Business
{
    public partial class frmAppAproval : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationInfoTable;
        public DataRow ApplicationInfoRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
        public string CtrlID = "";
        string SelectStr = "and 1=1";
        string CtrlType = "未审核";
        /// <summary>商品部申请单状态</summary>
        public frmAppAproval()
        {
            InitializeComponent();
            GetApplicationDetail();
            cbCtrlType.Items.Add("未审核");
            cbCtrlType.Items.Add("已生成唯一码未购买");
            cbCtrlType.Items.Add("最终确认");
            cbCtrlType.Items.Add("全部");
            cbCtrlType.SelectedIndex = 0;
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            ApplicationInfoTable = new DataTable();
            
            switch (CtrlType)
            {
                case "未审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApproval(""); break;
                case "最终确认": ApplicationInfoTable = applicationInfo.SelectNotPassedApplication(""); break;
                case "已生成唯一码未购买": ApplicationInfoTable = applicationInfo.SelectUnCodedApplication(""); break;
                case "全部": ApplicationInfoTable = applicationInfo.SelectAllApplication(""); break;
                default: ApplicationInfoTable = applicationInfo.SelectApplicationByApproval(""); break;
            }
            dgvApplyInfo.AutoGenerateColumns = false;
            dgvApplyInfo.DataSource = ApplicationInfoTable;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (applicationInfo.TransNo != null)
            {
                frmAppApprovalDetail faad = new frmAppApprovalDetail(applicationInfo,CtrlType);
                if (faad.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
            else
            {
                MessageBox.Show("请选择一行记录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtChoose_TextChanged(object sender, EventArgs e)
        {
            if (TxtChoose.Text != "")
            {
                SelectStr = string.Format("and 1=1 and( TransNo='{0}' or ApplicantsNo='{0}' or PurchaseLocation='{0}' or ApplicantsName='{0}')", TxtChoose.Text);
            }
        }

        private void dgvApplyInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvApplyInfo.CurrentCell.RowIndex;
            if (dgvApplyInfo.RowCount > 0 && dgvApplyInfo.SelectedRows.Count>0)
            {
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value > 0) txtApprovalState2.Text = "通过"; else txtApprovalState2.Text = "未审批";
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value >= 2) txtApprovalState.Text = "通过"; else txtApprovalState.Text = "未审批";
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value >= 4) txtApprovalState3.Text = "通过"; else txtApprovalState3.Text = "未审批";
                if (dgvApplyInfo.SelectedRows[0].Cells["UnCode"].Value != null) txtUnCode.Text = dgvApplyInfo.SelectedRows[0].Cells["UnCode"].Value.ToString();
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value > 5) txtStaffApproval.Text = "已确认"; else txtStaffApproval.Text = "未确认";
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value == 9) txtFinish.Text = "已完成"; else txtFinish.Text = "未完成";

                applicationInfo.TransNo = dgvApplyInfo.SelectedRows[0].Cells["TransNo"].Value.ToString();
                applicationInfo.Applicants = dgvApplyInfo.SelectedRows[0].Cells["Applicants"].Value.ToString();
                applicationInfo.ApplicantsNo = dgvApplyInfo.SelectedRows[0].Cells["ApplicantsNo"].Value.ToString();
                applicationInfo.ApplicantsName = dgvApplyInfo.SelectedRows[0].Cells["ApplicantsName"].Value.ToString();
                applicationInfo.ApplicantsDate = dgvApplyInfo.SelectedRows[0].Cells["ApplicantsDate"].Value.ToString();
                applicationInfo.Location = dgvApplyInfo.SelectedRows[0].Cells["Location"].Value.ToString();
                applicationInfo.PurchaseLocation = dgvApplyInfo.SelectedRows[0].Cells["PurchaseLocation"].Value.ToString();
                applicationInfo.ApprovalName = dgvApplyInfo.SelectedRows[0].Cells["ApprovalName"].Value.ToString();
                applicationInfo.ApprovalDate = dgvApplyInfo.SelectedRows[0].Cells["ApprovalDate"].Value.ToString();
                applicationInfo.ApprovalName2 = dgvApplyInfo.SelectedRows[0].Cells["ApprovalName2"].Value.ToString();
                applicationInfo.ApprovalDate2 = dgvApplyInfo.SelectedRows[0].Cells["ApprovalDate2"].Value.ToString();
                applicationInfo.StaffName = dgvApplyInfo.SelectedRows[0].Cells["StaffName"].Value.ToString();
                applicationInfo.SalesDate = dgvApplyInfo.SelectedRows[0].Cells["SalesDate"].Value.ToString();
                applicationInfo.AppState = (int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value;
                applicationInfo.EditReason = dgvApplyInfo.SelectedRows[0].Cells["EditReason"].Value.ToString();
                applicationInfo.EditRemark = dgvApplyInfo.SelectedRows[0].Cells["EditRemark"].Value.ToString();
            }
            if(row!=null)
            {
                if ((int)dgvApplyInfo.Rows[row].Cells["AppState"].Value > 0) txtApprovalState2.Text = "通过"; else txtApprovalState2.Text = "未审批";
                if ((int)dgvApplyInfo.Rows[row].Cells["AppState"].Value >= 2) txtApprovalState.Text = "通过"; else txtApprovalState.Text = "未审批";
                if ((int)dgvApplyInfo.Rows[row].Cells["AppState"].Value >= 4) txtApprovalState3.Text = "通过"; else txtApprovalState3.Text = "未审批";
                if (dgvApplyInfo.Rows[row].Cells["UnCode"].Value != null) txtUnCode.Text = dgvApplyInfo.Rows[row].Cells["UnCode"].Value.ToString();
                if ((int)dgvApplyInfo.Rows[row].Cells["AppState"].Value > 5) txtStaffApproval.Text = "已确认"; else txtStaffApproval.Text = "未确认";
                if ((int)dgvApplyInfo.Rows[row].Cells["AppState"].Value == 9) txtFinish.Text = "已完成"; else txtFinish.Text = "未完成";

                applicationInfo.TransNo = dgvApplyInfo.Rows[row].Cells["TransNo"].Value.ToString();
                applicationInfo.Applicants = dgvApplyInfo.Rows[row].Cells["Applicants"].Value.ToString();
                applicationInfo.ApplicantsNo = dgvApplyInfo.Rows[row].Cells["ApplicantsNo"].Value.ToString();
                applicationInfo.ApplicantsName = dgvApplyInfo.Rows[row].Cells["ApplicantsName"].Value.ToString();
                applicationInfo.ApplicantsDate = dgvApplyInfo.Rows[row].Cells["ApplicantsDate"].Value.ToString();
                applicationInfo.Location = dgvApplyInfo.Rows[row].Cells["Location"].Value.ToString();
                applicationInfo.PurchaseLocation = dgvApplyInfo.Rows[row].Cells["PurchaseLocation"].Value.ToString();
                applicationInfo.ApprovalName = dgvApplyInfo.Rows[row].Cells["ApprovalName"].Value.ToString();
                applicationInfo.ApprovalDate = dgvApplyInfo.Rows[row].Cells["ApprovalDate"].Value.ToString();
                applicationInfo.ApprovalName2 = dgvApplyInfo.Rows[row].Cells["ApprovalName2"].Value.ToString();
                applicationInfo.ApprovalDate2 = dgvApplyInfo.Rows[row].Cells["ApprovalDate2"].Value.ToString();
                applicationInfo.StaffName = dgvApplyInfo.Rows[row].Cells["StaffName"].Value.ToString();
                applicationInfo.SalesDate = dgvApplyInfo.Rows[row].Cells["SalesDate"].Value.ToString();
                applicationInfo.AppState = (int)dgvApplyInfo.Rows[row].Cells["AppState"].Value;
                applicationInfo.EditReason = dgvApplyInfo.Rows[row].Cells["EditReason"].Value.ToString();
                applicationInfo.EditRemark = dgvApplyInfo.Rows[row].Cells["EditRemark"].Value.ToString();
            }
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            switch (CtrlType)
            {
                case "未审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApproval(SelectStr); break;
                case "最终确认": ApplicationInfoTable = applicationInfo.SelectNotPassedApplication(SelectStr); break;
                case "已生成唯一码未购买": ApplicationInfoTable = applicationInfo.SelectUnCodedApplication(SelectStr); break;
                case "全部": ApplicationInfoTable = applicationInfo.SelectAllApplication(SelectStr); break;
                default: ApplicationInfoTable = applicationInfo.SelectApplicationByApproval(SelectStr); break;
            }
            dgvApplyInfo.DataSource = ApplicationInfoTable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (applicationInfo.TransNo != null)
            {
                try
                {
                    frmEditRemark fer = new frmEditRemark(applicationInfo.EditRemark);
                    if (fer.ShowDialog() == DialogResult.OK)
                    {
                        DataTable dt = applicationInfo.SelectApplicationByTransNo(applicationInfo.TransNo);
                        if(dt.Rows.Count>0)
                        {
                            dt.Rows[0]["EditRemark"] = fer.EditReasonString;
                            applicationInfo.UpdateApplicationInfo(dt);
                        }
                        applicationInfo.DeleteApplicaionInfo(applicationInfo.TransNo);
                        MessageBox.Show("撤销成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        GetApplicationDetail();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("撤销失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请选择一行记录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            if (applicationInfo.TransNo != null)
            {
                frmAlterApplication faa = new frmAlterApplication(applicationInfo);
                if (faa.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
            else
            {
                MessageBox.Show("请选择一行记录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvApplyInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvApplyInfo.Rows)
            {
                if (dgvr.Cells["FinalException"] != null && dgvr.Cells["FinalException"].Value != null && dgvr.Cells["FinalException"].Value.ToString() != "")
                {
                    if ((int)dgvr.Cells["FinalException"].Value == 1) { dgvr.Cells["FinalExceptionFilter"].Value = "异常"; dgvr.Cells["FinalExceptionFilter"].Style.ForeColor = Color.Red; }
                    else dgvr.Cells["FinalExceptionFilter"].Value = "正常";
                }
            }
        }

        private void cbCtrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlType = cbCtrlType.SelectedItem.ToString();
            GetApplicationDetail();
            //if (cbCtrlType.SelectedItem.ToString() == "未审核") { btnApprovalAll.Visible = true;}
            //else { btnApprovalAll.Visible = false; }


            if (CtrlType == "未审核") { dgvApplyInfo.Columns["ApprovalState"].Visible = true; dgvApplyInfo.Columns["FinalState"].Visible = false; dgvApplyInfo.Columns["FinalExceptionFilter"].Visible = false; btnSelectAll.Visible = true; btnApprovalAll.Text = "批量审批通过"; btnApprovalAll.Visible = true; }
            else if (CtrlType == "最终确认") { dgvApplyInfo.Columns["ApprovalState"].Visible = false; dgvApplyInfo.Columns["FinalState"].Visible = true; dgvApplyInfo.Columns["FinalExceptionFilter"].Visible = true; btnSelectAll.Visible = true; btnApprovalAll.Text = "批量最终确认"; btnApprovalAll.Visible = true; }
            else { dgvApplyInfo.Columns["ApprovalState"].Visible = false; dgvApplyInfo.Columns["FinalState"].Visible = false; dgvApplyInfo.Columns["FinalExceptionFilter"].Visible = false; btnSelectAll.Visible = false; btnApprovalAll.Visible = false; }

        }

        private void dgvApplyInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (applicationInfo.TransNo != null)
            {
                frmAppApprovalDetail faad = new frmAppApprovalDetail(applicationInfo, CtrlType);
                if (faad.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
        }

        private void btnApprovalAll_Click(object sender, EventArgs e)
        {
            int successRows = 0;
            if (CtrlType == "未审核")
            {
                foreach (DataRow dr in ApplicationInfoTable.Rows)
                {
                    if (dr["ApprovalState"].ToString() == "1")
                    {
                        successRows += applicationInfo.ApprovalApplication(dr["TransNo"].ToString(), Login.LoginUser, 1, DateTime.Now);
                    }
                }
                MessageBox.Show("审批通过" + successRows + "条", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(CtrlType=="最终确认")
            {
                foreach (DataRow dr in ApplicationInfoTable.Rows)
                {
                    if (dr["FinalState"].ToString() == "1")
                    {
                        successRows += applicationInfo.FinalConfirm(dr["TransNo"].ToString());
                    }
                }
                MessageBox.Show("最终确认通过" + successRows + "条", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            bool isAll = true;
            if (CtrlType == "未审核")
            {
                foreach (DataRow dr in ApplicationInfoTable.Rows)
                {
                    if (dr["ApprovalState"].ToString() == "0") isAll = false;
                }
                if (isAll)
                {
                    foreach (DataRow dr in ApplicationInfoTable.Rows)
                    {
                        dr["ApprovalState"] = 0;
                    }
                }
                else
                {
                    foreach (DataRow dr in ApplicationInfoTable.Rows)
                    {
                        dr["ApprovalState"] = 1;
                    }
                }
            }
            if(CtrlType=="最终确认")
            {
                foreach (DataRow dr in ApplicationInfoTable.Rows)
                {
                    if (dr["FinalState"].ToString() == "0") isAll = false;
                }
                if (isAll)
                {
                    foreach (DataRow dr in ApplicationInfoTable.Rows)
                    {
                        dr["FinalState"] = 0;
                    }
                }
                else
                {
                    foreach (DataRow dr in ApplicationInfoTable.Rows)
                    {
                        dr["FinalState"] = 1;
                    }
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
