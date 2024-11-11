using BUS_QLNS;
using BUS_QLNS.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS_QLNS
{
    public class NhanVienThoiViec_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public NhanVienThoiViec getItem(string soqd)
        {
            return db.NhanVienThoiViecs.FirstOrDefault(x => x.SoQD == soqd);
        }

        public List<NhanVienThoiViec> getList()
        {
            return db.NhanVienThoiViecs.ToList();
        }
        public List<dynamic> getListFull()
        {
            return (from tv in db.NhanVienThoiViecs
                    join nv in db.NhanViens on tv.MaNhanVien equals nv.MaNhanVien
                    
                    select new
                    {
                        tv.SoQD,
                        tv.NgayQuyetDinh,
                        tv.NgayThoiViec,
                        tv.MaNhanVien,
                        HoTen = nv.HoTen,
                        tv.LyDo,
                        tv.GhiChu,
                        tv.CREATED_BY,
                        tv.CREATED_DATE,
                        tv.UPDATED_BY,
                        tv.UPDATED_DATE,
                        tv.DELETED_BY,
                        tv.DELETED_DATE
                    }).ToList<dynamic>();
        }
        private NHANVIEN_BUS _nhanvienBUS;

        public NhanVienThoiViec_BUS()
        {
            _nhanvienBUS = new NHANVIEN_BUS();
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

        public void Delete(string soqd, int userId)
        {
            try
            {
                var _tv = db.NhanVienThoiViecs.FirstOrDefault(x => x.SoQD == soqd);
                if (_tv != null)
                {
                    // Cập nhật trạng thái nhân viên
                    if (_tv.MaNhanVien.HasValue)
                    {
                        var nv = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == _tv.MaNhanVien.Value);
                        if (nv != null)
                        {
                            nv.DaThoiViec = false;
                        }
                    }

                    // Cập nhật quyết định thôi việc
                    _tv.DELETED_BY = userId;
                    _tv.DELETED_DATE = DateTime.Now;

                    // Lưu tất cả thay đổi trong một lần
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "";
                throw new Exception($"Lỗi: {ex.Message}. Chi tiết: {innerException}");
            }
        }
        public List<int> GetNhanVienDaCoQuyetDinh()
        {
            return db.NhanVienThoiViecs
                .Where(x => x.DELETED_BY == null)
                .Select(x => x.MaNhanVien.Value)
                .ToList();
        }

        public string MaxSoQuyetDinh()
        {
            try
            {
                var lastQD = db.NhanVienThoiViecs
                    .OrderByDescending(x => x.SoQD)
                    .FirstOrDefault();

                if (lastQD != null)
                {
                    string currentNumber = lastQD.SoQD.Split('/')[0];
                    return currentNumber;
                }
                return "00000";
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy số quyết định tối đa: {ex.Message}");
            }
        }
    }
}