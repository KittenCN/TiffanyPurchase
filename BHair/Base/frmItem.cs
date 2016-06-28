using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.BaseData;

namespace BHair.Base
{
    public partial class frmItem : Form
    {
        Items item = new Items();
        /// <summary>添加商品</summary>
        public frmItem()
        {
            InitializeComponent();
        }

        public frmItem(string ItemID)
        {
            InitializeComponent();
            this.Text = "修改商品信息";
            btnOk.Text = "修改";
            txtItemID.ReadOnly = true;
            item.ItemsDT = item.SelectItemByItemID(ItemID);
            if (item.ItemsDT.Rows.Count > 0)
            {
                txtItemID.Text = item.ItemsDT.Rows[0]["ItemID"].ToString();
                txtPrice.Text = item.ItemsDT.Rows[0]["Price"].ToString();
                txtPrice2.Text = item.ItemsDT.Rows[0]["Price2"].ToString();
                txtPrice3.Text = item.ItemsDT.Rows[0]["Price3"].ToString();
                txtItemName.Text = item.ItemsDT.Rows[0]["ItemName"].ToString();
                txtDetail.Text = item.ItemsDT.Rows[0]["Detail"].ToString();
                if(item.ItemsDT.Rows[0]["IsSpecial"].ToString()=="1")
                {
                    cbIsSpecial.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("无法获取商品信息！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Text == "新增商品")
            {
                if (this.txtItemID.Text.Trim() == "")
                {
                    MessageBox.Show("货号不能为空，请输入！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtItemID.Focus();
                    return;
                }
                if (item.SelectItemByItemID(txtItemID.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("货号已存在，请重新输入！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtItemID.Focus();
                    return;
                }

                try
                {
                    item.ItemsDT = item.SelectItemByItemID("");
                    DataRow dr = item.ItemsDT.NewRow();
                    dr["ItemID"] = txtItemID.Text.Trim();
                    dr["Price"] = txtPrice.Value;
                    dr["Price2"] = txtPrice2.Value;
                    dr["Price3"] = txtPrice3.Value;
                    dr["ItemName"] = txtItemName.Text.Trim();
                    dr["Detail"] = txtDetail.Text.Trim();
                    dr["IsDelete"] = 0;
                    if (cbIsSpecial.Checked) dr["IsSpecial"] = 1;
                    else dr["IsSpecial"] = 0;
                    item.ItemsDT.Rows.Add(dr);
                    item.InsertItems(item.ItemsDT);
                    MessageBox.Show("添加成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("添加失败！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                try
                {
                    item.ItemsDT.Rows[0]["Price"] = txtPrice.Value;
                    item.ItemsDT.Rows[0]["Price2"] = txtPrice2.Value;
                    item.ItemsDT.Rows[0]["Price3"] = txtPrice3.Value;
                    item.ItemsDT.Rows[0]["ItemName"] = txtItemName.Text;
                    item.ItemsDT.Rows[0]["Detail"] = txtDetail.Text;
                    if (cbIsSpecial.Checked) item.ItemsDT.Rows[0]["IsSpecial"] = 1;
                    else item.ItemsDT.Rows[0]["IsSpecial"] = 0;
                    item.UpdateItems(item.ItemsDT);
                    MessageBox.Show("修改成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("修改失败！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
                DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
