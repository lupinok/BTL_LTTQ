using GUI_QLNS;
using GUI_QLNS.HeThong;
using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DAL;
using GUI_QLNS.NhanVien;
using GUI_QLNS.NhanVien.Luong;

namespace GUI_QLNS
{
    public static class Program
    {
        public static string CurrentUser { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Kiểm tra kết nối trước
            if (TryConnectWithSavedSettings())
            {
                Application.Run(new DangNhap());
            }
            else
            {
                // Nếu không kết nối được, hiện form kết nối
                frmKetNoi f = new frmKetNoi();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmKetNoi());
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

                    if (helper.IsConnection)
                    {
                        // Check if the specific database exists
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string checkDbQuery = "SELECT database_id FROM sys.databases WHERE Name = @databaseName";
                            using (SqlCommand command = new SqlCommand(checkDbQuery, connection))
                            {
                                command.Parameters.AddWithValue("@databaseName", Properties.Settings.Default.LastDatabaseName);
                                object result = command.ExecuteScalar();
                                return result != null;
                            }
                        }
                    }
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
