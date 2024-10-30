using DevExpress.XtraBars;
using GUI_QLNS.HeThong;
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
    }
}