using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class BangCongNhanVienChiTiet_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();
        public BANGCONG_NHANVIEN_CHITIET getItem(int makycong, int manv, int ngay)
        {
            return db.BANGCONG_NHANVIEN_CHITIET.FirstOrDefault(x => x.MAKYCONG == makycong && x.MaNhanVien == manv && x.NGAY.Value.Day == ngay);
        }
        public BANGCONG_NHANVIEN_CHITIET Add(BANGCONG_NHANVIEN_CHITIET bcct)
        {
            try
            {
                db.BANGCONG_NHANVIEN_CHITIET.Add(bcct);
                db.SaveChanges();
                return bcct;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public BANGCONG_NHANVIEN_CHITIET Update(BANGCONG_NHANVIEN_CHITIET bcct)
        {
            try
            {
                BANGCONG_NHANVIEN_CHITIET bcnv = db.BANGCONG_NHANVIEN_CHITIET.FirstOrDefault(x => x.MAKYCONG == bcct.MAKYCONG && x.MaNhanVien == bcct.MaNhanVien && x.NGAY == bcct.NGAY);
                bcnv.KYHIEU = bcnv.KYHIEU;
                bcnv.GIOVAO = bcct.GIOVAO;
                bcnv.GIORA = bcct.GIORA;
                bcnv.NGAYPHEP = bcct.NGAYPHEP;
                bcnv.GHICHU = bcct.GHICHU;
                bcnv.NGAYCONG = bcct.NGAYCONG;
                bcnv.CONGCHUNHAT = bcct.CONGCHUNHAT;
                bcnv.CONGNGAYLE = bcct.CONGNGAYLE;
                bcnv.UPDATED_BY = bcct.UPDATED_BY;
                bcnv.UPDATED_DATE = bcct.UPDATED_DATE;
                db.SaveChanges();
                return bcct;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public double tongNgayPhep(int makycong, int manv)
        {
            return db.BANGCONG_NHANVIEN_CHITIET.Where(x => x.MAKYCONG == makycong && x.MaNhanVien == manv && x.NGAYPHEP != null).ToList().Sum(p => p.NGAYPHEP.Value);
        }

        public double tongNgayCong(int makycong, int manv)
        {
            return db.BANGCONG_NHANVIEN_CHITIET.Where(x => x.MAKYCONG == makycong && x.MaNhanVien == manv && x.NGAYCONG != null).ToList().Sum(p => p.NGAYCONG.Value);
        }
    }
}
