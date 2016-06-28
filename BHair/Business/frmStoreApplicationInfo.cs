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
    public partial class frmStoreApplicationInfo : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationInfoTable;
        public DataRow ApplicationInfoRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
        public string CtrlID = "";
        string SelectStr = "and 1=1";
        string CtrlType = "已确认购买";
        /// <summary>商品部申请单状态</summary>
        public frmStoreApplicationInfo()
        {
            InitializeComponent();
            GetApplicationDetail();
            //cbCtrlType.Items.Add("已确认购买");
            //cbCtrlType.SelectedIndex = 0;
            cbMoneyUnit.Items.Add("全部");
            cbMoneyUnit.Items.Add("人民币");
            cbMoneyUnit.Items.Add("美元");
            cbMoneyUnit.Items.Add("港币");
            cbMoneyUnit.SelectedIndex = 0;
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            //ApplicationInfoTable = new DataTable();
            
            //switch (CtrlType)
            //{
            //    case "未审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApproval(""); break;
            //    case "店面已确认购买": ApplicationInfoTable = applicationInfo.SelectNotPassedApplication(""); break;
            //    case "已生成唯一码未购买": ApplicationInfoTable = applicationInfo.SelectUnCodedApplication(""); break;
            //    case "全部": ApplicationInfoTable = applicationInfo.SelectAllApplication(""); break;
            //    default: ApplicationInfoTable = applicationInfo.SelectApplicationByApproval(""); break;
            //}
            //dgvApplyInfo.AutoGenerateColumns = false;
            //dgvApplyInfo.DataSource = ApplicationInfoTable;
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
            //if (TxtChoose.Text != "")
            //{
            //    SelectStr = string.Format("and 1=1 and( TransNo='{0}' or ApplicantsNo='{0}' or PurchaseLocation='{0}' or ApplicantsName='{0}')", TxtChoose.Text);
            //}

        }

        private void dgvApplyInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvApplyInfo.RowCount > 0)
            //{
            //    if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value >=4) txtApprovalState.Text = "通过"; else txtApprovalState.Text = "未审批";
            //    if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value >0) txtApprovalState2.Text = "通过"; else txtApprovalState2.Text = "未审批";
            //    if (dgvApplyInfo.SelectedRows[0].Cells["UnCode"].Value!=null) txtUnCode.Text = dgvApplyInfo.SelectedRows[0].Cells["UnCode"].Value.ToString();
            //    if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value > 5) txtStaffApproval.Text = "已确认"; else txtStaffApproval.Text = "未确认";
            //    if ((int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value == 9) txtFinish.Text = "已完成"; else txtFinish.Text = "未完成";

            //    applicationInfo.TransNo = dgvApplyInfo.SelectedRows[0].Cells["TransNo"].Value.ToString();
            //    applicationInfo.Applicants = dgvApplyInfo.SelectedRows[0].Cells["Applicants"].Value.ToString();
            //    applicationInfo.ApplicantsNo = dgvApplyInfo.SelectedRows[0].Cells["ApplicantsNo"].Value.ToString();
            //    applicationInfo.ApplicantsName = dgvApplyInfo.SelectedRows[0].Cells["ApplicantsName"].Value.ToString();
            //    applicationInfo.ApplicantsDate = dgvApplyInfo.SelectedRows[0].Cells["ApplicantsDate"].Value.ToString();
            //    applicationInfo.Location = dgvApplyInfo.SelectedRows[0].Cells["Location"].Value.ToString();
            //    applicationInfo.PurchaseLocation = dgvApplyInfo.SelectedRows[0].Cells["PurchaseLocation"].Value.ToString();
            //    applicationInfo.ApprovalName = dgvApplyInfo.SelectedRows[0].Cells["ApprovalName"].Value.ToString();
            //    applicationInfo.ApprovalDate = dgvApplyInfo.SelectedRows[0].Cells["ApprovalDate"].Value.ToString();
            //    applicationInfo.ApprovalName2 = dgvApplyInfo.SelectedRows[0].Cells["ApprovalName2"].Value.ToString();
            //    applicationInfo.ApprovalDate2 = dgvApplyInfo.SelectedRows[0].Cells["ApprovalDate2"].Value.ToString();
            //    applicationInfo.StaffName = dgvApplyInfo.SelectedRows[0].Cells["StaffName"].Value.ToString();
            //    applicationInfo.SalesDate = dgvApplyInfo.SelectedRows[0].Cells["SalesDate"].Value.ToString();
            //    applicationInfo.AppState = (int)dgvApplyInfo.SelectedRows[0].Cells["AppState"].Value;
            //    applicationInfo.EditReason = dgvApplyInfo.SelectedRows[0].Cells["EditReason"].Value.ToString();
            //}
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            SelectStr += string.Format(" and ApplicationInfo.ApplicantsDate>#{0}# and ApplicationInfo.ApplicantsDate<#{1}#", txtSDate.Value.Date, txtEDate.Value.AddDays(1).Date);
            if (TxtChoose.Text != "")
            {
                SelectStr += string.Format(" and ApplicationInfo.ApplicantsName='{0}' ", TxtChoose.Text);
            }
            if (cbMoneyUnit.SelectedIndex != 0)
            {
                SelectStr += string.Format(" and [ApplicationDetail.MoneyUnit]={0} ", cbMoneyUnit.SelectedIndex);
            }
            if (Login.LoginUser.Character == 1) ApplicationInfoTable = applicationInfo.SelectHisApplicationByStore1(SelectStr);
            else ApplicationInfoTable = applicationInfo.SelectHisApplicationByStore(SelectStr,Login.LoginUser.Store);
            dgvApplyInfo.AutoGenerateColumns = false;
            dgvApplyInfo.DataSource = ApplicationInfoTable;
            SelectStr = "and 1=1";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (applicationInfo.TransNo != null)
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
                    eh.StoreReportExcel(localFilePath, ApplicationInfoTable);
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvApplyInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void cbCtrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CtrlType = cbCtrlType.SelectedItem.ToString();
            //GetApplicationDetail();
        }

        private void dgvApplyInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (applicationInfo.TransNo != null)
            //{
            //    frmAppApprovalDetail faad = new frmAppApprovalDetail(applicationInfo, CtrlType);
            //    if (faad.ShowDialog() == DialogResult.OK)
            //    {
            //        this.GetApplicationDetail();
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStoreApplication fsa = new frmStoreApplication();
            fsa.Show();
        }



    }
}
