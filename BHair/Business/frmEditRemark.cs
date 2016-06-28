﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BHair.Business
{
    public partial class frmEditRemark : Form
    {
        public string EditReasonString;
        public frmEditRemark()
        {
            InitializeComponent();
        }

        public frmEditRemark(string oldEditReason)
        {
            InitializeComponent();
            EditReasonString = oldEditReason;
            //txtEditReason.Text = EditReasonString;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditReasonString += Login.LoginUser.UserName+":"+ txtEditReason.Text+"|";
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
