using BUS_QLNS.Interface;
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

        public bool KiemTraTienUng(int maNhanVien, decimal soTienUng)
        {
            try
            {
                // Lấy mã chức vụ của nhân viên
                var nhanVien = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == maNhanVien);
                if (nhanVien == null)
                    throw new Exception("Không tìm thấy nhân viên");

                // Lấy lương chức vụ
                var chucVu = db.ChucVus.FirstOrDefault(x => x.MaChucVu == nhanVien.MaChucVu);
                if (chucVu == null)
                    throw new Exception("Không tìm thấy chức vụ của nhân viên");

                // Kiểm tra số tiền ứng có vượt quá lương chức vụ không
                return soTienUng <= chucVu.LuongChucVu/2;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra tiền ứng: " + ex.Message);
            }
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

                return check != null; 
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
