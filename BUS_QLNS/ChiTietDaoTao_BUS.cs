using BUS_QLNS.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class ChiTietDaoTao_BUS : IChiTietDaoTao_BUS
    {
        private readonly BTLMonLTTQEntities db;

        public ChiTietDaoTao_BUS()
        {
            db = new BTLMonLTTQEntities();
        }

        public List<ChiTietKhoaDaoTao> GetList()
        {
            return db.ChiTietKhoaDaoTaos.ToList();
        }

        public List<ChiTietKhoaDaoTao> GetByDaoTao(int maDaoTao)
        {
            return db.ChiTietKhoaDaoTaos.Where(x => x.MaDaoTao == maDaoTao).ToList();
        }

        public ChiTietKhoaDaoTao GetItem(int maDaoTao, int maNhanVien)
        {
            return db.ChiTietKhoaDaoTaos.FirstOrDefault(x =>
                x.MaDaoTao == maDaoTao && x.MaNhanVien == maNhanVien);
        }

        public ChiTietKhoaDaoTao Add(ChiTietKhoaDaoTao ctdt)
        {
            try
            {
                ValidateChiTietDaoTao(ctdt);

                var exists = db.ChiTietKhoaDaoTaos.FirstOrDefault(x =>
                    x.MaDaoTao == ctdt.MaDaoTao && x.MaNhanVien == ctdt.MaNhanVien);

                if (exists != null)
                    throw new Exception("Nhân viên này đã tham gia khóa đào tạo");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.ChiTietKhoaDaoTaos.Add(ctdt);
                        db.SaveChanges();
                        transaction.Commit();
                        return ctdt;
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
                throw new Exception($"Lỗi thêm chi tiết đào tạo: {ex.Message}");
            }
        }

        public void Delete(int maDaoTao, int maNhanVien)
        {
            try
            {
                var ctdt = db.ChiTietKhoaDaoTaos.FirstOrDefault(x =>
                    x.MaDaoTao == maDaoTao && x.MaNhanVien == maNhanVien);

                if (ctdt == null)
                    throw new Exception("Không tìm thấy chi tiết đào tạo");

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.ChiTietKhoaDaoTaos.Remove(ctdt);
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
                throw new Exception($"Lỗi xóa chi tiết đào tạo: {ex.Message}");
            }
        }

        public ChiTietKhoaDaoTao Update(ChiTietKhoaDaoTao ctdt)
        {
            try
            {
                ValidateChiTietDaoTao(ctdt);

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var existing = db.ChiTietKhoaDaoTaos.FirstOrDefault(x =>
                            x.MaDaoTao == ctdt.MaDaoTao && x.MaNhanVien == ctdt.MaNhanVien);

                        if (existing == null)
                            throw new Exception("Không tìm thấy chi tiết đào tạo");

                        existing.ThoiGianDuKien = ctdt.ThoiGianDuKien;
                        existing.DanhGiaKhoa = ctdt.DanhGiaKhoa;

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
                throw new Exception($"Lỗi cập nhật chi tiết đào tạo: {ex.Message}");
            }
        }

        private void ValidateChiTietDaoTao(ChiTietKhoaDaoTao ctdt)
        {
            if (ctdt == null)
                throw new ArgumentNullException(nameof(ctdt), "Dữ liệu chi tiết đào tạo không được để trống");

            if (ctdt.MaDaoTao <= 0)
                throw new Exception("Mã đào tạo không hợp lệ");

            if (ctdt.MaNhanVien <= 0)
                throw new Exception("Mã nhân viên không hợp lệ");

            if (ctdt.ThoiGianDuKien <= 0)
                throw new Exception("Thời gian dự kiến phải lớn hơn 0");

            // Kiểm tra khóa đào tạo có tồn tại không
            var daoTao = db.ChiTietKhoaDaoTaos.FirstOrDefault(x => x.MaDaoTao == ctdt.MaDaoTao);
            if (daoTao == null)
                throw new Exception($"Không tìm thấy khóa đào tạo với mã {ctdt.MaDaoTao}");

            // Kiểm tra nhân viên có tồn tại không
            var nhanVien = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == ctdt.MaNhanVien);
            if (nhanVien == null)
                throw new Exception($"Không tìm thấy nhân viên với mã {ctdt.MaNhanVien}");
        }

        public List<object> GetChiTietDaoTaoDetails(int maDaoTao)
        {
            return (from ctdt in db.ChiTietKhoaDaoTaos
                    join nv in db.NhanViens on ctdt.MaNhanVien equals nv.MaNhanVien
                    where ctdt.MaDaoTao == maDaoTao
                    select new
                    {
                        ctdt.MaDaoTao,
                        ctdt.MaNhanVien,
                        nv.HoTen,
                        ctdt.ThoiGianDuKien,
                        ctdt.DanhGiaKhoa
                    }).ToList<object>();
        }

        public List<string> GetDanhGiaList()
        {
            return new List<string>
            {
                "Xuất sắc",
                "Tốt",
                "Khá",
                "Trung bình",
                "Yếu"
            };
        }

        public NhanVien GetNhanVien(int maNhanVien)
        {
            return db.NhanViens.FirstOrDefault(x => x.MaNhanVien == maNhanVien);
        }
    }
}