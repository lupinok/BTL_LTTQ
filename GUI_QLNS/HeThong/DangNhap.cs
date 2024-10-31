using BUS_QLNS;
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

namespace GUI_QLNS.HeThong
{
	public partial class DangNhap : DevExpress.XtraEditors.XtraForm
	{
		TAIKHOAN_BUS _taikhoanBUS;
		public DangNhap()
		{
			InitializeComponent();
			_taikhoanBUS = new TAIKHOAN_BUS();
			// Thêm sự kiện click cho nút đăng nhập
			this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
		}

		private void DangNhapHeThong()
		{
			try
			{
				if (string.IsNullOrEmpty(txtTenDangNhap.Text))
				{
					MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtTenDangNhap.Focus();
					return;
				}

				if (string.IsNullOrEmpty(txtMatKhau.Text))
				{
					MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtMatKhau.Focus();
					return;
				}

				var taiKhoan = _taikhoanBUS.getItem(txtTenDangNhap.Text.Trim());

				if (taiKhoan != null && taiKhoan.MatKhau == txtMatKhau.Text.Trim())
				{
					if (taiKhoan.TrangThaiTaiKhoan != "Kích hoạt")
					{
						MessageBox.Show("Tài khoản đã bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					// Lưu thông tin đăng nhập
					Properties.Settings.Default.TenDangNhap = taiKhoan.TenDangNhap;
					Properties.Settings.Default.VaiTro = taiKhoan.VaiTro;
					Properties.Settings.Default.Save();

					Main mainForm = new Main();
					this.Hide();
					mainForm.ShowDialog();
					this.Close();
				}
				else
				{
					MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void DangNhap_Load(object sender, EventArgs e)
		{

		}

		private void btnDangNhap_Click(object sender, EventArgs e)
		{
			DangNhapHeThong();
		}

		private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				DangNhapHeThong();
			}
		}
	}
}