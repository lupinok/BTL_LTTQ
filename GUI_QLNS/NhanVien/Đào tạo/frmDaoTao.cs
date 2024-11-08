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
    public partial class frmDaoTao : DevExpress.XtraEditors.XtraForm
    {
        public frmDaoTao()
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
        DaoTao_BUS _daoTao;
        bool _them;
        int _maKhoaDaoTao;
        private bool _hasEditPermission;
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

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
            txtMaDaoTao.Enabled = !kt;
            txtTenDaoTao.Enabled = !kt;
            dtNgayBatDau.Enabled = !kt;
            dtNgayKetThuc.Enabled = !kt;
            txtChiPhi.Enabled = !kt;
            txtNoiDung.Enabled = !kt;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _daoTao.GetDaoTaoDetails();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void ResetValue()
        {
            txtMaDaoTao.Text = string.Empty;
            txtTenDaoTao.Text = string.Empty;
            dtNgayBatDau.EditValue = DateTime.Now;
            dtNgayKetThuc.EditValue = DateTime.Now.AddMonths(1);
            txtChiPhi.Text = "0";
            txtNoiDung.Text = string.Empty;
        }

        private void SaveData()
        {
            try
            {
                if (!int.TryParse(txtMaDaoTao.Text.Trim(), out int maKhoaDaoTao))
                    throw new Exception("Mã khóa đào tạo phải là số");

                if (maKhoaDaoTao <= 0)
                    throw new Exception("Mã khóa đào tạo phải lớn hơn 0");

                if (string.IsNullOrEmpty(txtTenDaoTao.Text))
                    throw new Exception("Tên khóa đào tạo không được để trống");

                if (!decimal.TryParse(txtChiPhi.Text, out decimal chiPhi))
                    throw new Exception("Chi phí phải là số");

                if (_them)
                {
                    var exists = _daoTao.GetItem(maKhoaDaoTao);
                    if (exists != null)
                        throw new Exception("Mã khóa đào tạo đã tồn tại!");
                }

                var dt = new DaoTao
                {
                    MaDaoTao = maKhoaDaoTao,
                    TenKhoa = txtTenDaoTao.Text.Trim(),
                    NgayBatDau = dtNgayBatDau.DateTime,
                    NgayKetThuc = dtNgayKetThuc.DateTime,
                    ChiPhi = chiPhi,
                    NoiDung = txtNoiDung.Text.Trim(),
                };

                if (_them)
                {
                    _daoTao.Add(dt);
                }
                else
                {
                    _daoTao.Update(dt);
                }

                _them = false;
                loadData();
                _showHide(true);
                MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmDaoTao_Load(object sender, EventArgs e)
        {
            _them = false;
            _daoTao = new DaoTao_BUS();
            _showHide(true);
            loadData();
            splitContainer1.Panel1Collapsed = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
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
                    _daoTao.Delete(_maKhoaDaoTao);
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

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                try
                {
                    _maKhoaDaoTao = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaDaoTao").ToString());
                    txtMaDaoTao.Text = gvDanhSach.GetFocusedRowCellValue("MaDaoTao").ToString();
                    txtTenDaoTao.Text = gvDanhSach.GetFocusedRowCellValue("TenKhoa").ToString();
                    dtNgayBatDau.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayBatDau");
                    dtNgayKetThuc.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayKetThuc");
                    txtChiPhi.Text = gvDanhSach.GetFocusedRowCellValue("ChiPhi").ToString();
                    txtNoiDung.Text = gvDanhSach.GetFocusedRowCellValue("NoiDung").ToString();

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

        

        private void gcDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maKhoaDaoTao = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaDaoTao").ToString());
                ChiTietDaoTao frm = new ChiTietDaoTao(_maKhoaDaoTao);
                frm.ShowDialog();
            }
        }
    }
}
