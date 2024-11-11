using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNS
{
    public class ChamCong_DAL : DatabaseConnection
    {
        public ChamCong_DAL(string connectionString) : base(connectionString)
        {
        }

        // Method to get all attendance records
        public DataTable GetAllAttendanceRecords()
        {
            DataTable attendanceRecords = new DataTable();
            string query = "SELECT * FROM ChamCong";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(attendanceRecords);
            }

            return attendanceRecords;
        }

        // Method to insert a new attendance record
        public bool InsertAttendanceRecord(int maChamCong, DateTime ngayChamCong, TimeSpan gioVao, TimeSpan gioRa, int maNhanVien, string ketQuaChamCong)
        {
            string query = "INSERT INTO ChamCong (MaChamCong, NgayChamCong, GioVao, GioRa, MaNhanVien, KetQuaChamCong) " +
                           "VALUES (@MaChamCong, @NgayChamCong, @GioVao, @GioRa, @MaNhanVien, @KetQuaChamCong)";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaChamCong", maChamCong);
                command.Parameters.AddWithValue("@NgayChamCong", ngayChamCong);
                command.Parameters.AddWithValue("@GioVao", gioVao);
                command.Parameters.AddWithValue("@GioRa", gioRa);
                command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                command.Parameters.AddWithValue("@KetQuaChamCong", ketQuaChamCong);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Method to update an existing attendance record
        public bool UpdateAttendanceRecord(int maChamCong, DateTime ngayChamCong, TimeSpan gioVao, TimeSpan gioRa, int maNhanVien, string ketQuaChamCong)
        {
            string query = "UPDATE ChamCong SET NgayChamCong = @NgayChamCong, GioVao = @GioVao, GioRa = @GioRa, " +
                           "MaNhanVien = @MaNhanVien, KetQuaChamCong = @KetQuaChamCong WHERE MaChamCong = @MaChamCong";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaChamCong", maChamCong);
                command.Parameters.AddWithValue("@NgayChamCong", ngayChamCong);
                command.Parameters.AddWithValue("@GioVao", gioVao);
                command.Parameters.AddWithValue("@GioRa", gioRa);
                command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                command.Parameters.AddWithValue("@KetQuaChamCong", ketQuaChamCong);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Method to delete an attendance record
        public bool DeleteAttendanceRecord(int maChamCong)
        {
            string query = "DELETE FROM ChamCong WHERE MaChamCong = @MaChamCong";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaChamCong", maChamCong);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Method to get attendance records for a specific employee
        public DataTable GetAttendanceRecordsByEmployee(int maNhanVien)
        {
            DataTable attendanceRecords = new DataTable();
            string query = "SELECT * FROM ChamCong WHERE MaNhanVien = @MaNhanVien";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(attendanceRecords);
            }

            return attendanceRecords;
        }

        // Method to get attendance records for a specific date range
        public DataTable GetAttendanceRecordsByDateRange(DateTime startDate, DateTime endDate)
        {
            DataTable attendanceRecords = new DataTable();
            string query = "SELECT * FROM ChamCong WHERE NgayChamCong BETWEEN @StartDate AND @EndDate";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(attendanceRecords);
            }

            return attendanceRecords;
        }
    }
}
