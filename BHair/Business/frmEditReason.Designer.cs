namespace BHair.Business
{
    partial class frmEditReason
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
            this.txtEditReason = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEditReason
            // 
            this.txtEditReason.Location = new System.Drawing.Point(12, 12);
            this.txtEditReason.Name = "txtEditReason";
            this.txtEditReason.Size = new System.Drawing.Size(301, 126);
            this.txtEditReason.TabIndex = 0;
            this.txtEditReason.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(238, 149);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmEditReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 184);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtEditReason);
            this.Name = "frmEditReason";
            this.Text = "填写修改原因：";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtEditReason;
        private System.Windows.Forms.Button btnOK;
    }
}