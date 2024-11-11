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

namespace GUI_QLNS.NhanVien.NhanVienThoiViec
{
    public partial class frmNVThoiViec : DevExpress.XtraEditors.XtraForm
    {
        NhanVienThoiViec_BUS _nvtv;
        NHANVIEN_BUS _nhanvien;
        PHANQUYEN_BUS _phanquyenBUS;
        string _currentUser;
        bool _them;
        string soQD;
        public frmNVThoiViec()
        {
            InitializeComponent();
            _nvtv = new NhanVienThoiViec_BUS();
            _nhanvien = new NHANVIEN_BUS();
            _phanquyenBUS = new PHANQUYEN_BUS();
            _currentUser = Program.CurrentUser;
        }

        private void frmNVThoiViec_Load(object sender, EventArgs e)
        {
            _nvtv = new NhanVienThoiViec_BUS();
            _nhanvien = new NHANVIEN_BUS();
            _them = false;
            _showHide(true);
            LoadNhanVien();
            LoadData();
            splitContainer1.Panel1Collapsed = true;
        }
        private void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = !kt;
            btnXoa.Enabled = !kt;
            dtNgayQD.Enabled = !kt;
            dtNgayTV.Enabled = !kt;
            txtSoQD.Enabled = false;
            txtLyDo.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            tlkNhanVien.Enabled = !kt;
        }

        private void ResetValue()
        {
            txtSoQD.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            dtNgayQD.EditValue = DateTime.Now;
            dtNgayTV.EditValue = DateTime.Now;
        }

        private void LoadNhanVien()
        {
            try
            {
                var dsNhanVien = new List<DAL.NhanVien>();
                
                // Nếu là admin thì lấy tất cả nhân viên
                if (Properties.Settings.Default.VaiTro == "Quản trị viên")
                {
                    dsNhanVien = _nhanvien.getList();
                }
                else
                {
                    // Lấy danh sách phòng ban được phân quyền
                    var dsPhongBan = _phanquyenBUS.GetPhongBanByTaiKhoan(_currentUser);
                    
                    // Lấy nhân viên thuộc các phòng ban được phân quyền
                    foreach (var maPhongBan in dsPhongBan)
                    {
                        var nhanVienPhongBan = _nhanvien.getListByPhongBan(maPhongBan);
                        dsNhanVien.AddRange(nhanVienPhongBan);
                    }
                }

                // Thiết lập dữ liệu cho TreeListLookUpEdit
                tlkNhanVien.Properties.DataSource = dsNhanVien;
                tlkNhanVien.Properties.DisplayMember = "HoTen";
                tlkNhanVien.Properties.ValueMember = "MaNhanVien";
                tlkNhanVien.Properties.NullText = "-- Chọn nhân viên --";

                // Cấu hình hiển thị các cột trong dropdown
                treeListLookUpEdit1TreeList.Columns.Clear();
                treeListLookUpEdit1TreeList.Columns.Add(new DevExpress.XtraTreeList.Columns.TreeListColumn
                {
                    Caption = "Mã NV",
                    FieldName = "MaNhanVien",
                    Visible = true,
                    Width = 80
                });
                treeListLookUpEdit1TreeList.Columns.Add(new DevExpress.XtraTreeList.Columns.TreeListColumn
                {
                    Caption = "Họ Tên",
                    FieldName = "HoTen", 
                    Visible = true,
                    Width = 200
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách nhân viên: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            gcDanhSach.DataSource = _nvtv.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void SaveData()
        {
            try
            {
                // Kiểm tra nhập liệu
                if (string.IsNullOrEmpty(txtLyDo.Text))
                {
                    MessageBox.Show("Vui lòng nhập lý do thôi việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLyDo.Focus();
                    return;
                }

                if (tlkNhanVien.EditValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tlkNhanVien.Focus();
                    return;
                }

                // Kiểm tra ngày
                if (dtNgayQD.DateTime > DateTime.Now)
                {
                    MessageBox.Show("Ngày quyết định không được lớn hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtNgayQD.Focus();
                    return;
                }

                if (dtNgayTV.DateTime < dtNgayQD.DateTime)
                {
                    MessageBox.Show("Ngày thôi việc không được nhỏ hơn ngày quyết định!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtNgayTV.Focus();
                    return;
                }
                if (_them)
                {

                    string maxSoQD = _nvtv.MaxSoQuyetDinh();
                    int so = int.Parse(maxSoQD) +1 ;
                    string soQDMoi = so.ToString("00000") + "/" + DateTime.Now.Year.ToString() + "/QDTV";

                    txtSoQD.Text = soQDMoi;

                    var tv = new DAL.NhanVienThoiViec
                    {
                        SoQD = soQDMoi,
                        NgayQuyetDinh = dtNgayQD.DateTime,
                        NgayThoiViec = dtNgayTV.DateTime,
                        MaNhanVien = int.Parse(tlkNhanVien.EditValue.ToString()),
                        LyDo = txtLyDo.Text.Trim(),
                        GhiChu = txtGhiChu.Text.Trim(),
                        CREATED_BY = 1,
                        CREATED_DATE = DateTime.Now
                    };
                    _nvtv.Add(tv);
                    MessageBox.Show("Thêm quyết định thôi việc thành công!", "Thông báo");
                }
                else
                {
                    var tv = _nvtv.getItem(soQD);
                    if (tv != null)
                    {
                        tv.NgayQuyetDinh = dtNgayQD.DateTime;
                        tv.NgayThoiViec = dtNgayTV.DateTime;
                        tv.MaNhanVien = int.Parse(tlkNhanVien.EditValue.ToString());
                        tv.LyDo = txtLyDo.Text.Trim();
                        tv.GhiChu = txtGhiChu.Text.Trim();
                        tv.UPDATED_BY = 1;
                        tv.UPDATED_DATE = DateTime.Now;
                        _nvtv.Update(tv);
                        MessageBox.Show("Cập nhật quyết định thôi việc thành công!", "Thông báo");
                    }
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            ResetValue();
            LoadNhanVien();
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
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nvtv.Delete(soQD, 1);
                LoadNhanVien();
                LoadData(); // Reload để cập nhật trạng thái DELETED
            }
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SaveData();
                LoadData();
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
                    soQD = gvDanhSach.GetFocusedRowCellValue("SoQD").ToString();
                    txtSoQD.Text = gvDanhSach.GetFocusedRowCellValue("SoQD").ToString();
                    dtNgayQD.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayQuyetDinh");
                    dtNgayTV.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayThoiViec");
                    tlkNhanVien.EditValue = gvDanhSach.GetFocusedRowCellValue("MaNhanVien");
                    txtLyDo.Text = gvDanhSach.GetFocusedRowCellValue("LyDo").ToString();
                    txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GhiChu").ToString();

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

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DELETED_BY" && e.CellValue != null)
            {
                Image img = Properties.Resources.delete;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }

    }
}