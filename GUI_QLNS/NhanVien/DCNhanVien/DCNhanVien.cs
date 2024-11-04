using BUS_QLNS;
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

namespace GUI_QLNS.NhanVien.DCNhanVien
{
    public partial class DCNhanVien : DevExpress.XtraEditors.XtraForm
    {
        private NHANVIEN_BUS _nhanvienBUS;
        private DCNHANVIEN_BUS _dcnhanvienBUS;
        private LICHSU_BUS _lichsuBUS;
        private string _currentUser;
        private bool _isNewRecord = false;
        private bool _hasEditPermission;
        private int _sodc;

        public DCNhanVien()
        {
            InitializeComponent();
            _dcnhanvienBUS = new DCNHANVIEN_BUS();
            _lichsuBUS = new LICHSU_BUS();
            _currentUser = Program.CurrentUser;

            // Kiểm tra vai trò
            string vaiTro = Properties.Settings.Default.VaiTro;
            _hasEditPermission = vaiTro != "Xem" && vaiTro != "Chỉnh sửa";

            // Ẩn các nút nếu không có quyền chỉnh sửa
            if (!_hasEditPermission)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }

            LoadComboBoxes();
            LoadData();
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _isNewRecord = true;
            ShowHideControls(true);
            ClearFields();
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void cbHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cbHoTen.SelectedValue != null)
                {
                    if (cbHoTen.SelectedItem == null) return;

                    // Kiểm tra kiểu dữ liệu và chuyển đổi an toàn
                    var selectedNhanVien = cbHoTen.SelectedItem as DAL.NhanVien;
                    if (selectedNhanVien == null || !selectedNhanVien.MaPhongBan.HasValue) return;

                    // Load lại danh sách phòng ban, loại trừ phòng ban hiện tại
                    var listPhongBan = _dcnhanvienBUS.GetListPhongBanExcept(selectedNhanVien.MaPhongBan.Value);
                    if (listPhongBan != null)
                    {
                        cbTenPhongBan2.DataSource = new BindingSource(listPhongBan, null);
                        cbTenPhongBan2.DisplayMember = "TenPhongBan";
                        cbTenPhongBan2.ValueMember = "MaPhongBan";
                        cbTenPhongBan2.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load thông tin nhân viên: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ không?", "Thông báo",
        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _dcnhanvienBUS.DeleteAll();
                    LoadData();
                    MessageBox.Show("Đã xóa bảng điều chuyển!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _lichsuBUS.ThemLichSu("Xóa điều chuyển", _currentUser,
                        $"Xóa bảng điều chuyển nhân viên");
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _lichsuBUS.ThemLichSu("Lỗi", _currentUser,
                        $"Lỗi khi xóa điều chuyển: {ex.Message}");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cbHoTen.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbTenPhongBan2.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng ban muốn điều chuyển", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbMaChucVu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ mới", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dc = new DAL.NhanVien_DieuChuyen
                {
                    SoDC = _sodc,
                    MaNhanVien = Convert.ToInt32(cbHoTen.SelectedValue),
                    Ngay = DateTime.ParseExact(txtNgay.Text.Trim(), "dd/MM/yyyy", null),
                    MaPhongBan2 = Convert.ToInt32(cbTenPhongBan2.SelectedValue),
                    MaChucVu2 = Convert.ToInt32(cbMaChucVu.SelectedValue),
                    LyDoDC = txtLyDo.Text.Trim(),
                    GhiChuDC = txtGhiChu.Text.Trim()
                };

                if (_isNewRecord)
                    _dcnhanvienBUS.Add(dc);
                else
                    _dcnhanvienBUS.Update(dc);

                LoadData();
                ShowHideControls(false);
                MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                string action = _isNewRecord ? "Thêm" : "Cập nhật";
                _lichsuBUS.ThemLichSu($"{action} điều chuyển", _currentUser,
                    $"{action} điều chuyển nhân viên {cbHoTen.Text}");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _lichsuBUS.ThemLichSu("Lỗi", _currentUser,
                    $"Lỗi khi thao tác với điều chuyển: {ex.Message}");
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHideControls(false);
            ClearFields();
        }

        private void ShowHideControls(bool isEdit)
        {
            if (_hasEditPermission)
            {
                btnThem.Enabled = !isEdit;
                btnXoa.Enabled = !isEdit;
                btnLuu.Enabled = isEdit;
                btnHuy.Enabled = isEdit;

                cbHoTen.Enabled = isEdit;
                txtNgay.Enabled = isEdit;
                cbTenPhongBan2.Enabled = isEdit;
                cbMaChucVu.Enabled = false;
                txtLyDo.Enabled = isEdit;
                txtGhiChu.Enabled = isEdit;
            }
        }

        private void ClearFields()
        {
            cbHoTen.Text = string.Empty;
            txtNgay.Text = string.Empty;
            cbTenPhongBan2.Text = string.Empty;
            cbMaChucVu.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }

        private void LoadData()
        {
            gcDanhSach.DataSource = _dcnhanvienBUS.GetList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Clear data source cũ
                cbHoTen.DataSource = null;
                cbHoTen.Items.Clear();

                // Load danh sách nhân viên
                var listNhanVien = _dcnhanvienBUS.GetListNhanVien();

                if (listNhanVien != null && listNhanVien.Any())
                {
                    // Thiết lập lại DataSource
                    cbHoTen.DataSource = new BindingSource(listNhanVien, null);
                    cbHoTen.DisplayMember = "HoTen";
                    cbHoTen.ValueMember = "MaNhanVien";
                    cbHoTen.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nhân viên",
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _sodc = int.Parse(gvDanhSach.GetFocusedRowCellValue("SoDC").ToString());
                cbHoTen.Text = gvDanhSach.GetFocusedRowCellValue("HoTen").ToString();
                var ngay = gvDanhSach.GetFocusedRowCellValue("Ngay");
                txtNgay.Text = ngay != null ? Convert.ToDateTime(ngay).ToString("dd/MM/yyyy") : "";
                cbTenPhongBan2.Text = gvDanhSach.GetFocusedRowCellValue("TenPhongBan2").ToString();
                txtLyDo.Text = gvDanhSach.GetFocusedRowCellValue("LyDoDC").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GhiChuDC").ToString();

                if (_hasEditPermission)
                {
                    btnXoa.Enabled = true;
                }
            }
        }

        private void DCNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            ShowHideControls(false);
            btnLuu.Enabled = false;
        }

        private void cbTenPhongBan2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTenPhongBan2.SelectedValue != null)
                {
                    var maPhongBan = (cbTenPhongBan2.SelectedValue as int?) ?? 0;

                    // Load danh sách chức vụ theo phòng ban
                    var listChucVu = _dcnhanvienBUS.getListChucVuByPhongBan(maPhongBan);

                    cbMaChucVu.DataSource = new BindingSource(listChucVu, null);
                    cbMaChucVu.DisplayMember = "TenChucVu";
                    cbMaChucVu.ValueMember = "MaChucVu";
                    cbMaChucVu.SelectedIndex = -1;
                }
                else
                {
                    cbMaChucVu.DataSource = null;
                    cbMaChucVu.Items.Clear();
                }
                cbMaChucVu.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load chức vụ: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}