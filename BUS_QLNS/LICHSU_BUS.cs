using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
	public class LICHSU_BUS
	{
		private BTLMonLTTQEntities db;

		public LICHSU_BUS()
		{
			db = new BTLMonLTTQEntities();
		}

		public List<LichSuHoatDong> GetList()
		{
			return db.LichSuHoatDongs.OrderByDescending(x => x.ThoiGian).ToList();
		}

		public void ThemLichSu(string loaiHoatDong, string tenDangNhap, string ghiChu)
		{
			try
			{
				var ls = new LichSuHoatDong
				{
					ThoiGian = DateTime.Now,
					LoaiHoatDong = loaiHoatDong,
					TenDangNhap = tenDangNhap,
					GhiChu = ghiChu
				};
				db.LichSuHoatDongs.Add(ls);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi khi thêm lịch sử: " + ex.Message);
			}
		}

		public void XoaTatCa()
		{
			try
			{
				var lichSu = db.LichSuHoatDongs.ToList();
				db.LichSuHoatDongs.RemoveRange(lichSu);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi khi xóa lịch sử: " + ex.Message);
			}
		}
	}
}
