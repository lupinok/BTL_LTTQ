using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class UngLuong_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public UngLuong getItem(string mpc)
        {
            return db.UngLuongs.FirstOrDefault(x => x.MaUngLuong == mpc);
        }



        public List<UngLuong> getList()
        {
            return db.UngLuongs.ToList();
        }

        public UngLuong Add(UngLuong lc)
        {
            try
            {
                var exists = db.UngLuongs.FirstOrDefault(x =>
                x.MaUngLuong == lc.MaUngLuong);

                if (exists != null)
                    throw new Exception("Đã tồn tại bản ghi này cho nhân viên.");
                db.UngLuongs.Add(lc);
                db.SaveChanges();
                return lc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }


        public UngLuong Update(UngLuong lc)
        {
            try
            {
                var _lc = db.UngLuongs.FirstOrDefault(x => x.MaUngLuong == lc.MaUngLuong);
                if (_lc != null)
                {
                    _lc.MaNhanVien = lc.MaNhanVien;
                    _lc.MaUngLuong = lc.MaUngLuong;
                    _lc.HoTen = lc.HoTen;
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
                throw new Exception($"Lỗi khi cập nhật UngLuongs: {ex.Message}");
            }
        }
        public bool KiemTraTrung(int maNV, int thang, int nam)
        {
            try
            {
                var check = db.UngLuongs.FirstOrDefault(x =>
                    x.MaNhanVien == maNV &&
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
                var _lc = db.UngLuongs.FirstOrDefault(x => x.MaUngLuong == mpc);
                if (_lc != null)
                {
                    db.UngLuongs.Remove(_lc);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa UngLuongs: {ex.Message}");
            }
        }
    }
}
