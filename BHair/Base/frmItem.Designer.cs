namespace BHair.Base
{
    partial class frmItem
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
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbIsSpecial = new System.Windows.Forms.CheckBox();
            this.txtPrice = new System.Windows.Forms.NumericUpDown();
            this.txtPrice2 = new System.Windows.Forms.NumericUpDown();
            this.txtPrice3 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(441, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(316, 197);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(83, 12);
            this.txtItemID.MaxLength = 30;
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(175, 21);
            this.txtItemID.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "货号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "零售价（RMB）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "产品名字";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(83, 52);
            this.txtItemName.MaxLength = 30;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(175, 21);
            this.txtItemName.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "产品描述";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(83, 124);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(433, 53);
            this.txtDetail.TabIndex = 25;
            this.txtDetail.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "零售价（港元）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "零售价（美元）";
            // 
            // cbIsSpecial
            // 
            this.cbIsSpecial.AutoSize = true;
            this.cbIsSpecial.Location = new System.Drawing.Point(14, 91);
            this.cbIsSpecial.Name = "cbIsSpecial";
            this.cbIsSpecial.Size = new System.Drawing.Size(108, 16);
            this.cbIsSpecial.TabIndex = 30;
            this.cbIsSpecial.Text = "是否为特殊商品";
            this.cbIsSpecial.UseVisualStyleBackColor = true;
            // 
            // txtPrice
            // 
            this.txtPrice.DecimalPlaces = 2;
            this.txtPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtPrice.Location = new System.Drawing.Point(396, 13);
            this.txtPrice.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(120, 21);
            this.txtPrice.TabIndex = 31;
            // 
            // txtPrice2
            // 
            this.txtPrice2.DecimalPlaces = 2;
            this.txtPrice2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtPrice2.Location = new System.Drawing.Point(396, 53);
            this.txtPrice2.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.Size = new System.Drawing.Size(120, 21);
            this.txtPrice2.TabIndex = 32;
            // 
            // txtPrice3
            // 
            this.txtPrice3.DecimalPlaces = 2;
            this.txtPrice3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtPrice3.Location = new System.Drawing.Point(396, 87);
            this.txtPrice3.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtPrice3.Name = "txtPrice3";
            this.txtPrice3.Size = new System.Drawing.Size(120, 21);
            this.txtPrice3.TabIndex = 33;
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 230);
            this.Controls.Add(this.txtPrice3);
            this.Controls.Add(this.txtPrice2);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cbIsSpecial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtItemID);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增商品";
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbIsSpecial;
        private System.Windows.Forms.NumericUpDown txtPrice;
        private System.Windows.Forms.NumericUpDown txtPrice2;
        private System.Windows.Forms.NumericUpDown txtPrice3;
    }
}