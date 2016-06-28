namespace BHair.Base
{
    partial class frmConfig
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
            this.btnOk = new System.Windows.Forms.Button();
            this.txtEmailID = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHKD = new System.Windows.Forms.NumericUpDown();
            this.txtUSD = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCNY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmailSMTP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtUSrate = new System.Windows.Forms.NumericUpDown();
            this.txtHKrate = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtHKD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSD)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCNY)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHKrate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(222, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(141, 365);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtEmailID
            // 
            this.txtEmailID.Location = new System.Drawing.Point(78, 17);
            this.txtEmailID.MaxLength = 30;
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Size = new System.Drawing.Size(197, 21);
            this.txtEmailID.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 12);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Email账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "Email密码";
            // 
            // txtEmailPwd
            // 
            this.txtEmailPwd.Location = new System.Drawing.Point(78, 46);
            this.txtEmailPwd.MaxLength = 30;
            this.txtEmailPwd.Name = "txtEmailPwd";
            this.txtEmailPwd.PasswordChar = '*';
            this.txtEmailPwd.Size = new System.Drawing.Size(197, 21);
            this.txtEmailPwd.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "SMTP地址";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(78, 73);
            this.txtEmailAddress.MaxLength = 30;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(197, 21);
            this.txtEmailAddress.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "港币赠礼上限";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "美元赠礼上限";
            // 
            // txtHKD
            // 
            this.txtHKD.DecimalPlaces = 2;
            this.txtHKD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtHKD.Location = new System.Drawing.Point(112, 59);
            this.txtHKD.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtHKD.Name = "txtHKD";
            this.txtHKD.Size = new System.Drawing.Size(163, 21);
            this.txtHKD.TabIndex = 26;
            // 
            // txtUSD
            // 
            this.txtUSD.DecimalPlaces = 2;
            this.txtUSD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtUSD.Location = new System.Drawing.Point(112, 91);
            this.txtUSD.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtUSD.Name = "txtUSD";
            this.txtUSD.Size = new System.Drawing.Size(163, 21);
            this.txtUSD.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCNY);
            this.groupBox1.Controls.Add(this.txtUSD);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtHKD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 119);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "赠礼上限设置，超过上限填写赠礼详情";
            // 
            // txtCNY
            // 
            this.txtCNY.DecimalPlaces = 2;
            this.txtCNY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtCNY.Location = new System.Drawing.Point(112, 26);
            this.txtCNY.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtCNY.Name = "txtCNY";
            this.txtCNY.Size = new System.Drawing.Size(163, 21);
            this.txtCNY.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "人民币赠礼上限";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEmailSMTP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtEmailAddress);
            this.groupBox2.Controls.Add(this.txtEmailPwd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtEmailID);
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Location = new System.Drawing.Point(3, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 130);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "邮箱设置";
            // 
            // txtEmailSMTP
            // 
            this.txtEmailSMTP.Location = new System.Drawing.Point(78, 101);
            this.txtEmailSMTP.MaxLength = 30;
            this.txtEmailSMTP.Name = "txtEmailSMTP";
            this.txtEmailSMTP.Size = new System.Drawing.Size(197, 21);
            this.txtEmailSMTP.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "Email地址";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtHKrate);
            this.groupBox3.Controls.Add(this.txtUSrate);
            this.groupBox3.Location = new System.Drawing.Point(3, 274);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 85);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "汇率设置";
            // 
            // txtUSrate
            // 
            this.txtUSrate.DecimalPlaces = 2;
            this.txtUSrate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtUSrate.Location = new System.Drawing.Point(112, 17);
            this.txtUSrate.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtUSrate.Name = "txtUSrate";
            this.txtUSrate.Size = new System.Drawing.Size(163, 21);
            this.txtUSrate.TabIndex = 29;
            // 
            // txtHKrate
            // 
            this.txtHKrate.DecimalPlaces = 2;
            this.txtHKrate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtHKrate.Location = new System.Drawing.Point(112, 50);
            this.txtHKrate.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtHKrate.Name = "txtHKrate";
            this.txtHKrate.Size = new System.Drawing.Size(163, 21);
            this.txtHKrate.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "美元兑人民币";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "港币兑人民币";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 400);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统设置";
            ((System.ComponentModel.ISupportInitialize)(this.txtHKD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCNY)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHKrate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtEmailID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtHKD;
        private System.Windows.Forms.NumericUpDown txtUSD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown txtCNY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEmailSMTP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown txtHKrate;
        private System.Windows.Forms.NumericUpDown txtUSrate;
    }
}