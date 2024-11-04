using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS.Interface
{
    public interface IChiTietDuAn_BUS
    {
        // Lấy danh sách tất cả chi tiết dự án
        List<ChiTietDuAn> GetList();

        // Lấy danh sách chi tiết theo mã dự án
        List<ChiTietDuAn> GetByDuAn(int maDuAn);

        // Lấy một chi tiết dự án cụ thể
        ChiTietDuAn GetItem(int maDuAn, int maNhanVien);

        // Thêm chi tiết dự án mới
        ChiTietDuAn Add(ChiTietDuAn ctda);

        // Cập nhật chi tiết dự án
        ChiTietDuAn Update(ChiTietDuAn ctda);

        // Xóa chi tiết dự án
        void Delete(int maDuAn, int maNhanVien);

        // Lấy chi tiết dự án với thông tin nhân viên
        List<object> GetChiTietDuAnDetails(int maDuAn);

        // Lấy danh sách nhân viên có thể thêm vào dự án
        List<object> GetAvailableNhanVien(int maDuAn);

        // Lấy danh sách vai trò
        List<string> GetVaiTroList();

        // Lấy thông tin nhân viên
        NhanVien GetNhanVien(int maNhanVien);
    }
}
