namespace BHair.Base
{
    partial class frmAdvDataControl
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
            this.btnLoadData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.dgvAI = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAD = new System.Windows.Forms.DataGridView();
            this.rID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rCodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rTransNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbProcess = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAI)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAD)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(16, 31);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(67, 48);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "查询所有重复数据";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(744, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "警告!!使用本界面功能时,请确保除本人外,其他所有账号都已退出登陆!!否则,将会导致数据处理失败!!";
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(89, 31);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(67, 48);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "处理所有重复数据";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // dgvAI
            // 
            this.dgvAI.AllowUserToAddRows = false;
            this.dgvAI.AllowUserToDeleteRows = false;
            this.dgvAI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TransNo});
            this.dgvAI.Location = new System.Drawing.Point(6, 20);
            this.dgvAI.Name = "dgvAI";
            this.dgvAI.ReadOnly = true;
            this.dgvAI.RowTemplate.Height = 23;
            this.dgvAI.Size = new System.Drawing.Size(358, 315);
            this.dgvAI.TabIndex = 3;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // TransNo
            // 
            this.TransNo.DataPropertyName = "TransNo";
            this.TransNo.HeaderText = "TransNo";
            this.TransNo.Name = "TransNo";
            this.TransNo.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAI);
            this.groupBox1.Location = new System.Drawing.Point(16, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 346);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ApplicationInfo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAD);
            this.groupBox2.Location = new System.Drawing.Point(392, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 346);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ApplicationDetail";
            // 
            // dgvAD
            // 
            this.dgvAD.AllowUserToAddRows = false;
            this.dgvAD.AllowUserToDeleteRows = false;
            this.dgvAD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rID,
            this.rCodeID,
            this.rTransNo});
            this.dgvAD.Location = new System.Drawing.Point(7, 20);
            this.dgvAD.Name = "dgvAD";
            this.dgvAD.ReadOnly = true;
            this.dgvAD.RowTemplate.Height = 23;
            this.dgvAD.Size = new System.Drawing.Size(357, 315);
            this.dgvAD.TabIndex = 0;
            // 
            // rID
            // 
            this.rID.DataPropertyName = "ID";
            this.rID.HeaderText = "rID";
            this.rID.Name = "rID";
            this.rID.ReadOnly = true;
            // 
            // rCodeID
            // 
            this.rCodeID.DataPropertyName = "CodeID";
            this.rCodeID.HeaderText = "rCodeID";
            this.rCodeID.Name = "rCodeID";
            this.rCodeID.ReadOnly = true;
            // 
            // rTransNo
            // 
            this.rTransNo.DataPropertyName = "TransNo";
            this.rTransNo.HeaderText = "rTransNo ";
            this.rTransNo.Name = "rTransNo";
            this.rTransNo.ReadOnly = true;
            // 
            // pbProcess
            // 
            this.pbProcess.Location = new System.Drawing.Point(163, 47);
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(599, 23);
            this.pbProcess.TabIndex = 6;
            this.pbProcess.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // frmAdvDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 433);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbProcess);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadData);
            this.Name = "frmAdvDataControl";
            this.Text = "frmAdvDataControl";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAI)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DataGridView dgvAI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransNo;
        private System.Windows.Forms.DataGridView dgvAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn rID;
        private System.Windows.Forms.DataGridViewTextBoxColumn rCodeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn rTransNo;
        private System.Windows.Forms.ProgressBar pbProcess;
        private System.Windows.Forms.Label label2;
    }
}