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

namespace GUI_QLNS.NhanVien.Đào_tạo
{
    public partial class ChiTietDaoTao : DevExpress.XtraEditors.XtraForm
    {
        ChiTietDaoTao_BUS _chiTietDT;
        bool _them;
        int _maKhoaDaoTao;
        int _maNhanVien;
        public ChiTietDaoTao()
        {
            InitializeComponent();
        }
        public ChiTietDaoTao(int maKhoaDaoTao)
        {
            InitializeComponent();
            _maKhoaDaoTao = maKhoaDaoTao;
            _chiTietDT = new ChiTietDaoTao_BUS();
        }
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            txtMaNhanVien.Enabled = !kt;
            txtTenNhanVien.Enabled = !kt;
            cboDanhGia.Enabled = !kt;
            txtThoiGian.Enabled = !kt;
            txtMaDaoTao.Enabled = false;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _chiTietDT.GetChiTietDaoTaoDetails(_maKhoaDaoTao);
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void loadCbDanhGia()
        {
            cboDanhGia.Items.Clear();
            foreach (var danhGia in _chiTietDT.GetDanhGiaList())
            {
                cboDanhGia.Items.Add(danhGia);
            }
        }
        

        private void ResetValue()
        {
            txtMaNhanVien.Text = string.Empty;
            txtTenNhanVien.Text = string.Empty;
            cboDanhGia.SelectedIndex = -1;
            txtThoiGian.Text = string.Empty;
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
                if (!int.TryParse(txtThoiGian.Text.Trim(), out int thoiGian))
                    throw new Exception("Thời gian phải là số");
                if (_them)
                {
                    var exists = _chiTietDT.GetItem(_maKhoaDaoTao, maNhanVien);
                    if (exists != null)
                        throw new Exception("Nhân viên này đã tham gia khóa đào tạo");
                }

                if (_them)
                {
                    var ctdt = new ChiTietKhoaDaoTao
                    {
                        MaDaoTao = _maKhoaDaoTao,
                        MaNhanVien = maNhanVien,
                        DanhGiaKhoa = cboDanhGia.Text.Trim(),
                        ThoiGianDuKien = thoiGian
                    };
                    _chiTietDT.Add(ctdt);
                }
                else
                {
                    var ctdt = _chiTietDT.GetItem(_maKhoaDaoTao, maNhanVien);
                    if (ctdt != null)
                    {
                        ctdt.DanhGiaKhoa = cboDanhGia.Text.Trim();
                        ctdt.ThoiGianDuKien = thoiGian;
                        _chiTietDT.Update(ctdt);
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


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChiTietDaoTao_Load(object sender, EventArgs e)
        {
            _them = false;
            _showHide(true);
            loadData();
            loadCbDanhGia();
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
            if (gvDanhSach.RowCount > 0 && _maNhanVien != 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _chiTietDT.Delete(_maKhoaDaoTao, _maNhanVien);
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
                    var ctdt = _chiTietDT.GetItem(_maKhoaDaoTao, _maNhanVien);
                    
                    if (ctdt != null)
                    {
                        txtMaNhanVien.Text = ctdt.MaNhanVien.ToString();
                        txtTenNhanVien.Text = gvDanhSach.GetFocusedRowCellValue("HoTen").ToString();
                        cboDanhGia.Text = ctdt.DanhGiaKhoa;
                        // Chuyển đổi int? sang string
                        txtThoiGian.Text = ctdt.ThoiGianDuKien?.ToString() ?? string.Empty;
                    }

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
            splitContainer1.Panel1Collapsed = false;
        }

        private void txtTenNhanVien_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                if (int.TryParse(txtMaNhanVien.Text.Trim(), out int maNV))
                {
                    var nhanVien = _chiTietDT.GetNhanVien(maNV);
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