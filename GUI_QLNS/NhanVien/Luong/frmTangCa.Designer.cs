namespace GUI_QLNS.NhanVien.Luong
{
    partial class frmTangCa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTangCa));
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
            this.cboTgian = new System.Windows.Forms.DateTimePicker();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.cbSoGio = new System.Windows.Forms.ComboBox();
            this.cbLoaiCa = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.scNhanVien = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gcTangCa = new DevExpress.XtraGrid.GridControl();
            this.gvTangCa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenLoaiCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HeSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.create_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaLoaiCa = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTangCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTangCa)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(828, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 377);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(828, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 353);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(828, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 353);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cboTgian);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtGhiChu);
            this.panelControl1.Controls.Add(this.cbSoGio);
            this.panelControl1.Controls.Add(this.cbLoaiCa);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.scNhanVien);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(828, 91);
            this.panelControl1.TabIndex = 4;
            // 
            // cboTgian
            // 
            this.cboTgian.CustomFormat = "dd/MM/yyyy";
            this.cboTgian.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cboTgian.Location = new System.Drawing.Point(664, 8);
            this.cboTgian.Name = "cboTgian";
            this.cboTgian.Size = new System.Drawing.Size(137, 21);
            this.cboTgian.TabIndex = 52;
            this.cboTgian.ValueChanged += new System.EventHandler(this.cboNBD_ValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(611, 11);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 51;
            this.labelControl2.Text = "Thời gian:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(73, 54);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(522, 21);
            this.txtGhiChu.TabIndex = 50;
            // 
            // cbSoGio
            // 
            this.cbSoGio.FormattingEnabled = true;
            this.cbSoGio.Items.AddRange(new object[] {
            "0.5",
            "1.0",
            "1.5",
            "2.0",
            "2.5",
            "3.0",
            "3.5",
            "4.0",
            "4.5",
            "5.0",
            "5.5",
            "6.0"});
            this.cbSoGio.Location = new System.Drawing.Point(464, 8);
            this.cbSoGio.Name = "cbSoGio";
            this.cbSoGio.Size = new System.Drawing.Size(131, 21);
            this.cbSoGio.TabIndex = 49;
            // 
            // cbLoaiCa
            // 
            this.cbLoaiCa.FormattingEnabled = true;
            this.cbLoaiCa.Items.AddRange(new object[] {
            "Khen thu?ng",
            "K? lu?t"});
            this.cbLoaiCa.Location = new System.Drawing.Point(254, 7);
            this.cbLoaiCa.Name = "cbLoaiCa";
            this.cbLoaiCa.Size = new System.Drawing.Size(131, 21);
            this.cbLoaiCa.TabIndex = 49;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(425, 11);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 48;
            this.labelControl1.Text = "Số giờ:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(211, 10);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 13);
            this.labelControl8.TabIndex = 48;
            this.labelControl8.Text = "Loại ca:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(28, 57);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(39, 13);
            this.labelControl5.TabIndex = 46;
            this.labelControl5.Text = "Ghi chú:";
            // 
            // scNhanVien
            // 
            this.scNhanVien.Location = new System.Drawing.Point(73, 8);
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
            this.labelControl3.Location = new System.Drawing.Point(15, 10);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 45;
            this.labelControl3.Text = "Nhân viên:";
            // 
            // gcTangCa
            // 
            this.gcTangCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTangCa.Location = new System.Drawing.Point(0, 115);
            this.gcTangCa.MainView = this.gvTangCa;
            this.gcTangCa.MenuManager = this.barManager1;
            this.gcTangCa.Name = "gcTangCa";
            this.gcTangCa.Size = new System.Drawing.Size(828, 262);
            this.gcTangCa.TabIndex = 19;
            this.gcTangCa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTangCa});
            // 
            // gvTangCa
            // 
            this.gvTangCa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.HoTen,
            this.TenLoaiCa,
            this.SoGio,
            this.HeSo,
            this.SoTien,
            this.GhiChu,
            this.create_date,
            this.MaNhanVien,
            this.MaLoaiCa});
            this.gvTangCa.GridControl = this.gcTangCa;
            this.gvTangCa.Name = "gvTangCa";
            this.gvTangCa.Click += new System.EventHandler(this.gvTangCa_Click);
            // 
            // HoTen
            // 
            this.HoTen.Caption = "Họ và Tên";
            this.HoTen.FieldName = "HoTen";
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = true;
            this.HoTen.VisibleIndex = 0;
            this.HoTen.Width = 82;
            // 
            // TenLoaiCa
            // 
            this.TenLoaiCa.Caption = "Loại Ca";
            this.TenLoaiCa.FieldName = "TenLoaiCa";
            this.TenLoaiCa.Name = "TenLoaiCa";
            this.TenLoaiCa.Visible = true;
            this.TenLoaiCa.VisibleIndex = 1;
            this.TenLoaiCa.Width = 72;
            // 
            // SoGio
            // 
            this.SoGio.Caption = "Số giờ";
            this.SoGio.FieldName = "SoGio";
            this.SoGio.Name = "SoGio";
            this.SoGio.Visible = true;
            this.SoGio.VisibleIndex = 2;
            this.SoGio.Width = 173;
            // 
            // HeSo
            // 
            this.HeSo.Caption = "Hệ số";
            this.HeSo.FieldName = "HeSo";
            this.HeSo.Name = "HeSo";
            this.HeSo.Visible = true;
            this.HeSo.VisibleIndex = 3;
            this.HeSo.Width = 160;
            // 
            // SoTien
            // 
            this.SoTien.Caption = "Số tiền";
            this.SoTien.FieldName = "SoTien";
            this.SoTien.Name = "SoTien";
            this.SoTien.Visible = true;
            this.SoTien.VisibleIndex = 4;
            this.SoTien.Width = 146;
            // 
            // GhiChu
            // 
            this.GhiChu.Caption = "Ghi chú";
            this.GhiChu.FieldName = "GhiChu";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 5;
            this.GhiChu.Width = 170;
            // 
            // create_date
            // 
            this.create_date.Caption = "Ngày tạo";
            this.create_date.FieldName = "create_date";
            this.create_date.Name = "create_date";
            this.create_date.Visible = true;
            this.create_date.VisibleIndex = 6;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.Caption = "gridColumn1";
            this.MaNhanVien.FieldName = "MaNhanVien";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // MaLoaiCa
            // 
            this.MaLoaiCa.Caption = "gridColumn1";
            this.MaLoaiCa.FieldName = "MaLoaiCa";
            this.MaLoaiCa.Name = "MaLoaiCa";
            // 
            // frmTangCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 397);
            this.Controls.Add(this.gcTangCa);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmTangCa";
            this.Text = "TangCa";
            this.Load += new System.EventHandler(this.TangCa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTangCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTangCa)).EndInit();
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
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.ComboBox cbSoGio;
        private System.Windows.Forms.ComboBox cbLoaiCa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SearchLookUpEdit scNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gcTangCa;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTangCa;
        private DevExpress.XtraGrid.Columns.GridColumn TenLoaiCa;
        private DevExpress.XtraGrid.Columns.GridColumn SoGio;
        private DevExpress.XtraGrid.Columns.GridColumn HeSo;
        private DevExpress.XtraGrid.Columns.GridColumn SoTien;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn MaNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn MaLoaiCa;
        private System.Windows.Forms.DateTimePicker cboTgian;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn create_date;
    }
}