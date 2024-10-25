using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNS
{
    public class PhongBan_DAL : DatabaseConnection
    {
        public PhongBan_DAL(string connectionString) : base(connectionString)
        {
        }

        // Method to get all departments
        public DataTable GetAllDepartments()
        {
            DataTable departments = new DataTable();
            string query = "SELECT * FROM PhongBan";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(departments);
            }

            return departments;
        }

        // Method to insert a new department
        public bool InsertDepartment(int maPhongBan, string tenPhongBan, int soLuongNhanVien, string truongPhong)
        {
            string query = "INSERT INTO PhongBan (MaPhongBan, TenPhongBan, SoLuongNhanVien, TruongPhong) " +
                           "VALUES (@MaPhongBan, @TenPhongBan, @SoLuongNhanVien, @TruongPhong)";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                command.Parameters.AddWithValue("@TenPhongBan", tenPhongBan);
                command.Parameters.AddWithValue("@SoLuongNhanVien", soLuongNhanVien);
                command.Parameters.AddWithValue("@TruongPhong", truongPhong);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Method to update an existing department
        public bool UpdateDepartment(int maPhongBan, string tenPhongBan, int soLuongNhanVien, string truongPhong)
        {
            string query = "UPDATE PhongBan SET TenPhongBan = @TenPhongBan, SoLuongNhanVien = @SoLuongNhanVien, " +
                           "TruongPhong = @TruongPhong WHERE MaPhongBan = @MaPhongBan";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                command.Parameters.AddWithValue("@TenPhongBan", tenPhongBan);
                command.Parameters.AddWithValue("@SoLuongNhanVien", soLuongNhanVien);
                command.Parameters.AddWithValue("@TruongPhong", truongPhong);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Method to delete a department
        public bool DeleteDepartment(int maPhongBan)
        {
            string query = "DELETE FROM PhongBan WHERE MaPhongBan = @MaPhongBan";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhongBan", maPhongBan);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
