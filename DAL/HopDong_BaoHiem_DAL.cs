using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNS
{
	public class HopDong_BaoHiem_DAL : DatabaseConnection
	{
		public HopDong_BaoHiem_DAL(string connectionString) : base(connectionString)
		{
		}

		// Method to get insurance details for a specific employee
		public DataTable GetBaoHiemDetails(int employeeId)
		{
			DataTable baoHiemDetails = new DataTable();
			string query = "SELECT * FROM BaoHiem WHERE MaNhanVien = @MaNhanVien";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaNhanVien", employeeId);

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				adapter.Fill(baoHiemDetails);
			}

			return baoHiemDetails;
		}

		// Method to insert a new insurance record
		public bool InsertBaoHiem(int maBaoHiem, DateTime ngayDong, DateTime ngayHetHan, decimal mucDong, int maNhanVien, string tenBaoHiem)
		{
			string query = "INSERT INTO BaoHiem (MaBaoHiem, NgayDong, NgayHetHan, MucDong, MaNhanVien, TenBaoHiem) " +
						   "VALUES (@MaBaoHiem, @NgayDong, @NgayHetHan, @MucDong, @MaNhanVien, @TenBaoHiem)";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaBaoHiem", maBaoHiem);
				command.Parameters.AddWithValue("@NgayDong", ngayDong);
				command.Parameters.AddWithValue("@NgayHetHan", ngayHetHan);
				command.Parameters.AddWithValue("@MucDong", mucDong);
				command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
				command.Parameters.AddWithValue("@TenBaoHiem", tenBaoHiem);

				connection.Open();
				int result = command.ExecuteNonQuery();
				return result > 0;
			}
		}

		// Method to get contract details for a specific employee
		public DataTable GetHopDongDetails(int employeeId)
		{
			DataTable hopDongDetails = new DataTable();
			string query = "SELECT * FROM HopDongLaoDong WHERE MaNhanVien = @MaNhanVien";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaNhanVien", employeeId);

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				adapter.Fill(hopDongDetails);
			}

			return hopDongDetails;
		}

		// Method to insert a new labor contract
		public bool InsertHopDong(int maHopDong, string loaiHopDong, DateTime ngayBatDau, DateTime ngayKetThuc, decimal luongHopDong, int maNhanVien, string noiDungHopDong)
		{
			string query = "INSERT INTO HopDongLaoDong (MaHopDong, LoaiHopDong, NgayBatDau, NgayKetThuc, LuongHopDong, MaNhanVien, NoiDungHopDong) " +
						   "VALUES (@MaHopDong, @LoaiHopDong, @NgayBatDau, @NgayKetThuc, @LuongHopDong, @MaNhanVien, @NoiDungHopDong)";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaHopDong", maHopDong);
				command.Parameters.AddWithValue("@LoaiHopDong", loaiHopDong);
				command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
				command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
				command.Parameters.AddWithValue("@LuongHopDong", luongHopDong);
				command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
				command.Parameters.AddWithValue("@NoiDungHopDong", noiDungHopDong);

				connection.Open();
				int result = command.ExecuteNonQuery();
				return result > 0;
			}
		}
	}
}
