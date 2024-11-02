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

namespace GUI_QLNS.NhanVien.PhongBan
{
    public partial class frmPhongBan : DevExpress.XtraEditors.XtraForm
    {
        PhongBan_BUS _phongBan;
        bool _them;
        int _maphongban;
        public frmPhongBan()
        {
            InitializeComponent();
        }
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
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
            _showHide(true);
            loadData();
            LoadTruongPhong();
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
                    _phongBan.Delete(_maphongban);
                    loadData();
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
                ResetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _maphongban = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaPhongBan").ToString());
                    txtMaPhongBan.Text = gvDanhSach.GetFocusedRowCellValue("MaPhongBan").ToString();
                    txtTenPhongBan.Text = gvDanhSach.GetFocusedRowCellValue("TenPhongBan").ToString();
                    cboTruongPhong.Text = gvDanhSach.GetFocusedRowCellValue("TruongPhong").ToString();
                    // Enable nút Sửa và Xóa
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
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