namespace BHair.Base
{
    partial class frmMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabMember = new System.Windows.Forms.TabControl();
            this.tabDetail = new System.Windows.Forms.TabPage();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.grpNotNull = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbManagerID = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRestAmount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMoneyUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblAffirm = new System.Windows.Forms.Label();
            this.txtAffirm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCharacter = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.lblCard = new System.Windows.Forms.Label();
            this.cbIsAdmin = new System.Windows.Forms.CheckBox();
            this.cbIsAble = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbStore = new System.Windows.Forms.ComboBox();
            this.tabMember.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.grpNotNull.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRestAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(410, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(318, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabMember
            // 
            this.tabMember.Controls.Add(this.tabDetail);
            this.tabMember.Location = new System.Drawing.Point(12, 171);
            this.tabMember.Name = "tabMember";
            this.tabMember.SelectedIndex = 0;
            this.tabMember.Size = new System.Drawing.Size(477, 175);
            this.tabMember.TabIndex = 5;
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.txtDepartment);
            this.tabDetail.Controls.Add(this.label3);
            this.tabDetail.Controls.Add(this.txtPosition);
            this.tabDetail.Controls.Add(this.label1);
            this.tabDetail.Controls.Add(this.txtEmail);
            this.tabDetail.Controls.Add(this.lblAddress);
            this.tabDetail.Controls.Add(this.txtTel);
            this.tabDetail.Controls.Add(this.lblPhone);
            this.tabDetail.Controls.Add(this.lblRemark);
            this.tabDetail.Controls.Add(this.txtDetail);
            this.tabDetail.Location = new System.Drawing.Point(4, 22);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetail.Size = new System.Drawing.Size(469, 149);
            this.tabDetail.TabIndex = 0;
            this.tabDetail.Text = "详细信息(可选)";
            this.tabDetail.UseVisualStyleBackColor = true;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(77, 61);
            this.txtDepartment.MaxLength = 18;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(151, 21);
            this.txtDepartment.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "部门：";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(77, 37);
            this.txtPosition.MaxLength = 18;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(151, 21);
            this.txtPosition.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "职位：";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(77, 89);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(231, 21);
            this.txtEmail.TabIndex = 10;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 92);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(71, 12);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Email地址：";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(77, 10);
            this.txtTel.MaxLength = 13;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(80, 21);
            this.txtTel.TabIndex = 8;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(6, 13);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(65, 12);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "联系电话：";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(15, 125);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(41, 12);
            this.lblRemark.TabIndex = 16;
            this.lblRemark.Text = "备注：";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(77, 122);
            this.txtDetail.MaxLength = 400;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(378, 21);
            this.txtDetail.TabIndex = 17;
            // 
            // grpNotNull
            // 
            this.grpNotNull.Controls.Add(this.cbStore);
            this.grpNotNull.Controls.Add(this.label8);
            this.grpNotNull.Controls.Add(this.button1);
            this.grpNotNull.Controls.Add(this.cbManagerID);
            this.grpNotNull.Controls.Add(this.label7);
            this.grpNotNull.Controls.Add(this.txtRestAmount);
            this.grpNotNull.Controls.Add(this.label6);
            this.grpNotNull.Controls.Add(this.txtTotalAmount);
            this.grpNotNull.Controls.Add(this.label5);
            this.grpNotNull.Controls.Add(this.cbMoneyUnit);
            this.grpNotNull.Controls.Add(this.label4);
            this.grpNotNull.Controls.Add(this.txtEmployeeID);
            this.grpNotNull.Controls.Add(this.groupBox1);
            this.grpNotNull.Controls.Add(this.label2);
            this.grpNotNull.Controls.Add(this.cboCharacter);
            this.grpNotNull.Controls.Add(this.lblLevel);
            this.grpNotNull.Controls.Add(this.txtUserName);
            this.grpNotNull.Controls.Add(this.lblName);
            this.grpNotNull.Controls.Add(this.txtUID);
            this.grpNotNull.Controls.Add(this.lblCard);
            this.grpNotNull.Location = new System.Drawing.Point(12, 12);
            this.grpNotNull.Name = "grpNotNull";
            this.grpNotNull.Size = new System.Drawing.Size(477, 153);
            this.grpNotNull.TabIndex = 4;
            this.grpNotNull.TabStop = false;
            this.grpNotNull.Text = "用户信息(必填)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "重置密码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbManagerID
            // 
            this.cbManagerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManagerID.Enabled = false;
            this.cbManagerID.FormattingEnabled = true;
            this.cbManagerID.Location = new System.Drawing.Point(71, 90);
            this.cbManagerID.Name = "cbManagerID";
            this.cbManagerID.Size = new System.Drawing.Size(80, 20);
            this.cbManagerID.TabIndex = 29;
            this.cbManagerID.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "直属经理：";
            this.label7.Visible = false;
            // 
            // txtRestAmount
            // 
            this.txtRestAmount.DecimalPlaces = 2;
            this.txtRestAmount.Enabled = false;
            this.txtRestAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtRestAmount.Location = new System.Drawing.Point(384, 119);
            this.txtRestAmount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtRestAmount.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.txtRestAmount.Name = "txtRestAmount";
            this.txtRestAmount.ReadOnly = true;
            this.txtRestAmount.Size = new System.Drawing.Size(83, 21);
            this.txtRestAmount.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "剩余额度：";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtTotalAmount.Location = new System.Drawing.Point(71, 121);
            this.txtTotalAmount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(80, 21);
            this.txtTotalAmount.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "货币类型：";
            // 
            // cbMoneyUnit
            // 
            this.cbMoneyUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoneyUnit.Enabled = false;
            this.cbMoneyUnit.FormattingEnabled = true;
            this.cbMoneyUnit.Location = new System.Drawing.Point(227, 120);
            this.cbMoneyUnit.Name = "cbMoneyUnit";
            this.cbMoneyUnit.Size = new System.Drawing.Size(80, 20);
            this.cbMoneyUnit.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "当年额度：";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(227, 25);
            this.txtEmployeeID.MaxLength = 30;
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.ReadOnly = true;
            this.txtEmployeeID.Size = new System.Drawing.Size(80, 21);
            this.txtEmployeeID.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.lblAffirm);
            this.groupBox1.Controls.Add(this.txtAffirm);
            this.groupBox1.Location = new System.Drawing.Point(313, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 72);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改密码";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(2, 19);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 12);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "用户密码：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(71, 14);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(83, 21);
            this.txtPassword.TabIndex = 13;
            // 
            // lblAffirm
            // 
            this.lblAffirm.AutoSize = true;
            this.lblAffirm.Location = new System.Drawing.Point(2, 44);
            this.lblAffirm.Name = "lblAffirm";
            this.lblAffirm.Size = new System.Drawing.Size(65, 12);
            this.lblAffirm.TabIndex = 14;
            this.lblAffirm.Text = "确认密码：";
            // 
            // txtAffirm
            // 
            this.txtAffirm.Location = new System.Drawing.Point(71, 41);
            this.txtAffirm.MaxLength = 20;
            this.txtAffirm.Name = "txtAffirm";
            this.txtAffirm.PasswordChar = '*';
            this.txtAffirm.Size = new System.Drawing.Size(83, 21);
            this.txtAffirm.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "员工编号：";
            // 
            // cboCharacter
            // 
            this.cboCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCharacter.Enabled = false;
            this.cboCharacter.FormattingEnabled = true;
            this.cboCharacter.Location = new System.Drawing.Point(71, 56);
            this.cboCharacter.Name = "cboCharacter";
            this.cboCharacter.Size = new System.Drawing.Size(80, 20);
            this.cboCharacter.TabIndex = 7;
            this.cboCharacter.SelectedIndexChanged += new System.EventHandler(this.cboCharacter_SelectedIndexChanged);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(6, 60);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(65, 12);
            this.lblLevel.TabIndex = 6;
            this.lblLevel.Text = "用户角色：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(227, 56);
            this.txtUserName.MaxLength = 30;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(80, 21);
            this.txtUserName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(157, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "用户姓名：";
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(71, 25);
            this.txtUID.MaxLength = 12;
            this.txtUID.Name = "txtUID";
            this.txtUID.ReadOnly = true;
            this.txtUID.Size = new System.Drawing.Size(80, 21);
            this.txtUID.TabIndex = 1;
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(6, 28);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(65, 12);
            this.lblCard.TabIndex = 0;
            this.lblCard.Text = "用户账号：";
            // 
            // cbIsAdmin
            // 
            this.cbIsAdmin.AutoSize = true;
            this.cbIsAdmin.Location = new System.Drawing.Point(20, 353);
            this.cbIsAdmin.Name = "cbIsAdmin";
            this.cbIsAdmin.Size = new System.Drawing.Size(120, 16);
            this.cbIsAdmin.TabIndex = 8;
            this.cbIsAdmin.Text = "是否为超级管理员";
            this.cbIsAdmin.UseVisualStyleBackColor = true;
            this.cbIsAdmin.Visible = false;
            // 
            // cbIsAble
            // 
            this.cbIsAble.AutoSize = true;
            this.cbIsAble.Location = new System.Drawing.Point(159, 353);
            this.cbIsAble.Name = "cbIsAble";
            this.cbIsAble.Size = new System.Drawing.Size(108, 16);
            this.cbIsAble.TabIndex = 9;
            this.cbIsAble.Text = "是否冻结该用户";
            this.cbIsAble.UseVisualStyleBackColor = true;
            this.cbIsAble.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(157, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "所属店面：";
            this.label8.Visible = false;
            // 
            // cbStore
            // 
            this.cbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStore.Enabled = false;
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Location = new System.Drawing.Point(227, 90);
            this.cbStore.Name = "cbStore";
            this.cbStore.Size = new System.Drawing.Size(80, 20);
            this.cbStore.TabIndex = 31;
            this.cbStore.Visible = false;
            // 
            // frmMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 384);
            this.Controls.Add(this.cbIsAble);
            this.Controls.Add(this.cbIsAdmin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabMember);
            this.Controls.Add(this.grpNotNull);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMember";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户信息";
            this.tabMember.ResumeLayout(false);
            this.tabDetail.ResumeLayout(false);
            this.tabDetail.PerformLayout();
            this.grpNotNull.ResumeLayout(false);
            this.grpNotNull.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRestAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabMember;
        private System.Windows.Forms.TabPage tabDetail;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.GroupBox grpNotNull;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtAffirm;
        private System.Windows.Forms.Label lblAffirm;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cboCharacter;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbIsAdmin;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.NumericUpDown txtRestAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtTotalAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMoneyUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbManagerID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbIsAble;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbStore;
        private System.Windows.Forms.Label label8;
    }
}