namespace BHair.Business
{
    partial class frmStoreApplicationInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAlter = new System.Windows.Forms.Button();
            this.dgvApplyInfo = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtEDate = new System.Windows.Forms.DateTimePicker();
            this.txtSDate = new System.Windows.Forms.DateTimePicker();
            this.TxtChoose = new System.Windows.Forms.TextBox();
            this.BtnChoose = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbMoneyUnit = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TransNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicantsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicantsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApprovalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyInfo)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnAlter);
            this.panel1.Location = new System.Drawing.Point(12, 479);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 82);
            this.panel1.TabIndex = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "店面购买确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAlter
            // 
            this.btnAlter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlter.Location = new System.Drawing.Point(869, 38);
            this.btnAlter.Name = "btnAlter";
            this.btnAlter.Size = new System.Drawing.Size(91, 23);
            this.btnAlter.TabIndex = 3;
            this.btnAlter.Text = "打印成Excel";
            this.btnAlter.UseVisualStyleBackColor = true;
            this.btnAlter.Click += new System.EventHandler(this.btnAlter_Click);
            // 
            // dgvApplyInfo
            // 
            this.dgvApplyInfo.AllowUserToAddRows = false;
            this.dgvApplyInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApplyInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplyInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApplyInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransNo,
            this.ApplicantsDate,
            this.ApplicantsName,
            this.ItemID,
            this.MoneyUnit,
            this.ApprovalCount,
            this.FinalPrice});
            this.dgvApplyInfo.Location = new System.Drawing.Point(12, 110);
            this.dgvApplyInfo.MultiSelect = false;
            this.dgvApplyInfo.Name = "dgvApplyInfo";
            this.dgvApplyInfo.RowTemplate.Height = 23;
            this.dgvApplyInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplyInfo.Size = new System.Drawing.Size(969, 360);
            this.dgvApplyInfo.TabIndex = 127;
            this.dgvApplyInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplyInfo_CellClick);
            this.dgvApplyInfo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvApplyInfo_CellMouseDoubleClick);
            this.dgvApplyInfo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvApplyInfo_DataBindingComplete);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(12, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(969, 98);
            this.panel3.TabIndex = 128;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.txtEDate);
            this.panel4.Controls.Add(this.txtSDate);
            this.panel4.Controls.Add(this.TxtChoose);
            this.panel4.Controls.Add(this.BtnChoose);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.cbMoneyUnit);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(3, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(957, 73);
            this.panel4.TabIndex = 6;
            // 
            // txtEDate
            // 
            this.txtEDate.Location = new System.Drawing.Point(75, 42);
            this.txtEDate.Name = "txtEDate";
            this.txtEDate.Size = new System.Drawing.Size(134, 21);
            this.txtEDate.TabIndex = 10;
            // 
            // txtSDate
            // 
            this.txtSDate.Location = new System.Drawing.Point(75, 11);
            this.txtSDate.Name = "txtSDate";
            this.txtSDate.Size = new System.Drawing.Size(134, 21);
            this.txtSDate.TabIndex = 9;
            // 
            // TxtChoose
            // 
            this.TxtChoose.Location = new System.Drawing.Point(318, 45);
            this.TxtChoose.Name = "TxtChoose";
            this.TxtChoose.Size = new System.Drawing.Size(119, 21);
            this.TxtChoose.TabIndex = 1;
            this.TxtChoose.TextChanged += new System.EventHandler(this.TxtChoose_TextChanged);
            // 
            // BtnChoose
            // 
            this.BtnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChoose.Location = new System.Drawing.Point(873, 41);
            this.BtnChoose.Name = "BtnChoose";
            this.BtnChoose.Size = new System.Drawing.Size(75, 23);
            this.BtnChoose.TabIndex = 0;
            this.BtnChoose.Text = "查询";
            this.BtnChoose.UseVisualStyleBackColor = true;
            this.BtnChoose.Click += new System.EventHandler(this.BtnChoose_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "结束时间：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "开始时间：";
            // 
            // cbMoneyUnit
            // 
            this.cbMoneyUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoneyUnit.FormattingEnabled = true;
            this.cbMoneyUnit.Location = new System.Drawing.Point(318, 14);
            this.cbMoneyUnit.Name = "cbMoneyUnit";
            this.cbMoneyUnit.Size = new System.Drawing.Size(119, 20);
            this.cbMoneyUnit.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(247, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "货币单位：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "员工姓名：";
            // 
            // TransNo
            // 
            this.TransNo.DataPropertyName = "TransNo";
            this.TransNo.HeaderText = "交易号";
            this.TransNo.Name = "TransNo";
            this.TransNo.ReadOnly = true;
            // 
            // ApplicantsDate
            // 
            this.ApplicantsDate.DataPropertyName = "ApplicantsDate";
            this.ApplicantsDate.HeaderText = "申请日期";
            this.ApplicantsDate.Name = "ApplicantsDate";
            this.ApplicantsDate.ReadOnly = true;
            // 
            // ApplicantsName
            // 
            this.ApplicantsName.DataPropertyName = "ApplicantsName";
            this.ApplicantsName.HeaderText = "员工姓名";
            this.ApplicantsName.Name = "ApplicantsName";
            this.ApplicantsName.ReadOnly = true;
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.HeaderText = "货号";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            // 
            // MoneyUnit
            // 
            this.MoneyUnit.DataPropertyName = "MoneyUnit";
            this.MoneyUnit.HeaderText = "MoneyUnit";
            this.MoneyUnit.Name = "MoneyUnit";
            this.MoneyUnit.ReadOnly = true;
            this.MoneyUnit.Visible = false;
            // 
            // ApprovalCount
            // 
            this.ApprovalCount.DataPropertyName = "ApprovalCount";
            this.ApprovalCount.HeaderText = "批准数量";
            this.ApprovalCount.Name = "ApprovalCount";
            this.ApprovalCount.ReadOnly = true;
            // 
            // FinalPrice
            // 
            this.FinalPrice.DataPropertyName = "FinalPrice";
            this.FinalPrice.HeaderText = "折后总价";
            this.FinalPrice.Name = "FinalPrice";
            this.FinalPrice.ReadOnly = true;
            // 
            // frmStoreApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvApplyInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmStoreApplicationInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "申请单状态";
            this.Text = "店面确认";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyInfo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvApplyInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TxtChoose;
        private System.Windows.Forms.Button BtnChoose;
        private System.Windows.Forms.Button btnAlter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker txtEDate;
        private System.Windows.Forms.DateTimePicker txtSDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbMoneyUnit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantsDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalPrice;


    }
}