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

namespace GUI_QLNS.NhanVien
{
	public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
	{
		private NHANVIEN_BUS _nhanvienBUS;
		private bool _isNewRecord = false;

		public frmNhanVien()
		{
			InitializeComponent();
			_nhanvienBUS = new NHANVIEN_BUS();
		}

		private void NhanVien_Load(object sender, EventArgs e)
		{
			LoadData();
			ShowHideControls(false);
		}

		void LoadData()
		{
			gcDanhSach.DataSource = _nhanvienBUS.getList();
			gvDanhSach.OptionsBehavior.Editable = false;
		}

		void ShowHideControls(bool isEdit)
		{
			btnThem.Enabled = !isEdit;
			btnSua.Enabled = !isEdit;
			btnXoa.Enabled = !isEdit;
			btnLuu.Enabled = isEdit;
			btnHuy.Enabled = isEdit;
			
			txtMaNhanVien.Enabled = isEdit && _isNewRecord;
			txtHoTen.Enabled = isEdit;
			txtNgaySinh.Enabled = isEdit;
			txtSoDienThoai.Enabled = isEdit;
			txtEmail.Enabled = isEdit;
			txtMaPhongBan.Enabled = isEdit;
			txtMaChucVu.Enabled = isEdit;
		}

		void ClearFields()
		{
			txtMaNhanVien.Text = string.Empty;
			txtHoTen.Text = string.Empty;
			txtNgaySinh.Text = string.Empty;
			txtSoDienThoai.Text = string.Empty;
			txtEmail.Text = string.Empty;
			txtMaPhongBan.Text = string.Empty;
			txtMaChucVu.Text = string.Empty;
		}

		private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_isNewRecord = true;
			ShowHideControls(true);
			ClearFields();

		}

		private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_isNewRecord = false;
			ShowHideControls(true);
			
			int manv = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaNhanVien").ToString());
			SYLL frm = new SYLL(manv, true);
			frm.ShowDialog();

			LoadData();
		}

		private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (string.IsNullOrEmpty(txtMaNhanVien.Text))
			{
				MessageBox.Show("Vui lòng chọn nhân viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				try
				{
					_nhanvienBUS.Delete(int.Parse(txtMaNhanVien.Text));
					LoadData();
					ClearFields();
					MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (string.IsNullOrEmpty(txtMaNhanVien.Text) || 
				string.IsNullOrEmpty(txtHoTen.Text) ||
				string.IsNullOrEmpty(txtNgaySinh.Text) ||
				string.IsNullOrEmpty(txtSoDienThoai.Text) ||
				string.IsNullOrEmpty(txtEmail.Text) ||
				string.IsNullOrEmpty(txtMaPhongBan.Text) ||
				string.IsNullOrEmpty(txtMaChucVu.Text))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				var nv = new DAL.NhanVien
				{
					MaNhanVien = int.Parse(txtMaNhanVien.Text.Trim()),
					HoTen = txtHoTen.Text.Trim(),
					NgaySinh = DateTime.ParseExact(txtNgaySinh.Text.Trim(), "dd/MM/yyyy", null),
					SoDienThoai = int.Parse(txtSoDienThoai.Text.Trim()),
					Email = txtEmail.Text.Trim(),
					MaPhongBan = int.Parse(txtMaPhongBan.Text.Trim()),
					MaChucVu = int.Parse(txtMaChucVu.Text.Trim()),
				};

				if (_isNewRecord)
					_nhanvienBUS.Add(nv);
				else
					_nhanvienBUS.Update(nv);

				LoadData();
				ShowHideControls(false);
				ClearFields();
				MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ShowHideControls(false);
			ClearFields();
		}

		private void gvDanhSach_Click(object sender, EventArgs e)
		{
			if (gvDanhSach.RowCount > 0)
			{
				txtMaNhanVien.Text = gvDanhSach.GetFocusedRowCellValue("MaNhanVien").ToString();
				txtHoTen.Text = gvDanhSach.GetFocusedRowCellValue("HoTen").ToString();
				var ngaySinh = gvDanhSach.GetFocusedRowCellValue("NgaySinh");
				txtNgaySinh.Text = ngaySinh != null ? Convert.ToDateTime(ngaySinh).ToString("dd/MM/yyyy") : "";
				txtSoDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("SoDienThoai").ToString();
				txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("Email").ToString();
				txtMaPhongBan.Text = gvDanhSach.GetFocusedRowCellValue("MaPhongBan").ToString();
				txtMaChucVu.Text = gvDanhSach.GetFocusedRowCellValue("MaChucVu").ToString();
			}
		}

		private void gcDanhSach_Click(object sender, EventArgs e)
		{

		}

		private void gvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if (e.FocusedRowHandle >= 0)
			{
				try
				{
					txtMaNhanVien.Text = gvDanhSach.GetFocusedRowCellValue("MaNhanVien").ToString();
					txtHoTen.Text = gvDanhSach.GetFocusedRowCellValue("HoTen").ToString();
					var ngaySinh = gvDanhSach.GetFocusedRowCellValue("NgaySinh");
					txtNgaySinh.Text = ngaySinh != null ? Convert.ToDateTime(ngaySinh).ToString("dd/MM/yyyy") : "";
					txtSoDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("SoDienThoai").ToString();
					txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("Email").ToString();
					txtMaPhongBan.Text = gvDanhSach.GetFocusedRowCellValue("MaPhongBan").ToString();
					txtMaChucVu.Text = gvDanhSach.GetFocusedRowCellValue("MaChucVu").ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
				}
			}
		}

		private void gvDanhSach_DoubleClick(object sender, EventArgs e)
		{
			if (gvDanhSach.FocusedRowHandle >= 0)
			{
				int manhanvien = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaNhanVien").ToString());
				SYLL f = new SYLL(manhanvien);
				f.ShowDialog();
			}
		}
	}
}