using DevExpress.XtraBars;
using GUI_QLNS.HeThong;
using GUI_QLNS.NhanVien;
using GUI_QLNS.NhanVien.ChamCong;
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
        public Main()
        {
            InitializeComponent();
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

            openForm(typeof(frmTinhLuong));
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmPhuCap));
        }
    }
}