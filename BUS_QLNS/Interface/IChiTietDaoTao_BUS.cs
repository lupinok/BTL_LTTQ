using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS.Interface
{
    public interface IChiTietDaoTao_BUS
    {
        // Lấy danh sách tất cả chi tiết đào tạo
        List<ChiTietKhoaDaoTao> GetList();

        // Lấy danh sách chi tiết theo mã đào tạo
        List<ChiTietKhoaDaoTao> GetByDaoTao(int maDaoTao);

        // Lấy một chi tiết đào tạo cụ thể
        ChiTietKhoaDaoTao GetItem(int maDaoTao, int maNhanVien);

        // Thêm chi tiết đào tạo mới
        ChiTietKhoaDaoTao Add(ChiTietKhoaDaoTao ctdt);

        // Cập nhật chi tiết đào tạo
        ChiTietKhoaDaoTao Update(ChiTietKhoaDaoTao ctdt);

        // Xóa chi tiết đào tạo
        void Delete(int maDaoTao, int maNhanVien);

        // Lấy chi tiết đào tạo với thông tin nhân viên
        List<object> GetChiTietDaoTaoDetails(int maDaoTao);

        // Lấy danh sách đánh giá
        List<string> GetDanhGiaList();

        // Lấy thông tin nhân viên
        NhanVien GetNhanVien(int maNhanVien);
    }
}
