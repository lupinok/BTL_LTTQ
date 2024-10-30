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

namespace GUI_QLNS.NhanVien.ChamCong
{
    public partial class frmLoaiCong : DevExpress.XtraEditors.XtraForm
    {
        LOAICONG_BUS _loaicong;
        bool _them;

        public frmLoaiCong()
        {
            InitializeComponent();
            _them = false;
            _loaicong = new LOAICONG_BUS();
            _showHide(true);
            loadData();
        }

        private void frmLoaiCong_Load(object sender, EventArgs e)
        {
            _them = false;
            _loaicong = new LOAICONG_BUS();
            _showHide(true);
            loadData();
        }

        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            txtTenLoaiCong.Enabled = !kt;
            txtMaLoaiCong.Enabled = !kt;
            speHeSo.Enabled = !kt;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _loaicong.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void ResetValue()
        {
            txtMaLoaiCong.Text = string.Empty;
            txtTenLoaiCong.Text = string.Empty;
            speHeSo.EditValue = 1;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            ResetValue();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
            txtMaLoaiCong.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                string id = gvDanhSach.GetFocusedRowCellValue("MaLoaiCong").ToString();
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _loaicong.Delete(id);
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
                var newLoaiCong = new LoaiCong
                {
                    MaLoaiCong = txtMaLoaiCong.Text,
                    TenLoaiCong = txtTenLoaiCong.Text,
                    HeSo = (double)(decimal)speHeSo.EditValue,
                };
                _loaicong.Add(newLoaiCong);
            }
            else
            {
                var existingLoaiCong = _loaicong.getItem(txtMaLoaiCong.Text);
                if (existingLoaiCong != null)
                {
                    existingLoaiCong.TenLoaiCong = txtTenLoaiCong.Text;
                    existingLoaiCong.HeSo = (double)(decimal)speHeSo.EditValue;
                    _loaicong.Update(existingLoaiCong);
                }
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                txtMaLoaiCong.Text = gvDanhSach.GetFocusedRowCellValue("MaLoaiCong").ToString();
                txtTenLoaiCong.Text = gvDanhSach.GetFocusedRowCellValue("TenLoaiCong").ToString();
                speHeSo.Text = gvDanhSach.GetFocusedRowCellValue("HeSo").ToString();
            }
        }
    }
}