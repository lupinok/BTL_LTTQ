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

namespace GUI_QLNS.NhanVien.ThuongPhat
{
    public partial class ThuongPhat : DevExpress.XtraEditors.XtraForm
    {
        public ThuongPhat()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void ThuongPhat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet8.ChiTietKT_KL' table. You can move, or remove it, as needed.
            this.chiTietKT_KLTableAdapter.Fill(this.bTLMonLTTQDataSet8.ChiTietKT_KL);
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet7.KT_KL' table. You can move, or remove it, as needed.
            this.kT_KLTableAdapter.Fill(this.bTLMonLTTQDataSet7.KT_KL);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new ThemThuongPhat();
            frm.ShowDialog();
        }
    }
}