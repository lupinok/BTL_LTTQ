using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNS
{
    public class TrangQuanTri_DAL : DatabaseConnection
    {
        public TrangQuanTri_DAL(string connectionString) : base(connectionString)
        {
        }

        // Hiển thị thông tin tài khoản
        public DataTable GetAccountInfo(string tenDangNhap)
        {
            DataTable accountInfo = new DataTable();
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(accountInfo);
            }

            return accountInfo;
        }

        // Cấp tài khoản mới
        public bool CreateNewAccount(string tenDangNhap, string matKhau, string vaiTro, string trangThaiTaiKhoan)
        {
            string query = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, TrangThaiTaiKhoan, NgayTao) " +
                           "VALUES (@TenDangNhap, @MatKhau, @VaiTro, @TrangThaiTaiKhoan, @NgayTao)";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@MatKhau", matKhau);
                command.Parameters.AddWithValue("@VaiTro", vaiTro);
                command.Parameters.AddWithValue("@TrangThaiTaiKhoan", trangThaiTaiKhoan);
                command.Parameters.AddWithValue("@NgayTao", DateTime.Now);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Cấp quyền cho tài khoản
        public bool UpdateAccountRole(string tenDangNhap, string newRole)
        {
            string query = "UPDATE TaiKhoan SET VaiTro = @VaiTro WHERE TenDangNhap = @TenDangNhap";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@VaiTro", newRole);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Lấy danh sách tất cả tài khoản
        public DataTable GetAllAccounts()
        {
            DataTable accounts = new DataTable();
            string query = "SELECT * FROM TaiKhoan";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(accounts);
            }

            return accounts;
        }

        // Lấy lịch sử hoạt động
        public DataTable GetActivityHistory(DateTime startDate, DateTime endDate)
        {
            DataTable activityHistory = new DataTable();
            string query = "SELECT * FROM LichSuHoatDong WHERE ThoiGian BETWEEN @StartDate AND @EndDate ORDER BY ThoiGian DESC";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(activityHistory);
            }

            return activityHistory;
        }

        // Lấy lịch sử hoạt động của một tài khoản cụ thể
        public DataTable GetActivityHistoryByAccount(string tenDangNhap)
        {
            DataTable activityHistory = new DataTable();
            string query = "SELECT * FROM LichSuHoatDong WHERE TenDangNhap = @TenDangNhap ORDER BY ThoiGian DESC";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(activityHistory);
            }

            return activityHistory;
        }

        // Thêm một bản ghi vào lịch sử hoạt động
        public bool AddActivityLog(string loaiHoatDong, string tenDangNhap, string ghiChu)
        {
            string query = "INSERT INTO LichSuHoatDong (LoaiHoatDong, ThoiGian, TenDangNhap, GhiChu) " +
                           "VALUES (@LoaiHoatDong, @ThoiGian, @TenDangNhap, @GhiChu)";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LoaiHoatDong", loaiHoatDong);
                command.Parameters.AddWithValue("@ThoiGian", DateTime.Now);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@GhiChu", ghiChu);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
