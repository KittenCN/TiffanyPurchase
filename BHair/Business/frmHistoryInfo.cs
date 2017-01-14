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
    public partial class frmHistoryInfo : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationInfoTable;
        public DataRow ApplicationInfoRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
        public string CtrlID = "";
        string SelectStr = "and 1=1 ";
        string CtrlType = "全部";
        double totalPrice = 0;
        /// <summary>商品部申请单状态</summary>
        public frmHistoryInfo()
        {
            InitializeComponent();
            GetApplicationDetail();
            cbCtrlType.Items.Add("全部");
            cbCtrlType.SelectedIndex = 0;
            cbMoneyUnit.Items.Add("全部");
            cbMoneyUnit.Items.Add("人民币");
            cbMoneyUnit.Items.Add("美元");
            cbMoneyUnit.Items.Add("港币");
            cbMoneyUnit.Items.Add("澳元");
            cbMoneyUnit.Items.Add("新元");
            cbMoneyUnit.Items.Add("马币");
            cbMoneyUnit.Items.Add("英镑");
            cbMoneyUnit.Items.Add("欧元");
            cbMoneyUnit.Items.Add("日元");
            cbMoneyUnit.Items.Add("台币");
            cbMoneyUnit.SelectedIndex = 0;
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
                case "全部": ApplicationInfoTable = applicationInfo.SelectHistoryApplication(""); break;
                default: ApplicationInfoTable = applicationInfo.SelectHistoryApplication(""); break;
            }
            dgvApplyInfo.AutoGenerateColumns = false;
            dgvApplyInfo.DataSource = ApplicationInfoTable;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (applicationInfo.TransNo != null)
            {
                new frmHistoryDetail(applicationInfo,CtrlType).ShowDialog();
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
                //SelectStr = string.Format("and 1=1 and( TransNo='{0}' or ApplicantsNo='{0}' or PurchaseLocation='{0}' or ApplicantsName='{0}')", TxtChoose.Text);
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
            }
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            SelectStr += string.Format(" and ApplicationInfo.ApplicantsDate>#{0}# and ApplicationInfo.ApplicantsDate<#{1}#", txtSDate.Value.Date, txtEDate.Value.AddDays(1).Date);
            if (TxtChoose.Text != "")
            {
                SelectStr += string.Format(" and ApplicantsName='{0}' ", TxtChoose.Text);
            }
            if (cbMoneyUnit.SelectedIndex != 0)
            {
                SelectStr += string.Format(" and [MoneyUnit]={0} ", cbMoneyUnit.SelectedIndex);
            }
            switch (CtrlType)
            {
                case "全部": ApplicationInfoTable = applicationInfo.SelectHistoryApplication(SelectStr); break;
                default: ApplicationInfoTable = applicationInfo.SelectHistoryApplication(""); break;
            }
            dgvApplyInfo.AutoGenerateColumns=false;
            dgvApplyInfo.DataSource = ApplicationInfoTable;
            SelectStr = "and 1=1";
            totalPrice = 0;
            foreach(DataRow dr in ApplicationInfoTable.Rows)
            {
                totalPrice += double.Parse(dr["TotalPrice"].ToString());
            }
            labelTotalPrice.Text = string.Format("总计：{0}",totalPrice);
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
                if (dgvr.Cells["MoneyUnit"] != null && dgvr.Cells["MoneyUnit"].Value != null && dgvr.Cells["MoneyUnit"].Value.ToString() != "")
                {
                    //if ((int)dgvr.Cells["MoneyUnit"].Value == 2) dgvr.Cells["MoneyUnitFilter"].Value = "美元";
                    //if ((int)dgvr.Cells["MoneyUnit"].Value == 3) dgvr.Cells["MoneyUnitFilter"].Value = "港币";
                    //else dgvr.Cells["MoneyUnitFilter"].Value = "人民币";
                    switch ((int)dgvr.Cells["MoneyUnit"].Value)
                    {
                        case 1:
                            dgvr.Cells["MoneyUnitFilter"].Value = "人民币";
                            break;
                        case 2:
                            dgvr.Cells["MoneyUnitFilter"].Value = "美元";
                            break;
                        case 3:
                            dgvr.Cells["MoneyUnitFilter"].Value = "港币";
                            break;
                        case 4:
                            dgvr.Cells["MoneyUnitFilter"].Value = "澳元";
                            break;
                        case 5:
                            dgvr.Cells["MoneyUnitFilter"].Value = "新元";
                            break;
                        case 6:
                            dgvr.Cells["MoneyUnitFilter"].Value = "马币";
                            break;
                        case 7:
                            dgvr.Cells["MoneyUnitFilter"].Value = "英镑";
                            break;
                        case 8:
                            dgvr.Cells["MoneyUnitFilter"].Value = "欧元";
                            break;
                        case 9:
                            dgvr.Cells["MoneyUnitFilter"].Value = "日元";
                            break;
                        case 10:
                            dgvr.Cells["MoneyUnitFilter"].Value = "台币";
                            break;
                        default:
                            dgvr.Cells["MoneyUnitFilter"].Value = "人民币";
                            break;
                    }
                }
            }
        }

        private void cbCtrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlType = cbCtrlType.SelectedItem.ToString();
            GetApplicationDetail();
        }

        private void dgvApplyInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (applicationInfo.TransNo != null)
            {
                new frmHistoryDetail(applicationInfo, CtrlType).ShowDialog();
            }
        }

        private void btnExportEXCEL_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "EXCEL文件(*.xls)|*.xls";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    //string strRandom = getRandomString(12);
                    //string tempFilePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\" + strRandom + ".xls";
                    string localFilePath = saveFileDialog.FileName.ToString();
                    PrintPDF pe = new PrintPDF();
                    pe.WriteToExcel(pe.exporeDataToTable(dgvApplyInfo), localFilePath, "Sheet1");
                    //string localFilePath = saveFileDialog.FileName.ToString();
                    //PrintPDF pp = new PrintPDF();
                    //pp.XLSConvertToPDF(tempFilePath, localFilePath);
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF文件(*.pdf)|*.pdf";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string strRandom = getRandomString(12);
                    string tempFilePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\" + strRandom + ".xls";
                    PrintPDF pe = new PrintPDF();
                    pe.WriteToExcel(pe.exporeDataToTable(dgvApplyInfo), tempFilePath, "Sheet1");
                    string localFilePath = saveFileDialog.FileName.ToString();
                    PrintPDF pp = new PrintPDF();
                    pp.XLSConvertToPDF(tempFilePath, localFilePath);
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        Random m_rnd = new Random();
        public char getRandomChar()
        {
            int ret = m_rnd.Next(122);
            while (ret < 48 || (ret > 57 && ret < 65) || (ret > 90 && ret < 97))
            {
                ret = m_rnd.Next(122);
            }
            return (char)ret;
        }
        public string getRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(getRandomChar());
            }
            return sb.ToString();
        }
    }
}
