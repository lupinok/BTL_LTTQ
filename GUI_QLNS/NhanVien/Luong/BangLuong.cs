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

namespace GUI_QLNS.NhanVien.Luong
{
    public partial class BangLuong : DevExpress.XtraEditors.XtraForm
    {
        public BangLuong()
        {
            InitializeComponent();
        }

        private void BangLuong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet5.PhieuLuong' table. You can move, or remove it, as needed.
            this.phieuLuongTableAdapter.Fill(this.bTLMonLTTQDataSet5.PhieuLuong);

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new ThemPhieuLuong();
            frm.ShowDialog();
        }
    }
}