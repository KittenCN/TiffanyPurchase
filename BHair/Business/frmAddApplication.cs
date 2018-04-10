using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.Table;
using System.Text.RegularExpressions;
using BHair.Base;
using System.Threading;

namespace BHair.Business
{
    public partial class frmAddApplication : WinFormsUI.Docking.DockContent
    {
        Business.BaseData.Items items = new BaseData.Items();
        Business.BaseData.Store store = new BaseData.Store();
        bool ExcitItemID = false;
        int codeID = 0;
        int CalFlag = 0;
        DataTable AddApplicationDT;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        public static string transNo = "";
        /// <summary>内购申请单</summary>
        public frmAddApplication()
        {
            Random ro = new Random(10);
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            transNo = "NG" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ran.Next().ToString().Substring(0, 4);
            InitializeComponent();
            GetDataTable();
            LoadComBox();
            txtApplicantsName.Text = Login.LoginUser.UserName;
            txtApplicantsNo.Text = Login.LoginUser.EmployeeID;
            txtDeadline.Value = DateTime.Now.AddDays(14);
            string strLocal = "";
            if (Login.LoginUser.Character == 4)
            {
                strLocal = Login.LoginUser.Store;
            }
            else
            {
                strLocal = Login.LoginUser.Department;
            }
            txtLocation.Text = strLocal;

            groupBox1.Text = string.Format("如果产品作为赠礼且零售价超过{0}人民币，请填写以下信息", EmailControl.config.CNY);
            groupBox3.Text = string.Format("赠礼明细(超过{0}人民币必填)", EmailControl.config.CNY);
        }

        void GetDataTable()
        {

            AddApplicationDT = applicationDetail.SelectAppDetailByTransNo("0", "");
            AddApplicationDT.Columns.Add("IsSpecial", Type.GetType("System.Int32"));
            dgvApplyProducts.Columns.Add("IsSpecial", "IsSpecial");
            dgvApplyProducts.Columns["IsSpecial"].Visible = false;
            dgvApplyProducts.Columns["IsSpecial"].DataPropertyName = "IsSpecial";
            dgvApplyProducts.AutoGenerateColumns = false;
            dgvApplyProducts.DataSource = AddApplicationDT;

            dgvApplyGift.AutoGenerateColumns = false;
            dgvApplyGift.DataSource = AddApplicationDT;
        }

        void LoadComBox()
        {
            txtMoneyUnit.Items.Add("人民币");
            txtMoneyUnit.Items.Add("美元");
            txtMoneyUnit.Items.Add("港币");
            txtMoneyUnit.Items.Add("澳元");
            txtMoneyUnit.Items.Add("新元");
            txtMoneyUnit.Items.Add("马币");
            txtMoneyUnit.Items.Add("英镑");
            txtMoneyUnit.Items.Add("欧元");
            txtMoneyUnit.Items.Add("日元");
            txtMoneyUnit.Items.Add("台币");
            txtMoneyUnit.SelectedIndex = 0;
            if (Login.LoginUser.MoneyUnit > 1) txtMoneyUnit.SelectedIndex = Login.LoginUser.MoneyUnit - 1;

            txtSelforGift.Items.Add("自用");
            txtSelforGift.Items.Add("送礼");
            txtSelforGift.SelectedIndex = 0;

            store.StoreDT = store.SelectAllStoreInfo();
            txtPurchaseLocation.DataSource = store.StoreDT;
            txtPurchaseLocation.DisplayMember = "StoreName";
            txtPurchaseLocation.ValueMember = "StoreName";

            cbDiscount.Items.Add("100%");
            cbDiscount.Items.Add("80%");
            cbDiscount.Items.Add("75%");
            cbDiscount.Items.Add("70%");
            cbDiscount.Items.Add("60%");
            cbDiscount.Items.Add("50%");
            cbDiscount.SelectedIndex = 0;

            txtTransNo.Text = transNo;

            txtIsSpecial.Visible = false;
            txtApprovalCount.Visible = false;
        }

