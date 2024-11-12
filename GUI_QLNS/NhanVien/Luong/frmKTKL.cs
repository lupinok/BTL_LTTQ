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
using BUS_QLNS;
using BusinessLayer;
using DAL;

namespace GUI_QLNS.NhanVien.Luong
{
    public partial class frmKTKL : DevExpress.XtraEditors.XtraForm
    {
        
        KTKL_BUS phucapBus;
        NHANVIEN_BUS nhanvienBus;
        bool _them;
        int manv;
        int mask;
        private bool _hasEditPermission;
        public frmKTKL()
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
            btnSua.Enabled = !kt;
            btnXoa.Enabled = !kt;
            cboNBD.Enabled = !kt;
            cboNKT.Enabled = !kt;
            txtTienPhat.Enabled = !kt;
            txtTienThuong.Enabled = !kt;
            scNhanVien.Enabled = !kt;
            cbLyDo.Enabled = !kt;
            cbSuKien.Enabled = !kt;
            cboNBD.Enabled = !kt;
            cboNKT.Enabled = !kt;
        }
        private void PhuCap_Load(object sender, EventArgs e)
        {
            _them = false;
            phucapBus = new KTKL_BUS();
            nhanvienBus = new NHANVIEN_BUS();
            
            _showHide(true);
            loadData();
            loadNhanVien();
            cbSuKien.SelectedIndexChanged += CbSuKien_SelectedIndexChanged;
        }
            private void CbSuKien_SelectedIndexChanged(object sender, EventArgs e)
            {

            if (cbSuKien.SelectedIndex != -1)
            {
                string loaiSK = cbSuKien.Text;
                var danhSachSK = phucapBus.getListSuKienTheoLoai(loaiSK);

                cbLyDo.DataSource = danhSachSK;
                cbLyDo.DisplayMember = "LyDo";
                cbLyDo.ValueMember = "MaSuKien";

                if (loaiSK == "Khen thưởng")
                {
                    txtTienPhat.Text = "0";
                    txtTienThuong.Text = "";
                }
                else
                {
                    txtTienThuong.Text = "0";
                    txtTienPhat.Text = "";
                }
            }
        }

