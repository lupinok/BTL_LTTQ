﻿using BUS_QLNS;
using DAL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNS.NhanVien.PhongBan
{
    public partial class frmPhongBan : DevExpress.XtraEditors.XtraForm
    {
        PhongBan_BUS _phongBan;
        bool _them;
        int _maphongban;
        private bool _hasEditPermission;
        private LICHSU_BUS _lichsuBUS;
        private string _currentUser;
        private string _selectedUser;
        private PHANQUYEN_BUS _phanQuyenBUS;
        private bool _isPhanQuyen = false;
        public frmPhongBan()
        {
            InitializeComponent();

            // Khởi tạo các đối tượng BUS
            _phongBan = new PhongBan_BUS();
            _lichsuBUS = new LICHSU_BUS();
            _phanQuyenBUS = new PHANQUYEN_BUS();
            _currentUser = Program.CurrentUser;

            // Kiểm tra vai trò
            string vaiTro = Properties.Settings.Default.VaiTro;
            _hasEditPermission = vaiTro != "Chỉnh sửa" && vaiTro != "Xem";

            // Ẩn các nút nếu không có quyền chỉnh sửa
            if (!_hasEditPermission)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
        }
        public frmPhongBan(string tenDangNhap = null)
        {
            InitializeComponent();
            _selectedUser = tenDangNhap;
            _phanQuyenBUS = new PHANQUYEN_BUS();
            _phongBan = new PhongBan_BUS();
            _lichsuBUS = new LICHSU_BUS();
            _currentUser = Program.CurrentUser;

            if (_selectedUser != null)
            {
                _isPhanQuyen = true;
                gvDanhSach.OptionsSelection.MultiSelect = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnHuy.Enabled = false;

                // Chỉ hiện nút Lưu để lưu phân quyền
                btnLuu.Enabled = true;
                btnLuu.Caption = "Lưu phân quyền";

                // Load các phòng ban đã được phân quyền
                loadData();
                var dsPhongBan = _phanQuyenBUS.GetPhongBanByTaiKhoan(_selectedUser);
                foreach (var maPhongBan in dsPhongBan)
                {
                    gvDanhSach.SelectRow(gvDanhSach.LocateByValue("MaPhongBan", maPhongBan));
                }
            }
        }
        void _showHide(bool kt)
        {
            // Chỉ thay đổi trạng thái nút Lưu khi không phải là phân quyền
            if (!_isPhanQuyen)
            {
                btnLuu.Enabled = !kt;
            }
            
            btnHuy.Enabled = !kt;
            
            // Chỉ enable các nút khi có quyền chỉnh sửa
            if (!_hasEditPermission)
            {
                btnThem.Enabled = false;
            }
            btnSua.Enabled = !kt;
            btnXoa.Enabled = !kt;
            txtMaPhongBan.Enabled = !kt;
            txtTenPhongBan.Enabled = !kt;
            cboTruongPhong.Enabled = !kt;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _phongBan.GetList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void ResetValue()
        {
            txtMaPhongBan.Text = string.Empty;
            txtTenPhongBan.Text = string.Empty;
            cboTruongPhong.Text = string.Empty;
        }
        private void SaveData()
        {
            try
            {
                if (!int.TryParse(txtMaPhongBan.Text.Trim(), out int maPhongBan))
                    throw new Exception("Mã phòng ban phải là số");

                if (maPhongBan <= 0)
                    throw new Exception("Mã phòng ban phải lớn hơn 0");

                if (string.IsNullOrEmpty(txtTenPhongBan.Text))
                    throw new Exception("Tên phòng ban không được để trống");

                if (_them)
                {
                    // Kiểm tra mã phòng ban đã tồn tại chưa
                    var exists = _phongBan.GetItem(maPhongBan);
                    if (exists != null)
                        throw new Exception("Mã phòng ban đã tồn tại!");
                }
                if (_them)
                {
                    var pb = new DAL.PhongBan
                    {
                        MaPhongBan = maPhongBan,
                        TenPhongBan = txtTenPhongBan.Text.Trim(),
                        TruongPhong = cboTruongPhong.Text.Trim(),
                    };
                    _phongBan.Add(pb);
                }
                else
                {
                    var pb = _phongBan.GetItem(_maphongban);
                    if (pb != null)
                    {
                        pb.MaPhongBan = maPhongBan;
                        pb.TenPhongBan = txtTenPhongBan.Text.Trim();
                        pb.TruongPhong = cboTruongPhong.Text.Trim();
                        _phongBan.Update(pb);
                    }
                }
                _them = false;
                loadData();
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTruongPhong()
        {
            cboTruongPhong.Properties.Items.Clear();

            // Thêm item "Chưa có trưởng phòng"
            cboTruongPhong.Properties.Items.Add("Chưa có trưởng phòng");

            // Thêm danh sách nhân viên chưa thuộc phòng ban nào
            cboTruongPhong.Properties.Items.AddRange(_phongBan.GetEmployeeNames().ToArray());

            // Nếu đang ở chế độ sửa, thêm tên trưởng phòng hiện tại vào danh sách (nếu có)
            if (!_them && _maphongban > 0)
            {
                string currentTruongPhong = _phongBan.GetCurrentTruongPhong(_maphongban);
                if (!string.IsNullOrEmpty(currentTruongPhong) &&
                    !cboTruongPhong.Properties.Items.Contains(currentTruongPhong))
                {
                    cboTruongPhong.Properties.Items.Add(currentTruongPhong);
                }
            }

            // Mặc định chọn "Chưa có trưởng phòng"
            cboTruongPhong.SelectedIndex = 0;
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            _them = false;
            _phongBan = new PhongBan_BUS();
            
            // Chỉ gọi _showHide khi không phải là phân quyền
            if (!_isPhanQuyen)
            {
                _showHide(true);
            }
            
            loadData();
            LoadTruongPhong();
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            ResetValue();
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try {
                        _phongBan.Delete(_maphongban);
                        loadData();
                        _lichsuBUS.ThemLichSu("Xóa phòng ban", _currentUser,
                            $"Xóa phòng ban {txtTenPhongBan.Text}");
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _lichsuBUS.ThemLichSu("Lỗi", _currentUser,
                            $"Lỗi khi xóa phòng ban: {ex.Message}");
                    }
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isPhanQuyen)
            {
                try
                {
                    var selectedRows = gvDanhSach.GetSelectedRows();
                    var dsPhongBan = selectedRows.Select(i =>
                        int.Parse(gvDanhSach.GetRowCellValue(i, "MaPhongBan").ToString())).ToList();
                    _phanQuyenBUS.PhanQuyen(_selectedUser, dsPhongBan);

                    MessageBox.Show("Phân quyền thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _lichsuBUS.ThemLichSu("Phân quyền", _currentUser,
                        $"Phân quyền phòng ban cho tài khoản {_selectedUser}");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi phân quyền: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    SaveData();
                    loadData();
                    _them = false;
                    _showHide(true);
                    string action = _them ? "Thêm" : "Cập nhật";
                    _lichsuBUS.ThemLichSu($"{action} phòng ban", _currentUser,
                        $"{action}  phòng ban {txtTenPhongBan.Text}");
                    ResetValue();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _lichsuBUS.ThemLichSu("Lỗi", _currentUser,
                        $"Lỗi khi thao tác với phòng ban: {ex.Message}");
                }
            }
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            _showHide(true);  // Hiện các nút chức năng
            if (gvDanhSach.RowCount > 0)
            {
                try
                {
                    // Lấy dữ liệu từ dòng được chọn
                    _maphongban = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaPhongBan").ToString());
                    txtMaPhongBan.Text = gvDanhSach.GetFocusedRowCellValue("MaPhongBan").ToString();
                    txtTenPhongBan.Text = gvDanhSach.GetFocusedRowCellValue("TenPhongBan").ToString();
                    cboTruongPhong.Text = gvDanhSach.GetFocusedRowCellValue("TruongPhong").ToString();
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    // Chỉ enable các nút khi có quyền chỉnh sửa
                    if (!_hasEditPermission)
                    {
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnThem.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load dữ liệu: " + ex.Message,
                                  "Lỗi",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            splitContainer1.Panel1Collapsed = false;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle >= 0)
            {
                int maPhongBan = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaPhongBan").ToString());
                // Kiểm tra quyền truy cập phòng ban
                var dsPhongBan = _phanQuyenBUS.GetPhongBanByTaiKhoan(Program.CurrentUser);
                if (Properties.Settings.Default.VaiTro == "Quản trị viên" ||
                    dsPhongBan.Contains(maPhongBan))
                {
                    frmNhanVien f = new frmNhanVien(maPhongBan);
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập phòng ban này!");
                }
            }

        }

        private void gvDanhSach_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                int maPhongBan = int.Parse(gvDanhSach.GetRowCellValue(e.RowHandle, "MaPhongBan").ToString());
                var dsPhongBan = _phanQuyenBUS.GetPhongBanByTaiKhoan(Program.CurrentUser);

                // Nếu không phải admin và không có quyền truy cập phòng ban này
                if (Properties.Settings.Default.VaiTro != "Quản trị viên" &&
                    !dsPhongBan.Contains(maPhongBan))
                {
                    e.Appearance.ForeColor = Color.Gray;
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
            if (e.RowHandle >= 0 && _isPhanQuyen)
            {
                int maPhongBan = int.Parse(gvDanhSach.GetRowCellValue(e.RowHandle, "MaPhongBan").ToString());
                var dsPhongBan = _phanQuyenBUS.GetPhongBanByTaiKhoan(_selectedUser);

                if (dsPhongBan.Contains(maPhongBan))
                {
                    e.Appearance.BackColor = Color.LightBlue;
                }
            }
        }
    }
}