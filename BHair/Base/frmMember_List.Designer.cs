namespace BHair.Base
{
    partial class frmMember_List
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMember = new System.Windows.Forms.Label();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.dgvMember = new System.Windows.Forms.DataGridView();
            this.UID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Character = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.MoneyUnitState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowIsAble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPermission = new System.Windows.Forms.Button();
            this.btnOutEmpInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(10, 15);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(101, 12);
            this.lblMember.TabIndex = 0;
            this.lblMember.Text = "输入账号或姓名：";
            // 
            // txtMember
            // 
            this.txtMember.Location = new System.Drawing.Point(141, 12);
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(100, 21);
            this.txtMember.TabIndex = 1;
            this.txtMember.TextChanged += new System.EventHandler(this.txtMember_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(606, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "新增用户(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModify.Location = new System.Drawing.Point(697, 10);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(85, 23);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "编辑用户(&M)";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
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
            this.UserPwd,
            this.Tel,
            this.Email,
            this.Position,
            this.Department,
            this.Store,
            this.Detail,
            this.Character,
            this.Column11,
            this.Column12,
            this.LastLoginTime,
            this.IsAdmin,
            this.IsDelete,
            this.ID,
            this.TotalAmount,
            this.UsedAmount,
            this.RestAmount,
            this.MoneyUnit,
            this.MoneyUnitState,
            this.IsAble,
            this.ShowIsAble});
            this.dgvMember.Location = new System.Drawing.Point(12, 39);
            this.dgvMember.MultiSelect = false;
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.RowTemplate.Height = 23;
            this.dgvMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMember.Size = new System.Drawing.Size(872, 361);
            this.dgvMember.TabIndex = 6;
            this.dgvMember.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMember_CellFormatting);
            this.dgvMember.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMember_CellMouseDoubleClick);
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
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.Position.DefaultCellStyle = dataGridViewCellStyle1;
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
            // Store
            // 
            this.Store.DataPropertyName = "Store";
            this.Store.HeaderText = "所属店面";
            this.Store.Name = "Store";
            this.Store.ReadOnly = true;
            this.Store.Visible = false;
            // 
            // Detail
            // 
            this.Detail.DataPropertyName = "Detail";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Detail.DefaultCellStyle = dataGridViewCellStyle2;
            this.Detail.HeaderText = "用户信息描述";
            this.Detail.MinimumWidth = 20;
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            // 
            // Character
            // 
            this.Character.DataPropertyName = "Character";
            this.Character.HeaderText = "所属角色";
            this.Character.Name = "Character";
            this.Character.ReadOnly = true;
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
            this.RestAmount.Visible = false;
            // 
            // MoneyUnit
            // 
            this.MoneyUnit.DataPropertyName = "MoneyUnit";
            this.MoneyUnit.HeaderText = "MoneyUnit";
            this.MoneyUnit.Name = "MoneyUnit";
            this.MoneyUnit.ReadOnly = true;
            this.MoneyUnit.Visible = false;
            // 
            // MoneyUnitState
            // 
            this.MoneyUnitState.HeaderText = "货币类型";
            this.MoneyUnitState.Name = "MoneyUnitState";
            this.MoneyUnitState.ReadOnly = true;
            // 
            // IsAble
            // 
            this.IsAble.DataPropertyName = "IsAble";
            this.IsAble.HeaderText = "IsAble";
            this.IsAble.Name = "IsAble";
            this.IsAble.ReadOnly = true;
            this.IsAble.Visible = false;
            // 
            // ShowIsAble
            // 
            this.ShowIsAble.HeaderText = "是否可用";
            this.ShowIsAble.Name = "ShowIsAble";
            this.ShowIsAble.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(788, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "删除用户(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(401, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "导入用户(&I)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPermission
            // 
            this.btnPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPermission.Location = new System.Drawing.Point(492, 10);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(108, 23);
            this.btnPermission.TabIndex = 9;
            this.btnPermission.Text = "导入可用工号(&I)";
            this.btnPermission.UseVisualStyleBackColor = true;
            this.btnPermission.Click += new System.EventHandler(this.btnPermission_Click);
            // 
            // btnOutEmpInfo
            // 
            this.btnOutEmpInfo.Location = new System.Drawing.Point(310, 10);
            this.btnOutEmpInfo.Name = "btnOutEmpInfo";
            this.btnOutEmpInfo.Size = new System.Drawing.Size(85, 23);
            this.btnOutEmpInfo.TabIndex = 10;
            this.btnOutEmpInfo.Text = "导出员工信息";
            this.btnOutEmpInfo.UseVisualStyleBackColor = true;
            this.btnOutEmpInfo.Click += new System.EventHandler(this.btnOutEmpInfo_Click);
            // 
            // frmMember_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 424);
            this.Controls.Add(this.btnOutEmpInfo);
            this.Controls.Add(this.btnPermission);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvMember);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMember);
            this.Controls.Add(this.lblMember);
            this.MinimumSize = new System.Drawing.Size(912, 463);
            this.Name = "frmMember_List";
            this.TabText = "用户管理";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.frmMember_List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.TextBox txtMember;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.DataGridView dgvMember;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPermission;
        private System.Windows.Forms.DataGridViewTextBoxColumn UID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Character;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyUnitState;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAble;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowIsAble;
        private System.Windows.Forms.Button btnOutEmpInfo;
    }
}