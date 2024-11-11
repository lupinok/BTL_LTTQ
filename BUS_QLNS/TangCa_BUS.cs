using BUS_QLNS.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class TangCa_BUS 
    {
         BTLMonLTTQEntities db = new BTLMonLTTQEntities();
        public TangCa getItem(int manv,string malc)
        {
            return db.TangCas.FirstOrDefault(x => x.MaNhanVien == manv && x.MaLoaiCa == malc);
        }

        public List<TangCa> getList()
        {
            return db.TangCas.ToList();
        }

        public TangCa Add(TangCa lc)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lc.GhiChu))
                    throw new Exception("Nội dung không được bỏ trống.");

                // Kiểm tra xem nhân viên đã có loại ca này trong cùng ngày chưa
                var exists = db.TangCas.FirstOrDefault(x =>
                    x.MaNhanVien == lc.MaNhanVien &&
                    x.MaLoaiCa == lc.MaLoaiCa &&
                    SqlFunctions.DatePart("day", x.create_date) == SqlFunctions.DatePart("day", lc.create_date));

                if (exists != null)
                    throw new Exception("Nhân viên đã có loại ca này trong ngày " + lc.create_date.Value.ToString("dd/MM/yyyy"));

                db.TangCas.Add(lc);
                db.SaveChanges();
                return lc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        
        
        public  TangCa Update(TangCa lc)
        {
            try
            {
                var duplicate = db.TangCas.FirstOrDefault(x =>
                   x.MaNhanVien == lc.MaNhanVien &&
                   x.MaLoaiCa == lc.MaLoaiCa &&
                  SqlFunctions.DatePart("day", x.create_date) == SqlFunctions.DatePart("day", lc.create_date) &&
                   x.MaNhanVien != lc.MaNhanVien);

                if (duplicate != null)
                    throw new Exception("Nhân viên đã có loại ca này trong ngày " + lc.create_date.Value.ToString("dd/MM/yyyy"));
                var _lc = db.TangCas.FirstOrDefault(x => x.MaNhanVien == lc.MaNhanVien && x.MaLoaiCa == lc.MaLoaiCa);
                if (_lc != null)
                {
                    _lc.MaNhanVien = lc.MaNhanVien;
                    _lc.MaLoaiCa = lc.MaLoaiCa;
                    _lc.HoTen = lc.HoTen;
                    _lc.TenLoaiCa = lc.TenLoaiCa;
                    _lc.SoGio = lc.SoGio;
                    _lc.HeSo = lc.HeSo;
                    _lc.SoTien = lc.SoTien;
                    _lc.GhiChu = lc.GhiChu;
                    _lc.update_by = lc.update_by;
                    _lc.create_date = lc.create_date;
                    db.SaveChanges();
                }
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật TangCa: {ex.Message}");
            }
        }

        public void Delete(int manv, string malc)
        {
            try
            {
                var _lc = db.TangCas.FirstOrDefault(x => x.MaNhanVien == manv && x.MaLoaiCa == malc);
                if (_lc != null)
                {
                    db.TangCas.Remove(_lc);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa TangCa: {ex.Message}");
            }
        }
    }
}
