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

namespace GUI_QLNS.NhanVien.DuAn
{
    public partial class DuAn : DevExpress.XtraEditors.XtraForm
    {
        public DuAn()
        {
            InitializeComponent();
        }

        private void DuAn_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet10.ChiTietDuAn' table. You can move, or remove it, as needed.
            this.chiTietDuAnTableAdapter.Fill(this.bTLMonLTTQDataSet10.ChiTietDuAn);
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet9.DuAn' table. You can move, or remove it, as needed.
            this.duAnTableAdapter.Fill(this.bTLMonLTTQDataSet9.DuAn);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new ThemDuAn();
            frm.ShowDialog();
        }
    }
}