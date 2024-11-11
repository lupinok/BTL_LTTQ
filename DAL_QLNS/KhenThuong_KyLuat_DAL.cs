using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNS
{
	public class KhenThuong_KyLuat_DAL : DatabaseConnection
	{
		public KhenThuong_KyLuat_DAL(string connectionString) : base(connectionString)
		{
		}

		// Method to get reward and discipline details for a specific employee
		public DataTable GetKT_KLDetails(int employeeId)
		{
			DataTable kt_klDetails = new DataTable();
			string query = "SELECT * FROM ChiTietKT_KL WHERE MaNhanVien = @MaNhanVien";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaNhanVien", employeeId);

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				adapter.Fill(kt_klDetails);
			}

			return kt_klDetails;
		}

		// Method to insert a new reward or discipline record
		public bool InsertKT_KL(int maNhanVien, int maSuKien, string chiTiet, decimal tienThuongPhat)
		{
			string query = "INSERT INTO ChiTietKT_KL (MaNhanVien, MaSuKien, ChiTiet, TienThuongPhat) " +
						   "VALUES (@MaNhanVien, @MaSuKien, @ChiTiet, @TienThuongPhat)";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
				command.Parameters.AddWithValue("@MaSuKien", maSuKien);
				command.Parameters.AddWithValue("@ChiTiet", chiTiet);
				command.Parameters.AddWithValue("@TienThuongPhat", tienThuongPhat);

				connection.Open();
				int result = command.ExecuteNonQuery();
				return result > 0;
			}
		}

		// Method to update an existing reward or discipline record
		public bool UpdateKT_KL(int maNhanVien, int maSuKien, string chiTiet, decimal tienThuongPhat)
		{
			string query = "UPDATE ChiTietKT_KL SET ChiTiet = @ChiTiet, TienThuongPhat = @TienThuongPhat " +
						   "WHERE MaNhanVien = @MaNhanVien AND MaSuKien = @MaSuKien";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
				command.Parameters.AddWithValue("@MaSuKien", maSuKien);
				command.Parameters.AddWithValue("@ChiTiet", chiTiet);
				command.Parameters.AddWithValue("@TienThuongPhat", tienThuongPhat);

				connection.Open();
				int result = command.ExecuteNonQuery();
				return result > 0;
			}
		}

		// Method to delete a reward or discipline record
		public bool DeleteKT_KL(int maNhanVien, int maSuKien)
		{
			string query = "DELETE FROM ChiTietKT_KL WHERE MaNhanVien = @MaNhanVien AND MaSuKien = @MaSuKien";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
				command.Parameters.AddWithValue("@MaSuKien", maSuKien);

				connection.Open();
				int result = command.ExecuteNonQuery();
				return result > 0;
			}
		}
	}
}
