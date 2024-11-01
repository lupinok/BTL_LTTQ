using DevExpress.XtraEditors;
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
    public partial class CapNhatNgayCong : DevExpress.XtraEditors.XtraForm
    {
        public CapNhatNgayCong()
        {
            InitializeComponent();
        }
        public int _manv;
        public string _hoten;
        public int _makycong;
        public string _ngay;

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_manv.ToString() + "-" + _makycong.ToString() + "-" + _ngay);
        }
    }
}