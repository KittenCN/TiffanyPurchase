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
    public partial class frmStore_List : WinFormsUI.Docking.DockContent
    {
        Store store = new Store();
        public frmStore_List()
        {
            InitializeComponent();
            LoadStoreList();
        }

        /// <summary>加载店面列表</summary>
        private void LoadStoreList()
        {
            store.StoreDT = store.SelectAllStoreInfo();
            dgvStore.DataSource = store.StoreDT;
        }




        /// <summary>新增</summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStore objfrmStore = new frmStore();
            if (objfrmStore.ShowDialog() == DialogResult.OK)
            {
                this.LoadStoreList();
            }
        }

        /// <summary>修改</summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            this.ShowStore();
        }

        private void dgvSubject_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.ShowStore();
            }
        }

        /// <summary>显示店面窗口</summary>
        private void ShowStore()
        {
            if (this.dgvStore.CurrentRow != null)
            {
                string StoreName = this.dgvStore.CurrentRow.Cells[1].Value.ToString();
                frmStore objfrmStore = new frmStore(StoreName);
                if (objfrmStore.ShowDialog() == DialogResult.OK)
                {
                    this.LoadStoreList();
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("是否移除该店面", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (this.dgvStore.CurrentRow != null)
            {
                string CurrentID = dgvStore.CurrentRow.Cells["ID"].Value.ToString();
                try
                {
                    store.DeleteStore(CurrentID);
                    MessageBox.Show("已移除该店面", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStoreList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        

    }
}
