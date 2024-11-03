using BUS_QLNS;
using BusinessLayer;
using DAL;
using DevExpress.CodeParser;
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
    public partial class frmTangCa : DevExpress.XtraEditors.XtraForm
    {
        TangCa_BUS tangcaBus;
        NHANVIEN_BUS nhanvienBus;
        LOAICA_BUS loaicaBus;
        bool _them;
        int manv;
        string malc;
        public frmTangCa()
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
            cbLoaiCa.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            cbSoGio.Enabled = !kt;
            scNhanVien.Enabled = !kt;
            
        }
        void loadData()
        {

            gcTangCa.DataSource = tangcaBus.getList().Select(tc => new
            {
                tc.MaNhanVien,
                tc.MaLoaiCa,
                tc.HoTen,
                TenLoaiCa = loaicaBus.getTenLoaiCa(tc.MaLoaiCa), // Lấy tên loại ca khi hiển thị
                tc.SoGio,
                tc.HeSo,
                tc.SoTien,
                tc.GhiChu,
                tc.create_date
            }).ToList();

            gvTangCa.OptionsBehavior.Editable = false;
        }
        void loadLoaiCa()
        {
            cbLoaiCa.DataSource = loaicaBus.getList();
            cbLoaiCa.DisplayMember = "TenLoaiCa";
            cbLoaiCa.ValueMember = "MaLoaiCa";
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
            scNhanVien.SelectionStart = -1;
            txtGhiChu.Text = "";
            cbSoGio.SelectedIndex = -1;
            cbLoaiCa.SelectedIndex = -1;

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
            if (gvTangCa.RowCount > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tangcaBus.Delete(manv, malc);
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

        private void TangCa_Load(object sender, EventArgs e)
        {
            _them = false;
            tangcaBus = new TangCa_BUS();
            nhanvienBus = new NHANVIEN_BUS();
            loaicaBus = new LOAICA_BUS();

            _showHide(true);
            loadData();
            loadNhanVien();
            loadLoaiCa();
        }
        private void SaveData()
        {
            int maNV = Convert.ToInt32(scNhanVien.EditValue);
            string maLoaiCa = cbLoaiCa.SelectedValue.ToString();
            string hoTen = scNhanVien.Text;
            decimal soGio = Convert.ToDecimal(cbSoGio.Text);
            string tenLoaiCa = loaicaBus.getTenLoaiCa(maLoaiCa);
          

            double heSo = loaicaBus.getHeSo(maLoaiCa);

            // Tính số tiền
            decimal soTien = Convert.ToDecimal(soGio * (decimal)heSo * 200000);
            if (_them)
            {
                if (scNhanVien.EditValue == null)
                    throw new Exception("Vui lòng chọn nhân viên");
                if (cbLoaiCa.SelectedIndex == -1)
                    throw new Exception("Vui lòng chọn loại ca");
                if (cbSoGio.SelectedIndex == -1)
                    throw new Exception("Vui lòng chọn số giờ");

                var ac = new TangCa
                {
                    MaNhanVien = maNV,
                    MaLoaiCa = maLoaiCa,
                    HoTen = hoTen,
                    TenLoaiCa = tenLoaiCa,
                    SoGio = soGio,
                    HeSo = (decimal)heSo,
                    SoTien = soTien,
                    GhiChu = txtGhiChu.Text,
                    create_by = "",
                    create_date = cboTgian.Value
                };
                tangcaBus.Add(ac);
            }
            else
               if (scNhanVien.EditValue == null)
                throw new Exception("Vui lòng chọn nhân viên");
            if (cbLoaiCa.SelectedIndex == -1)
                throw new Exception("Vui lòng chọn loại ca");
            if (cbSoGio.SelectedIndex == -1)
                throw new Exception("Vui lòng chọn số giờ");

            var bc = tangcaBus.getItem(maNV, maLoaiCa);
            if (bc != null)
            {
                bc.MaNhanVien = maNV;
                bc.MaLoaiCa = maLoaiCa;
                bc.HoTen = hoTen;
                bc.TenLoaiCa = tenLoaiCa;
                bc.SoGio = soGio;
                bc.HeSo = (decimal)heSo;
                bc.SoTien = soTien;
                bc.GhiChu = txtGhiChu.Text;
                bc.create_by = "";
                bc.create_date = cboTgian.Value;
            };
            tangcaBus.Update(bc);

        }

        private void gvTangCa_Click(object sender, EventArgs e)
        {
            
            _showHide(false);
            btnXem.Enabled = true;
            if (gvTangCa.RowCount > 0)
            {
                manv = int.Parse(gvTangCa.GetFocusedRowCellValue("MaNhanVien").ToString());
                malc = (gvTangCa.GetFocusedRowCellValue("MaLoaiCa").ToString());

                // Load thông tin nhân viên vào SearchLookUpEdit
                
                scNhanVien.EditValue = manv;
                cbLoaiCa.SelectedValue = malc;
                txtGhiChu.Text = gvTangCa.GetFocusedRowCellValue("GhiChu").ToString();
                cbSoGio.Text = gvTangCa.GetFocusedRowCellValue("SoGio").ToString();

            }
        }

        private void cboNBD_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}