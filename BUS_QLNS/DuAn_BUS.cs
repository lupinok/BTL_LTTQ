using BUS_QLNS.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class DuAn_BUS 
    {
        private readonly BTLMonLTTQEntities db;

        public DuAn_BUS()
        {
            db = new BTLMonLTTQEntities();
        }

        public DuAn GetItem(int maDuAn)
        {
            return db.DuAns.FirstOrDefault(x => x.MaDuAn == maDuAn);
        }

        public List<DuAn> GetList()
        {
            return db.DuAns.ToList();
        }

        public DuAn Add(DuAn da)
        {
            try
            {
                ValidateDuAn(da);

                var exists = db.DuAns.FirstOrDefault(x => x.MaDuAn == da.MaDuAn);
                if (exists != null)
                    throw new Exception($"Mã dự án {da.MaDuAn} đã tồn tại");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.DuAns.Add(da);
                        db.SaveChanges();
                        transaction.Commit();
                        return da;
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
                throw new Exception($"Lỗi thêm dự án: {ex.Message}");
            }
        }

        public void Delete(int maDuAn)
        {
            try
            {
                var duAn = db.DuAns.FirstOrDefault(x => x.MaDuAn == maDuAn);
                if (duAn == null)
                    throw new Exception($"Không tìm thấy dự án với mã {maDuAn}");

                // Kiểm tra xem có chi tiết dự án nào không
                var hasChiTiet = db.ChiTietDuAns.Any(x => x.MaDuAn == maDuAn);
                if (hasChiTiet)
                    throw new Exception($"Không thể xóa dự án {maDuAn} vì đang có nhân viên tham gia");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.DuAns.Remove(duAn);
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
                throw new Exception($"Lỗi xóa dự án: {ex.Message}");
            }
        }

        public DuAn Update(DuAn da)
        {
            try
            {
                ValidateDuAn(da);

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var existingDuAn = db.DuAns.FirstOrDefault(x => x.MaDuAn == da.MaDuAn);
                        if (existingDuAn == null)
                            throw new Exception($"Không tìm thấy dự án với mã {da.MaDuAn}");

                        existingDuAn.TenDuAn = da.TenDuAn;
                        existingDuAn.NgayBatDau = da.NgayBatDau;
                        existingDuAn.NgayKetThuc = da.NgayKetThuc;
                        existingDuAn.NganSach = da.NganSach;
                        existingDuAn.TrangThai = da.TrangThai;
                        existingDuAn.MoTa = da.MoTa;

                        db.SaveChanges();
                        transaction.Commit();
                        return existingDuAn;
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
                throw new Exception($"Lỗi cập nhật dự án: {ex.Message}");
            }
        }

        private void ValidateDuAn(DuAn da)
        {
            if (da == null)
                throw new ArgumentNullException(nameof(da), "Dữ liệu dự án không được để trống");

            if (da.MaDuAn <= 0)
                throw new Exception("Mã dự án không hợp lệ");

            if (string.IsNullOrEmpty(da.TenDuAn))
                throw new Exception("Tên dự án không được để trống");

            if (da.NgayBatDau > da.NgayKetThuc)
                throw new Exception("Ngày bắt đầu không thể sau ngày kết thúc");

            if (da.NganSach <= 0)
                throw new Exception("Ngân sách phải lớn hơn 0");
        }

        public IQueryable<object> GetProjectDetails()
        {
            return from da in db.DuAns
                   select new
                   {
                       da.MaDuAn,
                       da.TenDuAn,
                       da.NgayBatDau,
                       da.NgayKetThuc,
                       da.NganSach,
                       da.TrangThai,
                       da.MoTa,
                       SoLuongNhanVien = da.ChiTietDuAns.Count()
                   };
        }
    }
}
