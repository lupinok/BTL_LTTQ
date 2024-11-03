using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class LOAICA_BUS
    {
         BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public LoaiCa getItem(string maloaica)
        {
            return db.LoaiCas.FirstOrDefault(x => x.MaLoaiCa == maloaica);
        }

        public List<LoaiCa> getList()
        {
            return db.LoaiCas.ToList();
        }
        public  string getTenLoaiCa(string maLoaiCa)
        {
            
                var loaiCa = db.LoaiCas.FirstOrDefault(x => x.MaLoaiCa == maLoaiCa);
                return loaiCa.TenLoaiCa ;
         
        }

        // Hàm lấy hệ số theo mã loại ca
        public  double getHeSo(string maLoaiCa)
        {
            try
            {
                var loaiCa = db.LoaiCas.FirstOrDefault(x => x.MaLoaiCa == maLoaiCa);
                return loaiCa != null ? loaiCa.HeSo : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public LoaiCa Add(LoaiCa lc)
        {
            try
            {
                if (db.LoaiCas.Any(x => x.MaLoaiCa == lc.MaLoaiCa))
                    throw new Exception("Mã ca đã tồn tại.");
                if (string.IsNullOrWhiteSpace(lc.TenLoaiCa))
                    throw new Exception("Tên ca không được bỏ trống.");
                if (lc.HeSo < 1)
                    throw new Exception("Hệ số phải lớn hơn 1.");

                db.LoaiCas.Add(lc);
                db.SaveChanges();
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public LoaiCa Update(LoaiCa lc)
        {
            try
            {
                var _lc = db.LoaiCas.FirstOrDefault(x => x.MaLoaiCa == lc.MaLoaiCa);
                if (_lc != null)
                {
                    _lc.TenLoaiCa = lc.TenLoaiCa;
                    _lc.HeSo = lc.HeSo;
                    _lc.update_by = lc.update_by;
                    db.SaveChanges();
                }
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật LoaiCa: {ex.Message}");
            }
        }

        public void Delete(string maloaica)
        {
            try
            {
                var _lc = db.LoaiCas.FirstOrDefault(x => x.MaLoaiCa == maloaica);
                if (_lc != null)
                {
                    db.LoaiCas.Remove(_lc);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa LoaiCa: {ex.Message}");
            }
        }
    }
}
