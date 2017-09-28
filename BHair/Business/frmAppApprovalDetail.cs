using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.Table;
using System.Text.RegularExpressions;
using System.Threading;

namespace BHair.Business
{
    public partial class frmAppApprovalDetail : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataRow ApplicationDetailRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
         ApplicationDetail applicationDetail = new ApplicationDetail();
        public string CtrlID = "";
        string strCtrlType = "";
        double totalPrice = 0;
        /// <summary>商品部审批申请单详情</summary>
        public frmAppApprovalDetail(ApplicationInfo ParentAppInfo, string CtrlType)
        {
            InitializeComponent();
            strCtrlType = CtrlType;
            applicationInfo = ParentAppInfo;
            this.Text = string.Format("申请单详细信息:交易号：{0}", applicationInfo.TransNo);
            GetApplicationDetail();
            InitButton(CtrlType);
            if (strCtrlType == "未审核") txtApproval.Text = "";           
            groupBox3.Text = string.Format("如果产品作为赠礼且零售价超过{0}人民币，请填写以下信息", EmailControl.config.CNY);
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            ApplicationDetailTable = applicationDetail.SelectAppDetailByTransNo(applicationInfo.TransNo,"");
            dgvApplyDetails.AutoGenerateColumns = false;
            dgvApplyDetails.DataSource = ApplicationDetailTable;

            txtApplicantsNo.Text = applicationInfo.ApplicantsNo;
            txtApplicantsName.Text = applicationInfo.ApplicantsName;
            txtDate.Text = applicationInfo.ApplicantsDate;
            txtLocation.Text = applicationInfo.Location;
            txtPurchaseLocation.Text = applicationInfo.PurchaseLocation;
            txtApproval2.Text = applicationInfo.ApprovalName2;
            txtApprovalTime2.Text = applicationInfo.ApprovalDate2;
            txtStaffName.Text = applicationInfo.StaffName;
            txtSalesDate.Text = applicationInfo.SalesDate;
            if (strCtrlType == "未审核")
            {
                txtApproval.Text = "";
            }
            else
            {
                txtApproval.Text = applicationInfo.ApprovalName;
            }

            if (txtApproval2.Text=="")
            {
                txtApprovalTime2.Text = "";
            }
            if (txtStaffName.Text == "")
            {
                txtSalesDate.Text = "";
            }

            if(applicationInfo.AppState<0)
            {
                txtApproval.Text = "自动审核失败";
                BtnApprovalOK.Enabled = false;
                btnConfirm.Enabled = false;
                //btnEdit.Enabled = false;
                //btnEdit2.Enabled = false;
            }
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        void InitButton(string CtrlType)
        {
            switch(CtrlType)
            {
                case "未审核": ApprovalPanel.Visible = true; break;
                case "最终确认": Confirmpanel.Visible = true; break;
                case "全部": break;
                default: break;
            }
        }

        //审核按钮
        private void BtnApprovalOK_Click(object sender, EventArgs e)
        {
            try
            {
                applicationInfo.ApprovalApplication(applicationInfo.TransNo, Login.LoginUser, 1, dtApprovalTime.Value);
                Thread thread = new Thread(new ThreadStart(SendEmail));
                thread.Start();
                MessageBox.Show("审核完毕", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("审核失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        void SendEmail()
        {
            EmailControl.ToEmployeeConfirm(applicationInfo); 
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
                if (dgvr.Cells["IsRepetition"] != null && dgvr.Cells["IsRepetition"].Value != null && dgvr.Cells["IsRepetition"].Value.ToString() != "")
                {
                    if ((int)dgvr.Cells["IsRepetition"].Value == 0) dgvr.Cells["IsRepetitionFilter"].Value = "否";
                    else dgvr.Cells["IsRepetitionFilter"].Value = "是";
                }
                if (dgvr.Cells["IsSuccess"] != null && dgvr.Cells["IsSuccess"].Value != null && dgvr.Cells["IsSuccess"].Value.ToString() != "")
                {
                    if ((int)dgvr.Cells["IsSuccess"].Value == 0) dgvr.Cells["IsSuccessFilter"].Value = "否";
                    else dgvr.Cells["IsSuccessFilter"].Value = "是";
                }
                if (dgvr.Cells["MoneyUnit"] != null && dgvr.Cells["MoneyUnit"].Value != null && dgvr.Cells["MoneyUnit"].Value.ToString() != "")
                {
                    //if ((int)dgvr.Cells["MoneyUnit"].Value == 2) dgvr.Cells["MoneyUnitShow"].Value = "美元";
                    //if ((int)dgvr.Cells["MoneyUnit"].Value == 3 ) dgvr.Cells["MoneyUnitShow"].Value = "港币";
                    //else dgvr.Cells["MoneyUnitShow"].Value = "人民币";
                    switch((int)dgvr.Cells["MoneyUnit"].Value)
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
        private Boolean CheckSpecial(string itemID)
        {
            Boolean boolResult = false;
            string strSQL = "select * from Items where itemID = '" + itemID + "'";
            AccessHelper ah = new AccessHelper();
            DataTable dt = ah.SelectToDataTable(strSQL);
            ah.Close();
            if (dt.Rows[0]["IsSpecial"].ToString() == "1")
            {
                boolResult = true;
            }
            return boolResult;
        }
        private int SMoneyunit(string itemID)
        {
            int intResult = 0;
            string strSQL = "select * from Items where itemID = '" + itemID + "'";
            AccessHelper ah = new AccessHelper();
            DataTable dt = ah.SelectToDataTable(strSQL);
            ah.Close();
            if (dt.Rows[0]["MoneyUnit"] != null)
            {
                intResult = int.Parse(dt.Rows[0]["MoneyUnit"].ToString());
            }
            return intResult;
        }
        //确认按钮
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                totalPrice = 0;
                double exchangeRate = 1;
                foreach (DataGridViewRow dgvr in dgvApplyDetails.Rows)
                {
                    if ((int)dgvr.Cells["IsSuccess"].Value == 1 && !CheckSpecial(dgvr.Cells["ItemID"].Value.ToString()))
                    {
                        if (SMoneyunit(dgvr.Cells["ItemID"].Value.ToString()) == 2) exchangeRate = double.Parse(EmailControl.config.USrate.ToString());
                        else if (SMoneyunit(dgvr.Cells["ItemID"].Value.ToString()) == 3) exchangeRate = double.Parse(EmailControl.config.HKrate.ToString());
                        totalPrice += double.Parse(dgvr.Cells["FinalPrice"].Value.ToString()) * exchangeRate;
                    }
                }               
                applicationInfo.StorePay(applicationInfo.TransNo, "", applicationInfo.Applicants, totalPrice, 1);
                applicationDetail.UpdateBuyApplicationDetail(ApplicationDetailTable, applicationInfo.TransNo);
                applicationInfo.FinalConfirm(applicationInfo.TransNo);
                MessageBox.Show("确认完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("确认失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                faa.GetEditState();
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

        private void dgvApplyDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (applicationInfo.TransNo != null)
            {
                frmAlterApplication faa = new frmAlterApplication(applicationInfo);
                faa.GetEditState();
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
        private void dgvApplyDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