        void loadData()
        {
            
            gcPhuCap.DataSource = phucapBus.getList();
            gvPhuCap.OptionsBehavior.Editable = false;
        }
        void loadNhanVien()
        {
            scNhanVien.Properties.DataSource = nhanvienBus.getList();
            scNhanVien.Properties.DisplayMember = "HoTen";
            scNhanVien.Properties.ValueMember = "MaNhanVien";
            searchLookUpEdit1View.Columns.Clear(); // Xóa tất cả cột hiện tại

            // Thêm cột Mã nhân viên
            searchLookUpEdit1View.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                Caption = "Mã NV",
                FieldName = "MaNhanVien",
                Visible = true,
                Width = 50
            });

            // Thêm cột Họ tên
            searchLookUpEdit1View.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                Caption = "Họ Tên",
                FieldName = "HoTen",
                Visible = true,
                Width = 200
            });
        }
        private void ResetValue()
        {
            scNhanVien.SelectionStart = 0;
            txtTienThuong.Text = "";
            txtTienPhat.Text = "";
            cbLyDo.SelectedIndex = -1;
            cbSuKien.SelectedIndex = -1;
            
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;  
            _showHide(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvPhuCap.RowCount > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    phucapBus.Delete(manv,mask);
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
            ResetValue();
        }
        private void SaveData()
        {
           
            if (_them)
            {
                if (scNhanVien.EditValue == null)
                    throw new Exception("Vui lòng chọn nhân viên");
                if (cbSuKien.SelectedIndex == -1)
                    throw new Exception("Vui lòng chọn loại sự kiện");
                if (cbLyDo.SelectedIndex == -1)
                    throw new Exception("Vui lòng chọn chi tiết sự kiện");
                if (txtTienThuong.Text == "" || txtTienPhat.Text == "")
                    throw new Exception("Vui lòng chọn số tiền");

                var ac = new ChiTietKT_KL
                {
                    MaNhanVien = int.Parse(scNhanVien.EditValue.ToString()),
                    MaSuKien = int.Parse(cbLyDo.SelectedValue.ToString()),
                    ChiTiet = cbLyDo.Text,
                    TienThuongPhat = cbSuKien.Text == "Khen thưởng"
                        ? decimal.Parse(txtTienThuong.Text.Replace(",", ""))  // Chuyển sang decimal
                        : decimal.Parse(txtTienPhat.Text.Replace(",", "")),
                    NgayBatDau = cboNBD.Value,     // Lấy giá trị từ DateTimePicker
                    NgayKetThuc = cboNKT.Value,
                    create_by = "",
                    create_date = DateTime.Now
                };
                phucapBus.Add(ac);
            }
            else
                if (scNhanVien.EditValue == null)
                throw new Exception("Vui lòng chọn nhân viên");
            if (cbSuKien.SelectedIndex == -1)
                throw new Exception("Vui lòng chọn loại sự kiện");
            if (cbLyDo.SelectedIndex == -1)
                throw new Exception("Vui lòng chọn chi tiết sự kiện");
            if (txtTienThuong.Text == "" || txtTienPhat.Text == "") 
                throw new Exception("Vui lòng chọn số tiền");

            var kc = phucapBus.getItem(manv, mask);
            if (kc != null)
            {
                kc.MaNhanVien = manv;
                kc.MaSuKien = mask;
                kc.ChiTiet = cbLyDo.Text;
                kc.TienThuongPhat = cbSuKien.Text == "Khen thưởng"
                    ? decimal.Parse(txtTienThuong.Text.Replace(",", ""))  // Chuyển sang decimal
                    : decimal.Parse(txtTienPhat.Text.Replace(",", ""));
                kc.NgayBatDau = cboNBD.Value;     // Lấy giá trị từ DateTimePicker
                kc.NgayKetThuc = cboNKT.Value;
                kc.update_by = "";
                kc.update_date = DateTime.Now;
                phucapBus.Update(kc);
            };

        }

        private void gvPhuCap_Click(object sender, EventArgs e)
        {
            _them = true;
            _showHide(false);
          
            if (gvPhuCap.RowCount > 0)
            {
                manv = int.Parse(gvPhuCap.GetFocusedRowCellValue("MaNhanVien").ToString());
                mask = int.Parse(gvPhuCap.GetFocusedRowCellValue("MaSuKien").ToString());

                // Load thông tin nhân viên vào SearchLookUpEdit
                scNhanVien.EditValue = manv;

                // Lấy thông tin sự kiện
                var suKien = phucapBus.getSuKien(mask);
                if (suKien != null)
                {
                    // Set loại sự kiện (Khen thưởng/Kỷ luật)
                    cbSuKien.Text = suKien.LoaiSuKien;

                    // Load danh sách chi tiết theo loại
                    var danhSachSK = phucapBus.getListSuKienTheoLoai(suKien.LoaiSuKien);
                    cbLyDo.DataSource = danhSachSK;
                    cbLyDo.DisplayMember = "ChiTiet";
                    cbLyDo.ValueMember = "MaSuKien";
                    cbLyDo.SelectedValue = mask;

                    // Lấy chi tiết khen thưởng/kỷ luật
                    var chiTiet = phucapBus.getLyDo(mask);
                    if (chiTiet != null)
                    {
                        // Set số tiền thưởng/phạt
                        if (suKien.LoaiSuKien == "Khen thưởng")
                        {
                            txtTienThuong.Text = chiTiet.TienThuongPhat.ToString();
                            txtTienPhat.Text = "0";
                            txtTienPhat.Enabled = false;
                            txtTienThuong.Enabled = true;
                            cboNBD.Value = chiTiet.NgayBatDau ?? DateTime.Now;
                            cboNKT.Value = chiTiet.NgayKetThuc ?? DateTime.Now;
                        }
                        else
                        {
                            txtTienPhat.Text = chiTiet.TienThuongPhat.ToString();
                            txtTienThuong.Text = "0";
                            txtTienThuong.Enabled = false;
                            txtTienPhat.Enabled = true;
                            cboNBD.Value = chiTiet.NgayBatDau ?? DateTime.Now;
                            cboNKT.Value = chiTiet.NgayKetThuc ?? DateTime.Now;
                        }
                    }
                    // Chỉ enable các nút khi có quyền chỉnh sửa
                    if (!_hasEditPermission)
                    {
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnThem.Enabled = false;
                    }
                }

                // Disable các control không được phép sửa khi xem chi tiết
                
            }
        }
    }
}