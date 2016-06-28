using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BHair.Business.Table;

namespace BHair.Business
{
    public partial class frmStoreApplication : WinFormsUI.Docking.DockContent
    {
        ApplicationInfo applicationInfo = new ApplicationInfo();
        public frmStoreApplication()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                applicationInfo.applicationDT = applicationInfo.SelectApplicationByStoreStaff(txtUnCode.Text, "");
            }
            catch
            {

            }
            if (applicationInfo.applicationDT != null && applicationInfo.applicationDT.Rows.Count > 0)
            {
                //if(int.Parse(applicationInfo.applicationDT.Rows[0]["AppState"].ToString())>5)
                //{
                //    MessageBox.Show("该唯一码已使用过", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                if (((DateTime)applicationInfo.applicationDT.Rows[0]["Deadline"]) < DateTime.Now)
                {
                    MessageBox.Show("该唯一码已过期", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    applicationInfo.TransNo = applicationInfo.applicationDT.Rows[0]["TransNo"].ToString();
                    applicationInfo.Applicants = applicationInfo.applicationDT.Rows[0]["Applicants"].ToString();
                    applicationInfo.ApplicantsNo = applicationInfo.applicationDT.Rows[0]["ApplicantsNo"].ToString();
                    applicationInfo.ApplicantsName = applicationInfo.applicationDT.Rows[0]["ApplicantsName"].ToString();
                    applicationInfo.ApplicantsDate = applicationInfo.applicationDT.Rows[0]["ApplicantsDate"].ToString();
                    applicationInfo.Location = applicationInfo.applicationDT.Rows[0]["Location"].ToString();
                    applicationInfo.PurchaseLocation = applicationInfo.applicationDT.Rows[0]["PurchaseLocation"].ToString();
                    applicationInfo.ApprovalName = applicationInfo.applicationDT.Rows[0]["ApprovalName"].ToString();
                    applicationInfo.ApprovalDate = applicationInfo.applicationDT.Rows[0]["ApprovalDate"].ToString();
                    applicationInfo.ApprovalName2 = applicationInfo.applicationDT.Rows[0]["ApprovalName2"].ToString();
                    applicationInfo.ApprovalDate2 = applicationInfo.applicationDT.Rows[0]["ApprovalDate2"].ToString();
                    applicationInfo.StaffName = applicationInfo.applicationDT.Rows[0]["StaffName"].ToString();
                    applicationInfo.SalesDate = applicationInfo.applicationDT.Rows[0]["SalesDate"].ToString();
                    applicationInfo.AppState = (int)applicationInfo.applicationDT.Rows[0]["AppState"];
                    applicationInfo.MoneyUnit = (int)applicationInfo.applicationDT.Rows[0]["MoneyUnit"];

                    new frmStoreApprovalDetail(applicationInfo, "").ShowDialog();
                    //}

                }
            }
            else
            {
                MessageBox.Show("不存在该唯一码", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
