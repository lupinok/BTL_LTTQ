using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNS
{
	public class DuAn_DAL : DatabaseConnection
	{
		public DuAn_DAL(string connectionString) : base(connectionString)
			{
			}

		// Method to get all projects
		public DataTable GetAllProjects()
		{
			DataTable projects = new DataTable();
			string query = "SELECT * FROM DuAn";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				adapter.Fill(projects);
			}

			return projects;
		}

		// Method to insert a new project
		public bool InsertProject(int maDuAn, string tenDuAn, DateTime ngayBatDau, DateTime ngayKetThuc, decimal nganSach, string trangThai, string moTa)
		{
			string query = "INSERT INTO DuAn (MaDuAn, TenDuAn, NgayBatDau, NgayKetThuc, NganSach, TrangThai, MoTa) " +
						   "VALUES (@MaDuAn, @TenDuAn, @NgayBatDau, @NgayKetThuc, @NganSach, @TrangThai, @MoTa)";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaDuAn", maDuAn);
				command.Parameters.AddWithValue("@TenDuAn", tenDuAn);
				command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
				command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
				command.Parameters.AddWithValue("@NganSach", nganSach);
				command.Parameters.AddWithValue("@TrangThai", trangThai);
				command.Parameters.AddWithValue("@MoTa", moTa);

				connection.Open();
				int result = command.ExecuteNonQuery();
				return result > 0;
			}
		}

		// Method to update an existing project
		public bool UpdateProject(int maDuAn, string tenDuAn, DateTime ngayBatDau, DateTime ngayKetThuc, decimal nganSach, string trangThai, string moTa)
		{
			string query = "UPDATE DuAn SET TenDuAn = @TenDuAn, NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc, " +
						   "NganSach = @NganSach, TrangThai = @TrangThai, MoTa = @MoTa WHERE MaDuAn = @MaDuAn";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaDuAn", maDuAn);
				command.Parameters.AddWithValue("@TenDuAn", tenDuAn);
				command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
				command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
				command.Parameters.AddWithValue("@NganSach", nganSach);
				command.Parameters.AddWithValue("@TrangThai", trangThai);
				command.Parameters.AddWithValue("@MoTa", moTa);

				connection.Open();
				int result = command.ExecuteNonQuery();
				return result > 0;
			}
		}

		// Method to delete a project
		public bool DeleteProject(int maDuAn)
		{
			string query = "DELETE FROM DuAn WHERE MaDuAn = @MaDuAn";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaDuAn", maDuAn);

				connection.Open();
				int result = command.ExecuteNonQuery();
				return result > 0;
			}
		}
	}
}
