namespace GUI_QLNS.NhanVien.Luong
{
    partial class frmHDLD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHDLD));
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtMD = new System.Windows.Forms.TextBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtSHD = new System.Windows.Forms.TextBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.cbBaoHiem = new System.Windows.Forms.ComboBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dateNKT = new System.Windows.Forms.DateTimePicker();
            this.dateNBD = new System.Windows.Forms.DateTimePicker();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.cbLoaiHD = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.scNhanVien = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gcHDLD = new DevExpress.XtraGrid.GridControl();
            this.gvHDLD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaHopDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoaiHopDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LuongHopDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NoiDungHopDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenBaoHiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MucDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHDLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHDLD)).BeginInit();
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(924, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 460);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(924, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 436);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(924, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 436);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtMD);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Controls.Add(this.txtSHD);
            this.panelControl1.Controls.Add(this.txtLuong);
            this.panelControl1.Controls.Add(this.cbBaoHiem);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.dateNKT);
            this.panelControl1.Controls.Add(this.dateNBD);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtGhiChu);
            this.panelControl1.Controls.Add(this.cbLoaiHD);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.scNhanVien);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(924, 91);
            this.panelControl1.TabIndex = 6;
            // 
            // txtMD
            // 
            this.txtMD.Location = new System.Drawing.Point(821, 7);
            this.txtMD.Name = "txtMD";
            this.txtMD.Size = new System.Drawing.Size(98, 21);
            this.txtMD.TabIndex = 63;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(764, 11);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(51, 13);
            this.labelControl9.TabIndex = 62;
            this.labelControl9.Text = "Mức đóng:";
            // 
            // txtSHD
            // 
            this.txtSHD.Location = new System.Drawing.Point(79, 7);
            this.txtSHD.Name = "txtSHD";
            this.txtSHD.Size = new System.Drawing.Size(118, 21);
            this.txtSHD.TabIndex = 61;
            // 
            // txtLuong
            // 
            this.txtLuong.Location = new System.Drawing.Point(480, 7);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(98, 21);
            this.txtLuong.TabIndex = 60;
            // 
            // cbBaoHiem
            // 
            this.cbBaoHiem.FormattingEnabled = true;
            this.cbBaoHiem.Items.AddRange(new object[] {
            "Bảo hiểm sức khỏe",
            "Bảo hiểm lao động",
            "Bảo hiểm nhân thọ"});
            this.cbBaoHiem.Location = new System.Drawing.Point(653, 7);
            this.cbBaoHiem.Name = "cbBaoHiem";
            this.cbBaoHiem.Size = new System.Drawing.Size(93, 21);
            this.cbBaoHiem.TabIndex = 59;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(600, 11);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(47, 13);
            this.labelControl7.TabIndex = 58;
            this.labelControl7.Text = "Bảo hiểm:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 11);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 13);
            this.labelControl6.TabIndex = 56;
            this.labelControl6.Text = "Số hợp đồng:";
            // 
            // dateNKT
            // 
            this.dateNKT.CustomFormat = "dd/MM/yyyy";
            this.dateNKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNKT.Location = new System.Drawing.Point(79, 61);
            this.dateNKT.Name = "dateNKT";
            this.dateNKT.Size = new System.Drawing.Size(118, 21);
            this.dateNKT.TabIndex = 55;
            // 
            // dateNBD
            // 
            this.dateNBD.CustomFormat = "dd/MM/yyyy";
            this.dateNBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNBD.Location = new System.Drawing.Point(79, 34);
            this.dateNBD.Name = "dateNBD";
            this.dateNBD.Size = new System.Drawing.Size(118, 21);
            this.dateNBD.TabIndex = 54;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(23, 67);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(44, 13);
            this.labelControl4.TabIndex = 53;
            this.labelControl4.Text = "Ngày KT:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 40);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 51;
            this.labelControl2.Text = "Ngày BĐ:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(313, 51);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(265, 21);
            this.txtGhiChu.TabIndex = 50;
            // 
            // cbLoaiHD
            // 
            this.cbLoaiHD.FormattingEnabled = true;
            this.cbLoaiHD.Items.AddRange(new object[] {
            "Thường",
            "Thử việc"});
            this.cbLoaiHD.Location = new System.Drawing.Point(313, 7);
            this.cbLoaiHD.Name = "cbLoaiHD";
            this.cbLoaiHD.Size = new System.Drawing.Size(99, 21);
            this.cbLoaiHD.TabIndex = 49;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(440, 11);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 48;
            this.labelControl1.Text = "Lương:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(236, 11);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(71, 13);
            this.labelControl8.TabIndex = 48;
            this.labelControl8.Text = "Loại hợp đồng:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(261, 54);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 13);
            this.labelControl5.TabIndex = 46;
            this.labelControl5.Text = "Nội dung:";
            // 
            // scNhanVien
            // 
            this.scNhanVien.Location = new System.Drawing.Point(670, 52);
            this.scNhanVien.MenuManager = this.barManager1;
            this.scNhanVien.Name = "scNhanVien";
            this.scNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.scNhanVien.Properties.PopupView = this.searchLookUpEdit1View;
            this.scNhanVien.Size = new System.Drawing.Size(118, 20);
            this.scNhanVien.TabIndex = 47;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(612, 54);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 45;
            this.labelControl3.Text = "Nhân viên:";
            // 
            // gcHDLD
            // 
            this.gcHDLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHDLD.Location = new System.Drawing.Point(0, 115);
            this.gcHDLD.MainView = this.gvHDLD;
            this.gcHDLD.MenuManager = this.barManager1;
            this.gcHDLD.Name = "gcHDLD";
            this.gcHDLD.Size = new System.Drawing.Size(924, 345);
            this.gcHDLD.TabIndex = 21;
            this.gcHDLD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHDLD});
            // 
            // gvHDLD
            // 
            this.gvHDLD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaHopDong,
            this.NgayBatDau,
            this.NgayKetThuc,
            this.LoaiHopDong,
            this.LuongHopDong,
            this.NoiDungHopDong,
            this.TenBaoHiem,
            this.MucDong,
            this.HoTen,
            this.MaNhanVien});
            this.gvHDLD.GridControl = this.gcHDLD;
            this.gvHDLD.Name = "gvHDLD";
            this.gvHDLD.Click += new System.EventHandler(this.gvHDLD_Click);
            // 
            // MaHopDong
            // 
            this.MaHopDong.Caption = "Mã hợp đồng";
            this.MaHopDong.FieldName = "MaHopDong";
            this.MaHopDong.Name = "MaHopDong";
            this.MaHopDong.Visible = true;
            this.MaHopDong.VisibleIndex = 0;
            this.MaHopDong.Width = 66;
            // 
            // NgayBatDau
            // 
            this.NgayBatDau.Caption = "Ngày bắt đầu";
            this.NgayBatDau.FieldName = "NgayBatDau";
            this.NgayBatDau.Name = "NgayBatDau";
            this.NgayBatDau.Visible = true;
            this.NgayBatDau.VisibleIndex = 1;
            this.NgayBatDau.Width = 88;
            // 
            // NgayKetThuc
            // 
            this.NgayKetThuc.Caption = "Ngày kết thúc";
            this.NgayKetThuc.FieldName = "NgayKetThuc";
            this.NgayKetThuc.Name = "NgayKetThuc";
            this.NgayKetThuc.Visible = true;
            this.NgayKetThuc.VisibleIndex = 2;
            this.NgayKetThuc.Width = 74;
            // 
            // LoaiHopDong
            // 
            this.LoaiHopDong.Caption = "Loại hợp đồng";
            this.LoaiHopDong.FieldName = "LoaiHopDong";
            this.LoaiHopDong.Name = "LoaiHopDong";
            this.LoaiHopDong.Visible = true;
            this.LoaiHopDong.VisibleIndex = 3;
            this.LoaiHopDong.Width = 80;
            // 
            // LuongHopDong
            // 
            this.LuongHopDong.Caption = "Lương hợp đồng";
            this.LuongHopDong.FieldName = "LuongHopDong";
            this.LuongHopDong.Name = "LuongHopDong";
            this.LuongHopDong.Visible = true;
            this.LuongHopDong.VisibleIndex = 4;
            this.LuongHopDong.Width = 87;
            // 
            // NoiDungHopDong
            // 
            this.NoiDungHopDong.Caption = "Ghi chú";
            this.NoiDungHopDong.FieldName = "NoiDungHopDong";
            this.NoiDungHopDong.Name = "NoiDungHopDong";
            this.NoiDungHopDong.Visible = true;
            this.NoiDungHopDong.VisibleIndex = 5;
            this.NoiDungHopDong.Width = 139;
            // 
            // TenBaoHiem
            // 
            this.TenBaoHiem.Caption = "Tên bảo hiểm";
            this.TenBaoHiem.FieldName = "TenBaoHiem";
            this.TenBaoHiem.Name = "TenBaoHiem";
            this.TenBaoHiem.Visible = true;
            this.TenBaoHiem.VisibleIndex = 6;
            this.TenBaoHiem.Width = 104;
            // 
            // MucDong
            // 
            this.MucDong.Caption = "Mức đóng";
            this.MucDong.FieldName = "MucDong";
            this.MucDong.Name = "MucDong";
            this.MucDong.Visible = true;
            this.MucDong.VisibleIndex = 7;
            this.MucDong.Width = 132;
            // 
            // HoTen
            // 
            this.HoTen.Caption = "Nhân viên";
            this.HoTen.FieldName = "HoTen";
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = true;
            this.HoTen.VisibleIndex = 8;
            this.HoTen.Width = 129;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.Caption = "gridColumn1";
            this.MaNhanVien.FieldName = "MaNhanVien";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // frmHDLD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 480);
            this.Controls.Add(this.gcHDLD);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmHDLD";
            this.Text = "HopDongLaoDong";
            this.Load += new System.EventHandler(this.frmHDLD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHDLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHDLD)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.ComboBox cbLoaiHD;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SearchLookUpEdit scNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gcHDLD;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHDLD;
        private DevExpress.XtraGrid.Columns.GridColumn NgayBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn NgayKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn LoaiHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn LuongHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn NoiDungHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn MaNhanVien;
        private System.Windows.Forms.DateTimePicker dateNBD;
        private System.Windows.Forms.DateTimePicker dateNKT;
        private System.Windows.Forms.ComboBox cbBaoHiem;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.TextBox txtLuong;
        private DevExpress.XtraGrid.Columns.GridColumn MaHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
        private System.Windows.Forms.TextBox txtSHD;
        private DevExpress.XtraGrid.Columns.GridColumn TenBaoHiem;
        private DevExpress.XtraGrid.Columns.GridColumn MucDong;
        private System.Windows.Forms.TextBox txtMD;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}