using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS.Interface
{
    public interface IBangCongNhanVienChiTiet_BUS
    {
        BANGCONG_NHANVIEN_CHITIET getItem(int makycong, int manv, int ngay);

        // Lấy kỳ công theo tháng và năm
        BANGCONG_NHANVIEN_CHITIET LayKyCongTheoThangNam(int thang, int nam);

        // Thêm mới bảng công chi tiết
        BANGCONG_NHANVIEN_CHITIET Add(BANGCONG_NHANVIEN_CHITIET bcct);

        // Cập nhật bảng công chi tiết
        BANGCONG_NHANVIEN_CHITIET Update(BANGCONG_NHANVIEN_CHITIET bcct);

        // Tính tổng ngày phép
        double tongNgayPhep(int makycong, int manv);

        // Tính tổng ngày công
        double tongNgayCong(int makycong, int manv);

    }
}
