using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class PhuCap_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public PhuCap getItem(string mpc)
        {
            return db.PhuCaps.FirstOrDefault(x => x.MaPhuCap == mpc);
        }
        public List<PhuCap> getList()
        {
            return db.PhuCaps.ToList();
        }

        public PhuCap Add(PhuCap lc)
        {
            try
            {
                var exists = db.PhuCaps.FirstOrDefault(x =>
                x.MaPhuCap == lc.MaPhuCap);

                if (exists != null)
                    throw new Exception("Đã tồn tại bản ghi này cho nhân viên.");
                db.PhuCaps.Add(lc);
                db.SaveChanges();
                return lc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        
       
        public PhuCap  Update(PhuCap lc)
        {
            try
            {
                var _lc = db.PhuCaps.FirstOrDefault(x => x.MaPhuCap == lc.MaPhuCap);
                if (_lc != null)
                {
                    _lc.MaNhanVien = lc.MaNhanVien;
                    _lc.MaPhuCap = lc.MaPhuCap;
                    _lc.HoTen = lc.HoTen;
                    _lc.LoaiPhuCap = lc.LoaiPhuCap;
                    _lc.SoTien = lc.SoTien; 
                    _lc.Thang = lc.Thang;
                    _lc.Nam = lc.Nam;
                    _lc.GhiChu = lc.GhiChu;
                    _lc.create_date = lc.create_date;
                    _lc.update_by = lc.update_by;
                    db.SaveChanges();
                }
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật PhuCaps: {ex.Message}");
            }
        }
        public bool KiemTraTrung(int maNV, string loaiPC, int thang, int nam)
        {
            try
            {
                // Kiểm tra xem đã tồn tại bản ghi nào thỏa mãn các điều kiện
                var check = db.PhuCaps.FirstOrDefault(x =>
                    x.MaNhanVien == maNV &&
                    x.LoaiPhuCap == loaiPC &&
                    x.Thang == thang &&
                    x.Nam == nam);

                return check != null; // Trả về true nếu đã tồn tại, false nếu chưa tồn tại
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra trùng: " + ex.Message);
            }
        }
        public void Delete(string mpc)
        {
            try
            {
                var _lc = db.PhuCaps.FirstOrDefault(x => x.MaPhuCap == mpc );
                if (_lc != null)
                {
                    db.PhuCaps.Remove(_lc);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa PhuCaps: {ex.Message}");
            }
        }
    }
}