        //填写物品ID获取信息
        private void txtItemID_Leave(object sender, EventArgs e)
        {
            items.ItemsDT = items.SelectItemByItemID(txtItemID.Text.Trim());
            if (items.ItemsDT != null && items.ItemsDT.Rows.Count > 0)
            {
                txtDetail.Text = items.ItemsDT.Rows[0]["Detail"].ToString();
                txtPrice.Value = decimal.Parse(items.ItemsDT.Rows[0]["Price"].ToString());
                txtIsSpecial.Text = items.ItemsDT.Rows[0]["IsSpecial"].ToString();

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
            //decimal MoneyDiscont = 1;
            //switch (txtMoneyUnit.SelectedIndex)
            //{
            //    case 0:
            //        MoneyDiscont = 1;
            //        break;
            //    case 1:
            //        MoneyDiscont = EmailControl.config.USrate;
            //        break;
            //    case 2:
            //        MoneyDiscont = EmailControl.config.HKrate;
            //        break;
            //    case 3:
            //        MoneyDiscont = EmailControl.config.MOPrate;
            //        break;
            //    case 4:
            //        MoneyDiscont = EmailControl.config.SGDrate;
            //        break;
            //    case 5:
            //        MoneyDiscont = EmailControl.config.MYRrate;
            //        break;
            //    case 6:
            //        MoneyDiscont = EmailControl.config.GBPrate;
            //        break;
            //    case 7:
            //        MoneyDiscont = EmailControl.config.EURrate;
            //        break;
            //    case 8:
            //        MoneyDiscont = EmailControl.config.JPYrate;
            //        break;
            //    case 9:
            //        MoneyDiscont = EmailControl.config.TWDrate;
            //        break;
            //}
            txtFinalPrice.Value = decimal.Parse((txtPrice.Value * txtApprovalCount.Value * txtApprovalDiscount.Value * (decimal)0.01).ToString("#0.00"));
        }

        //添加
        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal GiftTotal = 0;
            //if (txtMoneyUnit.SelectedIndex == 2) GiftTotal = EmailControl.config.HKD;
            //else if (txtMoneyUnit.SelectedIndex == 1) GiftTotal = EmailControl.config.USD;
            //else GiftTotal = EmailControl.config.CNY;
            switch (txtMoneyUnit.SelectedIndex)
            {
                case 0:
                    GiftTotal = EmailControl.config.CNY;
                    break;
                case 1:
                    GiftTotal = EmailControl.config.USD;
                    break;
                case 2:
                    GiftTotal = EmailControl.config.HKD;
                    break;
                case 3:
                    GiftTotal = EmailControl.config.MOP;
                    break;
                case 4:
                    GiftTotal = EmailControl.config.SGD;
                    break;
                case 5:
                    GiftTotal = EmailControl.config.MYR;
                    break;
                case 6:
                    GiftTotal = EmailControl.config.GBP;
                    break;
                case 7:
                    GiftTotal = EmailControl.config.EUR;
                    break;
                case 8:
                    GiftTotal = EmailControl.config.JPY;
                    break;
                case 9:
                    GiftTotal = EmailControl.config.TWD;
                    break;
            }
            if (!ExcitItemID) MessageBox.Show("不存在该货号", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (AddApplicationDT.Rows.Count > 4)
            {
                MessageBox.Show("超过五项，无法添加", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtSelforGift.SelectedIndex == 1 && txtPrice.Value * txtCount.Value > GiftTotal && (txtReason.Text == "" || txtRecipient.Text == "" || txtRelationship.Text == "" || txtPhoneNum.Text == ""))
            {
                MessageBox.Show("请填写赠礼明细", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                BaseData.Items items = new BaseData.Items();
                DataTable ItemDT = items.SelectItemByItemID(txtItemID.Text);
                if (ItemDT.Rows.Count > 0)
                {
                    DataRow dr = AddApplicationDT.NewRow();
                    codeID++;
                    //dr["CodeID"] = codeID.ToString();
                    dr["ItemID"] = txtItemID.Text;
                    dr["Detail"] = txtDetail.Text;
                    dr["Price"] = txtPrice.Value;
                    dr["Count"] = txtCount.Value;
                    dr["MoneyUnit"] = txtMoneyUnit.SelectedIndex + 1;
                    dr["SelforGift"] = txtSelforGift.SelectedIndex + 1;
                    dr["ApprovalCount"] = txtCount.Value;
                    dr["ApprovalDiscount"] = txtApprovalDiscount.Value;
                    dr["FinalPrice"] = txtFinalPrice.Value;
                    dr["Recipient"] = txtRecipient.Text;
                    dr["Relationship"] = txtRelationship.Text;
                    dr["Reason"] = txtReason.Text;
                    dr["PhoneNum"] = txtPhoneNum.Text;
                    dr["IsSpecial"] = txtIsSpecial.Text;
                    dr["IsSuccess"] = 0;
                    dr["IsDelete"] = 0;
                    AddApplicationDT.Rows.Add(dr);
                }
            }

            for (int i = 0; i < AddApplicationDT.Rows.Count; i++)
            {
                AddApplicationDT.Rows[i]["CodeID"] = i + 1;
            }
            GetTotalPrice();

            txtItemID.Text = "";
            txtDetail.Text = "";
            txtPrice.Value = 0;
            txtCount.Value = 1;
            txtFinalPrice.Value = 0;
            txtItemID.Focus();
            txtMoneyUnit.SelectedIndex = 0;
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
                decimal MoneyDiscont = 1;
                switch (rows.Cells["MoneyUnit"].Value.ToString())
                {
                    case "1":
                    default:
                        MoneyDiscont = 1;
                        break;
                    case "2":
                        MoneyDiscont = EmailControl.config.USrate;
                        break;
                    case "3":
                        MoneyDiscont = EmailControl.config.HKrate;
                        break;
                    case "4":
                        MoneyDiscont = EmailControl.config.MOPrate;
                        break;
                    case "5":
                        MoneyDiscont = EmailControl.config.SGDrate;
                        break;
                    case "6":
                        MoneyDiscont = EmailControl.config.MYRrate;
                        break;
                    case "7":
                        MoneyDiscont = EmailControl.config.GBPrate;
                        break;
                    case "8":
                        MoneyDiscont = EmailControl.config.EURrate;
                        break;
                    case "9":
                        MoneyDiscont = EmailControl.config.JPYrate;
                        break;
                    case "10":
                        MoneyDiscont = EmailControl.config.TWDrate;
                        break;
                }
                if (rows.Cells["FinalPrice"] != null && rows.Cells["FinalPrice"].Value != null)
                    totalPrice += double.Parse(rows.Cells["Price"].Value.ToString()) * double.Parse(rows.Cells["Count"].Value.ToString()) * double.Parse(rows.Cells["ApprovalDiscount"].Value.ToString()) / 100.00 * Convert.ToDouble(MoneyDiscont);
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
                int deleteRowsCount = 0;
                for (int i = 0; i < AddApplicationDT.Rows.Count; i++)
                {
                    if (AddApplicationDT.Rows[i].RowState == DataRowState.Deleted)
                    {
                        deleteRowsCount++;
                    }
                    else
                    {
                        AddApplicationDT.Rows[i]["CodeID"] = i + 1 - deleteRowsCount;
                    }
                }
                GetTotalPrice();
            }
            else
            {
                MessageBox.Show("请选中整行数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //批准最大数量
        private void txtCount_ValueChanged(object sender, EventArgs e)
        {
            //txtApprovalCount.Maximum = txtCount.Value;
            txtApprovalCount.Value = txtCount.Value;
            GetFinalPrice();
        }

        private void txtSelforGift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSelforGift.SelectedIndex == 0)
            {
                txtRecipient.ReadOnly = true;
                txtRelationship.ReadOnly = true;
                txtReason.ReadOnly = true;
                txtPhoneNum.ReadOnly = true;
                txtRecipient.Text = "";
                txtRelationship.Text = "";
                txtReason.Text = "";
                txtPhoneNum.Text = "";
            }
            else
            {
                txtRecipient.ReadOnly = false;
                txtRelationship.ReadOnly = false;
                txtReason.ReadOnly = false;
                txtPhoneNum.ReadOnly = false;
            }

        }

        private void dgvApplyProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvApplyProducts.Rows)
            {
                if (dgvr.Cells["SelforGift"] != null && dgvr.Cells["SelforGift"].Value != null && dgvr.Cells["SelforGift"].Value.ToString() != "")
                {
                    if ((int)dgvr.Cells["SelforGift"].Value == 1) dgvr.Cells["SelforGiftState"].Value = "自用";
                    else dgvr.Cells["SelforGiftState"].Value = "送礼";
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
                decimal MoneyDiscont = 1;
                switch (row["MoneyUnit"].ToString())
                {
                    case "1":
                    default:
                        MoneyDiscont = 1;
                        break;
                    case "2":
                        MoneyDiscont = EmailControl.config.USrate;
                        break;
                    case "3":
                        MoneyDiscont = EmailControl.config.HKrate;
                        break;
                    case "4":
                        MoneyDiscont = EmailControl.config.MOPrate;
                        break;
                    case "5":
                        MoneyDiscont = EmailControl.config.SGDrate;
                        break;
                    case "6":
                        MoneyDiscont = EmailControl.config.MYRrate;
                        break;
                    case "7":
                        MoneyDiscont = EmailControl.config.GBPrate;
                        break;
                    case "8":
                        MoneyDiscont = EmailControl.config.EURrate;
                        break;
                    case "9":
                        MoneyDiscont = EmailControl.config.JPYrate;
                        break;
                    case "10":
                        MoneyDiscont = EmailControl.config.TWDrate;
                        break;
                }
                if (items.SelectItemByItemID(row["ItemID"].ToString()).Rows[0]["IsSpecial"].ToString() == "1")
                {

                }
                else
                {
                    totalPrice += double.Parse(row["Price"].ToString()) * double.Parse(row["Count"].ToString()) * double.Parse(row["ApprovalDiscount"].ToString()) / 100.00 * Convert.ToDouble(MoneyDiscont);
                }
            }
            if (AddApplicationDT.Rows.Count == 0)
            {
                MessageBox.Show("申请表中未添加项目内容");
            }
            else if (Login.LoginUser.RestAmount - totalPrice < 0)
            {
                MessageBox.Show("当前余额不足");
            }
            else if (applicationInfo.SelectApplicationByTransNo(txtTransNo.Text).Rows.Count > 0)
            {
                MessageBox.Show("已存在该交易号");
            }
            else
            {
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
                dr["SalesDate"] = txtDeadline.Value.AddYears(3);
                dr["ApprovalDate"] = txtDeadline.Value.AddYears(3);
                dr["ApprovalDate2"] = txtDeadline.Value.AddYears(3);
                dr["PurchaseLocation"] = txtPurchaseLocation.Text;
                dr["IsDelete"] = 0;
                dr["AppState"] = 0;
                dr["ApprovalState"] = 0;
                dr["ApprovalState2"] = 0;
                dr["Approval2"] = Login.LoginUser.ManagerID;
                dr["StaffApproval"] = 0;
                dr["MoneyUnit"] = AddApplicationDT.Rows[0]["MoneyUnit"];
                foreach (DataRow addDr in AddApplicationDT.Rows)
                {
                    addDr["TransNo"] = dr["TransNo"];
                }
                AddAppInfoDT.Rows.Add(dr);
                try
                {
                    applicationInfo.SubmitApplicationInfo(AddAppInfoDT, totalPrice, Login.LoginUser.UID,0);
                    applicationDetail.SubmitApplicationDetail(AddApplicationDT, totalPrice, Login.LoginUser.UID,1);

                    Thread thread = new Thread(new ThreadStart(SendEmail));
                    thread.Start();


                    MessageBox.Show("提交成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("提交失败，错误信息：" + ex.Message);
                }
            }
        }

        void SendEmail()
        {
            EmailControl.ToApplicantSubmit2(txtTransNo.Text, Login.LoginUser.UID, txtApplicantsName.Text, DateTime.Now.ToString());
        }

        private void txtMoneyUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            items.ItemsDT = items.SelectItemByItemID(txtItemID.Text.Trim());
            if (items.ItemsDT.Rows.Count > 0)
            {
                string priceCol = "Price";
                //if (txtMoneyUnit.SelectedIndex == 0) priceCol = "Price";
                //if (txtMoneyUnit.SelectedIndex == 1) priceCol = "Price2";
                //if (txtMoneyUnit.SelectedIndex == 2) priceCol = "Price3";
                if (txtMoneyUnit.SelectedIndex == 0)
                {
                    priceCol = "Price";
                }
                else
                {
                    priceCol = "Price" + (txtMoneyUnit.SelectedIndex + 1).ToString();
                }
                //decimal MoneyDiscont = 1;
                //switch (txtMoneyUnit.SelectedIndex)
                //{
                //    case 0:
                //        MoneyDiscont = 1;
                //        break;
                //    case 1:
                //        MoneyDiscont = EmailControl.config.USrate;
                //        break;
                //    case 2:
                //        MoneyDiscont = EmailControl.config.HKrate;
                //        break;
                //    case 3:
                //        MoneyDiscont = EmailControl.config.MOPrate;
                //        break;
                //    case 4:
                //        MoneyDiscont = EmailControl.config.SGDrate;
                //        break;
                //    case 5:
                //        MoneyDiscont = EmailControl.config.MYRrate;
                //        break;
                //    case 6:
                //        MoneyDiscont = EmailControl.config.GBPrate;
                //        break;
                //    case 7:
                //        MoneyDiscont = EmailControl.config.EURrate;
                //        break;
                //    case 8:
                //        MoneyDiscont = EmailControl.config.JPYrate;
                //        break;
                //    case 9:
                //        MoneyDiscont = EmailControl.config.TWDrate;
                //        break;
                //}
                if (items.ItemsDT != null && items.ItemsDT.Rows.Count > 0 && items.ItemsDT.Rows[0][priceCol].ToString() != "")
                {
                    //if (MoneyDiscont == 0) MoneyDiscont = 1;
                    txtPrice.Value = decimal.Parse(items.ItemsDT.Rows[0][priceCol].ToString());
                }

            }
        }

        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {
            txtCount_ValueChanged(null, null);
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
                    txtApprovalDiscount.Value = 70;
                    break;
                case 4:
                    txtApprovalDiscount.Value = 60;
                    break;
                case 5:
                    txtApprovalDiscount.Value = 50;
                    break;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            CalFlag++;
            if (CalFlag > 5)
            {
                txtIsSpecial.Visible = true;
                txtApprovalCount.Visible = true;
            }

        }

        private void frmAddApplication_Load(object sender, EventArgs e)
        {

        }
    }
}
