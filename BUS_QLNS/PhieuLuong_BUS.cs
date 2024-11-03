﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;
namespace BUS_QLNS
{
    public class PhieuLuong_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public PhieuLuong getItem(int mpc)
        {
            return db.PhieuLuongs.FirstOrDefault(x => x.MaPhieuLuong == mpc);
        }
        public List<PhieuLuong> getList()
        {
            return db.PhieuLuongs.ToList();
        }
        public List<PhieuLuong> LayPhieuLuongTheoThang(int thang, int nam)
        {
            try
            {
                return db.PhieuLuongs
                    .Where(x => SqlFunctions.DatePart("month", x.create_date) == thang
                            && SqlFunctions.DatePart("year", x.create_date) == nam)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy phiếu lương: " + ex.Message);
            }
        }
        public void XoaPhieuLuongTheoThang(int thang, int nam)
        {
            try
            {
                var dsPhieuLuong = db.PhieuLuongs
                    .Where(x => SqlFunctions.DatePart("month", x.create_date) == thang
                            && SqlFunctions.DatePart("year", x.create_date) == nam)
                    .ToList();

                if (dsPhieuLuong.Any())
                {
                    db.PhieuLuongs.RemoveRange(dsPhieuLuong);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa phiếu lương: " + ex.Message);
            }
        }
        public void ThemPhieuLuong(PhieuLuong pl)
        {
            try
            {
                db.PhieuLuongs.Add(pl);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm phiếu lương: " + ex.Message);
            }
        }
        public PhieuLuong Add(PhieuLuong pl)
        {
            try
            {
                var exists = db.PhieuLuongs.FirstOrDefault(x =>
                    
                    SqlFunctions.DatePart("month", x.create_date) == SqlFunctions.DatePart("month", pl.create_date) &&
                    SqlFunctions.DatePart("month", x.create_date) == SqlFunctions.DatePart("month", pl.create_date));
                    
                if (exists != null)
                {
                    if (exists != null)
                    {
                        // Nếu đã tồn tại thì xóa bản ghi cũ
                        db.PhieuLuongs.Remove(exists);
                        db.SaveChanges();
                    }
                }
                
                 db.PhieuLuongs.Add(pl);
                db.SaveChanges();
                return pl;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public void Delete(int mpc)
        {
            try
            {
                var _lc = db.PhieuLuongs.FirstOrDefault(x => x.MaPhieuLuong == mpc);
                if (_lc != null)
                {
                    db.PhieuLuongs.Remove(_lc);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa PhieuLuongs: {ex.Message}");
            }
        }
        public bool KiemTraDaTinhLuong(int thang, int nam)
        {
            return db.PhieuLuongs.Any(x => SqlFunctions.DatePart("month", x.create_date) == thang
                                        && SqlFunctions.DatePart("year", x.create_date) == nam);
        }
        private int LayMaPhieuLuong(int thang, int nam)
        {
            try
            {
                // Tạo mã phiếu lương theo format: NămTháng
                // Ví dụ: 202401 cho tháng 1 năm 2024
                return int.Parse($"{nam}{thang:D2}");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tạo mã phiếu lương: " + ex.Message);
            }
        }
        public List<PhieuLuong> TinhLuong(int thang, int nam)
        {
            try
            {
                var result = new List<PhieuLuong>();
                var ngayTao = new DateTime(nam, thang, 1);
                var dsNhanVien = db.NhanViens.ToList();


                // Tạo một transaction để đảm bảo tất cả nhân viên được tính lương cùng lúc
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Tạo một phiếu lương đầu tiên để lấy mã tự động
                        var phieuLuongDau = new PhieuLuong
                        {
                            MaNhanVien = dsNhanVien.First().MaNhanVien,
                            create_date = ngayTao
                        };
                        db.PhieuLuongs.Add(phieuLuongDau);
                        db.SaveChanges();

                        // Lấy mã phiếu lương vừa được tạo
                        var maPhieuLuong = phieuLuongDau.MaPhieuLuong;

                        // Cập nhật thông tin cho phiếu lương đầu tiên
                        TinhLuongChoNhanVien(phieuLuongDau, dsNhanVien.First(), thang, nam);
                        db.SaveChanges();

                        // Tính lương cho các nhân viên còn lại
                        foreach (var nv in dsNhanVien.Skip(1))
                        {
                            var luong = new PhieuLuong
                            {
                                MaNhanVien = nv.MaNhanVien,
                                HoTen = nv.HoTen,
                                NgayTinhLuong = DateTime.Now,
                                create_date = ngayTao
                            };

                            TinhLuongChoNhanVien(luong, nv, thang, nam);
                            db.PhieuLuongs.Add(luong);
                        }

                        db.SaveChanges();
                        transaction.Commit();

                        // Lấy lại danh sách phiếu lương để trả về
                        result = LayPhieuLuongTheoThang(thang, nam);
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tính lương: " + ex.Message);
            }
        }
        private void TinhLuongChoNhanVien(PhieuLuong luong, NhanVien nv, int thang, int nam)
        {
            // Lấy lương cơ bản từ chức vụ
            var chucVu = db.ChucVus.FirstOrDefault(x => x.MaChucVu == nv.MaChucVu);
            luong.LuongCoBan = chucVu.LuongChucVu;

            luong.TangCa = db.TangCas
                .Where(x => x.MaNhanVien == nv.MaNhanVien
                    && SqlFunctions.DatePart("month", x.create_date) == thang
                    && SqlFunctions.DatePart("year", x.create_date) == nam)
                .Sum(x => x.SoTien) ?? 0;

            // Tính phụ cấp
            luong.PhuCap = db.PhuCaps
                .Where(x => x.MaNhanVien == nv.MaNhanVien
                && x.Thang == thang && x.Nam == nam)
                .Sum(x => x.SoTien) ?? 0;

            // Tính ứng lương
            luong.UngLuong = db.UngLuongs
                .Where(x => x.MaNhanVien == nv.MaNhanVien
                     && x.Thang == thang && x.Nam == nam)
                .Sum(x => x.SoTien) ?? 0;

            // Tính ngày công
            luong.NgayCong = 30;

            // Tính khen thưởng/kỷ luật
            luong.KTKL = db.ChiTietKT_KL
                .Where(x => x.MaNhanVien == nv.MaNhanVien
                    && SqlFunctions.DatePart("month", x.NgayBatDau) == thang
                    && SqlFunctions.DatePart("year", x.NgayKetThuc) == nam)
                .Sum(x => x.TienThuongPhat) ?? 0;


            // Tính lương thực nhận
            luong.LuongNhanDuoc = luong.LuongCoBan + luong.TangCa + luong.PhuCap
                + luong.KTKL - luong.UngLuong;
        }
        //public List<PhieuLuong> TinhLuong(int thang, int nam)
        //{
        //    try
        //    {
        //        var result = new List<PhieuLuong>();
        //        var ngayTao = new DateTime(nam, thang, 1);
        //        var dsNhanVien = db.NhanViens.ToList();
        //        var maPhieuLuong = LayMaPhieuLuong(thang, nam);
        //        foreach (var nv in dsNhanVien)
        //        {
        //            var luong = new PhieuLuong();

        //            // Thông tin cơ bản
        //            luong.MaPhieuLuong = maPhieuLuong;
        //            luong.MaNhanVien = nv.MaNhanVien;
        //            luong.HoTen = nv.HoTen;
        //            luong.NgayTinhLuong = DateTime.Now;
        //            luong.create_date = ngayTao;


        //            // Lấy lương cơ bản từ chức vụ
        //            var chucVu = db.ChucVus.FirstOrDefault(x => x.MaChucVu == nv.MaChucVu);
        //            luong.LuongCoBan = chucVu.LuongChucVu;

        //            // Tính tăng ca trong tháng
        //            luong.TangCa = db.TangCas
        //                .Where(x => x.MaNhanVien == nv.MaNhanVien
        //                    && SqlFunctions.DatePart("month", x.create_date) == thang
        //                    && SqlFunctions.DatePart("year", x.create_date) == nam)
        //                .Sum(x => x.SoTien) ?? 0;

        //            // Tính phụ cấp
        //            luong.PhuCap = db.PhuCaps
        //                .Where(x => x.MaNhanVien == nv.MaNhanVien 
        //                && x.Thang == thang && x.Nam == nam)
        //                .Sum(x => x.SoTien) ?? 0;

        //            // Tính ứng lương
        //            luong.UngLuong = db.UngLuongs
        //                .Where(x => x.MaNhanVien == nv.MaNhanVien
        //                     && x.Thang == thang && x.Nam == nam)
        //                .Sum(x => x.SoTien) ?? 0;

        //            // Tính ngày công
        //            luong.NgayCong = 30;

        //            // Tính khen thưởng/kỷ luật
        //            luong.KTKL = db.ChiTietKT_KL
        //                .Where(x => x.MaNhanVien == nv.MaNhanVien
        //                    && SqlFunctions.DatePart("month", x.NgayBatDau) == thang
        //                    && SqlFunctions.DatePart("year", x.NgayKetThuc) ==nam)
        //                .Sum(x => x.TienThuongPhat) ?? 0;


        //            // Tính lương thực nhận
        //            luong.LuongNhanDuoc = luong.LuongCoBan + luong.TangCa + luong.PhuCap
        //                + luong.KTKL - luong.UngLuong;

        //            result.Add(luong);
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi tính lương: " + ex.Message);
        //    }
        //}


    }
}