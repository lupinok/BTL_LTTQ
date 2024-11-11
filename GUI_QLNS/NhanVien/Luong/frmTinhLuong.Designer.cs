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
            this.btnIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
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
            this.MaKyCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayTinhLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LuongCoBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TangCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhuCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UngLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TienBaoHiem = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.btnIn,
            this.btnHuy,
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnIn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // btnIn
            // 
            this.btnIn.Caption = "In";
            this.btnIn.Id = 1;
            this.btnIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIn.ImageOptions.SvgImage")));
            this.btnIn.Name = "btnIn";
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy";
            this.btnHuy.Id = 4;
            this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
            this.btnHuy.Name = "btnHuy";
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(1323, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 646);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1323, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 616);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1323, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 616);
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
            this.panelControl1.Location = new System.Drawing.Point(0, 30);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1323, 65);
            this.panelControl1.TabIndex = 7;
            // 
            // btnBangLuong
            // 
            this.btnBangLuong.Location = new System.Drawing.Point(754, 6);
            this.btnBangLuong.Margin = new System.Windows.Forms.Padding(4);
            this.btnBangLuong.Name = "btnBangLuong";
            this.btnBangLuong.Size = new System.Drawing.Size(114, 28);
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
            this.cbBaoHiem.Location = new System.Drawing.Point(574, 9);
            this.cbBaoHiem.Margin = new System.Windows.Forms.Padding(4);
            this.cbBaoHiem.Name = "cbBaoHiem";
            this.cbBaoHiem.Size = new System.Drawing.Size(108, 24);
            this.cbBaoHiem.TabIndex = 59;
            // 
            // cboNam
            // 
            this.cboNam.Location = new System.Drawing.Point(538, 14);
            this.cboNam.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(31, 16);
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
            this.cbThang.Location = new System.Drawing.Point(322, 9);
            this.cbThang.Margin = new System.Windows.Forms.Padding(4);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(115, 24);
            this.cbThang.TabIndex = 49;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(275, 14);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(41, 16);
            this.labelControl8.TabIndex = 48;
            this.labelControl8.Text = "Tháng:";
            // 
            // gcHDLD
            // 
            this.gcHDLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHDLD.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gcHDLD.Location = new System.Drawing.Point(0, 95);
            this.gcHDLD.MainView = this.gvHDLD;
            this.gcHDLD.Margin = new System.Windows.Forms.Padding(4);
            this.gcHDLD.MenuManager = this.barManager1;
            this.gcHDLD.Name = "gcHDLD";
            this.gcHDLD.Size = new System.Drawing.Size(1323, 551);
            this.gcHDLD.TabIndex = 22;
            this.gcHDLD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHDLD});
            // 
            // gvHDLD
            // 
            this.gvHDLD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaPhieuLuong,
            this.MaKyCong,
            this.HoTen,
            this.NgayTinhLuong,
            this.LuongCoBan,
            this.TangCa,
            this.PhuCap,
            this.UngLuong,
            this.NgayCong,
            this.TienBaoHiem,
            this.KTKL,
            this.LuongNhanDuoc,
            this.MaNhanVien});
            this.gvHDLD.DetailHeight = 431;
            this.gvHDLD.GridControl = this.gcHDLD;
            this.gvHDLD.Name = "gvHDLD";
            this.gvHDLD.OptionsEditForm.PopupEditFormWidth = 933;
            // 
            // MaPhieuLuong
            // 
            this.MaPhieuLuong.Caption = "Kỳ công";
            this.MaPhieuLuong.FieldName = "MaPhieuLuong";
            this.MaPhieuLuong.MinWidth = 23;
            this.MaPhieuLuong.Name = "MaPhieuLuong";
            this.MaPhieuLuong.Width = 77;
            // 
            // MaKyCong
            // 
            this.MaKyCong.Caption = "Kỳ công";
            this.MaKyCong.FieldName = "MaKyCong";
            this.MaKyCong.MinWidth = 23;
            this.MaKyCong.Name = "MaKyCong";
            this.MaKyCong.Visible = true;
            this.MaKyCong.VisibleIndex = 0;
            this.MaKyCong.Width = 59;
            // 
            // HoTen
            // 
            this.HoTen.Caption = "Nhân viên";
            this.HoTen.FieldName = "HoTen";
            this.HoTen.MinWidth = 23;
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = true;
            this.HoTen.VisibleIndex = 1;
            this.HoTen.Width = 108;
            // 
            // NgayTinhLuong
            // 
            this.NgayTinhLuong.Caption = "Ngày tính lương";
            this.NgayTinhLuong.FieldName = "NgayTinhLuong";
            this.NgayTinhLuong.MinWidth = 23;
            this.NgayTinhLuong.Name = "NgayTinhLuong";
            this.NgayTinhLuong.Width = 103;
            // 
            // LuongCoBan
            // 
            this.LuongCoBan.Caption = "Lương cơ bản";
            this.LuongCoBan.FieldName = "LuongCoBan";
            this.LuongCoBan.MinWidth = 23;
            this.LuongCoBan.Name = "LuongCoBan";
            this.LuongCoBan.Visible = true;
            this.LuongCoBan.VisibleIndex = 2;
            this.LuongCoBan.Width = 69;
            // 
            // TangCa
            // 
            this.TangCa.Caption = "Tăng ca";
            this.TangCa.FieldName = "TangCa";
            this.TangCa.MinWidth = 23;
            this.TangCa.Name = "TangCa";
            this.TangCa.Visible = true;
            this.TangCa.VisibleIndex = 3;
            this.TangCa.Width = 72;
            // 
            // PhuCap
            // 
            this.PhuCap.Caption = "Phụ cấp";
            this.PhuCap.FieldName = "PhuCap";
            this.PhuCap.MinWidth = 23;
            this.PhuCap.Name = "PhuCap";
            this.PhuCap.Visible = true;
            this.PhuCap.VisibleIndex = 4;
            this.PhuCap.Width = 69;
            // 
            // UngLuong
            // 
            this.UngLuong.Caption = "Ứng lương";
            this.UngLuong.FieldName = "UngLuong";
            this.UngLuong.MinWidth = 23;
            this.UngLuong.Name = "UngLuong";
            this.UngLuong.Visible = true;
            this.UngLuong.VisibleIndex = 5;
            this.UngLuong.Width = 72;
            // 
            // NgayCong
            // 
            this.NgayCong.Caption = "Ngày công";
            this.NgayCong.FieldName = "NGAYCONG";
            this.NgayCong.MinWidth = 23;
            this.NgayCong.Name = "NgayCong";
            this.NgayCong.Visible = true;
            this.NgayCong.VisibleIndex = 6;
            this.NgayCong.Width = 61;
            // 
            // TienBaoHiem
            // 
            this.TienBaoHiem.Caption = "Tiền bảo hiểm";
            this.TienBaoHiem.FieldName = "TienBaoHiem";
            this.TienBaoHiem.MinWidth = 23;
            this.TienBaoHiem.Name = "TienBaoHiem";
            this.TienBaoHiem.Visible = true;
            this.TienBaoHiem.VisibleIndex = 7;
            this.TienBaoHiem.Width = 84;
            // 
            // KTKL
            // 
            this.KTKL.Caption = "Khen thưởng/Kỷ luật";
            this.KTKL.FieldName = "KTKL";
            this.KTKL.MinWidth = 23;
            this.KTKL.Name = "KTKL";
            this.KTKL.Visible = true;
            this.KTKL.VisibleIndex = 8;
            this.KTKL.Width = 96;
            // 
            // LuongNhanDuoc
            // 
            this.LuongNhanDuoc.Caption = "Lương thực nhận";
            this.LuongNhanDuoc.FieldName = "LuongNhanDuoc";
            this.LuongNhanDuoc.MinWidth = 23;
            this.LuongNhanDuoc.Name = "LuongNhanDuoc";
            this.LuongNhanDuoc.Visible = true;
            this.LuongNhanDuoc.VisibleIndex = 9;
            this.LuongNhanDuoc.Width = 112;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.Caption = "gridColumn1";
            this.MaNhanVien.FieldName = "MaNhanVien";
            this.MaNhanVien.MinWidth = 23;
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Width = 87;
            // 
            // frmTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 666);
            this.Controls.Add(this.gcHDLD);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private DevExpress.XtraBars.BarButtonItem btnIn;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
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
        private DevExpress.XtraGrid.Columns.GridColumn LuongNhanDuoc;
        private DevExpress.XtraGrid.Columns.GridColumn MaNhanVien;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.Button btnBangLuong;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn MaKyCong;
        private DevExpress.XtraGrid.Columns.GridColumn TienBaoHiem;
        private DevExpress.XtraGrid.Columns.GridColumn KTKL;
    }
}