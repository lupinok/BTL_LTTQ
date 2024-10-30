using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNS.NhanVien.Tài_khoản
{
    public partial class TaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet15.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Fill(this.bTLMonLTTQDataSet15.TaiKhoan);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new ThemTaiKhoan();
            frm.ShowDialog();
        }
    }
}