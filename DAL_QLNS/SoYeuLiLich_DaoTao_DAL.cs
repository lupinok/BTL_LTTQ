using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNS
{
	public class SoYeuLiLich_DaoTao_DAL : DatabaseConnection
	{
		public SoYeuLiLich_DaoTao_DAL(string connectionString) : base(connectionString)
		{
		}

		// Method to retrieve all records from SoYeuLyLich table
		public DataTable GetAllSoYeuLyLich()
		{
			using (SqlConnection conn = GetConnection())
			{
				string query = "SELECT * FROM SoYeuLyLich";
				SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
				DataTable dataTable = new DataTable();
				adapter.Fill(dataTable);
				return dataTable;
			}
		}

		// Method to insert a new record into SoYeuLyLich table
		public bool InsertSoYeuLyLich(int maNhanVien, string trinhDoHocVan, string kinhNghiem, string kyNang, string chungChi, string ngoaiNgu, DateTime ngayTao, string gioiTinh, string queQuan, string giaCanh)
		{
			using (SqlConnection conn = GetConnection())
			{
				string query = "INSERT INTO SoYeuLyLich (MaNhanVien, TrinhDoHocVan, KinhNghiem, KyNang, ChungChi, NgoaiNgu, NgayTao, GioiTinh, QueQuan, GiaCanh) VALUES (@MaNhanVien, @TrinhDoHocVan, @KinhNghiem, @KyNang, @ChungChi, @NgoaiNgu, @NgayTao, @GioiTinh, @QueQuan, @GiaCanh)";
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
				cmd.Parameters.AddWithValue("@TrinhDoHocVan", trinhDoHocVan);
				cmd.Parameters.AddWithValue("@KinhNghiem", kinhNghiem);
				cmd.Parameters.AddWithValue("@KyNang", kyNang);
				cmd.Parameters.AddWithValue("@ChungChi", chungChi);
				cmd.Parameters.AddWithValue("@NgoaiNgu", ngoaiNgu);
				cmd.Parameters.AddWithValue("@NgayTao", ngayTao);
				cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
				cmd.Parameters.AddWithValue("@QueQuan", queQuan);
				cmd.Parameters.AddWithValue("@GiaCanh", giaCanh);

				conn.Open();
				int result = cmd.ExecuteNonQuery();
				return result > 0;
			}
		}

		// Method to update a record in SoYeuLyLich table
		public bool UpdateSoYeuLyLich(int maNhanVien, string trinhDoHocVan, string kinhNghiem, string kyNang, string chungChi, string ngoaiNgu, DateTime ngayTao, string gioiTinh, string queQuan, string giaCanh)
		{
			using (SqlConnection conn = GetConnection())
			{
				string query = "UPDATE SoYeuLyLich SET TrinhDoHocVan = @TrinhDoHocVan, KinhNghiem = @KinhNghiem, KyNang = @KyNang, ChungChi = @ChungChi, NgoaiNgu = @NgoaiNgu, NgayTao = @NgayTao, GioiTinh = @GioiTinh, QueQuan = @QueQuan, GiaCanh = @GiaCanh WHERE MaNhanVien = @MaNhanVien";
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
				cmd.Parameters.AddWithValue("@TrinhDoHocVan", trinhDoHocVan);
				cmd.Parameters.AddWithValue("@KinhNghiem", kinhNghiem);
				cmd.Parameters.AddWithValue("@KyNang", kyNang);
				cmd.Parameters.AddWithValue("@ChungChi", chungChi);
				cmd.Parameters.AddWithValue("@NgoaiNgu", ngoaiNgu);
				cmd.Parameters.AddWithValue("@NgayTao", ngayTao);
				cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
				cmd.Parameters.AddWithValue("@QueQuan", queQuan);
				cmd.Parameters.AddWithValue("@GiaCanh", giaCanh);

				conn.Open();
				int result = cmd.ExecuteNonQuery();
				return result > 0;
			}
		}

		// Method to delete a record from SoYeuLyLich table
		public bool DeleteSoYeuLyLich(int maNhanVien)
		{
			using (SqlConnection conn = GetConnection())
			{
				string query = "DELETE FROM SoYeuLyLich WHERE MaNhanVien = @MaNhanVien";
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

				conn.Open();
				int result = cmd.ExecuteNonQuery();
				return result > 0;
			}
		}

		// Similar methods can be added for DaoTao table
	}
}
