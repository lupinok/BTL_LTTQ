using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class DCNHANVIEN_BUS
    {
        private readonly BTLMonLTTQEntities db;

        public DCNHANVIEN_BUS()
        {
            db = new BTLMonLTTQEntities();
        }

        public List<dynamic> GetList()
        {
            try
            {
                using (var db = new BTLMonLTTQEntities())
                {
                    var list = (from dc in db.NhanVien_DieuChuyen
                                join nv in db.NhanViens on dc.MaNhanVien equals nv.MaNhanVien
                                join pb1 in db.PhongBans on dc.MaPhongBan equals pb1.MaPhongBan
                                join pb2 in db.PhongBans on dc.MaPhongBan2 equals pb2.MaPhongBan
                                select new
                                {
                                    dc.SoDC,
                                    nv.HoTen,
                                    dc.Ngay,
                                    TenPhongBan = pb1.TenPhongBan,  // Phòng ban trước
                                    TenPhongBan2 = pb2.TenPhongBan, // Phòng ban sau
                                    dc.LyDoDC,
                                    dc.GhiChuDC,
                                    dc.MaNhanVien,
                                    dc.MaPhongBan,
                                    dc.MaPhongBan2
                                }).ToList<dynamic>();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public NhanVien_DieuChuyen Add(NhanVien_DieuChuyen dc)
        {
            try
            {
                ValidateDieuChuyen(dc);

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Lấy phòng ban hiện tại của nhân viên
                        var nhanVien = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == dc.MaNhanVien);
                        if (nhanVien != null)
                        {
                            // Lưu mã phòng ban và chức vụ cũ vào bản ghi điều chuyển
                            dc.MaPhongBan = nhanVien.MaPhongBan;
                            dc.MaChucVu = nhanVien.MaChucVu;

                            // Thêm lịch sử điều chuyển
                            db.NhanVien_DieuChuyen.Add(dc);

                            // Cập nhật phòng ban và chức vụ mới cho nhân viên
                            nhanVien.MaPhongBan = dc.MaPhongBan2;
                            nhanVien.MaChucVu = dc.MaChucVu2;
                        }

                        db.SaveChanges();
                        transaction.Commit();
                        return dc;
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
                throw new Exception($"Lỗi điều chuyển nhân viên: {ex.Message}");
            }
        }

        private void ValidateDieuChuyen(NhanVien_DieuChuyen dc)
        {
            if (dc.MaNhanVien == null)
                throw new Exception("Chưa chọn nhân viên");

            if (dc.MaPhongBan2 == null)
                throw new Exception("Chưa chọn phòng ban mới");

            if (dc.MaPhongBan == dc.MaPhongBan2)
                throw new Exception("Phòng ban mới phải khác phòng ban hiện tại");

            if (string.IsNullOrWhiteSpace(dc.LyDoDC))
                throw new Exception("Chưa nhập lý do điều chuyển");
        }

        public void DeleteAll()
        {
            try
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Xóa toàn bộ dữ liệu trong bảng điều chuyển
                        var allRecords = db.NhanVien_DieuChuyen.ToList();
                        db.NhanVien_DieuChuyen.RemoveRange(allRecords);
                        db.SaveChanges();
                        // Reset identity về 1
                        db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('NhanVien_DieuChuyen', RESEED, 0)");
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
                throw new Exception($"Lỗi xóa dữ liệu: {ex.Message}");
            }
        }

        public void Update(NhanVien_DieuChuyen dc)
        {
            try
            {
                ValidateDieuChuyen(dc);

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var existingDC = db.NhanVien_DieuChuyen.Find(dc.SoDC);
                        if (existingDC != null)
                        {
                            // Cập nhật thông tin điều chuyển
                            existingDC.Ngay = dc.Ngay;
                            existingDC.MaPhongBan2 = dc.MaPhongBan2;
                            existingDC.LyDoDC = dc.LyDoDC;
                            existingDC.GhiChuDC = dc.GhiChuDC;

                            // Cập nhật phòng ban mới cho nhân viên
                            var nhanVien = db.NhanViens.Find(dc.MaNhanVien);
                            if (nhanVien != null)
                            {
                                nhanVien.MaPhongBan = dc.MaPhongBan2;
                            }

                            db.SaveChanges();
                            transaction.Commit();
                        }
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
                throw new Exception($"Lỗi cập nhật điều chuyển: {ex.Message}");
            }
        }

        public List<NhanVien> GetListNhanVien()
        {
            using (var db = new BTLMonLTTQEntities())
            {
                return db.NhanViens.ToList();
            }
        }

        public List<PhongBan> GetListPhongBan()
        {
            using (var db = new BTLMonLTTQEntities())
            {
                return db.PhongBans.ToList();
            }
        }
        public List<ChucVu> getListChucVuByPhongBan(int maPhongBan)
        {
            string prefix = maPhongBan.ToString() + "0";
            return db.ChucVus.Where(x => x.MaChucVu.ToString().StartsWith(prefix)).ToList();
        }

        public List<PhongBan> GetListPhongBanExcept(int maPhongBan)
        {
            using (var db = new BTLMonLTTQEntities())
            {
                return db.PhongBans.Where(p => p.MaPhongBan != maPhongBan).ToList();
            }
        }

        public NhanVien GetNhanVien(int maNV)
        {
            using (var db = new BTLMonLTTQEntities())
            {
                return db.NhanViens.Find(maNV);
            }
        }
    }
}

