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
    public partial class frmLoaiCa : DevExpress.XtraEditors.XtraForm
    {
        LOAICA_BUS _loaica;
        bool _them;
        int _id;

        public frmLoaiCa()
        {
            InitializeComponent();
            _them = false;
            _loaica = new LOAICA_BUS();
            _showHide(true);
            loadData();
        }

        private void frmLoaiCa_Load(object sender, EventArgs e)
        {
            _them = false;
            _loaica = new LOAICA_BUS();
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
            txtTenLoaiCa.Enabled = !kt;
            txtMaLoaiCa.Enabled = !kt;
            speHeSo.Enabled = !kt;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _loaica.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            txtTenLoaiCa.Text = string.Empty;
            speHeSo.EditValue = 1;
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
                string id = gvDanhSach.GetFocusedRowCellValue("MaLoaiCa").ToString();
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _loaica.Delete(id, "");
                    loadData();
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _them = false;
            _showHide(true);
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
                var newLoaiCa = new LoaiCa
                {
                    MaLoaiCa = txtMaLoaiCa.Text,
                    TenLoaiCa = txtTenLoaiCa.Text,
                    HeSo = (double)(decimal)speHeSo.EditValue,
                };
                _loaica.Add(newLoaiCa);
            }
            else
            {
                var existingLoaiCa = _loaica.getItem(txtMaLoaiCa.Text);
                if (existingLoaiCa != null)
                {
                    existingLoaiCa.TenLoaiCa = txtTenLoaiCa.Text;
                    existingLoaiCa.HeSo = (double)(decimal)speHeSo.EditValue;
                    _loaica.Update(existingLoaiCa);
                }
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                txtMaLoaiCa.Text = gvDanhSach.GetFocusedRowCellValue("MaLoaiCa").ToString();
                txtTenLoaiCa.Text = gvDanhSach.GetFocusedRowCellValue("TenLoaiCa").ToString();
                speHeSo.Text = gvDanhSach.GetFocusedRowCellValue("HeSo").ToString();
            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "delete_by" && e.CellValue != null)
            {
                Image img = Properties.Resources.ic_bhxh;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }
    }
}