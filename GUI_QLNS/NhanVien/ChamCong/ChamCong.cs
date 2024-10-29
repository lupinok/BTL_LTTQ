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

namespace GUI_QLNS.NhanVien.ChamCong
{
    public partial class ChamCong : DevExpress.XtraEditors.XtraForm
    {
        public ChamCong()
        {
            InitializeComponent();
        }

        private void ChamCong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet1.ChamCong' table. You can move, or remove it, as needed.
            this.chamCongTableAdapter.Fill(this.bTLMonLTTQDataSet1.ChamCong);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new ThemChamCong();
            frm.ShowDialog();
        }
    }
}