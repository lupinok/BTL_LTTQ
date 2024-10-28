namespace GUI_QLNS
{
    partial class Login
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			this.directXFormContainerControl1 = new DevExpress.XtraEditors.DirectXFormContainerControl();
			this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.directXFormContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// directXFormContainerControl1
			// 
			this.directXFormContainerControl1.Controls.Add(this.textEdit2);
			this.directXFormContainerControl1.Controls.Add(this.simpleButton3);
			this.directXFormContainerControl1.Controls.Add(this.simpleButton1);
			this.directXFormContainerControl1.Controls.Add(this.checkEdit1);
			this.directXFormContainerControl1.Controls.Add(this.textEdit1);
			this.directXFormContainerControl1.Controls.Add(this.simpleButton2);
			this.directXFormContainerControl1.Controls.Add(this.labelControl1);
			this.directXFormContainerControl1.Location = new System.Drawing.Point(1, 31);
			this.directXFormContainerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.directXFormContainerControl1.Name = "directXFormContainerControl1";
			this.directXFormContainerControl1.Size = new System.Drawing.Size(970, 486);
			this.directXFormContainerControl1.TabIndex = 0;
			// 
			// textEdit2
			// 
			this.textEdit2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textEdit2.EditValue = "";
			this.textEdit2.Location = new System.Drawing.Point(332, 237);
			this.textEdit2.Name = "textEdit2";
			this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.textEdit2.Properties.Appearance.Options.UseFont = true;
			this.textEdit2.Properties.NullValuePrompt = "Password";
			this.textEdit2.Size = new System.Drawing.Size(346, 32);
			this.textEdit2.TabIndex = 12;
			// 
			// simpleButton3
			// 
			this.simpleButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
			this.simpleButton3.Location = new System.Drawing.Point(283, 229);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
			this.simpleButton3.Size = new System.Drawing.Size(51, 41);
			this.simpleButton3.TabIndex = 11;
			this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Aqua;
			this.simpleButton1.Appearance.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.simpleButton1.Appearance.Options.UseBackColor = true;
			this.simpleButton1.Appearance.Options.UseFont = true;
			this.simpleButton1.AppearanceHovered.BackColor = System.Drawing.Color.Blue;
			this.simpleButton1.AppearanceHovered.ForeColor = System.Drawing.Color.White;
			this.simpleButton1.AppearanceHovered.Options.UseBackColor = true;
			this.simpleButton1.AppearanceHovered.Options.UseForeColor = true;
			this.simpleButton1.Location = new System.Drawing.Point(332, 318);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(346, 54);
			this.simpleButton1.TabIndex = 10;
			this.simpleButton1.Text = "Login";
			// 
			// checkEdit1
			// 
			this.checkEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.checkEdit1.Location = new System.Drawing.Point(332, 283);
			this.checkEdit1.Name = "checkEdit1";
			this.checkEdit1.Properties.Caption = "Remember";
			this.checkEdit1.Size = new System.Drawing.Size(101, 20);
			this.checkEdit1.TabIndex = 9;
			// 
			// textEdit1
			// 
			this.textEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textEdit1.Location = new System.Drawing.Point(332, 184);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.textEdit1.Properties.Appearance.Options.UseFont = true;
			this.textEdit1.Properties.NullValuePrompt = "Email Address";
			this.textEdit1.Size = new System.Drawing.Size(346, 32);
			this.textEdit1.TabIndex = 8;
			// 
			// simpleButton2
			// 
			this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
			this.simpleButton2.Location = new System.Drawing.Point(283, 181);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
			this.simpleButton2.Size = new System.Drawing.Size(51, 41);
			this.simpleButton2.TabIndex = 7;
			// 
			// labelControl1
			// 
			this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
			this.labelControl1.Appearance.Options.UseFont = true;
			this.labelControl1.Appearance.Options.UseForeColor = true;
			this.labelControl1.Location = new System.Drawing.Point(341, 105);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(321, 73);
			this.labelControl1.TabIndex = 6;
			this.labelControl1.Text = "Login form";
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildControls.Add(this.directXFormContainerControl1);
			this.ClientSize = new System.Drawing.Size(972, 488);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.HtmlTemplate.Styles = resources.GetString("Login.HtmlTemplate.Styles");
			this.HtmlTemplate.Template = resources.GetString("Login.HtmlTemplate.Template");
			this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Login.IconOptions.SvgImage")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Login";
			this.Text = "Login";
			this.directXFormContainerControl1.ResumeLayout(false);
			this.directXFormContainerControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DirectXFormContainerControl directXFormContainerControl1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}