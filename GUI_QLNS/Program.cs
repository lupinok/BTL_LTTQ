using GUI_QLNS.HeThong;
using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GUI_QLNS
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Kiểm tra kết nối trước khi mở form chính
            frmKetNoi frmConnect = new frmKetNoi();
            if (frmConnect.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Main());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
