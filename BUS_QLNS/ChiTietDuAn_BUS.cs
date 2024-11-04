using BUS_QLNS.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class ChiTietDuAn_BUS : IChiTietDuAn_BUS
    {
        private readonly BTLMonLTTQEntities db;

        public ChiTietDuAn_BUS()
        {
            db = new BTLMonLTTQEntities();
        }

        public List<ChiTietDuAn> GetList()
        {
            return db.ChiTietDuAns.ToList();
        }

        public List<ChiTietDuAn> GetByDuAn(int maDuAn)
        {
            return db.ChiTietDuAns.Where(x => x.MaDuAn == maDuAn).ToList();
        }

        public ChiTietDuAn GetItem(int maDuAn, int maNhanVien)
        {
            return db.ChiTietDuAns.FirstOrDefault(x =>
                x.MaDuAn == maDuAn && x.MaNhanVien == maNhanVien);
        }

        public ChiTietDuAn Add(ChiTietDuAn ctda)
        {
            try
            {
                ValidateChiTietDuAn(ctda);

                var exists = db.ChiTietDuAns.FirstOrDefault(x =>
                    x.MaDuAn == ctda.MaDuAn && x.MaNhanVien == ctda.MaNhanVien);

                if (exists != null)
                    throw new Exception("Nhân viên này đã tham gia dự án");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.ChiTietDuAns.Add(ctda);
                        db.SaveChanges();
                        transaction.Commit();
                        return ctda;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thêm chi tiết dự án: {ex.Message}");
            }
        }

        public void Delete(int maDuAn, int maNhanVien)
        {
            try
            {
                var ctda = db.ChiTietDuAns.FirstOrDefault(x =>
                    x.MaDuAn == maDuAn && x.MaNhanVien == maNhanVien);

                if (ctda == null)
                    throw new Exception("Không tìm thấy chi tiết dự án");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.ChiTietDuAns.Remove(ctda);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xóa chi tiết dự án: {ex.Message}");
            }
        }

        public ChiTietDuAn Update(ChiTietDuAn ctda)
        {
            try
            {
                ValidateChiTietDuAn(ctda);

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var existing = db.ChiTietDuAns.FirstOrDefault(x =>
                            x.MaDuAn == ctda.MaDuAn && x.MaNhanVien == ctda.MaNhanVien);

                        if (existing == null)
                            throw new Exception("Không tìm thấy chi tiết dự án");

                        existing.ThoiHanDuAn = ctda.ThoiHanDuAn;
                        existing.DanhGia = ctda.DanhGia;
                        existing.VaiTro = ctda.VaiTro;

                        db.SaveChanges();
                        transaction.Commit();
                        return existing;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật chi tiết dự án: {ex.Message}");
            }
        }

        private void ValidateChiTietDuAn(ChiTietDuAn ctda)
        {
            if (ctda == null)
                throw new ArgumentNullException(nameof(ctda), "Dữ liệu chi tiết dự án không được để trống");

            if (ctda.MaDuAn <= 0)
                throw new Exception("Mã dự án không hợp lệ");

            if (ctda.MaNhanVien <= 0)
                throw new Exception("Mã nhân viên không hợp lệ");

            if (string.IsNullOrEmpty(ctda.VaiTro))
                throw new Exception("Vai trò không được để trống");

            // Kiểm tra dự án có tồn tại không
            var duAn = db.DuAns.FirstOrDefault(x => x.MaDuAn == ctda.MaDuAn);
            if (duAn == null)
                throw new Exception($"Không tìm thấy dự án với mã {ctda.MaDuAn}");

            // Kiểm tra nhân viên có tồn tại không
            var nhanVien = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == ctda.MaNhanVien);
            if (nhanVien == null)
                throw new Exception($"Không tìm thấy nhân viên với mã {ctda.MaNhanVien}");
        }

        public List<object> GetChiTietDuAnDetails(int maDuAn)
        {
            return (from ctda in db.ChiTietDuAns
                    join nv in db.NhanViens on ctda.MaNhanVien equals nv.MaNhanVien
                    where ctda.MaDuAn == maDuAn
                    select new
                    {
                        ctda.MaDuAn,
                        ctda.MaNhanVien,
                        nv.HoTen,
                        ctda.ThoiHanDuAn,
                        ctda.DanhGia,
                        ctda.VaiTro,
                        nv.ChucVu.TenChucVu,
                        nv.PhongBan.TenPhongBan
                    }).ToList<object>();
        }

        public List<object> GetAvailableNhanVien(int maDuAn)
        {
            return (from nv in db.NhanViens
                    where !db.ChiTietDuAns.Any(x => x.MaDuAn == maDuAn && x.MaNhanVien == nv.MaNhanVien)
                    select new
                    {
                        nv.MaNhanVien,
                        nv.HoTen,
                        nv.ChucVu.TenChucVu,
                        nv.PhongBan.TenPhongBan
                    }).ToList<object>();
        }

        public List<string> GetVaiTroList()
        {
            return new List<string>
            {
                "Quản lý dự án",
                "Trưởng nhóm",
                "Thành viên",
                "Cố vấn",
                "Khách hàng"
            };
        }
        public NhanVien GetNhanVien(int maNhanVien)
        {
            return db.NhanViens.FirstOrDefault(x => x.MaNhanVien == maNhanVien);
        }
    }
}
