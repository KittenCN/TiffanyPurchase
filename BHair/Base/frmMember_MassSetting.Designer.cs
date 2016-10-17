namespace BHair.Base
{
    partial class frmMember_MassSetting
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
            this.gbMassSettingStore = new System.Windows.Forms.GroupBox();
            this.rbMassSettingStore = new System.Windows.Forms.RadioButton();
            this.gbMassFrozen = new System.Windows.Forms.GroupBox();
            this.rbMassFrozen = new System.Windows.Forms.RadioButton();
            this.cbAbleMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbStore = new System.Windows.Forms.ComboBox();
            this.cbIsAble = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbMassSettingStore.SuspendLayout();
            this.gbMassFrozen.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMassSettingStore
            // 
            this.gbMassSettingStore.Controls.Add(this.cbStore);
            this.gbMassSettingStore.Controls.Add(this.label8);
            this.gbMassSettingStore.Controls.Add(this.rbMassSettingStore);
            this.gbMassSettingStore.Location = new System.Drawing.Point(13, 13);
            this.gbMassSettingStore.Name = "gbMassSettingStore";
            this.gbMassSettingStore.Size = new System.Drawing.Size(259, 54);
            this.gbMassSettingStore.TabIndex = 0;
            this.gbMassSettingStore.TabStop = false;
            this.gbMassSettingStore.Text = "批量设置店面";
            // 
            // rbMassSettingStore
            // 
            this.rbMassSettingStore.AutoSize = true;
            this.rbMassSettingStore.Location = new System.Drawing.Point(6, -1);
            this.rbMassSettingStore.Name = "rbMassSettingStore";
            this.rbMassSettingStore.Size = new System.Drawing.Size(95, 16);
            this.rbMassSettingStore.TabIndex = 0;
            this.rbMassSettingStore.TabStop = true;
            this.rbMassSettingStore.Text = "批量设置店面";
            this.rbMassSettingStore.UseVisualStyleBackColor = true;
            this.rbMassSettingStore.CheckedChanged += new System.EventHandler(this.rbMassSettingStore_CheckedChanged);
            // 
            // gbMassFrozen
            // 
            this.gbMassFrozen.Controls.Add(this.cbIsAble);
            this.gbMassFrozen.Controls.Add(this.cbAbleMode);
            this.gbMassFrozen.Controls.Add(this.rbMassFrozen);
            this.gbMassFrozen.Location = new System.Drawing.Point(13, 73);
            this.gbMassFrozen.Name = "gbMassFrozen";
            this.gbMassFrozen.Size = new System.Drawing.Size(259, 52);
            this.gbMassFrozen.TabIndex = 1;
            this.gbMassFrozen.TabStop = false;
            this.gbMassFrozen.Text = "批量冻结";
            // 
            // rbMassFrozen
            // 
            this.rbMassFrozen.AutoSize = true;
            this.rbMassFrozen.Location = new System.Drawing.Point(6, -1);
            this.rbMassFrozen.Name = "rbMassFrozen";
            this.rbMassFrozen.Size = new System.Drawing.Size(71, 16);
            this.rbMassFrozen.TabIndex = 0;
            this.rbMassFrozen.TabStop = true;
            this.rbMassFrozen.Text = "批量冻结";
            this.rbMassFrozen.UseVisualStyleBackColor = true;
            this.rbMassFrozen.CheckedChanged += new System.EventHandler(this.rbMassFrozen_CheckedChanged);
            // 
            // cbAbleMode
            // 
            this.cbAbleMode.Enabled = false;
            this.cbAbleMode.FormattingEnabled = true;
            this.cbAbleMode.Location = new System.Drawing.Point(75, 20);
            this.cbAbleMode.Name = "cbAbleMode";
            this.cbAbleMode.Size = new System.Drawing.Size(173, 20);
            this.cbAbleMode.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 31;
            this.label8.Text = "所属店面：";
            // 
            // cbStore
            // 
            this.cbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStore.Enabled = false;
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Location = new System.Drawing.Point(75, 25);
            this.cbStore.Name = "cbStore";
            this.cbStore.Size = new System.Drawing.Size(173, 20);
            this.cbStore.TabIndex = 32;
            // 
            // cbIsAble
            // 
            this.cbIsAble.AutoSize = true;
            this.cbIsAble.Location = new System.Drawing.Point(6, 23);
            this.cbIsAble.Name = "cbIsAble";
            this.cbIsAble.Size = new System.Drawing.Size(59, 12);
            this.cbIsAble.TabIndex = 13;
            this.cbIsAble.Text = "冻结类型:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(117, 226);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(198, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmMember_MassSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.gbMassFrozen);
            this.Controls.Add(this.gbMassSettingStore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMember_MassSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMember_MassSetting";
            this.Load += new System.EventHandler(this.frmMember_MassSetting_Load);
            this.gbMassSettingStore.ResumeLayout(false);
            this.gbMassSettingStore.PerformLayout();
            this.gbMassFrozen.ResumeLayout(false);
            this.gbMassFrozen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMassSettingStore;
        private System.Windows.Forms.RadioButton rbMassSettingStore;
        private System.Windows.Forms.GroupBox gbMassFrozen;
        private System.Windows.Forms.RadioButton rbMassFrozen;
        private System.Windows.Forms.ComboBox cbAbleMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbStore;
        private System.Windows.Forms.Label cbIsAble;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}