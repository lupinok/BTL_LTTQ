using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS.Interface
{
    public interface IDaoTao
    {
        // Lấy thông tin một khóa đào tạo
        DaoTao GetItem(int MaDaoTao);

        // Lấy danh sách tất cả khóa đào tạo
        List<DaoTao> GetList();

        // Thêm khóa đào tạo mới
        DaoTao Add(DaoTao dt);

        // Cập nhật thông tin khóa đào tạo
        DaoTao Update(DaoTao dt);

        // Xóa khóa đào tạo
        void Delete(int MaDaoTao);

        // Lấy chi tiết khóa đào tạo với số lượng nhân viên
        List<object> GetDaoTaoDetails();

        // Lấy danh sách nhân viên trong khóa đào tạo
        List<object> GetDaoTaoMembers(int MaDaoTao);

        // Lấy thông tin nhân viên
        NhanVien GetNhanVien(int maNhanVien);

        // Lấy danh sách nhân viên có thể thêm vào khóa đào tạo
        List<object> GetAvailableNhanVien(int MaDaoTao);
    }
}
