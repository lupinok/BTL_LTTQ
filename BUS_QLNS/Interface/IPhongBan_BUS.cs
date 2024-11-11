using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS.Interface
{
    public interface IPhongBan_BUS
    {
        // Lấy thông tin một phòng ban
        PhongBan GetItem(int MaPhongBan);

        // Lấy danh sách tất cả phòng ban
        List<PhongBan> GetList();

        // Thêm phòng ban mới
        PhongBan Add(PhongBan pb);

        // Xóa phòng ban
        void Delete(int maPhongBan);

        // Cập nhật thông tin phòng ban
        PhongBan Update(PhongBan pb);

        // Lấy chi tiết phòng ban (join với bộ phận và nhân viên)
        IQueryable<object> GetDepartmentDetails();

        // Lấy danh sách tên nhân viên chưa thuộc phòng ban nào
        List<string> GetEmployeeNames();

        // Lấy tên trưởng phòng hiện tại
        string GetCurrentTruongPhong(int maPhongBan);
    }
}
