using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
	public class SYLL_BUS
	{
		BTLMonLTTQEntities db = new BTLMonLTTQEntities();

		public SoYeuLyLich getItem(int manhanvien)
		{
			try
			{
				return db.SoYeuLyLiches.FirstOrDefault(x => x.MaNhanVien == manhanvien);
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi: " + ex.Message);
			}
		}

		public SoYeuLyLich Add(SoYeuLyLich syll)
		{
			try
			{
				db.SoYeuLyLiches.Add(syll);
				db.SaveChanges();
				return syll;
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi: " + ex.Message);
			}
		}

		public SoYeuLyLich Update(SoYeuLyLich syll)
		{
			try
			{
				var _syll = db.SoYeuLyLiches.FirstOrDefault(x => x.MaNhanVien == syll.MaNhanVien);
				if (_syll != null)
				{
					_syll.TrinhDoHocVan = syll.TrinhDoHocVan;
					_syll.KinhNghiem = syll.KinhNghiem;
					_syll.KyNang = syll.KyNang;
					_syll.ChungChi = syll.ChungChi;
					_syll.NgoaiNgu = syll.NgoaiNgu;
					_syll.GioiTinh = syll.GioiTinh;
					_syll.QueQuan = syll.QueQuan;
					_syll.GiaCanh = syll.GiaCanh;
					_syll.QuocTich = syll.QuocTich;
					_syll.NgayTao = syll.NgayTao;
					db.SaveChanges();
				}
				else // Nếu chưa có sơ yếu lý lịch thì thêm mới
				{
					return Add(syll);
				}
				return syll;
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi: " + ex.Message);
			}
		}

		public SoYeuLyLich UpdateHinhAnh(SoYeuLyLich syll)
		{
			try
			{
				var _syll = db.SoYeuLyLiches.FirstOrDefault(x => x.MaNhanVien == syll.MaNhanVien);
				if (_syll != null)
				{
					_syll.HinhAnh = syll.HinhAnh;
					db.SaveChanges();
				}
				else // Nếu chưa có sơ yếu lý lịch thì tạo mới
				{
					syll.NgayTao = DateTime.Now;
					return Add(syll);
				}
				return syll;
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi cập nhật hình ảnh: " + ex.Message);
			}
		}
	}
}
