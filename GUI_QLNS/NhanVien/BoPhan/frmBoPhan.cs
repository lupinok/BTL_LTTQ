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

namespace GUI_QLNS.NhanVien.BoPhan
{
    public partial class frmBoPhan : DevExpress.XtraEditors.XtraForm
    {
        BoPhan_BUS _boPhan;
        bool _them;
        int _mabophan;
        public frmBoPhan()
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
            txtMaBoPhan.Enabled = !kt;
            txtTenBoPhan.Enabled = !kt;
            cboMaPhongBan.Enabled = !kt;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _boPhan.GetList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void ResetValue()
        {
            txtMaBoPhan.Text = string.Empty;
            txtTenBoPhan.Text = string.Empty;
            cboMaPhongBan.Text = string.Empty;
        }
        private void SaveData()
        {
            try
            {
                if (!int.TryParse(txtMaBoPhan.Text.Trim(), out int maBoPhan))
                    throw new Exception("Mã bộ phận phải là số");

                if (maBoPhan <= 0)
                    throw new Exception("Mã bộ phận phải lớn hơn 0");

                if (string.IsNullOrEmpty(txtTenBoPhan.Text))
                    throw new Exception("Tên bộ phận không được để trống");
                if (string.IsNullOrEmpty(cboMaPhongBan.Text))
                    throw new Exception("Vui lòng chọn phòng ban");
                // Lấy mã phòng ban từ chuỗi đã chọn (ví dụ: "1 - Phòng Kế toán")
                string selectedValue = cboMaPhongBan.Text.Split('-')[0].Trim();
                if (!int.TryParse(selectedValue, out int maPhongBan))
                    throw new Exception("Mã phòng ban không hợp lệ");

                if (_them)
                {
                    // Kiểm tra mã bộ phận đã tồn tại chưa
                    var exists = _boPhan.GetItem(maBoPhan);
                    if (exists != null)
                        throw new Exception("Mã bộ phận đã tồn tại!");
                }
                if (_them)
                {
                    var bp = new DAL.BoPhan
                    {
                        MaBoPhan = maBoPhan,
                        TenBoPhan = txtTenBoPhan.Text.Trim(),
                        MaPhongBan = maPhongBan
                    };
                    _boPhan.Add(bp);
                }
                else
                {
                    var bp = _boPhan.GetItem(_mabophan);
                    if (bp != null)
                    {
                        bp.MaBoPhan = maBoPhan;
                        bp.TenBoPhan = txtTenBoPhan.Text.Trim();
                        bp.MaBoPhan = maBoPhan;
                        _boPhan.Update(bp);
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
        private void LoadBoPhan()
        {
            try
            {
                // Load danh sách phòng ban vào combobox
                var phongBan = new PhongBan_BUS();
                var list = phongBan.GetList();
                cboMaPhongBan.Properties.Items.Clear();

                // Thêm thông tin phòng ban vào combobox
                foreach (var item in list)
                {
                    // Hiển thị cả mã và tên phòng ban
                    string display = $"{item.MaPhongBan} - {item.TenPhongBan}";
                    cboMaPhongBan.Properties.Items.Add(display);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách phòng ban: " + ex.Message);
            }
        }
        private void frmBoPhan_Load(object sender, EventArgs e)
        {
            _them = false;
            _boPhan = new BoPhan_BUS();
            _showHide(true);
            loadData();
            LoadBoPhan();
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
                    _boPhan.Delete(_mabophan);
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
                    _mabophan = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaBoPhan").ToString());
                    txtTenBoPhan.Text = gvDanhSach.GetFocusedRowCellValue("TenBoPhan").ToString();
                    txtMaBoPhan.Text = gvDanhSach.GetFocusedRowCellValue("MaBoPhan").ToString();
                    cboMaPhongBan.Text = gvDanhSach.GetFocusedRowCellValue("MaPhongBan")?.ToString();

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