﻿using DevExpress.XtraEditors;
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
        public frmKTKL()
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
            cboNBD.Enabled = !kt;
            cboNKT.Enabled = !kt;
            txtTienPhat.Enabled = !kt;
            txtTienThuong.Enabled = !kt;
            scNhanVien.Enabled = !kt;
            cbLyDo.Enabled = !kt;
            cbSuKien.Enabled = !kt;
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

                if (loaiSK == "Khen thu?ng")
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
            scNhanVien.SelectionStart = -1;
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

                var ac = new ChiTietKT_KL
                {
                    MaNhanVien = int.Parse(scNhanVien.EditValue.ToString()),
                    MaSuKien = int.Parse(cbLyDo.SelectedValue.ToString()),
                    ChiTiet = cbLyDo.Text,
                    TienThuongPhat = cbSuKien.Text == "Khen thu?ng"
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
            
            var kc = new ChiTietKT_KL
            {
                MaNhanVien = manv, // Sử dụng mã nhân viên hiện tại
                MaSuKien = mask,   // Sử dụng mã sự kiện hiện tại
                ChiTiet = cbLyDo.Text,
                TienThuongPhat = cbSuKien.Text == "Khen thu?ng"
                    ? decimal.Parse(txtTienThuong.Text.Replace(",", ""))  // Chuyển sang decimal
                    : decimal.Parse(txtTienPhat.Text.Replace(",", "")),
                NgayBatDau = cboNBD.Value,     // Lấy giá trị từ DateTimePicker
                NgayKetThuc = cboNKT.Value,
                update_by = "",
                update_date = DateTime.Now
            };
            phucapBus.Update(kc);

        }

        private void gvPhuCap_Click(object sender, EventArgs e)
        {
            _showHide(false);
            btnXem.Enabled = true;
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
                        if (suKien.LoaiSuKien == "Khen thu?ng")
                        {
                            txtTienThuong.Text = chiTiet.TienThuongPhat.ToString();
                            txtTienPhat.Text = "0";
                            txtTienPhat.Enabled = false;
                            txtTienThuong.Enabled = false;
                            cboNBD.Value = chiTiet.NgayBatDau ?? DateTime.Now;
                            cboNKT.Value = chiTiet.NgayKetThuc ?? DateTime.Now;
                        }
                        else
                        {
                            txtTienPhat.Text = chiTiet.TienThuongPhat.ToString();
                            txtTienThuong.Text = "0";
                            txtTienThuong.Enabled = false;
                            txtTienPhat.Enabled = false;
                            cboNBD.Value = chiTiet.NgayBatDau ?? DateTime.Now;
                            cboNKT.Value = chiTiet.NgayKetThuc ?? DateTime.Now;
                        }
                    }
                }

                // Disable các control không được phép sửa khi xem chi tiết
                scNhanVien.Enabled = false;
                cbSuKien.Enabled = false;
                cbLyDo.Enabled = false;
            }
        }
    }
}