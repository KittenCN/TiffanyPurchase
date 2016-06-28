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
    public partial class frmItem_Import : WinFormsUI.Docking.DockContent
    {
        Items items = new Items();
        DataTable itemDT = new DataTable();
        string filePath = "";
        public frmItem_Import()
        {
            InitializeComponent();
            //LoadItemList();
        }

        /// <summary>加载商品列表</summary>
        private void LoadItemList()
        {
            items.ItemsDT = items.SelectAllItem();
            dgvItem.AutoGenerateColumns = false;
            dgvItem.DataSource = items.ItemsDT;
        }





        private void btnExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel文件|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    label1.Text = "正在导入Excel数据....";
                    filePath = openFileDialog.FileName;
                    ExcelHelper eh = new ExcelHelper();
                    DataTable tempDT = items.SelectItemByItemID("");
                    tempDT.Clear();
                    itemDT = eh.ExcelToDataTable_Items(filePath,tempDT);
                    dgvItem.AutoGenerateColumns = false;
                    dgvItem.DataSource = itemDT;
                    label1.Text = "Excel数据导入完成";
                }
                catch
                {
                    label1.Text = "Excel数据导入失败";
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            label1.Text = "正在导入到数据库....";
            try
            {
                //备份原item表
                items.BackupItem();
                //清空item表
                items.ClearItem();
                //插入新datatable表
                items.QuickInsertItems(itemDT);
                label1.Text = "数据库导入完成";
                DialogResult = DialogResult.OK;
            }
            catch
            {
                label1.Text = "数据库导入失败";
            }
        }

        

    }
}
