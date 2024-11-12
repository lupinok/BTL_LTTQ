namespace GUI_QLNS.NhanVien.Luong
{
    partial class frmKTKL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKTKL));
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.txtTienThuong = new System.Windows.Forms.TextBox();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.cbLyDo = new System.Windows.Forms.ComboBox();
            this.cbSuKien = new System.Windows.Forms.ComboBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.scNhanVien = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboNKT = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboNBD = new System.Windows.Forms.DateTimePicker();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gcPhuCap = new DevExpress.XtraGrid.GridControl();
            this.gvPhuCap = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaSuKien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChiTiet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TienThuongPhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPhuCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhuCap)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(925, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 394);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(925, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 370);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(925, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 370);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 24);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.txtTienThuong);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtTienPhat);
            this.splitContainerControl1.Panel2.Controls.Add(this.cbLyDo);
            this.splitContainerControl1.Panel2.Controls.Add(this.cbSuKien);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl8);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel2.Controls.Add(this.scNhanVien);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl7);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.cboNKT);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.cboNBD);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(925, 105);
            this.splitContainerControl1.SplitterPosition = 0;
            this.splitContainerControl1.TabIndex = 17;
            // 
            // txtTienThuong
            // 
            this.txtTienThuong.Location = new System.Drawing.Point(77, 75);
            this.txtTienThuong.Name = "txtTienThuong";
            this.txtTienThuong.Size = new System.Drawing.Size(153, 21);
            this.txtTienThuong.TabIndex = 43;
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.Location = new System.Drawing.Point(338, 75);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.Size = new System.Drawing.Size(161, 21);
            this.txtTienPhat.TabIndex = 42;
            // 
            // cbLyDo
            // 
            this.cbLyDo.FormattingEnabled = true;
            this.cbLyDo.Location = new System.Drawing.Point(338, 42);
            this.cbLyDo.Name = "cbLyDo";
            this.cbLyDo.Size = new System.Drawing.Size(337, 21);
            this.cbLyDo.TabIndex = 41;
            // 
            // cbSuKien
            // 
            this.cbSuKien.FormattingEnabled = true;
            this.cbSuKien.Items.AddRange(new object[] {
            "Khen thưởng",
            "Kỷ luật"});
            this.cbSuKien.Location = new System.Drawing.Point(77, 42);
            this.cbSuKien.Name = "cbSuKien";
            this.cbSuKien.Size = new System.Drawing.Size(153, 21);
            this.cbSuKien.TabIndex = 40;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(2, 45);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(55, 13);
            this.labelControl8.TabIndex = 39;
            this.labelControl8.Text = "Mã sự kiện:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(2, 80);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(62, 13);
            this.labelControl5.TabIndex = 31;
            this.labelControl5.Text = "Tiền thưởng:";
            // 
            // scNhanVien
            // 
            this.scNhanVien.Location = new System.Drawing.Point(77, 11);
            this.scNhanVien.MenuManager = this.barManager1;
            this.scNhanVien.Name = "scNhanVien";
            this.scNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.scNhanVien.Properties.PopupView = this.searchLookUpEdit1View;
            this.scNhanVien.Size = new System.Drawing.Size(118, 20);
            this.scNhanVien.TabIndex = 36;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(270, 80);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 33;
            this.labelControl7.Text = "Tiền phạt:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(270, 45);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "Nội dung:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(2, 13);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "Nhân viên:";
            // 
            // cboNKT
            // 
            this.cboNKT.CustomFormat = "dd/MM/yyyy";
            this.cboNKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cboNKT.Location = new System.Drawing.Point(538, 10);
            this.cboNKT.Name = "cboNKT";
            this.cboNKT.Size = new System.Drawing.Size(137, 21);
            this.cboNKT.TabIndex = 26;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(461, 13);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 13);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Ngày kết thúc:";
            // 
            // cboNBD
            // 
            this.cboNBD.CustomFormat = "dd/MM/yyyy";
            this.cboNBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cboNBD.Location = new System.Drawing.Point(299, 10);
            this.cboNBD.Name = "cboNBD";
            this.cboNBD.Size = new System.Drawing.Size(137, 21);
            this.cboNBD.TabIndex = 24;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(224, 13);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Ngày bắt đầu:";
            // 
            // gcPhuCap
            // 
            this.gcPhuCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPhuCap.Location = new System.Drawing.Point(0, 129);
            this.gcPhuCap.MainView = this.gvPhuCap;
            this.gcPhuCap.MenuManager = this.barManager1;
            this.gcPhuCap.Name = "gcPhuCap";
            this.gcPhuCap.Size = new System.Drawing.Size(925, 265);
            this.gcPhuCap.TabIndex = 18;
            this.gcPhuCap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPhuCap});
            // 
            // gvPhuCap
            // 
            this.gvPhuCap.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaNhanVien,
            this.MaSuKien,
            this.ChiTiet,
            this.TienThuongPhat,
            this.NgayBatDau,
            this.NgayKetThuc});
            this.gvPhuCap.GridControl = this.gcPhuCap;
            this.gvPhuCap.Name = "gvPhuCap";
            this.gvPhuCap.Click += new System.EventHandler(this.gvPhuCap_Click);
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.Caption = "Mã Nhân Viên";
            this.MaNhanVien.FieldName = "MaNhanVien";
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Visible = true;
            this.MaNhanVien.VisibleIndex = 0;
            this.MaNhanVien.Width = 79;
            // 
            // MaSuKien
            // 
            this.MaSuKien.Caption = "Mã Sự Kiện";
            this.MaSuKien.FieldName = "MaSuKien";
            this.MaSuKien.Name = "MaSuKien";
            this.MaSuKien.Visible = true;
            this.MaSuKien.VisibleIndex = 1;
            this.MaSuKien.Width = 69;
            // 
            // ChiTiet
            // 
            this.ChiTiet.Caption = "Chi Tiết";
            this.ChiTiet.FieldName = "ChiTiet";
            this.ChiTiet.Name = "ChiTiet";
            this.ChiTiet.Visible = true;
            this.ChiTiet.VisibleIndex = 2;
            this.ChiTiet.Width = 220;
            // 
            // TienThuongPhat
            // 
            this.TienThuongPhat.Caption = "Tiền Thưởng/Phạt";
            this.TienThuongPhat.FieldName = "TienThuongPhat";
            this.TienThuongPhat.Name = "TienThuongPhat";
            this.TienThuongPhat.Visible = true;
            this.TienThuongPhat.VisibleIndex = 3;
            this.TienThuongPhat.Width = 165;
            // 
            // NgayBatDau
            // 
            this.NgayBatDau.Caption = "Ngày Bắt Đầu";
            this.NgayBatDau.FieldName = "NgayBatDau";
            this.NgayBatDau.Name = "NgayBatDau";
            this.NgayBatDau.Visible = true;
            this.NgayBatDau.VisibleIndex = 4;
            this.NgayBatDau.Width = 112;
            // 
            // NgayKetThuc
            // 
            this.NgayKetThuc.Caption = "Ngày Kết Thúc";
            this.NgayKetThuc.FieldName = "NgayKetThuc";
            this.NgayKetThuc.Name = "NgayKetThuc";
            this.NgayKetThuc.Visible = true;
            this.NgayKetThuc.VisibleIndex = 5;
            this.NgayKetThuc.Width = 124;
            // 
            // frmKTKL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 414);
            this.Controls.Add(this.gcPhuCap);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmKTKL";
            this.Text = "KTKL";
            this.Load += new System.EventHandler(this.PhuCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            this.splitContainerControl1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPhuCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhuCap)).EndInit();
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
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gcPhuCap;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPhuCap;
        private System.Windows.Forms.DateTimePicker cboNBD;
        private System.Windows.Forms.DateTimePicker cboNKT;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SearchLookUpEdit scNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn MaNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn MaSuKien;
        private DevExpress.XtraGrid.Columns.GridColumn ChiTiet;
        private DevExpress.XtraGrid.Columns.GridColumn TienThuongPhat;
        private System.Windows.Forms.ComboBox cbSuKien;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.ComboBox cbLyDo;
        private System.Windows.Forms.TextBox txtTienThuong;
        private System.Windows.Forms.TextBox txtTienPhat;
        private DevExpress.XtraGrid.Columns.GridColumn NgayBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn NgayKetThuc;
    }
}