namespace GUI_QLNS.HeThong
{
    partial class Password
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ckPassword = new DevExpress.XtraEditors.CheckEdit();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtOP = new System.Windows.Forms.TextBox();
            this.txtNP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ckPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(53, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mật khẩu cũ:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(45, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Mật khẩu mới:";
            // 
            // ckPassword
            // 
            this.ckPassword.Location = new System.Drawing.Point(83, 96);
            this.ckPassword.Name = "ckPassword";
            this.ckPassword.Properties.Caption = "Hiển thị mật khẩu";
            this.ckPassword.Size = new System.Drawing.Size(148, 24);
            this.ckPassword.TabIndex = 2;
            this.ckPassword.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(289, 100);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(94, 29);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu mật khẩu";
            // 
            // txtOP
            // 
            this.txtOP.Location = new System.Drawing.Point(133, 18);
            this.txtOP.Name = "txtOP";
            this.txtOP.Size = new System.Drawing.Size(222, 23);
            this.txtOP.TabIndex = 6;
            // 
            // txtNP
            // 
            this.txtNP.Location = new System.Drawing.Point(133, 53);
            this.txtNP.Name = "txtNP";
            this.txtNP.Size = new System.Drawing.Size(222, 23);
            this.txtNP.TabIndex = 7;
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 151);
            this.Controls.Add(this.txtNP);
            this.Controls.Add(this.txtOP);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.ckPassword);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "Password";
            this.Text = "Password";
            ((System.ComponentModel.ISupportInitialize)(this.ckPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit ckPassword;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private System.Windows.Forms.TextBox txtOP;
        private System.Windows.Forms.TextBox txtNP;
    }
}