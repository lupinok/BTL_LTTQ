using GUI_QLNS.HeThong;
using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace GUI_QLNS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Kiểm tra kết nối trước
            if (TryConnectWithSavedSettings())
            {
                Application.Run(new Main());
            }
            else
            {
                // Nếu không kết nối được, hiện form kết nối
                frmKetNoi f = new frmKetNoi();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Main());
                }
            }
        }

        private static bool TryConnectWithSavedSettings()
        {
            try
            {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.LastServerName) 
                    && Properties.Settings.Default.UseWindowsAuth)
                {
                    string connectionString = BuildConnectionString();
                    SqlHelper helper = new SqlHelper(connectionString);
                    return helper.IsConnection;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Debug Error");
            }
            return false;
        }

        private static string BuildConnectionString()
        {
            string server = Properties.Settings.Default.LastServerName;
            string database = Properties.Settings.Default.LastDatabaseName;
            
            if (string.IsNullOrEmpty(database))
            {
                database = "master";
            }

            return $"Data Source={server};Initial Catalog={database};Integrated Security=True";
        }
    }
}
