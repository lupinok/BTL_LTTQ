using BUS_QLNS;
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

namespace GUI_QLNS.NhanVien.ChucVu
{
    public partial class frmChucVu : DevExpress.XtraEditors.XtraForm
    {
        ChucVu_BUS _chucVu;
        bool _them;
        int _machucvu;
        private bool _hasEditPermission;
        private LICHSU_BUS _lichsuBUS;
        private string _currentUser;

        public frmChucVu()
        {
            InitializeComponent();

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

            _chucVu = new ChucVu_BUS();
            _lichsuBUS = new LICHSU_BUS();
            _currentUser = Program.CurrentUser;
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            _them = false;
            _chucVu = new ChucVu_BUS();
            _showHide(true);
            loadData();
        }
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            // Chỉ enable các nút khi có quyền chỉnh sửa
            if (!_hasEditPermission)
            {
                btnThem.Enabled = false;
            }
            btnSua.Enabled = !kt;
            btnXoa.Enabled = !kt;
            txtLuongCV.Enabled = !kt;
            txtMaChucVu.Enabled = !kt;
            txtTenChucVu.Enabled = !kt;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _chucVu.GetList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void ResetValue()
        {
            txtLuongCV.Text = string.Empty;
            txtMaChucVu.Text = string.Empty;
            txtTenChucVu.Text = string.Empty;
        }
        private void SaveData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaChucVu.Text) || !int.TryParse(txtMaChucVu.Text, out int maChucVu))
                    throw new Exception("Mã chức vụ không hợp lệ");

                if (string.IsNullOrEmpty(txtTenChucVu.Text))
                    throw new Exception("Tên chức vụ không được để trống");

                decimal heSoLuong = 0;
                if (!string.IsNullOrEmpty(txtLuongCV.Text) && !decimal.TryParse(txtLuongCV.Text, out heSoLuong))
                    throw new Exception("Hệ số lương không hợp lệ");
                string tenChucVu = txtTenChucVu.Text.Trim();
                if (_them)
                {
                    // Kiểm tra mã chức vụ đã tồn tại chưa
                    var exists = _chucVu.GetItem(maChucVu);
                    if (exists != null)
                        throw new Exception("Mã chức vụ đã tồn tại!");

                    // Kiểm tra tên chức vụ đã tồn tại chưa
                    if (_chucVu.IsTenChucVuExists(tenChucVu))
                        throw new Exception("Tên chức vụ này đã tồn tại!");
                }

                if (_them)
                {
                    var cv = new DAL.ChucVu
                    {
                        MaChucVu = maChucVu,
                        TenChucVu = txtTenChucVu.Text.Trim(),
                        LuongChucVu = heSoLuong,
                    };
                    _chucVu.Add(cv);
                }
                else
                {
                    var cv = _chucVu.GetItem(_machucvu);
                    if (cv != null)
                    {
                        cv.MaChucVu = maChucVu;
                        cv.TenChucVu = txtTenChucVu.Text.Trim();
                        cv.LuongChucVu = heSoLuong;
                        _chucVu.Update(cv);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lưu chức vụ: " + ex.Message);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            ResetValue();
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
                        _chucVu.Delete(_machucvu);
                        loadData();
                        _lichsuBUS.ThemLichSu("Xóa chức vụ", _currentUser,
                            $"Xóa chức vụ {txtTenChucVu.Text}");
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _lichsuBUS.ThemLichSu("Lỗi", _currentUser,
                            $"Lỗi khi xóa chức vụ: {ex.Message}");
                    }
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SaveData();
                loadData();
                _them = false;
                _showHide(true);
                string action = _them ? "Thêm" : "Cập nhật";
                _lichsuBUS.ThemLichSu($"{action} chức vụ", _currentUser,
                    $"{action} chức vụ {txtTenChucVu.Text}");
                ResetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _lichsuBUS.ThemLichSu("Lỗi", _currentUser,
                    $"Lỗi khi thao tác với chức vụ: {ex.Message}");
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            _showHide(true);  // Hiện các nút chức năng
            if (gvDanhSach.RowCount > 0)
            {
                try
                {
                    // Lấy dữ liệu từ dòng được chọn
                    _machucvu = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaChucVu").ToString());
                    txtMaChucVu.Text = gvDanhSach.GetFocusedRowCellValue("MaChucVu").ToString();
                    txtTenChucVu.Text = gvDanhSach.GetFocusedRowCellValue("TenChucVu").ToString();
                    txtLuongCV.Text = gvDanhSach.GetFocusedRowCellValue("LuongChucVu")?.ToString() ?? "0";

                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
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
        }
    }
}