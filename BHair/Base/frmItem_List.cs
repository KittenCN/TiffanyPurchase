using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.BaseData;
using BHair.Business;

namespace BHair.Base
{
    public partial class frmItem_List : WinFormsUI.Docking.DockContent
    {
        Items items = new Items();
        public frmItem_List()
        {
            InitializeComponent();
            LoadItemList();
        }

        /// <summary>加载商品列表</summary>
        private void LoadItemList()
        {
            items.ItemsDT = items.SelectAllItem();
            dgvItem.AutoGenerateColumns = false;
            dgvItem.DataSource = items.ItemsDT;
        }




        /// <summary>新增</summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmItem objfrmItem = new frmItem();
            if (objfrmItem.ShowDialog() == DialogResult.OK)
            {
                this.LoadItemList();
            }
        }

        /// <summary>修改</summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            this.ShowItem();
        }

        private void dgvSubject_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.ShowItem();
            }
        }

        /// <summary>显示店面窗口</summary>
        private void ShowItem()
        {
            if (this.dgvItem.CurrentRow != null)
            {
                string ItemID = this.dgvItem.CurrentRow.Cells[1].Value.ToString();
                frmItem objfrmItem = new frmItem(ItemID);
                if (objfrmItem.ShowDialog() == DialogResult.OK)
                {
                    this.LoadItemList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("是否删除该商品", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (this.dgvItem.CurrentRow != null)
            {
                string CurrentID = dgvItem.CurrentRow.Cells["ID"].Value.ToString();
                try
                {
                    items.DeleteItem(CurrentID);
                    MessageBox.Show("已删除该商品", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadItemList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frmItem_Import objfrmItem_Import = new frmItem_Import();
            if (objfrmItem_Import.ShowDialog() == DialogResult.OK)
            {
                this.LoadItemList();
            }
        }

        

    }
}
