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

namespace BHair.Business
{
    public partial class frmAppStaffDetail : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataRow ApplicationDetailRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
         ApplicationDetail applicationDetail = new ApplicationDetail();
        public string CtrlID = "";
        string ctrlType = "正在审核";
        /// <summary>申请单详情</summary>
        public frmAppStaffDetail(ApplicationInfo ParentAppInfo, string CtrlType)
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
            ApplicationDetailTable = applicationDetail.SelectAppDetailByTransNo(applicationInfo.TransNo, " and [IsRepetition]=0 ");
            dgvApplyDetails.AutoGenerateColumns = false;
            dgvApplyDetails.DataSource = ApplicationDetailTable;

            txtApplicantsNo.Text = applicationInfo.ApplicantsNo;
            txtApplicantsName.Text = applicationInfo.ApplicantsName;
            txtDate.Text = applicationInfo.ApplicantsDate;
            txtLocation.Text = applicationInfo.Location;
            txtPurchaseLocation.Text = applicationInfo.PurchaseLocation;
            txtApproval.Text=applicationInfo.ApprovalName;
            dtApprovalTime.Text = applicationInfo.ApprovalDate;
            txtApproval2.Text = applicationInfo.ApprovalName2;
            txtApprovalTime2.Text = applicationInfo.ApprovalDate2;
            txtStaffName.Text = applicationInfo.StaffName;
            txtSalesDate.Text = applicationInfo.SalesDate;

            if (txtApproval.Text == "") dtApprovalTime.Text = "";
            if (txtApproval2.Text == "") txtApprovalTime2.Text = "";
            if (txtStaffName.Text == "") txtSalesDate.Text = "";

            if (applicationInfo.AppState < 0)
            {
                txtApproval.Text = "自动审核失败";
                btnConfirm.Enabled = false;
            }

        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void InitButton(string CtrlType)
        {
            switch(CtrlType)
            {
                //case "正在审核": if (applicationInfo.AppState == 3) Confirmpanel.Visible = true; break;
                case "已生成唯一码":  break;
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
            try
            {
                applicationInfo.StaffApprovalApplication(applicationInfo.TransNo);
                MessageBox.Show("成功确认", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        private void btnPrint_Click(object sender, EventArgs e)
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
                if (applicationInfo.AppState < 2)
                {
                    MessageBox.Show("商品部未批准，无法打印", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (applicationInfo.applicationDT.Rows.Count > 0)
                    {
                        try
                        {
                            //获得文件路径
                            string localFilePath = saveFileDialog.FileName.ToString();
                            PrintPDF pp = new PrintPDF();
                            if (applicationInfo.applicationDT.Rows[0]["MoneyUnit"].ToString()=="1" && Convert.ToInt32(ApplicationDetailTable.Rows[0].ItemArray[6]) == 1)
                            {
                                isSuccess = printPDF.CreatePDF(applicationInfo.applicationDT, ApplicationDetailTable, localFilePath, "Staff Purchase Requisition Form 订购申请表");
                            }
                            else
                            {
                                isSuccess = printPDF.CreateEnPDF(applicationInfo.applicationDT, ApplicationDetailTable, localFilePath);
                            }
                            if(isSuccess)
                            {
                                MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }


        private void pdfPrint(string filePath)
        {
            PrintDocument pd = new PrintDocument(); 
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = true;
            startInfo.FileName = filePath;
            startInfo.Verb = "print";
            startInfo.Arguments = @"/p /h \" + filePath + "\"\"" + pd.PrinterSettings.PrinterName + "\"";
            p.StartInfo = startInfo;
            p.Start();
            p.WaitForExit();
        }
    }
}
