using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.Table;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Threading;

namespace BHair.Business
{
    public partial class frmAppApprovalDetail3 : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataRow ApplicationDetailRow;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        public string CtrlID = "";
        string ctrlType = "未审核";
        /// <summary>经理审批申请单详情</summary>
        public frmAppApprovalDetail3(ApplicationInfo ParentAppInfo, string CtrlType)
        {
            InitializeComponent();
            applicationInfo = ParentAppInfo;
            this.Text = string.Format("申请单详细信息:交易号：{0}", applicationInfo.TransNo);
            GetApplicationDetail();
            InitButton(CtrlType);
            if (ctrlType == "未审核") txtApproval2.Text = Login.LoginUser.UserName;
            groupBox3.Text = string.Format("如果产品作为赠礼且零售价超过{0}人民币，请填写以下信息", EmailControl.config.CNY);
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            ApplicationDetailTable = applicationDetail.SelectAppDetailByTransNo(applicationInfo.TransNo, " and [IsRepetition]=0 ");
            dgvApplyDetails.AutoGenerateColumns = false;
            dgvApplyDetails.DataSource = ApplicationDetailTable;

            txtApplicantsNo.Text = applicationInfo.ApplicantsNo;
            txtApplicantsName.Text = applicationInfo.ApplicantsName;
            txtDate.Text = applicationInfo.ApplicantsDate;
            txtLocation.Text = applicationInfo.Location;
            txtPurchaseLocation.Text = applicationInfo.PurchaseLocation;
            txtApproval.Text = applicationInfo.ApprovalName;
            txtApproval2.Text = applicationInfo.ApprovalName2;
            txtApproval3.Text = applicationInfo.ApprovalName3;
            txtApprovalTime.Text = applicationInfo.ApprovalDate;
            txtApprovalTime2.Text = applicationInfo.ApprovalDate2;
            txtStaffName.Text = applicationInfo.StaffName;
            txtSalesDate.Text = applicationInfo.SalesDate;
            if (txtApproval.Text == "") txtApprovalTime.Text = "";
            if (txtApproval2.Text == "") txtApprovalTime2.Text = "";
            if (txtStaffName.Text == "") txtSalesDate.Text = "";


        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void InitButton(string CtrlType)
        {
            switch (CtrlType)
            {
                case "未审核": ApprovalPanel.Visible = true; break;
                case "已审核": break;
                default: break;
            }
        }

        //审核按钮
        private void BtnApprovalOK_Click(object sender, EventArgs e)
        {
            try
            {
                applicationInfo.ApprovalApplication3(applicationInfo.TransNo, Login.LoginUser, 1, dtApprovalTime3.Value);
                Thread thread = new Thread(new ThreadStart(SendEmail));
                thread.Start();
                
                MessageBox.Show("审核完毕", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("审核失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void SendEmail()
        {
            EmailControl.ToApplicantSubmit(applicationInfo);
        }


        private void dgvApplyDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvApplyDetails.Rows)
            {
                if (dgvr.Cells["SelforGift"] != null && dgvr.Cells["SelforGift"].Value != null && dgvr.Cells["SelforGift"].Value.ToString() != "")
                {
                    if ((int)dgvr.Cells["SelforGift"].Value == 1) dgvr.Cells["SelforGiftState"].Value = "自用";
                    else dgvr.Cells["SelforGiftState"].Value = "送礼";
                }
                if (dgvr.Cells["MoneyUnit"] != null && dgvr.Cells["MoneyUnit"].Value != null && dgvr.Cells["MoneyUnit"].Value.ToString() != "")
                {
                    //if ((int)dgvr.Cells["MoneyUnit"].Value == 2) dgvr.Cells["MoneyUnitShow"].Value = "美元";
                    //if ((int)dgvr.Cells["MoneyUnit"].Value == 3) dgvr.Cells["MoneyUnitShow"].Value = "港币";
                    //else dgvr.Cells["MoneyUnitShow"].Value = "人民币";
                    switch ((int)dgvr.Cells["MoneyUnit"].Value)
                    {
                        case 1:
                            dgvr.Cells["MoneyUnitShow"].Value = "人民币";
                            break;
                        case 2:
                            dgvr.Cells["MoneyUnitShow"].Value = "美元";
                            break;
                        case 3:
                            dgvr.Cells["MoneyUnitShow"].Value = "港币";
                            break;
                        case 4:
                            dgvr.Cells["MoneyUnitShow"].Value = "澳元";
                            break;
                        case 5:
                            dgvr.Cells["MoneyUnitShow"].Value = "新元";
                            break;
                        case 6:
                            dgvr.Cells["MoneyUnitShow"].Value = "马币";
                            break;
                        case 7:
                            dgvr.Cells["MoneyUnitShow"].Value = "英镑";
                            break;
                        case 8:
                            dgvr.Cells["MoneyUnitShow"].Value = "欧元";
                            break;
                        case 9:
                            dgvr.Cells["MoneyUnitShow"].Value = "日元";
                            break;
                        case 10:
                            dgvr.Cells["MoneyUnitShow"].Value = "台币";
                            break;
                        default:
                            dgvr.Cells["MoneyUnitShow"].Value = "人民币";
                            break;
                    }
                }
            }
        }



        private void dgvApplyDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCodeID.Text = dgvApplyDetails.SelectedRows[0].Cells["CodeID"].Value.ToString();
            lblRecipient.Text = dgvApplyDetails.SelectedRows[0].Cells["Recipient"].Value.ToString();
            lblRelationship.Text = dgvApplyDetails.SelectedRows[0].Cells["Relationship"].Value.ToString();
            lblReason.Text = dgvApplyDetails.SelectedRows[0].Cells["Reason"].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
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

        private void btnPrintPDF_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            Business.PrintPDF printPDF = new PrintPDF();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF文件(*.pdf)|*.pdf";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            applicationInfo.applicationDT = applicationInfo.SelectApplicationByTransNo(applicationInfo.TransNo);
            //点了保存按钮进入
            if (result == DialogResult.OK)
            {
                if (applicationInfo.applicationDT.Rows.Count > 0)
                {
                    try
                    {
                        //获得文件路径
                        string localFilePath = saveFileDialog.FileName.ToString();
                        PrintPDF pp = new PrintPDF();
                        if (Login.LoginUser.MoneyUnit == 1)
                        {
                            isSuccess = printPDF.CreatePDF(applicationInfo.applicationDT, ApplicationDetailTable, localFilePath, "Staff Purchase Requisition Form 订购申请表");
                        }
                        else
                        {
                            isSuccess = printPDF.CreateEnPDF(applicationInfo.applicationDT, ApplicationDetailTable, localFilePath);
                        }
                        MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }




    }
}
