using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class LOAICONG_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public LoaiCong getItem(string maloaicong)
        {
            return db.LoaiCongs.FirstOrDefault(x => x.MaLoaiCong == maloaicong);
        }

        public List<LoaiCong> getList()
        {
            return db.LoaiCongs.ToList();
        }

        public LoaiCong Add(LoaiCong lc)
        {
            try
            {
                if (db.LoaiCongs.Any(x => x.MaLoaiCong == lc.MaLoaiCong))
                    throw new Exception("Mã công đã tồn tại.");
                if (string.IsNullOrWhiteSpace(lc.TenLoaiCong))
                    throw new Exception("Tên công không được bỏ trống.");
                if (lc.HeSo < 1)
                    throw new Exception("Hệ số phải lớn hơn 1.");

                db.LoaiCongs.Add(lc);
                db.SaveChanges();
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public LoaiCong Update(LoaiCong lc)
        {
            try
            {
                var _lc = db.LoaiCongs.FirstOrDefault(x => x.MaLoaiCong == lc.MaLoaiCong);
                if (_lc != null)
                {
                    _lc.TenLoaiCong = lc.TenLoaiCong;
                    _lc.HeSo = lc.HeSo;
                    _lc.update_by = lc.update_by;
                    db.SaveChanges();
                }
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật LoaiCong: {ex.Message}");
            }
        }

        public void Delete(string maloaicong)
        {
            try
            {
                var _lc = db.LoaiCongs.FirstOrDefault(x => x.MaLoaiCong == maloaicong);
                if (_lc != null)
                {
                    db.LoaiCongs.Remove(_lc);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa LoaiCong: {ex.Message}");
            }
        }
    }
}
