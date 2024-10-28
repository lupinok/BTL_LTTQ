using DAL_QLNS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
	public class SoYeuLiLich_DaoTao_BUS : ISoYeuLiLich_DaoTao_BUS
	{
		private readonly SoYeuLiLich_DaoTao_DAL _syllDal;
		public SoYeuLiLich_DaoTao_BUS(string connectionString)
		{
			_syllDal = new SoYeuLiLich_DaoTao_DAL(connectionString);
		}

		public SoYeuLiLich_DaoTao_BUS()
		{
			_syllDal = new SoYeuLiLich_DaoTao_DAL(); 
		}

		// SoYeuLyLich methods
		public DataTable GetAllSoYeuLyLich()
		{
			return _syllDal.GetAllSoYeuLyLich();
		}

		public bool InsertSoYeuLyLich(int maNhanVien, string trinhDoHocVan, string kinhNghiem,
			string kyNang, string chungChi, string ngoaiNgu, DateTime ngayTao,
			string gioiTinh, string queQuan, string giaCanh)
		{
			return _syllDal.InsertSoYeuLyLich(maNhanVien, trinhDoHocVan, kinhNghiem,
				kyNang, chungChi, ngoaiNgu, ngayTao, gioiTinh, queQuan, giaCanh);
		}

		public bool UpdateSoYeuLyLich(int maNhanVien, string trinhDoHocVan, string kinhNghiem,
			string kyNang, string chungChi, string ngoaiNgu, DateTime ngayTao,
			string gioiTinh, string queQuan, string giaCanh)
		{
			return _syllDal.UpdateSoYeuLyLich(maNhanVien, trinhDoHocVan, kinhNghiem,
				kyNang, chungChi, ngoaiNgu, ngayTao, gioiTinh, queQuan, giaCanh);
		}

		public bool DeleteSoYeuLyLich(int maNhanVien)
		{
			return _syllDal.DeleteSoYeuLyLich(maNhanVien);
		}

		// DaoTao methods
		public DataTable GetAllDaoTao()
		{
			throw new NotImplementedException("Need to implement DaoTao methods in DAL first");
		}

		public bool InsertDaoTao(int maDaoTao, string tenKhoa, string noiDung,
			DateTime ngayBatDau, DateTime ngayKetThuc, decimal chiPhi)
		{
			throw new NotImplementedException("Need to implement DaoTao methods in DAL first");
		}

		public bool UpdateDaoTao(int maDaoTao, string tenKhoa, string noiDung,
			DateTime ngayBatDau, DateTime ngayKetThuc, decimal chiPhi)
		{
			throw new NotImplementedException("Need to implement DaoTao methods in DAL first");
		}

		public bool DeleteDaoTao(int maDaoTao)
		{
			throw new NotImplementedException("Need to implement DaoTao methods in DAL first");
		}
	}
}
