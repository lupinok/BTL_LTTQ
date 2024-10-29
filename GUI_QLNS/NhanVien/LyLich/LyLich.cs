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

namespace GUI_QLNS.NhanVien.LyLich
{
    public partial class LyLich : DevExpress.XtraEditors.XtraForm
    {
        public LyLich()
        {
            InitializeComponent();
        }

        private void LyLich_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet6.SoYeuLyLich' table. You can move, or remove it, as needed.
            this.soYeuLyLichTableAdapter.Fill(this.bTLMonLTTQDataSet6.SoYeuLyLich);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new ThemLyLich();
            frm.ShowDialog();
        }
    }
}