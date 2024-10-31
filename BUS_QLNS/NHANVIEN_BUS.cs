using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS_QLNS
{
	public class NHANVIEN_BUS
	{
		BTLMonLTTQEntities db = new BTLMonLTTQEntities();

		public NhanVien getItem(int manhanvien)
		{
			return db.NhanViens.FirstOrDefault(x => x.MaNhanVien == manhanvien);
		}

		public List<NhanVien> getList()
		{
			return db.NhanViens.ToList();
		}

		public NhanVien Add(NhanVien nv)
		{
			try
			{
				if (db.NhanViens.Any(x => x.MaNhanVien == nv.MaNhanVien))
					throw new Exception("Mã nhân viên đã tồn tại.");
				if (string.IsNullOrWhiteSpace(nv.HoTen))
					throw new Exception("Họ tên không được bỏ trống.");
				if (nv.SoDienThoai == null)
					throw new Exception("Số điện thoại không được bỏ trống.");
				if (string.IsNullOrWhiteSpace(nv.Email))
					throw new Exception("Email không được bỏ trống.");
				if (nv.MaPhongBan == null)
					throw new Exception("Mã phòng ban không được bỏ trống.");
				if (nv.MaChucVu == null)
					throw new Exception("Mã chức vụ không được bỏ trống.");

				db.NhanViens.Add(nv);
				db.SaveChanges();
				return nv;
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi: " + ex.Message);
			}
		}

		public NhanVien Update(NhanVien nv)
		{
			try
			{
				var _nv = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == nv.MaNhanVien);
				if (_nv != null)
				{
					_nv.HoTen = nv.HoTen;
					_nv.NgaySinh = nv.NgaySinh;
					_nv.SoDienThoai = nv.SoDienThoai;
					_nv.Email = nv.Email;
					_nv.MaPhongBan = nv.MaPhongBan;
					_nv.MaChucVu = nv.MaChucVu;
					db.SaveChanges();
				}
				return nv;
			}
			catch (Exception ex)
			{
				throw new Exception($"Lỗi khi cập nhật nhân viên: {ex.Message}");
			}
		}

		public void Delete(int manhanvien)
		{
			try
			{
				var _nv = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == manhanvien);
				if (_nv != null)
				{
					db.NhanViens.Remove(_nv);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Lỗi khi xóa nhân viên: {ex.Message}");
			}
		}
	}
}
