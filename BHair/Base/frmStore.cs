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
    public partial class frmStore : Form
    {
        Store store = new Store();
        /// <summary>添加店面</summary>
        public frmStore()
        {
            InitializeComponent();
        }

        public frmStore(string StoreName)
        {
            InitializeComponent();
            this.Text = "修改店面信息";
            btnOk.Text = "修改";
            txtStoreName.ReadOnly = true;
            store.StoreDT=store.SelectStoreInfoByStoreName(StoreName);
            if(store.StoreDT.Rows.Count>0)
            {
                txtStoreName.Text = store.StoreDT.Rows[0]["StoreName"].ToString();
                txtStoreAddress.Text = store.StoreDT.Rows[0]["Address"].ToString();
                //txtContact.Text = store.StoreDT.Rows[0]["Contact"].ToString();
                txtTel.Text = store.StoreDT.Rows[0]["Tel"].ToString();
            }
            else
            {
                MessageBox.Show("无法获取店面信息！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Text == "新增店面")
            {
                if (this.txtStoreName.Text.Trim() == "")
                {
                    MessageBox.Show("店面名称不能为空，请输入！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtStoreName.Focus();
                    return;
                }
                if (store.SelectStoreInfoByStoreName(txtStoreName.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("店面名称已存在，请重新输入！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtStoreName.Focus();
                    return;
                }

                try
                {
                    store.StoreDT = store.SelectStoreInfoByStoreName("");
                    DataRow dr = store.StoreDT.NewRow();
                    dr["StoreName"] = txtStoreName.Text.Trim();
                    dr["Address"] = txtStoreAddress.Text.Trim();
                    //dr["Contact"] = txtContact.Text.Trim();
                    dr["Tel"] = txtTel.Text.Trim();
                    dr["IsDelete"] = 0;
                    store.StoreDT.Rows.Add(dr);
                    store.InsertStoreInfo(store.StoreDT);
                    MessageBox.Show("添加成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
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
                    store.StoreDT.Rows[0]["Address"]=txtStoreAddress.Text;
                    //store.StoreDT.Rows[0]["Contact"] = txtContact.Text;
                    store.StoreDT.Rows[0]["Tel"] = txtTel.Text;
                    store.UpdateStoreInfo(store.StoreDT);
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
