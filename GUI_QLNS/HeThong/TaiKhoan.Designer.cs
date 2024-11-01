namespace GUI_QLNS.HeThong
{
	partial class frmTaiKhoan
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaiKhoan));
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar2 = new DevExpress.XtraBars.Bar();
			this.btnThem = new DevExpress.XtraBars.BarButtonItem();
			this.btnSua = new DevExpress.XtraBars.BarButtonItem();
			this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
			this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
			this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
			this.bar3 = new DevExpress.XtraBars.Bar();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
			this.cbVaiTro = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.txtMatKhau = new System.Windows.Forms.TextBox();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.txtTenDangNhap = new System.Windows.Forms.TextBox();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
			this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.TenDangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
			this.MatKhau = new DevExpress.XtraGrid.Columns.GridColumn();
			this.VaiTro = new DevExpress.XtraGrid.Columns.GridColumn();
			this.TrangThaiTaiKhoan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.NgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
			this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
			this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
			this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
			this.panelControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cbVaiTro.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
			this.SuspendLayout();
			// 
			// barManager1
			// 
			this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.btnLuu,
            this.btnHuy});
			this.barManager1.MainMenu = this.bar2;
			this.barManager1.MaxItemId = 6;
			this.barManager1.StatusBar = this.bar3;
			// 
			// bar2
			// 
			this.bar2.BarName = "Main menu";
			this.bar2.DockCol = 0;
			this.bar2.DockRow = 0;
			this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
			this.bar2.OptionsBar.MultiLine = true;
			this.bar2.OptionsBar.UseWholeRow = true;
			this.bar2.Text = "Main menu";
			// 
			// btnThem
			// 
			this.btnThem.Caption = "Thêm";
			this.btnThem.Id = 0;
			this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
			this.btnThem.Name = "btnThem";
			this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
			// 
			// btnSua
			// 
			this.btnSua.Caption = "Sửa";
			this.btnSua.Id = 1;
			this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSua.ImageOptions.SvgImage")));
			this.btnSua.Name = "btnSua";
			this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
			// 
			// btnXoa
			// 
			this.btnXoa.Caption = "Xóa";
			this.btnXoa.Id = 2;
			this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
			// 
			// btnLuu
			// 
			this.btnLuu.Caption = "Lưu";
			this.btnLuu.Id = 3;
			this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
			// 
			// btnHuy
			// 
			this.btnHuy.Caption = "Hủy";
			this.btnHuy.Id = 4;
			this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
			this.btnHuy.Name = "btnHuy";
			this.btnHuy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHuy_ItemClick);
			// 
			// bar3
			// 
			this.bar3.BarName = "Status bar";
			this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
			this.bar3.DockCol = 0;
			this.bar3.DockRow = 0;
			this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
			this.bar3.OptionsBar.AllowQuickCustomization = false;
			this.bar3.OptionsBar.DrawDragBorder = false;
			this.bar3.OptionsBar.UseWholeRow = true;
			this.bar3.Text = "Status bar";
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.barManager1;
			this.barDockControlTop.Size = new System.Drawing.Size(1013, 30);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 474);
			this.barDockControlBottom.Manager = this.barManager1;
			this.barDockControlBottom.Size = new System.Drawing.Size(1013, 20);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
			this.barDockControlLeft.Manager = this.barManager1;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 444);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(1013, 30);
			this.barDockControlRight.Manager = this.barManager1;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 444);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 30);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panelControl3);
			this.splitContainer1.Panel1.Controls.Add(this.panelControl2);
			this.splitContainer1.Panel1.Controls.Add(this.panelControl1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.gcDanhSach);
			this.splitContainer1.Size = new System.Drawing.Size(1013, 444);
			this.splitContainer1.SplitterDistance = 67;
			this.splitContainer1.TabIndex = 17;
			// 
			// panelControl3
			// 
			this.panelControl3.Controls.Add(this.cbVaiTro);
			this.panelControl3.Controls.Add(this.labelControl3);
			this.panelControl3.Location = new System.Drawing.Point(507, 19);
			this.panelControl3.Name = "panelControl3";
			this.panelControl3.Size = new System.Drawing.Size(175, 28);
			this.panelControl3.TabIndex = 2;
			// 
			// cbVaiTro
			// 
			this.cbVaiTro.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbVaiTro.Location = new System.Drawing.Point(49, 2);
			this.cbVaiTro.MenuManager = this.barManager1;
			this.cbVaiTro.Name = "cbVaiTro";
			this.cbVaiTro.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.cbVaiTro.Properties.Appearance.Options.UseFont = true;
			this.cbVaiTro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbVaiTro.Size = new System.Drawing.Size(124, 22);
			this.cbVaiTro.TabIndex = 1;
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl3.Appearance.Options.UseFont = true;
			this.labelControl3.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelControl3.Location = new System.Drawing.Point(2, 2);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(47, 18);
			this.labelControl3.TabIndex = 0;
			this.labelControl3.Text = "Vai trò:";
			// 
			// panelControl2
			// 
			this.panelControl2.Controls.Add(this.txtMatKhau);
			this.panelControl2.Controls.Add(this.labelControl2);
			this.panelControl2.Location = new System.Drawing.Point(283, 19);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(200, 28);
			this.panelControl2.TabIndex = 1;
			// 
			// txtMatKhau
			// 
			this.txtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMatKhau.Font = new System.Drawing.Font("Tahoma", 8F);
			this.txtMatKhau.Location = new System.Drawing.Point(68, 2);
			this.txtMatKhau.Multiline = true;
			this.txtMatKhau.Name = "txtMatKhau";
			this.txtMatKhau.Size = new System.Drawing.Size(130, 24);
			this.txtMatKhau.TabIndex = 1;
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl2.Appearance.Options.UseFont = true;
			this.labelControl2.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelControl2.Location = new System.Drawing.Point(2, 2);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(66, 18);
			this.labelControl2.TabIndex = 0;
			this.labelControl2.Text = "Mật khẩu:";
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.txtTenDangNhap);
			this.panelControl1.Controls.Add(this.labelControl1);
			this.panelControl1.Location = new System.Drawing.Point(12, 19);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(248, 28);
			this.panelControl1.TabIndex = 0;
			// 
			// txtTenDangNhap
			// 
			this.txtTenDangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtTenDangNhap.Font = new System.Drawing.Font("Tahoma", 8F);
			this.txtTenDangNhap.Location = new System.Drawing.Point(108, 2);
			this.txtTenDangNhap.Multiline = true;
			this.txtTenDangNhap.Name = "txtTenDangNhap";
			this.txtTenDangNhap.Size = new System.Drawing.Size(138, 24);
			this.txtTenDangNhap.TabIndex = 1;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl1.Appearance.Options.UseFont = true;
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelControl1.Location = new System.Drawing.Point(2, 2);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(106, 18);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Tên đăng nhập:";
			// 
			// gcDanhSach
			// 
			this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcDanhSach.Location = new System.Drawing.Point(0, 0);
			this.gcDanhSach.MainView = this.gvDanhSach;
			this.gcDanhSach.MenuManager = this.barManager1;
			this.gcDanhSach.Name = "gcDanhSach";
			this.gcDanhSach.Size = new System.Drawing.Size(1013, 373);
			this.gcDanhSach.TabIndex = 0;
			this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
			// 
			// gvDanhSach
			// 
			this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TenDangNhap,
            this.MatKhau,
            this.VaiTro,
            this.TrangThaiTaiKhoan,
            this.NgayTao});
			this.gvDanhSach.GridControl = this.gcDanhSach;
			this.gvDanhSach.Name = "gvDanhSach";
			this.gvDanhSach.OptionsFind.AlwaysVisible = true;
			this.gvDanhSach.OptionsView.ShowGroupPanel = false;
			this.gvDanhSach.Click += new System.EventHandler(this.gvDanhSach_Click);
			// 
			// TenDangNhap
			// 
			this.TenDangNhap.Caption = "Tên đăng nhập";
			this.TenDangNhap.FieldName = "TenDangNhap";
			this.TenDangNhap.MinWidth = 25;
			this.TenDangNhap.Name = "TenDangNhap";
			this.TenDangNhap.Visible = true;
			this.TenDangNhap.VisibleIndex = 0;
			this.TenDangNhap.Width = 94;
			// 
			// MatKhau
			// 
			this.MatKhau.Caption = "Mật khẩu";
			this.MatKhau.FieldName = "MatKhau";
			this.MatKhau.MinWidth = 25;
			this.MatKhau.Name = "MatKhau";
			this.MatKhau.Visible = true;
			this.MatKhau.VisibleIndex = 1;
			this.MatKhau.Width = 94;
			// 
			// VaiTro
			// 
			this.VaiTro.Caption = "Vai trò";
			this.VaiTro.FieldName = "VaiTro";
			this.VaiTro.MinWidth = 25;
			this.VaiTro.Name = "VaiTro";
			this.VaiTro.Visible = true;
			this.VaiTro.VisibleIndex = 2;
			this.VaiTro.Width = 94;
			// 
			// TrangThaiTaiKhoan
			// 
			this.TrangThaiTaiKhoan.Caption = "Trạng thái tài khoản";
			this.TrangThaiTaiKhoan.FieldName = "TrangThaiTaiKhoan";
			this.TrangThaiTaiKhoan.MinWidth = 25;
			this.TrangThaiTaiKhoan.Name = "TrangThaiTaiKhoan";
			this.TrangThaiTaiKhoan.Visible = true;
			this.TrangThaiTaiKhoan.VisibleIndex = 3;
			this.TrangThaiTaiKhoan.Width = 94;
			// 
			// NgayTao
			// 
			this.NgayTao.Caption = "Ngày tạo";
			this.NgayTao.FieldName = "NgayTao";
			this.NgayTao.MinWidth = 25;
			this.NgayTao.Name = "NgayTao";
			this.NgayTao.Visible = true;
			this.NgayTao.VisibleIndex = 4;
			this.NgayTao.Width = 94;
			// 
			// barDockControl3
			// 
			this.barDockControl3.CausesValidation = false;
			this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControl3.Location = new System.Drawing.Point(0, 30);
			this.barDockControl3.Manager = this.barManager1;
			this.barDockControl3.Size = new System.Drawing.Size(1013, 0);
			// 
			// barDockControl4
			// 
			this.barDockControl4.CausesValidation = false;
			this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControl4.Location = new System.Drawing.Point(0, 30);
			this.barDockControl4.Manager = this.barManager1;
			this.barDockControl4.Size = new System.Drawing.Size(1013, 0);
			// 
			// barDockControl1
			// 
			this.barDockControl1.CausesValidation = false;
			this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControl1.Location = new System.Drawing.Point(0, 30);
			this.barDockControl1.Manager = this.barManager1;
			this.barDockControl1.Size = new System.Drawing.Size(1013, 0);
			// 
			// frmTaiKhoan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1013, 494);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.barDockControl3);
			this.Controls.Add(this.barDockControl4);
			this.Controls.Add(this.barDockControl1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "frmTaiKhoan";
			this.Text = "TaiKhoan";
			this.Load += new System.EventHandler(this.TaiKhoan_Load);
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
			this.panelControl3.ResumeLayout(false);
			this.panelControl3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cbVaiTro.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			this.panelControl2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.panelControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar2;
		private DevExpress.XtraBars.BarButtonItem btnThem;
		private DevExpress.XtraBars.BarButtonItem btnSua;
		private DevExpress.XtraBars.BarButtonItem btnXoa;
		private DevExpress.XtraBars.BarButtonItem btnLuu;
		private DevExpress.XtraBars.BarButtonItem btnHuy;
		private DevExpress.XtraBars.Bar bar3;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private DevExpress.XtraGrid.GridControl gcDanhSach;
		private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
		private DevExpress.XtraGrid.Columns.GridColumn TenDangNhap;
		private DevExpress.XtraGrid.Columns.GridColumn MatKhau;
		private DevExpress.XtraGrid.Columns.GridColumn VaiTro;
		private DevExpress.XtraGrid.Columns.GridColumn TrangThaiTaiKhoan;
		private DevExpress.XtraGrid.Columns.GridColumn NgayTao;
		private DevExpress.XtraBars.BarDockControl barDockControl3;
		private DevExpress.XtraBars.BarDockControl barDockControl4;
		private DevExpress.XtraBars.BarDockControl barDockControl1;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private System.Windows.Forms.TextBox txtTenDangNhap;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private System.Windows.Forms.TextBox txtMatKhau;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.ComboBoxEdit cbVaiTro;
	}
}