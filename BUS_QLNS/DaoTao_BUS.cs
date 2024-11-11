using BUS_QLNS.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class DaoTao_BUS : IDaoTao
    {
        private readonly BTLMonLTTQEntities db;

        public DaoTao_BUS()
        {
            db = new BTLMonLTTQEntities();
        }

        public DaoTao GetItem(int MaDaoTao)
        {
            return db.DaoTaos.FirstOrDefault(x => x.MaDaoTao == MaDaoTao);
        }

        public List<DaoTao> GetList()
        {
            return db.DaoTaos.ToList();
        }

        public DaoTao Add(DaoTao dt)
        {
            try
            {
                ValidateDaoTao(dt);

                var exists = db.DaoTaos.FirstOrDefault(x => x.MaDaoTao == dt.MaDaoTao);
                if (exists != null)
                    throw new Exception($"Mã khóa đào tạo {dt.MaDaoTao} đã tồn tại");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.DaoTaos.Add(dt);
                        db.SaveChanges();
                        transaction.Commit();
                        return dt;
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
                throw new Exception($"Lỗi thêm khóa đào tạo: {ex.Message}");
            }
        }

        public void Delete(int MaDaoTao)
        {
            try
            {
                var daoTao = db.DaoTaos.FirstOrDefault(x => x.MaDaoTao == MaDaoTao);
                if (daoTao == null)
                    throw new Exception($"Không tìm thấy khóa đào tạo với mã {MaDaoTao}");

                // Kiểm tra xem có chi tiết khóa đào tạo nào không
                var hasChiTiet = db.ChiTietKhoaDaoTaos.Any(x => x.MaDaoTao == MaDaoTao);
                if (hasChiTiet)
                    throw new Exception($"Không thể xóa khóa đào tạo {MaDaoTao} vì đang có nhân viên tham gia");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.DaoTaos.Remove(daoTao);
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
                throw new Exception($"Lỗi xóa khóa đào tạo: {ex.Message}");
            }
        }

        public DaoTao Update(DaoTao dt)
        {
            try
            {
                ValidateDaoTao(dt);

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var existingDaoTao = db.DaoTaos.FirstOrDefault(x => x.MaDaoTao == dt.MaDaoTao);
                        if (existingDaoTao == null)
                            throw new Exception($"Không tìm thấy khóa đào tạo với mã {dt.MaDaoTao}");

                        existingDaoTao.TenKhoa = dt.TenKhoa;
                        existingDaoTao.NgayBatDau = dt.NgayBatDau;
                        existingDaoTao.NgayKetThuc = dt.NgayKetThuc;
                        existingDaoTao.ChiPhi = dt.ChiPhi;
                        existingDaoTao.NoiDung = dt.NoiDung;

                        db.SaveChanges();
                        transaction.Commit();
                        return existingDaoTao;
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
                throw new Exception($"Lỗi cập nhật khóa đào tạo: {ex.Message}");
            }
        }

        private void ValidateDaoTao(DaoTao dt)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt), "Dữ liệu khóa đào tạo không được để trống");

            if (dt.MaDaoTao <= 0)
                throw new Exception("Mã khóa đào tạo không hợp lệ");

            if (string.IsNullOrEmpty(dt.TenKhoa))
                throw new Exception("Tên khóa đào tạo không được để trống");

            if (dt.NgayBatDau > dt.NgayKetThuc)
                throw new Exception("Ngày bắt đầu không thể sau ngày kết thúc");

            if (dt.ChiPhi <= 0)
                throw new Exception("Chi phí phải lớn hơn 0");
        }

        public List<object> GetDaoTaoDetails()
        {
            return (from dt in db.DaoTaos
                    select new
                    {
                        dt.MaDaoTao,
                        dt.TenKhoa,
                        dt.NgayBatDau,
                        dt.NgayKetThuc,
                        dt.ChiPhi,
                        dt.NoiDung,
                        SoLuongNhanVien = dt.ChiTietKhoaDaoTaos.Count()
                    }).ToList<object>();
        }

        public List<object> GetDaoTaoMembers(int MaDaoTao)
        {
            return (from ctdt in db.ChiTietKhoaDaoTaos
                    join nv in db.NhanViens on ctdt.MaNhanVien equals nv.MaNhanVien
                    where ctdt.MaDaoTao == MaDaoTao
                    select new
                    {
                        nv.MaNhanVien,
                        nv.HoTen,
                        ctdt.DanhGiaKhoa,
                    }).ToList<object>();
        }

        public NhanVien GetNhanVien(int maNhanVien)
        {
            return db.NhanViens.FirstOrDefault(x => x.MaNhanVien == maNhanVien);
        }

        public List<object> GetAvailableNhanVien(int MaDaoTao)
        {
            return (from nv in db.NhanViens
                    where !db.ChiTietKhoaDaoTaos.Any(x =>
                        x.MaDaoTao == MaDaoTao && x.MaNhanVien == nv.MaNhanVien)
                    select new
                    {
                        nv.MaNhanVien,
                        nv.HoTen,
                        nv.ChucVu.TenChucVu,
                        nv.PhongBan.TenPhongBan
                    }).ToList<object>();
        }
    }
}
