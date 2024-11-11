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

namespace GUI_QLNS.NhanVien.Luong
{
    public partial class frmHDLD : DevExpress.XtraEditors.XtraForm
    {
        HDLD_BUS hdldBus;
        NHANVIEN_BUS nhanvienBus;
       
        int mahd;
        
        bool _them;
        private bool _hasEditPermission;
        public frmHDLD()
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
            txtGhiChu.Enabled = !kt;
            txtLuong.Enabled = !kt;
            scNhanVien.Enabled = !kt;
            txtSHD.Enabled = !kt;
            cbLoaiHD.Enabled = !kt;
            cbBaoHiem.Enabled = !kt;
            txtMD.Enabled = !kt;
            dateNBD.Enabled = !kt;
            dateNKT.Enabled = !kt;
        }
        void loadData()
        {
            gcHDLD.DataSource = hdldBus.getListFull();
            gvHDLD.OptionsBehavior.Editable = false;
            gvHDLD.Columns["LuongHopDong"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvHDLD.Columns["LuongHopDong"].DisplayFormat.FormatString = "N0";
            gvHDLD.Columns["MucDong"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvHDLD.Columns["MucDong"].DisplayFormat.FormatString = "N0";
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
        
        private void frmHDLD_Load(object sender, EventArgs e)
        {
            _them = false;
            hdldBus = new HDLD_BUS();
            nhanvienBus = new NHANVIEN_BUS();
            _showHide(true);
            loadData();
            loadNhanVien();
        }
        private void ResetValue()
        {
            txtSHD.Text = string.Empty;
            txtLuong.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtMD.Text = string.Empty;
            scNhanVien.EditValue = null;
            cbLoaiHD.SelectedIndex = -1;
            cbBaoHiem.SelectedIndex = -1;
            dateNBD.Value = DateTime.Now;
            dateNKT.Value = DateTime.Now;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _showHide(false);
            dateNBD.Value = DateTime.Now;
            dateNKT.Value = DateTime.Now;
            cbLoaiHD.SelectedIndex = 0;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            _them = false;
            _showHide(false);
            txtSHD.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                hdldBus.Delete(mahd);
                loadData();
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
        private void SaveData()
        {
            try
            {
                if (_them)
                {
                    // Kiểm tra dữ liệu đầu vào
                    if (string.IsNullOrEmpty(txtSHD.Text) || string.IsNullOrEmpty(txtLuong.Text) || 
                        scNhanVien.EditValue == null)
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!");
                        return;
                    }

                    // Kiểm tra trùng
                    int maNV = int.Parse(scNhanVien.EditValue.ToString());
                    int maHD = int.Parse(txtSHD.Text);
                    if (hdldBus.KiemTraTrung(maNV, maHD))
                    {
                        MessageBox.Show("Đã tồn tại hợp đồng này cho nhân viên!");
                        return;
                    }

                    // Tạo đối tượng hợp đồng mới
                    HopDongLaoDong hdld = new HopDongLaoDong
                    {
                        MaHopDong = maHD,
                        MaNhanVien = maNV,
                        LoaiHopDong = cbLoaiHD.Text,
                        NgayBatDau = dateNBD.Value,
                        NgayKetThuc = dateNKT.Value,
                        LuongHopDong = decimal.Parse(txtLuong.Text),
                        NoiDungHopDong = txtGhiChu.Text,
                        TenBaoHiem = cbBaoHiem.Text,
                        MucDong = decimal.Parse(txtMD.Text),
                        create_date = DateTime.Now
                    };

                    hdldBus.Add(hdld);
                }
                else
                {
                    // Kiểm tra dữ liệu đầu vào
                    if (string.IsNullOrEmpty(txtLuong.Text) || scNhanVien.EditValue == null)
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!");
                        return;
                    }

                    // Cập nhật hợp đồng
                    HopDongLaoDong hdld = new HopDongLaoDong
                    {
                        MaHopDong = mahd,
                        MaNhanVien = int.Parse(scNhanVien.EditValue.ToString()),
                        LoaiHopDong = cbLoaiHD.Text,
                        NgayBatDau = dateNBD.Value,
                        NgayKetThuc = dateNKT.Value,
                        LuongHopDong = decimal.Parse(txtLuong.Text),
                        NoiDungHopDong = txtGhiChu.Text,
                        TenBaoHiem = cbBaoHiem.Text,
                        MucDong = decimal.Parse(txtMD.Text),
                        update_by = DateTime.Now.ToString()
                    };

                    hdldBus.Update(hdld);
                }
                MessageBox.Show("Lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void gvHDLD_Click(object sender, EventArgs e)
        {
            try
            {
               
                _them = true;
                _showHide(false);
                if (gvHDLD.RowCount > 0)
                {
                    txtSHD.Enabled = false;
                    // Lấy mã hợp đồng từ dòng được chọn
                    mahd = int.Parse(gvHDLD.GetFocusedRowCellValue("MaHopDong").ToString());

                    // Load thông tin hợp đồng
                    txtSHD.Text = mahd.ToString();
                    txtLuong.Text = gvHDLD.GetFocusedRowCellValue("LuongHopDong").ToString();
                    txtGhiChu.Text = gvHDLD.GetFocusedRowCellValue("NoiDungHopDong")?.ToString();

                    // Load thông tin nhân viên
                    int maNV = int.Parse(gvHDLD.GetFocusedRowCellValue("MaNhanVien").ToString());
                    scNhanVien.EditValue = maNV;

                    // Load thông tin loại hợp đồng và ngày tháng
                    cbLoaiHD.Text = gvHDLD.GetFocusedRowCellValue("LoaiHopDong").ToString();

                    if (DateTime.TryParse(gvHDLD.GetFocusedRowCellValue("NgayBatDau").ToString(), out DateTime ngayBD))
                    {
                        dateNBD.Value = ngayBD;
                    }

                    if (DateTime.TryParse(gvHDLD.GetFocusedRowCellValue("NgayKetThuc").ToString(), out DateTime ngayKT))
                    {
                        dateNKT.Value = ngayKT;
                    }

                    // Load thông tin bảo hiểm
                    cbBaoHiem.Text = gvHDLD.GetFocusedRowCellValue("TenBaoHiem")?.ToString();
                    txtMD.Text = gvHDLD.GetFocusedRowCellValue("MucDong")?.ToString();
                    
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = true;
                    // Chỉ enable các nút khi có quyền chỉnh sửa
                    if (!_hasEditPermission)
                    {
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnThem.Enabled = false;
                    }
                }
                else
                {
                    ResetValue();
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}