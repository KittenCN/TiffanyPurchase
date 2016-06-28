using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using BHair.Business.Table;
using System.Text.RegularExpressions;

namespace BHair.Business
{
    public partial class frmAppStaff : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationInfoTable;
        public DataRow ApplicationInfoRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
        public string CtrlID = "";
        string SelectStr = "and 1=1";
        string CtrlType = "正在审核";
        /// <summary>员工申请单状态</summary>
        public frmAppStaff()
        {
            InitializeComponent();
            GetApplicationDetail();
            cbCtrlType.Items.Add("正在审核");
            cbCtrlType.Items.Add("已生成唯一码");
            cbCtrlType.Items.Add("已完成购买");
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
                case "正在审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApplicants(Login.LoginUser.UID, ""); btnPrintUnCode.Visible = false; btnAlter.Visible = true; btnDelete.Visible = true; break;
                case "已生成唯一码": ApplicationInfoTable = applicationInfo.SelectPassedApplicationByApplicants(Login.LoginUser.UID, ""); btnPrintUnCode.Visible = true; btnAlter.Visible = false; btnDelete.Visible = false; break;
                case "已完成购买": ApplicationInfoTable = applicationInfo.SelectHistoryApplicationByApplicants(Login.LoginUser.UID, ""); btnPrintUnCode.Visible = false; btnAlter.Visible = false; btnDelete.Visible = false; break;
                default: ApplicationInfoTable = applicationInfo.SelectApplicationByApplicants(Login.LoginUser.UID, ""); btnPrintUnCode.Visible = false; btnAlter.Visible = true; btnDelete.Visible = true; break;
            }
            dgvApplyInfo.AutoGenerateColumns = false;
            dgvApplyInfo.DataSource = ApplicationInfoTable;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (applicationInfo.TransNo != null)
            {
                new frmAppStaffDetail(applicationInfo,CtrlType).ShowDialog();

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
            if (dgvApplyInfo.RowCount > 0)
            {
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value > 0) txtApprovalState.Text = "通过"; else txtApprovalState.Text = "未审批";
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value >= 4) txtApprovalState2.Text = "通过"; else txtApprovalState2.Text = "未审批";
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
                applicationInfo.UnCode = dgvApplyInfo.SelectedRows[0].Cells["UnCode"].Value.ToString();
            }
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            switch (CtrlType)
            {
                case "正在审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApplicants(Login.LoginUser.UID, SelectStr); btnPrintUnCode.Visible = false; btnAlter.Visible = true; btnDelete.Visible = true; break;
                case "已生成唯一码": ApplicationInfoTable = applicationInfo.SelectPassedApplicationByApplicants(Login.LoginUser.UID, SelectStr); btnPrintUnCode.Visible = true; btnAlter.Visible = false; btnDelete.Visible = false; break;
                case "已完成购买": ApplicationInfoTable = applicationInfo.SelectHistoryApplicationByApplicants(Login.LoginUser.UID, SelectStr); btnPrintUnCode.Visible = false; btnAlter.Visible = false; btnDelete.Visible = false; break;
                default: ApplicationInfoTable = applicationInfo.SelectApplicationByApplicants(Login.LoginUser.UID, SelectStr); btnPrintUnCode.Visible = false; btnAlter.Visible = true; btnDelete.Visible = true; break;
            }
            dgvApplyInfo.DataSource = ApplicationInfoTable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.Parse(dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value.ToString())>=6)
            {
                MessageBox.Show("已确认购买，无法撤销", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (((DateTime)(dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value)).AddDays(3).Date < DateTime.Now.Date)
            {
                MessageBox.Show("超过修改时间，无法撤销", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (applicationInfo.TransNo != null )
            {
                try
                {
                    applicationInfo.DeleteApplicaionInfo(applicationInfo.TransNo);
                    MessageBox.Show("撤销成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GetApplicationDetail();
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
            if (int.Parse(dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value.ToString()) > 0)
            {
                MessageBox.Show("已进入流程，无法修改", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (((DateTime)(dgvApplyInfo.SelectedRows[0].Cells["ApplicantsDate"].Value)).AddDays(3).Date < DateTime.Now.Date)
            {
                MessageBox.Show("超过修改时间，无法修改", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
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
        }

        private void dgvApplyInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void cbCtrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlType = cbCtrlType.SelectedItem.ToString();
            GetApplicationDetail();
        }

        private void dgvApplyInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrintUnCode_Click(object sender, EventArgs e)
        {
            if (applicationInfo.UnCode ==null|| applicationInfo.UnCode == "")
            {
                MessageBox.Show("流程未生成一维码", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GetCode39 gc39 = new GetCode39();
                Bitmap bitmap = gc39.GetUnCodeBitmap(applicationInfo.UnCode);

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "bmp文件(*.bmp)|*.bmp";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (bitmap!=null&&saveFileDialog1.FileName!=null)
                    {
                        bitmap.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        MessageBox.Show("生成一维码成功");
                    }
                } 
            }
        }

        private void dgvApplyInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (applicationInfo.TransNo != null)
            {
                new frmAppStaffDetail(applicationInfo, CtrlType).ShowDialog();

            }
        }





    }
}
