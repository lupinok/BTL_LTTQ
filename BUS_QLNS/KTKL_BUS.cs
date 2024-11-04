using BUS_QLNS.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class KTKL_BUS 
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public ChiTietKT_KL getItem(int manv,int mask)
        {
            return db.ChiTietKT_KL.FirstOrDefault(x => x.MaNhanVien== manv && x.MaSuKien == mask);
        }
        public List<KT_KL> getListSK()
        {
            return db.KT_KL.ToList();
        }

        public List<KT_KL> getListSuKienTheoLoai(string loaiSK)
        {
            try
            {
                return db.KT_KL.Where(x => x.LoaiSuKien == loaiSK).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách sự kiện: " + ex.Message);
            }
        }

        public List<ChiTietKT_KL> getList()
        {
            return db.ChiTietKT_KL.ToList();
        }

        public ChiTietKT_KL Add(ChiTietKT_KL lc)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lc.ChiTiet))
                    throw new Exception("Nội dung không được bỏ trống.");

                var exists = db.ChiTietKT_KL.FirstOrDefault(x =>
                x.MaNhanVien == lc.MaNhanVien &&
                x.MaSuKien == lc.MaSuKien);

                if (exists != null)
                    throw new Exception("Đã tồn tại bản ghi này cho nhân viên.");
                db.ChiTietKT_KL.Add(lc);
                db.SaveChanges();
                return lc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public KT_KL getSuKien(int mask)
        {
            return db.KT_KL.FirstOrDefault(x => x.MaSuKien == mask);
        }
        public ChiTietKT_KL getLyDo(int mask)
        {
            return db.ChiTietKT_KL.FirstOrDefault(x => x.MaSuKien == mask);
        }
        public ChiTietKT_KL Update(ChiTietKT_KL lc)
        {
            try
            {
                var _lc = db.ChiTietKT_KL.FirstOrDefault(x => x.MaNhanVien == lc.MaNhanVien && x.MaSuKien == lc.MaSuKien);
                if (_lc != null)
                {
                    _lc.MaNhanVien = lc.MaNhanVien;
                    _lc.MaSuKien = lc.MaSuKien;
                    _lc.ChiTiet = lc.ChiTiet;
                    _lc.TienThuongPhat=lc.TienThuongPhat;
                    _lc.update_by = lc.update_by;
                    db.SaveChanges();
                }
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật ChiTietKT_KL: {ex.Message}");
            }
        }

        public void Delete(int manv,int mask)
        {
            try
            {
                var _lc = db.ChiTietKT_KL.FirstOrDefault(x => x.MaNhanVien == manv && x.MaSuKien == mask);
                if (_lc != null)
                {
                    db.ChiTietKT_KL.Remove(_lc);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa ChiTietKT_KL: {ex.Message}");
            }
        }
    }
}
