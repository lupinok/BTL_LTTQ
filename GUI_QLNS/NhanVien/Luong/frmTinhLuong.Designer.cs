namespace GUI_QLNS.NhanVien.Luong
{
    partial class frmTinhLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTinhLuong));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.btnXem = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnBangLuong = new System.Windows.Forms.Button();
            this.cbBaoHiem = new System.Windows.Forms.ComboBox();
            this.cboNam = new DevExpress.XtraEditors.LabelControl();
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.gcHDLD = new DevExpress.XtraGrid.GridControl();
            this.gvHDLD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaPhieuLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayTinhLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LuongCoBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TangCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhuCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UngLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KTKL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LuongNhanDuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.btnHuy,
            this.btnXem,
            this.barButtonItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Tính lương";
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
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Name = "btnXoa";
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.Name = "btnLuu";
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy";
            this.btnHuy.Id = 4;
            this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
            this.btnHuy.Name = "btnHuy";
            // 
            // btnXem
            // 
            this.btnXem.Caption = "Xem bảng công";
            this.btnXem.Id = 5;
            this.btnXem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXem.ImageOptions.SvgImage")));
            this.btnXem.Name = "btnXem";
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
            this.barDockControlTop.Size = new System.Drawing.Size(1134, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 521);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1134, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 497);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1134, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 497);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnBangLuong);
            this.panelControl1.Controls.Add(this.cbBaoHiem);
            this.panelControl1.Controls.Add(this.cboNam);
            this.panelControl1.Controls.Add(this.cbThang);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1134, 53);
            this.panelControl1.TabIndex = 7;
            // 
            // btnBangLuong
            // 
            this.btnBangLuong.Location = new System.Drawing.Point(646, 5);
            this.btnBangLuong.Name = "btnBangLuong";
            this.btnBangLuong.Size = new System.Drawing.Size(98, 23);
            this.btnBangLuong.TabIndex = 60;
            this.btnBangLuong.Text = "Xem bảng lương";
            this.btnBangLuong.UseVisualStyleBackColor = true;
            this.btnBangLuong.Click += new System.EventHandler(this.btnBangLuong_Click);
            // 
            // cbBaoHiem
            // 
            this.cbBaoHiem.FormattingEnabled = true;
            this.cbBaoHiem.Items.AddRange(new object[] {
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024"});
            this.cbBaoHiem.Location = new System.Drawing.Point(492, 7);
            this.cbBaoHiem.Name = "cbBaoHiem";
            this.cbBaoHiem.Size = new System.Drawing.Size(93, 21);
            this.cbBaoHiem.TabIndex = 59;
            // 
            // cboNam
            // 
            this.cboNam.Location = new System.Drawing.Point(461, 11);
            this.cboNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(25, 13);
            this.cboNam.TabIndex = 58;
            this.cboNam.Text = "Năm:";
            // 
            // cbThang
            // 
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbThang.Location = new System.Drawing.Point(276, 7);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(99, 21);
            this.cbThang.TabIndex = 49;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(236, 11);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(34, 13);
            this.labelControl8.TabIndex = 48;
            this.labelControl8.Text = "Tháng:";
            // 
            // gcHDLD
            // 
            this.gcHDLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHDLD.Location = new System.Drawing.Point(0, 77);
            this.gcHDLD.MainView = this.gvHDLD;
            this.gcHDLD.MenuManager = this.barManager1;
            this.gcHDLD.Name = "gcHDLD";
            this.gcHDLD.Size = new System.Drawing.Size(1134, 444);
            this.gcHDLD.TabIndex = 22;
            this.gcHDLD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHDLD});
            // 
            // gvHDLD
            // 
            this.gvHDLD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaPhieuLuong,
            this.HoTen,
            this.NgayTinhLuong,
            this.LuongCoBan,
            this.TangCa,
            this.PhuCap,
            this.UngLuong,
            this.NgayCong,
            this.KTKL,
            this.LuongNhanDuoc,
            this.MaNhanVien});
            this.gvHDLD.GridControl = this.gcHDLD;
            this.gvHDLD.Name = "gvHDLD";
            // 
            // MaPhieuLuong
            // 
            this.MaPhieuLuong.Caption = "Kỳ công";
            this.MaPhieuLuong.FieldName = "MaPhieuLuong";
            this.MaPhieuLuong.Name = "MaPhieuLuong";
            this.MaPhieuLuong.Visible = true;
            this.MaPhieuLuong.VisibleIndex = 0;
            this.MaPhieuLuong.Width = 66;
            // 
            // HoTen
            // 
            this.HoTen.Caption = "Nhân viên";
            this.HoTen.FieldName = "HoTen";
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = true;
            this.HoTen.VisibleIndex = 1;
            // 
            // NgayTinhLuong
            // 
            this.NgayTinhLuong.Caption = "Ngày tính lương";
            this.NgayTinhLuong.FieldName = "NgayTinhLuong";
            this.NgayTinhLuong.Name = "NgayTinhLuong";
            this.NgayTinhLuong.Width = 88;
            // 
            // LuongCoBan
            // 
            this.LuongCoBan.Caption = "Lương cơ bản";
            this.LuongCoBan.FieldName = "LuongCoBan";
            this.LuongCoBan.Name = "LuongCoBan";
            this.LuongCoBan.Visible = true;
            this.LuongCoBan.VisibleIndex = 2;
            this.LuongCoBan.Width = 74;
            // 
            // TangCa
            // 
            this.TangCa.Caption = "Tăng ca";
            this.TangCa.FieldName = "TangCa";
            this.TangCa.Name = "TangCa";
            this.TangCa.Visible = true;
            this.TangCa.VisibleIndex = 3;
            this.TangCa.Width = 80;
            // 
            // PhuCap
            // 
            this.PhuCap.Caption = "Phụ cấp";
            this.PhuCap.FieldName = "PhuCap";
            this.PhuCap.Name = "PhuCap";
            this.PhuCap.Visible = true;
            this.PhuCap.VisibleIndex = 4;
            this.PhuCap.Width = 87;
            // 
            // UngLuong
            // 
            this.UngLuong.Caption = "Ứng lương";
            this.UngLuong.FieldName = "UngLuong";
            this.UngLuong.Name = "UngLuong";
            this.UngLuong.Visible = true;
            this.UngLuong.VisibleIndex = 5;
            this.UngLuong.Width = 139;
            // 
            // NgayCong
            // 
            this.NgayCong.Caption = "Ngày công";
            this.NgayCong.FieldName = "NgayCong";
            this.NgayCong.Name = "NgayCong";
            this.NgayCong.Visible = true;
            this.NgayCong.VisibleIndex = 6;
            this.NgayCong.Width = 104;
            // 
            // KTKL
            // 
            this.KTKL.Caption = "Khen thưởng/Kỉ luật";
            this.KTKL.FieldName = "KTKL";
            this.KTKL.Name = "KTKL";
            this.KTKL.Visible = true;
            this.KTKL.VisibleIndex = 7;
            this.KTKL.Width = 132;
            // 
            // LuongNhanDuoc
            // 
            this.LuongNhanDuoc.Caption = "Lương thực nhận";
            this.LuongNhanDuoc.FieldName = "LuongNhanDuoc";
            this.LuongNhanDuoc.Name = "LuongNhanDuoc";
            this.LuongNhanDuoc.Visible = true;
            this.LuongNhanDuoc.VisibleIndex = 8;
            this.LuongNhanDuoc.Width = 129;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.Caption = "gridColumn1";
            this.MaNhanVien.FieldName = "MaNhanVien";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // frmTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 541);
            this.Controls.Add(this.gcHDLD);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmTinhLuong";
            this.Text = "frmTinhLuong";
            this.Load += new System.EventHandler(this.frmTinhLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
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
        private DevExpress.XtraBars.BarButtonItem btnXem;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cbBaoHiem;
        private DevExpress.XtraEditors.LabelControl cboNam;
        private System.Windows.Forms.ComboBox cbThang;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraGrid.GridControl gcHDLD;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHDLD;
        private DevExpress.XtraGrid.Columns.GridColumn MaPhieuLuong;
        private DevExpress.XtraGrid.Columns.GridColumn NgayTinhLuong;
        private DevExpress.XtraGrid.Columns.GridColumn LuongCoBan;
        private DevExpress.XtraGrid.Columns.GridColumn TangCa;
        private DevExpress.XtraGrid.Columns.GridColumn PhuCap;
        private DevExpress.XtraGrid.Columns.GridColumn UngLuong;
        private DevExpress.XtraGrid.Columns.GridColumn NgayCong;
        private DevExpress.XtraGrid.Columns.GridColumn KTKL;
        private DevExpress.XtraGrid.Columns.GridColumn LuongNhanDuoc;
        private DevExpress.XtraGrid.Columns.GridColumn MaNhanVien;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.Button btnBangLuong;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
    }
}