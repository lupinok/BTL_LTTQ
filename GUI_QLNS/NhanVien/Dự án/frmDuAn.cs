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

namespace GUI_QLNS.NhanVien.Dự_án
{
    public partial class frmDuAn : DevExpress.XtraEditors.XtraForm
    {
        DuAn_BUS _duAn;
        bool _them;
        int _maDuAn;
        private bool _hasEditPermission;
        public frmDuAn()
        {
            InitializeComponent();
            // Kiểm tra vai trò
            string vaiTro = Properties.Settings.Default.VaiTro;
            _hasEditPermission = vaiTro != "Chỉnh sửa";

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
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            // Chỉ enable các nút khi có quyền chỉnh sửa
            if (!_hasEditPermission)
            {
                btnThem.Enabled = false;
            }
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            txtMaDuAn.Enabled = !kt;
            txtTenDuAn.Enabled = !kt;
            dtNgayBatDau.Enabled = !kt;
            dtNgayKetThuc.Enabled = !kt;
            txtNganSach.Enabled = !kt;
            cboTrangThai.Enabled = !kt;
            txtMoTa.Enabled = !kt;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _duAn.GetProjectDetails().ToList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void ResetValue()
        {
            txtMaDuAn.Text = string.Empty;
            txtTenDuAn.Text = string.Empty;
            dtNgayBatDau.EditValue = DateTime.Now;
            dtNgayKetThuc.EditValue = DateTime.Now.AddMonths(1);
            txtNganSach.Text = "0";
            cboTrangThai.Text = "Chưa bắt đầu";
            txtMoTa.Text = string.Empty;
        }

        private void SaveData()
        {
            try
            {
                if (!int.TryParse(txtMaDuAn.Text.Trim(), out int maDuAn))
                    throw new Exception("Mã dự án phải là số");

                if (maDuAn <= 0)
                    throw new Exception("Mã dự án phải lớn hơn 0");

                if (string.IsNullOrEmpty(txtTenDuAn.Text))
                    throw new Exception("Tên dự án không được để trống");

                if (!decimal.TryParse(txtNganSach.Text, out decimal nganSach))
                    throw new Exception("Ngân sách phải là số");

                if (_them)
                {
                    var exists = _duAn.GetItem(maDuAn);
                    if (exists != null)
                        throw new Exception("Mã dự án đã tồn tại!");
                }

                var da = new DuAn
                {
                    MaDuAn = maDuAn,
                    TenDuAn = txtTenDuAn.Text.Trim(),
                    NgayBatDau = dtNgayBatDau.DateTime,
                    NgayKetThuc = dtNgayKetThuc.DateTime,
                    NganSach = nganSach,
                    TrangThai = cboTrangThai.Text,
                    MoTa = txtMoTa.Text
                };

                if (_them)
                {
                    _duAn.Add(da);
                }
                else
                {
                    _duAn.Update(da);
                }

                _them = false;
                loadData();
                _showHide(true);
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDuAn_Load(object sender, EventArgs e)
        {
            _them = false;
            _duAn = new DuAn_BUS();
            _showHide(true);
            loadData();
            cboTrangThai.Items.AddRange(new string[]
            {
                "Chưa bắt đầu",
                "Đang thực hiện",
                "Hoàn thành",
                "Tạm dừng",
                "Hủy bỏ"
            });
            splitContainer1.Panel1Collapsed = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                try
                {
                    _maDuAn = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaDuAn").ToString());
                    txtMaDuAn.Text = gvDanhSach.GetFocusedRowCellValue("MaDuAn").ToString();
                    txtTenDuAn.Text = gvDanhSach.GetFocusedRowCellValue("TenDuAn").ToString();
                    dtNgayBatDau.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayBatDau");
                    dtNgayKetThuc.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayKetThuc");
                    txtNganSach.Text = gvDanhSach.GetFocusedRowCellValue("NganSach").ToString();
                    cboTrangThai.Text = gvDanhSach.GetFocusedRowCellValue("TrangThai").ToString();
                    txtMoTa.Text = gvDanhSach.GetFocusedRowCellValue("MoTa").ToString();

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
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _duAn.Delete(_maDuAn);
                    loadData();
                }
            }
            splitContainer1.Panel1Collapsed = true;
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
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maDuAn = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaDuAn").ToString());
                ChiTietDuAn frm = new ChiTietDuAn(_maDuAn);
                frm.ShowDialog();
            }
        }
    }
}