using BUS_QLNS;
using DAL;
using GUI_QLNS.NhanVien;
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
		private int? _maPhongBan = null;
		private bool _isFilterByPhongBan = false;
		private bool _hasEditPermission;
		private bool openForm = false;
		private static frmNhanVien instance;  // Thêm biến static instance

		public static frmNhanVien Instance
		{
			get
			{
				if (instance == null || instance.IsDisposed)
					instance = new frmNhanVien();
				return instance;
			}
		}
		public frmNhanVien()
		{
			InitializeComponent();
			_nhanvienBUS = new NHANVIEN_BUS();
			_lichsuBUS = new LICHSU_BUS();
			_currentUser = Program.CurrentUser;
			_isFilterByPhongBan = false;


			// Kiểm tra vai trò
			string vaiTro = Properties.Settings.Default.VaiTro;
			_hasEditPermission = vaiTro != "Chỉnh sửa" && vaiTro != "Xem";

            // Ẩn các nút nếu không có quyền chỉnh sửa
            if (!_hasEditPermission)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                
            }
        }

		public frmNhanVien(int maPhongBan)
		{
			InitializeComponent();
			_nhanvienBUS = new NHANVIEN_BUS();
			_lichsuBUS = new LICHSU_BUS();
			_currentUser = Program.CurrentUser;
			_maPhongBan = maPhongBan;
			_isFilterByPhongBan = true;

			// Kiểm tra vai trò
			string vaiTro = Properties.Settings.Default.VaiTro;
			// Chỉ cho phép Quản trị viên và Chỉnh sửa có quyền thao tác khi mở từ phòng ban
			_hasEditPermission = vaiTro == "Quản trị viên" || vaiTro == "Chỉnh sửa";

            // Ẩn các nút nếu không có quyền chỉnh sửa và không được mở từ form phòng ban
            if (!_hasEditPermission)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                
            }
            gvDanhSach.OptionsBehavior.Editable = false;
        }

		private void NhanVien_Load(object sender, EventArgs e)
		{
            //// TODO: This line of code loads data into the 'bTLMonLTTQDataSet.ChucVu' table. You can move, or remove it, as needed.
            //this.chucVuTableAdapter.Fill(this.bTLMonLTTQDataSet.ChucVu);
            //// TODO: This line of code loads data into the 'bTLMonLTTQDataSet.PhongBan' table. You can move, or remove it, as needed.
            //this.phongBanTableAdapter.Fill(this.bTLMonLTTQDataSet.PhongBan);
            LoadPhongBan();
			ShowHideControls(false);

			if (_isFilterByPhongBan && _maPhongBan.HasValue)
			{
				// Nếu mở từ form Phòng ban, lọc theo phòng ban
				gcDanhSach.DataSource = _nhanvienBUS.getListByPhongBan(_maPhongBan.Value);
				lupPhongBan.EditValue = _maPhongBan.Value;
			}
			else
			{
				// Nếu mở từ form Main, hiển thị tất cả nhân viên
				LoadData();
			}
			btnLuu.Enabled=false;
			btnSua.Enabled=false;
			btnXoa.Enabled=false;
            splitContainer1.Panel1Collapsed = true; // Ẩn panel
        }

		void LoadData()
		{
			if (_isFilterByPhongBan && _maPhongBan.HasValue)
			{
				// Nếu mở từ form Phòng ban, luôn lọc theo phòng ban
				gcDanhSach.DataSource = _nhanvienBUS.getListByPhongBan(_maPhongBan.Value);
			}
			else
			{
				// Nếu mở từ form Main, hiển thị tất cả nhân viên
				gcDanhSach.DataSource = _nhanvienBUS.getList();
			}

			gvDanhSach.OptionsBehavior.Editable = false;
		}

		void LoadPhongBan()
		{
            try
            {
                var listPhongBan = _nhanvienBUS.getListPhongBan();

                lupPhongBan.Properties.DataSource = listPhongBan;
                lupPhongBan.Properties.DisplayMember = "TenPhongBan";
                lupPhongBan.Properties.ValueMember = "MaPhongBan";

                if (listPhongBan != null && listPhongBan.Count > 0)
                {
                    lupPhongBan.Properties.PopulateColumns();
                    // Ẩn tất cả các cột
                    foreach (DevExpress.XtraEditors.Controls.LookUpColumnInfo column in lupPhongBan.Properties.Columns)
                    {
                        column.Visible = false;
                    }
                    // Chỉ hiện cột TenPhongBan
                    lupPhongBan.Properties.Columns["TenPhongBan"].Visible = true;
                }

                lupPhongBan.Properties.ShowHeader = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load phòng ban: " + ex.Message);
            }
        }

		void LoadChucVu(int maPhongBan)
		{
            try
            {
                var listChucVu = _nhanvienBUS.getListChucVuByPhongBan(maPhongBan);

                lupChucVu.Properties.DataSource = listChucVu;
                lupChucVu.Properties.DisplayMember = "TenChucVu";
                lupChucVu.Properties.ValueMember = "MaChucVu";

                if (listChucVu != null && listChucVu.Count > 0)
                {
                    lupChucVu.Properties.PopulateColumns();
                    // Ẩn tất cả các cột
                    foreach (DevExpress.XtraEditors.Controls.LookUpColumnInfo column in lupChucVu.Properties.Columns)
                    {
                        column.Visible = false;
                    }
                    // Chỉ hiện cột TenChucVu
                    lupChucVu.Properties.Columns["TenChucVu"].Visible = true;
                }

                lupChucVu.Properties.ShowHeader = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load chức vụ: " + ex.Message);
            }
        }

		void ShowHideControls(bool isEdit)
		{
			if (_hasEditPermission)
			{
				btnThem.Enabled = !isEdit;
				btnSua.Enabled = !isEdit;
				btnXoa.Enabled = !isEdit;
				btnLuu.Enabled = isEdit;
				
				txtMaNhanVien.Enabled = isEdit && _isNewRecord;
				txtHoTen.Enabled = isEdit;
				txtNgaySinh.Enabled = isEdit;
				txtSoDienThoai.Enabled = isEdit;
				txtEmail.Enabled = isEdit;
				lupPhongBan.Enabled = isEdit;
				lupChucVu.Enabled = false;
			}
			else
			{
				// Nếu không có quyền chỉnh sửa, disable tất cả controls
				btnThem.Enabled = false;
				btnSua.Enabled = false;
				btnXoa.Enabled = false;
				btnLuu.Enabled = false;
				
				
				txtMaNhanVien.Enabled = false;
				txtHoTen.Enabled = false;
				txtNgaySinh.Enabled = false;
				txtSoDienThoai.Enabled = false;
				txtEmail.Enabled = false;
				lupPhongBan.Enabled = false;
				lupChucVu.Enabled = false;
			}
		}

		void ClearFields()
		{
			txtMaNhanVien.Text = string.Empty;
			txtHoTen.Text = string.Empty;
			txtNgaySinh.Text = string.Empty;
			txtSoDienThoai.Text = string.Empty;
			txtEmail.Text = string.Empty;
			lupPhongBan.Text = string.Empty;
			lupChucVu.Text = string.Empty;
		}

		private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_isNewRecord = true;
			ShowHideControls(true);
			ClearFields();
            splitContainer1.Panel1Collapsed = false; // Hiện panel
        }

		private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_isNewRecord = false;
			ShowHideControls(true);
			LoadData();
            splitContainer1.Panel1Collapsed = false; // Hiện panel
			lupPhongBan.Enabled = false;
			lupChucVu.Enabled = false;
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
            splitContainer1.Panel1Collapsed = true; // Ẩn panel
        }

		private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (string.IsNullOrEmpty(txtMaNhanVien.Text) ||
				string.IsNullOrEmpty(txtHoTen.Text) ||
				string.IsNullOrEmpty(txtNgaySinh.Text) ||
				string.IsNullOrEmpty(txtSoDienThoai.Text) ||
				string.IsNullOrEmpty(txtEmail.Text) ||
				string.IsNullOrEmpty(lupPhongBan.Text) ||
				string.IsNullOrEmpty(lupChucVu.Text))
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
                    MaPhongBan = Convert.ToInt32(lupPhongBan.EditValue),
                    MaChucVu = Convert.ToInt32(lupChucVu.EditValue),
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
            splitContainer1.Panel1Collapsed = true; // Ẩn panel
        }

		private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ShowHideControls(false);
			btnSua.Enabled = false;
			btnXoa.Enabled = false;
			ClearFields();
            splitContainer1.Panel1Collapsed = true; // Ẩn panel
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

					// Gán giá trị cho Phòng ban
					var maPhongBan = gvDanhSach.GetFocusedRowCellValue("MaPhongBan");
					if (maPhongBan != null)
					{
						lupPhongBan.EditValue = Convert.ToInt32(maPhongBan);
						
						// Load danh sách chức vụ của phòng ban
						LoadChucVu(Convert.ToInt32(maPhongBan));
						
						// Gán giá trị cho Chức vụ
						var maChucVu = gvDanhSach.GetFocusedRowCellValue("MaChucVu");
						if (maChucVu != null)
						{
							lupChucVu.EditValue = Convert.ToInt32(maChucVu);
						}
					}

					btnSua.Enabled = true;
					btnXoa.Enabled = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
				}
				lupChucVu.Enabled = false;
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

        private void lupPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lupPhongBan.EditValue != null)
                {
                    int maPhongBan = Convert.ToInt32(lupPhongBan.EditValue);
                    LoadChucVu(maPhongBan);
                    lupChucVu.Enabled = true;
                }
                else
                {
                    lupChucVu.Properties.DataSource = null;
                    lupChucVu.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn phòng ban: " + ex.Message);
            }
        }

        private void lupChucVu_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}