using BUS_QLNS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
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
    public partial class frmUngLuong : DevExpress.XtraEditors.XtraForm
    {
        UngLuong_BUS ungluongBus;
        NHANVIEN_BUS nhanvienBus;
       
        bool _them;
        string maul;
        private bool _hasEditPermission;
        public frmUngLuong()
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
            txtSoTien.Enabled = !kt;
            scNhanVien.Enabled = !kt;
            cbThang.Enabled = !kt;
            cbNam.Enabled = !kt;

        }
        void loadData()
        {

            gcUngLuong.DataSource = ungluongBus.getList();
            gvUngLuong.OptionsBehavior.Editable = false;





            // Format cột tiền tệ
            gvUngLuong.Columns["SoTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvUngLuong.Columns["SoTien"].DisplayFormat.FormatString = "N0";
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
            if (gvUngLuong.RowCount > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ungluongBus.Delete(maul);
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

        private void frmUngLuong_Load(object sender, EventArgs e)
        {
            _them = false;
            ungluongBus = new UngLuong_BUS();
            nhanvienBus = new NHANVIEN_BUS();
            _showHide(true);
            loadData();
            loadNhanVien();
        }
        private void ResetValue()
        {
            scNhanVien.SelectionStart = -1;
            txtGhiChu.Text = "";            
            cbNam.SelectedIndex = -1;
            txtSoTien.Text = "";
            cbThang.SelectedIndex = -1;

        }
        private void SaveData()
        {
            int maNV = Convert.ToInt32(scNhanVien.EditValue);    
            string hoTen = scNhanVien.Text;
            decimal soTien = decimal.Parse(txtSoTien.Text.Replace(",", ""));
            if (!ungluongBus.KiemTraTienUng(maNV, soTien / 2))
            {
                throw new Exception("Số tiền ứng không được vượt quá 50% lương cơ bản!");
            }
            int thang = Convert.ToInt32(cbThang.Text); // Lấy text thay vì SelectedValue
            int nam = Convert.ToInt32(cbNam.Text);
            if (_them)
            {
                
                if (ungluongBus.KiemTraTrung(maNV, thang, nam))
                {
                    throw new Exception($"Nhân viên {hoTen} đã ứng lương trong tháng {thang}/{nam}!");
                }
                if (scNhanVien.EditValue == null)
                    throw new Exception("Vui lòng chọn nhân viên");
                var ac = new UngLuong
                {
                    MaUngLuong = "UL" + DateTime.Now.Ticks.ToString(),
                    MaNhanVien = maNV,
                    HoTen = hoTen,
                    SoTien = soTien,
                    Thang = thang,
                    Nam = nam,
                    GhiChu = txtGhiChu.Text,
                    create_date = DateTime.Now,
                    update_by = null,
                   
                };
                ungluongBus.Add(ac);
            }
            else
               if (scNhanVien.EditValue == null)
                throw new Exception("Vui lòng chọn nhân viên");
            
            var bc = new UngLuong
            
            {
                MaNhanVien = maNV,
                HoTen = hoTen,             
                SoTien = soTien,
                Thang = thang,
                Nam = nam,
                GhiChu = txtGhiChu.Text,
                
                create_date = DateTime.Now,
                update_by = null
                
            };
            ungluongBus.Update(bc);

        }

        private void gvUngLuong_Click(object sender, EventArgs e)
        {
            _them = true;
            _showHide(false);
            
            if (gvUngLuong.RowCount > 0)
            {
                maul = gvUngLuong.GetFocusedRowCellValue("MaUngLuong").ToString();
                int maNV = Convert.ToInt32(gvUngLuong.GetFocusedRowCellValue("MaNhanVien"));
                string ghiChu = gvUngLuong.GetFocusedRowCellValue("GhiChu")?.ToString() ?? "";
                int thang = Convert.ToInt32(gvUngLuong.GetFocusedRowCellValue("Thang"));
                int nam = Convert.ToInt32(gvUngLuong.GetFocusedRowCellValue("Nam"));
                decimal soTien = Convert.ToDecimal(gvUngLuong.GetFocusedRowCellValue("SoTien"));

                // Hiển thị thông tin lên các control
                scNhanVien.EditValue = maNV;
                txtGhiChu.Text = ghiChu;
                cbThang.Text = thang.ToString();
                cbNam.Text = nam.ToString();
                txtSoTien.Text = soTien.ToString("N0");
                // Enable các nút chức năng phù hợp
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
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
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}