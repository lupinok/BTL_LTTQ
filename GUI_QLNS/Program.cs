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

            // Kiểm tra kết nối CSDL
            if (!CheckDatabaseConnection())
            {
                return; // Thoát ứng dụng nếu không kết nối được CSDL
            }

            Application.Run(new Main());
        }

        private static bool CheckDatabaseConnection()
        {
            try
            {
                // Đọc connection string từ App.config
                var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTLMonLTTQEntities"].ConnectionString;

                // Kiểm tra kết nối
                if (!DAL.DatabaseConnection.TestConnection(connectionString))
                {
                    // Hiển thị form kết nối nếu không kết nối được
                    while (true)
                    {
                        using (var frmKetNoi = new frmKetNoi())
                        {
                            if (frmKetNoi.ShowDialog() == DialogResult.OK)
                            {
                                // Thử kết nối lại sau khi cấu hình
                                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTLMonLTTQEntities"].ConnectionString;
                                if (DAL.DatabaseConnection.TestConnection(connectionString))
                                {
                                    return true;
                                }
                                else
                                {
                                    if (XtraMessageBox.Show(
                                        "Không thể kết nối đến cơ sở dữ liệu! Bạn có muốn cấu hình lại?",
                                        "Lỗi kết nối",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                // Người dùng đã hủy việc kết nối
                                return false;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Lỗi kiểm tra kết nối CSDL: {ex.Message}\nỨng dụng sẽ thoát.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
