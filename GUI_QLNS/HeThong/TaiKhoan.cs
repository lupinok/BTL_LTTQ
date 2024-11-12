using BUS_QLNS;
using DevExpress.XtraEditors;
using GUI_QLNS.NhanVien.PhongBan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNS.HeThong
{
	public partial class frmTaiKhoan : DevExpress.XtraEditors.XtraForm
	{
		private TAIKHOAN_BUS _taikhoanBUS;
		private LICHSU_BUS _lichsuBUS;
		private bool _isNewRecord = false;
		private string _currentUser;
        private bool _isPhanQuyen = false;

        public frmTaiKhoan()
		{
			InitializeComponent();
			_taikhoanBUS = new TAIKHOAN_BUS();
			_lichsuBUS = new LICHSU_BUS();
			_currentUser = Program.CurrentUser;
		}
        public frmTaiKhoan(bool isPhanQuyen = false)
        {
            InitializeComponent();
            _taikhoanBUS = new TAIKHOAN_BUS();
            _lichsuBUS = new LICHSU_BUS();
            _currentUser = Program.CurrentUser;
            _isPhanQuyen = isPhanQuyen;

            // Nếu mở form để phân quyền, ẩn các nút chức năng
            if (_isPhanQuyen)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
            }
            
            LoadData();
            ShowHideControls(false);
            LoadComboBoxData();
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
		{
			LoadData();
			ShowHideControls(false);
			LoadComboBoxData();
			btnLuu.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;
		}

		void LoadData()
		{
			gcDanhSach.DataSource = _taikhoanBUS.getList();
			gvDanhSach.OptionsBehavior.Editable = false;
		}

		void LoadComboBoxData()
		{
			// Thiết lập các giá trị cho combobox Vai trò
			cbVaiTro.Properties.Items.Clear();
			cbVaiTro.Properties.Items.AddRange(new string[] { "Quản trị viên", "Chỉnh sửa"});
			cbVaiTro.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		}

		void ShowHideControls(bool isEdit)
		{
			btnThem.Enabled = !isEdit;
			btnSua.Enabled = !isEdit;
			btnXoa.Enabled = !isEdit;
			btnLuu.Enabled = isEdit;

			txtTenDangNhap.Enabled = isEdit && _isNewRecord;
			txtMatKhau.Enabled = isEdit;
			cbVaiTro.Enabled = isEdit;
		}

		void ClearFields()
		{
			txtTenDangNhap.Text = "";
			txtMatKhau.Text = "";
			cbVaiTro.EditValue = null;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;
		}

		private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ShowHideControls(true);
			_isNewRecord = true;
			ClearFields();
			txtTenDangNhap.Enabled = true;
		}

		private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ShowHideControls(true);
			_isNewRecord = false;
		}

		private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				try
				{
					var tendangnhap = gvDanhSach.GetFocusedRowCellValue("TenDangNhap").ToString();
					_taikhoanBUS.Delete(tendangnhap);
					LoadData();
					MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					_lichsuBUS.ThemLichSu("Xóa tài khoản", _currentUser,
						$"Xóa tài khoản {txtTenDangNhap.Text}");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (string.IsNullOrEmpty(txtTenDangNhap.Text) || 
				string.IsNullOrEmpty(txtMatKhau.Text) ||
				cbVaiTro.EditValue == null)
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Thêm kiểm tra độ dài mật khẩu
			if (txtMatKhau.Text.Trim().Length < 6)
			{
				MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				var tk = new DAL.TaiKhoan
				{
					TenDangNhap = txtTenDangNhap.Text.Trim(),
					MatKhau = txtMatKhau.Text.Trim(),
					VaiTro = cbVaiTro.EditValue.ToString()
				};

				if (_isNewRecord)
					_taikhoanBUS.Add(tk);
				else
					_taikhoanBUS.Update(tk);

				LoadData();
				ShowHideControls(false);
				MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

				string action = _isNewRecord ? "Thêm" : "Cập nhật";
				_lichsuBUS.ThemLichSu($"{action} tài khoản", _currentUser,
					$"{action} thành công tài khoản {txtTenDangNhap.Text}");
                ClearFields();
            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				_lichsuBUS.ThemLichSu("Lỗi", _currentUser,
					$"Lỗi khi thao tác với tài khoản: {ex.Message}");
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
				txtTenDangNhap.Text = gvDanhSach.GetFocusedRowCellValue("TenDangNhap").ToString();
				txtMatKhau.Text = gvDanhSach.GetFocusedRowCellValue("MatKhau").ToString();
				cbVaiTro.EditValue = gvDanhSach.GetFocusedRowCellValue("VaiTro").ToString();
				btnSua.Enabled = true;
				btnXoa.Enabled = true;
			}
		}

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (_isPhanQuyen && gvDanhSach.FocusedRowHandle >= 0)
            {
                string tenDangNhap = gvDanhSach.GetFocusedRowCellValue("TenDangNhap").ToString();
                frmPhongBan f = new frmPhongBan(tenDangNhap);
                f.ShowDialog();
            }
        }
    }
}