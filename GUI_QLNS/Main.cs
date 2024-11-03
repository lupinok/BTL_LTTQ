using BUS_QLNS;
using DevExpress.XtraBars;
using GUI_QLNS.HeThong;
using GUI_QLNS.NhanVien;
using GUI_QLNS.NhanVien.BoPhan;
using GUI_QLNS.NhanVien.ChamCong;
using GUI_QLNS.NhanVien.ChucVu;
using GUI_QLNS.NhanVien.DCNhanVien;
using GUI_QLNS.NhanVien.PhongBan;
using GUI_QLNS.NhanVien.Luong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNS
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private LICHSU_BUS _lichsuBUS;
        private Timer _timer;
        
        public Main()
        {
            InitializeComponent();
            _lichsuBUS = new LICHSU_BUS();
            
            // Cấu hình Timer để cập nhật lịch sử định kỳ
            _timer = new Timer();
            _timer.Interval = 1000; // 1 giây
            _timer.Tick += Timer_Tick;
            _timer.Start();
            
            LoadLichSu();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadLichSu();
        }

        private void LoadLichSu()
        {
            try
            {
                // Lưu vị trí cuộn hiện tại
                int currentIndex = lstHistory.TopIndex;
                
                lstHistory.Items.Clear();
                var lichSu = _lichsuBUS.GetList();
                foreach (var ls in lichSu)
                {
                    string item = $"[{ls.ThoiGian:HH:mm:ss dd/MM/yyyy}] {ls.TenDangNhap}\n" +
                                $"{ls.LoaiHoatDong}\n" +
                                $"{ls.GhiChu}";
                    lstHistory.Items.Add(item);
                }

                // Khôi phục vị trí cuộn
                if (currentIndex >= 0 && currentIndex < lstHistory.Items.Count)
                {
                    lstHistory.TopIndex = currentIndex;
                }
                else if (lstHistory.Items.Count > 0)
                {
                    // Nếu vị trí cũ không hợp lệ, cuộn xuống cuối
                    lstHistory.TopIndex = lstHistory.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _timer.Stop();
            base.OnFormClosing(e);
        }

        void openForm(Type typeForm)
        {
            foreach (var frm in MdiChildren)
            {
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }

        private void btnLoaiCa_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmLoaiCa));
        }

       

        private void btnBangCong_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmBangCong));
        }

        private void bar_SettingDB_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmKetNoi));
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

		private void menu_nhanvien_ItemClick(object sender, ItemClickEventArgs e)
		{
            openForm(typeof(frmNhanVien));
		}

        private void menu_khenthuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmKTKL));
        }

        private void btnTangCa_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmTangCa));

        }

        private void btnUngLuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmUngLuong));
        }

		private void Main_Load(object sender, EventArgs e)
		{
            string vaiTro = Properties.Settings.Default.VaiTro;
        private void menu_hopdong_ItemClick(object sender, ItemClickEventArgs e)
        {

            openForm(typeof(frmHDLD));
        }

        private void barDockingMenuItem1_ListItemClick(object sender, ListItemClickEventArgs e)
        {

            openForm(typeof(frmPhuCap));
        }

        private void menu_luongnhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (vaiTro == "Chỉnh sửa" || vaiTro == "Xem")
            {
                // Ẩn các menu quản lý người dùng
                menu_users.Enabled = false;
                menu_phanquyen.Enabled = false;
            }
        }

		private void menu_users_ItemClick(object sender, ItemClickEventArgs e)
		{
            openForm(typeof(frmTaiKhoan));
		}

        private void btnXoaLichSu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ lịch sử?",
        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _lichsuBUS.XoaTatCa();
                    LoadLichSu(); // Refresh lại listbox
                    MessageBox.Show("Đã xóa toàn bộ lịch sử!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa lịch sử: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChucVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof (frmChucVu));
        }

        private void btbPhongBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmPhongBan));
        }

        private void btbBoPhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmBoPhan));
        }

        private void menu_changePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(Password));
        }

        private void menu_phanquyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTaiKhoan f = new frmTaiKhoan(true); // Truyền tham số true để biết là mở từ phân quyền
            f.ShowDialog();
        }

        private void menu_thuyenchuyen_congtac_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(DCNhanVien));
        }
    }
            openForm(typeof(frmTinhLuong));
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmPhuCap));
        }
    }
}