﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
	public class TAIKHOAN_BUS
	{
		BTLMonLTTQEntities db = new BTLMonLTTQEntities();

		public TaiKhoan getItem(string tendangnhap)
		{
			return db.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == tendangnhap);
		}

		public List<TaiKhoan> getList()
		{
			return db.TaiKhoans.ToList();
		}

		public TaiKhoan Add(TaiKhoan tk)
		{
			try
			{
				if (db.TaiKhoans.Any(x => x.TenDangNhap == tk.TenDangNhap))
					throw new Exception("Tên đăng nhập đã tồn tại.");
				if (string.IsNullOrWhiteSpace(tk.MatKhau))
					throw new Exception("Mật khẩu không được bỏ trống.");
				if (string.IsNullOrWhiteSpace(tk.VaiTro))
					throw new Exception("Vai trò không được bỏ trống.");

				tk.NgayTao = DateTime.Now;
				tk.TrangThaiTaiKhoan = "Kích hoạt";

				db.TaiKhoans.Add(tk);
				db.SaveChanges();
				return tk;
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi: " + ex.Message);
			}
		}

		public TaiKhoan Update(TaiKhoan tk)
		{
			try
			{
				var _tk = db.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == tk.TenDangNhap);
				if (_tk != null)
				{
					_tk.MatKhau = tk.MatKhau;
					_tk.VaiTro = tk.VaiTro;
					_tk.TrangThaiTaiKhoan = tk.TrangThaiTaiKhoan;
					db.SaveChanges();
				}
				return tk;
			}
			catch (Exception ex)
			{
				throw new Exception($"Lỗi khi cập nhật tài khoản: {ex.Message}");
			}
		}

		public void Delete(string tendangnhap)
		{
			try
			{
				var _tk = db.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == tendangnhap);
				if (_tk != null)
				{
					db.TaiKhoans.Remove(_tk);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Lỗi khi xóa tài khoản: {ex.Message}");
			}
		}
	}
}