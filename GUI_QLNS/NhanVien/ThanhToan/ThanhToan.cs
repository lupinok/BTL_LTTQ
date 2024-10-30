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

namespace GUI_QLNS.NhanVien.Thanh_toán
{
    public partial class ThanhToan : DevExpress.XtraEditors.XtraForm
    {
        public ThanhToan()
        {
            InitializeComponent();
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet16.ThanhToan' table. You can move, or remove it, as needed.
            this.thanhToanTableAdapter.Fill(this.bTLMonLTTQDataSet16.ThanhToan);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new ThemThanhToan();
            frm.ShowDialog();
        }
    }
}