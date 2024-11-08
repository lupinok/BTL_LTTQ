using BUS_QLNS;
using BusinessLayer;
using DAL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_QLNS.NhanVien.ChamCong
{
    public partial class frmBangCong : DevExpress.XtraEditors.XtraForm
    {
        KyCong_BUS _bangCong;
        bool _them;
        int _makycong;
        private Dictionary<int, frmBangCongChiTiet> _openDetailForms = new Dictionary<int, frmBangCongChiTiet>();
        private bool _hasEditPermission;

        public frmBangCong()
        {
            InitializeComponent();
            btnXem.Enabled = false;
            // Kiểm tra vai trò
            string vaiTro = Properties.Settings.Default.VaiTro;
            _hasEditPermission = vaiTro != "Chỉnh sửa";
        }

        private void frmBangCong_Load(object sender, EventArgs e)
        {
            _them = false;
            _bangCong = new KyCong_BUS();
            cboNam.Text = DateTime.Now.Year.ToString();
            cboThang.Text = DateTime.Now.Month.ToString();
            _showHide(true);
            loadData();
            btnXem.Enabled = false;
            splitContainer1.Panel1Collapsed = true;
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
            btnXem.Enabled = false;
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
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
            // Disable editing of certain fields if necessary
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                // Kiểm tra trạng thái khóa
                bool isKhoa = (bool)gvDanhSach.GetFocusedRowCellValue("KHOA");
                if (isKhoa)
                {
                    MessageBox.Show("Kỳ công đã bị khóa. Không thể xóa!", "Cảnh báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa kỳ công này không?\nDữ liệu chấm công của kỳ này cũng sẽ bị xóa!", 
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _bangCong.DeleteFullKyCong(_makycong);
                        loadData();
                        MessageBox.Show("Xóa kỳ công thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa kỳ công: " + ex.Message, "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

                    if (_openDetailForms.ContainsKey(_makycong))
                    {
                        _openDetailForms[_makycong].UpdateKhoaStatus();
                    }
                }
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0 && gvDanhSach.GetFocusedRowCellValue("MAKYCONG") != null)
            {
                _showHide(false);
                btnXem.Enabled = true;
                _makycong = int.Parse(gvDanhSach.GetFocusedRowCellValue("MAKYCONG").ToString());
                cboNam.Text = gvDanhSach.GetFocusedRowCellValue("NAM").ToString();
                cboThang.Text = gvDanhSach.GetFocusedRowCellValue("THANG").ToString();
                chkKhoa.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KHOA").ToString());
                chkTrangThai.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("TRANGTHAI").ToString());
                // Chỉ enable các nút khi có quyền chỉnh sửa
                if (!_hasEditPermission)
                {
                    btnXoa.Enabled = false;
                }
            }
            else
            {
                btnXem.Enabled = false;
            }
        }

        private void btnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangCongChiTiet frm = new frmBangCongChiTiet(this);
            frm._makycong = _makycong;
            frm._nam = int.Parse(cboNam.Text);
            frm._thang = int.Parse(cboThang.Text);
            
            // Theo dõi form chi tiết
            if (_openDetailForms.ContainsKey(_makycong))
            {
                _openDetailForms[_makycong].Close();
            }
            _openDetailForms[_makycong] = frm;

            // Đăng ký sự kiện form đóng để xóa khỏi dictionary
            frm.FormClosed += (s, args) => {
                _openDetailForms.Remove(_makycong);
            };
            
            frm.Show();
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnLoad(e);  // Gọi lại sự kiện Load của form
            loadData();
        }

        private void chkKhoa_CheckedChanged(object sender, EventArgs e)
        {
            if (_openDetailForms.ContainsKey(_makycong))
            {
                _openDetailForms[_makycong].UpdateKhoaStatus();
            }
        }

        public void UpdateKhoaStatus(int makycong, bool isKhoa)
        {
            if (_makycong == makycong)
            {
                chkKhoa.Checked = isKhoa;
                // Cập nhật database
                var kyCong = _bangCong.getItem(makycong);
                if (kyCong != null)
                {
                    kyCong.KHOA = isKhoa;
                    _bangCong.Update(kyCong);
                }
            }
        }
    }
}