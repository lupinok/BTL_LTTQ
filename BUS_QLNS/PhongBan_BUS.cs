using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class PhongBan_BUS
    {
        private readonly BTLMonLTTQEntities db;

        public PhongBan_BUS()
        {
            db = new BTLMonLTTQEntities();
        }

        public PhongBan GetItem(int MaPhongBan)
        {
            return db.PhongBans.FirstOrDefault(x => x.MaPhongBan == MaPhongBan);
        }

        public List<PhongBan> GetList()
        {
            return db.PhongBans.ToList();
        }

        public PhongBan Add(PhongBan pb)
        {
            try
            {
                ValidatePhongBan(pb);

                var exists = db.PhongBans.FirstOrDefault(x => x.MaPhongBan == pb.MaPhongBan);
                if (exists != null)
                    throw new Exception($"Mã phòng ban {pb.MaPhongBan} đã tồn tại");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.PhongBans.Add(pb);

                        // Cập nhật MAPHONGBAN cho trưởng phòng mới
                        if (!string.IsNullOrEmpty(pb.TruongPhong) && pb.TruongPhong != "Chưa có trưởng phòng")
                        {
                            var nhanVien = db.NhanViens.FirstOrDefault(x => x.HoTen == pb.TruongPhong);
                            if (nhanVien != null)
                            {
                                nhanVien.MaPhongBan = pb.MaPhongBan;
                            }
                        }

                        db.SaveChanges();
                        UpdateEmployeeCount(pb.MaPhongBan);
                        transaction.Commit();
                        return pb;
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
                throw new Exception($"Lỗi thêm phòng ban: {ex.Message}");
            }
        }
        public void Delete(int maPhongBan)
        {
            try
            {
                var phongBan = db.PhongBans.FirstOrDefault(x => x.MaPhongBan == maPhongBan);
                if (phongBan == null)
                    throw new Exception($"Không tìm thấy phòng ban với mã {maPhongBan}");

                // Kiểm tra xem có nhân viên nào đang giữ chức vụ này không
                var hasNhanVien = db.NhanViens.Any(x => x.MaPhongBan == maPhongBan);
                if (hasNhanVien)
                    throw new Exception($"Không thể xóa phòng ban {maPhongBan} vì đang có nhân viên giữ chức vụ này");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.PhongBans.Remove(phongBan);
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
                throw new Exception($"Lỗi xóa chức vụ: {ex.Message}");
            }
        }

        public PhongBan Update(PhongBan pb)
        {
            try
            {
                ValidatePhongBan(pb);

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var existingPhongBan = db.PhongBans.FirstOrDefault(x => x.MaPhongBan == pb.MaPhongBan);
                        if (existingPhongBan == null)
                            throw new Exception($"Không tìm thấy phòng ban với mã {pb.MaPhongBan}");

                        existingPhongBan.TenPhongBan = pb.TenPhongBan;

                        db.SaveChanges();
                        transaction.Commit();
                        return existingPhongBan;
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
                throw new Exception($"Lỗi cập nhật phòng ban: {ex.Message}");
            }
        }
        public IQueryable<object> GetDepartmentDetails()
        {
            return from bp in db.BoPhans
                   join pb in db.PhongBans on bp.MaPhongBan equals pb.MaPhongBan
                   join nv in db.NhanViens on pb.TruongPhong equals nv.MaNhanVien.ToString() into truongPhongInfo
                   from tp in truongPhongInfo.DefaultIfEmpty()
                   select new
                   {
                       pb.MaPhongBan,
                       pb.TenPhongBan,
                       SoLuongNhanVien = db.NhanViens.Count(nv => nv.MaPhongBan == pb.MaPhongBan),
                       TruongPhong = tp != null ? tp.HoTen : "Chưa có trưởng phòng",
                       MaTruongPhong = pb.TruongPhong
                   };
        }

        private void UpdateEmployeeCount(int maPhongBan)
        {
            var phongBan = db.PhongBans.FirstOrDefault(x => x.MaPhongBan == maPhongBan);
            if (phongBan != null)
            {
                phongBan.SoLuongNhanVien = db.NhanViens.Count(x => x.MaPhongBan == maPhongBan);
                db.SaveChanges();
            }
        }
        private void ValidatePhongBan(PhongBan pb)
        {
            if (pb == null)
                throw new ArgumentNullException(nameof(pb), "Dữ liệu phòng ban không được để trống");

            if (pb.MaPhongBan <= 0)
                throw new Exception("Mã phòng ban không được để trống");

            if (string.IsNullOrEmpty(pb.TenPhongBan))
                throw new Exception("Tên phòng ban không được để trống");
            // Kiểm tra tên trưởng phòng có tồn tại trong bảng nhân viên không
            if (!string.IsNullOrEmpty(pb.TruongPhong) && pb.TruongPhong != "Chưa có trưởng phòng")
            {
                var nhanVienExists = db.NhanViens.Any(x => x.HoTen.Equals(pb.TruongPhong.Trim(),
                    StringComparison.OrdinalIgnoreCase));
                if (!nhanVienExists)
                    throw new Exception($"Tên trưởng phòng '{pb.TruongPhong}' không tồn tại trong danh sách nhân viên");
            }
        }
        public List<string> GetEmployeeNames()
        {
            // Lấy danh sách nhân viên chưa thuộc phòng ban nào (MAPHONGBAN là null)
            return db.NhanViens
                .Where(x => x.MaPhongBan == null)
                .Select(x => x.HoTen)
                .ToList();
        }

        // Thêm phương thức để lấy tên nhân viên hiện tại của phòng ban (dùng cho trường hợp sửa)
        public string GetCurrentTruongPhong(int maPhongBan)
        {
            var phongBan = db.PhongBans.FirstOrDefault(x => x.MaPhongBan == maPhongBan);
            return phongBan?.TruongPhong;
        }
    }
}
