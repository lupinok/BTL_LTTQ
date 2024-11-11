using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNS
{
    public class DangNhap_DAL : DatabaseConnection
    {
        public DangNhap_DAL(string connectionString) : base(connectionString) { }

        public bool ValidateUser(string tenDangNhap, string matKhau)
        {
            string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@MatKhau", matKhau);

                connection.Open();
                int result = (int)command.ExecuteScalar();
                return result > 0;
            }
        }

        public DataTable GetUserInfo(string tenDangNhap)
        {
            DataTable userInfo = new DataTable();
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(userInfo);
            }

            return userInfo;
        }

        public bool ChangePassword(string tenDangNhap, string oldPassword, string newPassword)
        {
            string query = "UPDATE TaiKhoan SET MatKhau = @NewPassword WHERE TenDangNhap = @TenDangNhap AND MatKhau = @OldPassword";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@OldPassword", oldPassword);
                command.Parameters.AddWithValue("@NewPassword", newPassword);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
