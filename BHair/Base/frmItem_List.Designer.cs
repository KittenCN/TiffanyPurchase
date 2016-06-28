namespace BHair.Base
{
    partial class frmItem_List
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
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSpecial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(93, 7);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "修改(&M)";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "新增(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToResizeRows = false;
            this.dgvItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemID,
            this.ItemName,
            this.Price,
            this.Price2,
            this.Price3,
            this.Detail,
            this.IsDelete,
            this.OrderCount,
            this.Count,
            this.StoreID,
            this.DiscountInfo,
            this.Deadline,
            this.IsSpecial});
            this.dgvItem.Location = new System.Drawing.Point(12, 39);
            this.dgvItem.MultiSelect = false;
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.RowTemplate.Height = 23;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(702, 368);
            this.dgvItem.TabIndex = 4;
            this.dgvItem.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSubject_CellMouseDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(176, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(257, 7);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "导入(&I)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.HeaderText = "货号";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "产品名字";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "零售价(RMB)";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Price2
            // 
            this.Price2.DataPropertyName = "Price2";
            this.Price2.HeaderText = "零售价（美元）";
            this.Price2.Name = "Price2";
            this.Price2.ReadOnly = true;
            // 
            // Price3
            // 
            this.Price3.DataPropertyName = "Price3";
            this.Price3.HeaderText = "零售价（港元）";
            this.Price3.Name = "Price3";
            this.Price3.ReadOnly = true;
            // 
            // Detail
            // 
            this.Detail.DataPropertyName = "Detail";
            this.Detail.HeaderText = "产品详情";
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            // 
            // IsDelete
            // 
            this.IsDelete.DataPropertyName = "IsDelete";
            this.IsDelete.HeaderText = "IsDelete";
            this.IsDelete.Name = "IsDelete";
            this.IsDelete.ReadOnly = true;
            this.IsDelete.Visible = false;
            // 
            // OrderCount
            // 
            this.OrderCount.DataPropertyName = "OrderCount";
            this.OrderCount.HeaderText = "OrderCount";
            this.OrderCount.Name = "OrderCount";
            this.OrderCount.ReadOnly = true;
            this.OrderCount.Visible = false;
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Visible = false;
            // 
            // StoreID
            // 
            this.StoreID.DataPropertyName = "StoreID";
            this.StoreID.HeaderText = "StoreID";
            this.StoreID.Name = "StoreID";
            this.StoreID.ReadOnly = true;
            this.StoreID.Visible = false;
            // 
            // DiscountInfo
            // 
            this.DiscountInfo.DataPropertyName = "DiscountInfo";
            this.DiscountInfo.HeaderText = "DiscountInfo";
            this.DiscountInfo.Name = "DiscountInfo";
            this.DiscountInfo.ReadOnly = true;
            this.DiscountInfo.Visible = false;
            // 
            // Deadline
            // 
            this.Deadline.DataPropertyName = "Deadline";
            this.Deadline.HeaderText = "Deadline";
            this.Deadline.Name = "Deadline";
            this.Deadline.ReadOnly = true;
            this.Deadline.Visible = false;
            // 
            // IsSpecial
            // 
            this.IsSpecial.DataPropertyName = "IsSpecial";
            this.IsSpecial.HeaderText = "IsSpecial";
            this.IsSpecial.Name = "IsSpecial";
            this.IsSpecial.ReadOnly = true;
            this.IsSpecial.Visible = false;
            // 
            // frmItem_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 428);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvItem);
            this.MinimumSize = new System.Drawing.Size(742, 467);
            this.Name = "frmItem_List";
            this.TabText = "商品管理";
            this.Text = "商品管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSpecial;
    }
}