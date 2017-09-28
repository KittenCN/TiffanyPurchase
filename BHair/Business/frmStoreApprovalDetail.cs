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
    public partial class frmStoreApprovalDetail : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataRow ApplicationDetailRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
         ApplicationDetail applicationDetail = new ApplicationDetail();
        public string CtrlID = "";
        string ctrlType = "未审核";
        double totalPrice = 0;
        /// <summary>店面确认购买申请单详情</summary>
        public frmStoreApprovalDetail(ApplicationInfo ParentAppInfo, string CtrlType)
        {
            InitializeComponent();
            applicationInfo = ParentAppInfo;
            this.Text = string.Format("申请单详细信息:交易号：{0}", applicationInfo.TransNo);
            GetApplicationDetail();
            InitButton(CtrlType);
            txtStaffName.Text = Login.LoginUser.UserName;
            groupBox3.Text = string.Format("如果产品作为赠礼且零售价超过{0}人民币，请填写以下信息", EmailControl.config.CNY);
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            ApplicationDetailTable = applicationDetail.SelectAppDetailByTransNo(applicationInfo.TransNo, " and [IsRepetition]=0 ");
            foreach(DataRow dr in ApplicationDetailTable.Rows)
            {
                dr["IsSuccess"] = 0;
            }
            dgvApplyDetails.AutoGenerateColumns = false;
            dgvApplyDetails.DataSource = ApplicationDetailTable;

            txtApplicantsNo.Text = applicationInfo.ApplicantsNo;
            txtApplicantsName.Text = applicationInfo.ApplicantsName;
            txtDate.Text = applicationInfo.ApplicantsDate;
            txtLocation.Text = applicationInfo.Location;
            txtPurchaseLocation.Text = applicationInfo.PurchaseLocation;
            txtApproval.Text = applicationInfo.ApprovalName;
            txtApprovalTime.Text = applicationInfo.ApprovalDate;
            txtApproval2.Text = applicationInfo.ApprovalName2;
            txtApprovalTime2.Text = applicationInfo.ApprovalDate2;
            txtStaffName.Text = applicationInfo.StaffName;

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

        }

        //审核按钮
        private void BtnApprovalOK_Click(object sender, EventArgs e)
        {
            applicationInfo.ApprovalApplication(applicationInfo.TransNo, Login.LoginUser, 1, txtSalesDate.Value);
            MessageBox.Show("确认购买完毕", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
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

        //确认按钮
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //if (applicationInfo.CanBuy(applicationInfo.TransNo, "", applicationInfo.Applicants, totalPrice))
            //{
                try
                {
                    double exchangeRate = 1;
                    if (applicationInfo.MoneyUnit == 2) exchangeRate = double.Parse(EmailControl.config.USrate.ToString());
                    else if (applicationInfo.MoneyUnit == 3) exchangeRate = double.Parse(EmailControl.config.HKrate.ToString());
                    //将额度修改转移到商品部最终确认步骤 2017/09/28
                    //applicationInfo.StorePay(applicationInfo.TransNo, "", applicationInfo.Applicants, totalPrice,exchangeRate);
                    applicationDetail.UpdateBuyApplicationDetail(ApplicationDetailTable,applicationInfo.TransNo);
                    applicationInfo.StoreConfirm(applicationInfo.TransNo, Login.LoginUser, txtSalesDate.Value);
                    //购买异常标识
                    int exc = 0;
                    foreach(DataRow dr in ApplicationDetailTable.Rows)
                    {
                        if(dr["IsSuccess"].ToString()=="0")
                        {
                            exc++;
                        }
                    }
                    if (exc > 0) applicationInfo.SetFinalException(applicationInfo.TransNo);

                    Thread thread = new Thread(new ThreadStart(SendEmail));
                    thread.Start();
                    MessageBox.Show("确认完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("确认失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            //}
            //else
            //{
            //    MessageBox.Show("该用户余额不足", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        void SendEmail()
        {
            EmailControl.ToFinalConfirm(applicationInfo);
            EmailControl.SaleSuccess(applicationInfo);
        }

        private void dgvApplyDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvApplyDetails.SelectedRows.Count > 0)
            {
                lblCodeID.Text = dgvApplyDetails.SelectedRows[0].Cells["CodeID"].Value.ToString();
                lblRecipient.Text = dgvApplyDetails.SelectedRows[0].Cells["Recipient"].Value.ToString();
                lblRelationship.Text = dgvApplyDetails.SelectedRows[0].Cells["Relationship"].Value.ToString();
                lblReason.Text = dgvApplyDetails.SelectedRows[0].Cells["Reason"].Value.ToString();
            }

            
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

        private void dgvApplyDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvApplyDetails.IsCurrentCellDirty)
            {
                dgvApplyDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvApplyDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            totalPrice = 0;
            foreach (DataGridViewRow dgvr in dgvApplyDetails.Rows)
            {
                if ((int)dgvr.Cells["IsSuccess"].Value == 1)
                {
                    totalPrice += double.Parse(dgvr.Cells["FinalPrice"].Value.ToString());
                }
            }

            txtTotalPrice.Text = totalPrice.ToString("#0.00"); 
        }
        private void btnPrintPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF文件(*.pdf)|*.pdf";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            //点了保存按钮进入
            if (result == DialogResult.OK)
            {
                DataTable tempDetailDT=ApplicationDetailTable.Clone();
                foreach(DataRow dr in ApplicationDetailTable.Rows)
                {
                    if(dr["IsSuccess"].ToString()=="1")
                    {
                        tempDetailDT.Rows.Add(dr.ItemArray);
                    }
                }

                //获得文件路径
                string localFilePath = saveFileDialog.FileName.ToString();
                PrintPDF pp = new PrintPDF();
                try
                {
                    DataTable appDT = applicationInfo.SelectApplicationByTransNo(applicationInfo.TransNo);
                    pp.CreatePDF(appDT, tempDetailDT, localFilePath, "员工内购购买明细");
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
