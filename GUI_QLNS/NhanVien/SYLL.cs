using BUS_QLNS;
using DAL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNS.NhanVien
{
	public partial class SYLL : DevExpress.XtraEditors.XtraForm
	{
		private SYLL_BUS _syllBUS;
		private NHANVIEN_BUS _nhanvienBUS;
		private int _manhanvien;
		private bool _isEdit;
		private bool _isDataChanged = false;

		public SYLL(int manhanvien, bool isEdit = false)
		{
			InitializeComponent();
			_syllBUS = new SYLL_BUS();
			_nhanvienBUS = new NHANVIEN_BUS();
			_manhanvien = manhanvien;
			_isEdit = isEdit;
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
					Title = "Chọn hình ảnh"
				};

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string imagePath = openFileDialog.FileName;
					ptrHinhAnh.Image = Image.FromFile(imagePath);
					
					// Lưu đường dẫn hình ảnh vào CSDL
					var syll = new SoYeuLyLich
					{
						MaNhanVien = _manhanvien,
						HinhAnh = imagePath
					};
					_syllBUS.UpdateHinhAnh(syll);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi chọn hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SYLL_Load(object sender, EventArgs e)
		{
			LoadNhanVien();
			LoadData();
			SetReadOnly(!_isEdit);
			btnHinhAnh.Enabled = _isEdit;

			txtTrinhDoHocVan.EditValueChanged += TextEdit_EditValueChanged;
			txtKinhNghiem.EditValueChanged += TextEdit_EditValueChanged;
			txtKyNang.EditValueChanged += TextEdit_EditValueChanged;
			txtChungChi.EditValueChanged += TextEdit_EditValueChanged;
			txtNgoaiNgu.EditValueChanged += TextEdit_EditValueChanged;
			txtGioiTinh.EditValueChanged += TextEdit_EditValueChanged;
			txtQueQuan.EditValueChanged += TextEdit_EditValueChanged;
			txtGiaCanh.EditValueChanged += TextEdit_EditValueChanged;
			txtQuocTich.EditValueChanged += TextEdit_EditValueChanged;
		}

		private void TextEdit_EditValueChanged(object sender, EventArgs e)
		{
			if (_isEdit)
			{
				_isDataChanged = true;
			}
		}

		private void LoadNhanVien()
		{
			try
			{
				var nhanvien = _nhanvienBUS.getItem(_manhanvien);
				if (nhanvien != null)
				{
					txtHoTen.EditValue = nhanvien.HoTen;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi load thông tin nhân viên: " + ex.Message);
			}
		}

		private void SetReadOnly(bool isReadOnly)
		{
			txtTrinhDoHocVan.Properties.ReadOnly = isReadOnly;
			txtKinhNghiem.Properties.ReadOnly = isReadOnly;
			txtKyNang.Properties.ReadOnly = isReadOnly;
			txtChungChi.Properties.ReadOnly = isReadOnly;
			txtNgoaiNgu.Properties.ReadOnly = isReadOnly;
			txtNgayTao.Properties.ReadOnly = true;
			txtGioiTinh.Properties.ReadOnly = isReadOnly;
			txtQueQuan.Properties.ReadOnly = isReadOnly;
			txtGiaCanh.Properties.ReadOnly = isReadOnly;
			txtQuocTich.Properties.ReadOnly = isReadOnly;
			txtHoTen.Properties.ReadOnly = true;
			btnHinhAnh.Enabled = false;

			Color backColor = isReadOnly ? Color.WhiteSmoke : Color.White;
			txtTrinhDoHocVan.Properties.Appearance.BackColor = backColor;
			txtKinhNghiem.Properties.Appearance.BackColor = backColor;
			txtKyNang.Properties.Appearance.BackColor = backColor;
			txtChungChi.Properties.Appearance.BackColor = backColor;
			txtNgoaiNgu.Properties.Appearance.BackColor = backColor;
			txtNgayTao.Properties.Appearance.BackColor = Color.WhiteSmoke;
			txtGioiTinh.Properties.Appearance.BackColor = backColor;
			txtQueQuan.Properties.Appearance.BackColor = backColor;
			txtGiaCanh.Properties.Appearance.BackColor = backColor;
			txtQuocTich.Properties.Appearance.BackColor = backColor;
			txtHoTen.Properties.Appearance.BackColor = Color.WhiteSmoke;
		}

		void LoadData()
		{
			try
			{
				var syll = _syllBUS.getItem(_manhanvien);
				if (syll != null)
				{
					txtTrinhDoHocVan.EditValue = syll.TrinhDoHocVan;
					txtKinhNghiem.EditValue = syll.KinhNghiem;
					txtKyNang.EditValue = syll.KyNang;
					txtChungChi.EditValue = syll.ChungChi;
					txtNgoaiNgu.EditValue = syll.NgoaiNgu;
					txtNgayTao.EditValue = syll.NgayTao?.ToString("dd/MM/yyyy");
					txtGioiTinh.EditValue = syll.GioiTinh;
					txtQueQuan.EditValue = syll.QueQuan;
					txtGiaCanh.EditValue = syll.GiaCanh;
					txtQuocTich.EditValue = syll.QuocTich;

					// Load hình ảnh
					if (!string.IsNullOrEmpty(syll.HinhAnh) && File.Exists(syll.HinhAnh))
					{
						ptrHinhAnh.Image = Image.FromFile(syll.HinhAnh);
					}
					else
					{
						ptrHinhAnh.Image = null;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			try
			{
				if (_isDataChanged)
				{
					var syll = new SoYeuLyLich
					{
						MaNhanVien = _manhanvien,
						TrinhDoHocVan = txtTrinhDoHocVan.EditValue?.ToString(),
						KinhNghiem = txtKinhNghiem.EditValue?.ToString(),
						KyNang = txtKyNang.EditValue?.ToString(),
						ChungChi = txtChungChi.EditValue?.ToString(),
						NgoaiNgu = txtNgoaiNgu.EditValue?.ToString(),
						NgayTao = DateTime.Now,
						GioiTinh = txtGioiTinh.EditValue?.ToString(),
						QueQuan = txtQueQuan.EditValue?.ToString(),
						GiaCanh = txtGiaCanh.EditValue?.ToString(),
						QuocTich = txtQuocTich.EditValue?.ToString()
					};

					_syllBUS.Update(syll);
					MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

					_isEdit = false;
					_isDataChanged = false;
					btnLuu.Enabled = false;
					SetReadOnly(true);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Close();
		}

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _isEdit = true;
            SetReadOnly(false); // Cho phép nhập liệu
            btnLuu.Enabled = true;
            btnHinhAnh.Enabled = true;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_isDataChanged)
                {
                    var syll = new SoYeuLyLich
                    {
                        MaNhanVien = _manhanvien,
                        TrinhDoHocVan = txtTrinhDoHocVan.EditValue?.ToString(),
                        KinhNghiem = txtKinhNghiem.EditValue?.ToString(),
                        KyNang = txtKyNang.EditValue?.ToString(),
                        ChungChi = txtChungChi.EditValue?.ToString(),
                        NgoaiNgu = txtNgoaiNgu.EditValue?.ToString(),
                        NgayTao = DateTime.Now,
                        GioiTinh = txtGioiTinh.EditValue?.ToString(),
                        QueQuan = txtQueQuan.EditValue?.ToString(),
                        GiaCanh = txtGiaCanh.EditValue?.ToString(),
                        QuocTich = txtQuocTich.EditValue?.ToString()
                    };

                    _syllBUS.Update(syll);
                    MessageBox.Show("Lưu thông tin thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _isEdit = false;
                    _isDataChanged = false;
                    btnLuu.Enabled = false;
                    btnHinhAnh.Enabled = false;
                    SetReadOnly(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _isEdit = false;
            _isDataChanged = false;
            btnLuu.Enabled = false;
            btnHinhAnh.Enabled = false;
            SetReadOnly(true);
            LoadData(); // Load lại dữ liệu gốc
        }
    }
}