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
		private LICHSU_BUS _lichsuBUS;
		private string _currentUser;
		private bool _isNewRecord = false;

		public frmNhanVien()
		{
			InitializeComponent();
			_nhanvienBUS = new NHANVIEN_BUS();
			_lichsuBUS = new LICHSU_BUS();
			_currentUser = Program.CurrentUser;
		}

		private void NhanVien_Load(object sender, EventArgs e)
		{
			LoadData();
			LoadPhongBan();
			ShowHideControls(false);
		}

		void LoadData()
		{
			gcDanhSach.DataSource = _nhanvienBUS.getList();
			gvDanhSach.OptionsBehavior.Editable = false;
		}

		void LoadPhongBan()
		{
			// Load danh sách phòng ban vào cbMaPhongBan
			cbMaPhongBan.Properties.Items.Clear();
			var listPhongBan = _nhanvienBUS.getListPhongBan();
			foreach (var pb in listPhongBan)
			{
				cbMaPhongBan.Properties.Items.Add(pb.MaPhongBan);
			}
		}

		void LoadChucVu(int maPhongBan)
		{
			// Load danh sách chức vụ tương ứng với phòng ban
			cbMaChucVu.Properties.Items.Clear();
			var listChucVu = _nhanvienBUS.getListChucVuByPhongBan(maPhongBan);
			foreach (var cv in listChucVu)
			{
				cbMaChucVu.Properties.Items.Add(cv.MaChucVu);
			}
		}

		private void cbMaPhongBan_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (cbMaPhongBan.SelectedItem != null && !string.IsNullOrEmpty(cbMaPhongBan.SelectedItem.ToString()))
				{
					int maPhongBan;
					if (int.TryParse(cbMaPhongBan.SelectedItem.ToString(), out maPhongBan))
					{
						LoadChucVu(maPhongBan);
						cbMaChucVu.Enabled = true;
					}
					else
					{
						cbMaChucVu.Properties.Items.Clear();
						cbMaChucVu.Enabled = false;
					}
				}
				else
				{
					cbMaChucVu.Properties.Items.Clear();
					cbMaChucVu.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi chọn phòng ban: " + ex.Message);
				cbMaChucVu.Properties.Items.Clear();
				cbMaChucVu.Enabled = false;
			}
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
			cbMaPhongBan.Enabled = isEdit;
			cbMaChucVu.Enabled = false; // Mặc định disable cho đến khi chọn phòng ban
		}

		void ClearFields()
		{
			txtMaNhanVien.Text = string.Empty;
			txtHoTen.Text = string.Empty;
			txtNgaySinh.Text = string.Empty;
			txtSoDienThoai.Text = string.Empty;
			txtEmail.Text = string.Empty;
			cbMaPhongBan.Text = string.Empty;
			cbMaChucVu.Text = string.Empty;
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
					MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					_lichsuBUS.ThemLichSu("Xóa nhân viên", _currentUser,
						$"Xóa nhân viên {txtHoTen.Text}");
                    ClearFields();
                }
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					_lichsuBUS.ThemLichSu("Lỗi", _currentUser,
						$"Lỗi khi xóa nhân viên: {ex.Message}");
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
				string.IsNullOrEmpty(cbMaPhongBan.Text) ||
				string.IsNullOrEmpty(cbMaChucVu.Text))
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
					MaPhongBan = int.Parse(cbMaPhongBan.Text.Trim()),
					MaChucVu = int.Parse(cbMaChucVu.Text.Trim()),
				};

				if (_isNewRecord)
					_nhanvienBUS.Add(nv);
				else
					_nhanvienBUS.Update(nv);

				LoadData();
				ShowHideControls(false);
				MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				string action = _isNewRecord ? "Thêm" : "Cập nhật";
				_lichsuBUS.ThemLichSu($"{action} nhân viên", _currentUser,
					$"{action} thành công nhân viên {txtHoTen.Text}");
                ClearFields();
            }
			catch (Exception ex)
			{
				_lichsuBUS.ThemLichSu("Lỗi", _currentUser,
					$"Lỗi khi thao tác với nhân viên: {ex.Message}");
				throw;
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
				cbMaPhongBan.Text = gvDanhSach.GetFocusedRowCellValue("MaPhongBan").ToString();
				cbMaChucVu.Text = gvDanhSach.GetFocusedRowCellValue("MaChucVu").ToString();
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
					cbMaPhongBan.Text = gvDanhSach.GetFocusedRowCellValue("MaPhongBan").ToString();
					cbMaChucVu.Text = gvDanhSach.GetFocusedRowCellValue("MaChucVu").ToString();
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