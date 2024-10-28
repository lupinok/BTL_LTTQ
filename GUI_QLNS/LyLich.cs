using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL_QLNS;
using BUS_QLNS;

namespace GUI_QLNS
{
	public partial class LyLich : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
	{
		private SoYeuLiLich_DaoTao_BUS lylichBUS = new SoYeuLiLich_DaoTao_BUS();

		public LyLich()
		{
			InitializeComponent();
		}
		private void LyLich_Load(object sender, EventArgs e)
		{
			dgvSYLL.DataSource = lylichBUS.GetAllSoYeuLyLich();
			//dgvDaoTao.DataSource = lylichBUS.GetThongTinDaoTao();

			//// Đặt tên cột cho dgvDaoTao
			//dgvDaoTao.Columns["MaNhanVien"].HeaderText = "Mã NV";
			//dgvDaoTao.Columns["HoTen"].HeaderText = "Họ Tên";
			//dgvDaoTao.Columns["TenKhoa"].HeaderText = "Tên Khóa Đào Tạo";
			//dgvDaoTao.Columns["NoiDung"].HeaderText = "Nội Dung";
			//dgvDaoTao.Columns["ThoiGianDuKien"].HeaderText = "Thời Gian (Ngày)";
			//dgvDaoTao.Columns["DanhGiaKhoa"].HeaderText = "Đánh Giá";
			//dgvDaoTao.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
			//dgvDaoTao.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
		}

