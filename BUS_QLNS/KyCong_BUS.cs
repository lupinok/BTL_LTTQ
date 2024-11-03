using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class KyCong_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public KYCONG getItem(int makycong)
        {
            return db.KYCONGs.FirstOrDefault(x => x.MAKYCONG == makycong);
        }

        public List<KYCONG> getList()
        {
            return db.KYCONGs.ToList();
        }

        public KYCONG Add(KYCONG kc)
        {
            try
            {
                db.KYCONGs.Add(kc);
                db.SaveChanges();
                return kc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public KYCONG Update(KYCONG kc)
        {
            try
            {
                var _kc = db.KYCONGs.FirstOrDefault(x => x.MAKYCONG == kc.MAKYCONG);
                if (_kc != null)
                {
                    _kc.MAKYCONG = kc.MAKYCONG;
                    _kc.NAM = kc.NAM;
                    _kc.THANG = kc.THANG;
                    _kc.KHOA = kc.KHOA;
                    _kc.NGAYCONGTRONGTHANG = kc.NGAYCONGTRONGTHANG;
                    _kc.NGAYTINHCONG = kc.NGAYTINHCONG;
                    _kc.TRANGTHAI = kc.TRANGTHAI;
                    _kc.update_by = kc.update_by;
                    _kc.update_date = kc.update_date;
                    db.SaveChanges();
                }
                return kc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(int makycong, string iduser)
        {
            try
            {
                var _kc = db.KYCONGs.FirstOrDefault(x => x.MAKYCONG == makycong);
                if (_kc != null)
                {
                    // Xóa các bản ghi con trong KYCONGCHITIET trước (nếu có)
                    var kycongchitiet = db.KYCONGCHITIETs.Where(x => x.MAKYCONG == makycong);
                    if (kycongchitiet.Any())
                    {
                        db.KYCONGCHITIETs.RemoveRange(kycongchitiet);
                    }

                    // Sau đó xóa bản ghi trong KYCONG
                    db.KYCONGs.Remove(_kc);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public bool KiemTraPhatSinhKyCong(int makycong)
        {
            var kc = db.KYCONGs.FirstOrDefault(x => x.MAKYCONG == makycong);
            if (kc == null)
                return false;
            else
            {
                if (kc.TRANGTHAI == true)
                    return true;
                else
                    return false;
            }
        }
    }
}
