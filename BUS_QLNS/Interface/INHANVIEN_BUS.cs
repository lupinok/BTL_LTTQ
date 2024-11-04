using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS.Interface
{
    public interface INHANVIEN_BUS
    {
        // Lấy thông tin một nhân viên
        NhanVien getItem(int manhanvien);

        // Lấy danh sách tất cả nhân viên
        List<NhanVien> getList();

        // Lấy tên nhân viên theo mã
        string getTenNV(int mnv);

        // Thêm nhân viên mới
        NhanVien Add(NhanVien nv);

        // Cập nhật thông tin nhân viên
        NhanVien Update(NhanVien nv);

        // Xóa nhân viên
        void Delete(int manhanvien);

        // Lấy danh sách phòng ban
        List<PhongBan> getListPhongBan();

        // Lấy danh sách chức vụ theo phòng ban
        List<ChucVu> getListChucVuByPhongBan(int maPhongBan);

        // Lấy danh sách nhân viên theo phòng ban
        List<NhanVien> getListByPhongBan(int maPhongBan);
    }
}
