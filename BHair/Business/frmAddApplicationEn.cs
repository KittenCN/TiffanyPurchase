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
    public partial class frmAddApplicationEn : WinFormsUI.Docking.DockContent
    {
        Business.BaseData.Items items = new BaseData.Items();
        bool ExcitItemID=false;
        int codeID = 0;
        DataTable AddApplicationDT;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        /// <summary>内购申请单</summary>
        public frmAddApplicationEn()
        {
            InitializeComponent();
            GetDataTable();

            LoadComBox();


            txtApplicantsName.Text = Login.LoginUser.UserName;
            txtApplicantsNo.Text = Login.LoginUser.EmployeeID;
            txtDeadline.Value = DateTime.Now.AddDays(7);
            
        }

        void GetDataTable()
        {

            AddApplicationDT = applicationDetail.SelectAppDetailByTransNo("0","");
            dgvApplyProducts.DataSource = AddApplicationDT;

            dgvApplyGift.AutoGenerateColumns = false;
            dgvApplyGift.DataSource = AddApplicationDT;

        }



     



        void LoadComBox()
        {
            txtMoneyUnit.Items.Add("CNY");
            txtMoneyUnit.Items.Add("HKD");
            txtMoneyUnit.Items.Add("USD");
            txtMoneyUnit.SelectedIndex = 0;
            if (Login.LoginUser.MoneyUnit>1) txtMoneyUnit.SelectedIndex = Login.LoginUser.MoneyUnit - 1;

            txtSelforGift.Items.Add("Self");
            txtSelforGift.Items.Add("Gift");
            txtSelforGift.SelectedIndex = 0;

            cbDiscount.Items.Add("100%");
            cbDiscount.Items.Add("80%");
            cbDiscount.Items.Add("75%");
            cbDiscount.Items.Add("60%");
            cbDiscount.Items.Add("50%");
            cbDiscount.SelectedIndex = 0;
        }

        //填写物品ID获取信息
        private void txtItemID_Leave(object sender, EventArgs e)
        {
            items.ItemsDT= items.SelectItemByItemID(txtItemID.Text.Trim());
            if(items.ItemsDT!=null&&items.ItemsDT.Rows.Count>0)
            {
                txtDetail.Text = items.ItemsDT.Rows[0]["Detail"].ToString();
                txtPrice.Value = decimal.Parse(items.ItemsDT.Rows[0]["Price"].ToString());


                //if(Login.LoginUser.MoneyUnit==1)  txtPrice.Value = (decimal)items.ItemsDT.Rows[0]["Price"];
                //else if (Login.LoginUser.MoneyUnit == 2) txtPrice.Value = (decimal)items.ItemsDT.Rows[0]["Price2"];
                //else if (Login.LoginUser.MoneyUnit == 3) txtPrice.Value = (decimal)items.ItemsDT.Rows[0]["Price3"];

                ExcitItemID = true;
            }
            else
            {
                ExcitItemID = false;
            }
        }

        private void txtApprovalCount_ValueChanged(object sender, EventArgs e)
        {
            GetFinalPrice();
        }

        //批准价计算
        void GetFinalPrice()
        {
            txtFinalPrice.Value = decimal.Parse((txtPrice.Value * txtApprovalCount.Value * txtApprovalDiscount.Value * (decimal)0.01).ToString("#0.00"));
        }

        //添加
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ExcitItemID) MessageBox.Show("The SKU does not Excit ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                BaseData.Items items = new BaseData.Items();
                DataTable ItemDT = items.SelectItemByItemID(txtItemID.Text);
                if (ItemDT.Rows.Count > 0)
                {
                    DataRow dr = AddApplicationDT.NewRow();
                    codeID++;
                    dr["CodeID"] = codeID.ToString();
                    dr["ItemID"] = txtItemID.Text;
                    dr["Detail"] = txtDetail.Text;
                    dr["Price"] = txtPrice.Value;
                    dr["Count"] = txtCount.Value;
                    dr["MoneyUnit"] = txtMoneyUnit.SelectedIndex + 1;
                    dr["SelforGift"] = txtSelforGift.SelectedIndex + 1;
                    dr["ApprovalCount"] = txtApprovalCount.Value;
                    dr["ApprovalDiscount"] = txtApprovalDiscount.Value;
                    dr["FinalPrice"] = txtFinalPrice.Value;
                    dr["Recipient"] = txtRecipient.Text;
                    dr["Relationship"] = txtRelationship.Text;
                    dr["Reason"] = txtReason.Text;

                    dr["IsSuccess"] = 0;
                    dr["IsDelete"] = 0;
                    AddApplicationDT.Rows.Add(dr);
                }
            }


            GetTotalPrice();
        }


        private void txtApprovalDiscount_ValueChanged(object sender, EventArgs e)
        {
            GetFinalPrice();
        }

        //总价
        void GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (DataGridViewRow rows in dgvApplyProducts.Rows)
            {
                if (rows.Cells["FinalPrice"] != null && rows.Cells["FinalPrice"].Value!=null)
                totalPrice += double.Parse(rows.Cells["FinalPrice"].Value.ToString());
            }
            txtTotalPrice.Value = decimal.Parse(totalPrice.ToString("#0.00")); 
        }

        //删除
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvApplyProducts.SelectedRows.Count > 0)
            {
                dgvApplyProducts.Rows.Remove(dgvApplyProducts.SelectedRows[0]);
                foreach (DataRow dr in AddApplicationDT.Rows)
                {
                    if (dr.RowState == DataRowState.Deleted) dr.Delete();
                }
                GetTotalPrice();
            }
            else
            {
                MessageBox.Show("Please select the entire row of data ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //批准最大数量
        private void txtCount_ValueChanged(object sender, EventArgs e)
        {
            txtApprovalCount.Maximum = txtCount.Value;
        }

        private void txtSelforGift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtSelforGift.SelectedIndex==0)
            {
                txtRecipient.ReadOnly = true;
                txtRelationship.ReadOnly = true;
                txtReason.ReadOnly = true;
                txtRecipient.Text = "";
                txtRelationship.Text = "";
                txtReason.Text = "";
            }
            else
            {
                txtRecipient.ReadOnly = false;
                txtRelationship.ReadOnly = false;
                txtReason.ReadOnly = false;
                
            }

        }

        private void dgvApplyProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvApplyProducts.Rows)
            {
                if (dgvr.Cells["SelforGift"] != null && dgvr.Cells["SelforGift"].Value != null && dgvr.Cells["SelforGift"].Value.ToString()!="")
                {
                    if ((int)dgvr.Cells["SelforGift"].Value == 1) dgvr.Cells["SelforGiftState"].Value = "Self";
                    else dgvr.Cells["SelforGiftState"].Value = "Gift";
                }
            }


            //foreach (DataGridViewRow rows in dgvApplyGift.Rows)
            //{
            //    if (rows.Cells["SelforGift2"] != null && rows.Cells["SelforGift2"].Value != null)
            //    {
            //        if (rows.Cells["SelforGift2"].Value.ToString() == "2")
            //        {

            //            rows.Visible = true;
            //        }
            //        else
            //        {
            //            dgvApplyGift.CurrentCell = null;
            //            rows.Visible = false;
            //        }
            //    }
            //}
        }

        private void txtFinalPrice_Click(object sender, EventArgs e)
        {
            GetFinalPrice();
        }

        //提交
        private void btnOK_Click(object sender, EventArgs e)
        {
            double totalPrice = 0;
            
            foreach (DataRow row in AddApplicationDT.Rows)
            {
                if (items.SelectItemByItemID(row["ItemID"].ToString()).Rows[0]["IsSpecial"].ToString() == "1") { }
                else
                {
                    totalPrice += double.Parse(row["Price"].ToString()) * double.Parse(row["Count"].ToString());
                }
            }
            if (AddApplicationDT.Rows.Count == 0)
            {
                MessageBox.Show("Items are not added in the application form");
            }
            else if(Login.LoginUser.RestAmount-totalPrice<0)
            {
                MessageBox.Show("Your current balance is not enough");
            }
            else
            {
                string transNo = "NG"+ DateTime.Now.ToString("yyyyMMddHHmmssffff");
                DataTable AddAppInfoDT = applicationInfo.SelectApplicationByTransNo("0");
                DataRow dr = AddAppInfoDT.NewRow();
                dr["TransNo"] = transNo;
                dr["Applicants"] = Login.LoginUser.UID;
                dr["ApplicantsName"] = txtApplicantsName.Text;
                dr["ApplicantsNo"] = txtApplicantsNo.Text;
                dr["Location"] = txtLocation.Text;
                dr["ApplicantsDate"] = DateTime.Now;
                dr["TotalPrice"] = txtTotalPrice.Value;
                dr["Deadline"] = txtDeadline.Value;
                dr["PurchaseLocation"] = txtPurchaseLocation.Text;
                dr["IsDelete"] = 0;
                dr["AppState"] = 0;
                dr["ApprovalState"] = 0;
                dr["ApprovalState2"] = 0;
                dr["Approval2"] = Login.LoginUser.ManagerID;
                dr["StaffApproval"] = 0;
                foreach (DataRow addDr in AddApplicationDT.Rows)
                {
                    addDr["TransNo"] = dr["TransNo"];
                }
                AddAppInfoDT.Rows.Add(dr);
                try
                {
                    applicationInfo.SubmitApplicationInfo(AddAppInfoDT);
                    applicationDetail.SubmitApplicationDetail(AddApplicationDT);
                    Thread thread = new Thread(new ThreadStart(SendEmail));
                    thread.Start();
                    
                    MessageBox.Show("Submit Successe", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Submit Fail，Message：" + ex.Message);
                }
            }
        }
        void SendEmail()
        {
            EmailControl.ToApplicantSubmit2(txtTransNo.Text, Login.LoginUser.UID, txtApplicantsName.Text, DateTime.Now.ToString());
        }

        private void cbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDiscount.SelectedIndex)
            {
                case 0:
                    txtApprovalDiscount.Value = 100;
                    break;
                case 1:
                    txtApprovalDiscount.Value = 80;
                    break;
                case 2:
                    txtApprovalDiscount.Value = 75;
                    break;
                case 3:
                    txtApprovalDiscount.Value = 60;
                    break;
                case 4:
                    txtApprovalDiscount.Value = 50;
                    break;
            }
        }
    }
}