		private void dgvSYLL_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			try
			{
				// Lấy giá trị từ các TextBox
				string maNV = string.IsNullOrWhiteSpace(txtMaNV.Text) ? null : txtMaNV.Text.Trim();
				string trinhDoHV = string.IsNullOrWhiteSpace(txtTDHV.Text) ? null : txtTDHV.Text.Trim();
				string kinhNghiem = string.IsNullOrWhiteSpace(txtKNG.Text) ? null : txtKNG.Text.Trim();
				string kyNang = string.IsNullOrWhiteSpace(txtKN.Text) ? null : txtKN.Text.Trim();
				string chungChi = string.IsNullOrWhiteSpace(txtCC.Text) ? null : txtCC.Text.Trim();
				string ngoaiNgu = string.IsNullOrWhiteSpace(txtNN.Text) ? null : txtNN.Text.Trim();
				string ngayTao = string.IsNullOrWhiteSpace(txtNT.Text) ? null : txtNT.Text.Trim();
				string gioiTinh = string.IsNullOrWhiteSpace(txtGT.Text) ? null : txtGT.Text.Trim();
				string queQuan = string.IsNullOrWhiteSpace(txtQQ.Text) ? null : txtQQ.Text.Trim();
				string giaCanh = string.IsNullOrWhiteSpace(txtGC.Text) ? null : txtGC.Text.Trim();

				// Kiểm tra ít nhất một điều kiện tìm kiếm
				if (string.IsNullOrEmpty(maNV) && string.IsNullOrEmpty(trinhDoHV) &&
					string.IsNullOrEmpty(kinhNghiem) && string.IsNullOrEmpty(kyNang) &&
					string.IsNullOrEmpty(chungChi) && string.IsNullOrEmpty(ngoaiNgu) &&
					string.IsNullOrEmpty(ngayTao) && string.IsNullOrEmpty(gioiTinh) &&
					string.IsNullOrEmpty(queQuan) && string.IsNullOrEmpty(giaCanh))
				{
					MessageBox.Show("Vui lòng nhập ít nhất một điều kiện tìm kiếm!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				// Thực hiện tìm kiếm
				DataTable ketQua = lylichBUS.TimKiemSYLL(maNV, trinhDoHV, kinhNghiem, kyNang,
					chungChi, ngoaiNgu, ngayTao, gioiTinh, queQuan, giaCanh);

				// Hiển thị kết quả
				dgvSYLL.DataSource = ketQua;

				if (ketQua.Rows.Count == 0)
				{
					MessageBox.Show("Không tìm thấy kết quả nào!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show($"Tìm thấy {ketQua.Rows.Count} kết quả!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message,
					"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ResetValue()
		{
			txtMaNV.Clear();
			txtTDHV.Clear();
			txtKNG.Clear();
			txtKN.Clear();
			txtCC.Clear();
			txtNN.Clear();
			txtNT.Clear();
			txtGT.Clear();
			txtQQ.Clear();
			txtGC.Clear();

			// Reset trạng thái các nút
			btnThem.Enabled = true;
			btnSua.Enabled = true;
			btnXoa.Enabled = true;
			btnBoQua.Enabled = true;
			txtMaNV.Enabled = true;

			txtMaNV.Focus();
		}


		private void btnTimKiem_Click_1(object sender, EventArgs e)
		{
			try
			{
				// Lấy giá trị từ các TextBox
				string maNV = string.IsNullOrWhiteSpace(txtMaNV.Text) ? null : txtMaNV.Text.Trim();
				string trinhDoHV = string.IsNullOrWhiteSpace(txtTDHV.Text) ? null : txtTDHV.Text.Trim();
				string kinhNghiem = string.IsNullOrWhiteSpace(txtKNG.Text) ? null : txtKNG.Text.Trim();
				string kyNang = string.IsNullOrWhiteSpace(txtKN.Text) ? null : txtKN.Text.Trim();
				string chungChi = string.IsNullOrWhiteSpace(txtCC.Text) ? null : txtCC.Text.Trim();
				string ngoaiNgu = string.IsNullOrWhiteSpace(txtNN.Text) ? null : txtNN.Text.Trim();
				string ngayTao = string.IsNullOrWhiteSpace(txtNT.Text) ? null : txtNT.Text.Trim();
				string gioiTinh = string.IsNullOrWhiteSpace(txtGT.Text) ? null : txtGT.Text.Trim();
				string queQuan = string.IsNullOrWhiteSpace(txtQQ.Text) ? null : txtQQ.Text.Trim();
				string giaCanh = string.IsNullOrWhiteSpace(txtGC.Text) ? null : txtGC.Text.Trim();

				// Kiểm tra ít nhất một điều kiện tìm kiếm
				if (string.IsNullOrEmpty(maNV) && string.IsNullOrEmpty(trinhDoHV) &&
					string.IsNullOrEmpty(kinhNghiem) && string.IsNullOrEmpty(kyNang) &&
					string.IsNullOrEmpty(chungChi) && string.IsNullOrEmpty(ngoaiNgu) &&
					string.IsNullOrEmpty(ngayTao) && string.IsNullOrEmpty(gioiTinh) &&
					string.IsNullOrEmpty(queQuan) && string.IsNullOrEmpty(giaCanh))
				{
					MessageBox.Show("Vui lòng nhập ít nhất một điều kiện tìm kiếm!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				// Thực hiện tìm kiếm
				DataTable ketQua = lylichBUS.TimKiemSYLL(maNV, trinhDoHV, kinhNghiem, kyNang,
					chungChi, ngoaiNgu, ngayTao, gioiTinh, queQuan, giaCanh);

				// Hiển thị kết quả
				dgvSYLL.DataSource = ketQua;

				if (ketQua.Rows.Count == 0)
				{
					MessageBox.Show("Không tìm thấy kết quả nào!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show($"Tìm thấy {ketQua.Rows.Count} kết quả!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message,
					"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			try
			{
				// Kiểm tra dữ liệu đầu vào
				if (string.IsNullOrWhiteSpace(txtMaNV.Text))
				{
					MessageBox.Show("Vui lòng nhập mã nhân viên!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Chuyển đổi mã nhân viên
				if (!int.TryParse(txtMaNV.Text, out int maNV))
				{
					MessageBox.Show("Mã nhân viên phải là số!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Chuyển đổi ngày tạo
				DateTime ngayTao;
				if (string.IsNullOrWhiteSpace(txtNT.Text))
				{
					ngayTao = DateTime.Now; // Nếu không nhập thì lấy ngày hiện tại
				}
				else if (!DateTime.TryParseExact(txtNT.Text.Trim(),
					new[] { "dd/MM/yyyy", "d/M/yyyy" }, // Các định dạng chấp nhận
					System.Globalization.CultureInfo.InvariantCulture,
					System.Globalization.DateTimeStyles.None,
					out ngayTao))
				{
					MessageBox.Show("Ngày tạo không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				string trinhDoHV = txtTDHV.Text.Trim();
				string kinhNghiem = txtKNG.Text.Trim();
				string kyNang = txtKN.Text.Trim();
				string chungChi = txtCC.Text.Trim();
				string ngoaiNgu = txtNN.Text.Trim();
				string gioiTinh = txtGT.Text.Trim();
				string queQuan = txtQQ.Text.Trim();
				string giaCanh = txtGC.Text.Trim();

				// Thực hiện thêm mới
				bool ketQua = lylichBUS.InsertSoYeuLyLich(maNV, trinhDoHV, kinhNghiem,
					kyNang, chungChi, ngoaiNgu, ngayTao, gioiTinh, queQuan, giaCanh);

				if (ketQua)
				{
					MessageBox.Show("Thêm mới thành công!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					ResetValue();
					dgvSYLL.DataSource = lylichBUS.GetAllSoYeuLyLich();
				}
				else
				{
					MessageBox.Show("Thêm mới thất bại!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message,
					"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			try
			{
				// ... các kiểm tra khác ...

				// Chuyển đổi ngày tạo
				DateTime ngayTao;
				if (string.IsNullOrWhiteSpace(txtNT.Text))
				{
					ngayTao = DateTime.Now;
				}
				else if (!DateTime.TryParseExact(txtNT.Text.Trim(),
					new[] { "dd/MM/yyyy", "d/M/yyyy" },
					System.Globalization.CultureInfo.InvariantCulture,
					System.Globalization.DateTimeStyles.None,
					out ngayTao))
				{
					MessageBox.Show("Ngày tạo không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// ... code tiếp theo ...
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message,
					"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgvSYLL_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dgvSYLL.Rows[e.RowIndex];
				txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
				txtTDHV.Text = row.Cells["TrinhDoHocVan"].Value.ToString();
				txtKNG.Text = row.Cells["KinhNghiem"].Value.ToString();
				txtKN.Text = row.Cells["KyNang"].Value.ToString();
				txtCC.Text = row.Cells["ChungChi"].Value.ToString();
				txtNN.Text = row.Cells["NgoaiNgu"].Value.ToString();

				// Định dạng ngày tạo khi hiển thị
				if (row.Cells["NgayTao"].Value != null && row.Cells["NgayTao"].Value != DBNull.Value)
				{
					DateTime ngayTao = Convert.ToDateTime(row.Cells["NgayTao"].Value);
					txtNT.Text = ngayTao.ToString("dd/MM/yyyy");
				}

				txtGT.Text = row.Cells["GioiTinh"].Value.ToString();
				txtQQ.Text = row.Cells["QueQuan"].Value.ToString();
				txtGC.Text = row.Cells["GiaCanh"].Value.ToString();
			}
		}

		private void btnSua_Click_1(object sender, EventArgs e)
		{
			try
			{
				if (dgvSYLL.CurrentRow == null)
				{
					MessageBox.Show("Vui lòng chọn một dòng để sửa!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if (!int.TryParse(txtMaNV.Text, out int maNV))
				{
					MessageBox.Show("Mã nhân viên không hợp lệ!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				string trinhDoHV = txtTDHV.Text.Trim();
				string kinhNghiem = txtKNG.Text.Trim();
				string kyNang = txtKN.Text.Trim();
				string chungChi = txtCC.Text.Trim();
				string ngoaiNgu = txtNN.Text.Trim();

				string gioiTinh = txtGT.Text.Trim();
				string queQuan = txtQQ.Text.Trim();
				string giaCanh = txtGC.Text.Trim();
				DateTime ngayTao;
				if (string.IsNullOrWhiteSpace(txtNT.Text))
				{
					ngayTao = DateTime.Now;
				}
				else if (!DateTime.TryParseExact(txtNT.Text.Trim(),
					new[] { "dd/MM/yyyy", "d/M/yyyy" },
					System.Globalization.CultureInfo.InvariantCulture,
					System.Globalization.DateTimeStyles.None,
					out ngayTao))
				{
					MessageBox.Show("Ngày tạo không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				// Xác nhận trước khi sửa
				DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin này?",
					"Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes)
				{
					bool ketQua = lylichBUS.UpdateSoYeuLyLich(maNV, trinhDoHV, kinhNghiem,
						kyNang, chungChi, ngoaiNgu, ngayTao, gioiTinh, queQuan, giaCanh);

					if (ketQua)
					{
						MessageBox.Show("Cập nhật thành công!",
							"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ResetValue();
						dgvSYLL.DataSource = lylichBUS.GetAllSoYeuLyLich();
					}
					else
					{
						MessageBox.Show("Cập nhật thất bại!",
							"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message,
					"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			try
			{
				if (dgvSYLL.CurrentRow == null)
				{
					MessageBox.Show("Vui lòng chọn một dòng để xóa!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if (!int.TryParse(txtMaNV.Text, out int maNV))
				{
					MessageBox.Show("Mã nhân viên không hợp lệ!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Xác nhận trước khi xóa
				DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này?",
					"Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes)
				{
					bool ketQua = lylichBUS.DeleteSoYeuLyLich(maNV);

					if (ketQua)
					{
						MessageBox.Show("Xóa thành công!",
							"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ResetValue();
						dgvSYLL.DataSource = lylichBUS.GetAllSoYeuLyLich();
					}
					else
					{
						MessageBox.Show("Xóa thất bại!",
							"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message,
					"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void click(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				btnThem.Enabled = false;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;
				btnBoQua.Enabled = true;
				txtMaNV.Enabled = false;
				DataGridViewRow row = dgvSYLL.Rows[e.RowIndex];
				txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
				txtTDHV.Text = row.Cells["TrinhDoHocVan"].Value.ToString();
				txtKNG.Text = row.Cells["KinhNghiem"].Value.ToString();
				txtKN.Text = row.Cells["KyNang"].Value.ToString();
				txtCC.Text = row.Cells["ChungChi"].Value.ToString();
				txtNN.Text = row.Cells["NgoaiNgu"].Value.ToString();
				txtNT.Text = Convert.ToDateTime(row.Cells["NgayTao"].Value).ToString("dd/MM/yyyy");
				txtGT.Text = row.Cells["GioiTinh"].Value.ToString();
				txtQQ.Text = row.Cells["QueQuan"].Value.ToString();
				txtGC.Text = row.Cells["GiaCanh"].Value.ToString();
			}
		}

		private void btnBoQua_Click(object sender, EventArgs e)
		{
			try
			{
				ResetValue();
				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;
				txtMaNV.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message,
					"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
