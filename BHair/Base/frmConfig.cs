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
    public partial class frmConfig : Form
    {
        SetupConfig setupConfig = new SetupConfig();
        /// <summary>添加店面</summary>
        public frmConfig()
        {
            InitializeComponent();
            btnOk.Text = "修改";
            EmailControl.config.GetConfig();

            txtEmailID.Text= EmailControl.config.EmailID;
            txtEmailPwd.Text = EmailControl.config.EmailPwd;
            txtEmailAddress.Text = EmailControl.config.EmailAddress;
            txtEmailSMTP.Text = EmailControl.config.EmailSMTP;
            txtHKD.Value = EmailControl.config.HKD;
            txtUSD.Value = EmailControl.config.USD;
            txtCNY.Value = EmailControl.config.CNY;
            txtEUR.Value = EmailControl.config.EUR;
            txtGBP.Value = EmailControl.config.GBP;
            txtJPY.Value = EmailControl.config.JPY;
            txtMOP.Value = EmailControl.config.MOP;
            txtMYR.Value = EmailControl.config.MYR;
            txtSGD.Value = EmailControl.config.SGD;
            txtTWD.Value = EmailControl.config.TWD;
            txtUSrate.Value = EmailControl.config.USrate;
            txtHKrate.Value = EmailControl.config.HKrate;
            EURrate.Value = EmailControl.config.EURrate;
            GBPrate.Value = EmailControl.config.GBPrate;
            JPYrate.Value = EmailControl.config.JPYrate;
            MOPrate.Value = EmailControl.config.MOPrate;
            MYRrate.Value = EmailControl.config.MYRrate;
            SGDrate.Value = EmailControl.config.SGDrate;
            TWDrate.Value = EmailControl.config.TWDrate;
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                EmailControl.config.EmailID = txtEmailID.Text;
                EmailControl.config.EmailPwd = txtEmailPwd.Text;
                EmailControl.config.EmailAddress = txtEmailAddress.Text;
                EmailControl.config.EmailSMTP = txtEmailSMTP.Text;
                EmailControl.config.HKD = txtHKD.Value;
                EmailControl.config.USD = txtUSD.Value;
                EmailControl.config.CNY = txtCNY.Value;
                EmailControl.config.EUR = txtEUR.Value;
                EmailControl.config.GBP = txtGBP.Value;
                EmailControl.config.JPY = txtJPY.Value;
                EmailControl.config.MOP = txtMOP.Value;
                EmailControl.config.MYR = txtMYR.Value;
                EmailControl.config.SGD = txtSGD.Value;
                EmailControl.config.TWD = txtTWD.Value;
                EmailControl.config.USrate = txtUSrate.Value;
                EmailControl.config.HKrate = txtHKrate.Value;
                EmailControl.config.EURrate = EURrate.Value;
                EmailControl.config.GBPrate = GBPrate.Value;
                EmailControl.config.JPYrate = JPYrate.Value;
                EmailControl.config.MOPrate = MOPrate.Value;
                EmailControl.config.MYRrate = MYRrate.Value;
                EmailControl.config.SGDrate = SGDrate.Value;
                EmailControl.config.TWDrate = TWDrate.Value;
                EmailControl.config.UpdateConfig();
                MessageBox.Show("修改成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("修改失败！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
