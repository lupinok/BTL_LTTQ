using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLNS
{
	public class TinhLuong_DAL : DatabaseConnection
	{
		public TinhLuong_DAL(string connectionString) : base(connectionString)
		{
		}

		// Method to get salary details for a specific employee
		public DataTable GetSalaryDetails(int employeeId)
		{
			DataTable salaryDetails = new DataTable();
			string query = "SELECT * FROM PhieuLuong WHERE MaNhanVien = @MaNhanVien";

			using (SqlConnection connection = GetConnection())
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@MaNhanVien", employeeId);

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				adapter.Fill(salaryDetails);
			}

			return salaryDetails;
		}
	}
}
