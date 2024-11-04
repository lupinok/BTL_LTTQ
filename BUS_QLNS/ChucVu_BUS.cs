using BUS_QLNS.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class ChucVu_BUS : IChucVu_BUS
    {
        private readonly BTLMonLTTQEntities db;

        public ChucVu_BUS()
        {
            db = new BTLMonLTTQEntities();
        }

        public ChucVu GetItem(int MaChucVu)
        {
            return db.ChucVus.FirstOrDefault(x => x.MaChucVu == MaChucVu);
        }

        public List<ChucVu> GetList()
        {
            return db.ChucVus.ToList();
        }

        public ChucVu Add(ChucVu cv)
        {
            try
            {
                ValidateChucVu(cv);

                var exists = db.ChucVus.FirstOrDefault(x => x.MaChucVu == cv.MaChucVu);
                if (exists != null)
                    throw new Exception($"Mã chức vụ {cv.MaChucVu} đã tồn tại");

                db.ChucVus.Add(cv);
                db.SaveChanges();
                return cv;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thêm chức vụ: {ex.Message}");
            }
        }
        public void Delete(int maChucVu)
        {
            try
            {
                var chucVu = db.ChucVus.FirstOrDefault(x => x.MaChucVu == maChucVu);
                if (chucVu == null)
                    throw new Exception($"Không tìm thấy chức vụ với mã {maChucVu}");

                // Kiểm tra xem có nhân viên nào đang giữ chức vụ này không
                var hasNhanVien = db.NhanViens.Any(x => x.MaChucVu == maChucVu);
                if (hasNhanVien)
                    throw new Exception($"Không thể xóa chức vụ {maChucVu} vì đang có nhân viên giữ chức vụ này");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.ChucVus.Remove(chucVu);
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
        public ChucVu Update(ChucVu cv)
        {
            try
            {
                ValidateChucVu(cv);

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var existingChucVu = db.ChucVus.FirstOrDefault(x => x.MaChucVu == cv.MaChucVu);
                        if (existingChucVu == null)
                            throw new Exception($"Không tìm thấy chức vụ với mã {cv.MaChucVu}");

                        existingChucVu.TenChucVu = cv.TenChucVu;

                        db.SaveChanges();
                        transaction.Commit();
                        return existingChucVu;
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
                throw new Exception($"Lỗi cập nhật chức vụ: {ex.Message}");
            }
        }

        private void ValidateChucVu(ChucVu cv)
        {
            if (cv == null)
                throw new ArgumentNullException(nameof(cv), "Dữ liệu chức vụ không được để trống");

            if (cv.MaChucVu <= 0)
                throw new Exception("Mã chức vụ không được để trống");

            if (string.IsNullOrEmpty(cv.TenChucVu))
                throw new Exception("Tên chức vụ không được để trống");
        }
        public bool IsTenChucVuExists(string tenChucVu)
        {
            return db.ChucVus.Any(x => x.TenChucVu.Trim().ToLower() == tenChucVu.Trim().ToLower());
        }
    }
}
