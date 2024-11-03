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
        public frmChucVu()
        {
            InitializeComponent();
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            _them = false;
            _chucVu = new ChucVu_BUS();
            _showHide(true);
            loadData();
            splitContainer1.Panel1Collapsed = true;
        }
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
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
                    _chucVu.Delete(_machucvu);
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
                    _machucvu = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaChucVu").ToString());
                    txtMaChucVu.Text = gvDanhSach.GetFocusedRowCellValue("MaChucVu").ToString();
                    txtTenChucVu.Text = gvDanhSach.GetFocusedRowCellValue("TenChucVu").ToString();
                    txtLuongCV.Text = gvDanhSach.GetFocusedRowCellValue("LuongChucVu")?.ToString() ?? "0";

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
            splitContainer1.Panel1Collapsed = false;
        }
    }
}