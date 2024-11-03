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
			var nhanviens = db.NhanViens.ToList();
			foreach (var nv in nhanviens)
			{
				nv.PhongBan = db.PhongBans.FirstOrDefault(x => x.MaPhongBan == nv.MaPhongBan);
				nv.ChucVu = db.ChucVus.FirstOrDefault(x => x.MaChucVu == nv.MaChucVu);
			}
			return nhanviens;
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
					_nv.DaThoiViec = nv.DaThoiViec;
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
					var syll = db.SoYeuLyLiches.FirstOrDefault(x => x.MaNhanVien == manhanvien);
					if (syll != null)
					{
						db.SoYeuLyLiches.Remove(syll);
						db.SaveChanges();
					}

					db.NhanViens.Remove(_nv);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Lỗi khi xóa nhân viên: {ex.Message}");
			}
		}
		public List<PhongBan> getListPhongBan()
		{
			return db.PhongBans.ToList();
		}

		public List<ChucVu> getListChucVuByPhongBan(int maPhongBan)
		{
			string prefix = maPhongBan.ToString() + "0";
			return db.ChucVus.Where(x => x.MaChucVu.ToString().StartsWith(prefix)).ToList();
		}
	}
}
