using BUS_QLNS;
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

        public NhanVienThoiViec Add(NhanVienThoiViec tv)
        {
            try
            {
                db.NhanVienThoiViecs.Add(tv);
                db.SaveChanges();
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
                _tv.NgayQuyetDinh = tv.NgayQuyetDinh;
                _tv.NgayThoiViec = tv.NgayThoiViec;
                _tv.MaNhanVien = tv.MaNhanVien;
                _tv.LyDo = tv.LyDo;
                _tv.GhiChu = tv.GhiChu;
                _tv.UPDATED_BY = tv.UPDATED_BY;
                _tv.UPDATED_DATE = tv.UPDATED_DATE;
                db.SaveChanges();
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
                    _tv.DELETED_BY = userId;
                    _tv.DELETED_DATE = DateTime.Now;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi:" + ex.Message);
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
                    .Where(x => x.DELETED_DATE == null)
                    .OrderByDescending(x => x.SoQD)
                    .FirstOrDefault();

                if (lastQD != null)
                {
                    string currentNumber = lastQD.SoQD.Substring(0, 5);
                    return (int.Parse(currentNumber) + 1).ToString("D5");
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