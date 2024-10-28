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

		public SoYeuLiLich_DaoTao_DAL()
			: base("Data Source=DESKTOP-14IEBEU\\SQLEXPRESS;Initial Catalog=BTLMonLTTQ;Integrated Security=True")
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
		public DataTable GetThongTinDaoTao()
		{
			using (SqlConnection conn = GetConnection())
			{
				string query = @"SELECT 
					nv.MaNhanVien,
					nv.HoTen,
					dt.TenKhoa,
					dt.NoiDung,
					ctdt.ThoiGianDuKien,
					ctdt.DanhGiaKhoa,
					dt.NgayBatDau,
					dt.NgayKetThuc
				FROM NhanVien nv
				INNER JOIN ChiTietKhoaDaoTao ctdt ON nv.MaNhanVien = ctdt.MaNhanVien
				INNER JOIN DaoTao dt ON ctdt.MaDaoTao = dt.MaDaoTao";

				SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
				DataTable dataTable = new DataTable();
				adapter.Fill(dataTable);
				return dataTable;
			}
		}

		private List<string> GetMaNVByMaDaoTao(SqlConnection conn, string maDT)
		{
			List<string> maNVList = new List<string>();
			string query = "SELECT DISTINCT MaNhanVien FROM ChiTietKhoaDaoTao WHERE MaDaoTao = @MaDT";
			
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				cmd.Parameters.AddWithValue("@MaDT", maDT);
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						maNVList.Add(reader["MaNhanVien"].ToString());
					}
				}
			}
			return maNVList;
		}

		public DataTable TimKiemSYLL(string maNV, string trinhDoHV, string kinhNghiem, 
			string kyNang, string chungChi, string ngoaiNgu, string ngayTao, 
			string gioiTinh, string queQuan, string giaCanh)
		{
			using (SqlConnection conn = GetConnection())
			{
				string query = @"SELECT DISTINCT 
							syll.MaNhanVien,
							nv.HoTen,
							syll.TrinhDoHocVan,
							syll.KinhNghiem,
							syll.KyNang,
							syll.ChungChi,
							syll.NgoaiNgu,
							syll.NgayTao,
							syll.GioiTinh,
							syll.QueQuan,
							syll.GiaCanh
						FROM SoYeuLyLich syll
						INNER JOIN NhanVien nv ON syll.MaNhanVien = nv.MaNhanVien
						WHERE 1=1";

				List<SqlParameter> parameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(maNV))
				{
					query += " AND syll.MaNhanVien = @MaNV";
					parameters.Add(new SqlParameter("@MaNV", maNV));
				}
				if (!string.IsNullOrEmpty(trinhDoHV))
				{
					query += " AND syll.TrinhDoHocVan LIKE @TrinhDoHV";
					parameters.Add(new SqlParameter("@TrinhDoHV", "%" + trinhDoHV + "%"));
				}
				if (!string.IsNullOrEmpty(kinhNghiem))
				{
					query += " AND syll.KinhNghiem LIKE @KinhNghiem";
					parameters.Add(new SqlParameter("@KinhNghiem", "%" + kinhNghiem + "%"));
				}
				if (!string.IsNullOrEmpty(kyNang))
				{
					query += " AND syll.KyNang LIKE @KyNang";
					parameters.Add(new SqlParameter("@KyNang", "%" + kyNang + "%"));
				}
				if (!string.IsNullOrEmpty(chungChi))
				{
					query += " AND syll.ChungChi LIKE @ChungChi";
					parameters.Add(new SqlParameter("@ChungChi", "%" + chungChi + "%"));
				}
				if (!string.IsNullOrEmpty(ngoaiNgu))
				{
					query += " AND syll.NgoaiNgu LIKE @NgoaiNgu";
					parameters.Add(new SqlParameter("@NgoaiNgu", "%" + ngoaiNgu + "%"));
				}
				if (!string.IsNullOrEmpty(ngayTao))
				{
					query += " AND CONVERT(VARCHAR, syll.NgayTao, 103) LIKE @NgayTao";
					parameters.Add(new SqlParameter("@NgayTao", "%" + ngayTao + "%"));
				}
				if (!string.IsNullOrEmpty(gioiTinh))
				{
					query += " AND syll.GioiTinh LIKE @GioiTinh";
					parameters.Add(new SqlParameter("@GioiTinh", "%" + gioiTinh + "%"));
				}
				if (!string.IsNullOrEmpty(queQuan))
				{
					query += " AND syll.QueQuan LIKE @QueQuan";
					parameters.Add(new SqlParameter("@QueQuan", "%" + queQuan + "%"));
				}
				if (!string.IsNullOrEmpty(giaCanh))
				{
					query += " AND syll.GiaCanh LIKE @GiaCanh";
					parameters.Add(new SqlParameter("@GiaCanh", "%" + giaCanh + "%"));
				}

				query += " ORDER BY syll.MaNhanVien";

				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddRange(parameters.ToArray());

				
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				DataTable dataTable = new DataTable();
				adapter.Fill(dataTable);
				return dataTable;
			}
		}

		public DataTable TimKiemDaoTao(string maNV, string maDT, string tenKhoa, string queQuan, string gioiTinh)
		{
			using (SqlConnection conn = GetConnection())
			{
				string query = @"SELECT DISTINCT 
						nv.MaNhanVien, 
						nv.HoTen, 
						dt.MaDaoTao,
						dt.TenKhoa, 
						dt.NoiDung, 
						ctdt.ThoiGianDuKien, 
						ctdt.DanhGiaKhoa, 
						dt.NgayBatDau, 
						dt.NgayKetThuc, 
						syll.GioiTinh, 
						syll.QueQuan
					FROM NhanVien nv
					LEFT JOIN SoYeuLyLich syll ON nv.MaNhanVien = syll.MaNhanVien
					LEFT JOIN ChiTietKhoaDaoTao ctdt ON nv.MaNhanVien = ctdt.MaNhanVien
					LEFT JOIN DaoTao dt ON ctdt.MaDaoTao = dt.MaDaoTao
					WHERE 1=1";

				List<SqlParameter> parameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(maNV))
				{
					query += " AND nv.MaNhanVien = @MaNV";
					parameters.Add(new SqlParameter("@MaNV", maNV));
				}
				if (!string.IsNullOrEmpty(maDT))
				{
					query += " AND dt.MaDaoTao = @MaDT";
					parameters.Add(new SqlParameter("@MaDT", maDT));
				}
				if (!string.IsNullOrEmpty(tenKhoa))
				{
					query += " AND dt.TenKhoa LIKE @TenKhoa";
					parameters.Add(new SqlParameter("@TenKhoa", "%" + tenKhoa + "%"));
				}
				if (!string.IsNullOrEmpty(queQuan))
				{
					query += " AND syll.QueQuan LIKE @QueQuan";
					parameters.Add(new SqlParameter("@QueQuan", "%" + queQuan + "%"));
				}
				if (!string.IsNullOrEmpty(gioiTinh))
				{
					query += " AND syll.GioiTinh LIKE @GioiTinh";
					parameters.Add(new SqlParameter("@GioiTinh", "%" + gioiTinh + "%"));
				}

				query += " ORDER BY nv.MaNhanVien";

				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddRange(parameters.ToArray());

				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				DataTable dataTable = new DataTable();
				adapter.Fill(dataTable);
				return dataTable;
			}
		}
	}
}
