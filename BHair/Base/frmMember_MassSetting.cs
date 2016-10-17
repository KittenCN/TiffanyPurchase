using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BHair.Business.BaseData;
using BHair.Business;

namespace BHair.Base
{
    public partial class frmMember_MassSetting : Form
    {
        public frmMember_MassSetting()
        {
            InitializeComponent();           
        }

        private void frmMember_MassSetting_Load(object sender, EventArgs e)
        {
            LoadComBox();
            rbMassFrozen.Checked = false;
            rbMassSettingStore.Checked = false;
        }

        private void rbMassSettingStore_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMassSettingStore.Checked==true)
            {
                rbMassFrozen.Checked = false;
                cbStore.Enabled = true;
                cbAbleMode.Enabled = false;
            }
            else
            {
                cbStore.Enabled = false;
            }
        }

        private void rbMassFrozen_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMassFrozen.Checked==true)
            {
                rbMassSettingStore.Checked = false;
                cbStore.Enabled = false;
                cbAbleMode.Enabled = true;
            }
            else
            {
                cbAbleMode.Enabled = false;
            }
        }

        void LoadComBox()
        {
            Store store = new Store();
            DataTable AllStore = new DataTable();
            AllStore = store.SelectAllStoreInfo(" order by StoreName ");
            foreach (DataRow dr in AllStore.Rows)
            {
                cbStore.DataSource = AllStore;
                cbStore.DisplayMember = "StoreName";
                cbStore.ValueMember = "StoreName";
            }
            cbAbleMode.Items.Add("临时冻结");
            cbAbleMode.Items.Add("永久冻结");
            cbAbleMode.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            BHair.Business.Table.frmMember_MassSetting fmms = new BHair.Business.Table.frmMember_MassSetting();
            if (rbMassFrozen.Checked==true)
            {
                int successRows = 0;
                foreach (DataRow dr in BHair.Business.Table.frmMember_MassSetting.dt.Rows)
                {
                    if (dr["selected"].ToString() == "1")
                    {
                        successRows += fmms.intMassFrozen(dr["ID"].ToString(), int.Parse(cbAbleMode.SelectedIndex.ToString())+1);
                    }
                }
                MessageBox.Show("批量处理" + successRows + "条", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else if(rbMassSettingStore.Checked==true)
            {
                int successRows = 0;
                foreach (DataRow dr in BHair.Business.Table.frmMember_MassSetting.dt.Rows)
                {
                    if (dr["selected"].ToString() == "1")
                    {
                        successRows += fmms.intMassStore(dr["ID"].ToString(), cbStore.SelectedValue.ToString());
                    }
                }
                MessageBox.Show("批量处理" + successRows + "条", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择批量操作类型", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
