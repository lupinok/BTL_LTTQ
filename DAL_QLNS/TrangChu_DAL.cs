using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNS
{
    public class TrangChu_DAL : DatabaseConnection
    {
        public TrangChu_DAL(string connectionString) : base(connectionString)
        {
        }

        // Lấy thông tin tổng quan về nhân viên
        public DataTable GetEmployeeSummary()
        {
            DataTable summary = new DataTable();
            string query = @"SELECT COUNT(*) AS TotalEmployees, 
                                    COUNT(CASE WHEN GioiTinh = N'Nam' THEN 1 END) AS MaleEmployees,
                                    COUNT(CASE WHEN GioiTinh = N'Nữ' THEN 1 END) AS FemaleEmployees
                             FROM NhanVien";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(summary);
            }

            return summary;
        }

        // Lấy thông tin tổng quan về phòng ban
        public DataTable GetDepartmentSummary()
        {
            DataTable summary = new DataTable();
            string query = "SELECT COUNT(*) AS TotalDepartments, SUM(SoLuongNhanVien) AS TotalEmployeesInDepartments FROM PhongBan";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(summary);
            }

            return summary;
        }

        // Lấy thông tin tổng quan về dự án
        public DataTable GetProjectSummary()
        {
            DataTable summary = new DataTable();
            string query = @"SELECT COUNT(*) AS TotalProjects, 
                                    COUNT(CASE WHEN TrangThai = N'Đang thực hiện' THEN 1 END) AS OngoingProjects,
                                    COUNT(CASE WHEN TrangThai = N'Hoàn thành' THEN 1 END) AS CompletedProjects
                             FROM DuAn";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(summary);
            }

            return summary;
        }

        // Lấy thông tin chấm công hôm nay
        public DataTable GetTodayAttendance()
        {
            DataTable attendance = new DataTable();
            string query = @"SELECT COUNT(*) AS TotalAttendance, 
                                    COUNT(CASE WHEN KetQuaChamCong = N'Đúng giờ' THEN 1 END) AS OnTimeAttendance,
                                    COUNT(CASE WHEN KetQuaChamCong = N'Muộn' THEN 1 END) AS LateAttendance
                             FROM ChamCong
                             WHERE NgayChamCong = CAST(GETDATE() AS DATE)";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(attendance);
            }

            return attendance;
        }

        // Lấy danh sách các hoạt động gần đây
        public DataTable GetRecentActivities(int limit = 10)
        {
            DataTable activities = new DataTable();
            string query = @"SELECT TOP (@Limit) LoaiHoatDong, ThoiGian, TenDangNhap, GhiChu 
                             FROM LichSuHoatDong 
                             ORDER BY ThoiGian DESC";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Limit", limit);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(activities);
            }

            return activities;
        }

        // Kiểm tra quyền truy cập của người dùng
        public string GetUserRole(string tenDangNhap)
        {
            string query = "SELECT VaiTro FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                connection.Open();
                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : null;
            }
        }
    }
}
