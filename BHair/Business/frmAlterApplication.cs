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
    public partial class frmAlterApplication : WinFormsUI.Docking.DockContent
    {
        Business.BaseData.Items items = new BaseData.Items();
        int EditState = 0;
        string OldTransNo;
        bool ExcitItemID=false;
        int codeID = 0;
        DataTable AddApplicationDT;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        /// <summary>内购申请单编辑</summary>
        public frmAlterApplication(ApplicationInfo ai)
        {
            InitializeComponent();
            applicationInfo = ai;
            OldTransNo = ai.TransNo;
            GetDataTable();
            LoadComBox();
            LoadAppData();

            if (Login.LoginUser.Character == 1)
            {
                txtTotalPrice.ReadOnly = false;
                txtTransNo.ReadOnly = false;
                label11.Visible = true;
                txtEditReason.Visible = true;
            }

            groupBox1.Text = string.Format("如果产品作为赠礼且零售价超过{0}人民币，请填写以下信息", EmailControl.config.CNY);
            groupBox3.Text = string.Format("赠礼明细(超过{0}人民币必填)", EmailControl.config.CNY);
        }

        void GetDataTable()
        {

            applicationInfo.applicationDT = applicationInfo.SelectApplicationByTransNo(OldTransNo);

            AddApplicationDT = applicationDetail.SelectAppDetailByTransNo(applicationInfo.TransNo,"");
            dgvApplyProducts.AutoGenerateColumns = false;
            dgvApplyProducts.DataSource = AddApplicationDT;

            dgvApplyGift.AutoGenerateColumns = false;
            dgvApplyGift.DataSource = AddApplicationDT;

            int MaxID=0;
            foreach(DataRow dr in AddApplicationDT.Rows)
            {
                if((int)dr["ID"]>MaxID)
                {
                    MaxID = (int)dr["ID"];
                    codeID = int.Parse(dr["CodeID"].ToString());
                }
            }
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
            //if (Login.LoginUser.MoneyUnit>1) txtMoneyUnit.SelectedIndex = Login.LoginUser.MoneyUnit - 1;

            txtSelforGift.Items.Add("自用");
            txtSelforGift.Items.Add("送礼");
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
                //txtPrice.Value = decimal.Parse(items.ItemsDT.Rows[0]["Price"].ToString());


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
            decimal GiftTotal = 0;
            if (txtMoneyUnit.SelectedIndex == 2) GiftTotal = EmailControl.config.HKD;
            else if (txtMoneyUnit.SelectedIndex == 1) GiftTotal = EmailControl.config.USD;
            else GiftTotal = EmailControl.config.CNY;
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
                    dr["ApprovalCount"] = txtApprovalCount.Value;
                    dr["ApprovalDiscount"] = txtApprovalDiscount.Value;
                    dr["FinalPrice"] = txtFinalPrice.Value;
                    dr["Recipient"] = txtRecipient.Text;
                    dr["Relationship"] = txtRelationship.Text;
                    dr["Reason"] = txtReason.Text;
                    dr["PhoneNum"] = txtPhoneNum.Text;

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
                    if (dr.RowState == DataRowState.Deleted)  dr.Delete();  
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
                        AddApplicationDT.Rows[i]["CodeID"] = i + 1-deleteRowsCount;
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
            txtApprovalCount.Maximum = txtCount.Value;
        }

        private void txtSelforGift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtSelforGift.SelectedIndex==0)
            {
                txtRecipient.ReadOnly = true;
                txtRelationship.ReadOnly = true;
                txtReason.ReadOnly = true;
                txtPhoneNum.ReadOnly = true;
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
                if (dgvr.Cells["SelforGift"] != null && dgvr.Cells["SelforGift"].Value != null && dgvr.Cells["SelforGift"].Value.ToString()!="")
                {
                    if ((int)dgvr.Cells["SelforGift"].Value == 1) dgvr.Cells["SelforGiftState"].Value = "自用";
                    else dgvr.Cells["SelforGiftState"].Value = "送礼";
                }
                if (dgvr.Cells["IsSuccess"] != null && dgvr.Cells["IsSuccess"].Value != null && dgvr.Cells["IsSuccess"].Value.ToString() != "")
                {
                    if ((int)dgvr.Cells["IsSuccess"].Value == 1) dgvr.Cells["IsSuccessState"].Value = "已购买";
                    else dgvr.Cells["IsSuccessState"].Value = "未购买";
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
            DataTable AddAppInfoDT = applicationInfo.SelectApplicationByTransNo(OldTransNo);
            if (AddApplicationDT.Rows.Count == 0)
            {
                MessageBox.Show("申请表中未添加项目内容");
            }
            else if (txtTransNo.Text == null || txtTransNo.Text.Length == 0)
            {
                MessageBox.Show("请填写交易号");
            }
            else if(OldTransNo!=applicationInfo.TransNo&&applicationInfo.SelectApplicationByTransNo(applicationInfo.TransNo).Rows.Count>0)
            {
                MessageBox.Show("已存在该交易号");
            }
            else
            {
                if (Login.LoginUser.Character == 1)
                {
                    frmEditReason fer = new frmEditReason(applicationInfo.EditReason);
                    if (fer.ShowDialog() == DialogResult.OK)
                    {
                        AddAppInfoDT.Rows[0]["EditReason"] = fer.EditReasonString;

                        AddAppInfoDT.Rows[0]["TransNo"] = txtTransNo.Text;
                        AddAppInfoDT.Rows[0]["ApplicantsName"] = txtApplicantsName.Text;
                        AddAppInfoDT.Rows[0]["ApplicantsNo"] = txtApplicantsNo.Text;
                        AddAppInfoDT.Rows[0]["Location"] = txtLocation.Text;
                        AddAppInfoDT.Rows[0]["TotalPrice"] = txtTotalPrice.Value;
                        AddAppInfoDT.Rows[0]["Deadline"] = txtDeadline.Value;
                        AddAppInfoDT.Rows[0]["PurchaseLocation"] = txtPurchaseLocation.Text;
                        AddAppInfoDT.Rows[0]["MoneyUnit"] = AddApplicationDT.Rows[0]["MoneyUnit"];
                        foreach (DataRow addDr in AddApplicationDT.Rows)
                        {
                            if (addDr.RowState != DataRowState.Deleted)
                                addDr["TransNo"] = applicationInfo.TransNo;
                        }
                        try
                        {
                            applicationInfo.UpdateApplicationInfo(AddAppInfoDT);
                            applicationDetail.UpdateApplicationDetail(AddApplicationDT);
                            //if (EditState == 1)
                            //{
                            //    applicationInfo.ApprovalNotApplication(txtTransNo.Text,Login.LoginUser.UID,Login.LoginUser.UserName,2,DateTime.Now);
                            //    EmailControl.ToEmployeeConfirm(applicationInfo);
                            //}
                            MessageBox.Show("提交成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("提交失败，错误信息：" + ex.Message);
                        }
                    }
                }
                else
                {
                    AddAppInfoDT.Rows[0]["TransNo"] = txtTransNo.Text;
                    AddAppInfoDT.Rows[0]["ApplicantsName"] = txtApplicantsName.Text;
                    AddAppInfoDT.Rows[0]["ApplicantsNo"] = txtApplicantsNo.Text;
                    AddAppInfoDT.Rows[0]["Location"] = txtLocation.Text;
                    AddAppInfoDT.Rows[0]["TotalPrice"] = txtTotalPrice.Value;
                    AddAppInfoDT.Rows[0]["Deadline"] = txtDeadline.Value;
                    AddAppInfoDT.Rows[0]["PurchaseLocation"] = txtPurchaseLocation.Text;
                    AddAppInfoDT.Rows[0]["MoneyUnit"] = AddApplicationDT.Rows[0]["MoneyUnit"];
                    AddAppInfoDT.Rows[0]["EditReason"] = txtEditReason.Text;
                    foreach (DataRow addDr in AddApplicationDT.Rows)
                    {
                        if (addDr.RowState != DataRowState.Deleted)
                            addDr["TransNo"] = applicationInfo.TransNo;
                    }
                    try
                    {
                        applicationInfo.UpdateApplicationInfo(AddAppInfoDT);
                        applicationDetail.UpdateApplicationDetail(AddApplicationDT);
                        //if (EditState == 1)
                        //{
                        //    applicationInfo.ApprovalNotApplication(txtTransNo.Text,Login.LoginUser.UID,Login.LoginUser.UserName,2,DateTime.Now);
                        //    EmailControl.ToEmployeeConfirm(applicationInfo);
                        //}
                        MessageBox.Show("提交成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("提交失败，错误信息：" + ex.Message);
                    }
                }
            }
        }

        void LoadAppData()
        {
            if(applicationInfo.applicationDT.Rows.Count>0)
            {
                txtApplicantsName.Text = applicationInfo.applicationDT.Rows[0]["ApplicantsName"].ToString();
                txtApplicantsNo.Text = applicationInfo.applicationDT.Rows[0]["ApplicantsNo"].ToString();
                txtLocation.Text = applicationInfo.applicationDT.Rows[0]["Location"].ToString();
                txtPurchaseLocation.Text = applicationInfo.applicationDT.Rows[0]["PurchaseLocation"].ToString();
                txtDeadline.Value = ((DateTime)applicationInfo.applicationDT.Rows[0]["Deadline"]);
                txtTotalPrice.Value = decimal.Parse(applicationInfo.applicationDT.Rows[0]["TotalPrice"].ToString());
                txtTransNo.Text = OldTransNo;
                txtEditReason.Text = applicationInfo.applicationDT.Rows[0]["EditReason"].ToString();
            }
        }

        public void GetEditState()
        {
            EditState = 1;
        }

        private void dgvApplyProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvApplyProducts.RowCount > 0&&dgvApplyProducts.SelectedRows.Count==1)
            {
                txtItemID.Text = dgvApplyProducts.SelectedRows[0].Cells["ItemID"].Value.ToString();
                txtDetail.Text = dgvApplyProducts.SelectedRows[0].Cells["Detail"].Value.ToString();
                txtMoneyUnit.SelectedIndex = int.Parse(dgvApplyProducts.SelectedRows[0].Cells["MoneyUnit"].Value.ToString()) - 1;
                txtPrice.Value = decimal.Parse(dgvApplyProducts.SelectedRows[0].Cells["Price"].Value.ToString());                
                txtCount.Value = decimal.Parse(dgvApplyProducts.SelectedRows[0].Cells["Count"].Value.ToString());
                txtSelforGift.SelectedIndex = int.Parse(dgvApplyProducts.SelectedRows[0].Cells["SelforGift"].Value.ToString()) -1;
                txtApprovalCount.Value = decimal.Parse(dgvApplyProducts.SelectedRows[0].Cells["ApprovalCount"].Value.ToString());
                txtApprovalDiscount.Value = decimal.Parse(dgvApplyProducts.SelectedRows[0].Cells["ApprovalDiscount"].Value.ToString());
                txtFinalPrice.Value = decimal.Parse(dgvApplyProducts.SelectedRows[0].Cells["FinalPrice"].Value.ToString());
                txtRecipient.Text = dgvApplyProducts.SelectedRows[0].Cells["Recipient"].Value.ToString();
                txtRelationship.Text = dgvApplyProducts.SelectedRows[0].Cells["Relationship"].Value.ToString();
                txtReason.Text = dgvApplyProducts.SelectedRows[0].Cells["Reason"].Value.ToString();
                txtPhoneNum.Text = dgvApplyProducts.SelectedRows[0].Cells["PhoneNum"].Value.ToString();
                switch(txtApprovalDiscount.Value.ToString())
                {
                    case "100":
                    default:
                        cbDiscount.SelectedIndex = 0;
                        break;
                    case "80":
                        cbDiscount.SelectedIndex = 1;
                        break;
                    case "75":
                        cbDiscount.SelectedIndex = 2;
                        break;
                    case "60":
                        cbDiscount.SelectedIndex = 3;
                        break;
                    case "50":
                        cbDiscount.SelectedIndex = 4;
                        break;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BaseData.Items items = new BaseData.Items();
                DataTable ItemDT = items.SelectItemByItemID(txtItemID.Text);
                if (ItemDT.Rows.Count > 0)
                {
                    //dgvApplyProducts.SelectedRows[0].Cells["ItemID"].Value = txtItemID.Text;
                    //dgvApplyProducts.SelectedRows[0].Cells["Detail"].Value = txtDetail.Text;
                    //dgvApplyProducts.SelectedRows[0].Cells["Price"].Value = txtPrice.Value;
                    //dgvApplyProducts.SelectedRows[0].Cells["MoneyUnit"].Value = txtMoneyUnit.SelectedIndex + 1;
                    //dgvApplyProducts.SelectedRows[0].Cells["Count"].Value = txtCount.Value;
                    //dgvApplyProducts.SelectedRows[0].Cells["SelforGift"].Value = txtSelforGift.SelectedIndex + 1;
                    //dgvApplyProducts.SelectedRows[0].Cells["ApprovalCount"].Value = txtApprovalCount.Value;
                    //dgvApplyProducts.SelectedRows[0].Cells["ApprovalDiscount"].Value = txtApprovalDiscount.Value;
                    //dgvApplyProducts.SelectedRows[0].Cells["FinalPrice"].Value = txtFinalPrice.Value;
                    //dgvApplyProducts.SelectedRows[0].Cells["Recipient"].Value = txtRecipient.Text;
                    //dgvApplyProducts.SelectedRows[0].Cells["Relationship"].Value = txtRelationship.Text;
                    //dgvApplyProducts.SelectedRows[0].Cells["Reason"].Value = txtReason.Text;
                    foreach (DataRow dr in AddApplicationDT.Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted&&dr["CodeID"].ToString() == dgvApplyProducts.SelectedRows[0].Cells["dgvCodeID"].Value.ToString())
                        {
                            dr["ItemID"] = txtItemID.Text;
                            dr["Detail"] = txtDetail.Text;
                            dr["Price"] = txtPrice.Value;
                            dr["MoneyUnit"] = txtMoneyUnit.SelectedIndex + 1;
                            dr["Count"] = txtCount.Value;
                            dr["SelforGift"] = txtSelforGift.SelectedIndex + 1;
                            dr["ApprovalCount"] = txtApprovalCount.Value;
                            dr["ApprovalDiscount"] = txtApprovalDiscount.Value;
                            dr["FinalPrice"] = txtFinalPrice.Value;
                            dr["Recipient"] = txtRecipient.Text;
                            dr["Relationship"] = txtRelationship.Text;
                            dr["Reason"] = txtReason.Text;
                            dr["PhoneNum"] = txtPhoneNum;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("不存在该货号");
                }
            GetTotalPrice();
        }

        private void txtMoneyUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            items.ItemsDT = items.SelectItemByItemID(txtItemID.Text.Trim());
            if (items.ItemsDT.Rows.Count > 0)
            {
                string priceCol = "Price";
                if (txtMoneyUnit.SelectedIndex == 0) priceCol = "Price";
                if (txtMoneyUnit.SelectedIndex == 1) priceCol = "Price2";
                if (txtMoneyUnit.SelectedIndex == 2) priceCol = "Price3";
                txtPrice.Value = decimal.Parse(items.ItemsDT.Rows[0][priceCol].ToString());
            }
        }

        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {
            GetFinalPrice();
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

        private void dgvApplyProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
