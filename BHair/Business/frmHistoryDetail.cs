﻿using System;
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
    public partial class frmHistoryDetail : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataRow ApplicationDetailRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
         ApplicationDetail applicationDetail = new ApplicationDetail();
        public string CtrlID = "";
        string ctrlType = "全部";
        /// <summary>商品部审批申请单详情</summary>
        public frmHistoryDetail(ApplicationInfo ParentAppInfo, string CtrlType)
        {
            InitializeComponent();
            applicationInfo = ParentAppInfo;
            this.Text = string.Format("申请单详细信息:交易号：{0}", applicationInfo.TransNo);
            GetApplicationDetail();
            InitButton(CtrlType);
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
            txtApproval.Text = applicationInfo.ApprovalName;
            txtApprovalTime.Text = applicationInfo.ApprovalDate;
            txtApproval2.Text = applicationInfo.ApprovalName2;
            txtApprovalTime2.Text = applicationInfo.ApprovalDate2;
            txtStaffName.Text = applicationInfo.StaffName;
            txtSalesDate.Text = applicationInfo.SalesDate;



        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void InitButton(string CtrlType)
        {
            switch(CtrlType)
            {
                case "全部": break;
                default: break;
            }
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
            applicationInfo.FinalConfirm(applicationInfo.TransNo);
            MessageBox.Show("确认完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
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
        }


    }
}
