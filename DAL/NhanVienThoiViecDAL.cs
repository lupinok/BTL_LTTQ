using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class NhanVienThoiViecDAL
    {
        private QLNSEntities db;

        public NhanVienThoiViecDAL()
        {
            db = new QLNSEntities();
        }

        private void UpdateNhanVienStatus(int maNhanVien, DateTime ngayThoiViec)
        {
            try
            {
                var nhanVien = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == maNhanVien);
                if (nhanVien != null)
                {
                    nhanVien.DaThoiViec = ngayThoiViec <= DateTime.Now;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật trạng thái nhân viên: {ex.Message}");
            }
        }

        public NhanVienThoiViec Add(NhanVienThoiViec tv)
        {
            try
            {
                db.NhanVienThoiViecs.Add(tv);
                db.SaveChanges();
                
                if (tv.NgayThoiViec.HasValue && tv.MaNhanVien.HasValue)
                {
                    UpdateNhanVienStatus(tv.MaNhanVien.Value, tv.NgayThoiViec.Value);
                }
                
                return tv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi:" + ex.Message);
            }
        }

        public NhanVienThoiViec Update(NhanVienThoiViec tv)
        {
            try
            {
                var _tv = db.NhanVienThoiViecs.FirstOrDefault(x => x.SoQD == tv.SoQD);
                if (_tv != null)
                {
                    _tv.NgayQuyetDinh = tv.NgayQuyetDinh;
                    _tv.NgayThoiViec = tv.NgayThoiViec;
                    _tv.MaNhanVien = tv.MaNhanVien;
                    _tv.LyDo = tv.LyDo;
                    _tv.GhiChu = tv.GhiChu;
                    _tv.UPDATED_BY = tv.UPDATED_BY;
                    _tv.UPDATED_DATE = tv.UPDATED_DATE;
                    db.SaveChanges();

                    if (tv.NgayThoiViec.HasValue && tv.MaNhanVien.HasValue)
                    {
                        UpdateNhanVienStatus(tv.MaNhanVien.Value, tv.NgayThoiViec.Value);
                    }
                }
                return tv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi:" + ex.Message);
            }
        }
    }
} 