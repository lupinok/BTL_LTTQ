using System;

namespace GUI_QLNS.NhanVien
{
	partial class frmNhanVien
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVien));
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
			this.cbMaChucVu = new DevExpress.XtraEditors.ComboBoxEdit();
			this.cbMaPhongBan = new DevExpress.XtraEditors.ComboBoxEdit();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtSoDienThoai = new System.Windows.Forms.TextBox();
			this.txtNgaySinh = new System.Windows.Forms.TextBox();
			this.txtHoTen = new System.Windows.Forms.TextBox();
			this.txtMaNhanVien = new System.Windows.Forms.TextBox();
			this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
			this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.MaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
			this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
			this.NgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
			this.SoDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Email = new DevExpress.XtraGrid.Columns.GridColumn();
			this.MaPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.MaChucVu = new DevExpress.XtraGrid.Columns.GridColumn();
			this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
			this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
			this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
			this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cbMaChucVu.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbMaPhongBan.Properties)).BeginInit();
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
			this.barDockControlTop.Size = new System.Drawing.Size(1207, 30);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 474);
			this.barDockControlBottom.Manager = this.barManager1;
			this.barDockControlBottom.Size = new System.Drawing.Size(1207, 20);
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
			this.barDockControlRight.Location = new System.Drawing.Point(1207, 30);
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
			this.splitContainer1.Panel1.Controls.Add(this.cbMaChucVu);
			this.splitContainer1.Panel1.Controls.Add(this.cbMaPhongBan);
			this.splitContainer1.Panel1.Controls.Add(this.txtEmail);
			this.splitContainer1.Panel1.Controls.Add(this.txtSoDienThoai);
			this.splitContainer1.Panel1.Controls.Add(this.txtNgaySinh);
			this.splitContainer1.Panel1.Controls.Add(this.txtHoTen);
			this.splitContainer1.Panel1.Controls.Add(this.txtMaNhanVien);
			this.splitContainer1.Panel1.Controls.Add(this.labelControl7);
			this.splitContainer1.Panel1.Controls.Add(this.labelControl6);
			this.splitContainer1.Panel1.Controls.Add(this.labelControl5);
			this.splitContainer1.Panel1.Controls.Add(this.labelControl4);
			this.splitContainer1.Panel1.Controls.Add(this.labelControl3);
			this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
			this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.gcDanhSach);
			this.splitContainer1.Size = new System.Drawing.Size(1207, 444);
			this.splitContainer1.SplitterDistance = 67;
			this.splitContainer1.TabIndex = 22;
			// 
			// cbMaChucVu
			// 
			this.cbMaChucVu.Location = new System.Drawing.Point(566, 35);
			this.cbMaChucVu.MenuManager = this.barManager1;
			this.cbMaChucVu.Name = "cbMaChucVu";
			this.cbMaChucVu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbMaChucVu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.cbMaChucVu.Size = new System.Drawing.Size(100, 22);
			this.cbMaChucVu.TabIndex = 15;
			// 
			// cbMaPhongBan
			// 
			this.cbMaPhongBan.Location = new System.Drawing.Point(347, 35);
			this.cbMaPhongBan.MenuManager = this.barManager1;
			this.cbMaPhongBan.Name = "cbMaPhongBan";
			this.cbMaPhongBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbMaPhongBan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.cbMaPhongBan.Size = new System.Drawing.Size(100, 22);
			this.cbMaPhongBan.TabIndex = 14;
			this.cbMaPhongBan.SelectedIndexChanged += new System.EventHandler(this.cbMaPhongBan_SelectedIndexChanged);
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(99, 34);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(100, 23);
			this.txtEmail.TabIndex = 11;
			// 
			// txtSoDienThoai
			// 
			this.txtSoDienThoai.Location = new System.Drawing.Point(790, 3);
			this.txtSoDienThoai.Name = "txtSoDienThoai";
			this.txtSoDienThoai.Size = new System.Drawing.Size(100, 23);
			this.txtSoDienThoai.TabIndex = 10;
			// 
			// txtNgaySinh
			// 
			this.txtNgaySinh.Location = new System.Drawing.Point(566, 3);
			this.txtNgaySinh.Name = "txtNgaySinh";
			this.txtNgaySinh.Size = new System.Drawing.Size(100, 23);
			this.txtNgaySinh.TabIndex = 9;
			// 
			// txtHoTen
			// 
			this.txtHoTen.Location = new System.Drawing.Point(347, 3);
			this.txtHoTen.Name = "txtHoTen";
			this.txtHoTen.Size = new System.Drawing.Size(100, 23);
			this.txtHoTen.TabIndex = 8;
			// 
			// txtMaNhanVien
			// 
			this.txtMaNhanVien.Location = new System.Drawing.Point(99, 3);
			this.txtMaNhanVien.Name = "txtMaNhanVien";
			this.txtMaNhanVien.Size = new System.Drawing.Size(100, 23);
			this.txtMaNhanVien.TabIndex = 7;
			// 
			// labelControl7
			// 
			this.labelControl7.Location = new System.Drawing.Point(490, 37);
			this.labelControl7.Name = "labelControl7";
			this.labelControl7.Size = new System.Drawing.Size(70, 16);
			this.labelControl7.TabIndex = 6;
			this.labelControl7.Text = "Mã chức vụ:";
			// 
			// labelControl6
			// 
			this.labelControl6.Location = new System.Drawing.Point(244, 37);
			this.labelControl6.Name = "labelControl6";
			this.labelControl6.Size = new System.Drawing.Size(86, 16);
			this.labelControl6.TabIndex = 5;
			this.labelControl6.Text = "Mã phòng ban:";
			// 
			// labelControl5
			// 
			this.labelControl5.Location = new System.Drawing.Point(12, 37);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new System.Drawing.Size(36, 16);
			this.labelControl5.TabIndex = 4;
			this.labelControl5.Text = "Email:";
			// 
			// labelControl4
			// 
			this.labelControl4.Location = new System.Drawing.Point(704, 6);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(80, 16);
			this.labelControl4.TabIndex = 3;
			this.labelControl4.Text = "Số điện thoại:";
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(490, 6);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(60, 16);
			this.labelControl3.TabIndex = 2;
			this.labelControl3.Text = "Ngày sinh:";
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(244, 6);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(59, 16);
			this.labelControl2.TabIndex = 1;
			this.labelControl2.Text = "Họ và tên:";
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 6);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(81, 16);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Mã nhân viên:";
			// 
			// gcDanhSach
			// 
			this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcDanhSach.Location = new System.Drawing.Point(0, 0);
			this.gcDanhSach.MainView = this.gvDanhSach;
			this.gcDanhSach.MenuManager = this.barManager1;
			this.gcDanhSach.Name = "gcDanhSach";
			this.gcDanhSach.Size = new System.Drawing.Size(1207, 373);
			this.gcDanhSach.TabIndex = 0;
			this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
			this.gcDanhSach.Click += new System.EventHandler(this.gcDanhSach_Click);
			// 
			// gvDanhSach
			// 
			this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaNhanVien,
            this.HoTen,
            this.NgaySinh,
            this.SoDienThoai,
            this.Email,
            this.MaPhongBan,
            this.MaChucVu});
			this.gvDanhSach.GridControl = this.gcDanhSach;
			this.gvDanhSach.Name = "gvDanhSach";
			this.gvDanhSach.OptionsFind.AlwaysVisible = true;
			this.gvDanhSach.OptionsView.ShowGroupPanel = false;
			this.gvDanhSach.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDanhSach_FocusedRowChanged);
			this.gvDanhSach.DoubleClick += new System.EventHandler(this.gvDanhSach_DoubleClick);
			// 
			// MaNhanVien
			// 
			this.MaNhanVien.Caption = "Mã nhân viên";
			this.MaNhanVien.FieldName = "MaNhanVien";
			this.MaNhanVien.MinWidth = 25;
			this.MaNhanVien.Name = "MaNhanVien";
			this.MaNhanVien.Visible = true;
			this.MaNhanVien.VisibleIndex = 0;
			this.MaNhanVien.Width = 37;
			// 
			// HoTen
			// 
			this.HoTen.Caption = "Họ và tên";
			this.HoTen.FieldName = "HoTen";
			this.HoTen.MinWidth = 25;
			this.HoTen.Name = "HoTen";
			this.HoTen.Visible = true;
			this.HoTen.VisibleIndex = 1;
			this.HoTen.Width = 168;
			// 
			// NgaySinh
			// 
			this.NgaySinh.Caption = "Ngày sinh";
			this.NgaySinh.FieldName = "NgaySinh";
			this.NgaySinh.MinWidth = 25;
			this.NgaySinh.Name = "NgaySinh";
			this.NgaySinh.Visible = true;
			this.NgaySinh.VisibleIndex = 2;
			this.NgaySinh.Width = 117;
			// 
			// SoDienThoai
			// 
			this.SoDienThoai.Caption = "Số điện thoại";
			this.SoDienThoai.FieldName = "SoDienThoai";
			this.SoDienThoai.MinWidth = 25;
			this.SoDienThoai.Name = "SoDienThoai";
			this.SoDienThoai.Visible = true;
			this.SoDienThoai.VisibleIndex = 3;
			this.SoDienThoai.Width = 140;
			// 
			// Email
			// 
			this.Email.Caption = "Email";
			this.Email.FieldName = "Email";
			this.Email.MinWidth = 25;
			this.Email.Name = "Email";
			this.Email.Visible = true;
			this.Email.VisibleIndex = 4;
			this.Email.Width = 230;
			// 
			// MaPhongBan
			// 
			this.MaPhongBan.Caption = "Phòng ban";
			this.MaPhongBan.FieldName = "PhongBan.TenPhongBan";
			this.MaPhongBan.MinWidth = 25;
			this.MaPhongBan.Name = "MaPhongBan";
			this.MaPhongBan.Visible = true;
			this.MaPhongBan.VisibleIndex = 5;
			this.MaPhongBan.Width = 232;
			// 
			// MaChucVu
			// 
			this.MaChucVu.Caption = "Chức vụ";
			this.MaChucVu.FieldName = "ChucVu.TenChucVu";
			this.MaChucVu.MinWidth = 25;
			this.MaChucVu.Name = "MaChucVu";
			this.MaChucVu.Visible = true;
			this.MaChucVu.VisibleIndex = 6;
			this.MaChucVu.Width = 253;
			// 
			// barDockControl3
			// 
			this.barDockControl3.CausesValidation = false;
			this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControl3.Location = new System.Drawing.Point(0, 30);
			this.barDockControl3.Manager = this.barManager1;
			this.barDockControl3.Size = new System.Drawing.Size(1207, 0);
			// 
			// barDockControl4
			// 
			this.barDockControl4.CausesValidation = false;
			this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControl4.Location = new System.Drawing.Point(0, 30);
			this.barDockControl4.Manager = this.barManager1;
			this.barDockControl4.Size = new System.Drawing.Size(1207, 0);
			// 
			// barDockControl1
			// 
			this.barDockControl1.CausesValidation = false;
			this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControl1.Location = new System.Drawing.Point(0, 30);
			this.barDockControl1.Manager = this.barManager1;
			this.barDockControl1.Size = new System.Drawing.Size(1207, 0);
			// 
			// barDockControl2
			// 
			this.barDockControl2.CausesValidation = false;
			this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControl2.Location = new System.Drawing.Point(0, 30);
			this.barDockControl2.Manager = this.barManager1;
			this.barDockControl2.Size = new System.Drawing.Size(1207, 0);
			// 
			// frmNhanVien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1207, 494);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.barDockControl3);
			this.Controls.Add(this.barDockControl4);
			this.Controls.Add(this.barDockControl1);
			this.Controls.Add(this.barDockControl2);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "frmNhanVien";
			this.Text = "NhanVien";
			this.Load += new System.EventHandler(this.NhanVien_Load);
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cbMaChucVu.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbMaPhongBan.Properties)).EndInit();
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
		private DevExpress.XtraBars.BarDockControl barDockControl3;
		private DevExpress.XtraBars.BarDockControl barDockControl4;
		private DevExpress.XtraBars.BarDockControl barDockControl1;
		private DevExpress.XtraBars.BarDockControl barDockControl2;
		private DevExpress.XtraGrid.Columns.GridColumn MaNhanVien;
		private DevExpress.XtraGrid.Columns.GridColumn HoTen;
		private DevExpress.XtraGrid.Columns.GridColumn NgaySinh;
		private DevExpress.XtraGrid.Columns.GridColumn SoDienThoai;
		private DevExpress.XtraGrid.Columns.GridColumn Email;
		private DevExpress.XtraGrid.Columns.GridColumn MaPhongBan;
		private DevExpress.XtraGrid.Columns.GridColumn MaChucVu;
		private DevExpress.XtraEditors.LabelControl labelControl7;
		private DevExpress.XtraEditors.LabelControl labelControl6;
		private DevExpress.XtraEditors.LabelControl labelControl5;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtSoDienThoai;
		private System.Windows.Forms.TextBox txtNgaySinh;
		private System.Windows.Forms.TextBox txtHoTen;
		private System.Windows.Forms.TextBox txtMaNhanVien;
		private DevExpress.XtraEditors.ComboBoxEdit cbMaChucVu;
		private DevExpress.XtraEditors.ComboBoxEdit cbMaPhongBan;
	}
}