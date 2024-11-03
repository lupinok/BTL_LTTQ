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
    public partial class frmPhuCap : DevExpress.XtraEditors.XtraForm
    {
        PhuCap_BUS phucapBus;
        NHANVIEN_BUS nhanvienBus;
        bool _them;
        string mapc;
        public frmPhuCap()
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
            cbLoaiPC.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            cbSoTien.Enabled = !kt;
            scNhanVien.Enabled = !kt;
            cbThang.Enabled = !kt;
            cbNam.Enabled = !kt;

        }
        void loadData()
        {
            gcPhuCap.DataSource = phucapBus.getList();
            gvPhuCap.OptionsBehavior.Editable = false;
            gvPhuCap.Columns["SoTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvPhuCap.Columns["SoTien"].DisplayFormat.FormatString = "N0";
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
        void loadLoaiPC()
        {
            // Tạo danh sách loại phụ cấp
            var listPC = new List<dynamic>()
            {
                new { MaPhuCap= "PC1", LoaiPhuCap = "Phụ cấp ăn trưa" },
                new { MaPhuCap = "PC2", LoaiPhuCap = "Phụ cấp xăng xe" },
                new { MaPhuCap = "PC3", LoaiPhuCap = "Phụ cấp chức vụ" },
                // Thêm các loại phụ cấp khác
            };

            cbLoaiPC.DataSource = listPC;
            cbLoaiPC.DisplayMember = "LoaiPhuCap";
            cbLoaiPC.ValueMember = "MaPhuCap";
            cbLoaiPC.SelectedIndex = -1; // Reset selection
        }
        private void frmPhuCap_Load(object sender, EventArgs e)
        {
            _them = false;
            phucapBus = new PhuCap_BUS();
            nhanvienBus = new NHANVIEN_BUS();
            _showHide(true);
            loadData();
            loadNhanVien();
            loadLoaiPC();
            
        }
        private void ResetValue()
        {
            scNhanVien.SelectionStart = -1;
            txtGhiChu.Text = "";
            cbLoaiPC.SelectedIndex = -1;
            cbNam.SelectedIndex = -1;
            cbSoTien.SelectedIndex = -1;
            cbThang.SelectedIndex = -1;

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
                    phucapBus.Delete(mapc);
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
        private void SaveData()
        {
            int maNV = Convert.ToInt32(scNhanVien.EditValue);
            string loai = cbLoaiPC.Text;
            string hoTen = scNhanVien.Text;
            decimal soTien = decimal.Parse(cbSoTien.Text.Replace(",", ""));
            int thang = Convert.ToInt32(cbThang.Text); // Lấy text thay vì SelectedValue
            int nam = Convert.ToInt32(cbNam.Text);
            if (_them)
            {
                if (phucapBus.KiemTraTrung(maNV, loai, thang, nam))
                {
                    throw new Exception($"Nhân viên {hoTen} đã được nhận {loai} trong tháng {thang}/{nam}!");
                }
                if (scNhanVien.EditValue == null)
                    throw new Exception("Vui lòng chọn nhân viên");
                if (cbSoTien.SelectedIndex == -1)
                    throw new Exception("Vui lòng chọn số tiền");
                if (cbLoaiPC.SelectedIndex == -1)
                    throw new Exception("Vui lòng chọn loại phụ cấp");

                var ac = new PhuCap
                {
                    MaPhuCap = "PC" + DateTime.Now.Ticks.ToString(),
                    MaNhanVien = maNV,
                    HoTen    = hoTen,
                    LoaiPhuCap = loai,
                    SoTien = soTien,
                    Thang = thang,
                    Nam = nam,
                    GhiChu = txtGhiChu.Text,
                    create_by = "admin",
                    create_date = DateTime.Now,
                    update_by = null,
                    update_date = null
                };
                phucapBus.Add(ac);
            }
            else
               if (scNhanVien.EditValue == null)
                throw new Exception("Vui lòng chọn nhân viên");
            if (cbSoTien.SelectedIndex == -1)
                throw new Exception("Vui lòng chọn số tiền");
            if (cbLoaiPC.SelectedIndex == -1)
                throw new Exception("Vui lòng chọn loại phụ cấp");

            var bc = phucapBus.getItem(mapc);
            if (bc!=null)
            
            {
                bc.MaNhanVien = maNV;
                bc.HoTen = hoTen;
                bc.LoaiPhuCap = loai;
                bc.SoTien = soTien;
                bc.Thang = thang;
                bc.Nam = nam;
                bc.GhiChu = txtGhiChu.Text;
                bc.create_by = "admin";
                bc.create_date = DateTime.Now;
                bc.update_by = null;
                bc.update_date = null;
                phucapBus.Update(bc);
            };
           

        }

        private void gvPhuCap_Click(object sender, EventArgs e)
        {
            _showHide(false);
            btnXem.Enabled = true;
            if (gvPhuCap.RowCount > 0)
            {
                mapc = gvPhuCap.GetFocusedRowCellValue("MaPhuCap").ToString();
                int maNV = Convert.ToInt32(gvPhuCap.GetFocusedRowCellValue("MaNhanVien"));
                string loaiPC = gvPhuCap.GetFocusedRowCellValue("LoaiPhuCap").ToString();
                string ghiChu = gvPhuCap.GetFocusedRowCellValue("GhiChu")?.ToString() ?? "";
                int thang = Convert.ToInt32(gvPhuCap.GetFocusedRowCellValue("Thang"));
                int nam = Convert.ToInt32(gvPhuCap.GetFocusedRowCellValue("Nam"));
                decimal soTien = Convert.ToDecimal(gvPhuCap.GetFocusedRowCellValue("SoTien"));

                // Hiển thị thông tin lên các control
                scNhanVien.EditValue = maNV;
                cbLoaiPC.Text = loaiPC;
                txtGhiChu.Text = ghiChu;
                cbThang.Text = thang.ToString();
                cbNam.Text = nam.ToString();
                cbSoTien.Text = soTien.ToString("N0");

                // Enable các nút chức năng phù hợp
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
        }
    }
}