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

namespace GUI_QLNS.NhanVien.DaoTao
{
    public partial class DaoTao : DevExpress.XtraEditors.XtraForm
    {
        public DaoTao()
        {
            InitializeComponent();
        }

        private void DaoTao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet3.ChiTietKhoaDaoTao' table. You can move, or remove it, as needed.
            this.chiTietKhoaDaoTaoTableAdapter.Fill(this.bTLMonLTTQDataSet3.ChiTietKhoaDaoTao);
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet2.DaoTao' table. You can move, or remove it, as needed.
            this.daoTaoTableAdapter.Fill(this.bTLMonLTTQDataSet2.DaoTao);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new ThemKhoaDT();
            frm.ShowDialog();
        }
    }
}