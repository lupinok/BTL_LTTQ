using BUS_QLNS;
using DevExpress.XtraBars;
using GUI_QLNS.HeThong;
using GUI_QLNS.NhanVien;
using GUI_QLNS.NhanVien.ChamCong;
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
                lstHistory.Items.Clear();
                var lichSu = _lichsuBUS.GetList();
                foreach (var ls in lichSu)
                {
                    string item = $"[{ls.ThoiGian:HH:mm:ss dd/MM/yyyy}] {ls.TenDangNhap}\n" +
                                $"{ls.LoaiHoatDong}\n" +
                                $"{ls.GhiChu}";
                    lstHistory.Items.Add(item);
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

        private void btnLoaiCong_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmLoaiCong));
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

		private void Main_Load(object sender, EventArgs e)
		{

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
    }
}