namespace BHair.Base
{
    partial class frmMember_Import
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMember = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.dgvMember = new System.Windows.Forms.DataGridView();
            this.UID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Character = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyUnitState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastLoginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RestAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(128, 15);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(113, 12);
            this.lblMember.TabIndex = 0;
            this.lblMember.Text = "输入用户默认密码：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(259, 12);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 1;
            // 
            // dgvMember
            // 
            this.dgvMember.AllowUserToAddRows = false;
            this.dgvMember.AllowUserToDeleteRows = false;
            this.dgvMember.AllowUserToResizeRows = false;
            this.dgvMember.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMember.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UID,
            this.UserName,
            this.EmployeeID,
            this.Character,
            this.ManagerID,
            this.MoneyUnitState,
            this.Store,
            this.Position,
            this.Department,
            this.Email,
            this.Detail,
            this.UserPwd,
            this.Tel,
            this.Column11,
            this.Column12,
            this.LastLoginTime,
            this.IsAdmin,
            this.IsDelete,
            this.ID,
            this.TotalAmount,
            this.UsedAmount,
            this.RestAmount,
            this.MoneyUnit});
            this.dgvMember.Location = new System.Drawing.Point(12, 39);
            this.dgvMember.MultiSelect = false;
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.RowTemplate.Height = 23;
            this.dgvMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMember.Size = new System.Drawing.Size(1149, 503);
            this.dgvMember.TabIndex = 6;
            this.dgvMember.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMember_CellFormatting);
            this.dgvMember.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMember_DataBindingComplete);
            this.dgvMember.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMember_RowPostPaint);
            // 
            // UID
            // 
            this.UID.DataPropertyName = "UID";
            this.UID.HeaderText = "用户账号";
            this.UID.Name = "UID";
            this.UID.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "用户姓名";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "员工号码";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            // 
            // Character
            // 
            this.Character.DataPropertyName = "Character";
            this.Character.HeaderText = "所属角色";
            this.Character.Name = "Character";
            this.Character.ReadOnly = true;
            // 
            // ManagerID
            // 
            this.ManagerID.DataPropertyName = "ManagerID";
            this.ManagerID.HeaderText = "上属经理账号";
            this.ManagerID.Name = "ManagerID";
            this.ManagerID.ReadOnly = true;
            // 
            // MoneyUnitState
            // 
            this.MoneyUnitState.HeaderText = "货币单位";
            this.MoneyUnitState.Name = "MoneyUnitState";
            this.MoneyUnitState.ReadOnly = true;
            // 
            // Store
            // 
            this.Store.DataPropertyName = "Store";
            this.Store.HeaderText = "所属店面";
            this.Store.Name = "Store";
            this.Store.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Position.DefaultCellStyle = dataGridViewCellStyle3;
            this.Position.HeaderText = "职位";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "部门";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Detail
            // 
            this.Detail.DataPropertyName = "Detail";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.Detail.DefaultCellStyle = dataGridViewCellStyle4;
            this.Detail.HeaderText = "用户信息描述";
            this.Detail.MinimumWidth = 20;
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            // 
            // UserPwd
            // 
            this.UserPwd.DataPropertyName = "UserPwd";
            this.UserPwd.HeaderText = "用户密码";
            this.UserPwd.Name = "UserPwd";
            this.UserPwd.ReadOnly = true;
            this.UserPwd.Visible = false;
            // 
            // Tel
            // 
            this.Tel.DataPropertyName = "Tel";
            this.Tel.HeaderText = "电话";
            this.Tel.Name = "Tel";
            this.Tel.ReadOnly = true;
            this.Tel.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "CreateTime";
            this.Column11.HeaderText = "CreateTime";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "LoginTime";
            this.Column12.HeaderText = "LoginTime";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // LastLoginTime
            // 
            this.LastLoginTime.DataPropertyName = "LastLoginTime";
            this.LastLoginTime.HeaderText = "LastLoginTime";
            this.LastLoginTime.Name = "LastLoginTime";
            this.LastLoginTime.ReadOnly = true;
            this.LastLoginTime.Visible = false;
            // 
            // IsAdmin
            // 
            this.IsAdmin.DataPropertyName = "IsAdmin";
            this.IsAdmin.HeaderText = "IsAdmin";
            this.IsAdmin.Name = "IsAdmin";
            this.IsAdmin.ReadOnly = true;
            this.IsAdmin.Visible = false;
            // 
            // IsDelete
            // 
            this.IsDelete.DataPropertyName = "IsDelete";
            this.IsDelete.HeaderText = "IsDelete";
            this.IsDelete.Name = "IsDelete";
            this.IsDelete.ReadOnly = true;
            this.IsDelete.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = "TotalAmount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.Visible = false;
            // 
            // UsedAmount
            // 
            this.UsedAmount.DataPropertyName = "UsedAmount";
            this.UsedAmount.HeaderText = "UsedAmount";
            this.UsedAmount.Name = "UsedAmount";
            this.UsedAmount.ReadOnly = true;
            this.UsedAmount.Visible = false;
            // 
            // RestAmount
            // 
            this.RestAmount.DataPropertyName = "RestAmount";
            this.RestAmount.HeaderText = "剩余额度";
            this.RestAmount.Name = "RestAmount";
            this.RestAmount.ReadOnly = true;
            // 
            // MoneyUnit
            // 
            this.MoneyUnit.DataPropertyName = "MoneyUnit";
            this.MoneyUnit.HeaderText = "MoneyUnit";
            this.MoneyUnit.Name = "MoneyUnit";
            this.MoneyUnit.ReadOnly = true;
            this.MoneyUnit.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(12, 10);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(98, 23);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "选择Excel文件";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(1063, 548);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(98, 23);
            this.btnImport.TabIndex = 8;
            this.btnImport.Text = "导入到数据库";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 553);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 9;
            // 
            // frmMember_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 583);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dgvMember);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lblMember);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(912, 463);
            this.Name = "frmMember_Import";
            this.TabText = "用户导入";
            this.Text = "用户导入";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.DataGridView dgvMember;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Character;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyUnitState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastLoginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyUnit;
    }
}