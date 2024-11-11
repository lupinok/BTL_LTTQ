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
    public partial class ChiTietDuAn : DevExpress.XtraEditors.XtraForm
    {
        ChiTietDuAn_BUS _chiTietDA;
        bool _them;
        int _maDuAn;
        int _maNhanVien;
        private bool _hasEditPermission;
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public ChiTietDuAn(int maDuAn)
        {
            InitializeComponent();
            _maDuAn = maDuAn;
            _chiTietDA = new ChiTietDuAn_BUS();
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
            txtMaNhanVien.Enabled = !kt;
            txtTenNhanVien.Enabled = !kt; // Luôn readonly
            dtThoiHan.Enabled = !kt;
            txtDanhGia.Enabled = !kt;
            cboVaiTro.Enabled = !kt;
            txtMaDuAn.Enabled=false;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _chiTietDA.GetChiTietDuAnDetails(_maDuAn);
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void loadComboVaiTro()
        {
            cboVaiTro.Items.Clear();
            foreach (var vaiTro in _chiTietDA.GetVaiTroList())
            {
                cboVaiTro.Items.Add(vaiTro);
            }
        }

        private void ResetValue()
        {
            txtMaNhanVien.Text = string.Empty;
            txtTenNhanVien.Text = string.Empty;
            dtThoiHan.EditValue = DateTime.Now;
            txtDanhGia.Text = string.Empty;
            cboVaiTro.SelectedIndex = -1;
        }

        private void SaveData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaNhanVien.Text))
                    throw new Exception("Vui lòng nhập mã nhân viên");

                if (!int.TryParse(txtMaNhanVien.Text.Trim(), out int maNhanVien))
                    throw new Exception("Mã nhân viên phải là số");

                if (maNhanVien <= 0)
                    throw new Exception("Mã nhân viên phải lớn hơn 0");

                if (string.IsNullOrEmpty(cboVaiTro.Text))
                    throw new Exception("Vui lòng chọn vai trò");

                if (_them)
                {
                    // Kiểm tra nhân viên đã tồn tại trong dự án chưa
                    var exists = _chiTietDA.GetItem(_maDuAn, maNhanVien);
                    if (exists != null)
                        throw new Exception("Nhân viên này đã tham gia dự án");
                }

                if (_them)
                {
                    var ctda = new DAL.ChiTietDuAn
                    {
                        MaDuAn = _maDuAn,
                        MaNhanVien = maNhanVien,
                        ThoiHanDuAn = dtThoiHan.DateTime,
                        DanhGia = txtDanhGia.Text.Trim(),
                        VaiTro = cboVaiTro.Text.Trim()
                    };
                    _chiTietDA.Add(ctda);
                }
                else
                {
                    var ctda = _chiTietDA.GetItem(_maDuAn, maNhanVien);
                    if (ctda != null)
                    {
                        ctda.ThoiHanDuAn = dtThoiHan.DateTime;
                        ctda.DanhGia = txtDanhGia.Text.Trim();
                        ctda.VaiTro = cboVaiTro.Text.Trim();
                        _chiTietDA.Update(ctda);
                    }
                }

                _them = false;
                loadData();
                _showHide(true);
                ResetValue();
                MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ChiTietDuAn_Load(object sender, EventArgs e)
        {
            _them = false;
            _showHide(true);
            loadData();
            loadComboVaiTro();
            splitContainer1.Panel1Collapsed = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
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

            if (gvDanhSach.RowCount > 0 && _maNhanVien != 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _chiTietDA.Delete(_maDuAn, _maNhanVien);
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
            ResetValue();
            splitContainer1.Panel1Collapsed = true;
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                try
                {
                    _maNhanVien = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaNhanVien").ToString());
                    var ctda = _chiTietDA.GetItem(_maDuAn, _maNhanVien);

                    if (ctda != null)
                    {
                        txtMaNhanVien.Text = ctda.MaNhanVien.ToString();
                        txtTenNhanVien.Text = gvDanhSach.GetFocusedRowCellValue("HoTen").ToString();
                        dtThoiHan.EditValue = ctda.ThoiHanDuAn;
                        txtDanhGia.Text = ctda.DanhGia;
                        cboVaiTro.Text = ctda.VaiTro;
                    }

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

        private void txtTenNhanVien_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                if (int.TryParse(txtMaNhanVien.Text.Trim(), out int maNV))
                {
                    var nhanVien = _chiTietDA.GetNhanVien(maNV);
                    if (nhanVien != null)
                    {
                        txtTenNhanVien.Text = nhanVien.HoTen;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên với mã này!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaNhanVien.Focus();
                        txtTenNhanVien.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Mã nhân viên phải là số!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNhanVien.Focus();
                    txtTenNhanVien.Text = string.Empty;
                }
            }
            else
            {
                txtTenNhanVien.Text = string.Empty;
            }
        }
    }
}