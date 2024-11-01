using BUS_QLNS;
using BusinessLayer;
using DAL;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace GUI_QLNS.NhanVien.ChamCong
{
    public partial class frmBangCong : DevExpress.XtraEditors.XtraForm
    {
        KyCong_BUS _bangCong;
        bool _them;
        int _makycong;
        public frmBangCong()
        {
            InitializeComponent();
            btnXem.Enabled = false;
        }

        private void frmBangCong_Load(object sender, EventArgs e)
        {
            _them = false;
            _bangCong = new KyCong_BUS();
            cboNam.Text = DateTime.Now.Year.ToString();
            cboThang.Text = DateTime.Now.Month.ToString();
            _showHide(true);
            loadData();
        }

        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = !kt;
            btnXoa.Enabled = !kt;
            cboNam.Enabled = !kt;
            cboThang.Enabled = !kt;
            chkKhoa.Enabled = !kt;
            chkTrangThai.Enabled = !kt;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _bangCong.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void ResetValue()
        {
            cboNam.SelectedIndex = -1;
            cboThang.SelectedIndex = -1;
            chkKhoa.Checked = false;
            chkTrangThai.Checked = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            cboNam.Text = DateTime.Now.Year.ToString();
            cboThang.Text = DateTime.Now.Month.ToString();
            chkKhoa.Checked = false;
            chkTrangThai .Checked = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
            // Disable editing of certain fields if necessary
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _bangCong.Delete(_makycong, "");
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
            if (_them)
            {
                var kc = new KYCONG
                {
                    MAKYCONG = int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text),
                    NAM = int.Parse(cboNam.Text),
                    THANG = int.Parse(cboThang.Text),
                    KHOA = chkKhoa.Checked,
                    TRANGTHAI = chkTrangThai.Checked,
                    NGAYCONGTRONGTHANG = SP_Functions.demSoNgayLamViecTrongThang(int.Parse(cboThang.Text), int.Parse(cboNam.Text)),
                    NGAYTINHCONG = DateTime.Now,
                    create_by = "",
                    create_date = DateTime.Now
                };
                _bangCong.Add(kc);
            }
            else
            {
                var kc = _bangCong.getItem(_makycong);
                if (kc != null)
                {
                    kc.MAKYCONG = int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text);
                    kc.NAM = int.Parse(cboNam.Text);
                    kc.THANG = int.Parse(cboThang.Text);
                    kc.KHOA = chkKhoa.Checked;
                    kc.TRANGTHAI = chkTrangThai.Checked;
                    kc.NGAYCONGTRONGTHANG = SP_Functions.demSoNgayLamViecTrongThang(int.Parse(cboThang.Text), int.Parse(cboNam.Text));
                    kc.NGAYTINHCONG = DateTime.Now;
                    kc.create_by = "";
                    kc.create_date = DateTime.Now;
                    _bangCong.Update(kc);
                }
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            _showHide(false);
            btnXem.Enabled = true;
            if (gvDanhSach.RowCount > 0)
            {
                _makycong = int.Parse(gvDanhSach.GetFocusedRowCellValue("MAKYCONG").ToString());
                cboNam.Text = gvDanhSach.GetFocusedRowCellValue("NAM").ToString();
                cboThang.Text = gvDanhSach.GetFocusedRowCellValue("THANG").ToString();
                chkKhoa.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KHOA").ToString());
                chkTrangThai.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("TRANGTHAI").ToString());
            }
        }

        private void btnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangCongChiTiet frm = new frmBangCongChiTiet();
            frm._makycong = _makycong;
            frm._nam = int.Parse(cboNam.Text);
            frm._thang = int.Parse(cboThang.Text);
            frm.ShowDialog();
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnLoad(e);  // Gọi lại sự kiện Load của form
            loadData();
        }
    }
}